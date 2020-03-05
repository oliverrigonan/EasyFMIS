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

namespace easyfmis.Forms.Software.TrnDisbursement
{
    public partial class TrnDisbursementReceivingReceiptListForm : Form
    {
        public Entities.TrnSalesInvoiceEntity trnSalesInvoiceEntity;

        public static Int32 pageSize = 50;

        public Entities.TrnDisbursementLineEntity trnDisbursementLineEntity;
        public TrnDisbursementDetailForm trnDisbursementDetailForm;
        public Entities.TrnDisbursementEntity trnDisbursementEntity;

        public static List<Entities.DgvTrnDisbursementReceivingReceiptListEntity> receivingReceiptData = new List<Entities.DgvTrnDisbursementReceivingReceiptListEntity>();
        public static Int32 pageNumber = 1;
        public PagedList<Entities.DgvTrnDisbursementReceivingReceiptListEntity> searchReceivingReceiptPageList = new PagedList<Entities.DgvTrnDisbursementReceivingReceiptListEntity>(receivingReceiptData, pageNumber, pageSize);
        public BindingSource receivingReceiptDataSource = new BindingSource();

        public TrnDisbursementReceivingReceiptListForm(TrnDisbursementDetailForm disbursementDetailForm,Entities.TrnDisbursementEntity disbursementEntity, Entities.TrnDisbursementLineEntity disbursementLineEntity)
        {
            InitializeComponent();
            trnDisbursementDetailForm = disbursementDetailForm;
            trnDisbursementLineEntity = disbursementLineEntity;
            trnDisbursementEntity = disbursementEntity;

            CreateReceivingReceiptDataGridView();
        }

        public void UpdateReceivingReceiptDataSource()
        {
            SetReceivingReceiptDataSourceAsync();
        }

