using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class MstUserFormEntity
    {
        public Int32 Id { get; set; }
        public Int32 FormId { get; set; }
        public String Form { get; set; }
        public Int32 UserId { get; set; }
        public Boolean CanDelete { get; set; }
        public Boolean CanAdd { get; set; }
        public Boolean CanLock { get; set; }
        public Boolean CanUnlock { get; set; }
        public Boolean CanPrint { get; set; }
        public Boolean CanPreview { get; set; }
        public Boolean CanEdit { get; set; }
    }
}
