using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software.TrnSalesOrder
{
    public partial class TrnSalesOrderDetailSalesOrderItemDetailForm : Form
    {
        public TrnSalesOrderDetailForm trnSalesOrderDetailForm;
        public Entities.TrnSalesOrderItemEntity trnSalesOrderItemEntity;

        public TrnSalesOrderDetailSalesOrderItemDetailForm(TrnSalesOrderDetailForm salesOrderDetailForm, Entities.TrnSalesOrderItemEntity salesOrderItemEntity)
        {
            InitializeComponent();

            trnSalesOrderDetailForm = salesOrderDetailForm;
            trnSalesOrderItemEntity = salesOrderItemEntity;

            GetUnitList();

            textBoxQuantity.Focus();
            textBoxQuantity.SelectAll();
        }

        public void GetUnitList()
        {
            Controllers.TrnSalesOrderItemController trnSalesOrderItemController = new Controllers.TrnSalesOrderItemController();
            var unit = trnSalesOrderItemController.DropdownListArticleUnit(trnSalesOrderItemEntity.ItemId);
            if (unit.Any())
            {
                comboBoxUnit.DataSource = unit;
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
                        Id = trnSalesOrderItemEntity.UnitId,
                        Unit = trnSalesOrderItemEntity.Unit
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
            if (trnSalesOrderItemEntity.ItemInventoryId != null)
            {
                Controllers.TrnSalesOrderItemController trnSalesOrderItemController = new Controllers.TrnSalesOrderItemController();
                var inventoryCode = trnSalesOrderItemController.DropdownListArticleInventory(trnSalesOrderItemEntity.ItemId);
                if (inventoryCode.Any())
                {
                    comboBoxInventoryCode.DataSource = inventoryCode;
                    comboBoxInventoryCode.ValueMember = "Id";
                    comboBoxInventoryCode.DisplayMember = "InventoryCode";
                    GetDiscountList();

                }
            }
            else
            {
                comboBoxInventoryCode.Enabled = false;
                GetDiscountList();
            }

        }

        public void GetDiscountList()
        {
            Controllers.TrnSalesOrderItemController trnSalesOrderItemController = new Controllers.TrnSalesOrderItemController();
            var discount = trnSalesOrderItemController.DropdownListDiscount();
            if (discount.Any())
            {
                comboBoxDiscount.DataSource = discount;
                comboBoxDiscount.ValueMember = "Id";
                comboBoxDiscount.DisplayMember = "Discount";

                GetTaxList();
            }
            else
            {
                List<Entities.MstDiscountEntity> tax = new List<Entities.MstDiscountEntity>
                {
                    new Entities.MstDiscountEntity()
                    {
                        Id = trnSalesOrderItemEntity.DiscountId,
                        Discount = trnSalesOrderItemEntity.Discount
                    }
                };

                comboBoxDiscount.DataSource = tax;
                comboBoxDiscount.ValueMember = "Id";
                comboBoxDiscount.DisplayMember = "Discount";

                GetTaxList();
            }
        }

        public void GetTaxList()
        {
            Controllers.TrnSalesOrderItemController trnSalesOrderItemController = new Controllers.TrnSalesOrderItemController();
            var taxes = trnSalesOrderItemController.DropdownListTax();
            if (taxes.Any())
            {
                comboBoxTax.DataSource = taxes;
                comboBoxTax.ValueMember = "Id";
                comboBoxTax.DisplayMember = "Tax";

                GetSalesOrderItemItemDetail();
            }
            else
            {
                List<Entities.MstTaxEntity> tax = new List<Entities.MstTaxEntity>
                {
                    new Entities.MstTaxEntity()
                    {
                        Id = trnSalesOrderItemEntity.TaxId,
                        Tax = trnSalesOrderItemEntity.Tax
                    }
                };

                comboBoxTax.DataSource = tax;
                comboBoxTax.ValueMember = "Id";
                comboBoxTax.DisplayMember = "Tax";

                GetInventoryCode();
            }

            GetSalesOrderItemItemDetail();
        }


        public void GetSalesOrderItemItemDetail()
        {
            textBoxQuantity.Text = trnSalesOrderItemEntity.Quantity.ToString("#,##0.00");
            comboBoxInventoryCode.SelectedValue = trnSalesOrderItemEntity.ItemInventoryId;
            comboBoxUnit.SelectedValue = trnSalesOrderItemEntity.UnitId;
            textBoxDiscountRate.Text = trnSalesOrderItemEntity.DiscountRate.ToString("#,##0.00");
            textBoxDiscountAmount.Text = trnSalesOrderItemEntity.DiscountRate.ToString("#,##0.00");
            textBoxNetPrice.Text = trnSalesOrderItemEntity.DiscountRate.ToString("#,##0.00");
            textBoxAmount.Text = trnSalesOrderItemEntity.DiscountRate.ToString("#,##0.00");
            comboBoxTax.Text = trnSalesOrderItemEntity.DiscountRate.ToString("#,##0.00");
            textBoxTaxRate.Text = trnSalesOrderItemEntity.DiscountRate.ToString("#,##0.00");
            textBoxTaxAmount.Text = trnSalesOrderItemEntity.DiscountRate.ToString("#,##0.00");
            textBoxPrice.Text = trnSalesOrderItemEntity.Price.ToString("#,##0.00");

            ComputeAmount();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveSalesOrderItem();
        }

        public void SaveSalesOrderItem()
        {
            var id = trnSalesOrderItemEntity.Id;
            var sOId = trnSalesOrderItemEntity.SOId;
            var itemId = trnSalesOrderItemEntity.ItemId;
            var itemInventoryId = Convert.ToInt32(comboBoxInventoryCode.SelectedValue);
            var itemDescription = trnSalesOrderItemEntity.ItemDescription;
            var price = Convert.ToDecimal(textBoxPrice.Text);
            var unitId = Convert.ToInt32(comboBoxUnit.SelectedValue);
            var discountId = Convert.ToInt32(comboBoxDiscount.SelectedValue);
            var discountRate = Convert.ToDecimal(textBoxDiscountRate.Text);
            var discountAmount = Convert.ToDecimal(textBoxDiscountAmount.Text);
            var unit = trnSalesOrderItemEntity.Unit;
            var netPrice = Convert.ToDecimal(textBoxNetPrice.Text);
            var quantity = Convert.ToDecimal(textBoxQuantity.Text);
            var amount = Convert.ToDecimal(textBoxAmount.Text);
            var taxId = Convert.ToInt32(comboBoxTax.SelectedValue);
            var taxRate = Convert.ToDecimal(textBoxTaxRate.Text);
            var taxAmount = Convert.ToDecimal(textBoxTaxAmount.Text);

            Entities.TrnSalesOrderItemEntity salesOrderItemEntity = new Entities.TrnSalesOrderItemEntity()
            {
                Id = id,
                SOId = sOId,
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
                TaxAmount = taxAmount,
            };

            Controllers.TrnSalesOrderItemController trnSalesOrderItemController = new Controllers.TrnSalesOrderItemController();
            if (trnSalesOrderItemEntity.Id == 0)
            {
                String[] addSalesOrderItem = trnSalesOrderItemController.AddSalesOrderItem(salesOrderItemEntity);
                if (addSalesOrderItem[1].Equals("0") == false)
                {
                    trnSalesOrderDetailForm.UpdateSalesOrderItemDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(addSalesOrderItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                String[] updateSalesOrderItem = trnSalesOrderItemController.UpdateSalesOrderItem(trnSalesOrderItemEntity.Id, salesOrderItemEntity);
                if (updateSalesOrderItem[1].Equals("0") == false)
                {
                    trnSalesOrderDetailForm.UpdateSalesOrderItemDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(updateSalesOrderItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void UpdatePrice(Decimal price)
        {
            textBoxPrice.Text = price.ToString("#,##0.00");
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
                        taxAmount = amount * (taxRate / 100);
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
            if (String.IsNullOrEmpty(textBoxDiscountRate.Text))
            {
                textBoxQuantity.Text = "0.00";
            }

            if (String.IsNullOrEmpty(textBoxDiscountRate.Text))
            {
                textBoxDiscountRate.Text = "0.00";
            }

            if (String.IsNullOrEmpty(textBoxDiscountAmount.Text))
            {
                textBoxDiscountAmount.Text = "0.00";
            }
        }


        private void textBoxPrice_Click(object sender, EventArgs e)
        {
            TrnSalesOrderDetailSalesOrderItemDetailPriceForm trnSalesOrderDetailSalesOrderItemDetailPriceForm = new TrnSalesOrderDetailSalesOrderItemDetailPriceForm(this, trnSalesOrderItemEntity);
            trnSalesOrderDetailSalesOrderItemDetailPriceForm.ShowDialog();
        }


        private void comboBoxDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDiscount.SelectedItem == null)
            {
                return;
            }

            var selectedItemDiscount = (Entities.MstDiscountEntity)comboBoxDiscount.SelectedItem;
            if (selectedItemDiscount != null)
            {
                textBoxDiscountRate.Text = selectedItemDiscount.DiscountRate.ToString("#,##0.00");
                ComputeAmount();
            }
        }

        private void comboBoxTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTax.SelectedItem == null)
            {
                return;
            }

            var selectedItemTax = (Entities.MstTaxEntity)comboBoxTax.SelectedItem;
            if (selectedItemTax != null)
            {
                textBoxDiscountRate.Text = selectedItemTax.Rate.ToString("#,##0.00");
                ComputeAmount();
            }
        }

        private void textBoxItemQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxDiscountAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxDiscountRate_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxDiscountRate_Leave(object sender, EventArgs e)
        {
            DefaultZeroEmptyString();
            ComputeAmount();
        }

        private void textBoxDiscountAmount_Leave(object sender, EventArgs e)
        {
            DefaultZeroEmptyString();
            ComputeDiscountRate();
        }

        private void textBoxItemQuantity_Leave(object sender, EventArgs e)
        {
            DefaultZeroEmptyString();
            ComputeAmount();

        }

    }
}
