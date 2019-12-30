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
    public partial class MstCompanyListForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;

        public static List<Entities.DgvMstCompanyEntity> companyListData = new List<Entities.DgvMstCompanyEntity>();
        public PagedList<Entities.DgvMstCompanyEntity> companyListPageList = new PagedList<Entities.DgvMstCompanyEntity>(companyListData, pageNumber, pageSize);
        public BindingSource companyListDataSource = new BindingSource();

        public MstCompanyListForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();

            sysSoftwareForm = softwareForm;

            CreateCompanyListDataGridView();
        }

        public void UpdateCompanyListDataSource()
        {
            SetCompanyListDataSourceAsync();
        }

        public async void SetCompanyListDataSourceAsync()
        {
            List<Entities.DgvMstCompanyEntity> getCompanyListData = await GetCompanyListDataTask();
            if (getCompanyListData.Any())
            {
                companyListData = getCompanyListData;
                companyListPageList = new PagedList<Entities.DgvMstCompanyEntity>(companyListData, pageNumber, pageSize);

                if (companyListPageList.PageCount == 1)
                {
                    buttonCompanyListPageListFirst.Enabled = false;
                    buttonCompanyListPageListPrevious.Enabled = false;
                    buttonCompanyListPageListNext.Enabled = false;
                    buttonCompanyListPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonCompanyListPageListFirst.Enabled = false;
                    buttonCompanyListPageListPrevious.Enabled = false;
                    buttonCompanyListPageListNext.Enabled = true;
                    buttonCompanyListPageListLast.Enabled = true;
                }
                else if (pageNumber == companyListPageList.PageCount)
                {
                    buttonCompanyListPageListFirst.Enabled = true;
                    buttonCompanyListPageListPrevious.Enabled = true;
                    buttonCompanyListPageListNext.Enabled = false;
                    buttonCompanyListPageListLast.Enabled = false;
                }
                else
                {
                    buttonCompanyListPageListFirst.Enabled = true;
                    buttonCompanyListPageListPrevious.Enabled = true;
                    buttonCompanyListPageListNext.Enabled = true;
                    buttonCompanyListPageListLast.Enabled = true;
                }

                textBoxCompanyListPageNumber.Text = pageNumber + " / " + companyListPageList.PageCount;
                companyListDataSource.DataSource = companyListPageList;
            }
            else
            {
                buttonCompanyListPageListFirst.Enabled = false;
                buttonCompanyListPageListPrevious.Enabled = false;
                buttonCompanyListPageListNext.Enabled = false;
                buttonCompanyListPageListLast.Enabled = false;

                pageNumber = 1;

                companyListData = new List<Entities.DgvMstCompanyEntity>();
                companyListDataSource.Clear();
                textBoxCompanyListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvMstCompanyEntity>> GetCompanyListDataTask()
        {
            String filter = textBoxCompanyListFilter.Text;
            Controllers.MstCompanyController mstCompanyController = new Controllers.MstCompanyController();

            List<Entities.MstCompanyEntity> listCompany = mstCompanyController.ListCompany();
            if (listCompany.Any())
            {
                var items = from d in listCompany
                            where d.CompanyCode.ToLower().Contains(filter.ToLower())
                            || d.Company.ToLower().Contains(filter.ToLower())
                            select new Entities.DgvMstCompanyEntity
                            {
                                ColumnCompanyListButtonEdit = "Edit",
                                ColumnCompanyListButtonDelete = "Delete",
                                ColumnCompanyListId = d.Id,
                                ColumnCompanyListCompanyCode = d.CompanyCode,
                                ColumnCompanyListCompany = d.Company,
                                ColumnCompanyListIsLocked = d.IsLocked
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvMstCompanyEntity>());
            }
        }

        public void CreateCompanyListDataGridView()
        {
            UpdateCompanyListDataSource();

            dataGridViewCompanyList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewCompanyList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewCompanyList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewCompanyList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewCompanyList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewCompanyList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewCompanyList.DataSource = companyListDataSource;
        }

        public void GetCompanyListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Controllers.MstCompanyController mstCompanyController = new Controllers.MstCompanyController();
            String[] addCompany = mstCompanyController.AddCompany();
            if (addCompany[1].Equals("0") == false)
            {
                sysSoftwareForm.AddTabPageCompanyDetail(this, mstCompanyController.DetailCompany(Convert.ToInt32(addCompany[1])));
                UpdateCompanyListDataSource();
            }
            else
            {
                MessageBox.Show(addCompany[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewCompanyList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetCompanyListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewCompanyList.CurrentCell.ColumnIndex == dataGridViewCompanyList.Columns["ColumnCompanyListButtonEdit"].Index)
            {
                Controllers.MstCompanyController mstCompanyController = new Controllers.MstCompanyController();
                sysSoftwareForm.AddTabPageCompanyDetail(this, mstCompanyController.DetailCompany(Convert.ToInt32(dataGridViewCompanyList.Rows[e.RowIndex].Cells[2].Value)));

            }

            if (e.RowIndex > -1 && dataGridViewCompanyList.CurrentCell.ColumnIndex == dataGridViewCompanyList.Columns["ColumnCompanyListButtonDelete"].Index)
            {
                Boolean isLocked = Convert.ToBoolean(dataGridViewCompanyList.Rows[e.RowIndex].Cells[5].Value);

                if (isLocked == true)
                {
                    MessageBox.Show("Already locked.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult deleteDialogResult = MessageBox.Show("Delete Company?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (deleteDialogResult == DialogResult.Yes)
                    {
                        Controllers.MstCompanyController mstCompanyController = new Controllers.MstCompanyController();

                        String[] deleteCompany = mstCompanyController.DeleteCompany(Convert.ToInt32(dataGridViewCompanyList.Rows[e.RowIndex].Cells[2].Value));
                        if (deleteCompany[1].Equals("0") == false)
                        {
                            Int32 currentPageNumber = pageNumber;

                            pageNumber = 1;
                            UpdateCompanyListDataSource();

                            if (companyListPageList != null)
                            {
                                if (companyListData.Count() % pageSize == 1)
                                {
                                    pageNumber = currentPageNumber - 1;
                                }
                                else if (companyListData.Count() < 1)
                                {
                                    pageNumber = 1;
                                }
                                else
                                {
                                    pageNumber = currentPageNumber;
                                }

                                companyListDataSource.DataSource = companyListPageList;
                            }
                        }
                        else
                        {
                            MessageBox.Show(deleteCompany[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void textBoxCompanyListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateCompanyListDataSource();
            }
        }

        private void buttonCompanyListPageListFirst_Click(object sender, EventArgs e)
        {
            companyListPageList = new PagedList<Entities.DgvMstCompanyEntity>(companyListData, 1, pageSize);
            companyListDataSource.DataSource = companyListPageList;

            buttonCompanyListPageListFirst.Enabled = false;
            buttonCompanyListPageListPrevious.Enabled = false;
            buttonCompanyListPageListNext.Enabled = true;
            buttonCompanyListPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxCompanyListPageNumber.Text = pageNumber + " / " + companyListPageList.PageCount;
        }

        private void buttonCompanyListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (companyListPageList.HasPreviousPage == true)
            {
                companyListPageList = new PagedList<Entities.DgvMstCompanyEntity>(companyListData, --pageNumber, pageSize);
                companyListDataSource.DataSource = companyListPageList;
            }

            buttonCompanyListPageListNext.Enabled = true;
            buttonCompanyListPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonCompanyListPageListFirst.Enabled = false;
                buttonCompanyListPageListPrevious.Enabled = false;
            }

            textBoxCompanyListPageNumber.Text = pageNumber + " / " + companyListPageList.PageCount;
        }

        private void buttonCompanyListPageListNext_Click(object sender, EventArgs e)
        {
            if (companyListPageList.HasNextPage == true)
            {
                companyListPageList = new PagedList<Entities.DgvMstCompanyEntity>(companyListData, ++pageNumber, pageSize);
                companyListDataSource.DataSource = companyListPageList;
            }

            buttonCompanyListPageListFirst.Enabled = true;
            buttonCompanyListPageListPrevious.Enabled = true;

            if (pageNumber == companyListPageList.PageCount)
            {
                buttonCompanyListPageListNext.Enabled = false;
                buttonCompanyListPageListLast.Enabled = false;
            }

            textBoxCompanyListPageNumber.Text = pageNumber + " / " + companyListPageList.PageCount;
        }

        private void buttonCompanyListPageListLast_Click(object sender, EventArgs e)
        {
            companyListPageList = new PagedList<Entities.DgvMstCompanyEntity>(companyListData, companyListPageList.PageCount, pageSize);
            companyListDataSource.DataSource = companyListPageList;

            buttonCompanyListPageListFirst.Enabled = true;
            buttonCompanyListPageListPrevious.Enabled = true;
            buttonCompanyListPageListNext.Enabled = false;
            buttonCompanyListPageListLast.Enabled = false;

            pageNumber = companyListPageList.PageCount;
            textBoxCompanyListPageNumber.Text = pageNumber + " / " + companyListPageList.PageCount;
        }
    }
}
