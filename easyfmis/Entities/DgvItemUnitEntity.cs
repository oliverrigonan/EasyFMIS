using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvItemUnitEntity
    {
        public String ColumnItemArtilceUnitButtonEdit { get; set; }
        public String ColumnItemArtilceUnitButtonDelete { get; set; }
        public Int32 ColumnArtilceUnitListId { get; set; }
        public Int32 ColumnArtilceUnitListArticleId { get; set; }
        public String ColumnArtilceUnitListBaseUnit { get; set; }
        public String ColumnArtilceUnitListEquals { get; set; }
        public String ColumnArtilceUnitListBaseUnitMultiplier { get; set; }
        public String ColumnArtilceUnitListUnitMultiplier { get; set; }
        public Int32 ColumnItemUnitConversionListUnitId { get; set; }
        public String ColumnArtilceUnitListUnit { get; set; }
    }
}
