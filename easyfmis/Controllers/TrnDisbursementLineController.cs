using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class TrnDisbursementLineController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ======================
        // List Disbursement Item
        // ======================
        public List<Entities.TrnDisbursementLineEntity> ListDisbursementLine(Int32 CVId)
        {
            var disbursementItems = from d in db.TrnDisbursementLines
                                    where d.CVId == CVId
                                    select new Entities.TrnDisbursementLineEntity
                                    {
                                        Id = d.Id,
                                        CVId = d.CVId,
                                        ArticleGroupId = d.ArticleGroupId,
                                        RRId = d.RRId,
                                        RRNumber = d.TrnReceivingReceipt.RRNumber,
                                        Amount = d.Amount,
                                        OtherInformation = d.OtherInformation
                                    };

            return disbursementItems.OrderByDescending(d => d.Id).ToList();
        }

        // ==========================
        // Dropdown Receiving Reciept
        // ==========================
        public List<Entities.TrnReceivingReceiptEntity> DropDownReceivingReceipt(Int32 supplierId)
        {
            var receivingReceipt = from d in db.TrnReceivingReceipts
                                   where d.SupplierId == supplierId
                                   select new Entities.TrnReceivingReceiptEntity
                                   {
                                       Id = d.Id,
                                       RRNumber = d.RRNumber
                                   };
            return receivingReceipt.OrderByDescending(d => d.Id).ToList();
        }

        // ======================
        // Dropdown Article Group
        // ======================
        public List<Entities.MstArticleGroupEntity> DropDownArticleGroup()
        {
            var articleGroup = from d in db.MstArticleGroups
                               where d.ArticleTypeId == 3
                               select new Entities.MstArticleGroupEntity
                               {
                                   Id = d.Id,
                                   ArticleGroup = d.ArticleGroup
                               };

            return articleGroup.OrderByDescending(d => d.Id).ToList();
        }

        // =====================
        // Add Disbursement Line
        // =====================
        public String[] AddDisbursementLine(Entities.TrnDisbursementLineEntity objDisbursementLine)
        {
            try
            {
                var disbursement = from d in db.TrnDisbursements
                                   where d.Id == objDisbursementLine.CVId
                                   select d;

                if (disbursement.Any() == false)
                {
                    return new String[] { "Disbursement transaction not found.", "0" };
                }

                var articleGroup = from d in db.MstArticleGroups
                                   where d.Id == objDisbursementLine.ArticleGroupId
                                   select d;
                if (articleGroup.Any() == false)
                {
                    return new String[] { "Article group not found.", "0" };
                }

                var receiveReceipt = from d in db.TrnReceivingReceipts
                                     where d.Id == objDisbursementLine.RRId
                                     select d;
                if (receiveReceipt.Any() == false)
                {
                    return new String[] { "Receive receipt not found.", "0" };
                }

                Data.TrnDisbursementLine newDisbursementLine = new Data.TrnDisbursementLine
                {
                    CVId = objDisbursementLine.CVId,
                    ArticleGroupId = articleGroup.FirstOrDefault().Id,
                    RRId = receiveReceipt.FirstOrDefault().Id,
                    Amount = objDisbursementLine.Amount,
                    OtherInformation = objDisbursementLine.OtherInformation
                };

                db.TrnDisbursementLines.InsertOnSubmit(newDisbursementLine);
                db.SubmitChanges();

                return new String[] { "", "1" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ========================
        // Update Disbursement Line
        // ========================
        public String[] UpdateDisbursementLine(Int32 id, Entities.TrnDisbursementLineEntity objDisbursementLine)
        {
            try
            {
                var disbursementLine = from d in db.TrnDisbursementLines
                                       where d.Id == id
                                       select d;

                if (disbursementLine.Any())
                {
                    var disbursement = from d in db.TrnDisbursements
                                       where d.Id == objDisbursementLine.CVId
                                       select d;

                    if (disbursement.Any() == false)
                    {
                        return new String[] { "Disbursement not found.", "0" };
                    }

                    var articleGroup = from d in db.MstArticleGroups
                                       where d.Id == objDisbursementLine.ArticleGroupId
                                       select d;
                    if (articleGroup.Any() == false)
                    {
                        return new String[] { "Article group not found.", "0" };
                    }

                    var receiveReceipt = from d in db.TrnReceivingReceipts
                                         where d.Id == objDisbursementLine.RRId
                                         select d;
                    if (receiveReceipt.Any() == false)
                    {
                        return new String[] { "Receive receipt not found.", "0" };
                    }

                    var updateDisbursementLine = disbursementLine.FirstOrDefault();

                    updateDisbursementLine.ArticleGroupId = articleGroup.FirstOrDefault().Id;
                    updateDisbursementLine.RRId = receiveReceipt.FirstOrDefault().Id;
                    updateDisbursementLine.Amount = objDisbursementLine.Amount;
                    updateDisbursementLine.OtherInformation = objDisbursementLine.OtherInformation;
                    db.TrnDisbursementLines.InsertOnSubmit(updateDisbursementLine);
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Disbursement line transaction not found.", "0" };

                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ========================
        // Delete Disbursement Line
        // ========================
        public String[] DeleteDisbursementLine(Int32 id)
        {
            try
            {
                var disbursementLine = from d in db.TrnDisbursementLines
                                       where d.Id == id
                                       select d;

                if (disbursementLine.Any())
                {
                    var deleteDisbursementLine = disbursementLine.FirstOrDefault();
                    db.TrnDisbursementLines.DeleteOnSubmit(deleteDisbursementLine);
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Disbursement line transaction not found.", "0" };

                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

    }
}
