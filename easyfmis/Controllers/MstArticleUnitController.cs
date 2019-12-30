using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class MstArticleUnitController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());


        // =================
        // List Article Unit
        // =================
        public List<Entities.MstArticleUnitEntity> ListArticleList(Int32 articleId)
        {
            var articleUnits = from d in db.MstArticleUnits
                               where d.ArticleId == articleId
                               select new Entities.MstArticleUnitEntity
                               {
                                   Id = d.Id,
                                   ArticleId = d.ArticleId,
                                   BaseUnitMultiplier = d.BaseUnitMultiplier,
                                   BaseUnit = d.MstUnit.Unit,
                                   UnitMultiplier = d.UnitMultiplier,
                                   UnitId = d.UnitId,
                                   Unit = d.MstUnit.Unit
                               };
            return articleUnits.OrderByDescending(d => d.Id).ToList();
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

        // ===================
        // Detail Article Unit
        // ===================
        public Entities.MstArticleUnitEntity DetailArticleList()
        {
            var articleUnits = from d in db.MstArticleUnits
                               select new Entities.MstArticleUnitEntity
                               {
                                   Id = d.Id,
                                   ArticleId = d.ArticleId,
                                   BaseUnitMultiplier = d.BaseUnitMultiplier,
                                   UnitMultiplier = d.UnitMultiplier,
                                   UnitId = d.UnitId,
                                   Unit = d.MstUnit.Unit
                               };
            return articleUnits.FirstOrDefault();
        }

        // =================
        // Add Article Unit
        // =================
        public String[] AddArticleUnit(Entities.MstArticleUnitEntity objArticleUnit) {
            try
            {

                Data.MstArticleUnit newMstArticleUnit = new Data.MstArticleUnit()
                {
                    ArticleId = objArticleUnit.ArticleId,
                    BaseUnitMultiplier = objArticleUnit.BaseUnitMultiplier,
                    UnitMultiplier = objArticleUnit.UnitMultiplier,
                    UnitId = objArticleUnit.UnitId,
                };

                db.MstArticleUnits.InsertOnSubmit(newMstArticleUnit);
                db.SubmitChanges();

                return new String[] { "", "" };

            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===================
        // Update Article Unit
        // ===================
        public String[] UpdateArticleUnit(Entities.MstArticleUnitEntity objArticleUnit)
        {
            try
            {
                var articleUnit = from d in db.MstArticleUnits
                                where d.Id == objArticleUnit.Id
                                select d;

                if (articleUnit.Any())
                {
                    var updateArticleUnit = articleUnit.FirstOrDefault();
                    updateArticleUnit.BaseUnitMultiplier = objArticleUnit.BaseUnitMultiplier;
                    updateArticleUnit.UnitMultiplier = objArticleUnit.UnitMultiplier;
                    updateArticleUnit.UnitId = objArticleUnit.UnitId;
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Article Unit not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===================
        // Update Article Unit
        // ===================
        public String[] DeleteArticleUnit(Int32 id)
        {
            try
            {
                var articleUnit = from d in db.MstArticleUnits
                                  where d.Id == id
                                  select d;

                if (articleUnit.Any())
                {
                    db.MstArticleUnits.DeleteOnSubmit(articleUnit.FirstOrDefault());
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Article Unit not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }


    }
}
