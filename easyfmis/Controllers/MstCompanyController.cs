using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    public class MstCompanyController
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
                                CompanyCode = d.CompanyCode,
                                Company = d.Company,
                                IsLocked = d.IsLocked
                            };
            return companies.OrderByDescending(d => d.Id).ToList();
        }

        // ==============
        // Detail Company
        // ==============
        public Entities.MstCompanyEntity DetailCompany(Int32 id)
        {
            var company = from d in db.MstCompanies
                          where d.Id == id
                          select new Entities.MstCompanyEntity
                          {
                              Id = d.Id,
                              CompanyCode = d.CompanyCode,
                              Company = d.Company,
                              IsLocked = d.IsLocked
                          };
            return company.FirstOrDefault();
        }

        // ===========
        // Add Company
        // ===========
        public String[] AddCompany()
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                Data.MstCompany newCompany = new Data.MstCompany()
                {
                    CompanyCode = "NA",
                    Company = "NA",
                    IsLocked = false,
                    CreatedBy = currentUserLogin.FirstOrDefault().Id,
                    CreatedDateTime = DateTime.Today,
                    UpdatedBy = currentUserLogin.FirstOrDefault().Id,
                    UpdatedByDateTime = DateTime.Today
                };

                db.MstCompanies.InsertOnSubmit(newCompany);
                db.SubmitChanges();

                return new String[] { "", newCompany.Id.ToString() };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ============
        // Lock Company
        // ============
        public String[] LockCompany(Entities.MstCompanyEntity objCompany)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var companyCodeCheck = from d in db.MstCompanies
                                       where d.Id != objCompany.Id
                                       && d.CompanyCode == objCompany.CompanyCode
                                       select d;
                if (companyCodeCheck.Any())
                {
                    return new String[] { "Company code already exist.", "0" };
                }

                var company = from d in db.MstCompanies
                              where d.Id == objCompany.Id
                              select d;

                if (company.Any())
                {
                    var lockCompany = company.FirstOrDefault();
                    lockCompany.CompanyCode = objCompany.CompanyCode;
                    lockCompany.Company = objCompany.Company;
                    lockCompany.IsLocked = true;
                    lockCompany.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    lockCompany.UpdatedByDateTime = DateTime.Today;
                    db.SubmitChanges();

                    return new string[] { "", "" };
                }
                else
                {
                    return new string[] { "Company not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new string[] { e.Message, "0" };
            }
        }

        // ============
        // Lock Company
        // ============
        public String[] UnlockCompany(Entities.MstCompanyEntity objCompany)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var company = from d in db.MstCompanies
                              where d.Id == objCompany.Id
                              select d;
                if (company.Any())
                {
                    var unLockCompany = company.FirstOrDefault();
                    unLockCompany.IsLocked = false;
                    unLockCompany.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    unLockCompany.UpdatedByDateTime = DateTime.Today;
                    db.SubmitChanges();

                    return new string[] { "", "" };
                }
                else
                {
                    return new string[] { "Company not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new string[] { e.Message, "0" };
            }
        }

        // ==============
        // Delete Company
        // ==============
        public String[] DeleteCompany(Int32 id)
        {
            try
            {
                var company = from d in db.MstCompanies
                              where d.Id == id
                              select d;
                if (company.Any())
                {
                    if (company.FirstOrDefault().IsLocked == false)
                    {
                        var deleteCompany = company.FirstOrDefault();
                        db.MstCompanies.DeleteOnSubmit(company.FirstOrDefault());
                        db.SubmitChanges();

                        return new string[] { "", "" };
                    }
                    else
                    {
                        return new string[] { "Company is lock.", "0" };

                    }
                }
                else
                {
                    return new string[] { "Company not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new string[] { e.Message, "0" };
            }
        }


    }
}
