using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvCollectionEntity
    {
        public String ColumnCollectionButtonEdit { get; set; }
        public String ColumnCollectionButtonDelete { get; set; }
        public Int32 ColumnCollectionId { get; set; }
        public String ColumnCollectionORDate { get; set; }
        public String ColumnCollectionORNumber { get; set; }
        public String ColumnCollectionCustomer { get; set; }
        public String ColumnCollectionRemarks { get; set; }
        public Boolean ColumnCollectionIsLocked { get; set; }
        public String ColumnCollectionSpace { get; set; }
    }
}