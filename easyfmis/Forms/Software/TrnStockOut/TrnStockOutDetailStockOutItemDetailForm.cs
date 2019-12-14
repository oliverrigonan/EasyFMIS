using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software.TrnStockOut
{
    public partial class TrnStockOutDetailStockOutItemDetailForm : Form
    {
        public TrnStockOutDetailForm trnStockOutDetailForm;
        public Entities.TrnStockOutItemEntity trnStockOutItemEntity;

        public TrnStockOutDetailStockOutItemDetailForm(TrnStockOutDetailForm stockOutDetailForm, Entities.TrnStockOutItemEntity stockOutLineEntity)
        {
            InitializeComponent();

            trnStockOutDetailForm = stockOutDetailForm;
            trnStockOutItemEntity = stockOutLineEntity;

            GetUnitList();

            textBoxQuantity.Focus();
            textBoxQuantity.SelectAll();
        }

        public void GetUnitList()
        {
            Controllers.TrnStockOutItemController trnStockOutItemController = new Controllers.TrnStockOutItemController();
            if (trnStockOutItemController.DropdownListArticleUnit(trnStockOutItemEntity.ItemId).Any())
            {
                comboBoxUnit.DataSource = trnStockOutItemController.DropdownListArticleUnit(trnStockOutItemEntity.ItemId);
                comboBoxUnit.ValueMember = "UnitId";
                comboBoxUnit.DisplayMember = "Unit";

                GetInventoryCode();
            }
            else
            {
                List<Entities.MstUnitEntity> units = new List<Entities.MstUnitEntity>
                {
                    new Entities.MstUnitEntity()
                    {
                        Id = trnStockOutItemEntity.UnitId,
                        Unit = trnStockOutItemEntity.Unit
                    }
                };

                comboBoxUnit.DataSource = units;
                comboBoxUnit.ValueMember = "Id";
                comboBoxUnit.DisplayMember = "Unit";

                GetInventoryCode();
            }
        }

        public void GetInventoryCode()
        {
            Controllers.TrnStockOutItemController trnStockOutItemController = new Controllers.TrnStockOutItemController();
            if (trnStockOutItemController.DropdownListArticleInventory(trnStockOutItemEntity.ItemId).Any())
            {
                comboBoxInventoryCode.DataSource = trnStockOutItemController.DropdownListArticleInventory(trnStockOutItemEntity.ItemId);
                comboBoxInventoryCode.ValueMember = "Id";
                comboBoxInventoryCode.DisplayMember = "InventoryCode";
            }

            GetStockOutItemItemDetail();
        }

        public void GetStockOutItemItemDetail()
        {
            textBoxStockOutItemItemDescription.Text = trnStockOutItemEntity.ItemDescription;
            textBoxQuantity.Text = trnStockOutItemEntity.Quantity.ToString("#,##0.00");
            comboBoxUnit.SelectedValue = trnStockOutItemEntity.UnitId;
            comboBoxInventoryCode.SelectedValue = trnStockOutItemEntity.ItemInventoryId;
            textBoxCost.Text = trnStockOutItemEntity.Cost.ToString("#,##0.00");
            textBoxAmount.Text = trnStockOutItemEntity.Amount.ToString("#,##0.00");
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
            SaveStockOutItem();
        }

        public void SaveStockOutItem()
        {
            var id = trnStockOutItemEntity.Id;
            var OTId = trnStockOutItemEntity.OTId;
            var itemId = trnStockOutItemEntity.ItemId;
            var itemDescription = trnStockOutItemEntity.ItemDescription;
            var unitId = Convert.ToInt32(comboBoxUnit.SelectedValue);
            var unit = trnStockOutItemEntity.Unit;
            var itemInventoryId = Convert.ToInt32(comboBoxInventoryCode.SelectedValue);
            var quantity = Convert.ToDecimal(textBoxQuantity.Text);
            var cost = Convert.ToDecimal(textBoxCost.Text);
            var amount = Convert.ToDecimal(textBoxAmount.Text);

            Entities.TrnStockOutItemEntity newStockOutItemEntity = new Entities.TrnStockOutItemEntity()
            {
                Id = id,
                OTId = OTId,
                ItemId = itemId,
                ItemDescription = itemDescription,
                UnitId = unitId,
                Unit = unit,
                ItemInventoryId = itemInventoryId,
                Quantity = quantity,
                Cost = cost,
                Amount = amount
            };

            Controllers.TrnStockOutItemController trnPOSStockOutItemController = new Controllers.TrnStockOutItemController();
            if (newStockOutItemEntity.Id == 0)
            {
                String[] addStockOutItem = trnPOSStockOutItemController.AddStockOutItem(newStockOutItemEntity);
                if (addStockOutItem[1].Equals("0") == false)
                {
                    trnStockOutDetailForm.UpdateStockOutItemDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(addStockOutItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                String[] updateStockOutItem = trnPOSStockOutItemController.UpdateStockOutItem(trnStockOutItemEntity.Id, newStockOutItemEntity);
                if (updateStockOutItem[1].Equals("0") == false)
                {
                    trnStockOutDetailForm.UpdateStockOutItemDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(updateStockOutItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxStockOutItemQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxStockOutItemCost_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxStockOutItemPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxStockOutItemQuantity_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxQuantity.Text))
            {
                textBoxQuantity.Text = "0.00";
            }

            ComputeAmount();
        }

        private void textBoxStockOutItemCost_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxCost.Text))
            {
                textBoxCost.Text = "0.00";
            }

            ComputeAmount();
        }

        private void textBoxStockOutItemQuantity_Leave(object sender, EventArgs e)
        {
            textBoxQuantity.Text = Convert.ToDecimal(textBoxQuantity.Text).ToString("#,##0.00");
        }

        private void textBoxStockOutItemCost_Leave(object sender, EventArgs e)
        {
            textBoxCost.Text = Convert.ToDecimal(textBoxCost.Text).ToString("#,##0.00");
        }
    }
}
