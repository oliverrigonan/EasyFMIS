using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class TrnStockOutController
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

        // ==============
        // List Stock-Out 
        // ==============
        public List<Entities.TrnStockOutEntity> ListStockOut(DateTime dateFilter, String filter)
        {
            var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
            var currentBranchId = currentUserLogin.FirstOrDefault().BranchId;

            var stockOuts = from d in db.TrnStockOuts
                            where d.OTDate == dateFilter
                            && d.OTNumber.Contains(filter)
                            && d.BranchId == currentBranchId
                            select new Entities.TrnStockOutEntity
                            {
                                Id = d.Id,
                                BranchId = d.BranchId,
                                Branch = d.MstBranch.Branch,
                                OTNumber = d.OTNumber,
                                OTDate = d.OTDate,
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

            return stockOuts.OrderByDescending(d => d.Id).ToList();
        }

        // ================
        // Detail Stock-Out
        // ================
        public Entities.TrnStockOutEntity DetailStockOut(Int32 id)
        {
            var stockOut = from d in db.TrnStockOuts
                           where d.Id == id
                           select new Entities.TrnStockOutEntity
                           {
                               Id = d.Id,
                               BranchId = d.BranchId,
                               Branch = d.MstBranch.Branch,
                               OTNumber = d.OTNumber,
                               OTDate = d.OTDate,
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

            return stockOut.FirstOrDefault();
        }

        // ====================
        // Dropdown List - User
        // ====================
        public List<Entities.MstUserEntity> DropdownListStockOutUser()
        {
            var users = from d in db.MstUsers
                        select new Entities.MstUserEntity
                        {
                            Id = d.Id,
                            FullName = d.FullName
                        };

            return users.ToList();
        }

        // =============
        // Add Stock-Out
        // =============
        public String[] AddStockOut()
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                String stockOutNumber = "0000000001";
                var lastStockOut = from d in db.TrnStockOuts.OrderByDescending(d => d.Id) select d;
                if (lastStockOut.Any())
                {
                    Int32 newOTNumber = Convert.ToInt32(lastStockOut.FirstOrDefault().OTNumber) + 1;
                    stockOutNumber = FillLeadingZeroes(newOTNumber, 10);
                }

                Data.TrnStockOut newStockOut = new Data.TrnStockOut()
                {
                    BranchId = currentUserLogin.FirstOrDefault().BranchId,
                    OTDate = DateTime.Today,
                    OTNumber = stockOutNumber,
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

                db.TrnStockOuts.InsertOnSubmit(newStockOut);
                db.SubmitChanges();

                return new String[] { "", newStockOut.Id.ToString() };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ==============
        // Lock Stock-Out
        // ==============
        public String[] LockStockOut(Int32 id, Entities.TrnStockOutEntity objStockOut)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var checkedByUser = from d in db.MstUsers
                                    where d.Id == objStockOut.CheckedBy
                                    && d.IsLocked == true
                                    select d;

                if (checkedByUser.Any() == false)
                {
                    return new String[] { "Checked by user not found.", "0" };
                }

                var approvedByUser = from d in db.MstUsers
                                     where d.Id == objStockOut.ApprovedBy
                                     && d.IsLocked == true
                                     select d;

                if (approvedByUser.Any() == false)
                {
                    return new String[] { "Approved by user not found.", "0" };
                }

                var stockOut = from d in db.TrnStockOuts
                               where d.Id == id
                               select d;

                if (stockOut.Any())
                {
                    if (stockOut.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Already locked.", "0" };
                    }

                    var lockStockOut = stockOut.FirstOrDefault();
                    lockStockOut.OTDate = Convert.ToDateTime(objStockOut.OTDate);
                    lockStockOut.Remarks = objStockOut.Remarks;
                    lockStockOut.CheckedBy = objStockOut.CheckedBy;
                    lockStockOut.ApprovedBy = objStockOut.ApprovedBy;
                    lockStockOut.IsLocked = true;
                    lockStockOut.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    lockStockOut.UpdatedDateTime = DateTime.Now;
                    db.SubmitChanges();

                    Modules.TrnInventoryModule inventory = new Modules.TrnInventoryModule();
                    inventory.InsertInventoryStockOut(id);

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock-Out not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ================
        // Unlock Stock-Out
        // ================
        public String[] UnlockStockOut(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var stockOut = from d in db.TrnStockOuts
                               where d.Id == id
                               select d;

                if (stockOut.Any())
                {
                    if (stockOut.FirstOrDefault().IsLocked == false)
                    {
                        return new String[] { "Already unlocked.", "0" };
                    }

                    var unlockStockOut = stockOut.FirstOrDefault();
                    unlockStockOut.IsLocked = false;
                    unlockStockOut.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    unlockStockOut.UpdatedDateTime = DateTime.Now;
                    db.SubmitChanges();

                    Modules.TrnInventoryModule inventory = new Modules.TrnInventoryModule();
                    inventory.DeleteInventoryStockOut(id);

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock-Out not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ================
        // Delete Stock-Out
        // ================
        public String[] DeleteStockOut(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var stockOut = from d in db.TrnStockOuts
                               where d.Id == id
                               select d;

                if (stockOut.Any())
                {
                    if (stockOut.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Stock-Out is locked", "0" };
                    }

                    var deleteStockOut = stockOut.FirstOrDefault();
                    db.TrnStockOuts.DeleteOnSubmit(deleteStockOut);
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock-Out not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
