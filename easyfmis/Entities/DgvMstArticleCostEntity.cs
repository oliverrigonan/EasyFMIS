using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvMstArticleCostEntity
    {
        public String ColumnAticleCostButtonEdit { get; set; }
        public String ColumnAticleCostButtonDelete { get; set; }
        public Int32 ColumnAticleCostId { get; set; }
        public Int32 ColumnAticleCostArticleId { get; set; }
        public String ColumnAticleCostCostDescription { get; set; }
        public String ColumnAticleCostCost { get; set; }
        public Int32 ColumnAticleCostCurrencyId { get; set; }
        public String ColumnAticleCostCurrency { get; set; }
        public String ColumnAticleCostSpace { get; set; }
    }
}
