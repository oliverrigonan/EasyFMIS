using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvInventoryReportEntity
    {
        public String ColumnInventoryReportBarCode { get; set; }
        public String ColumnInventoryReportItemDescription { get; set; }
        public String ColumnInventoryReportInventoryCode { get; set; }
        public String ColumnInventoryReportUnit { get; set; }
        public String ColumnInventoryReportBeginningQuantity { get; set; }
        public String ColumnInventoryReportInQuantity { get; set; }
        public String ColumnInventoryReportOutQuantity { get; set; }
        public String ColumnInventoryReportEndinguantity { get; set; }
        public String ColumnInventoryReportCost { get; set; }
        public String ColumnInventoryReportAmount { get; set; }
        public String ColumnInventoryReportSpace { get; set; }
    }
}
