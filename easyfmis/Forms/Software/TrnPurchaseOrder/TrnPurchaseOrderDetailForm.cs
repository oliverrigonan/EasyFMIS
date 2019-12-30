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

namespace easyfmis.Forms.Software.TrnPurchaseOrder
{
    public partial class TrnPurchaseOrderDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        TrnPurchaseOrderForm trnPurchaseOrderForm;
        public Entities.TrnPurchaseOrderEntity trnPurchaseOrderEntity;

        public static List<Entities.DgvPurchaseOrderItemEntity> purchaseOrderItemData = new List<Entities.DgvPurchaseOrderItemEntity>();
        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;
        public PagedList<Entities.DgvPurchaseOrderItemEntity> purchaseOrderItemPageSize = new PagedList<Entities.DgvPurchaseOrderItemEntity>(purchaseOrderItemData, pageNumber, pageSize);
        public BindingSource purchaseOrderItemDataSource = new BindingSource();

        public TrnPurchaseOrderDetailForm(SysSoftwareForm softwareForm, TrnPurchaseOrderForm purchaseOrderForm, Entities.TrnPurchaseOrderEntity purchaseOrderEntity)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            trnPurchaseOrderForm = purchaseOrderForm;
            trnPurchaseOrderEntity = purchaseOrderEntity;

