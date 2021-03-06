﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class TrnSalesInvoiceItemController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // =======================
        // List Sales Invoice Item
        // =======================
        public List<Entities.TrnSalesInvoiceItemEntity> ListSalesInvoiceItem(Int32 SIId)
        {
            var salesInvoiceItems = from d in db.TrnSalesInvoiceItems
                                    where d.SIId == SIId
                                    select new Entities.TrnSalesInvoiceItemEntity
                                    {
                                        Id = d.Id,
                                        SIId = d.SIId,
                                        ItemId = d.ItemId,
                                        ItemBarCode = d.MstArticle.ArticleBarCode,
                                        ItemDescription = d.MstArticle.Article,
                                        ItemInventoryId = d.ItemInventoryId,
                                        ItemInventoryCode = d.MstArticleInventory.InventoryCode,
                                        UnitId = d.UnitId,
                                        Unit = d.MstUnit.Unit,
                                        Price = d.Price,
                                        DiscountId = d.DiscountId,
                                        Discount = d.MstDiscount.Discount,
                                        DiscountRate = d.DiscountRate,
                                        DiscountAmount = d.DiscountAmount,
                                        NetPrice = d.NetPrice,
                                        Quantity = d.Quantity,
                                        Amount = d.Amount,
                                        TaxId = d.TaxId,
                                        Tax = d.MstTax.Tax,
                                        TaxRate = d.TaxRate,
                                        TaxAmount = d.TaxAmount,
                                        BaseQuantity = d.BaseQuantity,
                                        BasePrice = d.BasePrice
                                    };

            return salesInvoiceItems.OrderByDescending(d => d.Id).ToList();
        }

        // ===================
        // List Inventory Item
        // ===================
        public List<Entities.MstArticleInventory> ListInventoryItem(String filter)
        {
            var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
            var currentBranchId = currentUserLogin.FirstOrDefault().BranchId;

            var items = from d in db.MstArticleInventories
                        where (d.InventoryCode.Contains(filter)
                        || d.MstArticle.ArticleBarCode.Contains(filter)
                        || d.MstArticle.Article.Contains(filter)
                        || d.InventoryCode.Contains(filter)
                        || d.MstArticle.MstUnit.Unit.Contains(filter))
                        && d.Quantity > 0
                        && d.MstArticle.IsLocked == true
                        && d.BranchId == currentBranchId
                        select new Entities.MstArticleInventory
                        {
                            Id = d.Id,
                            InventoryCode = d.InventoryCode,
                            ArticleId = d.ArticleId,
                            ArticleCode = d.MstArticle.ArticleCode,
                            ArticleBarCode = d.MstArticle.ArticleBarCode,
                            Article = d.MstArticle.Article,
                            Category = d.MstArticle.Category,
                            Quantity = d.Quantity,
                            UnitId = d.MstArticle.UnitId,
                            Unit = d.MstArticle.MstUnit.Unit,
                            DefaultPrice = d.MstArticle.DefaultPrice,
                            VATOutTaxId = d.MstArticle.VATOutTaxId,
                            VATOutTaxRate = d.MstArticle.MstTax1.Rate
                        };

            return items.OrderBy(d => d.Article).ToList();
        }

        // =======================
        // List Non-Inventory Item
        // =======================
        public List<Entities.MstArticleEntity> ListNonInventoryItem(String filter)
        {
            var items = from d in db.MstArticles
                        where d.ArticleTypeId == 1
                        && (d.ArticleBarCode.Contains(filter)
                        || d.Article.Contains(filter)
                        || d.MstUnit.Unit.Contains(filter))
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
                            DefaultPrice = d.DefaultPrice,
                            VATOutTaxId = d.VATOutTaxId,
                            VATOutTaxRate = d.MstTax1.Rate
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

        // ===========================
        // Dropdown List Article Price
        // ===========================
        public List<Entities.MstArticlePriceEntity> DropdownListArticlePrice(Int32 articleId)
        {
            var articlePrices = from d in db.MstArticlePrices
                                where d.ArticleId == articleId
                                select new Entities.MstArticlePriceEntity
                                {
                                    Price = d.Price
                                };

            return articlePrices.ToList();
        }

        // ========================
        // Dropdown List - Discount
        // ========================
        public List<Entities.MstDiscountEntity> DropdownListSalesInvoiceDiscount()
        {
            var terms = from d in db.MstDiscounts
                        select new Entities.MstDiscountEntity
                        {
                            Id = d.Id,
                            Discount = d.Discount,
                            DiscountRate = d.DiscountRate
                        };

            return terms.ToList();
        }

        // ===================
        // Dropdown List - Tax
        // ===================
        public List<Entities.MstTaxEntity> DropdownListSalesInvoiceTax()
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

        // ======================
        // Add Sales Invoice Item
        // ======================
        public String[] AddSalesInvoiceItem(Entities.TrnSalesInvoiceItemEntity objSalesInvoiceItem)
        {
            try
            {
                var salesInvoice = from d in db.TrnSalesInvoices
                                   where d.Id == objSalesInvoiceItem.SIId
                                   select d;

                if (salesInvoice.Any() == false)
                {
                    return new String[] { "Sales Invoice transaction not found.", "0" };
                }

                var item = from d in db.MstArticles
                           where d.Id == objSalesInvoiceItem.ItemId
                           && d.IsLocked == true
                           select d;

                if (item.Any() == false)
                {
                    return new String[] { "Item not found.", "0" };
                }

                var itemInventory = from d in db.MstArticleInventories
                                    where d.Id == objSalesInvoiceItem.ItemInventoryId
                                    select d;

                if (itemInventory.Any() == false)
                {
                    return new String[] { "Inventory code not found.", "0" };
                }

                var discount = from d in db.MstDiscounts
                               where d.Id == objSalesInvoiceItem.DiscountId
                               select d;

                if (discount.Any() == false)
                {
                    return new String[] { "Discount not found.", "0" };
                }

                var tax = from d in db.MstTaxes
                          where d.Id == objSalesInvoiceItem.TaxId
                          select d;

                if (tax.Any() == false)
                {
                    return new String[] { "Tax not found.", "0" };
                }

                var conversionUnit = from d in db.MstArticleUnits
                                     where d.ArticleId == objSalesInvoiceItem.ItemId
                                     && d.UnitId == objSalesInvoiceItem.UnitId
                                     && d.MstArticle.IsLocked == true
                                     select d;

                if (conversionUnit.Any() == false)
                {
                    return new String[] { "Item unit not found.", "0" };
                }

                Decimal baseQuantity = objSalesInvoiceItem.Quantity;
                if (conversionUnit.FirstOrDefault().UnitMultiplier > 0)
                {
                    baseQuantity = objSalesInvoiceItem.Quantity * (conversionUnit.FirstOrDefault().BaseUnitMultiplier / conversionUnit.FirstOrDefault().UnitMultiplier);
                }

                Decimal basePrice = item.FirstOrDefault().DefaultPrice;

                Data.TrnSalesInvoiceItem newSalesInvoiceItem = new Data.TrnSalesInvoiceItem
                {
                    SIId = objSalesInvoiceItem.SIId,
                    ItemId = objSalesInvoiceItem.ItemId,
                    ItemInventoryId = objSalesInvoiceItem.ItemInventoryId,
                    UnitId = objSalesInvoiceItem.UnitId,
                    Price = objSalesInvoiceItem.Price,
                    DiscountId = objSalesInvoiceItem.DiscountId,
                    DiscountRate = objSalesInvoiceItem.DiscountRate,
                    DiscountAmount = objSalesInvoiceItem.DiscountAmount,
                    NetPrice = objSalesInvoiceItem.NetPrice,
                    Quantity = objSalesInvoiceItem.Quantity,
                    Amount = objSalesInvoiceItem.Amount,
                    TaxId = objSalesInvoiceItem.TaxId,
                    TaxRate = objSalesInvoiceItem.TaxRate,
                    TaxAmount = objSalesInvoiceItem.TaxAmount,
                    BaseQuantity = baseQuantity,
                    BasePrice = basePrice
                };

                db.TrnSalesInvoiceItems.InsertOnSubmit(newSalesInvoiceItem);
                db.SubmitChanges();

                Decimal amount = 0;
                var salesInvoiceItems = from d in db.TrnSalesInvoiceItems
                                        where d.SIId == salesInvoice.FirstOrDefault().Id
                                        select d;

                if (salesInvoiceItems.Any())
                {
                    amount = salesInvoiceItems.Sum(d => d.Amount);
                }

                var updateSalesInvoice = salesInvoice.FirstOrDefault();
                updateSalesInvoice.Amount = amount;
                updateSalesInvoice.BalanceAmount = amount;
                db.SubmitChanges();

                return new String[] { "", "1" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =========================
        // Update Sales Invoice Item
        // =========================
        public String[] UpdateSalesInvoiceItem(Int32 id, Entities.TrnSalesInvoiceItemEntity objSalesInvoiceItem)
        {
            try
            {
                var salesInvoiceItem = from d in db.TrnSalesInvoiceItems
                                       where d.Id == id
                                       select d;

                if (salesInvoiceItem.Any())
                {
                    var salesInvoice = from d in db.TrnSalesInvoices
                                       where d.Id == objSalesInvoiceItem.SIId
                                       select d;

                    if (salesInvoice.Any() == false)
                    {
                        return new String[] { "Sales Invoice transaction not found.", "0" };
                    }

                    var itemInventory = from d in db.MstArticleInventories
                                        where d.Id == objSalesInvoiceItem.ItemInventoryId
                                        select d;

                    if (itemInventory.Any() == false)
                    {
                        return new String[] { "Inventory code not found.", "0" };
                    }

                    var discount = from d in db.MstDiscounts
                                   where d.Id == objSalesInvoiceItem.DiscountId
                                   select d;

                    if (discount.Any() == false)
                    {
                        return new String[] { "Discount not found.", "0" };
                    }

                    var tax = from d in db.MstTaxes
                              where d.Id == objSalesInvoiceItem.TaxId
                              select d;

                    if (tax.Any() == false)
                    {
                        return new String[] { "Tax not found.", "0" };
                    }

                    var conversionUnit = from d in db.MstArticleUnits
                                         where d.ArticleId == objSalesInvoiceItem.ItemId
                                         && d.UnitId == objSalesInvoiceItem.UnitId
                                         && d.MstArticle.IsLocked == true
                                         select d;

                    if (conversionUnit.Any() == false)
                    {
                        return new String[] { "Item unit not found.", "0" };
                    }

                    Decimal baseQuantity = objSalesInvoiceItem.Quantity;
                    if (conversionUnit.FirstOrDefault().UnitMultiplier > 0)
                    {
                        baseQuantity = objSalesInvoiceItem.Quantity * (conversionUnit.FirstOrDefault().BaseUnitMultiplier / conversionUnit.FirstOrDefault().UnitMultiplier);
                    }

                    var updateSalesInvoiceItem = salesInvoiceItem.FirstOrDefault();
                    updateSalesInvoiceItem.ItemInventoryId = objSalesInvoiceItem.ItemInventoryId;
                    updateSalesInvoiceItem.UnitId = objSalesInvoiceItem.UnitId;
                    updateSalesInvoiceItem.Price = objSalesInvoiceItem.Price;
                    updateSalesInvoiceItem.DiscountId = objSalesInvoiceItem.DiscountId;
                    updateSalesInvoiceItem.DiscountRate = objSalesInvoiceItem.DiscountRate;
                    updateSalesInvoiceItem.DiscountAmount = objSalesInvoiceItem.DiscountAmount;
                    updateSalesInvoiceItem.NetPrice = objSalesInvoiceItem.NetPrice;
                    updateSalesInvoiceItem.Quantity = objSalesInvoiceItem.Quantity;
                    updateSalesInvoiceItem.Amount = objSalesInvoiceItem.Amount;
                    updateSalesInvoiceItem.TaxId = objSalesInvoiceItem.TaxId;
                    updateSalesInvoiceItem.TaxRate = objSalesInvoiceItem.TaxRate;
                    updateSalesInvoiceItem.TaxAmount = objSalesInvoiceItem.TaxAmount;
                    updateSalesInvoiceItem.BaseQuantity = baseQuantity;
                    db.SubmitChanges();

                    Decimal amount = 0;
                    var salesInvoiceItems = from d in db.TrnSalesInvoiceItems
                                            where d.SIId == salesInvoice.FirstOrDefault().Id
                                            select d;

                    if (salesInvoiceItems.Any())
                    {
                        amount = salesInvoiceItems.Sum(d => d.Amount);
                    }

                    var updateSalesInvoice = salesInvoice.FirstOrDefault();
                    updateSalesInvoice.Amount = amount;
                    updateSalesInvoice.BalanceAmount = amount;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Sales Invoice item not found.  " + id, "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ==============
        // Discount Sales
        // ==============
        public String[] DiscountSalesInvoice(Int32 salesInvoiceId, Entities.MstDiscountEntity objDiscountEntity)
        {
            try
            {
                var salesInvoice = from d in db.TrnSalesInvoices
                                   where d.Id == salesInvoiceId
                                   select d;

                if (salesInvoice.Any())
                {

                    Decimal discountRate = 0;

                    var discount = from d in db.MstDiscounts
                                   where d.Id == objDiscountEntity.Id
                                   select d;

                    if (discount.Any())
                    {
                        if (discount.FirstOrDefault().Discount == "VARIABLE")
                        {
                            discountRate = objDiscountEntity.DiscountRate;
                        }
                        else
                        {
                            discountRate = discount.FirstOrDefault().DiscountRate;
                        }
                    }

                    var salesInvoiceLines = from d in db.TrnSalesInvoiceItems
                                            where d.SIId == salesInvoiceId
                                            select d;

                    if (salesInvoiceLines.Any())
                    {
                        foreach (var salesInvoiceLine in salesInvoiceLines)
                        {
                            Decimal quantity = salesInvoiceLine.Quantity;
                            Decimal price = salesInvoiceLine.Price;
                            Decimal taxRate = salesInvoiceLine.TaxRate;

                            Decimal discountAmount = 0;
                            Decimal taxAmount = 0;
                            Decimal netPrice = 0;
                            Decimal amount = 0;

                            if (discountRate > 0)
                            {
                                discountAmount = price * (discountRate / 100);
                            }

                            netPrice = price;

                            if (discountAmount > 0)
                            {
                                netPrice = price - discountAmount;
                            }

                            amount = quantity * netPrice;

                            if (taxRate > 0)
                            {
                                taxAmount = (amount / (1 + (taxRate / 100))) * (taxRate / 100);
                            }

                            salesInvoiceLine.DiscountId = discount.FirstOrDefault().Id;
                            salesInvoiceLine.DiscountRate = discountRate;
                            salesInvoiceLine.DiscountAmount = discountAmount;
                            salesInvoiceLine.NetPrice = netPrice;
                            salesInvoiceLine.Amount = amount;
                            salesInvoiceLine.TaxAmount = taxAmount;

                            db.SubmitChanges();
                        }
                    }

                    var updateSalesInvoice = salesInvoice.FirstOrDefault();
                    updateSalesInvoice.Amount = salesInvoice.FirstOrDefault().TrnSalesInvoiceItems.Any() ? salesInvoice.FirstOrDefault().TrnSalesInvoiceItems.Sum(d => d.Amount) : 0;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Sales not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =========================
        // Delete Sales Invoice Item
        // =========================
        public String[] DeleteSalesInvoiceItem(Int32 id)
        {
            try
            {
                var salesInvoiceItem = from d in db.TrnSalesInvoiceItems
                                       where d.Id == id
                                       select d;

                if (salesInvoiceItem.Any())
                {
                    Int32 SIId = salesInvoiceItem.FirstOrDefault().SIId;

                    var deleteSalesInvoiceItem = salesInvoiceItem.FirstOrDefault();
                    db.TrnSalesInvoiceItems.DeleteOnSubmit(deleteSalesInvoiceItem);
                    db.SubmitChanges();

                    var salesInvoice = from d in db.TrnSalesInvoices
                                       where d.Id == SIId
                                       select d;

                    if (salesInvoice.Any())
                    {
                        Decimal amount = 0;
                        var salesInvoiceItems = from d in db.TrnSalesInvoiceItems
                                                where d.SIId == salesInvoice.FirstOrDefault().Id
                                                select d;

                        if (salesInvoiceItems.Any())
                        {
                            amount = salesInvoiceItems.Sum(d => d.Amount);
                        }

                        var updateSalesInvoice = salesInvoice.FirstOrDefault();
                        updateSalesInvoice.Amount = amount;
                        updateSalesInvoice.BalanceAmount = amount;
                        db.SubmitChanges();
                    }

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Sales Invoice item not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ================
        // List Sales Order
        // ================
        public List<Entities.TrnSalesOrderEntity> ListSalesOrder(Int32 customerId)
        {
            var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
            var currentBranchId = currentUserLogin.FirstOrDefault().BranchId;

            var salesOrders = from d in db.TrnSalesOrders
                              where d.CustomerId == customerId
                              && d.BranchId == currentBranchId
                              && d.IsLocked == true
                              select new Entities.TrnSalesOrderEntity
                              {
                                  Id = d.Id,
                                  SODate = d.SODate,
                                  SONumber = d.SONumber,
                                  Remarks = d.Remarks
                              };

            List<Entities.TrnSalesOrderEntity> objSalesOrder = new List<Entities.TrnSalesOrderEntity>();

            foreach (var salesOrder in salesOrders)
            {

                var salesOrderItems = from d in db.TrnSalesOrderItems
                                      where d.TrnSalesOrder.Id == salesOrder.Id
                                      select d;

                foreach (var salesOrderItem in salesOrderItems)
                {
                    var salesInvoiceItems = from d in db.TrnSalesInvoiceItems
                                            where d.TrnSalesInvoice.CustomerId == customerId
                                            && d.TrnSalesInvoice.BranchId == currentBranchId
                                            && d.TrnSalesInvoice.SOId == salesOrder.Id
                                            && d.TrnSalesInvoice.IsLocked == true
                                            select d;

                    foreach (var salesInvoiceItem in salesInvoiceItems)
                    {
                        if (salesOrderItem.ItemId == salesInvoiceItem.ItemId)
                        {
                            salesOrderItem.Quantity -= salesInvoiceItem.Quantity;
                        }
                    }

                    if (salesOrderItem.Quantity > 0)
                    {
                        objSalesOrder.Add(salesOrder);
                        break;
                    }
                }
            }

            return objSalesOrder.OrderByDescending(d => d.Id).ToList();
        }

        // =============
        // List Sales Order Item 
        // =============
        public List<Entities.TrnSalesOrderItemEntity> ListSalesOrderItem(Int32 sOId, Int32 customerId)
        {
            var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
            var currentBranchId = currentUserLogin.FirstOrDefault().BranchId;

            var salesOrderItem = from d in db.TrnSalesOrderItems
                                 where d.SOId == sOId
                                 && d.TrnSalesOrder.MstBranch.Id == currentBranchId
                                 && d.TrnSalesOrder.CustomerId == customerId
                                 && d.TrnSalesOrder.IsLocked == true
                                 select new Entities.TrnSalesOrderItemEntity
                                 {
                                     Id = d.Id,
                                     SOId = d.SOId,
                                     ItemId = d.ItemId,
                                     BarCode = d.MstArticle.ArticleCode,
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

        // ===========================
        // List Load Sales Order Items
        // ===========================
        public String[] ListLoadSalesOrderItem(Int32 sIId, Int32 sOId)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                var currentBranchId = currentUserLogin.FirstOrDefault().BranchId;

                var salesInvoice = from d in db.TrnSalesInvoices
                                   where d.Id == sIId
                                   select d;

                var salesInvoiceItems = from d in db.TrnSalesInvoiceItems
                                        where d.SIId == sIId
                                        select d;

                if (salesInvoiceItems.Any())
                {
                    var updateSalesInvoice = salesInvoice.FirstOrDefault();
                    updateSalesInvoice.SOId = null;
                    db.SubmitChanges();

                    db.TrnSalesInvoiceItems.DeleteAllOnSubmit(salesInvoiceItems);
                    db.SubmitChanges();
                }

                if (salesInvoice.Any())
                {
                    var updateSalesInvoice = salesInvoice.FirstOrDefault();
                    updateSalesInvoice.SOId = sOId;
                    updateSalesInvoice.UpdatedBy = currentUserLogin.FirstOrDefault().Id;
                    updateSalesInvoice.UpdatedDateTime = DateTime.Now;
                    db.SubmitChanges();
                }
                else
                {
                    return new String[] { "Sales Invoice not found.", "0" };
                }

                var salesOrderItems = from d in db.TrnSalesOrderItems
                                      where d.SOId == sOId
                                      && d.TrnSalesOrder.MstBranch.Id == currentBranchId
                                      select new Entities.TrnSalesOrderItemEntity
                                      {
                                          Id = d.Id,
                                          SOId = d.SOId,
                                          ItemId = d.ItemId,
                                          BarCode = d.MstArticle.ArticleCode,
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

                List<Entities.TrnSalesInvoiceItemEntity> salesInvoiceItemEntities = new List<Entities.TrnSalesInvoiceItemEntity>();

                var salesInvoiceISOItems = from d in db.TrnSalesInvoiceItems
                                           where d.TrnSalesInvoice.SOId == sOId
                                           select d;

                foreach (var salesOrderItem in salesOrderItems)
                {
                    if (salesInvoiceISOItems.Any())
                    {
                        foreach (var salesInvoiceISOItem in salesInvoiceISOItems)
                        {
                            if (salesInvoiceISOItem.ItemId == salesOrderItem.ItemId)
                            {
                                salesOrderItem.Quantity -= salesInvoiceISOItem.Quantity;
                                salesOrderItem.BaseQuantity -= salesInvoiceISOItem.BaseQuantity;

                                if (salesOrderItem.Quantity < 0)
                                {
                                    salesOrderItem.Quantity = 0;
                                }
                            }
                        }

                        Decimal quantity = salesOrderItem.Quantity;
                        Decimal price = salesOrderItem.Price;

                        Decimal discountRate = salesOrderItem.DiscountRate;
                        Decimal discountAmount = 0;

                        if (discountRate > 0)
                        {
                            discountAmount = price * (discountRate / 100);
                        }

                        Decimal netPrice = price;
                        if (discountAmount > 0)
                        {
                            netPrice = price - discountAmount;
                        }

                        Decimal amount = quantity * netPrice;

                        Decimal taxRate = salesOrderItem.TaxRate;
                        Decimal taxAmount = 0;

                        if (taxRate > 0)
                        {
                            taxAmount = (amount / (1 + (taxRate / 100))) * (taxRate / 100);
                        }

                        if (salesOrderItem.Quantity > 0)
                        {
                            salesInvoiceItemEntities.Add(new Entities.TrnSalesInvoiceItemEntity
                            {
                                SIId = salesInvoice.FirstOrDefault().Id,
                                ItemId = salesOrderItem.ItemId,
                                ItemInventoryId = salesOrderItem.ItemInventoryId,
                                UnitId = salesOrderItem.UnitId,
                                Price = salesOrderItem.Price,
                                DiscountId = salesOrderItem.DiscountId,
                                DiscountRate = salesOrderItem.DiscountRate,
                                DiscountAmount = discountAmount,
                                NetPrice = netPrice,
                                Quantity = salesOrderItem.Quantity,
                                Amount = amount,
                                TaxId = salesOrderItem.TaxId,
                                TaxRate = salesOrderItem.TaxRate,
                                TaxAmount = taxAmount,
                                BaseQuantity = 0,
                                BasePrice = 0
                            });
                        }
                    }
                    else
                    {
                        salesInvoiceItemEntities.Add(new Entities.TrnSalesInvoiceItemEntity
                        {
                            SIId = salesInvoice.FirstOrDefault().Id,
                            ItemId = salesOrderItem.ItemId,
                            ItemInventoryId = salesOrderItem.ItemInventoryId,
                            UnitId = salesOrderItem.UnitId,
                            Price = salesOrderItem.Price,
                            DiscountId = salesOrderItem.DiscountId,
                            DiscountRate = salesOrderItem.DiscountRate,
                            DiscountAmount = salesOrderItem.DiscountAmount,
                            NetPrice = salesOrderItem.NetPrice,
                            Quantity = salesOrderItem.Quantity,
                            Amount = salesOrderItem.Amount,
                            TaxId = salesOrderItem.TaxId,
                            TaxRate = salesOrderItem.TaxRate,
                            TaxAmount = salesOrderItem.TaxAmount,
                            BaseQuantity = salesOrderItem.BaseQuantity,
                            BasePrice = salesOrderItem.BasePrice
                        });
                    }
                }

                foreach (var salesInvoiceItem in salesInvoiceItemEntities)
                {
                    var loadSalesOrderItem = AddSalesInvoiceItem(salesInvoiceItem);

                    if (loadSalesOrderItem[1].Equals("0") == true)
                    {
                        return new String[] { loadSalesOrderItem[0], "0" };
                    }
                }

                return new String[] { "", "1" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
