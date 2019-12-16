using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    public class MstArticleInventoryController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());


        public List<Entities.MstArticleInventoryEntity> ListItemInventory(Int32 itemId)
        {
            var inventories = from d in db.MstArticleInventories
                              where d.ArticleId == itemId
                              select new Entities.MstArticleInventoryEntity
                              {
                                  Id = d.Id,
                                  BranchId = d.BranchId,
                                  BranchCode = d.MstBranch.BranchCode,
                                  InventoryCode = d.InventoryCode,
                                  ItemId = d.ArticleId,
                                  Quantity = d.Quantity,
                                  Cost1 = d.Cost1,
                                  Cost2 = d.Cost2,
                                  Cost3 = d.Cost3,
                                  Cost4 = d.Cost4,
                                  Cost5 = d.Cost5
                              };

            return inventories.OrderByDescending(d => d.Id).ToList();
        }


        public Entities.MstArticleInventoryEntity DetailItemInventory(Int32 itemId)
        {
            var inventory = from d in db.MstArticleInventories
                            where d.ArticleId == itemId
                            select new Entities.MstArticleInventoryEntity
                            {
                                Id = d.Id,
                                BranchId = d.BranchId,
                                InventoryCode = d.InventoryCode,
                                ItemId = d.ArticleId,
                                ItemDescription = d.MstArticle.Article,
                                Quantity = d.Quantity,
                                Cost1 = d.Cost1,
                                Cost2 = d.Cost2,
                                Cost3 = d.Cost3,
                                Cost4 = d.Cost4,
                                Cost5 = d.Cost5
                            };
            return inventory.FirstOrDefault();
        }

        // ====================
        // Dropdown - Item List
        // ====================
        public List<Entities.MstArticleEntity> DropdownListItem(Int32 itemId)
        {
            var items = from d in db.MstArticles
                        where d.IsInventory == true
                        && d.Id != itemId
                        select new Entities.MstArticleEntity
                        {
                            Id = d.Id,
                            Article = d.Article,
                            Unit = d.MstUnit.Unit,
                            DefaultCost = d.DefaultCost,
                        };

            return items.ToList();
        }

        public String[] UpdateItemInventory(Entities.MstArticleInventoryEntity objItemInventory) {
            try
            {
                var inventory = from d in db.MstArticleInventories
                                where d.Id == objItemInventory.Id
                                select d;
                if (inventory.Any())
                {
                    var updateInventory = inventory.FirstOrDefault();
                    updateInventory.Quantity = objItemInventory.Quantity;
                    updateInventory.Cost1 = objItemInventory.Cost1;
                    updateInventory.Cost2 = objItemInventory.Cost2;
                    updateInventory.Cost3 = objItemInventory.Cost3;
                    updateInventory.Cost4 = objItemInventory.Cost4;
                    updateInventory.Cost5 = objItemInventory.Cost5;
                    db.SubmitChanges();

                    return new string[] { "", "" };
                }
                else {
                    return new String[] { "Item inventory not found!", "0" };
                }
            }
            catch (Exception e) {
                return new String[] { e.Message, "0" };
            }

        }

    }
}
