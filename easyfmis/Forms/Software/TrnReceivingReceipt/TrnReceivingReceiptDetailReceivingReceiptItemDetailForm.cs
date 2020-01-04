using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software.TrnReceivingReceipt
{
    public partial class TrnReceivingReceiptDetailReceivingReceiptItemDetailForm : Form
    {
        public TrnReceivingReceiptDetailForm trnReceivingReceiptDetailForm;
        public Entities.TrnReceivingReceiptItemEntity trnReceivingReceiptItemEntity;

        public TrnReceivingReceiptDetailReceivingReceiptItemDetailForm(TrnReceivingReceiptDetailForm receivingReceiptDetailForm, Entities.TrnReceivingReceiptItemEntity receivingReceiptLineEntity)
        {
            InitializeComponent();

            trnReceivingReceiptDetailForm = receivingReceiptDetailForm;
            trnReceivingReceiptItemEntity = receivingReceiptLineEntity;

            GetUnitList();

            textBoxQuantity.Focus();
            textBoxQuantity.SelectAll();
        }

        public void GetUnitList()
        {
            Controllers.TrnReceivingReceiptItemController trnReceivingReceiptItemController = new Controllers.TrnReceivingReceiptItemController();
            if (trnReceivingReceiptItemController.DropdownListArticleUnit(trnReceivingReceiptItemEntity.ItemId).Any())
            {
                comboBoxUnit.DataSource = trnReceivingReceiptItemController.DropdownListArticleUnit(trnReceivingReceiptItemEntity.ItemId);
                comboBoxUnit.ValueMember = "UnitId";
                comboBoxUnit.DisplayMember = "Unit";

                GetBranch();
            }
            else
            {
                List<Entities.MstUnitEntity> units = new List<Entities.MstUnitEntity>
                {
                    new Entities.MstUnitEntity()
                    {
                        Id = trnReceivingReceiptItemEntity.UnitId,
                        Unit = trnReceivingReceiptItemEntity.Unit
                    }
                };

                comboBoxUnit.DataSource = units;
                comboBoxUnit.ValueMember = "Id";
                comboBoxUnit.DisplayMember = "Unit";

                GetBranch();
            }
        }

        public void GetBranch()
        {
            Controllers.TrnReceivingReceiptItemController trnReceivingReceiptItemController = new Controllers.TrnReceivingReceiptItemController();
            if (trnReceivingReceiptItemController.DropdownListReceivingReceiptBranch().Any())
            {
                comboBoxBranch.DataSource = trnReceivingReceiptItemController.DropdownListReceivingReceiptBranch();
                comboBoxBranch.ValueMember = "Id";
                comboBoxBranch.DisplayMember = "Branch";
            }

            GetTax();
        }

        public void GetTax()
        {
            Controllers.TrnReceivingReceiptItemController trnReceivingReceiptItemController = new Controllers.TrnReceivingReceiptItemController();
            if (trnReceivingReceiptItemController.DropdownListReceivingReceiptTax().Any())
            {
                comboBoxTax.DataSource = trnReceivingReceiptItemController.DropdownListReceivingReceiptTax();
                comboBoxTax.ValueMember = "Id";
                comboBoxTax.DisplayMember = "Tax";
            }

            GetReceivingReceiptItemItemDetail();
        }

        public void GetReceivingReceiptItemItemDetail()
        {
            textBoxQuantity.Text = trnReceivingReceiptItemEntity.Quantity.ToString("#,##0.00");
            textBoxReceivingReceiptItemItemDescription.Text = trnReceivingReceiptItemEntity.ItemDescription;
            comboBoxUnit.SelectedValue = trnReceivingReceiptItemEntity.UnitId;
            comboBoxBranch.SelectedValue = trnReceivingReceiptItemEntity.BranchId;
            textBoxCost.Text = trnReceivingReceiptItemEntity.Cost.ToString("#,##0.00");
            textBoxAmount.Text = trnReceivingReceiptItemEntity.Amount.ToString("#,##0.00");
            comboBoxTax.SelectedValue = trnReceivingReceiptItemEntity.TaxId;
            textBoxTaxRate.Text = trnReceivingReceiptItemEntity.TaxRate.ToString("#,##0.00");
            textBoxTaxAmount.Text = trnReceivingReceiptItemEntity.TaxAmount.ToString("#,##0.00");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveReceivingReceiptItem();
        }

        public void SaveReceivingReceiptItem()
        {
            var id = trnReceivingReceiptItemEntity.Id;
            var RRId = trnReceivingReceiptItemEntity.RRId;
            var POId = trnReceivingReceiptItemEntity.POId;
            var itemId = trnReceivingReceiptItemEntity.ItemId;
            var unitId = Convert.ToInt32(comboBoxUnit.SelectedValue);
            var branchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
            var cost = Convert.ToDecimal(textBoxCost.Text);
            var quantity = Convert.ToDecimal(textBoxQuantity.Text);
            var amount = Convert.ToDecimal(textBoxAmount.Text);
            var taxId = Convert.ToInt32(comboBoxTax.SelectedValue);
            var taxRate = Convert.ToDecimal(textBoxTaxRate.Text);
            var taxAmount = Convert.ToDecimal(textBoxTaxAmount.Text);

            Entities.TrnReceivingReceiptItemEntity newReceivingReceiptItemEntity = new Entities.TrnReceivingReceiptItemEntity()
            {
                Id = id,
                RRId = RRId,
                POId = POId,
                ItemId = itemId,
                UnitId = unitId,
                BranchId = branchId,
                Cost = cost,
                Quantity = quantity,
                Amount = amount,
                TaxId = taxId,
                TaxRate = taxRate,
                TaxAmount = taxAmount,
                BaseCost = 0,
                BaseQuantity = 0,
            };

            Controllers.TrnReceivingReceiptItemController trnPOSReceivingReceiptItemController = new Controllers.TrnReceivingReceiptItemController();
            if (newReceivingReceiptItemEntity.Id == 0)
            {
                String[] addReceivingReceiptItem = trnPOSReceivingReceiptItemController.AddReceivingReceiptItem(newReceivingReceiptItemEntity);
                if (addReceivingReceiptItem[1].Equals("0") == false)
                {
                    trnReceivingReceiptDetailForm.UpdateReceivingReceiptItemDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(addReceivingReceiptItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                String[] updateReceivingReceiptItem = trnPOSReceivingReceiptItemController.UpdateReceivingReceiptItem(trnReceivingReceiptItemEntity.Id, newReceivingReceiptItemEntity);
                if (updateReceivingReceiptItem[1].Equals("0") == false)
                {
                    trnReceivingReceiptDetailForm.UpdateReceivingReceiptItemDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(updateReceivingReceiptItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void ComputeAmount()
        {
            try
            {
                if (String.IsNullOrEmpty(textBoxQuantity.Text) == false &&
                    String.IsNullOrEmpty(textBoxCost.Text) == false &&
                    String.IsNullOrEmpty(textBoxAmount.Text) == false &&
                    String.IsNullOrEmpty(textBoxTaxRate.Text) == false &&
                    String.IsNullOrEmpty(textBoxTaxAmount.Text) == false)
                {
                    Decimal quantity = Convert.ToDecimal(textBoxQuantity.Text);
                    Decimal cost = Convert.ToDecimal(textBoxCost.Text);
                    Decimal amount = quantity * cost;

                    textBoxAmount.Text = amount.ToString("#,##0.00");

                    Decimal taxRate = Convert.ToDecimal(textBoxTaxRate.Text);
                    Decimal taxAmount = 0;

                    if (taxRate > 0)
                    {
                        taxAmount = (amount / (1 + (taxRate / 100))) * (taxRate / 100);
                    }

                    textBoxTaxAmount.Text = taxAmount.ToString("#,##0.00");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DefaultZeroEmptyString()
        {
            if (String.IsNullOrEmpty(textBoxQuantity.Text))
            {
                textBoxQuantity.Text = Convert.ToDecimal(0).ToString("#,##0.00###");
            }

            if (String.IsNullOrEmpty(textBoxCost.Text))
            {
                textBoxCost.Text = Convert.ToDecimal(0).ToString("#,##0.00###");
            }

            if (String.IsNullOrEmpty(textBoxAmount.Text))
            {
                textBoxAmount.Text = Convert.ToDecimal(0).ToString("#,##0.00###");
            }

            if (String.IsNullOrEmpty(textBoxTaxRate.Text))
            {
                textBoxTaxRate.Text = Convert.ToDecimal(0).ToString("#,##0.00###");
            }

            if (String.IsNullOrEmpty(textBoxTaxAmount.Text))
            {
                textBoxTaxAmount.Text = Convert.ToDecimal(0).ToString("#,##0.00###");
            }
        }

        private void receivingReceiptTextBox_Leave(object sender, EventArgs e)
        {
            DefaultZeroEmptyString();
            ComputeAmount();
        }

        private void receivingReceiptTextBox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void comboBoxTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTax.SelectedItem == null)
            {
                return;
            }

            var selectedItem = (Entities.MstTaxEntity)comboBoxTax.SelectedItem;
            if (selectedItem != null)
            {
                textBoxTaxRate.Text = selectedItem.Rate.ToString("#,##0.00");
                ComputeAmount();
            }
        }
    }
}
