using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class SysCurrentEntity
    {
        public String CurrentUserId { get; set; }
        public String CurrentUserName { get; set; }
        public String CurrentUserFullName { get; set; }
        public String SoftwareVersion { get; set; }
        public String SoftwareDeveloper { get; set; }
        public String SoftwareContactSupportNumber { get; set; }
        public String LicenseCode { get; set; }
        public String ItemImagePath { get; set; }
    }
}