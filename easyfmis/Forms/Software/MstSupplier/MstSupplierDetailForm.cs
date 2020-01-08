using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software.MstSupplier
{
    public partial class MstSupplierDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public MstSupplierListForm mstSupplierListForm;
        public Entities.MstArticleEntity mstSupplierEntity;

        public MstSupplierDetailForm(SysSoftwareForm softwareForm, MstSupplierListForm itemListForm, Entities.MstArticleEntity supplierEntity)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            mstSupplierListForm = itemListForm;
            mstSupplierEntity = supplierEntity;

            DropdownArticleGroup();
        }

        public void DropdownArticleGroup()
        {
            Controllers.MstArticleController mstArticleController = new Controllers.MstArticleController();
            var articleGroup = mstArticleController.DropDownListArticleGroup("SUPPLIER");
            if (articleGroup.Any())
            {
                comboBoxArticleGroup.DataSource = articleGroup;
                comboBoxArticleGroup.DisplayMember = "ArticleGroup";
                comboBoxArticleGroup.ValueMember = "Id";
            }
            GetSupplierDetail();
        }


        public void GetSupplierDetail()
        {
            UpdateComponents(mstSupplierEntity.IsLocked);

            textBoxSupplierCode.Text = mstSupplierEntity.ArticleCode;
            comboBoxArticleGroup.SelectedValue = mstSupplierEntity.ArticleGroupId;
            textBoxSupplier.Text = mstSupplierEntity.Article;
            textBoxAddress.Text = mstSupplierEntity.Address;
            textBoxContactPerson.Text = mstSupplierEntity.ContactPerson;
            textBoxContactNumber.Text = mstSupplierEntity.ContactNumber;
            textBoxEmailAddress.Text = mstSupplierEntity.EmailAddress;
            textBoxTIN.Text = mstSupplierEntity.TIN;
            textBoxRemarks.Text = mstSupplierEntity.Remarks;

        }

        public void UpdateComponents(Boolean isLocked)
        {
            buttonLock.Enabled = !isLocked;
            buttonUnlock.Enabled = isLocked;
            comboBoxArticleGroup.Enabled = !isLocked;
            textBoxSupplierCode.Enabled = !isLocked;
            textBoxSupplier.Enabled = !isLocked;
            textBoxAddress.Enabled = !isLocked;
            textBoxContactPerson.Enabled = !isLocked;
            textBoxContactNumber.Enabled = !isLocked;
            textBoxTIN.Enabled = !isLocked;
            textBoxEmailAddress.Enabled = !isLocked;
            textBoxRemarks.Enabled = !isLocked;
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            Controllers.MstArticleController mstArticleController = new Controllers.MstArticleController();

            mstSupplierEntity.ArticleGroupId = Convert.ToInt32(comboBoxArticleGroup.SelectedValue);
            mstSupplierEntity.ArticleCode = textBoxSupplierCode.Text;
            mstSupplierEntity.Article = textBoxSupplier.Text;
            mstSupplierEntity.Address = textBoxAddress.Text;
            mstSupplierEntity.ContactPerson = textBoxContactPerson.Text;
            mstSupplierEntity.ContactNumber = textBoxContactNumber.Text;
            mstSupplierEntity.EmailAddress = textBoxEmailAddress.Text;
            mstSupplierEntity.TIN = textBoxTIN.Text;
            mstSupplierEntity.Remarks = textBoxRemarks.Text;

            String[] lockSupplier = mstArticleController.LockArticle(mstSupplierEntity);
            if (lockSupplier[1].Equals("0") == false)
            {
                UpdateComponents(true);
                mstSupplierListForm.UpdateSupplierListDataSource();
            }
            else
            {
                UpdateComponents(false);
                MessageBox.Show(lockSupplier[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            Controllers.MstArticleController mstSupplierController = new Controllers.MstArticleController();

            String[] unlockSupplier = mstSupplierController.UnlockArticle(mstSupplierEntity);
            if (unlockSupplier[1].Equals("0") == false)
            {
                UpdateComponents(false);
                mstSupplierListForm.UpdateSupplierListDataSource();
            }
            else
            {
                UpdateComponents(true);
                MessageBox.Show(unlockSupplier[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }
    }
}
