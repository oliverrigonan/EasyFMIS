using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Management;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace easyfmis.Modules
{
    public class SysLicenseModule
    {
        public static String getSerialNumber()
        {
            try
            {
                string serialNumber;
                string diskLetter = "C";
                ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + diskLetter + ":\"");
                disk.Get();
                serialNumber = disk["VolumeSerialNumber"].ToString();
                return serialNumber;
            }
            catch
            {
                return "Error drive.";
            }
        }

        public static String DecriptionKey()
        {
            try{
                String EncryptionKey = "EasyPOS 2020";
                string lisenceCode = Modules.SysCurrentModule.GetCurrentSettings().LicenseCode;

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
                        return Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch{
                return "Invalid license.";
            }
        }
    }
}
