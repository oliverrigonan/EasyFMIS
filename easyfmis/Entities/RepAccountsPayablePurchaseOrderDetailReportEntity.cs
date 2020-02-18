using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class RepAccountsPayablePurchaseOrderDetailReportEntity
    {
        public Int32 Id { get; set; }
        public String Branch { get; set; }
        public String PONumber { get; set; }
        public DateTime PODate { get; set; }
        public String ManualPONumber { get; set; }
        public String Supplier { get; set; }
        public String Term { get; set; }
        public DateTime DateNeeded { get; set; }
        public String Remarks { get; set; }
        public Boolean IsClose { get; set; }
        public String RequestedBy { get; set; }
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
