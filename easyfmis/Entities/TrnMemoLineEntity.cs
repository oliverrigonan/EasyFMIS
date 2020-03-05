using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class TrnMemoLineEntity
    {
        public Int32 Id { get; set; }
        public Int32 MOId { get; set; }
        public Int32? SIId { get; set; }
        public String SINumber { get; set;}
        public Int32? RRId { get; set; }
        public String RRNumber { get; set; }
        public Decimal DebitAmount { get; set; }
        public Decimal CreditAmount { get; set; }
        public String Particulars { get; set; }
    }
}
