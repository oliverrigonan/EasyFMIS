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

namespace easyfmis.Forms.Software.RepAccountsReceivableReport
{
    public partial class RepAccountReceivableSalesOrderDetailReportReportForm : Form
    {
        public List<Entities.DgvRepAccountsReceivableSalesOrderDetailReportEntity> salesOrderDetailReportList;
        public BindingSource dataSalesOrderDetailReportListSource = new BindingSource();
        public PagedList<Entities.DgvRepAccountsReceivableSalesOrderDetailReportEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;

        DateTime DateStart;
        DateTime DateEnd;
        Int32 CompanyId;
        Int32 BranchId;


        public RepAccountReceivableSalesOrderDetailReportReportForm(DateTime filterDateStart, DateTime filterDateEnd, Int32 filterCompanyId, String filterCompanyName, Int32 filterBranchId, String filterBranchName)
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

            CreateSalesOrderDetailReportDataGridView();
        }

        public List<Entities.DgvRepAccountsReceivableSalesOrderDetailReportEntity> GetSalesOrderDetailReportListData(DateTime filterDateStart, DateTime filterDateEnd, Int32 filterCompanyId, Int32 filterBranchId)
        {
            List<Entities.DgvRepAccountsReceivableSalesOrderDetailReportEntity> rowList = new List<Entities.DgvRepAccountsReceivableSalesOrderDetailReportEntity>();

            Controllers.RepAccountsReceivableReportController RepAccountsReceivableReportController = new Controllers.RepAccountsReceivableReportController();

            var salesOrderDetailReportList = RepAccountsReceivableReportController.ListSalesOrederDetailReport(filterDateStart, filterDateEnd, filterCompanyId, filterBranchId);
            if (salesOrderDetailReportList.Any())
            {
                var row = from d in salesOrderDetailReportList
                          select new Entities.DgvRepAccountsReceivableSalesOrderDetailReportEntity
                          {
                              ColumnSalesOrderDetailReportListBranch = d.Branch,
                              ColumnSalesOrderDetailReportListSONumber = d.SONumber,
                              ColumnSalesOrderDetailReportListSODate = d.SODate.ToShortTimeString(),
                              ColumnSalesOrderDetailReportListManualSONumber = d.ManualSONumber,
                              ColumnSalesOrderDetailReportListCustomer = d.Customer,
                              ColumnSalesOrderDetailReportListTerm = d.Term,
                              ColumnSalesOrderDetailReportListRemarks = d.Remarks,
                              ColumnSalesOrderDetailReportListSoldBy = d.SoldBy,
                              ColumnSalesOrderDetailReportListPreparedBy = d.PreparedBy,
                              ColumnSalesOrderDetailReportListCheckedBy = d.CheckedBy,
                              ColumnSalesOrderDetailReportListApprovedBy = d.ApprovedBy,
                              ColumnSalesOrderDetailReportListItemCode = d.ItemCode,
                              ColumnSalesOrderDetailReportListItemDescription = d.ItemDescription,
                              ColumnSalesOrderDetailReportListItemInventoryCode = d.ItemInventoryCode,
                              ColumnSalesOrderDetailReportListUnit = d.Unit,
                              ColumnSalesOrderDetailReportListPrice = d.Price.ToString("#,##0.00"),
                              ColumnSalesOrderDetailReportListDiscount = d.Discount,
                              ColumnSalesOrderDetailReportListDiscountRate = d.DiscountRate.ToString("#,##0.00"),
                              ColumnSalesOrderDetailReportListDiscountAmount = d.DiscountAmount.ToString("#,##0.00"),
                              ColumnSalesOrderDetailReportListNetPrice = d.NetPrice.ToString("#,##0.00"),
                              ColumnSalesOrderDetailReportListQuantity = d.Quantity.ToString("#,##0.00"),
                              ColumnSalesOrderDetailReportListAmount = d.Amount.ToString("#,##0.00"),
                              ColumnSalesOrderDetailReportListTax = d.Tax,
                              ColumnSalesOrderDetailReportListTaxRate = d.TaxRate.ToString("#,##0.00"),
                              ColumnSalesOrderDetailReportListTaxAmount = d.TaxAmount.ToString("#,##0.00"),
                              ColumnSalesOrderDetailReportListBaseQuantity = d.BaseQuantity.ToString("#,##0.00"),
                              ColumnSalesOrderDetailReportListBasePrice = d.BaseQuantity.ToString("#,##0.00")
                          };

                rowList = row.ToList();

            }
            return rowList;
        }

