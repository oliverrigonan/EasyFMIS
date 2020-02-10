using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class TrnReceivingReceiptItemEntity
    {
        public Int32 Id { get; set; }
        public Int32 RRId { get; set; }
        public Int32 POId { get; set; }
        public String PONumber { get; set; }
        public Int32 ItemId { get; set; }
        public String ItemBarCode { get; set; }
        public String ItemDescription { get; set; }
        public Int32 UnitId { get; set; }
        public String Unit { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal Cost { get; set; }
        public Decimal Amount { get; set; }
        public Int32 TaxId { get; set; }
        public String Tax { get; set; }
        public Decimal TaxRate { get; set; }
        public Decimal TaxAmount { get; set; }
        public Int32 BranchId { get; set; }
        public String Branch { get; set; }
        public Decimal BaseQuantity { get; set; }
        public Decimal BaseCost { get; set; }
    }
}