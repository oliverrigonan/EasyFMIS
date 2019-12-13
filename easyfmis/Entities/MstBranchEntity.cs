using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easyfmis.Entities
{
    public class MstBranchEntity
    {
        public Int32 Id { get; set; }
        public String BranchCode { get; set; }
        public String Branch { get; set; }
        public Int32 CompanyId { get; set; }
    }
}