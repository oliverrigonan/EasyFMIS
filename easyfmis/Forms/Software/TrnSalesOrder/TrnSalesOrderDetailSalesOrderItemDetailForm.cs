﻿using System;
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
            ComputeNetPrice();
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
            var unit = trnSalesOrderItemEntity.Unit;
            var quantity = Convert.ToDecimal(textBoxQuantity.Text);
            var amount = Convert.ToDecimal(textBoxAmount.Text);

            //Entities.TrnSalesOrderItemEntity newSalesOrderItemEntity = new Entities.TrnSalesOrderItemEntity()
            //{
            //    SOId = sOId,
            //    ItemId = itemId,
            //    ItemInventoryId = itemInventoryId,
            //    UnitId = unitId,
            //    Price = price,
            //    DiscountId = discountId,
            //    DiscountRate = 
            //    DiscountAmount
            //    NetPrice
            //    Quantity
            //    Amount
            //    TaxId
            //    TaxRate
            //    TaxAmount

            //};

            //Controllers.TrnStockOutItemController trnPOSStockOutItemController = new Controllers.TrnStockOutItemController();
            //if (newStockOutItemEntity.Id == 0)
            //{
            //    String[] addStockOutItem = trnPOSStockOutItemController.AddStockOutItem(newStockOutItemEntity);
            //    if (addStockOutItem[1].Equals("0") == false)
            //    {
            //        //trnStockOutDetailForm.UpdateStockOutItemDataSource();
            //        Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show(addStockOutItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //else
            //{
            //    String[] updateStockOutItem = trnPOSStockOutItemController.UpdateStockOutItem(trnSalesOrderItemEntity.Id, newStockOutItemEntity);
            //    if (updateStockOutItem[1].Equals("0") == false)
            //    {
            //        //trnStockOutDetailForm.UpdateStockOutItemDataSource();
            //        Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show(updateStockOutItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        public void UpdatePrice(Decimal price)
        {
            textBoxPrice.Text = price.ToString("#,##0.00");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
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

        private void textBoxItemQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxItemQuantity_Leave(object sender, EventArgs e)
        {
            textBoxQuantity.Text = Convert.ToDecimal(textBoxQuantity.Text).ToString("#,##0.00");

            ComputeAmount();

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

                ComputeNetPrice();
            }
        }

        private void textBoxPrice_Click(object sender, EventArgs e)
        {
            TrnSalesOrderDetailSalesOrderItemDetailPriceForm trnSalesOrderDetailSalesOrderItemDetailPriceForm = new TrnSalesOrderDetailSalesOrderItemDetailPriceForm(this, trnSalesOrderItemEntity);
            trnSalesOrderDetailSalesOrderItemDetailPriceForm.ShowDialog();
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
            }
        }

        public void ComputeAmount()
        {
            try
            {
                if (String.IsNullOrEmpty(textBoxQuantity.Text) == false && String.IsNullOrEmpty(textBoxNetPrice.Text) == false)
                {
                    Decimal quantity = Convert.ToDecimal(textBoxQuantity.Text);
                    Decimal price = Convert.ToDecimal(textBoxNetPrice.Text);
                    Decimal amount = price * quantity;

                    textBoxAmount.Text = amount.ToString("#,##0.00");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ComputeNetPrice()
        {
            try
            {
                if (String.IsNullOrEmpty(textBoxPrice.Text) == false && String.IsNullOrEmpty(textBoxDiscountAmount.Text) == false)
                {
                    Decimal price = Convert.ToDecimal(textBoxPrice.Text);
                    Decimal discountAmount = Convert.ToDecimal(textBoxDiscountAmount.Text);
                    Decimal netPrice = price - discountAmount;

                    textBoxNetPrice.Text = netPrice.ToString("#,##0.00");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxDiscountAmount_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxDiscountAmount.Text))
            {
                textBoxQuantity.Text = "0.00";
            }

            ComputeDiscountRate();
        }

        public void ComputeDiscountRate()
        {
            try
            {
                if (String.IsNullOrEmpty(textBoxPrice.Text) == false && String.IsNullOrEmpty(textBoxDiscountAmount.Text) == false)
                {
                    Decimal price = Convert.ToDecimal(textBoxPrice.Text);
                    Decimal discountAmount = Convert.ToDecimal(textBoxDiscountAmount.Text);

                    Decimal discountRate = discountAmount / price;

                    Decimal netPrice = price - discountAmount;

                    textBoxDiscountRate.Text = discountRate.ToString("#,##0.00");
                    textBoxNetPrice.Text = netPrice.ToString("#,##0.00");

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxDiscountAmount_Leave(object sender, EventArgs e)
        {
            textBoxDiscountAmount.Text = Convert.ToDecimal(textBoxDiscountAmount.Text).ToString("#,##0.00");
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
    }
}