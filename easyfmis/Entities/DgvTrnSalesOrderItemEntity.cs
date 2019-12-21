using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvTrnSalesOrderItemEntity
    {
        public Int32 ColumnTrnSalesOrderItemListId { get; set; }
        public Int32 ColumnTrnSalesOrderItemListSOId { get; set; }
        public Int32 ColumnTrnSalesOrderItemListItemId { get; set; }
        public Int32 ColumnTrnSalesOrderItemListItemInventoryId { get; set; }
        public Int32 ColumnTrnSalesOrderItemListUnitId { get; set; }
        public Decimal ColumnTrnSalesOrderItemListPrice { get; set; }
        public String ColumnTrnSalesOrderItemListDiscountId { get; set; }
        public Decimal ColumnTrnSalesOrderItemListDiscountRate { get; set; }
        public Decimal ColumnTrnSalesOrderItemListDiscountAmount { get; set; }
        public Decimal ColumnTrnSalesOrderItemListNetPrice { get; set; }
        public Decimal ColumnTrnSalesOrderItemListQuantity { get; set; }
        public Decimal ColumnTrnSalesOrderItemListAmount { get; set; }
        public Int32 ColumnTrnSalesOrderItemListTaxId { get; set; }
        public Decimal ColumnTrnSalesOrderItemListTaxRate { get; set; }
        public Decimal ColumnTrnSalesOrderItemListTaxAmount { get; set; }
        public Decimal ColumnTrnSalesOrderItemListBaseQuantity { get; set; }
        public Decimal ColumnTrnSalesOrderItemListBasePrice { get; set; }
    }
}
