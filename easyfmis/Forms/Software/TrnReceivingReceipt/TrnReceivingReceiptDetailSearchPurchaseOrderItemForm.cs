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
    public partial class TrnReceivingReceiptDetailSearchPurchaseOrderItemForm : Form
    {
        public TrnReceivingReceiptDetailForm trnReceivingReceiptDetailForm;
        public Entities.TrnReceivingReceiptEntity trnReceivingReceiptEntity;

        public static List<Entities.DgvSearchPurchaseOrderItemEntity> searchItemData = new List<Entities.DgvSearchPurchaseOrderItemEntity>();
        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;
        public PagedList<Entities.DgvSearchPurchaseOrderItemEntity> searchItemPageList = new PagedList<Entities.DgvSearchPurchaseOrderItemEntity>(searchItemData, pageNumber, pageSize);
        public BindingSource searchItemDataSource = new BindingSource();

        public TrnReceivingReceiptDetailSearchPurchaseOrderItemForm(TrnReceivingReceiptDetailForm receivingReceiptDetailForm, Entities.TrnReceivingReceiptEntity receivingReceiptEntity)
        {
            InitializeComponent();

            trnReceivingReceiptDetailForm = receivingReceiptDetailForm;
            trnReceivingReceiptEntity = receivingReceiptEntity;

            GetPONumberList();
        }

        public void GetPONumberList()
        {
            Controllers.TrnReceivingReceiptItemController trnReceivingReceiptItemController = new Controllers.TrnReceivingReceiptItemController();
            if (trnReceivingReceiptItemController.ListPurchaseOrder(trnReceivingReceiptEntity.SupplierId).Any())
            {
                comboBoxPONumber.DataSource = trnReceivingReceiptItemController.ListPurchaseOrder(trnReceivingReceiptEntity.SupplierId);
                comboBoxPONumber.ValueMember = "Id";
                comboBoxPONumber.DisplayMember = "PONumber";

                CreateSearchPurchaseOrderItemDataGridView();
            }
        }

        public void UpdateSearchPurchaseOrderItemDataSource()
        {
            Int32 POId = 0;
            if (comboBoxPONumber.SelectedValue != null)
            {
                POId = Convert.ToInt32(comboBoxPONumber.SelectedValue);
            }

            SetSearchPurchaseOrderItemDataSourceAsync(POId);
        }

        public async void SetSearchPurchaseOrderItemDataSourceAsync(Int32 POId)
        {
            List<Entities.DgvSearchPurchaseOrderItemEntity> getSearchPurchaseOrderItemData = await GetSearchPurchaseOrderItemDataTask(POId);
            if (getSearchPurchaseOrderItemData.Any())
            {
                pageNumber = 1;
                searchItemData = getSearchPurchaseOrderItemData;
                searchItemPageList = new PagedList<Entities.DgvSearchPurchaseOrderItemEntity>(searchItemData, pageNumber, pageSize);

                if (searchItemPageList.PageCount == 1)
                {
                    buttonSearchPurchaseOrderItemPageListFirst.Enabled = false;
                    buttonSearchPurchaseOrderItemPageListPrevious.Enabled = false;
                    buttonSearchPurchaseOrderItemPageListNext.Enabled = false;
                    buttonSearchPurchaseOrderItemPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonSearchPurchaseOrderItemPageListFirst.Enabled = false;
                    buttonSearchPurchaseOrderItemPageListPrevious.Enabled = false;
                    buttonSearchPurchaseOrderItemPageListNext.Enabled = true;
                    buttonSearchPurchaseOrderItemPageListLast.Enabled = true;
                }
                else if (pageNumber == searchItemPageList.PageCount)
                {
                    buttonSearchPurchaseOrderItemPageListFirst.Enabled = true;
                    buttonSearchPurchaseOrderItemPageListPrevious.Enabled = true;
                    buttonSearchPurchaseOrderItemPageListNext.Enabled = false;
                    buttonSearchPurchaseOrderItemPageListLast.Enabled = false;
                }
                else
                {
                    buttonSearchPurchaseOrderItemPageListFirst.Enabled = true;
                    buttonSearchPurchaseOrderItemPageListPrevious.Enabled = true;
                    buttonSearchPurchaseOrderItemPageListNext.Enabled = true;
                    buttonSearchPurchaseOrderItemPageListLast.Enabled = true;
                }

                textBoxSearchPurchaseOrderItemPageNumber.Text = pageNumber + " / " + searchItemPageList.PageCount;
                searchItemDataSource.DataSource = searchItemPageList;
            }
            else
            {
                buttonSearchPurchaseOrderItemPageListFirst.Enabled = false;
                buttonSearchPurchaseOrderItemPageListPrevious.Enabled = false;
                buttonSearchPurchaseOrderItemPageListNext.Enabled = false;
                buttonSearchPurchaseOrderItemPageListLast.Enabled = false;

                pageNumber = 1;

                searchItemData = new List<Entities.DgvSearchPurchaseOrderItemEntity>();
                searchItemDataSource.Clear();
                textBoxSearchPurchaseOrderItemPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvSearchPurchaseOrderItemEntity>> GetSearchPurchaseOrderItemDataTask(Int32 POId)
        {
            String filter = textBoxSearchPurchaseOrderItemFilter.Text;
            Controllers.TrnReceivingReceiptItemController trnReceivingReceiptItemController = new Controllers.TrnReceivingReceiptItemController();

            List<Entities.TrnPurchaseOrderItemEntity> listSearchPurchaseOrderItem = trnReceivingReceiptItemController.ListPurchaseOrderItem(POId, filter);
            if (listSearchPurchaseOrderItem.Any())
            {
                var items = from d in listSearchPurchaseOrderItem
                            select new Entities.DgvSearchPurchaseOrderItemEntity
                            {
                                ColumnSearchPurchaseOrderItemId = d.ItemId,
                                ColumnSearchPurchaseOrderItemBarCode = d.ItemBarCode,
                                ColumnSearchPurchaseOrderItemDescription = d.ItemDescription,
                                ColumnSearchPurchaseOrderItemUnitId = d.UnitId,
                                ColumnSearchPurchaseOrderItemUnit = d.Unit,
                                ColumnSearchPurchaseOrderItemBaseQuantity = d.BaseQuantity.ToString("#,#00.00"),
                                ColumnSearchPurchaseOrderItemBaseCost = d.BaseCost.ToString("#,#00.00"),
                                ColumnSearchPurchaseOrderItemVATInTaxId = d.VATInTaxId,
                                ColumnSearchPurchaseOrderItemVATInTaxRate = d.VATInTaxRate.ToString("#,#00.00"),
                                ColumnSearchPurchaseOrderItemButtonPick = "Pick"
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvSearchPurchaseOrderItemEntity>());
            }
        }

        public void CreateSearchPurchaseOrderItemDataGridView()
        {
            UpdateSearchPurchaseOrderItemDataSource();

            dataGridViewSearchPurchaseOrderItem.Columns[dataGridViewSearchPurchaseOrderItem.Columns["ColumnSearchPurchaseOrderItemButtonPick"].Index].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSearchPurchaseOrderItem.Columns[dataGridViewSearchPurchaseOrderItem.Columns["ColumnSearchPurchaseOrderItemButtonPick"].Index].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSearchPurchaseOrderItem.Columns[dataGridViewSearchPurchaseOrderItem.Columns["ColumnSearchPurchaseOrderItemButtonPick"].Index].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewSearchPurchaseOrderItem.DataSource = searchItemDataSource;
        }

        public void GetSearchPurchaseOrderItemCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewSearchPurchaseOrderItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewSearchPurchaseOrderItem.CurrentCell.ColumnIndex == dataGridViewSearchPurchaseOrderItem.Columns["ColumnSearchPurchaseOrderItemButtonPick"].Index)
            {
                var RRId = trnReceivingReceiptEntity.Id;
                var POId = Convert.ToInt32(comboBoxPONumber.SelectedValue);
                var itemId = Convert.ToInt32(dataGridViewSearchPurchaseOrderItem.Rows[e.RowIndex].Cells[dataGridViewSearchPurchaseOrderItem.Columns["ColumnSearchPurchaseOrderItemId"].Index].Value);
                var itemDescription = dataGridViewSearchPurchaseOrderItem.Rows[e.RowIndex].Cells[dataGridViewSearchPurchaseOrderItem.Columns["ColumnSearchPurchaseOrderItemDescription"].Index].Value.ToString();
                var unitId = Convert.ToInt32(dataGridViewSearchPurchaseOrderItem.Rows[e.RowIndex].Cells[dataGridViewSearchPurchaseOrderItem.Columns["ColumnSearchPurchaseOrderItemUnitId"].Index].Value);
                var unit = dataGridViewSearchPurchaseOrderItem.Rows[e.RowIndex].Cells[dataGridViewSearchPurchaseOrderItem.Columns["ColumnSearchPurchaseOrderItemUnit"].Index].Value.ToString();
                var quantity = Convert.ToDecimal(dataGridViewSearchPurchaseOrderItem.Rows[e.RowIndex].Cells[dataGridViewSearchPurchaseOrderItem.Columns["ColumnSearchPurchaseOrderItemBaseQuantity"].Index].Value);
                var cost = Convert.ToDecimal(dataGridViewSearchPurchaseOrderItem.Rows[e.RowIndex].Cells[dataGridViewSearchPurchaseOrderItem.Columns["ColumnSearchPurchaseOrderItemBaseCost"].Index].Value);
                var taxId = Convert.ToInt32(dataGridViewSearchPurchaseOrderItem.Rows[e.RowIndex].Cells[dataGridViewSearchPurchaseOrderItem.Columns["ColumnSearchPurchaseOrderItemVATInTaxId"].Index].Value);
                var taxRate = Convert.ToDecimal(dataGridViewSearchPurchaseOrderItem.Rows[e.RowIndex].Cells[dataGridViewSearchPurchaseOrderItem.Columns["ColumnSearchPurchaseOrderItemVATInTaxRate"].Index].Value);
                var branchId = trnReceivingReceiptEntity.BranchId;

                Entities.TrnReceivingReceiptItemEntity trnReceivingReceiptItemEntity = new Entities.TrnReceivingReceiptItemEntity()
                {
                    Id = 0,
                    RRId = RRId,
                    POId = POId,
                    ItemId = itemId,
                    ItemDescription = itemDescription,
                    UnitId = unitId,
                    Unit = unit,
                    Quantity = quantity,
                    Cost = cost,
                    TaxId = taxId,
                    TaxRate = taxRate,
                    TaxAmount = 0,
                    BranchId = branchId,
                    Amount = quantity * cost,
                    BaseCost = 0,
                    BaseQuantity = 0
                };

                TrnReceivingReceiptDetailReceivingReceiptItemDetailForm trnReceivingReceiptDetailReceivingReceiptItemDetailForm = new TrnReceivingReceiptDetailReceivingReceiptItemDetailForm(trnReceivingReceiptDetailForm, trnReceivingReceiptItemEntity);
                trnReceivingReceiptDetailReceivingReceiptItemDetailForm.ShowDialog();
            }
        }

        private void textBoxSearchPurchaseOrderItemFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateSearchPurchaseOrderItemDataSource();
                pageNumber = 1;
            }
        }

        private void buttonSearchPurchaseOrderItemPageListFirst_Click(object sender, EventArgs e)
        {
            searchItemPageList = new PagedList<Entities.DgvSearchPurchaseOrderItemEntity>(searchItemData, 1, pageSize);
            searchItemDataSource.DataSource = searchItemPageList;

            buttonSearchPurchaseOrderItemPageListFirst.Enabled = false;
            buttonSearchPurchaseOrderItemPageListPrevious.Enabled = false;
            buttonSearchPurchaseOrderItemPageListNext.Enabled = true;
            buttonSearchPurchaseOrderItemPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxSearchPurchaseOrderItemPageNumber.Text = pageNumber + " / " + searchItemPageList.PageCount;
        }

        private void buttonSearchPurchaseOrderItemPageListPrevious_Click(object sender, EventArgs e)
        {
            if (searchItemPageList.HasPreviousPage == true)
            {
                searchItemPageList = new PagedList<Entities.DgvSearchPurchaseOrderItemEntity>(searchItemData, --pageNumber, pageSize);
                searchItemDataSource.DataSource = searchItemPageList;
            }

            buttonSearchPurchaseOrderItemPageListNext.Enabled = true;
            buttonSearchPurchaseOrderItemPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonSearchPurchaseOrderItemPageListFirst.Enabled = false;
                buttonSearchPurchaseOrderItemPageListPrevious.Enabled = false;
            }

            textBoxSearchPurchaseOrderItemPageNumber.Text = pageNumber + " / " + searchItemPageList.PageCount;
        }

        private void buttonSearchPurchaseOrderItemPageListNext_Click(object sender, EventArgs e)
        {
            if (searchItemPageList.HasNextPage == true)
            {
                searchItemPageList = new PagedList<Entities.DgvSearchPurchaseOrderItemEntity>(searchItemData, ++pageNumber, pageSize);
                searchItemDataSource.DataSource = searchItemPageList;
            }

            buttonSearchPurchaseOrderItemPageListFirst.Enabled = true;
            buttonSearchPurchaseOrderItemPageListPrevious.Enabled = true;

            if (pageNumber == searchItemPageList.PageCount)
            {
                buttonSearchPurchaseOrderItemPageListNext.Enabled = false;
                buttonSearchPurchaseOrderItemPageListLast.Enabled = false;
            }

            textBoxSearchPurchaseOrderItemPageNumber.Text = pageNumber + " / " + searchItemPageList.PageCount;
        }

        private void buttonSearchPurchaseOrderItemPageListLast_Click(object sender, EventArgs e)
        {
            searchItemPageList = new PagedList<Entities.DgvSearchPurchaseOrderItemEntity>(searchItemData, searchItemPageList.PageCount, pageSize);
            searchItemDataSource.DataSource = searchItemPageList;

            buttonSearchPurchaseOrderItemPageListFirst.Enabled = true;
            buttonSearchPurchaseOrderItemPageListPrevious.Enabled = true;
            buttonSearchPurchaseOrderItemPageListNext.Enabled = false;
            buttonSearchPurchaseOrderItemPageListLast.Enabled = false;

            pageNumber = searchItemPageList.PageCount;
            textBoxSearchPurchaseOrderItemPageNumber.Text = pageNumber + " / " + searchItemPageList.PageCount;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBoxPONumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSearchPurchaseOrderItemDataSource();
        }
    }
}
