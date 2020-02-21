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
    public partial class RepInventoryReportStockTransferDetailReportForm : Form
    {
        public List<Entities.DgvRepInventoryReportStockTransferDetailReportEntity> stockTransferDetailReportList;
        public BindingSource dataStockTransferDetailReportListSource = new BindingSource();
        public PagedList<Entities.DgvRepInventoryReportStockTransferDetailReportEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;

        DateTime DateStart;
        DateTime DateEnd;
        Int32 CompanyId;
        Int32 BranchId;

        public RepInventoryReportStockTransferDetailReportForm(DateTime filterDateStart, DateTime filterDateEnd, Int32 filterCompanyId, String filterCompanyName, Int32 filterBranchId, String filterBranchName)
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

            CreateStockTransferDetailDataGridView();
        }

        public List<Entities.DgvRepInventoryReportStockTransferDetailReportEntity> GetStockTransferDetailReportListData(DateTime filterDateStart, DateTime filterDateEnd, Int32 filterCompanyId, Int32 filterBranchId)
        {
            List<Entities.DgvRepInventoryReportStockTransferDetailReportEntity> rowList = new List<Entities.DgvRepInventoryReportStockTransferDetailReportEntity>();

            Controllers.RepInventoryReportController repInventoryReportController = new Controllers.RepInventoryReportController();

            var stockTransferDetailReportList = repInventoryReportController.ListStockTransferDetailReport(filterDateStart, filterDateEnd, filterCompanyId, filterBranchId);
            if (stockTransferDetailReportList.Any())
            {
                var row = from d in stockTransferDetailReportList
                          select new Entities.DgvRepInventoryReportStockTransferDetailReportEntity
                          {
                              ColumnStockTransferDetailReportListBranch = d.Branch,
                              ColumnStockTransferDetailReportListSTNumber = d.STNumber,
                              ColumnStockTransferDetailReportListSTDate = d.STDate.ToShortDateString(),
                              ColumnStockTransferDetailReportListToBranch = d.ToBranch,
                              ColumnStockTransferDetailReportListRemarks = d.Remarks,
                              ColumnStockTransferDetailReportListPreparedBy = d.PreparedBy,
                              ColumnStockTransferDetailReportListCheckedBy = d.CheckedBy,
                              ColumnStockTransferDetailReportListApprovedBy = d.ApprovedBy,
                              ColumnStockTransferDetailReportListItemCode = d.ItemCode,
                              ColumnStockTransferDetailReportListItemDescription = d.ItemDescription,
                              ColumnStockTransferDetailReportListItemInventoryCode = d.ItemInventoryCode,
                              ColumnStockTransferDetailReportListUnit = d.Unit,
                              ColumnStockTransferDetailReportListQuantity = d.Quantity.ToString("#,##0.00"),
                              ColumnStockTransferDetailReportListCost = d.Cost.ToString("#,##0.00"),
                              ColumnStockTransferDetailReportListAmount = d.Amount.ToString("#,##0.00"),
                              ColumnStockTransferDetailReportListBaseQuantity = d.BaseQuantity.ToString("#,##0.00"),
                              ColumnStockTransferDetailReportListBaseCost = d.BaseCost.ToString("#,##0.00")
                          };

                rowList = row.ToList();

            }
            return rowList;
        }

        public void GetStockTransferDetailReportDataSource()
        {
            stockTransferDetailReportList = GetStockTransferDetailReportListData(DateStart, DateEnd, CompanyId, BranchId);
            if (stockTransferDetailReportList.Any())
            {
                pageNumber = 1;
                pageList = new PagedList<Entities.DgvRepInventoryReportStockTransferDetailReportEntity>(stockTransferDetailReportList, pageNumber, pageSize);

                if (pageList.PageCount == 1)
                {
                    buttonStockTransferDetailReportPageListFirst.Enabled = false;
                    buttonStockTransferDetailReportPageListPrevious.Enabled = false;
                    buttonStockTransferDetailReportPageListNext.Enabled = false;
                    buttonStockTransferDetailReportPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonStockTransferDetailReportPageListFirst.Enabled = false;
                    buttonStockTransferDetailReportPageListPrevious.Enabled = false;
                    buttonStockTransferDetailReportPageListNext.Enabled = true;
                    buttonStockTransferDetailReportPageListLast.Enabled = true;
                }
                else if (pageNumber == pageList.PageCount)
                {
                    buttonStockTransferDetailReportPageListFirst.Enabled = true;
                    buttonStockTransferDetailReportPageListPrevious.Enabled = true;
                    buttonStockTransferDetailReportPageListNext.Enabled = false;
                    buttonStockTransferDetailReportPageListLast.Enabled = false;
                }
                else
                {
                    buttonStockTransferDetailReportPageListFirst.Enabled = true;
                    buttonStockTransferDetailReportPageListPrevious.Enabled = true;
                    buttonStockTransferDetailReportPageListNext.Enabled = true;
                    buttonStockTransferDetailReportPageListLast.Enabled = true;
                }

                buttonStockTransferDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
                dataStockTransferDetailReportListSource.DataSource = pageList;
            }
            else
            {
                buttonStockTransferDetailReportPageListFirst.Enabled = false;
                buttonStockTransferDetailReportPageListPrevious.Enabled = false;
                buttonStockTransferDetailReportPageListNext.Enabled = false;
                buttonStockTransferDetailReportPageListLast.Enabled = false;

                dataStockTransferDetailReportListSource.Clear();
                buttonStockTransferDetailReportPageNumber.Text = "0 / 0";
            }
        }

        public void CreateStockTransferDetailDataGridView()
        {
            GetStockTransferDetailReportDataSource();
            dataGridViewStockTransferDetailReport.DataSource = dataStockTransferDetailReportListSource;
        }

        private void buttonStockTransferDetailReportPageListFirst_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepInventoryReportStockTransferDetailReportEntity>(stockTransferDetailReportList, 1, pageSize);
            dataStockTransferDetailReportListSource.DataSource = pageList;

            buttonStockTransferDetailReportPageListFirst.Enabled = false;
            buttonStockTransferDetailReportPageListPrevious.Enabled = false;
            buttonStockTransferDetailReportPageListNext.Enabled = true;
            buttonStockTransferDetailReportPageListLast.Enabled = true;

            pageNumber = 1;
            buttonStockTransferDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonStockTransferDetailReportPageListPrevious_Click(object sender, EventArgs e)
        {
            if (pageList.HasPreviousPage == true)
            {
                pageList = new PagedList<Entities.DgvRepInventoryReportStockTransferDetailReportEntity>(stockTransferDetailReportList, --pageNumber, pageSize);
                dataStockTransferDetailReportListSource.DataSource = pageList;
            }

            buttonStockTransferDetailReportPageListNext.Enabled = true;
            buttonStockTransferDetailReportPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonStockTransferDetailReportPageListFirst.Enabled = false;
                buttonStockTransferDetailReportPageListPrevious.Enabled = false;
            }

            buttonStockTransferDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonStockTransferDetailReportPageListNext_Click(object sender, EventArgs e)
        {
            if (pageList.HasNextPage == true)
            {
                pageList = new PagedList<Entities.DgvRepInventoryReportStockTransferDetailReportEntity>(stockTransferDetailReportList, ++pageNumber, pageSize);
                dataStockTransferDetailReportListSource.DataSource = pageList;
            }

            buttonStockTransferDetailReportPageListFirst.Enabled = true;
            buttonStockTransferDetailReportPageListPrevious.Enabled = true;

            if (pageNumber == pageList.PageCount)
            {
                buttonStockTransferDetailReportPageListNext.Enabled = false;
                buttonStockTransferDetailReportPageListLast.Enabled = false;
            }

            buttonStockTransferDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonStockTransferDetailReportPageListLast_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepInventoryReportStockTransferDetailReportEntity>(stockTransferDetailReportList, pageList.PageCount, pageSize);
            dataStockTransferDetailReportListSource.DataSource = pageList;

            buttonStockTransferDetailReportPageListFirst.Enabled = true;
            buttonStockTransferDetailReportPageListPrevious.Enabled = true;
            buttonStockTransferDetailReportPageListNext.Enabled = false;
            buttonStockTransferDetailReportPageListLast.Enabled = false;

            pageNumber = pageList.PageCount;
            buttonStockTransferDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
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
                         "STNumber",
                         "STDate",
                         "ToBranch",
                         "Remarks",
                         "PreparedBy",
                         "CheckedBy",
                         "ApprovedBy",
                         "ItemCode",
                         "ItemDescription",
                         "ItemInventoryCode",
                         "Unit",
                         "Quantity",
                         "Cost",
                         "Amount",
                         "BaseQuantity",
                         "BaseCost"
                    };

                    csv.AppendLine(String.Join(",", header));

                    if (stockTransferDetailReportList.Any())
                    {
                        foreach (var stockTransferDetailReport in stockTransferDetailReportList)
                        {
                            String[] data =
                            {
                                stockTransferDetailReport.ColumnStockTransferDetailReportListBranch.Replace(",", ""),
                                stockTransferDetailReport.ColumnStockTransferDetailReportListSTNumber.Replace(",", ""),
                                stockTransferDetailReport.ColumnStockTransferDetailReportListSTDate.Replace(",", ""),
                                stockTransferDetailReport.ColumnStockTransferDetailReportListToBranch.Replace(",", ""),
                                stockTransferDetailReport.ColumnStockTransferDetailReportListRemarks.Replace(",", ""),
                                stockTransferDetailReport.ColumnStockTransferDetailReportListPreparedBy.Replace(",", ""),
                                stockTransferDetailReport.ColumnStockTransferDetailReportListCheckedBy.Replace(",", ""),
                                stockTransferDetailReport.ColumnStockTransferDetailReportListApprovedBy.Replace(",", ""),
                                stockTransferDetailReport.ColumnStockTransferDetailReportListItemCode.Replace(",", ""),
                                stockTransferDetailReport.ColumnStockTransferDetailReportListItemDescription.Replace(",", ""),
                                stockTransferDetailReport.ColumnStockTransferDetailReportListItemInventoryCode.Replace(",", ""),
                                stockTransferDetailReport.ColumnStockTransferDetailReportListUnit.Replace(",", ""),
                                stockTransferDetailReport.ColumnStockTransferDetailReportListQuantity.Replace(",", ""),
                                stockTransferDetailReport.ColumnStockTransferDetailReportListCost.Replace(",", ""),
                                stockTransferDetailReport.ColumnStockTransferDetailReportListAmount.Replace(",", ""),
                                stockTransferDetailReport.ColumnStockTransferDetailReportListBaseQuantity.Replace(",", ""),
                                stockTransferDetailReport.ColumnStockTransferDetailReportListBaseCost.Replace(",", ""),
                            };

                            csv.AppendLine(String.Join(",", data));
                        }
                    }

                    String executingUser = WindowsIdentity.GetCurrent().Name;

                    DirectorySecurity securityRules = new DirectorySecurity();
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.Read, AccessControlType.Allow));
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.FullControl, AccessControlType.Allow));

                    DirectoryInfo createDirectorySTCSV = Directory.CreateDirectory(folderBrowserDialogGenerateCSV.SelectedPath, securityRules);
                    File.WriteAllText(createDirectorySTCSV.FullName + "\\StockTransferDetailReport_" + Convert.ToDateTime(textBoxStartDate.Text).ToString("yyyyMMdd") + ".csv", csv.ToString(), Encoding.GetEncoding("iso-8859-1"));

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
