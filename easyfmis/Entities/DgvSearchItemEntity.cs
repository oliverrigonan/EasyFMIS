using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easyfmis.Entities
{
    public class DgvSearchItemEntity
    {
        public Int32 ColumnSearchItemId { get; set; }
        public String ColumnSearchItemBarCode { get; set; }
        public String ColumnSearchItemDescription { get; set; }
        public Int32 ColumnSearchItemUnitId { get; set; }
        public String ColumnSearchItemUnit { get; set; }
        public String ColumnSearchItemPrice { get; set; }
        public String ColumnSearchItemButtonPick { get; set; }
    }
}