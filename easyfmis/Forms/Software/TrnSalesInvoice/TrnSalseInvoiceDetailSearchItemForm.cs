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

        public TrnSalesInvoiceDetailSearchItemForm(TrnSalesInvoiceDetailForm salesInvoiceDetailForm, Entities.TrnSalesInvoiceEntity salesInvoiceEntity)
        {
            InitializeComponent();

            trnSalesInvoiceDetailForm = salesInvoiceDetailForm;
            trnSalesInvoiceEntity = salesInvoiceEntity;

            CreateSearchInventoryItemDataGridView();
            CreateSearchNonInventoryItemDataGridView();
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
                                ColumnSearchInventoryItemQuantity = "0.00",
                                ColumnSearchInventoryItemPrice = d.DefaultPrice.ToString("#,##0.00"),
                                ColumnSearchInventoryItemButtonPick = "Pick",
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

                Entities.TrnSalesInvoiceItemEntity trnSalesInvoiceItemEntity = new Entities.TrnSalesInvoiceItemEntity()
                {
                    SIId = SIId,
                    ItemId = itemId,
                    ItemDescription = itemDescription,
                    ItemInventoryId = itemInventoryId,
                    UnitId = unitId,
                    Price = price,
                    DiscountId = 0,
                    DiscountRate = 0,
                    DiscountAmount = 0,
                    NetPrice = price,
                    Quantity = 0,
                    Amount = 0,
                    TaxId = 0,
                    TaxRate = 0,
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

                Entities.TrnSalesInvoiceItemEntity trnSalesInvoiceItemEntity = new Entities.TrnSalesInvoiceItemEntity()
                {
                    SIId = SIId,
                    ItemId = itemId,
                    ItemDescription = itemDescription,
                    ItemInventoryId = null,
                    UnitId = unitId,
                    Price = price,
                    DiscountId = 0,
                    DiscountRate = 0,
                    DiscountAmount = 0,
                    NetPrice = price,
                    Quantity = 0,
                    Amount = 0,
                    TaxId = 0,
                    TaxRate = 0,
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
    }
}
