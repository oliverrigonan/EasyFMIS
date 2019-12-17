using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvUserListEntity
    {
        public String ColumnUserListButtonEdit { get; set; }
        public String ColumnUserListButtonDelete { get; set; }
        public Int32 ColumnUserListId { get; set; }
        public String ColumnUserListUserName { get; set; }
        public String ColumnUserListFullName { get; set; }
        public Int32 ColumnUserListCompanyId { get; set; }
        public String ColumnUserListCompany { get; set; }
        public Int32 ColumnUserListBranchId { get; set; }
        public String ColumnUserListBranch { get; set; }
        public Boolean ColumnUserListIsLocked { get; set; }
    }
}
