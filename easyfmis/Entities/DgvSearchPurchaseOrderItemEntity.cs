using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easyfmis.Entities
{
    public class DgvSearchPurchaseOrderItemEntity
    {
        public Int32 ColumnSearchPurchaseOrderItemId { get; set; }
        public String ColumnSearchPurchaseOrderItemDescription { get; set; }
        public Int32 ColumnSearchPurchaseOrderItemUnitId { get; set; }
        public String ColumnSearchPurchaseOrderItemUnit { get; set; }
        public Int32 ColumnSearchPurchaseOrderItemVATInTaxId { get; set; }
        public String ColumnSearchPurchaseOrderItemVATInTaxRate { get; set; }
        public String ColumnSearchPurchaseOrderItemButtonPick { get; set; }
    }
}