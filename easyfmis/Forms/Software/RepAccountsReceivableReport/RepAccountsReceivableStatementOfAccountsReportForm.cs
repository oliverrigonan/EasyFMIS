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
    public partial class RepAccountsReceivableStatementOfAccountsReportForm : Form
    {
        public List<Entities.DgvRepAccountsReceivableStatementOfAccountReportEntity> statementOfAccountReportList;
        public BindingSource dataStatementOfAccountReportListSource = new BindingSource();
        public PagedList<Entities.DgvRepAccountsReceivableStatementOfAccountReportEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;

        public DateTime dateAsOf;
        public Int32 companyId;
        public Int32 branchId;
        public Int32 customerId;

        public RepAccountsReceivableStatementOfAccountsReportForm(DateTime filterDateAsOf, Int32 filterCompanyId, String filterCompanyName, Int32 filterBranchId, String filterBranchName, Int32 filterCustomerId, String filterCustomer)
        {
            InitializeComponent();

            dateAsOf = filterDateAsOf;
            companyId = filterCompanyId;
            branchId = filterBranchId;
            customerId = filterCustomerId;

            textBoxDateAsOf.Text = filterDateAsOf.Date.ToShortDateString();
            textBoxCompany.Text = filterCompanyName;
            textBoxBranch.Text = filterBranchName;
            textBoxCustomer.Text = filterCustomer;

            CreateStatementOfAccountReportDataGridView();
        }

        public List<Entities.DgvRepAccountsReceivableStatementOfAccountReportEntity> GetStatementOfAccountReportListData(DateTime filterDateAsOf, Int32 filterCompanyId, Int32 filterBranchId, Int32 filterCustomerId)
        {
            String filter = textBoxItemListFilter.Text;
            List<Entities.DgvRepAccountsReceivableStatementOfAccountReportEntity> rowList = new List<Entities.DgvRepAccountsReceivableStatementOfAccountReportEntity>();

            Controllers.RepAccountsReceivableReportController repAccountsReceivableReportController = new Controllers.RepAccountsReceivableReportController();

            var statementOfAccountReportList = repAccountsReceivableReportController.ListStatementOfAccountReport(filterDateAsOf, filterCompanyId, filterBranchId, filterCustomerId, filter);
            if (statementOfAccountReportList.Any())
            {
                var row = from d in statementOfAccountReportList
                          select new Entities.DgvRepAccountsReceivableStatementOfAccountReportEntity
                          {
                              ColumnReceivableStatementOfAccountReportListBranch = d.Branch,
                              ColumnReceivableStatementOfAccountReportListSINumber = d.SINumber,
                              ColumnReceivableStatementOfAccountReportListSIDate = d.SIDate.ToShortDateString(),
                              ColumnReceivableStatementOfAccountReportListCustomer = d.Customer,
                              ColumnReceivableStatementOfAccountReportListManualSINumber = d.ManualSINumber,
                              ColumnReceivableStatementOfAccountReportListTerm = d.Term,
                              ColumnReceivableStatementOfAccountReportListAmount = d.Amount.ToString("#,##0.00"),
                              ColumnReceivableStatementOfAccountReportListPaidAmount = d.PaidAmount.ToString("#,##0.00"),
                              ColumnReceivableStatementOfAccountReportListMemoAmount = d.MemoAmount.ToString("#,##0.00"),
                              ColumnReceivableStatementOfAccountReportListBalanceAmount = d.BalanceAmount.ToString("#,##0.00")
                          };

                rowList = row.ToList();

                Decimal totalAmount = statementOfAccountReportList.Sum(d=> d.Amount);
                Decimal totalPaidAmount = statementOfAccountReportList.Sum(d=> d.PaidAmount);
                Decimal totalMemoAmount = statementOfAccountReportList.Sum(d=> d.MemoAmount);
                Decimal totalBalanceAmount = statementOfAccountReportList.Sum(d=> d.BalanceAmount);

                Entities.DgvRepAccountsReceivableStatementOfAccountReportEntity totalStatementOfAccountReport = new Entities.DgvRepAccountsReceivableStatementOfAccountReportEntity()
                {
                    ColumnReceivableStatementOfAccountReportListBranch = "Total",
                    ColumnReceivableStatementOfAccountReportListSINumber = "",
                    ColumnReceivableStatementOfAccountReportListSIDate = "",
                    ColumnReceivableStatementOfAccountReportListCustomer = "",
                    ColumnReceivableStatementOfAccountReportListManualSINumber = "",
                    ColumnReceivableStatementOfAccountReportListTerm = "",
                    ColumnReceivableStatementOfAccountReportListAmount = totalAmount.ToString("#,##0.00"),
                    ColumnReceivableStatementOfAccountReportListPaidAmount = totalPaidAmount.ToString("#,##0.00"),
                    ColumnReceivableStatementOfAccountReportListMemoAmount = totalMemoAmount.ToString("#,##0.00"),
                    ColumnReceivableStatementOfAccountReportListBalanceAmount = totalBalanceAmount.ToString("#,##0.00")
                };

                rowList.Add(totalStatementOfAccountReport);

            }
            return rowList;
        }

        public void GetStatementOfAccountReportDataSource()
        {
            statementOfAccountReportList = GetStatementOfAccountReportListData(dateAsOf, companyId, branchId, customerId);
            if (statementOfAccountReportList.Any())
            {
                pageNumber = 1;
                pageList = new PagedList<Entities.DgvRepAccountsReceivableStatementOfAccountReportEntity>(statementOfAccountReportList, pageNumber, pageSize);

                if (pageList.PageCount == 1)
                {
                    buttonStatementOfAccountReportPageListFirst.Enabled = false;
                    buttonStatementOfAccountleReportPageListPrevious.Enabled = false;
                    buttonStatementOfAccountReportPageListNext.Enabled = false;
                    buttonStatementOfAccountReportPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonStatementOfAccountReportPageListFirst.Enabled = false;
                    buttonStatementOfAccountleReportPageListPrevious.Enabled = false;
                    buttonStatementOfAccountReportPageListNext.Enabled = true;
                    buttonStatementOfAccountReportPageListLast.Enabled = true;
                }
                else if (pageNumber == pageList.PageCount)
                {
                    buttonStatementOfAccountReportPageListFirst.Enabled = true;
                    buttonStatementOfAccountleReportPageListPrevious.Enabled = true;
                    buttonStatementOfAccountReportPageListNext.Enabled = false;
                    buttonStatementOfAccountReportPageListLast.Enabled = false;
                }
                else
                {
                    buttonStatementOfAccountReportPageListFirst.Enabled = true;
                    buttonStatementOfAccountleReportPageListPrevious.Enabled = true;
                    buttonStatementOfAccountReportPageListNext.Enabled = true;
                    buttonStatementOfAccountReportPageListLast.Enabled = true;
                }

                textBoxStatementOfAccountReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
                dataStatementOfAccountReportListSource.DataSource = pageList;
            }
            else
            {
                buttonStatementOfAccountReportPageListFirst.Enabled = false;
                buttonStatementOfAccountleReportPageListPrevious.Enabled = false;
                buttonStatementOfAccountReportPageListNext.Enabled = false;
                buttonStatementOfAccountReportPageListLast.Enabled = false;

                dataStatementOfAccountReportListSource.Clear();
                textBoxStatementOfAccountReportPageNumber.Text = "0 / 0";
            }
        }

        public void CreateStatementOfAccountReportDataGridView()
        {
            GetStatementOfAccountReportDataSource();
            dataGridViewStatementOfAccountReport.DataSource = dataStatementOfAccountReportListSource;
        }

        public void UpdateStatementOfAccountReportDataGridView()
        {
            CreateStatementOfAccountReportDataGridView();
        }

        private void buttonStatementOfAccountReportPageListFirst_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepAccountsReceivableStatementOfAccountReportEntity>(statementOfAccountReportList, 1, pageSize);
            dataStatementOfAccountReportListSource.DataSource = pageList;

            buttonStatementOfAccountReportPageListFirst.Enabled = false;
            buttonStatementOfAccountleReportPageListPrevious.Enabled = false;
            buttonStatementOfAccountReportPageListNext.Enabled = true;
            buttonStatementOfAccountReportPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxStatementOfAccountReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonStatementOfAccountReportPageListPrevious_Click(object sender, EventArgs e)
        {
            if (pageList.HasPreviousPage == true)
            {
                pageList = new PagedList<Entities.DgvRepAccountsReceivableStatementOfAccountReportEntity>(statementOfAccountReportList, --pageNumber, pageSize);
                dataStatementOfAccountReportListSource.DataSource = pageList;
            }

            buttonStatementOfAccountReportPageListNext.Enabled = true;
            buttonStatementOfAccountReportPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonStatementOfAccountReportPageListFirst.Enabled = false;
                buttonStatementOfAccountleReportPageListPrevious.Enabled = false;
            }

            textBoxStatementOfAccountReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonStatementOfAccountReportPageListNext_Click(object sender, EventArgs e)
        {
            if (pageList.HasNextPage == true)
            {
                pageList = new PagedList<Entities.DgvRepAccountsReceivableStatementOfAccountReportEntity>(statementOfAccountReportList, ++pageNumber, pageSize);
                dataStatementOfAccountReportListSource.DataSource = pageList;
            }

            buttonStatementOfAccountReportPageListFirst.Enabled = true;
            buttonStatementOfAccountleReportPageListPrevious.Enabled = true;

            if (pageNumber == pageList.PageCount)
            {
                buttonStatementOfAccountReportPageListNext.Enabled = false;
                buttonStatementOfAccountReportPageListLast.Enabled = false;
            }

            textBoxStatementOfAccountReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonStatementOfAccountReportPageListLast_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepAccountsReceivableStatementOfAccountReportEntity>(statementOfAccountReportList, pageList.PageCount, pageSize);
            dataStatementOfAccountReportListSource.DataSource = pageList;

            buttonStatementOfAccountReportPageListFirst.Enabled = true;
            buttonStatementOfAccountleReportPageListPrevious.Enabled = true;
            buttonStatementOfAccountReportPageListNext.Enabled = false;
            buttonStatementOfAccountReportPageListLast.Enabled = false;

            pageNumber = pageList.PageCount;
            textBoxStatementOfAccountReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
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
                         "SINumber",
                         "SIDate",
                         "ManualSINumber",
                         "Customer",
                         "Term",
                         "Amount",
                         "PaidAmount",
                         "MemoAmount",
                         "BalanceAmount"
                    };

                    csv.AppendLine(String.Join(",", header));

                    if (statementOfAccountReportList.Any())
                    {
                        foreach (var statementOfAccount in statementOfAccountReportList)
                        {
                            String[] data =
                            {
                                 statementOfAccount.ColumnReceivableStatementOfAccountReportListBranch.Replace(",", ""),
                                 statementOfAccount.ColumnReceivableStatementOfAccountReportListSINumber.Replace(",", ""),
                                 statementOfAccount.ColumnReceivableStatementOfAccountReportListSIDate.Replace(",", ""),
                                 statementOfAccount.ColumnReceivableStatementOfAccountReportListManualSINumber.Replace(",", ""),
                                 statementOfAccount.ColumnReceivableStatementOfAccountReportListCustomer.Replace(",", ""),
                                 statementOfAccount.ColumnReceivableStatementOfAccountReportListTerm.Replace(",", ""),
                                 statementOfAccount.ColumnReceivableStatementOfAccountReportListAmount.Replace(",", ""),
                                 statementOfAccount.ColumnReceivableStatementOfAccountReportListPaidAmount.Replace(",", ""),
                                 statementOfAccount.ColumnReceivableStatementOfAccountReportListMemoAmount.Replace(",", ""),
                                 statementOfAccount.ColumnReceivableStatementOfAccountReportListBalanceAmount.Replace(",", "")
                            };
                            csv.AppendLine(String.Join(",", data));
                        }
                    }

                    String executingUser = WindowsIdentity.GetCurrent().Name;

                    DirectorySecurity securityRules = new DirectorySecurity();
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.Read, AccessControlType.Allow));
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.FullControl, AccessControlType.Allow));

                    DirectoryInfo createDirectorySTCSV = Directory.CreateDirectory(folderBrowserDialogGenerateCSV.SelectedPath, securityRules);
                    File.WriteAllText(createDirectorySTCSV.FullName + "\\StatementOfAccountReport_" + Convert.ToDateTime(textBoxDateAsOf.Text).ToString("yyyyMMdd") + ".csv", csv.ToString(), Encoding.GetEncoding("iso-8859-1"));

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
                UpdateStatementOfAccountReportDataGridView();
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            String filter = textBoxItemListFilter.Text;
            new TrnSalesInvoiceDetailPrintPreviewForm(dateAsOf, companyId, branchId, customerId, filter);
        }
    }
}
