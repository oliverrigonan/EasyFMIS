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
    public partial class MstArticleComponentForm : Form
    {
        MstItemDetailForm mstItemDetailForm;
        Entities.MstArticleComponentEntity mstArticleComponentEntity;

        public MstArticleComponentForm(MstItemDetailForm itemDetailForm, Entities.MstArticleComponentEntity articleComponentEntity)
        {
            InitializeComponent();
            mstItemDetailForm = itemDetailForm;
            mstArticleComponentEntity = articleComponentEntity;

            GetItemComponentList();
        }

        public void GetItemComponentList()
        {
            Controllers.MstArticleComponentController mstItemComponentController = new Controllers.MstArticleComponentController();
            var items = mstItemComponentController.DropdownListItem(mstArticleComponentEntity.ItemId);
            if (items.Any())
            {
                comboBoxItemComponent.DataSource = items;
                comboBoxItemComponent.ValueMember = "Id";
                comboBoxItemComponent.DisplayMember = "Article";
            }
            LoadItemComponent();
        }

        public void LoadItemComponent()
        {
            comboBoxItemComponent.SelectedValue = mstArticleComponentEntity.ComponentItemId;
            textBoxUnit.Text = mstArticleComponentEntity.Unit;
            textBoxQuantity.Text = mstArticleComponentEntity.Quantity.ToString("#,##0.00");
            textBoxCost.Text = mstArticleComponentEntity.Cost.ToString("#,##0.00");
            textBoxAmount.Text = mstArticleComponentEntity.Amount.ToString("#,##0.00");

            computeAmount();
        }

        private void comboBoxItemComponent_Click(object sender, EventArgs e)
        {
            GetItemComponentList();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                Entities.MstArticleComponentEntity newItemComponent = new Entities.MstArticleComponentEntity()
                {
                    Id = mstArticleComponentEntity.Id,
                    ItemId = mstArticleComponentEntity.ItemId,
                    ComponentItemId = Convert.ToInt32(comboBoxItemComponent.SelectedValue),
                    Quantity = Convert.ToDecimal(textBoxQuantity.Text),
                    Cost = Convert.ToDecimal(textBoxCost.Text),
                    Amount = Convert.ToDecimal(textBoxAmount.Text),
                };

                if (mstArticleComponentEntity.Id == 0)
                {
                    Controllers.MstArticleComponentController mstItemComponentController = new Controllers.MstArticleComponentController();
                    String[] addItemComponent = mstItemComponentController.AddItemComponent(newItemComponent);

                    if (addItemComponent[1].Equals("0") == true)
                    {
                        MessageBox.Show(addItemComponent[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        mstItemDetailForm.UpdateItemComponentListDataSource();
                        Close();
                    }
                }
                else
                {
                    Controllers.MstArticleComponentController mstItemComponentController = new Controllers.MstArticleComponentController();
                    String[] updateItemComponent = mstItemComponentController.UpdateItemComponent(newItemComponent);

                    if (updateItemComponent[1].Equals("0") == true)
                    {
                        MessageBox.Show(updateItemComponent[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        mstItemDetailForm.UpdateItemComponentListDataSource();
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxQuantity_Leave(object sender, EventArgs e)
        {
            textBoxQuantity.Text = Convert.ToDecimal(textBoxQuantity.Text).ToString("#,##0.00");
            computeAmount();
        }

        private void comboBoxItemComponent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxItemComponent.SelectedItem == null)
            {
                return;
            }

            var selectedItemItemComponent = (Entities.MstArticleEntity)comboBoxItemComponent.SelectedItem;
            if (selectedItemItemComponent != null)
            {
                textBoxUnit.Text = selectedItemItemComponent.Unit;
                textBoxCost.Text = selectedItemItemComponent.DefaultCost.ToString("#,##0.00");

                if (String.IsNullOrEmpty(textBoxQuantity.Text) == false)
                {
                    computeAmount();
                }
            }
        }


        public void computeAmount()
        {
            Decimal quantity = Convert.ToDecimal(textBoxQuantity.Text);
            Decimal cost = Convert.ToDecimal(textBoxCost.Text);
            Decimal amount = quantity * cost;

            textBoxAmount.Text = amount.ToString("#,##0.00");
        }
    }
}
