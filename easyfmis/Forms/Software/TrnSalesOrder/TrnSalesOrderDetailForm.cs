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

namespace easyfmis.Forms.Software.TrnSalesOrder
{
    public partial class TrnSalesOrderDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        TrnSalesOrderForm trnSalesOrderForm;
        public Entities.TrnSalesOrderEntity trnSalesOrderEntity;

        public static List<Entities.DgvTrnSalesOrderItemEntity> stockOutItemData = new List<Entities.DgvTrnSalesOrderItemEntity>();
        public static Int32 stockOutItemPageNumber = 1;
        public static Int32 stockOutItemPageSize = 50;
        public PagedList<Entities.DgvTrnSalesOrderItemEntity> stockOutItemPageList = new PagedList<Entities.DgvTrnSalesOrderItemEntity>(stockOutItemData, stockOutItemPageNumber, stockOutItemPageSize);
        public BindingSource stockOutItemDataSource = new BindingSource();

        //public static List<Entities.DgvTrnInventoryEntriesEntity> inventoryEntriesData = new List<Entities.DgvTrnInventoryEntriesEntity>();
        //public static Int32 inventoryEntriesPageNumber = 1;
        //public static Int32 inventoryEntriesPageSize = 50;
        //public PagedList<Entities.DgvTrnInventoryEntriesEntity> inventoryEntriesPageList = new PagedList<Entities.DgvTrnInventoryEntriesEntity>(inventoryEntriesData, inventoryEntriesPageNumber, inventoryEntriesPageSize);
        //public BindingSource inventoryEntriesDataSource = new BindingSource();

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

