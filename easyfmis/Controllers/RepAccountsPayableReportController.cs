﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class RepAccountsPayableReportController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // =============
        // Compute Aging
        // =============
        public Decimal ComputeAge(Int32 Age, Int32 Elapsed, Decimal Amount)
        {
            Decimal returnValue = 0;

            if (Age == 0)
            {
                if (Elapsed < 30)
                {
                    returnValue = Amount;
                }
            }
            else if (Age == 1)
            {
                if (Elapsed >= 30 && Elapsed < 60)
                {
                    returnValue = Amount;
                }
            }
            else if (Age == 2)
            {
                if (Elapsed >= 60 && Elapsed < 90)
                {
                    returnValue = Amount;
                }
            }
            else if (Age == 3)
            {
                if (Elapsed >= 90 && Elapsed < 120)
                {
                    returnValue = Amount;
                }
            }
            else if (Age == 4)
            {
                if (Elapsed >= 120)
                {
                    returnValue = Amount;
                }
            }
            else
            {
                returnValue = 0;
            }

            return returnValue;
        }

        // =====================
        // Dropdown List Company
        // =====================
        public List<Entities.MstCompanyEntity> DropdownListCompany()
        {
            var companies = from d in db.MstCompanies
                            select new Entities.MstCompanyEntity
                            {
                                Id = d.Id,
                                Company = d.Company
                            };

            return companies.ToList();
        }

        // ====================
        // Dropdown List Branch
        // ====================
        public List<Entities.MstBranchEntity> DropdownListBranch(Int32 companyId)
        {
            var branches = from d in db.MstBranches
                           where d.CompanyId == companyId
                           select new Entities.MstBranchEntity
                           {
                               Id = d.Id,
                               Branch = d.Branch
                           };

            return branches.ToList();
        }

        // ============================
        // Accounts Payable Report List
        // ============================
        public List<Entities.RepAccountsPayableEntity> ListAccountsPayableReport(DateTime dateAsOf, Int32 companyId, Int32 branchId)
        {
            try
            {
                var receivingReceipt = from d in db.TrnReceivingReceipts
                                       where d.RRDate <= dateAsOf
                                       && d.MstBranch.CompanyId == companyId
                                       && d.BranchId == branchId
                                       && d.BalanceAmount > 0
                                       && d.IsLocked == true
                                       select new Entities.RepAccountsPayableEntity
                                       {
                                           RRId = d.Id,
                                           Branch = d.MstBranch.Branch,
                                           RRNumber = d.RRNumber,
                                           RRDate = d.RRDate.ToShortDateString(),
                                           ManualRRNumber = d.ManualRRNumber,
                                           SupplierCode = d.MstArticle.ArticleCode,
                                           Supplier = d.MstArticle.Article,
                                           DueDate = d.RRDate.AddDays(Convert.ToInt32(d.MstTerm.NumberOfDays)).ToShortDateString(),
                                           BalanceAmount = d.BalanceAmount,
                                           CurrentAmount = ComputeAge(0, Convert.ToDateTime(dateAsOf).Subtract(d.RRDate.AddDays(Convert.ToInt32(d.MstTerm.NumberOfDays))).Days, d.BalanceAmount),
                                           Age30Amount = ComputeAge(1, Convert.ToDateTime(dateAsOf).Subtract(d.RRDate.AddDays(Convert.ToInt32(d.MstTerm.NumberOfDays))).Days, d.BalanceAmount),
                                           Age60Amount = ComputeAge(2, Convert.ToDateTime(dateAsOf).Subtract(d.RRDate.AddDays(Convert.ToInt32(d.MstTerm.NumberOfDays))).Days, d.BalanceAmount),
                                           Age90Amount = ComputeAge(3, Convert.ToDateTime(dateAsOf).Subtract(d.RRDate.AddDays(Convert.ToInt32(d.MstTerm.NumberOfDays))).Days, d.BalanceAmount),
                                           Age120Amount = ComputeAge(4, Convert.ToDateTime(dateAsOf).Subtract(d.RRDate.AddDays(Convert.ToInt32(d.MstTerm.NumberOfDays))).Days, d.BalanceAmount)
                                       };

                return receivingReceipt.ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}