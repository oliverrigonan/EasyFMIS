using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software.TrnSalesInvoice
{
    public partial class TrnSalesInvoiceDetailDiscountForm : Form
    {
        public TrnSalesInvoiceDetailForm trnSalesInvoiceDetailForm;
        public Entities.TrnSalesInvoiceEntity trnSalesInvoiceEntity;
        public Decimal totalSIPrice = 0;

        public TrnSalesInvoiceDetailDiscountForm(TrnSalesInvoiceDetailForm salesInvoiceDetailForm, Entities.TrnSalesInvoiceEntity salesInvoiceEntity)
        {
            InitializeComponent();

            trnSalesInvoiceDetailForm = salesInvoiceDetailForm;
            trnSalesInvoiceEntity = salesInvoiceEntity;
            totalSIPrice = salesInvoiceDetailForm.SITotalItemPrice;


            GetDiscount();
        }

        public void GetDiscount()
        {
            Controllers.TrnSalesInvoiceItemController trnSalesInvoiceItemController = new Controllers.TrnSalesInvoiceItemController();
            if (trnSalesInvoiceItemController.DropdownListSalesInvoiceDiscount().Any())
            {
                comboBoxDiscount.DataSource = trnSalesInvoiceItemController.DropdownListSalesInvoiceDiscount();
                comboBoxDiscount.ValueMember = "Id";
                comboBoxDiscount.DisplayMember = "Discount";
            }
        }

        private void comboBoxDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDiscount.SelectedItem == null)
            {
                return;
            }

            if (comboBoxDiscount.Text.ToLower().Contains("variable"))
            {
                textBoxDiscountRate.ReadOnly = false;
                textBoxDiscountAmount.ReadOnly = false;
            }

            var selectedItem = (Entities.MstDiscountEntity)comboBoxDiscount.SelectedItem;
            if (selectedItem != null)
            {
                textBoxDiscountRate.Text = selectedItem.DiscountRate.ToString("#,##0.00");
                ComputeDiscountAmount();
            }
        }

        public void GetSalesDiscountInformation()
        {
            Int32? discountId = null;
            if (discountId != null)
            {
                comboBoxDiscount.SelectedValue = discountId;
            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Int32 discountId = Convert.ToInt32(comboBoxDiscount.SelectedValue);
            Decimal discountRate = Convert.ToDecimal(textBoxDiscountRate.Text);

            Entities.MstDiscountEntity discountEntity = new Entities.MstDiscountEntity()
            {
                Id = discountId,
                DiscountRate = discountRate
            };

            Controllers.TrnSalesInvoiceItemController trnSalesInvoiceItemController = new Controllers.TrnSalesInvoiceItemController();

            String[] discountSales = new String[2];

            if (trnSalesInvoiceDetailForm != null)
            {
                discountSales = trnSalesInvoiceItemController.DiscountSalesInvoice(trnSalesInvoiceDetailForm.trnSalesInvoiceEntity.Id, discountEntity);
            }

            if (discountSales[1].Equals("0") == false)
            {
                if (trnSalesInvoiceDetailForm != null)
                {
                    trnSalesInvoiceDetailForm.UpdateSalesInvoiceItemDataSource();
                }

                Close();
            }
            else
            {
                MessageBox.Show(discountSales[0], "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void DefaultZeroEmptyString()
        {
            if (String.IsNullOrEmpty(textBoxDiscountRate.Text))
            {
                textBoxDiscountRate.Text = Convert.ToDecimal(0).ToString("#,##0.00"); ;
            }

            if (String.IsNullOrEmpty(textBoxDiscountAmount.Text))
            {
                textBoxDiscountAmount.Text = Convert.ToDecimal(0).ToString("#,##0.00");
            }
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

        private void textBoxDiscountAmount_KeyPress(object sender, KeyPressEventArgs e)
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
            DefaultZeroEmptyString();
        }

        private void textBoxDiscountAmount_Leave(object sender, EventArgs e)
        {
            DefaultZeroEmptyString();
        }

        private void textBoxDiscountRate_TextChanged(object sender, EventArgs e)
        {
            ComputeDiscountAmount();
        }

        private void textBoxDiscountAmount_TextChanged(object sender, EventArgs e)
        {
            ComputeDiscountRate();
        }

        public void ComputeDiscountRate()
        {
            try
            {
                Decimal price = totalSIPrice;

                Decimal discountAmount = Convert.ToDecimal(textBoxDiscountAmount.Text);
                Decimal discountRate = 0;

                if (discountAmount > 0)
                {
                    discountRate = (discountAmount / price) * 100;
                }
                else
                {
                    discountRate = 0;
                }

                textBoxDiscountRate.Text = discountRate.ToString("#,##0.00");
                //textBoxDiscountRate.Text = discountRate.ToString("#,##0.00###");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ComputeDiscountAmount()
        {
            try
            {
                Decimal price = totalSIPrice;

                Decimal discountAmount = 0;
                Decimal discountRate = Convert.ToDecimal(textBoxDiscountRate.Text);

                if (discountRate > 0)
                {
                    discountAmount = (totalSIPrice * discountRate) / 100;
                }
                else
                {
                    discountAmount = 0;
                }

                textBoxDiscountAmount.Text = discountAmount.ToString("#,##0.00");
                //textBoxDiscountAmount.Text = discountAmount.ToString("#,##0.00###");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
