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
    public partial class SysSystemTablesPayTypeDetailForm : Form
    {
        SysSystemTablesForm sysSystemTablesForm;

        Entities.MstPayTypeEntity mstPayTypeEntity;

        public SysSystemTablesPayTypeDetailForm(SysSystemTablesForm systemTablesForm, Entities.MstPayTypeEntity payTypeEntity)
        {
            InitializeComponent();
            sysSystemTablesForm = systemTablesForm;
            mstPayTypeEntity = payTypeEntity;


            GetAccountList();
        }

        public void LoadPayType()
        {
            if (mstPayTypeEntity != null)
            {
                textBoxPayType.Text = mstPayTypeEntity.PayType;
                comboBoxAccount.SelectedValue = mstPayTypeEntity.AccountId;
            }
        }

        public void GetAccountList()
        {
            Controllers.MstPayTypeController mstPayTypeController = new Controllers.MstPayTypeController();
            var accounts = mstPayTypeController.DropDownListAccount();
            if (accounts.Any())
            {
                comboBoxAccount.DataSource = accounts;
                comboBoxAccount.ValueMember = "Id";
                comboBoxAccount.DisplayMember = "Account";

                LoadPayType();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Int32 payTypeId;

            if (mstPayTypeEntity == null)
            {
                payTypeId = 0;
            }
            else
            {
                payTypeId = mstPayTypeEntity.Id;
            }

            Entities.MstPayTypeEntity currentPayType = new Entities.MstPayTypeEntity()
            {
                Id = payTypeId,
                PayType = textBoxPayType.Text,
                AccountId = Convert.ToInt32(comboBoxAccount.SelectedValue)
            };

            if (mstPayTypeEntity == null)
            {
                Controllers.MstPayTypeController mstPayTypeController = new Controllers.MstPayTypeController();
                String[] addPayType = mstPayTypeController.AddPayType(currentPayType);
                if (addPayType[1].Equals("0"))
                {
                    MessageBox.Show(addPayType[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    sysSystemTablesForm.UpdatePayTypeListDataSource();
                    Close();
                }
            }
            else
            {
                Controllers.MstPayTypeController mstPayTypeController = new Controllers.MstPayTypeController();
                String[] updatePayType = mstPayTypeController.UpdatePayType(currentPayType);
                if (updatePayType[1].Equals("0"))
                {
                    MessageBox.Show(updatePayType[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    sysSystemTablesForm.UpdatePayTypeListDataSource();
                    Close();
                }
            }
        }
    }
}
