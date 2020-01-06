using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class MstTermController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // =========
        // List Term
        // =========
        public List<Entities.MstTermEntity> ListTerm(String filter)
        {
            var term = from d in db.MstTerms
                        where d.Term.Contains(filter)
                        select new Entities.MstTermEntity
                        {
                            Id = d.Id,
                            Term = d.Term,
                        };

            return term.OrderByDescending(d => d.Id).ToList();
        }

        // ========
        // Add Term
        // ========
        public String[] AddTerm(Entities.MstTermEntity objTerm)
        {
            try
            {
                Data.MstTerm addTerm = new Data.MstTerm()
                {
                    Term = objTerm.Term,
                    NumberOfDays = objTerm.NumberOfDays,
                    IsLocked = true
                };

                db.MstTerms.InsertOnSubmit(addTerm);
                db.SubmitChanges();

                return new String[] { "", "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===========
        // Update Term
        // ===========
        public String[] UpdateTerm(Entities.MstTermEntity objTerm)
        {
            try
            {
                var unit = from d in db.MstTerms
                           where d.Id == objTerm.Id
                           select d;

                if (unit.Any())
                {
                    var updateTerm = unit.FirstOrDefault();
                    updateTerm.Term = objTerm.Term;
                    updateTerm.NumberOfDays = objTerm.NumberOfDays;
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Term not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===========
        // Delete Term
        // ===========
        public String[] DeleteTerm(Int32 id)
        {
            try
            {
                var unit = from d in db.MstTerms
                           where d.Id == id
                           select d;

                if (unit.Any())
                {
                    var deleteTerm = unit.FirstOrDefault();
                    db.MstTerms.DeleteOnSubmit(deleteTerm);
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Term not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
