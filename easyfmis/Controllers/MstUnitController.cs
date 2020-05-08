using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class MstUnitController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // =========
        // List Unit
        // =========
        public List<Entities.MstUnitEntity> ListUnit()
        {
            var units = from d in db.MstUnits
                        select new Entities.MstUnitEntity
                        {
                            Id = d.Id,
                            Unit = d.Unit,
                        };

            return units.OrderByDescending(d => d.Id).ToList();
        }

        // ========
        // Add Unit
        // ========
        public String[] AddUnit(Entities.MstUnitEntity objUnit)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var unit = from d in db.MstUnits
                           where d.Unit == objUnit.Unit
                           select d;
                if (unit.Any())
                {
                    return new String[] { "Unit already Exist.", "0" };
                }

                Data.MstUnit addUnit = new Data.MstUnit()
                {
                    Unit = objUnit.Unit,
                    CreatedBy = currentUserLogin.FirstOrDefault().Id,
                    CreatedDateTime = DateTime.Today,
                    UpdatedBy = currentUserLogin.FirstOrDefault().Id,
                    UpdatedDateTime = DateTime.Today
                };

                db.MstUnits.InsertOnSubmit(addUnit);
                db.SubmitChanges();

                return new String[] { "", "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===========
        // Update Unit
        // ===========
        public String[] UpdateUnit(Entities.MstUnitEntity objUnit)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var unitCheck = from d in db.MstUnits
                           where d.Unit == objUnit.Unit
                           && d.Id != objUnit.Id
                           select d;
                if (unitCheck.Any())
                {
                    return new String[] { "Unit already Exist.", "0" };
                }

                var unit = from d in db.MstUnits
                           where d.Id == objUnit.Id
                           select d;

                if (unit.Any())
                {
                    var updateUnit = unit.FirstOrDefault();
                    updateUnit.Unit = objUnit.Unit;
                    updateUnit.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    updateUnit.UpdatedDateTime = DateTime.Today;
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Unit not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===========
        // Delete Unit
        // ===========
        public String[] DeleteUnit(Int32 id)
        {
            try
            {
                var unit = from d in db.MstUnits
                           where d.Id == id
                           select d;

                if (unit.Any())
                {
                    var deleteUnit = unit.FirstOrDefault();
                    db.MstUnits.DeleteOnSubmit(deleteUnit);
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Unit not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
