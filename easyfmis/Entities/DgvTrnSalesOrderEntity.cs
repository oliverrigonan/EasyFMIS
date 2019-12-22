using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvTrnSalesOrderEntity
    {
        public String ColumnTrnSalesOrderListButtonEdit { get; set; }
        public String ColumnTrnSalesOrderListButtonDelete { get; set; }
        public Int32 ColumnTrnSalesOrderListId { get; set; }
        public String ColumnTrnSalesOrderListSONumber { get; set; }
        public String ColumnTrnSalesOrderListSODate { get; set; }
        public String ColumnTrnSalesOrderListCustomer { get; set; }
        public String ColumnTrnSalesOrderListRemarks { get; set; }
        public Boolean ColumnTrnSalesOrderListsLocked { get; set; }
        public String ColumnTrnSalesOrderListSpace { get; set; }
    }
}
