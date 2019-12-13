using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easyfmis.Entities
{
    public class MstArticleEntity
    {
        public Int32 Id { get; set; }
        public Int32 ArticleTypeId { get; set; }
        public String ArticleCode { get; set; }
        public String ArticleBarCode { get; set; }
        public String Article { get; set; }
        public String ArticleAlias { get; set; }
        public String GenericArticleName { get; set; }
        public String Category { get; set; }
        public Int32 VATInTaxId { get; set; }
        public String VATInTax { get; set; }
        public Int32 VATOutTaxId { get; set; }
        public String VATOutTax { get; set; }
        public Int32 UnitId { get; set; }
        public String Unit { get; set; }
        public Int32? DefaultSupplierId { get; set; }
        public String DefaultSupplier { get; set; }
        public Decimal DefaultCost { get; set; }
        public Decimal DefaultPrice { get; set; }
        public Decimal ReorderQuantity { get; set; }
        public Boolean IsInventory { get; set; }
        public String Address { get; set; }
        public String ContactPerson { get; set; }
        public String ContactNumber { get; set; }
        public String EmailAddress { get; set; }
        public String TIN { get; set; }
        public String Remarks { get; set; }
        public Boolean IsLocked { get; set; }
        public Int32 CreatedBy { get; set; }
        public String CreatedByUserName { get; set; }
        public DateTime CreatedByDateTime { get; set; }
        public Int32 UpdatedBy { get; set; }
        public String UpdatedByUserName { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}