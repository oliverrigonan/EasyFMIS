﻿using System;
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
            if (repInventoryReportController.DropdownListCompany().Any())
            {
                comboBoxCompany.DataSource = repInventoryReportController.DropdownListCompany();
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
                if (repInventoryReportController.DropdownListBranch(companyId).Any())
                {
                    comboBoxBranch.DataSource = repInventoryReportController.DropdownListBranch(companyId);
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
            if (repInventoryReportController.DropdownListItem().Any())
            {
                comboBoxItem.DataSource = repInventoryReportController.DropdownListItem();
                comboBoxItem.ValueMember = "Id";
                comboBoxItem.DisplayMember = "Article";
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
                            RepInventoryReportStockCardReportForm repInventoryReportStockCardReportForm = new RepInventoryReportStockCardReportForm(startDate, endDate, companyId, companyName, branchId, branchName, itemId, itemName);
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
                        sysUserRights = new Modules.SysUserRightsModule("TrnStockTransfer");
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
