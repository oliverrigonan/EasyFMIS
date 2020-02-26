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


namespace easyfmis.Forms.Software.TrnCollection
{
    public partial class TrnCollectionDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        public TrnCollectionForm trnCollectionForm;
        public Entities.TrnCollectionEntity trnCollectionEntity;

        public static List<Entities.DgvCollectionLineEntity> collectionItemData = new List<Entities.DgvCollectionLineEntity>();
        public static Int32 collectionItemPageNumber = 1;
        public static Int32 collectionItemPageSize = 50;
        public PagedList<Entities.DgvCollectionLineEntity> collectionItemPageList = new PagedList<Entities.DgvCollectionLineEntity>(collectionItemData, collectionItemPageNumber, collectionItemPageSize);
        public BindingSource collectionItemDataSource = new BindingSource();

        public static List<Entities.DgvTrnInventoryEntriesEntity> inventoryEntriesData = new List<Entities.DgvTrnInventoryEntriesEntity>();
        public static Int32 inventoryEntriesPageNumber = 1;
        public static Int32 inventoryEntriesPageSize = 50;
        public PagedList<Entities.DgvTrnInventoryEntriesEntity> inventoryEntriesPageList = new PagedList<Entities.DgvTrnInventoryEntriesEntity>(inventoryEntriesData, inventoryEntriesPageNumber, inventoryEntriesPageSize);
        public BindingSource inventoryEntriesDataSource = new BindingSource();

        public TrnCollectionDetailForm(SysSoftwareForm softwareForm, TrnCollectionForm collectionListForm, Entities.TrnCollectionEntity collectionEntity)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            trnCollectionForm = collectionListForm;
            trnCollectionEntity = collectionEntity;

