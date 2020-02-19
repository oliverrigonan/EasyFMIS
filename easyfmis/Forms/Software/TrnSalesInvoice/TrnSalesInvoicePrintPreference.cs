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
    public partial class TrnSalesInvoicePrintPreference : Form
    {
        Int32 sIID;

        public TrnSalesInvoicePrintPreference(Int32 salesInvoiceId)
        {
            InitializeComponent();
            sIID = salesInvoiceId;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonPrintSalesInvoice_Click(object sender, EventArgs e)
        {
            new TrnSalesInvoiceDetailPrintPreviewForm(sIID, "Sales Invoice");
        }

        private void buttonPrintPakingList_Click(object sender, EventArgs e)
        {
            new TrnSalesInvoiceDetailPrintPreviewForm(sIID, "Packing List");

        }
    }
}
