using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class TrnMemoController
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
        // List Memo
        // ===================
        public List<Entities.TrnMemoEntity> ListMemo(DateTime startDateFilter, DateTime endDateFilter, String filter)
        {
            var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
            var currentBranchId = currentUserLogin.FirstOrDefault().BranchId;

            var memo = from d in db.TrnMemos
                       where d.MODate >= startDateFilter
                       && d.MODate <= endDateFilter
                       && d.BranchId == currentBranchId
                       && (d.MONumber.Contains(filter)
                       || d.MstArticle.Article.Contains(filter)
                       || d.Remarks.Contains(filter))
                       select new Entities.TrnMemoEntity
                       {
                           Id = d.Id,
                           BranchId = d.BranchId,
                           Branch = d.MstBranch.Branch,
                           MONumber = d.MONumber,
                           MODate = d.MODate,
                           ArticleId = d.ArticleId,
                           Article = d.MstArticle.Article,
                           Remarks = d.Remarks,
                           PreparedBy = d.PreparedBy,
                           CheckedBy = d.CheckedBy,
                           ApprovedBy = d.ApprovedBy,
                           IsLocked = d.IsLocked,
                           CreatedBy = d.CreatedBy,
                           CreatedDateTime = d.CreatedDateTime,
                           UpdatedBy = d.UpdatedBy,
                           UpdatedDateTime = d.UpdatedDateTime
                       };

            return memo.OrderByDescending(d => d.Id).ToList();
        }

        // =====================
        // Detail Memo
        // =====================
        public Entities.TrnMemoEntity DetailMemo(Int32 id)
        {
            var memo = from d in db.TrnMemos
                       where d.Id == id
                       select new Entities.TrnMemoEntity
                       {
                           Id = d.Id,
                           BranchId = d.BranchId,
                           Branch = d.MstBranch.Branch,
                           MONumber = d.MONumber,
                           MODate = d.MODate,
                           ArticleId = d.ArticleId,
                           Remarks = d.Remarks,
                           PreparedBy = d.PreparedBy,
                           CheckedBy = d.CheckedBy,
                           ApprovedBy = d.ApprovedBy,
                           IsLocked = d.IsLocked,
                           CreatedBy = d.CreatedBy,
                           CreatedDateTime = d.CreatedDateTime,
                           UpdatedBy = d.UpdatedBy,
                           UpdatedDateTime = d.UpdatedDateTime
                       };

            return memo.FirstOrDefault();
        }

        // =======================
        // Dropdown List - ArticleTyp
        // =======================
        public Int32 GetArticleTypeId(Int32 articleId)
        {
            var articleType = from d in db.MstArticles
                              where d.Id == articleId
                              select new Entities.MstArticleTypeEntity
                              {
                                  Id = d.MstArticleType.Id,
                                  ArticleType = d.MstArticleType.ArticleType
                              };

            return articleType.FirstOrDefault().Id;
        }

        // =======================
        // Dropdown List - Article
        // =======================
        public List<Entities.MstArticleTypeEntity> DropdownListMemoArticleType()
        {
            var suppliers = from d in db.MstArticleTypes
                            where d.ArticleType == "SUPPLIER"
                              || d.ArticleType == "CUSTOMER"
                            select new Entities.MstArticleTypeEntity
                            {
                                Id = d.Id,
                                ArticleType = d.ArticleType
                            };

            return suppliers.ToList();
        }

        // =======================
        // Dropdown List - Article
        // =======================
        public List<Entities.MstArticleEntity> DropdownListMemoArticle(Int32 ArticleTypeId)
        {
            var suppliers = from d in db.MstArticles
                            where d.ArticleTypeId == ArticleTypeId
                            select new Entities.MstArticleEntity
                            {
                                Id = d.Id,
                                Article = d.Article
                            };

            return suppliers.ToList();
        }

        // ====================
        // Dropdown List - User
        // ====================
        public List<Entities.MstUserEntity> DropdownListMemoUser()
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
        public String[] AddMemo()
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var currentBranchId = currentUserLogin.FirstOrDefault().BranchId;

                String MONumber = "0000000001";
                var lastMO = from d in db.TrnMemos.OrderByDescending(d => d.Id)
                             where d.BranchId == currentBranchId
                             select d;

                if (lastMO.Any())
                {
                    Int32 newMONumber = Convert.ToInt32(lastMO.FirstOrDefault().MONumber) + 1;
                    MONumber = FillLeadingZeroes(newMONumber, 10);
                }

                var article = from d in db.MstArticles
                              where d.MstArticleType.ArticleType != "ITEM"
                              && d.MstArticleType.ArticleType != "BANK"
                              && d.MstArticleType.ArticleType != "EMPLOYEE"
                              && d.MstArticleType.ArticleType != "OTHERS"
                              select d;

                if (article.Any() == false)
                {
                    return new String[] { "Article not found.", "0" };
                }

                Data.TrnMemo newMemo = new Data.TrnMemo
                {
                    BranchId = currentUserLogin.FirstOrDefault().BranchId,
                    MONumber = MONumber,
                    MODate = DateTime.Today,
                    ArticleId = article.FirstOrDefault().Id,
                    Remarks = "NA",
                    PreparedBy = currentUserLogin.FirstOrDefault().Id,
                    CheckedBy = currentUserLogin.FirstOrDefault().Id,
                    ApprovedBy = currentUserLogin.FirstOrDefault().Id,
                    IsLocked = false,
                    CreatedBy = currentUserLogin.FirstOrDefault().Id,
                    CreatedDateTime = DateTime.Today,
                    UpdatedBy = currentUserLogin.FirstOrDefault().Id,
                    UpdatedDateTime = DateTime.Today
                };

                db.TrnMemos.InsertOnSubmit(newMemo);
                db.SubmitChanges();

                return new String[] { "", newMemo.Id.ToString() };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }


        // ===================
        // Lock Memo
        // ===================
        public String[] LockMemo(Int32 id, Entities.TrnMemoEntity objMemo)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var checkedByUser = from d in db.MstUsers
                                    where d.Id == objMemo.CheckedBy
                                    && d.IsLocked == true
                                    select d;

                if (checkedByUser.Any() == false)
                {
                    return new String[] { "Checked by user not found.", "0" };
                }

                var preparedByUser = from d in db.MstUsers
                                     where d.Id == objMemo.PreparedBy
                                     && d.IsLocked == true
                                     select d;

                if (preparedByUser.Any() == false)
                {
                    return new String[] { "Checked by user not found.", "0" };
                }

                var approvedByUser = from d in db.MstUsers
                                     where d.Id == objMemo.ApprovedBy
                                     && d.IsLocked == true
                                     select d;

                if (approvedByUser.Any() == false)
                {
                    return new String[] { "Approved by user not found.", "0" };
                }

                var memo = from d in db.TrnMemos
                           where d.Id == id
                           select d;

                var article = from d in db.MstArticles
                              where d.Id == objMemo.ArticleId
                              && d.MstArticleType.ArticleType == "SUPPLIER"
                              || d.MstArticleType.ArticleType == "CUSTOMER"
                              select d;

                if (article.Any() == false)
                {
                    return new String[] { "Article not found.", "0" };
                }

                if (memo.Any())
                {
                    if (memo.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Already locked.", "0" };
                    }

                    var lockMemo = memo.FirstOrDefault();
                    lockMemo.MODate = objMemo.MODate;
                    lockMemo.ArticleId = objMemo.ArticleId;
                    lockMemo.Remarks = objMemo.Remarks;
                    lockMemo.PreparedBy = preparedByUser.FirstOrDefault().Id;
                    lockMemo.CheckedBy = checkedByUser.FirstOrDefault().Id;
                    lockMemo.ApprovedBy = approvedByUser.FirstOrDefault().Id;
                    lockMemo.IsLocked = true;
                    lockMemo.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    lockMemo.UpdatedDateTime = DateTime.Today;
                    db.SubmitChanges();

                    if (memo.FirstOrDefault().TrnMemoLines.Any())
                    {
                        foreach (var memoLine in memo.FirstOrDefault().TrnMemoLines)
                        {
                            if (memoLine.RRId != null)
                            {
                                Modules.TrnAccountsPayableModule trnAccountsPayableModule = new Modules.TrnAccountsPayableModule();
                                trnAccountsPayableModule.UpdateAccountsPayable(Convert.ToInt32(memoLine.RRId));
                            }

                            if (memoLine.SIId != null)
                            {
                                Modules.TrnAccountsReceivableModule trnAccountsReceivableModule = new Modules.TrnAccountsReceivableModule();
                                trnAccountsReceivableModule.UpdateAccountsReceivable(Convert.ToInt32(memoLine.SIId));
                            }
                        }
                    }

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Memo not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===========
        // Unlock Memo
        // ===========
        public String[] UnlockMemo(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var memo = from d in db.TrnMemos
                           where d.Id == id
                           select d;

                if (memo.Any())
                {
                    if (!memo.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Already unlocked.", "0" };
                    }

                    var unlockMemo = memo.FirstOrDefault();
                    unlockMemo.IsLocked = false;
                    unlockMemo.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    unlockMemo.UpdatedDateTime = DateTime.Today;
                    db.SubmitChanges();

                    if (memo.FirstOrDefault().TrnMemoLines.Any())
                    {
                        foreach (var memoLine in memo.FirstOrDefault().TrnMemoLines)
                        {
                            if (memoLine.RRId != null)
                            {
                                Modules.TrnAccountsPayableModule trnAccountsPayableModule = new Modules.TrnAccountsPayableModule();
                                trnAccountsPayableModule.UpdateAccountsPayable(Convert.ToInt32(memoLine.RRId));
                            }

                            if (memoLine.SIId != null)
                            {
                                Modules.TrnAccountsReceivableModule trnAccountsReceivableModule = new Modules.TrnAccountsReceivableModule();
                                trnAccountsReceivableModule.UpdateAccountsReceivable(Convert.ToInt32(memoLine.SIId));
                            }
                        }
                    }

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Memo not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===========
        // Unlock Memo
        // ===========
        public String[] DeleteMemo(Int32 id)
        {
            try
            {
                var memo = from d in db.TrnMemos
                           where d.Id == id
                           select d;

                if (memo.Any())
                {
                    if (memo.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Already locked.", "0" };
                    }

                    var deleteMemo = memo.FirstOrDefault();
                    db.TrnMemos.DeleteOnSubmit(deleteMemo);
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Memo not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
