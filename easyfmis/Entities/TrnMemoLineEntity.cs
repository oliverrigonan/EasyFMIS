using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    class TrnMemoLineEntity
    {
        public Int32 Id { get; set; }
        public Int32 MOId { get; set; }
        public Int32 SIId { get; set; }
        public Int32 RRId { get; set; }
        public Decimal Amount { get; set; }
        public String Particulars { get; set; }
    }
}
