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

namespace easyfmis.Forms.Software.TrnStockOut
{
    public partial class TrnStockOutDetailSearchItemForm : Form
    {
        public TrnStockOutDetailForm trnStockOutDetailForm;
        public Entities.TrnStockOutEntity trnStockOutEntity;

        public static List<Entities.DgvSearchInventoryItemEntity> searchItemData = new List<Entities.DgvSearchInventoryItemEntity>();
        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;
        public PagedList<Entities.DgvSearchInventoryItemEntity> searchItemPageList = new PagedList<Entities.DgvSearchInventoryItemEntity>(searchItemData, pageNumber, pageSize);
        public BindingSource searchItemDataSource = new BindingSource();

        public TrnStockOutDetailSearchItemForm(TrnStockOutDetailForm stockOutDetailForm, Entities.TrnStockOutEntity stockOutEntity)
        {
            InitializeComponent();

            trnStockOutDetailForm = stockOutDetailForm;
            trnStockOutEntity = stockOutEntity;

            CreateSearchItemDataGridView();
        }

        public void UpdateSearchItemDataSource()
        {
            SetSearchItemDataSourceAsync();
        }

        public async void SetSearchItemDataSourceAsync()
        {
            List<Entities.DgvSearchInventoryItemEntity> getSearchItemData = await GetSearchItemDataTask();
            if (getSearchItemData.Any())
            {
                searchItemData = getSearchItemData;
                searchItemPageList = new PagedList<Entities.DgvSearchInventoryItemEntity>(searchItemData, pageNumber, pageSize);

                if (searchItemPageList.PageCount == 1)
                {
                    buttonSearchItemPageListFirst.Enabled = false;
                    buttonSearchItemPageListPrevious.Enabled = false;
                    buttonSearchItemPageListNext.Enabled = false;
                    buttonSearchItemPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonSearchItemPageListFirst.Enabled = false;
                    buttonSearchItemPageListPrevious.Enabled = false;
                    buttonSearchItemPageListNext.Enabled = true;
                    buttonSearchItemPageListLast.Enabled = true;
                }
                else if (pageNumber == searchItemPageList.PageCount)
                {
                    buttonSearchItemPageListFirst.Enabled = true;
                    buttonSearchItemPageListPrevious.Enabled = true;
                    buttonSearchItemPageListNext.Enabled = false;
                    buttonSearchItemPageListLast.Enabled = false;
                }
                else
                {
                    buttonSearchItemPageListFirst.Enabled = true;
                    buttonSearchItemPageListPrevious.Enabled = true;
                    buttonSearchItemPageListNext.Enabled = true;
                    buttonSearchItemPageListLast.Enabled = true;
                }

                textBoxSearchItemPageNumber.Text = pageNumber + " / " + searchItemPageList.PageCount;
                searchItemDataSource.DataSource = searchItemPageList;
            }
            else
            {
                buttonSearchItemPageListFirst.Enabled = false;
                buttonSearchItemPageListPrevious.Enabled = false;
                buttonSearchItemPageListNext.Enabled = false;
                buttonSearchItemPageListLast.Enabled = false;

                pageNumber = 1;

                searchItemData = new List<Entities.DgvSearchInventoryItemEntity>();
                searchItemDataSource.Clear();
                textBoxSearchItemPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvSearchInventoryItemEntity>> GetSearchItemDataTask()
        {
            String filter = textBoxSearchItemFilter.Text;
            Controllers.TrnStockOutItemController trnStockOutItemController = new Controllers.TrnStockOutItemController();

            List<Entities.MstArticleInventory> listSearchItem = trnStockOutItemController.ListInventoryItem(filter);
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
                                ColumnSearchInventoryItemButtonPick = "Pick"
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvSearchInventoryItemEntity>());
            }
        }

        public void CreateSearchItemDataGridView()
        {
            UpdateSearchItemDataSource();

            dataGridViewSearchItem.Columns[dataGridViewSearchItem.Columns["ColumnSearchInventoryItemButtonPick"].Index].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSearchItem.Columns[dataGridViewSearchItem.Columns["ColumnSearchInventoryItemButtonPick"].Index].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSearchItem.Columns[dataGridViewSearchItem.Columns["ColumnSearchInventoryItemButtonPick"].Index].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewSearchItem.DataSource = searchItemDataSource;
        }

