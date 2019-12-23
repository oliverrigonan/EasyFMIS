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
        public Int32 ArticleId { get; set; }
        public String ArticleCode { get; set; }
        public String ArticleBarCode { get; set; }
        public String Article { get; set; }
        public String Category { get; set; }
        public Int32 UnitId { get; set; }
        public String Unit { get; set; }
        public Decimal DefaultPrice { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal Cost { get; set; }
        public Int32 VATOutTaxId { get; set; }
        public Decimal VATOutTaxRate { get; set; }
    }
}