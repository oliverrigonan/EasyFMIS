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

namespace easyfmis.Forms.Software.TrnSalesOrder
{
    public partial class TrnSalesOrderDetailSearchItemForm : Form
    {
        public TrnSalesOrderDetailForm trnSalesOrderDetailForm;
        Entities.TrnSalesOrderEntity trnSalesOrderEntity;

        public static List<Entities.DgvSearchInventoryItemEntity> searchInventoryItemData = new List<Entities.DgvSearchInventoryItemEntity>();
        public static Int32 inventoryItemPageNumber = 1;
        public static Int32 inventoryItemPageSize = 50;
        public PagedList<Entities.DgvSearchInventoryItemEntity> searchInventoryItemPageList = new PagedList<Entities.DgvSearchInventoryItemEntity>(searchInventoryItemData, inventoryItemPageNumber, inventoryItemPageSize);
        public BindingSource searchInventoryItemDataSource = new BindingSource();


        public TrnSalesOrderDetailSearchItemForm(TrnSalesOrderDetailForm salesOrderDetailForm, Entities.TrnSalesOrderEntity salesOrderEntity)
        {
            InitializeComponent();

            trnSalesOrderDetailForm = salesOrderDetailForm;
            trnSalesOrderEntity = salesOrderEntity;

            CreateSearchInventoryItemDataGridView();
            CreateSearchNonInventoryItemDataGridView();
        }

        public void UpdateSearchInventoryItemDataSource()
        {
            SetSearchInventoryItemDataSourceAsync();
        }

