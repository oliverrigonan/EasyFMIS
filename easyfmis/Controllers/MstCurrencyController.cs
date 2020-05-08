using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class MstCurrencyController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // =============
        // List Currency
        // =============
        public List<Entities.MstCurrencyEntity> ListCurrency()
        {
            var currencies = from d in db.MstCurrencies
                            select new Entities.MstCurrencyEntity
                            {
                                Id = d.Id,
                                CurrencyCode = d.CurrencyCode,
                                Currency = d.Currency
                            };

            return currencies.OrderByDescending(d => d.Id).ToList();
        }

        // ============
        // Add Currency
        // ============
        public String[] AddCurrency(Entities.MstCurrencyEntity objCurrency)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                Data.MstCurrency newCurrency = new Data.MstCurrency()
                {
                    CurrencyCode = objCurrency.CurrencyCode,
                    Currency = objCurrency.Currency
                };

                db.MstCurrencies.InsertOnSubmit(newCurrency);
                db.SubmitChanges();

                return new String[] { "", "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===============
        // Update Currency
        // ===============
        public String[] UpdateCurrency(Entities.MstCurrencyEntity objCurrency)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var currency = from d in db.MstCurrencies
                              where d.Id == objCurrency.Id
                              select d;

                if (currency.Any())
                {
                    var updateCurrency = currency.FirstOrDefault();
                    updateCurrency.CurrencyCode = objCurrency.CurrencyCode;
                    updateCurrency.Currency = objCurrency.Currency;
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Currency not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new string[] { e.Message, "0" };
            }
        }

        // ===============
        // Delete Currency
        // ===============
        public String[] DeleteCurrency(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var currency = from d in db.MstCurrencies
                               where d.Id == id
                               select d;

                if (currency.Any())
                {
                    var deleteCurrency = currency.FirstOrDefault();
                    db.MstCurrencies.DeleteOnSubmit(deleteCurrency);
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Currency not found", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
