using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    class TrnCollectionSalesInvoiceListEntity
    {
        public Int32 Id { get; set; }
        public String SINumber { get; set; }
        public DateTime SIDate { get; set; }
        public String ManualSINumber { get; set; }
        public String Remarks { get; set; }
        public Decimal BalanceAmount { get; set; }
    }
}
