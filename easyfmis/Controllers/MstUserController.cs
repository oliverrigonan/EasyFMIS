using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class MstUserController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ==========
        // List Users
        // ==========
        public List<Entities.MstUserEntity> ListUser(String filter)
        {
            var users = from d in db.MstUsers
                        where d.UserName.Contains(filter)
                        || d.FullName.Contains(filter)
                        select new Entities.MstUserEntity
                        {
                            Id = d.Id,
                            UserName = d.UserName,
                            Password = d.Password,
                            FullName = d.FullName,
                            CompanyId = d.CompanyId,
                            Company = d.MstCompany.Company,
                            BranchId = d.BranchId,
                            Branch = d.MstBranch.Branch,
                            IsLocked = d.IsLocked
                        };

            return users.OrderBy(d => d.Id).ToList();
        }

        // ===========
        // Detail User
        // ===========
        public Entities.MstUserEntity DetailUser(Int32 id)
        {
            var users = from d in db.MstUsers
                        where d.Id == id
                        select new Entities.MstUserEntity
                        {
                            Id = d.Id,
                            UserName = d.UserName,
                            Password = d.Password,
                            FullName = d.FullName,
                            CompanyId = d.CompanyId,
                            Company = d.MstCompany.Company,
                            BranchId = d.BranchId,
                            Branch = d.MstBranch.Branch,
                            IsLocked = d.IsLocked
                        };

            return users.FirstOrDefault();
        }

        // ============
        // List Company
        // ============
        public List<Entities.MstCompanyEntity> DropDownListCompany() {
            var company = from d in db.MstCompanies
                          select new Entities.MstCompanyEntity
                          {
                              Id = d.Id,
                              Company = d.Company
                          };
            return company.OrderByDescending(d => d.Id).ToList();
        }

         //===========
         //List Branch
         //===========
        public List<Entities.MstBranchEntity> DropDownListBranch(Int32 companyId)
        {
            var branches = from d in db.MstBranches
                           where d.CompanyId == companyId
                           select new Entities.MstBranchEntity
                           {
                               Id = d.Id,
                               BranchCode = d.BranchCode,
                               Branch = d.Branch,
                           };
            return branches.OrderByDescending(d=> d.Id).ToList();

        }

        // ========
        // Add User
        // ========
        public String[] AddUser()
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var company = from d in db.MstCompanies
                              select d;
                if (company.Any() == false)
                {
                    return new String[] { "Company not found", "0" };
                }

                var branch = from d in db.MstBranches
                             select d;
                if (branch.Any() == false)
                {
                    return new String[] { "Branch not found", "0" };
                }


                Data.MstUser newUser = new Data.MstUser()
                {
                    UserName = "NA",
                    Password = "NA",
                    FullName = "NA",
                    CompanyId = company.FirstOrDefault().Id,
                    BranchId = branch.FirstOrDefault().Id,
                    IsLocked = false,
                    CreatedBy = currentUserLogin.FirstOrDefault().Id,
                    CreatedDateTime = DateTime.Today,
                    UpdatedBy = currentUserLogin.FirstOrDefault().Id,
                    UpdatedDateTime = DateTime.Today
                };

                db.MstUsers.InsertOnSubmit(newUser);
                db.SubmitChanges();

                return new String[] { "", newUser.Id.ToString() };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =========
        // Lock User
        // =========
        public String[] LockUser(Int32 id, Entities.MstUserEntity objUser)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var existingUser = from d in db.MstUsers
                                   where d.UserName == objUser.UserName
                                   && d.IsLocked == true
                                   select d;

                if (existingUser.Any())
                {
                    return new String[] { "Username is already taken.", "0" };
                }

                var user = from d in db.MstUsers
                           where d.Id == id
                           select d;

                if (user.Any())
                {
                    var lockUser = user.FirstOrDefault();
                    lockUser.UserName = objUser.UserName;
                    lockUser.Password = objUser.Password;
                    lockUser.FullName = objUser.FullName;
                    lockUser.CompanyId = objUser.CompanyId;
                    lockUser.BranchId = objUser.BranchId;
                    lockUser.IsLocked = true;
                    lockUser.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    lockUser.UpdatedDateTime = DateTime.Today;
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "User not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===========
        // Unlock User
        // ===========
        public String[] UnlockUser(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var user = from d in db.MstUsers
                           where d.Id == id
                           select d;

                if (user.Any())
                {
                    var unlockUser = user.FirstOrDefault();
                    unlockUser.IsLocked = false;
                    unlockUser.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    unlockUser.UpdatedDateTime = DateTime.Today;
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "User not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===========
        // Delete User
        // ===========
        public String[] DeleteUser(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var user = from d in db.MstUsers
                           where d.Id == id
                           select d;

                if (user.Any())
                {
                    var deleteUser = user.FirstOrDefault();
                    db.MstUsers.DeleteOnSubmit(deleteUser);
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "User not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
