using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class TrnDisbursementLineEntity
    {
        public Int32 Id { get; set; }
        public Int32 CVId { get; set; }
        public Int32 ArticleGroupId { get; set; }
        public Int32? RRId { get; set; }
        public String RRNumber { get; set; }
        public Decimal Amount { get; set; }
        public String OtherInformation { get; set; }
    }
}