        public async void SetSearchInventoryItemDataSourceAsync()
        {
            List<Entities.DgvSearchInventoryItemEntity> getSearchItemData = await GetSearchInventoryItemDataTask();
            if (getSearchItemData.Any())
            {
                searchInventoryItemData = getSearchItemData;
                searchInventoryItemPageList = new PagedList<Entities.DgvSearchInventoryItemEntity>(searchInventoryItemData, inventoryItemPageNumber, inventoryItemPageSize);

                if (searchInventoryItemPageList.PageCount == 1)
                {
                    buttonSearchInventoryItemPageListFirst.Enabled = false;
                    buttonSearchInventoryItemPageListPrevious.Enabled = false;
                    buttonSearchInventoryItemPageListNext.Enabled = false;
                    buttonSearchInventoryItemPageListLast.Enabled = false;
                }
                else if (inventoryItemPageNumber == 1)
                {
                    buttonSearchInventoryItemPageListFirst.Enabled = false;
                    buttonSearchInventoryItemPageListPrevious.Enabled = false;
                    buttonSearchInventoryItemPageListNext.Enabled = true;
                    buttonSearchInventoryItemPageListLast.Enabled = true;
                }
                else if (inventoryItemPageNumber == searchInventoryItemPageList.PageCount)
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

                textBoxSearchInventoryItemPageNumber.Text = inventoryItemPageNumber + " / " + searchInventoryItemPageList.PageCount;
                searchInventoryItemDataSource.DataSource = searchInventoryItemPageList;
            }
            else
            {
                buttonSearchInventoryItemPageListFirst.Enabled = false;
                buttonSearchInventoryItemPageListPrevious.Enabled = false;
                buttonSearchInventoryItemPageListNext.Enabled = false;
                buttonSearchInventoryItemPageListLast.Enabled = false;

                inventoryItemPageNumber = 1;

                searchInventoryItemData = new List<Entities.DgvSearchInventoryItemEntity>();
                searchInventoryItemDataSource.Clear();
                textBoxSearchInventoryItemPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvSearchInventoryItemEntity>> GetSearchInventoryItemDataTask()
        {
            String filter = textBoxSearchItemFilter.Text;
            Controllers.TrnSalesOrderItemController trnSalesOrderItemController = new Controllers.TrnSalesOrderItemController();

            List<Entities.MstArticleInventory> listSearchItem = trnSalesOrderItemController.ListInventoryItem(filter);
            if (listSearchItem.Any())
            {
                var items = from d in listSearchItem
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
                                ColumnSearchInventoryItemButtonPick = "Pick"
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

            dataGridViewSearchItemInventory.Columns[dataGridViewSearchItemInventory.Columns["ColumnSearchInventoryItemButtonPick"].Index].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSearchItemInventory.Columns[dataGridViewSearchItemInventory.Columns["ColumnSearchInventoryItemButtonPick"].Index].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSearchItemInventory.Columns[dataGridViewSearchItemInventory.Columns["ColumnSearchInventoryItemButtonPick"].Index].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewSearchItemInventory.DataSource = searchInventoryItemDataSource;
        }

        public void GetSearchInventoryItemCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewSearchInventoryItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewSearchItemInventory.CurrentCell.ColumnIndex == dataGridViewSearchItemInventory.Columns["ColumnSearchInventoryItemButtonPick"].Index)
            {
                var salesOrderId = trnSalesOrderEntity.Id;
                var itemId = Convert.ToInt32(dataGridViewSearchItemInventory.Rows[e.RowIndex].Cells[dataGridViewSearchItemInventory.Columns["ColumnSearchInventoryItemId"].Index].Value);
                var itemDescription = dataGridViewSearchItemInventory.Rows[e.RowIndex].Cells[dataGridViewSearchItemInventory.Columns["ColumnSearchInventoryItemDescription"].Index].Value.ToString();
                var itemInventoryId = Convert.ToInt32(dataGridViewSearchItemInventory.Rows[e.RowIndex].Cells[dataGridViewSearchItemInventory.Columns["ColumnSearchInventoryId"].Index].Value);
                var unitId = Convert.ToInt32(dataGridViewSearchItemInventory.Rows[e.RowIndex].Cells[dataGridViewSearchItemInventory.Columns["ColumnSearchInventoryItemUnitId"].Index].Value);
                var unit = dataGridViewSearchItemInventory.Rows[e.RowIndex].Cells[dataGridViewSearchItemInventory.Columns["ColumnSearchInventoryItemUnit"].Index].Value.ToString();
                var price = dataGridViewSearchItemInventory.Rows[e.RowIndex].Cells[dataGridViewSearchItemInventory.Columns["ColumnSearchInventoryItemPrice"].Index].Value.ToString();

                Entities.TrnSalesOrderItemEntity trnSalesOrderItem = new Entities.TrnSalesOrderItemEntity()
                {
                    SOId = salesOrderId,
                    ItemId = itemId,
                    ItemInventoryId = itemInventoryId,
                    ItemDescription = itemDescription,
                    UnitId = unitId,
                    Price = Convert.ToDecimal(price),
                    DiscountRate = 0,
                    DiscountAmount = 0,
                    NetPrice = 0,
                    Quantity = 0,
                    Amount = 0,
                    TaxRate = 0,
                    TaxAmount = 0,
                    BaseQuantity = 0,
                    BasePrice = 0,
                };

                TrnSalesOrderDetailSalesOrderItemDetailForm trnSalesOrderDetailSalesOrderItemDetailForm = new TrnSalesOrderDetailSalesOrderItemDetailForm(trnSalesOrderDetailForm, trnSalesOrderItem);
                trnSalesOrderDetailSalesOrderItemDetailForm.ShowDialog();
            }
        }

        private void textBoxSearchInventoryItemFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateSearchInventoryItemDataSource();
                inventoryItemPageNumber = 1;
            }
        }

        private void buttonSearchInventoryItemPageListFirst_Click(object sender, EventArgs e)
        {
            searchInventoryItemPageList = new PagedList<Entities.DgvSearchInventoryItemEntity>(searchInventoryItemData, 1, inventoryItemPageSize);
            searchInventoryItemDataSource.DataSource = searchInventoryItemPageList;

            buttonSearchInventoryItemPageListFirst.Enabled = false;
            buttonSearchInventoryItemPageListPrevious.Enabled = false;
            buttonSearchInventoryItemPageListNext.Enabled = true;
            buttonSearchInventoryItemPageListLast.Enabled = true;

            inventoryItemPageNumber = 1;
            textBoxSearchInventoryItemPageNumber.Text = inventoryItemPageNumber + " / " + searchInventoryItemPageList.PageCount;
        }

