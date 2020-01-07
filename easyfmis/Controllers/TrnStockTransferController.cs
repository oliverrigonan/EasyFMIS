using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class TrnStockTransferController
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
        // List Stock Transfer
        // ===================
        public List<Entities.TrnStockTransferEntity> ListStockTransfer(DateTime startDateFilter, DateTime endDateFilter, String filter)
        {
            var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
            var currentBranchId = currentUserLogin.FirstOrDefault().BranchId;

            var stockTransfers = from d in db.TrnStockTransfers
                                 where d.STDate >= startDateFilter
                                 && d.STDate >= endDateFilter
                                 && d.BranchId == currentBranchId
                                 && (d.STNumber.Contains(filter)
                                 || d.Remarks.Contains(filter)
                                 || d.MstBranch1.Branch.Contains(filter))
                                 select new Entities.TrnStockTransferEntity
                                 {
                                     Id = d.Id,
                                     BranchId = d.BranchId,
                                     Branch = d.MstBranch.Branch,
                                     STNumber = d.STNumber,
                                     STDate = d.STDate,
                                     ToBranchId = d.ToBranchId,
                                     ToBranch = d.MstBranch1.Branch,
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

            return stockTransfers.OrderByDescending(d => d.Id).ToList();
        }

        // =====================
        // Detail Stock Transfer
        // =====================
        public Entities.TrnStockTransferEntity DetailStockTransfer(Int32 id)
        {
            var stockTransfer = from d in db.TrnStockTransfers
                                where d.Id == id
                                select new Entities.TrnStockTransferEntity
                                {
                                    Id = d.Id,
                                    BranchId = d.BranchId,
                                    Branch = d.MstBranch.Branch,
                                    STNumber = d.STNumber,
                                    STDate = d.STDate,
                                    ToBranchId = d.ToBranchId,
                                    ToBranch = d.MstBranch1.Branch,
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

            return stockTransfer.FirstOrDefault();
        }

        // ====================
        // Dropdown List - User
        // ====================
        public List<Entities.MstUserEntity> DropdownListStockTransferUser()
        {
            var users = from d in db.MstUsers
                        select new Entities.MstUserEntity
                        {
                            Id = d.Id,
                            FullName = d.FullName
                        };

            return users.ToList();
        }

        // =========================
        // Dropdown List - To Branch
        // =========================
        public List<Entities.MstBranchEntity> DropdownListStockTransferToBranch()
        {
            var branches = from d in db.MstBranches
                           select new Entities.MstBranchEntity
                           {
                               Id = d.Id,
                               Branch = d.Branch
                           };

            return branches.ToList();
        }

        // ==================
        // Add Stock Transfer
        // ==================
        public String[] AddStockTransfer()
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var currentBranchId = currentUserLogin.FirstOrDefault().BranchId;

                String stockTransferNumber = "0000000001";
                var lastStockTransfer = from d in db.TrnStockTransfers.OrderByDescending(d => d.Id)
                                        where d.BranchId == currentBranchId
                                        select d;
                if (lastStockTransfer.Any())
                {
                    Int32 newSTNumber = Convert.ToInt32(lastStockTransfer.FirstOrDefault().STNumber) + 1;
                    stockTransferNumber = FillLeadingZeroes(newSTNumber, 10);
                }

                Data.TrnStockTransfer newStockTransfer = new Data.TrnStockTransfer()
                {
                    BranchId = currentUserLogin.FirstOrDefault().BranchId,
                    STDate = DateTime.Today,
                    STNumber = stockTransferNumber,
                    ToBranchId = currentUserLogin.FirstOrDefault().BranchId,
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

                db.TrnStockTransfers.InsertOnSubmit(newStockTransfer);
                db.SubmitChanges();

                return new String[] { "", newStockTransfer.Id.ToString() };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===================
        // Lock Stock Transfer
        // ===================
        public String[] LockStockTransfer(Int32 id, Entities.TrnStockTransferEntity objStockTransfer)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var toBranch = from d in db.MstBranches
                               where d.Id == objStockTransfer.ToBranchId
                               && d.MstCompany.IsLocked == true
                               select d;

                if (toBranch.Any() == false)
                {
                    return new String[] { "Branch not found.", "0" };
                }

                var checkedByUser = from d in db.MstUsers
                                    where d.Id == objStockTransfer.CheckedBy
                                    && d.IsLocked == true
                                    select d;

                if (checkedByUser.Any() == false)
                {
                    return new String[] { "Checked by user not found.", "0" };
                }

                var approvedByUser = from d in db.MstUsers
                                     where d.Id == objStockTransfer.ApprovedBy
                                     && d.IsLocked == true
                                     select d;

                if (approvedByUser.Any() == false)
                {
                    return new String[] { "Approved by user not found.", "0" };
                }

                var stockTransfer = from d in db.TrnStockTransfers
                                    where d.Id == id
                                    select d;

                if (stockTransfer.Any())
                {
                    if (stockTransfer.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Already locked.", "0" };
                    }

                    var lockStockTransfer = stockTransfer.FirstOrDefault();
                    lockStockTransfer.STDate = Convert.ToDateTime(objStockTransfer.STDate);
                    lockStockTransfer.ToBranchId = objStockTransfer.ToBranchId;
                    lockStockTransfer.Remarks = objStockTransfer.Remarks;
                    lockStockTransfer.CheckedBy = objStockTransfer.CheckedBy;
                    lockStockTransfer.ApprovedBy = objStockTransfer.ApprovedBy;
                    lockStockTransfer.IsLocked = true;
                    lockStockTransfer.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    lockStockTransfer.UpdatedDateTime = DateTime.Now;
                    db.SubmitChanges();

                    Modules.TrnInventoryModule inventory = new Modules.TrnInventoryModule();
                    inventory.InsertInventoryStockTransfer(id);

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock Transfer not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =====================
        // Unlock Stock Transfer
        // =====================
        public String[] UnlockStockTransfer(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var stockTransfer = from d in db.TrnStockTransfers
                                    where d.Id == id
                                    select d;

                if (stockTransfer.Any())
                {
                    if (stockTransfer.FirstOrDefault().IsLocked == false)
                    {
                        return new String[] { "Already unlocked.", "0" };
                    }

                    var unlockStockTransfer = stockTransfer.FirstOrDefault();
                    unlockStockTransfer.IsLocked = false;
                    unlockStockTransfer.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    unlockStockTransfer.UpdatedDateTime = DateTime.Now;
                    db.SubmitChanges();

                    Modules.TrnInventoryModule inventory = new Modules.TrnInventoryModule();
                    inventory.DeleteInventoryStockTransfer(id);

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock Transfer not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =====================
        // Delete Stock Transfer
        // =====================
        public String[] DeleteStockTransfer(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var stockTransfer = from d in db.TrnStockTransfers
                                    where d.Id == id
                                    select d;

                if (stockTransfer.Any())
                {
                    if (stockTransfer.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Stock Transfer is locked", "0" };
                    }

                    var deleteStockTransfer = stockTransfer.FirstOrDefault();
                    db.TrnStockTransfers.DeleteOnSubmit(deleteStockTransfer);
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock Transfer not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
