using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvPurchaseOrderItemEntity
    {
        public String ColumnPurchaseOrderItemListButtonEdit { get; set; }
        public String ColumnPurchaseOrderItemListButtonDelete { get; set; }
        public Int32 ColumnPurchaseOrderItemListId { get; set; }
        public Int32 ColumnPurchaseOrderItemListPOId { get; set; }
        public Int32 ColumnPurchaseOrderItemListItemId { get; set; }
        public String ColumnPurchaseOrderItemListItemDescritpion { get; set; }
        public Int32 ColumnPurchaseOrderItemListUnitId { get; set; }
        public String ColumnPurchaseOrderItemListUnit { get; set; }
        public String ColumnPurchaseOrderItemListQuantity { get; set; }
        public String ColumnPurchaseOrderItemListCost { get; set; }
        public String ColumnPurchaseOrderItemListAmount { get; set; }
        public String ColumnPurchaseOrderItemListBaseQuantity { get; set; }
        public String ColumnPurchaseOrderItemListBaseCost { get; set; }
        public String ColumnPurchaseOrderItemSpace { get; set; }
    }
}
