using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software.MstCustomer
{
    public partial class MstCustomerDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public MstCustomerListForm mstCustomerListForm;
        public Entities.MstArticleEntity mstCustomerEntity;

        public MstCustomerDetailForm(SysSoftwareForm softwareForm, MstCustomerListForm itemListForm, Entities.MstArticleEntity customerEntity)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            mstCustomerListForm = itemListForm;
            mstCustomerEntity = customerEntity;

            GetCustomerDetail();
        }


        public void GetCustomerDetail()
        {
            UpdateComponents(mstCustomerEntity.IsLocked);

            textBoxCustomerCode.Text = mstCustomerEntity.ArticleCode;
            textBoxCustomer.Text = mstCustomerEntity.Article;
            textBoxAddress.Text = mstCustomerEntity.Address;
            textBoxContactPerson.Text = mstCustomerEntity.ContactPerson;
            textBoxContactNumber.Text = mstCustomerEntity.ContactNumber;
            textBoxEmailAddress.Text = mstCustomerEntity.EmailAddress;
            textBoxTIN.Text = mstCustomerEntity.TIN;
        }

        public void UpdateComponents(Boolean isLocked)
        {
            buttonLock.Enabled = !isLocked;
            buttonUnlock.Enabled = isLocked;

            textBoxCustomerCode.Enabled = !isLocked;
            textBoxCustomer.Enabled = !isLocked;
            textBoxAddress.Enabled = !isLocked;
            textBoxContactPerson.Enabled = !isLocked;
            textBoxContactNumber.Enabled = !isLocked;
            textBoxTIN.Enabled = !isLocked;
            textBoxEmailAddress.Enabled = !isLocked;
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            Controllers.MstArticleController mstArticleController = new Controllers.MstArticleController();

            mstCustomerEntity.ArticleCode = textBoxCustomerCode.Text;
            mstCustomerEntity.Article = textBoxCustomer.Text;
            mstCustomerEntity.Address = textBoxAddress.Text;
            mstCustomerEntity.ContactPerson = textBoxContactPerson.Text;
            mstCustomerEntity.ContactNumber = textBoxContactNumber.Text;
            mstCustomerEntity.EmailAddress = textBoxEmailAddress.Text;
            mstCustomerEntity.TIN = textBoxTIN.Text;


            String[] lockCustomer = mstArticleController.LockArticle(mstCustomerEntity);
            if (lockCustomer[1].Equals("0") == false)
            {
                UpdateComponents(true);
                mstCustomerListForm.UpdateCustomerListDataSource();
            }
            else
            {
                UpdateComponents(false);
                MessageBox.Show(lockCustomer[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            Controllers.MstArticleController mstCustomerController = new Controllers.MstArticleController();

            String[] unlockCustomer = mstCustomerController.UnlockArticle(mstCustomerEntity);
            if (unlockCustomer[1].Equals("0") == false)
            {
                UpdateComponents(false);
                mstCustomerListForm.UpdateCustomerListDataSource();
            }
            else
            {
                UpdateComponents(true);
                MessageBox.Show(unlockCustomer[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }
    }
}
