using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software.SysSystemTables
{
    public partial class SysSystemTablesBankDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public SysSystemTablesForm sysSystemTablesForm;
        public Entities.MstArticleEntity mstBankEntity;

        public SysSystemTablesBankDetailForm(SysSystemTablesForm systemTablesForm, Entities.MstArticleEntity bankEntity)
        {
            InitializeComponent();

            sysSystemTablesForm = systemTablesForm;
            mstBankEntity = bankEntity;

            DropdownArticleGroup();
        }

        public void DropdownArticleGroup()
        {
            Controllers.MstArticleController mstArticleController = new Controllers.MstArticleController();
            var articleGroup = mstArticleController.DropDownListArticleGroup("BANK");
            if (articleGroup.Any())
            {
                comboBoxArticleGroup.DataSource = articleGroup;
                comboBoxArticleGroup.DisplayMember = "ArticleGroup";
                comboBoxArticleGroup.ValueMember = "Id";
            }
            GetBankDetail();
        }


        public void GetBankDetail()
        {
            UpdateComponents(mstBankEntity.IsLocked);

            textBoxBankCode.Text = mstBankEntity.ArticleCode;
            comboBoxArticleGroup.SelectedValue = mstBankEntity.ArticleGroupId;
            textBoxBank.Text = mstBankEntity.Article;
            textBoxAddress.Text = mstBankEntity.Address;
            textBoxContactPerson.Text = mstBankEntity.ContactPerson;
            textBoxContactNumber.Text = mstBankEntity.ContactNumber;
            textBoxEmailAddress.Text = mstBankEntity.EmailAddress;
            textBoxTIN.Text = mstBankEntity.TIN;
        }

        public void UpdateComponents(Boolean isLocked)
        {
            buttonLock.Enabled = !isLocked;
            buttonUnlock.Enabled = isLocked;
            comboBoxArticleGroup.Enabled = !isLocked;
            textBoxBankCode.Enabled = !isLocked;
            textBoxBank.Enabled = !isLocked;
            textBoxAddress.Enabled = !isLocked;
            textBoxContactPerson.Enabled = !isLocked;
            textBoxContactNumber.Enabled = !isLocked;
            textBoxTIN.Enabled = !isLocked;
            textBoxEmailAddress.Enabled = !isLocked;
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            Controllers.MstArticleController mstArticleController = new Controllers.MstArticleController();

            mstBankEntity.ArticleGroupId = Convert.ToInt32(comboBoxArticleGroup.SelectedValue);
            mstBankEntity.ArticleCode = textBoxBankCode.Text;
            mstBankEntity.Article = textBoxBank.Text;
            mstBankEntity.Address = textBoxAddress.Text;
            mstBankEntity.ContactPerson = textBoxContactPerson.Text;
            mstBankEntity.ContactNumber = textBoxContactNumber.Text;
            mstBankEntity.EmailAddress = textBoxEmailAddress.Text;
            mstBankEntity.TIN = textBoxTIN.Text;


            String[] lockBank = mstArticleController.LockArticle(mstBankEntity);
            if (lockBank[1].Equals("0") == false)
            {
                UpdateComponents(true);
                sysSystemTablesForm.UpdateBankListDataSource();
            }
            else
            {
                UpdateComponents(false);
                MessageBox.Show(lockBank[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            Controllers.MstArticleController mstBankController = new Controllers.MstArticleController();

            String[] unlockBank = mstBankController.UnlockArticle(mstBankEntity);
            if (unlockBank[1].Equals("0") == false)
            {
                UpdateComponents(false);
                sysSystemTablesForm.UpdateBankListDataSource();
            }
            else
            {
                UpdateComponents(true);
                MessageBox.Show(unlockBank[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
