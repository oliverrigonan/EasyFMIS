using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class TrnSalesInvoiceController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ===================
        // Fill Leading Zeroes
        // ===================
        public String FillLeadingZeroes(Int32 number, Int32 length)
        {
            var result = number.ToString();
            var pad = length - result.Length;
            while (pad > 0)
            {
                result = '0' + result;
                pad--;
            }

            return result;
        }

        // ==================
        // List Sales Invoice
        // ==================
        public List<Entities.TrnSalesInvoiceEntity> ListSalesInvoice(DateTime startDateFilter, DateTime endDateFilter, String filter)
        {
            var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
            var currentBranchId = currentUserLogin.FirstOrDefault().BranchId;

            var salesInvoices = from d in db.TrnSalesInvoices
                                where d.SIDate >= startDateFilter
                                && d.SIDate >= endDateFilter
                                && d.BranchId == currentBranchId
                                && (d.SINumber.Contains(filter)
                                || d.ManualSINumber.Contains(filter)
                                || d.MstArticle.Article.Contains(filter)
                                || d.Remarks.Contains(filter))
                                select new Entities.TrnSalesInvoiceEntity
                                {
                                    Id = d.Id,
                                    BranchId = d.BranchId,
                                    Branch = d.MstBranch.Branch,
                                    SINumber = d.SINumber,
                                    SIDate = d.SIDate,
                                    ManualSINumber = d.ManualSINumber,
                                    CustomerId = d.CustomerId,
                                    Customer = d.MstArticle.Article,
                                    TermId = d.TermId,
                                    Remarks = d.Remarks,
                                    SoldBy = d.SoldBy,
                                    PreparedBy = d.PreparedBy,
                                    CheckedBy = d.CheckedBy,
                                    ApprovedBy = d.ApprovedBy,
                                    IsLocked = d.IsLocked,
                                    Amount = d.Amount,
                                    PaidAmount = d.PaidAmount,
                                    MemoAmount = d.MemoAmount,
                                    BalanceAmount = d.BalanceAmount,
                                    CreatedBy = d.CreatedBy,
                                    CreatedDateTime = d.CreatedDateTime,
                                    CreatedByUserName = d.MstUser3.UserName,
                                    UpdatedBy = d.UpdatedBy,
                                    UpdatedDateTime = d.UpdatedDateTime,
                                    UpdatedByUserName = d.MstUser4.UserName
                                };

            return salesInvoices.OrderByDescending(d => d.Id).ToList();
        }

        // ====================
        // Detail Sales Invoice
        // ====================
        public Entities.TrnSalesInvoiceEntity DetailSalesInvoice(Int32 id)
        {
            var salesInvoice = from d in db.TrnSalesInvoices
                               where d.Id == id
                               select new Entities.TrnSalesInvoiceEntity
                               {
                                   Id = d.Id,
                                   BranchId = d.BranchId,
                                   Branch = d.MstBranch.Branch,
                                   SINumber = d.SINumber,
                                   SIDate = d.SIDate,
                                   ManualSINumber = d.ManualSINumber,
                                   SOId = d.SOId,
                                   SONumber = d.TrnSalesOrder.SONumber,
                                   CustomerId = d.CustomerId,
                                   Customer = d.MstArticle.Article,
                                   TermId = d.TermId,
                                   Remarks = d.Remarks,
                                   SoldBy = d.SoldBy,
                                   PreparedBy = d.PreparedBy,
                                   CheckedBy = d.CheckedBy,
                                   ApprovedBy = d.ApprovedBy,
                                   IsLocked = d.IsLocked,
                                   Amount = d.Amount,
                                   PaidAmount = d.PaidAmount,
                                   MemoAmount = d.MemoAmount,
                                   BalanceAmount = d.BalanceAmount,
                                   CreatedBy = d.CreatedBy,
                                   CreatedDateTime = d.CreatedDateTime,
                                   CreatedByUserName = d.MstUser3.UserName,
                                   UpdatedBy = d.UpdatedBy,
                                   UpdatedDateTime = d.UpdatedDateTime,
                                   UpdatedByUserName = d.MstUser4.UserName
                               };

            return salesInvoice.FirstOrDefault();
        }

        // ========================
        // Dropdown List - Customer
        // ========================
        public List<Entities.MstArticleEntity> DropdownListSalesInvoiceCustomer()
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

        // ====================
        // Dropdown List - Term
        // ====================
        public List<Entities.MstTermEntity> DropdownListSalesInvoiceTerm()
        {
            var terms = from d in db.MstTerms
                        select new Entities.MstTermEntity
                        {
                            Id = d.Id,
                            Term = d.Term
                        };

            return terms.ToList();
        }

        // ====================
        // Dropdown List - User
        // ====================
        public List<Entities.MstUserEntity> DropdownListSalesInvoiceUser()
        {
            var users = from d in db.MstUsers
                        select new Entities.MstUserEntity
                        {
                            Id = d.Id,
                            FullName = d.FullName
                        };

            return users.ToList();
        }

        // =================
        // Add Sales Invoice
        // =================
        public String[] AddSalesInvoice()
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var customer = from d in db.MstArticles
                               where d.ArticleTypeId == 2
                               && d.IsLocked == true
                               select d;

                if (customer.Any() == false)
                {
                    return new String[] { "Customer not found.", "0" };
                }

                var term = from d in db.MstTerms
                           select d;

                if (term.Any() == false)
                {
                    return new String[] { "Term not found.", "0" };
                }

                var currentBranchId = currentUserLogin.FirstOrDefault().BranchId;

                String salesInvoiceNumber = "0000000001";
                var lastSalesInvoice = from d in db.TrnSalesInvoices.OrderByDescending(d => d.Id)
                                       where d.BranchId == currentBranchId
                                       select d;

                if (lastSalesInvoice.Any())
                {
                    Int32 newSINumber = Convert.ToInt32(lastSalesInvoice.FirstOrDefault().SINumber) + 1;
                    salesInvoiceNumber = FillLeadingZeroes(newSINumber, 10);
                }

                Data.TrnSalesInvoice newSalesInvoice = new Data.TrnSalesInvoice()
                {
                    BranchId = currentUserLogin.FirstOrDefault().BranchId,
                    SIDate = DateTime.Today,
                    SINumber = salesInvoiceNumber,
                    ManualSINumber = salesInvoiceNumber,
                    CustomerId = customer.FirstOrDefault().Id,
                    TermId = term.FirstOrDefault().Id,
                    Remarks = "",
                    SoldBy = currentUserLogin.FirstOrDefault().Id,
                    PreparedBy = currentUserLogin.FirstOrDefault().Id,
                    CheckedBy = currentUserLogin.FirstOrDefault().Id,
                    ApprovedBy = currentUserLogin.FirstOrDefault().Id,
                    IsLocked = false,
                    Amount = 0,
                    PaidAmount = 0,
                    MemoAmount = 0,
                    BalanceAmount = 0,
                    CreatedBy = currentUserLogin.FirstOrDefault().Id,
                    CreatedDateTime = DateTime.Now,
                    UpdatedBy = currentUserLogin.FirstOrDefault().Id,
                    UpdatedDateTime = DateTime.Now
                };

                db.TrnSalesInvoices.InsertOnSubmit(newSalesInvoice);
                db.SubmitChanges();

                return new String[] { "", newSalesInvoice.Id.ToString() };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ==================
        // Lock Sales Invoice
        // ==================
        public String[] LockSalesInvoice(Int32 id, Entities.TrnSalesInvoiceEntity objSalesInvoice)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                if (objSalesInvoice.SOId != null)
                {
                    var salesOrder = from d in db.TrnSalesOrders
                                     where d.Id == objSalesInvoice.SOId
                                     && d.IsLocked == true
                                     select d;

                    if (salesOrder.Any() == false)
                    {
                        return new String[] { "Sales Order not found.", "0" };
                    }
                }

                var customer = from d in db.MstArticles
                               where d.Id == objSalesInvoice.CustomerId
                               && d.ArticleTypeId == 2
                               && d.IsLocked == true
                               select d;

                if (customer.Any() == false)
                {
                    return new String[] { "Customer not found.", "0" };
                }

                var term = from d in db.MstTerms
                           where d.Id == objSalesInvoice.TermId
                           select d;

                if (term.Any() == false)
                {
                    return new String[] { "Term not found.", "0" };
                }

                var checkedByUser = from d in db.MstUsers
                                    where d.Id == objSalesInvoice.CheckedBy
                                    && d.IsLocked == true
                                    select d;

                if (checkedByUser.Any() == false)
                {
                    return new String[] { "Checked by user not found.", "0" };
                }

                var approvedByUser = from d in db.MstUsers
                                     where d.Id == objSalesInvoice.ApprovedBy
                                     && d.IsLocked == true
                                     select d;

                if (approvedByUser.Any() == false)
                {
                    return new String[] { "Approved by user not found.", "0" };
                }

                var salesInvoice = from d in db.TrnSalesInvoices
                                   where d.Id == id
                                   select d;

                if (salesInvoice.Any())
                {
                    if (salesInvoice.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Already locked.", "0" };
                    }

                    Decimal amount = 0;
                    var salesInvoiceItems = from d in db.TrnSalesInvoiceItems
                                            where d.SIId == id
                                            select d;

                    if (salesInvoiceItems.Any())
                    {
                        amount = salesInvoiceItems.Sum(d => d.Amount);
                    }

                    var lockSalesInvoice = salesInvoice.FirstOrDefault();
                    lockSalesInvoice.SIDate = Convert.ToDateTime(objSalesInvoice.SIDate);
                    lockSalesInvoice.ManualSINumber = objSalesInvoice.ManualSINumber;
                    lockSalesInvoice.SOId = objSalesInvoice.SOId;
                    lockSalesInvoice.CustomerId = objSalesInvoice.CustomerId;
                    lockSalesInvoice.TermId = objSalesInvoice.TermId;
                    lockSalesInvoice.Remarks = objSalesInvoice.Remarks;
                    lockSalesInvoice.SoldBy = objSalesInvoice.SoldBy;
                    lockSalesInvoice.CheckedBy = objSalesInvoice.CheckedBy;
                    lockSalesInvoice.ApprovedBy = objSalesInvoice.ApprovedBy;
                    lockSalesInvoice.IsLocked = true;
                    lockSalesInvoice.Amount = amount;
                    lockSalesInvoice.BalanceAmount = amount;
                    lockSalesInvoice.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    lockSalesInvoice.UpdatedDateTime = DateTime.Now;
                    db.SubmitChanges();

                    Modules.TrnInventoryModule inventory = new Modules.TrnInventoryModule();
                    inventory.InsertInventorySalesInvoice(id);

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Sales Invoicenot found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ====================
        // Unlock Sales Invoice
        // ====================
        public String[] UnlockSalesInvoice(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var salesInvoice = from d in db.TrnSalesInvoices
                                   where d.Id == id
                                   select d;

                if (salesInvoice.Any())
                {
                    if (salesInvoice.FirstOrDefault().IsLocked == false)
                    {
                        return new String[] { "Already unlocked.", "0" };
                    }

                    var collectionLines = from d in db.TrnCollectionLines
                                          where d.SIId == id
                                          && d.TrnCollection.IsLocked == true
                                          select d;

                    if (collectionLines.Any())
                    {
                        return new String[] { "Cannot unlock if paid.", "0" };
                    }

                    var unlockSalesInvoice = salesInvoice.FirstOrDefault();
                    unlockSalesInvoice.IsLocked = false;
                    unlockSalesInvoice.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    unlockSalesInvoice.UpdatedDateTime = DateTime.Now;
                    db.SubmitChanges();

                    Modules.TrnInventoryModule inventory = new Modules.TrnInventoryModule();
                    inventory.DeleteInventorySalesInvoice(id);

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Sales Invoicenot found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ====================
        // Delete Sales Invoice
        // ====================
        public String[] DeleteSalesInvoice(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var salesInvoice = from d in db.TrnSalesInvoices
                                   where d.Id == id
                                   select d;

                if (salesInvoice.Any())
                {
                    if (salesInvoice.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Sales Invoiceis locked", "0" };
                    }

                    var deleteSalesInvoice = salesInvoice.FirstOrDefault();
                    db.TrnSalesInvoices.DeleteOnSubmit(deleteSalesInvoice);
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Sales Invoicenot found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}