using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    class DgvMstArticlePriceEntity
    {
        public Int32 ColumnArticlePriceListId { get; set; }
        public Int32 ColumnArticlePriceListArticleId { get; set; }
        public String ColumnArticlePriceListPriceDescription { get; set; }
        public String ColumnArticlePriceListPrice { get; set; }
    }
}
