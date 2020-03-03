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

namespace easyfmis.Forms.Software.TrnMemo
{
    public partial class TrnMemoDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        private Modules.SysUserRightsModule sysUserRights;

        TrnMemoListForm trnMemoForm;
        public Entities.TrnMemoEntity trnMemoEntity;
        public String ArticleType;

        public static List<Entities.DgvTrnMemoLineEntity> memoLineData = new List<Entities.DgvTrnMemoLineEntity>();
        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;
        public PagedList<Entities.DgvTrnMemoLineEntity> memoLinePageSize = new PagedList<Entities.DgvTrnMemoLineEntity>(memoLineData, pageNumber, pageSize);
        public BindingSource memoLineDataSource = new BindingSource();

        public TrnMemoDetailForm(SysSoftwareForm softwareForm, TrnMemoListForm purchaseOrderForm, Entities.TrnMemoEntity memoEntity)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            sysUserRights = new Modules.SysUserRightsModule("TrnMemoDetail");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                trnMemoForm = purchaseOrderForm;
                trnMemoEntity = memoEntity;

                GetArticleTypeList();
            }
        }

        public void GetArticleTypeList()
        {
            Controllers.TrnMemoController trnMemoController = new Controllers.TrnMemoController();
            List<Entities.MstArticleTypeEntity> artileTypeList = new List<Entities.MstArticleTypeEntity>();
            var articlesType = trnMemoController.DropdownListMemoArticleType();
            if (articlesType.Any())
            {
                comboBoxArticleType.DataSource = articlesType;
                comboBoxArticleType.ValueMember = "Id";
                comboBoxArticleType.DisplayMember = "ArticleType";
            }

            comboBoxArticleType.SelectedValue = trnMemoController.GetArticleTypeId(trnMemoEntity.ArticleId);

            GetArticleList();
        }

        public void GetArticleList()
        {
            Controllers.TrnMemoController trnMemoController = new Controllers.TrnMemoController();
            var articles = trnMemoController.DropdownListMemoArticle(Convert.ToInt32(comboBoxArticleType.SelectedValue));
            if (articles.Any())
            {
                comboBoxArticle.DataSource = articles;
                comboBoxArticle.ValueMember = "Id";
                comboBoxArticle.DisplayMember = "Article";
            }

            GetUserList();
        }

        private void comboBoxArticleType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetArticleList();
        }

        public void GetUserList()
        {
            Controllers.TrnMemoController trnMemoController = new Controllers.TrnMemoController();
            var user = trnMemoController.DropdownListMemoUser();
            if (user.Any())
            {
                comboBoxPreparedBy.DataSource = user;
                comboBoxPreparedBy.ValueMember = "Id";
                comboBoxPreparedBy.DisplayMember = "FullName";

                comboBoxCheckedBy.DataSource = user;
                comboBoxCheckedBy.ValueMember = "Id";
                comboBoxCheckedBy.DisplayMember = "FullName";

                comboBoxApprovedBy.DataSource = user;
                comboBoxApprovedBy.ValueMember = "Id";
                comboBoxApprovedBy.DisplayMember = "FullName";
            }
            GetMemoDetail();
        }

        public void GetMemoDetail()
        {
            UpdateComponents(trnMemoEntity.IsLocked);

            textBoxBranch.Text = trnMemoEntity.Branch;
            textBoxMONumber.Text = trnMemoEntity.MONumber;
            dateTimePickerMODate.Value = trnMemoEntity.MODate;
            comboBoxArticle.SelectedValue = trnMemoEntity.ArticleId;
            textBoxRemarks.Text = trnMemoEntity.Remarks;
            comboBoxPreparedBy.SelectedValue = trnMemoEntity.PreparedBy;
            comboBoxCheckedBy.SelectedValue = trnMemoEntity.CheckedBy;
            comboBoxApprovedBy.SelectedValue = trnMemoEntity.ApprovedBy;

            CreateMemoLineDataGridView();
        }

        public void UpdateComponents(Boolean isLocked)
        {
            if (sysUserRights.GetUserRights().CanLock == false)
            {
                buttonLock.Enabled = false;
            }
            else
            {
                buttonLock.Enabled = !isLocked;
            }

            if (sysUserRights.GetUserRights().CanUnlock == false)
            {
                buttonUnlock.Enabled = false;
            }
            else
            {
                buttonUnlock.Enabled = isLocked;
            }

            if (sysUserRights.GetUserRights().CanEdit == false)
            {
                dataGridViewMemoLine.Columns[0].Visible = false;
            }
            else
            {
                dataGridViewMemoLine.Columns[0].Visible = !isLocked;
            }

            if (sysUserRights.GetUserRights().CanDelete == false)
            {
                dataGridViewMemoLine.Columns[1].Visible = false;
            }
            else
            {
                dataGridViewMemoLine.Columns[1].Visible = !isLocked;
            }

            textBoxBranch.Enabled = !isLocked;
            textBoxMONumber.Enabled = !isLocked;
            dateTimePickerMODate.Enabled = !isLocked;
            comboBoxArticle.Enabled = !isLocked;
            textBoxRemarks.Enabled = !isLocked;
            comboBoxPreparedBy.Enabled = !isLocked;
            comboBoxCheckedBy.Enabled = !isLocked;
            comboBoxApprovedBy.Enabled = !isLocked;
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            Controllers.TrnMemoController trnMemoController = new Controllers.TrnMemoController();

            Entities.TrnMemoEntity memoLineEntity = new Entities.TrnMemoEntity()
            {
                Id = trnMemoEntity.Id,
                BranchId = trnMemoEntity.BranchId,
                MONumber = textBoxMONumber.Text,
                MODate = dateTimePickerMODate.Value.Date,
                ArticleId = Convert.ToInt32(comboBoxArticle.SelectedValue),
                Remarks = textBoxRemarks.Text,
                PreparedBy = Convert.ToInt32(comboBoxPreparedBy.SelectedValue),
                CheckedBy = Convert.ToInt32(comboBoxCheckedBy.SelectedValue),
                ApprovedBy = Convert.ToInt32(comboBoxApprovedBy.SelectedValue),
            };

            String[] lockMemo = trnMemoController.LockMemo(trnMemoEntity.Id, memoLineEntity);
            if (lockMemo[1].Equals("0") == false)
            {
                UpdateComponents(true);
                trnMemoForm.UpdateMemoDataSource();
            }
            else
            {
                MessageBox.Show(lockMemo[0], "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            Controllers.TrnMemoController trnMemoController = new Controllers.TrnMemoController();

            String[] unlockMemo = trnMemoController.UnlockMemo(trnMemoEntity.Id);
            if (unlockMemo[1].Equals("0") == false)
            {
                UpdateComponents(false);
                trnMemoForm.UpdateMemoDataSource();
            }
            else
            {
                MessageBox.Show(unlockMemo[0], "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
            sysSoftwareForm.RemoveTabPage();
        }

        public void UpdateMemoLineDataSource()
        {
            SetMemoLineDataSourceAsync();
        }

        public async void SetMemoLineDataSourceAsync()
        {
            List<Entities.DgvTrnMemoLineEntity> getMemoLineData = await GetMemoLineDataTask();
            if (getMemoLineData.Any())
            {
                pageNumber = 1;
                memoLineData = getMemoLineData;
                memoLinePageSize = new PagedList<Entities.DgvTrnMemoLineEntity>(memoLineData, pageNumber, pageSize);

                if (memoLinePageSize.PageCount == 1)
                {
                    buttonMemoLinePageListFirst.Enabled = false;
                    buttonMemoLinePageListPrevious.Enabled = false;
                    buttonMemoLinePageListNext.Enabled = false;
                    buttonMemoLinePageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonMemoLinePageListFirst.Enabled = false;
                    buttonMemoLinePageListPrevious.Enabled = false;
                    buttonMemoLinePageListNext.Enabled = true;
                    buttonMemoLinePageListLast.Enabled = true;
                }
                else if (pageNumber == memoLinePageSize.PageCount)
                {
                    buttonMemoLinePageListFirst.Enabled = true;
                    buttonMemoLinePageListPrevious.Enabled = true;
                    buttonMemoLinePageListNext.Enabled = false;
                    buttonMemoLinePageListLast.Enabled = false;
                }
                else
                {
                    buttonMemoLinePageListFirst.Enabled = true;
                    buttonMemoLinePageListPrevious.Enabled = true;
                    buttonMemoLinePageListNext.Enabled = true;
                    buttonMemoLinePageListLast.Enabled = true;
                }

                textBoxMemoLinePageNumber.Text = pageNumber + " / " + memoLinePageSize.PageCount;
                memoLineDataSource.DataSource = memoLinePageSize;
            }
            else
            {
                buttonMemoLinePageListFirst.Enabled = false;
                buttonMemoLinePageListPrevious.Enabled = false;
                buttonMemoLinePageListNext.Enabled = false;
                buttonMemoLinePageListLast.Enabled = false;

                pageNumber = 1;

                memoLineData = new List<Entities.DgvTrnMemoLineEntity>();
                memoLineDataSource.Clear();
                textBoxMemoLinePageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvTrnMemoLineEntity>> GetMemoLineDataTask()
        {
            Controllers.TrnMemoLineController trnMemoLineController = new Controllers.TrnMemoLineController();

            List<Entities.TrnMemoLineEntity> listMemoLine = trnMemoLineController.ListMemoLine(trnMemoEntity.Id);
            if (listMemoLine.Any())
            {
                var items = from d in listMemoLine
                            select new Entities.DgvTrnMemoLineEntity
                            {
                                ColumnMemoLineListButtonEdit = "Edit",
                                ColumnMemoLineListButtonDelete = "Delete",
                                ColumnMemoLineListId = d.Id,
                                ColumnMemoLineListMOId = d.MOId,
                                ColumnMemoLineListSIId = d.SIId,
                                ColumnMemoLineListSINumber = d.SINumber,
                                ColumnMemoLineListRRId = d.RRId,
                                ColumnMemoLineListRRNumber = d.RRNumber,
                                ColumnMemoLineListAmount = d.Amount.ToString("#,##0.00"),
                                ColumnMemoLineListParticulars = d.Particulars
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvTrnMemoLineEntity>());
            }
        }

        public void CreateMemoLineDataGridView()
        {
            UpdateMemoLineDataSource();

            dataGridViewMemoLine.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewMemoLine.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewMemoLine.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewMemoLine.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewMemoLine.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewMemoLine.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewMemoLine.DataSource = memoLineDataSource;
        }

        public void GetMemoLineCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewMemoLine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetMemoLineCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewMemoLine.CurrentCell.ColumnIndex == dataGridViewMemoLine.Columns["ColumnMemoLineListButtonEdit"].Index)
            {
                var id = Convert.ToInt32(dataGridViewMemoLine.Rows[e.RowIndex].Cells[dataGridViewMemoLine.Columns["ColumnMemoLineListId"].Index].Value);
                var mOId = Convert.ToInt32(dataGridViewMemoLine.Rows[e.RowIndex].Cells[dataGridViewMemoLine.Columns["ColumnMemoLineListMOId"].Index].Value);
                var sIId = Convert.ToInt32(dataGridViewMemoLine.Rows[e.RowIndex].Cells[dataGridViewMemoLine.Columns["ColumnMemoLineListSIId"].Index].Value);
                var rRId = Convert.ToInt32(dataGridViewMemoLine.Rows[e.RowIndex].Cells[dataGridViewMemoLine.Columns["ColumnMemoLineListRRId"].Index].Value);
                var amount = Convert.ToDecimal(dataGridViewMemoLine.Rows[e.RowIndex].Cells[dataGridViewMemoLine.Columns["ColumnMemoLineListAmount"].Index].Value);
                var particulars = dataGridViewMemoLine.Rows[e.RowIndex].Cells[dataGridViewMemoLine.Columns["ColumnMemoLineListParticulars"].Index].Value.ToString();

                Entities.TrnMemoLineEntity objMemoLineEntity = new Entities.TrnMemoLineEntity()
                {
                    Id = id,
                    MOId = mOId,
                    SIId = sIId,
                    RRId = rRId,
                    Amount = amount,
                    Particulars = particulars
                };

                TrnMemoDetailMemoLineDetailForm trnMemoDetailMemoLineDetailForm = new TrnMemoDetailMemoLineDetailForm(this, trnMemoEntity, objMemoLineEntity, comboBoxArticleType.Text);
                trnMemoDetailMemoLineDetailForm.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewMemoLine.CurrentCell.ColumnIndex == dataGridViewMemoLine.Columns["ColumnMemoLineListButtonDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete Stock-In?", "Easy ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(dataGridViewMemoLine.Rows[e.RowIndex].Cells[dataGridViewMemoLine.Columns["ColumnMemoLineListId"].Index].Value);

                    Controllers.TrnMemoLineController trnMemoLineController = new Controllers.TrnMemoLineController();
                    String[] deleteMemoLine = trnMemoLineController.DeleteMemoLine(id);
                    if (deleteMemoLine[1].Equals("0") == false)
                    {
                        pageNumber = 1;
                        UpdateMemoLineDataSource();
                    }
                    else
                    {
                        MessageBox.Show(deleteMemoLine[0], "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonMemoLinePageListFirst_Click(object sender, EventArgs e)
        {
            memoLinePageSize = new PagedList<Entities.DgvTrnMemoLineEntity>(memoLineData, 1, pageSize);
            memoLineDataSource.DataSource = memoLinePageSize;

            buttonMemoLinePageListFirst.Enabled = false;
            buttonMemoLinePageListPrevious.Enabled = false;
            buttonMemoLinePageListNext.Enabled = true;
            buttonMemoLinePageListLast.Enabled = true;

            pageNumber = 1;
            textBoxMemoLinePageNumber.Text = pageNumber + " / " + memoLinePageSize.PageCount;
        }

        private void buttonMemoLinePageListPrevious_Click(object sender, EventArgs e)
        {
            if (memoLinePageSize.HasPreviousPage == true)
            {
                memoLinePageSize = new PagedList<Entities.DgvTrnMemoLineEntity>(memoLineData, --pageNumber, pageSize);
                memoLineDataSource.DataSource = memoLinePageSize;
            }

            buttonMemoLinePageListNext.Enabled = true;
            buttonMemoLinePageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonMemoLinePageListFirst.Enabled = false;
                buttonMemoLinePageListPrevious.Enabled = false;
            }

            textBoxMemoLinePageNumber.Text = pageNumber + " / " + memoLinePageSize.PageCount;
        }

        private void buttonMemoLinePageListNext_Click(object sender, EventArgs e)
        {
            if (memoLinePageSize.HasNextPage == true)
            {
                memoLinePageSize = new PagedList<Entities.DgvTrnMemoLineEntity>(memoLineData, ++pageNumber, pageSize);
                memoLineDataSource.DataSource = memoLinePageSize;
            }

            buttonMemoLinePageListFirst.Enabled = true;
            buttonMemoLinePageListPrevious.Enabled = true;

            if (pageNumber == memoLinePageSize.PageCount)
            {
                buttonMemoLinePageListNext.Enabled = false;
                buttonMemoLinePageListLast.Enabled = false;
            }

            textBoxMemoLinePageNumber.Text = pageNumber + " / " + memoLinePageSize.PageCount;
        }

        private void buttonMemoLinePageListLast_Click(object sender, EventArgs e)
        {
            memoLinePageSize = new PagedList<Entities.DgvTrnMemoLineEntity>(memoLineData, memoLinePageSize.PageCount, pageSize);
            memoLineDataSource.DataSource = memoLinePageSize;

            buttonMemoLinePageListFirst.Enabled = true;
            buttonMemoLinePageListPrevious.Enabled = true;
            buttonMemoLinePageListNext.Enabled = false;
            buttonMemoLinePageListLast.Enabled = false;

            pageNumber = memoLinePageSize.PageCount;
            textBoxMemoLinePageNumber.Text = pageNumber + " / " + memoLinePageSize.PageCount;
        }

        private void buttonAddMemoLine_Click(object sender, EventArgs e)
        {
            trnMemoEntity.ArticleId = Convert.ToInt32(comboBoxArticle.SelectedValue);
            TrnMemoDetailMemoLineDetailForm trnMemoDetailMemoLineDetailForm = new TrnMemoDetailMemoLineDetailForm(this, trnMemoEntity ,null, comboBoxArticleType.Text);
            trnMemoDetailMemoLineDetailForm.ShowDialog();
        }

     
    }
}
