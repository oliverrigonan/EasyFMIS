using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class SysLoginController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // =====
        // Login
        // =====
        public String[] Login(String username, String password)
        {
            try
            {
                var currentUser = from d in db.MstUsers
                                  where d.UserName.Equals(username)
                                  && d.Password.Equals(password)
                                  select d;

                if (currentUser.Any())
                {
                    Modules.SysCurrentModule.UpdateCurrentSettingsLogin(currentUser.FirstOrDefault().Id.ToString(), currentUser.FirstOrDefault().UserName);
                    return new String[] { "", currentUser.FirstOrDefault().Id.ToString() };
                }
                else
                {
                    return new String[] { "Username or password is incorrect.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
