using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvRepAccountsPayableReportEntity
    {
        public Int32 ColumnAccountsPayableReportRRId { get; set; }
        public String ColumnAccountsPayableReportBranch { get; set; }
        public String ColumnAccountsPayableReportRRNumber { get; set; }
        public String ColumnAccountsPayableReportRRDate { get; set; }
        public String ColumnAccountsPayableReportManualRRNumber { get; set; }
        public String ColumnAccountsPayableReportSupplierCode { get; set; }
        public String ColumnAccountsPayableReportSupplier { get; set; }
        public String ColumnAccountsPayableReportDueDate { get; set; }
        public String ColumnAccountsPayableReportBalanceAmount { get; set; }
        public String ColumnAccountsPayableReportCurrentAmount { get; set; }
        public String ColumnAccountsPayableReportAge30Amount { get; set; }
        public String ColumnAccountsPayableReportAge60Amount { get; set; }
        public String ColumnAccountsPayableReportAge90Amount { get; set; }
        public String ColumnAccountsPayableReportAge120Amount { get; set; }
        public String ColumnAccountsPayableReportSpace { get; set; }
    }
}