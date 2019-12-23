using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvSearchInventoryItemEntity
    {
        public Int32 ColumnSearchInventoryId { get; set; }
        public Int32 ColumnSearchInventoryItemId { get; set; }
        public String ColumnSearchInventoryItemInventoryCode { get; set; }
        public String ColumnSearchInventoryItemBarCode { get; set; }
        public String ColumnSearchInventoryItemDescription { get; set; }
        public Int32 ColumnSearchInventoryItemUnitId { get; set; }
        public String ColumnSearchInventoryItemUnit { get; set; }
        public String ColumnSearchInventoryItemQuantity { get; set; }
        public String ColumnSearchInventoryItemPrice { get; set; }
        public String ColumnSearchInventoryItemButtonPick { get; set; }
    }
}