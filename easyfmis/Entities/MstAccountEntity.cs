using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class MstAccountEntity
    {
        public Int32 Id { get; set; }
        public String AccountCode { get; set; }
        public String Account { get; set; }
        public Boolean IsLocked { get; set; }
        public Int32 AccountTypeId { get; set; }
        public String AccountType { get; set; }
    }
}
