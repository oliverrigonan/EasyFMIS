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

namespace easyfmis.Forms.Software.TrnPurchaseOrder
{
    public partial class TrnPurchaseOrderDetailSearchItemForm : Form
    {
        TrnPurchaseOrderDetailForm trnPurchaseOrderDetailForm;
        public Entities.TrnPurchaseOrderEntity trnPurchaseOrderEntity;

        public static List<Entities.DgvSearchItemEntity> searchItemData = new List<Entities.DgvSearchItemEntity>();
        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;
        public PagedList<Entities.DgvSearchItemEntity> searchItemPageList = new PagedList<Entities.DgvSearchItemEntity>(searchItemData, pageNumber, pageSize);
        public BindingSource searchItemDataSource = new BindingSource();

        public TrnPurchaseOrderDetailSearchItemForm(TrnPurchaseOrderDetailForm purchaseOrderDetailForm, Entities.TrnPurchaseOrderEntity purchaseOrderEntity)
        {
            InitializeComponent();

            trnPurchaseOrderDetailForm = purchaseOrderDetailForm;
            trnPurchaseOrderEntity = purchaseOrderEntity;

            CreateSearchItemDataGridView();
        }

        public void UpdateSearchItemDataSource()
        {
            SetSearchItemDataSourceAsync();
        }

        public async void SetSearchItemDataSourceAsync()
        {
            List<Entities.DgvSearchItemEntity> getSearchItemData = await GetSearchItemDataTask();
            if (getSearchItemData.Any())
            {
                searchItemData = getSearchItemData;
                searchItemPageList = new PagedList<Entities.DgvSearchItemEntity>(searchItemData, pageNumber, pageSize);

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

                searchItemData = new List<Entities.DgvSearchItemEntity>();
                searchItemDataSource.Clear();
                textBoxSearchItemPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvSearchItemEntity>> GetSearchItemDataTask()
        {
            String filter = textBoxSearchItemFilter.Text;
            Controllers.TrnPurchaseOrderItemController trnPurchaseOrderItemController = new Controllers.TrnPurchaseOrderItemController();

            List<Entities.MstArticleEntity> listSearchItem = trnPurchaseOrderItemController.ListItem(filter);
            if (listSearchItem.Any())
            {
                var items = from d in listSearchItem
                            select new Entities.DgvSearchItemEntity
                            {
                                ColumnSearchItemId = d.Id,
                                ColumnSearchItemBarCode = d.ArticleBarCode,
                                ColumnSearchItemDescription = d.Article,
                                ColumnSearchItemUnitId = d.UnitId,
                                ColumnSearchItemUnit = d.Unit,
                                ColumnSearchItemPrice = d.DefaultPrice.ToString("#,##0.00"),
                                ColumnSearchItemButtonPick = "Pick"
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvSearchItemEntity>());
            }
        }

        public void CreateSearchItemDataGridView()
        {
            UpdateSearchItemDataSource();

            dataGridViewSearchItem.Columns[dataGridViewSearchItem.Columns["ColumnSearchItemButtonPick"].Index].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSearchItem.Columns[dataGridViewSearchItem.Columns["ColumnSearchItemButtonPick"].Index].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSearchItem.Columns[dataGridViewSearchItem.Columns["ColumnSearchItemButtonPick"].Index].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewSearchItem.DataSource = searchItemDataSource;
        }

        public void GetSearchItemCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewSearchItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewSearchItem.CurrentCell.ColumnIndex == dataGridViewSearchItem.Columns["ColumnSearchItemButtonPick"].Index)
            {
                var purchaseOrderId = trnPurchaseOrderEntity.Id;
                var itemId = Convert.ToInt32(dataGridViewSearchItem.Rows[e.RowIndex].Cells[dataGridViewSearchItem.Columns["ColumnSearchItemId"].Index].Value);
                var itemDescription = dataGridViewSearchItem.Rows[e.RowIndex].Cells[dataGridViewSearchItem.Columns["ColumnSearchItemDescription"].Index].Value.ToString();
                var unitId = Convert.ToInt32(dataGridViewSearchItem.Rows[e.RowIndex].Cells[dataGridViewSearchItem.Columns["ColumnSearchItemUnitId"].Index].Value);
                var unit = dataGridViewSearchItem.Rows[e.RowIndex].Cells[dataGridViewSearchItem.Columns["ColumnSearchItemUnit"].Index].Value.ToString();
                var price = Convert.ToDecimal(dataGridViewSearchItem.Rows[e.RowIndex].Cells[dataGridViewSearchItem.Columns["ColumnSearchItemPrice"].Index].Value);

                Entities.TrnPurchaseOrderItemEntity trnPurchaseOrderItemEntity = new Entities.TrnPurchaseOrderItemEntity()
                {
                    Id = 0,
                    POId = purchaseOrderId,
                    ItemId = itemId,
                    ItemDescription = itemDescription,
                    UnitId = unitId,
                    Unit = unit,
                    Quantity = 1,
                    Cost = 0,
                    Amount = 0,
                    BaseCost = 0,
                    BaseQuantity = 0
                };

                TrnPurchaseOrderDetailPurchaseOrderItemDetailForm trnPurchaseOrderDetailPurchaseOrderItemDetailForm = new TrnPurchaseOrderDetailPurchaseOrderItemDetailForm(trnPurchaseOrderDetailForm, trnPurchaseOrderItemEntity);
                trnPurchaseOrderDetailPurchaseOrderItemDetailForm.ShowDialog();
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
            searchItemPageList = new PagedList<Entities.DgvSearchItemEntity>(searchItemData, 1, pageSize);
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
                searchItemPageList = new PagedList<Entities.DgvSearchItemEntity>(searchItemData, --pageNumber, pageSize);
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
                searchItemPageList = new PagedList<Entities.DgvSearchItemEntity>(searchItemData, ++pageNumber, pageSize);
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
            searchItemPageList = new PagedList<Entities.DgvSearchItemEntity>(searchItemData, searchItemPageList.PageCount, pageSize);
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
