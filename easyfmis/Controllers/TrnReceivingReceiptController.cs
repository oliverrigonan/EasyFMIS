using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class TrnReceivingReceiptController
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

        // ======================
        // List Receiving Receipt
        // ======================
        public List<Entities.TrnReceivingReceiptEntity> ListReceivingReceipt(DateTime dateFilter, String filter)
        {
            var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
            var currentBranchId = currentUserLogin.FirstOrDefault().BranchId;

            var receivingReceipts = from d in db.TrnReceivingReceipts
                                    where d.RRDate == dateFilter
                                    && d.BranchId == currentBranchId
                                    && (d.RRNumber.Contains(filter)
                                    || d.MstArticle.Article.Contains(filter)
                                    || d.Remarks.Contains(filter))
                                    select new Entities.TrnReceivingReceiptEntity
                                    {
                                        Id = d.Id,
                                        BranchId = d.BranchId,
                                        Branch = d.MstBranch.Branch,
                                        RRNumber = d.RRNumber,
                                        RRDate = d.RRDate,
                                        ManualRRNumber = d.ManualRRNumber,
                                        SupplierId = d.SupplierId,
                                        Supplier = d.MstArticle.Article,
                                        TermId = d.TermId,
                                        Remarks = d.Remarks,
                                        ReceivedBy = d.ReceivedBy,
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

            return receivingReceipts.OrderByDescending(d => d.Id).ToList();
        }

        // ========================
        // Detail Receiving Receipt
        // ========================
        public Entities.TrnReceivingReceiptEntity DetailReceivingReceipt(Int32 id)
        {
            var receivingReceipt = from d in db.TrnReceivingReceipts
                                   where d.Id == id
                                   select new Entities.TrnReceivingReceiptEntity
                                   {
                                       Id = d.Id,
                                       BranchId = d.BranchId,
                                       Branch = d.MstBranch.Branch,
                                       RRNumber = d.RRNumber,
                                       RRDate = d.RRDate,
                                       ManualRRNumber = d.ManualRRNumber,
                                       SupplierId = d.SupplierId,
                                       Supplier = d.MstArticle.Article,
                                       TermId = d.TermId,
                                       Remarks = d.Remarks,
                                       ReceivedBy = d.ReceivedBy,
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

            return receivingReceipt.FirstOrDefault();
        }

        // ========================
        // Dropdown List - Supplier
        // ========================
        public List<Entities.MstArticleEntity> DropdownListReceivingReceiptSupplier()
        {
            var suppliers = from d in db.MstArticles
                            where d.ArticleTypeId == 3
                            && d.IsLocked == true
                            select new Entities.MstArticleEntity
                            {
                                Id = d.Id,
                                Article = d.Article
                            };

            return suppliers.ToList();
        }

        // ====================
        // Dropdown List - Term
        // ====================
        public List<Entities.MstTermEntity> DropdownListReceivingReceiptTerm()
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
        public List<Entities.MstUserEntity> DropdownListReceivingReceiptUser()
        {
            var users = from d in db.MstUsers
                        select new Entities.MstUserEntity
                        {
                            Id = d.Id,
                            FullName = d.FullName
                        };

            return users.ToList();
        }

        // =====================
        // Add Receiving Receipt
        // =====================
        public String[] AddReceivingReceipt()
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var supplier = from d in db.MstArticles
                               where d.ArticleTypeId == 3
                               && d.IsLocked == true
                               select d;

                if (supplier.Any() == false)
                {
                    return new String[] { "Supplier not found.", "0" };
                }

                var term = from d in db.MstTerms
                           select d;

                if (term.Any() == false)
                {
                    return new String[] { "Term not found.", "0" };
                }

                String receivingReceiptNumber = "0000000001";
                var lastReceivingReceipt = from d in db.TrnReceivingReceipts.OrderByDescending(d => d.Id) select d;
                if (lastReceivingReceipt.Any())
                {
                    Int32 newRRNumber = Convert.ToInt32(lastReceivingReceipt.FirstOrDefault().RRNumber) + 1;
                    receivingReceiptNumber = FillLeadingZeroes(newRRNumber, 10);
                }

                Data.TrnReceivingReceipt newReceivingReceipt = new Data.TrnReceivingReceipt()
                {
                    BranchId = currentUserLogin.FirstOrDefault().BranchId,
                    RRDate = DateTime.Today,
                    RRNumber = receivingReceiptNumber,
                    ManualRRNumber = receivingReceiptNumber,
                    SupplierId = supplier.FirstOrDefault().Id,
                    TermId = term.FirstOrDefault().Id,
                    Remarks = "",
                    ReceivedBy = currentUserLogin.FirstOrDefault().Id,
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

                db.TrnReceivingReceipts.InsertOnSubmit(newReceivingReceipt);
                db.SubmitChanges();

                return new String[] { "", newReceivingReceipt.Id.ToString() };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ======================
        // Lock Receiving Receipt
        // ======================
        public String[] LockReceivingReceipt(Int32 id, Entities.TrnReceivingReceiptEntity objReceivingReceipt)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var supplier = from d in db.MstArticles
                               where d.Id == objReceivingReceipt.SupplierId
                               && d.ArticleTypeId == 3
                               && d.IsLocked == true
                               select d;

                if (supplier.Any() == false)
                {
                    return new String[] { "Supplier not found.", "0" };
                }

                var term = from d in db.MstTerms
                           where d.Id == objReceivingReceipt.TermId
                           select d;

                if (term.Any() == false)
                {
                    return new String[] { "Term not found.", "0" };
                }

                var checkedByUser = from d in db.MstUsers
                                    where d.Id == objReceivingReceipt.CheckedBy
                                    && d.IsLocked == true
                                    select d;

                if (checkedByUser.Any() == false)
                {
                    return new String[] { "Checked by user not found.", "0" };
                }

                var approvedByUser = from d in db.MstUsers
                                     where d.Id == objReceivingReceipt.ApprovedBy
                                     && d.IsLocked == true
                                     select d;

                if (approvedByUser.Any() == false)
                {
                    return new String[] { "Approved by user not found.", "0" };
                }

                var receivingReceipt = from d in db.TrnReceivingReceipts
                                       where d.Id == id
                                       select d;

                if (receivingReceipt.Any())
                {
                    if (receivingReceipt.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Already locked.", "0" };
                    }

                    Decimal amount = 0;
                    var receivingReceiptItems = from d in db.TrnReceivingReceiptItems
                                                where d.RRId == id
                                                select d;

                    if (receivingReceiptItems.Any())
                    {
                        amount = receivingReceiptItems.Sum(d => d.Amount);
                    }

                    var lockReceivingReceipt = receivingReceipt.FirstOrDefault();
                    lockReceivingReceipt.RRDate = Convert.ToDateTime(objReceivingReceipt.RRDate);
                    lockReceivingReceipt.ManualRRNumber = objReceivingReceipt.ManualRRNumber;
                    lockReceivingReceipt.SupplierId = objReceivingReceipt.SupplierId;
                    lockReceivingReceipt.TermId = objReceivingReceipt.TermId;
                    lockReceivingReceipt.Remarks = objReceivingReceipt.Remarks;
                    lockReceivingReceipt.ReceivedBy = objReceivingReceipt.ReceivedBy;
                    lockReceivingReceipt.CheckedBy = objReceivingReceipt.CheckedBy;
                    lockReceivingReceipt.ApprovedBy = objReceivingReceipt.ApprovedBy;
                    lockReceivingReceipt.IsLocked = true;
                    lockReceivingReceipt.Amount = amount;
                    lockReceivingReceipt.BalanceAmount = amount;
                    lockReceivingReceipt.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    lockReceivingReceipt.UpdatedDateTime = DateTime.Now;
                    db.SubmitChanges();

                    Modules.TrnInventoryModule inventory = new Modules.TrnInventoryModule();
                    inventory.InsertInventoryReceivingReceipt(id);

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Receiving Receipt not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ========================
        // Unlock Receiving Receipt
        // ========================
        public String[] UnlockReceivingReceipt(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var receivingReceipt = from d in db.TrnReceivingReceipts
                                       where d.Id == id
                                       select d;

                if (receivingReceipt.Any())
                {
                    if (receivingReceipt.FirstOrDefault().IsLocked == false)
                    {
                        return new String[] { "Already unlocked.", "0" };
                    }

                    var disbursementLines = from d in db.TrnDisbursementLines
                                            where d.RRId == id
                                            && d.TrnDisbursement.IsLocked == true
                                            select d;

                    if (disbursementLines.Any())
                    {
                        return new String[] { "Cannot unlock if paid.", "0" };
                    }

                    var unlockReceivingReceipt = receivingReceipt.FirstOrDefault();
                    unlockReceivingReceipt.IsLocked = false;
                    unlockReceivingReceipt.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    unlockReceivingReceipt.UpdatedDateTime = DateTime.Now;
                    db.SubmitChanges();

                    Modules.TrnInventoryModule inventory = new Modules.TrnInventoryModule();
                    inventory.DeleteInventoryReceivingReceipt(id);

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Receiving Receipt not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ========================
        // Delete Receiving Receipt
        // ========================
        public String[] DeleteReceivingReceipt(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var receivingReceipt = from d in db.TrnReceivingReceipts
                                       where d.Id == id
                                       select d;

                if (receivingReceipt.Any())
                {
                    if (receivingReceipt.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Receiving Receipt is locked", "0" };
                    }

                    var deleteReceivingReceipt = receivingReceipt.FirstOrDefault();
                    db.TrnReceivingReceipts.DeleteOnSubmit(deleteReceivingReceipt);
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Receiving Receipt not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}