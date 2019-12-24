using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class TrnReceivingReceiptItemController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ===========================
        // List Receiving Receipt Item
        // ===========================
        public List<Entities.TrnReceivingReceiptItemEntity> ListReceivingReceiptItem(Int32 RRId)
        {
            var receivingReceiptItems = from d in db.TrnReceivingReceiptItems
                                        where d.RRId == RRId
                                        select new Entities.TrnReceivingReceiptItemEntity
                                        {
                                            Id = d.Id,
                                            RRId = d.RRId,
                                            POId = d.POId,
                                            ItemId = d.ItemId,
                                            ItemDescription = d.MstArticle.Article,
                                            UnitId = d.UnitId,
                                            Unit = d.MstUnit.Unit,
                                            Quantity = d.Quantity,
                                            Cost = d.Cost,
                                            Amount = d.Amount,
                                            TaxId = d.TaxId,
                                            Tax = d.MstTax.Tax,
                                            TaxRate = d.TaxRate,
                                            TaxAmount = d.TaxAmount,
                                            BranchId = d.BranchId,
                                            Branch = d.MstBranch.Branch,
                                            BaseQuantity = d.BaseQuantity,
                                            BaseCost = d.BaseCost
                                        };

            return receivingReceiptItems.OrderByDescending(d => d.Id).ToList();
        }

        // ===================
        // List Inventory Item
        // ===================
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
                            VATOutTaxId = d.MstArticle.VATOutTaxId,
                            VATOutTaxRate = d.MstArticle.MstTax1.Rate
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

        // ===================
        // Dropdown List - Tax
        // ===================
        public List<Entities.MstTaxEntity> DropdownListReceivingReceiptTax()
        {
            var terms = from d in db.MstTaxes
                        select new Entities.MstTaxEntity
                        {
                            Id = d.Id,
                            Tax = d.Tax,
                            Rate = d.Rate
                        };

            return terms.ToList();
        }

        // ==========================
        // Add Receiving Receipt Item
        // ==========================
        public String[] AddReceivingReceiptItem(Entities.TrnReceivingReceiptItemEntity objReceivingReceiptItem)
        {
            try
            {
                var receivingReceipt = from d in db.TrnReceivingReceipts
                                       where d.Id == objReceivingReceiptItem.RRId
                                       select d;

                if (receivingReceipt.Any() == false)
                {
                    return new String[] { "Receiving Receipt transaction not found.", "0" };
                }

                var item = from d in db.MstArticles
                           where d.Id == objReceivingReceiptItem.ItemId
                           && d.IsLocked == true
                           select d;

                if (item.Any() == false)
                {
                    return new String[] { "Item not found.", "0" };
                }

                var tax = from d in db.MstTaxes
                          where d.Id == objReceivingReceiptItem.TaxId
                          select d;

                if (tax.Any() == false)
                {
                    return new String[] { "Tax not found.", "0" };
                }

                var conversionUnit = from d in db.MstArticleUnits
                                     where d.ArticleId == objReceivingReceiptItem.ItemId
                                     && d.UnitId == objReceivingReceiptItem.UnitId
                                     && d.MstArticle.IsLocked == true
                                     select d;

                if (conversionUnit.Any() == false)
                {
                    return new String[] { "Item unit not found.", "0" };
                }

                Decimal baseQuantity = objReceivingReceiptItem.Quantity;
                if (conversionUnit.FirstOrDefault().UnitMultiplier > 0)
                {
                    baseQuantity = objReceivingReceiptItem.Quantity * (conversionUnit.FirstOrDefault().BaseUnitMultiplier / conversionUnit.FirstOrDefault().UnitMultiplier);
                }

                Decimal baseCost = 0;
                if (baseQuantity > 0)
                {
                    baseCost = objReceivingReceiptItem.Amount / baseQuantity;
                }

                Data.TrnReceivingReceiptItem newReceivingReceiptItem = new Data.TrnReceivingReceiptItem
                {
                    RRId = objReceivingReceiptItem.RRId,
                    POId = objReceivingReceiptItem.POId,
                    ItemId = objReceivingReceiptItem.ItemId,
                    UnitId = objReceivingReceiptItem.UnitId,
                    Cost = objReceivingReceiptItem.Cost,
                    Quantity = objReceivingReceiptItem.Quantity,
                    Amount = objReceivingReceiptItem.Amount,
                    TaxId = objReceivingReceiptItem.TaxId,
                    TaxRate = objReceivingReceiptItem.TaxRate,
                    TaxAmount = objReceivingReceiptItem.TaxAmount,
                    BranchId = objReceivingReceiptItem.BranchId,
                    BaseQuantity = baseQuantity,
                    BaseCost = baseCost
                };

                db.TrnReceivingReceiptItems.InsertOnSubmit(newReceivingReceiptItem);
                db.SubmitChanges();

                return new String[] { "", "1" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =============================
        // Update Receiving Receipt Item
        // =============================
        public String[] UpdateReceivingReceiptItem(Int32 id, Entities.TrnReceivingReceiptItemEntity objReceivingReceiptItem)
        {
            try
            {
                var receivingReceiptItem = from d in db.TrnReceivingReceiptItems
                                           where d.Id == id
                                           select d;

                if (receivingReceiptItem.Any())
                {
                    var receivingReceipt = from d in db.TrnReceivingReceipts
                                           where d.Id == objReceivingReceiptItem.RRId
                                           select d;

                    if (receivingReceipt.Any() == false)
                    {
                        return new String[] { "Receiving Receipt transaction not found.", "0" };
                    }

                    var tax = from d in db.MstTaxes
                              where d.Id == objReceivingReceiptItem.TaxId
                              select d;

                    if (tax.Any() == false)
                    {
                        return new String[] { "Tax not found.", "0" };
                    }

                    var conversionUnit = from d in db.MstArticleUnits
                                         where d.ArticleId == objReceivingReceiptItem.ItemId
                                         && d.UnitId == objReceivingReceiptItem.UnitId
                                         && d.MstArticle.IsLocked == true
                                         select d;

                    if (conversionUnit.Any() == false)
                    {
                        return new String[] { "Item unit not found.", "0" };
                    }

                    Decimal baseQuantity = objReceivingReceiptItem.Quantity;
                    if (conversionUnit.FirstOrDefault().UnitMultiplier > 0)
                    {
                        baseQuantity = objReceivingReceiptItem.Quantity * (conversionUnit.FirstOrDefault().BaseUnitMultiplier / conversionUnit.FirstOrDefault().UnitMultiplier);
                    }

                    Decimal baseCost = 0;
                    if (baseQuantity > 0)
                    {
                        baseCost = objReceivingReceiptItem.Amount / baseQuantity;
                    }

                    var updateReceivingReceiptItem = receivingReceiptItem.FirstOrDefault();
                    updateReceivingReceiptItem.UnitId = objReceivingReceiptItem.UnitId;
                    updateReceivingReceiptItem.Cost = objReceivingReceiptItem.Cost;
                    updateReceivingReceiptItem.Quantity = objReceivingReceiptItem.Quantity;
                    updateReceivingReceiptItem.Amount = objReceivingReceiptItem.Amount;
                    updateReceivingReceiptItem.TaxId = objReceivingReceiptItem.TaxId;
                    updateReceivingReceiptItem.TaxRate = objReceivingReceiptItem.TaxRate;
                    updateReceivingReceiptItem.TaxAmount = objReceivingReceiptItem.TaxAmount;
                    updateReceivingReceiptItem.BranchId = objReceivingReceiptItem.BranchId;
                    updateReceivingReceiptItem.BaseQuantity = baseQuantity;
                    updateReceivingReceiptItem.BaseCost = baseCost;

                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Receiving Receipt item not found.  " + id, "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =============================
        // Delete Receiving Receipt Item
        // =============================
        public String[] DeleteReceivingReceiptItem(Int32 id)
        {
            try
            {
                var receivingReceiptItem = from d in db.TrnReceivingReceiptItems
                                           where d.Id == id
                                           select d;

                if (receivingReceiptItem.Any())
                {
                    var deleteReceivingReceiptItem = receivingReceiptItem.FirstOrDefault();
                    db.TrnReceivingReceiptItems.DeleteOnSubmit(deleteReceivingReceiptItem);
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Receiving Receipt item not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}