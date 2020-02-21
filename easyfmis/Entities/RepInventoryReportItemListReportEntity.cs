using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    class RepInventoryReportItemListReportEntity
    {
        public Int32 Id { get; set; }
        public String Code { get; set; }
        public String ItemDescription { get; set; }
        public String BarCode { get; set; }
        public String Category { get; set; }
        public String Unit { get; set; }
        public Decimal Price { get; set; }
    }
}