        private void buttonSearchEnventoryItemPageListPrevious_Click(object sender, EventArgs e)
        {
            if (searchInventoryItemPageList.HasPreviousPage == true)
            {
                searchInventoryItemPageList = new PagedList<Entities.DgvSearchInventoryItemEntity>(searchInventoryItemData, --inventoryItemPageNumber, inventoryItemPageSize);
                searchInventoryItemDataSource.DataSource = searchInventoryItemPageList;
            }

            buttonSearchInventoryItemPageListNext.Enabled = true;
            buttonSearchInventoryItemPageListLast.Enabled = true;

            if (inventoryItemPageNumber == 1)
            {
                buttonSearchInventoryItemPageListFirst.Enabled = false;
                buttonSearchInventoryItemPageListPrevious.Enabled = false;
            }

            textBoxSearchInventoryItemPageNumber.Text = inventoryItemPageNumber + " / " + searchInventoryItemPageList.PageCount;
        }

        private void buttonSearchInventoryItemPageListNext_Click(object sender, EventArgs e)
        {
            if (searchInventoryItemPageList.HasNextPage == true)
            {
                searchInventoryItemPageList = new PagedList<Entities.DgvSearchInventoryItemEntity>(searchInventoryItemData, ++inventoryItemPageNumber, inventoryItemPageSize);
                searchInventoryItemDataSource.DataSource = searchInventoryItemPageList;
            }

            buttonSearchInventoryItemPageListFirst.Enabled = true;
            buttonSearchInventoryItemPageListPrevious.Enabled = true;

            if (inventoryItemPageNumber == searchInventoryItemPageList.PageCount)
            {
                buttonSearchInventoryItemPageListNext.Enabled = false;
                buttonSearchInventoryItemPageListLast.Enabled = false;
            }

            textBoxSearchInventoryItemPageNumber.Text = inventoryItemPageNumber + " / " + searchInventoryItemPageList.PageCount;
        }

