using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    class RepAccountsReceivableStatementOfAccountReportEntity
    {
        public Int32 Id { get; set; }
        public String Branch { get; set; }
        public String SINumber { get; set; }
        public DateTime SIDate { get; set; }
        public String ManualSINumber { get; set; }
        public String Customer { get; set; }
        public String Term { get; set; }
        public String Remarks { get; set; }
        public String SoldBy { get; set; }
        public String PreparedBy { get; set; }
        public String CheckedBy { get; set; }
        public String ApprovedBy { get; set; }
        public Decimal Amount { get; set; }
        public Decimal PaidAmount { get; set; }
        public Decimal MemoAmount { get; set; }
        public Decimal BalanceAmount { get; set; }
    }
}
