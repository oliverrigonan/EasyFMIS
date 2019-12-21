using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easyfmis.Entities
{
    public class DgvStockTransferEntity
    {
        public String ColumnStockTransferButtonEdit { get; set; }
        public String ColumnStockTransferButtonDelete { get; set; }
        public Int32 ColumnStockTransferId { get; set; }
        public String ColumnStockTransferSTDate { get; set; }
        public String ColumnStockTransferSTNumber { get; set; }
        public String ColumnStockTransferToBranch { get; set; }
        public String ColumnStockTransferRemarks { get; set; }
        public Boolean ColumnStockTransferIsLocked { get; set; }
        public String ColumnStockTransferSpace { get; set; }
    }
}