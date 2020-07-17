using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class TrnMemoLineController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ==================
        // List Stock-In Item
        // ==================
        public List<Entities.TrnMemoLineEntity> ListMemoLine(Int32 memoId)
        {
            var memoLines = from d in db.TrnMemoLines
                            where d.MOId == memoId
                            select new Entities.TrnMemoLineEntity
                            {
                                Id = d.Id,
                                MOId = d.MOId,
                                SIId = d.SIId,
                                SINumber = d.TrnSalesInvoice.SINumber,
                                RRId = d.RRId,
                                RRNumber = d.TrnReceivingReceipt.RRNumber,
                                DebitAmount = d.DebitAmount,
                                CreditAmount = d.CreditAmount,
                                Particulars = d.Particulars
                            };

            return memoLines.OrderByDescending(d => d.Id).ToList();
        }

        // ==================
        // List Sales Invoice
        // ==================
        public List<Entities.TrnSalesInvoiceEntity> DropDownListSalesInvoice(Int32 articleId)
        {
            var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
            var currentBranchId = currentUserLogin.FirstOrDefault().BranchId;

            var salesInvoices = from d in db.TrnSalesInvoices
                                where d.BranchId == currentBranchId
                                && d.CustomerId == articleId
                                && d.BalanceAmount > 0
                                && d.IsLocked == true
                                select new Entities.TrnSalesInvoiceEntity
                                {
                                    Id = d.Id,
                                    SINumber = d.SINumber,
                                };

            return salesInvoices.OrderByDescending(d => d.Id).ToList();
        }

        public List<Entities.TrnReceivingReceiptEntity> DropDownListListReceivingReceipt(Int32 articleId)
        {
            var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
            var currentBranchId = currentUserLogin.FirstOrDefault().BranchId;

            var receivingReceipts = from d in db.TrnReceivingReceipts
                                    where d.BranchId == currentBranchId
                                    && d.SupplierId == articleId
                                    && d.BalanceAmount > 0
                                    select new Entities.TrnReceivingReceiptEntity
                                    {
                                        Id = d.Id,
                                        RRNumber = d.RRNumber,
                                    };

            return receivingReceipts.OrderByDescending(d => d.Id).ToList();
        }

        public String[] AddMemoLine(Entities.TrnMemoLineEntity objMemoLine)
        {
            try
            {
                var memo = from d in db.TrnMemos
                           where d.Id == objMemoLine.MOId
                           select d;
                if (memo.Any() == false)
                {
                    return new String[] { "Memo line not found.", "0" };
                }

                Int32? sIId;

                var salesInvoice = from d in db.TrnSalesInvoices
                                   where d.Id == objMemoLine.SIId
                                   select d;

                var receivingReceipt = from d in db.TrnReceivingReceipts
                                       where d.Id == objMemoLine.RRId
                                       select d;

                if (objMemoLine.SIId == 0)
                {
                    sIId = null;
                }
                else
                {
                    sIId = objMemoLine.SIId;
                }

                Int32? rRId;

                if (objMemoLine.RRId == 0)
                {
                    rRId = null;
                }
                else
                {
                    rRId = objMemoLine.RRId;
                }

                Data.TrnMemoLine newMemo = new Data.TrnMemoLine
                {
                    MOId = objMemoLine.MOId,
                    SIId = sIId,
                    RRId = rRId,
                    DebitAmount = objMemoLine.DebitAmount,
                    CreditAmount = objMemoLine.CreditAmount,
                    Particulars = objMemoLine.Particulars
                };

                db.TrnMemoLines.InsertOnSubmit(newMemo);
                db.SubmitChanges();

                return new String[] { "", "1" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        public String[] UpdateMemoLine(Entities.TrnMemoLineEntity objMemoLine)
        {
            try
            {
                var memoLine = from d in db.TrnMemoLines
                               where d.Id == objMemoLine.Id
                               select d;

                if (memoLine.Any())
                {
                    var memo = from d in db.TrnMemos
                               where d.Id == objMemoLine.MOId
                               select d;

                    if (memo.Any())
                    {
                        if (objMemoLine.SIId == 0)
                        {
                            var receivingReceipt = from d in db.TrnReceivingReceipts
                                                   where d.Id == objMemoLine.RRId
                                                   select d;
                            if (receivingReceipt.Any() == false)
                            {
                                return new String[] { "Receiving Receipt not found.", "0" };
                            }
                            objMemoLine.SIId = null;

                        }

                        if (objMemoLine.RRId == 0)
                        {
                            var salesInvoice = from d in db.TrnSalesInvoices
                                               where d.Id == objMemoLine.SIId
                                               select d;
                            if (salesInvoice.Any() == false)
                            {
                                return new String[] { "Sales Invoice not found.", "0" };
                            }
                            objMemoLine.RRId = null;
                        }

                        var updateMemoLine = memoLine.FirstOrDefault();
                        updateMemoLine.SIId = objMemoLine.SIId;
                        updateMemoLine.RRId = objMemoLine.RRId;
                        updateMemoLine.DebitAmount = objMemoLine.DebitAmount;
                        updateMemoLine.CreditAmount = objMemoLine.CreditAmount;
                        updateMemoLine.Particulars = objMemoLine.Particulars;
                        db.SubmitChanges();

                        return new String[] { "", "1" };
                    }
                    else
                    {
                        return new String[] { "Memo Line not found.", "0" };
                    }
                }
                else
                {
                    return new String[] { "Memo not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        public String[] DeleteMemoLine(Int32 id)
        {
            try
            {
                var memoLine = from d in db.TrnMemoLines
                               where d.Id == id
                               select d;

                if (memoLine.Any())
                {
                    db.TrnMemoLines.DeleteOnSubmit(memoLine.FirstOrDefault());
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Memo not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
