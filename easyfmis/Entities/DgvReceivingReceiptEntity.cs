using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvReceivingReceiptEntity
    {
        public String ColumnReceivingReceiptButtonEdit { get; set; }
        public String ColumnReceivingReceiptButtonDelete { get; set; }
        public Int32 ColumnReceivingReceiptId { get; set; }
        public String ColumnReceivingReceiptRRDate { get; set; }
        public String ColumnReceivingReceiptRRNumber { get; set; }
        public String ColumnReceivingReceiptManualRRNumber { get; set; }
        public String ColumnReceivingReceiptRemarks { get; set; }
        public String ColumnReceivingReceiptAmount { get; set; }
        public Boolean ColumnReceivingReceiptIsLocked { get; set; }
        public String ColumnReceivingReceiptSpace { get; set; }
    }
}