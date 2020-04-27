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
    public partial class RepInventoryReportStockInSalesReturnDetailReportForm : Form
    {
        public List<Entities.DgvRepInventoryReportStockInDetailReportEntity> stockInSalesReturnDetailReportList;
        public BindingSource dataStockInSalesReturnDetailReportListSource = new BindingSource();
        public PagedList<Entities.DgvRepInventoryReportStockInDetailReportEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;

        DateTime DateStart;
        DateTime DateEnd;
        Int32 CompanyId;
        Int32 BranchId;

        public RepInventoryReportStockInSalesReturnDetailReportForm(DateTime filterDateStart, DateTime filterDateEnd, Int32 filterCompanyId, String filterCompanyName, Int32 filterBranchId, String filterBranchName)
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

            CreateStockInSalesReturnDetailDataGridView();
        }

        public List<Entities.DgvRepInventoryReportStockInDetailReportEntity> GetStockInSalesReturnDetailReportListData(DateTime filterDateStart, DateTime filterDateEnd, Int32 filterCompanyId, Int32 filterBranchId)
        {
            String filter = textBoxItemListFilter.Text;

            List<Entities.DgvRepInventoryReportStockInDetailReportEntity> rowList = new List<Entities.DgvRepInventoryReportStockInDetailReportEntity>();

            Controllers.RepInventoryReportController repInventoryReportController = new Controllers.RepInventoryReportController();

            var stockInSalesReturnDetailReportList = repInventoryReportController.ListStockInSalesReturnDetailReport(filterDateStart, filterDateEnd, filterCompanyId, filterBranchId, filter);
            if (stockInSalesReturnDetailReportList.Any())
            {
                var row = from d in stockInSalesReturnDetailReportList
                          select new Entities.DgvRepInventoryReportStockInDetailReportEntity
                          {
                              ColumnStockInDetailReportListBranch = d.Branch,
                              ColumnStockInDetailReportListINNumber = d.INNumber,
                              ColumnStockInDetailReportListINDate = d.INDate.ToShortDateString(),
                              ColumnStockInDetailReportListRemarks = d.Remarks,
                              ColumnStockInDetailReportListPreparedBy = d.PreparedBy,
                              ColumnStockInDetailReportListCheckedBy = d.CheckedBy,
                              ColumnStockInDetailReportListApprovedBy = d.ApprovedBy,
                              ColumnStockInDetailReportListItemCode = d.ItemCode,
                              ColumnStockInDetailReportListItemDescription = d.ItemDescription,
                              ColumnStockInDetailReportListUnit = d.Unit,
                              ColumnStockInDetailReportListQuantity = d.Quantity.ToString("#,##0.00"),
                              ColumnStockInDetailReportListCost = d.Cost.ToString("#,##0.00"),
                              ColumnStockInDetailReportListAmount = d.Amount.ToString("#,##0.00"),
                              ColumnStockInDetailReportListBaseQuantity = d.BaseQuantity.ToString("#,##0.00"),
                              ColumnStockInDetailReportListBaseCost = d.BaseCost.ToString("#,##0.00")
                          };

                rowList = row.ToList();

                Decimal totalAmount = stockInSalesReturnDetailReportList.Sum(d=>d.Amount);

                Entities.DgvRepInventoryReportStockInDetailReportEntity totalAmountStockInSalesReturnDetailReport = new Entities.DgvRepInventoryReportStockInDetailReportEntity()
                {
                    ColumnStockInDetailReportListBranch = "Total",
                    ColumnStockInDetailReportListINNumber = "",
                    ColumnStockInDetailReportListINDate = "",
                    ColumnStockInDetailReportListRemarks = "",
                    ColumnStockInDetailReportListPreparedBy = "",
                    ColumnStockInDetailReportListCheckedBy = "",
                    ColumnStockInDetailReportListApprovedBy = "",
                    ColumnStockInDetailReportListItemCode = "",
                    ColumnStockInDetailReportListItemDescription = "",
                    ColumnStockInDetailReportListUnit = "",
                    ColumnStockInDetailReportListQuantity = "",
                    ColumnStockInDetailReportListCost = "",
                    ColumnStockInDetailReportListAmount = totalAmount.ToString("#,##0.00"),
                    ColumnStockInDetailReportListBaseQuantity = "",
                    ColumnStockInDetailReportListBaseCost = "",
                };

                rowList.Add(totalAmountStockInSalesReturnDetailReport);
            }
            return rowList;
        }

        public void GetStockInSalesReturnDetailReportDataSource()
        {
            stockInSalesReturnDetailReportList = GetStockInSalesReturnDetailReportListData(DateStart, DateEnd, CompanyId, BranchId);
            if (stockInSalesReturnDetailReportList.Any())
            {
                pageNumber = 1;
                pageList = new PagedList<Entities.DgvRepInventoryReportStockInDetailReportEntity>(stockInSalesReturnDetailReportList, pageNumber, pageSize);

                if (pageList.PageCount == 1)
                {
                    buttonStockInSalesReturnDetailReportPageListFirst.Enabled = false;
                    buttonStockInSalesReturnDetailReportPageListPrevious.Enabled = false;
                    buttonStockInSalesReturnDetailReportPageListNext.Enabled = false;
                    buttonStockInSalesReturnDetailReportPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonStockInSalesReturnDetailReportPageListFirst.Enabled = false;
                    buttonStockInSalesReturnDetailReportPageListPrevious.Enabled = false;
                    buttonStockInSalesReturnDetailReportPageListNext.Enabled = true;
                    buttonStockInSalesReturnDetailReportPageListLast.Enabled = true;
                }
                else if (pageNumber == pageList.PageCount)
                {
                    buttonStockInSalesReturnDetailReportPageListFirst.Enabled = true;
                    buttonStockInSalesReturnDetailReportPageListPrevious.Enabled = true;
                    buttonStockInSalesReturnDetailReportPageListNext.Enabled = false;
                    buttonStockInSalesReturnDetailReportPageListLast.Enabled = false;
                }
                else
                {
                    buttonStockInSalesReturnDetailReportPageListFirst.Enabled = true;
                    buttonStockInSalesReturnDetailReportPageListPrevious.Enabled = true;
                    buttonStockInSalesReturnDetailReportPageListNext.Enabled = true;
                    buttonStockInSalesReturnDetailReportPageListLast.Enabled = true;
                }

                textBoxStockInSalesReturnDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
                dataStockInSalesReturnDetailReportListSource.DataSource = pageList;
            }
            else
            {
                buttonStockInSalesReturnDetailReportPageListFirst.Enabled = false;
                buttonStockInSalesReturnDetailReportPageListPrevious.Enabled = false;
                buttonStockInSalesReturnDetailReportPageListNext.Enabled = false;
                buttonStockInSalesReturnDetailReportPageListLast.Enabled = false;

                dataStockInSalesReturnDetailReportListSource.Clear();
                textBoxStockInSalesReturnDetailReportPageNumber.Text = "0 / 0";
            }
        }

        public void CreateStockInSalesReturnDetailDataGridView()
        {
            GetStockInSalesReturnDetailReportDataSource();
            dataGridViewStockInSalesReturnDetailReport.DataSource = dataStockInSalesReturnDetailReportListSource;
        }

        public void UpdateStockInDetailDataGridView()
        {
            CreateStockInSalesReturnDetailDataGridView();
        }

        private void buttonStockInSalesReturnDetailReportPageListFirst_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepInventoryReportStockInDetailReportEntity>(stockInSalesReturnDetailReportList, 1, pageSize);
            dataStockInSalesReturnDetailReportListSource.DataSource = pageList;

            buttonStockInSalesReturnDetailReportPageListFirst.Enabled = false;
            buttonStockInSalesReturnDetailReportPageListPrevious.Enabled = false;
            buttonStockInSalesReturnDetailReportPageListNext.Enabled = true;
            buttonStockInSalesReturnDetailReportPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxStockInSalesReturnDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonStockInSalesReturnDetailReportPageListPrevious_Click(object sender, EventArgs e)
        {
            if (pageList.HasPreviousPage == true)
            {
                pageList = new PagedList<Entities.DgvRepInventoryReportStockInDetailReportEntity>(stockInSalesReturnDetailReportList, --pageNumber, pageSize);
                dataStockInSalesReturnDetailReportListSource.DataSource = pageList;
            }

            buttonStockInSalesReturnDetailReportPageListNext.Enabled = true;
            buttonStockInSalesReturnDetailReportPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonStockInSalesReturnDetailReportPageListFirst.Enabled = false;
                buttonStockInSalesReturnDetailReportPageListPrevious.Enabled = false;
            }

            textBoxStockInSalesReturnDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonStockInSalesReturnDetailReportPageListNext_Click(object sender, EventArgs e)
        {
            if (pageList.HasNextPage == true)
            {
                pageList = new PagedList<Entities.DgvRepInventoryReportStockInDetailReportEntity>(stockInSalesReturnDetailReportList, ++pageNumber, pageSize);
                dataStockInSalesReturnDetailReportListSource.DataSource = pageList;
            }

            buttonStockInSalesReturnDetailReportPageListFirst.Enabled = true;
            buttonStockInSalesReturnDetailReportPageListPrevious.Enabled = true;

            if (pageNumber == pageList.PageCount)
            {
                buttonStockInSalesReturnDetailReportPageListNext.Enabled = false;
                buttonStockInSalesReturnDetailReportPageListLast.Enabled = false;
            }

            textBoxStockInSalesReturnDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonStockInSalesReturnDetailReportPageListLast_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepInventoryReportStockInDetailReportEntity>(stockInSalesReturnDetailReportList, pageList.PageCount, pageSize);
            dataStockInSalesReturnDetailReportListSource.DataSource = pageList;

            buttonStockInSalesReturnDetailReportPageListFirst.Enabled = true;
            buttonStockInSalesReturnDetailReportPageListPrevious.Enabled = true;
            buttonStockInSalesReturnDetailReportPageListNext.Enabled = false;
            buttonStockInSalesReturnDetailReportPageListLast.Enabled = false;

            pageNumber = pageList.PageCount;
            textBoxStockInSalesReturnDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
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
                        "ColumnStockInDetailReportListBranch",
                        "ColumnStockInDetailReportListINNumber",
                        "ColumnStockInDetailReportListINDate",
                        "ColumnStockInDetailReportListRemarks",
                        "ColumnStockInDetailReportListPreparedBy",
                        "ColumnStockInDetailReportListCheckedBy",
                        "ColumnStockInDetailReportListApprovedBy",
                        "ColumnStockInDetailReportListItemCode",
                        "ColumnStockInDetailReportListItemDescription",
                        "ColumnStockInDetailReportListUnit",
                        "ColumnStockInDetailReportListQuantity",
                        "ColumnStockInDetailReportListCost",
                        "ColumnStockInDetailReportListAmount",
                        "ColumnStockInDetailReportListBaseQuantity",
                        "ColumnStockInDetailReportListBaseCost",
                    };

                    csv.AppendLine(String.Join(",", header));

                    if (stockInSalesReturnDetailReportList.Any())
                    {
                        foreach (var stockInDetailReport in stockInSalesReturnDetailReportList)
                        {
                            String[] data =
                            {
                                  stockInDetailReport.ColumnStockInDetailReportListBranch.Replace(",", ""),
                                  stockInDetailReport.ColumnStockInDetailReportListINNumber.Replace(",", ""),
                                  stockInDetailReport.ColumnStockInDetailReportListINDate.Replace(",", ""),
                                  stockInDetailReport.ColumnStockInDetailReportListRemarks.Replace(",", ""),
                                  stockInDetailReport.ColumnStockInDetailReportListPreparedBy.Replace(",", ""),
                                  stockInDetailReport.ColumnStockInDetailReportListCheckedBy.Replace(",", ""),
                                  stockInDetailReport.ColumnStockInDetailReportListApprovedBy.Replace(",", ""),
                                  stockInDetailReport.ColumnStockInDetailReportListItemCode.Replace(",", ""),
                                  stockInDetailReport.ColumnStockInDetailReportListItemDescription.Replace(",", ""),
                                  stockInDetailReport.ColumnStockInDetailReportListUnit.Replace(",", ""),
                                  stockInDetailReport.ColumnStockInDetailReportListQuantity.Replace(",", ""),
                                  stockInDetailReport.ColumnStockInDetailReportListCost.Replace(",", ""),
                                  stockInDetailReport.ColumnStockInDetailReportListAmount.Replace(",", ""),
                                  stockInDetailReport.ColumnStockInDetailReportListBaseQuantity.Replace(",", ""),
                                  stockInDetailReport.ColumnStockInDetailReportListBaseCost.Replace(",", ""),
                            };

                            csv.AppendLine(String.Join(",", data));
                        }
                    }

                    String executingUser = WindowsIdentity.GetCurrent().Name;

                    DirectorySecurity securityRules = new DirectorySecurity();
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.Read, AccessControlType.Allow));
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.FullControl, AccessControlType.Allow));

                    DirectoryInfo createDirectorySTCSV = Directory.CreateDirectory(folderBrowserDialogGenerateCSV.SelectedPath, securityRules);
                    File.WriteAllText(createDirectorySTCSV.FullName + "\\StockInDetailReport_" + Convert.ToDateTime(textBoxStartDate.Text).ToString("yyyyMMdd") + ".csv", csv.ToString(), Encoding.GetEncoding("iso-8859-1"));

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
                UpdateStockInDetailDataGridView();
            }
        }
    }
}
