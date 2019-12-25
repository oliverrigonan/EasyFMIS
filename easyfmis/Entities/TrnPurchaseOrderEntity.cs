using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class TrnPurchaseOrderEntity
    {
        public Int32 Id { get; set; }
        public Int32 BranchId { get; set; }
        public String Branch { get; set; }
        public String PONumber { get; set; }
        public DateTime PODate { get; set; }
        public String ManualPONumber { get; set; }
        public Int32 SupplierId { get; set; }
        public String Supplier { get; set; }
        public Int32 TermId { get; set; }
        public String Term { get; set; }
        public DateTime DateNeeded { get; set; }
        public String Remarks { get; set; }
        public Boolean IsClose { get; set; }
        public Int32 RequestedBy { get; set; }
        public String RequestedByFullName { get; set; }
        public Int32 PreparedBy { get; set; }
        public String PreparedByFullName { get; set; }
        public Int32 CheckedBy { get; set; }
        public String CheckedByFullName { get; set; }
        public Int32 ApprovedBy { get; set; }
        public String ApprovedByFullName { get; set; }
        public Boolean IsLocked { get; set; }
        public Int32 CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Int32 UpdatedBy { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
