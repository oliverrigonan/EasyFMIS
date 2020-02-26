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

namespace easyfmis.Forms.Software.TrnCollection
{
    public partial class TrnCollectionSalesInvoiceListForm : Form
    {
        public Entities.TrnSalesInvoiceEntity trnSalesInvoiceEntity;

        public static Int32 pageSize = 50;

        public Entities.TrnCollectionLineEntity newCollectionLineEntity;
        public TrnCollectionDetailForm trnCollectionDetailForm;
        public Int32 CustomerId;

        public static List<Entities.DgvTrnCollectionSalesInvoiceListEntity> salesInvoiceData = new List<Entities.DgvTrnCollectionSalesInvoiceListEntity>();
        public static Int32 salesInvoicePageNumber = 1;
        public PagedList<Entities.DgvTrnCollectionSalesInvoiceListEntity> searchInventoryItemPageList = new PagedList<Entities.DgvTrnCollectionSalesInvoiceListEntity>(salesInvoiceData, salesInvoicePageNumber, pageSize);
        public BindingSource salesInvoiceDataSource = new BindingSource();

        public TrnCollectionSalesInvoiceListForm(TrnCollectionDetailForm collectionDetailForm, Int32 customerId, Entities.TrnCollectionLineEntity collectionLineEntity)
        {
            InitializeComponent();
            trnCollectionDetailForm = collectionDetailForm;
            newCollectionLineEntity = collectionLineEntity;
            CustomerId = customerId;

            CreateSalesInvoiceDataGridView();
        }

        public void UpdateSalesInvoiceDataSource()
        {
            SetSalesInvoiceDataSourceAsync();
        }

