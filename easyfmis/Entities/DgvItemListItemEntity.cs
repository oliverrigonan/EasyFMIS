using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvItemListItemEntity
    {
        public String ColumnItemListButtonEdit { get; set; }
        public String ColumnItemListButtonDelete { get; set; }
        public Int32 ColumnItemListId { get; set; }
        public Int32 ColumnItemListArticleTypeId { get; set; }
        public String ColumnItemListArticleCode { get; set; }
        public String ColumnItemListArticleBarCode { get; set; }
        public String ColumnItemListArticle { get; set; }
        public String ColumnItemListArticleAlias { get; set; }
        public String ColumnItemListGenericArticleName { get; set; }
        public String ColumnItemListCategory { get; set; }
        public Int32 ColumnItemListVATInTaxId { get; set; }
        public String ColumnItemListVATInTax { get; set; }
        public Int32 ColumnItemListVATOutTaxId { get; set; }
        public String ColumnItemListVATOutTax { get; set; }
        public Int32 ColumnItemListUnitId { get; set; }
        public String ColumnItemListUnit { get; set; }
        public Int32? ColumnItemListDefaultSupplierId { get; set; }
        public String ColumnItemListDefaultCost { get; set; }
        public String ColumnItemListDefaultPrice { get; set; }
        public String ColumnItemListReorderQuantity { get; set; }
        public Boolean ColumnItemListIsInventory { get; set; }
        public Boolean ColumnItemListIsLocked { get; set; }
        public String ColumnItemListSpace { get; set; }
    }
}
