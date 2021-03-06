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

namespace easyfmis.Forms.Software.TrnStockIn
{
    public partial class TrnStockInDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        private Modules.SysUserRightsModule sysUserRights;

        public TrnStockInForm trnStockInForm;
        public Entities.TrnStockInEntity trnStockInEntity;

        public static List<Entities.DgvStockInItemEntity> stockInItemData = new List<Entities.DgvStockInItemEntity>();
        public static Int32 stockInItemPageNumber = 1;
        public static Int32 stockInItemPageSize = 50;
        public PagedList<Entities.DgvStockInItemEntity> stockInItemPageList = new PagedList<Entities.DgvStockInItemEntity>(stockInItemData, stockInItemPageNumber, stockInItemPageSize);
        public BindingSource stockInItemDataSource = new BindingSource();

        public static List<Entities.DgvTrnInventoryEntriesEntity> inventoryEntriesData = new List<Entities.DgvTrnInventoryEntriesEntity>();
        public static Int32 inventoryEntriesPageNumber = 1;
        public static Int32 inventoryEntriesPageSize = 50;
        public PagedList<Entities.DgvTrnInventoryEntriesEntity> inventoryEntriesPageList = new PagedList<Entities.DgvTrnInventoryEntriesEntity>(inventoryEntriesData, inventoryEntriesPageNumber, inventoryEntriesPageSize);
        public BindingSource inventoryEntriesDataSource = new BindingSource();

        public TrnStockInDetailForm(SysSoftwareForm softwareForm, TrnStockInForm stockInListForm, Entities.TrnStockInEntity stockInEntity)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            
            sysUserRights = new Modules.SysUserRightsModule("TrnStockInDetail");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                trnStockInForm = stockInListForm;
                trnStockInEntity = stockInEntity;

