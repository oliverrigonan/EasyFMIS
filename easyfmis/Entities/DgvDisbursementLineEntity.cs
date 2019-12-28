using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvDisbursementLineEntity
    {
        public String ColumnDisbursementLineListButtonEdit { get; set; }
        public String ColumnDisbursementLineListButtonDelete { get; set; }
        public Int32 ColumnDisbursementLineListId { get; set; }
        public Int32 ColumnDisbursementLineListCVId { get; set; }
        public Int32 ColumnDisbursementLineListArticleGroupId { get; set; }
        public String ColumnDisbursementLineListArticleGroup { get; set; }
        public Int32? ColumnDisbursementLineListRRId { get; set; }
        public String ColumnDisbursementLineListRR { get; set; }
        public String ColumnDisbursementLineListAmount { get; set; }
        public String ColumnDisbursementLineListOtherInformation { get; set; }
        public String ColumnDisbursementLineListSpace { get; set; }

    }
}
