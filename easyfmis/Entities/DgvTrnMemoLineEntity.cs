using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvTrnMemoLineEntity
    {
        public String ColumnMemoLineListButtonEdit { get; set; }
        public String ColumnMemoLineListButtonDelete { get; set; }
        public Int32 ColumnMemoLineListId { get; set; }
        public Int32 ColumnMemoLineListMOId { get; set; }
        public Int32? ColumnMemoLineListSIId { get; set; }
        public String ColumnMemoLineListSINumber { get; set; }
        public Int32? ColumnMemoLineListRRId { get; set; }
        public String ColumnMemoLineListRRNumber { get; set; }
        public String ColumnMemoLineListDebit { get; set; }
        public String ColumnMemoLineListCredit { get; set; }
        public String ColumnMemoLineListParticulars { get; set; }
        public String ColumnMemoLineListSpace { get; set; }
    }
}
