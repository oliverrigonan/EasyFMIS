using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class TrnInventoryController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ===============================
        // List Stock-In Inventory Entries
        // ===============================
        public List<Entities.TrnInventoryEntity> ListStockInInventoryEntries(Int32 INId)
        {
            var inventories = from d in db.TrnInventories
                              where d.INId == INId
                              select new Entities.TrnInventoryEntity
                              {
                                  Branch = d.MstBranch.Branch,
                                  InventoryDate = d.InventoryDate,
                                  ItemDescription = d.MstArticle.Article,
                                  ItemInventoryCode = d.MstArticleInventory.InventoryCode,
                                  Quantity = d.Quantity,
                                  Amount = d.Amount
                              };

            return inventories.ToList();
        }

        // ================================
        // List Stock-Out Inventory Entries
        // ================================
        public List<Entities.TrnInventoryEntity> ListStockOutInventoryEntries(Int32 OTId)
        {
            var inventories = from d in db.TrnInventories
                              where d.OTId == OTId
                              select new Entities.TrnInventoryEntity
                              {
                                  Branch = d.MstBranch.Branch,
                                  InventoryDate = d.InventoryDate,
                                  ItemDescription = d.MstArticle.Article,
                                  ItemInventoryCode = d.MstArticleInventory.InventoryCode,
                                  Quantity = d.Quantity,
                                  Amount = d.Amount
                              };

            return inventories.ToList();
        }

        // =====================================
        // List Stock Transfer Inventory Entries
        // =====================================
        public List<Entities.TrnInventoryEntity> ListStockTransferInventoryEntries(Int32 STId)
        {
            var inventories = from d in db.TrnInventories
                              where d.STId == STId
                              select new Entities.TrnInventoryEntity
                              {
                                  Branch = d.MstBranch.Branch,
                                  InventoryDate = d.InventoryDate,
                                  ItemDescription = d.MstArticle.Article,
                                  ItemInventoryCode = d.MstArticleInventory.InventoryCode,
                                  Quantity = d.Quantity,
                                  Amount = d.Amount
                              };

            return inventories.ToList();
        }

        // ====================================
        // List Sales Invoice Inventory Entries
        // ====================================
        public List<Entities.TrnInventoryEntity> ListSalesInvoiceInventoryEntries(Int32 SIId)
        {
            var inventories = from d in db.TrnInventories
                              where d.SIId == SIId
                              select new Entities.TrnInventoryEntity
                              {
                                  Branch = d.MstBranch.Branch,
                                  InventoryDate = d.InventoryDate,
                                  ItemDescription = d.MstArticle.Article,
                                  ItemInventoryCode = d.MstArticleInventory.InventoryCode,
                                  Quantity = d.Quantity,
                                  Amount = d.Amount
                              };

            return inventories.ToList();
        }
    }
}
