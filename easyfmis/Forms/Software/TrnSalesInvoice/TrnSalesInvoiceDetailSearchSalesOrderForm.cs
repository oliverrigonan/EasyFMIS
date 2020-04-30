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
    public partial class TrnSalesInvoiceDetailSearchSalesOrderForm : Form
    {
        public TrnSalesInvoiceDetailForm trnSalesInvoiceDetailForm;
        public Entities.TrnSalesInvoiceEntity trnSalesInvoiceEntity;

        public static Int32 pageSize = 50;

        public static List<Entities.DgvSalesInvoiceSearchSalesOrderEntity> salesOrderData = new List<Entities.DgvSalesInvoiceSearchSalesOrderEntity>();
        public static Int32 salesOrderPageNumber = 1;
        public static Int32 SalesOrderPageSize = 50;
        public PagedList<Entities.DgvSalesInvoiceSearchSalesOrderEntity> salesOrderPageList = new PagedList<Entities.DgvSalesInvoiceSearchSalesOrderEntity>(salesOrderData, salesOrderPageNumber, SalesOrderPageSize);
        public BindingSource salesOrderDataSource = new BindingSource();

        public TrnSalesInvoiceDetailSearchSalesOrderForm(TrnSalesInvoiceDetailForm salesInvoiceDetailForm, Entities.TrnSalesInvoiceEntity salesInvoiceEntity)
        {
            InitializeComponent();

            trnSalesInvoiceDetailForm = salesInvoiceDetailForm;
            trnSalesInvoiceEntity = salesInvoiceEntity;

            CreateSalesOrderDataGridView();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public Task<List<Entities.DgvSalesInvoiceSearchSalesOrderEntity>> GetSalesOrderItemDataTask()
        {
            Controllers.TrnSalesInvoiceItemController trnSalesInvoiceItemController = new Controllers.TrnSalesInvoiceItemController();
            var stringFilter = textBoxSearchSalesOrderItemFilter.Text;
            List<Entities.TrnSalesOrderEntity> listSalesOrder = trnSalesInvoiceItemController.ListSalesOrder(trnSalesInvoiceEntity.CustomerId);
            if (listSalesOrder.Any())
            {
                var items = from d in listSalesOrder
                            where d.SONumber.Contains(stringFilter)
                            && d.Remarks.Contains(stringFilter)
                            select new Entities.DgvSalesInvoiceSearchSalesOrderEntity
                            {
                                ColumnSalesInvoiceSearchSalesOrderListId = d.Id,
                                ColumnSalesInvoiceSearchSalesOrderListSONumber = d.SONumber,
                                ColumnSalesInvoiceSearchSalesOrderListSODate = d.SODate.ToShortDateString(),
                                ColumnSalesInvoiceSearchSalesOrderListRemarks = d.Remarks,
                                ColumnSalesInvoiceSearchSalesOrderListPick = "Pick",
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvSalesInvoiceSearchSalesOrderEntity>());
            }
        }

        public async void SetSalesOrdertemDataSourceAsync()
        {
            List<Entities.DgvSalesInvoiceSearchSalesOrderEntity> getSalesOrderData = await GetSalesOrderItemDataTask();
            if (getSalesOrderData.Any())
            {
                salesOrderData = getSalesOrderData;
                salesOrderPageList = new PagedList<Entities.DgvSalesInvoiceSearchSalesOrderEntity>(salesOrderData, salesOrderPageNumber, SalesOrderPageSize);

                if (salesOrderPageList.PageCount == 1)
                {
                    buttonSalesOrderPageListFirst.Enabled = false;
                    buttonSalesOrderPageListPrevious.Enabled = false;
                    buttonSalesOrderPageListNext.Enabled = false;
                    buttonSalesOrderPageListLast.Enabled = false;
                }
                else if (salesOrderPageNumber == 1)
                {
                    buttonSalesOrderPageListFirst.Enabled = false;
                    buttonSalesOrderPageListPrevious.Enabled = false;
                    buttonSalesOrderPageListNext.Enabled = true;
                    buttonSalesOrderPageListLast.Enabled = true;
                }
                else if (salesOrderPageNumber == salesOrderPageList.PageCount)
                {
                    buttonSalesOrderPageListFirst.Enabled = true;
                    buttonSalesOrderPageListPrevious.Enabled = true;
                    buttonSalesOrderPageListNext.Enabled = false;
                    buttonSalesOrderPageListLast.Enabled = false;
                }
                else
                {
                    buttonSalesOrderPageListFirst.Enabled = true;
                    buttonSalesOrderPageListPrevious.Enabled = true;
                    buttonSalesOrderPageListNext.Enabled = true;
                    buttonSalesOrderPageListLast.Enabled = true;
                }

                textBoxSalesOrderPageNumber.Text = salesOrderPageNumber + " / " + salesOrderPageList.PageCount;
                salesOrderDataSource.DataSource = salesOrderPageList;
            }
            else
            {
                buttonSalesOrderPageListFirst.Enabled = false;
                buttonSalesOrderPageListPrevious.Enabled = false;
                buttonSalesOrderPageListNext.Enabled = false;
                buttonSalesOrderPageListLast.Enabled = false;

                salesOrderPageNumber = 1;

                salesOrderData = new List<Entities.DgvSalesInvoiceSearchSalesOrderEntity>();
                salesOrderDataSource.Clear();
                textBoxSalesOrderPageNumber.Text = "1 / 1";
            }
        }


        public void UpdateSalesOrderDataSource()
        {
            SetSalesOrdertemDataSourceAsync();
        }

        public void CreateSalesOrderDataGridView()
        {
            UpdateSalesOrderDataSource();

            dataGridViewSalesOrder.Columns[dataGridViewSalesOrder.Columns["ColumnSalesInvoiceSearchSalesOrderListPick"].Index].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSalesOrder.Columns[dataGridViewSalesOrder.Columns["ColumnSalesInvoiceSearchSalesOrderListPick"].Index].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSalesOrder.Columns[dataGridViewSalesOrder.Columns["ColumnSalesInvoiceSearchSalesOrderListPick"].Index].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewSalesOrder.DataSource = salesOrderDataSource;
        }

        public void GetSalesOrderItemCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewSalesOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetSalesOrderItemCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewSalesOrder.CurrentCell.ColumnIndex == dataGridViewSalesOrder.Columns["ColumnSalesInvoiceSearchSalesOrderListPick"].Index)
            {
               
                DialogResult deleteDialogResult = MessageBox.Show("Load Sales Order?", "Easy ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    var SIId = trnSalesInvoiceEntity.Id;
                    var SOId = Convert.ToInt32(dataGridViewSalesOrder.Rows[e.RowIndex].Cells[dataGridViewSalesOrder.Columns["ColumnSalesInvoiceSearchSalesOrderListId"].Index].Value);
                    var SONumber = dataGridViewSalesOrder.Rows[e.RowIndex].Cells[dataGridViewSalesOrder.Columns["ColumnSalesInvoiceSearchSalesOrderListSONumber"].Index].Value.ToString();

                    Controllers.TrnSalesInvoiceItemController trnSalesInvoiceItemController = new Controllers.TrnSalesInvoiceItemController();
                    String[] loadSalesOrderItem = trnSalesInvoiceItemController.ListLoadSalesOrderItem(SIId, SOId);
                    if (loadSalesOrderItem[1].Equals("0") == false)
                    {
                        trnSalesInvoiceDetailForm.trnSalesInvoiceEntity.SOId = SOId;
                        trnSalesInvoiceDetailForm.trnSalesInvoiceEntity.SONumber = SONumber;
                        trnSalesInvoiceDetailForm.UpdateSONumber();
                        trnSalesInvoiceDetailForm.UpdateSalesInvoiceItemDataSource();
                    }
                    else
                    {
                        MessageBox.Show(loadSalesOrderItem[0], "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonSalesOrderPageListFirst_Click(object sender, EventArgs e)
        {
            salesOrderPageList = new PagedList<Entities.DgvSalesInvoiceSearchSalesOrderEntity>(salesOrderData, 1, SalesOrderPageSize);
            salesOrderDataSource.DataSource = salesOrderPageList;

            buttonSalesOrderPageListFirst.Enabled = false;
            buttonSalesOrderPageListPrevious.Enabled = false;
            buttonSalesOrderPageListNext.Enabled = true;
            buttonSalesOrderPageListLast.Enabled = true;

            salesOrderPageNumber = 1;
            textBoxSalesOrderPageNumber.Text = salesOrderPageNumber + " / " + salesOrderPageList.PageCount;
        }

        private void buttonSalesOrderPageListPrevious_Click(object sender, EventArgs e)
        {
            if (salesOrderPageList.HasPreviousPage == true)
            {
                salesOrderPageList = new PagedList<Entities.DgvSalesInvoiceSearchSalesOrderEntity>(salesOrderData, --salesOrderPageNumber, SalesOrderPageSize);
                salesOrderDataSource.DataSource = salesOrderPageList;
            }

            buttonSalesOrderPageListNext.Enabled = true;
            buttonSalesOrderPageListLast.Enabled = true;

            if (salesOrderPageNumber == 1)
            {
                buttonSalesOrderPageListFirst.Enabled = false;
                buttonSalesOrderPageListPrevious.Enabled = false;
            }

            textBoxSalesOrderPageNumber.Text = salesOrderPageNumber + " / " + salesOrderPageList.PageCount;
        }

        private void buttonSalesOrderPageListNext_Click(object sender, EventArgs e)
        {
            if (salesOrderPageList.HasNextPage == true)
            {
                salesOrderPageList = new PagedList<Entities.DgvSalesInvoiceSearchSalesOrderEntity>(salesOrderData, ++salesOrderPageNumber, SalesOrderPageSize);
                salesOrderDataSource.DataSource = salesOrderPageList;
            }

            buttonSalesOrderPageListFirst.Enabled = true;
            buttonSalesOrderPageListPrevious.Enabled = true;

            if (salesOrderPageNumber == salesOrderPageList.PageCount)
            {
                buttonSalesOrderPageListNext.Enabled = false;
                buttonSalesOrderPageListLast.Enabled = false;
            }

            textBoxSalesOrderPageNumber.Text = salesOrderPageNumber + " / " + salesOrderPageList.PageCount;
        }

        private void buttonSalesOrderPageListLast_Click(object sender, EventArgs e)
        {
            salesOrderPageList = new PagedList<Entities.DgvSalesInvoiceSearchSalesOrderEntity>(salesOrderData, salesOrderPageList.PageCount, SalesOrderPageSize);
            salesOrderDataSource.DataSource = salesOrderPageList;

            buttonSalesOrderPageListFirst.Enabled = true;
            buttonSalesOrderPageListPrevious.Enabled = true;
            buttonSalesOrderPageListNext.Enabled = false;
            buttonSalesOrderPageListLast.Enabled = false;

            salesOrderPageNumber = salesOrderPageList.PageCount;
            textBoxSalesOrderPageNumber.Text = salesOrderPageNumber + " / " + salesOrderPageList.PageCount;
        }


        private void textBoxSearchSalesOrderItemFilter_KeyDown(object sender, KeyEventArgs e)
        {
            UpdateSalesOrderDataSource();
        }

        private void TrnSalesInvoiceDetailSearchItemForm_Load(object sender, EventArgs e)
        {

        }

    }
}
