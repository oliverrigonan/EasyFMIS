﻿using PagedList;
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
    public partial class TrnSalesOrderDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        TrnSalesOrderForm trnSalesOrderForm;
        public Entities.TrnSalesOrderEntity trnSalesOrderEntity;

        public static List<Entities.DgvTrnSalesOrderItemEntity> salesOrderItemData = new List<Entities.DgvTrnSalesOrderItemEntity>();
        public static Int32 salesOrdertemPageNumber = 1;
        public static Int32 stockOutItemPageSize = 50;
        public PagedList<Entities.DgvTrnSalesOrderItemEntity> salesOrderItemPageSize = new PagedList<Entities.DgvTrnSalesOrderItemEntity>(salesOrderItemData, salesOrdertemPageNumber, stockOutItemPageSize);
        public BindingSource salesOrderItemDataSource = new BindingSource();

        public TrnSalesOrderDetailForm(SysSoftwareForm softwareForm, TrnSalesOrderForm salesOrderForm, Entities.TrnSalesOrderEntity salesOrderEntity)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            trnSalesOrderForm = salesOrderForm;
            trnSalesOrderEntity = salesOrderEntity;

            GetCustomerList();
        }

        public void GetCustomerList()
        {
            Controllers.TrnSalesOrderController trnSalesOrderController = new Controllers.TrnSalesOrderController();
            var customer = trnSalesOrderController.DropdownListSalesOrderCustomer();
            if (customer.Any())
            {
                comboBoxCustomer.DataSource = customer;
                comboBoxCustomer.ValueMember = "Id";
                comboBoxCustomer.DisplayMember = "Article";

                GetTermList();
            }
        }

        public void GetTermList()
        {
            Controllers.TrnSalesOrderController trnSalesOrderController = new Controllers.TrnSalesOrderController();
            var term = trnSalesOrderController.DropdownListSalesOrderTerm();
            if (term.Any())
            {
                comboBoxTerm.DataSource = term;
                comboBoxTerm.ValueMember = "Id";
                comboBoxTerm.DisplayMember = "Term";

                GetUserList();
            }
        }

        public void GetUserList()
        {
            Controllers.TrnSalesOrderController trnSalesOrderController = new Controllers.TrnSalesOrderController();
            var user = trnSalesOrderController.DropdownListSalesOrderUser();
            if (user.Any())
            {
                comboBoxPreparedBy.DataSource = user;
                comboBoxPreparedBy.ValueMember = "Id";
                comboBoxPreparedBy.DisplayMember = "FullName";

                comboBoxCheckedBy.DataSource = user;
                comboBoxCheckedBy.ValueMember = "Id";
                comboBoxCheckedBy.DisplayMember = "FullName";

                comboBoxApprovedBy.DataSource = user;
                comboBoxApprovedBy.ValueMember = "Id";
                comboBoxApprovedBy.DisplayMember = "FullName";

                GetSalesOrderDetail();
            }
        }

        public void GetSalesOrderDetail()
        {
            UpdateComponents(trnSalesOrderEntity.IsLocked);

            textBoxBranch.Text = trnSalesOrderEntity.Branch;
            textBoxSONumber.Text = trnSalesOrderEntity.SONumber;
            dateTimePickerSODate.Value = trnSalesOrderEntity.SODate;
            textBoxManualSONumber.Text = trnSalesOrderEntity.ManualSONumber;
            comboBoxCustomer.SelectedValue = trnSalesOrderEntity.CustomerId;
            comboBoxTerm.SelectedValue = trnSalesOrderEntity.TermId;
            textBoxRemarks.Text = trnSalesOrderEntity.Remarks;
            comboBoxPreparedBy.SelectedValue = trnSalesOrderEntity.PreparedBy;
            comboBoxCheckedBy.SelectedValue = trnSalesOrderEntity.CheckedBy;
            comboBoxApprovedBy.SelectedValue = trnSalesOrderEntity.ApprovedBy;

            CreateSalesOrderItemDataGridView();
        }

        public void UpdateComponents(Boolean isLocked)
        {
            buttonLock.Enabled = !isLocked;
            buttonUnlock.Enabled = isLocked;
            buttonPrint.Enabled = !isLocked;

            buttonSearchItem.Enabled = !isLocked;

            textBoxBranch.Enabled = !isLocked;
            textBoxSONumber.Enabled = !isLocked;
            dateTimePickerSODate.Enabled = !isLocked;
            textBoxManualSONumber.Enabled = !isLocked;
            comboBoxCustomer.Enabled = !isLocked;
            comboBoxTerm.Enabled = !isLocked;
            textBoxRemarks.Enabled = !isLocked;
            comboBoxCheckedBy.Enabled = !isLocked;
            comboBoxApprovedBy.Enabled = !isLocked;

            dataGridViewSalesOrderItem.Columns[0].Visible = !isLocked;
            dataGridViewSalesOrderItem.Columns[1].Visible = !isLocked;
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            Controllers.TrnSalesOrderController trnSalesOrderController = new Controllers.TrnSalesOrderController();

            trnSalesOrderEntity.SODate = dateTimePickerSODate.Value;
            trnSalesOrderEntity.ManualSONumber = textBoxManualSONumber.Text;
            trnSalesOrderEntity.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue);
            trnSalesOrderEntity.TermId = Convert.ToInt32(comboBoxTerm.SelectedValue);
            trnSalesOrderEntity.Remarks = textBoxRemarks.Text;
            trnSalesOrderEntity.CheckedBy = Convert.ToInt32(comboBoxCheckedBy.SelectedValue);
            trnSalesOrderEntity.ApprovedBy = Convert.ToInt32(comboBoxApprovedBy.SelectedValue);

            String[] lockSalesOrder = trnSalesOrderController.LockSalesOrder(trnSalesOrderEntity.Id, trnSalesOrderEntity);
            if (lockSalesOrder[1].Equals("0") == false)
            {
                UpdateComponents(true);
                trnSalesOrderForm.UpdateSalesOrderDataSource();
                //UpdateInventoryEntriesDataSource();
            }
            else
            {
                MessageBox.Show(lockSalesOrder[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            Controllers.TrnSalesOrderController trnSalesOrderController = new Controllers.TrnSalesOrderController();

            String[] unlockSalesOrder = trnSalesOrderController.UnlockSalesOrder(trnSalesOrderEntity.Id);
            if (unlockSalesOrder[1].Equals("0") == false)
            {
                UpdateComponents(false);
                trnSalesOrderForm.UpdateSalesOrderDataSource();

                //UpdateInventoryEntriesDataSource();
            }
            else
            {
                MessageBox.Show(unlockSalesOrder[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
            sysSoftwareForm.RemoveTabPage();
        }

        public void UpdateStockOutItemDataSource()
        {
            SetStockOutItemDataSourceAsync();
        }

        public async void SetStockOutItemDataSourceAsync()
        {
            List<Entities.DgvTrnSalesOrderItemEntity> getStockOutItemData = await GetSalesOrderItemDataTask();
            if (getStockOutItemData.Any())
            {
                salesOrderItemData = getStockOutItemData;
                salesOrderItemPageSize = new PagedList<Entities.DgvTrnSalesOrderItemEntity>(salesOrderItemData, salesOrdertemPageNumber, stockOutItemPageSize);

                if (salesOrderItemPageSize.PageCount == 1)
                {
                    buttonSalesOrderItemPageListFirst.Enabled = false;
                    buttonSalesOrderItemPageListPrevious.Enabled = false;
                    buttonSalesOrderItemPageListNext.Enabled = false;
                    buttonSalesOrderItemPageListLast.Enabled = false;
                }
                else if (salesOrdertemPageNumber == 1)
                {
                    buttonSalesOrderItemPageListFirst.Enabled = false;
                    buttonSalesOrderItemPageListPrevious.Enabled = false;
                    buttonSalesOrderItemPageListNext.Enabled = true;
                    buttonSalesOrderItemPageListLast.Enabled = true;
                }
                else if (salesOrdertemPageNumber == salesOrderItemPageSize.PageCount)
                {
                    buttonSalesOrderItemPageListFirst.Enabled = true;
                    buttonSalesOrderItemPageListPrevious.Enabled = true;
                    buttonSalesOrderItemPageListNext.Enabled = false;
                    buttonSalesOrderItemPageListLast.Enabled = false;
                }
                else
                {
                    buttonSalesOrderItemPageListFirst.Enabled = true;
                    buttonSalesOrderItemPageListPrevious.Enabled = true;
                    buttonSalesOrderItemPageListNext.Enabled = true;
                    buttonSalesOrderItemPageListLast.Enabled = true;
                }

                textBoxSalesOrderItemPageNumber.Text = salesOrdertemPageNumber + " / " + salesOrderItemPageSize.PageCount;
                salesOrderItemDataSource.DataSource = salesOrderItemPageSize;
            }
            else
            {
                buttonSalesOrderItemPageListFirst.Enabled = false;
                buttonSalesOrderItemPageListPrevious.Enabled = false;
                buttonSalesOrderItemPageListNext.Enabled = false;
                buttonSalesOrderItemPageListLast.Enabled = false;

                salesOrdertemPageNumber = 1;

                salesOrderItemData = new List<Entities.DgvTrnSalesOrderItemEntity>();
                salesOrderItemDataSource.Clear();
                textBoxSalesOrderItemPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvTrnSalesOrderItemEntity>> GetSalesOrderItemDataTask()
        {
            Controllers.TrnSalesOrderItemController trnSalesOrderItemController = new Controllers.TrnSalesOrderItemController();

            List<Entities.TrnSalesOrderItemEntity> listSalesOrderItem = trnSalesOrderItemController.ListSalesOrderItem(trnSalesOrderEntity.Id);
            if (listSalesOrderItem.Any())
            {
                var items = from d in listSalesOrderItem
                            select new Entities.DgvTrnSalesOrderItemEntity
                            {
                                ColumnTrnSalesOrderItemListButtonEdit = "Edit",
                                ColumnTrnSalesOrderItemListButtonDelete = "Delete",
                                ColumnTrnSalesOrderItemListId = d.Id,
                                ColumnTrnSalesOrderItemListSOId = d.SOId,
                                ColumnTrnSalesOrderItemListItemId = d.ItemId,
                                ColumnTrnSalesOrderItemListItemDescription = d.ItemDescription,
                                ColumnTrnSalesOrderItemListItemInventoryId = d.ItemInventoryId,
                                ColumnTrnSalesOrderItemListItemInventoryCode = d.ItemInventoryCode,
                                ColumnTrnSalesOrderItemListUnitId = d.UnitId,
                                ColumnTrnSalesOrderItemListUnit = d.Unit,
                                ColumnTrnSalesOrderItemListPrice = d.Price.ToString("#,##0.00"),
                                ColumnTrnSalesOrderItemListDiscount = d.Discount,
                                ColumnTrnSalesOrderItemListDiscountId = d.DiscountId,
                                ColumnTrnSalesOrderItemListDiscountRate = d.DiscountRate.ToString("#,##0.00"),
                                ColumnTrnSalesOrderItemListDiscountAmount = d.DiscountAmount.ToString("#,##0.00"),
                                ColumnTrnSalesOrderItemListNetPrice = d.NetPrice.ToString("#,##0.00"),
                                ColumnTrnSalesOrderItemListQuantity = d.Quantity.ToString("#,##0.00"),
                                ColumnTrnSalesOrderItemListAmount = d.Amount.ToString("#,##0.00"),
                                ColumnTrnSalesOrderItemListTaxId = d.TaxId,
                                ColumnTrnSalesOrderItemListTax = d.Tax,
                                ColumnTrnSalesOrderItemListTaxRate = d.TaxRate.ToString("#,##0.00"),
                                ColumnTrnSalesOrderItemListTaxAmount = d.TaxAmount.ToString("#,##0.00"),
                                ColumnTrnSalesOrderItemListBaseQuantity = d.BaseQuantity.ToString("#,##0.00"),
                                ColumnTrnSalesOrderItemListBasePrice = d.BasePrice.ToString("#,##0.00")
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvTrnSalesOrderItemEntity>());
            }
        }

        public void CreateSalesOrderItemDataGridView()
        {
            UpdateStockOutItemDataSource();

            dataGridViewSalesOrderItem.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSalesOrderItem.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSalesOrderItem.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewSalesOrderItem.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewSalesOrderItem.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewSalesOrderItem.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewSalesOrderItem.DataSource = salesOrderItemDataSource;
        }

        public void GetStockOutItemCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewStockOutItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetStockOutItemCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewSalesOrderItem.CurrentCell.ColumnIndex == dataGridViewSalesOrderItem.Columns["ColumnStockOutItemButtonEdit"].Index)
            {
                //var id = Convert.ToInt32(dataGridViewStockOutItem.Rows[e.RowIndex].Cells[dataGridViewStockOutItem.Columns["ColumnStockOutItemId"].Index].Value);
                //var OTId = Convert.ToInt32(dataGridViewStockOutItem.Rows[e.RowIndex].Cells[dataGridViewStockOutItem.Columns["ColumnStockOutItemOTId"].Index].Value);
                //var itemId = Convert.ToInt32(dataGridViewStockOutItem.Rows[e.RowIndex].Cells[dataGridViewStockOutItem.Columns["ColumnStockOutItemItemId"].Index].Value);
                //var itemDescription = dataGridViewStockOutItem.Rows[e.RowIndex].Cells[dataGridViewStockOutItem.Columns["ColumnStockOutItemItemDescription"].Index].Value.ToString();
                //var unitId = Convert.ToInt32(dataGridViewStockOutItem.Rows[e.RowIndex].Cells[dataGridViewStockOutItem.Columns["ColumnStockOutItemUnitId"].Index].Value);
                //var unit = dataGridViewStockOutItem.Rows[e.RowIndex].Cells[dataGridViewStockOutItem.Columns["ColumnStockOutItemUnit"].Index].Value.ToString();
                //var itemInventoryId = Convert.ToInt32(dataGridViewStockOutItem.Rows[e.RowIndex].Cells[dataGridViewStockOutItem.Columns["ColumnStockOutItemInventoryId"].Index].Value);
                //var itemInventoryCode = dataGridViewStockOutItem.Rows[e.RowIndex].Cells[dataGridViewStockOutItem.Columns["ColumnStockOutItemInventoryCode"].Index].Value.ToString();
                //var quantity = Convert.ToDecimal(dataGridViewStockOutItem.Rows[e.RowIndex].Cells[dataGridViewStockOutItem.Columns["ColumnStockOutItemQuantity"].Index].Value);
                //var cost = Convert.ToDecimal(dataGridViewStockOutItem.Rows[e.RowIndex].Cells[dataGridViewStockOutItem.Columns["ColumnStockOutItemCost"].Index].Value);
                //var amount = Convert.ToDecimal(dataGridViewStockOutItem.Rows[e.RowIndex].Cells[dataGridViewStockOutItem.Columns["ColumnStockOutItemAmount"].Index].Value);

                //Entities.TrnSalesOrderItemEntity trnStockOutItemEntity = new Entities.TrnSalesOrderItemEntity()
                //{
                //    Id = id,
                //    OTId = OTId,
                //    ItemId = itemId,
                //    ItemDescription = itemDescription,
                //    UnitId = unitId,
                //    Unit = unit,
                //    ItemInventoryId = itemInventoryId,
                //    ItemInventoryCode = itemInventoryCode,
                //    Quantity = quantity,
                //    Cost = cost,
                //    Amount = amount
                //};

                //TrnStockOutDetailStockOutItemDetailForm trnStockOutDetailStockOutItemDetailForm = new TrnStockOutDetailStockOutItemDetailForm(this, trnStockOutItemEntity);
                //trnStockOutDetailStockOutItemDetailForm.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewSalesOrderItem.CurrentCell.ColumnIndex == dataGridViewSalesOrderItem.Columns["ColumnStockOutItemButtonDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete Stock-In?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(dataGridViewSalesOrderItem.Rows[e.RowIndex].Cells[dataGridViewSalesOrderItem.Columns["ColumnStockOutItemId"].Index].Value);

                    Controllers.TrnStockOutItemController trnStockOutItemController = new Controllers.TrnStockOutItemController();
                    String[] deleteStockOutItem = trnStockOutItemController.DeleteStockOutItem(id);
                    if (deleteStockOutItem[1].Equals("0") == false)
                    {
                        salesOrdertemPageNumber = 1;
                        UpdateStockOutItemDataSource();
                    }
                    else
                    {
                        MessageBox.Show(deleteStockOutItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonStockOutItemPageListFirst_Click(object sender, EventArgs e)
        {
            salesOrderItemPageSize = new PagedList<Entities.DgvTrnSalesOrderItemEntity>(salesOrderItemData, 1, stockOutItemPageSize);
            salesOrderItemDataSource.DataSource = salesOrderItemPageSize;

            buttonSalesOrderItemPageListFirst.Enabled = false;
            buttonSalesOrderItemPageListPrevious.Enabled = false;
            buttonSalesOrderItemPageListNext.Enabled = true;
            buttonSalesOrderItemPageListLast.Enabled = true;

            salesOrdertemPageNumber = 1;
            textBoxSalesOrderItemPageNumber.Text = salesOrdertemPageNumber + " / " + salesOrderItemPageSize.PageCount;
        }

        private void buttonStockOutItemPageListPrevious_Click(object sender, EventArgs e)
        {
            if (salesOrderItemPageSize.HasPreviousPage == true)
            {
                salesOrderItemPageSize = new PagedList<Entities.DgvTrnSalesOrderItemEntity>(salesOrderItemData, --salesOrdertemPageNumber, stockOutItemPageSize);
                salesOrderItemDataSource.DataSource = salesOrderItemPageSize;
            }

            buttonSalesOrderItemPageListNext.Enabled = true;
            buttonSalesOrderItemPageListLast.Enabled = true;

            if (salesOrdertemPageNumber == 1)
            {
                buttonSalesOrderItemPageListFirst.Enabled = false;
                buttonSalesOrderItemPageListPrevious.Enabled = false;
            }

            textBoxSalesOrderItemPageNumber.Text = salesOrdertemPageNumber + " / " + salesOrderItemPageSize.PageCount;
        }

        private void buttonStockOutItemPageListNext_Click(object sender, EventArgs e)
        {
            if (salesOrderItemPageSize.HasNextPage == true)
            {
                salesOrderItemPageSize = new PagedList<Entities.DgvTrnSalesOrderItemEntity>(salesOrderItemData, ++salesOrdertemPageNumber, stockOutItemPageSize);
                salesOrderItemDataSource.DataSource = salesOrderItemPageSize;
            }

            buttonSalesOrderItemPageListFirst.Enabled = true;
            buttonSalesOrderItemPageListPrevious.Enabled = true;

            if (salesOrdertemPageNumber == salesOrderItemPageSize.PageCount)
            {
                buttonSalesOrderItemPageListNext.Enabled = false;
                buttonSalesOrderItemPageListLast.Enabled = false;
            }

            textBoxSalesOrderItemPageNumber.Text = salesOrdertemPageNumber + " / " + salesOrderItemPageSize.PageCount;
        }

        private void buttonStockOutItemPageListLast_Click(object sender, EventArgs e)
        {
            salesOrderItemPageSize = new PagedList<Entities.DgvTrnSalesOrderItemEntity>(salesOrderItemData, salesOrderItemPageSize.PageCount, stockOutItemPageSize);
            salesOrderItemDataSource.DataSource = salesOrderItemPageSize;

            buttonSalesOrderItemPageListFirst.Enabled = true;
            buttonSalesOrderItemPageListPrevious.Enabled = true;
            buttonSalesOrderItemPageListNext.Enabled = false;
            buttonSalesOrderItemPageListLast.Enabled = false;

            salesOrdertemPageNumber = salesOrderItemPageSize.PageCount;
            textBoxSalesOrderItemPageNumber.Text = salesOrdertemPageNumber + " / " + salesOrderItemPageSize.PageCount;
        }

        private void buttonSearchItem_Click(object sender, EventArgs e)
        {
            TrnSalesOrderDetailSearchItemForm trnStockOutDetailSearchItemForm = new TrnSalesOrderDetailSearchItemForm(this, trnSalesOrderEntity);
            trnStockOutDetailSearchItemForm.ShowDialog();
        }

    }
}