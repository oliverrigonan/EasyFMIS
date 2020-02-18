using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    class RepAccountsPayableDisbursementDetailReportEntity
    {
        public Int32 Id { get; set; }
        public String Branch { get; set; }
        public String CVNumber { get; set; }
        public String CVDate { get; set; }
        public String ManualCVNumber { get; set; }
        public String Supplier { get; set; }
        public String Payee { get; set; }
        public String PayType { get; set; }
        public String Bank { get; set; }
        public String Remarks { get; set; }
        public String CheckNumber { get; set; }
        public String CheckDate { get; set; }
        public Boolean IsCrossCheck { get; set; }
        public Boolean IsClear { get; set; }
        public String PreparedBy { get; set; }
        public String CheckedBy { get; set; }
        public String ApprovedBy { get; set; }
        public String ArticleGroup { get; set; }
        public String RRNumber { get; set; }
        public Decimal Amount { get; set; }
        public String Particulars { get; set; }
    }
}