        private void buttonSearchInventoryItemPageListLast_Click(object sender, EventArgs e)
        {
            searchInventoryItemPageList = new PagedList<Entities.DgvSearchInventoryItemEntity>(searchInventoryItemData, searchInventoryItemPageList.PageCount, inventoryItemPageSize);
            searchInventoryItemDataSource.DataSource = searchInventoryItemPageList;

            buttonSearchInventoryItemPageListFirst.Enabled = true;
            buttonSearchInventoryItemPageListPrevious.Enabled = true;
            buttonSearchInventoryItemPageListNext.Enabled = false;
            buttonSearchInventoryItemPageListLast.Enabled = false;

            inventoryItemPageNumber = searchInventoryItemPageList.PageCount;
            textBoxSearchInventoryItemPageNumber.Text = inventoryItemPageNumber + " / " + searchInventoryItemPageList.PageCount;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public static List<Entities.DgvSearchNonInventoryItemEntity> searchNonInventoryItemData = new List<Entities.DgvSearchNonInventoryItemEntity>();
        public static Int32 nonInventoryItemPageNumber = 1;
        public static Int32 nonInventoryItemPpageSize = 50;
        public PagedList<Entities.DgvSearchNonInventoryItemEntity> searchItemPageList = new PagedList<Entities.DgvSearchNonInventoryItemEntity>(searchNonInventoryItemData, nonInventoryItemPageNumber, nonInventoryItemPpageSize);
        public BindingSource searchNonInventoryItemDataSource = new BindingSource();

        public void UpdateSearchItemDataSource()
        {
            SetSearchItemDataSourceAsync();
        }

        public async void SetSearchItemDataSourceAsync()
        {
            List<Entities.DgvSearchNonInventoryItemEntity> getSearchItemData = await GetSearchItemDataTask();
            if (getSearchItemData.Any())
            {
                searchNonInventoryItemData = getSearchItemData;
                searchItemPageList = new PagedList<Entities.DgvSearchNonInventoryItemEntity>(searchNonInventoryItemData, nonInventoryItemPageNumber, nonInventoryItemPpageSize);

                if (searchItemPageList.PageCount == 1)
                {
                    buttonSearchNonInventoryItemPageListFirst.Enabled = false;
                    buttonSearchNonInventoryItemPageListPrevious.Enabled = false;
                    buttonSearchNonInventoryItemPageListNext.Enabled = false;
                    buttonSearchNonInventoryItemPageListLast.Enabled = false;
                }
                else if (nonInventoryItemPageNumber == 1)
                {
                    buttonSearchNonInventoryItemPageListFirst.Enabled = false;
                    buttonSearchNonInventoryItemPageListPrevious.Enabled = false;
                    buttonSearchNonInventoryItemPageListNext.Enabled = true;
                    buttonSearchNonInventoryItemPageListLast.Enabled = true;
                }
                else if (nonInventoryItemPageNumber == searchItemPageList.PageCount)
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

                textBoxSearchNonInventoryItemPageNumber.Text = nonInventoryItemPageNumber + " / " + searchItemPageList.PageCount;
                searchNonInventoryItemDataSource.DataSource = searchItemPageList;
            }
            else
            {
                buttonSearchNonInventoryItemPageListFirst.Enabled = false;
                buttonSearchNonInventoryItemPageListPrevious.Enabled = false;
                buttonSearchNonInventoryItemPageListNext.Enabled = false;
                buttonSearchNonInventoryItemPageListLast.Enabled = false;

                nonInventoryItemPageNumber = 1;

                searchNonInventoryItemData = new List<Entities.DgvSearchNonInventoryItemEntity>();
                searchNonInventoryItemDataSource.Clear();
                textBoxSearchNonInventoryItemPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvSearchNonInventoryItemEntity>> GetSearchItemDataTask()
        {
            String filter = textBoxSearchItemFilter.Text;
            Controllers.TrnSalesOrderItemController trnSalesOrderItemController = new Controllers.TrnSalesOrderItemController();

            List<Entities.MstArticleEntity> listSearchItem = trnSalesOrderItemController.ListNonInventoryItem(filter);
            if (listSearchItem.Any())
            {
                var items = from d in listSearchItem
                            select new Entities.DgvSearchNonInventoryItemEntity
                            {
                                ColumnSearchNonInventoryId = d.Id,
                                ColumnSearchNonInventoryItemBarCode = d.ArticleCode,
                                ColumnSearchNonInventoryItemDescription = d.Article,
                                ColumnSearchNonInventoryItemUnitId = d.UnitId,
                                ColumnSearchNonInventoryItemUnit = d.Unit,
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
            UpdateSearchItemDataSource();

            dataGridViewSearchNonInventoryItem.Columns[dataGridViewSearchNonInventoryItem.Columns["ColumnSearchNonInventoryItemButtonPick"].Index].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSearchNonInventoryItem.Columns[dataGridViewSearchNonInventoryItem.Columns["ColumnSearchNonInventoryItemButtonPick"].Index].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSearchNonInventoryItem.Columns[dataGridViewSearchNonInventoryItem.Columns["ColumnSearchNonInventoryItemButtonPick"].Index].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewSearchNonInventoryItem.DataSource = searchNonInventoryItemDataSource;
        }

        public void GetSearchItemCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewSearchItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewSearchNonInventoryItem.CurrentCell.ColumnIndex == dataGridViewSearchNonInventoryItem.Columns["ColumnSearchNonInventoryItemButtonPick"].Index)
            {
                var salesOrderId = trnSalesOrderEntity.Id;
                var itemId = Convert.ToInt32(dataGridViewSearchNonInventoryItem.Rows[e.RowIndex].Cells[dataGridViewSearchNonInventoryItem.Columns["ColumnSearchNonInventoryId"].Index].Value);
                var itemDescription = dataGridViewSearchNonInventoryItem.Rows[e.RowIndex].Cells[dataGridViewSearchNonInventoryItem.Columns["ColumnSearchNonInventoryItemDescription"].Index].Value.ToString();
                var unitId = Convert.ToInt32(dataGridViewSearchNonInventoryItem.Rows[e.RowIndex].Cells[dataGridViewSearchNonInventoryItem.Columns["ColumnSearchNonInventoryItemUnitId"].Index].Value);
                var unit = dataGridViewSearchNonInventoryItem.Rows[e.RowIndex].Cells[dataGridViewSearchNonInventoryItem.Columns["ColumnSearchNonInventoryItemUnit"].Index].Value.ToString();

                Entities.TrnSalesOrderItemEntity addSalesOrderItem = new Entities.TrnSalesOrderItemEntity()
                {
                    SOId = salesOrderId,
                    ItemId = itemId,
                    ItemInventoryId = null,
                    UnitId = unitId,
                };

                //TrnSalesOrderDetailSalesOrderItemDetailForm trnSalesOrderDetailSalesOrderItemDetailForm = new TrnSalesOrderDetailSalesOrderItemDetailForm();
            }
        }

        private void textBoxSearchNonInventoryItemFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateSearchItemDataSource();
                nonInventoryItemPageNumber = 1;
            }
        }

        private void buttonSearchItemPageListFirst_Click(object sender, EventArgs e)
        {
            searchItemPageList = new PagedList<Entities.DgvSearchNonInventoryItemEntity>(searchNonInventoryItemData, 1, nonInventoryItemPpageSize);
            searchNonInventoryItemDataSource.DataSource = searchItemPageList;

            buttonSearchNonInventoryItemPageListFirst.Enabled = false;
            buttonSearchNonInventoryItemPageListPrevious.Enabled = false;
            buttonSearchNonInventoryItemPageListNext.Enabled = true;
            buttonSearchNonInventoryItemPageListLast.Enabled = true;

            nonInventoryItemPageNumber = 1;
            textBoxSearchNonInventoryItemPageNumber.Text = nonInventoryItemPageNumber + " / " + searchItemPageList.PageCount;
        }

        private void buttonSearchItemPageListPrevious_Click(object sender, EventArgs e)
        {
            if (searchItemPageList.HasPreviousPage == true)
            {
                searchItemPageList = new PagedList<Entities.DgvSearchNonInventoryItemEntity>(searchNonInventoryItemData, --nonInventoryItemPageNumber, nonInventoryItemPpageSize);
                searchNonInventoryItemDataSource.DataSource = searchItemPageList;
            }

            buttonSearchNonInventoryItemPageListNext.Enabled = true;
            buttonSearchNonInventoryItemPageListLast.Enabled = true;

            if (nonInventoryItemPageNumber == 1)
            {
                buttonSearchNonInventoryItemPageListFirst.Enabled = false;
                buttonSearchNonInventoryItemPageListPrevious.Enabled = false;
            }

            textBoxSearchNonInventoryItemPageNumber.Text = nonInventoryItemPageNumber + " / " + searchItemPageList.PageCount;
        }

        private void buttonSearchItemPageListNext_Click(object sender, EventArgs e)
        {
            if (searchItemPageList.HasNextPage == true)
            {
                searchItemPageList = new PagedList<Entities.DgvSearchNonInventoryItemEntity>(searchNonInventoryItemData, ++nonInventoryItemPageNumber, nonInventoryItemPpageSize);
                searchNonInventoryItemDataSource.DataSource = searchItemPageList;
            }

            buttonSearchNonInventoryItemPageListFirst.Enabled = true;
            buttonSearchNonInventoryItemPageListPrevious.Enabled = true;

            if (nonInventoryItemPageNumber == searchItemPageList.PageCount)
            {
                buttonSearchNonInventoryItemPageListNext.Enabled = false;
                buttonSearchNonInventoryItemPageListLast.Enabled = false;
            }

            textBoxSearchNonInventoryItemPageNumber.Text = nonInventoryItemPageNumber + " / " + searchItemPageList.PageCount;
        }

        private void buttonSearchItemPageListLast_Click(object sender, EventArgs e)
        {
            searchItemPageList = new PagedList<Entities.DgvSearchNonInventoryItemEntity>(searchNonInventoryItemData, searchItemPageList.PageCount, nonInventoryItemPpageSize);
            searchNonInventoryItemDataSource.DataSource = searchItemPageList;

            buttonSearchNonInventoryItemPageListFirst.Enabled = true;
            buttonSearchNonInventoryItemPageListPrevious.Enabled = true;
            buttonSearchNonInventoryItemPageListNext.Enabled = false;
            buttonSearchNonInventoryItemPageListLast.Enabled = false;

            nonInventoryItemPageNumber = searchItemPageList.PageCount;
            textBoxSearchNonInventoryItemPageNumber.Text = nonInventoryItemPageNumber + " / " + searchItemPageList.PageCount;
        }

    }
}
