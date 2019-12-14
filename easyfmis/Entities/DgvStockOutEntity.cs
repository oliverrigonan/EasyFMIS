using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easyfmis.Entities
{
    public class DgvStockOutEntity
    {
        public String ColumnStockOutButtonEdit { get; set; }
        public String ColumnStockOutButtonDelete { get; set; }
        public Int32 ColumnStockOutId { get; set; }
        public String ColumnStockOutOTDate { get; set; }
        public String ColumnStockOutOTNumber { get; set; }
        public String ColumnStockOutRemarks { get; set; }
        public Boolean ColumnStockOutIsLocked { get; set; }
        public String ColumnStockOutSpace { get; set; }
    }
}