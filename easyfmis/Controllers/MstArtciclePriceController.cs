using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class MstArtciclePriceController
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
                                 PriceDescription = d.PriceDescription,
                                 Price = d.Price,
                             };

            return itemPrices.OrderByDescending(d => d.Id).ToList();
        }
    }
}
