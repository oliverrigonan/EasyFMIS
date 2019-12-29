using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvSalesInvoiceEntity
    {
        public String ColumnSalesInvoiceButtonEdit { get; set; }
        public String ColumnSalesInvoiceButtonDelete { get; set; }
        public Int32 ColumnSalesInvoiceId { get; set; }
        public String ColumnSalesInvoiceSIDate { get; set; }
        public String ColumnSalesInvoiceSINumber { get; set; }
        public String ColumnSalesInvoiceManualSINumber { get; set; }
        public String ColumnSalesInvoiceCustomer { get; set; }
        public String ColumnSalesInvoiceRemarks { get; set; }
        public String ColumnSalesInvoiceAmount { get; set; }
        public String ColumnSalesInvoicePaidAmount { get; set; }
        public Boolean ColumnSalesInvoiceIsLocked { get; set; }
        public String ColumnSalesInvoiceSpace { get; set; }
    }
}