using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class TrnDisbursementController
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

        // =================
        // List Disbursement 
        // =================
        public List<Entities.TrnDisbursementEntity> ListDisbursement(DateTime dateFilter, String filter)
        {
            var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
            var currentBranchId = currentUserLogin.FirstOrDefault().BranchId;

            var disbursements = from d in db.TrnDisbursements
                                where d.CVDate == dateFilter
                                && d.CVNumber.Contains(filter)
                                && d.BranchId == currentBranchId
                                select new Entities.TrnDisbursementEntity
                                {
                                    Id = d.Id,
                                    BranchId = d.BranchId,
                                    CVNumber = d.CVNumber,
                                    CVDate = d.CVDate,
                                    ManualCVNumber = d.ManualCVNumber,
                                    SupplierId = d.SupplierId,
                                    Supplier = d.MstArticle.Article,
                                    Payee = d.Payee,
                                    PayTypeId = d.PayTypeId,
                                    BankId = d.BankId,
                                    Remarks = d.Remarks,
                                    Amount = d.Amount,
                                    CheckNumber = d.CheckNumber,
                                    CheckDate = d.CheckDate,
                                    IsCrossCheck = d.IsCrossCheck,
                                    IsClear = d.IsClear,
                                    PreparedBy = d.PreparedBy,
                                    CheckedBy = d.CheckedBy,
                                    ApprovedBy = d.ApprovedBy,
                                    IsLocked = d.IsLocked,
                                    CreatedBy = d.CreatedBy,
                                    CreatedDateTime = d.CreatedDateTime,
                                    UpdatedBy = d.UpdatedBy,
                                    UpdatedDateTime = d.UpdatedDateTime,
                                };

            return disbursements.OrderByDescending(d => d.Id).ToList();
        }

        // ===================
        // Detail Disbursement 
        // ===================
        public Entities.TrnDisbursementEntity DetailDisbursement(Int32 id)
        {
            var disbursement = from d in db.TrnDisbursements
                               where d.Id == id
                               select new Entities.TrnDisbursementEntity
                               {
                                   Id = d.Id,
                                   BranchId = d.BranchId,
                                   Branch = d.MstBranch.Branch,
                                   CVNumber = d.CVNumber,
                                   CVDate = d.CVDate,
                                   ManualCVNumber = d.ManualCVNumber,
                                   SupplierId = d.SupplierId,
                                   Payee = d.Payee,
                                   PayTypeId = d.PayTypeId,
                                   BankId = d.BankId,
                                   Remarks = d.Remarks,
                                   Amount = d.Amount,
                                   CheckNumber = d.CheckNumber,
                                   CheckDate = d.CheckDate,
                                   IsCrossCheck = d.IsCrossCheck,
                                   IsClear = d.IsClear,
                                   PreparedBy = d.PreparedBy,
                                   CheckedBy = d.CheckedBy,
                                   ApprovedBy = d.ApprovedBy,
                                   IsLocked = d.IsLocked,
                                   CreatedBy = d.CreatedBy,
                                   CreatedDateTime = d.CreatedDateTime,
                                   UpdatedBy = d.UpdatedBy,
                                   UpdatedDateTime = d.UpdatedDateTime,
                               };

            return disbursement.FirstOrDefault();
        }

        // ========================
        // Dropdown List - Supplier
        // ========================
        public List<Entities.MstArticleEntity> DropdownListSupplier()
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
        // Dropdown List - User
        // ====================
        public List<Entities.MstUserEntity> DropdownListUser()
        {
            var users = from d in db.MstUsers
                        select new Entities.MstUserEntity
                        {
                            Id = d.Id,
                            FullName = d.FullName
                        };

            return users.ToList();
        }

        // ========================
        // Dropdown List - Pay Type
        // ========================
        public List<Entities.MstPayTypeEntity> DropdownListPayType()
        {
            var payType = from d in db.MstPayTypes
                          where d.IsLocked == true
                          select new Entities.MstPayTypeEntity
                          {
                              Id = d.Id,
                              PayType = d.PayType
                          };

            return payType.ToList();
        }

        // ========================
        // Dropdown List - Pay Type
        // ========================
        public List<Entities.MstArticleEntity> DropdownListBank()
        {
            var bank = from d in db.MstArticles
                       where d.IsLocked == true
                       && d.MstArticleType.ArticleType == "BANK"
                       select new Entities.MstArticleEntity
                       {
                           Id = d.Id,
                           Article = d.Article
                       };

            return bank.ToList();
        }

        // ================
        // Add Disbursement
        // ================
        public String[] AddDisbursement()
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
                               select d;

                if (supplier.Any() == false)
                {
                    return new String[] { "Supplier not found.", "0" };
                }

                var payType = from d in db.MstPayTypes
                              where d.IsLocked == true
                              select d;

                if (payType.Any() == false)
                {
                    return new String[] { "Pay type not found.", "0" };
                }

                var bank = from d in db.MstArticles
                           where d.IsLocked == true
                           && d.MstArticleType.ArticleType == "BANK"
                           select d;

                if (bank.Any() == false)
                {
                    return new String[] { "Bank not found.", "0" };
                }

                String CVNumber = "0000000001";
                var lastCV = from d in db.TrnDisbursements.OrderByDescending(d => d.Id) select d;
                if (lastCV.Any())
                {
                    Int32 newCVNumber = Convert.ToInt32(lastCV.FirstOrDefault().CVNumber) + 1;
                    CVNumber = FillLeadingZeroes(newCVNumber, 10);
                }

                Data.TrnDisbursement newDisbursement = new Data.TrnDisbursement
                {
                    BranchId = currentUserLogin.FirstOrDefault().BranchId,
                    CVNumber = CVNumber,
                    CVDate = DateTime.Today,
                    ManualCVNumber = "NA",
                    SupplierId = supplier.FirstOrDefault().Id,
                    Payee = "NA",
                    PayTypeId = payType.FirstOrDefault().Id,
                    BankId = bank.FirstOrDefault().Id,
                    Remarks = "NA",
                    Amount = 0,
                    CheckNumber = "NA",
                    CheckDate = DateTime.Today,
                    IsCrossCheck = false,
                    IsClear = false,
                    PreparedBy = currentUserLogin.FirstOrDefault().Id,
                    CheckedBy = currentUserLogin.FirstOrDefault().Id,
                    ApprovedBy = currentUserLogin.FirstOrDefault().Id,
                    IsLocked = false,
                    CreatedBy = currentUserLogin.FirstOrDefault().Id,
                    CreatedDateTime = DateTime.Today,
                    UpdatedBy = currentUserLogin.FirstOrDefault().Id,
                    UpdatedDateTime = DateTime.Today
                };

                db.TrnDisbursements.InsertOnSubmit(newDisbursement);
                db.SubmitChanges();

                return new String[] { "", newDisbursement.Id.ToString() };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =================
        // Lock Disbursement
        // =================
        public String[] LockDisbursement(Int32 id, Entities.TrnDisbursementEntity objDisbursement)
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
                               && d.Id == objDisbursement.SupplierId
                               select d;

                if (supplier.Any() == false)
                {
                    return new String[] { "Supplier not found.", "0" };
                }

                var payType = from d in db.MstPayTypes
                              where d.IsLocked == true
                              && d.Id == objDisbursement.PayTypeId
                              select d;

                if (payType.Any() == false)
                {
                    return new String[] { "Pay type not found.", "0" };
                }

                var bank = from d in db.MstArticles
                           where d.IsLocked == true
                           && d.ArticleTypeId == 4
                           && d.Id == objDisbursement.BankId
                           select d;

                if (bank.Any() == false)
                {
                    return new String[] { "Bank not found.", "0" };
                }

                var checkedByUser = from d in db.MstUsers
                                    where d.Id == objDisbursement.CheckedBy
                                    && d.IsLocked == true
                                    select d;

                if (checkedByUser.Any() == false)
                {
                    return new String[] { "Checked by user not found.", "0" };
                }

                var preparedByUser = from d in db.MstUsers
                                     where d.Id == objDisbursement.PreparedBy
                                     && d.IsLocked == true
                                     select d;

                if (preparedByUser.Any() == false)
                {
                    return new String[] { "Checked by user not found.", "0" };
                }

                var approvedByUser = from d in db.MstUsers
                                     where d.Id == objDisbursement.ApprovedBy
                                     && d.IsLocked == true
                                     select d;

                if (approvedByUser.Any() == false)
                {
                    return new String[] { "Approved by user not found.", "0" };
                }

                var disbursement = from d in db.TrnDisbursements
                                   where d.Id == id
                                   select d;

                if (disbursement.Any())
                {
                    if (disbursement.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Already locked.", "0" };
                    }

                    var lockDisbursement = disbursement.FirstOrDefault();
                    lockDisbursement.CVNumber = objDisbursement.CVNumber;
                    lockDisbursement.CVDate = objDisbursement.CVDate;
                    lockDisbursement.ManualCVNumber = objDisbursement.ManualCVNumber;
                    lockDisbursement.SupplierId = objDisbursement.SupplierId;
                    lockDisbursement.Payee = objDisbursement.Payee;
                    lockDisbursement.PayTypeId = objDisbursement.PayTypeId;
                    lockDisbursement.BankId = objDisbursement.BankId;
                    lockDisbursement.Remarks = objDisbursement.Remarks;
                    lockDisbursement.Amount = objDisbursement.Amount;
                    lockDisbursement.CheckNumber = objDisbursement.CheckNumber;
                    lockDisbursement.CheckDate = objDisbursement.CheckDate;
                    lockDisbursement.IsCrossCheck = objDisbursement.IsCrossCheck;
                    lockDisbursement.IsClear = objDisbursement.IsClear;
                    lockDisbursement.PreparedBy = objDisbursement.PreparedBy;
                    lockDisbursement.CheckedBy = objDisbursement.CheckedBy;
                    lockDisbursement.ApprovedBy = objDisbursement.ApprovedBy;
                    lockDisbursement.IsLocked = true;
                    lockDisbursement.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    lockDisbursement.UpdatedDateTime = DateTime.Today;
                    db.SubmitChanges();

                    var disbursementLines = from d in db.TrnDisbursementLines
                                            where d.CVId == id
                                            && d.RRId != null
                                            select d;

                    if (disbursementLines.Any())
                    {
                        foreach (var disbursementLine in disbursementLines)
                        {
                            Int32 RRId = Convert.ToInt32(disbursementLine.RRId);

                            Modules.TrnAccountsPayableModule accountsPayable = new Modules.TrnAccountsPayableModule();
                            accountsPayable.UpdateAccountsPayable(RRId);
                        }
                    }

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Disbursement not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===================
        // Unlock Disbursement
        // ===================
        public String[] UnlockDisbursement(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var disbursement = from d in db.TrnDisbursements
                                   where d.Id == id
                                   select d;

                if (disbursement.Any())
                {
                    if (!disbursement.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Already locked.", "0" };
                    }

                    var unlockDisbursement = disbursement.FirstOrDefault();
                    unlockDisbursement.IsLocked = false;
                    unlockDisbursement.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    unlockDisbursement.UpdatedDateTime = DateTime.Today;
                    db.SubmitChanges();

                    var disbursementLines = from d in db.TrnDisbursementLines
                                            where d.CVId == id
                                            && d.RRId != null
                                            select d;

                    if (disbursementLines.Any())
                    {
                        foreach (var disbursementLine in disbursementLines)
                        {
                            Int32 RRId = Convert.ToInt32(disbursementLine.RRId);

                            Modules.TrnAccountsPayableModule accountsPayable = new Modules.TrnAccountsPayableModule();
                            accountsPayable.UpdateAccountsPayable(RRId);
                        }
                    }

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Disbursement not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===================
        // Delete Disbursement
        // ===================
        public String[] DeleteDisbursement(Int32 id)
        {
            try
            {

                var disbursement = from d in db.TrnDisbursements
                                   where d.Id == id
                                   select d;

                if (disbursement.Any())
                {
                    if (disbursement.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Already locked.", "0" };
                    }

                    var deletePurchaseOrder = disbursement.FirstOrDefault();
                    db.TrnDisbursements.DeleteOnSubmit(deletePurchaseOrder);
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Disbursement not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
