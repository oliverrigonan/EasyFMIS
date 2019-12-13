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

namespace easyfmis.Forms.Software.TrnStockIn
{
    public partial class TrnStockInDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        public TrnStockInForm trnStockInForm;
        public Entities.TrnStockInEntity trnStockInEntity;

        public static List<Entities.DgvStockInItemEntity> stockInLineData = new List<Entities.DgvStockInItemEntity>();
        public static Int32 stockInLinePageNumber = 1;
        public static Int32 stockInLinePageSize = 50;
        public PagedList<Entities.DgvStockInItemEntity> stockInLinePageList = new PagedList<Entities.DgvStockInItemEntity>(stockInLineData, stockInLinePageNumber, stockInLinePageSize);
        public BindingSource stockInLineDataSource = new BindingSource();

        public TrnStockInDetailForm(SysSoftwareForm softwareForm, TrnStockInForm stockInListForm, Entities.TrnStockInEntity stockInEntity)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            trnStockInForm = stockInListForm;
            trnStockInEntity = stockInEntity;

            GetUserList();
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

            CreateStockInItemDataGridView();
        }

        public void UpdateComponents(Boolean isLocked)
        {
            buttonLock.Enabled = !isLocked;
            buttonUnlock.Enabled = isLocked;
            buttonPrint.Enabled = !isLocked;

            buttonSearchItem.Enabled = !isLocked;

            dateTimePickerINDate.Enabled = !isLocked;
            textBoxRemarks.Enabled = !isLocked;
            comboBoxCheckedBy.Enabled = !isLocked;
            comboBoxApprovedBy.Enabled = !isLocked;

            dataGridViewStockInItem.Columns[0].Visible = !isLocked;
            dataGridViewStockInItem.Columns[1].Visible = !isLocked;
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            Controllers.TrnStockInController trnStockInController = new Controllers.TrnStockInController();

            Entities.TrnStockInEntity newStockInEntity = new Entities.TrnStockInEntity()
            {
                INDate = dateTimePickerINDate.Value.Date,
                Remarks = textBoxRemarks.Text,
                CheckedBy = Convert.ToInt32(comboBoxCheckedBy.SelectedValue),
                ApprovedBy = Convert.ToInt32(comboBoxApprovedBy.SelectedValue)
            };

            String[] lockStockIn = trnStockInController.LockStockIn(trnStockInEntity.Id, newStockInEntity);
            if (lockStockIn[1].Equals("0") == false)
            {
                UpdateComponents(true);
                trnStockInForm.UpdateStockInDataSource();
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
            }
            else
            {
                MessageBox.Show(unlockStockIn[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void UpdateStockInItemDataSource()
        {
            SetStockInItemDataSourceAsync();
        }

        public async void SetStockInItemDataSourceAsync()
        {
            List<Entities.DgvStockInItemEntity> getStockInItemData = await GetStockInItemDataTask();
            if (getStockInItemData.Any())
            {
                stockInLineData = getStockInItemData;
                stockInLinePageList = new PagedList<Entities.DgvStockInItemEntity>(stockInLineData, stockInLinePageNumber, stockInLinePageSize);

                if (stockInLinePageList.PageCount == 1)
                {
                    buttonStockInItemPageListFirst.Enabled = false;
                    buttonStockInItemPageListPrevious.Enabled = false;
                    buttonStockInItemPageListNext.Enabled = false;
                    buttonStockInItemPageListLast.Enabled = false;
                }
                else if (stockInLinePageNumber == 1)
                {
                    buttonStockInItemPageListFirst.Enabled = false;
                    buttonStockInItemPageListPrevious.Enabled = false;
                    buttonStockInItemPageListNext.Enabled = true;
                    buttonStockInItemPageListLast.Enabled = true;
                }
                else if (stockInLinePageNumber == stockInLinePageList.PageCount)
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

                textBoxStockInItemPageNumber.Text = stockInLinePageNumber + " / " + stockInLinePageList.PageCount;
                stockInLineDataSource.DataSource = stockInLinePageList;
            }
            else
            {
                buttonStockInItemPageListFirst.Enabled = false;
                buttonStockInItemPageListPrevious.Enabled = false;
                buttonStockInItemPageListNext.Enabled = false;
                buttonStockInItemPageListLast.Enabled = false;

                stockInLinePageNumber = 1;

                stockInLineData = new List<Entities.DgvStockInItemEntity>();
                stockInLineDataSource.Clear();
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
                                ColumnStockInItemItemId = d.ItemId,
                                ColumnStockInItemItemDescription = d.ItemDescription,
                                ColumnStockInItemUnitId = d.UnitId,
                                ColumnStockInItemUnit = d.Unit,
                                ColumnStockInItemQuantity = d.Quantity.ToString("#,##0.00"),
                                ColumnStockInItemCost = d.Cost.ToString("#,##0.00"),
                                ColumnStockInItemAmount = d.Amount.ToString("#,##0.00"),
                                ColumnStockInItemBaseQuantity = d.BaseQuantity.ToString("#,##0.00"),
                                ColumnStockInItemBaseCost = d.BaseCost.ToString("#,##0.00"),
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
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

            dataGridViewStockInItem.DataSource = stockInLineDataSource;
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
                        stockInLinePageNumber = 1;
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
            stockInLinePageList = new PagedList<Entities.DgvStockInItemEntity>(stockInLineData, 1, stockInLinePageSize);
            stockInLineDataSource.DataSource = stockInLinePageList;

            buttonStockInItemPageListFirst.Enabled = false;
            buttonStockInItemPageListPrevious.Enabled = false;
            buttonStockInItemPageListNext.Enabled = true;
            buttonStockInItemPageListLast.Enabled = true;

            stockInLinePageNumber = 1;
            textBoxStockInItemPageNumber.Text = stockInLinePageNumber + " / " + stockInLinePageList.PageCount;
        }

        private void buttonStockInItemPageListPrevious_Click(object sender, EventArgs e)
        {
            if (stockInLinePageList.HasPreviousPage == true)
            {
                stockInLinePageList = new PagedList<Entities.DgvStockInItemEntity>(stockInLineData, --stockInLinePageNumber, stockInLinePageSize);
                stockInLineDataSource.DataSource = stockInLinePageList;
            }

            buttonStockInItemPageListNext.Enabled = true;
            buttonStockInItemPageListLast.Enabled = true;

            if (stockInLinePageNumber == 1)
            {
                buttonStockInItemPageListFirst.Enabled = false;
                buttonStockInItemPageListPrevious.Enabled = false;
            }

            textBoxStockInItemPageNumber.Text = stockInLinePageNumber + " / " + stockInLinePageList.PageCount;
        }

        private void buttonStockInItemPageListNext_Click(object sender, EventArgs e)
        {
            if (stockInLinePageList.HasNextPage == true)
            {
                stockInLinePageList = new PagedList<Entities.DgvStockInItemEntity>(stockInLineData, ++stockInLinePageNumber, stockInLinePageSize);
                stockInLineDataSource.DataSource = stockInLinePageList;
            }

            buttonStockInItemPageListFirst.Enabled = true;
            buttonStockInItemPageListPrevious.Enabled = true;

            if (stockInLinePageNumber == stockInLinePageList.PageCount)
            {
                buttonStockInItemPageListNext.Enabled = false;
                buttonStockInItemPageListLast.Enabled = false;
            }

            textBoxStockInItemPageNumber.Text = stockInLinePageNumber + " / " + stockInLinePageList.PageCount;
        }

        private void buttonStockInItemPageListLast_Click(object sender, EventArgs e)
        {
            stockInLinePageList = new PagedList<Entities.DgvStockInItemEntity>(stockInLineData, stockInLinePageList.PageCount, stockInLinePageSize);
            stockInLineDataSource.DataSource = stockInLinePageList;

            buttonStockInItemPageListFirst.Enabled = true;
            buttonStockInItemPageListPrevious.Enabled = true;
            buttonStockInItemPageListNext.Enabled = false;
            buttonStockInItemPageListLast.Enabled = false;

            stockInLinePageNumber = stockInLinePageList.PageCount;
            textBoxStockInItemPageNumber.Text = stockInLinePageNumber + " / " + stockInLinePageList.PageCount;
        }

        private void buttonSearchItem_Click(object sender, EventArgs e)
        {
            TrnStockInDetailSearchItemForm trnStockInDetailSearchItemForm = new TrnStockInDetailSearchItemForm(this, trnStockInEntity);
            trnStockInDetailSearchItemForm.ShowDialog();
        }
    }
}
