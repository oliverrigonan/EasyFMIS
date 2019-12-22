using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagedList;

namespace easyfmis.Forms.Software.TrnSalesOrder
{
    public partial class TrnSalesOrderForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public static List<Entities.DgvTrnSalesOrderEntity> salesOrderListData = new List<Entities.DgvTrnSalesOrderEntity>();
        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;
        public PagedList<Entities.DgvTrnSalesOrderEntity> salesOrderListPageList = new PagedList<Entities.DgvTrnSalesOrderEntity>(salesOrderListData, pageNumber, pageSize);
        public BindingSource salesOrderListDataSource = new BindingSource();

        public TrnSalesOrderForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            CreateSalesOrderDataGridView();
        }

        public void UpdateSalesOrderDataSource()
        {
            SetSalesOrderDataSourceAsync();
        }

        public async void SetSalesOrderDataSourceAsync()
        {
            List<Entities.DgvTrnSalesOrderEntity> getSalesOrderData = await GetSalesOrderDataTask();
            if (getSalesOrderData.Any())
            {
                salesOrderListData = getSalesOrderData;
                salesOrderListPageList = new PagedList<Entities.DgvTrnSalesOrderEntity>(salesOrderListData, pageNumber, pageSize);

                if (salesOrderListPageList.PageCount == 1)
                {
                    buttonSalesOrderPageListFirst.Enabled = false;
                    buttonSalesOrderPageListPrevious.Enabled = false;
                    buttonSalesOrderPageListNext.Enabled = false;
                    buttonSalesOrderPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonSalesOrderPageListFirst.Enabled = false;
                    buttonSalesOrderPageListPrevious.Enabled = false;
                    buttonSalesOrderPageListNext.Enabled = true;
                    buttonSalesOrderPageListLast.Enabled = true;
                }
                else if (pageNumber == salesOrderListPageList.PageCount)
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

                textBoxSalesOrderPageNumber.Text = pageNumber + " / " + salesOrderListPageList.PageCount;
                salesOrderListDataSource.DataSource = salesOrderListPageList;
            }
            else
            {
                buttonSalesOrderPageListFirst.Enabled = false;
                buttonSalesOrderPageListPrevious.Enabled = false;
                buttonSalesOrderPageListNext.Enabled = false;
                buttonSalesOrderPageListLast.Enabled = false;

                pageNumber = 1;

                salesOrderListData = new List<Entities.DgvTrnSalesOrderEntity>();
                salesOrderListDataSource.Clear();
                textBoxSalesOrderPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvTrnSalesOrderEntity>> GetSalesOrderDataTask()
        {
            DateTime dateFilter = dateTimePickerSalesOrderFilter.Value.Date;
            String filter = textBoxSalesOrderFilter.Text;
            Controllers.TrnSalesOrderController trnSalesOrderController = new Controllers.TrnSalesOrderController();

            List<Entities.TrnSalesOrderEntity> listSalesOrder = trnSalesOrderController.ListSalesOrder(dateFilter, filter);
            if (listSalesOrder.Any())
            {
                var items = from d in listSalesOrder
                            select new Entities.DgvTrnSalesOrderEntity
                            {
                                ColumnTrnSalesOrderListButtonEdit = "Edit",
                                ColumnTrnSalesOrderListButtonDelete = "Delete",
                                ColumnTrnSalesOrderListId = d.Id,
                                ColumnTrnSalesOrderListSODate = d.SODate.ToShortDateString(),
                                ColumnTrnSalesOrderListSONumber = d.SONumber,
                                ColumnTrnSalesOrderListCustomer = d.Customer,
                                ColumnTrnSalesOrderListRemarks = d.Remarks,
                                ColumnTrnSalesOrderListsLocked = d.IsLocked
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvTrnSalesOrderEntity>());
            }
        }

        public void CreateSalesOrderDataGridView()
        {
            UpdateSalesOrderDataSource();

            dataGridViewSalesOrder.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSalesOrder.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSalesOrder.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewSalesOrder.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewSalesOrder.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewSalesOrder.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewSalesOrder.DataSource = salesOrderListDataSource;
        }

        public void GetSalesOrderCurrentSelectedCell
            (Int32 rowIndex)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Controllers.TrnSalesOrderController trnSalesOrderController = new Controllers.TrnSalesOrderController();
            String[] addSalesOrder = trnSalesOrderController.AddSalesOrder();
            if (addSalesOrder[1].Equals("0") == false)
            {
                sysSoftwareForm.AddTabPageSalesOrderDetail(this, trnSalesOrderController.DetailSalesOrder(Convert.ToInt32(addSalesOrder[1])));
                UpdateSalesOrderDataSource();
            }
            else
            {
                MessageBox.Show(addSalesOrder[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
            sysSoftwareForm.RemoveTabPage();
        }

        private void dataGridViewSalesOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetSalesOrderCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewSalesOrder.CurrentCell.ColumnIndex == dataGridViewSalesOrder.Columns["ColumnTrnSalesOrderListButtonEdit"].Index)
            {
                Controllers.TrnSalesOrderController trnSalesOrderController = new Controllers.TrnSalesOrderController();
                sysSoftwareForm.AddTabPageSalesOrderDetail(this, trnSalesOrderController.DetailSalesOrder(Convert.ToInt32(dataGridViewSalesOrder.Rows[e.RowIndex].Cells[dataGridViewSalesOrder.Columns["ColumnTrnSalesOrderListId"].Index].Value)));
            }

            if (e.RowIndex > -1 && dataGridViewSalesOrder.CurrentCell.ColumnIndex == dataGridViewSalesOrder.Columns["ColumnTrnSalesOrderListButtonDelete"].Index)
            {
                Boolean isLocked = Convert.ToBoolean(dataGridViewSalesOrder.Rows[e.RowIndex].Cells[dataGridViewSalesOrder.Columns["ColumnTrnSalesOrderListsLocked"].Index].Value);

                if (isLocked == true)
                {
                    MessageBox.Show("Already locked.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult deleteDialogResult = MessageBox.Show("Delete Sales order?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (deleteDialogResult == DialogResult.Yes)
                    {
                        Controllers.TrnSalesOrderController trnSalesOrderController = new Controllers.TrnSalesOrderController();

                        String[] deleteSalesOrder = trnSalesOrderController.DeleteSalesOrder(Convert.ToInt32(dataGridViewSalesOrder.Rows[e.RowIndex].Cells[dataGridViewSalesOrder.Columns["ColumnTrnSalesOrderListId"].Index].Value));
                        if (deleteSalesOrder[1].Equals("0") == false)
                        {
                            pageNumber = 1;
                            UpdateSalesOrderDataSource();
                        }
                        else
                        {
                            MessageBox.Show(deleteSalesOrder[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void dateTimePickerStockOutFilter_ValueChanged(object sender, EventArgs e)
        {
            UpdateSalesOrderDataSource();
        }

        private void textBoxStockOutFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateSalesOrderDataSource();
            }
        }

        private void buttonStockOutPageListFirst_Click(object sender, EventArgs e)
        {
            salesOrderListPageList = new PagedList<Entities.DgvTrnSalesOrderEntity>(salesOrderListData, 1, pageSize);
            salesOrderListDataSource.DataSource = salesOrderListPageList;

            buttonSalesOrderPageListFirst.Enabled = false;
            buttonSalesOrderPageListPrevious.Enabled = false;
            buttonSalesOrderPageListNext.Enabled = true;
            buttonSalesOrderPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxSalesOrderPageNumber.Text = pageNumber + " / " + salesOrderListPageList.PageCount;
        }

        private void buttonStockOutPageListPrevious_Click(object sender, EventArgs e)
        {
            if (salesOrderListPageList.HasPreviousPage == true)
            {
                salesOrderListPageList = new PagedList<Entities.DgvTrnSalesOrderEntity>(salesOrderListData, --pageNumber, pageSize);
                salesOrderListDataSource.DataSource = salesOrderListPageList;
            }

            buttonSalesOrderPageListNext.Enabled = true;
            buttonSalesOrderPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonSalesOrderPageListFirst.Enabled = false;
                buttonSalesOrderPageListPrevious.Enabled = false;
            }

            textBoxSalesOrderPageNumber.Text = pageNumber + " / " + salesOrderListPageList.PageCount;
        }

        private void buttonStockOutPageListNext_Click(object sender, EventArgs e)
        {
            if (salesOrderListPageList.HasNextPage == true)
            {
                salesOrderListPageList = new PagedList<Entities.DgvTrnSalesOrderEntity>(salesOrderListData, ++pageNumber, pageSize);
                salesOrderListDataSource.DataSource = salesOrderListPageList;
            }

            buttonSalesOrderPageListFirst.Enabled = true;
            buttonSalesOrderPageListPrevious.Enabled = true;

            if (pageNumber == salesOrderListPageList.PageCount)
            {
                buttonSalesOrderPageListNext.Enabled = false;
                buttonSalesOrderPageListLast.Enabled = false;
            }

            textBoxSalesOrderPageNumber.Text = pageNumber + " / " + salesOrderListPageList.PageCount;
        }

        private void buttonStockOutPageListLast_Click(object sender, EventArgs e)
        {
            salesOrderListPageList = new PagedList<Entities.DgvTrnSalesOrderEntity>(salesOrderListData, salesOrderListPageList.PageCount, pageSize);
            salesOrderListDataSource.DataSource = salesOrderListPageList;

            buttonSalesOrderPageListFirst.Enabled = true;
            buttonSalesOrderPageListPrevious.Enabled = true;
            buttonSalesOrderPageListNext.Enabled = false;
            buttonSalesOrderPageListLast.Enabled = false;

            pageNumber = salesOrderListPageList.PageCount;
            textBoxSalesOrderPageNumber.Text = pageNumber + " / " + salesOrderListPageList.PageCount;
        }
    }
}
