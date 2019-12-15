using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software.MstItem
{
    public partial class MstItemListForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public static List<Entities.DgvItemListItemEntity> itemListData = new List<Entities.DgvItemListItemEntity>();
        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;

        public PagedList<Entities.DgvItemListItemEntity> itemListPageList = new PagedList<Entities.DgvItemListItemEntity>(itemListData, pageNumber, pageSize);
        public BindingSource itemListDataSource = new BindingSource();

        public MstItemListForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();

            sysSoftwareForm = softwareForm;

            CreateItemListDataGridView();
        }

        public void UpdateItemListDataSource()
        {
            SetItemListDataSourceAsync();
        }

        public async void SetItemListDataSourceAsync()
        {
            List<Entities.DgvItemListItemEntity> getItemListData = await GetItemListDataTask();
            if (getItemListData.Any())
            {
                itemListData = getItemListData;
                itemListPageList = new PagedList<Entities.DgvItemListItemEntity>(itemListData, pageNumber, pageSize);

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
            }
            else
            {
                buttonItemListPageListFirst.Enabled = false;
                buttonItemListPageListPrevious.Enabled = false;
                buttonItemListPageListNext.Enabled = false;
                buttonItemListPageListLast.Enabled = false;

                pageNumber = 1;

                itemListData = new List<Entities.DgvItemListItemEntity>();
                itemListDataSource.Clear();
                textBoxItemListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvItemListItemEntity>> GetItemListDataTask()
        {
            String filter = textBoxItemListFilter.Text;
            Controllers.MstArticleController mstItemController = new Controllers.MstArticleController();

            List<Entities.MstArticleEntity> listItem = mstItemController.ListArticle(1);
            if (listItem.Any())
            {
                var items = from d in listItem
                            where d.ArticleCode.Contains(filter)
                            || d.ArticleBarCode.Contains(filter)
                            || d.Article.Contains(filter)
                            || d.Category.Contains(filter)
                            select new Entities.DgvItemListItemEntity
                            {
                                ColumnItemListButtonEdit = "Edit",
                                ColumnItemListButtonDelete = "Delete",
                                ColumnItemListId = d.Id,
                                ColumnItemListArticleCode = d.ArticleCode,
                                ColumnItemListArticleBarCode = d.ArticleBarCode,
                                ColumnItemListArticle = d.Article,
                                ColumnItemListArticleAlias = d.ArticleAlias,
                                ColumnItemListGenericArticleName = d.GenericArticleName,
                                ColumnItemListCategory = d.Category,
                                ColumnItemListVATInTaxId = d.VATInTaxId,
                                ColumnItemListVATInTax = d.VATInTax,
                                ColumnItemListVATOutTaxId = d.VATOutTaxId,
                                ColumnItemListVATOutTax = d.VATOutTax,
                                ColumnItemListUnitId = d.UnitId,
                                ColumnItemListUnit = d.Unit,
                                ColumnItemListDefaultSupplierId = d.DefaultSupplierId,
                                ColumnItemListDefaultCost = d.DefaultCost.ToString("#,##0.00"),
                                ColumnItemListDefaultPrice = d.DefaultPrice.ToString("#,##0.00"),
                                ColumnItemListReorderQuantity = d.ReorderQuantity.ToString("#,##0.00"),
                                ColumnItemListIsInventory = d.IsInventory,
                                ColumnItemListIsLocked = d.IsLocked
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvItemListItemEntity>());
            }
        }

        public void CreateItemListDataGridView()
        {
            UpdateItemListDataSource();

            dataGridViewItemList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewItemList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewItemList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewItemList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewItemList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewItemList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewItemList.DataSource = itemListDataSource;
        }

        public void GetItemListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
            sysSoftwareForm.RemoveTabPage();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Controllers.MstArticleController mstItemController = new Controllers.MstArticleController();
            String[] addItem = mstItemController.AddArticle();
            if (addItem[1].Equals("0") == false)
            {
                sysSoftwareForm.AddTabPageItemDetail(this, mstItemController.DetailArticle(Convert.ToInt32(addItem[1])));
                UpdateItemListDataSource();
            }
            else
            {
                MessageBox.Show(addItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewItemList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetItemListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewItemList.CurrentCell.ColumnIndex == dataGridViewItemList.Columns["ColumnItemListButtonEdit"].Index)
            {
                Controllers.MstArticleController mstItemController = new Controllers.MstArticleController();
                sysSoftwareForm.AddTabPageItemDetail(this, mstItemController.DetailArticle(Convert.ToInt32(dataGridViewItemList.Rows[e.RowIndex].Cells[2].Value)));
            }

            if (e.RowIndex > -1 && dataGridViewItemList.CurrentCell.ColumnIndex == dataGridViewItemList.Columns["ColumnItemListButtonDelete"].Index)
            {
                Boolean isLocked = Convert.ToBoolean(dataGridViewItemList.Rows[e.RowIndex].Cells[21].Value);

                if (isLocked == true)
                {
                    MessageBox.Show("Already locked.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult deleteDialogResult = MessageBox.Show("Delete Item?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (deleteDialogResult == DialogResult.Yes)
                    {
                        Controllers.MstArticleController mstItemController = new Controllers.MstArticleController();

                        String[] deleteItem = mstItemController.DeleteArticle(Convert.ToInt32(dataGridViewItemList.Rows[e.RowIndex].Cells[2].Value));
                        if (deleteItem[1].Equals("0") == false)
                        {
                            Int32 currentPageNumber = pageNumber;

                            pageNumber = 1;
                            UpdateItemListDataSource();

                            if (itemListPageList != null)
                            {
                                if (itemListData.Count() % pageSize == 1)
                                {
                                    pageNumber = currentPageNumber - 1;
                                }
                                else if (itemListData.Count() < 1)
                                {
                                    pageNumber = 1;
                                }
                                else
                                {
                                    pageNumber = currentPageNumber;
                                }

                                itemListDataSource.DataSource = itemListPageList;
                            }
                        }
                        else
                        {
                            MessageBox.Show(deleteItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
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
            itemListPageList = new PagedList<Entities.DgvItemListItemEntity>(itemListData, 1, pageSize);
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
                itemListPageList = new PagedList<Entities.DgvItemListItemEntity>(itemListData, --pageNumber, pageSize);
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
                itemListPageList = new PagedList<Entities.DgvItemListItemEntity>(itemListData, ++pageNumber, pageSize);
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
            itemListPageList = new PagedList<Entities.DgvItemListItemEntity>(itemListData, itemListPageList.PageCount, pageSize);
            itemListDataSource.DataSource = itemListPageList;

            buttonItemListPageListFirst.Enabled = true;
            buttonItemListPageListPrevious.Enabled = true;
            buttonItemListPageListNext.Enabled = false;
            buttonItemListPageListLast.Enabled = false;

            pageNumber = itemListPageList.PageCount;
            textBoxItemListPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }
    }
}
