using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class TrnSalesOrderItemController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // =============
        // List Stock-In 
        // =============
        public List<Entities.TrnSalesOrderItemEntity> ListSalesOrderItem(Int32 sOId)
        {
            var salesOrderItem = from d in db.TrnSalesOrderItems
                                 where d.SOId == sOId
                                 select new Entities.TrnSalesOrderItemEntity
                                 {
                                     Id = d.Id,
                                     SOId = d.SOId,
                                     ItemId = d.ItemId,
                                     ItemDescription = d.MstArticle.Article,
                                     ItemInventoryId = d.ItemInventoryId,
                                     ItemInventoryCode = d.MstArticleInventory.InventoryCode,
                                     UnitId = d.UnitId,
                                     Unit = d.MstUnit.Unit,
                                     Price = d.Price,
                                     DiscountId = d.DiscountId,
                                     DiscountRate = d.DiscountRate,
                                     DiscountAmount = d.DiscountAmount,
                                     NetPrice = d.NetPrice,
                                     Quantity = d.Quantity,
                                     Amount = d.Amount,
                                     TaxId = d.TaxId,
                                     TaxRate = d.TaxRate,
                                     TaxAmount = d.TaxAmount,
                                     BaseQuantity = d.BaseQuantity,
                                     BasePrice = d.BasePrice,
                                 };

            return salesOrderItem.OrderByDescending(d => d.Id).ToList();
        }

        // =========
        // List Item
        // =========
        public List<Entities.MstArticleEntity> ListNonInventoryItem(String filter)
        {
            var items = from d in db.MstArticles
                        where d.ArticleTypeId == 1
                        && (d.ArticleCode.Contains(filter)
                        || d.ArticleBarCode.Contains(filter)
                        || d.Article.Contains(filter)
                        || d.Category.Contains(filter))
                        && d.IsInventory == false
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

        // =========
        // List Item
        // =========
        public List<Entities.MstArticleInventory> ListInventoryItem(String filter)
        {
            var items = from d in db.MstArticleInventories
                        where (d.InventoryCode.Contains(filter)
                        || d.MstArticle.ArticleCode.Contains(filter)
                        || d.MstArticle.ArticleBarCode.Contains(filter)
                        || d.MstArticle.Article.Contains(filter)
                        || d.MstArticle.Category.Contains(filter)
                        || d.MstArticle.MstUnit.Unit.Contains(filter))
                        && d.MstArticle.IsLocked == true
                        select new Entities.MstArticleInventory
                        {
                            Id = d.Id,
                            InventoryCode = d.InventoryCode,
                            ArticleId = d.ArticleId,
                            ArticleCode = d.MstArticle.ArticleCode,
                            ArticleBarCode = d.MstArticle.ArticleBarCode,
                            Article = d.MstArticle.Article,
                            Category = d.MstArticle.Category,
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

        // ======================
        // Dropdown List Discount
        // ======================
        public List<Entities.MstDiscountEntity> DropdownListDiscount()
        {
            var discounts = from d in db.MstDiscounts
                            where d.IsLocked == true
                            select new Entities.MstDiscountEntity
                            {
                                Id = d.Id,
                                Discount = d.Discount,
                                DiscountRate = d.DiscountRate,
                            };

            return discounts.ToList();
        }

        // ======================
        // Dropdown List Discount
        // ======================
        public List<Entities.MstTaxEntity> DropdownListTax()
        {
            var taxes = from d in db.MstTaxes
                            where d.IsLocked == true
                            select new Entities.MstTaxEntity
                            {
                                Id = d.Id,
                                Tax = d.Tax,
                                Rate = d.Rate
                            };

            return taxes.ToList();
        }

        // ========================
        // Dropdown Detail Discount
        // ========================
        public List<Entities.MstDiscountEntity> DropdownDetailDiscount(Int32 discountId)
        {
            var discounts = from d in db.MstDiscounts
                            where d.Id == discountId
                            && d.IsLocked == true
                            select new Entities.MstDiscountEntity
                            {
                                Id = d.Id,
                                Discount = d.Discount,
                                DiscountRate = d.DiscountRate,
                            };

            return discounts.ToList();
        }

        // ====================
        // Add Sales Order Item
        // ====================
        public String[] AddSalesOrderItem(Entities.TrnSalesOrderItemEntity objSalesOrderItem)
        {
            try
            {
                var salesOrderItem = from d in db.TrnSalesOrderItems
                                     where d.Id == objSalesOrderItem.SOId
                                     select d;

                if (salesOrderItem.Any() == false)
                {
                    return new String[] { "Sales order transaction not found.", "0" };
                }


                var item = from d in db.MstArticles
                           where d.Id == objSalesOrderItem.ItemId
                           && d.IsLocked == true
                           select d;

                if (item.Any() == false)
                {
                    return new String[] { "Item not found.", "0" };
                }

                var itemInventory = from d in db.MstArticleInventories
                                    where d.Id == objSalesOrderItem.ItemInventoryId
                                    select d;

                if (itemInventory.Any() == false)
                {
                    return new String[] { "Inventory code not found.", "0" };
                }

                var conversionUnit = from d in db.MstArticleUnits
                                     where d.ArticleId == objSalesOrderItem.ItemId
                                     && d.UnitId == objSalesOrderItem.UnitId
                                     && d.MstArticle.IsLocked == true
                                     select d;

                if (conversionUnit.Any() == false)
                {
                    return new String[] { "Item unit not found.", "0" };
                }

                Decimal baseQuantity = objSalesOrderItem.Quantity;
                if (conversionUnit.FirstOrDefault().UnitMultiplier > 0)
                {
                    baseQuantity = objSalesOrderItem.Quantity * (conversionUnit.FirstOrDefault().BaseUnitMultiplier / conversionUnit.FirstOrDefault().UnitMultiplier);
                }

                Decimal baseCost = 0;
                if (baseQuantity > 0)
                {
                    baseCost = objSalesOrderItem.Amount / baseQuantity;
                }

                Data.TrnSalesOrderItem newSalesOrderItem = new Data.TrnSalesOrderItem
                {
                    SOId = objSalesOrderItem.SOId,
                    ItemId = objSalesOrderItem.ItemId,
                    ItemInventoryId = objSalesOrderItem.ItemInventoryId,
                    UnitId = objSalesOrderItem.UnitId,
                    Price = objSalesOrderItem.Price,
                    DiscountId = objSalesOrderItem.DiscountId,
                    DiscountRate = objSalesOrderItem.DiscountRate,
                    DiscountAmount = objSalesOrderItem.DiscountAmount,
                    NetPrice = objSalesOrderItem.NetPrice,
                    Quantity = objSalesOrderItem.Quantity,
                    Amount = objSalesOrderItem.Amount,
                    TaxId = objSalesOrderItem.TaxId,
                    TaxRate = objSalesOrderItem.TaxRate,
                    TaxAmount = objSalesOrderItem.TaxAmount,
                    BaseQuantity = baseQuantity,
                    BasePrice = item.FirstOrDefault().DefaultPrice

                };

                db.TrnSalesOrderItems.InsertOnSubmit(newSalesOrderItem);
                db.SubmitChanges();

                return new String[] { "", "1" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =======================
        // Update Sales Order Item
        // =======================
        public String[] UpdateSalesOrderItem(Int32 id, Entities.TrnSalesOrderItemEntity objSalesOrderItem)
        {
            try
            {
                var salesOrderItem = from d in db.TrnSalesOrderItems
                                     where d.Id == id
                                     select d;

                if (salesOrderItem.Any())
                {
                    var salesOrder = from d in db.TrnSalesOrders
                                     where d.Id == objSalesOrderItem.SOId
                                     select d;

                    if (salesOrder.Any() == false)
                    {
                        return new String[] { "Sales order transaction not found.", "0" };
                    }

                    var item = from d in db.MstArticles
                               where d.Id == objSalesOrderItem.ItemId
                               && d.IsLocked == true
                               select d;

                    if (item.Any() == false)
                    {
                        return new String[] { "Item not found.", "0" };
                    }

                    var itemInventory = from d in db.MstArticleInventories
                                        where d.Id == objSalesOrderItem.ItemInventoryId
                                        select d;

                    if (itemInventory.Any() == false)
                    {
                        return new String[] { "Inventory code not found.", "0" };
                    }

                    var conversionUnit = from d in db.MstArticleUnits
                                         where d.ArticleId == objSalesOrderItem.ItemId
                                         && d.UnitId == objSalesOrderItem.UnitId
                                         && d.MstArticle.IsLocked == true
                                         select d;

                    if (conversionUnit.Any() == false)
                    {
                        return new String[] { "Item unit not found.", "0" };
                    }

                    Decimal baseQuantity = objSalesOrderItem.Quantity;
                    if (conversionUnit.FirstOrDefault().UnitMultiplier > 0)
                    {
                        baseQuantity = objSalesOrderItem.Quantity * (conversionUnit.FirstOrDefault().BaseUnitMultiplier / conversionUnit.FirstOrDefault().UnitMultiplier);
                    }

                    Decimal baseCost = 0;
                    if (baseQuantity > 0)
                    {
                        baseCost = objSalesOrderItem.Amount / baseQuantity;
                    }

                    var updateSalesOrderItem = salesOrderItem.FirstOrDefault();
                    updateSalesOrderItem.ItemId = objSalesOrderItem.ItemId;
                    updateSalesOrderItem.ItemInventoryId = objSalesOrderItem.ItemInventoryId;
                    updateSalesOrderItem.UnitId = objSalesOrderItem.UnitId;
                    updateSalesOrderItem.Price = objSalesOrderItem.Price;
                    updateSalesOrderItem.DiscountId = objSalesOrderItem.DiscountId;
                    updateSalesOrderItem.DiscountRate = objSalesOrderItem.DiscountRate;
                    updateSalesOrderItem.DiscountAmount = objSalesOrderItem.DiscountAmount;
                    updateSalesOrderItem.NetPrice = objSalesOrderItem.NetPrice;
                    updateSalesOrderItem.Quantity = objSalesOrderItem.Quantity;
                    updateSalesOrderItem.Amount = objSalesOrderItem.Amount;
                    updateSalesOrderItem.TaxId = objSalesOrderItem.TaxId;
                    updateSalesOrderItem.TaxRate = objSalesOrderItem.TaxRate;
                    updateSalesOrderItem.TaxAmount = objSalesOrderItem.TaxAmount;
                    updateSalesOrderItem.TaxAmount = objSalesOrderItem.TaxAmount;
                    updateSalesOrderItem.BaseQuantity = baseQuantity;
                    updateSalesOrderItem.BasePrice = item.FirstOrDefault().DefaultPrice;

                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Sales order item not found.  " + id, "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }



        // =======================
        // Delete Sales Order Item
        // =======================
        public String[] DeleteStockOutItem(Int32 id)
        {
            try
            {
                var salesOrderItem = from d in db.TrnSalesOrderItems
                                     where d.Id == id
                                     select d;

                if (salesOrderItem.Any())
                {
                    var deleteSalesOrderItem = salesOrderItem.FirstOrDefault();
                    db.TrnSalesOrderItems.DeleteOnSubmit(deleteSalesOrderItem);
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Sales order item not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
