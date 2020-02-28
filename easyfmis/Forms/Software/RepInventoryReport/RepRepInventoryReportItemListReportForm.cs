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
    public partial class RepRepInventoryReportItemListReportForm : Form
    {
        public List<Entities.DgvRepInventoryReportItemListReportEntity> itemListReportList;
        public BindingSource dataItemListReportListSource = new BindingSource();
        public PagedList<Entities.DgvRepInventoryReportItemListReportEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;

        public RepRepInventoryReportItemListReportForm()
        {
            InitializeComponent();

            CreateItemListDataGridView();
        }

        public List<Entities.DgvRepInventoryReportItemListReportEntity> GetItemListReportListData()
        {
            List<Entities.DgvRepInventoryReportItemListReportEntity> rowList = new List<Entities.DgvRepInventoryReportItemListReportEntity>();

            Controllers.RepInventoryReportController repInventoryReportController = new Controllers.RepInventoryReportController();

            var itemListReportList = repInventoryReportController.ListItem();
            if (itemListReportList.Any())
            {
                var row = from d in itemListReportList
                          select new Entities.DgvRepInventoryReportItemListReportEntity
                          {
                              ColumnItemListReportListCode = d.Code,
                              ColumnItemListReportListItemDescription = d.ItemDescription,
                              ColumnItemListReportListBarCode = d.BarCode,
                              ColumnItemListReportListCategory = d.Category,
                              ColumnItemListReportListUnit = d.Unit,
                              ColumnItemListReportListPrice = d.Price.ToString("#,##0.00")
                          };

                rowList = row.ToList();

            }
            return rowList;
        }

        public void GetItemListReportDataSource()
        {
            itemListReportList = GetItemListReportListData();
            if (itemListReportList.Any())
            {
                pageNumber = 1;
                pageList = new PagedList<Entities.DgvRepInventoryReportItemListReportEntity>(itemListReportList, pageNumber, pageSize);

                if (pageList.PageCount == 1)
                {
                    buttonItemListReportPageListFirst.Enabled = false;
                    buttonItemListReportPageListPrevious.Enabled = false;
                    buttonItemListReportPageListNext.Enabled = false;
                    buttonItemListReportPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonItemListReportPageListFirst.Enabled = false;
                    buttonItemListReportPageListPrevious.Enabled = false;
                    buttonItemListReportPageListNext.Enabled = true;
                    buttonItemListReportPageListLast.Enabled = true;
                }
                else if (pageNumber == pageList.PageCount)
                {
                    buttonItemListReportPageListFirst.Enabled = true;
                    buttonItemListReportPageListPrevious.Enabled = true;
                    buttonItemListReportPageListNext.Enabled = false;
                    buttonItemListReportPageListLast.Enabled = false;
                }
                else
                {
                    buttonItemListReportPageListFirst.Enabled = true;
                    buttonItemListReportPageListPrevious.Enabled = true;
                    buttonItemListReportPageListNext.Enabled = true;
                    buttonItemListReportPageListLast.Enabled = true;
                }

                textBoxListReportReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
                dataItemListReportListSource.DataSource = pageList;
            }
            else
            {
                buttonItemListReportPageListFirst.Enabled = false;
                buttonItemListReportPageListPrevious.Enabled = false;
                buttonItemListReportPageListNext.Enabled = false;
                buttonItemListReportPageListLast.Enabled = false;

                dataItemListReportListSource.Clear();
                textBoxListReportReportPageNumber.Text = "0 / 0";
            }
        }

        public void CreateItemListDataGridView()
        {
            GetItemListReportDataSource();
            dataGridViewItemListReport.DataSource = dataItemListReportListSource;
        }

        private void buttonItemListReportPageListFirst_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepInventoryReportItemListReportEntity>(itemListReportList, 1, pageSize);
            dataItemListReportListSource.DataSource = pageList;

            buttonItemListReportPageListFirst.Enabled = false;
            buttonItemListReportPageListPrevious.Enabled = false;
            buttonItemListReportPageListNext.Enabled = true;
            buttonItemListReportPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxListReportReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonItemListReportPageListPrevious_Click(object sender, EventArgs e)
        {
            if (pageList.HasPreviousPage == true)
            {
                pageList = new PagedList<Entities.DgvRepInventoryReportItemListReportEntity>(itemListReportList, --pageNumber, pageSize);
                dataItemListReportListSource.DataSource = pageList;
            }

            buttonItemListReportPageListNext.Enabled = true;
            buttonItemListReportPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonItemListReportPageListFirst.Enabled = false;
                buttonItemListReportPageListPrevious.Enabled = false;
            }

            textBoxListReportReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonItemListReportPageListNext_Click(object sender, EventArgs e)
        {
            if (pageList.HasNextPage == true)
            {
                pageList = new PagedList<Entities.DgvRepInventoryReportItemListReportEntity>(itemListReportList, ++pageNumber, pageSize);
                dataItemListReportListSource.DataSource = pageList;
            }

            buttonItemListReportPageListFirst.Enabled = true;
            buttonItemListReportPageListPrevious.Enabled = true;

            if (pageNumber == pageList.PageCount)
            {
                buttonItemListReportPageListNext.Enabled = false;
                buttonItemListReportPageListLast.Enabled = false;
            }

            textBoxListReportReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonItemListReportPageListLast_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepInventoryReportItemListReportEntity>(itemListReportList, pageList.PageCount, pageSize);
            dataItemListReportListSource.DataSource = pageList;

            buttonItemListReportPageListFirst.Enabled = true;
            buttonItemListReportPageListPrevious.Enabled = true;
            buttonItemListReportPageListNext.Enabled = false;
            buttonItemListReportPageListLast.Enabled = false;

            pageNumber = pageList.PageCount;
            textBoxListReportReportPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonClose_OnClick(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonGenerateCSV_Click(object sender, EventArgs e)
        {
            try
            {
                String dateNow = DateTime.Today.ToString();
                DialogResult dialogResult = folderBrowserDialogGenerateCSV.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    StringBuilder csv = new StringBuilder();

                    String[] header =
                    {
                        "Code",
                        "ItemDescription",
                        "BarCode",
                        "Category",
                        "Unit",
                        "Price",
                    };

                    csv.AppendLine(String.Join(",", header));

                    if (itemListReportList.Any())
                    {
                        foreach (var itemList in itemListReportList)
                        {
                            String[] data =
                            {
                                itemList.ColumnItemListReportListCode.Replace(",", ""),
                                itemList.ColumnItemListReportListItemDescription.Replace(",", ""),
                                itemList.ColumnItemListReportListBarCode.Replace(",", ""),
                                itemList.ColumnItemListReportListCategory.Replace(",", ""),
                                itemList.ColumnItemListReportListUnit.Replace(",", ""),
                                itemList.ColumnItemListReportListPrice.Replace(",", ""),
                            };

                            csv.AppendLine(String.Join(",", data));
                        }
                    }

                    String executingUser = WindowsIdentity.GetCurrent().Name;

                    DirectorySecurity securityRules = new DirectorySecurity();
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.Read, AccessControlType.Allow));
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.FullControl, AccessControlType.Allow));

                    DirectoryInfo createDirectorySTCSV = Directory.CreateDirectory(folderBrowserDialogGenerateCSV.SelectedPath, securityRules);
                    File.WriteAllText(createDirectorySTCSV.FullName + "\\SalesDetailReportPerPersonReport_" + Convert.ToDateTime(dateNow).ToString("yyyyMMdd") + ".csv", csv.ToString(), Encoding.GetEncoding("iso-8859-1"));

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
