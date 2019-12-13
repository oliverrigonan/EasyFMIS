using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class TrnStockOutItemEntity
    {
        public Int32 Id { get; set; }
        public Int32 INId { get; set; }
        public Int32 ItemId { get; set; }
        public String ItemDescription { get; set; }
        public Int32 ItemInventoryId { get; set; }
        public String ItemInventoryCode { get; set; }
        public Int32 UnitId { get; set; }
        public String Unit { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal Cost { get; set; }
        public Decimal Amount { get; set; }
        public Decimal BaseQuantity { get; set; }
        public Decimal BaseCost { get; set; }
    }
}
