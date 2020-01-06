using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class MstTaxController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ========
        // List Tax
        // ========
        public List<Entities.MstTaxEntity> ListTax(String filter)
        {
            var taxes = from d in db.MstTaxes
                        where d.TaxCode.Contains(filter)
                        || d.Tax.Contains(filter)
                        || d.MstAccount.Account.Contains(filter)
                        select new Entities.MstTaxEntity
                        {
                            Id = d.Id,
                            TaxCode = d.TaxCode,
                            Tax = d.Tax,
                            Rate = d.Rate,
                            AccountId = d.AccountId,
                            Account = d.MstAccount.Account
                        };

            return taxes.OrderByDescending(d => d.Id).ToList();
        }

        // =============
        // List Tax TaxCode
        // =============
        public String[] DropDownListTaxCode()
        {
            return new String[] { "INCLUSIVE", "EXCLUSIVE" };
        }

        // =======================
        // Dropdown List - Account
        // =======================
        public List<Entities.MstAccountEntity> DropDownListAccount()
        {
            var accounts = from d in db.MstAccounts
                           select new Entities.MstAccountEntity
                           {
                               Id = d.Id,
                               Account = d.Account
                           };

            return accounts.ToList();
        }

        // =======
        // Add Tax
        // =======
        public String[] AddTax(Entities.MstTaxEntity objTax)
        {
            try
            {
                Data.MstTax addTax = new Data.MstTax()
                {
                    TaxCode = objTax.TaxCode,
                    Tax = objTax.Tax,
                    Rate = objTax.Rate,
                    AccountId = objTax.AccountId
                };

                db.MstTaxes.InsertOnSubmit(addTax);
                db.SubmitChanges();

                return new String[] { "", "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ==========
        // Update Tax
        // ==========
        public String[] UpdateTax(Entities.MstTaxEntity objTax)
        {
            try
            {
                var tax = from d in db.MstTaxes
                          where d.Id == objTax.Id
                          select d;

                if (tax.Any())
                {
                    var updateTax = tax.FirstOrDefault();
                    updateTax.TaxCode = objTax.TaxCode;
                    updateTax.Tax = objTax.Tax;
                    updateTax.Rate = objTax.Rate;
                    updateTax.AccountId = objTax.AccountId;
                    db.SubmitChanges();

                    return new string[] { "", "" };
                }
                else
                {
                    return new String[] { "Tax not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ==========
        // Delete Tax
        // ==========
        public String[] DeleteTax(Int32 id)
        {
            try
            {
                var tax = from d in db.MstTaxes
                          where d.Id == id
                          select d;

                if (tax.Any())
                {
                    var deleteTax = tax.FirstOrDefault();
                    db.MstTaxes.DeleteOnSubmit(deleteTax);
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Tax not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
