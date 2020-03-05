using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Modules
{
    class TrnAccountsPayableModule
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // =======================
        // Update Accounts Payable
        // =======================
        public void UpdateAccountsPayable(Int32 RRId)
        {
            var receivingReceipt = from d in db.TrnReceivingReceipts where d.Id == RRId select d;
            if (receivingReceipt.Any())
            {
                Decimal paidAmount = 0;
                Decimal memoDebit = 0;
                Decimal memoCredit = 0;
                Decimal memoAmount = 0;

                var disbursementLines = from d in db.TrnDisbursementLines where d.RRId == RRId && d.TrnDisbursement.IsLocked == true select d;
                if (disbursementLines.Any())
                {
                    paidAmount = disbursementLines.Sum(d => d.Amount);
                }

                var memoLines = from d in db.TrnMemoLines where d.RRId == RRId && d.TrnMemo.IsLocked == true select d;
                if (memoLines.Any())
                {
                    memoDebit = memoLines.Sum(d => d.DebitAmount);
                    memoCredit = memoLines.Sum(d => d.CreditAmount);
                    memoAmount = memoDebit - memoCredit;
                }

                Decimal receivingReceiptAmount = receivingReceipt.FirstOrDefault().Amount;
                Decimal balanceAmount = (receivingReceiptAmount - paidAmount) + memoAmount;

                var updateReceivingReceipt = receivingReceipt.FirstOrDefault();
                updateReceivingReceipt.PaidAmount = paidAmount;
                updateReceivingReceipt.MemoAmount = memoAmount;
                updateReceivingReceipt.BalanceAmount = balanceAmount;

                db.SubmitChanges();
            }
        }
    }
}