        public void GetSearchItemCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewSearchItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewSearchItem.CurrentCell.ColumnIndex == dataGridViewSearchItem.Columns["ColumnSearchInventoryItemButtonPick"].Index)
            {
                var stockOutId = trnStockOutEntity.Id;
                var itemId = Convert.ToInt32(dataGridViewSearchItem.Rows[e.RowIndex].Cells[dataGridViewSearchItem.Columns["ColumnSearchInventoryItemId"].Index].Value);
                var itemDescription = dataGridViewSearchItem.Rows[e.RowIndex].Cells[dataGridViewSearchItem.Columns["ColumnSearchInventoryItemDescription"].Index].Value.ToString();
                var itemInventoryId = Convert.ToInt32(dataGridViewSearchItem.Rows[e.RowIndex].Cells[dataGridViewSearchItem.Columns["ColumnSearchInventoryId"].Index].Value);
                var unitId = Convert.ToInt32(dataGridViewSearchItem.Rows[e.RowIndex].Cells[dataGridViewSearchItem.Columns["ColumnSearchInventoryItemUnitId"].Index].Value);
                var unit = dataGridViewSearchItem.Rows[e.RowIndex].Cells[dataGridViewSearchItem.Columns["ColumnSearchInventoryItemUnit"].Index].Value.ToString();

                Entities.TrnStockOutItemEntity trnStockOutItemEntity = new Entities.TrnStockOutItemEntity()
                {
                    Id = 0,
                    OTId = stockOutId,
                    ItemId = itemId,
                    ItemDescription = itemDescription,
                    ItemInventoryId = itemInventoryId,
                    UnitId = unitId,
                    Unit = unit,
                    Quantity = 1,
                    Cost = 0,
                    Amount = 0,
                    BaseCost = 0,
                    BaseQuantity = 0
                };

                TrnStockOutDetailStockOutItemDetailForm trnStockOutDetailStockOutItemDetailForm = new TrnStockOutDetailStockOutItemDetailForm(trnStockOutDetailForm, trnStockOutItemEntity);
                trnStockOutDetailStockOutItemDetailForm.ShowDialog();
            }
        }

        private void textBoxSearchItemFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateSearchItemDataSource();
                pageNumber = 1;
            }
        }

        private void buttonSearchItemPageListFirst_Click(object sender, EventArgs e)
        {
            searchItemPageList = new PagedList<Entities.DgvSearchInventoryItemEntity>(searchItemData, 1, pageSize);
            searchItemDataSource.DataSource = searchItemPageList;

            buttonSearchItemPageListFirst.Enabled = false;
            buttonSearchItemPageListPrevious.Enabled = false;
            buttonSearchItemPageListNext.Enabled = true;
            buttonSearchItemPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxSearchItemPageNumber.Text = pageNumber + " / " + searchItemPageList.PageCount;
        }

        private void buttonSearchItemPageListPrevious_Click(object sender, EventArgs e)
        {
            if (searchItemPageList.HasPreviousPage == true)
            {
                searchItemPageList = new PagedList<Entities.DgvSearchInventoryItemEntity>(searchItemData, --pageNumber, pageSize);
                searchItemDataSource.DataSource = searchItemPageList;
            }

            buttonSearchItemPageListNext.Enabled = true;
            buttonSearchItemPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonSearchItemPageListFirst.Enabled = false;
                buttonSearchItemPageListPrevious.Enabled = false;
            }

            textBoxSearchItemPageNumber.Text = pageNumber + " / " + searchItemPageList.PageCount;
        }

        private void buttonSearchItemPageListNext_Click(object sender, EventArgs e)
        {
            if (searchItemPageList.HasNextPage == true)
            {
                searchItemPageList = new PagedList<Entities.DgvSearchInventoryItemEntity>(searchItemData, ++pageNumber, pageSize);
                searchItemDataSource.DataSource = searchItemPageList;
            }

            buttonSearchItemPageListFirst.Enabled = true;
            buttonSearchItemPageListPrevious.Enabled = true;

            if (pageNumber == searchItemPageList.PageCount)
            {
                buttonSearchItemPageListNext.Enabled = false;
                buttonSearchItemPageListLast.Enabled = false;
            }

            textBoxSearchItemPageNumber.Text = pageNumber + " / " + searchItemPageList.PageCount;
        }

        private void buttonSearchItemPageListLast_Click(object sender, EventArgs e)
        {
            searchItemPageList = new PagedList<Entities.DgvSearchInventoryItemEntity>(searchItemData, searchItemPageList.PageCount, pageSize);
            searchItemDataSource.DataSource = searchItemPageList;

            buttonSearchItemPageListFirst.Enabled = true;
            buttonSearchItemPageListPrevious.Enabled = true;
            buttonSearchItemPageListNext.Enabled = false;
            buttonSearchItemPageListLast.Enabled = false;

            pageNumber = searchItemPageList.PageCount;
            textBoxSearchItemPageNumber.Text = pageNumber + " / " + searchItemPageList.PageCount;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
