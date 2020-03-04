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
    public partial class RepAccountsReceivableReportCollectionDetailReportForm : Form
    {
        public List<Entities.DgvRepAccountsReceivableCollectionDetailReportEntity> collectionDetailReportList;
        public BindingSource dataCollectionDetailReportListSource = new BindingSource();
        public PagedList<Entities.DgvRepAccountsReceivableCollectionDetailReportEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;

        DateTime DateStart;
        DateTime DateEnd;
        Int32 CompanyId;
        Int32 BranchId;


        public RepAccountsReceivableReportCollectionDetailReportForm(DateTime filterDateStart, DateTime filterDateEnd, Int32 filterCompanyId, String filterCompanyName, Int32 filterBranchId, String filterBranchName)
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

            CreateCollectionDetailReportDataGridView();
        }

        public List<Entities.DgvRepAccountsReceivableCollectionDetailReportEntity> GetCollectionDetailReportListData(DateTime filterDateStart, DateTime filterDateEnd, Int32 filterCompanyId, Int32 filterBranchId)
        {
            String filter = textBoxItemListFilter.Text;
            List<Entities.DgvRepAccountsReceivableCollectionDetailReportEntity> rowList = new List<Entities.DgvRepAccountsReceivableCollectionDetailReportEntity>();

            Controllers.RepAccountsReceivableReportController repAccountsPayableReportController = new Controllers.RepAccountsReceivableReportController();

            var collectionDetailReportList = repAccountsPayableReportController.ListCollectionDetailReport(filterDateStart, filterDateEnd, filterCompanyId, filterBranchId, filter);
            if (collectionDetailReportList.Any())
            {
                var row = from d in collectionDetailReportList
                          select new Entities.DgvRepAccountsReceivableCollectionDetailReportEntity
                          {
                              ColumnCollectionDetailReportListBranch = d.Branch,
                              ColumnCollectionDetailReportListORNumber = d.ORNumber,
                              ColumnCollectionDetailReportListORDate = d.ORDate,
                              ColumnCollectionDetailReportListManualORNumber = d.ManualORNumber,
                              ColumnCollectionDetailReportListCustomer = d.Customer,
                              ColumnCollectionDetailReportListRemarks = d.Remarks,
                              ColumnCollectionDetailReportListPreparedBy = d.PreparedBy,
                              ColumnCollectionDetailReportListCheckedBy = d.CheckedBy,
                              ColumnCollectionDetailReportListApprovedBy = d.ApprovedBy,
                              ColumnCollectionDetailReportListArticleGroup = d.ArticleGroup,
                              ColumnCollectionDetailReportListSINumber = d.SINumber,
                              ColumnCollectionDetailReportListAmount = d.Amount.ToString("#,##0.00"),
                              ColumnCollectionDetailReportListPayType = d.PayType,
                              ColumnCollectionDetailReportListCheckNumber = d.CheckNumber,
                              ColumnCollectionDetailReportListCheckDate = d.CheckDate.ToShortDateString(),
                              ColumnCollectionDetailReportListCheckBank = d.CheckBank,
                              ColumnCollectionDetailReportListCreditCardVerificationCode = d.CreditCardVerificationCode,
                              ColumnCollectionDetailReportListCreditCardNumber = d.CreditCardNumber,
                              ColumnCollectionDetailReportListCreditCardType = d.CreditCardType,
                              ColumnCollectionDetailReportListCreditCardBank = d.CreditCardBank,
                              ColumnCollectionDetailReportListCreditCardReferenceNumber = d.CreditCardReferenceNumber,
                              ColumnCollectionDetailReportListCreditCardHolderName = d.CreditCardHolderName,
                              ColumnCollectionDetailReportListCreditCardExpiry = d.CreditCardExpiry,
                              ColumnCollectionDetailReportListGiftCertificateNumber = d.GiftCertificateNumber,
                              ColumnCollectionDetailReportListOtherInformation = d.OtherInformation
                          };

                rowList = row.ToList();

                Decimal totalAmount = collectionDetailReportList.Sum(d => d.Amount);

                Entities.DgvRepAccountsReceivableCollectionDetailReportEntity totalCollectionDetailReport = new Entities.DgvRepAccountsReceivableCollectionDetailReportEntity()
                {
                    ColumnCollectionDetailReportListBranch = "Total",
                    ColumnCollectionDetailReportListORNumber = "",
                    ColumnCollectionDetailReportListORDate = "",
                    ColumnCollectionDetailReportListManualORNumber = "",
                    ColumnCollectionDetailReportListCustomer = "",
                    ColumnCollectionDetailReportListRemarks = "",
                    ColumnCollectionDetailReportListPreparedBy = "",
                    ColumnCollectionDetailReportListCheckedBy = "",
                    ColumnCollectionDetailReportListApprovedBy = "",
                    ColumnCollectionDetailReportListArticleGroup = "",
                    ColumnCollectionDetailReportListSINumber = "",
                    ColumnCollectionDetailReportListAmount = totalAmount.ToString("#,##0.00"),
                    ColumnCollectionDetailReportListPayType = "",
                    ColumnCollectionDetailReportListCheckNumber = "",
                    ColumnCollectionDetailReportListCheckDate = "",
                    ColumnCollectionDetailReportListCheckBank = "",
                    ColumnCollectionDetailReportListCreditCardVerificationCode = "",
                    ColumnCollectionDetailReportListCreditCardNumber = "",
                    ColumnCollectionDetailReportListCreditCardType = "",
                    ColumnCollectionDetailReportListCreditCardBank = "",
                    ColumnCollectionDetailReportListCreditCardReferenceNumber = "",
                    ColumnCollectionDetailReportListCreditCardHolderName = "",
                    ColumnCollectionDetailReportListCreditCardExpiry = "",
                    ColumnCollectionDetailReportListGiftCertificateNumber = "",
                    ColumnCollectionDetailReportListOtherInformation = ""
                };

                rowList.Add(totalCollectionDetailReport);
            }
            return rowList;
        }

        public void GetCollectionDetailReportDataSource()
        {
            collectionDetailReportList = GetCollectionDetailReportListData(DateStart, DateEnd, CompanyId, BranchId);
            if (collectionDetailReportList.Any())
            {
                pageNumber = 1;
                pageList = new PagedList<Entities.DgvRepAccountsReceivableCollectionDetailReportEntity>(collectionDetailReportList, pageNumber, pageSize);

                if (pageList.PageCount == 1)
                {
                    buttonCollectionDetailReportPageListFirst.Enabled = false;
                    buttonCollectionDetailReportPageListPrevious.Enabled = false;
                    buttonCollectionDetailReportPageListNext.Enabled = false;
                    buttonCollectionDetailReportPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonCollectionDetailReportPageListFirst.Enabled = false;
                    buttonCollectionDetailReportPageListPrevious.Enabled = false;
                    buttonCollectionDetailReportPageListNext.Enabled = true;
                    buttonCollectionDetailReportPageListLast.Enabled = true;
                }
                else if (pageNumber == pageList.PageCount)
                {
                    buttonCollectionDetailReportPageListFirst.Enabled = true;
                    buttonCollectionDetailReportPageListPrevious.Enabled = true;
                    buttonCollectionDetailReportPageListNext.Enabled = false;
                    buttonCollectionDetailReportPageListLast.Enabled = false;
                }
                else
                {
                    buttonCollectionDetailReportPageListFirst.Enabled = true;
                    buttonCollectionDetailReportPageListPrevious.Enabled = true;
                    buttonCollectionDetailReportPageListNext.Enabled = true;
                    buttonCollectionDetailReportPageListLast.Enabled = true;
                }

                buttonCollectionDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
                dataCollectionDetailReportListSource.DataSource = pageList;
            }
            else
            {
                buttonCollectionDetailReportPageListFirst.Enabled = false;
                buttonCollectionDetailReportPageListPrevious.Enabled = false;
                buttonCollectionDetailReportPageListNext.Enabled = false;
                buttonCollectionDetailReportPageListLast.Enabled = false;

                dataCollectionDetailReportListSource.Clear();
                buttonCollectionDetailReportPageNumber.Text = "0 / 0";
            }
        }

        public void CreateCollectionDetailReportDataGridView()
        {
            GetCollectionDetailReportDataSource();
            dataGridViewCollectionDetailReport.DataSource = dataCollectionDetailReportListSource;
        }

        public void UpdateCollectionDetailReportDataGridView()
        {
            CreateCollectionDetailReportDataGridView();
        }

        private void buttonCollectionDetailReportPageListFirst_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepAccountsReceivableCollectionDetailReportEntity>(collectionDetailReportList, 1, pageSize);
            dataCollectionDetailReportListSource.DataSource = pageList;

            buttonCollectionDetailReportPageListFirst.Enabled = false;
            buttonCollectionDetailReportPageListPrevious.Enabled = false;
            buttonCollectionDetailReportPageListNext.Enabled = true;
            buttonCollectionDetailReportPageListLast.Enabled = true;

            pageNumber = 1;
            buttonCollectionDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonCollectionDetailReportPageListPrevious_Click(object sender, EventArgs e)
        {
            if (pageList.HasPreviousPage == true)
            {
                pageList = new PagedList<Entities.DgvRepAccountsReceivableCollectionDetailReportEntity>(collectionDetailReportList, --pageNumber, pageSize);
                dataCollectionDetailReportListSource.DataSource = pageList;
            }

            buttonCollectionDetailReportPageListNext.Enabled = true;
            buttonCollectionDetailReportPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonCollectionDetailReportPageListFirst.Enabled = false;
                buttonCollectionDetailReportPageListPrevious.Enabled = false;
            }

            buttonCollectionDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonCollectionDetailReportPageListNext_Click(object sender, EventArgs e)
        {
            if (pageList.HasNextPage == true)
            {
                pageList = new PagedList<Entities.DgvRepAccountsReceivableCollectionDetailReportEntity>(collectionDetailReportList, ++pageNumber, pageSize);
                dataCollectionDetailReportListSource.DataSource = pageList;
            }

            buttonCollectionDetailReportPageListFirst.Enabled = true;
            buttonCollectionDetailReportPageListPrevious.Enabled = true;

            if (pageNumber == pageList.PageCount)
            {
                buttonCollectionDetailReportPageListNext.Enabled = false;
                buttonCollectionDetailReportPageListLast.Enabled = false;
            }

            buttonCollectionDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonCollectionDetailReportPageListLast_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepAccountsReceivableCollectionDetailReportEntity>(collectionDetailReportList, pageList.PageCount, pageSize);
            dataCollectionDetailReportListSource.DataSource = pageList;

            buttonCollectionDetailReportPageListFirst.Enabled = true;
            buttonCollectionDetailReportPageListPrevious.Enabled = true;
            buttonCollectionDetailReportPageListNext.Enabled = false;
            buttonCollectionDetailReportPageListLast.Enabled = false;

            pageNumber = pageList.PageCount;
            buttonCollectionDetailReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
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
                        "ColumnCollectionDetailReportListBranch",
                        "ColumnCollectionDetailReportListORNumber",
                        "ColumnCollectionDetailReportListORDate",
                        "ColumnCollectionDetailReportListManualORNumber",
                        "ColumnCollectionDetailReportListCustomer",
                        "ColumnCollectionDetailReportListRemarks",
                        "ColumnCollectionDetailReportListPreparedBy",
                        "ColumnCollectionDetailReportListCheckedBy",
                        "ColumnCollectionDetailReportListApprovedBy",
                        "ColumnCollectionDetailReportListArticleGroup",
                        "ColumnCollectionDetailReportListSINumber",
                        "ColumnCollectionDetailReportListAmount",
                        "ColumnCollectionDetailReportListPayType",
                        "ColumnCollectionDetailReportListCheckNumber",
                        "ColumnCollectionDetailReportListCheckDate",
                        "ColumnCollectionDetailReportListCheckBank",
                        "ColumnCollectionDetailReportListCreditCardVerificationCode",
                        "ColumnCollectionDetailReportListCreditCardNumber",
                        "ColumnCollectionDetailReportListCreditCardType",
                        "ColumnCollectionDetailReportListCreditCardBank",
                        "ColumnCollectionDetailReportListCreditCardReferenceNumber",
                        "ColumnCollectionDetailReportListCreditCardHolderName",
                        "ColumnCollectionDetailReportListCreditCardExpiry",
                        "ColumnCollectionDetailReportListGiftCertificateNumber",
                        "ColumnCollectionDetailReportListOtherInformation"
                    };

                    csv.AppendLine(String.Join(",", header));

                    if (collectionDetailReportList.Any())
                    {
                        foreach (var collectionDetailReport in collectionDetailReportList)
                        {
                            String[] data =
                            {
                                collectionDetailReport.ColumnCollectionDetailReportListBranch.Replace(",", ""),
                                collectionDetailReport.ColumnCollectionDetailReportListORNumber.Replace(",", ""),
                                collectionDetailReport.ColumnCollectionDetailReportListORDate.Replace(",", ""),
                                collectionDetailReport.ColumnCollectionDetailReportListManualORNumber.Replace(",", ""),
                                collectionDetailReport.ColumnCollectionDetailReportListCustomer.Replace(",", ""),
                                collectionDetailReport.ColumnCollectionDetailReportListRemarks.Replace(",", ""),
                                collectionDetailReport.ColumnCollectionDetailReportListPreparedBy.Replace(",", ""),
                                collectionDetailReport.ColumnCollectionDetailReportListCheckedBy.Replace(",", ""),
                                collectionDetailReport.ColumnCollectionDetailReportListApprovedBy.Replace(",", ""),
                                collectionDetailReport.ColumnCollectionDetailReportListArticleGroup.Replace(",", ""),
                                collectionDetailReport.ColumnCollectionDetailReportListSINumber.Replace(",", ""),
                                collectionDetailReport.ColumnCollectionDetailReportListAmount.Replace(",", ""),
                                collectionDetailReport.ColumnCollectionDetailReportListPayType.Replace(",", ""),
                                collectionDetailReport.ColumnCollectionDetailReportListCheckNumber.Replace(",", ""),
                                collectionDetailReport.ColumnCollectionDetailReportListCheckDate.Replace(",", ""),
                                collectionDetailReport.ColumnCollectionDetailReportListCheckBank.Replace(",", ""),
                                collectionDetailReport.ColumnCollectionDetailReportListCreditCardVerificationCode.Replace(",", ""),
                                collectionDetailReport.ColumnCollectionDetailReportListCreditCardNumber.Replace(",", ""),
                                collectionDetailReport.ColumnCollectionDetailReportListCreditCardType.Replace(",", ""),
                                collectionDetailReport.ColumnCollectionDetailReportListCreditCardBank.Replace(",", ""),
                                collectionDetailReport.ColumnCollectionDetailReportListCreditCardReferenceNumber.Replace(",", ""),
                                collectionDetailReport.ColumnCollectionDetailReportListCreditCardHolderName.Replace(",", ""),
                                collectionDetailReport.ColumnCollectionDetailReportListCreditCardExpiry.Replace(",", ""),
                                collectionDetailReport.ColumnCollectionDetailReportListGiftCertificateNumber.Replace(",", ""),
                                collectionDetailReport.ColumnCollectionDetailReportListOtherInformation.Replace(",", ""),
                            };

                            csv.AppendLine(String.Join(",", data));
                        }
                    }

                    String executingUser = WindowsIdentity.GetCurrent().Name;

                    DirectorySecurity securityRules = new DirectorySecurity();
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.Read, AccessControlType.Allow));
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.FullControl, AccessControlType.Allow));

                    DirectoryInfo createDirectorySTCSV = Directory.CreateDirectory(folderBrowserDialogGenerateCSV.SelectedPath, securityRules);
                    File.WriteAllText(createDirectorySTCSV.FullName + "\\CollectionDetailReportPerPersonReport_" + Convert.ToDateTime(textBoxStartDate.Text).ToString("yyyyMMdd") + ".csv", csv.ToString(), Encoding.GetEncoding("iso-8859-1"));

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
                UpdateCollectionDetailReportDataGridView();
            }
        }
    }
}
