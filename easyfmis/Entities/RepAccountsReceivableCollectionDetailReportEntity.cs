using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Entities
{
    class RepAccountsReceivableCollectionDetailReportEntity
    {
        public Int32 Id { get; set; }
        public String Branch { get; set; }
        public String ORNumber { get; set; }
        public String ORDate { get; set; }
        public String ManualORNumber { get; set; }
        public String Customer { get; set; }
        public String Remarks { get; set; }
        public String PreparedBy { get; set; }
        public String CheckedBy { get; set; }
        public String ApprovedBy { get; set; }
        public String ArticleGroup { get; set; }
        public String SINumber { get; set; }
        public Decimal Amount { get; set; }
        public String PayType { get; set; }
        public String CheckNumber { get; set; }
        public DateTime CheckDate { get; set; }
        public String CheckBank { get; set; }
        public String CreditCardVerificationCode { get; set; }
        public String CreditCardNumber { get; set; }
        public String CreditCardType { get; set; }
        public String CreditCardBank { get; set; }
        public String CreditCardReferenceNumber { get; set; }
        public String CreditCardHolderName { get; set; }
        public String CreditCardExpiry { get; set; }
        public String GiftCertificateNumber { get; set; }
        public String OtherInformation { get; set; }
    }
}
