using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvReceivingReceiptItemEntity
    {
        public String ColumnReceivingReceiptItemListButtonEdit { get; set; }
        public String ColumnReceivingReceiptItemListButtonDelete { get; set; }
        public Int32 ColumnReceivingReceiptItemListId { get; set; }
        public Int32 ColumnReceivingReceiptItemListRRId { get; set; }
        public Int32? ColumnReceivingReceiptItemListPOId { get; set; }
        public String ColumnReceivingReceiptItemListPONumber{ get; set; }
        public Int32 ColumnReceivingReceiptItemListItemId { get; set; }
        public String ColumnReceivingReceiptItemListItemBarCode { get; set; }
        public String ColumnReceivingReceiptItemListItemDescription { get; set; }
        public Int32 ColumnReceivingReceiptItemListUnitId { get; set; }
        public String ColumnReceivingReceiptItemListUnit { get; set; }
        public String ColumnReceivingReceiptItemListQuantity { get; set; }
        public String ColumnReceivingReceiptItemListCost { get; set; }
        public String ColumnReceivingReceiptItemListAmount { get; set; }
        public Int32 ColumnReceivingReceiptItemListBranchId { get; set; }
        public String ColumnReceivingReceiptItemListBranch { get; set; }
        public Int32 ColumnReceivingReceiptItemListTaxId { get; set; }
        public String ColumnReceivingReceiptItemListTax { get; set; }
        public String ColumnReceivingReceiptItemListTaxRate { get; set; }
        public String ColumnReceivingReceiptItemListTaxAmount { get; set; }
        public String ColumnReceivingReceiptItemListBaseQuantity { get; set; }
        public String ColumnReceivingReceiptItemListBaseCost { get; set; }
        public String ColumnReceivingReceiptItemListSpace { get; set; }
    }
}