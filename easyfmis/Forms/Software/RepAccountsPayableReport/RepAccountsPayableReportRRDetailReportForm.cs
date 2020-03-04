using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software.RepAccountsPayableReport
{
    public partial class RepAccountsPayableReportRRDetailReportForm : Form
    {
        public List<Entities.DgvRepAccountsPayableReceivingReceiptDetailReportEntity> receivingReceiptDetailReportList;
        public BindingSource dataReceivingReceiptDetailReportListSource = new BindingSource();
        public PagedList<Entities.DgvRepAccountsPayableReceivingReceiptDetailReportEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;

        DateTime DateStart;
        DateTime DateEnd;
        Int32 CompanyId;
        Int32 BranchId;



        public RepAccountsPayableReportRRDetailReportForm(DateTime filterDateStart, DateTime filterDateEnd, Int32 filterCompanyId, String filterCompanyName, Int32 filterBranchId, String filterBranchName)
        {
            InitializeComponent();

            DateStart = filterDateStart;
            DateEnd = filterDateEnd;
            CompanyId = filterCompanyId;
            BranchId = filterBranchId;

            textBoxStartDate.Text = filterDateStart.Date.ToShortDateString();
            textBoxEndDate.Text = filterDateEnd.Date.ToShortDateString();
            textBoxCompany.Text = filterCompanyName;
            textBoxBranch.Text = filterBranchName;

            CreateReceivingReceiptReportDataGridView();
        }

        public List<Entities.DgvRepAccountsPayableReceivingReceiptDetailReportEntity> GetRecevingReceiptReportListData(DateTime filterDateStart, DateTime filterDateEnd, Int32 filterCompanyId, Int32 filterBranchId)
        {
            String filter = textBoxItemListFilter.Text;
            List<Entities.DgvRepAccountsPayableReceivingReceiptDetailReportEntity> rowList = new List<Entities.DgvRepAccountsPayableReceivingReceiptDetailReportEntity>();

            Controllers.RepAccountsPayableReportController repAccountsPayableReportController = new Controllers.RepAccountsPayableReportController();

            var receivingReceiptDetailReportList = repAccountsPayableReportController.ListReceivingReceiptDetailReport(filterDateStart, filterDateEnd, filterCompanyId, filterBranchId, filter);
            if (receivingReceiptDetailReportList.Any())
            {
                var row = from d in receivingReceiptDetailReportList
                          select new Entities.DgvRepAccountsPayableReceivingReceiptDetailReportEntity
                          {
                              ColumnRepAccountsPayableReceivingReceiptDetailListId = d.Id,
                              ColumnRepAccountsPayableReceivingReceiptDetailListBranch = d.Branch,
                              ColumnRepAccountsPayableReceivingReceiptDetailListRRNumber = d.RRNumber,
                              ColumnRepAccountsPayableReceivingReceiptDetailListRRDate = d.RRDate.ToShortDateString(),
                              ColumnRepAccountsPayableReceivingReceiptDetailListManualRRNumber = d.ManualRRNumber,
                              ColumnRepAccountsPayableReceivingReceiptDetailListSupplier = d.Supplier,
                              ColumnRepAccountsPayableReceivingReceiptDetailListTerm = d.Term,
                              ColumnRepAccountsPayableReceivingReceiptDetailListRemarks = d.Remarks,
                              ColumnRepAccountsPayableReceivingReceiptDetailListReceivedBy = d.ReceivedBy,
                              ColumnRepAccountsPayableReceivingReceiptDetailListPreparedBy = d.PreparedBy,
                              ColumnRepAccountsPayableReceivingReceiptDetailListCheckedBy = d.CheckedBy,
                              ColumnRepAccountsPayableReceivingReceiptDetailListApprovedBy = d.ApprovedBy,
                              ColumnRepAccountsPayableReceivingReceiptDetailListPaidAmount = d.PaidAmount.ToString("#,##0.00"),
                              ColumnRepAccountsPayableReceivingReceiptDetailListMemoAmount = d.MemoAmount.ToString("#,##0.00"),
                              ColumnRepAccountsPayableReceivingReceiptDetailListPONumber = d.PONumber,
                              ColumnRepAccountsPayableReceivingReceiptDetailListItemCode = d.ItemCode,
                              ColumnRepAccountsPayableReceivingReceiptDetailListItemDescription = d.ItemDescription,
                              ColumnRepAccountsPayableReceivingReceiptDetailListUnit = d.Unit,
                              ColumnRepAccountsPayableReceivingReceiptDetailListQuantity = d.Quantity.ToString("#,##0.00"),
                              ColumnRepAccountsPayableReceivingReceiptDetailListCost = d.Cost.ToString("#,##0.00"),
                              ColumnRepAccountsPayableReceivingReceiptDetailListAmount = d.Amount.ToString("#,##0.00"),
                              ColumnRepAccountsPayableReceivingReceiptDetailListTax = d.Tax,
                              ColumnRepAccountsPayableReceivingReceiptDetailListTaxRate = d.TaxRate.ToString("#,##0.00"),
                              ColumnRepAccountsPayableReceivingReceiptDetailListTaxAmount = d.TaxAmount.ToString("#,##0.00"),
                              ColumnRepAccountsPayableReceivingReceiptDetailListBaseQuantity = d.BaseQuantity.ToString("#,##0.00"),
                              ColumnRepAccountsPayableReceivingReceiptDetailListBaseCost = d.BaseCost.ToString("#,##0.00")
                          };

                rowList = row.ToList();

                Decimal totalPaidAmount = receivingReceiptDetailReportList.Sum(d=> d.PaidAmount);
                Decimal totalMemoAmount = receivingReceiptDetailReportList.Sum(d => d.MemoAmount);
                Decimal totalCost = receivingReceiptDetailReportList.Sum(d => d.Cost);
                Decimal totalAmount = receivingReceiptDetailReportList.Sum(d => d.Amount);
                Decimal totalTaxAmount = receivingReceiptDetailReportList.Sum(d => d.TaxAmount);
                Decimal totalBaseCost = receivingReceiptDetailReportList.Sum(d => d.BaseCost);


                Entities.DgvRepAccountsPayableReceivingReceiptDetailReportEntity totalReceivingReceiptDetailReport = new Entities.DgvRepAccountsPayableReceivingReceiptDetailReportEntity()
                {
                    ColumnRepAccountsPayableReceivingReceiptDetailListId = 0,
                    ColumnRepAccountsPayableReceivingReceiptDetailListBranch = "Total",
                    ColumnRepAccountsPayableReceivingReceiptDetailListRRNumber = "",
                    ColumnRepAccountsPayableReceivingReceiptDetailListRRDate = "",
                    ColumnRepAccountsPayableReceivingReceiptDetailListManualRRNumber = "",
                    ColumnRepAccountsPayableReceivingReceiptDetailListSupplier = "",
                    ColumnRepAccountsPayableReceivingReceiptDetailListTerm = "",
                    ColumnRepAccountsPayableReceivingReceiptDetailListRemarks = "",
                    ColumnRepAccountsPayableReceivingReceiptDetailListReceivedBy = "",
                    ColumnRepAccountsPayableReceivingReceiptDetailListPreparedBy = "",
                    ColumnRepAccountsPayableReceivingReceiptDetailListCheckedBy = "",
                    ColumnRepAccountsPayableReceivingReceiptDetailListApprovedBy = "",
                    ColumnRepAccountsPayableReceivingReceiptDetailListPaidAmount = totalPaidAmount.ToString("#,##0.00"),
                    ColumnRepAccountsPayableReceivingReceiptDetailListMemoAmount = totalMemoAmount.ToString("#,##0.00"),
                    ColumnRepAccountsPayableReceivingReceiptDetailListPONumber = "",
                    ColumnRepAccountsPayableReceivingReceiptDetailListItemCode = "",
                    ColumnRepAccountsPayableReceivingReceiptDetailListItemDescription = "",
                    ColumnRepAccountsPayableReceivingReceiptDetailListUnit = "",
                    ColumnRepAccountsPayableReceivingReceiptDetailListQuantity = "",
                    ColumnRepAccountsPayableReceivingReceiptDetailListCost = "",
                    ColumnRepAccountsPayableReceivingReceiptDetailListAmount = totalAmount.ToString("#,##0.00"),
                    ColumnRepAccountsPayableReceivingReceiptDetailListTax = "",
                    ColumnRepAccountsPayableReceivingReceiptDetailListTaxRate = "",
                    ColumnRepAccountsPayableReceivingReceiptDetailListTaxAmount = totalTaxAmount.ToString("#,##0.00"),
                    ColumnRepAccountsPayableReceivingReceiptDetailListBaseQuantity = "",
                    ColumnRepAccountsPayableReceivingReceiptDetailListBaseCost = ""
                };

                rowList.Add(totalReceivingReceiptDetailReport);

            }
            return rowList;
        }

        public void GetReceivingReceiptReportDataSource()
        {
            receivingReceiptDetailReportList = GetRecevingReceiptReportListData(DateStart, DateEnd, CompanyId, BranchId);
            if (receivingReceiptDetailReportList.Any())
            {
                pageNumber = 1;
                pageList = new PagedList<Entities.DgvRepAccountsPayableReceivingReceiptDetailReportEntity>(receivingReceiptDetailReportList, pageNumber, pageSize);

                if (pageList.PageCount == 1)
                {
                    buttonRRDetailReportPageListFirst.Enabled = false;
                    buttonRRDetailReportPageListPrevious.Enabled = false;
                    buttonRRDetailReportPageListNext.Enabled = false;
                    buttonRRDetailReportPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonRRDetailReportPageListFirst.Enabled = false;
                    buttonRRDetailReportPageListPrevious.Enabled = false;
                    buttonRRDetailReportPageListNext.Enabled = true;
                    buttonRRDetailReportPageListLast.Enabled = true;
                }
                else if (pageNumber == pageList.PageCount)
                {
                    buttonRRDetailReportPageListFirst.Enabled = true;
                    buttonRRDetailReportPageListPrevious.Enabled = true;
                    buttonRRDetailReportPageListNext.Enabled = false;
                    buttonRRDetailReportPageListLast.Enabled = false;
                }
                else
                {
                    buttonRRDetailReportPageListFirst.Enabled = true;
                    buttonRRDetailReportPageListPrevious.Enabled = true;
                    buttonRRDetailReportPageListNext.Enabled = true;
                    buttonRRDetailReportPageListLast.Enabled = true;
                }

                textBoxRRDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
                dataReceivingReceiptDetailReportListSource.DataSource = pageList;
            }
            else
            {
                buttonRRDetailReportPageListFirst.Enabled = false;
                buttonRRDetailReportPageListPrevious.Enabled = false;
                buttonRRDetailReportPageListNext.Enabled = false;
                buttonRRDetailReportPageListLast.Enabled = false;

                dataReceivingReceiptDetailReportListSource.Clear();
                textBoxRRDetailReportPageNumber.Text = "0 / 0";
            }
        }

        public void CreateReceivingReceiptReportDataGridView()
        {
            GetReceivingReceiptReportDataSource();
            dataGridViewRRDetailReportReport.DataSource = dataReceivingReceiptDetailReportListSource;
        }

        public void UpdateReceivingReceiptReportDataGridView()
        {
            CreateReceivingReceiptReportDataGridView();
        }

        private void buttonReceivingReceiptReportPageListFirst_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepAccountsPayableReceivingReceiptDetailReportEntity>(receivingReceiptDetailReportList, 1, pageSize);
            dataReceivingReceiptDetailReportListSource.DataSource = pageList;

            buttonRRDetailReportPageListFirst.Enabled = false;
            buttonRRDetailReportPageListPrevious.Enabled = false;
            buttonRRDetailReportPageListNext.Enabled = true;
            buttonRRDetailReportPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxRRDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonReceivingReceiptReportPageListPrevious_Click(object sender, EventArgs e)
        {
            if (pageList.HasPreviousPage == true)
            {
                pageList = new PagedList<Entities.DgvRepAccountsPayableReceivingReceiptDetailReportEntity>(receivingReceiptDetailReportList, --pageNumber, pageSize);
                dataReceivingReceiptDetailReportListSource.DataSource = pageList;
            }

            buttonRRDetailReportPageListNext.Enabled = true;
            buttonRRDetailReportPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonRRDetailReportPageListFirst.Enabled = false;
                buttonRRDetailReportPageListPrevious.Enabled = false;
            }

            textBoxRRDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonReceivingReceiptReportPageListNext_Click(object sender, EventArgs e)
        {
            if (pageList.HasNextPage == true)
            {
                pageList = new PagedList<Entities.DgvRepAccountsPayableReceivingReceiptDetailReportEntity>(receivingReceiptDetailReportList, ++pageNumber, pageSize);
                dataReceivingReceiptDetailReportListSource.DataSource = pageList;
            }

            buttonRRDetailReportPageListFirst.Enabled = true;
            buttonRRDetailReportPageListPrevious.Enabled = true;

            if (pageNumber == pageList.PageCount)
            {
                buttonRRDetailReportPageListNext.Enabled = false;
                buttonRRDetailReportPageListLast.Enabled = false;
            }

            textBoxRRDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonReceivingReceiptReportPageListLast_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepAccountsPayableReceivingReceiptDetailReportEntity>(receivingReceiptDetailReportList, pageList.PageCount, pageSize);
            dataReceivingReceiptDetailReportListSource.DataSource = pageList;

            buttonRRDetailReportPageListFirst.Enabled = true;
            buttonRRDetailReportPageListPrevious.Enabled = true;
            buttonRRDetailReportPageListNext.Enabled = false;
            buttonRRDetailReportPageListLast.Enabled = false;

            pageNumber = pageList.PageCount;
            textBoxRRDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonClose_OnClick(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonGenerateCSV_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = folderBrowserDialogGenerateCSV.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    StringBuilder csv = new StringBuilder();

                    String[] header =
                    {
                        "Branch",
                        "RRNumber",
                        "RRDate",
                        "ManualRRNumber",
                        "Supplier",
                        "Term",
                        "Remarks",
                        "ReceivedBy",
                        "PreparedBy",
                        "CheckedBy",
                        "ApprovedBy",
                        "PaidAmount",
                        "MemoAmount",
                        "PONumber",
                        "ItemCode",
                        "ItemDescription",
                        "Unit",
                        "Quantity",
                        "Cost",
                        "Amount",
                        "Tax",
                        "TaxRate",
                        "TaxAmount",
                        "BaseQuantity",
                        "BaseCost"
                    };

                    csv.AppendLine(String.Join(",", header));

                    if (receivingReceiptDetailReportList.Any())
                    {
                        foreach (var receivingReceiptDetailReport in receivingReceiptDetailReportList)
                        {
                            String[] data =
                            {
                                receivingReceiptDetailReport.ColumnRepAccountsPayableReceivingReceiptDetailListBranch.Replace(",", ""),
                                receivingReceiptDetailReport.ColumnRepAccountsPayableReceivingReceiptDetailListRRNumber.Replace(",", ""),
                                receivingReceiptDetailReport.ColumnRepAccountsPayableReceivingReceiptDetailListRRDate.Replace(",", ""),
                                receivingReceiptDetailReport.ColumnRepAccountsPayableReceivingReceiptDetailListManualRRNumber.Replace(",", ""),
                                receivingReceiptDetailReport.ColumnRepAccountsPayableReceivingReceiptDetailListSupplier.Replace(",", ""),
                                receivingReceiptDetailReport.ColumnRepAccountsPayableReceivingReceiptDetailListTerm.Replace(",", ""),
                                receivingReceiptDetailReport.ColumnRepAccountsPayableReceivingReceiptDetailListRemarks.Replace(",", ""),
                                receivingReceiptDetailReport.ColumnRepAccountsPayableReceivingReceiptDetailListReceivedBy.Replace(",", ""),
                                receivingReceiptDetailReport.ColumnRepAccountsPayableReceivingReceiptDetailListPreparedBy.Replace(",", ""),
                                receivingReceiptDetailReport.ColumnRepAccountsPayableReceivingReceiptDetailListCheckedBy.Replace(",", ""),
                                receivingReceiptDetailReport.ColumnRepAccountsPayableReceivingReceiptDetailListApprovedBy.Replace(",", ""),
                                receivingReceiptDetailReport.ColumnRepAccountsPayableReceivingReceiptDetailListPaidAmount.Replace(",", ""),
                                receivingReceiptDetailReport.ColumnRepAccountsPayableReceivingReceiptDetailListMemoAmount.Replace(",", ""),
                                receivingReceiptDetailReport.ColumnRepAccountsPayableReceivingReceiptDetailListPONumber.Replace(",", ""),
                                receivingReceiptDetailReport.ColumnRepAccountsPayableReceivingReceiptDetailListItemCode.Replace(",", ""),
                                receivingReceiptDetailReport.ColumnRepAccountsPayableReceivingReceiptDetailListItemDescription.Replace(",", ""),
                                receivingReceiptDetailReport.ColumnRepAccountsPayableReceivingReceiptDetailListUnit.Replace(",", ""),
                                receivingReceiptDetailReport.ColumnRepAccountsPayableReceivingReceiptDetailListQuantity.Replace(",", ""),
                                receivingReceiptDetailReport.ColumnRepAccountsPayableReceivingReceiptDetailListCost.Replace(",", ""),
                                receivingReceiptDetailReport.ColumnRepAccountsPayableReceivingReceiptDetailListAmount.Replace(",", ""),
                                receivingReceiptDetailReport.ColumnRepAccountsPayableReceivingReceiptDetailListTax.Replace(",", ""),
                                receivingReceiptDetailReport.ColumnRepAccountsPayableReceivingReceiptDetailListTaxRate.Replace(",", ""),
                                receivingReceiptDetailReport.ColumnRepAccountsPayableReceivingReceiptDetailListTaxAmount.Replace(",", ""),
                                receivingReceiptDetailReport.ColumnRepAccountsPayableReceivingReceiptDetailListBaseQuantity.Replace(",", ""),
                                receivingReceiptDetailReport.ColumnRepAccountsPayableReceivingReceiptDetailListBaseCost.Replace(",", "")
                            };

                            csv.AppendLine(String.Join(",", data));
                        }
                    }

                    String executingUser = WindowsIdentity.GetCurrent().Name;

                    DirectorySecurity securityRules = new DirectorySecurity();
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.Read, AccessControlType.Allow));
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.FullControl, AccessControlType.Allow));

                    DirectoryInfo createDirectorySTCSV = Directory.CreateDirectory(folderBrowserDialogGenerateCSV.SelectedPath, securityRules);
                    File.WriteAllText(createDirectorySTCSV.FullName + "\\ReceivingReceiptDetailReport_" + Convert.ToDateTime(textBoxStartDate.Text).ToString("yyyyMMdd") + ".csv", csv.ToString(), Encoding.GetEncoding("iso-8859-1"));

                    MessageBox.Show("Generate CSV Successful!", "Generate CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxItemListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateReceivingReceiptReportDataGridView();
            }
        }
    }
}
