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

namespace easyfmis.Forms.Software.TrnSalesInvoice
{
    public partial class TrnSalesInvoiceDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        public TrnSalesInvoiceForm trnSalesInvoiceForm;
        public Entities.TrnSalesInvoiceEntity trnSalesInvoiceEntity;

        public static List<Entities.DgvSalesInvoiceItemEntity> salesInvoiceItemData = new List<Entities.DgvSalesInvoiceItemEntity>();
        public static Int32 salesInvoiceItemPageNumber = 1;
        public static Int32 salesInvoiceItemPageSize = 50;
        public PagedList<Entities.DgvSalesInvoiceItemEntity> salesInvoiceItemPageList = new PagedList<Entities.DgvSalesInvoiceItemEntity>(salesInvoiceItemData, salesInvoiceItemPageNumber, salesInvoiceItemPageSize);
        public BindingSource salesInvoiceItemDataSource = new BindingSource();

        public static List<Entities.DgvTrnInventoryEntriesEntity> inventoryEntriesData = new List<Entities.DgvTrnInventoryEntriesEntity>();
        public static Int32 inventoryEntriesPageNumber = 1;
        public static Int32 inventoryEntriesPageSize = 50;
        public PagedList<Entities.DgvTrnInventoryEntriesEntity> inventoryEntriesPageList = new PagedList<Entities.DgvTrnInventoryEntriesEntity>(inventoryEntriesData, inventoryEntriesPageNumber, inventoryEntriesPageSize);
        public BindingSource inventoryEntriesDataSource = new BindingSource();

        public TrnSalesInvoiceDetailForm(SysSoftwareForm softwareForm, TrnSalesInvoiceForm salesInvoiceListForm, Entities.TrnSalesInvoiceEntity salesInvoiceEntity)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            trnSalesInvoiceForm = salesInvoiceListForm;
            trnSalesInvoiceEntity = salesInvoiceEntity;

