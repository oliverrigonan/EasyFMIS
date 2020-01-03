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
    public partial class SysSystemTablesDiscountDetailForm : Form
    {
        SysSystemTablesForm sysSystemTablesForm;

        Entities.MstDiscountEntity mstDiscountEntity;

        public SysSystemTablesDiscountDetailForm(SysSystemTablesForm systemTablesForm, Entities.MstDiscountEntity discountEntity)
        {
            InitializeComponent();
            sysSystemTablesForm = systemTablesForm;
            mstDiscountEntity = discountEntity;

            LoadDiscount();
        }

        public void LoadDiscount()
        {
            if (mstDiscountEntity != null)
            {
                textDiscount.Text = mstDiscountEntity.Discount;
                textBoxDiscountRate.Text = mstDiscountEntity.DiscountRate.ToString("#,##0.00");
            }
            else
            {
                textBoxDiscountRate.Text = "0.00";
            }
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            Int32 discountId = 0;

            if (mstDiscountEntity != null)
            {
                discountId = mstDiscountEntity.Id;
            }

            Entities.MstDiscountEntity discountEntity = new Entities.MstDiscountEntity()
            {
                Id = discountId,
                Discount = textDiscount.Text,
                DiscountRate = Convert.ToDecimal(textBoxDiscountRate.Text)
            };

            if (mstDiscountEntity == null)
            {
                Controllers.MstDiscountController mstDiscountController = new Controllers.MstDiscountController();
                String[] addDiscount = mstDiscountController.AddDiscount(discountEntity);
                if (addDiscount[1].Equals("0") == true)
                {
                    MessageBox.Show(addDiscount[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    sysSystemTablesForm.UpdateDiscountListDataSource();
                    Close();
                }
            }
            else
            {
                Controllers.MstDiscountController mstDiscountController = new Controllers.MstDiscountController();
                String[] updateDiscount = mstDiscountController.UpdateDiscount(discountEntity);
                if (updateDiscount[1].Equals("0") == true)
                {
                    MessageBox.Show(updateDiscount[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    sysSystemTablesForm.UpdateDiscountListDataSource();
                    Close();
                }

            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxDiscountRate_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxDiscountRate_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxDiscountRate.Text))
            {
                textBoxDiscountRate.Text = Convert.ToDecimal(0).ToString("#,##0.00###");
            }
        }
    }
}
