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

namespace easyfmis.Forms.Software.SysSystemTables
{
    public partial class SysSystemTablesForm : Form
    {

        public SysSoftwareForm sysSoftwareForm;

        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;

        public static List<Entities.DgvBankListEntity> bankListData = new List<Entities.DgvBankListEntity>();
        public PagedList<Entities.DgvBankListEntity> bankListPageList = new PagedList<Entities.DgvBankListEntity>(bankListData, pageNumber, pageSize);
        public BindingSource bankListDataSource = new BindingSource();

        public SysSystemTablesForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();

            sysSoftwareForm = softwareForm;

            CreateBankListDataGridView();
        }

        public void UpdateBankListDataSource()
        {
            SetBankListDataSourceAsync();
        }

        public async void SetBankListDataSourceAsync()
        {
            List<Entities.DgvBankListEntity> getBankListData = await GetBankListDataTask();
            if (getBankListData.Any())
            {
                bankListData = getBankListData;
                bankListPageList = new PagedList<Entities.DgvBankListEntity>(bankListData, pageNumber, pageSize);

                if (bankListPageList.PageCount == 1)
                {
                    buttonBankListPageListFirst.Enabled = false;
                    buttonBankListPageListPrevious.Enabled = false;
                    buttonBankListPageListNext.Enabled = false;
                    buttonBankListPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonBankListPageListFirst.Enabled = false;
                    buttonBankListPageListPrevious.Enabled = false;
                    buttonBankListPageListNext.Enabled = true;
                    buttonBankListPageListLast.Enabled = true;
                }
                else if (pageNumber == bankListPageList.PageCount)
                {
                    buttonBankListPageListFirst.Enabled = true;
                    buttonBankListPageListPrevious.Enabled = true;
                    buttonBankListPageListNext.Enabled = false;
                    buttonBankListPageListLast.Enabled = false;
                }
                else
                {
                    buttonBankListPageListFirst.Enabled = true;
                    buttonBankListPageListPrevious.Enabled = true;
                    buttonBankListPageListNext.Enabled = true;
                    buttonBankListPageListLast.Enabled = true;
                }

                textBoxBankListPageNumber.Text = pageNumber + " / " + bankListPageList.PageCount;
                bankListDataSource.DataSource = bankListPageList;
            }
            else
            {
                buttonBankListPageListFirst.Enabled = false;
                buttonBankListPageListPrevious.Enabled = false;
                buttonBankListPageListNext.Enabled = false;
                buttonBankListPageListLast.Enabled = false;

                pageNumber = 1;

                bankListData = new List<Entities.DgvBankListEntity>();
                bankListDataSource.Clear();
                textBoxBankListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvBankListEntity>> GetBankListDataTask()
        {
            String filter = textBoxBankListFilter.Text;
            Controllers.MstArticleController mstBankController = new Controllers.MstArticleController();

            List<Entities.MstArticleEntity> listBank = mstBankController.ListArticle(4);
            if (listBank.Any())
            {
                var items = from d in listBank
                            where d.ArticleCode.Contains(filter)
                            || d.ArticleBarCode.Contains(filter)
                            || d.Article.Contains(filter)
                            || d.Category.Contains(filter)
                            select new Entities.DgvBankListEntity
                            {
                                ColumnBankListButtonEdit = "Edit",
                                ColumnBankListButtonDelete = "Delete",
                                ColumnBankListId = d.Id,
                                ColumnBankListBankCode = d.ArticleCode,
                                ColumnBankListBank = d.Article,
                                ColumnBankListContactNumber = d.Address,
                                ColumnBankListAddress = d.ContactNumber,
                                ColumnBankListIsLocked = d.IsLocked,
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvBankListEntity>());
            }
        }

        public void CreateBankListDataGridView()
        {
            UpdateBankListDataSource();

            dataGridViewBankList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewBankList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewBankList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewBankList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewBankList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewBankList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewBankList.DataSource = bankListDataSource;
        }

        public void GetBankListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Controllers.MstArticleController mstBankController = new Controllers.MstArticleController();
            String[] addBank = mstBankController.AddArticle("BANK");
            if (addBank[1].Equals("0") == false)
            {

                MstBankDetailForm mstBankDetailForm = new MstBankDetailForm(this, mstBankController.DetailArticle(Convert.ToInt32(addBank[1])));
                UpdateBankListDataSource();
                mstBankDetailForm.ShowDialog();
            }
            else
            {
                MessageBox.Show(addBank[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewBankList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetBankListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewBankList.CurrentCell.ColumnIndex == dataGridViewBankList.Columns["ColumnBankListButtonEdit"].Index)
            {
                Controllers.MstArticleController mstBankController = new Controllers.MstArticleController();
                MstBankDetailForm mstBankDetailForm = new MstBankDetailForm(this, mstBankController.DetailArticle(Convert.ToInt32(dataGridViewBankList.Rows[e.RowIndex].Cells[2].Value)));
                mstBankDetailForm.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewBankList.CurrentCell.ColumnIndex == dataGridViewBankList.Columns["ColumnBankListButtonDelete"].Index)
            {
                Boolean isLocked = Convert.ToBoolean(dataGridViewBankList.Rows[e.RowIndex].Cells[7].Value);

                if (isLocked == true)
                {
                    MessageBox.Show("Already locked.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult deleteDialogResult = MessageBox.Show("Delete Bank?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (deleteDialogResult == DialogResult.Yes)
                    {
                        Controllers.MstArticleController mstBankController = new Controllers.MstArticleController();

                        String[] deleteBank = mstBankController.DeleteArticle(Convert.ToInt32(dataGridViewBankList.Rows[e.RowIndex].Cells[2].Value));
                        if (deleteBank[1].Equals("0") == false)
                        {
                            Int32 currentPageNumber = pageNumber;

                            pageNumber = 1;
                            UpdateBankListDataSource();

                            if (bankListPageList != null)
                            {
                                if (bankListData.Count() % pageSize == 1)
                                {
                                    pageNumber = currentPageNumber - 1;
                                }
                                else if (bankListData.Count() < 1)
                                {
                                    pageNumber = 1;
                                }
                                else
                                {
                                    pageNumber = currentPageNumber;
                                }

                                bankListDataSource.DataSource = bankListPageList;
                            }
                        }
                        else
                        {
                            MessageBox.Show(deleteBank[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void textBoxBankListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateBankListDataSource();
            }
        }

        private void buttonBankListPageListFirst_Click(object sender, EventArgs e)
        {
            bankListPageList = new PagedList<Entities.DgvBankListEntity>(bankListData, 1, pageSize);
            bankListDataSource.DataSource = bankListPageList;

            buttonBankListPageListFirst.Enabled = false;
            buttonBankListPageListPrevious.Enabled = false;
            buttonBankListPageListNext.Enabled = true;
            buttonBankListPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxBankListPageNumber.Text = pageNumber + " / " + bankListPageList.PageCount;
        }

        private void buttonBankListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (bankListPageList.HasPreviousPage == true)
            {
                bankListPageList = new PagedList<Entities.DgvBankListEntity>(bankListData, --pageNumber, pageSize);
                bankListDataSource.DataSource = bankListPageList;
            }

            buttonBankListPageListNext.Enabled = true;
            buttonBankListPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonBankListPageListFirst.Enabled = false;
                buttonBankListPageListPrevious.Enabled = false;
            }

            textBoxBankListPageNumber.Text = pageNumber + " / " + bankListPageList.PageCount;
        }

        private void buttonBankListPageListNext_Click(object sender, EventArgs e)
        {
            if (bankListPageList.HasNextPage == true)
            {
                bankListPageList = new PagedList<Entities.DgvBankListEntity>(bankListData, ++pageNumber, pageSize);
                bankListDataSource.DataSource = bankListPageList;
            }

            buttonBankListPageListFirst.Enabled = true;
            buttonBankListPageListPrevious.Enabled = true;

            if (pageNumber == bankListPageList.PageCount)
            {
                buttonBankListPageListNext.Enabled = false;
                buttonBankListPageListLast.Enabled = false;
            }

            textBoxBankListPageNumber.Text = pageNumber + " / " + bankListPageList.PageCount;
        }

        private void buttonBankListPageListLast_Click(object sender, EventArgs e)
        {
            bankListPageList = new PagedList<Entities.DgvBankListEntity>(bankListData, bankListPageList.PageCount, pageSize);
            bankListDataSource.DataSource = bankListPageList;

            buttonBankListPageListFirst.Enabled = true;
            buttonBankListPageListPrevious.Enabled = true;
            buttonBankListPageListNext.Enabled = false;
            buttonBankListPageListLast.Enabled = false;

            pageNumber = bankListPageList.PageCount;
            textBoxBankListPageNumber.Text = pageNumber + " / " + bankListPageList.PageCount;
        }
    }
}
