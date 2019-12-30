using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class TrnPurchaseOrderItemController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ==================
        // List Stock-In Item
        // ==================
        public List<Entities.TrnPurchaseOrderItemEntity> ListPurchaseOrderItem(Int32 POId)
        {
            var purchaseOrderItems = from d in db.TrnPurchaseOrderItems
                                     where d.POId == POId
                                     select new Entities.TrnPurchaseOrderItemEntity
                                     {
                                         Id = d.Id,
                                         POId = d.POId,
                                         ItemId = d.ItemId,
                                         ItemDescription = d.MstArticle.Article,
                                         UnitId = d.UnitId,
                                         Unit = d.MstUnit.Unit,
                                         Quantity = d.Quantity,
                                         Cost = d.Cost,
                                         Amount = d.Amount,
                                         BaseQuantity = d.BaseQuantity,
                                         BaseCost = d.BaseCost
                                     };

            return purchaseOrderItems.OrderByDescending(d => d.Id).ToList();
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

        // =======================
        // Add Purchase Order Item
        // =======================
        public String[] AddPurchaseOrderItem(Entities.TrnPurchaseOrderItemEntity objPurchaseOrderItem)
        {
            try
            {
                var purchaseOrder = from d in db.TrnPurchaseOrders
                              where d.Id == objPurchaseOrderItem.POId
                              select d;

                if (purchaseOrder.Any() == false)
                {
                    return new String[] { "Purchase order transaction not found.", "0" };
                }

                var conversionUnit = from d in db.MstArticleUnits
                                     where d.ArticleId == objPurchaseOrderItem.ItemId
                                     && d.UnitId == objPurchaseOrderItem.UnitId
                                     && d.MstArticle.IsLocked == true
                                     select d;

                if (conversionUnit.Any() == false)
                {
                    return new String[] { "Item unit not found.", "0" };
                }

                Decimal baseQuantity = objPurchaseOrderItem.Quantity;
                if (conversionUnit.FirstOrDefault().UnitMultiplier > 0)
                {
                    baseQuantity = objPurchaseOrderItem.Quantity * (conversionUnit.FirstOrDefault().BaseUnitMultiplier / conversionUnit.FirstOrDefault().UnitMultiplier);
                }

                Decimal baseCost = 0;
                if (baseQuantity > 0)
                {
                    baseCost = objPurchaseOrderItem.Amount / baseQuantity;
                }

                Data.TrnPurchaseOrderItem newPurchaseOrderItem = new Data.TrnPurchaseOrderItem
                {
                    POId = objPurchaseOrderItem.POId,
                    ItemId = objPurchaseOrderItem.ItemId,
                    UnitId = objPurchaseOrderItem.UnitId,
                    Quantity = objPurchaseOrderItem.Quantity,
                    Cost = objPurchaseOrderItem.Cost,
                    Amount = objPurchaseOrderItem.Amount,
                    BaseQuantity = baseQuantity,
                    BaseCost = baseCost
                };

                db.TrnPurchaseOrderItems.InsertOnSubmit(newPurchaseOrderItem);
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
        public String[] UpdatePurchaseOrderItem(Int32 id, Entities.TrnPurchaseOrderItemEntity objPurchaseOrderItem)
        {
            try
            {
                var purchaseOrderItem = from d in db.TrnPurchaseOrderItems
                                  where d.Id == id
                                  select d;

                if (purchaseOrderItem.Any())
                {
                    var purchaseOrder = from d in db.TrnPurchaseOrders
                                  where d.Id == objPurchaseOrderItem.POId
                                  select d;

                    if (purchaseOrder.Any() == false)
                    {
                        return new String[] { "Purchase order transaction not found.", "0" };
                    }

                    var conversionUnit = from d in db.MstArticleUnits
                                         where d.ArticleId == objPurchaseOrderItem.ItemId
                                         && d.UnitId == objPurchaseOrderItem.UnitId
                                         && d.MstArticle.IsLocked == true
                                         select d;

                    if (conversionUnit.Any() == false)
                    {
                        return new String[] { "Item unit not found.", "0" };
                    }

                    Decimal baseQuantity = objPurchaseOrderItem.Quantity;
                    if (conversionUnit.FirstOrDefault().UnitMultiplier > 0)
                    {
                        baseQuantity = objPurchaseOrderItem.Quantity * (conversionUnit.FirstOrDefault().BaseUnitMultiplier / conversionUnit.FirstOrDefault().UnitMultiplier);
                    }

                    Decimal baseCost = 0;
                    if (baseQuantity > 0)
                    {
                        baseCost = objPurchaseOrderItem.Amount / baseQuantity;
                    }

                    var updatePurchaseOrderItem = purchaseOrderItem.FirstOrDefault();
                    updatePurchaseOrderItem.ItemId = objPurchaseOrderItem.ItemId;
                    updatePurchaseOrderItem.UnitId = objPurchaseOrderItem.UnitId;
                    updatePurchaseOrderItem.Quantity = objPurchaseOrderItem.Quantity;
                    updatePurchaseOrderItem.Amount = objPurchaseOrderItem.Amount;
                    updatePurchaseOrderItem.BaseQuantity = baseQuantity;
                    updatePurchaseOrderItem.BaseCost = baseCost;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Purchase order item not found.  " + id, "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ====================
        // Update Stock-In Item
        // ====================
        public String[] DeletePurchaseOrderItem(Int32 id)
        {
            try
            {
                var purchaseOrderItem = from d in db.TrnPurchaseOrderItems
                                        where d.Id == id
                                        select d;

                if (purchaseOrderItem.Any())
                {
                    var deletePurchaseOrderItem = purchaseOrderItem.FirstOrDefault();
                    db.TrnPurchaseOrderItems.DeleteOnSubmit(deletePurchaseOrderItem);
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Purchase order item not found.  " + id, "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
