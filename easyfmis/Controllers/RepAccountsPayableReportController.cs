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
        public List<Entities.RepAccountsPayableEntity> ListAccountsPayableReport(DateTime dateAsOf, Int32 companyId, Int32 branchId, String filter)
        {
            try
            {
                var receivingReceipt = from d in db.TrnReceivingReceipts
                                       where d.RRDate <= dateAsOf
                                       && d.MstBranch.CompanyId == companyId
                                       && d.BranchId == branchId
                                       && d.BalanceAmount > 0
                                       && d.IsLocked == true
                                       && (d.MstBranch.Branch.Contains(filter)
                                       || d.RRNumber.Contains(filter)
                                       || d.ManualRRNumber.Contains(filter)
                                       || d.MstArticle.ArticleCode.Contains(filter)
                                       || d.MstArticle.Article.Contains(filter)
                                       || d.BalanceAmount.ToString().Contains(filter))
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
        public List<Entities.RepAccountsPayablePurchaseOrderDetailReportEntity> ListPurchaseOrderDetailReport(DateTime filterDateStart, DateTime filterDateEnd, Int32 companyId, Int32 branchId, String filter)
        {
            try
            {
                var purchaseOrderDetailReport = from d in db.TrnPurchaseOrderItems
                                                where d.TrnPurchaseOrder.PODate >= filterDateStart
                                                && d.TrnPurchaseOrder.PODate <= filterDateEnd
                                                && d.TrnPurchaseOrder.MstBranch.CompanyId == companyId
                                                && d.TrnPurchaseOrder.BranchId == branchId
                                                && (d.TrnPurchaseOrder.MstBranch.Branch.Contains(filter)
                                                || d.TrnPurchaseOrder.PONumber.Contains(filter)
                                                || d.TrnPurchaseOrder.ManualPONumber.Contains(filter)
                                                || d.TrnPurchaseOrder.MstArticle.Article.Contains(filter)
                                                || d.TrnPurchaseOrder.MstTerm.Term.Contains(filter)
                                                || d.TrnPurchaseOrder.Remarks.Contains(filter)
                                                || d.TrnPurchaseOrder.MstUser.FullName.Contains(filter)
                                                || d.TrnPurchaseOrder.MstUser1.FullName.Contains(filter)
                                                || d.TrnPurchaseOrder.MstUser2.FullName.Contains(filter)
                                                || d.TrnPurchaseOrder.MstUser3.FullName.Contains(filter)
                                                || d.MstArticle.ArticleBarCode.Contains(filter)
                                                || d.MstArticle.Article.Contains(filter)
                                                || d.MstUnit.Unit.Contains(filter)
                                                || d.Quantity.ToString().Contains(filter)
                                                || d.Cost.ToString().Contains(filter)
                                                || d.Amount.ToString().Contains(filter)
                                                || d.BaseQuantity.ToString().Contains(filter)
                                                || d.BaseCost.ToString().Contains(filter))
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
        public List<Entities.RepAccountsPayableReceivingReceiptDetailReportEntity> ListReceivingReceiptDetailReport(DateTime filterDateStart, DateTime filterDateEnd, Int32 companyId, Int32 branchId, String filter)
        {
            try
            {
                var receivingReceiptReport = from d in db.TrnReceivingReceiptItems
                                             where d.TrnReceivingReceipt.RRDate >= filterDateStart
                                             && d.TrnReceivingReceipt.RRDate <= filterDateEnd
                                             && d.TrnReceivingReceipt.MstBranch.CompanyId == companyId
                                             && d.TrnReceivingReceipt.BranchId == branchId
                                             && (d.MstBranch.Branch.Contains(filter)
                                             || d.TrnReceivingReceipt.RRNumber.Contains(filter)
                                             || d.TrnReceivingReceipt.ManualRRNumber.Contains(filter)
                                             || d.TrnReceivingReceipt.MstArticle.Article.Contains(filter)
                                             || d.TrnReceivingReceipt.MstTerm.Term.Contains(filter)
                                             || d.TrnReceivingReceipt.Remarks.Contains(filter)
                                             || d.TrnReceivingReceipt.MstUser.FullName.Contains(filter)
                                             || d.TrnReceivingReceipt.MstUser1.FullName.Contains(filter)
                                             || d.TrnReceivingReceipt.MstUser2.FullName.Contains(filter)
                                             || d.TrnReceivingReceipt.MstUser3.FullName.Contains(filter)
                                             || d.TrnReceivingReceipt.PaidAmount.ToString().Contains(filter)
                                             || d.TrnReceivingReceipt.MemoAmount.ToString().Contains(filter)
                                             || d.TrnPurchaseOrder.PONumber.Contains(filter)
                                             || d.MstArticle.ArticleBarCode.Contains(filter)
                                             || d.MstArticle.Article.Contains(filter)
                                             || d.MstUnit.Unit.Contains(filter)
                                             || d.Quantity.ToString().Contains(filter)
                                             || d.Amount.ToString().Contains(filter)
                                             || d.MstTax.Tax.Contains(filter)
                                             || d.TaxRate.ToString().Contains(filter)
                                             || d.TaxAmount.ToString().Contains(filter)
                                             || d.BaseQuantity.ToString().Contains(filter)
                                             || d.BaseCost.ToString().Contains(filter))
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

        public List<Entities.RepAccountsPayableDisbursementDetailReportEntity> ListDisbursementDetailReport(DateTime filterDateStart, DateTime filterDateEnd, Int32 companyId, Int32 branchId, String filter)
        {
            try
            {
                var disbursementDetailReport = from d in db.TrnDisbursementLines
                                               where d.TrnDisbursement.CVDate >= filterDateStart
                                               && d.TrnDisbursement.CVDate <= filterDateEnd
                                               && d.TrnDisbursement.MstBranch.CompanyId == companyId
                                               && d.TrnDisbursement.BranchId == branchId
                                               && (d.TrnDisbursement.MstBranch.Branch.Contains(filter)
                                               || d.TrnDisbursement.CVNumber.Contains(filter)
                                               || d.TrnDisbursement.ManualCVNumber.Contains(filter)
                                               || d.TrnDisbursement.MstArticle.Article.Contains(filter)
                                               || d.TrnDisbursement.Payee.Contains(filter)
                                               || d.TrnDisbursement.MstPayType.PayType.Contains(filter)
                                               || d.TrnDisbursement.MstArticle1.Article.Contains(filter)
                                               || d.TrnDisbursement.Remarks.Contains(filter)
                                               || d.TrnDisbursement.CheckNumber.Contains(filter)
                                               || d.TrnDisbursement.IsCrossCheck.ToString().Contains(filter)
                                               || d.TrnDisbursement.IsClear.ToString().Contains(filter)
                                               || d.TrnDisbursement.MstUser.FullName.Contains(filter)
                                               || d.TrnDisbursement.MstUser1.FullName.Contains(filter)
                                               || d.TrnDisbursement.MstUser2.FullName.Contains(filter)
                                               || d.MstArticleGroup.ArticleGroup.Contains(filter)
                                               || d.TrnReceivingReceipt.RRNumber.Contains(filter)
                                               || d.Amount.ToString().Contains(filter)
                                               || d.OtherInformation.ToString().Contains(filter))
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