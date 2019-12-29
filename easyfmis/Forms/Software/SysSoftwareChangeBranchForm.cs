using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software
{
    public partial class SysSoftwareChangeBranchForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public SysSoftwareChangeBranchForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            DropdownCompany();
        }

        public void DropdownCompany()
        {
            Controllers.SysSoftwareController sysSoftwareController = new Controllers.SysSoftwareController();
            var companies = sysSoftwareController.ListCompany();
            if (companies.Any())
            {
                comboBoxCompany.DataSource = companies;
                comboBoxCompany.DisplayMember = "Company";
                comboBoxCompany.ValueMember = "Id";

                DropdownBranch(Convert.ToInt32(comboBoxCompany.SelectedValue));
            }
        }

        public void DropdownBranch(Int32 companyId)
        {
            Controllers.SysSoftwareController sysSoftwareController = new Controllers.SysSoftwareController();
            var branches = sysSoftwareController.ListBranch(companyId);
            if (branches.Any())
            {
                comboBoxBranch.DataSource = branches;
                comboBoxBranch.DisplayMember = "Branch";
                comboBoxBranch.ValueMember = "Id";
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Int32 companyId = Convert.ToInt32(comboBoxCompany.SelectedValue);
            Int32 branchId = Convert.ToInt32(comboBoxBranch.SelectedValue);

            Controllers.SysSoftwareController sysSoftwareController = new Controllers.SysSoftwareController();

            String[] updateUserBranch = sysSoftwareController.UpdateUserBranch(companyId, branchId);
            if (updateUserBranch[1].Equals("0") == false)
            {
                sysSoftwareForm.GetUserDetail();
                sysSoftwareForm.ClearTabPages();
                Close();
            }
            else
            {
                MessageBox.Show(updateUserBranch[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 companyId = Convert.ToInt32(comboBoxCompany.SelectedValue);
            DropdownBranch(companyId);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
