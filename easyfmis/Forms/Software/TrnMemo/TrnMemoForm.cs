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

namespace easyfmis.Forms.Software.TrnMemo
{
    public partial class TrnMemoForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public static List<Entities.DgvTrnMemoEntity> memoListData = new List<Entities.DgvTrnMemoEntity>();
        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;
        public PagedList<Entities.DgvTrnMemoEntity> memoListPageList = new PagedList<Entities.DgvTrnMemoEntity>(memoListData, pageNumber, pageSize);
        public BindingSource memoListDataSource = new BindingSource();

        public TrnMemoForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            CreateMemoDataGridView();
        }

        public void UpdateMemoDataSource()
        {
            SetMemoDataSourceAsync();
        }

        public async void SetMemoDataSourceAsync()
        {
            List<Entities.DgvTrnMemoEntity> getMemoData = await GetMemoDataTask();
            if (getMemoData.Any())
            {
                pageNumber = 1;
                memoListData = getMemoData;
                memoListPageList = new PagedList<Entities.DgvTrnMemoEntity>(memoListData, pageNumber, pageSize);

                if (memoListPageList.PageCount == 1)
                {
                    buttonMemoPageListFirst.Enabled = false;
                    buttonMemoPageListPrevious.Enabled = false;
                    buttonMemoPageListNext.Enabled = false;
                    buttonMemoPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonMemoPageListFirst.Enabled = false;
                    buttonMemoPageListPrevious.Enabled = false;
                    buttonMemoPageListNext.Enabled = true;
                    buttonMemoPageListLast.Enabled = true;
                }
                else if (pageNumber == memoListPageList.PageCount)
                {
                    buttonMemoPageListFirst.Enabled = true;
                    buttonMemoPageListPrevious.Enabled = true;
                    buttonMemoPageListNext.Enabled = false;
                    buttonMemoPageListLast.Enabled = false;
                }
                else
                {
                    buttonMemoPageListFirst.Enabled = true;
                    buttonMemoPageListPrevious.Enabled = true;
                    buttonMemoPageListNext.Enabled = true;
                    buttonMemoPageListLast.Enabled = true;
                }

                textBoxMemoPageNumber.Text = pageNumber + " / " + memoListPageList.PageCount;
                memoListDataSource.DataSource = memoListPageList;
            }
            else
            {
                buttonMemoPageListFirst.Enabled = false;
                buttonMemoPageListPrevious.Enabled = false;
                buttonMemoPageListNext.Enabled = false;
                buttonMemoPageListLast.Enabled = false;

                pageNumber = 1;

                memoListData = new List<Entities.DgvTrnMemoEntity>();
                memoListDataSource.Clear();
                textBoxMemoPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvTrnMemoEntity>> GetMemoDataTask()
        {
            DateTime startDateFilter = dateTimePickerMemoFilterStartDate.Value.Date;
            DateTime endDateFilter = dateTimePickerMemoFilterEndDate.Value.Date;

            String filter = textBoxMemoFilter.Text;
            Controllers.TrnMemoController trnMemoController = new Controllers.TrnMemoController();

            List<Entities.TrnMemoEntity> listMemo = trnMemoController.ListMemo(startDateFilter, endDateFilter, filter);
            if (listMemo.Any())
            {
                var memo = from d in listMemo
                                    select new Entities.DgvTrnMemoEntity
                                    {
                                        ColumnMemoListButtonEdit = "Edit",
                                        ColumnMemoListButtonDelete = "Delete",
                                        ColumnMemoListId = d.Id,
                                        ColumnMemoListMONumber = d.MONumber,
                                        ColumnMemoListMODate = d.MODate.ToShortDateString(),
                                        ColumnMemoListArticle = d.Article,
                                        ColumnMemoListRemarks = d.Remarks,
                                        ColumnMemoListIsLocked = d.IsLocked
                                    };

                return Task.FromResult(memo.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvTrnMemoEntity>());
            }
        }

        public void CreateMemoDataGridView()
        {
            UpdateMemoDataSource();

            dataGridViewMemo.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewMemo.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewMemo.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewMemo.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewMemo.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewMemo.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewMemo.DataSource = memoListDataSource;
        }

        public void GetMemoCurrentSelectedCell
            (Int32 rowIndex)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Controllers.TrnMemoController trnMemoController = new Controllers.TrnMemoController();
            String[] addMemo = trnMemoController.AddMemo();
            if (addMemo[1].Equals("0") == false)
            {
                //sysSoftwareForm.AddTabPageMemoDetail(this, trnMemoController.DetailMemo(Convert.ToInt32(addMemo[1])));
                //UpdateMemoDataSource();
            }
            else
            {
                MessageBox.Show(addMemo[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
            sysSoftwareForm.RemoveTabPage();
        }

        private void dataGridViewMemo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetMemoCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewMemo.CurrentCell.ColumnIndex == dataGridViewMemo.Columns["ColumnMemoListButtonEdit"].Index)
            {
            //    Controllers.TrnMemoController trnMemoController = new Controllers.TrnMemoController();
            //    sysSoftwareForm.AddTabPageMemoDetail(this, trnMemoController.DetailMemo(Convert.ToInt32(dataGridViewMemo.Rows[e.RowIndex].Cells[dataGridViewMemo.Columns["ColumnMemoListId"].Index].Value)));
            }

            if (e.RowIndex > -1 && dataGridViewMemo.CurrentCell.ColumnIndex == dataGridViewMemo.Columns["ColumnMemoListButtonDelete"].Index)
            {
                Boolean isLocked = Convert.ToBoolean(dataGridViewMemo.Rows[e.RowIndex].Cells[dataGridViewMemo.Columns["ColumnMemoListIsLocked"].Index].Value);

                if (isLocked == true)
                {
                    MessageBox.Show("Already locked.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult deleteDialogResult = MessageBox.Show("Delete Sales order?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (deleteDialogResult == DialogResult.Yes)
                    {
                        Controllers.TrnMemoController trnMemoController = new Controllers.TrnMemoController();

                        String[] deleteMemo = trnMemoController.DeleteMemo(Convert.ToInt32(dataGridViewMemo.Rows[e.RowIndex].Cells[dataGridViewMemo.Columns["ColumnMemoListId"].Index].Value));
                        if (deleteMemo[1].Equals("0") == false)
                        {
                            pageNumber = 1;
                            UpdateMemoDataSource();
                        }
                        else
                        {
                            MessageBox.Show(deleteMemo[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void dateTimePickerMemoFilterStartDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateMemoDataSource();
        }

        private void dateTimePickerMemoFilterEndDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateMemoDataSource();
        }

        private void textBoxMemoFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateMemoDataSource();
            }
        }

        private void buttonMemoPageListFirst_Click(object sender, EventArgs e)
        {
            memoListPageList = new PagedList<Entities.DgvTrnMemoEntity>(memoListData, 1, pageSize);
            memoListDataSource.DataSource = memoListPageList;

            buttonMemoPageListFirst.Enabled = false;
            buttonMemoPageListPrevious.Enabled = false;
            buttonMemoPageListNext.Enabled = true;
            buttonMemoPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxMemoPageNumber.Text = pageNumber + " / " + memoListPageList.PageCount;
        }

        private void buttonMemoPageListPrevious_Click(object sender, EventArgs e)
        {
            if (memoListPageList.HasPreviousPage == true)
            {
                memoListPageList = new PagedList<Entities.DgvTrnMemoEntity>(memoListData, --pageNumber, pageSize);
                memoListDataSource.DataSource = memoListPageList;
            }

            buttonMemoPageListNext.Enabled = true;
            buttonMemoPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonMemoPageListFirst.Enabled = false;
                buttonMemoPageListPrevious.Enabled = false;
            }

            textBoxMemoPageNumber.Text = pageNumber + " / " + memoListPageList.PageCount;
        }

        private void buttonMemoPageListNext_Click(object sender, EventArgs e)
        {
            if (memoListPageList.HasNextPage == true)
            {
                memoListPageList = new PagedList<Entities.DgvTrnMemoEntity>(memoListData, ++pageNumber, pageSize);
                memoListDataSource.DataSource = memoListPageList;
            }

            buttonMemoPageListFirst.Enabled = true;
            buttonMemoPageListPrevious.Enabled = true;

            if (pageNumber == memoListPageList.PageCount)
            {
                buttonMemoPageListNext.Enabled = false;
                buttonMemoPageListLast.Enabled = false;
            }

            textBoxMemoPageNumber.Text = pageNumber + " / " + memoListPageList.PageCount;
        }

        private void buttonMemoPageListLast_Click(object sender, EventArgs e)
        {
            memoListPageList = new PagedList<Entities.DgvTrnMemoEntity>(memoListData, memoListPageList.PageCount, pageSize);
            memoListDataSource.DataSource = memoListPageList;

            buttonMemoPageListFirst.Enabled = true;
            buttonMemoPageListPrevious.Enabled = true;
            buttonMemoPageListNext.Enabled = false;
            buttonMemoPageListLast.Enabled = false;

            pageNumber = memoListPageList.PageCount;
            textBoxMemoPageNumber.Text = pageNumber + " / " + memoListPageList.PageCount;
        }
    }
}
