using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Modules
{
    class SysUserRightsModule
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ================
        // List User Rights
        // ================
        public Entities.SysUserRightsEntity sysUserRightsEntity { get; set; }

        // ==========
        // Contructor
        // ==========
        public SysUserRightsModule(String formName)
        {
            var currentUserLogin = from d in db.MstUsers
                                   where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId)
                                   select d;

            if (currentUserLogin.Any())
            {
                var userForms = from d in db.MstUserForms
                                where d.UserId == currentUserLogin.FirstOrDefault().Id
                                && d.SysForm.Form.Equals(formName)
                                select new Entities.SysUserRightsEntity
                                {
                                    CanDelete = d.CanDelete,
                                    CanAdd = d.CanAdd,
                                    CanLock = d.CanLock,
                                    CanUnlock = d.CanUnlock,
                                    CanPrint = d.CanPrint,
                                    CanPreview = d.CanPreview,
                                    CanEdit = d.CanEdit,
                                };

                if (userForms.Any())
                {
                    sysUserRightsEntity = userForms.FirstOrDefault();
                }
            }
        }

        // ===============
        // Get User Rights
        // ===============
        public Entities.SysUserRightsEntity GetUserRights()
        {
            return sysUserRightsEntity;
        }
    }
}
