using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvPurchaseOrderEntity
    {
        public Int32 ColumnPurchaseOrderListId { get; set; }
        public Int32 ColumnPurchaseOrderListBranchId { get; set; }
        public String ColumnPurchaseOrderListPONumber { get; set; }
        public String ColumnPurchaseOrderListPODate { get; set; }
        public String ColumnPurchaseOrderListManualPONumber { get; set; }
        public Int32 ColumnPurchaseOrderListSupplierId { get; set; }
        public Int32 ColumnPurchaseOrderListTermId { get; set; }
        public String ColumnPurchaseOrderListDateNeeded { get; set; }
        public String ColumnPurchaseOrderListRemarks { get; set; }
        public Boolean ColumnPurchaseOrderListIsClose { get; set; }
        public Int32 ColumnPurchaseOrderListRequestedBy { get; set; }
        public Int32 ColumnPurchaseOrderListPreparedBy { get; set; }
        public Int32 ColumnPurchaseOrderListCheckedBy { get; set; }
        public Int32 ColumnPurchaseOrderListApprovedBy { get; set; }
        public Boolean ColumnPurchaseOrderListIsLocked { get; set; }
        public Int32 ColumnPurchaseOrderListCreatedBy { get; set; }
        public String ColumnPurchaseOrderListCreatedString { get; set; }
        public Int32 ColumnPurchaseOrderListUpdatedBy { get; set; }
        public String ColumnPurchaseOrderListUpdatedString { get; set; }
    }
}
