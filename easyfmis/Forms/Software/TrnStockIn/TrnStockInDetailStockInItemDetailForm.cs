using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software.TrnStockIn
{
    public partial class TrnStockInDetailStockInItemDetailForm : Form
    {
        public TrnStockInDetailForm trnStockInDetailForm;
        public Entities.TrnStockInItemEntity trnStockInItemEntity;

        public TrnStockInDetailStockInItemDetailForm(TrnStockInDetailForm stockInDetailForm, Entities.TrnStockInItemEntity stockInLineEntity)
        {
            InitializeComponent();

            trnStockInDetailForm = stockInDetailForm;
            trnStockInItemEntity = stockInLineEntity;

            GetUnitList();

            textBoxQuantity.Focus();
            textBoxQuantity.SelectAll();
        }

        public void GetUnitList()
        {
            Controllers.TrnStockInItemController trnStockInItemController = new Controllers.TrnStockInItemController();
            if (trnStockInItemController.DropdownListArticleUnit(trnStockInItemEntity.ItemId).Any())
            {
                comboBoxUnit.DataSource = trnStockInItemController.DropdownListArticleUnit(trnStockInItemEntity.ItemId);
                comboBoxUnit.ValueMember = "UnitId";
                comboBoxUnit.DisplayMember = "Unit";

                GetStockInItemItemDetail();
            }
            else
            {
                List<Entities.MstUnitEntity> units = new List<Entities.MstUnitEntity>
                {
                    new Entities.MstUnitEntity()
                    {
                        Id = trnStockInItemEntity.UnitId,
                        Unit = trnStockInItemEntity.Unit
                    }
                };

                comboBoxUnit.DataSource = units;
                comboBoxUnit.ValueMember = "Id";
                comboBoxUnit.DisplayMember = "Unit";

                GetStockInItemItemDetail();
            }
        }

        public void GetStockInItemItemDetail()
        {
            textBoxStockInItemItemDescription.Text = trnStockInItemEntity.ItemDescription;
            textBoxQuantity.Text = trnStockInItemEntity.Quantity.ToString("#,##0.00");
            comboBoxUnit.SelectedValue = trnStockInItemEntity.UnitId;
            textBoxCost.Text = trnStockInItemEntity.Cost.ToString("#,##0.00");
            textBoxAmount.Text = trnStockInItemEntity.Amount.ToString("#,##0.00");
        }

        public void ComputeAmount()
        {
            try
            {
                if (String.IsNullOrEmpty(textBoxQuantity.Text) == false && String.IsNullOrEmpty(textBoxCost.Text) == false)
                {
                    Decimal quantity = Convert.ToDecimal(textBoxQuantity.Text);
                    Decimal cost = Convert.ToDecimal(textBoxCost.Text);
                    Decimal amount = cost * quantity;

                    textBoxAmount.Text = amount.ToString("#,##0.00");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveStockInItem();
        }

        public void SaveStockInItem()
        {
            var id = trnStockInItemEntity.Id;
            var INId = trnStockInItemEntity.INId;
            var itemId = trnStockInItemEntity.ItemId;
            var itemDescription = trnStockInItemEntity.ItemDescription;
            var unitId = Convert.ToInt32(comboBoxUnit.SelectedValue);
            var unit = trnStockInItemEntity.Unit;
            var quantity = Convert.ToDecimal(textBoxQuantity.Text);
            var cost = Convert.ToDecimal(textBoxCost.Text);
            var amount = Convert.ToDecimal(textBoxAmount.Text);

            Entities.TrnStockInItemEntity newStockInItemEntity = new Entities.TrnStockInItemEntity()
            {
                Id = id,
                INId = INId,
                ItemId = itemId,
                ItemDescription = itemDescription,
                UnitId = unitId,
                Unit = unit,
                Quantity = quantity,
                Cost = cost,
                Amount = amount
            };

            Controllers.TrnStockInItemController trnPOSStockInItemController = new Controllers.TrnStockInItemController();
            if (newStockInItemEntity.Id == 0)
            {
                String[] addStockInItem = trnPOSStockInItemController.AddStockInItem(newStockInItemEntity);
                if (addStockInItem[1].Equals("0") == false)
                {
                    trnStockInDetailForm.UpdateStockInItemDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(addStockInItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                String[] updateStockInItem = trnPOSStockInItemController.UpdateStockInItem(trnStockInItemEntity.Id, newStockInItemEntity);
                if (updateStockInItem[1].Equals("0") == false)
                {
                    trnStockInDetailForm.UpdateStockInItemDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(updateStockInItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxStockInItemQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxStockInItemCost_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxStockInItemPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxStockInItemQuantity_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxQuantity.Text))
            {
                textBoxQuantity.Text = "0.00";
            }

            ComputeAmount();
        }

        private void textBoxStockInItemCost_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxCost.Text))
            {
                textBoxCost.Text = "0.00";
            }

            ComputeAmount();
        }

        private void textBoxStockInItemQuantity_Leave(object sender, EventArgs e)
        {
            textBoxQuantity.Text = Convert.ToDecimal(textBoxQuantity.Text).ToString("#,##0.00");
        }

        private void textBoxStockInItemCost_Leave(object sender, EventArgs e)
        {
            textBoxCost.Text = Convert.ToDecimal(textBoxCost.Text).ToString("#,##0.00");
        }
    }
}
