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
    public partial class TrnSalesInvoiceDetailSalesInvoiceItemDetailPriceForm : Form
    {
        TrnSalesInvoiceDetailSalesInvoiceItemDetailForm trnSalesInvoiceDetailSalesInvoiceItemDetailForm;
        public Entities.TrnSalesInvoiceItemEntity trnSalesInvoiceItemEntity;

        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;

        public static List<Entities.DgvMstItemPrice> itemPriceListData = new List<Entities.DgvMstItemPrice>();
        public PagedList<Entities.DgvMstItemPrice> itemPriceListPageList = new PagedList<Entities.DgvMstItemPrice>(itemPriceListData, pageNumber, pageSize);
        public BindingSource itemPriceListDataSource = new BindingSource();

        public TrnSalesInvoiceDetailSalesInvoiceItemDetailPriceForm(TrnSalesInvoiceDetailSalesInvoiceItemDetailForm salesInvoiceDetailSalesInvoiceItemDetailForm, Entities.TrnSalesInvoiceItemEntity salesInvoiceItemEntity)
        {
            InitializeComponent();

            trnSalesInvoiceDetailSalesInvoiceItemDetailForm = salesInvoiceDetailSalesInvoiceItemDetailForm;
            trnSalesInvoiceItemEntity = salesInvoiceItemEntity;

            LoadItemPrice();
        }

        public void LoadItemPrice()
        {
            textBoxItemDescription.Text = trnSalesInvoiceItemEntity.ItemDescription;
            CreateItemPriceListDataGridView();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void UpdateItemPriceListDataSource()
        {
            SetItemPriceListDataSourceAsync();
        }

        public async void SetItemPriceListDataSourceAsync()
        {
            List<Entities.DgvMstItemPrice> getItemPriceListData = await GetItemPriceListDataTask();
            if (getItemPriceListData.Any())
            {
                pageNumber = 1;
                itemPriceListData = getItemPriceListData;
                itemPriceListPageList = new PagedList<Entities.DgvMstItemPrice>(itemPriceListData, pageNumber, pageSize);

                if (itemPriceListPageList.PageCount == 1)
                {
                    buttonItemPriceListPageListFirst.Enabled = false;
                    buttonItemPriceListPageListPrevious.Enabled = false;
                    buttonItemPriceListPageListNext.Enabled = false;
                    buttonItemPriceListPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonItemPriceListPageListFirst.Enabled = false;
                    buttonItemPriceListPageListPrevious.Enabled = false;
                    buttonItemPriceListPageListNext.Enabled = true;
                    buttonItemPriceListPageListLast.Enabled = true;
                }
                else if (pageNumber == itemPriceListPageList.PageCount)
                {
                    buttonItemPriceListPageListFirst.Enabled = true;
                    buttonItemPriceListPageListPrevious.Enabled = true;
                    buttonItemPriceListPageListNext.Enabled = false;
                    buttonItemPriceListPageListLast.Enabled = false;
                }
                else
                {
                    buttonItemPriceListPageListFirst.Enabled = true;
                    buttonItemPriceListPageListPrevious.Enabled = true;
                    buttonItemPriceListPageListNext.Enabled = true;
                    buttonItemPriceListPageListLast.Enabled = true;
                }

                textBoxItemPriceListPageNumber.Text = pageNumber + " / " + itemPriceListPageList.PageCount;
                itemPriceListDataSource.DataSource = itemPriceListPageList;
            }
            else
            {
                buttonItemPriceListPageListFirst.Enabled = false;
                buttonItemPriceListPageListPrevious.Enabled = false;
                buttonItemPriceListPageListNext.Enabled = false;
                buttonItemPriceListPageListLast.Enabled = false;

                pageNumber = 1;

                itemPriceListData = new List<Entities.DgvMstItemPrice>();
                itemPriceListDataSource.Clear();
                textBoxItemPriceListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvMstItemPrice>> GetItemPriceListDataTask()
        {
            Controllers.MstArtciclePriceController mstArtciclePriceController = new Controllers.MstArtciclePriceController();
            List<Entities.MstArticlePriceEntity> listItemPrice = mstArtciclePriceController.ListItemPrice(trnSalesInvoiceItemEntity.ItemId);

            if (listItemPrice.Any())
            {
                var itemPrices = from d in listItemPrice
                                 select new Entities.DgvMstItemPrice
                                 {
                                     ColumnItemPriceListButtonPick = "Pick",
                                     ColumnItemPriceListPriceDescription = d.PriceDescription,
                                     ColumnItemPriceListPrice = d.Price.ToString("#,##0.00")
                                 };

                return Task.FromResult(itemPrices.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvMstItemPrice>());
            }
        }

        public void CreateItemPriceListDataGridView()
        {
            UpdateItemPriceListDataSource();

            dataGridViewItemPriceList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewItemPriceList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewItemPriceList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewItemPriceList.DataSource = itemPriceListDataSource;
        }

        public void GetItemPriceListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonItemPriceListPageListFirst_Click(object sender, EventArgs e)
        {
            itemPriceListPageList = new PagedList<Entities.DgvMstItemPrice>(itemPriceListData, 1, pageSize);
            itemPriceListDataSource.DataSource = itemPriceListPageList;

            buttonItemPriceListPageListFirst.Enabled = false;
            buttonItemPriceListPageListPrevious.Enabled = false;
            buttonItemPriceListPageListNext.Enabled = true;
            buttonItemPriceListPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxItemPriceListPageNumber.Text = pageNumber + " / " + itemPriceListPageList.PageCount;
        }

        private void buttonItemPriceListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (itemPriceListPageList.HasPreviousPage == true)
            {
                itemPriceListPageList = new PagedList<Entities.DgvMstItemPrice>(itemPriceListData, --pageNumber, pageSize);
                itemPriceListDataSource.DataSource = itemPriceListPageList;
            }

            buttonItemPriceListPageListNext.Enabled = true;
            buttonItemPriceListPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonItemPriceListPageListFirst.Enabled = false;
                buttonItemPriceListPageListPrevious.Enabled = false;
            }

            textBoxItemPriceListPageNumber.Text = pageNumber + " / " + itemPriceListPageList.PageCount;
        }

        private void buttonItemPriceListPageListNext_Click(object sender, EventArgs e)
        {
            if (itemPriceListPageList.HasNextPage == true)
            {
                itemPriceListPageList = new PagedList<Entities.DgvMstItemPrice>(itemPriceListData, ++pageNumber, pageSize);
                itemPriceListDataSource.DataSource = itemPriceListPageList;
            }

            buttonItemPriceListPageListFirst.Enabled = true;
            buttonItemPriceListPageListPrevious.Enabled = true;

            if (pageNumber == itemPriceListPageList.PageCount)
            {
                buttonItemPriceListPageListNext.Enabled = false;
                buttonItemPriceListPageListLast.Enabled = false;
            }

            textBoxItemPriceListPageNumber.Text = pageNumber + " / " + itemPriceListPageList.PageCount;
        }

        private void buttonItemPriceListPageListLast_Click(object sender, EventArgs e)
        {
            itemPriceListPageList = new PagedList<Entities.DgvMstItemPrice>(itemPriceListData, itemPriceListPageList.PageCount, pageSize);
            itemPriceListDataSource.DataSource = itemPriceListPageList;

            buttonItemPriceListPageListFirst.Enabled = true;
            buttonItemPriceListPageListPrevious.Enabled = true;
            buttonItemPriceListPageListNext.Enabled = false;
            buttonItemPriceListPageListLast.Enabled = false;

            pageNumber = itemPriceListPageList.PageCount;
            textBoxItemPriceListPageNumber.Text = pageNumber + " / " + itemPriceListPageList.PageCount;
        }

        private void dataGridViewItemPriceList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetItemPriceListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewItemPriceList.CurrentCell.ColumnIndex == dataGridViewItemPriceList.Columns["ColumnItemPriceListButtonPick"].Index)
            {
                if (dataGridViewItemPriceList.Rows[dataGridViewItemPriceList.CurrentCell.RowIndex].Cells[dataGridViewItemPriceList.Columns["ColumnItemPriceListPriceDescription"].Index].Value.ToString().ToLower() == "variable")
                {
                    Decimal price = Convert.ToDecimal(dataGridViewItemPriceList.Rows[dataGridViewItemPriceList.CurrentCell.RowIndex].Cells[dataGridViewItemPriceList.Columns["ColumnItemPriceListPrice"].Index].Value);

                    TrnSalesInvoiceVariablePriceForm trnSalesInvoiceVariablePriceForm = new TrnSalesInvoiceVariablePriceForm(this, trnSalesInvoiceDetailSalesInvoiceItemDetailForm, price);
                    trnSalesInvoiceVariablePriceForm.ShowDialog();
                }
                else
                {
                    Decimal price = Convert.ToDecimal(dataGridViewItemPriceList.Rows[dataGridViewItemPriceList.CurrentCell.RowIndex].Cells[dataGridViewItemPriceList.Columns["ColumnItemPriceListPrice"].Index].Value);

                    trnSalesInvoiceDetailSalesInvoiceItemDetailForm.UpdatePrice(price);
                    Close();
                }

            }
        }
    }
}
