using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvMstCompanyEntity
    {
        public String ColumnCompanyListButtonEdit { get; set; }
        public String ColumnCompanyListButtonDelete { get; set; }
        public Int32 ColumnCompanyListId { get; set; }
        public String ColumnCompanyListCompanyCode { get; set; }
        public String ColumnCompanyListCompany { get; set; }
        public Boolean ColumnCompanyListIsLocked { get; set; }
    }
}
