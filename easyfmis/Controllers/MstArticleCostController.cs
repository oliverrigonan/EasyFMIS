using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class MstArticleCostController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // =========
        // List Cost
        // =========
        public List<Entities.MstArticleCostEntity> ListItemCost(Int32 articleId)
        {
            var costs = from d in db.MstArticleCosts
                        where d.ArticleId == articleId
                        select new Entities.MstArticleCostEntity
                        {
                            Id = d.Id,
                            ArticleId = d.ArticleId,
                            CostDescription = d.CostDescription,
                            Cost = d.Cost,
                            CurrencyId = d.CurrencyId,
                            Currency = d.MstCurrency.CurrencyCode
                        };

            return costs.ToList();
        }

        // =============
        // List Currency
        // =============
        public List<Entities.MstCurrencyEntity> ListCurrency()
        {
            var currencies = from d in db.MstCurrencies
                             select new Entities.MstCurrencyEntity
                             {
                                 Id = d.Id,
                                 CurrencyCode = d.CurrencyCode
                             };

            return currencies.ToList();
        }

        // ============
        // Add Cost
        // ============
        public String[] AddCost(Entities.MstArticleCostEntity objCost)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var article = from d in db.MstArticles
                              where d.Id == objCost.ArticleId
                              select d;
                if (article.Any() == false)
                {
                    return new String[] { "Article not found.", "0" };
                }

                var currency = from d in db.MstCurrencies
                               where d.Id == objCost.CurrencyId
                               select d;
                if (currency.Any() == false)
                {
                    return new String[] { "Currency not found.", "0" };
                }

                Data.MstArticleCost newCost = new Data.MstArticleCost()
                {
                    ArticleId = article.FirstOrDefault().Id,
                    CostDescription = objCost.CostDescription,
                    Cost = objCost.Cost,
                    CurrencyId = currency.FirstOrDefault().Id
                };

                db.MstArticleCosts.InsertOnSubmit(newCost);
                db.SubmitChanges();

                return new String[] { "", "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===========
        // Update Cost
        // ===========
        public String[] UpdateCost(Entities.MstArticleCostEntity objCost)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var cost = from d in db.MstArticleCosts
                           where d.Id == objCost.Id
                           select d;

                var currency = from d in db.MstCurrencies
                               where d.Id == objCost.CurrencyId
                               select d;
                if (currency.Any() == false)
                {
                    return new String[] { "Currency not found.", "0" };
                }

                if (cost.Any())
                {
                    var updateCost = cost.FirstOrDefault();
                    updateCost.Cost = objCost.Cost;
                    updateCost.CostDescription = objCost.CostDescription;
                    updateCost.CurrencyId = objCost.CurrencyId;

                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Cost not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new string[] { e.Message, "0" };
            }
        }

        // ===========
        // Delete Cost
        // ===========
        public String[] DeleteCost(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var cost = from d in db.MstArticleCosts
                           where d.Id == id
                           select d;

                if (cost.Any())
                {
                    db.MstArticleCosts.DeleteOnSubmit(cost.FirstOrDefault());
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Cost not found", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
