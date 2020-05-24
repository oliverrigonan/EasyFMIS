using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.License
{
    public partial class SysLicenseForm : Form
    {
        private String lisenceCode = "";

        public SysLicenseForm()
        {
            InitializeComponent();
            getSerialNumber();

            lisenceCode = Modules.SysCurrentModule.GetCurrentSettings().LicenseCode;

            if (String.IsNullOrEmpty(lisenceCode))
            {
                MessageBox.Show("No license code.", "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                textBoxLicenseCode.Text = lisenceCode;
                License();
            }
        }

        private void getSerialNumber()
        {
            textBoxSerialNumber.Text = Modules.SysLicenseModule.GetSerialNumber();
        }


        private void buttonClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            License();
        }

        private void License()
        {
            if (Modules.SysLicenseModule.CheckLicenseCode(textBoxLicenseCode.Text) == Modules.SysLicenseModule.GetSerialNumber())
            {
                Modules.SysCurrentModule.UpdateCurrentSettingsLicenseCode(textBoxLicenseCode.Text);

                Hide();

                Forms.Account.SysLogin.SysLoginForm sysLoginForm = new Account.SysLogin.SysLoginForm();
                sysLoginForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid License Code.", "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
