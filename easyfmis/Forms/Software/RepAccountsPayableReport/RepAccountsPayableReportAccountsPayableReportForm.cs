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
    public partial class RepAccountsPayableReportAccountsPayableReportForm : Form
    {
        public List<Entities.DgvRepAccountsPayableReportEntity> accountsPayableReportList;
        public BindingSource dataAccountsPayableReportListSource = new BindingSource();
        public PagedList<Entities.DgvRepAccountsPayableReportEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;

        public DateTime dateAsOf;
        public Int32 companyId;
        public Int32 branchId;

        public RepAccountsPayableReportAccountsPayableReportForm(DateTime filterDateAsOf, Int32 filterCompanyId, String filterCompanyName, Int32 filterBranchId, String filterBranchName)
        {
            InitializeComponent();

            dateAsOf = filterDateAsOf;
            companyId = filterCompanyId;
            branchId = filterBranchId;

            textBoxDateAsOf.Text = filterDateAsOf.Date.ToShortDateString();
            textBoxCompany.Text = filterCompanyName;
            textBoxBranch.Text = filterBranchName;

            CreateAccountsPayableReportDataGridView();
        }

        public List<Entities.DgvRepAccountsPayableReportEntity> GetAccountsPayableReportListData(DateTime filterDateAsOf, Int32 filterCompanyId, Int32 filterBranchId)
        {
            List<Entities.DgvRepAccountsPayableReportEntity> rowList = new List<Entities.DgvRepAccountsPayableReportEntity>();

            Controllers.RepAccountsPayableReportController repInvetoryReportController = new Controllers.RepAccountsPayableReportController();

            var accountsPayableReportList = repInvetoryReportController.ListAccountsPayableReport(filterDateAsOf, filterCompanyId, filterBranchId);
            if (accountsPayableReportList.Any())
            {
                var row = from d in accountsPayableReportList
                          select new Entities.DgvRepAccountsPayableReportEntity
                          {
                              ColumnAccountsPayableReportRRId = d.RRId,
                              ColumnAccountsPayableReportBranch = d.Branch,
                              ColumnAccountsPayableReportRRNumber = d.RRNumber,
                              ColumnAccountsPayableReportRRDate = d.RRDate,
                              ColumnAccountsPayableReportManualRRNumber = d.ManualRRNumber,
                              ColumnAccountsPayableReportSupplierCode = d.SupplierCode,
                              ColumnAccountsPayableReportSupplier = d.Supplier,
                              ColumnAccountsPayableReportDueDate = d.DueDate,
                              ColumnAccountsPayableReportBalanceAmount = d.BalanceAmount.ToString("#,##0.00"),
                              ColumnAccountsPayableReportCurrentAmount = d.CurrentAmount.ToString("#,##0.00"),
                              ColumnAccountsPayableReportAge30Amount = d.Age30Amount.ToString("#,##0.00"),
                              ColumnAccountsPayableReportAge60Amount = d.Age60Amount.ToString("#,##0.00"),
                              ColumnAccountsPayableReportAge90Amount = d.Age90Amount.ToString("#,##0.00"),
                              ColumnAccountsPayableReportAge120Amount = d.Age120Amount.ToString("#,##0.00"),
                              ColumnAccountsPayableReportSpace = ""
                          };

                rowList = row.ToList();

            }
            return rowList;
        }

        public void GetAccountsPayableReportDataSource()
        {
            accountsPayableReportList = GetAccountsPayableReportListData(dateAsOf, companyId, branchId);
            if (accountsPayableReportList.Any())
            {
                pageNumber = 1;
                pageList = new PagedList<Entities.DgvRepAccountsPayableReportEntity>(accountsPayableReportList, pageNumber, pageSize);

                if (pageList.PageCount == 1)
                {
                    buttonAccountsPayableReportPageListFirst.Enabled = false;
                    buttonAccountsPayableReportPageListPrevious.Enabled = false;
                    buttonAccountsPayableReportPageListNext.Enabled = false;
                    buttonAccountsPayableReportPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonAccountsPayableReportPageListFirst.Enabled = false;
                    buttonAccountsPayableReportPageListPrevious.Enabled = false;
                    buttonAccountsPayableReportPageListNext.Enabled = true;
                    buttonAccountsPayableReportPageListLast.Enabled = true;
                }
                else if (pageNumber == pageList.PageCount)
                {
                    buttonAccountsPayableReportPageListFirst.Enabled = true;
                    buttonAccountsPayableReportPageListPrevious.Enabled = true;
                    buttonAccountsPayableReportPageListNext.Enabled = false;
                    buttonAccountsPayableReportPageListLast.Enabled = false;
                }
                else
                {
                    buttonAccountsPayableReportPageListFirst.Enabled = true;
                    buttonAccountsPayableReportPageListPrevious.Enabled = true;
                    buttonAccountsPayableReportPageListNext.Enabled = true;
                    buttonAccountsPayableReportPageListLast.Enabled = true;
                }

                textBoxAccountsPayableReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
                dataAccountsPayableReportListSource.DataSource = pageList;
            }
            else
            {
                buttonAccountsPayableReportPageListFirst.Enabled = false;
                buttonAccountsPayableReportPageListPrevious.Enabled = false;
                buttonAccountsPayableReportPageListNext.Enabled = false;
                buttonAccountsPayableReportPageListLast.Enabled = false;

                dataAccountsPayableReportListSource.Clear();
                textBoxAccountsPayableReportPageNumber.Text = "0 / 0";
            }
        }

        public void CreateAccountsPayableReportDataGridView()
        {
            GetAccountsPayableReportDataSource();
            dataGridViewAccountsPayableReport.DataSource = dataAccountsPayableReportListSource;
        }

        private void buttonAccountsPayableReportPageListFirst_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepAccountsPayableReportEntity>(accountsPayableReportList, 1, pageSize);
            dataAccountsPayableReportListSource.DataSource = pageList;

            buttonAccountsPayableReportPageListFirst.Enabled = false;
            buttonAccountsPayableReportPageListPrevious.Enabled = false;
            buttonAccountsPayableReportPageListNext.Enabled = true;
            buttonAccountsPayableReportPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxAccountsPayableReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonAccountsPayableReportPageListPrevious_Click(object sender, EventArgs e)
        {
            if (pageList.HasPreviousPage == true)
            {
                pageList = new PagedList<Entities.DgvRepAccountsPayableReportEntity>(accountsPayableReportList, --pageNumber, pageSize);
                dataAccountsPayableReportListSource.DataSource = pageList;
            }

            buttonAccountsPayableReportPageListNext.Enabled = true;
            buttonAccountsPayableReportPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonAccountsPayableReportPageListFirst.Enabled = false;
                buttonAccountsPayableReportPageListPrevious.Enabled = false;
            }

            textBoxAccountsPayableReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonAccountsPayableReportPageListNext_Click(object sender, EventArgs e)
        {
            if (pageList.HasNextPage == true)
            {
                pageList = new PagedList<Entities.DgvRepAccountsPayableReportEntity>(accountsPayableReportList, ++pageNumber, pageSize);
                dataAccountsPayableReportListSource.DataSource = pageList;
            }

            buttonAccountsPayableReportPageListFirst.Enabled = true;
            buttonAccountsPayableReportPageListPrevious.Enabled = true;

            if (pageNumber == pageList.PageCount)
            {
                buttonAccountsPayableReportPageListNext.Enabled = false;
                buttonAccountsPayableReportPageListLast.Enabled = false;
            }

            textBoxAccountsPayableReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonAccountsPayableReportPageListLast_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepAccountsPayableReportEntity>(accountsPayableReportList, pageList.PageCount, pageSize);
            dataAccountsPayableReportListSource.DataSource = pageList;

            buttonAccountsPayableReportPageListFirst.Enabled = true;
            buttonAccountsPayableReportPageListPrevious.Enabled = true;
            buttonAccountsPayableReportPageListNext.Enabled = false;
            buttonAccountsPayableReportPageListLast.Enabled = false;

            pageNumber = pageList.PageCount;
            textBoxAccountsPayableReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
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
                        "RR Number",
                        "RR Date",
                        "Manual RR Number",
                        "Supplier Code",
                        "Supplier",
                        "Due Date",
                        "Balance Amount",
                        "Current Amount",
                        "30 Days",
                        "60 Days",
                        "90 Days",
                        "Over 120 Days"
                    };

                    csv.AppendLine(String.Join(",", header));

                    if (accountsPayableReportList.Any())
                    {
                        foreach (var accountsPayableReport in accountsPayableReportList)
                        {
                            String[] data =
                            {
                                accountsPayableReport.ColumnAccountsPayableReportBranch.Replace(",", ""),
                                accountsPayableReport.ColumnAccountsPayableReportRRNumber.Replace(",", ""),
                                accountsPayableReport.ColumnAccountsPayableReportRRDate.Replace(",", ""),
                                accountsPayableReport.ColumnAccountsPayableReportManualRRNumber.Replace(",", ""),
                                accountsPayableReport.ColumnAccountsPayableReportSupplierCode.Replace(",", ""),
                                accountsPayableReport.ColumnAccountsPayableReportSupplier.Replace(",", ""),
                                accountsPayableReport.ColumnAccountsPayableReportDueDate.Replace(",", ""),
                                accountsPayableReport.ColumnAccountsPayableReportBalanceAmount.Replace(",", ""),
                                accountsPayableReport.ColumnAccountsPayableReportCurrentAmount.Replace(",", ""),
                                accountsPayableReport.ColumnAccountsPayableReportAge30Amount.Replace(",", ""),
                                accountsPayableReport.ColumnAccountsPayableReportAge60Amount.Replace(",", ""),
                                accountsPayableReport.ColumnAccountsPayableReportAge90Amount.Replace(",", ""),
                                accountsPayableReport.ColumnAccountsPayableReportAge120Amount.Replace(",", ""),
                            };

                            csv.AppendLine(String.Join(",", data));
                        }
                    }

                    String executingUser = WindowsIdentity.GetCurrent().Name;

                    DirectorySecurity securityRules = new DirectorySecurity();
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.Read, AccessControlType.Allow));
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.FullControl, AccessControlType.Allow));

                    DirectoryInfo createDirectorySTCSV = Directory.CreateDirectory(folderBrowserDialogGenerateCSV.SelectedPath, securityRules);
                    File.WriteAllText(createDirectorySTCSV.FullName + "\\AccountsPayableReport_" + Convert.ToDateTime(textBoxDateAsOf.Text).ToString("yyyyMMdd") + ".csv", csv.ToString(), Encoding.GetEncoding("iso-8859-1"));

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
