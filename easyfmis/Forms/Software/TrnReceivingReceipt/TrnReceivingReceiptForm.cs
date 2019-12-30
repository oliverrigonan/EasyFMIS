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

namespace easyfmis.Forms.Software.TrnReceivingReceipt
{
    public partial class TrnReceivingReceiptForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public static List<Entities.DgvReceivingReceiptEntity> itemListData = new List<Entities.DgvReceivingReceiptEntity>();
        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;
        public PagedList<Entities.DgvReceivingReceiptEntity> itemListPageList = new PagedList<Entities.DgvReceivingReceiptEntity>(itemListData, pageNumber, pageSize);
        public BindingSource itemListDataSource = new BindingSource();

        public TrnReceivingReceiptForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            CreateReceivingReceiptDataGridView();
        }

        public void UpdateReceivingReceiptDataSource()
        {
            SetReceivingReceiptDataSourceAsync();
        }

        public async void SetReceivingReceiptDataSourceAsync()
        {
            List<Entities.DgvReceivingReceiptEntity> getReceivingReceiptData = await GetReceivingReceiptDataTask();
            if (getReceivingReceiptData.Any())
            {
                itemListData = getReceivingReceiptData;
                itemListPageList = new PagedList<Entities.DgvReceivingReceiptEntity>(itemListData, pageNumber, pageSize);

                if (itemListPageList.PageCount == 1)
                {
                    buttonReceivingReceiptPageListFirst.Enabled = false;
                    buttonReceivingReceiptPageListPrevious.Enabled = false;
                    buttonReceivingReceiptPageListNext.Enabled = false;
                    buttonReceivingReceiptPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonReceivingReceiptPageListFirst.Enabled = false;
                    buttonReceivingReceiptPageListPrevious.Enabled = false;
                    buttonReceivingReceiptPageListNext.Enabled = true;
                    buttonReceivingReceiptPageListLast.Enabled = true;
                }
                else if (pageNumber == itemListPageList.PageCount)
                {
                    buttonReceivingReceiptPageListFirst.Enabled = true;
                    buttonReceivingReceiptPageListPrevious.Enabled = true;
                    buttonReceivingReceiptPageListNext.Enabled = false;
                    buttonReceivingReceiptPageListLast.Enabled = false;
                }
                else
                {
                    buttonReceivingReceiptPageListFirst.Enabled = true;
                    buttonReceivingReceiptPageListPrevious.Enabled = true;
                    buttonReceivingReceiptPageListNext.Enabled = true;
                    buttonReceivingReceiptPageListLast.Enabled = true;
                }

                textBoxReceivingReceiptPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
                itemListDataSource.DataSource = itemListPageList;
            }
            else
            {
                buttonReceivingReceiptPageListFirst.Enabled = false;
                buttonReceivingReceiptPageListPrevious.Enabled = false;
                buttonReceivingReceiptPageListNext.Enabled = false;
                buttonReceivingReceiptPageListLast.Enabled = false;

                pageNumber = 1;

                itemListData = new List<Entities.DgvReceivingReceiptEntity>();
                itemListDataSource.Clear();
                textBoxReceivingReceiptPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvReceivingReceiptEntity>> GetReceivingReceiptDataTask()
        {
            DateTime startDateFilter = dateTimePickerReceivingReceiptFilterStartDate.Value.Date;
            DateTime endDateFilter = dateTimePickerReceivingReceiptFilterEndDate.Value.Date;

            String filter = textBoxReceivingReceiptFilter.Text;
            Controllers.TrnReceivingReceiptController trnReceivingReceiptController = new Controllers.TrnReceivingReceiptController();

            List<Entities.TrnReceivingReceiptEntity> listReceivingReceipt = trnReceivingReceiptController.ListReceivingReceipt(startDateFilter, endDateFilter, filter);
            if (listReceivingReceipt.Any())
            {
                var items = from d in listReceivingReceipt
                            select new Entities.DgvReceivingReceiptEntity
                            {
                                ColumnReceivingReceiptButtonEdit = "Edit",
                                ColumnReceivingReceiptButtonDelete = "Delete",
                                ColumnReceivingReceiptId = d.Id,
                                ColumnReceivingReceiptRRDate = d.RRDate.ToShortDateString(),
                                ColumnReceivingReceiptRRNumber = d.RRNumber,
                                ColumnReceivingReceiptManualRRNumber = d.ManualRRNumber,
                                ColumnReceivingReceiptSupplier = d.Supplier,
                                ColumnReceivingReceiptRemarks = d.Remarks,
                                ColumnReceivingReceiptAmount = d.Amount.ToString("#,##0.00"),
                                ColumnReceivingReceiptPaidAmount = d.PaidAmount.ToString("#,##0.00"),
                                ColumnReceivingReceiptIsLocked = d.IsLocked,
                                ColumnReceivingReceiptSpace = ""
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvReceivingReceiptEntity>());
            }
        }

        public void CreateReceivingReceiptDataGridView()
        {
            UpdateReceivingReceiptDataSource();

            dataGridViewReceivingReceipt.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewReceivingReceipt.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewReceivingReceipt.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewReceivingReceipt.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewReceivingReceipt.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewReceivingReceipt.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewReceivingReceipt.DataSource = itemListDataSource;
        }

        public void GetReceivingReceiptCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Controllers.TrnReceivingReceiptController trnReceivingReceiptController = new Controllers.TrnReceivingReceiptController();
            String[] addReceivingReceipt = trnReceivingReceiptController.AddReceivingReceipt();
            if (addReceivingReceipt[1].Equals("0") == false)
            {
                sysSoftwareForm.AddTabPageReceivingReceiptDetail(this, trnReceivingReceiptController.DetailReceivingReceipt(Convert.ToInt32(addReceivingReceipt[1])));
                UpdateReceivingReceiptDataSource();
            }
            else
            {
                MessageBox.Show(addReceivingReceipt[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
            sysSoftwareForm.RemoveTabPage();
        }

        private void dataGridViewReceivingReceipt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetReceivingReceiptCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewReceivingReceipt.CurrentCell.ColumnIndex == dataGridViewReceivingReceipt.Columns["ColumnReceivingReceiptButtonEdit"].Index)
            {
                Controllers.TrnReceivingReceiptController trnReceivingReceiptController = new Controllers.TrnReceivingReceiptController();
                sysSoftwareForm.AddTabPageReceivingReceiptDetail(this, trnReceivingReceiptController.DetailReceivingReceipt(Convert.ToInt32(dataGridViewReceivingReceipt.Rows[e.RowIndex].Cells[2].Value)));
            }

            if (e.RowIndex > -1 && dataGridViewReceivingReceipt.CurrentCell.ColumnIndex == dataGridViewReceivingReceipt.Columns["ColumnReceivingReceiptButtonDelete"].Index)
            {
                Boolean isLocked = Convert.ToBoolean(dataGridViewReceivingReceipt.Rows[e.RowIndex].Cells[dataGridViewReceivingReceipt.Columns["ColumnReceivingReceiptIsLocked"].Index].Value);

                if (isLocked == true)
                {
                    MessageBox.Show("Already locked.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult deleteDialogResult = MessageBox.Show("Delete Stock-In?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (deleteDialogResult == DialogResult.Yes)
                    {
                        Controllers.TrnReceivingReceiptController trnReceivingReceiptController = new Controllers.TrnReceivingReceiptController();

                        String[] deleteReceivingReceipt = trnReceivingReceiptController.DeleteReceivingReceipt(Convert.ToInt32(dataGridViewReceivingReceipt.Rows[e.RowIndex].Cells[2].Value));
                        if (deleteReceivingReceipt[1].Equals("0") == false)
                        {
                            pageNumber = 1;
                            UpdateReceivingReceiptDataSource();
                        }
                        else
                        {
                            MessageBox.Show(deleteReceivingReceipt[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void dateTimePickerReceivingReceiptFilterStartDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateReceivingReceiptDataSource();
        }

        private void dateTimePickerReceivingReceiptFilterEndDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateReceivingReceiptDataSource();
        }

        private void textBoxReceivingReceiptFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateReceivingReceiptDataSource();
            }
        }

        private void buttonReceivingReceiptPageListFirst_Click(object sender, EventArgs e)
        {
            itemListPageList = new PagedList<Entities.DgvReceivingReceiptEntity>(itemListData, 1, pageSize);
            itemListDataSource.DataSource = itemListPageList;

            buttonReceivingReceiptPageListFirst.Enabled = false;
            buttonReceivingReceiptPageListPrevious.Enabled = false;
            buttonReceivingReceiptPageListNext.Enabled = true;
            buttonReceivingReceiptPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxReceivingReceiptPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonReceivingReceiptPageListPrevious_Click(object sender, EventArgs e)
        {
            if (itemListPageList.HasPreviousPage == true)
            {
                itemListPageList = new PagedList<Entities.DgvReceivingReceiptEntity>(itemListData, --pageNumber, pageSize);
                itemListDataSource.DataSource = itemListPageList;
            }

            buttonReceivingReceiptPageListNext.Enabled = true;
            buttonReceivingReceiptPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonReceivingReceiptPageListFirst.Enabled = false;
                buttonReceivingReceiptPageListPrevious.Enabled = false;
            }

            textBoxReceivingReceiptPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonReceivingReceiptPageListNext_Click(object sender, EventArgs e)
        {
            if (itemListPageList.HasNextPage == true)
            {
                itemListPageList = new PagedList<Entities.DgvReceivingReceiptEntity>(itemListData, ++pageNumber, pageSize);
                itemListDataSource.DataSource = itemListPageList;
            }

            buttonReceivingReceiptPageListFirst.Enabled = true;
            buttonReceivingReceiptPageListPrevious.Enabled = true;

            if (pageNumber == itemListPageList.PageCount)
            {
                buttonReceivingReceiptPageListNext.Enabled = false;
                buttonReceivingReceiptPageListLast.Enabled = false;
            }

            textBoxReceivingReceiptPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonReceivingReceiptPageListLast_Click(object sender, EventArgs e)
        {
            itemListPageList = new PagedList<Entities.DgvReceivingReceiptEntity>(itemListData, itemListPageList.PageCount, pageSize);
            itemListDataSource.DataSource = itemListPageList;

            buttonReceivingReceiptPageListFirst.Enabled = true;
            buttonReceivingReceiptPageListPrevious.Enabled = true;
            buttonReceivingReceiptPageListNext.Enabled = false;
            buttonReceivingReceiptPageListLast.Enabled = false;

            pageNumber = itemListPageList.PageCount;
            textBoxReceivingReceiptPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }
    }
}