        public void GetSalesOrderDetailReportDataSource()
        {
            salesOrderDetailReportList = GetSalesOrderDetailReportListData(DateStart, DateEnd, CompanyId, BranchId);
            if (salesOrderDetailReportList.Any())
            {
                pageNumber = 1;
                pageList = new PagedList<Entities.DgvRepAccountsReceivableSalesOrderDetailReportEntity>(salesOrderDetailReportList, pageNumber, pageSize);

                if (pageList.PageCount == 1)
                {
                    buttonSalesOrderDetailReportPageListFirst.Enabled = false;
                    buttonSalesOrderDetailReportPageListPrevious.Enabled = false;
                    buttonSalesOrderDetailReportPageListNext.Enabled = false;
                    buttonSalesOrderDetailReportPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonSalesOrderDetailReportPageListFirst.Enabled = false;
                    buttonSalesOrderDetailReportPageListPrevious.Enabled = false;
                    buttonSalesOrderDetailReportPageListNext.Enabled = true;
                    buttonSalesOrderDetailReportPageListLast.Enabled = true;
                }
                else if (pageNumber == pageList.PageCount)
                {
                    buttonSalesOrderDetailReportPageListFirst.Enabled = true;
                    buttonSalesOrderDetailReportPageListPrevious.Enabled = true;
                    buttonSalesOrderDetailReportPageListNext.Enabled = false;
                    buttonSalesOrderDetailReportPageListLast.Enabled = false;
                }
                else
                {
                    buttonSalesOrderDetailReportPageListFirst.Enabled = true;
                    buttonSalesOrderDetailReportPageListPrevious.Enabled = true;
                    buttonSalesOrderDetailReportPageListNext.Enabled = true;
                    buttonSalesOrderDetailReportPageListLast.Enabled = true;
                }

                textBoxSalesOrderDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
                dataSalesOrderDetailReportListSource.DataSource = pageList;
            }
            else
            {
                buttonSalesOrderDetailReportPageListFirst.Enabled = false;
                buttonSalesOrderDetailReportPageListPrevious.Enabled = false;
                buttonSalesOrderDetailReportPageListNext.Enabled = false;
                buttonSalesOrderDetailReportPageListLast.Enabled = false;

                dataSalesOrderDetailReportListSource.Clear();
                textBoxSalesOrderDetailReportPageNumber.Text = "0 / 0";
            }
        }

        public void CreateSalesOrderDetailReportDataGridView()
        {
            GetSalesOrderDetailReportDataSource();
            dataGridViewAccountsReceivableSalesOrderDetailReport.DataSource = dataSalesOrderDetailReportListSource;
        }

        private void buttonSalesOrderDetailReportPageListFirst_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepAccountsReceivableSalesOrderDetailReportEntity>(salesOrderDetailReportList, 1, pageSize);
            dataSalesOrderDetailReportListSource.DataSource = pageList;

            buttonSalesOrderDetailReportPageListFirst.Enabled = false;
            buttonSalesOrderDetailReportPageListPrevious.Enabled = false;
            buttonSalesOrderDetailReportPageListNext.Enabled = true;
            buttonSalesOrderDetailReportPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxSalesOrderDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonSalesOrderDetailReportPageListPrevious_Click(object sender, EventArgs e)
        {
            if (pageList.HasPreviousPage == true)
            {
                pageList = new PagedList<Entities.DgvRepAccountsReceivableSalesOrderDetailReportEntity>(salesOrderDetailReportList, --pageNumber, pageSize);
                dataSalesOrderDetailReportListSource.DataSource = pageList;
            }

            buttonSalesOrderDetailReportPageListNext.Enabled = true;
            buttonSalesOrderDetailReportPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonSalesOrderDetailReportPageListFirst.Enabled = false;
                buttonSalesOrderDetailReportPageListPrevious.Enabled = false;
            }

            textBoxSalesOrderDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonSalesOrderDetailReportPageListNext_Click(object sender, EventArgs e)
        {
            if (pageList.HasNextPage == true)
            {
                pageList = new PagedList<Entities.DgvRepAccountsReceivableSalesOrderDetailReportEntity>(salesOrderDetailReportList, ++pageNumber, pageSize);
                dataSalesOrderDetailReportListSource.DataSource = pageList;
            }

            buttonSalesOrderDetailReportPageListFirst.Enabled = true;
            buttonSalesOrderDetailReportPageListPrevious.Enabled = true;

            if (pageNumber == pageList.PageCount)
            {
                buttonSalesOrderDetailReportPageListNext.Enabled = false;
                buttonSalesOrderDetailReportPageListLast.Enabled = false;
            }

            textBoxSalesOrderDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonSalesOrderDetailReportPageListLast_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepAccountsReceivableSalesOrderDetailReportEntity>(salesOrderDetailReportList, pageList.PageCount, pageSize);
            dataSalesOrderDetailReportListSource.DataSource = pageList;

            buttonSalesOrderDetailReportPageListFirst.Enabled = true;
            buttonSalesOrderDetailReportPageListPrevious.Enabled = true;
            buttonSalesOrderDetailReportPageListNext.Enabled = false;
            buttonSalesOrderDetailReportPageListLast.Enabled = false;

            pageNumber = pageList.PageCount;
            textBoxSalesOrderDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
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
                        "SONumber",
                        "SODate",
                        "ManualSONumber",
                        "Customer",
                        "Term",
                        "Remarks",
                        "SoldBy",
                        "PreparedBy",
                        "CheckedBy",
                        "ApprovedBy",
                        "ItemCode",
                        "ItemDescription",
                        "ItemInventoryCode",
                        "Unit",
                        "Price",
                        "Discount",
                        "DiscountRate",
                        "DiscountAmount",
                        "NetPrice",
                        "Quantity",
                        "Amount",
                        "Tax",
                        "TaxRate",
                        "TaxAmount",
                        "BaseQuantity",
                        "BasePrice"
                    };

                    csv.AppendLine(String.Join(",", header));

                    if (salesOrderDetailReportList.Any())
                    {
                        foreach (var salesOrderDetailReport in salesOrderDetailReportList)
                        {
                            String[] data =
                            {
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListBranch.Replace(",", ""),
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListSONumber.Replace(",", ""),
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListSODate.Replace(",", ""),
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListManualSONumber.Replace(",", ""),
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListCustomer.Replace(",", ""),
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListTerm.Replace(",", ""),
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListRemarks.Replace(",", ""),
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListSoldBy.Replace(",", ""),
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListPreparedBy.Replace(",", ""),
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListCheckedBy.Replace(",", ""),
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListApprovedBy.Replace(",", ""),
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListItemCode.Replace(",", ""),
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListItemDescription.Replace(",", ""),
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListItemInventoryCode.Replace(",", ""),
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListUnit.Replace(",", ""),
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListPrice.Replace(",", ""),
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListDiscount.Replace(",", ""),
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListDiscountRate.Replace(",", ""),
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListDiscountAmount.Replace(",", ""),
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListNetPrice.Replace(",", ""),
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListQuantity.Replace(",", ""),
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListAmount.Replace(",", ""),
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListTax.Replace(",", ""),
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListTaxRate.Replace(",", ""),
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListTaxAmount.Replace(",", ""),
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListBaseQuantity.Replace(",", ""),
                                salesOrderDetailReport.ColumnSalesOrderDetailReportListBasePrice.Replace(",", ""),
                            };

                            csv.AppendLine(String.Join(",", data));
                        }
                    }

                    String executingUser = WindowsIdentity.GetCurrent().Name;

                    DirectorySecurity securityRules = new DirectorySecurity();
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.Read, AccessControlType.Allow));
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.FullControl, AccessControlType.Allow));

                    DirectoryInfo createDirectorySTCSV = Directory.CreateDirectory(folderBrowserDialogGenerateCSV.SelectedPath, securityRules);
                    File.WriteAllText(createDirectorySTCSV.FullName + "\\SaleseOrderDetailReport" + Convert.ToDateTime(textBoxStartDate.Text).ToString("yyyyMMdd") + ".csv", csv.ToString(), Encoding.GetEncoding("iso-8859-1"));

                    MessageBox.Show("Generate CSV Successful!", "Generate CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RepAccountReceivableSalesOrderDetailReportReportForm_Load(object sender, EventArgs e)
        {

        }
    }
}
