using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software.TrnSalesInvoice
{
    public partial class TrnSalesInvoiceDetailSearchItemForm : Form
    {
        public TrnSalesInvoiceDetailForm trnSalesInvoiceDetailForm;
        public Entities.TrnSalesInvoiceEntity trnSalesInvoiceEntity;

        public static Int32 pageSize = 50;

        public static List<Entities.DgvSearchInventoryItemEntity> searchInventoryItemData = new List<Entities.DgvSearchInventoryItemEntity>();
        public static Int32 SearchInventoryItemPageNumber = 1;
        public PagedList<Entities.DgvSearchInventoryItemEntity> searchInventoryItemPageList = new PagedList<Entities.DgvSearchInventoryItemEntity>(searchInventoryItemData, SearchInventoryItemPageNumber, pageSize);
        public BindingSource searchInventoryItemDataSource = new BindingSource();

        public static List<Entities.DgvSearchNonInventoryItemEntity> searchNonInventoryItemData = new List<Entities.DgvSearchNonInventoryItemEntity>();
        public static Int32 SearchNonInventoryItemPageNumber = 1;
        public PagedList<Entities.DgvSearchNonInventoryItemEntity> searchNonInventoryItemPageList = new PagedList<Entities.DgvSearchNonInventoryItemEntity>(searchNonInventoryItemData, SearchNonInventoryItemPageNumber, pageSize);
        public BindingSource searchNonInventoryItemDataSource = new BindingSource();

        public static List<Entities.DgvSalesInvoiceItemEntitySalesOrderitemEntity> salesOrderItemData = new List<Entities.DgvSalesInvoiceItemEntitySalesOrderitemEntity>();
        public static Int32 salesOrdertemPageNumber = 1;
        public static Int32 stockOutItemPageSize = 50;
        public PagedList<Entities.DgvSalesInvoiceItemEntitySalesOrderitemEntity> salesOrderItemPageSize = new PagedList<Entities.DgvSalesInvoiceItemEntitySalesOrderitemEntity>(salesOrderItemData, salesOrdertemPageNumber, stockOutItemPageSize);
        public BindingSource salesOrderItemDataSource = new BindingSource();

        public TrnSalesInvoiceDetailSearchItemForm(TrnSalesInvoiceDetailForm salesInvoiceDetailForm, Entities.TrnSalesInvoiceEntity salesInvoiceEntity)
        {
            InitializeComponent();

            trnSalesInvoiceDetailForm = salesInvoiceDetailForm;
            trnSalesInvoiceEntity = salesInvoiceEntity;

            CreateSearchInventoryItemDataGridView();
            CreateSearchNonInventoryItemDataGridView();
            GetSONumberList(trnSalesInvoiceEntity.CustomerId);
        }

        public void UpdateSearchInventoryItemDataSource()
        {
            SetSearchInventoryItemDataSourceAsync();
        }

        public async void SetSearchInventoryItemDataSourceAsync()
        {
            List<Entities.DgvSearchInventoryItemEntity> getSearchInventoryItemData = await GetSearchInventoryItemDataTask();
            if (getSearchInventoryItemData.Any())
            {
                SearchInventoryItemPageNumber = 1;
                searchInventoryItemData = getSearchInventoryItemData;
                searchInventoryItemPageList = new PagedList<Entities.DgvSearchInventoryItemEntity>(searchInventoryItemData, SearchInventoryItemPageNumber, pageSize);

                if (searchInventoryItemPageList.PageCount == 1)
                {
                    buttonSearchInventoryItemPageListFirst.Enabled = false;
                    buttonSearchInventoryItemPageListPrevious.Enabled = false;
                    buttonSearchInventoryItemPageListNext.Enabled = false;
                    buttonSearchInventoryItemPageListLast.Enabled = false;
                }
                else if (SearchInventoryItemPageNumber == 1)
                {
                    buttonSearchInventoryItemPageListFirst.Enabled = false;
                    buttonSearchInventoryItemPageListPrevious.Enabled = false;
                    buttonSearchInventoryItemPageListNext.Enabled = true;
                    buttonSearchInventoryItemPageListLast.Enabled = true;
                }
                else if (SearchInventoryItemPageNumber == searchInventoryItemPageList.PageCount)
                {
                    buttonSearchInventoryItemPageListFirst.Enabled = true;
                    buttonSearchInventoryItemPageListPrevious.Enabled = true;
                    buttonSearchInventoryItemPageListNext.Enabled = false;
                    buttonSearchInventoryItemPageListLast.Enabled = false;
                }
                else
                {
                    buttonSearchInventoryItemPageListFirst.Enabled = true;
                    buttonSearchInventoryItemPageListPrevious.Enabled = true;
                    buttonSearchInventoryItemPageListNext.Enabled = true;
                    buttonSearchInventoryItemPageListLast.Enabled = true;
                }

                textBoxSearchInventoryItemPageNumber.Text = SearchInventoryItemPageNumber + " / " + searchInventoryItemPageList.PageCount;
                searchInventoryItemDataSource.DataSource = searchInventoryItemPageList;
            }
            else
            {
                buttonSearchInventoryItemPageListFirst.Enabled = false;
                buttonSearchInventoryItemPageListPrevious.Enabled = false;
                buttonSearchInventoryItemPageListNext.Enabled = false;
                buttonSearchInventoryItemPageListLast.Enabled = false;

                SearchInventoryItemPageNumber = 1;

                searchInventoryItemData = new List<Entities.DgvSearchInventoryItemEntity>();
                searchInventoryItemDataSource.Clear();
                textBoxSearchInventoryItemPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvSearchInventoryItemEntity>> GetSearchInventoryItemDataTask()
        {
            String filter = textBoxSearchInventoryItemFilter.Text;
            Controllers.TrnSalesInvoiceItemController trnSalesInvoiceItemController = new Controllers.TrnSalesInvoiceItemController();

            List<Entities.MstArticleInventory> listSearchInventoryItem = trnSalesInvoiceItemController.ListInventoryItem(filter);
            if (listSearchInventoryItem.Any())
            {
                var items = from d in listSearchInventoryItem
                            select new Entities.DgvSearchInventoryItemEntity
                            {
                                ColumnSearchInventoryId = d.Id,
                                ColumnSearchInventoryItemInventoryCode = d.InventoryCode,
                                ColumnSearchInventoryItemId = d.ArticleId,
                                ColumnSearchInventoryItemBarCode = d.ArticleBarCode,
                                ColumnSearchInventoryItemDescription = d.Article,
                                ColumnSearchInventoryItemUnitId = d.UnitId,
                                ColumnSearchInventoryItemUnit = d.Unit,
                                ColumnSearchInventoryItemQuantity = d.Quantity.ToString("#,##0.00"),
                                ColumnSearchInventoryItemPrice = d.DefaultPrice.ToString("#,##0.00"),
                                ColumnSearchInventoryItemButtonPick = "Pick",
                                ColumnSearchInventoryItemVATOutTaxId = d.VATOutTaxId,
                                ColumnSearchInventoryItemVATOutTaxRate = d.VATOutTaxRate.ToString("#,##0.00"),
                                ColumnSearchInventoryItemSpace = ""
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvSearchInventoryItemEntity>());
            }
        }

        public void CreateSearchInventoryItemDataGridView()
        {
            UpdateSearchInventoryItemDataSource();

            dataGridViewSearchInventoryItem.Columns[dataGridViewSearchInventoryItem.Columns["ColumnSearchInventoryItemButtonPick"].Index].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSearchInventoryItem.Columns[dataGridViewSearchInventoryItem.Columns["ColumnSearchInventoryItemButtonPick"].Index].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSearchInventoryItem.Columns[dataGridViewSearchInventoryItem.Columns["ColumnSearchInventoryItemButtonPick"].Index].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewSearchInventoryItem.DataSource = searchInventoryItemDataSource;
        }

        public void GetSearchInventoryItemCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewSearchInventoryItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewSearchInventoryItem.CurrentCell.ColumnIndex == dataGridViewSearchInventoryItem.Columns["ColumnSearchInventoryItemButtonPick"].Index)
            {
                var SIId = trnSalesInvoiceEntity.Id;
                var itemId = Convert.ToInt32(dataGridViewSearchInventoryItem.Rows[e.RowIndex].Cells[dataGridViewSearchInventoryItem.Columns["ColumnSearchInventoryItemId"].Index].Value);
                var itemDescription = dataGridViewSearchInventoryItem.Rows[e.RowIndex].Cells[dataGridViewSearchInventoryItem.Columns["ColumnSearchInventoryItemDescription"].Index].Value.ToString();
                var itemInventoryId = Convert.ToInt32(dataGridViewSearchInventoryItem.Rows[e.RowIndex].Cells[dataGridViewSearchInventoryItem.Columns["ColumnSearchInventoryId"].Index].Value);
                var unitId = Convert.ToInt32(dataGridViewSearchInventoryItem.Rows[e.RowIndex].Cells[dataGridViewSearchInventoryItem.Columns["ColumnSearchInventoryItemUnitId"].Index].Value);
                var unit = dataGridViewSearchInventoryItem.Rows[e.RowIndex].Cells[dataGridViewSearchInventoryItem.Columns["ColumnSearchInventoryItemUnit"].Index].Value.ToString();
                var price = Convert.ToDecimal(dataGridViewSearchInventoryItem.Rows[e.RowIndex].Cells[dataGridViewSearchInventoryItem.Columns["ColumnSearchInventoryItemPrice"].Index].Value);
                var taxId = Convert.ToInt32(dataGridViewSearchInventoryItem.Rows[e.RowIndex].Cells[dataGridViewSearchInventoryItem.Columns["ColumnSearchInventoryItemVATOutTaxId"].Index].Value);
                var taxRate = Convert.ToDecimal(dataGridViewSearchInventoryItem.Rows[e.RowIndex].Cells[dataGridViewSearchInventoryItem.Columns["ColumnSearchInventoryItemVATOutTaxRate"].Index].Value);

                Entities.TrnSalesInvoiceItemEntity trnSalesInvoiceItemEntity = new Entities.TrnSalesInvoiceItemEntity()
                {
                    SIId = SIId,
                    ItemId = itemId,
                    ItemDescription = itemDescription,
                    ItemInventoryId = itemInventoryId,
                    UnitId = unitId,
                    Price = price,
                    DiscountId = 2,
                    DiscountRate = 0,
                    DiscountAmount = 0,
                    NetPrice = price,
                    Quantity = 0,
                    Amount = 0,
                    TaxId = taxId,
                    TaxRate = taxRate,
                    TaxAmount = 0,
                    BaseQuantity = 0,
                    BasePrice = price
                };

                TrnSalesInvoiceDetailSalesInvoiceItemDetailForm trnSalesInvoiceDetailSalesInvoiceItemDetailForm = new TrnSalesInvoiceDetailSalesInvoiceItemDetailForm(trnSalesInvoiceDetailForm, trnSalesInvoiceItemEntity);
                trnSalesInvoiceDetailSalesInvoiceItemDetailForm.ShowDialog();
            }
        }

        private void textBoxSearchInventoryItemFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateSearchInventoryItemDataSource();
                SearchInventoryItemPageNumber = 1;
            }
        }

        private void buttonSearchInventoryItemPageListFirst_Click(object sender, EventArgs e)
        {
            searchInventoryItemPageList = new PagedList<Entities.DgvSearchInventoryItemEntity>(searchInventoryItemData, 1, pageSize);
            searchInventoryItemDataSource.DataSource = searchInventoryItemPageList;

            buttonSearchInventoryItemPageListFirst.Enabled = false;
            buttonSearchInventoryItemPageListPrevious.Enabled = false;
            buttonSearchInventoryItemPageListNext.Enabled = true;
            buttonSearchInventoryItemPageListLast.Enabled = true;

            SearchInventoryItemPageNumber = 1;
            textBoxSearchInventoryItemPageNumber.Text = SearchInventoryItemPageNumber + " / " + searchInventoryItemPageList.PageCount;
        }

        private void buttonSearchInventoryItemPageListPrevious_Click(object sender, EventArgs e)
        {
            if (searchInventoryItemPageList.HasPreviousPage == true)
            {
                searchInventoryItemPageList = new PagedList<Entities.DgvSearchInventoryItemEntity>(searchInventoryItemData, --SearchInventoryItemPageNumber, pageSize);
                searchInventoryItemDataSource.DataSource = searchInventoryItemPageList;
            }

            buttonSearchInventoryItemPageListNext.Enabled = true;
            buttonSearchInventoryItemPageListLast.Enabled = true;

            if (SearchInventoryItemPageNumber == 1)
            {
                buttonSearchInventoryItemPageListFirst.Enabled = false;
                buttonSearchInventoryItemPageListPrevious.Enabled = false;
            }

            textBoxSearchInventoryItemPageNumber.Text = SearchInventoryItemPageNumber + " / " + searchInventoryItemPageList.PageCount;
        }

        private void buttonSearchInventoryItemPageListNext_Click(object sender, EventArgs e)
        {
            if (searchInventoryItemPageList.HasNextPage == true)
            {
                searchInventoryItemPageList = new PagedList<Entities.DgvSearchInventoryItemEntity>(searchInventoryItemData, ++SearchInventoryItemPageNumber, pageSize);
                searchInventoryItemDataSource.DataSource = searchInventoryItemPageList;
            }

            buttonSearchInventoryItemPageListFirst.Enabled = true;
            buttonSearchInventoryItemPageListPrevious.Enabled = true;

            if (SearchInventoryItemPageNumber == searchInventoryItemPageList.PageCount)
            {
                buttonSearchInventoryItemPageListNext.Enabled = false;
                buttonSearchInventoryItemPageListLast.Enabled = false;
            }

            textBoxSearchInventoryItemPageNumber.Text = SearchInventoryItemPageNumber + " / " + searchInventoryItemPageList.PageCount;
        }

        private void buttonSearchInventoryItemPageListLast_Click(object sender, EventArgs e)
        {
            searchInventoryItemPageList = new PagedList<Entities.DgvSearchInventoryItemEntity>(searchInventoryItemData, searchInventoryItemPageList.PageCount, pageSize);
            searchInventoryItemDataSource.DataSource = searchInventoryItemPageList;

            buttonSearchInventoryItemPageListFirst.Enabled = true;
            buttonSearchInventoryItemPageListPrevious.Enabled = true;
            buttonSearchInventoryItemPageListNext.Enabled = false;
            buttonSearchInventoryItemPageListLast.Enabled = false;

            SearchInventoryItemPageNumber = searchInventoryItemPageList.PageCount;
            textBoxSearchInventoryItemPageNumber.Text = SearchInventoryItemPageNumber + " / " + searchInventoryItemPageList.PageCount;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void UpdateSearchNonInventoryItemDataSource()
        {
            SetSearchNonInventoryItemDataSourceAsync();
        }

        public async void SetSearchNonInventoryItemDataSourceAsync()
        {
            List<Entities.DgvSearchNonInventoryItemEntity> getSearchNonInventoryItemData = await GetSearchNonInventoryItemDataTask();
            if (getSearchNonInventoryItemData.Any())
            {
                SearchNonInventoryItemPageNumber = 1;
                searchNonInventoryItemData = getSearchNonInventoryItemData;
                searchNonInventoryItemPageList = new PagedList<Entities.DgvSearchNonInventoryItemEntity>(searchNonInventoryItemData, SearchNonInventoryItemPageNumber, pageSize);

                if (searchNonInventoryItemPageList.PageCount == 1)
                {
                    buttonSearchNonInventoryItemPageListFirst.Enabled = false;
                    buttonSearchNonInventoryItemPageListPrevious.Enabled = false;
                    buttonSearchNonInventoryItemPageListNext.Enabled = false;
                    buttonSearchNonInventoryItemPageListLast.Enabled = false;
                }
                else if (SearchNonInventoryItemPageNumber == 1)
                {
                    buttonSearchNonInventoryItemPageListFirst.Enabled = false;
                    buttonSearchNonInventoryItemPageListPrevious.Enabled = false;
                    buttonSearchNonInventoryItemPageListNext.Enabled = true;
                    buttonSearchNonInventoryItemPageListLast.Enabled = true;
                }
                else if (SearchNonInventoryItemPageNumber == searchNonInventoryItemPageList.PageCount)
                {
                    buttonSearchNonInventoryItemPageListFirst.Enabled = true;
                    buttonSearchNonInventoryItemPageListPrevious.Enabled = true;
                    buttonSearchNonInventoryItemPageListNext.Enabled = false;
                    buttonSearchNonInventoryItemPageListLast.Enabled = false;
                }
                else
                {
                    buttonSearchNonInventoryItemPageListFirst.Enabled = true;
                    buttonSearchNonInventoryItemPageListPrevious.Enabled = true;
                    buttonSearchNonInventoryItemPageListNext.Enabled = true;
                    buttonSearchNonInventoryItemPageListLast.Enabled = true;
                }

                textBoxSearchNonInventoryItemPageNumber.Text = SearchNonInventoryItemPageNumber + " / " + searchNonInventoryItemPageList.PageCount;
                searchNonInventoryItemDataSource.DataSource = searchNonInventoryItemPageList;
            }
            else
            {
                buttonSearchNonInventoryItemPageListFirst.Enabled = false;
                buttonSearchNonInventoryItemPageListPrevious.Enabled = false;
                buttonSearchNonInventoryItemPageListNext.Enabled = false;
                buttonSearchNonInventoryItemPageListLast.Enabled = false;

                SearchNonInventoryItemPageNumber = 1;

                searchNonInventoryItemData = new List<Entities.DgvSearchNonInventoryItemEntity>();
                searchNonInventoryItemDataSource.Clear();
                textBoxSearchNonInventoryItemPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvSearchNonInventoryItemEntity>> GetSearchNonInventoryItemDataTask()
        {
            String filter = textBoxSearchNonInventoryItemFilter.Text;
            Controllers.TrnSalesInvoiceItemController trnSalesInvoiceItemController = new Controllers.TrnSalesInvoiceItemController();

            List<Entities.MstArticleEntity> listSearchNonInventoryItem = trnSalesInvoiceItemController.ListNonInventoryItem(filter);
            if (listSearchNonInventoryItem.Any())
            {
                var items = from d in listSearchNonInventoryItem
                            select new Entities.DgvSearchNonInventoryItemEntity
                            {
                                ColumnSearchNonInventoryItemId = d.Id,
                                ColumnSearchNonInventoryItemBarCode = d.ArticleBarCode,
                                ColumnSearchNonInventoryItemDescription = d.Article,
                                ColumnSearchNonInventoryItemUnitId = d.UnitId,
                                ColumnSearchNonInventoryItemUnit = d.Unit,
                                ColumnSearchNonInventoryItemPrice = d.DefaultPrice.ToString("#,##0.00"),
                                ColumnSearchNonInventoryVATOutTaxId = d.VATOutTaxId,
                                ColumnSearchNonInventoryVATOutTaxRate = d.VATOutTaxRate.ToString("#,##0.00"),
                                ColumnSearchNonInventoryItemButtonPick = "Pick"
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvSearchNonInventoryItemEntity>());
            }
        }

        public void CreateSearchNonInventoryItemDataGridView()
        {
            UpdateSearchNonInventoryItemDataSource();

            dataGridViewSearchNonInventoryItem.Columns[dataGridViewSearchNonInventoryItem.Columns["ColumnSearchNonInventoryItemButtonPick"].Index].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSearchNonInventoryItem.Columns[dataGridViewSearchNonInventoryItem.Columns["ColumnSearchNonInventoryItemButtonPick"].Index].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSearchNonInventoryItem.Columns[dataGridViewSearchNonInventoryItem.Columns["ColumnSearchNonInventoryItemButtonPick"].Index].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewSearchNonInventoryItem.DataSource = searchNonInventoryItemDataSource;
        }

        public void GetSearchNonInventoryItemCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewSearchNonInventoryItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewSearchNonInventoryItem.CurrentCell.ColumnIndex == dataGridViewSearchNonInventoryItem.Columns["ColumnSearchNonInventoryItemButtonPick"].Index)
            {
                var SIId = trnSalesInvoiceEntity.Id;
                var itemId = Convert.ToInt32(dataGridViewSearchNonInventoryItem.Rows[e.RowIndex].Cells[dataGridViewSearchNonInventoryItem.Columns["ColumnSearchNonInventoryItemId"].Index].Value);
                var itemDescription = dataGridViewSearchNonInventoryItem.Rows[e.RowIndex].Cells[dataGridViewSearchNonInventoryItem.Columns["ColumnSearchNonInventoryItemDescription"].Index].Value.ToString();
                var unitId = Convert.ToInt32(dataGridViewSearchNonInventoryItem.Rows[e.RowIndex].Cells[dataGridViewSearchNonInventoryItem.Columns["ColumnSearchNonInventoryItemUnitId"].Index].Value);
                var unit = dataGridViewSearchNonInventoryItem.Rows[e.RowIndex].Cells[dataGridViewSearchNonInventoryItem.Columns["ColumnSearchNonInventoryItemUnit"].Index].Value.ToString();
                var price = Convert.ToDecimal(dataGridViewSearchNonInventoryItem.Rows[e.RowIndex].Cells[dataGridViewSearchNonInventoryItem.Columns["ColumnSearchNonInventoryItemPrice"].Index].Value);
                var taxId = Convert.ToInt32(dataGridViewSearchNonInventoryItem.Rows[e.RowIndex].Cells[dataGridViewSearchNonInventoryItem.Columns["ColumnSearchNonInventoryVATOutTaxId"].Index].Value);
                var taxRate = Convert.ToDecimal(dataGridViewSearchNonInventoryItem.Rows[e.RowIndex].Cells[dataGridViewSearchNonInventoryItem.Columns["ColumnSearchNonInventoryVATOutTaxRate"].Index].Value);

                Entities.TrnSalesInvoiceItemEntity trnSalesInvoiceItemEntity = new Entities.TrnSalesInvoiceItemEntity()
                {
                    SIId = SIId,
                    ItemId = itemId,
                    ItemDescription = itemDescription,
                    ItemInventoryId = null,
                    UnitId = unitId,
                    Price = price,
                    DiscountId = 2,
                    DiscountRate = 0,
                    DiscountAmount = 0,
                    NetPrice = price,
                    Quantity = 0,
                    Amount = 0,
                    TaxId = taxId,
                    TaxRate = taxRate,
                    TaxAmount = 0,
                    BaseQuantity = 0,
                    BasePrice = price
                };

                TrnSalesInvoiceDetailSalesInvoiceItemDetailForm trnSalesInvoiceDetailSalesInvoiceItemDetailForm = new TrnSalesInvoiceDetailSalesInvoiceItemDetailForm(trnSalesInvoiceDetailForm, trnSalesInvoiceItemEntity);
                trnSalesInvoiceDetailSalesInvoiceItemDetailForm.ShowDialog();
            }
        }

        private void textBoxSearchNonInventoryItemFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateSearchNonInventoryItemDataSource();
                SearchNonInventoryItemPageNumber = 1;
            }
        }

        private void buttonSearchNonInventoryItemPageListFirst_Click(object sender, EventArgs e)
        {
            searchNonInventoryItemPageList = new PagedList<Entities.DgvSearchNonInventoryItemEntity>(searchNonInventoryItemData, 1, pageSize);
            searchNonInventoryItemDataSource.DataSource = searchNonInventoryItemPageList;

            buttonSearchNonInventoryItemPageListFirst.Enabled = false;
            buttonSearchNonInventoryItemPageListPrevious.Enabled = false;
            buttonSearchNonInventoryItemPageListNext.Enabled = true;
            buttonSearchNonInventoryItemPageListLast.Enabled = true;

            SearchNonInventoryItemPageNumber = 1;
            textBoxSearchNonInventoryItemPageNumber.Text = SearchNonInventoryItemPageNumber + " / " + searchNonInventoryItemPageList.PageCount;
        }

        private void buttonSearchNonInventoryItemPageListPrevious_Click(object sender, EventArgs e)
        {
            if (searchNonInventoryItemPageList.HasPreviousPage == true)
            {
                searchNonInventoryItemPageList = new PagedList<Entities.DgvSearchNonInventoryItemEntity>(searchNonInventoryItemData, --SearchNonInventoryItemPageNumber, pageSize);
                searchNonInventoryItemDataSource.DataSource = searchNonInventoryItemPageList;
            }

            buttonSearchNonInventoryItemPageListNext.Enabled = true;
            buttonSearchNonInventoryItemPageListLast.Enabled = true;

            if (SearchNonInventoryItemPageNumber == 1)
            {
                buttonSearchNonInventoryItemPageListFirst.Enabled = false;
                buttonSearchNonInventoryItemPageListPrevious.Enabled = false;
            }

            textBoxSearchNonInventoryItemPageNumber.Text = SearchNonInventoryItemPageNumber + " / " + searchNonInventoryItemPageList.PageCount;
        }

        private void buttonSearchNonInventoryItemPageListNext_Click(object sender, EventArgs e)
        {
            if (searchNonInventoryItemPageList.HasNextPage == true)
            {
                searchNonInventoryItemPageList = new PagedList<Entities.DgvSearchNonInventoryItemEntity>(searchNonInventoryItemData, ++SearchNonInventoryItemPageNumber, pageSize);
                searchNonInventoryItemDataSource.DataSource = searchNonInventoryItemPageList;
            }

            buttonSearchNonInventoryItemPageListFirst.Enabled = true;
            buttonSearchNonInventoryItemPageListPrevious.Enabled = true;

            if (SearchNonInventoryItemPageNumber == searchNonInventoryItemPageList.PageCount)
            {
                buttonSearchNonInventoryItemPageListNext.Enabled = false;
                buttonSearchNonInventoryItemPageListLast.Enabled = false;
            }

            textBoxSearchNonInventoryItemPageNumber.Text = SearchNonInventoryItemPageNumber + " / " + searchNonInventoryItemPageList.PageCount;
        }

        private void buttonSearchNonInventoryItemPageListLast_Click(object sender, EventArgs e)
        {
            searchNonInventoryItemPageList = new PagedList<Entities.DgvSearchNonInventoryItemEntity>(searchNonInventoryItemData, searchNonInventoryItemPageList.PageCount, pageSize);
            searchNonInventoryItemDataSource.DataSource = searchNonInventoryItemPageList;

            buttonSearchNonInventoryItemPageListFirst.Enabled = true;
            buttonSearchNonInventoryItemPageListPrevious.Enabled = true;
            buttonSearchNonInventoryItemPageListNext.Enabled = false;
            buttonSearchNonInventoryItemPageListLast.Enabled = false;

            SearchNonInventoryItemPageNumber = searchNonInventoryItemPageList.PageCount;
            textBoxSearchNonInventoryItemPageNumber.Text = SearchNonInventoryItemPageNumber + " / " + searchNonInventoryItemPageList.PageCount;
        }

        public void GetSONumberList(Int32 customerId)
        {
            Controllers.TrnSalesInvoiceItemController trnSalesInvoiceItemController = new Controllers.TrnSalesInvoiceItemController();
            var salesOrderList = trnSalesInvoiceItemController.ListSalesOrder(customerId);
            if (salesOrderList.Any())
            {
                comboBoxSONumber.DataSource = salesOrderList;
                comboBoxSONumber.DisplayMember = "SONumber";
                comboBoxSONumber.ValueMember = "Id";

                CreateSalesOrderItemDataGridView();
            }
        }

        public Task<List<Entities.DgvSalesInvoiceItemEntitySalesOrderitemEntity>> GetSalesOrderItemDataTask()
        {
            Controllers.TrnSalesInvoiceItemController trnSalesInvoiceItemController = new Controllers.TrnSalesInvoiceItemController();
            var SOId = Convert.ToInt32(comboBoxSONumber.SelectedValue);
            var stringFilter = textBoxSearchSalesOrderItemFilter.Text;
            List<Entities.TrnSalesOrderItemEntity> listSalesOrderItem = trnSalesInvoiceItemController.ListSalesOrderItem(SOId, trnSalesInvoiceEntity.CustomerId);
            if (listSalesOrderItem.Any())
            {
                var items = from d in listSalesOrderItem
                            where d.BarCode.Contains(stringFilter)
                            || d.ItemDescription.Contains(stringFilter)
                            select new Entities.DgvSalesInvoiceItemEntitySalesOrderitemEntity
                            {
                                ColumnTrnSalesOrderItemListId = d.Id,
                                ColumnTrnSalesOrderItemListSOId = d.SOId,
                                ColumnTrnSalesOrderItemListBarCode = d.BarCode,
                                ColumnTrnSalesOrderItemListItemId = d.ItemId,
                                ColumnTrnSalesOrderItemListItemDescription = d.ItemDescription,
                                ColumnTrnSalesOrderItemListItemInventoryId = d.ItemInventoryId,
                                ColumnTrnSalesOrderItemListItemInventoryCode = d.ItemInventoryCode,
                                ColumnTrnSalesOrderItemListUnitId = d.UnitId,
                                ColumnTrnSalesOrderItemListUnit = d.Unit,
                                ColumnTrnSalesOrderItemListPrice = d.Price.ToString("#,##0.00"),
                                ColumnTrnSalesOrderItemListDiscountId = d.DiscountId,
                                ColumnTrnSalesOrderItemListDiscount = d.Discount,
                                ColumnTrnSalesOrderItemListDiscountRate = d.DiscountRate.ToString("#,##0.00"),
                                ColumnTrnSalesOrderItemListDiscountAmount = d.DiscountAmount.ToString("#,##0.00"),
                                ColumnTrnSalesOrderItemListNetPrice = d.NetPrice.ToString("#,##0.00"),
                                ColumnTrnSalesOrderItemListQuantity = d.Quantity.ToString("#,##0.00"),
                                ColumnTrnSalesOrderItemListAmount = d.Amount.ToString("#,##0.00"),
                                ColumnTrnSalesOrderItemListTaxId = d.TaxId,
                                ColumnTrnSalesOrderItemListTax = d.Tax,
                                ColumnTrnSalesOrderItemListTaxRate = d.TaxRate.ToString("#,##0.00"),
                                ColumnTrnSalesOrderItemListTaxAmount = d.TaxAmount.ToString("#,##0.00"),
                                ColumnSalesOrderItemListPick = "Pick"
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvSalesInvoiceItemEntitySalesOrderitemEntity>());
            }
        }

        public async void SetStockOutItemDataSourceAsync()
        {
            List<Entities.DgvSalesInvoiceItemEntitySalesOrderitemEntity> getStockOutItemData = await GetSalesOrderItemDataTask();
            if (getStockOutItemData.Any())
            {
                salesOrderItemData = getStockOutItemData;
                salesOrderItemPageSize = new PagedList<Entities.DgvSalesInvoiceItemEntitySalesOrderitemEntity>(salesOrderItemData, salesOrdertemPageNumber, stockOutItemPageSize);

                if (salesOrderItemPageSize.PageCount == 1)
                {
                    buttonSalesOrderItemPageListFirst.Enabled = false;
                    buttonSalesOrderItemPageListPrevious.Enabled = false;
                    buttonSalesOrderItemPageListNext.Enabled = false;
                    buttonSalesOrderItemPageListLast.Enabled = false;
                }
                else if (salesOrdertemPageNumber == 1)
                {
                    buttonSalesOrderItemPageListFirst.Enabled = false;
                    buttonSalesOrderItemPageListPrevious.Enabled = false;
                    buttonSalesOrderItemPageListNext.Enabled = true;
                    buttonSalesOrderItemPageListLast.Enabled = true;
                }
                else if (salesOrdertemPageNumber == salesOrderItemPageSize.PageCount)
                {
                    buttonSalesOrderItemPageListFirst.Enabled = true;
                    buttonSalesOrderItemPageListPrevious.Enabled = true;
                    buttonSalesOrderItemPageListNext.Enabled = false;
                    buttonSalesOrderItemPageListLast.Enabled = false;
                }
                else
                {
                    buttonSalesOrderItemPageListFirst.Enabled = true;
                    buttonSalesOrderItemPageListPrevious.Enabled = true;
                    buttonSalesOrderItemPageListNext.Enabled = true;
                    buttonSalesOrderItemPageListLast.Enabled = true;
                }

                textBoxSalesOrderItemPageNumber.Text = salesOrdertemPageNumber + " / " + salesOrderItemPageSize.PageCount;
                salesOrderItemDataSource.DataSource = salesOrderItemPageSize;
            }
            else
            {
                buttonSalesOrderItemPageListFirst.Enabled = false;
                buttonSalesOrderItemPageListPrevious.Enabled = false;
                buttonSalesOrderItemPageListNext.Enabled = false;
                buttonSalesOrderItemPageListLast.Enabled = false;

                salesOrdertemPageNumber = 1;

                salesOrderItemData = new List<Entities.DgvSalesInvoiceItemEntitySalesOrderitemEntity>();
                salesOrderItemDataSource.Clear();
                textBoxSalesOrderItemPageNumber.Text = "1 / 1";
            }
        }


        public void UpdateSalesOrderItemDataSource()
        {
            SetStockOutItemDataSourceAsync();
        }

        public void CreateSalesOrderItemDataGridView()
        {
            UpdateSalesOrderItemDataSource();

            dataGridViewSalesOrderItem.Columns[dataGridViewSalesOrderItem.Columns["ColumnSalesOrderItemListPick"].Index].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSalesOrderItem.Columns[dataGridViewSalesOrderItem.Columns["ColumnSalesOrderItemListPick"].Index].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSalesOrderItem.Columns[dataGridViewSalesOrderItem.Columns["ColumnSalesOrderItemListPick"].Index].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewSalesOrderItem.DataSource = salesOrderItemDataSource;
        }

        public void GetSalesOrderItemCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewSalesOrderItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetSalesOrderItemCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewSalesOrderItem.CurrentCell.ColumnIndex == dataGridViewSalesOrderItem.Columns["ColumnSalesOrderItemListPick"].Index)
            {
                var SIId = trnSalesInvoiceEntity.Id;
                var itemId = Convert.ToInt32(dataGridViewSalesOrderItem.Rows[e.RowIndex].Cells[dataGridViewSalesOrderItem.Columns["ColumnTrnSalesOrderItemListItemId"].Index].Value);
                var itemDescription = dataGridViewSalesOrderItem.Rows[e.RowIndex].Cells[dataGridViewSalesOrderItem.Columns["ColumnTrnSalesOrderItemListItemDescription"].Index].Value.ToString();
                var itemInventoryId = Convert.ToInt32(dataGridViewSalesOrderItem.Rows[e.RowIndex].Cells[dataGridViewSalesOrderItem.Columns["ColumnTrnSalesOrderItemListItemInventoryId"].Index].Value);
                var itemInventoryCode = dataGridViewSalesOrderItem.Rows[e.RowIndex].Cells[dataGridViewSalesOrderItem.Columns["ColumnTrnSalesOrderItemListItemInventoryCode"].Index].Value.ToString();
                var unitId = Convert.ToInt32(dataGridViewSalesOrderItem.Rows[e.RowIndex].Cells[dataGridViewSalesOrderItem.Columns["ColumnTrnSalesOrderItemListUnitId"].Index].Value);
                var unit = dataGridViewSalesOrderItem.Rows[e.RowIndex].Cells[dataGridViewSalesOrderItem.Columns["ColumnTrnSalesOrderItemListUnit"].Index].Value.ToString();
                var price = Convert.ToDecimal(dataGridViewSalesOrderItem.Rows[e.RowIndex].Cells[dataGridViewSalesOrderItem.Columns["ColumnTrnSalesOrderItemListPrice"].Index].Value);
                var discountId = Convert.ToInt32(dataGridViewSalesOrderItem.Rows[e.RowIndex].Cells[dataGridViewSalesOrderItem.Columns["ColumnTrnSalesOrderItemListDiscountId"].Index].Value);
                var discountRate = Convert.ToDecimal(dataGridViewSalesOrderItem.Rows[e.RowIndex].Cells[dataGridViewSalesOrderItem.Columns["ColumnTrnSalesOrderItemListDiscountRate"].Index].Value);
                var discountAmount = Convert.ToDecimal(dataGridViewSalesOrderItem.Rows[e.RowIndex].Cells[dataGridViewSalesOrderItem.Columns["ColumnTrnSalesOrderItemListDiscountAmount"].Index].Value);
                var netPrice = Convert.ToDecimal(dataGridViewSalesOrderItem.Rows[e.RowIndex].Cells[dataGridViewSalesOrderItem.Columns["ColumnTrnSalesOrderItemListNetPrice"].Index].Value);
                var quantity = Convert.ToDecimal(dataGridViewSalesOrderItem.Rows[e.RowIndex].Cells[dataGridViewSalesOrderItem.Columns["ColumnTrnSalesOrderItemListQuantity"].Index].Value);
                var amount = Convert.ToDecimal(dataGridViewSalesOrderItem.Rows[e.RowIndex].Cells[dataGridViewSalesOrderItem.Columns["ColumnTrnSalesOrderItemListAmount"].Index].Value);
                var taxId = Convert.ToInt32(dataGridViewSalesOrderItem.Rows[e.RowIndex].Cells[dataGridViewSalesOrderItem.Columns["ColumnTrnSalesOrderItemListTaxId"].Index].Value);
                var taxRate = Convert.ToDecimal(dataGridViewSalesOrderItem.Rows[e.RowIndex].Cells[dataGridViewSalesOrderItem.Columns["ColumnTrnSalesOrderItemListTaxRate"].Index].Value);
                var taxAmount = Convert.ToDecimal(dataGridViewSalesOrderItem.Rows[e.RowIndex].Cells[dataGridViewSalesOrderItem.Columns["ColumnTrnSalesOrderItemListTaxAmount"].Index].Value);

                Entities.TrnSalesInvoiceItemEntity trnSalesInvoiceItemEntity = new Entities.TrnSalesInvoiceItemEntity()
                {
                    SIId = SIId,
                    ItemId = itemId,
                    ItemDescription = itemDescription,
                    ItemInventoryId = itemInventoryId,
                    UnitId = unitId,
                    Price = price,
                    DiscountId = discountId,
                    DiscountRate = discountRate,
                    DiscountAmount = discountAmount,
                    NetPrice = netPrice,
                    Quantity = quantity,
                    Amount = amount,
                    TaxId = taxId,
                    TaxRate = taxRate,
                    TaxAmount = taxAmount,
                    BaseQuantity = 0,
                    BasePrice = price
                };

                TrnSalesInvoiceDetailSalesInvoiceItemDetailForm trnSalesInvoiceDetailSalesInvoiceItemDetailForm = new TrnSalesInvoiceDetailSalesInvoiceItemDetailForm(trnSalesInvoiceDetailForm, trnSalesInvoiceItemEntity);
                trnSalesInvoiceDetailSalesInvoiceItemDetailForm.ShowDialog();
            }
        }

        private void buttonStockOutItemPageListFirst_Click(object sender, EventArgs e)
        {
            salesOrderItemPageSize = new PagedList<Entities.DgvSalesInvoiceItemEntitySalesOrderitemEntity>(salesOrderItemData, 1, stockOutItemPageSize);
            salesOrderItemDataSource.DataSource = salesOrderItemPageSize;

            buttonSalesOrderItemPageListFirst.Enabled = false;
            buttonSalesOrderItemPageListPrevious.Enabled = false;
            buttonSalesOrderItemPageListNext.Enabled = true;
            buttonSalesOrderItemPageListLast.Enabled = true;

            salesOrdertemPageNumber = 1;
            textBoxSalesOrderItemPageNumber.Text = salesOrdertemPageNumber + " / " + salesOrderItemPageSize.PageCount;
        }

        private void buttonStockOutItemPageListPrevious_Click(object sender, EventArgs e)
        {
            if (salesOrderItemPageSize.HasPreviousPage == true)
            {
                salesOrderItemPageSize = new PagedList<Entities.DgvSalesInvoiceItemEntitySalesOrderitemEntity>(salesOrderItemData, --salesOrdertemPageNumber, stockOutItemPageSize);
                salesOrderItemDataSource.DataSource = salesOrderItemPageSize;
            }

            buttonSalesOrderItemPageListNext.Enabled = true;
            buttonSalesOrderItemPageListLast.Enabled = true;

            if (salesOrdertemPageNumber == 1)
            {
                buttonSalesOrderItemPageListFirst.Enabled = false;
                buttonSalesOrderItemPageListPrevious.Enabled = false;
            }

            textBoxSalesOrderItemPageNumber.Text = salesOrdertemPageNumber + " / " + salesOrderItemPageSize.PageCount;
        }

        private void buttonStockOutItemPageListNext_Click(object sender, EventArgs e)
        {
            if (salesOrderItemPageSize.HasNextPage == true)
            {
                salesOrderItemPageSize = new PagedList<Entities.DgvSalesInvoiceItemEntitySalesOrderitemEntity>(salesOrderItemData, ++salesOrdertemPageNumber, stockOutItemPageSize);
                salesOrderItemDataSource.DataSource = salesOrderItemPageSize;
            }

            buttonSalesOrderItemPageListFirst.Enabled = true;
            buttonSalesOrderItemPageListPrevious.Enabled = true;

            if (salesOrdertemPageNumber == salesOrderItemPageSize.PageCount)
            {
                buttonSalesOrderItemPageListNext.Enabled = false;
                buttonSalesOrderItemPageListLast.Enabled = false;
            }

            textBoxSalesOrderItemPageNumber.Text = salesOrdertemPageNumber + " / " + salesOrderItemPageSize.PageCount;
        }

        private void buttonStockOutItemPageListLast_Click(object sender, EventArgs e)
        {
            salesOrderItemPageSize = new PagedList<Entities.DgvSalesInvoiceItemEntitySalesOrderitemEntity>(salesOrderItemData, salesOrderItemPageSize.PageCount, stockOutItemPageSize);
            salesOrderItemDataSource.DataSource = salesOrderItemPageSize;

            buttonSalesOrderItemPageListFirst.Enabled = true;
            buttonSalesOrderItemPageListPrevious.Enabled = true;
            buttonSalesOrderItemPageListNext.Enabled = false;
            buttonSalesOrderItemPageListLast.Enabled = false;

            salesOrdertemPageNumber = salesOrderItemPageSize.PageCount;
            textBoxSalesOrderItemPageNumber.Text = salesOrdertemPageNumber + " / " + salesOrderItemPageSize.PageCount;
        }

        private void textBoxSearchSalesOrderItemFilter_KeyDown(object sender, KeyEventArgs e)
        {
            UpdateSalesOrderItemDataSource();
        }
    }
}
