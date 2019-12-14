using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easyfmis.Entities
{
    public class DgvStockInItemEntity
    {
        public String ColumnStockInItemButtonEdit { get; set; }
        public String ColumnStockInItemButtonDelete { get; set; }
        public Int32 ColumnStockInItemId { get; set; }
        public Int32 ColumnStockInItemINId { get; set; }
        public Int32 ColumnStockInItemItemId { get; set; }
        public String ColumnStockInItemItemDescription { get; set; }
        public Int32 ColumnStockInItemUnitId { get; set; }
        public String ColumnStockInItemUnit { get; set; }
        public String ColumnStockInItemQuantity { get; set; }
        public String ColumnStockInItemCost { get; set; }
        public String ColumnStockInItemAmount { get; set; }
        public String ColumnStockInItemBaseQuantity { get; set; }
        public String ColumnStockInItemBaseCost { get; set; }
        public String ColumnStockInItemSpace { get; set; }
    }
}