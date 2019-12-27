using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class TrnDisbursementEntity
    {
        public Int32 Id { get; set; }
        public Int32 BranchId { get; set; }
        public String Branch { get; set; }
        public String CVNumber { get; set; }
        public DateTime CVDate { get; set; }
        public String ManualCVNumber { get; set; }
        public Int32 SupplierId { get; set; }
        public String Supplier { get; set; }
        public String Payee { get; set; }
        public Int32 PayTypeId { get; set; }
        public Int32 BankId { get; set; }
        public String Remarks { get; set; }
        public Decimal Amount { get; set; }
        public String CheckNumber { get; set; }
        public DateTime? CheckDate { get; set; }
        public Boolean IsCrossCheck { get; set; }
        public Boolean IsClear { get; set; }
        public Int32 PreparedBy { get; set; }
        public Int32 CheckedBy { get; set; }
        public Int32 ApprovedBy { get; set; }
        public Boolean IsLocked { get; set; }
        public Int32 CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Int32 UpdatedBy { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
