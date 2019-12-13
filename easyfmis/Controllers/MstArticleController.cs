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

            return articles.ToList();
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
                              ArticleCode = d.ArticleCode,
                              ArticleBarCode = d.ArticleBarCode,
                              Article = d.ArticleBarCode,
                              ArticleAlias = d.ArticleBarCode,
                              GenericArticleName = d.ArticleBarCode,
                              Category = d.ArticleBarCode,
                              VATInTaxId = d.VATInTaxId,
                              VATOutTaxId = d.VATOutTaxId,
                              UnitId = d.UnitId,
                              DefaultSupplierId = d.DefaultSupplierId,
                              DefaultCost = d.DefaultCost,
                              DefaultPrice = d.DefaultPrice,
                              ReorderQuantity = d.ReorderQuantity,
                              IsInventory = d.IsInventory,
                              Address = d.Address,
                              ContactPerson = d.ContactPerson,
                              ContactNumber = d.ContactNumber,
                              EmailAddress = d.EmailAddress,
                              TIN = d.TIN,
                              Remarks = d.Remarks,
                              IsLocked = d.IsLocked,
                              CreatedBy = d.CreatedBy,
                              CreatedByDateTime = d.CreatedByDateTime,
                              UpdatedBy = d.UpdatedBy,
                              UpdatedDateTime = d.UpdatedDateTime
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

        // ===========
        // Add Article
        // ===========
        public String[] AddArticle()
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var unit = from d in db.MstUnits
                           select d;
                if (unit.Any())
                {
                    return new String[] { "Unit not found.", "0" };
                }

                var tax = from d in db.MstTaxes
                          select d;
                if (tax.Any())
                {
                    return new String[] { "Tax not found.", "0" };
                }

                var articleType = from d in db.MstArticleTypes
                                  select d;
                if (articleType.Any())
                {
                    return new String[] { "Tax type not found.", "0" };
                }

                var article = from d in db.MstArticles
                              select d;
                if (article.Any())
                {
                    return new String[] { "Article not found.", "0" };
                }


                Data.MstArticle newArticle = new Data.MstArticle()
                {
                    ArticleTypeId = articleType.FirstOrDefault().Id,
                    ArticleCode = "NA",
                    ArticleBarCode = "NA",
                    Article = "NA",
                    ArticleAlias = "NA",
                    GenericArticleName = "NA",
                    Category = "NA",
                    VATInTaxId = tax.FirstOrDefault().Id,
                    VATOutTaxId = tax.FirstOrDefault().Id,
                    UnitId = unit.FirstOrDefault().Id,
                    DefaultSupplierId = article.FirstOrDefault().Id,
                    DefaultCost = 0,
                    DefaultPrice = 0,
                    ReorderQuantity = 0,
                    IsInventory = false,
                    Address = "NA",
                    ContactPerson = "NA",
                    ContactNumber = "NA",
                    EmailAddress = "NA",
                    TIN = "NA",
                    Remarks = "NA",
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

                var currentArticle = from d in db.MstArticles
                                     where d.Id == objArticle.Id
                                     select d;
                if (currentArticle.Any())
                {
                    var updateArticle = currentArticle.FirstOrDefault();
                    updateArticle.ArticleTypeId = objArticle.ArticleTypeId;
                    updateArticle.ArticleCode = objArticle.ArticleCode;
                    updateArticle.ArticleBarCode = objArticle.ArticleBarCode;
                    updateArticle.Article = objArticle.Article;
                    updateArticle.ArticleAlias = objArticle.ArticleAlias;
                    updateArticle.GenericArticleName = objArticle.GenericArticleName;
                    updateArticle.Category = objArticle.Category;
                    updateArticle.VATInTaxId = objArticle.VATInTaxId;
                    updateArticle.VATOutTaxId = objArticle.VATOutTaxId;
                    updateArticle.UnitId = objArticle.UnitId;
                    updateArticle.DefaultSupplierId = Convert.ToInt32(objArticle.DefaultSupplierId);
                    updateArticle.DefaultCost = objArticle.DefaultCost;
                    updateArticle.DefaultPrice = objArticle.DefaultPrice;
                    updateArticle.ReorderQuantity = objArticle.ReorderQuantity;
                    updateArticle.IsInventory = objArticle.IsInventory;
                    updateArticle.Address = objArticle.Address;
                    updateArticle.ContactPerson = objArticle.ContactPerson;
                    updateArticle.ContactNumber = objArticle.ContactNumber;
                    updateArticle.EmailAddress = objArticle.EmailAddress;
                    updateArticle.TIN = objArticle.TIN;
                    updateArticle.Remarks = objArticle.Remarks;
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
                if (currentArticle.Any())
                {
                    var lockArticle = currentArticle.FirstOrDefault();
                    lockArticle.ArticleTypeId = objArticle.ArticleTypeId;
                    lockArticle.ArticleCode = objArticle.ArticleCode;
                    lockArticle.ArticleBarCode = objArticle.ArticleBarCode;
                    lockArticle.Article = objArticle.Article;
                    lockArticle.ArticleAlias = objArticle.ArticleAlias;
                    lockArticle.GenericArticleName = objArticle.GenericArticleName;
                    lockArticle.Category = objArticle.Category;
                    lockArticle.VATInTaxId = objArticle.VATInTaxId;
                    lockArticle.VATOutTaxId = objArticle.VATOutTaxId;
                    lockArticle.UnitId = objArticle.UnitId;
                    lockArticle.DefaultSupplierId = Convert.ToInt32(objArticle.DefaultSupplierId);
                    lockArticle.DefaultCost = objArticle.DefaultCost;
                    lockArticle.DefaultPrice = objArticle.DefaultPrice;
                    lockArticle.ReorderQuantity = objArticle.ReorderQuantity;
                    lockArticle.IsInventory = objArticle.IsInventory;
                    lockArticle.Address = objArticle.Address;
                    lockArticle.ContactPerson = objArticle.ContactPerson;
                    lockArticle.ContactNumber = objArticle.ContactNumber;
                    lockArticle.EmailAddress = objArticle.EmailAddress;
                    lockArticle.TIN = objArticle.TIN;
                    lockArticle.Remarks = objArticle.Remarks;
                    lockArticle.IsLocked = objArticle.IsLocked;
                    lockArticle.UpdatedBy = objArticle.UpdatedBy;
                    lockArticle.UpdatedDateTime = DateTime.Today;
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

                    unlockArticle.IsLocked = objArticle.IsLocked;
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