                GetUserList();
            }
        }

        public void GetUserList()
        {
            Controllers.TrnStockInController trnStockInController = new Controllers.TrnStockInController();
            if (trnStockInController.DropdownListStockInUser().Any())
            {
                comboBoxPreparedBy.DataSource = trnStockInController.DropdownListStockInUser();
                comboBoxPreparedBy.ValueMember = "Id";
                comboBoxPreparedBy.DisplayMember = "FullName";

                comboBoxCheckedBy.DataSource = trnStockInController.DropdownListStockInUser();
                comboBoxCheckedBy.ValueMember = "Id";
                comboBoxCheckedBy.DisplayMember = "FullName";

                comboBoxApprovedBy.DataSource = trnStockInController.DropdownListStockInUser();
                comboBoxApprovedBy.ValueMember = "Id";
                comboBoxApprovedBy.DisplayMember = "FullName";

                GetStockInDetail();
            }
        }

        public void GetStockInDetail()
        {
            UpdateComponents(trnStockInEntity.IsLocked);

            textBoxBranch.Text = trnStockInEntity.Branch;
            textBoxINNumber.Text = trnStockInEntity.INNumber;
            dateTimePickerINDate.Value = trnStockInEntity.INDate;
            textBoxRemarks.Text = trnStockInEntity.Remarks;
            comboBoxPreparedBy.SelectedValue = trnStockInEntity.PreparedBy;
            comboBoxCheckedBy.SelectedValue = trnStockInEntity.CheckedBy;
            comboBoxApprovedBy.SelectedValue = trnStockInEntity.ApprovedBy;
            checkBoxIsReturned.Checked = trnStockInEntity.IsReturned;

            CreateStockInItemDataGridView();
            CreateInventoryEntriesDataGridView();
        }

        public void UpdateComponents(Boolean isLocked)
        {
            if (sysUserRights.GetUserRights().CanLock == false)
            {
                buttonLock.Enabled = false;
            }
            else
            {
                buttonLock.Enabled = !isLocked;
            }

            if (sysUserRights.GetUserRights().CanUnlock == false)
            {
                buttonUnlock.Enabled = false;
            }
            else
            {
                buttonUnlock.Enabled = isLocked;
            }

            if (sysUserRights.GetUserRights().CanPrint == false)
            {
                buttonPrint.Enabled = false;
            }
            else
            {
                buttonPrint.Enabled = isLocked;
            }

            if (sysUserRights.GetUserRights().CanAdd == false)
            {
                buttonSearchItem.Enabled = false;
            }
            else
            {
                buttonSearchItem.Enabled = !isLocked;
            }

            if (sysUserRights.GetUserRights().CanEdit == false)
            {
                dataGridViewStockInItem.Columns[0].Visible = false;
            }
            else
            {
                dataGridViewStockInItem.Columns[0].Visible = !isLocked;
            }

            if (sysUserRights.GetUserRights().CanDelete == false)
            {
                dataGridViewStockInItem.Columns[1].Visible = false;
            }
            else
            {
                dataGridViewStockInItem.Columns[1].Visible = !isLocked;
            }

            textBoxBranch.Enabled = !isLocked;
            textBoxINNumber.Enabled = !isLocked;
            dateTimePickerINDate.Enabled = !isLocked;
            textBoxRemarks.Enabled = !isLocked;
            comboBoxCheckedBy.Enabled = !isLocked;
            comboBoxApprovedBy.Enabled = !isLocked;
            checkBoxIsReturned.Enabled = !isLocked;
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            Controllers.TrnStockInController trnStockInController = new Controllers.TrnStockInController();

            Entities.TrnStockInEntity newStockInEntity = new Entities.TrnStockInEntity()
            {
                INDate = dateTimePickerINDate.Value.Date,
                Remarks = textBoxRemarks.Text,
                CheckedBy = Convert.ToInt32(comboBoxCheckedBy.SelectedValue),
                ApprovedBy = Convert.ToInt32(comboBoxApprovedBy.SelectedValue),
                IsReturned = checkBoxIsReturned.Checked
            };

            String[] lockStockIn = trnStockInController.LockStockIn(trnStockInEntity.Id, newStockInEntity);
            if (lockStockIn[1].Equals("0") == false)
            {
                UpdateComponents(true);
                trnStockInForm.UpdateStockInDataSource();

                UpdateInventoryEntriesDataSource();
            }
            else
            {
                MessageBox.Show(lockStockIn[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            Controllers.TrnStockInController trnStockInController = new Controllers.TrnStockInController();

            String[] unlockStockIn = trnStockInController.UnlockStockIn(trnStockInEntity.Id);
            if (unlockStockIn[1].Equals("0") == false)
            {
                UpdateComponents(false);
                trnStockInForm.UpdateStockInDataSource();

                UpdateInventoryEntriesDataSource();
            }
            else
            {
                MessageBox.Show(unlockStockIn[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            new TrnStockInDetailPrintPreviewForm(trnStockInEntity.Id);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
            sysSoftwareForm.RemoveTabPage();
        }

        public void UpdateStockInItemDataSource()
        {
            SetStockInItemDataSourceAsync();
        }

        public async void SetStockInItemDataSourceAsync()
        {
            List<Entities.DgvStockInItemEntity> getStockInItemData = await GetStockInItemDataTask();
            if (getStockInItemData.Any())
            {
                stockInItemPageNumber = 1;
                stockInItemData = getStockInItemData;
                stockInItemPageList = new PagedList<Entities.DgvStockInItemEntity>(stockInItemData, stockInItemPageNumber, stockInItemPageSize);

                if (stockInItemPageList.PageCount == 1)
                {
                    buttonStockInItemPageListFirst.Enabled = false;
                    buttonStockInItemPageListPrevious.Enabled = false;
                    buttonStockInItemPageListNext.Enabled = false;
                    buttonStockInItemPageListLast.Enabled = false;
                }
                else if (stockInItemPageNumber == 1)
                {
                    buttonStockInItemPageListFirst.Enabled = false;
                    buttonStockInItemPageListPrevious.Enabled = false;
                    buttonStockInItemPageListNext.Enabled = true;
                    buttonStockInItemPageListLast.Enabled = true;
                }
                else if (stockInItemPageNumber == stockInItemPageList.PageCount)
                {
                    buttonStockInItemPageListFirst.Enabled = true;
                    buttonStockInItemPageListPrevious.Enabled = true;
                    buttonStockInItemPageListNext.Enabled = false;
                    buttonStockInItemPageListLast.Enabled = false;
                }
                else
                {
                    buttonStockInItemPageListFirst.Enabled = true;
                    buttonStockInItemPageListPrevious.Enabled = true;
                    buttonStockInItemPageListNext.Enabled = true;
                    buttonStockInItemPageListLast.Enabled = true;
                }

                textBoxStockInItemPageNumber.Text = stockInItemPageNumber + " / " + stockInItemPageList.PageCount;
                stockInItemDataSource.DataSource = stockInItemPageList;
            }
            else
            {
                buttonStockInItemPageListFirst.Enabled = false;
                buttonStockInItemPageListPrevious.Enabled = false;
                buttonStockInItemPageListNext.Enabled = false;
                buttonStockInItemPageListLast.Enabled = false;

                stockInItemPageNumber = 1;

                stockInItemData = new List<Entities.DgvStockInItemEntity>();
                stockInItemDataSource.Clear();
                textBoxStockInItemPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvStockInItemEntity>> GetStockInItemDataTask()
        {
            Controllers.TrnStockInItemController trnStockInItemController = new Controllers.TrnStockInItemController();

            List<Entities.TrnStockInItemEntity> listStockInItem = trnStockInItemController.ListStockInItem(trnStockInEntity.Id);
            if (listStockInItem.Any())
            {
                var items = from d in listStockInItem
                            select new Entities.DgvStockInItemEntity
                            {
                                ColumnStockInItemButtonEdit = "Edit",
                                ColumnStockInItemButtonDelete = "Delete",
                                ColumnStockInItemId = d.Id,
                                ColumnStockInItemINId = d.INId,
                                ColumnStockInItemItemBarCode = d.ItemBarCode,
                                ColumnStockInItemItemId = d.ItemId,
                                ColumnStockInItemItemDescription = d.ItemDescription,
                                ColumnStockInItemUnitId = d.UnitId,
                                ColumnStockInItemUnit = d.Unit,
                                ColumnStockInItemQuantity = d.Quantity.ToString("#,##0.00"),
                                ColumnStockInItemCost = d.Cost.ToString("#,##0.00"),
                                ColumnStockInItemAmount = d.Amount.ToString("#,##0.00"),
                                ColumnStockInItemBaseQuantity = d.BaseQuantity.ToString("#,##0.00"),
                                ColumnStockInItemBaseCost = d.BaseCost.ToString("#,##0.00"),
                                ColumnStockInItemSpace = ""
                            };

                textBoxTotalAmount.Text = listStockInItem.Sum(d => d.Amount).ToString("#,##0.00");
                return Task.FromResult(items.ToList());
            }
            else
            {
                textBoxTotalAmount.Text = Convert.ToDecimal("0").ToString("#,##0.00");

                return Task.FromResult(new List<Entities.DgvStockInItemEntity>());
            }
        }

        public void CreateStockInItemDataGridView()
        {
            UpdateStockInItemDataSource();

            dataGridViewStockInItem.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewStockInItem.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewStockInItem.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewStockInItem.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewStockInItem.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewStockInItem.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewStockInItem.DataSource = stockInItemDataSource;
        }

        public void GetStockInItemCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewStockInItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetStockInItemCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewStockInItem.CurrentCell.ColumnIndex == dataGridViewStockInItem.Columns["ColumnStockInItemButtonEdit"].Index)
            {
                var id = Convert.ToInt32(dataGridViewStockInItem.Rows[e.RowIndex].Cells[dataGridViewStockInItem.Columns["ColumnStockInItemId"].Index].Value);
                var INId = Convert.ToInt32(dataGridViewStockInItem.Rows[e.RowIndex].Cells[dataGridViewStockInItem.Columns["ColumnStockInItemINId"].Index].Value);
                var itemId = Convert.ToInt32(dataGridViewStockInItem.Rows[e.RowIndex].Cells[dataGridViewStockInItem.Columns["ColumnStockInItemItemId"].Index].Value);
                var itemDescription = dataGridViewStockInItem.Rows[e.RowIndex].Cells[dataGridViewStockInItem.Columns["ColumnStockInItemItemDescription"].Index].Value.ToString();
                var unitId = Convert.ToInt32(dataGridViewStockInItem.Rows[e.RowIndex].Cells[dataGridViewStockInItem.Columns["ColumnStockInItemUnitId"].Index].Value);
                var unit = dataGridViewStockInItem.Rows[e.RowIndex].Cells[dataGridViewStockInItem.Columns["ColumnStockInItemUnit"].Index].Value.ToString();
                var quantity = Convert.ToDecimal(dataGridViewStockInItem.Rows[e.RowIndex].Cells[dataGridViewStockInItem.Columns["ColumnStockInItemQuantity"].Index].Value);
                var cost = Convert.ToDecimal(dataGridViewStockInItem.Rows[e.RowIndex].Cells[dataGridViewStockInItem.Columns["ColumnStockInItemCost"].Index].Value);
                var amount = Convert.ToDecimal(dataGridViewStockInItem.Rows[e.RowIndex].Cells[dataGridViewStockInItem.Columns["ColumnStockInItemAmount"].Index].Value);

                Entities.TrnStockInItemEntity trnStockInItemEntity = new Entities.TrnStockInItemEntity()
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

                TrnStockInDetailStockInItemDetailForm trnStockInDetailStockInItemDetailForm = new TrnStockInDetailStockInItemDetailForm(this, trnStockInItemEntity);
                trnStockInDetailStockInItemDetailForm.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewStockInItem.CurrentCell.ColumnIndex == dataGridViewStockInItem.Columns["ColumnStockInItemButtonDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete Stock-In?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(dataGridViewStockInItem.Rows[e.RowIndex].Cells[dataGridViewStockInItem.Columns["ColumnStockInItemId"].Index].Value);

                    Controllers.TrnStockInItemController trnStockInItemController = new Controllers.TrnStockInItemController();
                    String[] deleteStockInItem = trnStockInItemController.DeleteStockInItem(id);
                    if (deleteStockInItem[1].Equals("0") == false)
                    {
                        stockInItemPageNumber = 1;
                        UpdateStockInItemDataSource();
                    }
                    else
                    {
                        MessageBox.Show(deleteStockInItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonStockInItemPageListFirst_Click(object sender, EventArgs e)
        {
            stockInItemPageList = new PagedList<Entities.DgvStockInItemEntity>(stockInItemData, 1, stockInItemPageSize);
            stockInItemDataSource.DataSource = stockInItemPageList;

            buttonStockInItemPageListFirst.Enabled = false;
            buttonStockInItemPageListPrevious.Enabled = false;
            buttonStockInItemPageListNext.Enabled = true;
            buttonStockInItemPageListLast.Enabled = true;

            stockInItemPageNumber = 1;
            textBoxStockInItemPageNumber.Text = stockInItemPageNumber + " / " + stockInItemPageList.PageCount;
        }

        private void buttonStockInItemPageListPrevious_Click(object sender, EventArgs e)
        {
            if (stockInItemPageList.HasPreviousPage == true)
            {
                stockInItemPageList = new PagedList<Entities.DgvStockInItemEntity>(stockInItemData, --stockInItemPageNumber, stockInItemPageSize);
                stockInItemDataSource.DataSource = stockInItemPageList;
            }

            buttonStockInItemPageListNext.Enabled = true;
            buttonStockInItemPageListLast.Enabled = true;

            if (stockInItemPageNumber == 1)
            {
                buttonStockInItemPageListFirst.Enabled = false;
                buttonStockInItemPageListPrevious.Enabled = false;
            }

            textBoxStockInItemPageNumber.Text = stockInItemPageNumber + " / " + stockInItemPageList.PageCount;
        }

        private void buttonStockInItemPageListNext_Click(object sender, EventArgs e)
        {
            if (stockInItemPageList.HasNextPage == true)
            {
                stockInItemPageList = new PagedList<Entities.DgvStockInItemEntity>(stockInItemData, ++stockInItemPageNumber, stockInItemPageSize);
                stockInItemDataSource.DataSource = stockInItemPageList;
            }

            buttonStockInItemPageListFirst.Enabled = true;
            buttonStockInItemPageListPrevious.Enabled = true;

            if (stockInItemPageNumber == stockInItemPageList.PageCount)
            {
                buttonStockInItemPageListNext.Enabled = false;
                buttonStockInItemPageListLast.Enabled = false;
            }

            textBoxStockInItemPageNumber.Text = stockInItemPageNumber + " / " + stockInItemPageList.PageCount;
        }

        private void buttonStockInItemPageListLast_Click(object sender, EventArgs e)
        {
            stockInItemPageList = new PagedList<Entities.DgvStockInItemEntity>(stockInItemData, stockInItemPageList.PageCount, stockInItemPageSize);
            stockInItemDataSource.DataSource = stockInItemPageList;

            buttonStockInItemPageListFirst.Enabled = true;
            buttonStockInItemPageListPrevious.Enabled = true;
            buttonStockInItemPageListNext.Enabled = false;
            buttonStockInItemPageListLast.Enabled = false;

            stockInItemPageNumber = stockInItemPageList.PageCount;
            textBoxStockInItemPageNumber.Text = stockInItemPageNumber + " / " + stockInItemPageList.PageCount;
        }

        private void buttonSearchItem_Click(object sender, EventArgs e)
        {
            TrnStockInDetailSearchItemForm trnStockInDetailSearchItemForm = new TrnStockInDetailSearchItemForm(this, trnStockInEntity);
            trnStockInDetailSearchItemForm.ShowDialog();
        }

        public void UpdateInventoryEntriesDataSource()
        {
            SetInventoryEntriesDataSourceAsync();
        }

        public async void SetInventoryEntriesDataSourceAsync()
        {
            List<Entities.DgvTrnInventoryEntriesEntity> getInventoryEntriesData = await GetInventoryEntriesDataTask();
            if (getInventoryEntriesData.Any())
            {
                inventoryEntriesPageNumber = 1;
                inventoryEntriesData = getInventoryEntriesData;
                inventoryEntriesPageList = new PagedList<Entities.DgvTrnInventoryEntriesEntity>(inventoryEntriesData, inventoryEntriesPageNumber, inventoryEntriesPageSize);

                if (inventoryEntriesPageList.PageCount == 1)
                {
                    buttonInventoryEntriesPageListFirst.Enabled = false;
                    buttonInventoryEntriesPageListPrevious.Enabled = false;
                    buttonInventoryEntriesPageListNext.Enabled = false;
                    buttonInventoryEntriesPageListLast.Enabled = false;
                }
                else if (inventoryEntriesPageNumber == 1)
                {
                    buttonInventoryEntriesPageListFirst.Enabled = false;
                    buttonInventoryEntriesPageListPrevious.Enabled = false;
                    buttonInventoryEntriesPageListNext.Enabled = true;
                    buttonInventoryEntriesPageListLast.Enabled = true;
                }
                else if (inventoryEntriesPageNumber == inventoryEntriesPageList.PageCount)
                {
                    buttonInventoryEntriesPageListFirst.Enabled = true;
                    buttonInventoryEntriesPageListPrevious.Enabled = true;
                    buttonInventoryEntriesPageListNext.Enabled = false;
                    buttonInventoryEntriesPageListLast.Enabled = false;
                }
                else
                {
                    buttonInventoryEntriesPageListFirst.Enabled = true;
                    buttonInventoryEntriesPageListPrevious.Enabled = true;
                    buttonInventoryEntriesPageListNext.Enabled = true;
                    buttonInventoryEntriesPageListLast.Enabled = true;
                }

                textBoxInventoryEntriesPageNumber.Text = inventoryEntriesPageNumber + " / " + inventoryEntriesPageList.PageCount;
                inventoryEntriesDataSource.DataSource = inventoryEntriesPageList;
            }
            else
            {
                buttonInventoryEntriesPageListFirst.Enabled = false;
                buttonInventoryEntriesPageListPrevious.Enabled = false;
                buttonInventoryEntriesPageListNext.Enabled = false;
                buttonInventoryEntriesPageListLast.Enabled = false;

                inventoryEntriesPageNumber = 1;

                inventoryEntriesData = new List<Entities.DgvTrnInventoryEntriesEntity>();
                inventoryEntriesDataSource.Clear();
                textBoxInventoryEntriesPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvTrnInventoryEntriesEntity>> GetInventoryEntriesDataTask()
        {
            Controllers.TrnInventoryController trnInventoryController = new Controllers.TrnInventoryController();

            List<Entities.TrnInventoryEntity> listInventoryEntries = trnInventoryController.ListStockInInventoryEntries(trnStockInEntity.Id);
            if (listInventoryEntries.Any())
            {
                var items = from d in listInventoryEntries
                            select new Entities.DgvTrnInventoryEntriesEntity
                            {
                                ColumnInventoryEntriesBranch = d.Branch,
                                ColumnInventoryEntriesInventoryDate = d.InventoryDate.ToShortDateString(),
                                ColumnInventoryEntriesItemDescription = d.ItemDescription,
                                ColumnInventoryEntriesInventoryCode = d.ItemInventoryCode,
                                ColumnInventoryEntriesQuantity = d.Quantity.ToString("#,##0.00"),
                                ColumnInventoryEntriesAmount = d.Amount.ToString("#,##0.00"),
                                ColumnInventoryEntriesSpace = ""
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvTrnInventoryEntriesEntity>());
            }
        }

        public void CreateInventoryEntriesDataGridView()
        {
            UpdateInventoryEntriesDataSource();
            dataGridViewInventoryEntries.DataSource = inventoryEntriesDataSource;
        }

        public void GetInventoryEntriesCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonInventoryEntriesPageListFirst_Click(object sender, EventArgs e)
        {
            inventoryEntriesPageList = new PagedList<Entities.DgvTrnInventoryEntriesEntity>(inventoryEntriesData, 1, inventoryEntriesPageSize);
            inventoryEntriesDataSource.DataSource = inventoryEntriesPageList;

            buttonInventoryEntriesPageListFirst.Enabled = false;
            buttonInventoryEntriesPageListPrevious.Enabled = false;
            buttonInventoryEntriesPageListNext.Enabled = true;
            buttonInventoryEntriesPageListLast.Enabled = true;

            inventoryEntriesPageNumber = 1;
            textBoxInventoryEntriesPageNumber.Text = inventoryEntriesPageNumber + " / " + inventoryEntriesPageList.PageCount;
        }

        private void buttonInventoryEntriesPageListPrevious_Click(object sender, EventArgs e)
        {
            if (inventoryEntriesPageList.HasPreviousPage == true)
            {
                inventoryEntriesPageList = new PagedList<Entities.DgvTrnInventoryEntriesEntity>(inventoryEntriesData, --inventoryEntriesPageNumber, inventoryEntriesPageSize);
                inventoryEntriesDataSource.DataSource = inventoryEntriesPageList;
            }

            buttonInventoryEntriesPageListNext.Enabled = true;
            buttonInventoryEntriesPageListLast.Enabled = true;

            if (inventoryEntriesPageNumber == 1)
            {
                buttonInventoryEntriesPageListFirst.Enabled = false;
                buttonInventoryEntriesPageListPrevious.Enabled = false;
            }

            textBoxInventoryEntriesPageNumber.Text = inventoryEntriesPageNumber + " / " + inventoryEntriesPageList.PageCount;
        }

        private void buttonInventoryEntriesPageListNext_Click(object sender, EventArgs e)
        {
            if (inventoryEntriesPageList.HasNextPage == true)
            {
                inventoryEntriesPageList = new PagedList<Entities.DgvTrnInventoryEntriesEntity>(inventoryEntriesData, ++inventoryEntriesPageNumber, inventoryEntriesPageSize);
                inventoryEntriesDataSource.DataSource = inventoryEntriesPageList;
            }

            buttonInventoryEntriesPageListFirst.Enabled = true;
            buttonInventoryEntriesPageListPrevious.Enabled = true;

            if (inventoryEntriesPageNumber == inventoryEntriesPageList.PageCount)
            {
                buttonInventoryEntriesPageListNext.Enabled = false;
                buttonInventoryEntriesPageListLast.Enabled = false;
            }

            textBoxInventoryEntriesPageNumber.Text = inventoryEntriesPageNumber + " / " + inventoryEntriesPageList.PageCount;
        }

        private void buttonInventoryEntriesPageListLast_Click(object sender, EventArgs e)
        {
            inventoryEntriesPageList = new PagedList<Entities.DgvTrnInventoryEntriesEntity>(inventoryEntriesData, inventoryEntriesPageList.PageCount, inventoryEntriesPageSize);
            inventoryEntriesDataSource.DataSource = inventoryEntriesPageList;

            buttonInventoryEntriesPageListFirst.Enabled = true;
            buttonInventoryEntriesPageListPrevious.Enabled = true;
            buttonInventoryEntriesPageListNext.Enabled = false;
            buttonInventoryEntriesPageListLast.Enabled = false;

            inventoryEntriesPageNumber = inventoryEntriesPageList.PageCount;
            textBoxInventoryEntriesPageNumber.Text = inventoryEntriesPageNumber + " / " + inventoryEntriesPageList.PageCount;
        }
    }
}
