using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class MstArticleComponentController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ===================
        // Fill Leading Zeroes
        // ===================
        public String FillLeadingZeroes(Int32 number, Int32 length)
        {
            var result = number.ToString();
            var pad = length - result.Length;
            while (pad > 0)
            {
                result = '0' + result;
                pad--;
            }

            return result;
        }

        // ===================
        // Item Component List
        // ===================
        public List<Entities.MstArticleComponentEntity> ItemComponentList(Int32 itemId)
        {
            var itemComponent = from d in db.MstArticleComponents
                                where d.ArticleId == itemId
                                select new Entities.MstArticleComponentEntity
                                {
                                    Id = d.Id,
                                    ItemId = d.ArticleId,
                                    ItemDescription = d.MstArticle.Article,
                                    ComponentItemId = d.ComponentArticleId,
                                    ComponentItemDescription = d.MstArticle1.Article,
                                    UnitId = d.UnitId,
                                    Unit = d.MstUnit.Unit,
                                    Quantity = d.Quantity,
                                    Cost = d.Cost,
                                    Amount = d.Amount,
                                };

            return itemComponent.OrderByDescending(d => d.Id).ToList();
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

        // ==================
        // Add Item Component
        // ==================
        public String[] AddItemComponent(Entities.MstArticleComponentEntity objItemComponent)
        {
            try
            {
                var componentItem = from d in db.MstArticles
                                    where d.Id == objItemComponent.ComponentItemId
                                    select d;

                if (componentItem.Any() == false)
                {
                    return new String[] { "Item component not found.", "0" };
                }

                Data.MstArticleComponent addComponent = new Data.MstArticleComponent()
                {
                    ArticleId = objItemComponent.ItemId,
                    ComponentArticleId = objItemComponent.ComponentItemId,
                    UnitId = componentItem.First().UnitId,
                    Quantity = objItemComponent.Quantity,
                    Cost = objItemComponent.Cost,
                    Amount = objItemComponent.Amount,
                };

                db.MstArticleComponents.InsertOnSubmit(addComponent);
                db.SubmitChanges();

                return new String[] { "", "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =====================
        // Update Item Component
        // =====================
        public String[] UpdateItemComponent(Entities.MstArticleComponentEntity objItemComponent)
        {
            try
            {
                var itemComponent = from d in db.MstArticleComponents
                                    where d.Id == objItemComponent.Id
                                    select d;

                if (itemComponent.Any())
                {
                    var componentItem = from d in db.MstArticles
                                        where d.Id == objItemComponent.ComponentItemId
                                        select d;

                    if (componentItem.Any() == false)
                    {
                        return new String[] { "Component item not found.", "0" };
                    }

                    var updateItemComponent = itemComponent.FirstOrDefault();
                    updateItemComponent.ComponentArticleId = objItemComponent.ComponentItemId;
                    updateItemComponent.UnitId = componentItem.FirstOrDefault().UnitId;
                    updateItemComponent.Quantity = objItemComponent.Quantity;
                    updateItemComponent.Cost = objItemComponent.Cost;
                    updateItemComponent.Amount = objItemComponent.Amount;
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Item Component not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =====================
        // Delete Item Component
        // =====================
        public String[] DeleteItemComponent(int id)
        {
            try
            {
                var itemComponent = from d in db.MstArticleComponents
                                    where d.Id == id
                                    select d;

                if (itemComponent.Any())
                {
                    var deleteItemComponent = itemComponent.FirstOrDefault();
                    db.MstArticleComponents.DeleteOnSubmit(deleteItemComponent);
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Item Component not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
