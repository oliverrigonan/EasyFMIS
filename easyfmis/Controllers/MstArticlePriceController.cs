using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class MstArticlePriceController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ===============
        // List Item Price
        // ===============
        public List<Entities.MstArticlePriceEntity> ListItemPrice(Int32 itemId)
        {
            var itemPrices = from d in db.MstArticlePrices
                             where d.ArticleId == itemId
                             select new Entities.MstArticlePriceEntity
                             {
                                 Id = d.Id,
                                 ArticleId = d.ArticleId,
                                 PriceDescription = d.PriceDescription,
                                 Price = d.Price,
                             };

            return itemPrices.OrderByDescending(d => d.Id).ToList();
        }

        // ==============
        // Add Item Price
        // ==============
        public String[] AddItemPrice(Entities.MstArticlePriceEntity objItemPrice)
        {
            try
            {
                Data.MstArticlePrice addItemPrice = new Data.MstArticlePrice()
                {
                    Id = objItemPrice.Id,
                    ArticleId = objItemPrice.ArticleId,
                    PriceDescription = objItemPrice.PriceDescription,
                    Price = objItemPrice.Price
                };

                db.MstArticlePrices.InsertOnSubmit(addItemPrice);
                db.SubmitChanges();

                return new String[] { "", "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =================
        // Update Item Price
        // =================
        public String[] UpdateItemPrice(Entities.MstArticlePriceEntity objItemPrice)
        {
            try
            {
                var itemPrice = from d in db.MstArticlePrices
                                where d.Id == objItemPrice.Id
                                select d;

                if (itemPrice.Any())
                {
                    var updateItemPrice = itemPrice.FirstOrDefault();
                    updateItemPrice.PriceDescription = objItemPrice.PriceDescription;
                    updateItemPrice.Price = objItemPrice.Price;
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Item price not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =================
        // Delete Item Price
        // =================
        public String[] DeleteItemPrice(Int32 id)
        {
            try
            {
                var itemPrice = from d in db.MstArticlePrices
                                where d.Id == id
                                select d;

                if (itemPrice.Any())
                {
                    var deleteItemPrice = itemPrice.FirstOrDefault();
                    db.MstArticlePrices.DeleteOnSubmit(deleteItemPrice);
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Item price not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
