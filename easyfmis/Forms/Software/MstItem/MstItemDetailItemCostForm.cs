using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software.MstItem
{
    public partial class MstItemDetailItemCostForm : Form
    {
        public Entities.MstArticleCostEntity mstArticleCostEntity;
        public MstItemDetailForm mstItemDetailForm;
        public Int32 itemId;

        public MstItemDetailItemCostForm(MstItemDetailForm itemDetailForm, Entities.MstArticleCostEntity articleCostEntity, Int32 articleId)
        {
            InitializeComponent();
            mstItemDetailForm = itemDetailForm;
            mstArticleCostEntity = articleCostEntity;
            itemId = articleId;

            GetCurrency();
        }

        public void LoadCostDetail()
        {
            if (mstArticleCostEntity != null)
            {
                textBoxCostDescription.Text = mstArticleCostEntity.CostDescription;
                textBoxCost.Text = mstArticleCostEntity.Cost.ToString("#,##0.00");
                comboBoxCurrency.SelectedValue = mstArticleCostEntity.CurrencyId;
            }
            else {
                textBoxCostDescription.Text = "NA";
                textBoxCost.Text = 0.ToString("#,##0.00");
            }
        }

        public void GetCurrency()
        {
            Controllers.MstArticleCostController mstArticleCostController = new Controllers.MstArticleCostController();
            var currencies = mstArticleCostController.ListCurrency();
            if (currencies != null)
            {
                comboBoxCurrency.DataSource = currencies;
                comboBoxCurrency.ValueMember = "Id";
                comboBoxCurrency.DisplayMember = "CurrencyCode";
                LoadCostDetail();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (mstArticleCostEntity == null)
            {
                Entities.MstArticleCostEntity newCost = new Entities.MstArticleCostEntity()
                {
                    ArticleId = itemId,
                    CostDescription = textBoxCostDescription.Text,
                    Cost = Convert.ToDecimal(textBoxCost.Text),
                    CurrencyId = Convert.ToInt32(comboBoxCurrency.SelectedValue),
                };

                Controllers.MstArticleCostController mstArticleCostController = new Controllers.MstArticleCostController();

                String[] addCost = mstArticleCostController.AddCost(newCost);
                if (addCost[1].Equals("0") == true)
                {
                    MessageBox.Show(addCost[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    mstItemDetailForm.UpdateCostListDataSource();
                    Close();
                }
            }
            else
            {
                mstArticleCostEntity.CostDescription = textBoxCostDescription.Text;
                mstArticleCostEntity.Cost = Convert.ToDecimal(textBoxCost.Text);
                mstArticleCostEntity.CurrencyId = Convert.ToInt32(comboBoxCurrency.SelectedValue);
                Controllers.MstArticleCostController mstArticleCostController = new Controllers.MstArticleCostController();
                String[] updateCost = mstArticleCostController.UpdateCost(mstArticleCostEntity);
                if (updateCost[1].Equals("0") == true)
                {
                    MessageBox.Show(updateCost[0], "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    mstItemDetailForm.UpdateCostListDataSource();
                    Close();
                }

            }
        }

        private void textBoxCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBoxCost_Leave(object sender, EventArgs e)
        {
            textBoxCost.Text = Convert.ToDecimal(textBoxCost.Text).ToString("#,##0.00");
        }
    }
}
