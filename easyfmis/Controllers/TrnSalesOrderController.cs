using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class TrnSalesOrderController
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

        // ================
        // List Sales Order
        // ================
        public List<Entities.TrnSalesOrderEntity> ListSalesOrder(DateTime dateFilter, String filter)
        {
            var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
            var currentBranchId = currentUserLogin.FirstOrDefault().BranchId;

            var salesOrders = from d in db.TrnSalesOrders
                              where d.SODate == dateFilter
                              && d.SONumber.Contains(filter)
                              && d.BranchId == currentBranchId
                              select new Entities.TrnSalesOrderEntity
                              {
                                  Id = d.Id,
                                  BranchId = d.BranchId,
                                  SONumber = d.SONumber,
                                  SODate = d.SODate,
                                  ManualSONumber = d.ManualSONumber,
                                  CustomerId = d.CustomerId,
                                  Customer = d.MstArticle.Article,
                                  TermId = d.TermId,
                                  Remarks = d.Remarks,
                                  SoldBy = d.SoldBy,
                                  PreparedBy = d.PreparedBy,
                                  CheckedBy = d.CheckedBy,
                                  ApprovedBy = d.ApprovedBy,
                                  IsLocked = d.IsLocked,
                                  CreatedBy = d.CreatedBy,
                                  CreatedDateTime = d.CreatedDateTime,
                                  UpdatedBy = d.UpdatedBy,
                                  UpdatedDateTime = d.UpdatedDateTime
                              };

            return salesOrders.OrderByDescending(d => d.Id).ToList();
        }

        // ==================
        // Detail Sales Order
        // ==================
        public Entities.TrnSalesOrderEntity DetailSalesOrder(Int32 id)
        {
            var salesOrder = from d in db.TrnSalesOrders
                             where d.Id == id
                             select new Entities.TrnSalesOrderEntity
                             {
                                 Id = d.Id,
                                 BranchId = d.BranchId,
                                 Branch = d.MstBranch.Branch,
                                 SONumber = d.SONumber,
                                 SODate = d.SODate,
                                 ManualSONumber = d.ManualSONumber,
                                 CustomerId = d.CustomerId,
                                 TermId = d.TermId,
                                 Remarks = d.Remarks,
                                 SoldBy = d.SoldBy,
                                 PreparedBy = d.PreparedBy,
                                 CheckedBy = d.CheckedBy,
                                 ApprovedBy = d.ApprovedBy,
                                 IsLocked = d.IsLocked,
                                 CreatedBy = d.CreatedBy,
                                 CreatedDateTime = d.CreatedDateTime,
                                 UpdatedBy = d.UpdatedBy,
                                 UpdatedDateTime = d.UpdatedDateTime
                             };

            return salesOrder.FirstOrDefault();
        }

        // ===========
        // List Branch
        // ===========
        public List<Entities.MstBranchEntity> DropdownListSalesOrderBranch()
        {
            var branch = from d in db.MstBranches
                         select new Entities.MstBranchEntity
                         {
                             Id = d.Id,
                             Branch = d.Branch
                         };

            return branch.ToList();
        }

        // ========================
        // Dropdown List - Customer
        // ========================
        public List<Entities.MstArticleEntity> DropdownListSalesOrderCustomer()
        {
            var customers = from d in db.MstArticles
                            where d.MstArticleType.ArticleType == "CUSTOMER"
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
        public List<Entities.MstTermEntity> DropdownListSalesOrderTerm()
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
        public List<Entities.MstUserEntity> DropdownListSalesOrderUser()
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
        public String[] AddSalesOrder()
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }



                String sONumber = "0000000001";
                var lastSO = from d in db.TrnSalesOrders.OrderByDescending(d => d.Id) select d;
                if (lastSO.Any())
                {
                    Int32 newSONumber = Convert.ToInt32(lastSO.FirstOrDefault().SONumber) + 1;
                    sONumber = FillLeadingZeroes(newSONumber, 10);
                }

                var customer = from d in db.MstArticles
                               where d.MstArticleType.ArticleType == "CUSTOMER"
                               select d;

                if (customer.Any() == false)
                {
                    return new String[] { "Customer not found.", "0" };
                }

                var term = from d in db.MstTerms
                           where d.IsLocked == true
                           select d;

                if (term.Any() == false)
                {
                    return new String[] { "Term not found.", "0" };
                }

                Data.TrnSalesOrder newSalesOrder = new Data.TrnSalesOrder()
                {
                    BranchId = currentUserLogin.FirstOrDefault().BranchId,
                    SONumber = sONumber,
                    SODate = DateTime.Today,
                    ManualSONumber = "NA",
                    CustomerId = customer.FirstOrDefault().Id,
                    TermId = term.FirstOrDefault().Id,
                    Remarks = "NA",
                    SoldBy = currentUserLogin.FirstOrDefault().Id,
                    PreparedBy = currentUserLogin.FirstOrDefault().Id,
                    CheckedBy = currentUserLogin.FirstOrDefault().Id,
                    ApprovedBy = currentUserLogin.FirstOrDefault().Id,
                    IsLocked = false,
                    CreatedBy = currentUserLogin.FirstOrDefault().Id,
                    CreatedDateTime = DateTime.Today,
                    UpdatedBy = currentUserLogin.FirstOrDefault().Id,
                    UpdatedDateTime = DateTime.Today,
                };

                db.TrnSalesOrders.InsertOnSubmit(newSalesOrder);
                db.SubmitChanges();

                return new String[] { "", newSalesOrder.Id.ToString() };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ================
        // Lock Sales Order
        // ================
        public String[] LockSalesOrder(Int32 id, Entities.TrnSalesOrderEntity objSalesOrder)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var checkedByUser = from d in db.MstUsers
                                    where d.Id == objSalesOrder.CheckedBy
                                    && d.IsLocked == true
                                    select d;

                if (checkedByUser.Any() == false)
                {
                    return new String[] { "Checked by user not found.", "0" };
                }

                var approvedByUser = from d in db.MstUsers
                                     where d.Id == objSalesOrder.ApprovedBy
                                     && d.IsLocked == true
                                     select d;

                if (approvedByUser.Any() == false)
                {
                    return new String[] { "Approved by user not found.", "0" };
                }

                var salesOrder = from d in db.TrnSalesOrders
                              where d.Id == id
                              select d;

                if (salesOrder.Any())
                {
                    if (salesOrder.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Already locked.", "0" };
                    }

                    var lockSalesOder = salesOrder.FirstOrDefault();
                    lockSalesOder.ManualSONumber= objSalesOrder.ManualSONumber;
                    lockSalesOder.SODate = Convert.ToDateTime(objSalesOrder.SODate);
                    lockSalesOder.CustomerId = objSalesOrder.CustomerId;
                    lockSalesOder.TermId = objSalesOrder.TermId;
                    lockSalesOder.Remarks = objSalesOrder.Remarks;
                    lockSalesOder.SoldBy = objSalesOrder.SoldBy;
                    lockSalesOder.CheckedBy = objSalesOrder.CheckedBy;
                    lockSalesOder.ApprovedBy = objSalesOrder.ApprovedBy;
                    lockSalesOder.IsLocked = true;
                    lockSalesOder.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    lockSalesOder.UpdatedDateTime = DateTime.Now;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Sales Order not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ================
        // Lock Sales Order
        // ================
        public String[] UnlockSalesOrder(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var salesOrder = from d in db.TrnSalesOrders
                                 where d.Id == id
                                 select d;

                if (salesOrder.Any())
                {
                    if (!salesOrder.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Already unlocked.", "0" };
                    }

                    var unlockSalesOder = salesOrder.FirstOrDefault();
                    unlockSalesOder.IsLocked = false;
                    unlockSalesOder.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    unlockSalesOder.UpdatedDateTime = DateTime.Now;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Sales Order not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ==================
        // Delete Sales Order
        // ==================
        public String[] DeleteSalesOrder(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var salesOrder = from d in db.TrnSalesOrders
                                 where d.Id == id
                                 select d;

                if (salesOrder.Any())
                {
                    if (salesOrder.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Already locked.", "0" };
                    }

                    var deleteSalesOder = salesOrder.FirstOrDefault();
                    db.TrnSalesOrders.DeleteOnSubmit(deleteSalesOder);
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Sales Order not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
