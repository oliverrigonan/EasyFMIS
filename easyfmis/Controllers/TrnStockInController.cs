using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class TrnStockInController
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

        // =============
        // List Stock-In 
        // =============
        public List<Entities.TrnStockInEntity> ListStockIn(DateTime dateFilter, String filter)
        {
            var stockIns = from d in db.TrnStockIns
                           where d.INDate == dateFilter
                           && d.INNumber.Contains(filter)
                           select new Entities.TrnStockInEntity
                           {
                               Id = d.Id,
                               BranchId = d.BranchId,
                               INNumber = d.INNumber,
                               INDate = d.INDate,
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

            return stockIns.OrderByDescending(d => d.Id).ToList();
        }

        // ===============
        // Detail Stock-In
        // ===============
        public Entities.TrnStockInEntity DetailStockIn(Int32 id)
        {
            var stockIn = from d in db.TrnStockIns
                          where d.Id == id
                          select new Entities.TrnStockInEntity
                          {
                              Id = d.Id,
                              BranchId = d.BranchId,
                              INNumber = d.INNumber,
                              INDate = d.INDate,
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

            return stockIn.FirstOrDefault();
        }

        // ====================
        // Dropdown List - User
        // ====================
        public List<Entities.MstUserEntity> DropdownListStockInUser()
        {
            var users = from d in db.MstUsers
                        select new Entities.MstUserEntity
                        {
                            Id = d.Id,
                            FullName = d.FullName
                        };

            return users.ToList();
        }

        // ============ 
        // Add Stock-In
        // ============
        public String[] AddStockIn()
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                String stockInNumber = "0000000001";
                var lastStockIn = from d in db.TrnStockIns.OrderByDescending(d => d.Id) select d;
                if (lastStockIn.Any())
                {
                    Int32 newINNumber = Convert.ToInt32(lastStockIn.FirstOrDefault().INNumber) + 1;
                    stockInNumber = FillLeadingZeroes(newINNumber, 10);
                }

                Data.TrnStockIn newStockIn = new Data.TrnStockIn()
                {
                    BranchId = currentUserLogin.FirstOrDefault().BranchId,
                    INDate = DateTime.Today,
                    INNumber = stockInNumber,
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

                db.TrnStockIns.InsertOnSubmit(newStockIn);
                db.SubmitChanges();

                return new String[] { "", newStockIn.Id.ToString() };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =============
        // Lock Stock-In
        // =============
        public String[] LockStockIn(Int32 id, Entities.TrnStockInEntity objStockIn)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var checkedByUser = from d in db.MstUsers
                                    where d.Id == objStockIn.CheckedBy
                                    && d.IsLocked == true
                                    select d;

                if (checkedByUser.Any() == false)
                {
                    return new String[] { "Checked by user not found.", "0" };
                }

                var approvedByUser = from d in db.MstUsers
                                     where d.Id == objStockIn.ApprovedBy
                                     && d.IsLocked == true
                                     select d;

                if (approvedByUser.Any() == false)
                {
                    return new String[] { "Approved by user not found.", "0" };
                }

                var stockIn = from d in db.TrnStockIns
                              where d.Id == id
                              select d;

                if (stockIn.Any())
                {
                    if (stockIn.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Already locked.", "0" };
                    }

                    var lockStockIn = stockIn.FirstOrDefault();
                    lockStockIn.INDate = Convert.ToDateTime(objStockIn.INDate);
                    lockStockIn.Remarks = objStockIn.Remarks;
                    lockStockIn.CheckedBy = objStockIn.CheckedBy;
                    lockStockIn.ApprovedBy = objStockIn.ApprovedBy;
                    lockStockIn.IsLocked = true;
                    lockStockIn.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    lockStockIn.UpdatedDateTime = DateTime.Now;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock-In not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===============
        // Unlock Stock-In
        // ===============
        public String[] UnlockStockIn(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var stockIn = from d in db.TrnStockIns
                              where d.Id == id
                              select d;

                if (stockIn.Any())
                {
                    if (stockIn.FirstOrDefault().IsLocked == false)
                    {
                        return new String[] { "Already unlocked.", "0" };
                    }

                    var unlockStockIn = stockIn.FirstOrDefault();
                    unlockStockIn.IsLocked = false;
                    unlockStockIn.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    unlockStockIn.UpdatedDateTime = DateTime.Now;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock-In not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===============
        // Delete Stock-In
        // ===============
        public String[] DeleteStockIn(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var stockIn = from d in db.TrnStockIns
                              where d.Id == id
                              select d;

                if (stockIn.Any())
                {
                    if (stockIn.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Stock-In is locked", "0" };
                    }

                    var deleteStockIn = stockIn.FirstOrDefault();
                    db.TrnStockIns.DeleteOnSubmit(deleteStockIn);
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock-In not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
