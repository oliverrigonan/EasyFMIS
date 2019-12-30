using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class TrnCollectionController
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

        // ===============
        // List Collection
        // ===============
        public List<Entities.TrnCollectionEntity> ListCollection(DateTime startDateFilter, DateTime endDateFilter, String filter)
        {
            var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
            var currentBranchId = currentUserLogin.FirstOrDefault().BranchId;

            var collections = from d in db.TrnCollections
                              where d.ORDate >= startDateFilter
                              && d.ORDate <= endDateFilter
                              && d.BranchId == currentBranchId
                              && (d.ORNumber.Contains(filter)
                              || d.MstArticle.Article.Contains(filter)
                              || d.Remarks.Contains(filter))
                              select new Entities.TrnCollectionEntity
                              {
                                  Id = d.Id,
                                  BranchId = d.BranchId,
                                  Branch = d.MstBranch.Branch,
                                  ORNumber = d.ORNumber,
                                  ORDate = d.ORDate,
                                  ManualORNumber = d.ManualORNumber,
                                  CustomerId = d.CustomerId,
                                  Customer = d.MstArticle.Article,
                                  Remarks = d.Remarks,
                                  PreparedBy = d.PreparedBy,
                                  CheckedBy = d.CheckedBy,
                                  ApprovedBy = d.ApprovedBy,
                                  IsLocked = d.IsLocked,
                                  CreatedBy = d.CreatedBy,
                                  CreatedDateTime = d.CreatedDateTime,
                                  CreatedByUserName = d.MstUser3.UserName,
                                  UpdatedBy = d.UpdatedBy,
                                  UpdatedDateTime = d.UpdatedDateTime,
                                  UpdatedByUserName = d.MstUser4.UserName
                              };

            return collections.OrderByDescending(d => d.Id).ToList();
        }

        // =================
        // Detail Collection
        // =================
        public Entities.TrnCollectionEntity DetailCollection(Int32 id)
        {
            var collection = from d in db.TrnCollections
                             where d.Id == id
                             select new Entities.TrnCollectionEntity
                             {
                                 Id = d.Id,
                                 BranchId = d.BranchId,
                                 Branch = d.MstBranch.Branch,
                                 ORNumber = d.ORNumber,
                                 ORDate = d.ORDate,
                                 ManualORNumber = d.ManualORNumber,
                                 CustomerId = d.CustomerId,
                                 Customer = d.MstArticle.Article,
                                 Remarks = d.Remarks,
                                 PreparedBy = d.PreparedBy,
                                 CheckedBy = d.CheckedBy,
                                 ApprovedBy = d.ApprovedBy,
                                 IsLocked = d.IsLocked,
                                 CreatedBy = d.CreatedBy,
                                 CreatedDateTime = d.CreatedDateTime,
                                 CreatedByUserName = d.MstUser3.UserName,
                                 UpdatedBy = d.UpdatedBy,
                                 UpdatedDateTime = d.UpdatedDateTime,
                                 UpdatedByUserName = d.MstUser4.UserName
                             };

            return collection.FirstOrDefault();
        }

        // ========================
        // Dropdown List - Customer
        // ========================
        public List<Entities.MstArticleEntity> DropdownListCollectionCustomer()
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
        // Dropdown List - User
        // ====================
        public List<Entities.MstUserEntity> DropdownListCollectionUser()
        {
            var users = from d in db.MstUsers
                        select new Entities.MstUserEntity
                        {
                            Id = d.Id,
                            FullName = d.FullName
                        };

            return users.ToList();
        }

        // ==============
        // Add Collection
        // ==============
        public String[] AddCollection()
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

                String collectionNumber = "0000000001";
                var lastCollection = from d in db.TrnCollections.OrderByDescending(d => d.Id) select d;
                if (lastCollection.Any())
                {
                    Int32 newORNumber = Convert.ToInt32(lastCollection.FirstOrDefault().ORNumber) + 1;
                    collectionNumber = FillLeadingZeroes(newORNumber, 10);
                }

                Data.TrnCollection newCollection = new Data.TrnCollection()
                {
                    BranchId = currentUserLogin.FirstOrDefault().BranchId,
                    ORDate = DateTime.Today,
                    ORNumber = collectionNumber,
                    ManualORNumber = collectionNumber,
                    CustomerId = customer.FirstOrDefault().Id,
                    Remarks = "",
                    PreparedBy = currentUserLogin.FirstOrDefault().Id,
                    CheckedBy = currentUserLogin.FirstOrDefault().Id,
                    ApprovedBy = currentUserLogin.FirstOrDefault().Id,
                    IsLocked = false,
                    CreatedBy = currentUserLogin.FirstOrDefault().Id,
                    CreatedDateTime = DateTime.Now,
                    UpdatedBy = currentUserLogin.FirstOrDefault().Id,
                    UpdatedDateTime = DateTime.Now
                };

                db.TrnCollections.InsertOnSubmit(newCollection);
                db.SubmitChanges();

                return new String[] { "", newCollection.Id.ToString() };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===============
        // Lock Collection
        // ===============
        public String[] LockCollection(Int32 id, Entities.TrnCollectionEntity objCollection)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var customer = from d in db.MstArticles
                               where d.Id == objCollection.CustomerId
                               && d.ArticleTypeId == 2
                               && d.IsLocked == true
                               select d;

                if (customer.Any() == false)
                {
                    return new String[] { "Customer not found.", "0" };
                }

                var checkedByUser = from d in db.MstUsers
                                    where d.Id == objCollection.CheckedBy
                                    && d.IsLocked == true
                                    select d;

                if (checkedByUser.Any() == false)
                {
                    return new String[] { "Checked by user not found.", "0" };
                }

                var approvedByUser = from d in db.MstUsers
                                     where d.Id == objCollection.ApprovedBy
                                     && d.IsLocked == true
                                     select d;

                if (approvedByUser.Any() == false)
                {
                    return new String[] { "Approved by user not found.", "0" };
                }

                var collection = from d in db.TrnCollections
                                 where d.Id == id
                                 select d;

                if (collection.Any())
                {
                    if (collection.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Already locked.", "0" };
                    }

                    var lockCollection = collection.FirstOrDefault();
                    lockCollection.ORDate = Convert.ToDateTime(objCollection.ORDate);
                    lockCollection.ManualORNumber = objCollection.ManualORNumber;
                    lockCollection.CustomerId = objCollection.CustomerId;
                    lockCollection.Remarks = objCollection.Remarks;
                    lockCollection.CheckedBy = objCollection.CheckedBy;
                    lockCollection.ApprovedBy = objCollection.ApprovedBy;
                    lockCollection.IsLocked = true;
                    lockCollection.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    lockCollection.UpdatedDateTime = DateTime.Now;
                    db.SubmitChanges();

                    var collectionLines = from d in db.TrnCollectionLines
                                          where d.ORId == id
                                          && d.SIId != null
                                          select d;

                    if (collectionLines.Any())
                    {
                        foreach (var collectionLine in collectionLines)
                        {
                            Int32 SIId = Convert.ToInt32(collectionLine.SIId);

                            Modules.TrnAccountsReceivableModule accountsReceivable = new Modules.TrnAccountsReceivableModule();
                            accountsReceivable.UpdateAccountsReceivable(SIId);
                        }
                    }

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Collection not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =================
        // Unlock Collection
        // =================
        public String[] UnlockCollection(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var collection = from d in db.TrnCollections
                                 where d.Id == id
                                 select d;

                if (collection.Any())
                {
                    if (collection.FirstOrDefault().IsLocked == false)
                    {
                        return new String[] { "Already unlocked.", "0" };
                    }

                    var unlockCollection = collection.FirstOrDefault();
                    unlockCollection.IsLocked = false;
                    unlockCollection.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    unlockCollection.UpdatedDateTime = DateTime.Now;
                    db.SubmitChanges();

                    var collectionLines = from d in db.TrnCollectionLines
                                          where d.ORId == id
                                          && d.SIId != null
                                          select d;

                    if (collectionLines.Any())
                    {
                        foreach (var collectionLine in collectionLines)
                        {
                            Int32 SIId = Convert.ToInt32(collectionLine.SIId);

                            Modules.TrnAccountsReceivableModule accountsReceivable = new Modules.TrnAccountsReceivableModule();
                            accountsReceivable.UpdateAccountsReceivable(SIId);
                        }
                    }

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Collection not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =================
        // Delete Collection
        // =================
        public String[] DeleteCollection(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var collection = from d in db.TrnCollections
                                 where d.Id == id
                                 select d;

                if (collection.Any())
                {
                    if (collection.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Collection is locked", "0" };
                    }

                    var deleteCollection = collection.FirstOrDefault();
                    db.TrnCollections.DeleteOnSubmit(deleteCollection);
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Collection not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}