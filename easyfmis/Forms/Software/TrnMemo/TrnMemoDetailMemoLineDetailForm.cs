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
    public partial class TrnMemoDetailMemoLineDetailForm : Form
    {
        public TrnMemoDetailForm trnMemoDetailForm;
        public Entities.TrnMemoLineEntity trnMemoLineEntity;
        public Entities.TrnMemoEntity trnMemoEntity;

        public TrnMemoDetailMemoLineDetailForm(TrnMemoDetailForm memoDetailForm, Entities.TrnMemoEntity memoEntity, Entities.TrnMemoLineEntity memoLineEntity, String articleType)
        {
            InitializeComponent();

            trnMemoDetailForm = memoDetailForm;
            trnMemoEntity = memoEntity;
            trnMemoLineEntity = memoLineEntity;

            if (articleType == "CUSTOMER")
            {
                comboBoxRRNumber.Enabled = false;
                GetSINumberList();
            }

            if (articleType == "SUPPLIER")
            {
                comboBoxSINumber.Enabled = false;
                GetRRNumberList();
            }

        }

        public void GetSINumberList()
        {
            Controllers.TrnMemoLineController trnMemoLineController = new Controllers.TrnMemoLineController();
            var SIList = trnMemoLineController.DropDownListSalesInvoice(trnMemoEntity.ArticleId);
            if (SIList.Any())
            {
                comboBoxSINumber.DataSource = SIList;
                comboBoxSINumber.ValueMember = "Id";
                comboBoxSINumber.DisplayMember = "SINumber";
            }
            GetMemoLineDetail();

        }

        public void GetRRNumberList()
        {
            Controllers.TrnMemoLineController trnMemoLineController = new Controllers.TrnMemoLineController();
            var SIList = trnMemoLineController.DropDownListListReceivingReceipt(trnMemoEntity.ArticleId);
            if (SIList.Any())
            {
                comboBoxRRNumber.DataSource = SIList;
                comboBoxRRNumber.ValueMember = "Id";
                comboBoxRRNumber.DisplayMember = "RRNumber";
            }

            GetMemoLineDetail();
        }

        public void GetMemoLineDetail()
        {
            if (trnMemoLineEntity != null)
            {
                comboBoxSINumber.SelectedValue = trnMemoLineEntity.SIId;
                comboBoxRRNumber.SelectedValue = trnMemoLineEntity.RRId;
                textBoxDebit.Text = trnMemoLineEntity.DebitAmount.ToString("#,##0.00");
                textBoxCredit.Text = trnMemoLineEntity.CreditAmount.ToString("#,##0.00");
                textBoxParticulars.Text = trnMemoLineEntity.Particulars;
            }
            else
            {
                textBoxDebit.Text = (0).ToString("#,##0.00");
                textBoxCredit.Text = (0).ToString("#,##0.00");
                textBoxParticulars.Text = "";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveMemoLine();
        }

        public void SaveMemoLine()
        {
            Int32 id = 0;
            if (trnMemoLineEntity != null)
            {
                id = trnMemoLineEntity.Id;
            }
            var mOId = trnMemoEntity.Id;
            var sIId = Convert.ToInt32(comboBoxSINumber.SelectedValue);
            var rRId = Convert.ToInt32(comboBoxRRNumber.SelectedValue);
            var debitAmount = Convert.ToDecimal(textBoxDebit.Text);
            var creditAmount = Convert.ToDecimal(textBoxCredit.Text);
            var particulars = textBoxParticulars.Text;

            Entities.TrnMemoLineEntity objMemoLineEntity = new Entities.TrnMemoLineEntity()
            {
                Id = id,
                MOId = mOId,
                SIId = sIId,
                RRId = rRId,
                DebitAmount = debitAmount,
                CreditAmount = creditAmount,
                Particulars = particulars
            };

            Controllers.TrnMemoLineController trnMemoLineController = new Controllers.TrnMemoLineController();
            if (objMemoLineEntity.Id == 0)
            {
                String[] addMemoLine = trnMemoLineController.AddMemoLine(objMemoLineEntity);
                if (addMemoLine[1].Equals("0") == false)
                {
                    trnMemoDetailForm.UpdateMemoLineDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(addMemoLine[0], "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                String[] updateMemoLine = trnMemoLineController.UpdateMemoLine(objMemoLineEntity);
                if (updateMemoLine[1].Equals("0") == false)
                {
                    trnMemoDetailForm.UpdateMemoLineDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(updateMemoLine[0], "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxDebitAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxDebitAmount_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxDebit.Text))
            {
                textBoxDebit.Text = "0.00";
            }
        }

        private void textBoxCreditAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxCreditAmount_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxDebit.Text))
            {
                textBoxDebit.Text = "0.00";
            }
        }

        private void textBoxParticulars_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxSINumber_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxRRNumber_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
