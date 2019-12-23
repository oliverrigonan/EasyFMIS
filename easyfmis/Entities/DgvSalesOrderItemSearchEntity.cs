using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easyfmis.Entities
{
    public class DgvSalesOrderItemSearchEntity
    {
        public String ColumnStockOutItemButtonEdit { get; set; }
        public String ColumnStockOutItemButtonDelete { get; set; }
        public Int32 ColumnStockOutItemId { get; set; }
        public Int32 ColumnStockOutItemSOId { get; set; }
        public Int32 ColumnStockOutItemItemId { get; set; }
        public String ColumnStockOutItemItemDescription { get; set; }
        public Int32 ColumnStockOutItemUnitId { get; set; }
        public String ColumnStockOutItemUnit { get; set; }
        public Int32 ColumnStockOutItemInventoryId { get; set; }
        public String ColumnStockOutItemInventoryCode { get; set; }
        public String ColumnStockOutItemQuantity { get; set; }
        public String ColumnStockOutItemCost { get; set; }
        public String ColumnStockOutItemAmount { get; set; }
        public String ColumnStockOutItemBaseQuantity { get; set; }
        public String ColumnStockOutItemBaseCost { get; set; }
        public String ColumnStockOutItemSpace { get; set; }
    }
}