using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class TrnCollectionEntity
    {
        public Int32 Id { get; set; }
        public Int32 BranchId { get; set; }
        public String Branch { get; set; }
        public String ORNumber { get; set; }
        public DateTime ORDate { get; set; }
        public String ManualORNumber { get; set; }
        public Int32 CustomerId { get; set; }
        public String Customer { get; set; }
        public String Remarks { get; set; }
        public Int32 PreparedBy { get; set; }
        public Int32 CheckedBy { get; set; }
        public Int32 ApprovedBy { get; set; }
        public Boolean IsLocked { get; set; }
        public Int32 CreatedBy { get; set; }
        public String CreatedByUserName { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Int32 UpdatedBy { get; set; }
        public String UpdatedByUserName { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
