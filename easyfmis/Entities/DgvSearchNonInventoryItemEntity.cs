using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvSearchNonInventoryItemEntity
    {
        public Int32 ColumnSearchNonInventoryItemId { get; set; }
        public String ColumnSearchNonInventoryItemBarCode { get; set; }
        public String ColumnSearchNonInventoryItemDescription { get; set; }
        public Int32 ColumnSearchNonInventoryItemUnitId { get; set; }
        public String ColumnSearchNonInventoryItemUnit { get; set; }
        public String ColumnSearchNonInventoryItemPrice { get; set; }
        public String ColumnSearchNonInventoryItemButtonPick { get; set; }
    }
}