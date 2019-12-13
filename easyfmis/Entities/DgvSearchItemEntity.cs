using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easyfmis.Entities
{
    public class DgvSearchItemEntity
    {
        public object ColumnSearchItemId { get; set; }
        public object ColumnSearchItemBarCode { get; set; }
        public object ColumnSearchItemDescription { get; set; }
        public object ColumnSearchItemUnitId { get; set; }
        public object ColumnSearchItemUnit { get; set; }
        public object ColumnSearchItemPrice { get; set; }
        public string ColumnSearchItemButtonPick { get; set; }
    }
}