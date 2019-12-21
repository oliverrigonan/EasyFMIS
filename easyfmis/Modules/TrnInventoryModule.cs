﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Modules
{
    class TrnInventoryModule
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ========================
        // Update Article Inventory
        // ========================
        public void UpdateArticleInventory(Int32 id)
        {
            try
            {
                var articleInventory = from d in db.MstArticleInventories
                                       where d.Id == id
                                       select d;

                if (articleInventory.Any())
                {
                    var inventories = from d in db.TrnInventories
                                      where d.ItemInventoryId == id
                                      select d;

                    if (inventories.Any())
                    {
                        Decimal quantity = inventories.Sum(d => d.Quantity);
                        Decimal cost = inventories.OrderByDescending(d => d.Id).FirstOrDefault().MstArticleInventory.Cost1;

                        var updateArticleInventory = articleInventory.FirstOrDefault();
                        updateArticleInventory.Quantity = quantity;
                        updateArticleInventory.Cost1 = cost;

                        db.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Update Article Inventory Error: " + ex.Message);
            }
        }

        // ===========================
        // Insert Inventory - Stock In
        // ===========================
        public void InsertInventoryStockIn(Int32 INId)
        {
            try
            {
                var stockInItems = from d in db.TrnStockInItems
                                   where d.INId == INId
                                   && d.TrnStockIn.IsLocked == true
                                   select d;

                if (stockInItems.Any())
                {
                    foreach (var stockInItem in stockInItems)
                    {
                        Int32 articleInventoryId = 0;

                        var articleInventories = from d in db.MstArticleInventories
                                                 where d.ArticleId == stockInItem.ItemId
                                                 && d.BranchId == stockInItem.TrnStockIn.BranchId
                                                 select d;

                        if (articleInventories.Any())
                        {
                            articleInventoryId = articleInventories.FirstOrDefault().Id;
                        }
                        else
                        {
                            String inventoryCode = "IN-" + stockInItem.TrnStockIn.MstBranch.BranchCode + "-" + stockInItem.TrnStockIn.INNumber;

                            Data.MstArticleInventory newArticleInventory = new Data.MstArticleInventory()
                            {
                                BranchId = stockInItem.TrnStockIn.BranchId,
                                InventoryCode = inventoryCode,
                                ArticleId = stockInItem.ItemId,
                                Quantity = stockInItem.BaseQuantity,
                                Cost1 = stockInItem.BaseCost
                            };

                            db.MstArticleInventories.InsertOnSubmit(newArticleInventory);
                            db.SubmitChanges();

                            articleInventoryId = newArticleInventory.Id;
                        }

                        if (articleInventoryId != 0)
                        {
                            Data.TrnInventory newInventory = new Data.TrnInventory()
                            {
                                BranchId = stockInItem.TrnStockIn.BranchId,
                                InventoryDate = stockInItem.TrnStockIn.INDate,
                                ItemId = stockInItem.ItemId,
                                ItemInventoryId = articleInventoryId,
                                QuantityIn = stockInItem.BaseQuantity,
                                QuantityOut = 0,
                                Quantity = stockInItem.BaseQuantity,
                                Amount = stockInItem.BaseCost * stockInItem.BaseQuantity,
                                SIId = null,
                                INId = INId,
                                OTId = null,
                                STId = null,
                            };

                            db.TrnInventories.InsertOnSubmit(newInventory);
                            db.SubmitChanges();

                            UpdateArticleInventory(articleInventoryId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Insert Stock-In Inventory Error: " + ex.Message);
            }
        }

        // ===========================
        // Delete Inventory - Stock In
        // ===========================
        public void DeleteInventoryStockIn(Int32 INId)
        {
            try
            {
                var inventories = from d in db.TrnInventories
                                  where d.INId == INId
                                  select d;

                if (inventories.Any())
                {
                    List<Int32> articleInventoryIds = new List<Int32>();
                    foreach (var inventory in inventories)
                    {
                        if (articleInventoryIds.Contains(inventory.ItemInventoryId) == false)
                        {
                            articleInventoryIds.Add(inventory.ItemInventoryId);
                        }
                    }

                    db.TrnInventories.DeleteAllOnSubmit(inventories);
                    db.SubmitChanges();

                    if (articleInventoryIds.Any())
                    {
                        foreach (var articleInventoryId in articleInventoryIds)
                        {
                            UpdateArticleInventory(articleInventoryId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Delete Stock-In Inventory Error: " + ex.Message);
            }
        }

        // ============================
        // Insert Inventory - Stock Out
        // ============================
        public void InsertInventoryStockOut(Int32 OTId)
        {
            try
            {
                var stockOutItems = from d in db.TrnStockOutItems
                                    where d.OTId == OTId
                                    && d.TrnStockOut.IsLocked == true
                                    select d;

                if (stockOutItems.Any())
                {
                    foreach (var stockOutItem in stockOutItems)
                    {
                        Int32 articleInventoryId = 0;

                        var articleInventories = from d in db.MstArticleInventories
                                                 where d.Id == stockOutItem.ItemInventoryId
                                                 select d;

                        if (articleInventories.Any())
                        {
                            articleInventoryId = articleInventories.FirstOrDefault().Id;
                        }

                        if (articleInventoryId != 0)
                        {
                            Data.TrnInventory newInventory = new Data.TrnInventory()
                            {
                                BranchId = stockOutItem.TrnStockOut.BranchId,
                                InventoryDate = stockOutItem.TrnStockOut.OTDate,
                                ItemId = stockOutItem.ItemId,
                                ItemInventoryId = articleInventoryId,
                                QuantityIn = 0,
                                QuantityOut = stockOutItem.BaseQuantity,
                                Quantity = stockOutItem.BaseQuantity * -1,
                                Amount = stockOutItem.BaseCost * (stockOutItem.BaseQuantity * -1),
                                SIId = null,
                                INId = null,
                                OTId = OTId,
                                STId = null,
                            };

                            db.TrnInventories.InsertOnSubmit(newInventory);
                            db.SubmitChanges();

                            UpdateArticleInventory(articleInventoryId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Insert Stock-Out Inventory Error: " + ex.Message);
            }
        }

        // ============================
        // Delete Inventory - Stock Out
        // ============================
        public void DeleteInventoryStockOut(Int32 OTId)
        {
            try
            {
                var inventories = from d in db.TrnInventories
                                  where d.OTId == OTId
                                  select d;

                if (inventories.Any())
                {
                    List<Int32> articleInventoryIds = new List<Int32>();
                    foreach (var inventory in inventories)
                    {
                        if (articleInventoryIds.Contains(inventory.ItemInventoryId) == false)
                        {
                            articleInventoryIds.Add(inventory.ItemInventoryId);
                        }
                    }

                    db.TrnInventories.DeleteAllOnSubmit(inventories);
                    db.SubmitChanges();

                    if (articleInventoryIds.Any())
                    {
                        foreach (var articleInventoryId in articleInventoryIds)
                        {
                            UpdateArticleInventory(articleInventoryId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Delete Stock-Out Inventory Error: " + ex.Message);
            }
        }

        // =================================
        // Insert Inventory - Stock Transfer
        // =================================
        public void InsertInventoryStockTransfer(Int32 STId)
        {
            try
            {
                var stockTransferItems = from d in db.TrnStockTransferItems
                                    where d.STId == STId
                                    && d.TrnStockTransfer.IsLocked == true
                                    select d;

                if (stockTransferItems.Any())
                {
                    foreach (var stockTransferItem in stockTransferItems)
                    {
                        Int32 articleInventoryId = 0;

                        var articleInventories = from d in db.MstArticleInventories
                                                 where d.Id == stockTransferItem.ItemInventoryId
                                                 select d;

                        if (articleInventories.Any())
                        {
                            articleInventoryId = articleInventories.FirstOrDefault().Id;
                        }

                        if (articleInventoryId != 0)
                        {
                            Data.TrnInventory newOutInventory = new Data.TrnInventory()
                            {
                                BranchId = stockTransferItem.TrnStockTransfer.BranchId,
                                InventoryDate = stockTransferItem.TrnStockTransfer.STDate,
                                ItemId = stockTransferItem.ItemId,
                                ItemInventoryId = articleInventoryId,
                                QuantityIn = 0,
                                QuantityOut = stockTransferItem.BaseQuantity,
                                Quantity = stockTransferItem.BaseQuantity * -1,
                                Amount = stockTransferItem.BaseCost * (stockTransferItem.BaseQuantity * -1),
                                SIId = null,
                                INId = null,
                                OTId = null,
                                STId = STId
                            };

                            db.TrnInventories.InsertOnSubmit(newOutInventory);
                            db.SubmitChanges();

                            Data.TrnInventory newInInventory = new Data.TrnInventory()
                            {
                                BranchId = stockTransferItem.TrnStockTransfer.ToBranchId,
                                InventoryDate = stockTransferItem.TrnStockTransfer.STDate,
                                ItemId = stockTransferItem.ItemId,
                                ItemInventoryId = articleInventoryId,
                                QuantityIn = stockTransferItem.BaseQuantity,
                                QuantityOut = 0,
                                Quantity = stockTransferItem.BaseQuantity,
                                Amount = stockTransferItem.BaseCost * stockTransferItem.BaseQuantity,
                                SIId = null,
                                INId = null,
                                OTId = null,
                                STId = STId,
                            };

                            db.TrnInventories.InsertOnSubmit(newInInventory);
                            db.SubmitChanges();

                            UpdateArticleInventory(articleInventoryId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Insert Stock-Out Inventory Error: " + ex.Message);
            }
        }

        // =================================
        // Delete Inventory - Stock Transfer
        // =================================
        public void DeleteInventoryStockTransfer(Int32 STId)
        {
            try
            {
                var inventories = from d in db.TrnInventories
                                  where d.STId == STId
                                  select d;

                if (inventories.Any())
                {
                    List<Int32> articleInventoryIds = new List<Int32>();
                    foreach (var inventory in inventories)
                    {
                        if (articleInventoryIds.Contains(inventory.ItemInventoryId) == false)
                        {
                            articleInventoryIds.Add(inventory.ItemInventoryId);
                        }
                    }

                    db.TrnInventories.DeleteAllOnSubmit(inventories);
                    db.SubmitChanges();

                    if (articleInventoryIds.Any())
                    {
                        foreach (var articleInventoryId in articleInventoryIds)
                        {
                            UpdateArticleInventory(articleInventoryId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Delete Stock-Out Inventory Error: " + ex.Message);
            }
        }
    }
}
