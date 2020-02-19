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
    public partial class TrnSalesInvoiceVariablePriceForm : Form
    {
        TrnSalesInvoiceDetailSalesInvoiceItemDetailForm trnSalesInvoiceDetailSalesInvoiceItemDetailForm;
        TrnSalesInvoiceDetailSalesInvoiceItemDetailPriceForm trnSalesInvoiceDetailSalesInvoiceItemDetailPriceForm;

        public TrnSalesInvoiceVariablePriceForm(TrnSalesInvoiceDetailSalesInvoiceItemDetailPriceForm salesInvoiceDetailSalesInvoiceItemDetailPriceForm,TrnSalesInvoiceDetailSalesInvoiceItemDetailForm salesInvoiceDetailSalesInvoiceItemDetailForm, Decimal Price)
        {
            InitializeComponent();
            trnSalesInvoiceDetailSalesInvoiceItemDetailPriceForm = salesInvoiceDetailSalesInvoiceItemDetailPriceForm;
            trnSalesInvoiceDetailSalesInvoiceItemDetailForm = salesInvoiceDetailSalesInvoiceItemDetailForm;

            textBoxPrice.Text = Price.ToString("#,##0.00");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Decimal price = Convert.ToDecimal(textBoxPrice.Text);
            trnSalesInvoiceDetailSalesInvoiceItemDetailForm.UpdatePrice(price);
            trnSalesInvoiceDetailSalesInvoiceItemDetailPriceForm.Close();
            Close();
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxPrice_Leave(object sender, EventArgs e)
        {
            textBoxPrice.Text = Convert.ToDecimal(textBoxPrice.Text).ToString("#,##0.00");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
