using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class MstAccountController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ============
        // List Account
        // ============
        public List<Entities.MstAccountEntity> ListAccount(String filter)
        {
            var accounts = from d in db.MstAccounts
                           where d.AccountCode.Contains(filter)
                           || d.Account.Contains(filter)
                           || d.MstAccountType.ArticleType.Contains(filter)
                           select new Entities.MstAccountEntity
                           {
                               Id = d.Id,
                               AccountCode = d.AccountCode,
                               Account = d.Account,
                               IsLocked = d.IsLocked,
                               AccountTypeId = d.AccountTypeId,
                               AccountType = d.MstAccountType.ArticleType
                           };

            return accounts.OrderByDescending(d => d.Id).ToList();
        }

        // =================
        // List Account Type
        // =================
        public List<Entities.MstAccountType> ListType()
        {
            var accountType = from d in db.MstAccountTypes
                              select new Entities.MstAccountType
                              {
                                  Id = d.Id,
                                  ArticleType = d.ArticleType
                              };

            return accountType.OrderByDescending(d => d.Id).ToList();
        }

        // ===========
        // Add Account
        // ===========
        public String[] AddAccount(Entities.MstAccountEntity objAccount)
        {
            try
            {
                Data.MstAccount addAccount = new Data.MstAccount()
                {
                    AccountCode = objAccount.AccountCode,
                    Account = objAccount.Account,
                    IsLocked = true,
                    AccountTypeId = objAccount.AccountTypeId
                };

                db.MstAccounts.InsertOnSubmit(addAccount);
                db.SubmitChanges();

                return new String[] { "", "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ==============
        // Update Account
        // ==============
        public String[] UpdateAccount(Entities.MstAccountEntity objAccount)
        {
            try
            {
                var account = from d in db.MstAccounts
                              where d.Id == objAccount.Id
                              select d;

                if (account.Any())
                {
                    var updateAccount = account.FirstOrDefault();
                    updateAccount.AccountCode = objAccount.AccountCode;
                    updateAccount.Account = objAccount.Account;
                    updateAccount.AccountTypeId = objAccount.AccountTypeId;
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Account not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ==============
        // Delete Account
        // ==============
        public String[] DeleteAccount(int id)
        {
            try
            {
                var account = from d in db.MstAccounts
                              where d.Id == id
                              select d;

                if (account.Any())
                {
                    var deleteAccount = account.FirstOrDefault();
                    db.MstAccounts.DeleteOnSubmit(deleteAccount);
                    db.SubmitChanges();

                    return new string[] { "", "" };
                }
                else
                {
                    return new String[] { "Account not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
