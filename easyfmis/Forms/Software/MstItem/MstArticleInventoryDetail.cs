using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software.MstItem
{
    public partial class MstArticleInventoryDetail : Form
    {
        MstItemDetailForm mstItemDetailForm;
        Entities.MstArticleInventoryEntity mstArticleInventoryEntity;

        public MstArticleInventoryDetail(MstItemDetailForm itemDetailForm, Entities.MstArticleInventoryEntity articleInventoryEntity)
        {
            InitializeComponent();
            mstItemDetailForm = itemDetailForm;
            mstArticleInventoryEntity = articleInventoryEntity;
            LoadComponent();
        }

        public void LoadComponent() {
            textBoxBranchCode.Text = mstArticleInventoryEntity.BranchCode;
            textBoxInventoryCode.Text = mstArticleInventoryEntity.InventoryCode;
            textBoxQuantity.Text = mstArticleInventoryEntity.Quantity.ToString("#,##0.00");
            textBoxCost1.Text = mstArticleInventoryEntity.Cost1.ToString("#,##0.00");
            textBoxCost2.Text = mstArticleInventoryEntity.Cost2.ToString("#,##0.00");
            textBoxCost3.Text = mstArticleInventoryEntity.Cost3.ToString("#,##0.00");
            textBoxCost4.Text = mstArticleInventoryEntity.Cost4.ToString("#,##0.00");
            textBoxCost5.Text = mstArticleInventoryEntity.Cost5.ToString("#,##0.00");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            mstArticleInventoryEntity.Quantity = Convert.ToDecimal(textBoxQuantity.Text);
            mstArticleInventoryEntity.Cost1 = Convert.ToDecimal(textBoxCost1.Text);
            mstArticleInventoryEntity.Cost2 = Convert.ToDecimal(textBoxCost2.Text);
            mstArticleInventoryEntity.Cost3 = Convert.ToDecimal(textBoxCost3.Text);
            mstArticleInventoryEntity.Cost4 = Convert.ToDecimal(textBoxCost4.Text);
            mstArticleInventoryEntity.Cost5 = Convert.ToDecimal(textBoxCost5.Text);

            Controllers.MstArticleInventoryController mstArticleInventoryController = new Controllers.MstArticleInventoryController();
            String[] updateItemInventory = mstArticleInventoryController.UpdateItemInventory(mstArticleInventoryEntity);

            if (updateItemInventory[1].Equals("0") == true)
            {
                MessageBox.Show(updateItemInventory[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                mstItemDetailForm.UpdateItemInventoryListDataSource();
                Close();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void DefaultZeroEmptyString()
        {
            if (String.IsNullOrEmpty(textBoxQuantity.Text))
            {
                textBoxQuantity.Text = Convert.ToDecimal(0).ToString("#,##0.00###");
            }

            if (String.IsNullOrEmpty(textBoxCost1.Text))
            {
                textBoxCost1.Text = Convert.ToDecimal(textBoxCost1.Text).ToString("#,##0.00");
            }

            if (String.IsNullOrEmpty(textBoxCost2.Text))
            {
                textBoxCost2.Text = Convert.ToDecimal(textBoxCost2.Text).ToString("#,##0.00");
            }

            if (String.IsNullOrEmpty(textBoxCost3.Text))
            {
                textBoxCost3.Text = Convert.ToDecimal(textBoxCost3.Text).ToString("#,##0.00");
            }

            if (String.IsNullOrEmpty(textBoxCost4.Text))
            {
                textBoxCost4.Text = Convert.ToDecimal(textBoxCost4.Text).ToString("#,##0.00");
            }

            if (String.IsNullOrEmpty(textBoxCost5.Text))
            {
                textBoxCost5.Text = Convert.ToDecimal(textBoxCost5.Text).ToString("#,##0.00");
            }

            if (String.IsNullOrEmpty(textBoxCost5.Text))
            {
                textBoxQuantity.Text = Convert.ToDecimal(textBoxQuantity.Text).ToString("#,##0.00");
            }
        }



        private void textBoxCost1_Leave(object sender, EventArgs e)
        {
            DefaultZeroEmptyString();
        }


        private void textBoxCost2_Leave(object sender, EventArgs e)
        {
            DefaultZeroEmptyString();
        }

        private void textBoxCost3_Leave(object sender, EventArgs e)
        {
            DefaultZeroEmptyString();
        }

        private void textBoxCost4_Leave(object sender, EventArgs e)
        {
            DefaultZeroEmptyString();
        }

        private void textBoxCost5_Leave(object sender, EventArgs e)
        {
            DefaultZeroEmptyString();
        }

        private void textBoxQuantity_Leave(object sender, EventArgs e)
        {
            DefaultZeroEmptyString();
        }

        private void textBoxCost1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxCost2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxCost3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxCost4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxCost5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxQuantity_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
