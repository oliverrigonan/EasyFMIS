using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class MstArticlePriceEntity
    {
        public Int32 Id { get; set; }
        public Int32 ArticleId { get; set; }
        public String PriceDescription { get; set; }
        public Decimal Price { get; set; }
    }
}
