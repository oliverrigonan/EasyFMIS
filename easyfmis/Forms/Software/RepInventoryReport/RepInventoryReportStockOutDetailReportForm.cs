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

namespace easyfmis.Forms.Software.RepInventoryReport
{
    public partial class RepInventoryReportStockOutDetailReportForm : Form
    {
        public List<Entities.DgvRepInventoryReportStockOutDetailReportEntity> stockOutDetailReportList;
        public BindingSource dataStockOutDetailReportListSource = new BindingSource();
        public PagedList<Entities.DgvRepInventoryReportStockOutDetailReportEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;

        DateTime DateStart;
        DateTime DateEnd;
        Int32 CompanyId;
        Int32 BranchId;

        public RepInventoryReportStockOutDetailReportForm(DateTime filterDateStart, DateTime filterDateEnd, Int32 filterCompanyId, String filterCompanyName, Int32 filterBranchId, String filterBranchName)
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

            CreateStockOutDetailDataGridView();
        }

        public List<Entities.DgvRepInventoryReportStockOutDetailReportEntity> GetSalesInvoiceDetailReportListData(DateTime filterDateStart, DateTime filterDateEnd, Int32 filterCompanyId, Int32 filterBranchId)
        {
            String filter = textBoxItemListFilter.Text;

            List<Entities.DgvRepInventoryReportStockOutDetailReportEntity> rowList = new List<Entities.DgvRepInventoryReportStockOutDetailReportEntity>();

            Controllers.RepInventoryReportController repInventoryReportController = new Controllers.RepInventoryReportController();

            var stockOutDetailReportList = repInventoryReportController.ListStockOutDetailReport(filterDateStart, filterDateEnd, filterCompanyId, filterBranchId, filter);
            if (stockOutDetailReportList.Any())
            {
                var row = from d in stockOutDetailReportList
                          select new Entities.DgvRepInventoryReportStockOutDetailReportEntity
                          {
                              ColumnStockOutDetailReportListBranch = d.Branch,
                              ColumnStockOutDetailReportListOTNumber = d.OTNumber,
                              ColumnStockOutDetailReportListOTDate = d.OTDate.ToShortDateString(),
                              ColumnStockOutDetailReportListRemarks = d.Remarks,
                              ColumnStockOutDetailReportListPreparedBy = d.PreparedBy,
                              ColumnStockOutDetailReportListCheckedBy = d.CheckedBy,
                              ColumnStockOutDetailReportListApprovedBy = d.ApprovedBy,
                              ColumnStockOutDetailReportListItemCode = d.ItemCode,
                              ColumnStockOutDetailReportListItemDescription = d.ItemDescription,
                              ColumnStockOutDetailReportListItemInventoryCode = d.ItemInventoryCode,
                              ColumnStockOutDetailReportListUnit = d.Unit,
                              ColumnStockOutDetailReportListQuantity = d.Quantity.ToString("#,##0.00"),
                              ColumnStockOutDetailReportListCost = d.Cost.ToString("#,##0.00"),
                              ColumnStockOutDetailReportListAmount = d.Amount.ToString("#,##0.00"),
                              ColumnStockOutDetailReportListBaseQuantity = d.BaseQuantity.ToString("#,##0.00"),
                              ColumnStockOutDetailReportListBaseCost = d.BaseCost.ToString("#,##0.00")
                          };

                rowList = row.ToList();

                Decimal totalAmount = stockOutDetailReportList.Sum(d => d.Amount);

                Entities.DgvRepInventoryReportStockOutDetailReportEntity totalAmountStockOutDetailReport = new Entities.DgvRepInventoryReportStockOutDetailReportEntity()
                {
                    ColumnStockOutDetailReportListBranch = "Total",
                    ColumnStockOutDetailReportListOTNumber = "",
                    ColumnStockOutDetailReportListOTDate = "",
                    ColumnStockOutDetailReportListRemarks = "",
                    ColumnStockOutDetailReportListPreparedBy = "",
                    ColumnStockOutDetailReportListCheckedBy = "",
                    ColumnStockOutDetailReportListApprovedBy = "",
                    ColumnStockOutDetailReportListItemCode = "",
                    ColumnStockOutDetailReportListItemDescription = "",
                    ColumnStockOutDetailReportListItemInventoryCode = "",
                    ColumnStockOutDetailReportListUnit = "",
                    ColumnStockOutDetailReportListQuantity = "",
                    ColumnStockOutDetailReportListCost = "",
                    ColumnStockOutDetailReportListAmount = totalAmount.ToString("#,##0.00"),
                    ColumnStockOutDetailReportListBaseQuantity = "",
                    ColumnStockOutDetailReportListBaseCost = "",
                };

                rowList.Add(totalAmountStockOutDetailReport);

            }
            return rowList;
        }

