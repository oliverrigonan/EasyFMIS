using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class RepAccountsReceivableReportController
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

        // ======================
        // Dropdown List Customer
        // ======================
        public List<Entities.MstArticleEntity> DropdownListCustomer()
        {
            var customers = from d in db.MstArticles
                            where d.ArticleTypeId == 2
                            && d.IsLocked == true
                            select new Entities.MstArticleEntity
                            {
                                Id = d.Id,
                                Article = d.Article
                            };

            return customers.ToList();
        }

        // ======================
        // Dropdown List Sold By
        // ======================
        public List<Entities.MstUserEntity> DropdownListSoldBy()
        {
            var users = from d in db.MstUsers
                        where d.IsLocked == true
                        select new Entities.MstUserEntity
                        {
                            Id = d.Id,
                            UserName = d.UserName
                        };

            return users.ToList();
        }

        // ===============================
        // Accounts Receivable Report List
        // ===============================
        public List<Entities.RepAccountsReceivableEntity> ListAccountsReceivableReport(DateTime dateAsOf, Int32 companyId, Int32 branchId)
        {
            try
            {
                var salesInvoice = from d in db.TrnSalesInvoices
                                   where d.SIDate <= dateAsOf
                                   && d.MstBranch.CompanyId == companyId
                                   && d.BranchId == branchId
                                   && d.BalanceAmount > 0
                                   && d.IsLocked == true
                                   select new Entities.RepAccountsReceivableEntity
                                   {
                                       SIId = d.Id,
                                       Branch = d.MstBranch.Branch,
                                       SINumber = d.SINumber,
                                       SIDate = d.SIDate.ToShortDateString(),
                                       ManualSINumber = d.ManualSINumber,
                                       CustomerCode = d.MstArticle.ArticleCode,
                                       Customer = d.MstArticle.Article,
                                       DueDate = d.SIDate.AddDays(Convert.ToInt32(d.MstTerm.NumberOfDays)).ToShortDateString(),
                                       BalanceAmount = d.BalanceAmount,
                                       CurrentAmount = ComputeAge(0, Convert.ToDateTime(dateAsOf).Subtract(d.SIDate.AddDays(Convert.ToInt32(d.MstTerm.NumberOfDays))).Days, d.BalanceAmount),
                                       Age30Amount = ComputeAge(1, Convert.ToDateTime(dateAsOf).Subtract(d.SIDate.AddDays(Convert.ToInt32(d.MstTerm.NumberOfDays))).Days, d.BalanceAmount),
                                       Age60Amount = ComputeAge(2, Convert.ToDateTime(dateAsOf).Subtract(d.SIDate.AddDays(Convert.ToInt32(d.MstTerm.NumberOfDays))).Days, d.BalanceAmount),
                                       Age90Amount = ComputeAge(3, Convert.ToDateTime(dateAsOf).Subtract(d.SIDate.AddDays(Convert.ToInt32(d.MstTerm.NumberOfDays))).Days, d.BalanceAmount),
                                       Age120Amount = ComputeAge(4, Convert.ToDateTime(dateAsOf).Subtract(d.SIDate.AddDays(Convert.ToInt32(d.MstTerm.NumberOfDays))).Days, d.BalanceAmount)
                                   };

                return salesInvoice.ToList();
            }
            catch
            {
                return null;
            }
        }

        // ================================
        // Sales Invoice Detail Report List
        // ================================
        public List<Entities.RepSalesInvoiceEntity> ListSalesInvoiceDetailReport(DateTime dateStart, DateTime dateEnd, Int32 companyId, Int32 branchId, Int32 SoldById)
        {
            try
            {
                var salesInvoiceItem = from d in db.TrnSalesInvoiceItems
                                       where d.TrnSalesInvoice.SIDate >= dateStart
                                       && d.TrnSalesInvoice.SIDate <= dateEnd
                                       && d.TrnSalesInvoice.MstBranch.CompanyId == companyId
                                       && d.TrnSalesInvoice.BranchId == branchId
                                       && d.TrnSalesInvoice.SoldBy == SoldById
                                       && d.TrnSalesInvoice.IsLocked == true
                                       select new Entities.RepSalesInvoiceEntity
                                       {
                                           SINumber = d.TrnSalesInvoice.SINumber,
                                           ItemDescription = d.MstArticle.Article,
                                           ItemInventoryCode = d.MstArticle.ArticleCode,
                                           Unit = d.MstUnit.Unit,
                                           Price = d.Price,
                                           Discount = d.MstDiscount.Discount,
                                           DiscountRate = d.DiscountRate,
                                           DiscountAmount = d.DiscountAmount,
                                           NetPrice = d.NetPrice,
                                           Quantity = d.Quantity,
                                           Amount = d.Amount,
                                           Tax = d.MstTax.Tax,
                                           TaxRate = d.TaxRate,
                                           TaxAmount = d.TaxAmount,
                                           BaseQuantity = d.BaseQuantity,
                                           BasePrice = d.BasePrice
                                       };

                return salesInvoiceItem.ToList();
            }
            catch
            {
                return null;
            }
        }

        // ==============================
        // Sales Order Detail Report List
        // ==============================
        public List<Entities.RepAccountsReceivableSalesOrderDetailReportEntity> ListSalesOrederDetailReport(DateTime dateStart, DateTime dateEnd, Int32 companyId, Int32 branchId)
        {
            try
            {
                var salesOrderItem = from d in db.TrnSalesOrderItems
                                     where d.TrnSalesOrder.SODate >= dateStart
                                     && d.TrnSalesOrder.SODate <= dateEnd
                                     && d.TrnSalesOrder.MstBranch.CompanyId == companyId
                                     && d.TrnSalesOrder.BranchId == branchId
                                     && d.TrnSalesOrder.IsLocked == true
                                     select new Entities.RepAccountsReceivableSalesOrderDetailReportEntity
                                     {
                                         Id = d.Id,
                                         Branch = d.TrnSalesOrder.MstBranch.Branch,
                                         SONumber = d.TrnSalesOrder.SONumber,
                                         SODate = d.TrnSalesOrder.SODate,
                                         ManualSONumber = d.TrnSalesOrder.ManualSONumber,
                                         Customer = d.TrnSalesOrder.MstArticle.Article,
                                         Term = d.TrnSalesOrder.MstTerm.Term,
                                         Remarks = d.TrnSalesOrder.Remarks,
                                         SoldBy = d.TrnSalesOrder.MstUser.UserName,
                                         PreparedBy = d.TrnSalesOrder.MstUser1.UserName,
                                         CheckedBy = d.TrnSalesOrder.MstUser2.UserName,
                                         ApprovedBy = d.TrnSalesOrder.MstUser3.UserName,
                                         ItemCode = d.MstArticle.ArticleBarCode,
                                         ItemDescription = d.MstArticle.Article,
                                         ItemInventoryCode = d.MstArticleInventory.InventoryCode,
                                         Unit = d.MstUnit.Unit,
                                         Price = d.Price,
                                         Discount = d.MstDiscount.Discount,
                                         DiscountRate = d.DiscountRate,
                                         DiscountAmount = d.DiscountAmount,
                                         NetPrice = d.NetPrice,
                                         Quantity = d.Quantity,
                                         Amount = d.Amount,
                                         Tax = d.MstTax.Tax,
                                         TaxRate = d.TaxRate,
                                         TaxAmount = d.TaxAmount,
                                         BaseQuantity = d.BaseQuantity,
                                         BasePrice = d.BasePrice
                                     };

                return salesOrderItem.ToList();
            }
            catch
            {
                return null;
            }
        }

        // ==============================
        // Sales Order Detail Report List
        // ==============================
        public List<Entities.RepAccountsReceivableCollectionDetailReportEntity> ListCollectionDetailReport(DateTime dateStart, DateTime dateEnd, Int32 companyId, Int32 branchId)
        {
            try
            {
                var collectionDetail = from d in db.TrnCollectionLines
                                       where d.TrnCollection.ORDate >= dateStart
                                       && d.TrnCollection.ORDate <= dateEnd
                                       && d.TrnCollection.MstBranch.CompanyId == companyId
                                       && d.TrnCollection.BranchId == branchId
                                       && d.TrnCollection.IsLocked == true
                                       select new Entities.RepAccountsReceivableCollectionDetailReportEntity
                                       {
                                           Id = d.Id,
                                           Branch = d.TrnCollection.MstBranch.Branch,
                                           ORNumber = d.TrnCollection.ORNumber,
                                           ORDate = d.TrnCollection.ORDate.ToShortDateString(),
                                           ManualORNumber = d.TrnCollection.ManualORNumber,
                                           Customer = d.TrnCollection.MstArticle.Article,
                                           Remarks = d.TrnCollection.Remarks,
                                           PreparedBy = d.TrnCollection.MstUser.FullName,
                                           CheckedBy = d.TrnCollection.MstUser1.FullName,
                                           ApprovedBy = d.TrnCollection.MstUser2.FullName,
                                           ArticleGroup = d.MstArticleGroup.ArticleGroup,
                                           SINumber = d.TrnSalesInvoice.SINumber,
                                           Amount = d.Amount,
                                           PayType = d.MstPayType.PayType,
                                           CheckNumber = d.CheckNumber,
                                           CheckDate = Convert.ToDateTime(d.CheckDate),
                                           CheckBank = d.CheckBank,
                                           CreditCardVerificationCode = d.CreditCardVerificationCode,
                                           CreditCardNumber = d.CreditCardNumber,
                                           CreditCardType = d.CreditCardType,
                                           CreditCardBank = d.CreditCardBank,
                                           CreditCardReferenceNumber = d.CreditCardReferenceNumber,
                                           CreditCardHolderName = d.CreditCardHolderName,
                                           CreditCardExpiry = d.CreditCardExpiry,
                                           GiftCertificateNumber = d.GiftCertificateNumber,
                                           OtherInformation = d.OtherInformation
                                       };

                return collectionDetail.ToList();
            }
            catch
            {
                return null;
            }
        }

        // ===========================
        // Statement of Account Report
        // ===========================
        public List<Entities.RepAccountsReceivableStatementOfAccountReportEntity> ListStatementOfAccountReport(DateTime dateAsOf, Int32 companyId, Int32 branchId, Int32 customerID)
        {
            try
            {
                var collectionDetail = from d in db.TrnSalesInvoices
                                       where d.SIDate <= dateAsOf
                                       && d.MstBranch.CompanyId == companyId
                                       && d.BranchId == branchId
                                       && d.IsLocked == true
                                       && d.BalanceAmount > 0
                                       select new Entities.RepAccountsReceivableStatementOfAccountReportEntity
                                       {
                                           Id = d.Id,
                                           Branch = d.MstBranch.Branch,
                                           SINumber = d.SINumber,
                                           SIDate = d.SIDate,
                                           ManualSINumber = d.ManualSINumber,
                                           Customer = d.MstArticle.Article,
                                           Term = d.MstTerm.Term,
                                           Amount = d.Amount,
                                           PaidAmount = d.PaidAmount,
                                           MemoAmount = d.MemoAmount,
                                           BalanceAmount = d.BalanceAmount
                                       };

                return collectionDetail.ToList();
            }
            catch
            {
                return null;
            }
        }

    }
}