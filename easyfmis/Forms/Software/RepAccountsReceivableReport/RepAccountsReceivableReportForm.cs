using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software.RepAccountsReceivableReport
{
    public partial class RepAccountsReceivableReportForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public RepAccountsReceivableReportForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            GetCompanies();
        }

        public void GetCompanies()
        {
            Controllers.RepAccountsReceivableReportController repAccountsReceivableReportController = new Controllers.RepAccountsReceivableReportController();
            if (repAccountsReceivableReportController.DropdownListCompany().Any())
            {
                comboBoxCompany.DataSource = repAccountsReceivableReportController.DropdownListCompany();
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

                Controllers.RepAccountsReceivableReportController repAccountsReceivableReportController = new Controllers.RepAccountsReceivableReportController();
                if (repAccountsReceivableReportController.DropdownListBranch(companyId).Any())
                {
                    comboBoxBranch.DataSource = repAccountsReceivableReportController.DropdownListBranch(companyId);
                    comboBoxBranch.ValueMember = "Id";
                    comboBoxBranch.DisplayMember = "Branch";

                    GetCustomers();
                }
            }
            else
            {

            }
        }

        public void GetCustomers()
        {
            Controllers.RepAccountsReceivableReportController repAccountsReceivableReportController = new Controllers.RepAccountsReceivableReportController();
            if (repAccountsReceivableReportController.DropdownListCustomer().Any())
            {
                comboBoxCustomer.DataSource = repAccountsReceivableReportController.DropdownListCustomer();
                comboBoxCustomer.ValueMember = "Id";
                comboBoxCustomer.DisplayMember = "Article";
            }
        }

        public void GetSoldBy()
        {
            Controllers.RepAccountsReceivableReportController repAccountsReceivableReportController = new Controllers.RepAccountsReceivableReportController();
            if (repAccountsReceivableReportController.DropdownListCustomer().Any())
            {
                comboBoxCustomer.DataSource = repAccountsReceivableReportController.DropdownListCustomer();
                comboBoxCustomer.ValueMember = "Id";
                comboBoxCustomer.DisplayMember = "Article";
            }
        }

        private void listBoxSalesReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAccountsReceivableReport.SelectedItem != null)
            {
                String selectedItem = listBoxAccountsReceivableReport.SelectedItem.ToString();
                switch (selectedItem)
                {
                    case "Accounts Receivable Report":
                        labelStartDate.Visible = false;
                        dateTimePickerStartDate.Visible = false;

                        labelEndDate.Visible = false;
                        dateTimePickerEndDate.Visible = false;

                        labelDateAsOf.Visible = true;
                        dateTimePickerDateAsOf.Visible = true;

                        labelCompany.Visible = true;
                        comboBoxCompany.Visible = true;

                        labelBranch.Visible = true;
                        comboBoxBranch.Visible = true;

                        labelCustomer.Visible = false;
                        comboBoxCustomer.Visible = false;

                        break;
                    case "Statement of Account":
                        labelStartDate.Visible = true;
                        dateTimePickerStartDate.Visible = true;

                        labelEndDate.Visible = true;
                        dateTimePickerEndDate.Visible = true;

                        labelDateAsOf.Visible = false;
                        dateTimePickerDateAsOf.Visible = false;

                        labelCompany.Visible = true;
                        comboBoxCompany.Visible = true;

                        labelBranch.Visible = true;
                        comboBoxBranch.Visible = true;

                        labelCustomer.Visible = true;
                        comboBoxCustomer.Visible = true;

                        break;
                    case "Sales Order Detail Report":
                        labelStartDate.Visible = true;
                        dateTimePickerStartDate.Visible = true;

                        labelEndDate.Visible = true;
                        dateTimePickerEndDate.Visible = true;

                        labelDateAsOf.Visible = false;
                        dateTimePickerDateAsOf.Visible = false;

                        labelCompany.Visible = true;
                        comboBoxCompany.Visible = true;

                        labelBranch.Visible = true;
                        comboBoxBranch.Visible = true;

                        labelCustomer.Visible = false;
                        comboBoxCustomer.Visible = false;

                        break;
                    case "Sales Invoice Detail Report":
                        labelStartDate.Visible = true;
                        dateTimePickerStartDate.Visible = true;

                        labelEndDate.Visible = true;
                        dateTimePickerEndDate.Visible = true;

                        labelDateAsOf.Visible = false;
                        dateTimePickerDateAsOf.Visible = false;

                        labelCompany.Visible = true;
                        comboBoxCompany.Visible = true;

                        labelBranch.Visible = true;
                        comboBoxBranch.Visible = true;

                        labelCustomer.Visible = false;
                        comboBoxCustomer.Visible = false;

                        labelSoldBy.Visible = false;
                        comboBoxSoldBy.Visible = false;
                        

                        break;
                    case "Collection Detail Report":
                        labelStartDate.Visible = true;
                        dateTimePickerStartDate.Visible = true;

                        labelEndDate.Visible = true;
                        dateTimePickerEndDate.Visible = true;

                        labelDateAsOf.Visible = false;
                        dateTimePickerDateAsOf.Visible = false;

                        labelCompany.Visible = true;
                        comboBoxCompany.Visible = true;

                        labelBranch.Visible = true;
                        comboBoxBranch.Visible = true;

                        labelCustomer.Visible = false;
                        comboBoxCustomer.Visible = false;

                        break;
                    default:
                        labelStartDate.Visible = false;
                        dateTimePickerStartDate.Visible = false;

                        labelEndDate.Visible = false;
                        dateTimePickerEndDate.Visible = false;

                        labelDateAsOf.Visible = false;
                        dateTimePickerDateAsOf.Visible = false;

                        labelCompany.Visible = false;
                        comboBoxCompany.Visible = false;

                        labelBranch.Visible = false;
                        comboBoxBranch.Visible = false;

                        labelCustomer.Visible = false;
                        comboBoxCustomer.Visible = false;

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
            if (listBoxAccountsReceivableReport.SelectedItem != null)
            {
                DateTime dateStart = dateTimePickerStartDate.Value.Date;
                DateTime dateEnd = dateTimePickerEndDate.Value.Date;

                DateTime dateAsOf = dateTimePickerDateAsOf.Value.Date;
                Int32 companyId = Convert.ToInt32(comboBoxCompany.SelectedValue);
                String companyName = comboBoxCompany.GetItemText(comboBoxCompany.SelectedItem);
                Int32 branchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
                String branchName = comboBoxBranch.GetItemText(comboBoxBranch.SelectedItem);
                Int32 soldById = Convert.ToInt32(comboBoxSoldBy.SelectedValue);
                String soldBy = comboBoxBranch.GetItemText(comboBoxSoldBy.SelectedItem);

                String selectedItem = listBoxAccountsReceivableReport.SelectedItem.ToString();
                switch (selectedItem)
                {
                    case "Accounts Receivable Report":
                        RepAccountsReceivableReportAccountsReceivableReportForm repAccountsReceivableReportAccountsReceivableReportForm = new RepAccountsReceivableReportAccountsReceivableReportForm(dateAsOf, companyId, companyName, branchId, branchName);
                        repAccountsReceivableReportAccountsReceivableReportForm.ShowDialog();

                        break;
                    case "Sales Invoice Detail Report":
                        RepbuttonSalesReportBySalesPersonReportSalesReportBySalesPersonForm repbuttonSalesReportBySalesPersonReportSalesReportBySalesPersonForm = new RepbuttonSalesReportBySalesPersonReportSalesReportBySalesPersonForm(dateStart, dateEnd, companyId, companyName, branchId, branchName, soldById, soldBy);
                        repbuttonSalesReportBySalesPersonReportSalesReportBySalesPersonForm.ShowDialog();
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
