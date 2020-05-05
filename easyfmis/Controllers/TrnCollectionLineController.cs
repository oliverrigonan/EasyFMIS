using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class TrnCollectionLineController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ====================
        // List Collection Line
        // ====================
        public List<Entities.TrnCollectionLineEntity> ListCollectionLine(Int32 ORId)
        {
            var collectionLines = from d in db.TrnCollectionLines
                                  where d.ORId == ORId
                                  select new Entities.TrnCollectionLineEntity
                                  {
                                      Id = d.Id,
                                      ORId = d.ORId,
                                      ArticleGroupId = d.ArticleGroupId,
                                      ArticleGroup = d.MstArticleGroup.ArticleGroup,
                                      SIId = d.SIId,
                                      SINumber = d.SIId != null ? d.TrnSalesInvoice.SINumber : "",
                                      Amount = d.Amount,
                                      PayTypeId = d.PayTypeId,
                                      PayType = d.MstPayType.PayType,
                                      CheckNumber = d.CheckNumber,
                                      CheckDate = d.CheckDate,
                                      CheckBank = d.CheckBank,
                                      CreditCardVerificationCode = d.CreditCardVerificationCode,
                                      CreditCardNumber = d.CreditCardNumber,
                                      CreditCardType = d.CreditCardType,
                                      CreditCardBank = d.CreditCardBank,
                                      CreditCardReferenceNumber = d.CreditCardReferenceNumber,
                                      CreditCardHolderName = d.CreditCardHolderName,
                                      CreditCardExpiry = d.CreditCardExpiry,
                                      GiftCertificateNumber = d.GiftCertificateNumber,
                                      OtherInformation = d.OtherInformation
                                  };

            return collectionLines.OrderByDescending(d => d.Id).ToList();
        }

        // ===========================
        // Dropdown List Article Group
        // ===========================
        public List<Entities.MstArticleGroupEntity> DropdownListArticleGroup()
        {
            var articleGroups = from d in db.MstArticleGroups
                                where d.ArticleTypeId == 2
                                select new Entities.MstArticleGroupEntity
                                {
                                    Id = d.Id,
                                    ArticleGroup = d.ArticleGroup
                                };

            return articleGroups.ToList();
        }

        // ==================
        // List Sales Invoice
        // ==================
        public List<Entities.TrnCollectionSalesInvoiceListEntity> ListSalesInvoice(Int32 customerId)
        {
            var salesInvoices = from d in db.TrnSalesInvoices
                                where d.CustomerId == customerId
                                && d.IsLocked == true
                                && d.Amount > 0
                                select new Entities.TrnCollectionSalesInvoiceListEntity
                                {
                                    Id = d.Id,
                                    SINumber = d.SINumber,
                                    SIDate = d.SIDate,
                                    ManualSINumber = d.ManualSINumber,
                                    Remarks = d.Remarks,
                                    BalanceAmount = d.Amount - d.PaidAmount,
                                };

            return salesInvoices.OrderByDescending(d => d.Id).ToList();
        }

        // =======================
        // Dropdown List SI Number
        // =======================
        public List<Entities.TrnSalesInvoiceEntity> DropdownListSINumber(Int32 customerId)
        {
            var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
            var currentBranchId = currentUserLogin.FirstOrDefault().BranchId;

            var salesInvoices = from d in db.TrnSalesInvoices
                                where d.CustomerId == customerId
                                && d.MstBranch.Id == currentBranchId
                                && d.Amount > 0
                                && d.IsLocked == true
                                select new Entities.TrnSalesInvoiceEntity
                                {
                                    Id = d.Id,
                                    SINumber = d.SINumber,
                                    Amount = d.Amount
                                };

            return salesInvoices.ToList();
        }

        // ======================
        // Dropdown List Pay Type
        // ======================
        public List<Entities.MstPayTypeEntity> DropdownListPayType()
        {
            var payTypes = from d in db.MstPayTypes
                           select new Entities.MstPayTypeEntity
                           {
                               Id = d.Id,
                               PayType = d.PayType
                           };

            return payTypes.ToList();
        }

        // ===================
        // Add Collection Line
        // ===================
        public String[] AddCollectionLine(Entities.TrnCollectionLineEntity objCollectionLine)
        {
            try
            {
                var collection = from d in db.TrnCollections
                                 where d.Id == objCollectionLine.ORId
                                 select d;

                if (collection.Any() == false)
                {
                    return new String[] { "Collection transaction not found.", "0" };
                }

                var articleGroup = from d in db.MstArticleGroups
                                   where d.Id == objCollectionLine.ArticleGroupId
                                   select d;

                if (articleGroup.Any() == false)
                {
                    return new String[] { "Article group not found.", "0" };
                }

                Int32? SIId = null;
                var salesInvoice = from d in db.TrnSalesInvoices
                                   where d.Id == objCollectionLine.SIId
                                   && d.IsLocked == true
                                   select d;

                if (salesInvoice.Any())
                {
                    SIId = salesInvoice.FirstOrDefault().Id;
                }

                var payType = from d in db.MstPayTypes
                              where d.Id == objCollectionLine.PayTypeId
                              select d;

                if (payType.Any() == false)
                {
                    return new String[] { "Pay type not found.", "0" };
                }

                Data.TrnCollectionLine newCollectionLine = new Data.TrnCollectionLine
                {
                    ORId = objCollectionLine.ORId,
                    ArticleGroupId = objCollectionLine.ArticleGroupId,
                    SIId = SIId,
                    Amount = objCollectionLine.Amount,
                    PayTypeId = objCollectionLine.PayTypeId,
                    CheckNumber = objCollectionLine.CheckNumber,
                    CheckDate = objCollectionLine.CheckDate,
                    CheckBank = objCollectionLine.CheckBank,
                    CreditCardVerificationCode = objCollectionLine.CreditCardVerificationCode,
                    CreditCardNumber = objCollectionLine.CreditCardNumber,
                    CreditCardType = objCollectionLine.CreditCardType,
                    CreditCardBank = objCollectionLine.CreditCardBank,
                    CreditCardReferenceNumber = objCollectionLine.CreditCardReferenceNumber,
                    CreditCardHolderName = objCollectionLine.CreditCardHolderName,
                    CreditCardExpiry = objCollectionLine.CreditCardExpiry,
                    GiftCertificateNumber = objCollectionLine.GiftCertificateNumber,
                    OtherInformation = objCollectionLine.OtherInformation
                };

                db.TrnCollectionLines.InsertOnSubmit(newCollectionLine);
                db.SubmitChanges();

                return new String[] { "", "1" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ======================
        // Update Collection Line
        // ======================
        public String[] UpdateCollectionLine(Int32 id, Entities.TrnCollectionLineEntity objCollectionLine)
        {
            try
            {
                var collectionLine = from d in db.TrnCollectionLines
                                     where d.Id == id
                                     select d;

                if (collectionLine.Any())
                {
                    var collection = from d in db.TrnCollections
                                     where d.Id == objCollectionLine.ORId
                                     select d;

                    if (collection.Any() == false)
                    {
                        return new String[] { "Collection transaction not found.", "0" };
                    }

                    var articleGroup = from d in db.MstArticleGroups
                                       where d.Id == objCollectionLine.ArticleGroupId
                                       select d;

                    if (articleGroup.Any() == false)
                    {
                        return new String[] { "Article group not found.", "0" };
                    }

                    Int32? SIId = null;
                    var salesInvoice = from d in db.TrnSalesInvoices
                                       where d.Id == objCollectionLine.SIId
                                       && d.IsLocked == true
                                       select d;

                    if (salesInvoice.Any())
                    {
                        SIId = salesInvoice.FirstOrDefault().Id;
                    }

                    var payType = from d in db.MstPayTypes
                                  where d.Id == objCollectionLine.PayTypeId
                                  select d;

                    if (payType.Any() == false)
                    {
                        return new String[] { "Pay type not found.", "0" };
                    }

                    var updateCollectionLine = collectionLine.FirstOrDefault();
                    updateCollectionLine.ArticleGroupId = objCollectionLine.ArticleGroupId;
                    updateCollectionLine.SIId = SIId;
                    updateCollectionLine.Amount = objCollectionLine.Amount;
                    updateCollectionLine.PayTypeId = objCollectionLine.PayTypeId;
                    updateCollectionLine.CheckNumber = objCollectionLine.CheckNumber;
                    updateCollectionLine.CheckDate = objCollectionLine.CheckDate;
                    updateCollectionLine.CheckBank = objCollectionLine.CheckBank;
                    updateCollectionLine.CreditCardVerificationCode = objCollectionLine.CreditCardVerificationCode;
                    updateCollectionLine.CreditCardNumber = objCollectionLine.CreditCardNumber;
                    updateCollectionLine.CreditCardType = objCollectionLine.CreditCardType;
                    updateCollectionLine.CreditCardBank = objCollectionLine.CreditCardBank;
                    updateCollectionLine.CreditCardReferenceNumber = objCollectionLine.CreditCardReferenceNumber;
                    updateCollectionLine.CreditCardHolderName = objCollectionLine.CreditCardHolderName;
                    updateCollectionLine.CreditCardExpiry = objCollectionLine.CreditCardExpiry;
                    updateCollectionLine.GiftCertificateNumber = objCollectionLine.GiftCertificateNumber;
                    updateCollectionLine.OtherInformation = objCollectionLine.OtherInformation;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Collection line not found.  " + id, "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ======================
        // Delete Collection Line
        // ======================
        public String[] DeleteCollectionLine(Int32 id)
        {
            try
            {
                var collectionLine = from d in db.TrnCollectionLines
                                     where d.Id == id
                                     select d;

                if (collectionLine.Any())
                {
                    var deleteCollectionLine = collectionLine.FirstOrDefault();
                    db.TrnCollectionLines.DeleteOnSubmit(deleteCollectionLine);
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Collection line not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
