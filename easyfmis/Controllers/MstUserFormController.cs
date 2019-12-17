using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyfmis.Controllers
{
    class MstUserFormController
    {
        // ============
        // Data Context
        // ============
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ==============
        // List User Form
        // ==============
        public List<Entities.MstUserFormEntity> ListUserForm(Int32 userId)
        {
            var userForms = from d in db.MstUserForms
                            where d.UserId == userId
                            select new Entities.MstUserFormEntity
                            {
                                Id = d.Id,
                                FormId = d.FormId,
                                Form = d.SysForm.FormDescription,
                                UserId = d.UserId,
                                CanDelete = d.CanDelete,
                                CanAdd = d.CanAdd,
                                CanLock = d.CanLock,
                                CanUnlock = d.CanUnlock,
                                CanPrint = d.CanPrint,
                                CanPreview = d.CanPreview,
                                CanEdit = d.CanEdit
                            };

            return userForms.OrderByDescending(d => d.Id).ToList();
        }

        // ==================
        // Dropdown List Form
        // ==================
        public List<Entities.SysFormEntity> DropdownListForm()
        {
            var forms = from d in db.SysForms
                        select new Entities.SysFormEntity
                        {
                            Id = d.Id,
                            Form = d.Form,
                            FormDescription = d.FormDescription
                        };

            return forms.ToList();
        }

        // =============
        // Add User Form
        // =============
        public String[] AddUserForm(Entities.MstUserFormEntity objUserForm)
        {
            try
            {
                var user = from d in db.MstUsers
                           where d.Id == objUserForm.UserId
                           select d;

                if (user.Any() == false)
                {
                    return new String[] { "User transaction not found.", "0" };
                }

                var form = from d in db.SysForms
                           where d.Id == objUserForm.FormId
                           select d;

                if (form.Any() == false)
                {
                    return new String[] { "Form not found.", "0" };
                }

                Data.MstUserForm newUserForm = new Data.MstUserForm
                {
                    FormId = objUserForm.FormId,
                    UserId = objUserForm.UserId,
                    CanDelete = objUserForm.CanDelete,
                    CanAdd = objUserForm.CanAdd,
                    CanLock = objUserForm.CanLock,
                    CanUnlock = objUserForm.CanUnlock,
                    CanPrint = objUserForm.CanPrint,
                    CanPreview = objUserForm.CanPreview,
                    CanEdit = objUserForm.CanEdit,
                };

                db.MstUserForms.InsertOnSubmit(newUserForm);
                db.SubmitChanges();

                return new String[] { "", "1" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ================
        // Update User Form
        // ================
        public String[] UpdateUserForm(Int32 id, Entities.MstUserFormEntity objUserForm)
        {
            try
            {
                var userForm = from d in db.MstUserForms
                               where d.Id == id
                               select d;

                if (userForm.Any())
                {
                    var user = from d in db.MstUsers
                               where d.Id == objUserForm.UserId
                               select d;

                    if (user.Any() == false)
                    {
                        return new String[] { "User transaction not found.", "0" };
                    }

                    var updateUserForm = userForm.FirstOrDefault();
                    updateUserForm.FormId = objUserForm.FormId;
                    updateUserForm.CanDelete = objUserForm.CanDelete;
                    updateUserForm.CanAdd = objUserForm.CanAdd;
                    updateUserForm.CanLock = objUserForm.CanLock;
                    updateUserForm.CanUnlock = objUserForm.CanUnlock;
                    updateUserForm.CanPrint = objUserForm.CanPrint;
                    updateUserForm.CanPreview = objUserForm.CanPreview;
                    updateUserForm.CanEdit = objUserForm.CanEdit;

                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Form not found.  " + id, "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ================
        // Delete User Form
        // ================
        public String[] DeleteUserForm(Int32 id)
        {
            try
            {
                var userForm = from d in db.MstUserForms
                               where d.Id == id
                               select d;

                if (userForm.Any())
                {
                    var deleteUserForm = userForm.FirstOrDefault();
                    db.MstUserForms.DeleteOnSubmit(deleteUserForm);
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Form not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