        public void GetStockOutDetailReportDataSource()
        {
            stockOutDetailReportList = GetSalesInvoiceDetailReportListData(DateStart, DateEnd, CompanyId, BranchId);
            if (stockOutDetailReportList.Any())
            {
                pageNumber = 1;
                pageList = new PagedList<Entities.DgvRepInventoryReportStockOutDetailReportEntity>(stockOutDetailReportList, pageNumber, pageSize);

                if (pageList.PageCount == 1)
                {
                    buttonStockOutDetailReportPageListFirst.Enabled = false;
                    buttonStockOutDetailReportPageListPrevious.Enabled = false;
                    buttonStockOutDetailReportPageListNext.Enabled = false;
                    buttonStockOutDetailReportPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonStockOutDetailReportPageListFirst.Enabled = false;
                    buttonStockOutDetailReportPageListPrevious.Enabled = false;
                    buttonStockOutDetailReportPageListNext.Enabled = true;
                    buttonStockOutDetailReportPageListLast.Enabled = true;
                }
                else if (pageNumber == pageList.PageCount)
                {
                    buttonStockOutDetailReportPageListFirst.Enabled = true;
                    buttonStockOutDetailReportPageListPrevious.Enabled = true;
                    buttonStockOutDetailReportPageListNext.Enabled = false;
                    buttonStockOutDetailReportPageListLast.Enabled = false;
                }
                else
                {
                    buttonStockOutDetailReportPageListFirst.Enabled = true;
                    buttonStockOutDetailReportPageListPrevious.Enabled = true;
                    buttonStockOutDetailReportPageListNext.Enabled = true;
                    buttonStockOutDetailReportPageListLast.Enabled = true;
                }

                textBoxStockOutDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
                dataStockOutDetailReportListSource.DataSource = pageList;
            }
            else
            {
                buttonStockOutDetailReportPageListFirst.Enabled = false;
                buttonStockOutDetailReportPageListPrevious.Enabled = false;
                buttonStockOutDetailReportPageListNext.Enabled = false;
                buttonStockOutDetailReportPageListLast.Enabled = false;

                dataStockOutDetailReportListSource.Clear();
                textBoxStockOutDetailReportPageNumber.Text = "0 / 0";
            }
        }

        public void CreateStockOutDetailDataGridView()
        {
            GetStockOutDetailReportDataSource();
            dataGridViewStockOutDetailReport.DataSource = dataStockOutDetailReportListSource;
        }

        public void UpdateStockOutDetailDataGridView()
        {
            CreateStockOutDetailDataGridView();
        }

        private void buttonSalesInvoiceDetailReportPageListFirst_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepInventoryReportStockOutDetailReportEntity>(stockOutDetailReportList, 1, pageSize);
            dataStockOutDetailReportListSource.DataSource = pageList;

            buttonStockOutDetailReportPageListFirst.Enabled = false;
            buttonStockOutDetailReportPageListPrevious.Enabled = false;
            buttonStockOutDetailReportPageListNext.Enabled = true;
            buttonStockOutDetailReportPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxStockOutDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonSalesInvoiceDetailReportPageListPrevious_Click(object sender, EventArgs e)
        {
            if (pageList.HasPreviousPage == true)
            {
                pageList = new PagedList<Entities.DgvRepInventoryReportStockOutDetailReportEntity>(stockOutDetailReportList, --pageNumber, pageSize);
                dataStockOutDetailReportListSource.DataSource = pageList;
            }

            buttonStockOutDetailReportPageListNext.Enabled = true;
            buttonStockOutDetailReportPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonStockOutDetailReportPageListFirst.Enabled = false;
                buttonStockOutDetailReportPageListPrevious.Enabled = false;
            }

            textBoxStockOutDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonSalesInvoiceDetailReportPageListNext_Click(object sender, EventArgs e)
        {
            if (pageList.HasNextPage == true)
            {
                pageList = new PagedList<Entities.DgvRepInventoryReportStockOutDetailReportEntity>(stockOutDetailReportList, ++pageNumber, pageSize);
                dataStockOutDetailReportListSource.DataSource = pageList;
            }

            buttonStockOutDetailReportPageListFirst.Enabled = true;
            buttonStockOutDetailReportPageListPrevious.Enabled = true;

            if (pageNumber == pageList.PageCount)
            {
                buttonStockOutDetailReportPageListNext.Enabled = false;
                buttonStockOutDetailReportPageListLast.Enabled = false;
            }

            textBoxStockOutDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonSalesInvoiceDetailReportPageListLast_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepInventoryReportStockOutDetailReportEntity>(stockOutDetailReportList, pageList.PageCount, pageSize);
            dataStockOutDetailReportListSource.DataSource = pageList;

            buttonStockOutDetailReportPageListFirst.Enabled = true;
            buttonStockOutDetailReportPageListPrevious.Enabled = true;
            buttonStockOutDetailReportPageListNext.Enabled = false;
            buttonStockOutDetailReportPageListLast.Enabled = false;

            pageNumber = pageList.PageCount;
            textBoxStockOutDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
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
                        "ColumnStockOutDetailReportListBranch",
                        "ColumnStockOutDetailReportListOTNumber",
                        "ColumnStockOutDetailReportListOTDate",
                        "ColumnStockOutDetailReportListRemarks",
                        "ColumnStockOutDetailReportListPreparedBy",
                        "ColumnStockOutDetailReportListCheckedBy",
                        "ColumnStockOutDetailReportListApprovedBy",
                        "ColumnStockOutDetailReportListItemCode",
                        "ColumnStockOutDetailReportListItemDescription",
                        "ColumnStockOutDetailReportListItemInventoryCode",
                        "ColumnStockOutDetailReportListUnit",
                        "ColumnStockOutDetailReportListQuantity",
                        "ColumnStockOutDetailReportListCost",
                        "ColumnStockOutDetailReportListAmount",
                        "ColumnStockOutDetailReportListBaseQuantity",
                        "ColumnStockOutDetailReportListBaseCost"
                    };

                    csv.AppendLine(String.Join(",", header));

                    if (stockOutDetailReportList.Any())
                    {
                        foreach (var stockOutDetailReport in stockOutDetailReportList)
                        {
                            String[] data =
                            {
                                  stockOutDetailReport.ColumnStockOutDetailReportListBranch.Replace(",", ""),
                                  stockOutDetailReport.ColumnStockOutDetailReportListOTNumber.Replace(",", ""),
                                  stockOutDetailReport.ColumnStockOutDetailReportListOTDate.Replace(",", ""),
                                  stockOutDetailReport.ColumnStockOutDetailReportListRemarks.Replace(",", ""),
                                  stockOutDetailReport.ColumnStockOutDetailReportListPreparedBy.Replace(",", ""),
                                  stockOutDetailReport.ColumnStockOutDetailReportListCheckedBy.Replace(",", ""),
                                  stockOutDetailReport.ColumnStockOutDetailReportListApprovedBy.Replace(",", ""),
                                  stockOutDetailReport.ColumnStockOutDetailReportListItemCode.Replace(",", ""),
                                  stockOutDetailReport.ColumnStockOutDetailReportListItemDescription.Replace(",", ""),
                                  stockOutDetailReport.ColumnStockOutDetailReportListItemInventoryCode.Replace(",", ""),
                                  stockOutDetailReport.ColumnStockOutDetailReportListUnit.Replace(",", ""),
                                  stockOutDetailReport.ColumnStockOutDetailReportListQuantity.Replace(",", ""),
                                  stockOutDetailReport.ColumnStockOutDetailReportListCost.Replace(",", ""),
                                  stockOutDetailReport.ColumnStockOutDetailReportListAmount.Replace(",", ""),
                                  stockOutDetailReport.ColumnStockOutDetailReportListBaseQuantity.Replace(",", ""),
                                  stockOutDetailReport.ColumnStockOutDetailReportListBaseCost.Replace(",", "")
                            };

                            csv.AppendLine(String.Join(",", data));
                        }
                    }

                    String executingUser = WindowsIdentity.GetCurrent().Name;

                    DirectorySecurity securityRules = new DirectorySecurity();
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.Read, AccessControlType.Allow));
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.FullControl, AccessControlType.Allow));

                    DirectoryInfo createDirectorySTCSV = Directory.CreateDirectory(folderBrowserDialogGenerateCSV.SelectedPath, securityRules);
                    File.WriteAllText(createDirectorySTCSV.FullName + "\\StockOutDetailReport_" + Convert.ToDateTime(textBoxStartDate.Text).ToString("yyyyMMdd") + ".csv", csv.ToString(), Encoding.GetEncoding("iso-8859-1"));

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
                UpdateStockOutDetailDataGridView();
            }
        }
    }
}
