using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class MstArticleController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ===================
        // Fill Leading Zeroes
        // ===================
        public String FillLeadingZeroes(Int32 number, Int32 length)
        {
            var result = number.ToString();
            var pad = length - result.Length;
            while (pad > 0)
            {
                result = '0' + result;
                pad--;
            }

            return result;
        }

        // ============
        // List Article
        // ============
        public List<Entities.MstArticleEntity> ListArticle(Int32 articleTypeId)
        {
            var articles = from d in db.MstArticles
                           where d.ArticleTypeId == articleTypeId
                           select new Entities.MstArticleEntity
                           {
                               Id = d.Id,
                               ArticleTypeId = d.ArticleTypeId,
                               ArticleGroupId = d.ArticleTypeId,
                               ArticleCode = d.ArticleCode,
                               ArticleBarCode = d.ArticleBarCode,
                               Article = d.Article,
                               ArticleAlias = d.ArticleAlias,
                               GenericArticleName = d.GenericArticleName,
                               Category = d.Category,
                               VATInTaxId = d.VATInTaxId,
                               VATInTax = d.MstTax.Tax,
                               VATOutTaxId = d.VATOutTaxId,
                               VATOutTax = d.MstTax1.Tax,
                               UnitId = d.UnitId,
                               Unit = d.MstUnit.Unit,
                               DefaultSupplierId = d.DefaultSupplierId,
                               DefaultCost = d.DefaultCost,
                               DefaultPrice = d.DefaultPrice,
                               ReorderQuantity = d.ReorderQuantity,
                               IsInventory = d.IsInventory,
                               Address = d.Address,
                               ContactPerson = d.ContactNumber,
                               ContactNumber = d.ContactNumber,
                               EmailAddress = d.EmailAddress,
                               TIN = d.TIN,
                               Remarks = d.Remarks,
                               IsLocked = d.IsLocked,
                               CreatedBy = d.CreatedBy,
                               CreatedByUserName = d.MstUser.UserName,
                               CreatedByDateTime = d.CreatedByDateTime,
                               UpdatedBy = d.UpdatedBy,
                               UpdatedByUserName = d.MstUser.UserName,
                               UpdatedDateTime = d.UpdatedDateTime
                           };

            return articles.OrderByDescending(d => d.ArticleCode).ToList();
        }

        // ==============
        // Detail Article
        // ==============
        public Entities.MstArticleEntity DetailArticle(Int32 id)
        {
            var article = from d in db.MstArticles
                          where d.Id == id
                          select new Entities.MstArticleEntity
                          {
                              Id = d.Id,
                              ArticleTypeId = d.ArticleTypeId,
                              ArticleGroupId = d.ArticleTypeId,
                              ArticleCode = d.ArticleCode,
                              ArticleBarCode = d.ArticleBarCode,
                              Article = d.Article,
                              ArticleAlias = d.ArticleAlias,
                              GenericArticleName = d.GenericArticleName,
                              Category = d.Category,
                              VATInTaxId = d.VATInTaxId,
                              VATOutTaxId = d.VATOutTaxId,
                              UnitId = d.UnitId,
                              TermId = d.TermId,
                              DefaultSupplierId = d.DefaultSupplierId,
                              DefaultCost = d.DefaultCost,
                              DefaultPrice = d.DefaultPrice,
                              ReorderQuantity = d.ReorderQuantity,
                              CreditLimit = d.CreditLimit,
                              IsInventory = d.IsInventory,
                              Address = d.Address,
                              ContactPerson = d.ContactPerson,
                              ContactNumber = d.ContactNumber,
                              EmailAddress = d.EmailAddress,
                              TIN = d.TIN,
                              Remarks = d.Remarks,
                              ShippingInstruction = d.ShippingInstruction,
                              IsLocked = d.IsLocked,
                              CreatedBy = d.CreatedBy,
                              CreatedByDateTime = d.CreatedByDateTime,
                              UpdatedBy = d.UpdatedBy,
                              UpdatedDateTime = d.UpdatedDateTime,
                              ImagePath = d.ImagePath
                          };

            return article.FirstOrDefault();
        }

        // ========
        // List Tax
        // ========
        public List<Entities.MstTaxEntity> DropDownListTax()
        {
            var taxes = from d in db.MstTaxes
                        select new Entities.MstTaxEntity
                        {
                            Id = d.Id,
                            TaxCode = d.TaxCode,
                        };
            return taxes.OrderByDescending(d => d.Id).ToList();
        }

        // =========
        // List Unit
        // =========
        public List<Entities.MstUnitEntity> DropDownListUnit()
        {
            var units = from d in db.MstUnits
                        select new Entities.MstUnitEntity
                        {
                            Id = d.Id,
                            Unit = d.Unit
                        };

            return units.OrderByDescending(d => d.Id).ToList();
        }

        // ==================
        // List Article Group
        // ==================
        public List<Entities.MstArticleGroupEntity> DropDownListArticleGroup(String articleType)
        {
            var units = from d in db.MstArticleGroups
                        where d.MstArticleType.ArticleType == articleType
                        select new Entities.MstArticleGroupEntity
                        {
                            Id = d.Id,
                            ArticleGroup = d.ArticleGroup
                        };

            return units.OrderByDescending(d => d.Id).ToList();
        }

        // ==================
        // List Article Group
        // ==================
        public List<Entities.MstTermEntity> DropDownListTerms()
        {
            var terms = from d in db.MstTerms
                        where d.IsLocked == true
                        select new Entities.MstTermEntity
                        {
                            Id = d.Id,
                            Term = d.Term
                        };

            return terms.OrderByDescending(d => d.Id).ToList();
        }

        // ===========
        // Add Article
        // ===========
        public String[] AddArticle(String _articleType)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                String itemCode = "0000000001";
                var lastItemCode = from d in db.MstArticles.OrderByDescending(d => d.ArticleCode)
                                   where d.MstArticleType.ArticleType == _articleType
                                   select d;
                if (lastItemCode.Any())
                {
                    Int32 newItemCode = Convert.ToInt32(lastItemCode.FirstOrDefault().ArticleCode) + 1;
                    itemCode = FillLeadingZeroes(newItemCode, 10);
                }

                var unit = from d in db.MstUnits
                           select d;
                if (unit.Any() == false)
                {
                    return new String[] { "Unit not found.", "0" };
                }

                var taxVATIn = from d in db.MstTaxes
                               where d.TaxCode == "VATIN"
                               select d;
                if (taxVATIn.Any() == false)
                {
                    return new String[] { "VAT INPUT Tax not found.", "0" };
                }

                var taxVATOut = from d in db.MstTaxes
                                where d.TaxCode == "VATOUT"
                                select d;
                if (taxVATOut.Any() == false)
                {
                    return new String[] { "VAT OUTPUT Tax not found.", "0" };
                }

                var articleType = from d in db.MstArticleTypes
                                  where d.ArticleType == _articleType
                                  select d;

                if (articleType.Any() == false)
                {
                    return new String[] { "Article type not found.", "0" };
                }

                var articleGroup = from d in db.MstArticleGroups
                                   where d.MstArticleType.ArticleType == _articleType
                                   select d;
                if (articleGroup.Any() == false)
                {
                    return new String[] { "Article group not found.", "0" };
                }

                Int32? supplierId;
                var supplier = from d in db.MstArticles
                               where d.MstArticleType.Id == 3
                               select d;
                if (_articleType == "ITEM")
                {
                    if (supplier.Any())
                    {
                        supplierId = supplier.FirstOrDefault().Id;
                    }
                    else
                    {
                        supplierId = null;
                    }
                }
                else
                {
                    supplierId = null;
                }

                var term = from d in db.MstTerms
                                   where d.IsLocked == true
                                   select d;
                if (term.Any() == false)
                {
                    return new String[] { "Terms not found.", "0" };
                }

                Data.MstArticle newArticle = new Data.MstArticle()
                {
                    ArticleTypeId = articleType.FirstOrDefault().Id,
                    ArticleGroupId = articleGroup.FirstOrDefault().Id,
                    ArticleCode = itemCode,
                    ArticleBarCode = "NA",
                    Article = "NA",
                    ArticleAlias = "NA",
                    GenericArticleName = "NA",
                    Category = "NA",
                    VATInTaxId = taxVATIn.FirstOrDefault().Id,
                    VATOutTaxId = taxVATOut.FirstOrDefault().Id,
                    UnitId = unit.FirstOrDefault().Id,
                    TermId = term.FirstOrDefault().Id,
                    DefaultSupplierId = supplierId,
                    DefaultCost = 0,
                    DefaultPrice = 0,
                    ReorderQuantity = 0,
                    CreditLimit = 1000000,
                    IsInventory = true,
                    Address = "NA",
                    ContactPerson = "NA",
                    ContactNumber = "NA",
                    EmailAddress = "NA",
                    TIN = "NA",
                    Remarks = "NA",
                    ShippingInstruction = "NA",
                    IsLocked = false,
                    CreatedBy = currentUserLogin.FirstOrDefault().Id,
                    CreatedByDateTime = DateTime.Today,
                    UpdatedBy = currentUserLogin.FirstOrDefault().Id,
                    UpdatedDateTime = DateTime.Today
                };

                db.MstArticles.InsertOnSubmit(newArticle);
                db.SubmitChanges();

                return new String[] { "", newArticle.Id.ToString() };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ==============
        // Update Article
        // ==============
        public String[] SaveArticle(Entities.MstArticleEntity objArticle)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var checkBarcode = from d in db.MstArticles
                                   where d.ArticleBarCode == objArticle.ArticleBarCode
                                   && d.Id != objArticle.Id
                                   select d;

                if (checkBarcode.Any() && checkBarcode.FirstOrDefault().MstArticleType.ArticleType == "ITEM")
                {
                    return new String[] { "Barcode already exist.", "0" };
                }

                var term = from d in db.MstTerms
                           where d.Id == objArticle.TermId
                           select d;
                if (term.Any() == false)
                {
                    return new String[] { "Terms not found.", "0" };
                }

                var currentArticle = from d in db.MstArticles
                                     where d.Id == objArticle.Id
                                     select d;
                if (currentArticle.Any())
                {

                    var updateArticle = currentArticle.FirstOrDefault();
                    updateArticle.ArticleGroupId = objArticle.ArticleGroupId;
                    updateArticle.ArticleCode = objArticle.ArticleCode;
                    updateArticle.ArticleBarCode = objArticle.ArticleBarCode;
                    updateArticle.Article = objArticle.Article;
                    updateArticle.ArticleAlias = objArticle.ArticleAlias;
                    updateArticle.GenericArticleName = objArticle.GenericArticleName;
                    updateArticle.Category = objArticle.Category;
                    updateArticle.VATInTaxId = objArticle.VATInTaxId;
                    updateArticle.VATOutTaxId = objArticle.VATOutTaxId;
                    updateArticle.UnitId = objArticle.UnitId;
                    updateArticle.TermId = objArticle.TermId;
                    updateArticle.DefaultSupplierId = Convert.ToInt32(objArticle.DefaultSupplierId);
                    updateArticle.DefaultCost = objArticle.DefaultCost;
                    updateArticle.DefaultPrice = objArticle.DefaultPrice;
                    updateArticle.ReorderQuantity = objArticle.ReorderQuantity;
                    updateArticle.CreditLimit = objArticle.CreditLimit;
                    updateArticle.IsInventory = objArticle.IsInventory;
                    updateArticle.Address = objArticle.Address;
                    updateArticle.ContactPerson = objArticle.ContactPerson;
                    updateArticle.ContactNumber = objArticle.ContactNumber;
                    updateArticle.EmailAddress = objArticle.EmailAddress;
                    updateArticle.TIN = objArticle.TIN;
                    updateArticle.Remarks = objArticle.Remarks;
                    updateArticle.ShippingInstruction = objArticle.ShippingInstruction;
                    updateArticle.IsLocked = objArticle.IsLocked;
                    updateArticle.UpdatedBy = objArticle.UpdatedBy;
                    updateArticle.UpdatedDateTime = DateTime.Today;
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Article not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ============
        // Lock Article
        // ============
        public String[] LockArticle(Entities.MstArticleEntity objArticle)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var currentArticle = from d in db.MstArticles
                                     where d.Id == objArticle.Id
                                     select d;

                if (currentArticle.FirstOrDefault().MstArticleType.ArticleType == "ITEM")
                {
                    var checkBarcode = from d in db.MstArticles
                                       where d.ArticleBarCode == objArticle.ArticleBarCode
                                       && d.Id != objArticle.Id
                                       select d;

                    if (checkBarcode.Any())
                    {
                        return new String[] { "Barcode already exist.", "0" };
                    }
                }

                if (currentArticle.Any())
                {
                    var lockArticle = currentArticle.FirstOrDefault();
                    lockArticle.ArticleTypeId = objArticle.ArticleTypeId;
                    lockArticle.ArticleGroupId = objArticle.ArticleGroupId;
                    lockArticle.ArticleCode = objArticle.ArticleCode;
                    lockArticle.ArticleBarCode = objArticle.ArticleBarCode;
                    lockArticle.Article = objArticle.Article;
                    lockArticle.ArticleAlias = objArticle.ArticleAlias;
                    lockArticle.GenericArticleName = objArticle.GenericArticleName;
                    lockArticle.Category = objArticle.Category;
                    lockArticle.VATInTaxId = objArticle.VATInTaxId;
                    lockArticle.VATOutTaxId = objArticle.VATOutTaxId;
                    lockArticle.UnitId = objArticle.UnitId;
                    lockArticle.TermId = objArticle.TermId;
                    lockArticle.DefaultSupplierId = objArticle.DefaultSupplierId;
                    lockArticle.DefaultCost = objArticle.DefaultCost;
                    lockArticle.DefaultPrice = objArticle.DefaultPrice;
                    lockArticle.ReorderQuantity = objArticle.ReorderQuantity;
                    lockArticle.CreditLimit = objArticle.CreditLimit;
                    lockArticle.IsInventory = objArticle.IsInventory;
                    lockArticle.Address = objArticle.Address;
                    lockArticle.ContactPerson = objArticle.ContactPerson;
                    lockArticle.ContactNumber = objArticle.ContactNumber;
                    lockArticle.EmailAddress = objArticle.EmailAddress;
                    lockArticle.TIN = objArticle.TIN;
                    lockArticle.Remarks = objArticle.Remarks;
                    lockArticle.ShippingInstruction = objArticle.ShippingInstruction;
                    lockArticle.IsLocked = true;
                    lockArticle.UpdatedBy = objArticle.UpdatedBy;
                    lockArticle.UpdatedDateTime = DateTime.Today;
                    lockArticle.ImagePath = objArticle.ImagePath;
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Article not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ==============
        // Unlock Article
        // ==============
        public String[] UnlockArticle(Entities.MstArticleEntity objArticle)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var currentArticle = from d in db.MstArticles
                                     where d.Id == objArticle.Id
                                     select d;
                if (currentArticle.Any())
                {
                    var unlockArticle = currentArticle.FirstOrDefault();

                    unlockArticle.IsLocked = false;
                    unlockArticle.UpdatedBy = objArticle.UpdatedBy;
                    unlockArticle.UpdatedDateTime = DateTime.Today;
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Article not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ==============
        // Delete Article
        // ==============
        public String[] DeleteArticle(Int32 id)
        {
            try
            {
                var currentArticle = from d in db.MstArticles
                                     where d.Id == id
                                     select d;
                if (currentArticle.Any())
                {
                    if (currentArticle.Any())
                    {
                        var deleteArticle = currentArticle.FirstOrDefault();
                        db.MstArticles.DeleteOnSubmit(deleteArticle);
                        db.SubmitChanges();

                        return new string[] { "", "" };
                    }
                    else
                    {
                        return new string[] { "Article is lock", "0" };
                    }
                }
                else
                {
                    return new string[] { "Article not founr.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
