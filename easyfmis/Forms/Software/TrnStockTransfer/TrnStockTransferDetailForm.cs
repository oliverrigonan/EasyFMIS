using PagedList;
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
    public partial class TrnStockTransferDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        public TrnStockTransferForm trnStockTransferForm;
        public Entities.TrnStockTransferEntity trnStockTransferEntity;

        public static List<Entities.DgvStockTransferItemEntity> stockOutItemData = new List<Entities.DgvStockTransferItemEntity>();
        public static Int32 stockOutItemPageNumber = 1;
        public static Int32 stockOutItemPageSize = 50;
        public PagedList<Entities.DgvStockTransferItemEntity> stockOutItemPageList = new PagedList<Entities.DgvStockTransferItemEntity>(stockOutItemData, stockOutItemPageNumber, stockOutItemPageSize);
        public BindingSource stockOutItemDataSource = new BindingSource();

        public static List<Entities.DgvTrnInventoryEntriesEntity> inventoryEntriesData = new List<Entities.DgvTrnInventoryEntriesEntity>();
        public static Int32 inventoryEntriesPageNumber = 1;
        public static Int32 inventoryEntriesPageSize = 50;
        public PagedList<Entities.DgvTrnInventoryEntriesEntity> inventoryEntriesPageList = new PagedList<Entities.DgvTrnInventoryEntriesEntity>(inventoryEntriesData, inventoryEntriesPageNumber, inventoryEntriesPageSize);
        public BindingSource inventoryEntriesDataSource = new BindingSource();

        public TrnStockTransferDetailForm(SysSoftwareForm softwareForm, TrnStockTransferForm stockOutListForm, Entities.TrnStockTransferEntity stockOutEntity)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            trnStockTransferForm = stockOutListForm;
            trnStockTransferEntity = stockOutEntity;

            GetBranchList();
        }

        public void GetBranchList()
        {
            Controllers.TrnStockTransferController trnStockTransferController = new Controllers.TrnStockTransferController();
            if (trnStockTransferController.DropdownListStockTransferToBranch().Any())
            {
                comboBoxToBranch.DataSource = trnStockTransferController.DropdownListStockTransferToBranch();
                comboBoxToBranch.ValueMember = "Id";
                comboBoxToBranch.DisplayMember = "Branch";

                GetUserList();
            }
        }

        public void GetUserList()
        {
            Controllers.TrnStockTransferController trnStockTransferController = new Controllers.TrnStockTransferController();
            if (trnStockTransferController.DropdownListStockTransferUser().Any())
            {
                comboBoxPreparedBy.DataSource = trnStockTransferController.DropdownListStockTransferUser();
                comboBoxPreparedBy.ValueMember = "Id";
                comboBoxPreparedBy.DisplayMember = "FullName";

                comboBoxCheckedBy.DataSource = trnStockTransferController.DropdownListStockTransferUser();
                comboBoxCheckedBy.ValueMember = "Id";
                comboBoxCheckedBy.DisplayMember = "FullName";

                comboBoxApprovedBy.DataSource = trnStockTransferController.DropdownListStockTransferUser();
                comboBoxApprovedBy.ValueMember = "Id";
                comboBoxApprovedBy.DisplayMember = "FullName";

                GetStockTransferDetail();
            }
        }

        public void GetStockTransferDetail()
        {
            UpdateComponents(trnStockTransferEntity.IsLocked);

            textBoxBranch.Text = trnStockTransferEntity.Branch;
            textBoxSTNumber.Text = trnStockTransferEntity.STNumber;
            dateTimePickerSTDate.Value = trnStockTransferEntity.STDate;
            comboBoxToBranch.SelectedValue = trnStockTransferEntity.ToBranchId;
            textBoxRemarks.Text = trnStockTransferEntity.Remarks;
            comboBoxPreparedBy.SelectedValue = trnStockTransferEntity.PreparedBy;
            comboBoxCheckedBy.SelectedValue = trnStockTransferEntity.CheckedBy;
            comboBoxApprovedBy.SelectedValue = trnStockTransferEntity.ApprovedBy;

            CreateStockTransferItemDataGridView();
            CreateInventoryEntriesDataGridView();
        }

        public void UpdateComponents(Boolean isLocked)
        {
            buttonLock.Enabled = !isLocked;
            buttonUnlock.Enabled = isLocked;
            buttonPrint.Enabled = !isLocked;

            buttonSearchItem.Enabled = !isLocked;

            textBoxBranch.Enabled = !isLocked;
            textBoxSTNumber.Enabled = !isLocked;
            dateTimePickerSTDate.Enabled = !isLocked;
            comboBoxToBranch.Enabled = !isLocked;
            textBoxRemarks.Enabled = !isLocked;
            comboBoxCheckedBy.Enabled = !isLocked;
            comboBoxApprovedBy.Enabled = !isLocked;

            dataGridViewStockTransferItem.Columns[0].Visible = !isLocked;
            dataGridViewStockTransferItem.Columns[1].Visible = !isLocked;
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            Controllers.TrnStockTransferController trnStockTransferController = new Controllers.TrnStockTransferController();

            Entities.TrnStockTransferEntity newStockTransferEntity = new Entities.TrnStockTransferEntity()
            {
                STDate = dateTimePickerSTDate.Value.Date,
                ToBranchId = Convert.ToInt32(comboBoxToBranch.SelectedValue),
                Remarks = textBoxRemarks.Text,
                CheckedBy = Convert.ToInt32(comboBoxCheckedBy.SelectedValue),
                ApprovedBy = Convert.ToInt32(comboBoxApprovedBy.SelectedValue)
            };

            String[] lockStockTransfer = trnStockTransferController.LockStockTransfer(trnStockTransferEntity.Id, newStockTransferEntity);
            if (lockStockTransfer[1].Equals("0") == false)
            {
                UpdateComponents(true);
                trnStockTransferForm.UpdateStockTransferDataSource();

                UpdateInventoryEntriesDataSource();
            }
            else
            {
                MessageBox.Show(lockStockTransfer[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            Controllers.TrnStockTransferController trnStockTransferController = new Controllers.TrnStockTransferController();

            String[] unlockStockTransfer = trnStockTransferController.UnlockStockTransfer(trnStockTransferEntity.Id);
            if (unlockStockTransfer[1].Equals("0") == false)
            {
                UpdateComponents(false);
                trnStockTransferForm.UpdateStockTransferDataSource();

                UpdateInventoryEntriesDataSource();
            }
            else
            {
                MessageBox.Show(unlockStockTransfer[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void UpdateStockTransferItemDataSource()
        {
            SetStockTransferItemDataSourceAsync();
        }

        public async void SetStockTransferItemDataSourceAsync()
        {
            List<Entities.DgvStockTransferItemEntity> getStockTransferItemData = await GetStockTransferItemDataTask();
            if (getStockTransferItemData.Any())
            {
                stockOutItemData = getStockTransferItemData;
                stockOutItemPageList = new PagedList<Entities.DgvStockTransferItemEntity>(stockOutItemData, stockOutItemPageNumber, stockOutItemPageSize);

                if (stockOutItemPageList.PageCount == 1)
                {
                    buttonStockTransferItemPageListFirst.Enabled = false;
                    buttonStockTransferItemPageListPrevious.Enabled = false;
                    buttonStockTransferItemPageListNext.Enabled = false;
                    buttonStockTransferItemPageListLast.Enabled = false;
                }
                else if (stockOutItemPageNumber == 1)
                {
                    buttonStockTransferItemPageListFirst.Enabled = false;
                    buttonStockTransferItemPageListPrevious.Enabled = false;
                    buttonStockTransferItemPageListNext.Enabled = true;
                    buttonStockTransferItemPageListLast.Enabled = true;
                }
                else if (stockOutItemPageNumber == stockOutItemPageList.PageCount)
                {
                    buttonStockTransferItemPageListFirst.Enabled = true;
                    buttonStockTransferItemPageListPrevious.Enabled = true;
                    buttonStockTransferItemPageListNext.Enabled = false;
                    buttonStockTransferItemPageListLast.Enabled = false;
                }
                else
                {
                    buttonStockTransferItemPageListFirst.Enabled = true;
                    buttonStockTransferItemPageListPrevious.Enabled = true;
                    buttonStockTransferItemPageListNext.Enabled = true;
                    buttonStockTransferItemPageListLast.Enabled = true;
                }

                textBoxStockTransferItemPageNumber.Text = stockOutItemPageNumber + " / " + stockOutItemPageList.PageCount;
                stockOutItemDataSource.DataSource = stockOutItemPageList;
            }
            else
            {
                buttonStockTransferItemPageListFirst.Enabled = false;
                buttonStockTransferItemPageListPrevious.Enabled = false;
                buttonStockTransferItemPageListNext.Enabled = false;
                buttonStockTransferItemPageListLast.Enabled = false;

                stockOutItemPageNumber = 1;

                stockOutItemData = new List<Entities.DgvStockTransferItemEntity>();
                stockOutItemDataSource.Clear();
                textBoxStockTransferItemPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvStockTransferItemEntity>> GetStockTransferItemDataTask()
        {
            Controllers.TrnStockTransferItemController trnStockTransferItemController = new Controllers.TrnStockTransferItemController();

            List<Entities.TrnStockTransferItemEntity> listStockTransferItem = trnStockTransferItemController.ListStockTransferItem(trnStockTransferEntity.Id);
            if (listStockTransferItem.Any())
            {
                var items = from d in listStockTransferItem
                            select new Entities.DgvStockTransferItemEntity
                            {
                                ColumnStockTransferItemButtonEdit = "Edit",
                                ColumnStockTransferItemButtonDelete = "Delete",
                                ColumnStockTransferItemId = d.Id,
                                ColumnStockTransferItemSTId = d.STId,
                                ColumnStockTransferItemItemId = d.ItemId,
                                ColumnStockTransferItemItemDescription = d.ItemDescription,
                                ColumnStockTransferItemUnitId = d.UnitId,
                                ColumnStockTransferItemUnit = d.Unit,
                                ColumnStockTransferItemInventoryId = d.ItemInventoryId,
                                ColumnStockTransferItemInventoryCode = d.ItemInventoryCode,
                                ColumnStockTransferItemQuantity = d.Quantity.ToString("#,##0.00"),
                                ColumnStockTransferItemCost = d.Cost.ToString("#,##0.00"),
                                ColumnStockTransferItemAmount = d.Amount.ToString("#,##0.00"),
                                ColumnStockTransferItemBaseQuantity = d.BaseQuantity.ToString("#,##0.00"),
                                ColumnStockTransferItemBaseCost = d.BaseCost.ToString("#,##0.00"),
                                ColumnStockTransferItemSpace = ""
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvStockTransferItemEntity>());
            }
        }

        public void CreateStockTransferItemDataGridView()
        {
            UpdateStockTransferItemDataSource();

            dataGridViewStockTransferItem.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewStockTransferItem.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewStockTransferItem.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewStockTransferItem.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewStockTransferItem.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewStockTransferItem.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewStockTransferItem.DataSource = stockOutItemDataSource;
        }

        public void GetStockTransferItemCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewStockTransferItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetStockTransferItemCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewStockTransferItem.CurrentCell.ColumnIndex == dataGridViewStockTransferItem.Columns["ColumnStockTransferItemButtonEdit"].Index)
            {
                var id = Convert.ToInt32(dataGridViewStockTransferItem.Rows[e.RowIndex].Cells[dataGridViewStockTransferItem.Columns["ColumnStockTransferItemId"].Index].Value);
                var STId = Convert.ToInt32(dataGridViewStockTransferItem.Rows[e.RowIndex].Cells[dataGridViewStockTransferItem.Columns["ColumnStockTransferItemSTId"].Index].Value);
                var itemId = Convert.ToInt32(dataGridViewStockTransferItem.Rows[e.RowIndex].Cells[dataGridViewStockTransferItem.Columns["ColumnStockTransferItemItemId"].Index].Value);
                var itemDescription = dataGridViewStockTransferItem.Rows[e.RowIndex].Cells[dataGridViewStockTransferItem.Columns["ColumnStockTransferItemItemDescription"].Index].Value.ToString();
                var unitId = Convert.ToInt32(dataGridViewStockTransferItem.Rows[e.RowIndex].Cells[dataGridViewStockTransferItem.Columns["ColumnStockTransferItemUnitId"].Index].Value);
                var unit = dataGridViewStockTransferItem.Rows[e.RowIndex].Cells[dataGridViewStockTransferItem.Columns["ColumnStockTransferItemUnit"].Index].Value.ToString();
                var itemInventoryId = Convert.ToInt32(dataGridViewStockTransferItem.Rows[e.RowIndex].Cells[dataGridViewStockTransferItem.Columns["ColumnStockTransferItemInventoryId"].Index].Value);
                var itemInventoryCode = dataGridViewStockTransferItem.Rows[e.RowIndex].Cells[dataGridViewStockTransferItem.Columns["ColumnStockTransferItemInventoryCode"].Index].Value.ToString();
                var quantity = Convert.ToDecimal(dataGridViewStockTransferItem.Rows[e.RowIndex].Cells[dataGridViewStockTransferItem.Columns["ColumnStockTransferItemQuantity"].Index].Value);
                var cost = Convert.ToDecimal(dataGridViewStockTransferItem.Rows[e.RowIndex].Cells[dataGridViewStockTransferItem.Columns["ColumnStockTransferItemCost"].Index].Value);
                var amount = Convert.ToDecimal(dataGridViewStockTransferItem.Rows[e.RowIndex].Cells[dataGridViewStockTransferItem.Columns["ColumnStockTransferItemAmount"].Index].Value);

                Entities.TrnStockTransferItemEntity trnStockTransferItemEntity = new Entities.TrnStockTransferItemEntity()
                {
                    Id = id,
                    STId = STId,
                    ItemId = itemId,
                    ItemDescription = itemDescription,
                    UnitId = unitId,
                    Unit = unit,
                    ItemInventoryId = itemInventoryId,
                    ItemInventoryCode = itemInventoryCode,
                    Quantity = quantity,
                    Cost = cost,
                    Amount = amount
                };

                TrnStockTransferDetailStockTransferItemDetailForm trnStockTransferDetailStockTransferItemDetailForm = new TrnStockTransferDetailStockTransferItemDetailForm(this, trnStockTransferItemEntity);
                trnStockTransferDetailStockTransferItemDetailForm.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewStockTransferItem.CurrentCell.ColumnIndex == dataGridViewStockTransferItem.Columns["ColumnStockTransferItemButtonDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete Stock-In?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(dataGridViewStockTransferItem.Rows[e.RowIndex].Cells[dataGridViewStockTransferItem.Columns["ColumnStockTransferItemId"].Index].Value);

                    Controllers.TrnStockTransferItemController trnStockTransferItemController = new Controllers.TrnStockTransferItemController();
                    String[] deleteStockTransferItem = trnStockTransferItemController.DeleteStockTransferItem(id);
                    if (deleteStockTransferItem[1].Equals("0") == false)
                    {
                        stockOutItemPageNumber = 1;
                        UpdateStockTransferItemDataSource();
                    }
                    else
                    {
                        MessageBox.Show(deleteStockTransferItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonStockTransferItemPageListFirst_Click(object sender, EventArgs e)
        {
            stockOutItemPageList = new PagedList<Entities.DgvStockTransferItemEntity>(stockOutItemData, 1, stockOutItemPageSize);
            stockOutItemDataSource.DataSource = stockOutItemPageList;

            buttonStockTransferItemPageListFirst.Enabled = false;
            buttonStockTransferItemPageListPrevious.Enabled = false;
            buttonStockTransferItemPageListNext.Enabled = true;
            buttonStockTransferItemPageListLast.Enabled = true;

            stockOutItemPageNumber = 1;
            textBoxStockTransferItemPageNumber.Text = stockOutItemPageNumber + " / " + stockOutItemPageList.PageCount;
        }

        private void buttonStockTransferItemPageListPrevious_Click(object sender, EventArgs e)
        {
            if (stockOutItemPageList.HasPreviousPage == true)
            {
                stockOutItemPageList = new PagedList<Entities.DgvStockTransferItemEntity>(stockOutItemData, --stockOutItemPageNumber, stockOutItemPageSize);
                stockOutItemDataSource.DataSource = stockOutItemPageList;
            }

            buttonStockTransferItemPageListNext.Enabled = true;
            buttonStockTransferItemPageListLast.Enabled = true;

            if (stockOutItemPageNumber == 1)
            {
                buttonStockTransferItemPageListFirst.Enabled = false;
                buttonStockTransferItemPageListPrevious.Enabled = false;
            }

            textBoxStockTransferItemPageNumber.Text = stockOutItemPageNumber + " / " + stockOutItemPageList.PageCount;
        }

        private void buttonStockTransferItemPageListNext_Click(object sender, EventArgs e)
        {
            if (stockOutItemPageList.HasNextPage == true)
            {
                stockOutItemPageList = new PagedList<Entities.DgvStockTransferItemEntity>(stockOutItemData, ++stockOutItemPageNumber, stockOutItemPageSize);
                stockOutItemDataSource.DataSource = stockOutItemPageList;
            }

            buttonStockTransferItemPageListFirst.Enabled = true;
            buttonStockTransferItemPageListPrevious.Enabled = true;

            if (stockOutItemPageNumber == stockOutItemPageList.PageCount)
            {
                buttonStockTransferItemPageListNext.Enabled = false;
                buttonStockTransferItemPageListLast.Enabled = false;
            }

            textBoxStockTransferItemPageNumber.Text = stockOutItemPageNumber + " / " + stockOutItemPageList.PageCount;
        }

        private void buttonStockTransferItemPageListLast_Click(object sender, EventArgs e)
        {
            stockOutItemPageList = new PagedList<Entities.DgvStockTransferItemEntity>(stockOutItemData, stockOutItemPageList.PageCount, stockOutItemPageSize);
            stockOutItemDataSource.DataSource = stockOutItemPageList;

            buttonStockTransferItemPageListFirst.Enabled = true;
            buttonStockTransferItemPageListPrevious.Enabled = true;
            buttonStockTransferItemPageListNext.Enabled = false;
            buttonStockTransferItemPageListLast.Enabled = false;

            stockOutItemPageNumber = stockOutItemPageList.PageCount;
            textBoxStockTransferItemPageNumber.Text = stockOutItemPageNumber + " / " + stockOutItemPageList.PageCount;
        }

        private void buttonSearchItem_Click(object sender, EventArgs e)
        {
            TrnStockTransferDetailSearchItemForm trnStockTransferDetailSearchItemForm = new TrnStockTransferDetailSearchItemForm(this, trnStockTransferEntity);
            trnStockTransferDetailSearchItemForm.ShowDialog();
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

            List<Entities.TrnInventoryEntity> listInventoryEntries = trnInventoryController.ListStockTransferInventoryEntries(trnStockTransferEntity.Id);
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
