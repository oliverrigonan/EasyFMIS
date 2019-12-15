using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class MstArticleInventoryEntity
    {
        public Int32 Id { get; set; }
        public Int32 BranchId { get; set; }
        public String BranchCode { get; set; }
        public String InventoryCode { get; set; }
        public Int32 ItemId { get; set; }
        public String ItemDescription { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal Cost1 { get; set; }
        public Decimal Cost2 { get; set; }
        public Decimal Cost3 { get; set; }
        public Decimal Cost4 { get; set; }
        public Decimal Cost5 { get; set; }
    }
}
