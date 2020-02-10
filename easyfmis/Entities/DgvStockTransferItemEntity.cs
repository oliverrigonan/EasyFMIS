using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easyfmis.Entities
{
    public class DgvStockTransferItemEntity
    {
        public String ColumnStockTransferItemButtonEdit { get; set; }
        public String ColumnStockTransferItemButtonDelete { get; set; }
        public Int32 ColumnStockTransferItemId { get; set; }
        public Int32 ColumnStockTransferItemSTId { get; set; }
        public Int32 ColumnStockTransferItemItemId { get; set; }
        public String ColumnStockTransferItemItemBarCode { get; set; }
        public String ColumnStockTransferItemItemDescription { get; set; }
        public Int32 ColumnStockTransferItemUnitId { get; set; }
        public String ColumnStockTransferItemUnit { get; set; }
        public Int32 ColumnStockTransferItemInventoryId { get; set; }
        public String ColumnStockTransferItemInventoryCode { get; set; }
        public String ColumnStockTransferItemQuantity { get; set; }
        public String ColumnStockTransferItemCost { get; set; }
        public String ColumnStockTransferItemAmount { get; set; }
        public String ColumnStockTransferItemBaseQuantity { get; set; }
        public String ColumnStockTransferItemBaseCost { get; set; }
        public String ColumnStockTransferItemSpace { get; set; }
    }
}