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
    public partial class RepAccountReceivableReportSalesInvoiceDetailReportForm : Form
    {
        public List<Entities.DgvRepSalesInvoiceEntity> salesInvoiceDetailReportList;
        public BindingSource dataSalesInvoiceDetailReportListSource = new BindingSource();
        public PagedList<Entities.DgvRepSalesInvoiceEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;

        DateTime DateStart;
        DateTime DateEnd;
        Int32 CompanyId;
        Int32 BranchId;
        Int32 SodlById;
        Int32 CustomerId;

        public RepAccountReceivableReportSalesInvoiceDetailReportForm(DateTime filterDateStart, DateTime filterDateEnd, Int32 filterCompanyId, String filterCompanyName, Int32 filterBranchId, String filterBranchName, Int32 filterSoldById, String filterSoldByName, Int32 filterCustomerId, String filterCustomerName, String filterItem, String filterItemCode)
        {
            InitializeComponent();

            DateStart = filterDateStart;
            DateEnd = filterDateEnd;
            CompanyId = filterCompanyId;
            BranchId = filterBranchId;
            SodlById = filterSoldById;
            CustomerId = filterCustomerId;

            textBoxStartDate.Text = filterDateStart.Date.ToShortDateString();
            textBoxEndDate.Text = filterDateEnd.Date.ToShortDateString();
            textBoxCompany.Text = filterCompanyName;
            textBoxBranch.Text = filterBranchName;
            textBoxSoldBy.Text = filterSoldByName;
            textBoxCustomer.Text = filterCustomerName;
            textBoxItem.Text = filterItem;
            textBoxItemCode.Text = filterItemCode;

            CreateSalesInvoiceDetailDataGridView();
        }

        public List<Entities.DgvRepSalesInvoiceEntity> GetSalesInvoiceDetailReportListData(DateTime filterDateStart, DateTime filterDateEnd, Int32 filterCompanyId, Int32 filterBranchId, Int32 filterSoldById, Int32 filterCustomerId)
        {
            String filter = textBoxItemListFilter.Text;
            String item = textBoxItem.Text;
            String itemCode = textBoxItemCode.Text;
            List<Entities.DgvRepSalesInvoiceEntity> rowList = new List<Entities.DgvRepSalesInvoiceEntity>();

            Controllers.RepAccountsReceivableReportController repInvetoryReportController = new Controllers.RepAccountsReceivableReportController();

            var salesInvoiceDetailReportList = repInvetoryReportController.ListSalesInvoiceDetailReport(filterDateStart, filterDateEnd, filterCompanyId, filterBranchId, filterSoldById, filterCustomerId, item, itemCode, filter);
            if (salesInvoiceDetailReportList.Any())
            {
                var row = from d in salesInvoiceDetailReportList
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

                Decimal totalDiscountAmount = 0;

                foreach (var salesInvoiceDetail in salesInvoiceDetailReportList) {
                    totalDiscountAmount += (salesInvoiceDetail.DiscountAmount * salesInvoiceDetail.BaseQuantity);
                }

                Decimal totalAmount = salesInvoiceDetailReportList.Sum(d=> d.Amount);
                Decimal totalTaxAmount = salesInvoiceDetailReportList.Sum(d=> d.TaxAmount);

                Entities.DgvRepSalesInvoiceEntity totalSalesInvoice = new Entities.DgvRepSalesInvoiceEntity() {
                    ColumnSalesInvoiceListSINumber = "Total",
                    ColumnSalesInvoiceListItemDescription = "",
                    ColumnSalesInvoiceListItemInventoryCode = "",
                    ColumnSalesInvoiceListUnit = "",
                    ColumnSalesInvoiceListPrice = "",
                    ColumnSalesInvoiceListDiscount = "",
                    ColumnSalesInvoiceListDiscountRate = "",
                    ColumnSalesInvoiceListDiscountAmount = totalDiscountAmount.ToString("#,##0.00"),
                    ColumnSalesInvoiceListNetPrice = "",
                    ColumnSalesInvoiceListQuantity = "",
                    ColumnSalesInvoiceListAmount = totalAmount.ToString("#,##0.00"),
                    ColumnSalesInvoiceListTax = "",
                    ColumnSalesInvoiceListTaxRate = "",
                    ColumnSalesInvoiceListTaxAmount = totalTaxAmount.ToString("#,##0.00"),
                    ColumnSalesInvoiceListBaseQuantity = "",
                    ColumnSalesInvoiceListBasePrice = ""
                };

                rowList.Add(totalSalesInvoice);
            }
            return rowList;
        }

        public void GetSalesInvoiceDetailReportDataSource()
        {
            salesInvoiceDetailReportList = GetSalesInvoiceDetailReportListData(DateStart, DateEnd, CompanyId, BranchId, SodlById, CustomerId);
            if (salesInvoiceDetailReportList.Any())
            {
                pageNumber = 1;
                pageList = new PagedList<Entities.DgvRepSalesInvoiceEntity>(salesInvoiceDetailReportList, pageNumber, pageSize);

                if (pageList.PageCount == 1)
                {
                    buttonSalesInvoiceDetailReportPageListFirst.Enabled = false;
                    buttonSalesInvoiceDetailReportPageListPrevious.Enabled = false;
                    buttonSalesInvoiceDetailReportPageListNext.Enabled = false;
                    buttonSalesInvoiceDetailReportPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonSalesInvoiceDetailReportPageListFirst.Enabled = false;
                    buttonSalesInvoiceDetailReportPageListPrevious.Enabled = false;
                    buttonSalesInvoiceDetailReportPageListNext.Enabled = true;
                    buttonSalesInvoiceDetailReportPageListLast.Enabled = true;
                }
                else if (pageNumber == pageList.PageCount)
                {
                    buttonSalesInvoiceDetailReportPageListFirst.Enabled = true;
                    buttonSalesInvoiceDetailReportPageListPrevious.Enabled = true;
                    buttonSalesInvoiceDetailReportPageListNext.Enabled = false;
                    buttonSalesInvoiceDetailReportPageListLast.Enabled = false;
                }
                else
                {
                    buttonSalesInvoiceDetailReportPageListFirst.Enabled = true;
                    buttonSalesInvoiceDetailReportPageListPrevious.Enabled = true;
                    buttonSalesInvoiceDetailReportPageListNext.Enabled = true;
                    buttonSalesInvoiceDetailReportPageListLast.Enabled = true;
                }

                buttonSalesInvoiceDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
                dataSalesInvoiceDetailReportListSource.DataSource = pageList;
            }
            else
            {
                buttonSalesInvoiceDetailReportPageListFirst.Enabled = false;
                buttonSalesInvoiceDetailReportPageListPrevious.Enabled = false;
                buttonSalesInvoiceDetailReportPageListNext.Enabled = false;
                buttonSalesInvoiceDetailReportPageListLast.Enabled = false;

                dataSalesInvoiceDetailReportListSource.Clear();
                buttonSalesInvoiceDetailReportPageNumber.Text = "0 / 0";
            }
        }

        public void CreateSalesInvoiceDetailDataGridView()
        {
            GetSalesInvoiceDetailReportDataSource();
            dataGridViewSalesInvoiceDetailReport.DataSource = dataSalesInvoiceDetailReportListSource;
        }

        public void UpdateSalesInvoiceDetailDataGridView()
        {
            CreateSalesInvoiceDetailDataGridView();
        }

        private void buttonSalesInvoiceDetailReportPageListFirst_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepSalesInvoiceEntity>(salesInvoiceDetailReportList, 1, pageSize);
            dataSalesInvoiceDetailReportListSource.DataSource = pageList;

            buttonSalesInvoiceDetailReportPageListFirst.Enabled = false;
            buttonSalesInvoiceDetailReportPageListPrevious.Enabled = false;
            buttonSalesInvoiceDetailReportPageListNext.Enabled = true;
            buttonSalesInvoiceDetailReportPageListLast.Enabled = true;

            pageNumber = 1;
            buttonSalesInvoiceDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonSalesInvoiceDetailReportPageListPrevious_Click(object sender, EventArgs e)
        {
            if (pageList.HasPreviousPage == true)
            {
                pageList = new PagedList<Entities.DgvRepSalesInvoiceEntity>(salesInvoiceDetailReportList, --pageNumber, pageSize);
                dataSalesInvoiceDetailReportListSource.DataSource = pageList;
            }

            buttonSalesInvoiceDetailReportPageListNext.Enabled = true;
            buttonSalesInvoiceDetailReportPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonSalesInvoiceDetailReportPageListFirst.Enabled = false;
                buttonSalesInvoiceDetailReportPageListPrevious.Enabled = false;
            }

            buttonSalesInvoiceDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonSalesInvoiceDetailReportPageListNext_Click(object sender, EventArgs e)
        {
            if (pageList.HasNextPage == true)
            {
                pageList = new PagedList<Entities.DgvRepSalesInvoiceEntity>(salesInvoiceDetailReportList, ++pageNumber, pageSize);
                dataSalesInvoiceDetailReportListSource.DataSource = pageList;
            }

            buttonSalesInvoiceDetailReportPageListFirst.Enabled = true;
            buttonSalesInvoiceDetailReportPageListPrevious.Enabled = true;

            if (pageNumber == pageList.PageCount)
            {
                buttonSalesInvoiceDetailReportPageListNext.Enabled = false;
                buttonSalesInvoiceDetailReportPageListLast.Enabled = false;
            }

            buttonSalesInvoiceDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonSalesInvoiceDetailReportPageListLast_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepSalesInvoiceEntity>(salesInvoiceDetailReportList, pageList.PageCount, pageSize);
            dataSalesInvoiceDetailReportListSource.DataSource = pageList;

            buttonSalesInvoiceDetailReportPageListFirst.Enabled = true;
            buttonSalesInvoiceDetailReportPageListPrevious.Enabled = true;
            buttonSalesInvoiceDetailReportPageListNext.Enabled = false;
            buttonSalesInvoiceDetailReportPageListLast.Enabled = false;

            pageNumber = pageList.PageCount;
            buttonSalesInvoiceDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
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

                    if (salesInvoiceDetailReportList.Any())
                    {
                        foreach (var salesDetailReport in salesInvoiceDetailReportList)
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
                    File.WriteAllText(createDirectorySTCSV.FullName + "\\SalesDetailReportReport_" + Convert.ToDateTime(textBoxStartDate.Text).ToString("yyyyMMdd") + ".csv", csv.ToString(), Encoding.GetEncoding("iso-8859-1"));

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
                UpdateSalesInvoiceDetailDataGridView();
            }
        }
    }
}
