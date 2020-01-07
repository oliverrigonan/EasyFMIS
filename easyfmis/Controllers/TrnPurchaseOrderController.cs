using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class TrnPurchaseOrderController
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

        // ===================
        // List Purchase Order
        // ===================
        public List<Entities.TrnPurchaseOrderEntity> ListPurchaseOrder(DateTime startDateFilter, DateTime endDateFilter, String filter)
        {
            var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
            var currentBranchId = currentUserLogin.FirstOrDefault().BranchId;

            var purchaseOrders = from d in db.TrnPurchaseOrders
                                 where d.PODate >= startDateFilter
                                 && d.PODate <= endDateFilter
                                 && d.BranchId == currentBranchId
                                 && (d.PONumber.Contains(filter)
                                 || d.MstArticle.Article.Contains(filter)
                                 || d.Remarks.Contains(filter))
                                 select new Entities.TrnPurchaseOrderEntity
                                 {
                                     Id = d.Id,
                                     BranchId = d.BranchId,
                                     PONumber = d.PONumber,
                                     PODate = d.PODate,
                                     ManualPONumber = d.ManualPONumber,
                                     SupplierId = d.SupplierId,
                                     Supplier = d.MstArticle.Article,
                                     TermId = d.TermId,
                                     Term = d.MstTerm.Term,
                                     DateNeeded = d.DateNeeded,
                                     Remarks = d.Remarks,
                                     IsClose = d.IsClose,
                                     RequestedBy = d.RequestedBy,
                                     RequestedByFullName = d.MstUser.FullName,
                                     PreparedBy = d.PreparedBy,
                                     PreparedByFullName = d.MstUser1.FullName,
                                     CheckedBy = d.CheckedBy,
                                     CheckedByFullName = d.MstUser2.FullName,
                                     ApprovedBy = d.ApprovedBy,
                                     ApprovedByFullName = d.MstUser3.FullName,
                                     IsLocked = d.IsLocked,
                                     CreatedBy = d.CheckedBy,
                                     CreatedDateTime = d.CreatedDateTime,
                                     UpdatedBy = d.UpdatedBy,
                                     UpdatedDateTime = d.UpdatedDateTime
                                 };

            return purchaseOrders.OrderByDescending(d => d.Id).ToList();
        }

        // =====================
        // Detail Purchase Order
        // =====================
        public Entities.TrnPurchaseOrderEntity DetailPurchaseOrder(Int32 id)
        {
            var purchaseOrder = from d in db.TrnPurchaseOrders
                                where d.Id == id
                                select new Entities.TrnPurchaseOrderEntity
                                {
                                    Id = d.Id,
                                    BranchId = d.BranchId,
                                    Branch = d.MstBranch.Branch,
                                    PONumber = d.PONumber,
                                    PODate = d.PODate,
                                    ManualPONumber = d.ManualPONumber,
                                    SupplierId = d.SupplierId,
                                    Supplier = d.MstArticle.Article,
                                    TermId = d.TermId,
                                    Term = d.MstTerm.Term,
                                    DateNeeded = d.DateNeeded,
                                    Remarks = d.Remarks,
                                    IsClose = d.IsClose,
                                    RequestedBy = d.RequestedBy,
                                    RequestedByFullName = d.MstUser.FullName,
                                    PreparedBy = d.PreparedBy,
                                    PreparedByFullName = d.MstUser1.FullName,
                                    CheckedBy = d.CheckedBy,
                                    CheckedByFullName = d.MstUser2.FullName,
                                    ApprovedBy = d.ApprovedBy,
                                    ApprovedByFullName = d.MstUser3.FullName,
                                    IsLocked = d.IsLocked,
                                    CreatedBy = d.CheckedBy,
                                    CreatedDateTime = d.CreatedDateTime,
                                    UpdatedBy = d.UpdatedBy,
                                    UpdatedDateTime = d.UpdatedDateTime
                                };

            return purchaseOrder.FirstOrDefault();
        }

        // ========================
        // Dropdown List - Supplier
        // ========================
        public List<Entities.MstArticleEntity> DropdownListPurchaseOrderSupplier()
        {
            var suppliers = from d in db.MstArticles
                            where d.MstArticleType.ArticleType == "SUPPLIER"
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
        public List<Entities.MstTermEntity> DropdownListPurchaseOrderTerm()
        {
            var terms = from d in db.MstTerms
                        where d.IsLocked == true
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
        public List<Entities.MstUserEntity> DropdownListPurchaseOrderUser()
        {
            var users = from d in db.MstUsers
                        select new Entities.MstUserEntity
                        {
                            Id = d.Id,
                            FullName = d.FullName
                        };

            return users.ToList();
        }

        // ===============
        // Add Sales Order
        // ===============
        public String[] AddPurchaseOrder()
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var currentBranchId = currentUserLogin.FirstOrDefault().BranchId;

                String PONumber = "0000000001";
                var lastPO = from d in db.TrnPurchaseOrders.OrderByDescending(d => d.Id)
                             where d.BranchId == currentBranchId
                             select d;

                if (lastPO.Any())
                {
                    Int32 newPONumber = Convert.ToInt32(lastPO.FirstOrDefault().PONumber) + 1;
                    PONumber = FillLeadingZeroes(newPONumber, 10);
                }

                var supplier = from d in db.MstArticles
                               where d.MstArticleType.ArticleType == "SUPPLIER"
                               select d;

                if (supplier.Any() == false)
                {
                    return new String[] { "Supplier not found.", "0" };
                }

                var term = from d in db.MstTerms
                           where d.IsLocked == true
                           select d;

                if (term.Any() == false)
                {
                    return new String[] { "Term not found.", "0" };
                }

                Data.TrnPurchaseOrder newPurchaseOrder = new Data.TrnPurchaseOrder
                {
                    BranchId = currentUserLogin.FirstOrDefault().BranchId,
                    PONumber = PONumber,
                    PODate = DateTime.Today,
                    ManualPONumber = "NA",
                    SupplierId = supplier.FirstOrDefault().Id,
                    TermId = term.FirstOrDefault().Id,
                    DateNeeded = DateTime.Today,
                    Remarks = "NA",
                    IsClose = false,
                    RequestedBy = currentUserLogin.FirstOrDefault().Id,
                    PreparedBy = currentUserLogin.FirstOrDefault().Id,
                    CheckedBy = currentUserLogin.FirstOrDefault().Id,
                    ApprovedBy = currentUserLogin.FirstOrDefault().Id,
                    IsLocked = false,
                    CreatedBy = currentUserLogin.FirstOrDefault().Id,
                    CreatedDateTime = DateTime.Today,
                    UpdatedBy = currentUserLogin.FirstOrDefault().Id,
                    UpdatedDateTime = DateTime.Today
                };

                db.TrnPurchaseOrders.InsertOnSubmit(newPurchaseOrder);
                db.SubmitChanges();

                return new String[] { "", newPurchaseOrder.Id.ToString() };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }


        // ===================
        // Lock Purchase Order
        // ===================
        public String[] LockPurchaseOrder(Int32 id, Entities.TrnPurchaseOrderEntity objPurchaseOrder)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var requestedByUser = from d in db.MstUsers
                                      where d.Id == objPurchaseOrder.RequestedBy
                                      && d.IsLocked == true
                                      select d;

                if (requestedByUser.Any() == false)
                {
                    return new String[] { "Checked by user not found.", "0" };
                }

                var checkedByUser = from d in db.MstUsers
                                    where d.Id == objPurchaseOrder.CheckedBy
                                    && d.IsLocked == true
                                    select d;

                if (checkedByUser.Any() == false)
                {
                    return new String[] { "Checked by user not found.", "0" };
                }

                var preparedByUser = from d in db.MstUsers
                                     where d.Id == objPurchaseOrder.PreparedBy
                                     && d.IsLocked == true
                                     select d;

                if (preparedByUser.Any() == false)
                {
                    return new String[] { "Checked by user not found.", "0" };
                }

                var approvedByUser = from d in db.MstUsers
                                     where d.Id == objPurchaseOrder.ApprovedBy
                                     && d.IsLocked == true
                                     select d;

                if (approvedByUser.Any() == false)
                {
                    return new String[] { "Approved by user not found.", "0" };
                }

                var purchaseOrder = from d in db.TrnPurchaseOrders
                                    where d.Id == id
                                    select d;

                if (purchaseOrder.Any())
                {
                    if (purchaseOrder.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Already locked.", "0" };
                    }

                    var lockPurchaseOrder = purchaseOrder.FirstOrDefault();
                    lockPurchaseOrder.PODate = objPurchaseOrder.PODate;
                    lockPurchaseOrder.ManualPONumber = objPurchaseOrder.ManualPONumber;
                    lockPurchaseOrder.SupplierId = objPurchaseOrder.SupplierId;
                    lockPurchaseOrder.TermId = objPurchaseOrder.TermId;
                    lockPurchaseOrder.DateNeeded = objPurchaseOrder.DateNeeded;
                    lockPurchaseOrder.Remarks = objPurchaseOrder.Remarks;
                    lockPurchaseOrder.IsClose = objPurchaseOrder.IsClose;
                    lockPurchaseOrder.RequestedBy = requestedByUser.FirstOrDefault().Id;
                    lockPurchaseOrder.PreparedBy = preparedByUser.FirstOrDefault().Id;
                    lockPurchaseOrder.CheckedBy = checkedByUser.FirstOrDefault().Id;
                    lockPurchaseOrder.ApprovedBy = approvedByUser.FirstOrDefault().Id;
                    lockPurchaseOrder.IsLocked = true;
                    lockPurchaseOrder.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    lockPurchaseOrder.UpdatedDateTime = DateTime.Today;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Purchase Order not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =====================
        // Unlock Purchase Order
        // =====================
        public String[] UnlockPurchaseOrder(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var purchaseOrder = from d in db.TrnPurchaseOrders
                                    where d.Id == id
                                    select d;

                if (purchaseOrder.Any())
                {
                    if (!purchaseOrder.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Already unlocked.", "0" };
                    }

                    var unlockPurchaseOrder = purchaseOrder.FirstOrDefault();
                    unlockPurchaseOrder.IsLocked = false;
                    unlockPurchaseOrder.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    unlockPurchaseOrder.UpdatedDateTime = DateTime.Today;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Purchase Order not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =====================
        // Unlock Purchase Order
        // =====================
        public String[] DeletePurchaseOrder(Int32 id)
        {
            try
            {
                var purchaseOrder = from d in db.TrnPurchaseOrders
                                    where d.Id == id
                                    select d;

                if (purchaseOrder.Any())
                {
                    if (purchaseOrder.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Already locked.", "0" };
                    }

                    var deletePurchaseOrder = purchaseOrder.FirstOrDefault();
                    db.TrnPurchaseOrders.DeleteOnSubmit(deletePurchaseOrder);
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Purchase Order not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
