using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace easyfmis.Forms.Software.SysUtilities
{
    public partial class SysUtilitiesItemPriceCostForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        private Modules.SysUserRightsModule sysUserRights;

        public Boolean isIntegrationStarted = false;
        public Int32 logMessageCount = 0;

        public String logLocation = "";

        public SysUtilitiesItemPriceCostForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;
            sysUserRights = new Modules.SysUserRightsModule("SysSettings");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            CreateItemListDataGridView();
            UpdateItemListDataSource();
        }

        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;

        public static List<Entities.DgvSysMenuItemListEntity> itemListData = new List<Entities.DgvSysMenuItemListEntity>();
        public PagedList<Entities.DgvSysMenuItemListEntity> itemListPageList = new PagedList<Entities.DgvSysMenuItemListEntity>(itemListData, pageNumber, pageSize);
        public BindingSource itemListDataSource = new BindingSource();

        public void UpdateItemListDataSource()
        {
            SetItemListDataSourceAsync();
        }

        public async void SetItemListDataSourceAsync()
        {
            itemListData = await GetItemListDataTask();
            if (itemListData.Any())
            {

                pageNumber = 1;
                itemListPageList = new PagedList<Entities.DgvSysMenuItemListEntity>(itemListData, pageNumber, pageSize);

                if (itemListPageList.PageCount == 1)
                {
                    buttonItemListPageListFirst.Enabled = false;
                    buttonItemListPageListPrevious.Enabled = false;
                    buttonItemListPageListNext.Enabled = false;
                    buttonItemListPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonItemListPageListFirst.Enabled = false;
                    buttonItemListPageListPrevious.Enabled = false;
                    buttonItemListPageListNext.Enabled = true;
                    buttonItemListPageListLast.Enabled = true;
                }
                else if (pageNumber == itemListPageList.PageCount)
                {
                    buttonItemListPageListFirst.Enabled = true;
                    buttonItemListPageListPrevious.Enabled = true;
                    buttonItemListPageListNext.Enabled = false;
                    buttonItemListPageListLast.Enabled = false;
                }
                else
                {
                    buttonItemListPageListFirst.Enabled = true;
                    buttonItemListPageListPrevious.Enabled = true;
                    buttonItemListPageListNext.Enabled = true;
                    buttonItemListPageListLast.Enabled = true;
                }

                textBoxItemListPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
                itemListDataSource.DataSource = itemListPageList;

                GetItemListCurrentSelectedCell(dataGridViewItemList.CurrentCell.RowIndex);
            }
            else
            {
                buttonItemListPageListFirst.Enabled = false;
                buttonItemListPageListPrevious.Enabled = false;
                buttonItemListPageListNext.Enabled = false;
                buttonItemListPageListLast.Enabled = false;

                pageNumber = 1;

                itemListData = new List<Entities.DgvSysMenuItemListEntity>();
                itemListDataSource.Clear();
                textBoxItemListPageNumber.Text = "1 / 1";

                GetItemListCurrentSelectedCell(-1);
            }
        }

        public Task<List<Entities.DgvSysMenuItemListEntity>> GetItemListDataTask()
        {
            String filter = textBoxItemListFilter.Text;
            Controllers.SysMenuController mstItemController = new Controllers.SysMenuController();

            List<Entities.SysMenuItemListEntity> listItem = mstItemController.ListArticle(1);
            if (listItem.Any())
            {
                var items = from d in listItem
                            where d.ItemCode.ToLower().Contains(filter.ToLower())
                            || d.ItemDescription.ToLower().Contains(filter.ToLower())
                            || d.Unit.ToLower().Contains(filter.ToLower())
                            select new Entities.DgvSysMenuItemListEntity
                            {
                                ColumnSysMenuItemListId = d.Id,
                                ColumnSysMenuItemListItemCode = d.ItemCode,
                                ColumnSysMenuItemListItemDescription = d.ItemDescription,
                                ColumnSysMenuItemListOnHandQuatity = string.Format("{0:0.00}", d.OnHandQuatity),
                                ColumnSysMenuItemListUnit = d.Unit
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvSysMenuItemListEntity>());
            }
        }

        public void CreateItemListDataGridView()
        {

            dataGridViewItemList.DataSource = itemListDataSource;
        }

        private void dataGridViewItemList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetItemListCurrentSelectedCell(e.RowIndex);
            }
        }

        private void textBoxItemListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateItemListDataSource();
            }
        }

        private void buttonItemListPageListFirst_Click(object sender, EventArgs e)
        {
            itemListPageList = new PagedList<Entities.DgvSysMenuItemListEntity>(itemListData, 1, pageSize);
            itemListDataSource.DataSource = itemListPageList;

            buttonItemListPageListFirst.Enabled = false;
            buttonItemListPageListPrevious.Enabled = false;
            buttonItemListPageListNext.Enabled = true;
            buttonItemListPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxItemListPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonItemListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (itemListPageList.HasPreviousPage == true)
            {
                itemListPageList = new PagedList<Entities.DgvSysMenuItemListEntity>(itemListData, --pageNumber, pageSize);
                itemListDataSource.DataSource = itemListPageList;
            }

            buttonItemListPageListNext.Enabled = true;
            buttonItemListPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonItemListPageListFirst.Enabled = false;
                buttonItemListPageListPrevious.Enabled = false;
            }

            textBoxItemListPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonItemListPageListNext_Click(object sender, EventArgs e)
        {
            if (itemListPageList.HasNextPage == true)
            {
                itemListPageList = new PagedList<Entities.DgvSysMenuItemListEntity>(itemListData, ++pageNumber, pageSize);
                itemListDataSource.DataSource = itemListPageList;
            }

            buttonItemListPageListFirst.Enabled = true;
            buttonItemListPageListPrevious.Enabled = true;

            if (pageNumber == itemListPageList.PageCount)
            {
                buttonItemListPageListNext.Enabled = false;
                buttonItemListPageListLast.Enabled = false;
            }

            textBoxItemListPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonItemListPageListLast_Click(object sender, EventArgs e)
        {
            itemListPageList = new PagedList<Entities.DgvSysMenuItemListEntity>(itemListData, itemListPageList.PageCount, pageSize);
            itemListDataSource.DataSource = itemListPageList;

            buttonItemListPageListFirst.Enabled = true;
            buttonItemListPageListPrevious.Enabled = true;
            buttonItemListPageListNext.Enabled = false;
            buttonItemListPageListLast.Enabled = false;

            pageNumber = itemListPageList.PageCount;
            textBoxItemListPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }


        public void GetItemListCurrentSelectedCell(Int32 rowIndex)
        {
            dataGridViewPriceList.Rows.Clear();
            dataGridViewPriceList.Refresh();
            dataGridViewCostList.Rows.Clear();
            dataGridViewCostList.Refresh();

            if (rowIndex == -1)
            {

            }
            else
            {
                Controllers.SysMenuController sysMenuController = new Controllers.SysMenuController();
                var priceList = sysMenuController.GetPriceList(Convert.ToInt32(dataGridViewItemList.Rows[rowIndex].Cells[0].Value));
                if (priceList.Any())
                {
                    foreach (var price in priceList)
                    {
                        dataGridViewPriceList.Rows.Add(
                            price.PriceDescription,
                            price.Price.ToString("##,#0.00")
                        );
                    }
                }

                var costList = sysMenuController.GetCostList(Convert.ToInt32(dataGridViewItemList.Rows[rowIndex].Cells[0].Value));
                if (costList.Any())
                {
                    foreach (var cost in costList)
                    {
                        dataGridViewCostList.Rows.Add(
                            cost.CostDescription,
                            cost.Cost.ToString("##,#0.00") + cost.Currency
                        );
                    }
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }
    }
}
