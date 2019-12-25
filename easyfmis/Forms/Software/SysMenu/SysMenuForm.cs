using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software.SysMenu
{
    public partial class SysMenuForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public SysMenuForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;
        }

        private void buttonStockIn_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageStockInList();
        }

        private void buttonStockOut_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageStockOutList();
        }

        private void buttonItem_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageItemList();
        }

        private void buttonInventoryReport_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageInventoryReports();
        }

        private void buttonCustomer_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageCustomerList();
        }

        private void buttonUser_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageUserList();

        }

        private void buttonCompany_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageCompanyList();
        }

        private void buttonStockTransfer_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageStockTransferList();
        }

        private void buttonSalesOrder_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageSalesOrderList();
        }

        private void buttonSalesInvoice_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageSalesInvoiceList();
        }

        private void buttonReceivingReceipt_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageReceivingReceiptList();
        }

        private void buttonPurchaseOrder_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPagePurchaseOrderList();
        }
    }
}
