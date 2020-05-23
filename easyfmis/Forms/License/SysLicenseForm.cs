using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.License
{
    public partial class SysLicenseForm : Form
    {
        Forms.Account.SysLogin.SysLoginForm sysLoginForm;
        private String serialNumber = "";
        private String decryptedKey = "";
        private String lisenceCode = "";

        public SysLicenseForm()
        {
            InitializeComponent();
            getSerialNumber();

            lisenceCode = Modules.SysCurrentModule.GetCurrentSettings().LicenseCode;
            if (String.IsNullOrEmpty(lisenceCode))
            {
                MessageBox.Show("No Serial Number!", "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DecriptionKey();
                if (serialNumber == decryptedKey)
                {
                    //sysLoginForm = new Forms.Account.SysLogin.SysLoginForm();
                    //sysLoginForm.Show();
                }
            }
        }

        private void getSerialNumber()
        {
            try
            {
                string diskLetter = "C";
                ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + diskLetter + ":\"");
                disk.Get();
                textBoxSerialNumber.Text = disk["VolumeSerialNumber"].ToString();
                serialNumber = textBoxSerialNumber.Text;
            }
            catch
            {
                MessageBox.Show("Error drive.");
            }
        }

        private void DecriptionKey()
        {
            try
            {
                string EncryptionKey = "EasyPOS 2020";
                byte[] cipherBytes = Convert.FromBase64String(lisenceCode);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        decryptedKey = Encoding.Unicode.GetString(ms.ToArray());

                    }
                }
            }
            catch
            {
                MessageBox.Show("Invalid license.");
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
