using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace easyfmis.Modules
{
    class SysCurrentModule
    {
        public static String path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Settings/SysCurrent.json");

        // ====================
        // Get Current Settings 
        // ====================
        public static Entities.SysCurrentEntity GetCurrentSettings()
        {
            String json;
            using (StreamReader trmRead = new StreamReader(path)) { json = trmRead.ReadToEnd(); }

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            Entities.SysCurrentEntity sysCurrentEntity = javaScriptSerializer.Deserialize<Entities.SysCurrentEntity>(json);

            return sysCurrentEntity;
        }

        // ===============================
        // Update Current Settings - Login
        // ===============================
        public static void UpdateCurrentSettingsLogin(String currentUserId, String userName)
        {
            var currentSettings = GetCurrentSettings();

            Entities.SysCurrentEntity newEntities = new Entities.SysCurrentEntity()
            {
                CurrentUserId = currentUserId,
                CurrentUserName = userName,
                CurrentUserFullName = currentSettings.CurrentUserFullName,
                SoftwareVersion = currentSettings.SoftwareVersion,
                SoftwareDeveloper = currentSettings.SoftwareDeveloper,
                SoftwareContactSupportNumber = currentSettings.SoftwareContactSupportNumber,
                LicenseCode = currentSettings.LicenseCode,
                ItemImagePath = currentSettings.ItemImagePath,
            };

            String newJson = new JavaScriptSerializer().Serialize(newEntities);
            File.WriteAllText(path, newJson);
        }

        // ======================================
        // Update Current Settings - License Code
        // ======================================
        public static void UpdateCurrentSettingsLicenseCode(String licenseCode)
        {
            var currentSettings = GetCurrentSettings();

            currentSettings.LicenseCode = licenseCode;

            String newJson = new JavaScriptSerializer().Serialize(currentSettings);
            File.WriteAllText(path, newJson);
        }
    }
}
