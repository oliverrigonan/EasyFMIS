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

namespace easyfmis.Forms.Software.MstSupplier
{
    public partial class MstSupplierListForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        private Modules.SysUserRightsModule sysUserRights;

        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;

        public static List<Entities.DgvMstSupplierEntities> supplierListData = new List<Entities.DgvMstSupplierEntities>();
        public PagedList<Entities.DgvMstSupplierEntities> supplierListPageList = new PagedList<Entities.DgvMstSupplierEntities>(supplierListData, pageNumber, pageSize);
        public BindingSource supplierListDataSource = new BindingSource();

        public MstSupplierListForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();

            sysSoftwareForm = softwareForm;

            sysUserRights = new Modules.SysUserRightsModule("MstItem");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (sysUserRights.GetUserRights().CanAdd == false)
                {
                    buttonAdd.Enabled = false;
                }

                if (sysUserRights.GetUserRights().CanEdit == false)
                {
                    dataGridViewSupplierList.Columns[0].Visible = false;
                }

                if (sysUserRights.GetUserRights().CanDelete == false)
                {
                    dataGridViewSupplierList.Columns[1].Visible = false;
                }

                CreateSupplierListDataGridView();
            }
        }

        public void UpdateSupplierListDataSource()
        {
            SetSupplierListDataSourceAsync();
        }

        public async void SetSupplierListDataSourceAsync()
        {
            List<Entities.DgvMstSupplierEntities> getSupplierListData = await GetSupplierListDataTask();
            if (getSupplierListData.Any())
            {
                pageNumber = 1;
                supplierListData = getSupplierListData;
                supplierListPageList = new PagedList<Entities.DgvMstSupplierEntities>(supplierListData, pageNumber, pageSize);

                if (supplierListPageList.PageCount == 1)
                {
                    buttonSupplierListPageListFirst.Enabled = false;
                    buttonSupplierListPageListPrevious.Enabled = false;
                    buttonSupplierListPageListNext.Enabled = false;
                    buttonSupplierListPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonSupplierListPageListFirst.Enabled = false;
                    buttonSupplierListPageListPrevious.Enabled = false;
                    buttonSupplierListPageListNext.Enabled = true;
                    buttonSupplierListPageListLast.Enabled = true;
                }
                else if (pageNumber == supplierListPageList.PageCount)
                {
                    buttonSupplierListPageListFirst.Enabled = true;
                    buttonSupplierListPageListPrevious.Enabled = true;
                    buttonSupplierListPageListNext.Enabled = false;
                    buttonSupplierListPageListLast.Enabled = false;
                }
                else
                {
                    buttonSupplierListPageListFirst.Enabled = true;
                    buttonSupplierListPageListPrevious.Enabled = true;
                    buttonSupplierListPageListNext.Enabled = true;
                    buttonSupplierListPageListLast.Enabled = true;
                }

                textBoxSupplierListPageNumber.Text = pageNumber + " / " + supplierListPageList.PageCount;
                supplierListDataSource.DataSource = supplierListPageList;
            }
            else
            {
                buttonSupplierListPageListFirst.Enabled = false;
                buttonSupplierListPageListPrevious.Enabled = false;
                buttonSupplierListPageListNext.Enabled = false;
                buttonSupplierListPageListLast.Enabled = false;

                pageNumber = 1;

                supplierListData = new List<Entities.DgvMstSupplierEntities>();
                supplierListDataSource.Clear();
                textBoxSupplierListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvMstSupplierEntities>> GetSupplierListDataTask()
        {
            String filter = textBoxSupplierListFilter.Text;
            Controllers.MstArticleController mstSupplierController = new Controllers.MstArticleController();

            List<Entities.MstArticleEntity> listSupplier = mstSupplierController.ListArticle(3);
            if (listSupplier.Any())
            {
                var items = from d in listSupplier
                            where d.ArticleCode.ToLower().Contains(filter.ToLower())
                            || d.ArticleBarCode.ToLower().Contains(filter.ToLower())
                            || d.Article.ToLower().Contains(filter.ToLower())
                            || d.Category.ToLower().Contains(filter.ToLower())
                            select new Entities.DgvMstSupplierEntities
                            {
                                ColumnSupplierListButtonEdit = "Edit",
                                ColumnSupplierListButtonDelete = "Delete",
                                ColumnSupplierListId = d.Id,
                                ColumnSupplierListSupplierCode = d.ArticleCode,
                                ColumnSupplierListSupplier = d.Article,
                                ColumnSupplierListAddress = d.Address,
                                ColumnSupplierListContactNumber = d.ContactNumber,
                                ColumnSupplierListIsLocked = d.IsLocked,
                                ColumnSupplierListSpace = ""
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvMstSupplierEntities>());
            }
        }

        public void CreateSupplierListDataGridView()
        {
            UpdateSupplierListDataSource();

            dataGridViewSupplierList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSupplierList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSupplierList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewSupplierList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewSupplierList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewSupplierList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewSupplierList.DataSource = supplierListDataSource;
        }

        public void GetSupplierListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Controllers.MstArticleController mstSupplierController = new Controllers.MstArticleController();
            String[] addSupplier = mstSupplierController.AddArticle("SUPPLIER");
            if (addSupplier[1].Equals("0") == false)
            {
                sysSoftwareForm.AddTabPageSupplierDetail(this, mstSupplierController.DetailArticle(Convert.ToInt32(addSupplier[1])));
                UpdateSupplierListDataSource();
            }
            else
            {
                MessageBox.Show(addSupplier[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewSupplierList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetSupplierListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewSupplierList.CurrentCell.ColumnIndex == dataGridViewSupplierList.Columns["ColumnSupplierListButtonEdit"].Index)
            {
                Controllers.MstArticleController mstSupplierController = new Controllers.MstArticleController();
                sysSoftwareForm.AddTabPageSupplierDetail(this, mstSupplierController.DetailArticle(Convert.ToInt32(dataGridViewSupplierList.Rows[e.RowIndex].Cells[2].Value)));
            }

            if (e.RowIndex > -1 && dataGridViewSupplierList.CurrentCell.ColumnIndex == dataGridViewSupplierList.Columns["ColumnSupplierListButtonDelete"].Index)
            {
                Boolean isLocked = Convert.ToBoolean(dataGridViewSupplierList.Rows[e.RowIndex].Cells[7].Value);

                if (isLocked == true)
                {
                    MessageBox.Show("Already locked.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult deleteDialogResult = MessageBox.Show("Delete Supplier?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (deleteDialogResult == DialogResult.Yes)
                    {
                        Controllers.MstArticleController mstSupplierController = new Controllers.MstArticleController();

                        String[] deleteSupplier = mstSupplierController.DeleteArticle(Convert.ToInt32(dataGridViewSupplierList.Rows[e.RowIndex].Cells[2].Value));
                        if (deleteSupplier[1].Equals("0") == false)
                        {
                            Int32 currentPageNumber = pageNumber;

                            pageNumber = 1;
                            UpdateSupplierListDataSource();

                            if (supplierListPageList != null)
                            {
                                if (supplierListData.Count() % pageSize == 1)
                                {
                                    pageNumber = currentPageNumber - 1;
                                }
                                else if (supplierListData.Count() < 1)
                                {
                                    pageNumber = 1;
                                }
                                else
                                {
                                    pageNumber = currentPageNumber;
                                }

                                supplierListDataSource.DataSource = supplierListPageList;
                            }
                        }
                        else
                        {
                            MessageBox.Show(deleteSupplier[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void textBoxSupplierListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateSupplierListDataSource();
            }
        }

        private void buttonSupplierListPageListFirst_Click(object sender, EventArgs e)
        {
            supplierListPageList = new PagedList<Entities.DgvMstSupplierEntities>(supplierListData, 1, pageSize);
            supplierListDataSource.DataSource = supplierListPageList;

            buttonSupplierListPageListFirst.Enabled = false;
            buttonSupplierListPageListPrevious.Enabled = false;
            buttonSupplierListPageListNext.Enabled = true;
            buttonSupplierListPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxSupplierListPageNumber.Text = pageNumber + " / " + supplierListPageList.PageCount;
        }

        private void buttonSupplierListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (supplierListPageList.HasPreviousPage == true)
            {
                supplierListPageList = new PagedList<Entities.DgvMstSupplierEntities>(supplierListData, --pageNumber, pageSize);
                supplierListDataSource.DataSource = supplierListPageList;
            }

            buttonSupplierListPageListNext.Enabled = true;
            buttonSupplierListPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonSupplierListPageListFirst.Enabled = false;
                buttonSupplierListPageListPrevious.Enabled = false;
            }

            textBoxSupplierListPageNumber.Text = pageNumber + " / " + supplierListPageList.PageCount;
        }

        private void buttonSupplierListPageListNext_Click(object sender, EventArgs e)
        {
            if (supplierListPageList.HasNextPage == true)
            {
                supplierListPageList = new PagedList<Entities.DgvMstSupplierEntities>(supplierListData, ++pageNumber, pageSize);
                supplierListDataSource.DataSource = supplierListPageList;
            }

            buttonSupplierListPageListFirst.Enabled = true;
            buttonSupplierListPageListPrevious.Enabled = true;

            if (pageNumber == supplierListPageList.PageCount)
            {
                buttonSupplierListPageListNext.Enabled = false;
                buttonSupplierListPageListLast.Enabled = false;
            }

            textBoxSupplierListPageNumber.Text = pageNumber + " / " + supplierListPageList.PageCount;
        }

        private void buttonSupplierListPageListLast_Click(object sender, EventArgs e)
        {
            supplierListPageList = new PagedList<Entities.DgvMstSupplierEntities>(supplierListData, supplierListPageList.PageCount, pageSize);
            supplierListDataSource.DataSource = supplierListPageList;

            buttonSupplierListPageListFirst.Enabled = true;
            buttonSupplierListPageListPrevious.Enabled = true;
            buttonSupplierListPageListNext.Enabled = false;
            buttonSupplierListPageListLast.Enabled = false;

            pageNumber = supplierListPageList.PageCount;
            textBoxSupplierListPageNumber.Text = pageNumber + " / " + supplierListPageList.PageCount;
        }
    }
}
