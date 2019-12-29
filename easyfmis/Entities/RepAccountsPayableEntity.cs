using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    class RepAccountsPayableEntity
    {
        public Int32 RRId { get; set; }
        public String Branch { get; set; }
        public String RRNumber { get; set; }
        public String RRDate { get; set; }
        public String ManualRRNumber { get; set; }
        public String SupplierCode { get; set; }
        public String Supplier { get; set; }
        public String DueDate { get; set; }
        public Decimal BalanceAmount { get; set; }
        public Decimal CurrentAmount { get; set; }
        public Decimal Age30Amount { get; set; }
        public Decimal Age60Amount { get; set; }
        public Decimal Age90Amount { get; set; }
        public Decimal Age120Amount { get; set; }
    }
}
