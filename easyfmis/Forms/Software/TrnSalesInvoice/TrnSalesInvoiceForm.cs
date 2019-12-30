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

namespace easyfmis.Forms.Software.TrnSalesInvoice
{
    public partial class TrnSalesInvoiceForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public static List<Entities.DgvSalesInvoiceEntity> itemListData = new List<Entities.DgvSalesInvoiceEntity>();
        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;
        public PagedList<Entities.DgvSalesInvoiceEntity> itemListPageList = new PagedList<Entities.DgvSalesInvoiceEntity>(itemListData, pageNumber, pageSize);
        public BindingSource itemListDataSource = new BindingSource();

        public TrnSalesInvoiceForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            CreateSalesInvoiceDataGridView();
        }

        public void UpdateSalesInvoiceDataSource()
        {
            SetSalesInvoiceDataSourceAsync();
        }

        public async void SetSalesInvoiceDataSourceAsync()
        {
            List<Entities.DgvSalesInvoiceEntity> getSalesInvoiceData = await GetSalesInvoiceDataTask();
            if (getSalesInvoiceData.Any())
            {
                itemListData = getSalesInvoiceData;
                itemListPageList = new PagedList<Entities.DgvSalesInvoiceEntity>(itemListData, pageNumber, pageSize);

                if (itemListPageList.PageCount == 1)
                {
                    buttonSalesInvoicePageListFirst.Enabled = false;
                    buttonSalesInvoicePageListPrevious.Enabled = false;
                    buttonSalesInvoicePageListNext.Enabled = false;
                    buttonSalesInvoicePageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonSalesInvoicePageListFirst.Enabled = false;
                    buttonSalesInvoicePageListPrevious.Enabled = false;
                    buttonSalesInvoicePageListNext.Enabled = true;
                    buttonSalesInvoicePageListLast.Enabled = true;
                }
                else if (pageNumber == itemListPageList.PageCount)
                {
                    buttonSalesInvoicePageListFirst.Enabled = true;
                    buttonSalesInvoicePageListPrevious.Enabled = true;
                    buttonSalesInvoicePageListNext.Enabled = false;
                    buttonSalesInvoicePageListLast.Enabled = false;
                }
                else
                {
                    buttonSalesInvoicePageListFirst.Enabled = true;
                    buttonSalesInvoicePageListPrevious.Enabled = true;
                    buttonSalesInvoicePageListNext.Enabled = true;
                    buttonSalesInvoicePageListLast.Enabled = true;
                }

                textBoxSalesInvoicePageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
                itemListDataSource.DataSource = itemListPageList;
            }
            else
            {
                buttonSalesInvoicePageListFirst.Enabled = false;
                buttonSalesInvoicePageListPrevious.Enabled = false;
                buttonSalesInvoicePageListNext.Enabled = false;
                buttonSalesInvoicePageListLast.Enabled = false;

                pageNumber = 1;

                itemListData = new List<Entities.DgvSalesInvoiceEntity>();
                itemListDataSource.Clear();
                textBoxSalesInvoicePageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvSalesInvoiceEntity>> GetSalesInvoiceDataTask()
        {
            DateTime startDateateFilter = dateTimePickerSalesInvoiceFilterStartDate.Value.Date;
            DateTime endDateFilter = dateTimePickerSalesInvoiceFilterStartDate.Value.Date;

            String filter = textBoxSalesInvoiceFilter.Text;
            Controllers.TrnSalesInvoiceController trnSalesInvoiceController = new Controllers.TrnSalesInvoiceController();

            List<Entities.TrnSalesInvoiceEntity> listSalesInvoice = trnSalesInvoiceController.ListSalesInvoice(startDateateFilter, endDateFilter, filter);
            if (listSalesInvoice.Any())
            {
                var items = from d in listSalesInvoice
                            select new Entities.DgvSalesInvoiceEntity
                            {
                                ColumnSalesInvoiceButtonEdit = "Edit",
                                ColumnSalesInvoiceButtonDelete = "Delete",
                                ColumnSalesInvoiceId = d.Id,
                                ColumnSalesInvoiceSIDate = d.SIDate.ToShortDateString(),
                                ColumnSalesInvoiceSINumber = d.SINumber,
                                ColumnSalesInvoiceManualSINumber = d.ManualSINumber,
                                ColumnSalesInvoiceCustomer = d.Customer,
                                ColumnSalesInvoiceRemarks = d.Remarks,
                                ColumnSalesInvoiceAmount = d.Amount.ToString("#,##0.00"),
                                ColumnSalesInvoicePaidAmount = d.PaidAmount.ToString("#,##0.00"),
                                ColumnSalesInvoiceIsLocked = d.IsLocked,
                                ColumnSalesInvoiceSpace = ""
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvSalesInvoiceEntity>());
            }
        }

        public void CreateSalesInvoiceDataGridView()
        {
            UpdateSalesInvoiceDataSource();

            dataGridViewSalesInvoice.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSalesInvoice.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSalesInvoice.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewSalesInvoice.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewSalesInvoice.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewSalesInvoice.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewSalesInvoice.DataSource = itemListDataSource;
        }

        public void GetSalesInvoiceCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Controllers.TrnSalesInvoiceController trnSalesInvoiceController = new Controllers.TrnSalesInvoiceController();
            String[] addSalesInvoice = trnSalesInvoiceController.AddSalesInvoice();
            if (addSalesInvoice[1].Equals("0") == false)
            {
                sysSoftwareForm.AddTabPageSalesInvoiceDetail(this, trnSalesInvoiceController.DetailSalesInvoice(Convert.ToInt32(addSalesInvoice[1])));
                UpdateSalesInvoiceDataSource();
            }
            else
            {
                MessageBox.Show(addSalesInvoice[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
            sysSoftwareForm.RemoveTabPage();
        }

        private void dataGridViewSalesInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetSalesInvoiceCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewSalesInvoice.CurrentCell.ColumnIndex == dataGridViewSalesInvoice.Columns["ColumnSalesInvoiceButtonEdit"].Index)
            {
                Controllers.TrnSalesInvoiceController trnSalesInvoiceController = new Controllers.TrnSalesInvoiceController();
                sysSoftwareForm.AddTabPageSalesInvoiceDetail(this, trnSalesInvoiceController.DetailSalesInvoice(Convert.ToInt32(dataGridViewSalesInvoice.Rows[e.RowIndex].Cells[2].Value)));
            }

            if (e.RowIndex > -1 && dataGridViewSalesInvoice.CurrentCell.ColumnIndex == dataGridViewSalesInvoice.Columns["ColumnSalesInvoiceButtonDelete"].Index)
            {
                Boolean isLocked = Convert.ToBoolean(dataGridViewSalesInvoice.Rows[e.RowIndex].Cells[dataGridViewSalesInvoice.Columns["ColumnSalesInvoiceIsLocked"].Index].Value);

                if (isLocked == true)
                {
                    MessageBox.Show("Already locked.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult deleteDialogResult = MessageBox.Show("Delete Stock-In?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (deleteDialogResult == DialogResult.Yes)
                    {
                        Controllers.TrnSalesInvoiceController trnSalesInvoiceController = new Controllers.TrnSalesInvoiceController();

                        String[] deleteSalesInvoice = trnSalesInvoiceController.DeleteSalesInvoice(Convert.ToInt32(dataGridViewSalesInvoice.Rows[e.RowIndex].Cells[2].Value));
                        if (deleteSalesInvoice[1].Equals("0") == false)
                        {
                            pageNumber = 1;
                            UpdateSalesInvoiceDataSource();
                        }
                        else
                        {
                            MessageBox.Show(deleteSalesInvoice[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void dateTimePickerSalesInvoiceFilterStartDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateSalesInvoiceDataSource();
        }

        private void dateTimePickerSalesInvoiceFilterEndDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateSalesInvoiceDataSource();
        }

        private void textBoxSalesInvoiceFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateSalesInvoiceDataSource();
            }
        }

        private void buttonSalesInvoicePageListFirst_Click(object sender, EventArgs e)
        {
            itemListPageList = new PagedList<Entities.DgvSalesInvoiceEntity>(itemListData, 1, pageSize);
            itemListDataSource.DataSource = itemListPageList;

            buttonSalesInvoicePageListFirst.Enabled = false;
            buttonSalesInvoicePageListPrevious.Enabled = false;
            buttonSalesInvoicePageListNext.Enabled = true;
            buttonSalesInvoicePageListLast.Enabled = true;

            pageNumber = 1;
            textBoxSalesInvoicePageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonSalesInvoicePageListPrevious_Click(object sender, EventArgs e)
        {
            if (itemListPageList.HasPreviousPage == true)
            {
                itemListPageList = new PagedList<Entities.DgvSalesInvoiceEntity>(itemListData, --pageNumber, pageSize);
                itemListDataSource.DataSource = itemListPageList;
            }

            buttonSalesInvoicePageListNext.Enabled = true;
            buttonSalesInvoicePageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonSalesInvoicePageListFirst.Enabled = false;
                buttonSalesInvoicePageListPrevious.Enabled = false;
            }

            textBoxSalesInvoicePageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonSalesInvoicePageListNext_Click(object sender, EventArgs e)
        {
            if (itemListPageList.HasNextPage == true)
            {
                itemListPageList = new PagedList<Entities.DgvSalesInvoiceEntity>(itemListData, ++pageNumber, pageSize);
                itemListDataSource.DataSource = itemListPageList;
            }

            buttonSalesInvoicePageListFirst.Enabled = true;
            buttonSalesInvoicePageListPrevious.Enabled = true;

            if (pageNumber == itemListPageList.PageCount)
            {
                buttonSalesInvoicePageListNext.Enabled = false;
                buttonSalesInvoicePageListLast.Enabled = false;
            }

            textBoxSalesInvoicePageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonSalesInvoicePageListLast_Click(object sender, EventArgs e)
        {
            itemListPageList = new PagedList<Entities.DgvSalesInvoiceEntity>(itemListData, itemListPageList.PageCount, pageSize);
            itemListDataSource.DataSource = itemListPageList;

            buttonSalesInvoicePageListFirst.Enabled = true;
            buttonSalesInvoicePageListPrevious.Enabled = true;
            buttonSalesInvoicePageListNext.Enabled = false;
            buttonSalesInvoicePageListLast.Enabled = false;

            pageNumber = itemListPageList.PageCount;
            textBoxSalesInvoicePageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }
    }
}
