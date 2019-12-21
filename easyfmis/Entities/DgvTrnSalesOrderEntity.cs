using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvTrnSalesOrderEntity
    {
        public Int32 ColumnTrnSalesOrderListId { get; set; }
        public String ColumnTrnSalesOrderListSONumber { get; set; }
        public String ColumnTrnSalesOrderListSODate { get; set; }
        public String ColumnTrnSalesOrderListManualSONumber { get; set; }
        public Int32 ColumnTrnSalesOrderListCustomerId { get; set; }
        public String ColumnTrnSalesOrderListCustomer { get; set; }
        public String ColumnTrnSalesOrderListRemarks { get; set; }
        public Boolean IColumnTrnSalesOrderListsLocked { get; set; }
    }
}
