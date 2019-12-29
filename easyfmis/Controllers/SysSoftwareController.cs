using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class SysSoftwareController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ============
        // List Company
        // ============
        public List<Entities.MstCompanyEntity> ListCompany()
        {
            var companies = from d in db.MstCompanies
                            select new Entities.MstCompanyEntity
                            {
                                Id = d.Id,
                                Company = d.Company
                            };

            return companies.OrderByDescending(d => d.Id).ToList();
        }

        // ===========
        // List Branch
        // ===========
        public List<Entities.MstBranchEntity> ListBranch(Int32 companyId)
        {
            var branches = from d in db.MstBranches
                           where d.CompanyId == companyId
                           select new Entities.MstBranchEntity
                           {
                               Id = d.Id,
                               Branch = d.Branch,
                               CompanyId = d.CompanyId
                           };

            return branches.OrderByDescending(d => d.Id).ToList();
        }

        // ==================
        // Update User Branch
        // ==================
        public String[] UpdateUserBranch(Int32 companyId, Int32 branchId)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var updateCurrentUserBranch = currentUserLogin.FirstOrDefault();
                updateCurrentUserBranch.CompanyId = companyId;
                updateCurrentUserBranch.BranchId = branchId;
                db.SubmitChanges();

                return new String[] { "", "1" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