            GetCustomerList();
        }

        public void GetCustomerList()
        {
            Controllers.TrnCollectionController trnCollectionController = new Controllers.TrnCollectionController();
            if (trnCollectionController.DropdownListCollectionCustomer().Any())
            {
                comboBoxCustomer.DataSource = trnCollectionController.DropdownListCollectionCustomer();
                comboBoxCustomer.ValueMember = "Id";
                comboBoxCustomer.DisplayMember = "Article";

                GetUserList();
            }
        }

        public void GetUserList()
        {
            Controllers.TrnCollectionController trnCollectionController = new Controllers.TrnCollectionController();
            if (trnCollectionController.DropdownListCollectionUser().Any())
            {
                comboBoxPreparedBy.DataSource = trnCollectionController.DropdownListCollectionUser();
                comboBoxPreparedBy.ValueMember = "Id";
                comboBoxPreparedBy.DisplayMember = "FullName";

                comboBoxCheckedBy.DataSource = trnCollectionController.DropdownListCollectionUser();
                comboBoxCheckedBy.ValueMember = "Id";
                comboBoxCheckedBy.DisplayMember = "FullName";

                comboBoxApprovedBy.DataSource = trnCollectionController.DropdownListCollectionUser();
                comboBoxApprovedBy.ValueMember = "Id";
                comboBoxApprovedBy.DisplayMember = "FullName";

                GetCollectionDetail();
            }
        }

        public void GetCollectionDetail()
        {
            UpdateComponents(trnCollectionEntity.IsLocked);

            textBoxBranch.Text = trnCollectionEntity.Branch;
            textBoxORNumber.Text = trnCollectionEntity.ORNumber;
            dateTimePickerORDate.Value = trnCollectionEntity.ORDate;
            textBoxManualORNumber.Text = trnCollectionEntity.ManualORNumber;
            comboBoxCustomer.SelectedValue = trnCollectionEntity.CustomerId;
            textBoxRemarks.Text = trnCollectionEntity.Remarks;
            comboBoxPreparedBy.SelectedValue = trnCollectionEntity.PreparedBy;
            comboBoxCheckedBy.SelectedValue = trnCollectionEntity.CheckedBy;
            comboBoxApprovedBy.SelectedValue = trnCollectionEntity.ApprovedBy;

            CreateCollectionLineDataGridView();
        }

        public void UpdateComponents(Boolean isLocked)
        {
            buttonLock.Enabled = !isLocked;
            buttonUnlock.Enabled = isLocked;
            buttonPrint.Enabled = isLocked;

            buttonSearchItem.Enabled = !isLocked;

            textBoxBranch.Enabled = !isLocked;
            textBoxORNumber.Enabled = !isLocked;
            dateTimePickerORDate.Enabled = !isLocked;
            textBoxManualORNumber.Enabled = !isLocked;
            comboBoxCustomer.Enabled = !isLocked;
            textBoxRemarks.Enabled = !isLocked;
            comboBoxCheckedBy.Enabled = !isLocked;
            comboBoxApprovedBy.Enabled = !isLocked;

            dataGridViewCollectionLine.Columns[0].Visible = !isLocked;
            dataGridViewCollectionLine.Columns[1].Visible = !isLocked;
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            Entities.TrnCollectionEntity newCollectionEntity = new Entities.TrnCollectionEntity()
            {
                ORDate = dateTimePickerORDate.Value.Date,
                ManualORNumber = textBoxManualORNumber.Text,
                CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue),
                Remarks = textBoxRemarks.Text,
                CheckedBy = Convert.ToInt32(comboBoxCheckedBy.SelectedValue),
                ApprovedBy = Convert.ToInt32(comboBoxApprovedBy.SelectedValue)
            };

            Controllers.TrnCollectionController trnCollectionController = new Controllers.TrnCollectionController();
            String[] lockCollection = trnCollectionController.LockCollection(trnCollectionEntity.Id, newCollectionEntity);

            if (lockCollection[1].Equals("0") == false)
            {
                UpdateComponents(true);
                trnCollectionForm.UpdateCollectionDataSource();
            }
            else
            {
                MessageBox.Show(lockCollection[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            Controllers.TrnCollectionController trnCollectionController = new Controllers.TrnCollectionController();
            String[] unlockCollection = trnCollectionController.UnlockCollection(trnCollectionEntity.Id);

            if (unlockCollection[1].Equals("0") == false)
            {
                UpdateComponents(false);
                trnCollectionForm.UpdateCollectionDataSource();
            }
            else
            {
                MessageBox.Show(unlockCollection[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            new TrnCollectionDetailPrintPreviewForm(trnCollectionEntity.Id);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
            sysSoftwareForm.RemoveTabPage();
        }

        public void UpdateCollectionLineDataSource()
        {
            SetCollectionLineDataSourceAsync();
        }

        public async void SetCollectionLineDataSourceAsync()
        {
            List<Entities.DgvCollectionLineEntity> getCollectionLineData = await GetCollectionLineDataTask();
            if (getCollectionLineData.Any())
            {
                collectionItemPageNumber = 1;
                collectionItemData = getCollectionLineData;
                collectionItemPageList = new PagedList<Entities.DgvCollectionLineEntity>(collectionItemData, collectionItemPageNumber, collectionItemPageSize);

                if (collectionItemPageList.PageCount == 1)
                {
                    buttonCollectionLinePageListFirst.Enabled = false;
                    buttonCollectionLinePageListPrevious.Enabled = false;
                    buttonCollectionLinePageListNext.Enabled = false;
                    buttonCollectionLinePageListLast.Enabled = false;
                }
                else if (collectionItemPageNumber == 1)
                {
                    buttonCollectionLinePageListFirst.Enabled = false;
                    buttonCollectionLinePageListPrevious.Enabled = false;
                    buttonCollectionLinePageListNext.Enabled = true;
                    buttonCollectionLinePageListLast.Enabled = true;
                }
                else if (collectionItemPageNumber == collectionItemPageList.PageCount)
                {
                    buttonCollectionLinePageListFirst.Enabled = true;
                    buttonCollectionLinePageListPrevious.Enabled = true;
                    buttonCollectionLinePageListNext.Enabled = false;
                    buttonCollectionLinePageListLast.Enabled = false;
                }
                else
                {
                    buttonCollectionLinePageListFirst.Enabled = true;
                    buttonCollectionLinePageListPrevious.Enabled = true;
                    buttonCollectionLinePageListNext.Enabled = true;
                    buttonCollectionLinePageListLast.Enabled = true;
                }

                textBoxCollectionLinePageNumber.Text = collectionItemPageNumber + " / " + collectionItemPageList.PageCount;
                collectionItemDataSource.DataSource = collectionItemPageList;
            }
            else
            {
                buttonCollectionLinePageListFirst.Enabled = false;
                buttonCollectionLinePageListPrevious.Enabled = false;
                buttonCollectionLinePageListNext.Enabled = false;
                buttonCollectionLinePageListLast.Enabled = false;

                collectionItemPageNumber = 1;

                collectionItemData = new List<Entities.DgvCollectionLineEntity>();
                collectionItemDataSource.Clear();
                textBoxCollectionLinePageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvCollectionLineEntity>> GetCollectionLineDataTask()
        {
            Controllers.TrnCollectionLineController trnCollectionLineController = new Controllers.TrnCollectionLineController();

            List<Entities.TrnCollectionLineEntity> listCollectionLine = trnCollectionLineController.ListCollectionLine(trnCollectionEntity.Id);
            if (listCollectionLine.Any())
            {

                var items = from d in listCollectionLine
                            select new Entities.DgvCollectionLineEntity
                            {
                                ColumnCollectionLineListButtonEdit = "Edit",
                                ColumnCollectionLineListButtonDelete = "Delete",
                                ColumnCollectionLineListId = d.Id,
                                ColumnCollectionLineListORId = d.ORId,
                                ColumnCollectionLineListArticleGroupId = d.ArticleGroupId,
                                ColumnCollectionLineListArticleGroup = d.ArticleGroup,
                                ColumnCollectionLineListSIId = d.SIId,
                                ColumnCollectionLineListSINumber = d.SINumber,
                                ColumnCollectionLineListAmount = d.Amount.ToString("#,##0.00"),
                                ColumnCollectionLineListPayTypeId = d.PayTypeId,
                                ColumnCollectionLineListPayType = d.PayType,
                                ColumnCollectionLineListCheckNumber = d.CheckNumber,
                                ColumnCollectionLineListCheckDate = d.CheckDate != null ? Convert.ToDateTime(d.CheckDate).ToShortDateString() : "",
                                ColumnCollectionLineListCheckBank = d.CheckBank,
                                ColumnCollectionLineListCreditCardVerificationCode = d.CreditCardVerificationCode,
                                ColumnCollectionLineListCreditCardNumber = d.CreditCardNumber,
                                ColumnCollectionLineListCreditCardType = d.CreditCardType,
                                ColumnCollectionLineListCreditCardBank = d.CreditCardBank,
                                ColumnCollectionLineListCreditCardReferenceNumber = d.CreditCardReferenceNumber,
                                ColumnCollectionLineListCreditCardHolderName = d.CreditCardHolderName,
                                ColumnCollectionLineListCreditCardExpiry = d.CreditCardExpiry,
                                ColumnCollectionLineListGiftCertificateNumber = d.GiftCertificateNumber,
                                ColumnCollectionLineListOtherInformation = d.OtherInformation,
                                ColumnCollectionLineListSpace = ""
                            };

                textBoxTotalAmount.Text = listCollectionLine.Sum(d => d.Amount).ToString("#,##0.00");

                return Task.FromResult(items.ToList());
            }
            else
            {
                textBoxTotalAmount.Text = Convert.ToDecimal("0").ToString("#,##0.00");

                return Task.FromResult(new List<Entities.DgvCollectionLineEntity>());
            }
        }



        public void CreateCollectionLineDataGridView()
        {
            UpdateCollectionLineDataSource();

            dataGridViewCollectionLine.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewCollectionLine.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewCollectionLine.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewCollectionLine.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewCollectionLine.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewCollectionLine.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewCollectionLine.DataSource = collectionItemDataSource;
        }

        public void GetCollectionLineCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewCollectionLine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetCollectionLineCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewCollectionLine.CurrentCell.ColumnIndex == dataGridViewCollectionLine.Columns["ColumnCollectionLineListButtonEdit"].Index)
            {

                var id = Convert.ToInt32(dataGridViewCollectionLine.Rows[e.RowIndex].Cells[dataGridViewCollectionLine.Columns["ColumnCollectionLineListId"].Index].Value);
                if (id != 0)
                {
                    var ORId = Convert.ToInt32(dataGridViewCollectionLine.Rows[e.RowIndex].Cells[dataGridViewCollectionLine.Columns["ColumnCollectionLineListORId"].Index].Value);
                    var articleGroupId = Convert.ToInt32(dataGridViewCollectionLine.Rows[e.RowIndex].Cells[dataGridViewCollectionLine.Columns["ColumnCollectionLineListArticleGroupId"].Index].Value);
                    var articleGroup = dataGridViewCollectionLine.Rows[e.RowIndex].Cells[dataGridViewCollectionLine.Columns["ColumnCollectionLineListArticleGroup"].Index].Value.ToString();
                    var SIId = Convert.ToInt32(dataGridViewCollectionLine.Rows[e.RowIndex].Cells[dataGridViewCollectionLine.Columns["ColumnCollectionLineListSIId"].Index].Value);
                    var SINumber = dataGridViewCollectionLine.Rows[e.RowIndex].Cells[dataGridViewCollectionLine.Columns["ColumnCollectionLineListSINumber"].Index].Value.ToString();
                    var amount = Convert.ToDecimal(dataGridViewCollectionLine.Rows[e.RowIndex].Cells[dataGridViewCollectionLine.Columns["ColumnCollectionLineListAmount"].Index].Value);
                    var payTypeId = Convert.ToInt32(dataGridViewCollectionLine.Rows[e.RowIndex].Cells[dataGridViewCollectionLine.Columns["ColumnCollectionLineListPayTypeId"].Index].Value);
                    var payType = dataGridViewCollectionLine.Rows[e.RowIndex].Cells[dataGridViewCollectionLine.Columns["ColumnCollectionLineListPayType"].Index].Value.ToString();
                    var checkNumber = dataGridViewCollectionLine.Rows[e.RowIndex].Cells[dataGridViewCollectionLine.Columns["ColumnCollectionLineListCheckNumber"].Index].Value.ToString();
                    var checkDate = Convert.ToDateTime(dataGridViewCollectionLine.Rows[e.RowIndex].Cells[dataGridViewCollectionLine.Columns["ColumnCollectionLineListCheckDate"].Index].Value);
                    var checkBank = dataGridViewCollectionLine.Rows[e.RowIndex].Cells[dataGridViewCollectionLine.Columns["ColumnCollectionLineListCheckBank"].Index].Value.ToString();
                    var creditCardVerificationCode = dataGridViewCollectionLine.Rows[e.RowIndex].Cells[dataGridViewCollectionLine.Columns["ColumnCollectionLineListCreditCardVerificationCode"].Index].Value.ToString();
                    var creditCardNumber = dataGridViewCollectionLine.Rows[e.RowIndex].Cells[dataGridViewCollectionLine.Columns["ColumnCollectionLineListCreditCardNumber"].Index].Value.ToString();
                    var creditCardType = dataGridViewCollectionLine.Rows[e.RowIndex].Cells[dataGridViewCollectionLine.Columns["ColumnCollectionLineListCreditCardType"].Index].Value.ToString();
                    var creditCardBank = dataGridViewCollectionLine.Rows[e.RowIndex].Cells[dataGridViewCollectionLine.Columns["ColumnCollectionLineListCreditCardBank"].Index].Value.ToString();
                    var creditCardReferenceNumber = dataGridViewCollectionLine.Rows[e.RowIndex].Cells[dataGridViewCollectionLine.Columns["ColumnCollectionLineListCreditCardReferenceNumber"].Index].Value.ToString();
                    var creditCardHolderName = dataGridViewCollectionLine.Rows[e.RowIndex].Cells[dataGridViewCollectionLine.Columns["ColumnCollectionLineListCreditCardHolderName"].Index].Value.ToString();
                    var creditCardExpiry = dataGridViewCollectionLine.Rows[e.RowIndex].Cells[dataGridViewCollectionLine.Columns["ColumnCollectionLineListCreditCardExpiry"].Index].Value.ToString();
                    var giftCertificateNumber = dataGridViewCollectionLine.Rows[e.RowIndex].Cells[dataGridViewCollectionLine.Columns["ColumnCollectionLineListGiftCertificateNumber"].Index].Value.ToString();
                    var otherInformation = dataGridViewCollectionLine.Rows[e.RowIndex].Cells[dataGridViewCollectionLine.Columns["ColumnCollectionLineListOtherInformation"].Index].Value.ToString();

                    Entities.TrnCollectionLineEntity currentCollectionLineEntity = new Entities.TrnCollectionLineEntity()
                    {
                        Id = id,
                        ORId = ORId,
                        ArticleGroupId = articleGroupId,
                        ArticleGroup = articleGroup,
                        SIId = SIId,
                        SINumber = SINumber,
                        Amount = amount,
                        PayTypeId = payTypeId,
                        PayType = payType,
                        CheckNumber = checkNumber,
                        CheckDate = checkDate,
                        CheckBank = checkBank,
                        CreditCardVerificationCode = creditCardVerificationCode,
                        CreditCardNumber = creditCardNumber,
                        CreditCardType = creditCardType,
                        CreditCardBank = creditCardBank,
                        CreditCardReferenceNumber = creditCardReferenceNumber,
                        CreditCardHolderName = creditCardHolderName,
                        CreditCardExpiry = creditCardExpiry,
                        GiftCertificateNumber = giftCertificateNumber,
                        OtherInformation = otherInformation
                    };
                    TrnCollectionDetailCollectionLineDetailForm trnCollectionDetailCollectionLineDetailForm = new TrnCollectionDetailCollectionLineDetailForm(this, currentCollectionLineEntity);
                    trnCollectionDetailCollectionLineDetailForm.ShowDialog();
                }
            }

            if (e.RowIndex > -1 && dataGridViewCollectionLine.CurrentCell.ColumnIndex == dataGridViewCollectionLine.Columns["ColumnCollectionLineListButtonDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete Stock-In?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(dataGridViewCollectionLine.Rows[e.RowIndex].Cells[dataGridViewCollectionLine.Columns["ColumnCollectionLineListId"].Index].Value);
                    if (id != 0)
                    {
                        Controllers.TrnCollectionLineController trnCollectionLineController = new Controllers.TrnCollectionLineController();
                        String[] deleteCollectionLine = trnCollectionLineController.DeleteCollectionLine(id);
                        if (deleteCollectionLine[1].Equals("0") == false)
                        {
                            collectionItemPageNumber = 1;
                            UpdateCollectionLineDataSource();
                        }
                        else
                        {
                            MessageBox.Show(deleteCollectionLine[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void buttonCollectionLinePageListFirst_Click(object sender, EventArgs e)
        {
            collectionItemPageList = new PagedList<Entities.DgvCollectionLineEntity>(collectionItemData, 1, collectionItemPageSize);
            collectionItemDataSource.DataSource = collectionItemPageList;

            buttonCollectionLinePageListFirst.Enabled = false;
            buttonCollectionLinePageListPrevious.Enabled = false;
            buttonCollectionLinePageListNext.Enabled = true;
            buttonCollectionLinePageListLast.Enabled = true;

            collectionItemPageNumber = 1;
            textBoxCollectionLinePageNumber.Text = collectionItemPageNumber + " / " + collectionItemPageList.PageCount;
        }

        private void buttonCollectionLinePageListPrevious_Click(object sender, EventArgs e)
        {
            if (collectionItemPageList.HasPreviousPage == true)
            {
                collectionItemPageList = new PagedList<Entities.DgvCollectionLineEntity>(collectionItemData, --collectionItemPageNumber, collectionItemPageSize);
                collectionItemDataSource.DataSource = collectionItemPageList;
            }

            buttonCollectionLinePageListNext.Enabled = true;
            buttonCollectionLinePageListLast.Enabled = true;

            if (collectionItemPageNumber == 1)
            {
                buttonCollectionLinePageListFirst.Enabled = false;
                buttonCollectionLinePageListPrevious.Enabled = false;
            }

            textBoxCollectionLinePageNumber.Text = collectionItemPageNumber + " / " + collectionItemPageList.PageCount;
        }

        private void buttonCollectionLinePageListNext_Click(object sender, EventArgs e)
        {
            if (collectionItemPageList.HasNextPage == true)
            {
                collectionItemPageList = new PagedList<Entities.DgvCollectionLineEntity>(collectionItemData, ++collectionItemPageNumber, collectionItemPageSize);
                collectionItemDataSource.DataSource = collectionItemPageList;
            }

            buttonCollectionLinePageListFirst.Enabled = true;
            buttonCollectionLinePageListPrevious.Enabled = true;

            if (collectionItemPageNumber == collectionItemPageList.PageCount)
            {
                buttonCollectionLinePageListNext.Enabled = false;
                buttonCollectionLinePageListLast.Enabled = false;
            }

            textBoxCollectionLinePageNumber.Text = collectionItemPageNumber + " / " + collectionItemPageList.PageCount;
        }

        private void buttonCollectionLinePageListLast_Click(object sender, EventArgs e)
        {
            collectionItemPageList = new PagedList<Entities.DgvCollectionLineEntity>(collectionItemData, collectionItemPageList.PageCount, collectionItemPageSize);
            collectionItemDataSource.DataSource = collectionItemPageList;

            buttonCollectionLinePageListFirst.Enabled = true;
            buttonCollectionLinePageListPrevious.Enabled = true;
            buttonCollectionLinePageListNext.Enabled = false;
            buttonCollectionLinePageListLast.Enabled = false;

            collectionItemPageNumber = collectionItemPageList.PageCount;
            textBoxCollectionLinePageNumber.Text = collectionItemPageNumber + " / " + collectionItemPageList.PageCount;
        }

        private void buttonSearchItem_Click(object sender, EventArgs e)
        {
            Entities.TrnCollectionLineEntity newCollectionLineEntity = new Entities.TrnCollectionLineEntity()
            {
                Id = 0,
                ORId = trnCollectionEntity.Id,
                ArticleGroupId = 0,
                ArticleGroup = "",
                SIId = null,
                SINumber = "",
                Amount = 0,
                PayTypeId = 0,
                PayType = "",
                CheckNumber = "",
                CheckDate = null,
                CheckBank = "",
                CreditCardVerificationCode = "",
                CreditCardNumber = "",
                CreditCardType = "",
                CreditCardBank = "",
                CreditCardReferenceNumber = "",
                CreditCardHolderName = "",
                CreditCardExpiry = "",
                GiftCertificateNumber = "",
                OtherInformation = ""
            };

            TrnCollectionSalesInvoiceListForm trnCollectionSalesInvoiceListForm = new TrnCollectionSalesInvoiceListForm(this, Convert.ToInt32(comboBoxCustomer.SelectedValue), newCollectionLineEntity);
            trnCollectionSalesInvoiceListForm.ShowDialog();
        }


    }
}
