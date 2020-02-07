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
    public partial class SysSystemTablesCurrencyDetailForm : Form
    {

        Entities.MstCurrencyEntity mstCurrencyEntity;
        SysSystemTablesForm sysSystemTablesForm;

        public SysSystemTablesCurrencyDetailForm(SysSystemTablesForm systemTablesForm, Entities.MstCurrencyEntity mstCurrency)
        {
            InitializeComponent();

            sysSystemTablesForm = systemTablesForm;
            mstCurrencyEntity = mstCurrency;

            LoadCurrency();
        }

        public void LoadCurrency()
        {
            if (mstCurrencyEntity != null)
            {
                textBoxCode.Text = mstCurrencyEntity.CurrencyCode;
                textBoxCurrency.Text = mstCurrencyEntity.Currency;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (mstCurrencyEntity == null)
            {
                Entities.MstCurrencyEntity newCurrency = new Entities.MstCurrencyEntity()
                {
                    CurrencyCode = textBoxCode.Text,
                    Currency = textBoxCurrency.Text
                };

                Controllers.MstCurrencyController mstCurrencyController = new Controllers.MstCurrencyController();
                String[] addCurrency = mstCurrencyController.AddCurrency(newCurrency);
                if (addCurrency[1].Equals("0") == true)
                {
                    MessageBox.Show(addCurrency[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    sysSystemTablesForm.UpdateCurrencyListDataSource();
                    Close();
                }
            }
            else
            {
                mstCurrencyEntity.CurrencyCode = textBoxCode.Text;
                mstCurrencyEntity.Currency = textBoxCurrency.Text;

                Controllers.MstCurrencyController mstCurrencyController = new Controllers.MstCurrencyController();
                String[] updateCurrency = mstCurrencyController.UpdateCurrency(mstCurrencyEntity);
                if (updateCurrency[1].Equals("0") == true)
                {
                    MessageBox.Show(updateCurrency[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    sysSystemTablesForm.UpdateCurrencyListDataSource();
                    Close();
                }

            }
        }
    }
}
