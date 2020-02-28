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
    public partial class RepInventoryReportStockInDetailReportForm : Form
    {
        public List<Entities.DgvRepInventoryReportStockInDetailReportEntity> stockInDetailReportList;
        public BindingSource dataStockInDetailReportListSource = new BindingSource();
        public PagedList<Entities.DgvRepInventoryReportStockInDetailReportEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;

        DateTime DateStart;
        DateTime DateEnd;
        Int32 CompanyId;
        Int32 BranchId;

        public RepInventoryReportStockInDetailReportForm(DateTime filterDateStart, DateTime filterDateEnd, Int32 filterCompanyId, String filterCompanyName, Int32 filterBranchId, String filterBranchName)
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

            CreateStockInDetailDataGridView();
        }

        public List<Entities.DgvRepInventoryReportStockInDetailReportEntity> GetStockInDetailReportListData(DateTime filterDateStart, DateTime filterDateEnd, Int32 filterCompanyId, Int32 filterBranchId)
        {
            List<Entities.DgvRepInventoryReportStockInDetailReportEntity> rowList = new List<Entities.DgvRepInventoryReportStockInDetailReportEntity>();

            Controllers.RepInventoryReportController repInventoryReportController = new Controllers.RepInventoryReportController();

            var stockInDetailReportList = repInventoryReportController.ListStockInDetailReport(filterDateStart, filterDateEnd, filterCompanyId, filterBranchId);
            if (stockInDetailReportList.Any())
            {
                var row = from d in stockInDetailReportList
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

                Decimal totalAmount = stockInDetailReportList.Sum(d=>d.Amount);

                Entities.DgvRepInventoryReportStockInDetailReportEntity totalAmountStockInDetailReport = new Entities.DgvRepInventoryReportStockInDetailReportEntity()
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

                rowList.Add(totalAmountStockInDetailReport);
            }
            return rowList;
        }

        public void GetStockInDetailReportDataSource()
        {
            stockInDetailReportList = GetStockInDetailReportListData(DateStart, DateEnd, CompanyId, BranchId);
            if (stockInDetailReportList.Any())
            {
                pageNumber = 1;
                pageList = new PagedList<Entities.DgvRepInventoryReportStockInDetailReportEntity>(stockInDetailReportList, pageNumber, pageSize);

                if (pageList.PageCount == 1)
                {
                    buttonStockInDetailReportPageListFirst.Enabled = false;
                    buttonStockInDetailReportPageListPrevious.Enabled = false;
                    buttonStockInDetailReportPageListNext.Enabled = false;
                    buttonStockInDetailReportPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonStockInDetailReportPageListFirst.Enabled = false;
                    buttonStockInDetailReportPageListPrevious.Enabled = false;
                    buttonStockInDetailReportPageListNext.Enabled = true;
                    buttonStockInDetailReportPageListLast.Enabled = true;
                }
                else if (pageNumber == pageList.PageCount)
                {
                    buttonStockInDetailReportPageListFirst.Enabled = true;
                    buttonStockInDetailReportPageListPrevious.Enabled = true;
                    buttonStockInDetailReportPageListNext.Enabled = false;
                    buttonStockInDetailReportPageListLast.Enabled = false;
                }
                else
                {
                    buttonStockInDetailReportPageListFirst.Enabled = true;
                    buttonStockInDetailReportPageListPrevious.Enabled = true;
                    buttonStockInDetailReportPageListNext.Enabled = true;
                    buttonStockInDetailReportPageListLast.Enabled = true;
                }

                textBoxStockInDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
                dataStockInDetailReportListSource.DataSource = pageList;
            }
            else
            {
                buttonStockInDetailReportPageListFirst.Enabled = false;
                buttonStockInDetailReportPageListPrevious.Enabled = false;
                buttonStockInDetailReportPageListNext.Enabled = false;
                buttonStockInDetailReportPageListLast.Enabled = false;

                dataStockInDetailReportListSource.Clear();
                textBoxStockInDetailReportPageNumber.Text = "0 / 0";
            }
        }

        public void CreateStockInDetailDataGridView()
        {
            GetStockInDetailReportDataSource();
            dataGridViewStockInDetailReport.DataSource = dataStockInDetailReportListSource;
        }

        private void buttonStockInDetailReportPageListFirst_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepInventoryReportStockInDetailReportEntity>(stockInDetailReportList, 1, pageSize);
            dataStockInDetailReportListSource.DataSource = pageList;

            buttonStockInDetailReportPageListFirst.Enabled = false;
            buttonStockInDetailReportPageListPrevious.Enabled = false;
            buttonStockInDetailReportPageListNext.Enabled = true;
            buttonStockInDetailReportPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxStockInDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonStockInDetailReportPageListPrevious_Click(object sender, EventArgs e)
        {
            if (pageList.HasPreviousPage == true)
            {
                pageList = new PagedList<Entities.DgvRepInventoryReportStockInDetailReportEntity>(stockInDetailReportList, --pageNumber, pageSize);
                dataStockInDetailReportListSource.DataSource = pageList;
            }

            buttonStockInDetailReportPageListNext.Enabled = true;
            buttonStockInDetailReportPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonStockInDetailReportPageListFirst.Enabled = false;
                buttonStockInDetailReportPageListPrevious.Enabled = false;
            }

            textBoxStockInDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonStockInDetailReportPageListNext_Click(object sender, EventArgs e)
        {
            if (pageList.HasNextPage == true)
            {
                pageList = new PagedList<Entities.DgvRepInventoryReportStockInDetailReportEntity>(stockInDetailReportList, ++pageNumber, pageSize);
                dataStockInDetailReportListSource.DataSource = pageList;
            }

            buttonStockInDetailReportPageListFirst.Enabled = true;
            buttonStockInDetailReportPageListPrevious.Enabled = true;

            if (pageNumber == pageList.PageCount)
            {
                buttonStockInDetailReportPageListNext.Enabled = false;
                buttonStockInDetailReportPageListLast.Enabled = false;
            }

            textBoxStockInDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonStockInDetailReportPageListLast_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepInventoryReportStockInDetailReportEntity>(stockInDetailReportList, pageList.PageCount, pageSize);
            dataStockInDetailReportListSource.DataSource = pageList;

            buttonStockInDetailReportPageListFirst.Enabled = true;
            buttonStockInDetailReportPageListPrevious.Enabled = true;
            buttonStockInDetailReportPageListNext.Enabled = false;
            buttonStockInDetailReportPageListLast.Enabled = false;

            pageNumber = pageList.PageCount;
            textBoxStockInDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
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

                    if (stockInDetailReportList.Any())
                    {
                        foreach (var stockInDetailReport in stockInDetailReportList)
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
    }
}
