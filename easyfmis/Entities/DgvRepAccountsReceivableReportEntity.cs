using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvRepAccountsReceivableReportEntity
    {
        public Int32 ColumnAccountsReceivableReportSIId { get; set; }
        public String ColumnAccountsReceivableReportBranch { get; set; }
        public String ColumnAccountsReceivableReportSINumber { get; set; }
        public String ColumnAccountsReceivableReportSIDate { get; set; }
        public String ColumnAccountsReceivableReportManualSINumber { get; set; }
        public String ColumnAccountsReceivableReportCustomerCode { get; set; }
        public String ColumnAccountsReceivableReportCustomer { get; set; }
        public String ColumnAccountsReceivableReportDueDate { get; set; }
        public String ColumnAccountsReceivableReportBalanceAmount { get; set; }
        public String ColumnAccountsReceivableReportCurrentAmount { get; set; }
        public String ColumnAccountsReceivableReportAge30Amount { get; set; }
        public String ColumnAccountsReceivableReportAge60Amount { get; set; }
        public String ColumnAccountsReceivableReportAge90Amount { get; set; }
        public String ColumnAccountsReceivableReportAge120Amount { get; set; }
        public String ColumnAccountsReceivableReportSpace { get; set; }
    }
}