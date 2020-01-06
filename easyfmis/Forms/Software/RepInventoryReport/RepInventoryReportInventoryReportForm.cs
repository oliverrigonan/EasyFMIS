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
    public partial class RepInventoryReportInventoryReportForm : Form
    {
        public List<Entities.DgvRepInventoryReportEntity> inventoryReportList;
        public BindingSource dataInventoryReportListSource = new BindingSource();
        public PagedList<Entities.DgvRepInventoryReportEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;

        public DateTime startDate;
        public DateTime endDate;
        public Int32 companyId;
        public Int32 branchId;

        public RepInventoryReportInventoryReportForm(DateTime filterStartDate, DateTime filterEndDate, Int32 filterCompanyId, String filterCompanyName, Int32 filterBranchId, String filterBranchName)
        {
            InitializeComponent();

            startDate = filterStartDate;
            endDate = filterEndDate;
            companyId = filterCompanyId;
            branchId = filterBranchId;

            textBoxStartDate.Text = filterStartDate.Date.ToShortDateString();
            textBoxEndDate.Text = filterEndDate.Date.ToShortDateString();
            textBoxCompany.Text = filterCompanyName;
            textBoxBranch.Text = filterBranchName;

            CreateInventoryReportDataGridView();
        }

        public List<Entities.DgvRepInventoryReportEntity> GetInventoryReportListData(DateTime filterStartDate, DateTime filterEndDate, Int32 filterCompanyId, Int32 filterBranchId)
        {
            List<Entities.DgvRepInventoryReportEntity> rowList = new List<Entities.DgvRepInventoryReportEntity>();

            Controllers.RepInventoryReportController repInvetoryReportController = new Controllers.RepInventoryReportController();

            var inventoryReportList = repInvetoryReportController.ListInventoryReport(filterStartDate, filterEndDate, filterCompanyId, filterBranchId);
            if (inventoryReportList.Any())
            {
                var row = from d in inventoryReportList
                          select new Entities.DgvRepInventoryReportEntity
                          {
                              ColumnInventoryReportBarCode = d.BarCode,
                              ColumnInventoryReportItemDescription = d.ItemDescription,
                              ColumnInventoryReportInventoryCode = d.InventoryCode,
                              ColumnInventoryReportUnit = d.Unit,
                              ColumnInventoryReportBeginningQuantity = d.BeginningQuantity.ToString("#,##0.00"),
                              ColumnInventoryReportInQuantity = d.InQuantity.ToString("#,##0.00"),
                              ColumnInventoryReportOutQuantity = d.OutQuantity.ToString("#,##0.00"),
                              ColumnInventoryReportEndinguantity = d.Endinguantity.ToString("#,##0.00"),
                              ColumnInventoryReportCost = d.Cost.ToString("#,##0.00"),
                              ColumnInventoryReportAmount = d.Amount.ToString("#,##0.00"),
                              ColumnInventoryReportSpace = ""
                          };

                rowList = row.ToList();

            }
            return rowList;
        }

        public void GetInventoryReportDataSource()
        {
            inventoryReportList = GetInventoryReportListData(startDate, endDate, companyId, branchId);
            if (inventoryReportList.Any())
            {
                pageNumber = 1;
                pageList = new PagedList<Entities.DgvRepInventoryReportEntity>(inventoryReportList, pageNumber, pageSize);

                if (pageList.PageCount == 1)
                {
                    buttonInventoryReportPageListFirst.Enabled = false;
                    buttonInventoryReportPageListPrevious.Enabled = false;
                    buttonInventoryReportPageListNext.Enabled = false;
                    buttonInventoryReportPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonInventoryReportPageListFirst.Enabled = false;
                    buttonInventoryReportPageListPrevious.Enabled = false;
                    buttonInventoryReportPageListNext.Enabled = true;
                    buttonInventoryReportPageListLast.Enabled = true;
                }
                else if (pageNumber == pageList.PageCount)
                {
                    buttonInventoryReportPageListFirst.Enabled = true;
                    buttonInventoryReportPageListPrevious.Enabled = true;
                    buttonInventoryReportPageListNext.Enabled = false;
                    buttonInventoryReportPageListLast.Enabled = false;
                }
                else
                {
                    buttonInventoryReportPageListFirst.Enabled = true;
                    buttonInventoryReportPageListPrevious.Enabled = true;
                    buttonInventoryReportPageListNext.Enabled = true;
                    buttonInventoryReportPageListLast.Enabled = true;
                }

                textBoxInventoryReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
                dataInventoryReportListSource.DataSource = pageList;
            }
            else
            {
                buttonInventoryReportPageListFirst.Enabled = false;
                buttonInventoryReportPageListPrevious.Enabled = false;
                buttonInventoryReportPageListNext.Enabled = false;
                buttonInventoryReportPageListLast.Enabled = false;

                dataInventoryReportListSource.Clear();
                textBoxInventoryReportPageNumber.Text = "0 / 0";
            }
        }

        public void CreateInventoryReportDataGridView()
        {
            GetInventoryReportDataSource();
            dataGridViewInventoryReport.DataSource = dataInventoryReportListSource;
        }

        private void buttonInventoryReportPageListFirst_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepInventoryReportEntity>(inventoryReportList, 1, pageSize);
            dataInventoryReportListSource.DataSource = pageList;

            buttonInventoryReportPageListFirst.Enabled = false;
            buttonInventoryReportPageListPrevious.Enabled = false;
            buttonInventoryReportPageListNext.Enabled = true;
            buttonInventoryReportPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxInventoryReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonInventoryReportPageListPrevious_Click(object sender, EventArgs e)
        {
            if (pageList.HasPreviousPage == true)
            {
                pageList = new PagedList<Entities.DgvRepInventoryReportEntity>(inventoryReportList, --pageNumber, pageSize);
                dataInventoryReportListSource.DataSource = pageList;
            }

            buttonInventoryReportPageListNext.Enabled = true;
            buttonInventoryReportPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonInventoryReportPageListFirst.Enabled = false;
                buttonInventoryReportPageListPrevious.Enabled = false;
            }

            textBoxInventoryReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonInventoryReportPageListNext_Click(object sender, EventArgs e)
        {
            if (pageList.HasNextPage == true)
            {
                pageList = new PagedList<Entities.DgvRepInventoryReportEntity>(inventoryReportList, ++pageNumber, pageSize);
                dataInventoryReportListSource.DataSource = pageList;
            }

            buttonInventoryReportPageListFirst.Enabled = true;
            buttonInventoryReportPageListPrevious.Enabled = true;

            if (pageNumber == pageList.PageCount)
            {
                buttonInventoryReportPageListNext.Enabled = false;
                buttonInventoryReportPageListLast.Enabled = false;
            }

            textBoxInventoryReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonInventoryReportPageListLast_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepInventoryReportEntity>(inventoryReportList, pageList.PageCount, pageSize);
            dataInventoryReportListSource.DataSource = pageList;

            buttonInventoryReportPageListFirst.Enabled = true;
            buttonInventoryReportPageListPrevious.Enabled = true;
            buttonInventoryReportPageListNext.Enabled = false;
            buttonInventoryReportPageListLast.Enabled = false;

            pageNumber = pageList.PageCount;
            textBoxInventoryReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
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
                        "Barcode",
                        "Item Description",
                        "Inventory Code",
                        "Unit",
                        "Beginning Quantity",
                        "In Quantity",
                        "Out Quantity",
                        "Ending Quantity",
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
                                inventoryReport.ColumnInventoryReportBarCode.Replace("," , ""),
                                inventoryReport.ColumnInventoryReportItemDescription.Replace("," , ""),
                                inventoryReport.ColumnInventoryReportInventoryCode.Replace("," , ""),
                                inventoryReport.ColumnInventoryReportUnit.Replace("," , ""),
                                inventoryReport.ColumnInventoryReportBeginningQuantity.Replace("," , ""),
                                inventoryReport.ColumnInventoryReportInQuantity.Replace("," , ""),
                                inventoryReport.ColumnInventoryReportOutQuantity.Replace("," , ""),
                                inventoryReport.ColumnInventoryReportEndinguantity.Replace("," , ""),
                                inventoryReport.ColumnInventoryReportCost.Replace("," , ""),
                                inventoryReport.ColumnInventoryReportAmount.Replace("," , "")
                            };

                            csv.AppendLine(String.Join(",", data));
                        }
                    }

                    String executingUser = WindowsIdentity.GetCurrent().Name;

                    DirectorySecurity securityRules = new DirectorySecurity();
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.Read, AccessControlType.Allow));
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.FullControl, AccessControlType.Allow));

                    DirectoryInfo createDirectorySTCSV = Directory.CreateDirectory(folderBrowserDialogGenerateCSV.SelectedPath, securityRules);
                    File.WriteAllText(createDirectorySTCSV.FullName + "\\InventoryReport_" + Convert.ToDateTime(textBoxStartDate.Text).ToString("yyyyMMdd") + "_" + Convert.ToDateTime(textBoxEndDate.Text).ToString("yyyyMMdd") + ".csv", csv.ToString(), Encoding.GetEncoding("iso-8859-1"));

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
