using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class MstTaxEntity
    {
        public Int32 Id { get; set; }
        public String TaxCode { get; set; }
        public String Tax { get; set; }
        public Decimal Rate { get; set; }
        public Int32 AccountId { get; set; }
        public String Account { get; set; }
        public Boolean IsLocked { get; set; }
        public Int32 CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Int32 UpdatedBy { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
