using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software.RepAccountsPayableReport
{
    public partial class RepAccountsPayableReportForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public RepAccountsPayableReportForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            GetCompanies();
        }

        public void GetCompanies()
        {
            Controllers.RepAccountsPayableReportController repAccountsPayableReportController = new Controllers.RepAccountsPayableReportController();
            if (repAccountsPayableReportController.DropdownListCompany().Any())
            {
                comboBoxCompany.DataSource = repAccountsPayableReportController.DropdownListCompany();
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

                Controllers.RepAccountsPayableReportController repAccountsPayableReportController = new Controllers.RepAccountsPayableReportController();
                if (repAccountsPayableReportController.DropdownListBranch(companyId).Any())
                {
                    comboBoxBranch.DataSource = repAccountsPayableReportController.DropdownListBranch(companyId);
                    comboBoxBranch.ValueMember = "Id";
                    comboBoxBranch.DisplayMember = "Branch";
                }
            }
            else
            {

            }
        }

        private void listBoxSalesReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAccountsPayableReport.SelectedItem != null)
            {
                String selectedItem = listBoxAccountsPayableReport.SelectedItem.ToString();
                switch (selectedItem)
                {
                    case "Accounts Payable Report":
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

                        break;
                    case "Purchase Order Detail Report":
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

                        break;
                    case "Receiving Receipt Detail Report":
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

                        break;
                    case "Disbursement Detail Report":
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
            if (listBoxAccountsPayableReport.SelectedItem != null)
            {
                DateTime dateAsOf = dateTimePickerDateAsOf.Value.Date;
                Int32 companyId = Convert.ToInt32(comboBoxCompany.SelectedValue);
                String companyName = comboBoxCompany.GetItemText(comboBoxCompany.SelectedItem);
                Int32 branchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
                String branchName = comboBoxBranch.GetItemText(comboBoxBranch.SelectedItem);

                String selectedItem = listBoxAccountsPayableReport.SelectedItem.ToString();
                switch (selectedItem)
                {
                    case "Accounts Payable Report":
                        RepAccountsPayableReportAccountsPayableReportForm repAccountsPayableReportAccountsPayableReportForm = new RepAccountsPayableReportAccountsPayableReportForm(dateAsOf, companyId, companyName, branchId, branchName);
                        repAccountsPayableReportAccountsPayableReportForm.ShowDialog();

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
