using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvDisbursementEntity
    {
        public String ColumnDisbursementListButtonEdit { get; set; }
        public String ColumnDisbursementListButtonDelete { get; set; }
        public Int32 ColumnDisbursementListId { get; set; }
        public String ColumnDisbursementListCVDate { get; set; }
        public String ColumnDisbursementListCVNumber { get; set; }
        public String ColumnDisbursementListSupplier { get; set; }
        public String ColumnDisbursementListRemarks { get; set; }
        public String ColumnDisbursementListAmount { get; set; }
        public Boolean ColumnDisbursementListIsCrossCheck { get; set; }
        public Boolean ColumnDisbursementListIsClear { get; set; }
        public Boolean ColumnDisbursementListIsLocked { get; set; }
        public String ColumnDisbursementListSpace { get; set; }
    }
}
