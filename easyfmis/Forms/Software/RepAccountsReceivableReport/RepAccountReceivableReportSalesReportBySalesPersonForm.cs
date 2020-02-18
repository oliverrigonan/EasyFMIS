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
    public partial class RepbuttonSalesReportBySalesPersonReportSalesReportBySalesPersonForm : Form
    {
        public List<Entities.DgvRepSalesInvoiceEntity> salesDetailReportList;
        public BindingSource dataSalesDetailReportListSource = new BindingSource();
        public PagedList<Entities.DgvRepSalesInvoiceEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;

        DateTime DateStart;
        DateTime DateEnd;
        Int32 CompanyId;
        Int32 BranchId;
        Int32 SoldById;



        public RepbuttonSalesReportBySalesPersonReportSalesReportBySalesPersonForm(DateTime filterDateStart, DateTime filterDateEnd, Int32 filterCompanyId, String filterCompanyName, Int32 filterBranchId, String filterBranchName, Int32 filterSoldById, String filterSoldBy)
        {
            InitializeComponent();

            DateStart = filterDateStart;
            DateEnd = filterDateEnd;
            CompanyId = filterCompanyId;
            BranchId = filterBranchId;
            SoldById = filterSoldById;

            textBoxStartDate.Text = filterDateStart.Date.ToShortDateString();
            textBoxEndDate.Text = filterDateEnd.Date.ToShortDateString();
            textBoxCompany.Text = filterCompanyName;
            textBoxBranch.Text = filterBranchName;
            textBoxSoldBy.Text = filterSoldBy;

            CreateSalesReportReportDataGridView();
        }

        public List<Entities.DgvRepSalesInvoiceEntity> GetSalesReportBySalesPersonReportListData(DateTime filterDateStart, DateTime filterDateEnd, Int32 filterCompanyId, Int32 filterBranchId, Int32 filterSoldById)
        {
            List<Entities.DgvRepSalesInvoiceEntity> rowList = new List<Entities.DgvRepSalesInvoiceEntity>();

            Controllers.RepAccountsReceivableReportController repInvetoryReportController = new Controllers.RepAccountsReceivableReportController();

            var salesDetailReportList = repInvetoryReportController.ListSalesInvoiceDetailReport(filterDateStart, filterDateEnd, filterCompanyId, filterBranchId, filterSoldById);
            if (salesDetailReportList.Any())
            {
                var row = from d in salesDetailReportList
                          select new Entities.DgvRepSalesInvoiceEntity
                          {
                              ColumnSalesInvoiceListSINumber = d.SINumber,
                              ColumnSalesInvoiceListItemDescription = d.ItemDescription,
                              ColumnSalesInvoiceListItemInventoryCode = d.ItemInventoryCode,
                              ColumnSalesInvoiceListUnit = d.Unit,
                              ColumnSalesInvoiceListPrice = d.Price.ToString("#,##0.00"),
                              ColumnSalesInvoiceListDiscount = d.Discount,
                              ColumnSalesInvoiceListDiscountRate = d.DiscountRate.ToString("#,##0.00"),
                              ColumnSalesInvoiceListDiscountAmount = d.DiscountAmount.ToString("#,##0.00"),
                              ColumnSalesInvoiceListNetPrice = d.NetPrice.ToString("#,##0.00"),
                              ColumnSalesInvoiceListQuantity = d.Quantity.ToString("#,##0.00"),
                              ColumnSalesInvoiceListAmount = d.Amount.ToString("#,##0.00"),
                              ColumnSalesInvoiceListTax = d.Tax,
                              ColumnSalesInvoiceListTaxRate = d.TaxRate.ToString("#,##0.00"),
                              ColumnSalesInvoiceListTaxAmount = d.TaxAmount.ToString("#,##0.00"),
                              ColumnSalesInvoiceListBaseQuantity = d.Quantity.ToString("#,##0.00"),
                              ColumnSalesInvoiceListBasePrice = d.Price.ToString("#,##0.00")
                          };

                rowList = row.ToList();

            }
            return rowList;
        }

        public void GetAccountsPayableReportDataSource()
        {
            salesDetailReportList = GetSalesReportBySalesPersonReportListData(DateStart, DateEnd, CompanyId, BranchId, SoldById);
            if (salesDetailReportList.Any())
            {
                pageNumber = 1;
                pageList = new PagedList<Entities.DgvRepSalesInvoiceEntity>(salesDetailReportList, pageNumber, pageSize);

                if (pageList.PageCount == 1)
                {
                    buttonSalesReportBySalesPersonReportPageListFirst.Enabled = false;
                    buttonSalesReportBySalesPersonleReportPageListPrevious.Enabled = false;
                    buttonSalesReportBySalesPersonlReportPageListNext.Enabled = false;
                    buttonSalesReportBySalesPersonReportPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonSalesReportBySalesPersonReportPageListFirst.Enabled = false;
                    buttonSalesReportBySalesPersonleReportPageListPrevious.Enabled = false;
                    buttonSalesReportBySalesPersonlReportPageListNext.Enabled = true;
                    buttonSalesReportBySalesPersonReportPageListLast.Enabled = true;
                }
                else if (pageNumber == pageList.PageCount)
                {
                    buttonSalesReportBySalesPersonReportPageListFirst.Enabled = true;
                    buttonSalesReportBySalesPersonleReportPageListPrevious.Enabled = true;
                    buttonSalesReportBySalesPersonlReportPageListNext.Enabled = false;
                    buttonSalesReportBySalesPersonReportPageListLast.Enabled = false;
                }
                else
                {
                    buttonSalesReportBySalesPersonReportPageListFirst.Enabled = true;
                    buttonSalesReportBySalesPersonleReportPageListPrevious.Enabled = true;
                    buttonSalesReportBySalesPersonlReportPageListNext.Enabled = true;
                    buttonSalesReportBySalesPersonReportPageListLast.Enabled = true;
                }

                buttonSalesReportBySalesPersonReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
                dataSalesDetailReportListSource.DataSource = pageList;
            }
            else
            {
                buttonSalesReportBySalesPersonReportPageListFirst.Enabled = false;
                buttonSalesReportBySalesPersonleReportPageListPrevious.Enabled = false;
                buttonSalesReportBySalesPersonlReportPageListNext.Enabled = false;
                buttonSalesReportBySalesPersonReportPageListLast.Enabled = false;

                dataSalesDetailReportListSource.Clear();
                buttonSalesReportBySalesPersonReportPageNumber.Text = "0 / 0";
            }
        }

        public void CreateSalesReportReportDataGridView()
        {
            GetAccountsPayableReportDataSource();
            dataGridViewSalesDetailReportBySalesPersonReport.DataSource = dataSalesDetailReportListSource;
        }

        private void buttonSalesReportBySalesPersonReportPageListFirst_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepSalesInvoiceEntity>(salesDetailReportList, 1, pageSize);
            dataSalesDetailReportListSource.DataSource = pageList;

            buttonSalesReportBySalesPersonReportPageListFirst.Enabled = false;
            buttonSalesReportBySalesPersonleReportPageListPrevious.Enabled = false;
            buttonSalesReportBySalesPersonlReportPageListNext.Enabled = true;
            buttonSalesReportBySalesPersonReportPageListLast.Enabled = true;

            pageNumber = 1;
            buttonSalesReportBySalesPersonReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonSalesReportBySalesPersonReportPageListPrevious_Click(object sender, EventArgs e)
        {
            if (pageList.HasPreviousPage == true)
            {
                pageList = new PagedList<Entities.DgvRepSalesInvoiceEntity>(salesDetailReportList, --pageNumber, pageSize);
                dataSalesDetailReportListSource.DataSource = pageList;
            }

            buttonSalesReportBySalesPersonlReportPageListNext.Enabled = true;
            buttonSalesReportBySalesPersonReportPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonSalesReportBySalesPersonReportPageListFirst.Enabled = false;
                buttonSalesReportBySalesPersonleReportPageListPrevious.Enabled = false;
            }

            buttonSalesReportBySalesPersonReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonSalesReportBySalesPersonReportPageListNext_Click(object sender, EventArgs e)
        {
            if (pageList.HasNextPage == true)
            {
                pageList = new PagedList<Entities.DgvRepSalesInvoiceEntity>(salesDetailReportList, ++pageNumber, pageSize);
                dataSalesDetailReportListSource.DataSource = pageList;
            }

            buttonSalesReportBySalesPersonReportPageListFirst.Enabled = true;
            buttonSalesReportBySalesPersonleReportPageListPrevious.Enabled = true;

            if (pageNumber == pageList.PageCount)
            {
                buttonSalesReportBySalesPersonlReportPageListNext.Enabled = false;
                buttonSalesReportBySalesPersonReportPageListLast.Enabled = false;
            }

            buttonSalesReportBySalesPersonReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonSalesReportBySalesPersonReportPageListLast_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepSalesInvoiceEntity>(salesDetailReportList, pageList.PageCount, pageSize);
            dataSalesDetailReportListSource.DataSource = pageList;

            buttonSalesReportBySalesPersonReportPageListFirst.Enabled = true;
            buttonSalesReportBySalesPersonleReportPageListPrevious.Enabled = true;
            buttonSalesReportBySalesPersonlReportPageListNext.Enabled = false;
            buttonSalesReportBySalesPersonReportPageListLast.Enabled = false;

            pageNumber = pageList.PageCount;
            buttonSalesReportBySalesPersonReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
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
                        "SINumber",
                        "ItemDescription",
                        "InventoryCode",
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

                    if (salesDetailReportList.Any())
                    {
                        foreach (var salesDetailReport in salesDetailReportList)
                        {
                            String[] data =
                            {
                                salesDetailReport.ColumnSalesInvoiceListSINumber .Replace(",", ""),
                                salesDetailReport.ColumnSalesInvoiceListItemDescription.Replace(",", ""),
                                salesDetailReport.ColumnSalesInvoiceListItemInventoryCode.Replace(",", ""),
                                salesDetailReport.ColumnSalesInvoiceListUnit.Replace(",", ""),
                                salesDetailReport.ColumnSalesInvoiceListPrice.Replace(",", ""),
                                salesDetailReport.ColumnSalesInvoiceListDiscount.Replace(",", ""),
                                salesDetailReport.ColumnSalesInvoiceListDiscountRate.Replace(",", ""),
                                salesDetailReport.ColumnSalesInvoiceListDiscountAmount.Replace(",", ""),
                                salesDetailReport.ColumnSalesInvoiceListNetPrice.Replace(",", ""),
                                salesDetailReport.ColumnSalesInvoiceListQuantity.Replace(",", ""),
                                salesDetailReport.ColumnSalesInvoiceListAmount.Replace(",", ""),
                                salesDetailReport.ColumnSalesInvoiceListTax.Replace(",", ""),
                                salesDetailReport.ColumnSalesInvoiceListTaxRate.Replace(",", ""),
                                salesDetailReport.ColumnSalesInvoiceListTaxAmount.Replace(",", ""),
                                salesDetailReport.ColumnSalesInvoiceListBaseQuantity.Replace(",", ""),
                                salesDetailReport.ColumnSalesInvoiceListBasePrice.Replace(",", "")
                            };

                            csv.AppendLine(String.Join(",", data));
                        }
                    }

                    String executingUser = WindowsIdentity.GetCurrent().Name;

                    DirectorySecurity securityRules = new DirectorySecurity();
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.Read, AccessControlType.Allow));
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.FullControl, AccessControlType.Allow));

                    DirectoryInfo createDirectorySTCSV = Directory.CreateDirectory(folderBrowserDialogGenerateCSV.SelectedPath, securityRules);
                    File.WriteAllText(createDirectorySTCSV.FullName + "\\SalesDetailReportPerPersonReport_" + Convert.ToDateTime(textBoxStartDate.Text).ToString("yyyyMMdd") + ".csv", csv.ToString(), Encoding.GetEncoding("iso-8859-1"));

                    MessageBox.Show("Generate CSV Successful!", "Generate CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
