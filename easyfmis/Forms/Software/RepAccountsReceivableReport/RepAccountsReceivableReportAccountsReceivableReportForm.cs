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
    public partial class RepAccountsReceivableReportAccountsReceivableReportForm : Form
    {
        public List<Entities.DgvRepAccountsReceivableReportEntity> accountsReceivableReportList;
        public BindingSource dataAccountsReceivableReportListSource = new BindingSource();
        public PagedList<Entities.DgvRepAccountsReceivableReportEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;

        public DateTime dateAsOf;
        public Int32 companyId;
        public Int32 branchId;

        public RepAccountsReceivableReportAccountsReceivableReportForm(DateTime filterDateAsOf, Int32 filterCompanyId, String filterCompanyName, Int32 filterBranchId, String filterBranchName)
        {
            InitializeComponent();

            dateAsOf = filterDateAsOf;
            companyId = filterCompanyId;
            branchId = filterBranchId;

            textBoxDateAsOf.Text = filterDateAsOf.Date.ToShortDateString();
            textBoxCompany.Text = filterCompanyName;
            textBoxBranch.Text = filterBranchName;

            CreateAccountsReceivableReportDataGridView();
        }

        public List<Entities.DgvRepAccountsReceivableReportEntity> GetAccountsReceivableReportListData(DateTime filterDateAsOf, Int32 filterCompanyId, Int32 filterBranchId)
        {
            List<Entities.DgvRepAccountsReceivableReportEntity> rowList = new List<Entities.DgvRepAccountsReceivableReportEntity>();

            Controllers.RepAccountsReceivableReportController repInvetoryReportController = new Controllers.RepAccountsReceivableReportController();

            var accountsReceivableReportList = repInvetoryReportController.ListAccountsReceivableReport(filterDateAsOf, filterCompanyId, filterBranchId);
            if (accountsReceivableReportList.Any())
            {
                var row = from d in accountsReceivableReportList
                          select new Entities.DgvRepAccountsReceivableReportEntity
                          {
                              ColumnAccountsReceivableReportSIId = d.SIId,
                              ColumnAccountsReceivableReportBranch = d.Branch,
                              ColumnAccountsReceivableReportSINumber = d.SINumber,
                              ColumnAccountsReceivableReportSIDate = d.SIDate,
                              ColumnAccountsReceivableReportManualSINumber = d.ManualSINumber,
                              ColumnAccountsReceivableReportCustomerCode = d.CustomerCode,
                              ColumnAccountsReceivableReportCustomer = d.Customer,
                              ColumnAccountsReceivableReportDueDate = d.DueDate,
                              ColumnAccountsReceivableReportBalanceAmount = d.BalanceAmount.ToString("#,##0.00"),
                              ColumnAccountsReceivableReportCurrentAmount = d.CurrentAmount.ToString("#,##0.00"),
                              ColumnAccountsReceivableReportAge30Amount = d.Age30Amount.ToString("#,##0.00"),
                              ColumnAccountsReceivableReportAge60Amount = d.Age60Amount.ToString("#,##0.00"),
                              ColumnAccountsReceivableReportAge90Amount = d.Age90Amount.ToString("#,##0.00"),
                              ColumnAccountsReceivableReportAge120Amount = d.Age120Amount.ToString("#,##0.00"),
                              ColumnAccountsReceivableReportSpace = ""
                          };

                rowList = row.ToList();

                Decimal totalBalanceAmount = accountsReceivableReportList.Sum(d => d.BalanceAmount);
                Decimal totalCurrentAmount = accountsReceivableReportList.Sum(d => d.CurrentAmount);
                Decimal totalAge30Amount = accountsReceivableReportList.Sum(d => d.Age30Amount);
                Decimal totalAge60Amount = accountsReceivableReportList.Sum(d => d.Age60Amount);
                Decimal totalAge90Amount = accountsReceivableReportList.Sum(d => d.Age90Amount);
                Decimal totalAge120Amount = accountsReceivableReportList.Sum(d => d.Age120Amount);


                Entities.DgvRepAccountsReceivableReportEntity totalAccountsReceivableReport = new Entities.DgvRepAccountsReceivableReportEntity()
                {
                    ColumnAccountsReceivableReportSIId = 0,
                    ColumnAccountsReceivableReportBranch = "Total",
                    ColumnAccountsReceivableReportSINumber = "",
                    ColumnAccountsReceivableReportSIDate = "",
                    ColumnAccountsReceivableReportManualSINumber = "",
                    ColumnAccountsReceivableReportCustomerCode = "",
                    ColumnAccountsReceivableReportCustomer = "",
                    ColumnAccountsReceivableReportDueDate = "",
                    ColumnAccountsReceivableReportBalanceAmount = totalBalanceAmount.ToString("#,##0.00"),
                    ColumnAccountsReceivableReportCurrentAmount = totalCurrentAmount.ToString("#,##0.00"),
                    ColumnAccountsReceivableReportAge30Amount = totalAge30Amount.ToString("#,##0.00"),
                    ColumnAccountsReceivableReportAge60Amount = totalAge60Amount.ToString("#,##0.00"),
                    ColumnAccountsReceivableReportAge90Amount = totalAge90Amount.ToString("#,##0.00"),
                    ColumnAccountsReceivableReportAge120Amount = totalAge120Amount.ToString("#,##0.00"),
                    ColumnAccountsReceivableReportSpace = ""
                };

                rowList.Add(totalAccountsReceivableReport);
            }
            return rowList;
        }

        public void GetAccountsReceivableReportDataSource()
        {
            accountsReceivableReportList = GetAccountsReceivableReportListData(dateAsOf, companyId, branchId);
            if (accountsReceivableReportList.Any())
            {
                pageNumber = 1;
                pageList = new PagedList<Entities.DgvRepAccountsReceivableReportEntity>(accountsReceivableReportList, pageNumber, pageSize);

                if (pageList.PageCount == 1)
                {
                    buttonAccountsReceivableReportPageListFirst.Enabled = false;
                    buttonAccountsReceivableReportPageListPrevious.Enabled = false;
                    buttonAccountsReceivableReportPageListNext.Enabled = false;
                    buttonAccountsReceivableReportPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonAccountsReceivableReportPageListFirst.Enabled = false;
                    buttonAccountsReceivableReportPageListPrevious.Enabled = false;
                    buttonAccountsReceivableReportPageListNext.Enabled = true;
                    buttonAccountsReceivableReportPageListLast.Enabled = true;
                }
                else if (pageNumber == pageList.PageCount)
                {
                    buttonAccountsReceivableReportPageListFirst.Enabled = true;
                    buttonAccountsReceivableReportPageListPrevious.Enabled = true;
                    buttonAccountsReceivableReportPageListNext.Enabled = false;
                    buttonAccountsReceivableReportPageListLast.Enabled = false;
                }
                else
                {
                    buttonAccountsReceivableReportPageListFirst.Enabled = true;
                    buttonAccountsReceivableReportPageListPrevious.Enabled = true;
                    buttonAccountsReceivableReportPageListNext.Enabled = true;
                    buttonAccountsReceivableReportPageListLast.Enabled = true;
                }

                textBoxAccountsReceivableReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
                dataAccountsReceivableReportListSource.DataSource = pageList;
            }
            else
            {
                buttonAccountsReceivableReportPageListFirst.Enabled = false;
                buttonAccountsReceivableReportPageListPrevious.Enabled = false;
                buttonAccountsReceivableReportPageListNext.Enabled = false;
                buttonAccountsReceivableReportPageListLast.Enabled = false;

                dataAccountsReceivableReportListSource.Clear();
                textBoxAccountsReceivableReportPageNumber.Text = "0 / 0";
            }
        }

        public void CreateAccountsReceivableReportDataGridView()
        {
            GetAccountsReceivableReportDataSource();
            dataGridViewAccountsReceivableReport.DataSource = dataAccountsReceivableReportListSource;
        }

        private void buttonAccountsReceivableReportPageListFirst_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepAccountsReceivableReportEntity>(accountsReceivableReportList, 1, pageSize);
            dataAccountsReceivableReportListSource.DataSource = pageList;

            buttonAccountsReceivableReportPageListFirst.Enabled = false;
            buttonAccountsReceivableReportPageListPrevious.Enabled = false;
            buttonAccountsReceivableReportPageListNext.Enabled = true;
            buttonAccountsReceivableReportPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxAccountsReceivableReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonAccountsReceivableReportPageListPrevious_Click(object sender, EventArgs e)
        {
            if (pageList.HasPreviousPage == true)
            {
                pageList = new PagedList<Entities.DgvRepAccountsReceivableReportEntity>(accountsReceivableReportList, --pageNumber, pageSize);
                dataAccountsReceivableReportListSource.DataSource = pageList;
            }

            buttonAccountsReceivableReportPageListNext.Enabled = true;
            buttonAccountsReceivableReportPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonAccountsReceivableReportPageListFirst.Enabled = false;
                buttonAccountsReceivableReportPageListPrevious.Enabled = false;
            }

            textBoxAccountsReceivableReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonAccountsReceivableReportPageListNext_Click(object sender, EventArgs e)
        {
            if (pageList.HasNextPage == true)
            {
                pageList = new PagedList<Entities.DgvRepAccountsReceivableReportEntity>(accountsReceivableReportList, ++pageNumber, pageSize);
                dataAccountsReceivableReportListSource.DataSource = pageList;
            }

            buttonAccountsReceivableReportPageListFirst.Enabled = true;
            buttonAccountsReceivableReportPageListPrevious.Enabled = true;

            if (pageNumber == pageList.PageCount)
            {
                buttonAccountsReceivableReportPageListNext.Enabled = false;
                buttonAccountsReceivableReportPageListLast.Enabled = false;
            }

            textBoxAccountsReceivableReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonAccountsReceivableReportPageListLast_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepAccountsReceivableReportEntity>(accountsReceivableReportList, pageList.PageCount, pageSize);
            dataAccountsReceivableReportListSource.DataSource = pageList;

            buttonAccountsReceivableReportPageListFirst.Enabled = true;
            buttonAccountsReceivableReportPageListPrevious.Enabled = true;
            buttonAccountsReceivableReportPageListNext.Enabled = false;
            buttonAccountsReceivableReportPageListLast.Enabled = false;

            pageNumber = pageList.PageCount;
            textBoxAccountsReceivableReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
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
                        "SI Number",
                        "SI Date",
                        "Manual SI Number",
                        "Customer Code",
                        "Customer",
                        "Due Date",
                        "Balance Amount",
                        "Current Amount",
                        "30 Days",
                        "60 Days",
                        "90 Days",
                        "Over 120 Days"
                    };

                    csv.AppendLine(String.Join(",", header));

                    if (accountsReceivableReportList.Any())
                    {
                        foreach (var accountsReceivableReport in accountsReceivableReportList)
                        {
                            String[] data =
                            {
                                accountsReceivableReport.ColumnAccountsReceivableReportBranch.Replace(",", ""),
                                accountsReceivableReport.ColumnAccountsReceivableReportSINumber.Replace(",", ""),
                                accountsReceivableReport.ColumnAccountsReceivableReportSIDate.Replace(",", ""),
                                accountsReceivableReport.ColumnAccountsReceivableReportManualSINumber.Replace(",", ""),
                                accountsReceivableReport.ColumnAccountsReceivableReportCustomerCode.Replace(",", ""),
                                accountsReceivableReport.ColumnAccountsReceivableReportCustomer.Replace(",", ""),
                                accountsReceivableReport.ColumnAccountsReceivableReportDueDate.Replace(",", ""),
                                accountsReceivableReport.ColumnAccountsReceivableReportBalanceAmount.Replace(",", ""),
                                accountsReceivableReport.ColumnAccountsReceivableReportCurrentAmount.Replace(",", ""),
                                accountsReceivableReport.ColumnAccountsReceivableReportAge30Amount.Replace(",", ""),
                                accountsReceivableReport.ColumnAccountsReceivableReportAge60Amount.Replace(",", ""),
                                accountsReceivableReport.ColumnAccountsReceivableReportAge90Amount.Replace(",", ""),
                                accountsReceivableReport.ColumnAccountsReceivableReportAge120Amount.Replace(",", ""),
                            };

                            csv.AppendLine(String.Join(",", data));
                        }
                    }

                    String executingUser = WindowsIdentity.GetCurrent().Name;

                    DirectorySecurity securityRules = new DirectorySecurity();
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.Read, AccessControlType.Allow));
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.FullControl, AccessControlType.Allow));

                    DirectoryInfo createDirectorySTCSV = Directory.CreateDirectory(folderBrowserDialogGenerateCSV.SelectedPath, securityRules);
                    File.WriteAllText(createDirectorySTCSV.FullName + "\\AccountsReceivableReport_" + Convert.ToDateTime(textBoxDateAsOf.Text).ToString("yyyyMMdd") + ".csv", csv.ToString(), Encoding.GetEncoding("iso-8859-1"));

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
