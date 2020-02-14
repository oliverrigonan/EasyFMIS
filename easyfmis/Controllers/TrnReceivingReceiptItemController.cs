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
                                            PONumber = d.TrnPurchaseOrder.PONumber,
                                            ItemId = d.ItemId,
                                            ItemBarCode = d.MstArticle.ArticleBarCode,
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
        // List Purchase Order
        // ===================
        public List<Entities.TrnPurchaseOrderEntity> ListPurchaseOrder(Int32 supplierId)
        {
            var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
            var currentBranchId = currentUserLogin.FirstOrDefault().BranchId;

            var purchaseOrders = from d in db.TrnPurchaseOrders
                                 where d.SupplierId == supplierId
                                 && d.BranchId == currentBranchId
                                 && d.IsLocked == true
                                 select new Entities.TrnPurchaseOrderEntity
                                 {
                                     Id = d.Id,
                                     PONumber = "PO Number: " + d.PONumber,
                                 };

            return purchaseOrders.OrderBy(d => d.PONumber).ToList();
        }

        // ========================
        // List Purchase Order Item
        // ========================
        public List<Entities.TrnPurchaseOrderItemEntity> ListPurchaseOrderItem(Int32 POId, String filter)
        {
            var purchaseOrderItems = from d in db.TrnPurchaseOrderItems
                                     where d.POId == POId
                                     && (d.MstArticle.ArticleBarCode.Contains(filter)
                                     || d.MstArticle.Article.Contains(filter)
                                     || d.MstUnit.Unit.Contains(filter))
                                     && d.MstArticle.IsLocked == true
                                     select new Entities.TrnPurchaseOrderItemEntity
                                     {
                                         Id = d.Id,
                                         ItemId = d.ItemId,
                                         ItemBarCode = d.MstArticle.ArticleBarCode,
                                         ItemDescription = d.MstArticle.Article,
                                         UnitId = d.UnitId,
                                         Unit = d.MstUnit.Unit,
                                         BaseQuantity = d.BaseQuantity,
                                         BaseCost = d.BaseCost,
                                         VATInTaxId = d.MstArticle.VATInTaxId,
                                         VATInTaxRate = d.MstArticle.MstTax.Rate
                                     };

            return purchaseOrderItems.OrderBy(d => d.ItemDescription).ToList();
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
        // Dropdown List - Branch
        // ======================
        public List<Entities.MstBranchEntity> DropdownListReceivingReceiptBranch()
        {
            var branches = from d in db.MstBranches
                           select new Entities.MstBranchEntity
                           {
                               Id = d.Id,
                               Branch = d.Branch
                           };

            return branches.ToList();
        }

        // ===================
        // Dropdown List - Tax
        // ===================
        public List<Entities.MstTaxEntity> DropdownListReceivingReceiptTax()
        {
            var taxes = from d in db.MstTaxes
                        select new Entities.MstTaxEntity
                        {
                            Id = d.Id,
                            Tax = d.Tax,
                            Rate = d.Rate
                        };

            return taxes.ToList();
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

                var purchaseOrder = from d in db.TrnPurchaseOrders
                                    where d.Id == objReceivingReceiptItem.POId
                                    && d.IsLocked == true
                                    select d;

                if (purchaseOrder.Any() == false)
                {
                    return new String[] { "PO not found.", "0" };
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

                Decimal amount = 0;
                var receivingReceiptItems = from d in db.TrnReceivingReceiptItems
                                            where d.RRId == receivingReceipt.FirstOrDefault().Id
                                            select d;

                if (receivingReceiptItems.Any())
                {
                    amount = receivingReceiptItems.Sum(d => d.Amount);
                }

                var updateReceivingReceipt = receivingReceipt.FirstOrDefault();
                updateReceivingReceipt.Amount = amount;
                updateReceivingReceipt.BalanceAmount = amount;
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

                    Decimal amount = 0;
                    var receivingReceiptItems = from d in db.TrnReceivingReceiptItems
                                                where d.RRId == receivingReceipt.FirstOrDefault().Id
                                                select d;

                    if (receivingReceiptItems.Any())
                    {
                        amount = receivingReceiptItems.Sum(d => d.Amount);
                    }

                    var updateReceivingReceipt = receivingReceipt.FirstOrDefault();
                    updateReceivingReceipt.Amount = amount;
                    updateReceivingReceipt.BalanceAmount = amount;
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
                    Int32 RRId = receivingReceiptItem.FirstOrDefault().RRId;

                    var deleteReceivingReceiptItem = receivingReceiptItem.FirstOrDefault();
                    db.TrnReceivingReceiptItems.DeleteOnSubmit(deleteReceivingReceiptItem);
                    db.SubmitChanges();

                    var receivingReceipt = from d in db.TrnReceivingReceipts
                                           where d.Id == RRId
                                           select d;

                    if (receivingReceipt.Any())
                    {
                        Decimal amount = 0;
                        var receivingReceiptItems = from d in db.TrnReceivingReceiptItems
                                                    where d.RRId == receivingReceipt.FirstOrDefault().Id
                                                    select d;

                        if (receivingReceiptItems.Any())
                        {
                            amount = receivingReceiptItems.Sum(d => d.Amount);
                        }

                        var updateReceivingReceipt = receivingReceipt.FirstOrDefault();
                        updateReceivingReceipt.Amount = amount;
                        updateReceivingReceipt.BalanceAmount = amount;
                        db.SubmitChanges();
                    }

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