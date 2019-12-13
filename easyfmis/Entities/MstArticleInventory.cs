using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easyfmis.Entities
{
    public class MstArticleInventory
    {
        public Int32 Id { get; set; }
        public Int32 BranchId { get; set; }
        public String InventoryCode { get; set; }
        public String ArticleId { get; set; }
        public String Quantity { get; set; }
        public String Cost { get; set; }
    }
}