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

            if (trnSalesInvoiceItemEntity.ItemInventoryId != null)
            {
                comboBoxInventoryCode.SelectedValue = trnSalesInvoiceItemEntity.ItemInventoryId;
            }

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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveSalesInvoiceItem();
        }

        public void SaveSalesInvoiceItem()
        {
            var id = trnSalesInvoiceItemEntity.Id;
            var SIId = trnSalesInvoiceItemEntity.SIId;
            var itemId = trnSalesInvoiceItemEntity.ItemId;
            var itemInventoryId = Convert.ToInt32(comboBoxInventoryCode.SelectedValue);
            var unitId = Convert.ToInt32(comboBoxUnit.SelectedValue);
            var price = Convert.ToDecimal(textBoxPrice.Text);
            var discountId = Convert.ToInt32(comboBoxDiscount.SelectedValue);
            var discountRate = Convert.ToDecimal(textBoxDiscountRate.Text);
            var discountAmount = Convert.ToDecimal(textBoxDiscountAmount.Text);
            var netPrice = Convert.ToDecimal(textBoxNetPrice.Text);
            var quantity = Convert.ToDecimal(textBoxQuantity.Text);
            var amount = Convert.ToDecimal(textBoxAmount.Text);
            var taxId = Convert.ToInt32(comboBoxTax.SelectedValue);
            var taxRate = Convert.ToDecimal(textBoxTaxRate.Text);
            var taxAmount = Convert.ToDecimal(textBoxTaxAmount.Text);

            Entities.TrnSalesInvoiceItemEntity newSalesInvoiceItemEntity = new Entities.TrnSalesInvoiceItemEntity()
            {
                Id = id,
                SIId = SIId,
                ItemId = itemId,
                ItemInventoryId = itemInventoryId,
                UnitId = unitId,
                Price = price,
                DiscountId = discountId,
                DiscountRate = discountRate,
                DiscountAmount = discountAmount,
                NetPrice = netPrice,
                Quantity = quantity,
                Amount = amount,
                TaxId = taxId,
                TaxRate = taxRate,
                TaxAmount = taxAmount
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

        public void ComputeAmount()
        {
            try
            {
                if (String.IsNullOrEmpty(textBoxQuantity.Text) == false &&
                    String.IsNullOrEmpty(textBoxPrice.Text) == false &&
                    String.IsNullOrEmpty(textBoxDiscountRate.Text) == false &&
                    String.IsNullOrEmpty(textBoxDiscountAmount.Text) == false &&
                    String.IsNullOrEmpty(textBoxNetPrice.Text) == false &&
                    String.IsNullOrEmpty(textBoxAmount.Text) == false &&
                    String.IsNullOrEmpty(textBoxTaxRate.Text) == false &&
                    String.IsNullOrEmpty(textBoxTaxAmount.Text) == false)
                {
                    Decimal quantity = Convert.ToDecimal(textBoxQuantity.Text);
                    Decimal price = Convert.ToDecimal(textBoxPrice.Text);

                    Decimal discountRate = Convert.ToDecimal(textBoxDiscountRate.Text);
                    Decimal discountAmount = 0;

                    if (discountRate > 0)
                    {
                        discountAmount = price * (discountRate / 100);
                    }

                    textBoxDiscountAmount.Text = discountAmount.ToString("#,##0.00");

                    Decimal netPrice = price;
                    if (discountAmount > 0)
                    {
                        netPrice = price - discountAmount;
                    }

                    textBoxNetPrice.Text = netPrice.ToString("#,##0.00");

                    Decimal amount = quantity * netPrice;

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

        public void ComputeDiscountRate()
        {
            try
            {
                Decimal price = Convert.ToDecimal(textBoxPrice.Text);

                Decimal discountAmount = Convert.ToDecimal(textBoxDiscountAmount.Text);
                Decimal discountRate = 0;

                if (discountAmount > 0)
                {
                    discountRate = (discountAmount / price) * 100;
                }

                textBoxDiscountRate.Text = discountRate.ToString("#,##0.00###");

                ComputeAmount();
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

            if (String.IsNullOrEmpty(textBoxPrice.Text))
            {
                textBoxPrice.Text = Convert.ToDecimal(0).ToString("#,##0.00###");
            }

            if (String.IsNullOrEmpty(textBoxDiscountRate.Text))
            {
                textBoxDiscountRate.Text = Convert.ToDecimal(0).ToString("#,##0.00###");
            }

            if (String.IsNullOrEmpty(textBoxDiscountAmount.Text))
            {
                textBoxDiscountAmount.Text = Convert.ToDecimal(0).ToString("#,##0.00###");
            }

            if (String.IsNullOrEmpty(textBoxNetPrice.Text))
            {
                textBoxDiscountAmount.Text = Convert.ToDecimal(0).ToString("#,##0.00###");
            }

            if (String.IsNullOrEmpty(textBoxAmount.Text))
            {
                textBoxDiscountAmount.Text = Convert.ToDecimal(0).ToString("#,##0.00###");
            }

            if (String.IsNullOrEmpty(textBoxTaxRate.Text))
            {
                textBoxDiscountAmount.Text = Convert.ToDecimal(0).ToString("#,##0.00###");
            }

            if (String.IsNullOrEmpty(textBoxTaxAmount.Text))
            {
                textBoxDiscountAmount.Text = Convert.ToDecimal(0).ToString("#,##0.00###");
            }
        }

        private void salesInvoiceTextBox_Leave(object sender, EventArgs e)
        {
            DefaultZeroEmptyString();
            ComputeAmount();
        }

        private void salesInvoiceComputeDiscountRateTextBox_Leave(object sender, EventArgs e)
        {
            DefaultZeroEmptyString();
            ComputeDiscountRate();
        }

        private void salesInvoiceTextBox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void comboBoxDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDiscount.SelectedItem == null)
            {
                return;
            }

            var selectedItem = (Entities.MstDiscountEntity)comboBoxDiscount.SelectedItem;
            if (selectedItem != null)
            {
                textBoxDiscountRate.Text = selectedItem.DiscountRate.ToString("#,##0.00");
                ComputeAmount();
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

        private void textBoxPrice_Click(object sender, EventArgs e)
        {
            TrnSalesInvoiceDetailSalesInvoiceItemDetailPriceForm trnSalesInvoiceDetailSalesInvoiceItemDetailPriceForm = new TrnSalesInvoiceDetailSalesInvoiceItemDetailPriceForm(this, trnSalesInvoiceItemEntity);
            trnSalesInvoiceDetailSalesInvoiceItemDetailPriceForm.ShowDialog();
        }

        public void UpdatePrice(Decimal price)
        {
            textBoxPrice.Text = price.ToString("#,##0.00");
            ComputeAmount();
        }

        private void salesInvoiceTextBox_TextChanged(object sender, EventArgs e)
        {
            ComputeAmount();
        }
    }
}
