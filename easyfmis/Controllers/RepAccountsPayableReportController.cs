using System;
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

        // ==========================
        // Purchase Order Report List
        // ==========================
        public List<Entities.RepAccountsPayablePurchaseOrderDetailReportEntity> ListPurchaseOrderDetailReport(DateTime filterDateStart, DateTime filterDateEnd, Int32 companyId, Int32 branchId)
        {
            try
            {
                var purchaseOrderDetailReport = from d in db.TrnPurchaseOrderItems
                                                where d.TrnPurchaseOrder.PODate >= filterDateStart
                                                && d.TrnPurchaseOrder.PODate <= filterDateEnd
                                                && d.TrnPurchaseOrder.MstBranch.CompanyId == companyId
                                                && d.TrnPurchaseOrder.BranchId == branchId
                                                select new Entities.RepAccountsPayablePurchaseOrderDetailReportEntity
                                                {
                                                    Id = d.Id,
                                                    Branch = d.TrnPurchaseOrder.MstBranch.Branch,
                                                    PONumber = d.TrnPurchaseOrder.PONumber,
                                                    PODate = d.TrnPurchaseOrder.PODate,
                                                    ManualPONumber = d.TrnPurchaseOrder.ManualPONumber,
                                                    Supplier = d.TrnPurchaseOrder.MstArticle.Article,
                                                    Term = d.TrnPurchaseOrder.MstTerm.Term,
                                                    DateNeeded = d.TrnPurchaseOrder.DateNeeded,
                                                    Remarks = d.TrnPurchaseOrder.Remarks,
                                                    IsClose = d.TrnPurchaseOrder.IsClose,
                                                    RequestedBy = d.TrnPurchaseOrder.MstUser.FullName,
                                                    PreparedBy = d.TrnPurchaseOrder.MstUser1.FullName,
                                                    CheckedBy = d.TrnPurchaseOrder.MstUser2.FullName,
                                                    ApprovedBy = d.TrnPurchaseOrder.MstUser3.FullName,
                                                    ItemCode = d.MstArticle.ArticleBarCode,
                                                    ItemDescription = d.MstArticle.Article,
                                                    Unit = d.MstUnit.Unit,
                                                    Quantity = d.Quantity,
                                                    Cost = d.Cost,
                                                    Amount = d.Amount,
                                                    BaseQuantity = d.BaseQuantity,
                                                    BaseCost = d.BaseCost,
                                                };

                return purchaseOrderDetailReport.OrderByDescending(d => d.Id).ToList();
            }
            catch
            {
                return null;
            }
        }

        // ==========================
        // Purchase Order Report List
        // ==========================
        public List<Entities.RepAccountsPayableReceivingReceiptDetailReportEntity> ListReceivingReceiptDetailReport(DateTime filterDateStart, DateTime filterDateEnd, Int32 companyId, Int32 branchId)
        {
            try
            {
                var receivingReceiptReport = from d in db.TrnReceivingReceiptItems
                                             where d.TrnReceivingReceipt.RRDate >= filterDateStart
                                             && d.TrnReceivingReceipt.RRDate <= filterDateEnd
                                             && d.TrnReceivingReceipt.MstBranch.CompanyId == companyId
                                             && d.TrnReceivingReceipt.BranchId == branchId
                                             select new Entities.RepAccountsPayableReceivingReceiptDetailReportEntity
                                             {
                                                 Id = d.Id,
                                                 Branch = d.MstBranch.Branch,
                                                 RRNumber = d.TrnReceivingReceipt.RRNumber,
                                                 RRDate = d.TrnReceivingReceipt.RRDate,
                                                 ManualRRNumber = d.TrnReceivingReceipt.ManualRRNumber,
                                                 Supplier = d.TrnReceivingReceipt.MstArticle.Article,
                                                 Term = d.TrnReceivingReceipt.MstTerm.Term,
                                                 Remarks = d.TrnReceivingReceipt.Remarks,
                                                 ReceivedBy = d.TrnReceivingReceipt.MstUser.FullName,
                                                 PreparedBy = d.TrnReceivingReceipt.MstUser1.FullName,
                                                 CheckedBy = d.TrnReceivingReceipt.MstUser2.FullName,
                                                 ApprovedBy = d.TrnReceivingReceipt.MstUser3.FullName,
                                                 IsLocked = d.TrnReceivingReceipt.IsLocked,
                                                 PaidAmount = d.TrnReceivingReceipt.PaidAmount,
                                                 MemoAmount = d.TrnReceivingReceipt.MemoAmount,
                                                 PONumber = d.TrnPurchaseOrder.PONumber,
                                                 ItemCode = d.MstArticle.ArticleBarCode,
                                                 ItemDescription = d.MstArticle.Article,
                                                 Unit = d.MstUnit.Unit,
                                                 Quantity = d.Quantity,
                                                 Cost = d.Cost,
                                                 Amount = d.Amount,
                                                 Tax = d.MstTax.Tax,
                                                 TaxRate = d.TaxRate,
                                                 TaxAmount = d.TaxAmount,
                                                 BaseQuantity = d.BaseQuantity,
                                                 BaseCost = d.BaseCost
                                             };

                return receivingReceiptReport.OrderByDescending(d => d.Id).ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<Entities.RepAccountsPayableDisbursementDetailReportEntity> ListDisbursementDetailReport(DateTime filterDateStart, DateTime filterDateEnd, Int32 companyId, Int32 branchId)
        {
            try
            {
                var disbursementDetailReport = from d in db.TrnDisbursementLines
                                             where d.TrnDisbursement.CVDate >= filterDateStart
                                             && d.TrnDisbursement.CVDate <= filterDateEnd
                                             && d.TrnDisbursement.MstBranch.CompanyId == companyId
                                             && d.TrnDisbursement.BranchId == branchId
                                             select new Entities.RepAccountsPayableDisbursementDetailReportEntity
                                             {
                                                 Id = d.Id,
                                                 Branch = d.TrnDisbursement.MstBranch.Branch,
                                                 CVNumber = d.TrnDisbursement.CVNumber,
                                                 CVDate = d.TrnDisbursement.CVDate.ToShortDateString(),
                                                 ManualCVNumber = d.TrnDisbursement.ManualCVNumber,
                                                 Supplier = d.TrnDisbursement.MstArticle.Article,
                                                 Payee = d.TrnDisbursement.Payee,
                                                 PayType = d.TrnDisbursement.MstPayType.PayType,
                                                 Bank = d.TrnDisbursement.MstArticle1.Article,
                                                 Remarks = d.TrnDisbursement.Remarks,
                                                 CheckNumber = d.TrnDisbursement.CheckNumber,
                                                 CheckDate = d.TrnDisbursement.CheckDate.Value.ToShortDateString(),
                                                 IsCrossCheck = d.TrnDisbursement.IsCrossCheck,
                                                 IsClear = d.TrnDisbursement.IsClear,
                                                 PreparedBy = d.TrnDisbursement.MstUser.FullName,
                                                 CheckedBy = d.TrnDisbursement.MstUser1.FullName,
                                                 ApprovedBy = d.TrnDisbursement.MstUser2.FullName,
                                                 ArticleGroup = d.MstArticleGroup.ArticleGroup,
                                                 RRNumber = d.TrnReceivingReceipt.RRNumber,
                                                 Amount = d.Amount,
                                                 Particulars = d.OtherInformation
                                             };

                return disbursementDetailReport.OrderByDescending(d => d.Id).ToList();
            }
            catch
            {
                return null;
            }
        }


    }
}