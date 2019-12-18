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

namespace easyfmis.Forms.Software.MstCompany
{
    public partial class MstCompanyDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public MstCompanyListForm mstCompanyListForm;
        public Entities.MstCompanyEntity mstCompanyEntity;

        public static List<Entities.DgvMstBranchEntity> branchData = new List<Entities.DgvMstBranchEntity>();
        public static Int32 branchPageNumber = 1;
        public static Int32 branchPageSize = 50;
        public PagedList<Entities.DgvMstBranchEntity> branchPageList = new PagedList<Entities.DgvMstBranchEntity>(branchData, branchPageNumber, branchPageSize);
        public BindingSource branchDataSource = new BindingSource();

        public MstCompanyDetailForm(SysSoftwareForm softwareForm, MstCompanyListForm companyListForm, Entities.MstCompanyEntity companyEntity)
        {
            InitializeComponent();

            sysSoftwareForm = softwareForm;
            mstCompanyListForm = companyListForm;
            mstCompanyEntity = companyEntity;

            GetCompnayDetail();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }


        public void GetCompnayDetail()
        {
            UpdateComponents(mstCompanyEntity.IsLocked);

            textBoxCompanyCode.Text = mstCompanyEntity.CompanyCode;
            textBoxCompany.Text = mstCompanyEntity.Company;

            CreateCompanyFormListDataGridView();

        }

