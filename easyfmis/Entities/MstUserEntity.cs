using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easyfmis.Entities
{
    public class MstUserEntity
    {
        public Int32 Id { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String FullName { get; set; }
        public Int32 CompanyId { get; set; }
        public String Company { get; set; }
        public Int32 BranchId { get; set; }
        public String Branch { get; set; }
        public Boolean IsLocked { get; set; }
        public Int32 CreatedBy { get; set; }
        public String CreatedByUserName { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Int32 UpdatedBy { get; set; }
        public String UpdatedByUserName { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}