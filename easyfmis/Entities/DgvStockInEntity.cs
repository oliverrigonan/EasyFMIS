using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easyfmis.Entities
{
    public class DgvStockInEntity
    {
        public String ColumnStockInButtonEdit { get; set; }
        public String ColumnStockInButtonDelete { get; set; }
        public Int32 ColumnStockInId { get; set; }
        public String ColumnStockInINDate { get; set; }
        public String ColumnStockInINNumber { get; set; }
        public String ColumnStockInRemarks { get; set; }
        public Boolean ColumnStockInIsLocked { get; set; }
        public String ColumnStockInSpace { get; set; }
    }
}