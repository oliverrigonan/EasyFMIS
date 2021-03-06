﻿using PagedList;
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
        private Modules.SysUserRightsModule sysUserRights;

        public SysMenuForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            sysUserRights = new Modules.SysUserRightsModule("SysMenu");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private void buttonCollection_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageCollectionList();
        }

        private void buttonDisbursement_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageDisbursementList();
        }

        private void buttonSystemTables_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageSystemTables();
        }

        private void buttonAccountsPayableReport_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageAccountsPayableReport();
        }

        private void buttonAccountsReceivableReport_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageAccountsReceivableReport();
        }

        private void buttonSupplier_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageSupplierList();
        }

        private void buttonMemo_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageMemoList();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {

        }
    }
}
