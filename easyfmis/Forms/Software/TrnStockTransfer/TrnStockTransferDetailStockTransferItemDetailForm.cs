using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software.TrnStockTransfer
{
    public partial class TrnStockTransferDetailStockTransferItemDetailForm : Form
    {
        public TrnStockTransferDetailForm trnStockTransferDetailForm;
        public Entities.TrnStockTransferItemEntity trnStockTransferItemEntity;

        public TrnStockTransferDetailStockTransferItemDetailForm(TrnStockTransferDetailForm stockOutDetailForm, Entities.TrnStockTransferItemEntity stockOutLineEntity)
        {
            InitializeComponent();

            trnStockTransferDetailForm = stockOutDetailForm;
            trnStockTransferItemEntity = stockOutLineEntity;

            GetUnitList();

            textBoxQuantity.Focus();
            textBoxQuantity.SelectAll();
        }

        public void GetUnitList()
        {
            Controllers.TrnStockTransferItemController trnStockTransferItemController = new Controllers.TrnStockTransferItemController();
            if (trnStockTransferItemController.DropdownListArticleUnit(trnStockTransferItemEntity.ItemId).Any())
            {
                comboBoxUnit.DataSource = trnStockTransferItemController.DropdownListArticleUnit(trnStockTransferItemEntity.ItemId);
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
                        Id = trnStockTransferItemEntity.UnitId,
                        Unit = trnStockTransferItemEntity.Unit
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
            Controllers.TrnStockTransferItemController trnStockTransferItemController = new Controllers.TrnStockTransferItemController();
            if (trnStockTransferItemController.DropdownListArticleInventory(trnStockTransferItemEntity.ItemId).Any())
            {
                comboBoxInventoryCode.DataSource = trnStockTransferItemController.DropdownListArticleInventory(trnStockTransferItemEntity.ItemId);
                comboBoxInventoryCode.ValueMember = "Id";
                comboBoxInventoryCode.DisplayMember = "InventoryCode";
            }

            GetStockTransferItemItemDetail();
        }

        public void GetStockTransferItemItemDetail()
        {
            textBoxStockTransferItemItemDescription.Text = trnStockTransferItemEntity.ItemDescription;
            textBoxQuantity.Text = trnStockTransferItemEntity.Quantity.ToString("#,##0.00");
            comboBoxUnit.SelectedValue = trnStockTransferItemEntity.UnitId;
            comboBoxInventoryCode.SelectedValue = trnStockTransferItemEntity.ItemInventoryId;
            textBoxCost.Text = trnStockTransferItemEntity.Cost.ToString("#,##0.00");
            textBoxAmount.Text = trnStockTransferItemEntity.Amount.ToString("#,##0.00");
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
            SaveStockTransferItem();
        }

        public void SaveStockTransferItem()
        {
            var id = trnStockTransferItemEntity.Id;
            var STId = trnStockTransferItemEntity.STId;
            var itemId = trnStockTransferItemEntity.ItemId;
            var itemDescription = trnStockTransferItemEntity.ItemDescription;
            var unitId = Convert.ToInt32(comboBoxUnit.SelectedValue);
            var unit = trnStockTransferItemEntity.Unit;
            var itemInventoryId = Convert.ToInt32(comboBoxInventoryCode.SelectedValue);
            var quantity = Convert.ToDecimal(textBoxQuantity.Text);
            var cost = Convert.ToDecimal(textBoxCost.Text);
            var amount = Convert.ToDecimal(textBoxAmount.Text);

            Entities.TrnStockTransferItemEntity newStockTransferItemEntity = new Entities.TrnStockTransferItemEntity()
            {
                Id = id,
                STId = STId,
                ItemId = itemId,
                ItemDescription = itemDescription,
                UnitId = unitId,
                Unit = unit,
                ItemInventoryId = itemInventoryId,
                Quantity = quantity,
                Cost = cost,
                Amount = amount
            };

            Controllers.TrnStockTransferItemController trnPOSStockTransferItemController = new Controllers.TrnStockTransferItemController();
            if (newStockTransferItemEntity.Id == 0)
            {
                String[] addStockTransferItem = trnPOSStockTransferItemController.AddStockTransferItem(newStockTransferItemEntity);
                if (addStockTransferItem[1].Equals("0") == false)
                {
                    trnStockTransferDetailForm.UpdateStockTransferItemDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(addStockTransferItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                String[] updateStockTransferItem = trnPOSStockTransferItemController.UpdateStockTransferItem(trnStockTransferItemEntity.Id, newStockTransferItemEntity);
                if (updateStockTransferItem[1].Equals("0") == false)
                {
                    trnStockTransferDetailForm.UpdateStockTransferItemDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(updateStockTransferItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxStockTransferItemQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxStockTransferItemCost_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxStockTransferItemPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxStockTransferItemQuantity_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxQuantity.Text))
            {
                textBoxQuantity.Text = "0.00";
            }

            ComputeAmount();
        }

        private void textBoxStockTransferItemCost_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxCost.Text))
            {
                textBoxCost.Text = "0.00";
            }

            ComputeAmount();
        }

        private void textBoxStockTransferItemQuantity_Leave(object sender, EventArgs e)
        {
            textBoxQuantity.Text = Convert.ToDecimal(textBoxQuantity.Text).ToString("#,##0.00");
        }

        private void textBoxStockTransferItemCost_Leave(object sender, EventArgs e)
        {
            textBoxCost.Text = Convert.ToDecimal(textBoxCost.Text).ToString("#,##0.00");
        }
    }
}
