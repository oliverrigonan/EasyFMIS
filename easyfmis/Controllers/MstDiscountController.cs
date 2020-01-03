using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class MstDiscountController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ============
        // List Discount
        // ============
        public List<Entities.MstDiscountEntity> ListDiscount(String filter)
        {
            var discounts = from d in db.MstDiscounts
                           where d.Discount.Contains(filter)
                           select new Entities.MstDiscountEntity
                           {
                               Id = d.Id,
                               Discount = d.Discount,
                               DiscountRate = d.DiscountRate,
                               IsLocked = d.IsLocked,
                               CreatedBy = d.CreatedBy,
                               CreatedDateTime = d.CreatedDateTime,
                               UpdatedBy = d.UpdatedBy,
                               UpdatedByDateTime = d.UpdatedByDateTime

                           };

            return discounts.OrderByDescending(d => d.Id).ToList();
        }

        // ===========
        // Add Discount
        // ===========
        public String[] AddDiscount(Entities.MstDiscountEntity objDiscount)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                Data.MstDiscount addDiscount = new Data.MstDiscount()
                {
                    Discount = objDiscount.Discount,
                    DiscountRate = objDiscount.DiscountRate,
                    IsLocked = true,
                    CreatedBy = currentUserLogin.FirstOrDefault().Id,
                    CreatedDateTime = DateTime.Today,
                    UpdatedBy = currentUserLogin.FirstOrDefault().Id,
                    UpdatedByDateTime = DateTime.Today
                };

                db.MstDiscounts.InsertOnSubmit(addDiscount);
                db.SubmitChanges();

                return new String[] { "", "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ==============
        // Update Discount
        // ==============
        public String[] UpdateDiscount(Entities.MstDiscountEntity objDiscount)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var discount = from d in db.MstDiscounts
                              where d.Id == objDiscount.Id
                              select d;

                if (discount.Any())
                {
                    var updateDiscount = discount.FirstOrDefault();
                    updateDiscount.Discount = objDiscount.Discount;
                    updateDiscount.DiscountRate = objDiscount.DiscountRate;
                    updateDiscount.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    updateDiscount.UpdatedByDateTime = DateTime.Today;
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Discount not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ==============
        // Delete Discount
        // ==============
        public String[] DeleteDiscount(int id)
        {
            try
            {
                var discount = from d in db.MstDiscounts
                              where d.Id == id
                              select d;

                if (discount.Any())
                {
                    var deleteDiscount = discount.FirstOrDefault();
                    db.MstDiscounts.DeleteOnSubmit(deleteDiscount);
                    db.SubmitChanges();

                    return new string[] { "", "" };
                }
                else
                {
                    return new String[] { "Discount not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
