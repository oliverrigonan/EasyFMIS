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
    public partial class RepAccountPayableReportPurchaseOrderDetailReportForm : Form
    {
        public List<Entities.DgvRepAccountsPayablePurchaseOrderDetailReportEntity> purchaseOrderDetailReportList;
        public BindingSource dataPurchaseOrderReportListSource = new BindingSource();
        public PagedList<Entities.DgvRepAccountsPayablePurchaseOrderDetailReportEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;

        DateTime DateStart;
        DateTime DateEnd;
        Int32 CompanyId;
        Int32 BranchId;
        Int32 SoldById;

        public RepAccountPayableReportPurchaseOrderDetailReportForm(DateTime filterDateStart, DateTime filterDateEnd, Int32 filterCompanyId, String filterCompanyName, Int32 filterBranchId, String filterBranchName)
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

            CreatePurchaseOrderDetailReportDataGridView();
        }

        public List<Entities.DgvRepAccountsPayablePurchaseOrderDetailReportEntity> GetPurchaserOrderDetailReportListData(DateTime filterDateStart, DateTime filterDateEnd, Int32 filterCompanyId, Int32 filterBranchId, Int32 filterSoldById)
        {
            String filter = textBoxItemListFilter.Text;
            List<Entities.DgvRepAccountsPayablePurchaseOrderDetailReportEntity> rowList = new List<Entities.DgvRepAccountsPayablePurchaseOrderDetailReportEntity>();

            Controllers.RepAccountsPayableReportController repAccountsPayableReportController = new Controllers.RepAccountsPayableReportController();

            var purchaseOrderDetailReportList = repAccountsPayableReportController.ListPurchaseOrderDetailReport(filterDateStart, filterDateEnd, filterCompanyId, filterBranchId, filter);
            if (purchaseOrderDetailReportList.Any())
            {
                var row = from d in purchaseOrderDetailReportList
                          select new Entities.DgvRepAccountsPayablePurchaseOrderDetailReportEntity
                          {
                              ColumnPurchaseOrderDetailReportListBranch = d.Branch,
                              ColumnPurchaseOrderDetailReportListPONumber = d.PONumber,
                              ColumnPurchaseOrderDetailReportListPODate = d.PODate.ToShortDateString(),
                              ColumnPurchaseOrderDetailReportListManualPONumber = d.ManualPONumber,
                              ColumnPurchaseOrderDetailReportListSupplier = d.Supplier,
                              ColumnPurchaseOrderDetailReportListTerm = d.Term,
                              ColumnPurchaseOrderDetailReportListDateNeeded = d.DateNeeded.ToShortDateString(),
                              ColumnPurchaseOrderDetailReportListRemarks = d.Remarks,
                              ColumnPurchaseOrderDetailReportListIsClose = d.IsClose == true ? "Yes" : "",
                              ColumnPurchaseOrderDetailReportListRequestedBy = d.RequestedBy,
                              ColumnPurchaseOrderDetailReportListPreparedBy = d.PreparedBy,
                              ColumnPurchaseOrderDetailReportListCheckedBy = d.CheckedBy,
                              ColumnPurchaseOrderDetailReportListApprovedBy = d.ApprovedBy,
                              ColumnPurchaseOrderDetailReportListItemCode = d.ItemCode,
                              ColumnPurchaseOrderDetailReportListItemDescription = d.ItemDescription,
                              ColumnPurchaseOrderDetailReportListUnit = d.Unit,
                              ColumnPurchaseOrderDetailReportListQuantity = d.Quantity.ToString("#,##0.00"),
                              ColumnPurchaseOrderDetailReportListCost = d.Cost.ToString("#,##0.00"),
                              ColumnPurchaseOrderDetailReportListAmount = d.Amount.ToString("#,##0.00"),
                              ColumnPurchaseOrderDetailReportListBaseQuantity = d.BaseQuantity.ToString("#,##0.00"),
                              ColumnPurchaseOrderDetailReportListBaseCost = d.BaseCost.ToString("#,##0.00")
                          };

                rowList = row.ToList();

                Decimal totalAmount = purchaseOrderDetailReportList.Sum(d => d.Amount);

                Entities.DgvRepAccountsPayablePurchaseOrderDetailReportEntity totalAmounts = new Entities.DgvRepAccountsPayablePurchaseOrderDetailReportEntity()
                {
                    ColumnPurchaseOrderDetailReportListBranch = "Total",
                    ColumnPurchaseOrderDetailReportListPONumber = "",
                    ColumnPurchaseOrderDetailReportListPODate = "",
                    ColumnPurchaseOrderDetailReportListManualPONumber = "",
                    ColumnPurchaseOrderDetailReportListSupplier = "",
                    ColumnPurchaseOrderDetailReportListTerm = "",
                    ColumnPurchaseOrderDetailReportListDateNeeded = "",
                    ColumnPurchaseOrderDetailReportListRemarks = "",
                    ColumnPurchaseOrderDetailReportListIsClose = "",
                    ColumnPurchaseOrderDetailReportListRequestedBy = "",
                    ColumnPurchaseOrderDetailReportListPreparedBy = "",
                    ColumnPurchaseOrderDetailReportListCheckedBy = "",
                    ColumnPurchaseOrderDetailReportListApprovedBy = "",
                    ColumnPurchaseOrderDetailReportListItemCode = "",
                    ColumnPurchaseOrderDetailReportListItemDescription = "",
                    ColumnPurchaseOrderDetailReportListUnit = "",
                    ColumnPurchaseOrderDetailReportListQuantity = "",
                    ColumnPurchaseOrderDetailReportListCost = "",
                    ColumnPurchaseOrderDetailReportListAmount = totalAmount.ToString("#,##0.00"),
                    ColumnPurchaseOrderDetailReportListBaseQuantity = "",
                    ColumnPurchaseOrderDetailReportListBaseCost = ""
                };

                rowList.Add(totalAmounts);

            }
            return rowList;
        }

        public void GetPurchaseOrderDetailReportDataSource()
        {
            purchaseOrderDetailReportList = GetPurchaserOrderDetailReportListData(DateStart, DateEnd, CompanyId, BranchId, SoldById);
            if (purchaseOrderDetailReportList.Any())
            {
                pageNumber = 1;
                pageList = new PagedList<Entities.DgvRepAccountsPayablePurchaseOrderDetailReportEntity>(purchaseOrderDetailReportList, pageNumber, pageSize);

                if (pageList.PageCount == 1)
                {
                    buttonPurchaseOrderReportPageListFirst.Enabled = false;
                    buttonPurchaseOrderReportPageListPrevious.Enabled = false;
                    buttonPurchaseOrderReportPageListNext.Enabled = false;
                    buttonPurchaseOrderReportPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonPurchaseOrderReportPageListFirst.Enabled = false;
                    buttonPurchaseOrderReportPageListPrevious.Enabled = false;
                    buttonPurchaseOrderReportPageListNext.Enabled = true;
                    buttonPurchaseOrderReportPageListLast.Enabled = true;
                }
                else if (pageNumber == pageList.PageCount)
                {
                    buttonPurchaseOrderReportPageListFirst.Enabled = true;
                    buttonPurchaseOrderReportPageListPrevious.Enabled = true;
                    buttonPurchaseOrderReportPageListNext.Enabled = false;
                    buttonPurchaseOrderReportPageListLast.Enabled = false;
                }
                else
                {
                    buttonPurchaseOrderReportPageListFirst.Enabled = true;
                    buttonPurchaseOrderReportPageListPrevious.Enabled = true;
                    buttonPurchaseOrderReportPageListNext.Enabled = true;
                    buttonPurchaseOrderReportPageListLast.Enabled = true;
                }

                buttonPurchaseOrderReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
                dataPurchaseOrderReportListSource.DataSource = pageList;
            }
            else
            {
                buttonPurchaseOrderReportPageListFirst.Enabled = false;
                buttonPurchaseOrderReportPageListPrevious.Enabled = false;
                buttonPurchaseOrderReportPageListNext.Enabled = false;
                buttonPurchaseOrderReportPageListLast.Enabled = false;

                dataPurchaseOrderReportListSource.Clear();
                buttonPurchaseOrderReportPageNumber.Text = "0 / 0";
            }
        }

        public void UpdatePurchaseOrderDetailReportDataGridView()
        {
            CreatePurchaseOrderDetailReportDataGridView();
        }

        public void CreatePurchaseOrderDetailReportDataGridView()
        {
            GetPurchaseOrderDetailReportDataSource();
            dataGridViewAccountsPayablePurchaseOrderDetailReport.DataSource = dataPurchaseOrderReportListSource;
        }

        private void textBoxItemListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdatePurchaseOrderDetailReportDataGridView();
            }
        }

        private void buttonPurchaseOrderDetailReportPageListFirst_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepAccountsPayablePurchaseOrderDetailReportEntity>(purchaseOrderDetailReportList, 1, pageSize);
            dataPurchaseOrderReportListSource.DataSource = pageList;

            buttonPurchaseOrderReportPageListFirst.Enabled = false;
            buttonPurchaseOrderReportPageListPrevious.Enabled = false;
            buttonPurchaseOrderReportPageListNext.Enabled = true;
            buttonPurchaseOrderReportPageListLast.Enabled = true;

            pageNumber = 1;
            buttonPurchaseOrderReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonPurchaseOrderDetailReportPageListPrevious_Click(object sender, EventArgs e)
        {
            if (pageList.HasPreviousPage == true)
            {
                pageList = new PagedList<Entities.DgvRepAccountsPayablePurchaseOrderDetailReportEntity>(purchaseOrderDetailReportList, --pageNumber, pageSize);
                dataPurchaseOrderReportListSource.DataSource = pageList;
            }

            buttonPurchaseOrderReportPageListNext.Enabled = true;
            buttonPurchaseOrderReportPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonPurchaseOrderReportPageListFirst.Enabled = false;
                buttonPurchaseOrderReportPageListPrevious.Enabled = false;
            }

            buttonPurchaseOrderReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }



        private void buttonPurchaseOrderDetailReportPageListNext_Click(object sender, EventArgs e)
        {
            if (pageList.HasNextPage == true)
            {
                pageList = new PagedList<Entities.DgvRepAccountsPayablePurchaseOrderDetailReportEntity>(purchaseOrderDetailReportList, ++pageNumber, pageSize);
                dataPurchaseOrderReportListSource.DataSource = pageList;
            }

            buttonPurchaseOrderReportPageListFirst.Enabled = true;
            buttonPurchaseOrderReportPageListPrevious.Enabled = true;

            if (pageNumber == pageList.PageCount)
            {
                buttonPurchaseOrderReportPageListNext.Enabled = false;
                buttonPurchaseOrderReportPageListLast.Enabled = false;
            }

            buttonPurchaseOrderReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonPurchaseOrderDetailReportPageListLast_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepAccountsPayablePurchaseOrderDetailReportEntity>(purchaseOrderDetailReportList, pageList.PageCount, pageSize);
            dataPurchaseOrderReportListSource.DataSource = pageList;

            buttonPurchaseOrderReportPageListFirst.Enabled = true;
            buttonPurchaseOrderReportPageListPrevious.Enabled = true;
            buttonPurchaseOrderReportPageListNext.Enabled = false;
            buttonPurchaseOrderReportPageListLast.Enabled = false;

            pageNumber = pageList.PageCount;
            buttonPurchaseOrderReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
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
                        "ColumnPurchaseOrderDetailReportListBranch",
                        "ColumnPurchaseOrderDetailReportListPONumber",
                        "ColumnPurchaseOrderDetailReportListPODate",
                        "ColumnPurchaseOrderDetailReportListManualPONumber",
                        "ColumnPurchaseOrderDetailReportListSupplier",
                        "ColumnPurchaseOrderDetailReportListTerm",
                        "ColumnPurchaseOrderDetailReportListDateNeeded",
                        "ColumnPurchaseOrderDetailReportListRemarks",
                        "ColumnPurchaseOrderDetailReportListIsClose",
                        "ColumnPurchaseOrderDetailReportListRequestedBy",
                        "ColumnPurchaseOrderDetailReportListPreparedBy",
                        "ColumnPurchaseOrderDetailReportListCheckedBy",
                        "ColumnPurchaseOrderDetailReportListApprovedBy",
                        "ColumnPurchaseOrderDetailReportListItemCode ",
                        "ColumnPurchaseOrderDetailReportListItemDescription",
                        "ColumnPurchaseOrderDetailReportListUnit",
                        "ColumnPurchaseOrderDetailReportListQuantity",
                        "ColumnPurchaseOrderDetailReportListCost",
                        "ColumnPurchaseOrderDetailReportListAmount",
                        "ColumnPurchaseOrderDetailReportListBaseQuantity",
                        "ColumnPurchaseOrderDetailReportListBaseCost"
                    };

                    csv.AppendLine(String.Join(",", header));

                    if (purchaseOrderDetailReportList.Any())
                    {
                        foreach (var purchaseOrderDetailReport in purchaseOrderDetailReportList)
                        {
                            String[] data =
                            {
                                purchaseOrderDetailReport.ColumnPurchaseOrderDetailReportListBranch.Replace(",", ""),
                              purchaseOrderDetailReport.ColumnPurchaseOrderDetailReportListPONumber.Replace(",", ""),
                              purchaseOrderDetailReport.ColumnPurchaseOrderDetailReportListPODate.Replace(",", ""),
                              purchaseOrderDetailReport.ColumnPurchaseOrderDetailReportListManualPONumber.Replace(",", ""),
                              purchaseOrderDetailReport.ColumnPurchaseOrderDetailReportListSupplier.Replace(",", ""),
                              purchaseOrderDetailReport.ColumnPurchaseOrderDetailReportListTerm.Replace(",", ""),
                              purchaseOrderDetailReport.ColumnPurchaseOrderDetailReportListDateNeeded.Replace(",", ""),
                              purchaseOrderDetailReport.ColumnPurchaseOrderDetailReportListRemarks.Replace(",", ""),
                              purchaseOrderDetailReport.ColumnPurchaseOrderDetailReportListIsClose.ToString(),
                              purchaseOrderDetailReport.ColumnPurchaseOrderDetailReportListRequestedBy.Replace(",", ""),
                              purchaseOrderDetailReport.ColumnPurchaseOrderDetailReportListPreparedBy.Replace(",", ""),
                              purchaseOrderDetailReport.ColumnPurchaseOrderDetailReportListCheckedBy.Replace(",", ""),
                              purchaseOrderDetailReport.ColumnPurchaseOrderDetailReportListApprovedBy.Replace(",", ""),
                              purchaseOrderDetailReport.ColumnPurchaseOrderDetailReportListItemCode .Replace(",", ""),
                              purchaseOrderDetailReport.ColumnPurchaseOrderDetailReportListItemDescription.Replace(",", ""),
                              purchaseOrderDetailReport.ColumnPurchaseOrderDetailReportListUnit.Replace(",", ""),
                              purchaseOrderDetailReport.ColumnPurchaseOrderDetailReportListQuantity.Replace(",", ""),
                              purchaseOrderDetailReport.ColumnPurchaseOrderDetailReportListCost.Replace(",", ""),
                              purchaseOrderDetailReport.ColumnPurchaseOrderDetailReportListAmount.Replace(",", ""),
                              purchaseOrderDetailReport.ColumnPurchaseOrderDetailReportListBaseQuantity.Replace(",", ""),
                              purchaseOrderDetailReport.ColumnPurchaseOrderDetailReportListBaseCost.Replace(",", ""),
                            };

                            csv.AppendLine(String.Join(",", data));
                        }
                    }

                    String executingUser = WindowsIdentity.GetCurrent().Name;

                    DirectorySecurity securityRules = new DirectorySecurity();
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.Read, AccessControlType.Allow));
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.FullControl, AccessControlType.Allow));

                    DirectoryInfo createDirectorySTCSV = Directory.CreateDirectory(folderBrowserDialogGenerateCSV.SelectedPath, securityRules);
                    File.WriteAllText(createDirectorySTCSV.FullName + "\\PurchaseOrderDetailReport" + Convert.ToDateTime(textBoxStartDate.Text).ToString("yyyyMMdd") + ".csv", csv.ToString(), Encoding.GetEncoding("iso-8859-1"));

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
