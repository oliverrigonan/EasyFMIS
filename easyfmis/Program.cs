using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Modules.SysLicenseModule.DecriptionKey() == Modules.SysLicenseModule.GetSerialNumber())
            {
                Application.Run(new Forms.Account.SysLogin.SysLoginForm());
                //Application.Run(new Forms.Software.SysSoftwareForm());
            }
            else
            {
                Application.Run(new Forms.Software.SysSoftwareForm());

                //Application.Run(new Forms.License.SysLicenseForm());
            }
        }
    }
}
