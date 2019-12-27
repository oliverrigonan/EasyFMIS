using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    public class DgvCollectionLineEntity
    {
        public String ColumnCollectionLineListButtonEdit { get; set; }
        public String ColumnCollectionLineListButtonDelete { get; set; }
        public Int32 ColumnCollectionLineListId { get; set; }
        public Int32 ColumnCollectionLineListORId { get; set; }
        public Int32 ColumnCollectionLineListArticleGroupId { get; set; }
        public String ColumnCollectionLineListArticleGroup { get; set; }
        public Int32? ColumnCollectionLineListSIId { get; set; }
        public String ColumnCollectionLineListSINumber { get; set; }
        public String ColumnCollectionLineListAmount { get; set; }
        public Int32 ColumnCollectionLineListPayTypeId { get; set; }
        public String ColumnCollectionLineListPayType { get; set; }
        public String ColumnCollectionLineListCheckNumber { get; set; }
        public String ColumnCollectionLineListCheckDate { get; set; }
        public String ColumnCollectionLineListCheckBank { get; set; }
        public String ColumnCollectionLineListCreditCardVerificationCode { get; set; }
        public String ColumnCollectionLineListCreditCardNumber { get; set; }
        public String ColumnCollectionLineListCreditCardType { get; set; }
        public String ColumnCollectionLineListCreditCardBank { get; set; }
        public String ColumnCollectionLineListCreditCardReferenceNumber { get; set; }
        public String ColumnCollectionLineListCreditCardHolderName { get; set; }
        public String ColumnCollectionLineListCreditCardExpiry { get; set; }
        public String ColumnCollectionLineListGiftCertificateNumber { get; set; }
        public String ColumnCollectionLineListOtherInformation { get; set; }
        public String ColumnCollectionLineListSpace { get; set; }
    }
}