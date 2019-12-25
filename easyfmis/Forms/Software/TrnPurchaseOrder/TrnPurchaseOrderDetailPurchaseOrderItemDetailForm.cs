using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software.TrnPurchaseOrder
{
    public partial class TrnPurchaseOrderDetailPurchaseOrderItemDetailForm : Form
    {
        public TrnPurchaseOrderDetailForm trnPurchaseOrderDetailForm;
        public Entities.TrnPurchaseOrderItemEntity trnPurchaseOrderItemEntity;

        public TrnPurchaseOrderDetailPurchaseOrderItemDetailForm(TrnPurchaseOrderDetailForm purchaseOrderDetailForm, Entities.TrnPurchaseOrderItemEntity purchaseOrderItemEntity)
        {
            InitializeComponent();

            trnPurchaseOrderDetailForm = purchaseOrderDetailForm;
            trnPurchaseOrderItemEntity = purchaseOrderItemEntity;

            GetUnitList();

            textBoxQuantity.Focus();
            textBoxQuantity.SelectAll();
        }

        public void GetUnitList()
        {
            Controllers.TrnPurchaseOrderItemController trnPurchaseOrderItemController = new Controllers.TrnPurchaseOrderItemController();
            if (trnPurchaseOrderItemController.DropdownListArticleUnit(trnPurchaseOrderItemEntity.ItemId).Any())
            {
                comboBoxUnit.DataSource = trnPurchaseOrderItemController.DropdownListArticleUnit(trnPurchaseOrderItemEntity.ItemId);
                comboBoxUnit.ValueMember = "UnitId";
                comboBoxUnit.DisplayMember = "Unit";

                GetPurchaseOrderItemItemDetail();
            }
            else
            {
                List<Entities.MstUnitEntity> units = new List<Entities.MstUnitEntity>
                {
                    new Entities.MstUnitEntity()
                    {
                        Id = trnPurchaseOrderItemEntity.UnitId,
                        Unit = trnPurchaseOrderItemEntity.Unit
                    }
                };

                comboBoxUnit.DataSource = units;
                comboBoxUnit.ValueMember = "Id";
                comboBoxUnit.DisplayMember = "Unit";

                GetPurchaseOrderItemItemDetail();
            }
        }

        public void GetPurchaseOrderItemItemDetail()
        {
            textBoxPurchaseOrderItemItemDescription.Text = trnPurchaseOrderItemEntity.ItemDescription;
            textBoxQuantity.Text = trnPurchaseOrderItemEntity.Quantity.ToString("#,##0.00");
            comboBoxUnit.SelectedValue = trnPurchaseOrderItemEntity.UnitId;
            textBoxCost.Text = trnPurchaseOrderItemEntity.Cost.ToString("#,##0.00");
            textBoxAmount.Text = trnPurchaseOrderItemEntity.Amount.ToString("#,##0.00");
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
            SavePurchaseOrderItem();
        }

        public void SavePurchaseOrderItem()
        {
            var id = trnPurchaseOrderItemEntity.Id;
            var pOId = trnPurchaseOrderItemEntity.POId;
            var itemId = trnPurchaseOrderItemEntity.ItemId;
            var itemDescription = trnPurchaseOrderItemEntity.ItemDescription;
            var unitId = Convert.ToInt32(comboBoxUnit.SelectedValue);
            var unit = trnPurchaseOrderItemEntity.Unit;
            var quantity = Convert.ToDecimal(textBoxQuantity.Text);
            var cost = Convert.ToDecimal(textBoxCost.Text);
            var amount = Convert.ToDecimal(textBoxAmount.Text);

            Entities.TrnPurchaseOrderItemEntity newPurchaseOrderItemEntity = new Entities.TrnPurchaseOrderItemEntity()
            {
                Id = id,
                POId = pOId,
                ItemId = itemId,
                ItemDescription = itemDescription,
                UnitId = unitId,
                Unit = unit,
                Quantity = quantity,
                Cost = cost,
                Amount = amount
            };

            Controllers.TrnPurchaseOrderItemController trnPurchaseOrderItemController = new Controllers.TrnPurchaseOrderItemController();
            if (newPurchaseOrderItemEntity.Id == 0)
            {
                String[] addPurchaseOrderItem = trnPurchaseOrderItemController.AddPurchaseOrderItem(newPurchaseOrderItemEntity);
                if (addPurchaseOrderItem[1].Equals("0") == false)
                {
                    trnPurchaseOrderDetailForm.UpdatePurchaseOrderItemDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(addPurchaseOrderItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                String[] updatePurchaseOrderItem = trnPurchaseOrderItemController.UpdatePurchaseOrderItem(trnPurchaseOrderItemEntity.Id, newPurchaseOrderItemEntity);
                if (updatePurchaseOrderItem[1].Equals("0") == false)
                {
                    trnPurchaseOrderDetailForm.UpdatePurchaseOrderItemDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(updatePurchaseOrderItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxPurchaseOrderItemQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxPurchaseOrderItemCost_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxPurchaseOrderItemPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxPurchaseOrderItemQuantity_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxQuantity.Text))
            {
                textBoxQuantity.Text = "0.00";
            }

            ComputeAmount();
        }

        private void textBoxPurchaseOrderItemCost_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxCost.Text))
            {
                textBoxCost.Text = "0.00";
            }

            ComputeAmount();
        }

        private void textBoxPurchaseOrderItemQuantity_Leave(object sender, EventArgs e)
        {
            textBoxQuantity.Text = Convert.ToDecimal(textBoxQuantity.Text).ToString("#,##0.00");
        }

        private void textBoxPurchaseOrderItemCost_Leave(object sender, EventArgs e)
        {
            textBoxCost.Text = Convert.ToDecimal(textBoxCost.Text).ToString("#,##0.00");
        }
    }
}
