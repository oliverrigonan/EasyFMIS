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
    public partial class RepAccountsPayableReportDisbursementDetailReportForm : Form
    {
        public List<Entities.DgvRepAccountsPayableDisbursementDetailReportEntity> disbursementDetailReportList;
        public BindingSource dataDisbursementDetailReportListSource = new BindingSource();
        public PagedList<Entities.DgvRepAccountsPayableDisbursementDetailReportEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;

        DateTime DateStart;
        DateTime DateEnd;
        Int32 CompanyId;
        Int32 BranchId;


        public RepAccountsPayableReportDisbursementDetailReportForm(DateTime filterDateStart, DateTime filterDateEnd, Int32 filterCompanyId, String filterCompanyName, Int32 filterBranchId, String filterBranchName)
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

            CreateDisbursementDetailReportDataGridView();
        }

        public List<Entities.DgvRepAccountsPayableDisbursementDetailReportEntity> GetDisbursementDetailReportListData(DateTime filterDateStart, DateTime filterDateEnd, Int32 filterCompanyId, Int32 filterBranchId)
        {
            String filter = textBoxItemListFilter.Text;
            List<Entities.DgvRepAccountsPayableDisbursementDetailReportEntity> rowList = new List<Entities.DgvRepAccountsPayableDisbursementDetailReportEntity>();

            Controllers.RepAccountsPayableReportController repAccountsPayableReportController = new Controllers.RepAccountsPayableReportController();

            var disbursementDetailReportList = repAccountsPayableReportController.ListDisbursementDetailReport(filterDateStart, filterDateEnd, filterCompanyId, filterBranchId, filter);
            if (disbursementDetailReportList.Any())
            {
                var row = from d in disbursementDetailReportList
                          select new Entities.DgvRepAccountsPayableDisbursementDetailReportEntity
                          {
                              ColumnRepAccountsPayableDisbursementDetailReportListId = d.Id,
                              ColumnRepAccountsPayableDisbursementDetailReportListBranch = d.Branch,
                              ColumnRepAccountsPayableDisbursementDetailReportListCVNumber = d.CVNumber,
                              ColumnRepAccountsPayableDisbursementDetailReportListCVDate = d.CVDate,
                              ColumnRepAccountsPayableDisbursementDetailReportListManualCVNumber = d.ManualCVNumber,
                              ColumnRepAccountsPayableDisbursementDetailReportListSupplier = d.Supplier,
                              ColumnRepAccountsPayableDisbursementDetailReportListPayee = d.Payee,
                              ColumnRepAccountsPayableDisbursementDetailReportListPayType = d.PayType,
                              ColumnRepAccountsPayableDisbursementDetailReportListBank = d.Bank,
                              ColumnRepAccountsPayableDisbursementDetailReportListRemarks = d.Remarks,
                              ColumnRepAccountsPayableDisbursementDetailReportListCheckNumber = d.CheckNumber,
                              ColumnRepAccountsPayableDisbursementDetailReportListCheckDate = d.CheckDate,
                              ColumnRepAccountsPayableDisbursementDetailReportListIsCrossCheck = d.IsCrossCheck == true ? "Yes" : "",
                              ColumnRepAccountsPayableDisbursementDetailReportListIsClear = d.IsClear == true ? "Yes" : "",
                              ColumnRepAccountsPayableDisbursementDetailReportListPreparedBy = d.PreparedBy,
                              ColumnRepAccountsPayableDisbursementDetailReportListCheckedBy = d.CheckedBy,
                              ColumnRepAccountsPayableDisbursementDetailReportListApprovedBy = d.ApprovedBy,
                              ColumnRepAccountsPayableDisbursementDetailReportListArticleGroup = d.ArticleGroup,
                              ColumnRepAccountsPayableDisbursementDetailReportListRRNumber = d.RRNumber,
                              ColumnRepAccountsPayableDisbursementDetailReportListAmount = d.Amount.ToString("#,##0.00"),
                              ColumnRepAccountsPayableDisbursementDetailReportListParticulars = d.Particulars
                          };

                rowList = row.ToList();

                Decimal totalAmount = disbursementDetailReportList.Sum(d => d.Amount);

                Entities.DgvRepAccountsPayableDisbursementDetailReportEntity disbursementTotals = new Entities.DgvRepAccountsPayableDisbursementDetailReportEntity()
                {
                    ColumnRepAccountsPayableDisbursementDetailReportListId = 0,
                    ColumnRepAccountsPayableDisbursementDetailReportListBranch = "Total",
                    ColumnRepAccountsPayableDisbursementDetailReportListCVNumber = "",
                    ColumnRepAccountsPayableDisbursementDetailReportListCVDate = "",
                    ColumnRepAccountsPayableDisbursementDetailReportListManualCVNumber = "",
                    ColumnRepAccountsPayableDisbursementDetailReportListSupplier = "",
                    ColumnRepAccountsPayableDisbursementDetailReportListPayee = "",
                    ColumnRepAccountsPayableDisbursementDetailReportListPayType = "",
                    ColumnRepAccountsPayableDisbursementDetailReportListBank = "",
                    ColumnRepAccountsPayableDisbursementDetailReportListRemarks = "",
                    ColumnRepAccountsPayableDisbursementDetailReportListCheckNumber = "",
                    ColumnRepAccountsPayableDisbursementDetailReportListCheckDate = "",
                    ColumnRepAccountsPayableDisbursementDetailReportListIsCrossCheck = "",
                    ColumnRepAccountsPayableDisbursementDetailReportListIsClear = "",
                    ColumnRepAccountsPayableDisbursementDetailReportListPreparedBy = "",
                    ColumnRepAccountsPayableDisbursementDetailReportListCheckedBy = "",
                    ColumnRepAccountsPayableDisbursementDetailReportListApprovedBy = "",
                    ColumnRepAccountsPayableDisbursementDetailReportListArticleGroup = "",
                    ColumnRepAccountsPayableDisbursementDetailReportListRRNumber = "",
                    ColumnRepAccountsPayableDisbursementDetailReportListAmount = totalAmount.ToString("#,##0.00"),
                    ColumnRepAccountsPayableDisbursementDetailReportListParticulars = ""
                };

                rowList.Add(disbursementTotals);

            }
            return rowList;
        }

        public void GetDisbursementDetailReportDataSource()
        {
            disbursementDetailReportList = GetDisbursementDetailReportListData(DateStart, DateEnd, CompanyId, BranchId);
            if (disbursementDetailReportList.Any())
            {
                pageNumber = 1;
                pageList = new PagedList<Entities.DgvRepAccountsPayableDisbursementDetailReportEntity>(disbursementDetailReportList, pageNumber, pageSize);

                if (pageList.PageCount == 1)
                {
                    buttonDisbursementDetailReportPageListFirst.Enabled = false;
                    buttonDisbursementDetailReportPageListPrevious.Enabled = false;
                    buttonDisbursementDetailReportPageListNext.Enabled = false;
                    buttonDisbursementDetailReportPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonDisbursementDetailReportPageListFirst.Enabled = false;
                    buttonDisbursementDetailReportPageListPrevious.Enabled = false;
                    buttonDisbursementDetailReportPageListNext.Enabled = true;
                    buttonDisbursementDetailReportPageListLast.Enabled = true;
                }
                else if (pageNumber == pageList.PageCount)
                {
                    buttonDisbursementDetailReportPageListFirst.Enabled = true;
                    buttonDisbursementDetailReportPageListPrevious.Enabled = true;
                    buttonDisbursementDetailReportPageListNext.Enabled = false;
                    buttonDisbursementDetailReportPageListLast.Enabled = false;
                }
                else
                {
                    buttonDisbursementDetailReportPageListFirst.Enabled = true;
                    buttonDisbursementDetailReportPageListPrevious.Enabled = true;
                    buttonDisbursementDetailReportPageListNext.Enabled = true;
                    buttonDisbursementDetailReportPageListLast.Enabled = true;
                }

                buttonDisbursementDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
                dataDisbursementDetailReportListSource.DataSource = pageList;
            }
            else
            {
                buttonDisbursementDetailReportPageListFirst.Enabled = false;
                buttonDisbursementDetailReportPageListPrevious.Enabled = false;
                buttonDisbursementDetailReportPageListNext.Enabled = false;
                buttonDisbursementDetailReportPageListLast.Enabled = false;

                dataDisbursementDetailReportListSource.Clear();
                buttonDisbursementDetailReportPageNumber.Text = "0 / 0";
            }
        }

        public void CreateDisbursementDetailReportDataGridView()
        {
            GetDisbursementDetailReportDataSource();
            dataGridViewDisbursementDetailReport.DataSource = dataDisbursementDetailReportListSource;
        }

        public void UpdateDisbursementDetailReportDataGridView()
        {
            CreateDisbursementDetailReportDataGridView();
        }

        private void buttonDisbursementDetailReportPageListFirst_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepAccountsPayableDisbursementDetailReportEntity>(disbursementDetailReportList, 1, pageSize);
            dataDisbursementDetailReportListSource.DataSource = pageList;

            buttonDisbursementDetailReportPageListFirst.Enabled = false;
            buttonDisbursementDetailReportPageListPrevious.Enabled = false;
            buttonDisbursementDetailReportPageListNext.Enabled = true;
            buttonDisbursementDetailReportPageListLast.Enabled = true;

            pageNumber = 1;
            buttonDisbursementDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonDisbursementDetailReportPageListPrevious_Click(object sender, EventArgs e)
        {
            if (pageList.HasPreviousPage == true)
            {
                pageList = new PagedList<Entities.DgvRepAccountsPayableDisbursementDetailReportEntity>(disbursementDetailReportList, --pageNumber, pageSize);
                dataDisbursementDetailReportListSource.DataSource = pageList;
            }

            buttonDisbursementDetailReportPageListNext.Enabled = true;
            buttonDisbursementDetailReportPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonDisbursementDetailReportPageListFirst.Enabled = false;
                buttonDisbursementDetailReportPageListPrevious.Enabled = false;
            }

            buttonDisbursementDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonDisbursementDetailReportPageListNext_Click(object sender, EventArgs e)
        {
            if (pageList.HasNextPage == true)
            {
                pageList = new PagedList<Entities.DgvRepAccountsPayableDisbursementDetailReportEntity>(disbursementDetailReportList, ++pageNumber, pageSize);
                dataDisbursementDetailReportListSource.DataSource = pageList;
            }

            buttonDisbursementDetailReportPageListFirst.Enabled = true;
            buttonDisbursementDetailReportPageListPrevious.Enabled = true;

            if (pageNumber == pageList.PageCount)
            {
                buttonDisbursementDetailReportPageListNext.Enabled = false;
                buttonDisbursementDetailReportPageListLast.Enabled = false;
            }

            buttonDisbursementDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonDisbursementDetailReportPageListLast_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepAccountsPayableDisbursementDetailReportEntity>(disbursementDetailReportList, pageList.PageCount, pageSize);
            dataDisbursementDetailReportListSource.DataSource = pageList;

            buttonDisbursementDetailReportPageListFirst.Enabled = true;
            buttonDisbursementDetailReportPageListPrevious.Enabled = true;
            buttonDisbursementDetailReportPageListNext.Enabled = false;
            buttonDisbursementDetailReportPageListLast.Enabled = false;

            pageNumber = pageList.PageCount;
            buttonDisbursementDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
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
                        "ColumnRepAccountsPayableDisbursementDetailReportListBranch",
                        "ColumnRepAccountsPayableDisbursementDetailReportListCVNumber",
                        "ColumnRepAccountsPayableDisbursementDetailReportListCVDate",
                        "ColumnRepAccountsPayableDisbursementDetailReportListManualCVNumber",
                        "ColumnRepAccountsPayableDisbursementDetailReportListSupplier",
                        "ColumnRepAccountsPayableDisbursementDetailReportListPayee",
                        "ColumnRepAccountsPayableDisbursementDetailReportListPayType",
                        "ColumnRepAccountsPayableDisbursementDetailReportListBank",
                        "ColumnRepAccountsPayableDisbursementDetailReportListRemarks",
                        "ColumnRepAccountsPayableDisbursementDetailReportListCheckNumber",
                        "ColumnRepAccountsPayableDisbursementDetailReportListCheckDate",
                        "ColumnRepAccountsPayableDisbursementDetailReportListIsCrossCheck",
                        "ColumnRepAccountsPayableDisbursementDetailReportListIsClear",
                        "ColumnRepAccountsPayableDisbursementDetailReportListPreparedBy",
                        "ColumnRepAccountsPayableDisbursementDetailReportListCheckedBy",
                        "ColumnRepAccountsPayableDisbursementDetailReportListApprovedBy",
                        "ColumnRepAccountsPayableDisbursementDetailReportListArticleGroup",
                        "ColumnRepAccountsPayableDisbursementDetailReportListRRNumber",
                        "ColumnRepAccountsPayableDisbursementDetailReportListAmount",
                        "ColumnRepAccountsPayableDisbursementDetailReportListParticulars",
                    };

                    csv.AppendLine(String.Join(",", header));

                    if (disbursementDetailReportList.Any())
                    {
                        foreach (var disbursementDetailReport in disbursementDetailReportList)
                        {
                            String[] data =
                            {
                                disbursementDetailReport.ColumnRepAccountsPayableDisbursementDetailReportListBranch.Replace(",", ""),
                                disbursementDetailReport.ColumnRepAccountsPayableDisbursementDetailReportListCVNumber.Replace(",", ""),
                                disbursementDetailReport.ColumnRepAccountsPayableDisbursementDetailReportListCVDate.Replace(",", ""),
                                disbursementDetailReport.ColumnRepAccountsPayableDisbursementDetailReportListManualCVNumber.Replace(",", ""),
                                disbursementDetailReport.ColumnRepAccountsPayableDisbursementDetailReportListSupplier.Replace(",", ""),
                                disbursementDetailReport.ColumnRepAccountsPayableDisbursementDetailReportListPayee.Replace(",", ""),
                                disbursementDetailReport.ColumnRepAccountsPayableDisbursementDetailReportListPayType.Replace(",", ""),
                                disbursementDetailReport.ColumnRepAccountsPayableDisbursementDetailReportListBank.Replace(",", ""),
                                disbursementDetailReport.ColumnRepAccountsPayableDisbursementDetailReportListRemarks.Replace(",", ""),
                                disbursementDetailReport.ColumnRepAccountsPayableDisbursementDetailReportListCheckNumber.Replace(",", ""),
                                disbursementDetailReport.ColumnRepAccountsPayableDisbursementDetailReportListCheckDate.Replace(",", ""),
                                disbursementDetailReport.ColumnRepAccountsPayableDisbursementDetailReportListIsCrossCheck.ToString(),
                                disbursementDetailReport.ColumnRepAccountsPayableDisbursementDetailReportListIsClear.ToString(),
                                disbursementDetailReport.ColumnRepAccountsPayableDisbursementDetailReportListPreparedBy.Replace(",", ""),
                                disbursementDetailReport.ColumnRepAccountsPayableDisbursementDetailReportListCheckedBy.Replace(",", ""),
                                disbursementDetailReport.ColumnRepAccountsPayableDisbursementDetailReportListApprovedBy.Replace(",", ""),
                                disbursementDetailReport.ColumnRepAccountsPayableDisbursementDetailReportListArticleGroup.Replace(",", ""),
                                disbursementDetailReport.ColumnRepAccountsPayableDisbursementDetailReportListRRNumber.Replace(",", ""),
                                disbursementDetailReport.ColumnRepAccountsPayableDisbursementDetailReportListAmount.Replace(",", ""),
                                disbursementDetailReport.ColumnRepAccountsPayableDisbursementDetailReportListParticulars.Replace(",", ""),
                            };

                            csv.AppendLine(String.Join(",", data));
                        }
                    }

                    String executingUser = WindowsIdentity.GetCurrent().Name;

                    DirectorySecurity securityRules = new DirectorySecurity();
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.Read, AccessControlType.Allow));
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.FullControl, AccessControlType.Allow));

                    DirectoryInfo createDirectorySTCSV = Directory.CreateDirectory(folderBrowserDialogGenerateCSV.SelectedPath, securityRules);
                    File.WriteAllText(createDirectorySTCSV.FullName + "\\DisbursementDetailReportPerPersonReport_" + Convert.ToDateTime(textBoxStartDate.Text).ToString("yyyyMMdd") + ".csv", csv.ToString(), Encoding.GetEncoding("iso-8859-1"));

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
                UpdateDisbursementDetailReportDataGridView();
            }
        }
    }
}
