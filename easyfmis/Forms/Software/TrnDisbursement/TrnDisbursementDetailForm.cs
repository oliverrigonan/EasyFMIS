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

namespace easyfmis.Forms.Software.TrnDisbursement
{
    public partial class TrnDisbursementDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        public TrnDisbursementListForm trnDisbursementListForm;
        public Entities.TrnDisbursementEntity trnDisbursementEntity;

        public static List<Entities.DgvDisbursementLineEntity> disbursementLineData = new List<Entities.DgvDisbursementLineEntity>();
        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;
        public PagedList<Entities.DgvDisbursementLineEntity> disbursementLinePageList = new PagedList<Entities.DgvDisbursementLineEntity>(disbursementLineData, pageNumber, pageSize);
        public BindingSource disbursementLineDataSource = new BindingSource();

        public TrnDisbursementDetailForm(SysSoftwareForm softwareForm, TrnDisbursementListForm disbursementListForm, Entities.TrnDisbursementEntity disbursementEntity)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            trnDisbursementListForm = disbursementListForm;
            trnDisbursementEntity = disbursementEntity;

            GetSupplierList();
        }

        public void GetSupplierList()
        {
            Controllers.TrnDisbursementController trnDisbursementController = new Controllers.TrnDisbursementController();
            var supplier = trnDisbursementController.DropdownListSupplier();
            if (supplier.Any())
            {
                comboBoxSupplier.DataSource = supplier;
                comboBoxSupplier.ValueMember = "Id";
                comboBoxSupplier.DisplayMember = "Article";

                GetPaytype();
            }
        }

        public void GetPaytype()
        {
            Controllers.TrnDisbursementController trnDisbursementController = new Controllers.TrnDisbursementController();
            var payType = trnDisbursementController.DropdownListPayType();
            if (payType.Any())
            {
                comboBoxPayType.DataSource = payType;
                comboBoxPayType.ValueMember = "Id";
                comboBoxPayType.DisplayMember = "PayType";

                GetBank();
            }
        }

        public void GetBank()
        {
            Controllers.TrnDisbursementController trnDisbursementController = new Controllers.TrnDisbursementController();
            var bank = trnDisbursementController.DropdownListBank();
            if (bank.Any())
            {
                comboBoxBank.DataSource = bank;
                comboBoxBank.ValueMember = "Id";
                comboBoxBank.DisplayMember = "Article";
            }

            GetUserList();

        }

        public void GetUserList()
        {
            Controllers.TrnDisbursementController trnDisbursementController = new Controllers.TrnDisbursementController();
            var user = trnDisbursementController.DropdownListUser();
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
            GetDisbursementDetail();
        }

        public void GetDisbursementDetail()
        {
            UpdateComponents(trnDisbursementEntity.IsLocked);

            textBoxBranch.Text = trnDisbursementEntity.Branch;
            textBoxCVNumber.Text = trnDisbursementEntity.CVNumber;
            dateTimePickerCVDate.Value = trnDisbursementEntity.CVDate;
            textBoxManualCVNumber.Text = trnDisbursementEntity.CVNumber;
            comboBoxSupplier.SelectedValue = trnDisbursementEntity.SupplierId;
            textBoxPayee.Text = trnDisbursementEntity.Payee;
            comboBoxPayType.SelectedValue = trnDisbursementEntity.PayTypeId;
            comboBoxBank.SelectedValue = trnDisbursementEntity.BankId;
            textBoxRemarks.Text = trnDisbursementEntity.Remarks;
            textBoxAmount.Text = trnDisbursementEntity.Amount.ToString("#,##0.00");
            textBoxCheckNumber.Text = trnDisbursementEntity.CheckNumber;
            dateTimePickerCheckDate.Value = Convert.ToDateTime(trnDisbursementEntity.CheckDate);
            checkBoxIsCrossCheck.Checked = trnDisbursementEntity.IsCrossCheck;
            checkBoxIsClear.Checked = trnDisbursementEntity.IsClear;
            comboBoxPreparedBy.SelectedValue = trnDisbursementEntity.PreparedBy;
            comboBoxCheckedBy.SelectedValue = trnDisbursementEntity.CheckedBy;
            comboBoxApprovedBy.SelectedValue = trnDisbursementEntity.ApprovedBy;

            CreateDisbursementDataGridView();
        }

        public void UpdateComponents(Boolean isLocked)
        {
            buttonLock.Enabled = !isLocked;
            buttonUnlock.Enabled = isLocked;
            buttonPrint.Enabled = !isLocked;

            buttonDisbursementLine.Enabled = !isLocked;

            textBoxBranch.Enabled = !isLocked;
            textBoxCVNumber.Enabled = !isLocked;
            dateTimePickerCVDate.Enabled = !isLocked;
            textBoxManualCVNumber.Enabled = !isLocked;
            comboBoxSupplier.Enabled = !isLocked;
            textBoxPayee.Enabled = !isLocked;
            comboBoxPayType.Enabled = !isLocked;
            comboBoxBank.Enabled = !isLocked;
            textBoxRemarks.Enabled = !isLocked;
            textBoxAmount.Enabled = !isLocked;
            textBoxCheckNumber.Enabled = !isLocked;
            dateTimePickerCheckDate.Enabled = !isLocked;
            checkBoxIsCrossCheck.Enabled = !isLocked;
            checkBoxIsClear.Enabled = !isLocked;
            comboBoxPreparedBy.Enabled = !isLocked;
            comboBoxCheckedBy.Enabled = !isLocked;
            comboBoxApprovedBy.Enabled = !isLocked;

            dataGridViewDisbursementLine.Columns[0].Visible = !isLocked;
            dataGridViewDisbursementLine.Columns[1].Visible = !isLocked;
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            Controllers.TrnDisbursementController trnDisbursementController = new Controllers.TrnDisbursementController();

            Entities.TrnDisbursementEntity disbursementEntity = new Entities.TrnDisbursementEntity()
            {
                Id = trnDisbursementEntity.Id,
                BranchId = trnDisbursementEntity.BranchId,
                CVNumber = trnDisbursementEntity.CVNumber,
                CVDate = dateTimePickerCVDate.Value.Date,
                ManualCVNumber = textBoxManualCVNumber.Text,
                SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue),
                Payee = textBoxPayee.Text,
                PayTypeId = Convert.ToInt32(comboBoxPayType.SelectedValue),
                BankId = Convert.ToInt32(comboBoxBank.SelectedValue),
                Remarks = textBoxRemarks.Text,
                Amount = Convert.ToDecimal(textBoxAmount.Text),
                CheckNumber = textBoxCheckNumber.Text,
                CheckDate = dateTimePickerCheckDate.Value.Date,
                IsCrossCheck = checkBoxIsCrossCheck.Checked,
                IsClear = checkBoxIsClear.Checked,
                PreparedBy = Convert.ToInt32(comboBoxPreparedBy.SelectedValue),
                CheckedBy = Convert.ToInt32(comboBoxCheckedBy.SelectedValue),
                ApprovedBy = Convert.ToInt32(comboBoxApprovedBy.SelectedValue)
            };

            String[] lockDisbursement = trnDisbursementController.LockDisbursement(trnDisbursementEntity.Id, disbursementEntity);
            if (lockDisbursement[1].Equals("0") == false)
            {
                UpdateComponents(true);
                trnDisbursementListForm.UpdateDisbursementDataSource();
            }
            else
            {
                MessageBox.Show(lockDisbursement[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            Controllers.TrnDisbursementController trnDisbursementController = new Controllers.TrnDisbursementController();

            String[] unlockDisbursement = trnDisbursementController.UnlockDisbursement(trnDisbursementEntity.Id);
            if (unlockDisbursement[1].Equals("0") == false)
            {
                UpdateComponents(false);
                trnDisbursementListForm.UpdateDisbursementDataSource();
            }
            else
            {
                MessageBox.Show(unlockDisbursement[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
            sysSoftwareForm.RemoveTabPage();
        }

        public void UpdateDisbursementLineDataSource()
        {
            SetDisbursementLineDataSourceAsync();
        }

        public async void SetDisbursementLineDataSourceAsync()
        {
            List<Entities.DgvDisbursementLineEntity> getDisbursementLineData = await GetDisbursementLineDataTask();
            if (getDisbursementLineData.Any())
            {
                disbursementLineData = getDisbursementLineData;
                disbursementLinePageList = new PagedList<Entities.DgvDisbursementLineEntity>(disbursementLineData, pageNumber, pageSize);

                if (disbursementLinePageList.PageCount == 1)
                {
                    buttonDisbursementLinePageListFirst.Enabled = false;
                    buttonDisbursementLinePageListPrevious.Enabled = false;
                    buttonDisbursementLinePageListNext.Enabled = false;
                    buttonDisbursementLinePageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonDisbursementLinePageListFirst.Enabled = false;
                    buttonDisbursementLinePageListPrevious.Enabled = false;
                    buttonDisbursementLinePageListNext.Enabled = true;
                    buttonDisbursementLinePageListLast.Enabled = true;
                }
                else if (pageNumber == disbursementLinePageList.PageCount)
                {
                    buttonDisbursementLinePageListFirst.Enabled = true;
                    buttonDisbursementLinePageListPrevious.Enabled = true;
                    buttonDisbursementLinePageListNext.Enabled = false;
                    buttonDisbursementLinePageListLast.Enabled = false;
                }
                else
                {
                    buttonDisbursementLinePageListFirst.Enabled = true;
                    buttonDisbursementLinePageListPrevious.Enabled = true;
                    buttonDisbursementLinePageListNext.Enabled = true;
                    buttonDisbursementLinePageListLast.Enabled = true;
                }

                textBoxDisbursementLinePageNumber.Text = pageNumber + " / " + disbursementLinePageList.PageCount;
                disbursementLineDataSource.DataSource = disbursementLinePageList;
            }
            else
            {
                buttonDisbursementLinePageListFirst.Enabled = false;
                buttonDisbursementLinePageListPrevious.Enabled = false;
                buttonDisbursementLinePageListNext.Enabled = false;
                buttonDisbursementLinePageListLast.Enabled = false;

                pageNumber = 1;

                disbursementLineData = new List<Entities.DgvDisbursementLineEntity>();
                disbursementLineDataSource.Clear();
                textBoxDisbursementLinePageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvDisbursementLineEntity>> GetDisbursementLineDataTask()
        {
            Controllers.TrnDisbursementLineController trnDisbursementLineController = new Controllers.TrnDisbursementLineController();

            List<Entities.TrnDisbursementLineEntity> listDisbursementLine = trnDisbursementLineController.ListDisbursementLine(trnDisbursementEntity.Id);
            if (listDisbursementLine.Any())
            {
                var items = from d in listDisbursementLine
                            select new Entities.DgvDisbursementLineEntity
                            {
                                ColumnDisbursementLineListButtonEdit = "Edit",
                                ColumnDisbursementLineListButtonDelete = "Delete",
                                ColumnDisbursementLineListId = d.Id,
                                ColumnDisbursementLineListCVId = d.CVId,
                                ColumnDisbursementLineListArticleGroupId = d.ArticleGroupId,
                                ColumnDisbursementLineListArticleGroup = d.ArticleGroup,
                                ColumnDisbursementLineListRRId = d.RRId,
                                ColumnDisbursementLineListRR = d.RRNumber,
                                ColumnDisbursementLineListAmount = d.Amount.ToString("#,##0.00"),
                                ColumnDisbursementLineListOtherInformation = d.OtherInformation
                            };

                textBoxAmount.Text = listDisbursementLine.Sum(d => d.Amount).ToString("#,##0.00");

                return Task.FromResult(items.ToList());
            }
            else
            {
                textBoxAmount.Text = Convert.ToDecimal("0.00").ToString("#,##0.00");

                return Task.FromResult(new List<Entities.DgvDisbursementLineEntity>());
            }
        }

        public void CreateDisbursementDataGridView()
        {
            UpdateDisbursementLineDataSource();

            dataGridViewDisbursementLine.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewDisbursementLine.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewDisbursementLine.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewDisbursementLine.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewDisbursementLine.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewDisbursementLine.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewDisbursementLine.DataSource = disbursementLineDataSource;
        }

        public void GetDisbursementLineCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewDisbursementLine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetDisbursementLineCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewDisbursementLine.CurrentCell.ColumnIndex == dataGridViewDisbursementLine.Columns["ColumnDisbursementLineListButtonEdit"].Index)
            {
                var id = Convert.ToInt32(dataGridViewDisbursementLine.Rows[e.RowIndex].Cells[dataGridViewDisbursementLine.Columns["ColumnDisbursementLineListId"].Index].Value);
                var cVId = Convert.ToInt32(dataGridViewDisbursementLine.Rows[e.RowIndex].Cells[dataGridViewDisbursementLine.Columns["ColumnDisbursementLineListCVId"].Index].Value);
                var articleGroupId = Convert.ToInt32(dataGridViewDisbursementLine.Rows[e.RowIndex].Cells[dataGridViewDisbursementLine.Columns["ColumnDisbursementLineListArticleGroupId"].Index].Value);
                var rRId = Convert.ToUInt32(dataGridViewDisbursementLine.Rows[e.RowIndex].Cells[dataGridViewDisbursementLine.Columns["ColumnDisbursementLineListRRId"].Index].Value);
                var amount = Convert.ToDecimal(dataGridViewDisbursementLine.Rows[e.RowIndex].Cells[dataGridViewDisbursementLine.Columns["ColumnDisbursementLineListAmount"].Index].Value);
                var otherInformation = dataGridViewDisbursementLine.Rows[e.RowIndex].Cells[dataGridViewDisbursementLine.Columns["ColumnDisbursementLineListOtherInformation"].Index].Value.ToString();

                Entities.TrnDisbursementLineEntity updateDisbursementLineEntity = new Entities.TrnDisbursementLineEntity()
                {
                    Id = id,
                    CVId = cVId,
                    ArticleGroupId = articleGroupId,
                    RRId = (Int32?)rRId,
                    Amount = amount,
                    OtherInformation = otherInformation
                };

                TrnDisbursementDetailDisbursementLineDetailForm trnDisbursementDetailDisbursementLineForm = new TrnDisbursementDetailDisbursementLineDetailForm(this, updateDisbursementLineEntity, trnDisbursementEntity);
                trnDisbursementDetailDisbursementLineForm.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewDisbursementLine.CurrentCell.ColumnIndex == dataGridViewDisbursementLine.Columns["ColumnDisbursementLineListButtonDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete Stock-In?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(dataGridViewDisbursementLine.Rows[e.RowIndex].Cells[dataGridViewDisbursementLine.Columns["ColumnDisbursementLineListId"].Index].Value);

                    Controllers.TrnDisbursementLineController trnDisbursementLineController = new Controllers.TrnDisbursementLineController();
                    String[] deleteDisbursementLine = trnDisbursementLineController.DeleteDisbursementLine(id);
                    if (deleteDisbursementLine[1].Equals("0") == false)
                    {
                        pageNumber = 1;
                        UpdateDisbursementLineDataSource();
                    }
                    else
                    {
                        MessageBox.Show(deleteDisbursementLine[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonDisbursementLinePageListFirst_Click(object sender, EventArgs e)
        {
            disbursementLinePageList = new PagedList<Entities.DgvDisbursementLineEntity>(disbursementLineData, 1, pageSize);
            disbursementLineDataSource.DataSource = disbursementLinePageList;

            buttonDisbursementLinePageListFirst.Enabled = false;
            buttonDisbursementLinePageListPrevious.Enabled = false;
            buttonDisbursementLinePageListNext.Enabled = true;
            buttonDisbursementLinePageListLast.Enabled = true;

            pageNumber = 1;
            textBoxDisbursementLinePageNumber.Text = pageNumber + " / " + disbursementLinePageList.PageCount;
        }

        private void buttonDisbursementLinePageListPrevious_Click(object sender, EventArgs e)
        {
            if (disbursementLinePageList.HasPreviousPage == true)
            {
                disbursementLinePageList = new PagedList<Entities.DgvDisbursementLineEntity>(disbursementLineData, --pageNumber, pageSize);
                disbursementLineDataSource.DataSource = disbursementLinePageList;
            }

            buttonDisbursementLinePageListNext.Enabled = true;
            buttonDisbursementLinePageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonDisbursementLinePageListFirst.Enabled = false;
                buttonDisbursementLinePageListPrevious.Enabled = false;
            }

            textBoxDisbursementLinePageNumber.Text = pageNumber + " / " + disbursementLinePageList.PageCount;
        }

        private void buttonDisbursementLinePageListNext_Click(object sender, EventArgs e)
        {
            if (disbursementLinePageList.HasNextPage == true)
            {
                disbursementLinePageList = new PagedList<Entities.DgvDisbursementLineEntity>(disbursementLineData, ++pageNumber, pageSize);
                disbursementLineDataSource.DataSource = disbursementLinePageList;
            }

            buttonDisbursementLinePageListFirst.Enabled = true;
            buttonDisbursementLinePageListPrevious.Enabled = true;

            if (pageNumber == disbursementLinePageList.PageCount)
            {
                buttonDisbursementLinePageListNext.Enabled = false;
                buttonDisbursementLinePageListLast.Enabled = false;
            }

            textBoxDisbursementLinePageNumber.Text = pageNumber + " / " + disbursementLinePageList.PageCount;
        }

        private void buttonDisbursementLinePageListLast_Click(object sender, EventArgs e)
        {
            disbursementLinePageList = new PagedList<Entities.DgvDisbursementLineEntity>(disbursementLineData, disbursementLinePageList.PageCount, pageSize);
            disbursementLineDataSource.DataSource = disbursementLinePageList;

            buttonDisbursementLinePageListFirst.Enabled = true;
            buttonDisbursementLinePageListPrevious.Enabled = true;
            buttonDisbursementLinePageListNext.Enabled = false;
            buttonDisbursementLinePageListLast.Enabled = false;

            pageNumber = disbursementLinePageList.PageCount;
            textBoxDisbursementLinePageNumber.Text = pageNumber + " / " + disbursementLinePageList.PageCount;
        }

        private void buttonAddDisbursementLine_Click(object sender, EventArgs e)
        {
            TrnDisbursementDetailDisbursementLineDetailForm trnDisbursementDetailDisbursementLineForm = new TrnDisbursementDetailDisbursementLineDetailForm(this, null, trnDisbursementEntity);
            trnDisbursementDetailDisbursementLineForm.ShowDialog();
        }

        private void textBoxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBoxAmount_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxAmount.Text))
            {
                textBoxAmount.Text = "0.00";
            }
        }

    }
}
