using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvTrnMemoEntity
    {
        public String ColumnMemoListButtonEdit { get; set; }
        public String ColumnMemoListButtonDelete { get; set; }
        public Int32 ColumnMemoListId { get; set; }
        public String ColumnMemoListMONumber { get; set; }
        public String ColumnMemoListMODate { get; set; }
        public String ColumnMemoListArticle { get; set; }
        public String ColumnMemoListRemarks { get; set; }
        public Boolean ColumnMemoListIsLocked { get; set; }
        public String ColumnMemoListSpace { get; set; }
    }
}
