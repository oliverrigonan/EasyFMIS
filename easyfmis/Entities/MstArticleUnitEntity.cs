using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class MstArticleUnitEntity
    {
        public Int32 Id { get; set; }
        public Int32 ArticleId { get; set; }
        public Decimal BaseUnitMultiplier { get; set; }
        public Decimal UnitMultiplier { get; set; }
        public Int32 UnitId { get; set; }
        public String Unit { get; set; }
    }
}