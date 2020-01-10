using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class TrnStockTransferItemController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ========================
        // List Stock Transfer Item
        // ========================
        public List<Entities.TrnStockTransferItemEntity> ListStockTransferItem(Int32 STId)
        {
            var stockOutItems = from d in db.TrnStockTransferItems
                                where d.STId == STId
                                select new Entities.TrnStockTransferItemEntity
                                {
                                    Id = d.Id,
                                    STId = d.STId,
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
        public List<Entities.MstArticleInventory> ListInventoryItem(String filter)
        {
            var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
            var currentBranchId = currentUserLogin.FirstOrDefault().BranchId;

            var items = from d in db.MstArticleInventories
                        where (d.InventoryCode.Contains(filter)
                        || d.MstArticle.ArticleBarCode.Contains(filter)
                        || d.MstArticle.Article.Contains(filter)
                        || d.MstArticle.MstUnit.Unit.Contains(filter))
                        && d.MstArticle.IsLocked == true
                        && d.BranchId == currentBranchId
                        && d.Quantity > 0
                        select new Entities.MstArticleInventory
                        {
                            Id = d.Id,
                            InventoryCode = d.InventoryCode,
                            ArticleId = d.ArticleId,
                            ArticleCode = d.MstArticle.ArticleCode,
                            ArticleBarCode = d.MstArticle.ArticleBarCode,
                            Article = d.MstArticle.Article,
                            UnitId = d.MstArticle.UnitId,
                            Unit = d.MstArticle.MstUnit.Unit,
                            DefaultPrice = d.MstArticle.DefaultPrice,
                            Cost = d.Cost1,
                            Quantity = d.Quantity
                        };

            return items.OrderBy(d => d.Article).ToList();
        }

        // ============================
        // Dropdown List Inventory Code
        // ============================
        public List<Entities.MstArticleInventory> DropdownListArticleInventory(Int32 articleId)
        {
            var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
            var currentBranchId = currentUserLogin.FirstOrDefault().BranchId;

            var articleInventories = from d in db.MstArticleInventories
                                     where d.ArticleId == articleId
                                     && d.BranchId == currentBranchId
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

        // =======================
        // Add Stock Transfer Item
        // =======================
        public String[] AddStockTransferItem(Entities.TrnStockTransferItemEntity objStockTransferItem)
        {
            try
            {
                var stockOut = from d in db.TrnStockTransfers
                               where d.Id == objStockTransferItem.STId
                               select d;

                if (stockOut.Any() == false)
                {
                    return new String[] { "Stock Transfer transaction not found.", "0" };
                }

                var item = from d in db.MstArticles
                           where d.Id == objStockTransferItem.ItemId
                           && d.IsLocked == true
                           select d;

                if (item.Any() == false)
                {
                    return new String[] { "Item not found.", "0" };
                }

                var itemInventory = from d in db.MstArticleInventories
                                    where d.Id == objStockTransferItem.ItemInventoryId
                                    select d;

                if (itemInventory.Any() == false)
                {
                    return new String[] { "Inventory code not found.", "0" };
                }

                var conversionUnit = from d in db.MstArticleUnits
                                     where d.ArticleId == objStockTransferItem.ItemId
                                     && d.UnitId == objStockTransferItem.UnitId
                                     && d.MstArticle.IsLocked == true
                                     select d;

                if (conversionUnit.Any() == false)
                {
                    return new String[] { "Item unit not found.", "0" };
                }

                Decimal baseQuantity = objStockTransferItem.Quantity;
                if (conversionUnit.FirstOrDefault().UnitMultiplier > 0)
                {
                    baseQuantity = objStockTransferItem.Quantity * (conversionUnit.FirstOrDefault().BaseUnitMultiplier / conversionUnit.FirstOrDefault().UnitMultiplier);
                }

                Decimal baseCost = 0;
                if (baseQuantity > 0)
                {
                    baseCost = objStockTransferItem.Amount / baseQuantity;
                }

                Data.TrnStockTransferItem newStockTransferItem = new Data.TrnStockTransferItem
                {
                    STId = objStockTransferItem.STId,
                    ItemId = objStockTransferItem.ItemId,
                    ItemInventoryId = objStockTransferItem.ItemInventoryId,
                    UnitId = objStockTransferItem.UnitId,
                    Quantity = objStockTransferItem.Quantity,
                    Cost = objStockTransferItem.Cost,
                    Amount = objStockTransferItem.Amount,
                    BaseCost = baseCost,
                    BaseQuantity = baseQuantity
                };

                db.TrnStockTransferItems.InsertOnSubmit(newStockTransferItem);
                db.SubmitChanges();

                return new String[] { "", "1" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ==========================
        // Update Stock Transfer Item
        // ==========================
        public String[] UpdateStockTransferItem(Int32 id, Entities.TrnStockTransferItemEntity objStockTransferItem)
        {
            try
            {
                var stockOutItem = from d in db.TrnStockTransferItems
                                   where d.Id == id
                                   select d;

                if (stockOutItem.Any())
                {
                    var stockOut = from d in db.TrnStockTransfers
                                   where d.Id == objStockTransferItem.STId
                                   select d;

                    if (stockOut.Any() == false)
                    {
                        return new String[] { "Stock Transfer transaction not found.", "0" };
                    }

                    var itemInventory = from d in db.MstArticleInventories
                                        where d.Id == objStockTransferItem.ItemInventoryId
                                        select d;

                    if (itemInventory.Any() == false)
                    {
                        return new String[] { "Inventory code not found.", "0" };
                    }

                    var conversionUnit = from d in db.MstArticleUnits
                                         where d.ArticleId == objStockTransferItem.ItemId
                                         && d.UnitId == objStockTransferItem.UnitId
                                         && d.MstArticle.IsLocked == true
                                         select d;

                    if (conversionUnit.Any() == false)
                    {
                        return new String[] { "Item unit not found.", "0" };
                    }

                    Decimal baseQuantity = objStockTransferItem.Quantity;
                    if (conversionUnit.FirstOrDefault().UnitMultiplier > 0)
                    {
                        baseQuantity = objStockTransferItem.Quantity * (conversionUnit.FirstOrDefault().BaseUnitMultiplier / conversionUnit.FirstOrDefault().UnitMultiplier);
                    }

                    Decimal baseCost = 0;
                    if (baseQuantity > 0)
                    {
                        baseCost = objStockTransferItem.Amount / baseQuantity;
                    }

                    var updateStockTransferItem = stockOutItem.FirstOrDefault();
                    updateStockTransferItem.ItemInventoryId = objStockTransferItem.ItemInventoryId;
                    updateStockTransferItem.UnitId = objStockTransferItem.UnitId;
                    updateStockTransferItem.Quantity = objStockTransferItem.Quantity;
                    updateStockTransferItem.Cost = objStockTransferItem.Cost;
                    updateStockTransferItem.Amount = objStockTransferItem.Amount;
                    updateStockTransferItem.BaseCost = baseCost;
                    updateStockTransferItem.BaseQuantity = baseQuantity;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock Transfer item not found.  " + id, "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ==========================
        // Delete Stock Transfer Item
        // ==========================
        public String[] DeleteStockTransferItem(Int32 id)
        {
            try
            {
                var stockOutItem = from d in db.TrnStockTransferItems
                                   where d.Id == id
                                   select d;

                if (stockOutItem.Any())
                {
                    var deleteStockTransferItem = stockOutItem.FirstOrDefault();
                    db.TrnStockTransferItems.DeleteOnSubmit(deleteStockTransferItem);
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock Transfer item not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
