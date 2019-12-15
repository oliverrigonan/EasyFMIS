using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvItemComponentEntity
    {
        public String ColumnItemComponentButtonEdit { get; set; }
        public String ColumnItemComponentButtonDelete { get; set; }
        public Int32 ColumnItemComponentId { get; set; }
        public Int32 ColumnItemComponentItemId { get; set; }
        public String ColumnItemComponenItemDescription { get; set; }
        public Int32 ColumnItemComponentComponentItemId { get; set; }
        public String ColumnItemComponentComponentItemDescription { get; set; }
        public Int32 ColumnItemComponenUnitId { get; set; }
        public String ColumnItemComponenUnit { get; set; }
        public String ColumnItemComponenQuantity { get; set; }
        public String ColumnItemComponenCost { get; set; }
        public String ColumnItemComponenAmount { get; set; }
    }
}
