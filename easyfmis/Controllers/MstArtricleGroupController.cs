using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class MstArtricleGroupController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // =========
        // List ArticleGroup
        // =========
        public List<Entities.MstArticleGroupEntity> ListArticleGroup(String filter)
        {
            var articleGroup = from d in db.MstArticleGroups
                               where d.ArticleGroup.Contains(filter)
                               select new Entities.MstArticleGroupEntity
                               {
                                   Id = d.Id,
                                   ArticleGroup = d.ArticleGroup,
                                   ArticleTypeId = d.ArticleTypeId,
                                   ArticleType = d.MstArticleType.ArticleType,
                                   AccountId = d.MstAccount.Id,
                                   Account = d.MstAccount.Account
                               };

            return articleGroup.OrderByDescending(d => d.Id).ToList();
        }

        // ========
        // Add ArticleGroup
        // ========
        public String[] AddArticleGroup(Entities.MstArticleGroupEntity objArticleGroup)
        {
            try
            {
                Data.MstArticleGroup addArticleGroup = new Data.MstArticleGroup()
                {
                    ArticleGroup = objArticleGroup.ArticleGroup,
                    ArticleTypeId = objArticleGroup.ArticleTypeId,
                    AccountId = objArticleGroup.AccountId
                };

                db.MstArticleGroups.InsertOnSubmit(addArticleGroup);
                db.SubmitChanges();

                return new String[] { "", "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===========
        // Update ArticleGroup
        // ===========
        public String[] UpdateArticleGroup(Entities.MstArticleGroupEntity objArticleGroup)
        {
            try
            {
                var articleGroup = from d in db.MstArticleGroups
                           where d.Id == objArticleGroup.Id
                           select d;

                if (articleGroup.Any())
                {
                    var updateArticleGroup = articleGroup.FirstOrDefault();
                    updateArticleGroup.ArticleGroup = objArticleGroup.ArticleGroup;
                    updateArticleGroup.ArticleTypeId = objArticleGroup.ArticleTypeId;
                    updateArticleGroup.AccountId = objArticleGroup.AccountId;
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Article Group not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===========
        // Delete ArticleGroup
        // ===========
        public String[] DeleteArticleGroup(Int32 id)
        {
            try
            {
                var articleGroup = from d in db.MstArticleGroups
                           where d.Id == id
                           select d;

                if (articleGroup.Any())
                {
                    var deleteArticleGroup = articleGroup.FirstOrDefault();
                    db.MstArticleGroups.DeleteOnSubmit(deleteArticleGroup);
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Article Group not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

    }
}
