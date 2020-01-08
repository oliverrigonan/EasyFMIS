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

namespace easyfmis.Forms.Software.TrnReceivingReceipt
{
    public partial class TrnReceivingReceiptDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        public TrnReceivingReceiptForm trnReceivingReceiptForm;
        public Entities.TrnReceivingReceiptEntity trnReceivingReceiptEntity;

        public static List<Entities.DgvReceivingReceiptItemEntity> receivingReceiptItemData = new List<Entities.DgvReceivingReceiptItemEntity>();
        public static Int32 receivingReceiptItemPageNumber = 1;
        public static Int32 receivingReceiptItemPageSize = 50;
        public PagedList<Entities.DgvReceivingReceiptItemEntity> receivingReceiptItemPageList = new PagedList<Entities.DgvReceivingReceiptItemEntity>(receivingReceiptItemData, receivingReceiptItemPageNumber, receivingReceiptItemPageSize);
        public BindingSource receivingReceiptItemDataSource = new BindingSource();

        public static List<Entities.DgvTrnInventoryEntriesEntity> inventoryEntriesData = new List<Entities.DgvTrnInventoryEntriesEntity>();
        public static Int32 inventoryEntriesPageNumber = 1;
        public static Int32 inventoryEntriesPageSize = 50;
        public PagedList<Entities.DgvTrnInventoryEntriesEntity> inventoryEntriesPageList = new PagedList<Entities.DgvTrnInventoryEntriesEntity>(inventoryEntriesData, inventoryEntriesPageNumber, inventoryEntriesPageSize);
        public BindingSource inventoryEntriesDataSource = new BindingSource();

        public TrnReceivingReceiptDetailForm(SysSoftwareForm softwareForm, TrnReceivingReceiptForm receivingReceiptListForm, Entities.TrnReceivingReceiptEntity receivingReceiptEntity)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            trnReceivingReceiptForm = receivingReceiptListForm;
            trnReceivingReceiptEntity = receivingReceiptEntity;

