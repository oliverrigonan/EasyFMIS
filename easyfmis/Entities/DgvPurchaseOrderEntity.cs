using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvPurchaseOrderEntity
    {
        public String ColumnPurchaseOrderListButtonEdit { get; set; }
        public String ColumnPurchaseOrderListButtonDelete { get; set; }
        public Int32 ColumnPurchaseOrderListId { get; set; }
        public String ColumnPurchaseOrderListPONumber { get; set; }
        public String ColumnPurchaseOrderListPODate { get; set; }
        public String ColumnPurchaseOrderListSupplier { get; set; }
        public String ColumnPurchaseOrderListRemarks { get; set; }
        public Boolean ColumnPurchaseOrderListIsClose { get; set; }
        public Boolean ColumnPurchaseOrderListIsLocked { get; set; }
        public String ColumnPurchaseOrderListSpace { get; set; }
    }
}