        public void UpdateComponents(Boolean isLocked)
        {
            buttonLock.Enabled = !isLocked;

            buttonUnlock.Enabled = isLocked;

            textBoxCompanyCode.Enabled = !isLocked;
            textBoxCompany.Enabled = !isLocked;

            buttonAddBranch.Enabled = !isLocked;

            dataGridViewBranchFormList.Columns[0].Visible = !isLocked;
            dataGridViewBranchFormList.Columns[1].Visible = !isLocked;
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            Controllers.MstCompanyController mstCompanyController = new Controllers.MstCompanyController();

            mstCompanyEntity.CompanyCode = textBoxCompanyCode.Text;
            mstCompanyEntity.Company = textBoxCompany.Text;

            String[] lockCompany = mstCompanyController.LockCompany(mstCompanyEntity);
            if (lockCompany[1].Equals("0") == false)
            {
                UpdateComponents(true);
                mstCompanyListForm.UpdateCompanyListDataSource();
            }
            else
            {
                UpdateComponents(false);
                MessageBox.Show(lockCompany[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            Controllers.MstCompanyController mstCompanyController = new Controllers.MstCompanyController();

            String[] unlockCompany = mstCompanyController.UnlockCompany(mstCompanyEntity);
            if (unlockCompany[1].Equals("0") == false)
            {
                UpdateComponents(false);
                mstCompanyListForm.UpdateCompanyListDataSource();
            }
            else
            {
                UpdateComponents(true);
                MessageBox.Show(unlockCompany[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateCompanyListDataSource()
        {
            SetCompanyListDataSourceAsync();
        }

        public async void SetCompanyListDataSourceAsync()
        {
            List<Entities.DgvMstBranchEntity> getCompanyFormListData = await GetCompanyListDataTask();
            if (getCompanyFormListData.Any())
            {
                branchData = getCompanyFormListData;
                branchPageList = new PagedList<Entities.DgvMstBranchEntity>(branchData, branchPageNumber, branchPageSize);

                if (branchPageList.PageCount == 1)
                {
                    buttonBranchListPageListFirst.Enabled = false;
                    buttonBranchListPageListPrevious.Enabled = false;
                    buttonBranchListPageListNext.Enabled = false;
                    buttonBranchListPageListLast.Enabled = false;
                }
                else if (branchPageNumber == 1)
                {
                    buttonBranchListPageListFirst.Enabled = false;
                    buttonBranchListPageListPrevious.Enabled = false;
                    buttonBranchListPageListNext.Enabled = true;
                    buttonBranchListPageListLast.Enabled = true;
                }
                else if (branchPageNumber == branchPageList.PageCount)
                {
                    buttonBranchListPageListFirst.Enabled = true;
                    buttonBranchListPageListPrevious.Enabled = true;
                    buttonBranchListPageListNext.Enabled = false;
                    buttonBranchListPageListLast.Enabled = false;
                }
                else
                {
                    buttonBranchListPageListFirst.Enabled = true;
                    buttonBranchListPageListPrevious.Enabled = true;
                    buttonBranchListPageListNext.Enabled = true;
                    buttonBranchListPageListLast.Enabled = true;
                }

                textBoxBranchListPageNumber.Text = branchPageNumber + " / " + branchPageList.PageCount;
                branchDataSource.DataSource = branchPageList;
            }
            else
            {
                buttonBranchListPageListFirst.Enabled = false;
                buttonBranchListPageListPrevious.Enabled = false;
                buttonBranchListPageListNext.Enabled = false;
                buttonBranchListPageListLast.Enabled = false;

                branchPageNumber = 1;

                branchData = new List<Entities.DgvMstBranchEntity>();
                branchDataSource.Clear();
                textBoxBranchListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvMstBranchEntity>> GetCompanyListDataTask()
        {
            Controllers.MstBranchController mstBranchController = new Controllers.MstBranchController();
            List<Entities.MstBranchEntity> listBranch = mstBranchController.ListBranch(mstCompanyEntity.Id);
            if (listBranch.Any())
            {
                var items = from d in listBranch
                            select new Entities.DgvMstBranchEntity
                            {
                                ColumnBranchListButtonEdit = "Edit",
                                ColumnBranchListButtonDelete = "Delete",
                                ColumnBranchListId = d.Id,
                                ColumnBranchListBranchCode = d.BranchCode,
                                ColumnBranchListBranch = d.Branch,
                                ColumnBranchListCompanyId = d.CompanyId
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvMstBranchEntity>());
            }
        }

        public void CreateCompanyFormListDataGridView()
        {
            UpdateCompanyListDataSource();

            dataGridViewBranchFormList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewBranchFormList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewBranchFormList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewBranchFormList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewBranchFormList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewBranchFormList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewBranchFormList.DataSource = branchDataSource;
        }

        public void GetBranchListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewBranchList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetBranchListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewBranchFormList.CurrentCell.ColumnIndex == dataGridViewBranchFormList.Columns["ColumnBranchListButtonEdit"].Index)
            {
                Entities.MstBranchEntity selectedBranch = new Entities.MstBranchEntity()
                {
                    Id = Convert.ToInt32(dataGridViewBranchFormList.Rows[e.RowIndex].Cells[dataGridViewBranchFormList.Columns["ColumnBranchListId"].Index].Value),
                    BranchCode = dataGridViewBranchFormList.Rows[e.RowIndex].Cells[dataGridViewBranchFormList.Columns["ColumnBranchListBranchCode"].Index].Value.ToString(),
                    Branch = dataGridViewBranchFormList.Rows[e.RowIndex].Cells[dataGridViewBranchFormList.Columns["ColumnBranchListBranch"].Index].Value.ToString(),
                    CompanyId = Convert.ToInt32(dataGridViewBranchFormList.Rows[e.RowIndex].Cells[dataGridViewBranchFormList.Columns["ColumnBranchListCompanyId"].Index].Value)
                };

                MstCompanyDetailBranchDetailForm mstCompanyDetailBranchDetailForm = new MstCompanyDetailBranchDetailForm(this, selectedBranch, mstCompanyEntity.Id);
                mstCompanyDetailBranchDetailForm.ShowDialog();

            }

            if (e.RowIndex > -1 && dataGridViewBranchFormList.CurrentCell.ColumnIndex == dataGridViewBranchFormList.Columns["ColumnBranchListButtonDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete Form?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(dataGridViewBranchFormList.Rows[e.RowIndex].Cells[dataGridViewBranchFormList.Columns["ColumnBranchListId"].Index].Value);

                    Controllers.MstBranchController mstBranchController = new Controllers.MstBranchController();
                    String[] deleteCompanyForm = mstBranchController.DeleteBranch(id);
                    if (deleteCompanyForm[1].Equals("0") == false)
                    {
                        branchPageNumber = 1;
                        UpdateCompanyListDataSource();
                    }
                    else
                    {
                        MessageBox.Show(deleteCompanyForm[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonBranchListPageListFirst_Click(object sender, EventArgs e)
        {
            branchPageList = new PagedList<Entities.DgvMstBranchEntity>(branchData, 1, branchPageSize);
            branchDataSource.DataSource = branchPageList;

            buttonBranchListPageListFirst.Enabled = false;
            buttonBranchListPageListPrevious.Enabled = false;
            buttonBranchListPageListNext.Enabled = true;
            buttonBranchListPageListLast.Enabled = true;

            branchPageNumber = 1;
            textBoxBranchListPageNumber.Text = branchPageNumber + " / " + branchPageList.PageCount;
        }

        private void buttonBranchListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (branchPageList.HasPreviousPage == true)
            {
                branchPageList = new PagedList<Entities.DgvMstBranchEntity>(branchData, --branchPageNumber, branchPageSize);
                branchDataSource.DataSource = branchPageList;
            }

            buttonBranchListPageListNext.Enabled = true;
            buttonBranchListPageListLast.Enabled = true;

            if (branchPageNumber == 1)
            {
                buttonBranchListPageListFirst.Enabled = false;
                buttonBranchListPageListPrevious.Enabled = false;
            }

            textBoxBranchListPageNumber.Text = branchPageNumber + " / " + branchPageList.PageCount;
        }

        private void buttonBranchListPageListNext_Click(object sender, EventArgs e)
        {
            if (branchPageList.HasNextPage == true)
            {
                branchPageList = new PagedList<Entities.DgvMstBranchEntity>(branchData, ++branchPageNumber, branchPageSize);
                branchDataSource.DataSource = branchPageList;
            }

            buttonBranchListPageListFirst.Enabled = true;
            buttonBranchListPageListPrevious.Enabled = true;

            if (branchPageNumber == branchPageList.PageCount)
            {
                buttonBranchListPageListNext.Enabled = false;
                buttonBranchListPageListLast.Enabled = false;
            }

            textBoxBranchListPageNumber.Text = branchPageNumber + " / " + branchPageList.PageCount;
        }

        private void buttonBranchListPageListLast_Click(object sender, EventArgs e)
        {
            branchPageList = new PagedList<Entities.DgvMstBranchEntity>(branchData, branchPageList.PageCount, branchPageSize);
            branchDataSource.DataSource = branchPageList;

            buttonBranchListPageListFirst.Enabled = true;
            buttonBranchListPageListPrevious.Enabled = true;
            buttonBranchListPageListNext.Enabled = false;
            buttonBranchListPageListLast.Enabled = false;

            branchPageNumber = branchPageList.PageCount;
            textBoxBranchListPageNumber.Text = branchPageNumber + " / " + branchPageList.PageCount;
        }

        private void buttonAddBranch_Click(object sender, EventArgs e)
        {
            MstCompanyDetailBranchDetailForm mstCompanyDetailBranchDetailForm = new MstCompanyDetailBranchDetailForm(this, null, mstCompanyEntity.Id);
            mstCompanyDetailBranchDetailForm.ShowDialog();
        }
    }
}
