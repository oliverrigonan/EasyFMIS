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

namespace easyfmis.Forms.Software.MstCustomer
{
    public partial class MstCustomerListForm : Form
    {

        public SysSoftwareForm sysSoftwareForm;

        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;

        public static List<Entities.DgvMstCustomerEntities> customerListData = new List<Entities.DgvMstCustomerEntities>();
        public PagedList<Entities.DgvMstCustomerEntities> customerListPageList = new PagedList<Entities.DgvMstCustomerEntities>(customerListData, pageNumber, pageSize);
        public BindingSource customerListDataSource = new BindingSource();

        public MstCustomerListForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();

            sysSoftwareForm = softwareForm;

            CreateCustomerListDataGridView();
        }

        public void UpdateCustomerListDataSource()
        {
            SetCustomerListDataSourceAsync();
        }

        public async void SetCustomerListDataSourceAsync()
        {
            List<Entities.DgvMstCustomerEntities> getCustomerListData = await GetCustomerListDataTask();
            if (getCustomerListData.Any())
            {
                customerListData = getCustomerListData;
                customerListPageList = new PagedList<Entities.DgvMstCustomerEntities>(customerListData, pageNumber, pageSize);

                if (customerListPageList.PageCount == 1)
                {
                    buttonCustomerListPageListFirst.Enabled = false;
                    buttonCustomerListPageListPrevious.Enabled = false;
                    buttonCustomerListPageListNext.Enabled = false;
                    buttonCustomerListPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonCustomerListPageListFirst.Enabled = false;
                    buttonCustomerListPageListPrevious.Enabled = false;
                    buttonCustomerListPageListNext.Enabled = true;
                    buttonCustomerListPageListLast.Enabled = true;
                }
                else if (pageNumber == customerListPageList.PageCount)
                {
                    buttonCustomerListPageListFirst.Enabled = true;
                    buttonCustomerListPageListPrevious.Enabled = true;
                    buttonCustomerListPageListNext.Enabled = false;
                    buttonCustomerListPageListLast.Enabled = false;
                }
                else
                {
                    buttonCustomerListPageListFirst.Enabled = true;
                    buttonCustomerListPageListPrevious.Enabled = true;
                    buttonCustomerListPageListNext.Enabled = true;
                    buttonCustomerListPageListLast.Enabled = true;
                }

                textBoxCustomerListPageNumber.Text = pageNumber + " / " + customerListPageList.PageCount;
                customerListDataSource.DataSource = customerListPageList;
            }
            else
            {
                buttonCustomerListPageListFirst.Enabled = false;
                buttonCustomerListPageListPrevious.Enabled = false;
                buttonCustomerListPageListNext.Enabled = false;
                buttonCustomerListPageListLast.Enabled = false;

                pageNumber = 1;

                customerListData = new List<Entities.DgvMstCustomerEntities>();
                customerListDataSource.Clear();
                textBoxCustomerListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvMstCustomerEntities>> GetCustomerListDataTask()
        {
            String filter = textBoxCustomerListFilter.Text;
            Controllers.MstArticleController mstCustomerController = new Controllers.MstArticleController();

            List<Entities.MstArticleEntity> listCustomer = mstCustomerController.ListArticle(2);
            if (listCustomer.Any())
            {
                var items = from d in listCustomer
                            where d.ArticleCode.Contains(filter)
                            || d.ArticleBarCode.Contains(filter)
                            || d.Article.Contains(filter)
                            || d.Category.Contains(filter)
                            select new Entities.DgvMstCustomerEntities
                            {
                                ColumnCustomerListButtonEdit = "Edit",
                                ColumnCustomerListButtonDelete = "Delete",
                                ColumnCustomerListId = d.Id,
                                ColumnCustomerListCustomerCode = d.ArticleCode,
                                ColumnCustomerListCustomer = d.Article,
                                ColumnCustomerListAddress = d.Address,
                                ColumnCustomerListContactNumber = d.ContactNumber,
                                ColumnCustomerListIsLocked = d.IsLocked,
                                ColumnCustomerListSpace = ""
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvMstCustomerEntities>());
            }
        }

        public void CreateCustomerListDataGridView()
        {
            UpdateCustomerListDataSource();

            dataGridViewCustomerList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewCustomerList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewCustomerList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewCustomerList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewCustomerList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewCustomerList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewCustomerList.DataSource = customerListDataSource;
        }

        public void GetCustomerListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Controllers.MstArticleController mstCustomerController = new Controllers.MstArticleController();
            String[] addCustomer = mstCustomerController.AddArticle("CUSTOMER");
            if (addCustomer[1].Equals("0") == false)
            {
                sysSoftwareForm.AddTabPageCustomerDetail(this, mstCustomerController.DetailArticle(Convert.ToInt32(addCustomer[1])));
                UpdateCustomerListDataSource();
            }
            else
            {
                MessageBox.Show(addCustomer[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewCustomerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetCustomerListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewCustomerList.CurrentCell.ColumnIndex == dataGridViewCustomerList.Columns["ColumnCustomerListButtonEdit"].Index)
            {
                Controllers.MstArticleController mstCustomerController = new Controllers.MstArticleController();
                sysSoftwareForm.AddTabPageCustomerDetail(this, mstCustomerController.DetailArticle(Convert.ToInt32(dataGridViewCustomerList.Rows[e.RowIndex].Cells[2].Value)));
            }

            if (e.RowIndex > -1 && dataGridViewCustomerList.CurrentCell.ColumnIndex == dataGridViewCustomerList.Columns["ColumnCustomerListButtonDelete"].Index)
            {
                Boolean isLocked = Convert.ToBoolean(dataGridViewCustomerList.Rows[e.RowIndex].Cells[7].Value);

                if (isLocked == true)
                {
                    MessageBox.Show("Already locked.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult deleteDialogResult = MessageBox.Show("Delete Customer?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (deleteDialogResult == DialogResult.Yes)
                    {
                        Controllers.MstArticleController mstCustomerController = new Controllers.MstArticleController();

                        String[] deleteCustomer = mstCustomerController.DeleteArticle(Convert.ToInt32(dataGridViewCustomerList.Rows[e.RowIndex].Cells[2].Value));
                        if (deleteCustomer[1].Equals("0") == false)
                        {
                            Int32 currentPageNumber = pageNumber;

                            pageNumber = 1;
                            UpdateCustomerListDataSource();

                            if (customerListPageList != null)
                            {
                                if (customerListData.Count() % pageSize == 1)
                                {
                                    pageNumber = currentPageNumber - 1;
                                }
                                else if (customerListData.Count() < 1)
                                {
                                    pageNumber = 1;
                                }
                                else
                                {
                                    pageNumber = currentPageNumber;
                                }

                                customerListDataSource.DataSource = customerListPageList;
                            }
                        }
                        else
                        {
                            MessageBox.Show(deleteCustomer[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void textBoxCustomerListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateCustomerListDataSource();
            }
        }

        private void buttonCustomerListPageListFirst_Click(object sender, EventArgs e)
        {
            customerListPageList = new PagedList<Entities.DgvMstCustomerEntities>(customerListData, 1, pageSize);
            customerListDataSource.DataSource = customerListPageList;

            buttonCustomerListPageListFirst.Enabled = false;
            buttonCustomerListPageListPrevious.Enabled = false;
            buttonCustomerListPageListNext.Enabled = true;
            buttonCustomerListPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxCustomerListPageNumber.Text = pageNumber + " / " + customerListPageList.PageCount;
        }

        private void buttonCustomerListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (customerListPageList.HasPreviousPage == true)
            {
                customerListPageList = new PagedList<Entities.DgvMstCustomerEntities>(customerListData, --pageNumber, pageSize);
                customerListDataSource.DataSource = customerListPageList;
            }

            buttonCustomerListPageListNext.Enabled = true;
            buttonCustomerListPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonCustomerListPageListFirst.Enabled = false;
                buttonCustomerListPageListPrevious.Enabled = false;
            }

            textBoxCustomerListPageNumber.Text = pageNumber + " / " + customerListPageList.PageCount;
        }

        private void buttonCustomerListPageListNext_Click(object sender, EventArgs e)
        {
            if (customerListPageList.HasNextPage == true)
            {
                customerListPageList = new PagedList<Entities.DgvMstCustomerEntities>(customerListData, ++pageNumber, pageSize);
                customerListDataSource.DataSource = customerListPageList;
            }

            buttonCustomerListPageListFirst.Enabled = true;
            buttonCustomerListPageListPrevious.Enabled = true;

            if (pageNumber == customerListPageList.PageCount)
            {
                buttonCustomerListPageListNext.Enabled = false;
                buttonCustomerListPageListLast.Enabled = false;
            }

            textBoxCustomerListPageNumber.Text = pageNumber + " / " + customerListPageList.PageCount;
        }

        private void buttonCustomerListPageListLast_Click(object sender, EventArgs e)
        {
            customerListPageList = new PagedList<Entities.DgvMstCustomerEntities>(customerListData, customerListPageList.PageCount, pageSize);
            customerListDataSource.DataSource = customerListPageList;

            buttonCustomerListPageListFirst.Enabled = true;
            buttonCustomerListPageListPrevious.Enabled = true;
            buttonCustomerListPageListNext.Enabled = false;
            buttonCustomerListPageListLast.Enabled = false;

            pageNumber = customerListPageList.PageCount;
            textBoxCustomerListPageNumber.Text = pageNumber + " / " + customerListPageList.PageCount;
        }
    }
}
