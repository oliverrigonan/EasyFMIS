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

namespace easyfmis.Forms.Software.TrnDisbursement
{
    public partial class TrnDisbursementListForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public static List<Entities.DgvDisbursementEntity> disbursementListData = new List<Entities.DgvDisbursementEntity>();
        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;
        public PagedList<Entities.DgvDisbursementEntity> disbursementListPageList = new PagedList<Entities.DgvDisbursementEntity>(disbursementListData, pageNumber, pageSize);
        public BindingSource disbursementListDataSource = new BindingSource();

        public TrnDisbursementListForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            CreateDisbursementDataGridView();
        }

        public void UpdateDisbursementDataSource()
        {
            SetDisbursementDataSourceAsync();
        }

        public async void SetDisbursementDataSourceAsync()
        {
            List<Entities.DgvDisbursementEntity> getDisbursementData = await GetDisbursementDataTask();
            if (getDisbursementData.Any())
            {
                disbursementListData = getDisbursementData;
                disbursementListPageList = new PagedList<Entities.DgvDisbursementEntity>(disbursementListData, pageNumber, pageSize);

                if (disbursementListPageList.PageCount == 1)
                {
                    buttonDisbursementPageListFirst.Enabled = false;
                    buttonDisbursementPageListPrevious.Enabled = false;
                    buttonDisbursementPageListNext.Enabled = false;
                    buttonDisbursementPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonDisbursementPageListFirst.Enabled = false;
                    buttonDisbursementPageListPrevious.Enabled = false;
                    buttonDisbursementPageListNext.Enabled = true;
                    buttonDisbursementPageListLast.Enabled = true;
                }
                else if (pageNumber == disbursementListPageList.PageCount)
                {
                    buttonDisbursementPageListFirst.Enabled = true;
                    buttonDisbursementPageListPrevious.Enabled = true;
                    buttonDisbursementPageListNext.Enabled = false;
                    buttonDisbursementPageListLast.Enabled = false;
                }
                else
                {
                    buttonDisbursementPageListFirst.Enabled = true;
                    buttonDisbursementPageListPrevious.Enabled = true;
                    buttonDisbursementPageListNext.Enabled = true;
                    buttonDisbursementPageListLast.Enabled = true;
                }

                textBoxDisbursementPageNumber.Text = pageNumber + " / " + disbursementListPageList.PageCount;
                disbursementListDataSource.DataSource = disbursementListPageList;
            }
            else
            {
                buttonDisbursementPageListFirst.Enabled = false;
                buttonDisbursementPageListPrevious.Enabled = false;
                buttonDisbursementPageListNext.Enabled = false;
                buttonDisbursementPageListLast.Enabled = false;

                pageNumber = 1;

                disbursementListData = new List<Entities.DgvDisbursementEntity>();
                disbursementListDataSource.Clear();
                textBoxDisbursementPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvDisbursementEntity>> GetDisbursementDataTask()
        {
            DateTime startDateFilter = dateTimePickerDisbursementFilterStartDate.Value.Date;
            DateTime endDateFilter = dateTimePickerDisbursementFilterEndDate.Value.Date;

            String filter = textBoxDisbursementFilter.Text;
            Controllers.TrnDisbursementController trnDisbursementController = new Controllers.TrnDisbursementController();

            List<Entities.TrnDisbursementEntity> listDisbursment = trnDisbursementController.ListDisbursement(startDateFilter, endDateFilter, filter);
            if (listDisbursment.Any())
            {
                var disbursement = from d in listDisbursment
                                    select new Entities.DgvDisbursementEntity
                                    {
                                        ColumnDisbursementListButtonEdit = "Edit",
                                        ColumnDisbursementListButtonDelete = "Delete",
                                        ColumnDisbursementListId = d.Id,
                                        ColumnDisbursementListCVDate = d.CVDate.ToShortDateString(),
                                        ColumnDisbursementListCVNumber = d.CVNumber,
                                        ColumnDisbursementListSupplier = d.Supplier,
                                        ColumnDisbursementListRemarks = d.Remarks,
                                        ColumnDisbursementListAmount = d.Amount.ToString("#,##0.00"),
                                        ColumnDisbursementListIsCrossCheck = d.IsCrossCheck,
                                        ColumnDisbursementListIsClear = d.IsClear,
                                        ColumnDisbursementListIsLocked = d.IsLocked,
                                        ColumnDisbursementListSpace = ""
                                    };

                return Task.FromResult(disbursement.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvDisbursementEntity>());
            }
        }

        public void CreateDisbursementDataGridView()
        {
            UpdateDisbursementDataSource();

            dataGridViewDisbursement.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewDisbursement.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewDisbursement.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewDisbursement.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewDisbursement.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewDisbursement.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewDisbursement.DataSource = disbursementListDataSource;
        }

        public void GetDisbursementCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Controllers.TrnDisbursementController trnDisbursementController = new Controllers.TrnDisbursementController();

            String[] addDisbursement = trnDisbursementController.AddDisbursement();
            if (addDisbursement[1].Equals("0") == false)
            {
                sysSoftwareForm.AddTabPageDisbursementDetail(this, trnDisbursementController.DetailDisbursement(Convert.ToInt32(addDisbursement[1])));
                UpdateDisbursementDataSource();
            }
            else
            {
                MessageBox.Show(addDisbursement[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
            sysSoftwareForm.RemoveTabPage();
        }

        private void dataGridViewDisbursement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetDisbursementCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewDisbursement.CurrentCell.ColumnIndex == dataGridViewDisbursement.Columns["ColumnDisbursementListButtonEdit"].Index)
            {
                Controllers.TrnDisbursementController trnDisbursementController = new Controllers.TrnDisbursementController();
                sysSoftwareForm.AddTabPageDisbursementDetail(this, trnDisbursementController.DetailDisbursement(Convert.ToInt32(dataGridViewDisbursement.Rows[e.RowIndex].Cells[dataGridViewDisbursement.Columns["ColumnDisbursementListId"].Index].Value)));
            }

            if (e.RowIndex > -1 && dataGridViewDisbursement.CurrentCell.ColumnIndex == dataGridViewDisbursement.Columns["ColumnDisbursementListButtonDelete"].Index)
            {
                Boolean isLocked = Convert.ToBoolean(dataGridViewDisbursement.Rows[e.RowIndex].Cells[dataGridViewDisbursement.Columns["ColumnDisbursementListIsLocked"].Index].Value);

                if (isLocked == true)
                {
                    MessageBox.Show("Already locked.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult deleteDialogResult = MessageBox.Show("Delete Sales order?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (deleteDialogResult == DialogResult.Yes)
                    {
                        Controllers.TrnDisbursementController trnDisbursementController = new Controllers.TrnDisbursementController();

                        String[] deleteDisbursement = trnDisbursementController.DeleteDisbursement(Convert.ToInt32(dataGridViewDisbursement.Rows[e.RowIndex].Cells[dataGridViewDisbursement.Columns["ColumnDisbursementListId"].Index].Value));
                        if (deleteDisbursement[1].Equals("0") == false)
                        {
                            pageNumber = 1;
                            UpdateDisbursementDataSource();
                        }
                        else
                        {
                            MessageBox.Show(deleteDisbursement[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void dateTimePickerDisbursementFilterStartDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateDisbursementDataSource();
        }

        private void dateTimePickerDisbursementFilterEndDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateDisbursementDataSource();
        }

        private void textBoxDisbursementFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateDisbursementDataSource();
            }
        }

        private void buttonDisbursementPageListFirst_Click(object sender, EventArgs e)
        {
            disbursementListPageList = new PagedList<Entities.DgvDisbursementEntity>(disbursementListData, 1, pageSize);
            disbursementListDataSource.DataSource = disbursementListPageList;

            buttonDisbursementPageListFirst.Enabled = false;
            buttonDisbursementPageListPrevious.Enabled = false;
            buttonDisbursementPageListNext.Enabled = true;
            buttonDisbursementPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxDisbursementPageNumber.Text = pageNumber + " / " + disbursementListPageList.PageCount;
        }

        private void buttonDisbursementPageListPrevious_Click(object sender, EventArgs e)
        {
            if (disbursementListPageList.HasPreviousPage == true)
            {
                disbursementListPageList = new PagedList<Entities.DgvDisbursementEntity>(disbursementListData, --pageNumber, pageSize);
                disbursementListDataSource.DataSource = disbursementListPageList;
            }

            buttonDisbursementPageListNext.Enabled = true;
            buttonDisbursementPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonDisbursementPageListFirst.Enabled = false;
                buttonDisbursementPageListPrevious.Enabled = false;
            }

            textBoxDisbursementPageNumber.Text = pageNumber + " / " + disbursementListPageList.PageCount;
        }

        private void buttonDisbursementPageListNext_Click(object sender, EventArgs e)
        {
            if (disbursementListPageList.HasNextPage == true)
            {

                disbursementListPageList = new PagedList<Entities.DgvDisbursementEntity>(disbursementListData, ++pageNumber, pageSize);
                disbursementListDataSource.DataSource = disbursementListPageList;
            }

            buttonDisbursementPageListFirst.Enabled = true;
            buttonDisbursementPageListPrevious.Enabled = true;

            if (pageNumber == disbursementListPageList.PageCount)
            {
                buttonDisbursementPageListNext.Enabled = false;
                buttonDisbursementPageListLast.Enabled = false;
            }

            textBoxDisbursementPageNumber.Text = pageNumber + " / " + disbursementListPageList.PageCount;
        }

        private void buttonDisbursementPageListLast_Click(object sender, EventArgs e)
        {
            disbursementListPageList = new PagedList<Entities.DgvDisbursementEntity>(disbursementListData, disbursementListPageList.PageCount, pageSize);
            disbursementListDataSource.DataSource = disbursementListPageList;

            buttonDisbursementPageListFirst.Enabled = true;
            buttonDisbursementPageListPrevious.Enabled = true;
            buttonDisbursementPageListNext.Enabled = false;
            buttonDisbursementPageListLast.Enabled = false;

            pageNumber = disbursementListPageList.PageCount;
            textBoxDisbursementPageNumber.Text = pageNumber + " / " + disbursementListPageList.PageCount;
        }
    }
}
