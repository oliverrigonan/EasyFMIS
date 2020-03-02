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
            sysUserRights = new Modules.SysUserRightsModule("TrnStockIn");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sysSoftwareForm.AddTabPageStockInList();
            }
        }

        private void buttonStockOut_Click(object sender, EventArgs e)
        {
            sysUserRights = new Modules.SysUserRightsModule("TrnStockOut");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sysSoftwareForm.AddTabPageStockOutList();
            }
        }

        private void buttonItem_Click(object sender, EventArgs e)
        {
            sysUserRights = new Modules.SysUserRightsModule("MstItem");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sysSoftwareForm.AddTabPageItemList();
            }
        }

        private void buttonInventoryReport_Click(object sender, EventArgs e)
        {
            sysUserRights = new Modules.SysUserRightsModule("RepInventory");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sysSoftwareForm.AddTabPageInventoryReports();
            }
        }

        private void buttonCustomer_Click(object sender, EventArgs e)
        {
            sysUserRights = new Modules.SysUserRightsModule("MstCustomer");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sysSoftwareForm.AddTabPageCustomerList();
            }
        }

        private void buttonUser_Click(object sender, EventArgs e)
        {
            sysUserRights = new Modules.SysUserRightsModule("MstUser");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sysSoftwareForm.AddTabPageUserList();
            }
        }

        private void buttonCompany_Click(object sender, EventArgs e)
        {
            sysUserRights = new Modules.SysUserRightsModule("MstCompany");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sysSoftwareForm.AddTabPageCompanyList();
            }
        }

        private void buttonStockTransfer_Click(object sender, EventArgs e)
        {
            sysUserRights = new Modules.SysUserRightsModule("TrnStockTransfer");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sysSoftwareForm.AddTabPageStockTransferList();
            }
        }

        private void buttonSalesOrder_Click(object sender, EventArgs e)
        {
            sysUserRights = new Modules.SysUserRightsModule("TrnSalesOrder");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sysSoftwareForm.AddTabPageSalesOrderList();
            }
        }

        private void buttonSalesInvoice_Click(object sender, EventArgs e)
        {
            sysUserRights = new Modules.SysUserRightsModule("TrnSalesInvoice");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sysSoftwareForm.AddTabPageSalesInvoiceList();
            }
        }

        private void buttonReceivingReceipt_Click(object sender, EventArgs e)
        {
            sysUserRights = new Modules.SysUserRightsModule("TrnReceivingReceipt");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sysSoftwareForm.AddTabPageReceivingReceiptList();
            }
        }

        private void buttonPurchaseOrder_Click(object sender, EventArgs e)
        {
            sysUserRights = new Modules.SysUserRightsModule("TrnPurchaseOrder");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sysSoftwareForm.AddTabPagePurchaseOrderList();
            }
        }

        private void buttonCollection_Click(object sender, EventArgs e)
        {
            sysUserRights = new Modules.SysUserRightsModule("TrnCollection");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sysSoftwareForm.AddTabPageCollectionList();
            }
        }

        private void buttonDisbursement_Click(object sender, EventArgs e)
        {
            sysUserRights = new Modules.SysUserRightsModule("TrnDisbursement");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sysSoftwareForm.AddTabPageDisbursementList();
            }
        }

        private void buttonSystemTables_Click(object sender, EventArgs e)
        {
            sysUserRights = new Modules.SysUserRightsModule("MstTables");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sysSoftwareForm.AddTabPageSystemTables();
            }
        }

        private void buttonAccountsPayableReport_Click(object sender, EventArgs e)
        {
            sysUserRights = new Modules.SysUserRightsModule("RepAccountsPayable");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sysSoftwareForm.AddTabPageAccountsPayableReport();
            }
        }

        private void buttonAccountsReceivableReport_Click(object sender, EventArgs e)
        {
            sysUserRights = new Modules.SysUserRightsModule("RepAccountsReceivable");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sysSoftwareForm.AddTabPageAccountsReceivableReport();
            }
        }

        private void buttonSupplier_Click(object sender, EventArgs e)
        {
            sysUserRights = new Modules.SysUserRightsModule("MstSupplier");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sysSoftwareForm.AddTabPageSupplierList();
            }
        }

        private void buttonMemo_Click(object sender, EventArgs e)
        {
            sysUserRights = new Modules.SysUserRightsModule("TrnMemo");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sysSoftwareForm.AddTabPageMemoList();
            }
        }
    }
}
