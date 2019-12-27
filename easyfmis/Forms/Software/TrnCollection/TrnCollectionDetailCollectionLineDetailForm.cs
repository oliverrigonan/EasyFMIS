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
    public partial class TrnCollectionDetailCollectionLineDetailForm : Form
    {
        public TrnCollectionDetailForm trnCollectionDetailForm;

        public Entities.TrnCollectionLineEntity trnCollectionLineEntity;
        public Int32 customerId;

        public TrnCollectionDetailCollectionLineDetailForm(TrnCollectionDetailForm collectionDetailForm, Int32 filterCustomerId, Entities.TrnCollectionLineEntity collectionLineEntity)
        {
            InitializeComponent();
            trnCollectionDetailForm = collectionDetailForm;

            trnCollectionLineEntity = collectionLineEntity;
            customerId = filterCustomerId;

            GetArticleGroupList();
        }

        public void GetArticleGroupList()
        {
            Controllers.TrnCollectionLineController trnCollectionLineController = new Controllers.TrnCollectionLineController();
            if (trnCollectionLineController.DropdownListArticleGroup().Any())
            {
                comboBoxArticleGroup.DataSource = trnCollectionLineController.DropdownListArticleGroup();
                comboBoxArticleGroup.ValueMember = "Id";
                comboBoxArticleGroup.DisplayMember = "ArticleGroup";

                GetSINumberList();
            }
        }

        public void GetSINumberList()
        {
            Controllers.TrnCollectionLineController trnCollectionLineController = new Controllers.TrnCollectionLineController();
            if (trnCollectionLineController.DropdownListSINumber(customerId).Any())
            {
                comboBoxSINumber.DataSource = trnCollectionLineController.DropdownListSINumber(customerId);
                comboBoxSINumber.ValueMember = "Id";
                comboBoxSINumber.DisplayMember = "SINumber";

                GetPayTypeList();
            }
            else
            {
                GetPayTypeList();
            }
        }

        public void GetPayTypeList()
        {
            Controllers.TrnCollectionLineController trnCollectionLineController = new Controllers.TrnCollectionLineController();
            if (trnCollectionLineController.DropdownListPayType().Any())
            {
                comboBoxPayType.DataSource = trnCollectionLineController.DropdownListPayType();
                comboBoxPayType.ValueMember = "Id";
                comboBoxPayType.DisplayMember = "PayType";

                GetCollectionLineItemDetail();
            }
        }

        public void GetCollectionLineItemDetail()
        {
            comboBoxArticleGroup.SelectedValue = trnCollectionLineEntity.ArticleGroupId;

            if (trnCollectionLineEntity.SIId != null)
            {
                comboBoxSINumber.SelectedValue = trnCollectionLineEntity.SIId;
            }
            else
            {
                comboBoxSINumber.SelectedValue = "";
            }

            textBoxAmount.Text = trnCollectionLineEntity.Amount.ToString("#,##0.00");
            comboBoxPayType.SelectedValue = trnCollectionLineEntity.PayTypeId;
            textBoxCheckNumber.Text = trnCollectionLineEntity.CheckNumber;

            DateTime checkDate = DateTime.Today;
            if (trnCollectionLineEntity.CheckDate != null)
            {
                checkDate = Convert.ToDateTime(trnCollectionLineEntity.CheckDate);
            }

            dateTimePickerCheckDate.Value = checkDate;
            textBoxCheckBank.Text = trnCollectionLineEntity.CheckBank;
            textBoxCreditCardVerificationCode.Text = trnCollectionLineEntity.CreditCardVerificationCode;
            textBoxCreditCardNumber.Text = trnCollectionLineEntity.CreditCardNumber;
            textBoxCreditCardType.Text = trnCollectionLineEntity.CreditCardType;
            textBoxCreditCardBank.Text = trnCollectionLineEntity.CreditCardBank;
            textBoxCreditCardReferenceNumber.Text = trnCollectionLineEntity.CreditCardReferenceNumber;
            textBoxCreditCardHolderName.Text = trnCollectionLineEntity.CreditCardHolderName;
            textBoxCreditCardExpiry.Text = trnCollectionLineEntity.CreditCardExpiry;
            textBoxGiftCertificateNumber.Text = trnCollectionLineEntity.GiftCertificateNumber;
            textBoxOtherInformation.Text = trnCollectionLineEntity.OtherInformation;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveCollectionLine();
        }

        public void SaveCollectionLine()
        {
            var id = trnCollectionLineEntity.Id;
            var ORId = trnCollectionLineEntity.ORId;
            var articleGroupId = Convert.ToInt32(comboBoxArticleGroup.SelectedValue);
            var SIId = Convert.ToInt32(comboBoxSINumber.SelectedValue);
            var amount = Convert.ToDecimal(textBoxAmount.Text);
            var payTypeId = Convert.ToInt32(comboBoxPayType.SelectedValue);
            var checkNumber = textBoxCheckNumber.Text;
            var checkDate = dateTimePickerCheckDate.Value;
            var checkBank = textBoxCheckBank.Text;
            var creditCardVerificationCode = textBoxCreditCardVerificationCode.Text;
            var creditCardNumber = textBoxCreditCardNumber.Text;
            var creditCardType = textBoxCreditCardType.Text;
            var creditCardBank = textBoxCreditCardBank.Text;
            var creditCardReferenceNumber = textBoxCreditCardReferenceNumber.Text;
            var creditCardHolderName = textBoxCreditCardHolderName.Text;
            var creditCardExpiry = textBoxCreditCardExpiry.Text;
            var giftCertificateNumber = textBoxGiftCertificateNumber.Text;
            var otherInformation = textBoxOtherInformation.Text;

            Entities.TrnCollectionLineEntity newCollectionLineEntity = new Entities.TrnCollectionLineEntity()
            {
                Id = id,
                ORId = ORId,
                ArticleGroupId = articleGroupId,
                SIId = SIId,
                Amount = amount,
                PayTypeId = payTypeId,
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

            Controllers.TrnCollectionLineController trnCollectionLineController = new Controllers.TrnCollectionLineController();
            if (newCollectionLineEntity.Id == 0)
            {
                String[] addCollectionLine = trnCollectionLineController.AddCollectionLine(newCollectionLineEntity);
                if (addCollectionLine[1].Equals("0") == false)
                {
                    trnCollectionDetailForm.UpdateCollectionLineDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(addCollectionLine[0], "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                String[] updateCollectionLine = trnCollectionLineController.UpdateCollectionLine(trnCollectionLineEntity.Id, newCollectionLineEntity);
                if (updateCollectionLine[1].Equals("0") == false)
                {
                    trnCollectionDetailForm.UpdateCollectionLineDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(updateCollectionLine[0], "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxCollectionLineAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxCollectionLineCost_Leave(object sender, EventArgs e)
        {
            textBoxAmount.Text = Convert.ToDecimal(textBoxAmount.Text).ToString("#,##0.00");
        }
    }
}