            GetSupplierList();
        }

        public void GetSupplierList()
        {
            Controllers.TrnReceivingReceiptController trnReceivingReceiptController = new Controllers.TrnReceivingReceiptController();
            if (trnReceivingReceiptController.DropdownListReceivingReceiptSupplier().Any())
            {
                comboBoxSupplier.DataSource = trnReceivingReceiptController.DropdownListReceivingReceiptSupplier();
                comboBoxSupplier.ValueMember = "Id";
                comboBoxSupplier.DisplayMember = "Article";

                GetTermList();
            }
        }

        public void GetTermList()
        {
            Controllers.TrnReceivingReceiptController trnReceivingReceiptController = new Controllers.TrnReceivingReceiptController();
            if (trnReceivingReceiptController.DropdownListReceivingReceiptTerm().Any())
            {
                comboBoxTerm.DataSource = trnReceivingReceiptController.DropdownListReceivingReceiptTerm();
                comboBoxTerm.ValueMember = "Id";
                comboBoxTerm.DisplayMember = "Term";

                GetUserList();
            }
        }

        public void GetUserList()
        {
            Controllers.TrnReceivingReceiptController trnReceivingReceiptController = new Controllers.TrnReceivingReceiptController();
            if (trnReceivingReceiptController.DropdownListReceivingReceiptUser().Any())
            {
                comboBoxReceivedBy.DataSource = trnReceivingReceiptController.DropdownListReceivingReceiptUser();
                comboBoxReceivedBy.ValueMember = "Id";
                comboBoxReceivedBy.DisplayMember = "FullName";

                comboBoxPreparedBy.DataSource = trnReceivingReceiptController.DropdownListReceivingReceiptUser();
                comboBoxPreparedBy.ValueMember = "Id";
                comboBoxPreparedBy.DisplayMember = "FullName";

                comboBoxCheckedBy.DataSource = trnReceivingReceiptController.DropdownListReceivingReceiptUser();
                comboBoxCheckedBy.ValueMember = "Id";
                comboBoxCheckedBy.DisplayMember = "FullName";

                comboBoxApprovedBy.DataSource = trnReceivingReceiptController.DropdownListReceivingReceiptUser();
                comboBoxApprovedBy.ValueMember = "Id";
                comboBoxApprovedBy.DisplayMember = "FullName";

                GetReceivingReceiptDetail();
            }
        }

        public void GetReceivingReceiptDetail()
        {
            UpdateComponents(trnReceivingReceiptEntity.IsLocked);

            textBoxBranch.Text = trnReceivingReceiptEntity.Branch;
            textBoxRRNumber.Text = trnReceivingReceiptEntity.RRNumber;
            dateTimePickerRRDate.Value = trnReceivingReceiptEntity.RRDate;
            textBoxManualRRNumber.Text = trnReceivingReceiptEntity.ManualRRNumber;
            comboBoxSupplier.SelectedValue = trnReceivingReceiptEntity.SupplierId;
            comboBoxTerm.SelectedValue = trnReceivingReceiptEntity.TermId;
            textBoxRemarks.Text = trnReceivingReceiptEntity.Remarks;
            comboBoxReceivedBy.SelectedValue = trnReceivingReceiptEntity.ReceivedBy;
            comboBoxPreparedBy.SelectedValue = trnReceivingReceiptEntity.PreparedBy;
            comboBoxCheckedBy.SelectedValue = trnReceivingReceiptEntity.CheckedBy;
            comboBoxApprovedBy.SelectedValue = trnReceivingReceiptEntity.ApprovedBy;

            CreateReceivingReceiptItemDataGridView();
            CreateInventoryEntriesDataGridView();
        }

        public void UpdateComponents(Boolean isLocked)
        {
            buttonLock.Enabled = !isLocked;
            buttonUnlock.Enabled = isLocked;
            buttonPrint.Enabled = isLocked;

            buttonSearchPurchaseOrderItem.Enabled = !isLocked;

            textBoxBranch.Enabled = !isLocked;
            textBoxRRNumber.Enabled = !isLocked;
            dateTimePickerRRDate.Enabled = !isLocked;
            textBoxManualRRNumber.Enabled = !isLocked;
            comboBoxSupplier.Enabled = !isLocked;
            comboBoxTerm.Enabled = !isLocked;
            textBoxRemarks.Enabled = !isLocked;
            comboBoxReceivedBy.Enabled = !isLocked;
            comboBoxCheckedBy.Enabled = !isLocked;
            comboBoxApprovedBy.Enabled = !isLocked;

            dataGridViewReceivingReceiptItem.Columns[0].Visible = !isLocked;
            dataGridViewReceivingReceiptItem.Columns[1].Visible = !isLocked;
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            Entities.TrnReceivingReceiptEntity newReceivingReceiptEntity = new Entities.TrnReceivingReceiptEntity()
            {
                RRDate = dateTimePickerRRDate.Value.Date,
                ManualRRNumber = textBoxManualRRNumber.Text,
                SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue),
                TermId = Convert.ToInt32(comboBoxTerm.SelectedValue),
                Remarks = textBoxRemarks.Text,
                ReceivedBy = Convert.ToInt32(comboBoxReceivedBy.SelectedValue),
                CheckedBy = Convert.ToInt32(comboBoxCheckedBy.SelectedValue),
                ApprovedBy = Convert.ToInt32(comboBoxApprovedBy.SelectedValue)
            };

            Controllers.TrnReceivingReceiptController trnReceivingReceiptController = new Controllers.TrnReceivingReceiptController();
            String[] lockReceivingReceipt = trnReceivingReceiptController.LockReceivingReceipt(trnReceivingReceiptEntity.Id, newReceivingReceiptEntity);

            if (lockReceivingReceipt[1].Equals("0") == false)
            {
                UpdateComponents(true);
                trnReceivingReceiptForm.UpdateReceivingReceiptDataSource();

                UpdateInventoryEntriesDataSource();
            }
            else
            {
                MessageBox.Show(lockReceivingReceipt[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            Controllers.TrnReceivingReceiptController trnReceivingReceiptController = new Controllers.TrnReceivingReceiptController();
            String[] unlockReceivingReceipt = trnReceivingReceiptController.UnlockReceivingReceipt(trnReceivingReceiptEntity.Id);

            if (unlockReceivingReceipt[1].Equals("0") == false)
            {
                UpdateComponents(false);
                trnReceivingReceiptForm.UpdateReceivingReceiptDataSource();

                UpdateInventoryEntriesDataSource();
            }
            else
            {
                MessageBox.Show(unlockReceivingReceipt[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            new TrnReceivingReceiptDetailPrintPreviewForm(trnReceivingReceiptEntity.Id);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
            sysSoftwareForm.RemoveTabPage();
        }

        public void UpdateReceivingReceiptItemDataSource()
        {
            SetReceivingReceiptItemDataSourceAsync();
        }

        public async void SetReceivingReceiptItemDataSourceAsync()
        {
            List<Entities.DgvReceivingReceiptItemEntity> getReceivingReceiptItemData = await GetReceivingReceiptItemDataTask();
            if (getReceivingReceiptItemData.Any())
            {
                receivingReceiptItemPageNumber = 1;
                receivingReceiptItemData = getReceivingReceiptItemData;
                receivingReceiptItemPageList = new PagedList<Entities.DgvReceivingReceiptItemEntity>(receivingReceiptItemData, receivingReceiptItemPageNumber, receivingReceiptItemPageSize);

                if (receivingReceiptItemPageList.PageCount == 1)
                {
                    buttonReceivingReceiptItemPageListFirst.Enabled = false;
                    buttonReceivingReceiptItemPageListPrevious.Enabled = false;
                    buttonReceivingReceiptItemPageListNext.Enabled = false;
                    buttonReceivingReceiptItemPageListLast.Enabled = false;
                }
                else if (receivingReceiptItemPageNumber == 1)
                {
                    buttonReceivingReceiptItemPageListFirst.Enabled = false;
                    buttonReceivingReceiptItemPageListPrevious.Enabled = false;
                    buttonReceivingReceiptItemPageListNext.Enabled = true;
                    buttonReceivingReceiptItemPageListLast.Enabled = true;
                }
                else if (receivingReceiptItemPageNumber == receivingReceiptItemPageList.PageCount)
                {
                    buttonReceivingReceiptItemPageListFirst.Enabled = true;
                    buttonReceivingReceiptItemPageListPrevious.Enabled = true;
                    buttonReceivingReceiptItemPageListNext.Enabled = false;
                    buttonReceivingReceiptItemPageListLast.Enabled = false;
                }
                else
                {
                    buttonReceivingReceiptItemPageListFirst.Enabled = true;
                    buttonReceivingReceiptItemPageListPrevious.Enabled = true;
                    buttonReceivingReceiptItemPageListNext.Enabled = true;
                    buttonReceivingReceiptItemPageListLast.Enabled = true;
                }

                textBoxReceivingReceiptItemPageNumber.Text = receivingReceiptItemPageNumber + " / " + receivingReceiptItemPageList.PageCount;
                receivingReceiptItemDataSource.DataSource = receivingReceiptItemPageList;
            }
            else
            {
                buttonReceivingReceiptItemPageListFirst.Enabled = false;
                buttonReceivingReceiptItemPageListPrevious.Enabled = false;
                buttonReceivingReceiptItemPageListNext.Enabled = false;
                buttonReceivingReceiptItemPageListLast.Enabled = false;

                receivingReceiptItemPageNumber = 1;

                receivingReceiptItemData = new List<Entities.DgvReceivingReceiptItemEntity>();
                receivingReceiptItemDataSource.Clear();
                textBoxReceivingReceiptItemPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvReceivingReceiptItemEntity>> GetReceivingReceiptItemDataTask()
        {
            Controllers.TrnReceivingReceiptItemController trnReceivingReceiptItemController = new Controllers.TrnReceivingReceiptItemController();

            List<Entities.TrnReceivingReceiptItemEntity> listReceivingReceiptItem = trnReceivingReceiptItemController.ListReceivingReceiptItem(trnReceivingReceiptEntity.Id);
            if (listReceivingReceiptItem.Any())
            {
                var items = from d in listReceivingReceiptItem
                            select new Entities.DgvReceivingReceiptItemEntity
                            {
                                ColumnReceivingReceiptItemListButtonEdit = "Edit",
                                ColumnReceivingReceiptItemListButtonDelete = "Delete",
                                ColumnReceivingReceiptItemListId = d.Id,
                                ColumnReceivingReceiptItemListRRId = d.RRId,
                                ColumnReceivingReceiptItemListPOId = d.POId,
                                ColumnReceivingReceiptItemListPONumber = d.PONumber,
                                ColumnReceivingReceiptItemListItemId = d.ItemId,
                                ColumnReceivingReceiptItemListItemDescription = d.ItemDescription,
                                ColumnReceivingReceiptItemListUnitId = d.UnitId,
                                ColumnReceivingReceiptItemListUnit = d.Unit,
                                ColumnReceivingReceiptItemListQuantity = d.Quantity.ToString("#,##0.00"),
                                ColumnReceivingReceiptItemListCost = d.Cost.ToString("#,##0.00"),
                                ColumnReceivingReceiptItemListAmount = d.Amount.ToString("#,##0.00"),
                                ColumnReceivingReceiptItemListBranchId = d.BranchId,
                                ColumnReceivingReceiptItemListBranch = d.Branch,
                                ColumnReceivingReceiptItemListTaxId = d.TaxId,
                                ColumnReceivingReceiptItemListTax = d.Tax,
                                ColumnReceivingReceiptItemListTaxRate = d.TaxRate.ToString("#,##0.00"),
                                ColumnReceivingReceiptItemListTaxAmount = d.TaxAmount.ToString("#,##0.00"),
                                ColumnReceivingReceiptItemListBaseCost = d.BaseCost.ToString("#,##0.00"),
                                ColumnReceivingReceiptItemListBaseQuantity = d.BaseQuantity.ToString("#,##0.00"),
                                ColumnReceivingReceiptItemListSpace = ""
                            };

                textBoxTotalRRAmount.Text = listReceivingReceiptItem.Sum(d => d.Amount).ToString("#,##0.00");

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvReceivingReceiptItemEntity>());
            }
        }

        public void CreateReceivingReceiptItemDataGridView()
        {
            UpdateReceivingReceiptItemDataSource();

            dataGridViewReceivingReceiptItem.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewReceivingReceiptItem.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewReceivingReceiptItem.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewReceivingReceiptItem.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewReceivingReceiptItem.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewReceivingReceiptItem.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewReceivingReceiptItem.DataSource = receivingReceiptItemDataSource;
        }

        public void GetReceivingReceiptItemCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewReceivingReceiptItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetReceivingReceiptItemCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewReceivingReceiptItem.CurrentCell.ColumnIndex == dataGridViewReceivingReceiptItem.Columns["ColumnReceivingReceiptItemListButtonEdit"].Index)
            {
                var id = Convert.ToInt32(dataGridViewReceivingReceiptItem.Rows[e.RowIndex].Cells[dataGridViewReceivingReceiptItem.Columns["ColumnReceivingReceiptItemListId"].Index].Value);
                var RRId = Convert.ToInt32(dataGridViewReceivingReceiptItem.Rows[e.RowIndex].Cells[dataGridViewReceivingReceiptItem.Columns["ColumnReceivingReceiptItemListRRId"].Index].Value);
                var POId = Convert.ToInt32(dataGridViewReceivingReceiptItem.Rows[e.RowIndex].Cells[dataGridViewReceivingReceiptItem.Columns["ColumnReceivingReceiptItemListPOId"].Index].Value);
                var itemId = Convert.ToInt32(dataGridViewReceivingReceiptItem.Rows[e.RowIndex].Cells[dataGridViewReceivingReceiptItem.Columns["ColumnReceivingReceiptItemListItemId"].Index].Value);
                var itemDescription = dataGridViewReceivingReceiptItem.Rows[e.RowIndex].Cells[dataGridViewReceivingReceiptItem.Columns["ColumnReceivingReceiptItemListItemDescription"].Index].Value.ToString();
                var unitId = Convert.ToInt32(dataGridViewReceivingReceiptItem.Rows[e.RowIndex].Cells[dataGridViewReceivingReceiptItem.Columns["ColumnReceivingReceiptItemListUnitId"].Index].Value);
                var quantity = Convert.ToDecimal(dataGridViewReceivingReceiptItem.Rows[e.RowIndex].Cells[dataGridViewReceivingReceiptItem.Columns["ColumnReceivingReceiptItemListQuantity"].Index].Value);
                var cost = Convert.ToDecimal(dataGridViewReceivingReceiptItem.Rows[e.RowIndex].Cells[dataGridViewReceivingReceiptItem.Columns["ColumnReceivingReceiptItemListCost"].Index].Value);
                var amount = Convert.ToDecimal(dataGridViewReceivingReceiptItem.Rows[e.RowIndex].Cells[dataGridViewReceivingReceiptItem.Columns["ColumnReceivingReceiptItemListAmount"].Index].Value);
                var branchId = Convert.ToInt32(dataGridViewReceivingReceiptItem.Rows[e.RowIndex].Cells[dataGridViewReceivingReceiptItem.Columns["ColumnReceivingReceiptItemListBranchId"].Index].Value);
                var taxId = Convert.ToInt32(dataGridViewReceivingReceiptItem.Rows[e.RowIndex].Cells[dataGridViewReceivingReceiptItem.Columns["ColumnReceivingReceiptItemListTaxId"].Index].Value);
                var taxRate = Convert.ToDecimal(dataGridViewReceivingReceiptItem.Rows[e.RowIndex].Cells[dataGridViewReceivingReceiptItem.Columns["ColumnReceivingReceiptItemListTaxRate"].Index].Value);
                var taxAmount = Convert.ToDecimal(dataGridViewReceivingReceiptItem.Rows[e.RowIndex].Cells[dataGridViewReceivingReceiptItem.Columns["ColumnReceivingReceiptItemListTaxAmount"].Index].Value);

                Entities.TrnReceivingReceiptItemEntity trnReceivingReceiptItemEntity = new Entities.TrnReceivingReceiptItemEntity()
                {
                    Id = id,
                    RRId = RRId,
                    POId = POId,
                    ItemId = itemId,
                    ItemDescription = itemDescription,
                    UnitId = unitId,
                    Quantity = 1,
                    Cost = 0,
                    TaxId = taxId,
                    TaxRate = taxRate,
                    TaxAmount = 0,
                    BranchId = branchId,
                    Amount = 0,
                    BaseCost = 0,
                    BaseQuantity = 0
                };

                TrnReceivingReceiptDetailReceivingReceiptItemDetailForm trnReceivingReceiptDetailReceivingReceiptItemDetailForm = new TrnReceivingReceiptDetailReceivingReceiptItemDetailForm(this, trnReceivingReceiptItemEntity);
                trnReceivingReceiptDetailReceivingReceiptItemDetailForm.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewReceivingReceiptItem.CurrentCell.ColumnIndex == dataGridViewReceivingReceiptItem.Columns["ColumnReceivingReceiptItemListButtonDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete Stock-In?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(dataGridViewReceivingReceiptItem.Rows[e.RowIndex].Cells[dataGridViewReceivingReceiptItem.Columns["ColumnReceivingReceiptItemListId"].Index].Value);

                    Controllers.TrnReceivingReceiptItemController trnReceivingReceiptItemController = new Controllers.TrnReceivingReceiptItemController();
                    String[] deleteReceivingReceiptItem = trnReceivingReceiptItemController.DeleteReceivingReceiptItem(id);
                    if (deleteReceivingReceiptItem[1].Equals("0") == false)
                    {
                        receivingReceiptItemPageNumber = 1;
                        UpdateReceivingReceiptItemDataSource();
                    }
                    else
                    {
                        MessageBox.Show(deleteReceivingReceiptItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonReceivingReceiptItemPageListFirst_Click(object sender, EventArgs e)
        {
            receivingReceiptItemPageList = new PagedList<Entities.DgvReceivingReceiptItemEntity>(receivingReceiptItemData, 1, receivingReceiptItemPageSize);
            receivingReceiptItemDataSource.DataSource = receivingReceiptItemPageList;

            buttonReceivingReceiptItemPageListFirst.Enabled = false;
            buttonReceivingReceiptItemPageListPrevious.Enabled = false;
            buttonReceivingReceiptItemPageListNext.Enabled = true;
            buttonReceivingReceiptItemPageListLast.Enabled = true;

            receivingReceiptItemPageNumber = 1;
            textBoxReceivingReceiptItemPageNumber.Text = receivingReceiptItemPageNumber + " / " + receivingReceiptItemPageList.PageCount;
        }

        private void buttonReceivingReceiptItemPageListPrevious_Click(object sender, EventArgs e)
        {
            if (receivingReceiptItemPageList.HasPreviousPage == true)
            {
                receivingReceiptItemPageList = new PagedList<Entities.DgvReceivingReceiptItemEntity>(receivingReceiptItemData, --receivingReceiptItemPageNumber, receivingReceiptItemPageSize);
                receivingReceiptItemDataSource.DataSource = receivingReceiptItemPageList;
            }

            buttonReceivingReceiptItemPageListNext.Enabled = true;
            buttonReceivingReceiptItemPageListLast.Enabled = true;

            if (receivingReceiptItemPageNumber == 1)
            {
                buttonReceivingReceiptItemPageListFirst.Enabled = false;
                buttonReceivingReceiptItemPageListPrevious.Enabled = false;
            }

            textBoxReceivingReceiptItemPageNumber.Text = receivingReceiptItemPageNumber + " / " + receivingReceiptItemPageList.PageCount;
        }

        private void buttonReceivingReceiptItemPageListNext_Click(object sender, EventArgs e)
        {
            if (receivingReceiptItemPageList.HasNextPage == true)
            {
                receivingReceiptItemPageList = new PagedList<Entities.DgvReceivingReceiptItemEntity>(receivingReceiptItemData, ++receivingReceiptItemPageNumber, receivingReceiptItemPageSize);
                receivingReceiptItemDataSource.DataSource = receivingReceiptItemPageList;
            }

            buttonReceivingReceiptItemPageListFirst.Enabled = true;
            buttonReceivingReceiptItemPageListPrevious.Enabled = true;

            if (receivingReceiptItemPageNumber == receivingReceiptItemPageList.PageCount)
            {
                buttonReceivingReceiptItemPageListNext.Enabled = false;
                buttonReceivingReceiptItemPageListLast.Enabled = false;
            }

            textBoxReceivingReceiptItemPageNumber.Text = receivingReceiptItemPageNumber + " / " + receivingReceiptItemPageList.PageCount;
        }

        private void buttonReceivingReceiptItemPageListLast_Click(object sender, EventArgs e)
        {
            receivingReceiptItemPageList = new PagedList<Entities.DgvReceivingReceiptItemEntity>(receivingReceiptItemData, receivingReceiptItemPageList.PageCount, receivingReceiptItemPageSize);
            receivingReceiptItemDataSource.DataSource = receivingReceiptItemPageList;

            buttonReceivingReceiptItemPageListFirst.Enabled = true;
            buttonReceivingReceiptItemPageListPrevious.Enabled = true;
            buttonReceivingReceiptItemPageListNext.Enabled = false;
            buttonReceivingReceiptItemPageListLast.Enabled = false;

            receivingReceiptItemPageNumber = receivingReceiptItemPageList.PageCount;
            textBoxReceivingReceiptItemPageNumber.Text = receivingReceiptItemPageNumber + " / " + receivingReceiptItemPageList.PageCount;
        }

        private void buttonSearchPurchaseOrderItem_Click(object sender, EventArgs e)
        {
            TrnReceivingReceiptDetailSearchPurchaseOrderItemForm trnReceivingReceiptDetailSearchPurchaseOrderItemForm = new TrnReceivingReceiptDetailSearchPurchaseOrderItemForm(this, trnReceivingReceiptEntity);
            trnReceivingReceiptDetailSearchPurchaseOrderItemForm.ShowDialog();
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

            List<Entities.TrnInventoryEntity> listInventoryEntries = trnInventoryController.ListReceivingReceiptInventoryEntries(trnReceivingReceiptEntity.Id);
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
