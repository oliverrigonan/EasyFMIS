using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software.TrnSalesInvoice
{
    public partial class TrnSalesInvoiceDetailSalesInvoiceItemDetailForm : Form
    {
        public TrnSalesInvoiceDetailForm trnSalesInvoiceDetailForm;
        public Entities.TrnSalesInvoiceItemEntity trnSalesInvoiceItemEntity;

        public TrnSalesInvoiceDetailSalesInvoiceItemDetailForm(TrnSalesInvoiceDetailForm salesInvoiceDetailForm, Entities.TrnSalesInvoiceItemEntity salesInvoiceLineEntity)
        {
            InitializeComponent();

            trnSalesInvoiceDetailForm = salesInvoiceDetailForm;
            trnSalesInvoiceItemEntity = salesInvoiceLineEntity;

            GetUnitList();

            textBoxQuantity.Focus();
            textBoxQuantity.SelectAll();
        }

        public void GetUnitList()
        {
            Controllers.TrnSalesInvoiceItemController trnSalesInvoiceItemController = new Controllers.TrnSalesInvoiceItemController();
            if (trnSalesInvoiceItemController.DropdownListArticleUnit(trnSalesInvoiceItemEntity.ItemId).Any())
            {
                comboBoxUnit.DataSource = trnSalesInvoiceItemController.DropdownListArticleUnit(trnSalesInvoiceItemEntity.ItemId);
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
                        Id = trnSalesInvoiceItemEntity.UnitId,
                        Unit = trnSalesInvoiceItemEntity.Unit
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
            Controllers.TrnSalesInvoiceItemController trnSalesInvoiceItemController = new Controllers.TrnSalesInvoiceItemController();
            if (trnSalesInvoiceItemController.DropdownListArticleInventory(trnSalesInvoiceItemEntity.ItemId).Any())
            {
                comboBoxInventoryCode.DataSource = trnSalesInvoiceItemController.DropdownListArticleInventory(trnSalesInvoiceItemEntity.ItemId);
                comboBoxInventoryCode.ValueMember = "Id";
                comboBoxInventoryCode.DisplayMember = "InventoryCode";
            }

            GetDiscount();
        }

        public void GetDiscount()
        {
            Controllers.TrnSalesInvoiceItemController trnSalesInvoiceItemController = new Controllers.TrnSalesInvoiceItemController();
            if (trnSalesInvoiceItemController.DropdownListSalesInvoiceDiscount().Any())
            {
                comboBoxDiscount.DataSource = trnSalesInvoiceItemController.DropdownListSalesInvoiceDiscount();
                comboBoxDiscount.ValueMember = "Id";
                comboBoxDiscount.DisplayMember = "Discount";
            }

            GetTax();
        }

        public void GetTax()
        {
            Controllers.TrnSalesInvoiceItemController trnSalesInvoiceItemController = new Controllers.TrnSalesInvoiceItemController();
            if (trnSalesInvoiceItemController.DropdownListSalesInvoiceTax().Any())
            {
                comboBoxTax.DataSource = trnSalesInvoiceItemController.DropdownListSalesInvoiceTax();
                comboBoxTax.ValueMember = "Id";
                comboBoxTax.DisplayMember = "Tax";
            }

            GetSalesInvoiceItemItemDetail();
        }

        public void GetSalesInvoiceItemItemDetail()
        {
            textBoxQuantity.Text = trnSalesInvoiceItemEntity.Quantity.ToString("#,##0.00");
            textBoxSalesInvoiceItemItemDescription.Text = trnSalesInvoiceItemEntity.ItemDescription;
            comboBoxInventoryCode.SelectedValue = trnSalesInvoiceItemEntity.ItemInventoryId;
            comboBoxUnit.SelectedValue = trnSalesInvoiceItemEntity.UnitId;
            textBoxPrice.Text = trnSalesInvoiceItemEntity.Price.ToString("#,##0.00");
            comboBoxDiscount.SelectedValue = trnSalesInvoiceItemEntity.DiscountId;
            textBoxDiscountRate.Text = trnSalesInvoiceItemEntity.DiscountRate.ToString("#,##0.00");
            textBoxDiscountAmount.Text = trnSalesInvoiceItemEntity.DiscountAmount.ToString("#,##0.00");
            textBoxNetPrice.Text = trnSalesInvoiceItemEntity.NetPrice.ToString("#,##0.00");
            textBoxAmount.Text = trnSalesInvoiceItemEntity.Amount.ToString("#,##0.00");
            comboBoxTax.SelectedValue = trnSalesInvoiceItemEntity.TaxId;
            textBoxTaxRate.Text = trnSalesInvoiceItemEntity.TaxRate.ToString("#,##0.00");
            textBoxTaxAmount.Text = trnSalesInvoiceItemEntity.TaxAmount.ToString("#,##0.00");
        }

        public void ComputeAmount()
        {
            try
            {
                if (String.IsNullOrEmpty(textBoxQuantity.Text) == false && String.IsNullOrEmpty(textBoxNetPrice.Text) == false)
                {
                    Decimal quantity = Convert.ToDecimal(textBoxQuantity.Text);
                    Decimal cost = Convert.ToDecimal(textBoxNetPrice.Text);
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
            SaveSalesInvoiceItem();
        }

        public void SaveSalesInvoiceItem()
        {
            var id = trnSalesInvoiceItemEntity.Id;
            var SIId = trnSalesInvoiceItemEntity.SIId;
            var itemId = trnSalesInvoiceItemEntity.ItemId;
            var itemDescription = trnSalesInvoiceItemEntity.ItemDescription;
            var unitId = Convert.ToInt32(comboBoxUnit.SelectedValue);
            var unit = trnSalesInvoiceItemEntity.Unit;
            var itemInventoryId = Convert.ToInt32(comboBoxInventoryCode.SelectedValue);
            var quantity = Convert.ToDecimal(textBoxQuantity.Text);
            var cost = Convert.ToDecimal(textBoxNetPrice.Text);
            var amount = Convert.ToDecimal(textBoxAmount.Text);

            Entities.TrnSalesInvoiceItemEntity newSalesInvoiceItemEntity = new Entities.TrnSalesInvoiceItemEntity()
            {
                Id = id,
                SIId = SIId,
                ItemId = itemId,
                ItemDescription = itemDescription,
                UnitId = unitId,
                Unit = unit,
                ItemInventoryId = itemInventoryId,
                Quantity = quantity,
                Amount = amount
            };

            Controllers.TrnSalesInvoiceItemController trnPOSSalesInvoiceItemController = new Controllers.TrnSalesInvoiceItemController();
            if (newSalesInvoiceItemEntity.Id == 0)
            {
                String[] addSalesInvoiceItem = trnPOSSalesInvoiceItemController.AddSalesInvoiceItem(newSalesInvoiceItemEntity);
                if (addSalesInvoiceItem[1].Equals("0") == false)
                {
                    trnSalesInvoiceDetailForm.UpdateSalesInvoiceItemDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(addSalesInvoiceItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                String[] updateSalesInvoiceItem = trnPOSSalesInvoiceItemController.UpdateSalesInvoiceItem(trnSalesInvoiceItemEntity.Id, newSalesInvoiceItemEntity);
                if (updateSalesInvoiceItem[1].Equals("0") == false)
                {
                    trnSalesInvoiceDetailForm.UpdateSalesInvoiceItemDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(updateSalesInvoiceItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxSalesInvoiceItemQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxSalesInvoiceItemCost_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxSalesInvoiceItemPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxSalesInvoiceItemQuantity_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxQuantity.Text))
            {
                textBoxQuantity.Text = "0.00";
            }

            ComputeAmount();
        }

        private void textBoxSalesInvoiceItemCost_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxNetPrice.Text))
            {
                textBoxNetPrice.Text = "0.00";
            }

            ComputeAmount();
        }

        private void textBoxSalesInvoiceItemQuantity_Leave(object sender, EventArgs e)
        {
            textBoxQuantity.Text = Convert.ToDecimal(textBoxQuantity.Text).ToString("#,##0.00");
        }

        private void textBoxSalesInvoiceItemCost_Leave(object sender, EventArgs e)
        {
            textBoxNetPrice.Text = Convert.ToDecimal(textBoxNetPrice.Text).ToString("#,##0.00");
        }
    }
}
