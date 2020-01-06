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

namespace easyfmis.Forms.Software.TrnPurchaseOrder
{
    public partial class TrnPurchaseOrderForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public static List<Entities.DgvPurchaseOrderEntity> purchaseOrderListData = new List<Entities.DgvPurchaseOrderEntity>();
        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;
        public PagedList<Entities.DgvPurchaseOrderEntity> purchaseOrderListPageList = new PagedList<Entities.DgvPurchaseOrderEntity>(purchaseOrderListData, pageNumber, pageSize);
        public BindingSource purchaseOrderListDataSource = new BindingSource();

        public TrnPurchaseOrderForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            CreatePurchaseOrderDataGridView();
        }

        public void UpdatePurchaseOrderDataSource()
        {
            SetPurchaseOrderDataSourceAsync();
        }

        public async void SetPurchaseOrderDataSourceAsync()
        {
            List<Entities.DgvPurchaseOrderEntity> getPurchaseOrderData = await GetPurchaseOrderDataTask();
            if (getPurchaseOrderData.Any())
            {
                pageNumber = 1;
                purchaseOrderListData = getPurchaseOrderData;
                purchaseOrderListPageList = new PagedList<Entities.DgvPurchaseOrderEntity>(purchaseOrderListData, pageNumber, pageSize);

                if (purchaseOrderListPageList.PageCount == 1)
                {
                    buttonPurchaseOrderPageListFirst.Enabled = false;
                    buttonPurchaseOrderPageListPrevious.Enabled = false;
                    buttonPurchaseOrderPageListNext.Enabled = false;
                    buttonPurchaseOrderPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonPurchaseOrderPageListFirst.Enabled = false;
                    buttonPurchaseOrderPageListPrevious.Enabled = false;
                    buttonPurchaseOrderPageListNext.Enabled = true;
                    buttonPurchaseOrderPageListLast.Enabled = true;
                }
                else if (pageNumber == purchaseOrderListPageList.PageCount)
                {
                    buttonPurchaseOrderPageListFirst.Enabled = true;
                    buttonPurchaseOrderPageListPrevious.Enabled = true;
                    buttonPurchaseOrderPageListNext.Enabled = false;
                    buttonPurchaseOrderPageListLast.Enabled = false;
                }
                else
                {
                    buttonPurchaseOrderPageListFirst.Enabled = true;
                    buttonPurchaseOrderPageListPrevious.Enabled = true;
                    buttonPurchaseOrderPageListNext.Enabled = true;
                    buttonPurchaseOrderPageListLast.Enabled = true;
                }

                textBoxPurchaseOrderPageNumber.Text = pageNumber + " / " + purchaseOrderListPageList.PageCount;
                purchaseOrderListDataSource.DataSource = purchaseOrderListPageList;
            }
            else
            {
                buttonPurchaseOrderPageListFirst.Enabled = false;
                buttonPurchaseOrderPageListPrevious.Enabled = false;
                buttonPurchaseOrderPageListNext.Enabled = false;
                buttonPurchaseOrderPageListLast.Enabled = false;

                pageNumber = 1;

                purchaseOrderListData = new List<Entities.DgvPurchaseOrderEntity>();
                purchaseOrderListDataSource.Clear();
                textBoxPurchaseOrderPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvPurchaseOrderEntity>> GetPurchaseOrderDataTask()
        {
            DateTime startDateFilter = dateTimePickerPurchaseOrderFilterStartDate.Value.Date;
            DateTime endDateFilter = dateTimePickerPurchaseOrderFilterEndDate.Value.Date;

            String filter = textBoxPurchaseOrderFilter.Text;
            Controllers.TrnPurchaseOrderController trnPurchaseOrderController = new Controllers.TrnPurchaseOrderController();

            List<Entities.TrnPurchaseOrderEntity> listPurchaseOrder = trnPurchaseOrderController.ListPurchaseOrder(startDateFilter, endDateFilter, filter);
            if (listPurchaseOrder.Any())
            {
                var purchaseOrder = from d in listPurchaseOrder
                                    select new Entities.DgvPurchaseOrderEntity
                                    {
                                        ColumnPurchaseOrderListButtonEdit = "Edit",
                                        ColumnPurchaseOrderListButtonDelete = "Delete",
                                        ColumnPurchaseOrderListId = d.Id,
                                        ColumnPurchaseOrderListPONumber = d.PONumber,
                                        ColumnPurchaseOrderListPODate = d.PODate.ToShortDateString(),
                                        ColumnPurchaseOrderListSupplier = d.Supplier,
                                        ColumnPurchaseOrderListRemarks = d.Remarks,
                                        ColumnPurchaseOrderListIsClose = d.IsClose,
                                        ColumnPurchaseOrderListIsLocked = d.IsLocked,
                                    };

                return Task.FromResult(purchaseOrder.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvPurchaseOrderEntity>());
            }
        }

        public void CreatePurchaseOrderDataGridView()
        {
            UpdatePurchaseOrderDataSource();

            dataGridViewPurchaseOrder.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewPurchaseOrder.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewPurchaseOrder.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewPurchaseOrder.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewPurchaseOrder.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewPurchaseOrder.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewPurchaseOrder.DataSource = purchaseOrderListDataSource;
        }

        public void GetPurchaseOrderCurrentSelectedCell
            (Int32 rowIndex)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Controllers.TrnPurchaseOrderController trnPurchaseOrderController = new Controllers.TrnPurchaseOrderController();
            String[] addPurchaseOrder = trnPurchaseOrderController.AddPurchaseOrder();
            if (addPurchaseOrder[1].Equals("0") == false)
            {
                sysSoftwareForm.AddTabPagePurchaseOrderDetail(this, trnPurchaseOrderController.DetailPurchaseOrder(Convert.ToInt32(addPurchaseOrder[1])));
                UpdatePurchaseOrderDataSource();
            }
            else
            {
                MessageBox.Show(addPurchaseOrder[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
            sysSoftwareForm.RemoveTabPage();
        }

        private void dataGridViewPurchaseOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetPurchaseOrderCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewPurchaseOrder.CurrentCell.ColumnIndex == dataGridViewPurchaseOrder.Columns["ColumnPurchaseOrderListButtonEdit"].Index)
            {
                Controllers.TrnPurchaseOrderController trnPurchaseOrderController = new Controllers.TrnPurchaseOrderController();
                sysSoftwareForm.AddTabPagePurchaseOrderDetail(this, trnPurchaseOrderController.DetailPurchaseOrder(Convert.ToInt32(dataGridViewPurchaseOrder.Rows[e.RowIndex].Cells[dataGridViewPurchaseOrder.Columns["ColumnPurchaseOrderListId"].Index].Value)));
            }

            if (e.RowIndex > -1 && dataGridViewPurchaseOrder.CurrentCell.ColumnIndex == dataGridViewPurchaseOrder.Columns["ColumnPurchaseOrderListButtonDelete"].Index)
            {
                Boolean isLocked = Convert.ToBoolean(dataGridViewPurchaseOrder.Rows[e.RowIndex].Cells[dataGridViewPurchaseOrder.Columns["ColumnPurchaseOrderListIsLocked"].Index].Value);

                if (isLocked == true)
                {
                    MessageBox.Show("Already locked.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult deleteDialogResult = MessageBox.Show("Delete Sales order?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (deleteDialogResult == DialogResult.Yes)
                    {
                        Controllers.TrnPurchaseOrderController trnPurchaseOrderController = new Controllers.TrnPurchaseOrderController();

                        String[] deletePurchaseOrder = trnPurchaseOrderController.DeletePurchaseOrder(Convert.ToInt32(dataGridViewPurchaseOrder.Rows[e.RowIndex].Cells[dataGridViewPurchaseOrder.Columns["ColumnPurchaseOrderListId"].Index].Value));
                        if (deletePurchaseOrder[1].Equals("0") == false)
                        {
                            pageNumber = 1;
                            UpdatePurchaseOrderDataSource();
                        }
                        else
                        {
                            MessageBox.Show(deletePurchaseOrder[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void dateTimePickerPurchaseOrderFilterStartDate_ValueChanged(object sender, EventArgs e)
        {
            UpdatePurchaseOrderDataSource();
        }

        private void dateTimePickerPurchaseOrderFilterEndDate_ValueChanged(object sender, EventArgs e)
        {
            UpdatePurchaseOrderDataSource();
        }

        private void textBoxPurchaseOrderFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdatePurchaseOrderDataSource();
            }
        }

        private void buttonPurchaseOrderPageListFirst_Click(object sender, EventArgs e)
        {
            purchaseOrderListPageList = new PagedList<Entities.DgvPurchaseOrderEntity>(purchaseOrderListData, 1, pageSize);
            purchaseOrderListDataSource.DataSource = purchaseOrderListPageList;

            buttonPurchaseOrderPageListFirst.Enabled = false;
            buttonPurchaseOrderPageListPrevious.Enabled = false;
            buttonPurchaseOrderPageListNext.Enabled = true;
            buttonPurchaseOrderPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxPurchaseOrderPageNumber.Text = pageNumber + " / " + purchaseOrderListPageList.PageCount;
        }

        private void buttonPurchaseOrderPageListPrevious_Click(object sender, EventArgs e)
        {
            if (purchaseOrderListPageList.HasPreviousPage == true)
            {
                purchaseOrderListPageList = new PagedList<Entities.DgvPurchaseOrderEntity>(purchaseOrderListData, --pageNumber, pageSize);
                purchaseOrderListDataSource.DataSource = purchaseOrderListPageList;
            }

            buttonPurchaseOrderPageListNext.Enabled = true;
            buttonPurchaseOrderPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonPurchaseOrderPageListFirst.Enabled = false;
                buttonPurchaseOrderPageListPrevious.Enabled = false;
            }

            textBoxPurchaseOrderPageNumber.Text = pageNumber + " / " + purchaseOrderListPageList.PageCount;
        }

        private void buttonPurchaseOrderPageListNext_Click(object sender, EventArgs e)
        {
            if (purchaseOrderListPageList.HasNextPage == true)
            {
                purchaseOrderListPageList = new PagedList<Entities.DgvPurchaseOrderEntity>(purchaseOrderListData, ++pageNumber, pageSize);
                purchaseOrderListDataSource.DataSource = purchaseOrderListPageList;
            }

            buttonPurchaseOrderPageListFirst.Enabled = true;
            buttonPurchaseOrderPageListPrevious.Enabled = true;

            if (pageNumber == purchaseOrderListPageList.PageCount)
            {
                buttonPurchaseOrderPageListNext.Enabled = false;
                buttonPurchaseOrderPageListLast.Enabled = false;
            }

            textBoxPurchaseOrderPageNumber.Text = pageNumber + " / " + purchaseOrderListPageList.PageCount;
        }

        private void buttonPurchaseOrderPageListLast_Click(object sender, EventArgs e)
        {
            purchaseOrderListPageList = new PagedList<Entities.DgvPurchaseOrderEntity>(purchaseOrderListData, purchaseOrderListPageList.PageCount, pageSize);
            purchaseOrderListDataSource.DataSource = purchaseOrderListPageList;

            buttonPurchaseOrderPageListFirst.Enabled = true;
            buttonPurchaseOrderPageListPrevious.Enabled = true;
            buttonPurchaseOrderPageListNext.Enabled = false;
            buttonPurchaseOrderPageListLast.Enabled = false;

            pageNumber = purchaseOrderListPageList.PageCount;
            textBoxPurchaseOrderPageNumber.Text = pageNumber + " / " + purchaseOrderListPageList.PageCount;
        }
    }
}
