using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software.RepInventoryReport
{
    public partial class RepInventoryReportForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        private Modules.SysUserRightsModule sysUserRights;

        public RepInventoryReportForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            GetCompanies();
        }

        public void GetCompanies()
        {
            Controllers.RepInventoryReportController repInventoryReportController = new Controllers.RepInventoryReportController();
            var companies = repInventoryReportController.DropdownListCompany();
            if (companies.Any())
            {
                comboBoxCompany.DataSource = companies;
                comboBoxCompany.ValueMember = "Id";
                comboBoxCompany.DisplayMember = "Company";

                GetBranches();
            }
        }

        public void GetBranches()
        {
            if (comboBoxCompany.SelectedValue != null)
            {

                Int32 companyId = Convert.ToInt32(comboBoxCompany.SelectedValue);

                Controllers.RepInventoryReportController repInventoryReportController = new Controllers.RepInventoryReportController();
                var branches = repInventoryReportController.DropdownListBranch(companyId);
                if (branches.Any())
                {
                    comboBoxBranch.DataSource = branches;
                    comboBoxBranch.ValueMember = "Id";
                    comboBoxBranch.DisplayMember = "Branch";

                    GetItems();
                }
            }
            else
            {
                GetItems();
            }
        }

        public void GetItems()
        {
            Controllers.RepInventoryReportController repInventoryReportController = new Controllers.RepInventoryReportController();
            var items = repInventoryReportController.DropdownListItem();
            if (items.Any())
            {
                comboBoxItem.DataSource = items;
                comboBoxItem.ValueMember = "Id";
                comboBoxItem.DisplayMember = "Article";

                GetItemCode();
            }
        }

        public void GetItemCode()
        {
            Controllers.RepInventoryReportController repInventoryReportController = new Controllers.RepInventoryReportController();
            var itemCodes = repInventoryReportController.DropdownListItemCodes();
            if (itemCodes.Any())
            {
                comboBoxItemCode.DataSource = itemCodes;
                comboBoxItemCode.ValueMember = "Id";
                comboBoxItemCode.DisplayMember = "ArticleBarCode";
            }
        }

        private void listBoxSalesReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxInventoryReport.SelectedItem != null)
            {
                String selectedItem = listBoxInventoryReport.SelectedItem.ToString();
                switch (selectedItem)
                {
                    case "Inventory Report":
                        labelStartDate.Visible = true;
                        dateTimePickerStartDate.Visible = true;

                        labelEndDate.Visible = true;
                        dateTimePickerEndDate.Visible = true;

                        labelCompany.Visible = true;
                        comboBoxCompany.Visible = true;

                        labelBranch.Visible = true;
                        comboBoxBranch.Visible = true;

                        labelItem.Visible = false;
                        comboBoxItem.Visible = false;

                        labelItemCode.Visible = false;
                        comboBoxItemCode.Visible = false;

                        break;
                    case "Stock Card":
                        labelStartDate.Visible = true;
                        dateTimePickerStartDate.Visible = true;

                        labelEndDate.Visible = true;
                        dateTimePickerEndDate.Visible = true;

                        labelCompany.Visible = true;
                        comboBoxCompany.Visible = true;

                        labelBranch.Visible = true;
                        comboBoxBranch.Visible = true;

                        labelItem.Visible = true;
                        comboBoxItem.Visible = true;

                        labelItemCode.Visible = true;
                        comboBoxItemCode.Visible = true;

                        break;
                    case "Stock-In Detail Report":
                        labelStartDate.Visible = true;
                        dateTimePickerStartDate.Visible = true;

                        labelEndDate.Visible = true;
                        dateTimePickerEndDate.Visible = true;

                        labelCompany.Visible = true;
                        comboBoxCompany.Visible = true;

                        labelBranch.Visible = true;
                        comboBoxBranch.Visible = true;

                        labelItem.Visible = false;
                        comboBoxItem.Visible = false;

                        labelItemCode.Visible = false;
                        comboBoxItemCode.Visible = false;

                        break;
                    case "Stock-In Sales Return Detail Report":
                        labelStartDate.Visible = true;
                        dateTimePickerStartDate.Visible = true;

                        labelEndDate.Visible = true;
                        dateTimePickerEndDate.Visible = true;

                        labelCompany.Visible = true;
                        comboBoxCompany.Visible = true;

                        labelBranch.Visible = true;
                        comboBoxBranch.Visible = true;

                        labelItem.Visible = false;
                        comboBoxItem.Visible = false;

                        labelItemCode.Visible = false;
                        comboBoxItemCode.Visible = false;

                        break;
                    case "Stock-Out Detail Report":
                        labelStartDate.Visible = true;
                        dateTimePickerStartDate.Visible = true;

                        labelEndDate.Visible = true;
                        dateTimePickerEndDate.Visible = true;

                        labelCompany.Visible = true;
                        comboBoxCompany.Visible = true;

                        labelBranch.Visible = true;
                        comboBoxBranch.Visible = true;

                        labelItem.Visible = false;
                        comboBoxItem.Visible = false;

                        labelItemCode.Visible = false;
                        comboBoxItemCode.Visible = false;

                        break;
                    case "Stock Transfer Detail Report":
                        labelStartDate.Visible = true;
                        dateTimePickerStartDate.Visible = true;

                        labelEndDate.Visible = true;
                        dateTimePickerEndDate.Visible = true;

                        labelCompany.Visible = true;
                        comboBoxCompany.Visible = true;

                        labelBranch.Visible = true;
                        comboBoxBranch.Visible = true;

                        labelItem.Visible = false;
                        comboBoxItem.Visible = false;

                        labelItemCode.Visible = false;
                        comboBoxItemCode.Visible = false;

                        break;
                    case "Item List":
                        labelStartDate.Visible = false;
                        dateTimePickerStartDate.Visible = false;

                        labelEndDate.Visible = false;
                        dateTimePickerEndDate.Visible = false;

                        labelCompany.Visible = false;
                        comboBoxCompany.Visible = false;

                        labelBranch.Visible = false;
                        comboBoxBranch.Visible = false;

                        labelItem.Visible = false;
                        comboBoxItem.Visible = false;

                        labelItemCode.Visible = false;
                        comboBoxItemCode.Visible = false;

                        break;
                    default:
                        labelStartDate.Visible = false;
                        dateTimePickerStartDate.Visible = false;

                        labelEndDate.Visible = false;
                        dateTimePickerEndDate.Visible = false;

                        labelCompany.Visible = false;
                        comboBoxCompany.Visible = false;

                        labelBranch.Visible = false;
                        comboBoxBranch.Visible = false;

                        labelItem.Visible = false;
                        comboBoxItem.Visible = false;

                        labelItemCode.Visible = false;
                        comboBoxItemCode.Visible = false;
                        break;
                }
            }
            else
            {
                MessageBox.Show("Please select a report.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonView_OnClick(object sender, EventArgs e)
        {
            if (listBoxInventoryReport.SelectedItem != null)
            {
                DateTime startDate = dateTimePickerStartDate.Value.Date;
                DateTime endDate = dateTimePickerEndDate.Value.Date;
                Int32 companyId = Convert.ToInt32(comboBoxCompany.SelectedValue);
                String companyName = comboBoxCompany.GetItemText(comboBoxCompany.SelectedItem);
                Int32 branchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
                String branchName = comboBoxBranch.GetItemText(comboBoxBranch.SelectedItem);
                Int32 itemId = Convert.ToInt32(comboBoxItem.SelectedValue);
                String itemName = comboBoxItem.GetItemText(comboBoxItem.SelectedItem);
                String itemCode = comboBoxItem.GetItemText(comboBoxItemCode.Text);

                String selectedItem = listBoxInventoryReport.SelectedItem.ToString();
                switch (selectedItem)
                {
                    case "Inventory Report":
                        sysUserRights = new Modules.SysUserRightsModule("RepInventory");
                        if (sysUserRights.GetUserRights() == null)
                        {
                            MessageBox.Show("No rights!", "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            RepInventoryReportInventoryReportForm repInventoryReportInventoryReport = new RepInventoryReportInventoryReportForm(startDate, endDate, companyId, companyName, branchId, branchName);
                            repInventoryReportInventoryReport.Show();
                        }
                        break;
                    case "Stock Card":
                        sysUserRights = new Modules.SysUserRightsModule("RepStockCard");
                        if (sysUserRights.GetUserRights() == null)
                        {
                            MessageBox.Show("No rights!", "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            RepInventoryReportStockCardReportForm repInventoryReportStockCardReportForm = new RepInventoryReportStockCardReportForm(startDate, endDate, companyId, companyName, branchId, branchName, itemId, itemName, itemCode);
                            repInventoryReportStockCardReportForm.Show();
                        }
                        break;
                    case "Stock-In Detail Report":
                        sysUserRights = new Modules.SysUserRightsModule("RepStockInDetail");
                        if (sysUserRights.GetUserRights() == null)
                        {
                            MessageBox.Show("No rights!", "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            RepInventoryReportStockInDetailReportForm repInventoryReportStockInDetailReportForm = new RepInventoryReportStockInDetailReportForm(startDate, endDate, companyId, companyName, branchId, branchName);
                            repInventoryReportStockInDetailReportForm.Show();
                        }
                        break;
                    case "Stock-In Sales Return Detail Report":
                        sysUserRights = new Modules.SysUserRightsModule("RepStockInDetail");
                        if (sysUserRights.GetUserRights() == null)
                        {
                            MessageBox.Show("No rights!", "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            RepInventoryReportStockInSalesReturnDetailReportForm repInventoryReportStockInSalesReturnDetailReportForm = new RepInventoryReportStockInSalesReturnDetailReportForm(startDate, endDate, companyId, companyName, branchId, branchName);
                            repInventoryReportStockInSalesReturnDetailReportForm.Show();
                        }
                        break;
                    case "Stock-Out Detail Report":
                        sysUserRights = new Modules.SysUserRightsModule("RepStockOutDetail");
                        if (sysUserRights.GetUserRights() == null)
                        {
                            MessageBox.Show("No rights!", "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            RepInventoryReportStockOutDetailReportForm repInventoryReportStockOutDetailReportForm = new RepInventoryReportStockOutDetailReportForm(startDate, endDate, companyId, companyName, branchId, branchName);
                            repInventoryReportStockOutDetailReportForm.Show();
                        }
                        break;
                    case "Stock Transfer Detail Report":
                        sysUserRights = new Modules.SysUserRightsModule("RepStockTransferDetail");
                        if (sysUserRights.GetUserRights() == null)
                        {
                            MessageBox.Show("No rights!", "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            RepInventoryReportStockTransferDetailReportForm repInventoryReportStockTransferDetailReportForm = new RepInventoryReportStockTransferDetailReportForm(startDate, endDate, companyId, companyName, branchId, branchName);
                            repInventoryReportStockTransferDetailReportForm.Show();
                        }

                        break;
                    case "Item List":
                        sysUserRights = new Modules.SysUserRightsModule("RepItemList");
                        if (sysUserRights.GetUserRights() == null)
                        {
                            MessageBox.Show("No rights!", "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            RepRepInventoryReportItemListReportForm repRepInventoryReportItemListReportForm = new RepRepInventoryReportItemListReportForm();
                            repRepInventoryReportItemListReportForm.Show();
                        }
                        break;
                    default:

                        break;
                }
            }
            else
            {
                MessageBox.Show("Please select a report.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_OnClick(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }

        private void comboBoxCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBranches();
        }
    }
}
