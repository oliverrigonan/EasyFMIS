using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easyfmis.Entities
{
    public class MstCompanyEntity
    {
        public Int32 Id { get; set; }
        public String CompanyCode { get; set; }
        public String Company { get; set; }
        public Boolean IsLocked { get; set; }
        public Int32 CreatedBy { get; set; }
        public String CreatedByUserName { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Int32 UpdatedBy { get; set; }
        public String UpdatedByUserName { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}