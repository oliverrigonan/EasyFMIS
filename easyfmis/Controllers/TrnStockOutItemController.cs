using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class TrnStockOutItemController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ===================
        // List Stock-Out Item
        // ===================
        public List<Entities.TrnStockOutItemEntity> ListStockOutItem(Int32 OTId)
        {
            var stockOutItems = from d in db.TrnStockOutItems
                                where d.OTId == OTId
                                select new Entities.TrnStockOutItemEntity
                                {
                                    Id = d.Id,
                                    OTId = d.OTId,
                                    ItemId = d.ItemId,
                                    ItemDescription = d.MstArticle.Article,
                                    ItemInventoryId = d.ItemInventoryId,
                                    ItemInventoryCode = d.MstArticleInventory.InventoryCode,
                                    UnitId = d.UnitId,
                                    Unit = d.MstUnit.Unit,
                                    Quantity = d.Quantity,
                                    Cost = d.Cost,
                                    Amount = d.Amount,
                                    BaseCost = d.BaseCost,
                                    BaseQuantity = d.BaseQuantity
                                };

            return stockOutItems.OrderByDescending(d => d.Id).ToList();
        }

        // =========
        // List Item
        // =========
        public List<Entities.MstArticleEntity> ListItem(String filter)
        {
            var items = from d in db.MstArticles
                        where d.ArticleTypeId == 1
                        || d.ArticleCode.Contains(filter)
                        || d.ArticleBarCode.Contains(filter)
                        || d.Article.Contains(filter)
                        || d.Category.Contains(filter)
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

        // ============================
        // Dropdown List Inventory Code
        // ============================
        public List<Entities.MstArticleInventory> DropdownListArticleInventory(Int32 articleId)
        {
            var articleInventories = from d in db.MstArticleInventories
                                     where d.ArticleId == articleId
                                     select new Entities.MstArticleInventory
                                     {
                                         Id = d.Id,
                                         InventoryCode = d.InventoryCode
                                     };

            return articleInventories.ToList();
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

        // ==================
        // Add Stock-Out Item
        // ==================
        public String[] AddStockOutItem(Entities.TrnStockOutItemEntity objStockOutItem)
        {
            try
            {
                var stockOut = from d in db.TrnStockOuts
                               where d.Id == objStockOutItem.OTId
                               select d;

                if (stockOut.Any() == false)
                {
                    return new String[] { "Stock-Out transaction not found.", "0" };
                }

                var item = from d in db.MstArticles
                           where d.Id == objStockOutItem.ItemId
                           && d.IsLocked == true
                           select d;

                if (item.Any() == false)
                {
                    return new String[] { "Item not found.", "0" };
                }

                var itemInventory = from d in db.MstArticleInventories
                                    where d.Id == objStockOutItem.ItemInventoryId
                                    select d;

                if (itemInventory.Any() == false)
                {
                    return new String[] { "Inventory code not found.", "0" };
                }

                var conversionUnit = from d in db.MstArticleUnits
                                     where d.ArticleId == objStockOutItem.ItemId
                                     && d.UnitId == objStockOutItem.UnitId
                                     && d.MstArticle.IsLocked == true
                                     select d;

                if (conversionUnit.Any() == false)
                {
                    return new String[] { "Item unit not found.", "0" };
                }

                Decimal baseQuantity = objStockOutItem.Quantity;
                if (conversionUnit.FirstOrDefault().UnitMultiplier > 0)
                {
                    baseQuantity = objStockOutItem.Quantity * (conversionUnit.FirstOrDefault().BaseUnitMultiplier / conversionUnit.FirstOrDefault().UnitMultiplier);
                }

                Decimal baseCost = 0;
                if (baseQuantity > 0)
                {
                    baseCost = objStockOutItem.Amount / baseQuantity;
                }

                Data.TrnStockOutItem newStockOutItem = new Data.TrnStockOutItem
                {
                    OTId = objStockOutItem.OTId,
                    ItemId = objStockOutItem.ItemId,
                    ItemInventoryId = objStockOutItem.ItemInventoryId,
                    UnitId = objStockOutItem.UnitId,
                    Quantity = objStockOutItem.Quantity,
                    Cost = objStockOutItem.Cost,
                    Amount = objStockOutItem.Amount,
                    BaseCost = baseCost,
                    BaseQuantity = baseQuantity
                };

                db.TrnStockOutItems.InsertOnSubmit(newStockOutItem);
                db.SubmitChanges();

                return new String[] { "", "1" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =====================
        // Update Stock-Out Item
        // =====================
        public String[] UpdateStockOutItem(Int32 id, Entities.TrnStockOutItemEntity objStockOutItem)
        {
            try
            {
                var stockOutItem = from d in db.TrnStockOutItems
                                   where d.Id == id
                                   select d;

                if (stockOutItem.Any())
                {
                    var stockOut = from d in db.TrnStockOuts
                                   where d.Id == objStockOutItem.OTId
                                   select d;

                    if (stockOut.Any() == false)
                    {
                        return new String[] { "Stock-Out transaction not found.", "0" };
                    }

                    var itemInventory = from d in db.MstArticleInventories
                                        where d.Id == objStockOutItem.ItemInventoryId
                                        select d;

                    if (itemInventory.Any() == false)
                    {
                        return new String[] { "Inventory code not found.", "0" };
                    }

                    var conversionUnit = from d in db.MstArticleUnits
                                         where d.ArticleId == objStockOutItem.ItemId
                                         && d.UnitId == objStockOutItem.UnitId
                                         && d.MstArticle.IsLocked == true
                                         select d;

                    if (conversionUnit.Any() == false)
                    {
                        return new String[] { "Item unit not found.", "0" };
                    }

                    Decimal baseQuantity = objStockOutItem.Quantity;
                    if (conversionUnit.FirstOrDefault().UnitMultiplier > 0)
                    {
                        baseQuantity = objStockOutItem.Quantity * (conversionUnit.FirstOrDefault().BaseUnitMultiplier / conversionUnit.FirstOrDefault().UnitMultiplier);
                    }

                    Decimal baseCost = 0;
                    if (baseQuantity > 0)
                    {
                        baseCost = objStockOutItem.Amount / baseQuantity;
                    }

                    var updateStockOutItem = stockOutItem.FirstOrDefault();
                    updateStockOutItem.ItemInventoryId = objStockOutItem.ItemInventoryId;
                    updateStockOutItem.UnitId = objStockOutItem.UnitId;
                    updateStockOutItem.Quantity = objStockOutItem.Quantity;
                    updateStockOutItem.Cost = objStockOutItem.Cost;
                    updateStockOutItem.Amount = objStockOutItem.Amount;
                    updateStockOutItem.BaseCost = baseCost;
                    updateStockOutItem.BaseQuantity = baseQuantity;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock-Out item not found.  " + id, "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =====================
        // Delete Stock-Out Item
        // =====================
        public String[] DeleteStockOutItem(Int32 id)
        {
            try
            {
                var stockOutItem = from d in db.TrnStockOutItems
                                   where d.Id == id
                                   select d;

                if (stockOutItem.Any())
                {
                    var deleteStockOutItem = stockOutItem.FirstOrDefault();
                    db.TrnStockOutItems.DeleteOnSubmit(deleteStockOutItem);
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock-Out item not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