        public async void SetReceivingReceiptDataSourceAsync()
        {
            List<Entities.DgvTrnDisbursementReceivingReceiptListEntity> getReceivingReceiptData = await GetReceivingReceiptDataTask();
            if (getReceivingReceiptData.Any())
            {
                pageNumber = 1;
                receivingReceiptData = getReceivingReceiptData;
                searchReceivingReceiptPageList = new PagedList<Entities.DgvTrnDisbursementReceivingReceiptListEntity>(receivingReceiptData, pageNumber, pageSize);

                if (searchReceivingReceiptPageList.PageCount == 1)
                {
                    buttonReceivingReceiptPageListFirst.Enabled = false;
                    buttonReceivingReceiptPageListPrevious.Enabled = false;
                    buttonReceivingReceiptPageListNext.Enabled = false;
                    buttonReceivingReceiptPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonReceivingReceiptPageListFirst.Enabled = false;
                    buttonReceivingReceiptPageListPrevious.Enabled = false;
                    buttonReceivingReceiptPageListNext.Enabled = true;
                    buttonReceivingReceiptPageListLast.Enabled = true;
                }
                else if (pageNumber == searchReceivingReceiptPageList.PageCount)
                {
                    buttonReceivingReceiptPageListFirst.Enabled = true;
                    buttonReceivingReceiptPageListPrevious.Enabled = true;
                    buttonReceivingReceiptPageListNext.Enabled = false;
                    buttonReceivingReceiptPageListLast.Enabled = false;
                }
                else
                {
                    buttonReceivingReceiptPageListFirst.Enabled = true;
                    buttonReceivingReceiptPageListPrevious.Enabled = true;
                    buttonReceivingReceiptPageListNext.Enabled = true;
                    buttonReceivingReceiptPageListLast.Enabled = true;
                }

                textBoxReceivingReceiptPageNumber.Text = pageNumber + " / " + searchReceivingReceiptPageList.PageCount;
                receivingReceiptDataSource.DataSource = searchReceivingReceiptPageList;
            }
            else
            {
                buttonReceivingReceiptPageListFirst.Enabled = false;
                buttonReceivingReceiptPageListPrevious.Enabled = false;
                buttonReceivingReceiptPageListNext.Enabled = false;
                buttonReceivingReceiptPageListLast.Enabled = false;

                pageNumber = 1;

                receivingReceiptData = new List<Entities.DgvTrnDisbursementReceivingReceiptListEntity>();
                receivingReceiptDataSource.Clear();
                textBoxReceivingReceiptPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvTrnDisbursementReceivingReceiptListEntity>> GetReceivingReceiptDataTask()
        {
            String filter = textBoxReceivingReceiptFilter.Text;
            Controllers.TrnDisbursementLineController trnDisbursementLineController = new Controllers.TrnDisbursementLineController();

            List<Entities.TrnReceivingReceiptEntity> listReceivingReceipt = trnDisbursementLineController.ReceivingReceiptList(trnDisbursementEntity.SupplierId);
            if (listReceivingReceipt.Any())
            {
                var items = from d in listReceivingReceipt
                            select new Entities.DgvTrnDisbursementReceivingReceiptListEntity
                            {
                                ColumnDisbursementReceivingReceiptListRRId = d.Id,
                                ColumnDisbursementReceivingReceiptListRRNumber = d.RRNumber,
                                ColumnDisbursementReceivingReceiptListRRDate = d.RRDate.ToShortDateString(),
                                ColumnDisbursementReceivingReceiptListManualRRNumber = d.ManualRRNumber,
                                ColumnDisbursementReceivingReceiptListRemarks = d.Remarks,
                                ColumnDisbursementReceivingReceiptListBalanceAmount = d.BalanceAmount.ToString("#,##.00"),
                                ColumnDisbursementReceivingReceiptListButtongPick = "Pick"

                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvTrnDisbursementReceivingReceiptListEntity>());
            }
        }

        public void CreateReceivingReceiptDataGridView()
        {
            UpdateReceivingReceiptDataSource();

            dataGridViewReceivingReceipt.Columns[dataGridViewReceivingReceipt.Columns["ColumnDisbursementReceivingReceiptListButtongPick"].Index].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewReceivingReceipt.Columns[dataGridViewReceivingReceipt.Columns["ColumnDisbursementReceivingReceiptListButtongPick"].Index].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewReceivingReceipt.Columns[dataGridViewReceivingReceipt.Columns["ColumnDisbursementReceivingReceiptListButtongPick"].Index].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewReceivingReceipt.DataSource = receivingReceiptDataSource;
        }

        public void GetSalesInvoiceCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewReceivingReceipt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewReceivingReceipt.CurrentCell.ColumnIndex == dataGridViewReceivingReceipt.Columns["ColumnDisbursementReceivingReceiptListButtongPick"].Index)
            {
                var rRId = Convert.ToInt32(dataGridViewReceivingReceipt.Rows[e.RowIndex].Cells[dataGridViewReceivingReceipt.Columns["ColumnDisbursementReceivingReceiptListRRId"].Index].Value);
                var rRNumber = dataGridViewReceivingReceipt.Rows[e.RowIndex].Cells[dataGridViewReceivingReceipt.Columns["ColumnDisbursementReceivingReceiptListRRNumber"].Index].Value.ToString();
                var balanceAmount = dataGridViewReceivingReceipt.Rows[e.RowIndex].Cells[dataGridViewReceivingReceipt.Columns["ColumnDisbursementReceivingReceiptListBalanceAmount"].Index].Value.ToString();

                Entities.TrnDisbursementLineEntity disbursementLineEntity = new Entities.TrnDisbursementLineEntity()
                {
                    Id = 0,
                    CVId = trnDisbursementEntity.Id,
                    ArticleGroupId = 0,
                    ArticleGroup = "",
                    RRId = rRId,
                    RRNumber = rRNumber,
                    Amount = Convert.ToDecimal(balanceAmount),
                    OtherInformation = ""
                };

                TrnDisbursementDetailDisbursementLineDetailForm trnDisbursementDetailDisbursementLineDetailForm = new TrnDisbursementDetailDisbursementLineDetailForm(trnDisbursementDetailForm, disbursementLineEntity, trnDisbursementEntity);
                trnDisbursementDetailDisbursementLineDetailForm.ShowDialog();
            }
        }

        private void textBoxSalesInvoiceFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateReceivingReceiptDataSource();
                pageNumber = 1;
            }
        }

        private void buttonSalesInvoicePageListFirst_Click(object sender, EventArgs e)
        {
            searchReceivingReceiptPageList = new PagedList<Entities.DgvTrnDisbursementReceivingReceiptListEntity>(receivingReceiptData, 1, pageSize);
            receivingReceiptDataSource.DataSource = searchReceivingReceiptPageList;

            buttonReceivingReceiptPageListFirst.Enabled = false;
            buttonReceivingReceiptPageListPrevious.Enabled = false;
            buttonReceivingReceiptPageListNext.Enabled = true;
            buttonReceivingReceiptPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxReceivingReceiptPageNumber.Text = pageNumber + " / " + searchReceivingReceiptPageList.PageCount;
        }

        private void buttonSalesInvoicePageListPrevious_Click(object sender, EventArgs e)
        {
            if (searchReceivingReceiptPageList.HasPreviousPage == true)
            {
                searchReceivingReceiptPageList = new PagedList<Entities.DgvTrnDisbursementReceivingReceiptListEntity>(receivingReceiptData, --pageNumber, pageSize);
                receivingReceiptDataSource.DataSource = searchReceivingReceiptPageList;
            }

            buttonReceivingReceiptPageListNext.Enabled = true;
            buttonReceivingReceiptPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonReceivingReceiptPageListFirst.Enabled = false;
                buttonReceivingReceiptPageListPrevious.Enabled = false;
            }

            textBoxReceivingReceiptPageNumber.Text = pageNumber + " / " + searchReceivingReceiptPageList.PageCount;
        }

        private void buttonSalesInvoicePageListNext_Click(object sender, EventArgs e)
        {
            if (searchReceivingReceiptPageList.HasNextPage == true)
            {
                searchReceivingReceiptPageList = new PagedList<Entities.DgvTrnDisbursementReceivingReceiptListEntity>(receivingReceiptData, ++pageNumber, pageSize);
                receivingReceiptDataSource.DataSource = searchReceivingReceiptPageList;
            }

            buttonReceivingReceiptPageListFirst.Enabled = true;
            buttonReceivingReceiptPageListPrevious.Enabled = true;

            if (pageNumber == searchReceivingReceiptPageList.PageCount)
            {
                buttonReceivingReceiptPageListNext.Enabled = false;
                buttonReceivingReceiptPageListLast.Enabled = false;
            }

            textBoxReceivingReceiptPageNumber.Text = pageNumber + " / " + searchReceivingReceiptPageList.PageCount;
        }

        private void buttonSalesInvoicePageListLast_Click(object sender, EventArgs e)
        {
            searchReceivingReceiptPageList = new PagedList<Entities.DgvTrnDisbursementReceivingReceiptListEntity>(receivingReceiptData, searchReceivingReceiptPageList.PageCount, pageSize);
            receivingReceiptDataSource.DataSource = searchReceivingReceiptPageList;

            buttonReceivingReceiptPageListFirst.Enabled = true;
            buttonReceivingReceiptPageListPrevious.Enabled = true;
            buttonReceivingReceiptPageListNext.Enabled = false;
            buttonReceivingReceiptPageListLast.Enabled = false;

            pageNumber = searchReceivingReceiptPageList.PageCount;
            textBoxReceivingReceiptPageNumber.Text = pageNumber + " / " + searchReceivingReceiptPageList.PageCount;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
