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
                }
            }
            else
            {

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
                        labelDateAsOf.Visible = true;
                        dateTimePickerDateAsOf.Visible = true;
                        labelCompany.Visible = true;
                        comboBoxCompany.Visible = true;
                        labelBranch.Visible = true;
                        comboBoxBranch.Visible = true;

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

        private void buttonView_OnClick(object sender, EventArgs e)
        {
            if (listBoxAccountsReceivableReport.SelectedItem != null)
            {
                DateTime dateAsOf = dateTimePickerDateAsOf.Value.Date;
                Int32 companyId = Convert.ToInt32(comboBoxCompany.SelectedValue);
                String companyName = comboBoxCompany.GetItemText(comboBoxCompany.SelectedItem);
                Int32 branchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
                String branchName = comboBoxBranch.GetItemText(comboBoxBranch.SelectedItem);

                String selectedItem = listBoxAccountsReceivableReport.SelectedItem.ToString();
                switch (selectedItem)
                {
                    case "Accounts Receivable Report":
                        RepAccountsReceivableReportAccountsReceivableReportForm repAccountsReceivableReportAccountsReceivableReportForm = new RepAccountsReceivableReportAccountsReceivableReportForm(dateAsOf, companyId, companyName, branchId, branchName);
                        repAccountsReceivableReportAccountsReceivableReportForm.ShowDialog();

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
