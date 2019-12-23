using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvTrnSalesOrderItemEntity
    {
        public String ColumnTrnSalesOrderItemListButtonEdit { get; set; }
        public String ColumnTrnSalesOrderItemListButtonDelete { get; set; }
        public Int32 ColumnTrnSalesOrderItemListId { get; set; }
        public Int32 ColumnTrnSalesOrderItemListSOId { get; set; }
        public Int32 ColumnTrnSalesOrderItemListItemId { get; set; }
        public String ColumnTrnSalesOrderItemListItemDescription { get; set; }
        public Int32? ColumnTrnSalesOrderItemListItemInventoryId { get; set; }
        public String ColumnTrnSalesOrderItemListItemInventoryCode { get; set; }
        public Int32 ColumnTrnSalesOrderItemListUnitId { get; set; }
        public String ColumnTrnSalesOrderItemListUnit { get; set; }
        public String ColumnTrnSalesOrderItemListPrice { get; set; }
        public Int32 ColumnTrnSalesOrderItemListDiscountId { get; set; }
        public String ColumnTrnSalesOrderItemListDiscount { get; set; }
        public String ColumnTrnSalesOrderItemListDiscountRate { get; set; }
        public String ColumnTrnSalesOrderItemListDiscountAmount { get; set; }
        public String ColumnTrnSalesOrderItemListNetPrice { get; set; }
        public String ColumnTrnSalesOrderItemListQuantity { get; set; }
        public String ColumnTrnSalesOrderItemListAmount { get; set; }
        public Int32 ColumnTrnSalesOrderItemListTaxId { get; set; }
        public String ColumnTrnSalesOrderItemListTax { get; set; }
        public String ColumnTrnSalesOrderItemListTaxRate { get; set; }
        public String ColumnTrnSalesOrderItemListTaxAmount { get; set; }
        public String ColumnTrnSalesOrderItemListBaseQuantity { get; set; }
        public String ColumnTrnSalesOrderItemListBasePrice { get; set; }
        public String ColumnSalesOrderItemSpace { get; set; }
    }
}