            GetCustomerList();
        }

        public void GetCustomerList()
        {
            Controllers.TrnSalesInvoiceController trnSalesInvoiceController = new Controllers.TrnSalesInvoiceController();
            if (trnSalesInvoiceController.DropdownListSalesInvoiceCustomer().Any())
            {
                comboBoxCustomer.DataSource = trnSalesInvoiceController.DropdownListSalesInvoiceCustomer();
                comboBoxCustomer.ValueMember = "Id";
                comboBoxCustomer.DisplayMember = "Article";

                GetTermList();
            }
        }

        public void GetTermList()
        {
            Controllers.TrnSalesInvoiceController trnSalesInvoiceController = new Controllers.TrnSalesInvoiceController();
            if (trnSalesInvoiceController.DropdownListSalesInvoiceTerm().Any())
            {
                comboBoxTerm.DataSource = trnSalesInvoiceController.DropdownListSalesInvoiceTerm();
                comboBoxTerm.ValueMember = "Id";
                comboBoxTerm.DisplayMember = "Term";

                GetUserList();
            }
        }

        public void GetUserList()
        {
            Controllers.TrnSalesInvoiceController trnSalesInvoiceController = new Controllers.TrnSalesInvoiceController();
            if (trnSalesInvoiceController.DropdownListSalesInvoiceUser().Any())
            {
                comboBoxSoldBy.DataSource = trnSalesInvoiceController.DropdownListSalesInvoiceUser();
                comboBoxSoldBy.ValueMember = "Id";
                comboBoxSoldBy.DisplayMember = "FullName";

                comboBoxPreparedBy.DataSource = trnSalesInvoiceController.DropdownListSalesInvoiceUser();
                comboBoxPreparedBy.ValueMember = "Id";
                comboBoxPreparedBy.DisplayMember = "FullName";

                comboBoxCheckedBy.DataSource = trnSalesInvoiceController.DropdownListSalesInvoiceUser();
                comboBoxCheckedBy.ValueMember = "Id";
                comboBoxCheckedBy.DisplayMember = "FullName";

                comboBoxApprovedBy.DataSource = trnSalesInvoiceController.DropdownListSalesInvoiceUser();
                comboBoxApprovedBy.ValueMember = "Id";
                comboBoxApprovedBy.DisplayMember = "FullName";

                GetSalesInvoiceDetail();
            }
        }

        public void GetSalesInvoiceDetail()
        {
            UpdateComponents(trnSalesInvoiceEntity.IsLocked);

            textBoxBranch.Text = trnSalesInvoiceEntity.Branch;
            textBoxSINumber.Text = trnSalesInvoiceEntity.SINumber;
            dateTimePickerSIDate.Value = trnSalesInvoiceEntity.SIDate;
            textBoxManualSINumber.Text = trnSalesInvoiceEntity.ManualSINumber;
            comboBoxCustomer.SelectedValue = trnSalesInvoiceEntity.CustomerId;
            comboBoxTerm.SelectedValue = trnSalesInvoiceEntity.TermId;
            textBoxRemarks.Text = trnSalesInvoiceEntity.Remarks;
            comboBoxSoldBy.SelectedValue = trnSalesInvoiceEntity.SoldBy;
            comboBoxPreparedBy.SelectedValue = trnSalesInvoiceEntity.PreparedBy;
            comboBoxCheckedBy.SelectedValue = trnSalesInvoiceEntity.CheckedBy;
            comboBoxApprovedBy.SelectedValue = trnSalesInvoiceEntity.ApprovedBy;

            CreateSalesInvoiceItemDataGridView();
            CreateInventoryEntriesDataGridView();
        }

        public void UpdateComponents(Boolean isLocked)
        {
            buttonLock.Enabled = !isLocked;
            buttonUnlock.Enabled = isLocked;
            buttonPrint.Enabled = isLocked;

            buttonSearchItem.Enabled = !isLocked;

            textBoxBranch.Enabled = !isLocked;
            textBoxSINumber.Enabled = !isLocked;
            dateTimePickerSIDate.Enabled = !isLocked;
            textBoxManualSINumber.Enabled = !isLocked;
            comboBoxCustomer.Enabled = !isLocked;
            comboBoxTerm.Enabled = !isLocked;
            textBoxRemarks.Enabled = !isLocked;
            comboBoxSoldBy.Enabled = !isLocked;
            comboBoxCheckedBy.Enabled = !isLocked;
            comboBoxApprovedBy.Enabled = !isLocked;

            dataGridViewSalesInvoiceItem.Columns[0].Visible = !isLocked;
            dataGridViewSalesInvoiceItem.Columns[1].Visible = !isLocked;
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            Entities.TrnSalesInvoiceEntity newSalesInvoiceEntity = new Entities.TrnSalesInvoiceEntity()
            {
                SIDate = dateTimePickerSIDate.Value.Date,
                ManualSINumber = textBoxManualSINumber.Text,
                CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue),
                TermId = Convert.ToInt32(comboBoxTerm.SelectedValue),
                Remarks = textBoxRemarks.Text,
                SoldBy = Convert.ToInt32(comboBoxSoldBy.SelectedValue),
                CheckedBy = Convert.ToInt32(comboBoxCheckedBy.SelectedValue),
                ApprovedBy = Convert.ToInt32(comboBoxApprovedBy.SelectedValue)
            };

            Controllers.TrnSalesInvoiceController trnSalesInvoiceController = new Controllers.TrnSalesInvoiceController();
            String[] lockSalesInvoice = trnSalesInvoiceController.LockSalesInvoice(trnSalesInvoiceEntity.Id, newSalesInvoiceEntity);

            if (lockSalesInvoice[1].Equals("0") == false)
            {
                UpdateComponents(true);
                trnSalesInvoiceForm.UpdateSalesInvoiceDataSource();

                UpdateInventoryEntriesDataSource();
            }
            else
            {
                MessageBox.Show(lockSalesInvoice[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            Controllers.TrnSalesInvoiceController trnSalesInvoiceController = new Controllers.TrnSalesInvoiceController();
            String[] unlockSalesInvoice = trnSalesInvoiceController.UnlockSalesInvoice(trnSalesInvoiceEntity.Id);

            if (unlockSalesInvoice[1].Equals("0") == false)
            {
                UpdateComponents(false);
                trnSalesInvoiceForm.UpdateSalesInvoiceDataSource();

                UpdateInventoryEntriesDataSource();
            }
            else
            {
                MessageBox.Show(unlockSalesInvoice[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            new TrnSalesInvoiceDetailPrintPreviewForm(trnSalesInvoiceEntity.Id);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
            sysSoftwareForm.RemoveTabPage();
        }

        public void UpdateSalesInvoiceItemDataSource()
        {
            SetSalesInvoiceItemDataSourceAsync();
        }

        public async void SetSalesInvoiceItemDataSourceAsync()
        {
            List<Entities.DgvSalesInvoiceItemEntity> getSalesInvoiceItemData = await GetSalesInvoiceItemDataTask();
            if (getSalesInvoiceItemData.Any())
            {
                salesInvoiceItemPageNumber = 1;
                salesInvoiceItemData = getSalesInvoiceItemData;
                salesInvoiceItemPageList = new PagedList<Entities.DgvSalesInvoiceItemEntity>(salesInvoiceItemData, salesInvoiceItemPageNumber, salesInvoiceItemPageSize);

                if (salesInvoiceItemPageList.PageCount == 1)
                {
                    buttonSalesInvoiceItemPageListFirst.Enabled = false;
                    buttonSalesInvoiceItemPageListPrevious.Enabled = false;
                    buttonSalesInvoiceItemPageListNext.Enabled = false;
                    buttonSalesInvoiceItemPageListLast.Enabled = false;
                }
                else if (salesInvoiceItemPageNumber == 1)
                {
                    buttonSalesInvoiceItemPageListFirst.Enabled = false;
                    buttonSalesInvoiceItemPageListPrevious.Enabled = false;
                    buttonSalesInvoiceItemPageListNext.Enabled = true;
                    buttonSalesInvoiceItemPageListLast.Enabled = true;
                }
                else if (salesInvoiceItemPageNumber == salesInvoiceItemPageList.PageCount)
                {
                    buttonSalesInvoiceItemPageListFirst.Enabled = true;
                    buttonSalesInvoiceItemPageListPrevious.Enabled = true;
                    buttonSalesInvoiceItemPageListNext.Enabled = false;
                    buttonSalesInvoiceItemPageListLast.Enabled = false;
                }
                else
                {
                    buttonSalesInvoiceItemPageListFirst.Enabled = true;
                    buttonSalesInvoiceItemPageListPrevious.Enabled = true;
                    buttonSalesInvoiceItemPageListNext.Enabled = true;
                    buttonSalesInvoiceItemPageListLast.Enabled = true;
                }

                textBoxSalesInvoiceItemPageNumber.Text = salesInvoiceItemPageNumber + " / " + salesInvoiceItemPageList.PageCount;
                salesInvoiceItemDataSource.DataSource = salesInvoiceItemPageList;
            }
            else
            {
                buttonSalesInvoiceItemPageListFirst.Enabled = false;
                buttonSalesInvoiceItemPageListPrevious.Enabled = false;
                buttonSalesInvoiceItemPageListNext.Enabled = false;
                buttonSalesInvoiceItemPageListLast.Enabled = false;

                salesInvoiceItemPageNumber = 1;

                salesInvoiceItemData = new List<Entities.DgvSalesInvoiceItemEntity>();
                salesInvoiceItemDataSource.Clear();
                textBoxSalesInvoiceItemPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvSalesInvoiceItemEntity>> GetSalesInvoiceItemDataTask()
        {
            Controllers.TrnSalesInvoiceItemController trnSalesInvoiceItemController = new Controllers.TrnSalesInvoiceItemController();

            List<Entities.TrnSalesInvoiceItemEntity> listSalesInvoiceItem = trnSalesInvoiceItemController.ListSalesInvoiceItem(trnSalesInvoiceEntity.Id);
            if (listSalesInvoiceItem.Any())
            {
                var items = from d in listSalesInvoiceItem
                            select new Entities.DgvSalesInvoiceItemEntity
                            {
                                ColumnSalesInvoiceItemListButtonEdit = "Edit",
                                ColumnSalesInvoiceItemListButtonDelete = "Delete",
                                ColumnSalesInvoiceItemListId = d.Id,
                                ColumnSalesInvoiceItemListSIId = d.SIId,
                                ColumnSalesInvoiceItemListItemId = d.ItemId,
                                ColumnSalesInvoiceItemListItemDescription = d.ItemDescription,
                                ColumnSalesInvoiceItemListItemInventoryId = d.ItemInventoryId,
                                ColumnSalesInvoiceItemListItemInventoryCode = d.ItemInventoryCode,
                                ColumnSalesInvoiceItemListUnitId = d.UnitId,
                                ColumnSalesInvoiceItemListUnit = d.Unit,
                                ColumnSalesInvoiceItemListPrice = d.Price.ToString("#,##0.00"),
                                ColumnSalesInvoiceItemListDiscount = d.Discount,
                                ColumnSalesInvoiceItemListDiscountId = d.DiscountId,
                                ColumnSalesInvoiceItemListDiscountRate = d.DiscountRate.ToString("#,##0.00"),
                                ColumnSalesInvoiceItemListDiscountAmount = d.DiscountAmount.ToString("#,##0.00"),
                                ColumnSalesInvoiceItemListNetPrice = d.NetPrice.ToString("#,##0.00"),
                                ColumnSalesInvoiceItemListQuantity = d.Quantity.ToString("#,##0.00"),
                                ColumnSalesInvoiceItemListAmount = d.Amount.ToString("#,##0.00"),
                                ColumnSalesInvoiceItemListTaxId = d.TaxId,
                                ColumnSalesInvoiceItemListTax = d.Tax,
                                ColumnSalesInvoiceItemListTaxRate = d.TaxRate.ToString("#,##0.00"),
                                ColumnSalesInvoiceItemListTaxAmount = d.TaxAmount.ToString("#,##0.00"),
                                ColumnSalesInvoiceItemListBaseQuantity = d.BaseQuantity.ToString("#,##0.00"),
                                ColumnSalesInvoiceItemListBasePrice = d.BasePrice.ToString("#,##0.00"),
                                ColumnSalesInvoiceItemListSpace = ""
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvSalesInvoiceItemEntity>());
            }
        }

        public void CreateSalesInvoiceItemDataGridView()
        {
            UpdateSalesInvoiceItemDataSource();

            dataGridViewSalesInvoiceItem.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSalesInvoiceItem.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSalesInvoiceItem.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewSalesInvoiceItem.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewSalesInvoiceItem.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewSalesInvoiceItem.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewSalesInvoiceItem.DataSource = salesInvoiceItemDataSource;
        }

        public void GetSalesInvoiceItemCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewSalesInvoiceItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetSalesInvoiceItemCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewSalesInvoiceItem.CurrentCell.ColumnIndex == dataGridViewSalesInvoiceItem.Columns["ColumnSalesInvoiceItemListButtonEdit"].Index)
            {
                var id = Convert.ToInt32(dataGridViewSalesInvoiceItem.Rows[e.RowIndex].Cells[dataGridViewSalesInvoiceItem.Columns["ColumnSalesInvoiceItemListId"].Index].Value);
                var SIId = Convert.ToInt32(dataGridViewSalesInvoiceItem.Rows[e.RowIndex].Cells[dataGridViewSalesInvoiceItem.Columns["ColumnSalesInvoiceItemListSIId"].Index].Value);
                var itemId = Convert.ToInt32(dataGridViewSalesInvoiceItem.Rows[e.RowIndex].Cells[dataGridViewSalesInvoiceItem.Columns["ColumnSalesInvoiceItemListItemId"].Index].Value);
                var itemDescription = dataGridViewSalesInvoiceItem.Rows[e.RowIndex].Cells[dataGridViewSalesInvoiceItem.Columns["ColumnSalesInvoiceItemListItemDescription"].Index].Value.ToString();
                var itemInventoryId = Convert.ToInt32(dataGridViewSalesInvoiceItem.Rows[e.RowIndex].Cells[dataGridViewSalesInvoiceItem.Columns["ColumnSalesInvoiceItemListItemInventoryId"].Index].Value);
                var unitId = Convert.ToInt32(dataGridViewSalesInvoiceItem.Rows[e.RowIndex].Cells[dataGridViewSalesInvoiceItem.Columns["ColumnSalesInvoiceItemListUnitId"].Index].Value);
                var price = Convert.ToDecimal(dataGridViewSalesInvoiceItem.Rows[e.RowIndex].Cells[dataGridViewSalesInvoiceItem.Columns["ColumnSalesInvoiceItemListPrice"].Index].Value);
                var discountId = Convert.ToInt32(dataGridViewSalesInvoiceItem.Rows[e.RowIndex].Cells[dataGridViewSalesInvoiceItem.Columns["ColumnSalesInvoiceItemListDiscountId"].Index].Value);
                var discountRate = Convert.ToDecimal(dataGridViewSalesInvoiceItem.Rows[e.RowIndex].Cells[dataGridViewSalesInvoiceItem.Columns["ColumnSalesInvoiceItemListDiscountRate"].Index].Value);
                var discountAmount = Convert.ToDecimal(dataGridViewSalesInvoiceItem.Rows[e.RowIndex].Cells[dataGridViewSalesInvoiceItem.Columns["ColumnSalesInvoiceItemListDiscountAmount"].Index].Value);
                var netPrice = Convert.ToDecimal(dataGridViewSalesInvoiceItem.Rows[e.RowIndex].Cells[dataGridViewSalesInvoiceItem.Columns["ColumnSalesInvoiceItemListNetPrice"].Index].Value);
                var quantity = Convert.ToDecimal(dataGridViewSalesInvoiceItem.Rows[e.RowIndex].Cells[dataGridViewSalesInvoiceItem.Columns["ColumnSalesInvoiceItemListQuantity"].Index].Value);
                var amount = Convert.ToDecimal(dataGridViewSalesInvoiceItem.Rows[e.RowIndex].Cells[dataGridViewSalesInvoiceItem.Columns["ColumnSalesInvoiceItemListAmount"].Index].Value);
                var taxId = Convert.ToInt32(dataGridViewSalesInvoiceItem.Rows[e.RowIndex].Cells[dataGridViewSalesInvoiceItem.Columns["ColumnSalesInvoiceItemListTaxId"].Index].Value);
                var taxRate = Convert.ToDecimal(dataGridViewSalesInvoiceItem.Rows[e.RowIndex].Cells[dataGridViewSalesInvoiceItem.Columns["ColumnSalesInvoiceItemListTaxRate"].Index].Value);
                var taxAmount = Convert.ToDecimal(dataGridViewSalesInvoiceItem.Rows[e.RowIndex].Cells[dataGridViewSalesInvoiceItem.Columns["ColumnSalesInvoiceItemListTaxAmount"].Index].Value);

                Entities.TrnSalesInvoiceItemEntity trnSalesInvoiceItemEntity = new Entities.TrnSalesInvoiceItemEntity()
                {
                    Id = id,
                    SIId = SIId,
                    ItemId = itemId,
                    ItemDescription = itemDescription,
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
                    BaseQuantity = 0,
                    BasePrice = 0,
                };

                TrnSalesInvoiceDetailSalesInvoiceItemDetailForm trnSalesInvoiceDetailSalesInvoiceItemDetailForm = new TrnSalesInvoiceDetailSalesInvoiceItemDetailForm(this, trnSalesInvoiceItemEntity);
                trnSalesInvoiceDetailSalesInvoiceItemDetailForm.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewSalesInvoiceItem.CurrentCell.ColumnIndex == dataGridViewSalesInvoiceItem.Columns["ColumnSalesInvoiceItemListButtonDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete Stock-In?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(dataGridViewSalesInvoiceItem.Rows[e.RowIndex].Cells[dataGridViewSalesInvoiceItem.Columns["ColumnSalesInvoiceItemListId"].Index].Value);

                    Controllers.TrnSalesInvoiceItemController trnSalesInvoiceItemController = new Controllers.TrnSalesInvoiceItemController();
                    String[] deleteSalesInvoiceItem = trnSalesInvoiceItemController.DeleteSalesInvoiceItem(id);
                    if (deleteSalesInvoiceItem[1].Equals("0") == false)
                    {
                        salesInvoiceItemPageNumber = 1;
                        UpdateSalesInvoiceItemDataSource();
                    }
                    else
                    {
                        MessageBox.Show(deleteSalesInvoiceItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonSalesInvoiceItemPageListFirst_Click(object sender, EventArgs e)
        {
            salesInvoiceItemPageList = new PagedList<Entities.DgvSalesInvoiceItemEntity>(salesInvoiceItemData, 1, salesInvoiceItemPageSize);
            salesInvoiceItemDataSource.DataSource = salesInvoiceItemPageList;

            buttonSalesInvoiceItemPageListFirst.Enabled = false;
            buttonSalesInvoiceItemPageListPrevious.Enabled = false;
            buttonSalesInvoiceItemPageListNext.Enabled = true;
            buttonSalesInvoiceItemPageListLast.Enabled = true;

            salesInvoiceItemPageNumber = 1;
            textBoxSalesInvoiceItemPageNumber.Text = salesInvoiceItemPageNumber + " / " + salesInvoiceItemPageList.PageCount;
        }

        private void buttonSalesInvoiceItemPageListPrevious_Click(object sender, EventArgs e)
        {
            if (salesInvoiceItemPageList.HasPreviousPage == true)
            {
                salesInvoiceItemPageList = new PagedList<Entities.DgvSalesInvoiceItemEntity>(salesInvoiceItemData, --salesInvoiceItemPageNumber, salesInvoiceItemPageSize);
                salesInvoiceItemDataSource.DataSource = salesInvoiceItemPageList;
            }

            buttonSalesInvoiceItemPageListNext.Enabled = true;
            buttonSalesInvoiceItemPageListLast.Enabled = true;

            if (salesInvoiceItemPageNumber == 1)
            {
                buttonSalesInvoiceItemPageListFirst.Enabled = false;
                buttonSalesInvoiceItemPageListPrevious.Enabled = false;
            }

            textBoxSalesInvoiceItemPageNumber.Text = salesInvoiceItemPageNumber + " / " + salesInvoiceItemPageList.PageCount;
        }

        private void buttonSalesInvoiceItemPageListNext_Click(object sender, EventArgs e)
        {
            if (salesInvoiceItemPageList.HasNextPage == true)
            {
                salesInvoiceItemPageList = new PagedList<Entities.DgvSalesInvoiceItemEntity>(salesInvoiceItemData, ++salesInvoiceItemPageNumber, salesInvoiceItemPageSize);
                salesInvoiceItemDataSource.DataSource = salesInvoiceItemPageList;
            }

            buttonSalesInvoiceItemPageListFirst.Enabled = true;
            buttonSalesInvoiceItemPageListPrevious.Enabled = true;

            if (salesInvoiceItemPageNumber == salesInvoiceItemPageList.PageCount)
            {
                buttonSalesInvoiceItemPageListNext.Enabled = false;
                buttonSalesInvoiceItemPageListLast.Enabled = false;
            }

            textBoxSalesInvoiceItemPageNumber.Text = salesInvoiceItemPageNumber + " / " + salesInvoiceItemPageList.PageCount;
        }

        private void buttonSalesInvoiceItemPageListLast_Click(object sender, EventArgs e)
        {
            salesInvoiceItemPageList = new PagedList<Entities.DgvSalesInvoiceItemEntity>(salesInvoiceItemData, salesInvoiceItemPageList.PageCount, salesInvoiceItemPageSize);
            salesInvoiceItemDataSource.DataSource = salesInvoiceItemPageList;

            buttonSalesInvoiceItemPageListFirst.Enabled = true;
            buttonSalesInvoiceItemPageListPrevious.Enabled = true;
            buttonSalesInvoiceItemPageListNext.Enabled = false;
            buttonSalesInvoiceItemPageListLast.Enabled = false;

            salesInvoiceItemPageNumber = salesInvoiceItemPageList.PageCount;
            textBoxSalesInvoiceItemPageNumber.Text = salesInvoiceItemPageNumber + " / " + salesInvoiceItemPageList.PageCount;
        }

        private void buttonSearchItem_Click(object sender, EventArgs e)
        {
            TrnSalesInvoiceDetailSearchItemForm trnSalesInvoiceDetailSearchItemForm = new TrnSalesInvoiceDetailSearchItemForm(this, trnSalesInvoiceEntity);
            trnSalesInvoiceDetailSearchItemForm.ShowDialog();
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

            List<Entities.TrnInventoryEntity> listInventoryEntries = trnInventoryController.ListSalesInvoiceInventoryEntries(trnSalesInvoiceEntity.Id);
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

        private void comboBoxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            trnSalesInvoiceEntity.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue);
        }
    }
}
