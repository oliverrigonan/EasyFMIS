using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class RepInventoryReportStockCard
    {
        public String Document { get; set; }
        public DateTime InventoryDate { get; set; }
        public String Unit { get; set; }
        public Decimal BeginningQuantity { get; set; }
        public Decimal InQuantity { get; set; }
        public Decimal OutQuantity { get; set; }
        public Decimal Runninguantity { get; set; }
        public Decimal Cost { get; set; }
        public Decimal Amount { get; set; }
    }
}
