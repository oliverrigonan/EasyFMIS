using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class MstBranchController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ============
        // List Branch
        // ============
        public List<Entities.MstBranchEntity> ListBranch(Int32 companyId)
        {
            var branches = from d in db.MstBranches
                           where d.CompanyId == companyId
                           select new Entities.MstBranchEntity
                           {
                               Id = d.Id,
                               BranchCode = d.BranchCode,
                               Branch = d.Branch,
                               CompanyId = d.CompanyId
                           };
            return branches.OrderByDescending(d => d.Id).ToList();
        }

        // ==============
        // Detail Branch
        // ==============
        public Entities.MstBranchEntity DetailBranch(Int32 id)
        {
            var branch = from d in db.MstBranches
                         where d.Id == id
                         select new Entities.MstBranchEntity
                         {
                             Id = d.Id,
                             BranchCode = d.BranchCode,
                             Branch = d.Branch,
                         };

            return branch.FirstOrDefault();
        }

        // ===========
        // Add Branch
        // ===========
        public String[] AddBranch(Entities.MstBranchEntity objBranch)
        {
            try
            {
                var branchCodeCheck = from d in db.MstBranches
                                      where d.CompanyId == objBranch.CompanyId
                                      && d.BranchCode == objBranch.BranchCode
                                      select d;
                if (branchCodeCheck.Any())
                {
                    return new String[] { "Branch code already exist.", "0" };
                }

                Data.MstBranch newBranch = new Data.MstBranch()
                {
                    BranchCode = objBranch.BranchCode,
                    Branch = objBranch.Branch,
                    CompanyId = objBranch.CompanyId
                };

                db.MstBranches.InsertOnSubmit(newBranch);
                db.SubmitChanges();

                return new String[] { "", "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ============
        // Lock Branch
        // ============
        public String[] UpdateBranch(Entities.MstBranchEntity objBranch)
        {
            try
            {
                var branchCodeCheck = from d in db.MstBranches
                                      where d.CompanyId == objBranch.CompanyId
                                      && d.BranchCode == objBranch.BranchCode
                                      && d.Id != objBranch.Id
                                      select d;
                if (branchCodeCheck.Any())
                {
                    return new String[] { "Branch code has duplicate.", "0" };
                }
                else
                {
                    var branch = from d in db.MstBranches
                                 where d.Id == objBranch.Id
                                 select d;
                    if (branch.Any())
                    {
                        var lockBranch = branch.FirstOrDefault();
                        lockBranch.BranchCode = objBranch.BranchCode;
                        lockBranch.Branch = objBranch.Branch;
                        db.SubmitChanges();

                        return new string[] { "", "" };
                    }
                    else
                    {
                        return new string[] { "Branch not found.", "0" };
                    }
                }
            }
            catch (Exception e)
            {
                return new string[] { e.Message, "0" };
            }
        }

        // ==============
        // Delete Branch
        // ==============
        public String[] DeleteBranch(Int32 id)
        {
            try
            {
                var branch = from d in db.MstBranches
                             where d.Id == id
                             select d;
                if (branch.Any())
                {

                    var deleteBranch = branch.FirstOrDefault();
                    db.MstBranches.DeleteOnSubmit(branch.FirstOrDefault());
                    db.SubmitChanges();

                    return new string[] { "", "" };

                }
                else
                {
                    return new string[] { "Branch not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new string[] { e.Message, "0" };
            }
        }
    }
}
