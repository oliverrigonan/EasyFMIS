using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    class MstUnitEntity
    {
        public Int32 Id { get; set; }
        public String Unit { get; set; }
        public Boolean IsLocked { get; set; }
    }
}