        public async void SetSalesInvoiceDataSourceAsync()
        {
            List<Entities.DgvTrnCollectionSalesInvoiceListEntity> getSalesInvoiceData = await GetSalesInvoiceDataTask();
            if (getSalesInvoiceData.Any())
            {
                salesInvoicePageNumber = 1;
                salesInvoiceData = getSalesInvoiceData;
                searchInventoryItemPageList = new PagedList<Entities.DgvTrnCollectionSalesInvoiceListEntity>(salesInvoiceData, salesInvoicePageNumber, pageSize);

                if (searchInventoryItemPageList.PageCount == 1)
                {
                    buttonSalesInvoicePageListFirst.Enabled = false;
                    buttonSalesInvoicePageListPrevious.Enabled = false;
                    buttonSalesInvoicePageListNext.Enabled = false;
                    buttonSalesInvoicePageListLast.Enabled = false;
                }
                else if (salesInvoicePageNumber == 1)
                {
                    buttonSalesInvoicePageListFirst.Enabled = false;
                    buttonSalesInvoicePageListPrevious.Enabled = false;
                    buttonSalesInvoicePageListNext.Enabled = true;
                    buttonSalesInvoicePageListLast.Enabled = true;
                }
                else if (salesInvoicePageNumber == searchInventoryItemPageList.PageCount)
                {
                    buttonSalesInvoicePageListFirst.Enabled = true;
                    buttonSalesInvoicePageListPrevious.Enabled = true;
                    buttonSalesInvoicePageListNext.Enabled = false;
                    buttonSalesInvoicePageListLast.Enabled = false;
                }
                else
                {
                    buttonSalesInvoicePageListFirst.Enabled = true;
                    buttonSalesInvoicePageListPrevious.Enabled = true;
                    buttonSalesInvoicePageListNext.Enabled = true;
                    buttonSalesInvoicePageListLast.Enabled = true;
                }

                textBoxSalesInvoicePageNumber.Text = salesInvoicePageNumber + " / " + searchInventoryItemPageList.PageCount;
                salesInvoiceDataSource.DataSource = searchInventoryItemPageList;
            }
            else
            {
                buttonSalesInvoicePageListFirst.Enabled = false;
                buttonSalesInvoicePageListPrevious.Enabled = false;
                buttonSalesInvoicePageListNext.Enabled = false;
                buttonSalesInvoicePageListLast.Enabled = false;

                salesInvoicePageNumber = 1;

                salesInvoiceData = new List<Entities.DgvTrnCollectionSalesInvoiceListEntity>();
                salesInvoiceDataSource.Clear();
                textBoxSalesInvoicePageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvTrnCollectionSalesInvoiceListEntity>> GetSalesInvoiceDataTask()
        {
            String filter = textBoxSalesInvoiceFilter.Text;
            Controllers.TrnCollectionLineController trnCollectionLineController = new Controllers.TrnCollectionLineController();

            List<Entities.TrnCollectionSalesInvoiceListEntity> listSalesInvoice = trnCollectionLineController.ListSalesInvoice(CustomerId);
            if (listSalesInvoice.Any())
            {
                var items = from d in listSalesInvoice
                            where d.SINumber.ToLower().Contains(filter)
                            || d.ManualSINumber.ToLower().Contains(filter)
                            || d.Remarks.ToLower().Contains(filter)
                            select new Entities.DgvTrnCollectionSalesInvoiceListEntity
                            {
                                ColumnCollectionSalesInvoiceListId = d.Id,
                                ColumnCollectionSalesInvoiceListSINumber = d.SINumber,
                                ColumnCollectionSalesInvoiceListSIDate = d.SIDate.ToShortDateString(),
                                ColumnCollectionSalesInvoiceListManualSINumber = d.ManualSINumber,
                                ColumnCollectionSalesInvoiceListRemarks = d.Remarks,
                                ColumnCollectionSalesInvoiceListBalanceAmount = d.BalanceAmount.ToString("#,##0.00"),
                                ColumnCollectionSalesInvoiceListButtonPick = "Pick"
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvTrnCollectionSalesInvoiceListEntity>());
            }
        }

        public void CreateSalesInvoiceDataGridView()
        {
            UpdateSalesInvoiceDataSource();

            dataGridViewSalesInvoice.Columns[dataGridViewSalesInvoice.Columns["ColumnCollectionSalesInvoiceListButtonPick"].Index].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSalesInvoice.Columns[dataGridViewSalesInvoice.Columns["ColumnCollectionSalesInvoiceListButtonPick"].Index].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSalesInvoice.Columns[dataGridViewSalesInvoice.Columns["ColumnCollectionSalesInvoiceListButtonPick"].Index].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewSalesInvoice.DataSource = salesInvoiceDataSource;
        }

        public void GetSalesInvoiceCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewSalesInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewSalesInvoice.CurrentCell.ColumnIndex == dataGridViewSalesInvoice.Columns["ColumnCollectionSalesInvoiceListButtonPick"].Index)
            {
                var sIId = Convert.ToInt32(dataGridViewSalesInvoice.Rows[e.RowIndex].Cells[dataGridViewSalesInvoice.Columns["ColumnCollectionSalesInvoiceListId"].Index].Value);
                var sINumber = dataGridViewSalesInvoice.Rows[e.RowIndex].Cells[dataGridViewSalesInvoice.Columns["ColumnCollectionSalesInvoiceListSINumber"].Index].Value.ToString();
                var balanceAmount = dataGridViewSalesInvoice.Rows[e.RowIndex].Cells[dataGridViewSalesInvoice.Columns["ColumnCollectionSalesInvoiceListBalanceAmount"].Index].Value.ToString();

                Entities.TrnCollectionLineEntity collectionLineEntity = new Entities.TrnCollectionLineEntity()
                {
                    Id = newCollectionLineEntity.Id,
                    ORId = newCollectionLineEntity.ORId,
                    ArticleGroupId = 0,
                    ArticleGroup = "",
                    SIId = sIId,
                    SINumber = sINumber,
                    Amount = Convert.ToDecimal(balanceAmount),
                    PayTypeId = 0,
                    PayType = "",
                    CheckNumber = "",
                    CheckDate = null,
                    CheckBank = "",
                    CreditCardVerificationCode = "",
                    CreditCardNumber = "",
                    CreditCardType = "",
                    CreditCardBank = "",
                    CreditCardReferenceNumber = "",
                    CreditCardHolderName = "",
                    CreditCardExpiry = "",
                    GiftCertificateNumber = "",
                    OtherInformation = ""
                };

                TrnCollectionDetailCollectionLineDetailForm trnCollectionDetailCollectionLineDetailForm = new TrnCollectionDetailCollectionLineDetailForm(trnCollectionDetailForm, collectionLineEntity);
                trnCollectionDetailCollectionLineDetailForm.ShowDialog();
            }
        }

        private void textBoxSalesInvoiceFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateSalesInvoiceDataSource();
                salesInvoicePageNumber = 1;
            }
        }

        private void buttonSalesInvoicePageListFirst_Click(object sender, EventArgs e)
        {
            searchInventoryItemPageList = new PagedList<Entities.DgvTrnCollectionSalesInvoiceListEntity>(salesInvoiceData, 1, pageSize);
            salesInvoiceDataSource.DataSource = searchInventoryItemPageList;

            buttonSalesInvoicePageListFirst.Enabled = false;
            buttonSalesInvoicePageListPrevious.Enabled = false;
            buttonSalesInvoicePageListNext.Enabled = true;
            buttonSalesInvoicePageListLast.Enabled = true;

            salesInvoicePageNumber = 1;
            textBoxSalesInvoicePageNumber.Text = salesInvoicePageNumber + " / " + searchInventoryItemPageList.PageCount;
        }

        private void buttonSalesInvoicePageListPrevious_Click(object sender, EventArgs e)
        {
            if (searchInventoryItemPageList.HasPreviousPage == true)
            {
                searchInventoryItemPageList = new PagedList<Entities.DgvTrnCollectionSalesInvoiceListEntity>(salesInvoiceData, --salesInvoicePageNumber, pageSize);
                salesInvoiceDataSource.DataSource = searchInventoryItemPageList;
            }

            buttonSalesInvoicePageListNext.Enabled = true;
            buttonSalesInvoicePageListLast.Enabled = true;

            if (salesInvoicePageNumber == 1)
            {
                buttonSalesInvoicePageListFirst.Enabled = false;
                buttonSalesInvoicePageListPrevious.Enabled = false;
            }

            textBoxSalesInvoicePageNumber.Text = salesInvoicePageNumber + " / " + searchInventoryItemPageList.PageCount;
        }

        private void buttonSalesInvoicePageListNext_Click(object sender, EventArgs e)
        {
            if (searchInventoryItemPageList.HasNextPage == true)
            {
                searchInventoryItemPageList = new PagedList<Entities.DgvTrnCollectionSalesInvoiceListEntity>(salesInvoiceData, ++salesInvoicePageNumber, pageSize);
                salesInvoiceDataSource.DataSource = searchInventoryItemPageList;
            }

            buttonSalesInvoicePageListFirst.Enabled = true;
            buttonSalesInvoicePageListPrevious.Enabled = true;

            if (salesInvoicePageNumber == searchInventoryItemPageList.PageCount)
            {
                buttonSalesInvoicePageListNext.Enabled = false;
                buttonSalesInvoicePageListLast.Enabled = false;
            }

            textBoxSalesInvoicePageNumber.Text = salesInvoicePageNumber + " / " + searchInventoryItemPageList.PageCount;
        }

        private void buttonSalesInvoicePageListLast_Click(object sender, EventArgs e)
        {
            searchInventoryItemPageList = new PagedList<Entities.DgvTrnCollectionSalesInvoiceListEntity>(salesInvoiceData, searchInventoryItemPageList.PageCount, pageSize);
            salesInvoiceDataSource.DataSource = searchInventoryItemPageList;

            buttonSalesInvoicePageListFirst.Enabled = true;
            buttonSalesInvoicePageListPrevious.Enabled = true;
            buttonSalesInvoicePageListNext.Enabled = false;
            buttonSalesInvoicePageListLast.Enabled = false;

            salesInvoicePageNumber = searchInventoryItemPageList.PageCount;
            textBoxSalesInvoicePageNumber.Text = salesInvoicePageNumber + " / " + searchInventoryItemPageList.PageCount;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TrnSalesInvoiceDetailSearchItemForm_Load(object sender, EventArgs e)
        {

        }
    }
}
