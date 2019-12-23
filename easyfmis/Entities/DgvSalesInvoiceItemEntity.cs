using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvSalesInvoiceItemEntity
    {
        public String ColumnSalesInvoiceItemListButtonEdit { get; set; }
        public String ColumnSalesInvoiceItemListButtonDelete { get; set; }
        public Int32 ColumnSalesInvoiceItemListId { get; set; }
        public Int32 ColumnSalesInvoiceItemListSIId { get; set; }
        public Int32 ColumnSalesInvoiceItemListItemId { get; set; }
        public String ColumnSalesInvoiceItemListItemDescription { get; set; }
        public Int32? ColumnSalesInvoiceItemListItemInventoryId { get; set; }
        public String ColumnSalesInvoiceItemListItemInventoryCode { get; set; }
        public Int32 ColumnSalesInvoiceItemListUnitId { get; set; }
        public String ColumnSalesInvoiceItemListUnit { get; set; }
        public String ColumnSalesInvoiceItemListPrice { get; set; }
        public Int32 ColumnSalesInvoiceItemListDiscountId { get; set; }
        public String ColumnSalesInvoiceItemListDiscount { get; set; }
        public String ColumnSalesInvoiceItemListDiscountRate { get; set; }
        public String ColumnSalesInvoiceItemListDiscountAmount { get; set; }
        public String ColumnSalesInvoiceItemListNetPrice { get; set; }
        public String ColumnSalesInvoiceItemListQuantity { get; set; }
        public String ColumnSalesInvoiceItemListAmount { get; set; }
        public Int32 ColumnSalesInvoiceItemListTaxId { get; set; }
        public String ColumnSalesInvoiceItemListTax { get; set; }
        public String ColumnSalesInvoiceItemListTaxRate { get; set; }
        public String ColumnSalesInvoiceItemListTaxAmount { get; set; }
        public String ColumnSalesInvoiceItemListBaseQuantity { get; set; }
        public String ColumnSalesInvoiceItemListBasePrice { get; set; }
        public String ColumnSalesInvoiceItemListSpace { get; set; }
    }
}