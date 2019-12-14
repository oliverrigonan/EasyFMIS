using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class RepInventoryReport
    {
        public String BarCode { get; set; }
        public String ItemDescription { get; set; }
        public String InventoryCode { get; set; }
        public String Unit { get; set; }
        public Decimal BeginningQuantity { get; set; }
        public Decimal InQuantity { get; set; }
        public Decimal OutQuantity { get; set; }
        public Decimal Endinguantity { get; set; }
        public Decimal Cost { get; set; }
        public Decimal Amount { get; set; }
    }
}
