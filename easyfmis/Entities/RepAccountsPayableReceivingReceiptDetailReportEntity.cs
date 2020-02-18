using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class RepAccountsPayableReceivingReceiptDetailReportEntity
    {
        public Int32 Id { get; set; }
        public String Branch { get; set; }
        public String RRNumber { get; set; }
        public DateTime RRDate { get; set; }
        public String ManualRRNumber { get; set; }
        public String Supplier { get; set; }
        public String Term { get; set; }
        public String Remarks { get; set; }
        public String ReceivedBy { get; set; }
        public String PreparedBy { get; set; }
        public String CheckedBy { get; set; }
        public String ApprovedBy { get; set; }
        public Boolean IsLocked { get; set; }
        public Decimal PaidAmount { get; set; }
        public Decimal MemoAmount { get; set; }
        public String PONumber { get; set; }
        public String ItemCode { get; set; }
        public String ItemDescription { get; set; }
        public String Unit { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal Cost { get; set; }
        public Decimal Amount { get; set; }
        public String Tax { get; set; }
        public Decimal TaxRate { get; set; }
        public Decimal TaxAmount { get; set; }
        public Decimal BaseQuantity { get; set; }
        public Decimal BaseCost { get; set; }
    }
}
