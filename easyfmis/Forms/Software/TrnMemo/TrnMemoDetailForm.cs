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

namespace easyfmis.Forms.Software.TrnMemo
{
    public partial class TrnMemoDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        TrnMemoForm trnMemoForm;
        public Entities.TrnMemoEntity trnMemoEntity;

        public static List<Entities.DgvTrnMemoLineEntity> memoLineData = new List<Entities.DgvTrnMemoLineEntity>();
        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;
        public PagedList<Entities.DgvTrnMemoLineEntity> memoLinePageSize = new PagedList<Entities.DgvTrnMemoLineEntity>(memoLineData, pageNumber, pageSize);
        public BindingSource memoLineDataSource = new BindingSource();

        public TrnMemoDetailForm(SysSoftwareForm softwareForm, TrnMemoForm purchaseOrderForm, Entities.TrnMemoEntity memoEntity)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            trnMemoForm = purchaseOrderForm;
            trnMemoEntity = memoEntity;

            GetSupplierList();
        }

        public void GetSupplierList()
        {
            Controllers.TrnPurchaseOrderController trnPurchaseOrderController = new Controllers.TrnPurchaseOrderController();
            var supplier = trnPurchaseOrderController.DropdownListPurchaseOrderSupplier();
            if (supplier.Any())
            {
                comboBoxArticle.DataSource = supplier;
                comboBoxArticle.ValueMember = "Id";
                comboBoxArticle.DisplayMember = "Article";

                GetUserList();
            }
        }

        public void GetUserList()
        {
            Controllers.TrnPurchaseOrderController trnPurchaseOrderController = new Controllers.TrnPurchaseOrderController();
            var user = trnPurchaseOrderController.DropdownListPurchaseOrderUser();
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

                GetPurchaseOrderDetail();
            }
        }

        public void GetPurchaseOrderDetail()
        {
            //UpdateComponents(trnMemoEntity.IsLocked);

            //textBoxBranch.Text = trnMemoEntity.Branch;
            //textBoxMONumber.Text = trnMemoEntity.PONumber;
            //dateTimePickerPODate.Value = trnMemoEntity.PODate;
            //comboBoxArticle.SelectedValue = trnMemoEntity.SupplierId;
            //textBoxRemarks.Text = trnMemoEntity.Remarks;
            //comboBoxPreparedBy.SelectedValue = trnMemoEntity.PreparedBy;
            //comboBoxCheckedBy.SelectedValue = trnMemoEntity.CheckedBy;
            //comboBoxApprovedBy.SelectedValue = trnMemoEntity.ApprovedBy;

            CreateMemoLineDataGridView();
        }

        public void UpdateComponents(Boolean isLocked)
        {
            buttonLock.Enabled = !isLocked;
            buttonUnlock.Enabled = isLocked;
            buttonPrint.Enabled = isLocked;

            buttonSearchItem.Enabled = !isLocked;

            textBoxBranch.Enabled = !isLocked;
            textBoxMONumber.Enabled = !isLocked;
            dateTimePickerPODate.Enabled = !isLocked;
            comboBoxArticle.Enabled = !isLocked;
            textBoxRemarks.Enabled = !isLocked;
            comboBoxPreparedBy.Enabled = !isLocked;
            comboBoxCheckedBy.Enabled = !isLocked;
            comboBoxApprovedBy.Enabled = !isLocked;

            dataGridViewMemoLine.Columns[0].Visible = !isLocked;
            dataGridViewMemoLine.Columns[1].Visible = !isLocked;
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            //Controllers.TrnPurchaseOrderController trnPurchaseOrderController = new Controllers.TrnPurchaseOrderController();

            //Entities.TrnPurchaseOrderEntity purchaseOrderEntity = new Entities.TrnPurchaseOrderEntity()
            //{
            //    Id = trnMemoEntity.Id,
            //    BranchId = trnMemoEntity.BranchId,
            //    PONumber = trnMemoEntity.PONumber,
            //    PODate = dateTimePickerPODate.Value.Date,
            //    ManualPONumber = textBoxManualPONumber.Text,
            //    SupplierId = Convert.ToInt32(comboBoxArticle.SelectedValue),
            //    TermId = Convert.ToInt32(comboBoxTerm.SelectedValue),
            //    DateNeeded = dateTimePickerDateNeeded.Value.Date,
            //    Remarks = textBoxRemarks.Text,
            //    IsClose = checkBoxIsClosed.Checked,
            //    RequestedBy = Convert.ToInt32(comboBoxRequestedBy.SelectedValue),
            //    PreparedBy = Convert.ToInt32(comboBoxPreparedBy.SelectedValue),
            //    CheckedBy = Convert.ToInt32(comboBoxCheckedBy.SelectedValue),
            //    ApprovedBy = Convert.ToInt32(comboBoxApprovedBy.SelectedValue),
            //};

            //String[] lockPurchaseOrder = trnPurchaseOrderController.LockPurchaseOrder(trnMemoEntity.Id, purchaseOrderEntity);
            //if (lockPurchaseOrder[1].Equals("0") == false)
            //{
            //    UpdateComponents(true);
            //    trnMemoForm.UpdatePurchaseOrderDataSource();
            //}
            //else
            //{
            //    MessageBox.Show(lockPurchaseOrder[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            Controllers.TrnPurchaseOrderController trnPurchaseOrderController = new Controllers.TrnPurchaseOrderController();

            String[] unlockPurchaseOrder = trnPurchaseOrderController.UnlockPurchaseOrder(trnMemoEntity.Id);
            if (unlockPurchaseOrder[1].Equals("0") == false)
            {
                UpdateComponents(false);
                trnMemoForm.UpdateMemoDataSource();
            }
            else
            {
                MessageBox.Show(unlockPurchaseOrder[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            //new TrnPurchaseOrderDetailPrintPreviewForm(trnMemoEntity.Id);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
            sysSoftwareForm.RemoveTabPage();
        }

        public void UpdateMemoLineDataSource()
        {
            SetStockOutItemDataSourceAsync();
        }

        public async void SetStockOutItemDataSourceAsync()
        {
            List<Entities.DgvTrnMemoLineEntity> getStockOutItemData = await GetMemoLineDataTask();
            if (getStockOutItemData.Any())
            {
                pageNumber = 1;
                memoLineData = getStockOutItemData;
                memoLinePageSize = new PagedList<Entities.DgvTrnMemoLineEntity>(memoLineData, pageNumber, pageSize);

                if (memoLinePageSize.PageCount == 1)
                {
                    buttonMemoLinePageListFirst.Enabled = false;
                    buttonMemoLinePageListPrevious.Enabled = false;
                    buttonMemoLinePageListNext.Enabled = false;
                    buttonMemoLinePageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonMemoLinePageListFirst.Enabled = false;
                    buttonMemoLinePageListPrevious.Enabled = false;
                    buttonMemoLinePageListNext.Enabled = true;
                    buttonMemoLinePageListLast.Enabled = true;
                }
                else if (pageNumber == memoLinePageSize.PageCount)
                {
                    buttonMemoLinePageListFirst.Enabled = true;
                    buttonMemoLinePageListPrevious.Enabled = true;
                    buttonMemoLinePageListNext.Enabled = false;
                    buttonMemoLinePageListLast.Enabled = false;
                }
                else
                {
                    buttonMemoLinePageListFirst.Enabled = true;
                    buttonMemoLinePageListPrevious.Enabled = true;
                    buttonMemoLinePageListNext.Enabled = true;
                    buttonMemoLinePageListLast.Enabled = true;
                }

                textBoxMemoLinePageNumber.Text = pageNumber + " / " + memoLinePageSize.PageCount;
                memoLineDataSource.DataSource = memoLinePageSize;
            }
            else
            {
                buttonMemoLinePageListFirst.Enabled = false;
                buttonMemoLinePageListPrevious.Enabled = false;
                buttonMemoLinePageListNext.Enabled = false;
                buttonMemoLinePageListLast.Enabled = false;

                pageNumber = 1;

                memoLineData = new List<Entities.DgvTrnMemoLineEntity>();
                memoLineDataSource.Clear();
                textBoxMemoLinePageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvTrnMemoLineEntity>> GetMemoLineDataTask()
        {
            //Controllers.TrnMemoLineController trnMemoLineController = new Controllers.TrnMemoLineController();

            //List<Entities.TrnMemoLineEntity> listMemoLine = trnMemoLineController.ListMemoLine(trnMemoEntity.Id);
            //if (listMemoLine.Any())
            //{
            //    var items = from d in listMemoLine
            //                select new Entities.DgvTrnMemoLineEntity
            //                {
            //                    //ColumnMemoLineListButtonEdit = "Edit",
            //                    //ColumnMemoLineListButtonDelete = "Delete",
            //                    //ColumnMemoLineListId = d.Id,
            //                    //ColumnMemoLineListPOId = d.POId,
            //                    //ColumnMemoLineListItemId = d.ItemId,
            //                    //ColumnMemoLineListItemDescritpion = d.ItemDescription,
            //                    //ColumnMemoLineListUnitId = d.UnitId,
            //                    //ColumnMemoLineListUnit = d.Unit,
            //                    //ColumnMemoLineListQuantity = d.Quantity.ToString("#,##0.00"),
            //                    //ColumnMemoLineListCost = d.Cost.ToString("#,##0.00"),
            //                    //ColumnMemoLineListAmount = d.Amount.ToString("#,##0.00"),
            //                    //ColumnMemoLineListBaseQuantity = d.BaseQuantity.ToString("#,##0.00"),
            //                    //ColumnMemoLineListBaseCost = d.BaseCost.ToString("#,##0.00")
            //                };

            //    textBoxTotalPOAmount.Text = listMemoLine.Sum(d => d.Amount).ToString("#,##0.00");

            //    return Task.FromResult(items.ToList());
            //}
            //else
            //{
            return Task.FromResult(new List<Entities.DgvTrnMemoLineEntity>());
            //}
        }

        public void CreateMemoLineDataGridView()
        {
            UpdateMemoLineDataSource();

            dataGridViewMemoLine.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewMemoLine.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewMemoLine.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewMemoLine.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewMemoLine.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewMemoLine.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewMemoLine.DataSource = memoLineDataSource;
        }

        public void GetMemoLineCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewMemoLine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetMemoLineCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewMemoLine.CurrentCell.ColumnIndex == dataGridViewMemoLine.Columns["ColumnMemoLineListButtonEdit"].Index)
            {
                //var id = Convert.ToInt32(dataGridViewMemoLine.Rows[e.RowIndex].Cells[dataGridViewMemoLine.Columns["ColumnMemoLineListId"].Index].Value);
                //var pOId = Convert.ToInt32(dataGridViewMemoLine.Rows[e.RowIndex].Cells[dataGridViewMemoLine.Columns["ColumnMemoLineListPOId"].Index].Value);
                //var itemId = Convert.ToInt32(dataGridViewMemoLine.Rows[e.RowIndex].Cells[dataGridViewMemoLine.Columns["ColumnMemoLineListItemId"].Index].Value);
                //var itemDescription = dataGridViewMemoLine.Rows[e.RowIndex].Cells[dataGridViewMemoLine.Columns["ColumnMemoLineListItemDescritpion"].Index].Value.ToString();
                //var unitId = Convert.ToInt32(dataGridViewMemoLine.Rows[e.RowIndex].Cells[dataGridViewMemoLine.Columns["ColumnMemoLineListUnitId"].Index].Value);
                //var quantity = Convert.ToDecimal(dataGridViewMemoLine.Rows[e.RowIndex].Cells[dataGridViewMemoLine.Columns["ColumnMemoLineListQuantity"].Index].Value);
                //var Cost = Convert.ToDecimal(dataGridViewMemoLine.Rows[e.RowIndex].Cells[dataGridViewMemoLine.Columns["ColumnMemoLineListCost"].Index].Value);
                //var amount = Convert.ToDecimal(dataGridViewMemoLine.Rows[e.RowIndex].Cells[dataGridViewMemoLine.Columns["ColumnMemoLineListAmount"].Index].Value);
          

                //Entities.TrnMemoLineEntity trnMemoLineEntity = new Entities.TrnMemoLineEntity()
                //{
                //    Id = id,
                //    POId = pOId,
                //    ItemId = itemId,
                //    ItemDescription = itemDescription,
                //    UnitId = unitId,
                //    Quantity = quantity,
                //    Cost = Cost,
                //    Amount = amount
                //};

                //TrnPurchaseOrderDetailMemoLineDetailForm trnPurchaseOrderDetailMemoLineDetailForm = new TrnPurchaseOrderDetailMemoLineDetailForm(this, trnMemoLineEntity);
                //trnPurchaseOrderDetailMemoLineDetailForm.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewMemoLine.CurrentCell.ColumnIndex == dataGridViewMemoLine.Columns["ColumnMemoLineListButtonDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete Stock-In?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    //var id = Convert.ToInt32(dataGridViewMemoLine.Rows[e.RowIndex].Cells[dataGridViewMemoLine.Columns["ColumnMemoLineListId"].Index].Value);

                    //Controllers.TrnMemoLineController trnMemoLineController = new Controllers.TrnMemoLineController();
                    //String[] deleteMemoLine = trnMemoLineController.DeleteMemoLine(id);
                    //if (deleteMemoLine[1].Equals("0") == false)
                    //{
                    //    pageNumber = 1;
                    //    UpdateMemoLineDataSource();
                    //}
                    //else
                    //{
                    //    MessageBox.Show(deleteMemoLine[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
            }
        }

        private void buttonMemoLinePageListFirst_Click(object sender, EventArgs e)
        {
            memoLinePageSize = new PagedList<Entities.DgvTrnMemoLineEntity>(memoLineData, 1, pageSize);
            memoLineDataSource.DataSource = memoLinePageSize;

            buttonMemoLinePageListFirst.Enabled = false;
            buttonMemoLinePageListPrevious.Enabled = false;
            buttonMemoLinePageListNext.Enabled = true;
            buttonMemoLinePageListLast.Enabled = true;

            pageNumber = 1;
            textBoxMemoLinePageNumber.Text = pageNumber + " / " + memoLinePageSize.PageCount;
        }

        private void buttonMemoLinePageListPrevious_Click(object sender, EventArgs e)
        {
            if (memoLinePageSize.HasPreviousPage == true)
            {
                memoLinePageSize = new PagedList<Entities.DgvTrnMemoLineEntity>(memoLineData, --pageNumber, pageSize);
                memoLineDataSource.DataSource = memoLinePageSize;
            }

            buttonMemoLinePageListNext.Enabled = true;
            buttonMemoLinePageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonMemoLinePageListFirst.Enabled = false;
                buttonMemoLinePageListPrevious.Enabled = false;
            }

            textBoxMemoLinePageNumber.Text = pageNumber + " / " + memoLinePageSize.PageCount;
        }

        private void buttonMemoLinePageListNext_Click(object sender, EventArgs e)
        {
            if (memoLinePageSize.HasNextPage == true)
            {
                memoLinePageSize = new PagedList<Entities.DgvTrnMemoLineEntity>(memoLineData, ++pageNumber, pageSize);
                memoLineDataSource.DataSource = memoLinePageSize;
            }

            buttonMemoLinePageListFirst.Enabled = true;
            buttonMemoLinePageListPrevious.Enabled = true;

            if (pageNumber == memoLinePageSize.PageCount)
            {
                buttonMemoLinePageListNext.Enabled = false;
                buttonMemoLinePageListLast.Enabled = false;
            }

            textBoxMemoLinePageNumber.Text = pageNumber + " / " + memoLinePageSize.PageCount;
        }

        private void buttonMemoLinePageListLast_Click(object sender, EventArgs e)
        {
            memoLinePageSize = new PagedList<Entities.DgvTrnMemoLineEntity>(memoLineData, memoLinePageSize.PageCount, pageSize);
            memoLineDataSource.DataSource = memoLinePageSize;

            buttonMemoLinePageListFirst.Enabled = true;
            buttonMemoLinePageListPrevious.Enabled = true;
            buttonMemoLinePageListNext.Enabled = false;
            buttonMemoLinePageListLast.Enabled = false;

            pageNumber = memoLinePageSize.PageCount;
            textBoxMemoLinePageNumber.Text = pageNumber + " / " + memoLinePageSize.PageCount;
        }

        private void buttonSearchItem_Click(object sender, EventArgs e)
        {
            //TrnPurchaseOrderDetailSearchItemForm trnPurchaseOrderDetailSearchItemForm = new TrnPurchaseOrderDetailSearchItemForm(this, trnMemoEntity);
            //trnPurchaseOrderDetailSearchItemForm.ShowDialog();
        }

        private void TrnMemoDetailForm_Load(object sender, EventArgs e)
        {

        }
    }
}