                GetStockOutDetail();
            }
        }

        public void GetStockOutDetail()
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
            //CreateInventoryEntriesDataGridView();
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

            dataGridViewStockOutItem.Columns[0].Visible = !isLocked;
            dataGridViewStockOutItem.Columns[1].Visible = !isLocked;
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
            List<Entities.DgvTrnSalesOrderItemEntity> getStockOutItemData = await GetStockOutItemDataTask();
            if (getStockOutItemData.Any())
            {
                stockOutItemData = getStockOutItemData;
                stockOutItemPageList = new PagedList<Entities.DgvTrnSalesOrderItemEntity>(stockOutItemData, stockOutItemPageNumber, stockOutItemPageSize);

                if (stockOutItemPageList.PageCount == 1)
                {
                    buttonStockOutItemPageListFirst.Enabled = false;
                    buttonStockOutItemPageListPrevious.Enabled = false;
                    buttonStockOutItemPageListNext.Enabled = false;
                    buttonStockOutItemPageListLast.Enabled = false;
                }
                else if (stockOutItemPageNumber == 1)
                {
                    buttonStockOutItemPageListFirst.Enabled = false;
                    buttonStockOutItemPageListPrevious.Enabled = false;
                    buttonStockOutItemPageListNext.Enabled = true;
                    buttonStockOutItemPageListLast.Enabled = true;
                }
                else if (stockOutItemPageNumber == stockOutItemPageList.PageCount)
                {
                    buttonStockOutItemPageListFirst.Enabled = true;
                    buttonStockOutItemPageListPrevious.Enabled = true;
                    buttonStockOutItemPageListNext.Enabled = false;
                    buttonStockOutItemPageListLast.Enabled = false;
                }
                else
                {
                    buttonStockOutItemPageListFirst.Enabled = true;
                    buttonStockOutItemPageListPrevious.Enabled = true;
                    buttonStockOutItemPageListNext.Enabled = true;
                    buttonStockOutItemPageListLast.Enabled = true;
                }

                textBoxStockOutItemPageNumber.Text = stockOutItemPageNumber + " / " + stockOutItemPageList.PageCount;
                stockOutItemDataSource.DataSource = stockOutItemPageList;
            }
            else
            {
                buttonStockOutItemPageListFirst.Enabled = false;
                buttonStockOutItemPageListPrevious.Enabled = false;
                buttonStockOutItemPageListNext.Enabled = false;
                buttonStockOutItemPageListLast.Enabled = false;

                stockOutItemPageNumber = 1;

                stockOutItemData = new List<Entities.DgvTrnSalesOrderItemEntity>();
                stockOutItemDataSource.Clear();
                textBoxStockOutItemPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvTrnSalesOrderItemEntity>> GetStockOutItemDataTask()
        {
            Controllers.TrnSalesOrderItemController trnSalesOrderItemController = new Controllers.TrnSalesOrderItemController();

            List<Entities.TrnSalesOrderItemEntity> listSalesOrderItem = trnSalesOrderItemController.ListSalesOrderItem(trnSalesOrderEntity.Id);
            if (listSalesOrderItem.Any())
            {
                var items = from d in listSalesOrderItem
                            select new Entities.DgvTrnSalesOrderItemEntity
                            {
                                //ColumnStockOutItemButtonEdit = "Edit",
                                //ColumnStockOutItemButtonDelete = "Delete",
                                //ColumnStockOutItemId = d.Id,
                                //ColumnStockOutItemOTId = d.OTId,
                                //ColumnStockOutItemItemId = d.ItemId,
                                //ColumnStockOutItemItemDescription = d.ItemDescription,
                                //ColumnStockOutItemUnitId = d.UnitId,
                                //ColumnStockOutItemUnit = d.Unit,
                                //ColumnStockOutItemInventoryId = d.ItemInventoryId,
                                //ColumnStockOutItemInventoryCode = d.ItemInventoryCode,
                                //ColumnStockOutItemQuantity = d.Quantity.ToString("#,##0.00"),
                                //ColumnStockOutItemCost = d.Cost.ToString("#,##0.00"),
                                //ColumnStockOutItemAmount = d.Amount.ToString("#,##0.00"),
                                //ColumnStockOutItemBaseQuantity = d.BaseQuantity.ToString("#,##0.00"),
                                //ColumnStockOutItemBaseCost = d.BaseCost.ToString("#,##0.00"),
                                //ColumnStockOutItemSpace = ""
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

            dataGridViewStockOutItem.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewStockOutItem.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewStockOutItem.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewStockOutItem.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewStockOutItem.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewStockOutItem.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewStockOutItem.DataSource = stockOutItemDataSource;
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

            if (e.RowIndex > -1 && dataGridViewStockOutItem.CurrentCell.ColumnIndex == dataGridViewStockOutItem.Columns["ColumnStockOutItemButtonEdit"].Index)
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

            if (e.RowIndex > -1 && dataGridViewStockOutItem.CurrentCell.ColumnIndex == dataGridViewStockOutItem.Columns["ColumnStockOutItemButtonDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete Stock-In?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(dataGridViewStockOutItem.Rows[e.RowIndex].Cells[dataGridViewStockOutItem.Columns["ColumnStockOutItemId"].Index].Value);

                    Controllers.TrnStockOutItemController trnStockOutItemController = new Controllers.TrnStockOutItemController();
                    String[] deleteStockOutItem = trnStockOutItemController.DeleteStockOutItem(id);
                    if (deleteStockOutItem[1].Equals("0") == false)
                    {
                        stockOutItemPageNumber = 1;
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
            stockOutItemPageList = new PagedList<Entities.DgvTrnSalesOrderItemEntity>(stockOutItemData, 1, stockOutItemPageSize);
            stockOutItemDataSource.DataSource = stockOutItemPageList;

            buttonStockOutItemPageListFirst.Enabled = false;
            buttonStockOutItemPageListPrevious.Enabled = false;
            buttonStockOutItemPageListNext.Enabled = true;
            buttonStockOutItemPageListLast.Enabled = true;

            stockOutItemPageNumber = 1;
            textBoxStockOutItemPageNumber.Text = stockOutItemPageNumber + " / " + stockOutItemPageList.PageCount;
        }

        private void buttonStockOutItemPageListPrevious_Click(object sender, EventArgs e)
        {
            if (stockOutItemPageList.HasPreviousPage == true)
            {
                stockOutItemPageList = new PagedList<Entities.DgvTrnSalesOrderItemEntity>(stockOutItemData, --stockOutItemPageNumber, stockOutItemPageSize);
                stockOutItemDataSource.DataSource = stockOutItemPageList;
            }

            buttonStockOutItemPageListNext.Enabled = true;
            buttonStockOutItemPageListLast.Enabled = true;

            if (stockOutItemPageNumber == 1)
            {
                buttonStockOutItemPageListFirst.Enabled = false;
                buttonStockOutItemPageListPrevious.Enabled = false;
            }

            textBoxStockOutItemPageNumber.Text = stockOutItemPageNumber + " / " + stockOutItemPageList.PageCount;
        }

        private void buttonStockOutItemPageListNext_Click(object sender, EventArgs e)
        {
            if (stockOutItemPageList.HasNextPage == true)
            {
                stockOutItemPageList = new PagedList<Entities.DgvTrnSalesOrderItemEntity>(stockOutItemData, ++stockOutItemPageNumber, stockOutItemPageSize);
                stockOutItemDataSource.DataSource = stockOutItemPageList;
            }

            buttonStockOutItemPageListFirst.Enabled = true;
            buttonStockOutItemPageListPrevious.Enabled = true;

            if (stockOutItemPageNumber == stockOutItemPageList.PageCount)
            {
                buttonStockOutItemPageListNext.Enabled = false;
                buttonStockOutItemPageListLast.Enabled = false;
            }

            textBoxStockOutItemPageNumber.Text = stockOutItemPageNumber + " / " + stockOutItemPageList.PageCount;
        }

        private void buttonStockOutItemPageListLast_Click(object sender, EventArgs e)
        {
            stockOutItemPageList = new PagedList<Entities.DgvTrnSalesOrderItemEntity>(stockOutItemData, stockOutItemPageList.PageCount, stockOutItemPageSize);
            stockOutItemDataSource.DataSource = stockOutItemPageList;

            buttonStockOutItemPageListFirst.Enabled = true;
            buttonStockOutItemPageListPrevious.Enabled = true;
            buttonStockOutItemPageListNext.Enabled = false;
            buttonStockOutItemPageListLast.Enabled = false;

            stockOutItemPageNumber = stockOutItemPageList.PageCount;
            textBoxStockOutItemPageNumber.Text = stockOutItemPageNumber + " / " + stockOutItemPageList.PageCount;
        }

        //private void buttonSearchItem_Click(object sender, EventArgs e)
        //{
        //    TrnStockOutDetailSearchItemForm trnStockOutDetailSearchItemForm = new TrnStockOutDetailSearchItemForm(this, trnSalesOrderEntity);
        //    trnStockOutDetailSearchItemForm.ShowDialog();
        //}

        //public void UpdateInventoryEntriesDataSource()
        //{
        //    SetInventoryEntriesDataSourceAsync();
        //}

        //public async void SetInventoryEntriesDataSourceAsync()
        //{
        //    List<Entities.DgvTrnInventoryEntriesEntity> getInventoryEntriesData = await GetInventoryEntriesDataTask();
        //    if (getInventoryEntriesData.Any())
        //    {
        //        inventoryEntriesData = getInventoryEntriesData;
        //        inventoryEntriesPageList = new PagedList<Entities.DgvTrnInventoryEntriesEntity>(inventoryEntriesData, inventoryEntriesPageNumber, inventoryEntriesPageSize);

        //        if (inventoryEntriesPageList.PageCount == 1)
        //        {
        //            buttonInventoryEntriesPageListFirst.Enabled = false;
        //            buttonInventoryEntriesPageListPrevious.Enabled = false;
        //            buttonInventoryEntriesPageListNext.Enabled = false;
        //            buttonInventoryEntriesPageListLast.Enabled = false;
        //        }
        //        else if (inventoryEntriesPageNumber == 1)
        //        {
        //            buttonInventoryEntriesPageListFirst.Enabled = false;
        //            buttonInventoryEntriesPageListPrevious.Enabled = false;
        //            buttonInventoryEntriesPageListNext.Enabled = true;
        //            buttonInventoryEntriesPageListLast.Enabled = true;
        //        }
        //        else if (inventoryEntriesPageNumber == inventoryEntriesPageList.PageCount)
        //        {
        //            buttonInventoryEntriesPageListFirst.Enabled = true;
        //            buttonInventoryEntriesPageListPrevious.Enabled = true;
        //            buttonInventoryEntriesPageListNext.Enabled = false;
        //            buttonInventoryEntriesPageListLast.Enabled = false;
        //        }
        //        else
        //        {
        //            buttonInventoryEntriesPageListFirst.Enabled = true;
        //            buttonInventoryEntriesPageListPrevious.Enabled = true;
        //            buttonInventoryEntriesPageListNext.Enabled = true;
        //            buttonInventoryEntriesPageListLast.Enabled = true;
        //        }

        //        textBoxInventoryEntriesPageNumber.Text = inventoryEntriesPageNumber + " / " + inventoryEntriesPageList.PageCount;
        //        inventoryEntriesDataSource.DataSource = inventoryEntriesPageList;
        //    }
        //    else
        //    {
        //        buttonInventoryEntriesPageListFirst.Enabled = false;
        //        buttonInventoryEntriesPageListPrevious.Enabled = false;
        //        buttonInventoryEntriesPageListNext.Enabled = false;
        //        buttonInventoryEntriesPageListLast.Enabled = false;

        //        inventoryEntriesPageNumber = 1;

        //        inventoryEntriesData = new List<Entities.DgvTrnInventoryEntriesEntity>();
        //        inventoryEntriesDataSource.Clear();
        //        textBoxInventoryEntriesPageNumber.Text = "1 / 1";
        //    }
        //}

        //public Task<List<Entities.DgvTrnInventoryEntriesEntity>> GetInventoryEntriesDataTask()
        //{
        //    Controllers.TrnInventoryController trnInventoryController = new Controllers.TrnInventoryController();

        //    List<Entities.TrnInventoryEntity> listInventoryEntries = trnInventoryController.ListStockOutInventoryEntries(trnSalesOrderEntity.Id);
        //    if (listInventoryEntries.Any())
        //    {
        //        var items = from d in listInventoryEntries
        //                    select new Entities.DgvTrnInventoryEntriesEntity
        //                    {
        //                        ColumnInventoryEntriesBranch = d.Branch,
        //                        ColumnInventoryEntriesInventoryDate = d.InventoryDate.ToShortDateString(),
        //                        ColumnInventoryEntriesItemDescription = d.ItemDescription,
        //                        ColumnInventoryEntriesInventoryCode = d.ItemInventoryCode,
        //                        ColumnInventoryEntriesQuantity = d.Quantity.ToString("#,##0.00"),
        //                        ColumnInventoryEntriesAmount = d.Amount.ToString("#,##0.00"),
        //                        ColumnInventoryEntriesSpace = ""
        //                    };

        //        return Task.FromResult(items.ToList());
        //    }
        //    else
        //    {
        //        return Task.FromResult(new List<Entities.DgvTrnInventoryEntriesEntity>());
        //    }
        //}

        //public void CreateInventoryEntriesDataGridView()
        //{
        //    UpdateInventoryEntriesDataSource();
        //    dataGridViewInventoryEntries.DataSource = inventoryEntriesDataSource;
        //}

        //public void GetInventoryEntriesCurrentSelectedCell(Int32 rowIndex)
        //{

        //}

        //private void buttonInventoryEntriesPageListFirst_Click(object sender, EventArgs e)
        //{
        //    inventoryEntriesPageList = new PagedList<Entities.DgvTrnInventoryEntriesEntity>(inventoryEntriesData, 1, inventoryEntriesPageSize);
        //    inventoryEntriesDataSource.DataSource = inventoryEntriesPageList;

        //    buttonInventoryEntriesPageListFirst.Enabled = false;
        //    buttonInventoryEntriesPageListPrevious.Enabled = false;
        //    buttonInventoryEntriesPageListNext.Enabled = true;
        //    buttonInventoryEntriesPageListLast.Enabled = true;

        //    inventoryEntriesPageNumber = 1;
        //    textBoxInventoryEntriesPageNumber.Text = inventoryEntriesPageNumber + " / " + inventoryEntriesPageList.PageCount;
        //}

        //private void buttonInventoryEntriesPageListPrevious_Click(object sender, EventArgs e)
        //{
        //    if (inventoryEntriesPageList.HasPreviousPage == true)
        //    {
        //        inventoryEntriesPageList = new PagedList<Entities.DgvTrnInventoryEntriesEntity>(inventoryEntriesData, --inventoryEntriesPageNumber, inventoryEntriesPageSize);
        //        inventoryEntriesDataSource.DataSource = inventoryEntriesPageList;
        //    }

        //    buttonInventoryEntriesPageListNext.Enabled = true;
        //    buttonInventoryEntriesPageListLast.Enabled = true;

        //    if (inventoryEntriesPageNumber == 1)
        //    {
        //        buttonInventoryEntriesPageListFirst.Enabled = false;
        //        buttonInventoryEntriesPageListPrevious.Enabled = false;
        //    }

        //    textBoxInventoryEntriesPageNumber.Text = inventoryEntriesPageNumber + " / " + inventoryEntriesPageList.PageCount;
        //}

        //private void buttonInventoryEntriesPageListNext_Click(object sender, EventArgs e)
        //{
        //    if (inventoryEntriesPageList.HasNextPage == true)
        //    {
        //        inventoryEntriesPageList = new PagedList<Entities.DgvTrnInventoryEntriesEntity>(inventoryEntriesData, ++inventoryEntriesPageNumber, inventoryEntriesPageSize);
        //        inventoryEntriesDataSource.DataSource = inventoryEntriesPageList;
        //    }

        //    buttonInventoryEntriesPageListFirst.Enabled = true;
        //    buttonInventoryEntriesPageListPrevious.Enabled = true;

        //    if (inventoryEntriesPageNumber == inventoryEntriesPageList.PageCount)
        //    {
        //        buttonInventoryEntriesPageListNext.Enabled = false;
        //        buttonInventoryEntriesPageListLast.Enabled = false;
        //    }

        //    textBoxInventoryEntriesPageNumber.Text = inventoryEntriesPageNumber + " / " + inventoryEntriesPageList.PageCount;
        //}

        //private void buttonInventoryEntriesPageListLast_Click(object sender, EventArgs e)
        //{
        //    inventoryEntriesPageList = new PagedList<Entities.DgvTrnInventoryEntriesEntity>(inventoryEntriesData, inventoryEntriesPageList.PageCount, inventoryEntriesPageSize);
        //    inventoryEntriesDataSource.DataSource = inventoryEntriesPageList;

        //    buttonInventoryEntriesPageListFirst.Enabled = true;
        //    buttonInventoryEntriesPageListPrevious.Enabled = true;
        //    buttonInventoryEntriesPageListNext.Enabled = false;
        //    buttonInventoryEntriesPageListLast.Enabled = false;

        //    inventoryEntriesPageNumber = inventoryEntriesPageList.PageCount;
        //    textBoxInventoryEntriesPageNumber.Text = inventoryEntriesPageNumber + " / " + inventoryEntriesPageList.PageCount;
        //}
    }
}
