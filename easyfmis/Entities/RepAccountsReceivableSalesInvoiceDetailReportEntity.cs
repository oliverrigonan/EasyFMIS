using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    class RepAccountsReceivableSalesInvoiceDetailReportEntity
    {
        public Int32 Id { get; set; }
        public String Branch { get; set; }
        public String SINumber { get; set; }
        public String SIDate { get; set; }
        public String ManualSINumber { get; set; }
        public String Customer { get; set; }
        public String Term { get; set; }
        public String Remarks { get; set; }
        public String SoldBy { get; set; }
        public String PreparedBy { get; set; }
        public String CheckedBy { get; set; }
        public String ApprovedBy { get; set; }
        public Decimal PaidAmount { get; set; }
        public Decimal MemoAmount { get; set; }
        public Decimal BalanceAmount { get; set; }
        public String ItemCode { get; set; }
        public String ItemDescription { get; set; }
        public String ItemInventoryCode { get; set; }
        public String Unit { get; set; }
        public Decimal Price { get; set; }
        public String Discount { get; set; }
        public Decimal DiscountRate { get; set; }
        public Decimal DiscountAmount { get; set; }
        public Decimal NetPrice { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal Amount { get; set; }
        public String Tax { get; set; }
        public Decimal TaxRate { get; set; }
        public Decimal TaxAmount { get; set; }
        public Decimal BaseQuantity { get; set; }
        public Decimal BasePrice { get; set; }
    }
}
