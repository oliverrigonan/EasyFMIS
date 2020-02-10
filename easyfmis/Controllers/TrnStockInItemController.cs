using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class TrnStockInItemController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ==================
        // List Stock-In Item
        // ==================
        public List<Entities.TrnStockInItemEntity> ListStockInItem(Int32 INId)
        {
            var stockInItems = from d in db.TrnStockInItems
                               where d.INId == INId
                               select new Entities.TrnStockInItemEntity
                               {
                                   Id = d.Id,
                                   INId = d.INId,
                                   ItemBarCode = d.MstArticle.ArticleBarCode,
                                   ItemId = d.ItemId,
                                   ItemDescription = d.MstArticle.Article,
                                   UnitId = d.UnitId,
                                   Unit = d.MstUnit.Unit,
                                   Quantity = d.Quantity,
                                   Cost = d.Cost,
                                   Amount = d.Amount,
                                   BaseCost = d.BaseCost,
                                   BaseQuantity = d.BaseQuantity
                               };

            return stockInItems.OrderByDescending(d => d.Id).ToList();
        }

        // =========
        // List Item
        // =========
        public List<Entities.MstArticleEntity> ListItem(String filter)
        {
            var items = from d in db.MstArticles
                        where d.ArticleTypeId == 1
                        && (d.ArticleBarCode.Contains(filter)
                        || d.Article.Contains(filter)
                        || d.MstUnit.Unit.Contains(filter))
                        && d.IsLocked == true
                        select new Entities.MstArticleEntity
                        {
                            Id = d.Id,
                            ArticleCode = d.ArticleCode,
                            ArticleBarCode = d.ArticleBarCode,
                            Article = d.Article,
                            Category = d.Category,
                            UnitId = d.UnitId,
                            Unit = d.MstUnit.Unit,
                            DefaultPrice = d.DefaultPrice
                        };

            return items.OrderBy(d => d.Article).ToList();
        }

        // ==========================
        // Dropdown List Article Unit
        // ==========================
        public List<Entities.MstArticleUnitEntity> DropdownListArticleUnit(Int32 articleId)
        {
            var articleUnits = from d in db.MstArticleUnits
                               where d.ArticleId == articleId
                               select new Entities.MstArticleUnitEntity
                               {
                                   UnitId = d.UnitId,
                                   Unit = d.MstUnit.Unit
                               };

            return articleUnits.ToList();
        }

        // =================
        // Add Stock-In Item
        // =================
        public String[] AddStockInItem(Entities.TrnStockInItemEntity objStockInItem)
        {
            try
            {
                var stockIn = from d in db.TrnStockIns
                              where d.Id == objStockInItem.INId
                              select d;

                if (stockIn.Any() == false)
                {
                    return new String[] { "Stock-In transaction not found.", "0" };
                }


                var conversionUnit = from d in db.MstArticleUnits
                                     where d.ArticleId == objStockInItem.ItemId
                                     && d.UnitId == objStockInItem.UnitId
                                     && d.MstArticle.IsLocked == true
                                     select d;

                if (conversionUnit.Any() == false)
                {
                    return new String[] { "Item unit not found.", "0" };
                }

                Decimal baseQuantity = objStockInItem.Quantity;
                if (conversionUnit.FirstOrDefault().UnitMultiplier > 0)
                {
                    baseQuantity = objStockInItem.Quantity * (conversionUnit.FirstOrDefault().BaseUnitMultiplier / conversionUnit.FirstOrDefault().UnitMultiplier);
                }

                Decimal baseCost = 0;
                if (baseQuantity > 0)
                {
                    baseCost = objStockInItem.Amount / baseQuantity;
                }

                Data.TrnStockInItem newStockInItem = new Data.TrnStockInItem
                {
                    INId = objStockInItem.INId,
                    ItemId = objStockInItem.ItemId,
                    UnitId = objStockInItem.UnitId,
                    Quantity = objStockInItem.Quantity,
                    Cost = objStockInItem.Cost,
                    Amount = objStockInItem.Amount,
                    BaseCost = baseCost,
                    BaseQuantity = baseQuantity
                };

                db.TrnStockInItems.InsertOnSubmit(newStockInItem);
                db.SubmitChanges();

                return new String[] { "", "1" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ====================
        // Update Stock-In Item
        // ====================
        public String[] UpdateStockInItem(Int32 id, Entities.TrnStockInItemEntity objStockInItem)
        {
            try
            {
                var stockInItem = from d in db.TrnStockInItems
                                  where d.Id == id
                                  select d;

                if (stockInItem.Any())
                {
                    var stockIn = from d in db.TrnStockIns
                                  where d.Id == objStockInItem.INId
                                  select d;

                    if (stockIn.Any() == false)
                    {
                        return new String[] { "Stock-In transaction not found.", "0" };
                    }

                    var conversionUnit = from d in db.MstArticleUnits
                                         where d.ArticleId == objStockInItem.ItemId
                                         && d.UnitId == objStockInItem.UnitId
                                         && d.MstArticle.IsLocked == true
                                         select d;

                    if (conversionUnit.Any() == false)
                    {
                        return new String[] { "Item unit not found.", "0" };
                    }

                    Decimal baseQuantity = objStockInItem.Quantity;
                    if (conversionUnit.FirstOrDefault().UnitMultiplier > 0)
                    {
                        baseQuantity = objStockInItem.Quantity * (conversionUnit.FirstOrDefault().BaseUnitMultiplier / conversionUnit.FirstOrDefault().UnitMultiplier);
                    }

                    Decimal baseCost = 0;
                    if (baseQuantity > 0)
                    {
                        baseCost = objStockInItem.Amount / baseQuantity;
                    }

                    var updateStockInItem = stockInItem.FirstOrDefault();
                    updateStockInItem.UnitId = objStockInItem.UnitId;
                    updateStockInItem.Quantity = objStockInItem.Quantity;
                    updateStockInItem.Cost = objStockInItem.Cost;
                    updateStockInItem.Amount = objStockInItem.Amount;
                    updateStockInItem.BaseCost = baseCost;
                    updateStockInItem.BaseQuantity = baseQuantity;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock-In item not found.  " + id, "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ====================
        // Delete Stock-In Item
        // ====================
        public String[] DeleteStockInItem(Int32 id)
        {
            try
            {
                var stockInItem = from d in db.TrnStockInItems
                                  where d.Id == id
                                  select d;

                if (stockInItem.Any())
                {
                    var deleteStockInItem = stockInItem.FirstOrDefault();
                    db.TrnStockInItems.DeleteOnSubmit(deleteStockInItem);
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock-In item not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
