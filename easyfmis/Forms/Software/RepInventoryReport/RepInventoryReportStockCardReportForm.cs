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
    public partial class RepInventoryReportStockCardReportForm : Form
    {
        public List<Entities.DgvRepStockCardReportEntity> inventoryReportList;
        public BindingSource dataStockCardReportListSource = new BindingSource();
        public PagedList<Entities.DgvRepStockCardReportEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;

        public DateTime startDate;
        public DateTime endDate;
        public Int32 companyId;
        public Int32 branchId;
        public Int32 itemId;

        public RepInventoryReportStockCardReportForm(DateTime filterStartDate, DateTime filterEndDate, Int32 filterCompanyId, String filterCompanyName, Int32 filterBranchId, String filterBranchName, Int32 filterItemId, String filterItemName)
        {
            InitializeComponent();

            startDate = filterStartDate;
            endDate = filterEndDate;
            companyId = filterCompanyId;
            branchId = filterBranchId;
            itemId = filterItemId;

            textBoxStartDate.Text = filterStartDate.Date.ToShortDateString();
            textBoxEndDate.Text = filterEndDate.Date.ToShortDateString();
            textBoxCompany.Text = filterCompanyName;
            textBoxBranch.Text = filterBranchName;
            textBoxItem.Text = filterItemName;

            CreateStockCardReportDataGridView();
        }

        public List<Entities.DgvRepStockCardReportEntity> GetStockCardReportListData(DateTime filterStartDate, DateTime filterEndDate, Int32 filterCompanyId, Int32 filterBranchId, Int32 filterItemId)
        {
            String filter = textBoxItemListFilter.Text;

            List<Entities.DgvRepStockCardReportEntity> rowList = new List<Entities.DgvRepStockCardReportEntity>();

            Controllers.RepInventoryReportController repInvetoryReportController = new Controllers.RepInventoryReportController();

            var inventoryReportList = repInvetoryReportController.ListStockCardInventoryReport(filterStartDate, filterEndDate, filterCompanyId, filterBranchId, filterItemId, filter);
            if (inventoryReportList.Any())
            {
                var row = from d in inventoryReportList
                          select new Entities.DgvRepStockCardReportEntity
                          {
                              ColumnStockCardReportDocument = d.Document,
                              ColumnStockCardReportInventoryDate = d.InventoryDate.ToShortDateString(),
                              ColumnStockCardReportUnit = d.Unit,
                              ColumnStockCardReportBeginningQuantity = d.BeginningQuantity.ToString("#,##0.00"),
                              ColumnStockCardReportInQuantity = d.InQuantity.ToString("#,##0.00"),
                              ColumnStockCardReportOutQuantity = d.OutQuantity.ToString("#,##0.00"),
                              ColumnStockCardReportRunninguantity = d.Runninguantity.ToString("#,##0.00"),
                              ColumnStockCardReportCost = d.Cost.ToString("#,##0.00"),
                              ColumnStockCardReportAmount = d.Amount.ToString("#,##0.00"),
                              ColumnStockCardReportSpace = ""
                          };

                rowList = row.ToList();

                Decimal totalAmount = inventoryReportList.Sum(d => d.Amount);
                Decimal totalInQuantity = inventoryReportList.Sum(d => d.InQuantity);
                Decimal totalOutQuantity = inventoryReportList.Sum(d => d.OutQuantity);

                Entities.DgvRepStockCardReportEntity totalAmountStockCardReprot = new Entities.DgvRepStockCardReportEntity()
                {
                    ColumnStockCardReportDocument = "Total",
                    ColumnStockCardReportInventoryDate = "",
                    ColumnStockCardReportUnit = "",
                    ColumnStockCardReportBeginningQuantity = "",
                    ColumnStockCardReportInQuantity = totalInQuantity.ToString("#,##0.00"),
                    ColumnStockCardReportOutQuantity = totalOutQuantity.ToString("#,##0.00"),
                    ColumnStockCardReportRunninguantity = "",
                    ColumnStockCardReportCost = "",
                    ColumnStockCardReportAmount = "",
                    ColumnStockCardReportSpace = ""
                };

                rowList.Add(totalAmountStockCardReprot);
            }
            return rowList;
        }

        public void GetStockCardReportDataSource()
        {
            inventoryReportList = GetStockCardReportListData(startDate, endDate, companyId, branchId, itemId);
            if (inventoryReportList.Any())
            {
                pageNumber = 1;
                pageList = new PagedList<Entities.DgvRepStockCardReportEntity>(inventoryReportList, pageNumber, pageSize);

                if (pageList.PageCount == 1)
                {
                    buttonStockCardReportPageListFirst.Enabled = false;
                    buttonStockCardReportPageListPrevious.Enabled = false;
                    buttonStockCardReportPageListNext.Enabled = false;
                    buttonStockCardReportPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonStockCardReportPageListFirst.Enabled = false;
                    buttonStockCardReportPageListPrevious.Enabled = false;
                    buttonStockCardReportPageListNext.Enabled = true;
                    buttonStockCardReportPageListLast.Enabled = true;
                }
                else if (pageNumber == pageList.PageCount)
                {
                    buttonStockCardReportPageListFirst.Enabled = true;
                    buttonStockCardReportPageListPrevious.Enabled = true;
                    buttonStockCardReportPageListNext.Enabled = false;
                    buttonStockCardReportPageListLast.Enabled = false;
                }
                else
                {
                    buttonStockCardReportPageListFirst.Enabled = true;
                    buttonStockCardReportPageListPrevious.Enabled = true;
                    buttonStockCardReportPageListNext.Enabled = true;
                    buttonStockCardReportPageListLast.Enabled = true;
                }

                textBoxStockCardReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
                dataStockCardReportListSource.DataSource = pageList;
            }
            else
            {
                buttonStockCardReportPageListFirst.Enabled = false;
                buttonStockCardReportPageListPrevious.Enabled = false;
                buttonStockCardReportPageListNext.Enabled = false;
                buttonStockCardReportPageListLast.Enabled = false;

                dataStockCardReportListSource.Clear();
                textBoxStockCardReportPageNumber.Text = "0 / 0";
            }
        }

        public void CreateStockCardReportDataGridView()
        {
            GetStockCardReportDataSource();
            dataGridViewStockCardReport.DataSource = dataStockCardReportListSource;
        }

        public void UpdateStockCardReportDataGridView()
        {
            CreateStockCardReportDataGridView();
        }

        private void buttonStockCardReportPageListFirst_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepStockCardReportEntity>(inventoryReportList, 1, pageSize);
            dataStockCardReportListSource.DataSource = pageList;

            buttonStockCardReportPageListFirst.Enabled = false;
            buttonStockCardReportPageListPrevious.Enabled = false;
            buttonStockCardReportPageListNext.Enabled = true;
            buttonStockCardReportPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxStockCardReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonStockCardReportPageListPrevious_Click(object sender, EventArgs e)
        {
            if (pageList.HasPreviousPage == true)
            {
                pageList = new PagedList<Entities.DgvRepStockCardReportEntity>(inventoryReportList, --pageNumber, pageSize);
                dataStockCardReportListSource.DataSource = pageList;
            }

            buttonStockCardReportPageListNext.Enabled = true;
            buttonStockCardReportPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonStockCardReportPageListFirst.Enabled = false;
                buttonStockCardReportPageListPrevious.Enabled = false;
            }

            textBoxStockCardReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonStockCardReportPageListNext_Click(object sender, EventArgs e)
        {
            if (pageList.HasNextPage == true)
            {
                pageList = new PagedList<Entities.DgvRepStockCardReportEntity>(inventoryReportList, ++pageNumber, pageSize);
                dataStockCardReportListSource.DataSource = pageList;
            }

            buttonStockCardReportPageListFirst.Enabled = true;
            buttonStockCardReportPageListPrevious.Enabled = true;

            if (pageNumber == pageList.PageCount)
            {
                buttonStockCardReportPageListNext.Enabled = false;
                buttonStockCardReportPageListLast.Enabled = false;
            }

            textBoxStockCardReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonStockCardReportPageListLast_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepStockCardReportEntity>(inventoryReportList, pageList.PageCount, pageSize);
            dataStockCardReportListSource.DataSource = pageList;

            buttonStockCardReportPageListFirst.Enabled = true;
            buttonStockCardReportPageListPrevious.Enabled = true;
            buttonStockCardReportPageListNext.Enabled = false;
            buttonStockCardReportPageListLast.Enabled = false;

            pageNumber = pageList.PageCount;
            textBoxStockCardReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
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
                        "Document",
                        "Inventory Date",
                        "Unit",
                        "Beginning Quantity",
                        "In Quantity",
                        "Out Quantity",
                        "Running Quantity",
                        "Cost",
                        "Amount"
                    };

                    csv.AppendLine(String.Join(",", header));

                    if (inventoryReportList.Any())
                    {
                        foreach (var inventoryReport in inventoryReportList)
                        {
                            String[] data =
                            {
                                inventoryReport.ColumnStockCardReportDocument.Replace("," , ""),
                                inventoryReport.ColumnStockCardReportInventoryDate.Replace("," , ""),
                                inventoryReport.ColumnStockCardReportUnit.Replace("," , ""),
                                inventoryReport.ColumnStockCardReportBeginningQuantity.Replace("," , ""),
                                inventoryReport.ColumnStockCardReportInQuantity.Replace("," , ""),
                                inventoryReport.ColumnStockCardReportOutQuantity.Replace("," , ""),
                                inventoryReport.ColumnStockCardReportRunninguantity.Replace("," , ""),
                                inventoryReport.ColumnStockCardReportCost.Replace("," , ""),
                                inventoryReport.ColumnStockCardReportAmount.Replace("," , "")
                            };

                            csv.AppendLine(String.Join(",", data));
                        }
                    }

                    String executingUser = WindowsIdentity.GetCurrent().Name;

                    DirectorySecurity securityRules = new DirectorySecurity();
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.Read, AccessControlType.Allow));
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.FullControl, AccessControlType.Allow));

                    DirectoryInfo createDirectorySTCSV = Directory.CreateDirectory(folderBrowserDialogGenerateCSV.SelectedPath, securityRules);
                    File.WriteAllText(createDirectorySTCSV.FullName + "\\StockCardReport_" + Convert.ToDateTime(textBoxStartDate.Text).ToString("yyyyMMdd") + "_" + Convert.ToDateTime(textBoxEndDate.Text).ToString("yyyyMMdd") + ".csv", csv.ToString(), Encoding.GetEncoding("iso-8859-1"));

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
                UpdateStockCardReportDataGridView();
            }
        }
    }
}
