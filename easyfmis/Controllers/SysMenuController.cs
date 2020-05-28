using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class SysMenuController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ============
        // List Article
        // ============
        public List<Entities.SysMenuItemListEntity> ListArticle(Int32 articleTypeId)
        {
            var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
            var currentBranchId = currentUserLogin.FirstOrDefault().BranchId;

            var item = from d in db.MstArticles
                       where d.IsLocked == true
                       select new Entities.SysMenuItemListEntity
                       {
                           Id = d.Id,
                           ItemCode = d.ArticleBarCode,
                           ItemDescription = d.Article,
                           Unit = d.MstUnit.Unit,
                       };

            var itemInventory = from d in db.MstArticleInventories
                                where d.BranchId == currentBranchId
                                select d;

            var joinItemItemInventory = from d in item
                                        join e in itemInventory
                                        on d.Id equals e.ArticleId
                                        into f
                                        from g in f.DefaultIfEmpty()
                                        select new Entities.SysMenuItemListEntity
                                        {
                                            Id = d.Id,
                                            ItemCode = d.ItemCode,
                                            ItemDescription = d.ItemDescription,
                                            OnHandQuatity = g.Quantity,
                                            Unit = d.Unit,
                                        };

            return joinItemItemInventory.OrderByDescending(d => d.ItemCode).ToList();
        }

        public List<Entities.MstArticleCostEntity> GetCostList(Int32 itemId)
        {
            var costList = from d in db.MstArticleCosts
                           where d.ArticleId == itemId
                           select new Entities.MstArticleCostEntity
                           {
                               Id = d.Id,
                               ArticleId = d.ArticleId,
                               CostDescription = d.CostDescription,
                               Cost = d.Cost,
                               CurrencyId = d.CurrencyId,
                               Currency = d.MstCurrency.CurrencyCode
                           };

            return costList.ToList();
        }

        public List<Entities.MstArticlePriceEntity> GetPriceList(Int32 ItemId)
        {
            var priceList = from d in db.MstArticlePrices
                            where d.ArticleId == ItemId
                            select new Entities.MstArticlePriceEntity
                            {
                                Id = d.Id,
                                ArticleId = d.ArticleId,
                                PriceDescription = d.PriceDescription,
                                Price = d.Price
                            };

            return priceList.ToList();
        }
    }
}
