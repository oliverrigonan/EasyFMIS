using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class SysMenuItemListEntity
    {
        public Int32 Id { get; set; }
        public String ItemCode { get; set; }
        public String ItemDescription { get; set; }
        public Decimal? OnHandQuatity { get; set; }
        public String Unit { get; set; }
    }
}
