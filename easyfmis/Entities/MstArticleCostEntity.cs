using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class MstArticleCostEntity
    {
        public Int32 Id { get; set; }
        public Int32 ArticleId { get; set; }
        public String CostDescription { get; set; }
        public Decimal Cost { get; set; }
        public Int32 CurrencyId { get; set; }
        public String Currency { get; set; }
    }
}
