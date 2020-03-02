using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software.MstUser
{
    public partial class MstUserDetailUserFormDetailForm : Form
    {
        public MstUserDetailForm mstUserDetailForm;

        public Entities.MstUserFormEntity mtUserFormEntity;

        public MstUserDetailUserFormDetailForm(MstUserDetailForm userDetailForm, Entities.MstUserFormEntity userFormEntity)
        {
            InitializeComponent();

            mstUserDetailForm = userDetailForm;
            mtUserFormEntity = userFormEntity;

            GetFormList();
        }

        public void GetFormList()
        {
            Controllers.MstUserFormController mstUserFormController = new Controllers.MstUserFormController();
            if (mstUserFormController.DropdownListForm().Any())
            {
                comboBoxForm.DataSource = mstUserFormController.DropdownListForm();
                comboBoxForm.ValueMember = "Id";
                comboBoxForm.DisplayMember = "FormDescription";

                GetUserFormDetail();
            }
        }

        public void GetUserFormDetail()
        {
            comboBoxForm.SelectedValue = mtUserFormEntity.FormId;
            checkBoxCanDelete.Checked = mtUserFormEntity.CanDelete;
            checkBoxCanAdd.Checked = mtUserFormEntity.CanAdd;
            checkBoxCanLock.Checked = mtUserFormEntity.CanLock;
            checkBoxCanUnlock.Checked = mtUserFormEntity.CanUnlock;
            checkBoxCanPrint.Checked = mtUserFormEntity.CanPrint;
            checkBoxCanPreview.Checked = mtUserFormEntity.CanPreview;
            checkBoxCanEdit.Checked = mtUserFormEntity.CanEdit;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveUserForm();
        }

        public void SaveUserForm()
        {
            Entities.MstUserFormEntity newUserFormEntity = new Entities.MstUserFormEntity()
            {
                Id = mtUserFormEntity.Id,
                FormId = Convert.ToInt32(comboBoxForm.SelectedValue),
                Form = "",
                UserId = mtUserFormEntity.UserId,
                CanDelete = checkBoxCanDelete.Checked,
                CanAdd = checkBoxCanAdd.Checked,
                CanLock = checkBoxCanLock.Checked,
                CanUnlock = checkBoxCanUnlock.Checked,
                CanPrint = checkBoxCanPrint.Checked,
                CanPreview = checkBoxCanPreview.Checked,
                CanEdit = checkBoxCanEdit.Checked,
            };

            Controllers.MstUserFormController mstUserFormController = new Controllers.MstUserFormController();
            if (newUserFormEntity.Id == 0)
            {
                String[] addUserForm = mstUserFormController.AddUserForm(newUserFormEntity);
                if (addUserForm[1].Equals("0") == false)
                {
                    mstUserDetailForm.UpdateUserFormListDataSource();
                }
                else
                {
                    MessageBox.Show(addUserForm[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                String[] updateUserForm = mstUserFormController.UpdateUserForm(mtUserFormEntity.Id, newUserFormEntity);
                if (updateUserForm[1].Equals("0") == false)
                {
                    mstUserDetailForm.UpdateUserFormListDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(updateUserForm[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
