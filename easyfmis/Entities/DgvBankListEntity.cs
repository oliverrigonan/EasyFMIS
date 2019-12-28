using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvBankListEntity
    {
        public String ColumnBankListButtonEdit { get; set; }
        public String ColumnBankListButtonDelete { get; set; }
        public Int32 ColumnBankListId { get; set; }
        public String ColumnBankListBankCode { get; set; }
        public String ColumnBankListBank { get; set; }
        public String ColumnBankListContactNumber { get; set; }
        public String ColumnBankListAddress { get; set; }
        public Boolean ColumnBankListIsLocked { get; set; }
        public String ColumnBankListSpace { get; set; }
    }
}
