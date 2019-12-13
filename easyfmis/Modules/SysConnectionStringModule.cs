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
    class SysConnectionStringModule
    {
        // =====================
        // Get Connection String 
        // =====================
        public static String GetConnectionString()
        {
            String path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Settings/SysConnectionString.json");

            String json;
            using (StreamReader trmRead = new StreamReader(path)) { json = trmRead.ReadToEnd(); }

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            Entities.SysConnectionStringEntity sysConnectionStringEntity = javaScriptSerializer.Deserialize<Entities.SysConnectionStringEntity>(json);

            String connectionString = "Data Source=" + sysConnectionStringEntity.DataSource
                + ";Initial Catalog=" + sysConnectionStringEntity.InitialCatalog
                + ";Persist Security Info=True;User ID=" + sysConnectionStringEntity.UserId
                + ";Password=" + sysConnectionStringEntity.Password;

            return connectionString;
        }
    }
}
