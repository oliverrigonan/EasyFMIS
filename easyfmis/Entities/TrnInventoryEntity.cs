using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class TrnInventoryEntity
    {
        public Int32 Id { get; set; }
        public Int32 BranchId { get; set; }
        public String Branch { get; set; }
        public DateTime InventoryDate { get; set; }
        public Int32 ItemId { get; set; }
        public String ItemDescription { get; set; }
        public Int32 ItemInventoryId { get; set; }
        public String ItemInventoryCode { get; set; }
        public Decimal QuantityIn { get; set; }
        public Decimal QuantityOut { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal Amount { get; set; }
        public Int32? SIId { get; set; }
        public Int32? INId { get; set; }
        public Int32? OTId { get; set; }
    }
}
