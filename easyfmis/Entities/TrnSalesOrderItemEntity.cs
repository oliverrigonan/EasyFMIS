using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class TrnSalesOrderItemEntity
    {
        public Int32 Id { get; set; }
        public Int32 SOId { get; set; }
        public Int32 ItemId { get; set; }
        public Int32? ItemInventoryId { get; set; }
        public Int32 UnitId { get; set; }
        public String Unit { get; set; }
        public Decimal Price { get; set; }
        public Int32 DiscountId { get; set; }
        public Decimal DiscountRate { get; set; }
        public Decimal DiscountAmount { get; set; }
        public Decimal NetPrice { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal Amount { get; set; }
        public Int32 TaxId { get; set; }
        public Decimal TaxRate { get; set; }
        public Decimal TaxAmount { get; set; }
        public Decimal BaseQuantity { get; set; }
        public Decimal BasePrice { get; set; }
    }
}