            GetSupplierList();
        }

        public void GetSupplierList()
        {
            Controllers.TrnPurchaseOrderController trnPurchaseOrderController = new Controllers.TrnPurchaseOrderController();
            var supplier = trnPurchaseOrderController.DropdownListPurchaseOrderSupplier();
            if (supplier.Any())
            {
                comboBoxSupplier.DataSource = supplier;
                comboBoxSupplier.ValueMember = "Id";
                comboBoxSupplier.DisplayMember = "Article";

                GetTermList();
            }
        }

        public void GetTermList()
        {
            Controllers.TrnPurchaseOrderController trnPurchaseOrderController = new Controllers.TrnPurchaseOrderController();
            var term = trnPurchaseOrderController.DropdownListPurchaseOrderTerm();
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
            Controllers.TrnPurchaseOrderController trnPurchaseOrderController = new Controllers.TrnPurchaseOrderController();
            var user = trnPurchaseOrderController.DropdownListPurchaseOrderUser();
            if (user.Any())
            {
                comboBoxRequestedBy.DataSource = user;
                comboBoxRequestedBy.ValueMember = "Id";
                comboBoxRequestedBy.DisplayMember = "FullName";

                comboBoxPreparedBy.DataSource = user;
                comboBoxPreparedBy.ValueMember = "Id";
                comboBoxPreparedBy.DisplayMember = "FullName";

                comboBoxCheckedBy.DataSource = user;
                comboBoxCheckedBy.ValueMember = "Id";
                comboBoxCheckedBy.DisplayMember = "FullName";

                comboBoxApprovedBy.DataSource = user;
                comboBoxApprovedBy.ValueMember = "Id";
                comboBoxApprovedBy.DisplayMember = "FullName";

                GetPurchaseOrderDetail();
            }
        }

        public void GetPurchaseOrderDetail()
        {
            UpdateComponents(trnPurchaseOrderEntity.IsLocked);

            textBoxBranch.Text = trnPurchaseOrderEntity.Branch;
            textBoxPONumber.Text = trnPurchaseOrderEntity.PONumber;
            dateTimePickerPODate.Value = trnPurchaseOrderEntity.PODate;
            dateTimePickerDateNeeded.Value = trnPurchaseOrderEntity.DateNeeded;
            textBoxManualPONumber.Text = trnPurchaseOrderEntity.ManualPONumber;
            comboBoxSupplier.SelectedValue = trnPurchaseOrderEntity.SupplierId;
            comboBoxTerm.SelectedValue = trnPurchaseOrderEntity.TermId;
            textBoxRemarks.Text = trnPurchaseOrderEntity.Remarks;
            comboBoxRequestedBy.SelectedValue = trnPurchaseOrderEntity.RequestedBy;
            comboBoxPreparedBy.SelectedValue = trnPurchaseOrderEntity.PreparedBy;
            comboBoxCheckedBy.SelectedValue = trnPurchaseOrderEntity.CheckedBy;
            comboBoxApprovedBy.SelectedValue = trnPurchaseOrderEntity.ApprovedBy;
            checkBoxIsClosed.Checked = trnPurchaseOrderEntity.IsClose;

            CreatePurchaseOrderItemDataGridView();
        }

        public void UpdateComponents(Boolean isLocked)
        {
            buttonLock.Enabled = !isLocked;
            buttonUnlock.Enabled = isLocked;
            buttonPrint.Enabled = isLocked;

            buttonSearchItem.Enabled = !isLocked;

            textBoxBranch.Enabled = !isLocked;
            textBoxPONumber.Enabled = !isLocked;
            dateTimePickerPODate.Enabled = !isLocked;
            dateTimePickerDateNeeded.Enabled = !isLocked;
            textBoxManualPONumber.Enabled = !isLocked;
            comboBoxSupplier.Enabled = !isLocked;
            comboBoxTerm.Enabled = !isLocked;
            textBoxRemarks.Enabled = !isLocked;
            comboBoxRequestedBy.Enabled = !isLocked;
            comboBoxPreparedBy.Enabled = !isLocked;
            comboBoxCheckedBy.Enabled = !isLocked;
            comboBoxApprovedBy.Enabled = !isLocked;
            checkBoxIsClosed.Enabled = !isLocked;

            dataGridViewPurchaseOrderItem.Columns[0].Visible = !isLocked;
            dataGridViewPurchaseOrderItem.Columns[1].Visible = !isLocked;
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            Controllers.TrnPurchaseOrderController trnPurchaseOrderController = new Controllers.TrnPurchaseOrderController();

            Entities.TrnPurchaseOrderEntity purchaseOrderEntity = new Entities.TrnPurchaseOrderEntity()
            {
                Id = trnPurchaseOrderEntity.Id,
                BranchId = trnPurchaseOrderEntity.BranchId,
                PONumber = trnPurchaseOrderEntity.PONumber,
                PODate = dateTimePickerPODate.Value.Date,
                ManualPONumber = textBoxManualPONumber.Text,
                SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue),
                TermId = Convert.ToInt32(comboBoxTerm.SelectedValue),
                DateNeeded = dateTimePickerDateNeeded.Value.Date,
                Remarks = textBoxRemarks.Text,
                IsClose = checkBoxIsClosed.Checked,
                RequestedBy = Convert.ToInt32(comboBoxRequestedBy.SelectedValue),
                PreparedBy = Convert.ToInt32(comboBoxPreparedBy.SelectedValue),
                CheckedBy = Convert.ToInt32(comboBoxCheckedBy.SelectedValue),
                ApprovedBy = Convert.ToInt32(comboBoxApprovedBy.SelectedValue),
            };

            String[] lockPurchaseOrder = trnPurchaseOrderController.LockPurchaseOrder(trnPurchaseOrderEntity.Id, purchaseOrderEntity);
            if (lockPurchaseOrder[1].Equals("0") == false)
            {
                UpdateComponents(true);
                trnPurchaseOrderForm.UpdatePurchaseOrderDataSource();
            }
            else
            {
                MessageBox.Show(lockPurchaseOrder[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            Controllers.TrnPurchaseOrderController trnPurchaseOrderController = new Controllers.TrnPurchaseOrderController();

            String[] unlockPurchaseOrder = trnPurchaseOrderController.UnlockPurchaseOrder(trnPurchaseOrderEntity.Id);
            if (unlockPurchaseOrder[1].Equals("0") == false)
            {
                UpdateComponents(false);
                trnPurchaseOrderForm.UpdatePurchaseOrderDataSource();
            }
            else
            {
                MessageBox.Show(unlockPurchaseOrder[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void UpdatePurchaseOrderItemDataSource()
        {
            SetStockOutItemDataSourceAsync();
        }

        public async void SetStockOutItemDataSourceAsync()
        {
            List<Entities.DgvPurchaseOrderItemEntity> getStockOutItemData = await GetPurchaseOrderItemDataTask();
            if (getStockOutItemData.Any())
            {
                purchaseOrderItemData = getStockOutItemData;
                purchaseOrderItemPageSize = new PagedList<Entities.DgvPurchaseOrderItemEntity>(purchaseOrderItemData, pageNumber, pageSize);

                if (purchaseOrderItemPageSize.PageCount == 1)
                {
                    buttonPurchaseOrderItemPageListFirst.Enabled = false;
                    buttonPurchaseOrderItemPageListPrevious.Enabled = false;
                    buttonPurchaseOrderItemPageListNext.Enabled = false;
                    buttonPurchaseOrderItemPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonPurchaseOrderItemPageListFirst.Enabled = false;
                    buttonPurchaseOrderItemPageListPrevious.Enabled = false;
                    buttonPurchaseOrderItemPageListNext.Enabled = true;
                    buttonPurchaseOrderItemPageListLast.Enabled = true;
                }
                else if (pageNumber == purchaseOrderItemPageSize.PageCount)
                {
                    buttonPurchaseOrderItemPageListFirst.Enabled = true;
                    buttonPurchaseOrderItemPageListPrevious.Enabled = true;
                    buttonPurchaseOrderItemPageListNext.Enabled = false;
                    buttonPurchaseOrderItemPageListLast.Enabled = false;
                }
                else
                {
                    buttonPurchaseOrderItemPageListFirst.Enabled = true;
                    buttonPurchaseOrderItemPageListPrevious.Enabled = true;
                    buttonPurchaseOrderItemPageListNext.Enabled = true;
                    buttonPurchaseOrderItemPageListLast.Enabled = true;
                }

                textBoxPurchaseOrderItemPageNumber.Text = pageNumber + " / " + purchaseOrderItemPageSize.PageCount;
                purchaseOrderItemDataSource.DataSource = purchaseOrderItemPageSize;
            }
            else
            {
                buttonPurchaseOrderItemPageListFirst.Enabled = false;
                buttonPurchaseOrderItemPageListPrevious.Enabled = false;
                buttonPurchaseOrderItemPageListNext.Enabled = false;
                buttonPurchaseOrderItemPageListLast.Enabled = false;

                pageNumber = 1;

                purchaseOrderItemData = new List<Entities.DgvPurchaseOrderItemEntity>();
                purchaseOrderItemDataSource.Clear();
                textBoxPurchaseOrderItemPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvPurchaseOrderItemEntity>> GetPurchaseOrderItemDataTask()
        {
            Controllers.TrnPurchaseOrderItemController trnPurchaseOrderItemController = new Controllers.TrnPurchaseOrderItemController();

            List<Entities.TrnPurchaseOrderItemEntity> listPurchaseOrderItem = trnPurchaseOrderItemController.ListPurchaseOrderItem(trnPurchaseOrderEntity.Id);
            if (listPurchaseOrderItem.Any())
            {
                var items = from d in listPurchaseOrderItem
                            select new Entities.DgvPurchaseOrderItemEntity
                            {
                                ColumnPurchaseOrderItemListButtonEdit = "Edit",
                                ColumnPurchaseOrderItemListButtonDelete = "Delete",
                                ColumnPurchaseOrderItemListId = d.Id,
                                ColumnPurchaseOrderItemListPOId = d.POId,
                                ColumnPurchaseOrderItemListItemId = d.ItemId,
                                ColumnPurchaseOrderItemListItemDescritpion = d.ItemDescription,
                                ColumnPurchaseOrderItemListUnitId = d.UnitId,
                                ColumnPurchaseOrderItemListUnit = d.Unit,
                                ColumnPurchaseOrderItemListQuantity = d.Quantity.ToString("#,##0.00"),
                                ColumnPurchaseOrderItemListCost = d.Cost.ToString("#,##0.00"),
                                ColumnPurchaseOrderItemListAmount = d.Amount.ToString("#,##0.00"),
                                ColumnPurchaseOrderItemListBaseQuantity = d.BaseQuantity.ToString("#,##0.00"),
                                ColumnPurchaseOrderItemListBaseCost = d.BaseCost.ToString("#,##0.00")
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvPurchaseOrderItemEntity>());
            }
        }

        public void CreatePurchaseOrderItemDataGridView()
        {
            UpdatePurchaseOrderItemDataSource();

            dataGridViewPurchaseOrderItem.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewPurchaseOrderItem.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewPurchaseOrderItem.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewPurchaseOrderItem.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewPurchaseOrderItem.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewPurchaseOrderItem.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewPurchaseOrderItem.DataSource = purchaseOrderItemDataSource;
        }

        public void GetPurchaseOrderItemCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewPurchaseOrderItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetPurchaseOrderItemCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewPurchaseOrderItem.CurrentCell.ColumnIndex == dataGridViewPurchaseOrderItem.Columns["ColumnPurchaseOrderItemListButtonEdit"].Index)
            {
                var id = Convert.ToInt32(dataGridViewPurchaseOrderItem.Rows[e.RowIndex].Cells[dataGridViewPurchaseOrderItem.Columns["ColumnPurchaseOrderItemListId"].Index].Value);
                var pOId = Convert.ToInt32(dataGridViewPurchaseOrderItem.Rows[e.RowIndex].Cells[dataGridViewPurchaseOrderItem.Columns["ColumnPurchaseOrderItemListPOId"].Index].Value);
                var itemId = Convert.ToInt32(dataGridViewPurchaseOrderItem.Rows[e.RowIndex].Cells[dataGridViewPurchaseOrderItem.Columns["ColumnPurchaseOrderItemListItemId"].Index].Value);
                var itemDescription = dataGridViewPurchaseOrderItem.Rows[e.RowIndex].Cells[dataGridViewPurchaseOrderItem.Columns["ColumnPurchaseOrderItemListItemDescritpion"].Index].Value.ToString();
                var unitId = Convert.ToInt32(dataGridViewPurchaseOrderItem.Rows[e.RowIndex].Cells[dataGridViewPurchaseOrderItem.Columns["ColumnPurchaseOrderItemListUnitId"].Index].Value);
                var quantity = Convert.ToDecimal(dataGridViewPurchaseOrderItem.Rows[e.RowIndex].Cells[dataGridViewPurchaseOrderItem.Columns["ColumnPurchaseOrderItemListQuantity"].Index].Value);
                var Cost = Convert.ToDecimal(dataGridViewPurchaseOrderItem.Rows[e.RowIndex].Cells[dataGridViewPurchaseOrderItem.Columns["ColumnPurchaseOrderItemListCost"].Index].Value);
                var amount = Convert.ToDecimal(dataGridViewPurchaseOrderItem.Rows[e.RowIndex].Cells[dataGridViewPurchaseOrderItem.Columns["ColumnPurchaseOrderItemListAmount"].Index].Value);
          

                Entities.TrnPurchaseOrderItemEntity trnPurchaseOrderItemEntity = new Entities.TrnPurchaseOrderItemEntity()
                {
                    Id = id,
                    POId = pOId,
                    ItemId = itemId,
                    ItemDescription = itemDescription,
                    UnitId = unitId,
                    Quantity = quantity,
                    Cost = Cost,
                    Amount = amount
                };

                TrnPurchaseOrderDetailPurchaseOrderItemDetailForm trnPurchaseOrderDetailPurchaseOrderItemDetailForm = new TrnPurchaseOrderDetailPurchaseOrderItemDetailForm(this, trnPurchaseOrderItemEntity);
                trnPurchaseOrderDetailPurchaseOrderItemDetailForm.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewPurchaseOrderItem.CurrentCell.ColumnIndex == dataGridViewPurchaseOrderItem.Columns["ColumnPurchaseOrderItemListButtonDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete Stock-In?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(dataGridViewPurchaseOrderItem.Rows[e.RowIndex].Cells[dataGridViewPurchaseOrderItem.Columns["ColumnPurchaseOrderItemListId"].Index].Value);

                    Controllers.TrnPurchaseOrderItemController trnPurchaseOrderItemController = new Controllers.TrnPurchaseOrderItemController();
                    String[] deletePurchaseOrderItem = trnPurchaseOrderItemController.DeletePurchaseOrderItem(id);
                    if (deletePurchaseOrderItem[1].Equals("0") == false)
                    {
                        pageNumber = 1;
                        UpdatePurchaseOrderItemDataSource();
                    }
                    else
                    {
                        MessageBox.Show(deletePurchaseOrderItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonPurchaseOrderItemPageListFirst_Click(object sender, EventArgs e)
        {
            purchaseOrderItemPageSize = new PagedList<Entities.DgvPurchaseOrderItemEntity>(purchaseOrderItemData, 1, pageSize);
            purchaseOrderItemDataSource.DataSource = purchaseOrderItemPageSize;

            buttonPurchaseOrderItemPageListFirst.Enabled = false;
            buttonPurchaseOrderItemPageListPrevious.Enabled = false;
            buttonPurchaseOrderItemPageListNext.Enabled = true;
            buttonPurchaseOrderItemPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxPurchaseOrderItemPageNumber.Text = pageNumber + " / " + purchaseOrderItemPageSize.PageCount;
        }

        private void buttonPurchaseOrderItemPageListPrevious_Click(object sender, EventArgs e)
        {
            if (purchaseOrderItemPageSize.HasPreviousPage == true)
            {
                purchaseOrderItemPageSize = new PagedList<Entities.DgvPurchaseOrderItemEntity>(purchaseOrderItemData, --pageNumber, pageSize);
                purchaseOrderItemDataSource.DataSource = purchaseOrderItemPageSize;
            }

            buttonPurchaseOrderItemPageListNext.Enabled = true;
            buttonPurchaseOrderItemPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonPurchaseOrderItemPageListFirst.Enabled = false;
                buttonPurchaseOrderItemPageListPrevious.Enabled = false;
            }

            textBoxPurchaseOrderItemPageNumber.Text = pageNumber + " / " + purchaseOrderItemPageSize.PageCount;
        }

        private void buttonPurchaseOrderItemPageListNext_Click(object sender, EventArgs e)
        {
            if (purchaseOrderItemPageSize.HasNextPage == true)
            {
                purchaseOrderItemPageSize = new PagedList<Entities.DgvPurchaseOrderItemEntity>(purchaseOrderItemData, ++pageNumber, pageSize);
                purchaseOrderItemDataSource.DataSource = purchaseOrderItemPageSize;
            }

            buttonPurchaseOrderItemPageListFirst.Enabled = true;
            buttonPurchaseOrderItemPageListPrevious.Enabled = true;

            if (pageNumber == purchaseOrderItemPageSize.PageCount)
            {
                buttonPurchaseOrderItemPageListNext.Enabled = false;
                buttonPurchaseOrderItemPageListLast.Enabled = false;
            }

            textBoxPurchaseOrderItemPageNumber.Text = pageNumber + " / " + purchaseOrderItemPageSize.PageCount;
        }

        private void buttonPurchaseOrderItemPageListLast_Click(object sender, EventArgs e)
        {
            purchaseOrderItemPageSize = new PagedList<Entities.DgvPurchaseOrderItemEntity>(purchaseOrderItemData, purchaseOrderItemPageSize.PageCount, pageSize);
            purchaseOrderItemDataSource.DataSource = purchaseOrderItemPageSize;

            buttonPurchaseOrderItemPageListFirst.Enabled = true;
            buttonPurchaseOrderItemPageListPrevious.Enabled = true;
            buttonPurchaseOrderItemPageListNext.Enabled = false;
            buttonPurchaseOrderItemPageListLast.Enabled = false;

            pageNumber = purchaseOrderItemPageSize.PageCount;
            textBoxPurchaseOrderItemPageNumber.Text = pageNumber + " / " + purchaseOrderItemPageSize.PageCount;
        }

        private void buttonSearchItem_Click(object sender, EventArgs e)
        {
            TrnPurchaseOrderDetailSearchItemForm trnPurchaseOrderDetailSearchItemForm = new TrnPurchaseOrderDetailSearchItemForm(this, trnPurchaseOrderEntity);
            trnPurchaseOrderDetailSearchItemForm.ShowDialog();
        }

    }
}
