using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    class RepInventoryReportStockInDetailReportEntity
    {
        public Int32 Id { get; set; }
        public String Branch { get; set; }
        public String INNumber { get; set; }
        public DateTime INDate { get; set; }
        public String Remarks { get; set; }
        public String PreparedBy { get; set; }
        public String CheckedBy { get; set; }
        public String ApprovedBy { get; set; }
        public String ItemCode { get; set; }
        public String ItemDescription { get; set; }
        public String Unit { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal Cost { get; set; }
        public Decimal Amount { get; set; }
        public Decimal BaseQuantity { get; set; }
        public Decimal BaseCost { get; set; }
    }
}
