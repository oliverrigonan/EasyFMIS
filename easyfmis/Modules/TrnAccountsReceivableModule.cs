using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Modules
{
    class TrnAccountsReceivableModule
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ==========================
        // Update Accounts Receivable
        // ==========================
        public void UpdateAccountsReceivable(Int32 SIId)
        {
            var salesInvoice = from d in db.TrnSalesInvoices where d.Id == SIId select d;
            if (salesInvoice.Any())
            {
                Decimal paidAmount = 0;
                Decimal memoAmount = 0;
                Decimal memoDebit = 0;
                Decimal memoCredit = 0;

                var collectionLines = from d in db.TrnCollectionLines where d.SIId == SIId && d.TrnCollection.IsLocked == true select d;
                if (collectionLines.Any())
                {
                    paidAmount = collectionLines.Sum(d => d.Amount);
                }

                var memoLines = from d in db.TrnMemoLines where d.SIId == SIId && d.TrnMemo.IsLocked == true select d;
                if (memoLines.Any())
                {
                    memoDebit = memoLines.Sum(d => d.DebitAmount);
                    memoCredit = memoLines.Sum(d => d.CreditAmount);
                    memoAmount = memoDebit - memoCredit;
                }

                Decimal salesInvoiceAmount = salesInvoice.FirstOrDefault().Amount;
                Decimal balanceAmount = (salesInvoiceAmount - paidAmount) + memoAmount;

                var updateSalesInvoice = salesInvoice.FirstOrDefault();
                updateSalesInvoice.PaidAmount = paidAmount;
                updateSalesInvoice.MemoAmount = memoAmount;
                updateSalesInvoice.BalanceAmount = balanceAmount;

                db.SubmitChanges();
            }
        }
    }
}
