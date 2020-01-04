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
    public partial class MstItemDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public MstItemListForm mstItemListForm;
        public Entities.MstArticleEntity mstItemEntity;

        public List<Entities.MstArticlePriceEntity> mstArticlePriceEntity;
        public List<Entities.MstArticleUnitEntity> mstArticleUnitEntities;

        public MstItemDetailForm(SysSoftwareForm softwareForm, MstItemListForm itemListForm, Entities.MstArticleEntity itemEntity)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            mstItemListForm = itemListForm;
            mstItemEntity = itemEntity;

            DropdownArticleGroup();
        }

        public void DropdownArticleGroup()
        {
            Controllers.MstArticleController mstArticleController = new Controllers.MstArticleController();
            var articleGroup = mstArticleController.DropDownListArticleGroup("ITEM");
            if (articleGroup.Any())
            {
                comboBoxArticleGroup.DataSource = articleGroup;
                comboBoxArticleGroup.DisplayMember = "ArticleGroup";
                comboBoxArticleGroup.ValueMember = "Id";
            }
            GetTaxList();
        }

        public void GetTaxList()
        {
            Controllers.MstArticleController mstItemController = new Controllers.MstArticleController();
            if (mstItemController.DropDownListTax().Any())
            {
                comboBoxVATInTax.DataSource = mstItemController.DropDownListTax();
                comboBoxVATInTax.ValueMember = "Id";
                comboBoxVATInTax.DisplayMember = "TaxCode";

                comboBoxVATOutTax.DataSource = mstItemController.DropDownListTax();
                comboBoxVATOutTax.ValueMember = "Id";
                comboBoxVATOutTax.DisplayMember = "TaxCode";

                GetUnitList();
            }
        }

        public void GetUnitList()
        {
            Controllers.MstArticleController mstItemController = new Controllers.MstArticleController();
            if (mstItemController.DropDownListUnit().Any())
            {
                comboBoxUnit.DataSource = mstItemController.DropDownListUnit();
                comboBoxUnit.ValueMember = "Id";
                comboBoxUnit.DisplayMember = "Unit";

                GetSupplierList();
            }
        }

        public void GetSupplierList()
        {
            Controllers.MstArticleController mstItemController = new Controllers.MstArticleController();
            if (mstItemController.ListArticle(3).Any())
            {
                comboBoxDefaultSupplier.DataSource = mstItemController.ListArticle(3);
                comboBoxDefaultSupplier.ValueMember = "Id";
                comboBoxDefaultSupplier.DisplayMember = "Article";
            }
            GetItemDetail();
        }

        public void GetItemDetail()
        {
            UpdateComponents(mstItemEntity.IsLocked);

            comboBoxArticleGroup.SelectedValue = mstItemEntity.ArticleGroupId;
            textBoxItemCode.Text = mstItemEntity.ArticleCode;
            textBoxBarcode.Text = mstItemEntity.ArticleBarCode;
            textBoxDescription.Text = mstItemEntity.Article;
            textBoxAlias.Text = mstItemEntity.ArticleAlias;
            textBoxCategory.Text = mstItemEntity.Category;
            comboBoxVATInTax.SelectedValue = mstItemEntity.VATInTaxId;
            comboBoxVATOutTax.SelectedValue = mstItemEntity.VATOutTaxId;
            comboBoxUnit.SelectedValue = mstItemEntity.UnitId;

            Int32 supplierId = 0;
            comboBoxDefaultSupplier.SelectedValue = supplierId;
            if (mstItemEntity.DefaultSupplierId != null)
            {
                comboBoxDefaultSupplier.SelectedValue = mstItemEntity.DefaultSupplierId;

            }

            textBoxCost.Text = mstItemEntity.DefaultCost.ToString("#,##0.00");
            textBoxPrice.Text = mstItemEntity.DefaultPrice.ToString("#,##0.00"); ;
            textBoxReorderQuantity.Text = mstItemEntity.ReorderQuantity.ToString("#,##0.00");
            checkBoxIsInventory.Checked = mstItemEntity.IsInventory;
            textBoxGenericName.Text = mstItemEntity.GenericArticleName;
            textBoxRemarks.Text = mstItemEntity.Remarks;

            CreateArticleUnittDataGridView();
            CreateItemPriceListDataGridView();
            CreateItemComponentListDataGridView();
            CreateItemInventoryListDataGridView();
        }

        public void UpdateComponents(Boolean isLocked)
        {

            buttonLock.Enabled = !isLocked;
            buttonUnlock.Enabled = isLocked;

            comboBoxArticleGroup.Enabled = !isLocked;
            textBoxItemCode.Enabled = !isLocked;
            textBoxBarcode.Enabled = !isLocked;
            textBoxDescription.Enabled = !isLocked;
            textBoxAlias.Enabled = !isLocked;
            textBoxCategory.Enabled = !isLocked;
            comboBoxVATInTax.Enabled = !isLocked;
            comboBoxVATOutTax.Enabled = !isLocked;
            comboBoxUnit.Enabled = !isLocked;
            comboBoxDefaultSupplier.Enabled = !isLocked;
            textBoxCost.Enabled = !isLocked;
            textBoxPrice.Enabled = !isLocked;
            textBoxReorderQuantity.Enabled = !isLocked;
            checkBoxIsInventory.Enabled = !isLocked;
            textBoxRemarks.Enabled = !isLocked;
            textBoxGenericName.Enabled = !isLocked;

            buttonAddUnitConvertion.Enabled = !isLocked;
            buttonAddItemPrice.Enabled = !isLocked;
            buttonItemComponentAdd.Enabled = !isLocked;

            dataGridViewItemComponentList.Columns[0].Visible = !isLocked;
            dataGridViewItemComponentList.Columns[1].Visible = !isLocked;
            dataGridViewItemPriceList.Columns[0].Visible = !isLocked;
            dataGridViewItemPriceList.Columns[1].Visible = !isLocked;
            dataGridViewUnitConversion.Columns[0].Visible = !isLocked;
            dataGridViewUnitConversion.Columns[1].Visible = !isLocked;

            dataGridViewItemInventoryList.Columns["ColumnItemInventoryButtonEdit"].Visible = !isLocked;
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            if (mstArticlePriceEntity.Count > 0 && mstArticleUnitEntities.Count > 0)
            {
                Controllers.MstArticleController mstItemController = new Controllers.MstArticleController();

                mstItemEntity.ArticleCode = textBoxItemCode.Text;
                mstItemEntity.ArticleBarCode = textBoxBarcode.Text;
                mstItemEntity.Article = textBoxDescription.Text;
                mstItemEntity.ArticleAlias = textBoxAlias.Text;
                mstItemEntity.Category = textBoxCategory.Text;
                mstItemEntity.VATInTaxId = Convert.ToInt32(comboBoxVATInTax.SelectedValue);
                mstItemEntity.VATOutTaxId = Convert.ToInt32(comboBoxVATOutTax.SelectedValue);
                mstItemEntity.UnitId = Convert.ToInt32(comboBoxUnit.SelectedValue);
                mstItemEntity.DefaultSupplierId = Convert.ToInt32(comboBoxDefaultSupplier.SelectedValue);
                mstItemEntity.DefaultCost = Convert.ToDecimal(textBoxCost.Text);
                mstItemEntity.DefaultPrice = Convert.ToDecimal(textBoxPrice.Text);
                mstItemEntity.ReorderQuantity = Convert.ToDecimal(textBoxReorderQuantity.Text);
                mstItemEntity.IsInventory = checkBoxIsInventory.Checked;
                mstItemEntity.GenericArticleName = textBoxGenericName.Text;
                mstItemEntity.Remarks = textBoxRemarks.Text;

                String[] lockItem = mstItemController.LockArticle(mstItemEntity);
                if (lockItem[1].Equals("0") == false)
                {
                    UpdateComponents(true);
                    mstItemListForm.UpdateItemListDataSource();
                }
                else
                {
                    UpdateComponents(false);
                    MessageBox.Show(lockItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No Unit or Price!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            Controllers.MstArticleController mstItemController = new Controllers.MstArticleController();

            String[] unlockItem = mstItemController.UnlockArticle(mstItemEntity);
            if (unlockItem[1].Equals("0") == false)
            {
                UpdateComponents(false);
                mstItemListForm.UpdateItemListDataSource();
            }
            else
            {
                UpdateComponents(true);
                MessageBox.Show(unlockItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Close(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }

        private void textBoxCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBoxCost_Leave(object sender, EventArgs e)
        {
            textBoxCost.Text = Convert.ToDecimal(textBoxCost.Text).ToString("#,##0.00");
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBoxPrice_Leave(object sender, EventArgs e)
        {
            textBoxPrice.Text = Convert.ToDecimal(textBoxPrice.Text).ToString("#,##0.00");
        }

        private void textBoxReorderQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBoxReorderQuantity_Leave(object sender, EventArgs e)
        {
            textBoxReorderQuantity.Text = Convert.ToDecimal(textBoxReorderQuantity.Text).ToString("#,##0.00");
        }



        //====================
        // Unit Convertion Tab
        //====================

        public static Int32 pageSize = 50;
        public static Int32 pageNumber = 1;




        public static List<Entities.DgvItemUnitEntity> itemUnitConversionListData = new List<Entities.DgvItemUnitEntity>();
        public PagedList<Entities.DgvItemUnitEntity> itemUnitConversionPageList = new PagedList<Entities.DgvItemUnitEntity>(itemUnitConversionListData, pageNumber, pageSize);
        public BindingSource itemUnitConversionListDataSource = new BindingSource();

        public Task<List<Entities.DgvItemUnitEntity>> GetArtileUnitListDataTask()
        {
            Controllers.MstArticleUnitController mstArticleUnitController = new Controllers.MstArticleUnitController();
            List<Entities.MstArticleUnitEntity> listArticleUnit = mstArticleUnitController.ListArticleList(mstItemEntity.Id);
            mstArticleUnitEntities = listArticleUnit;
            if (listArticleUnit.Any())
            {
                var itemPrices = from d in listArticleUnit
                                 select new Entities.DgvItemUnitEntity
                                 {
                                     ColumnItemArtilceUnitButtonEdit = "Edit",
                                     ColumnItemArtilceUnitButtonDelete = "Delete",
                                     ColumnArtilceUnitListId = d.Id,
                                     ColumnArtilceUnitListArticleId = d.ArticleId,
                                     ColumnArtilceUnitListBaseUnitMultiplier = d.BaseUnitMultiplier.ToString("#,##0.00"),
                                     ColumnArtilceUnitListBaseUnit = d.BaseUnit,
                                     ColumnArtilceUnitListUnitMultiplier = d.UnitMultiplier.ToString("#,##0.00"),
                                     ColumnItemUnitConversionListUnitId = d.UnitId,
                                     ColumnArtilceUnitListUnit = d.Unit
                                 };

                return Task.FromResult(itemPrices.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvItemUnitEntity>());
            }
        }

        public async void SetArticleUnitListDataSourceAsync()
        {
            List<Entities.DgvItemUnitEntity> getArtileUnitListData = await GetArtileUnitListDataTask();
            if (getArtileUnitListData.Any())
            {
                itemUnitConversionListData = getArtileUnitListData;
                itemUnitConversionPageList = new PagedList<Entities.DgvItemUnitEntity>(itemUnitConversionListData, pageNumber, pageSize);

                if (itemUnitConversionPageList.PageCount == 1)
                {
                    buttonArticleUnitListPageListFirst.Enabled = false;
                    buttonArticleUnitListPageListPrevious.Enabled = false;
                    buttonArticleUnitListPageListNext.Enabled = false;
                    buttonArticleUnitListPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonArticleUnitListPageListFirst.Enabled = false;
                    buttonArticleUnitListPageListPrevious.Enabled = false;
                    buttonArticleUnitListPageListNext.Enabled = true;
                    buttonArticleUnitListPageListLast.Enabled = true;
                }
                else if (pageNumber == itemUnitConversionPageList.PageCount)
                {
                    buttonArticleUnitListPageListFirst.Enabled = true;
                    buttonArticleUnitListPageListPrevious.Enabled = true;
                    buttonArticleUnitListPageListNext.Enabled = false;
                    buttonArticleUnitListPageListLast.Enabled = false;
                }
                else
                {
                    buttonArticleUnitListPageListFirst.Enabled = true;
                    buttonArticleUnitListPageListPrevious.Enabled = true;
                    buttonArticleUnitListPageListNext.Enabled = true;
                    buttonArticleUnitListPageListLast.Enabled = true;
                }

                textBoxItemArticleUnitPageNumber.Text = pageNumber + " / " + itemUnitConversionPageList.PageCount;
                itemUnitConversionListDataSource.DataSource = itemUnitConversionPageList;
            }
            else
            {
                buttonArticleUnitListPageListFirst.Enabled = false;
                buttonArticleUnitListPageListPrevious.Enabled = false;
                buttonArticleUnitListPageListNext.Enabled = false;
                buttonArticleUnitListPageListLast.Enabled = false;

                pageNumber = 1;

                getArtileUnitListData = new List<Entities.DgvItemUnitEntity>();
                itemUnitConversionListDataSource.Clear();
                textBoxItemArticleUnitPageNumber.Text = "1 / 1";
            }
        }

        public void UpdateArticleUnitListDataSource()
        {
            SetArticleUnitListDataSourceAsync();
        }

        public void CreateArticleUnittDataGridView()
        {
            UpdateArticleUnitListDataSource();

            dataGridViewUnitConversion.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewUnitConversion.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewUnitConversion.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewUnitConversion.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewUnitConversion.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewUnitConversion.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewUnitConversion.DataSource = itemUnitConversionListDataSource;
        }

        private void buttonArticleUnitListPageListFirst_Click(object sender, EventArgs e)
        {
            itemUnitConversionPageList = new PagedList<Entities.DgvItemUnitEntity>(itemUnitConversionListData, 1, pageSize);
            itemUnitConversionListDataSource.DataSource = itemUnitConversionPageList;

            buttonArticleUnitListPageListFirst.Enabled = false;
            buttonArticleUnitListPageListPrevious.Enabled = false;
            buttonArticleUnitListPageListNext.Enabled = true;
            buttonArticleUnitListPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxItemArticleUnitPageNumber.Text = pageNumber + " / " + itemUnitConversionPageList.PageCount;
        }

        private void buttonArticleUnitListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (itemUnitConversionPageList.HasPreviousPage == true)
            {
                itemUnitConversionPageList = new PagedList<Entities.DgvItemUnitEntity>(itemUnitConversionListData, --pageNumber, pageSize);
                itemUnitConversionListDataSource.DataSource = itemUnitConversionPageList;
            }

            buttonArticleUnitListPageListNext.Enabled = true;
            buttonArticleUnitListPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonArticleUnitListPageListFirst.Enabled = false;
                buttonArticleUnitListPageListPrevious.Enabled = false;
            }

            textBoxItemArticleUnitPageNumber.Text = pageNumber + " / " + itemUnitConversionPageList.PageCount;
        }

        private void buttonArticleUnitListPageListNext_Click(object sender, EventArgs e)
        {
            if (itemUnitConversionPageList.HasNextPage == true)
            {
                itemUnitConversionPageList = new PagedList<Entities.DgvItemUnitEntity>(itemUnitConversionListData, ++pageNumber, pageSize);
                itemUnitConversionListDataSource.DataSource = itemUnitConversionPageList;
            }

            buttonArticleUnitListPageListFirst.Enabled = true;
            buttonArticleUnitListPageListPrevious.Enabled = true;

            if (pageNumber == itemUnitConversionPageList.PageCount)
            {
                buttonArticleUnitListPageListNext.Enabled = false;
                buttonArticleUnitListPageListLast.Enabled = false;
            }

            textBoxItemArticleUnitPageNumber.Text = pageNumber + " / " + itemUnitConversionPageList.PageCount;
        }

        private void buttonArticleUnitListPageListLast_Click(object sender, EventArgs e)
        {
            itemUnitConversionPageList = new PagedList<Entities.DgvItemUnitEntity>(itemUnitConversionListData, itemUnitConversionPageList.PageCount, pageSize);
            itemUnitConversionListDataSource.DataSource = itemUnitConversionPageList;

            buttonArticleUnitListPageListFirst.Enabled = true;
            buttonArticleUnitListPageListPrevious.Enabled = true;
            buttonArticleUnitListPageListNext.Enabled = false;
            buttonArticleUnitListPageListLast.Enabled = false;

            pageNumber = itemUnitConversionPageList.PageCount;
            textBoxItemArticleUnitPageNumber.Text = pageNumber + " / " + itemUnitConversionPageList.PageCount;
        }

        private void buttonAddUnitConvertion_Click(object sender, EventArgs e)
        {
            MstArticleUnitDetailForm mstArticleUnitDetailForm = new MstArticleUnitDetailForm(this, null, mstItemEntity);
            mstArticleUnitDetailForm.ShowDialog();
        }

        private void dataGridViewUnitConversion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetArticleUnitListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewUnitConversion.CurrentCell.ColumnIndex == dataGridViewUnitConversion.Columns["ColumnItemArtilceUnitButtonEdit"].Index)
            {
                Entities.MstArticleUnitEntity selectedArticleUnit = new Entities.MstArticleUnitEntity()
                {
                    Id = Convert.ToInt32(dataGridViewUnitConversion.Rows[e.RowIndex].Cells[dataGridViewUnitConversion.Columns["ColumnArtilceUnitListId"].Index].Value),
                    ArticleId = Convert.ToInt32(dataGridViewUnitConversion.Rows[e.RowIndex].Cells[dataGridViewUnitConversion.Columns["ColumnArtilceUnitListArticleId"].Index].Value),
                    BaseUnitMultiplier = Convert.ToDecimal(dataGridViewUnitConversion.Rows[e.RowIndex].Cells[dataGridViewUnitConversion.Columns["ColumnArtilceUnitListBaseUnitMultiplier"].Index].Value),
                    UnitMultiplier = Convert.ToDecimal(dataGridViewUnitConversion.Rows[e.RowIndex].Cells[dataGridViewUnitConversion.Columns["ColumnArtilceUnitListUnitMultiplier"].Index].Value),
                    UnitId = Convert.ToInt32(dataGridViewUnitConversion.Rows[e.RowIndex].Cells[dataGridViewUnitConversion.Columns["ColumnItemUnitConversionListUnitId"].Index].Value)
                };

                MstArticleUnitDetailForm mstArticleUnitDetailForm = new MstArticleUnitDetailForm(this, selectedArticleUnit, mstItemEntity);
                mstArticleUnitDetailForm.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewUnitConversion.CurrentCell.ColumnIndex == dataGridViewUnitConversion.Columns["ColumnItemArtilceUnitButtonDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete Unit Conversion?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    Controllers.MstArticleUnitController mstArticleUnitController = new Controllers.MstArticleUnitController();

                    String[] deleteArticleUnit = mstArticleUnitController.DeleteArticleUnit(Convert.ToInt32(dataGridViewUnitConversion.Rows[e.RowIndex].Cells[dataGridViewUnitConversion.Columns["ColumnArtilceUnitListId"].Index].Value));
                    if (deleteArticleUnit[1].Equals("0") == false)
                    {
                        Int32 currentPageNumber = pageNumber;

                        pageNumber = 1;
                        UpdateArticleUnitListDataSource();
                    }
                    else
                    {
                        MessageBox.Show(deleteArticleUnit[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        public void GetArticleUnitListCurrentSelectedCell(Int32 rowIndex)
        {

        }


        //===========
        // Item Price
        //===========

        public static List<Entities.DgvItemDetailItemPriceListEntity> itemPriceListData = new List<Entities.DgvItemDetailItemPriceListEntity>();
        public PagedList<Entities.DgvItemDetailItemPriceListEntity> itemPriceListPageList = new PagedList<Entities.DgvItemDetailItemPriceListEntity>(itemPriceListData, pageNumber, pageSize);
        public BindingSource itemPriceListDataSource = new BindingSource();

        public void UpdateItemPriceListDataSource()
        {
            SetItemPriceListDataSourceAsync();
        }

        public async void SetItemPriceListDataSourceAsync()
        {
            List<Entities.DgvItemDetailItemPriceListEntity> getItemPriceListData = await GetItemPriceListDataTask();
            if (getItemPriceListData.Any())
            {
                itemPriceListData = getItemPriceListData;
                itemPriceListPageList = new PagedList<Entities.DgvItemDetailItemPriceListEntity>(itemPriceListData, pageNumber, pageSize);

                if (itemPriceListPageList.PageCount == 1)
                {
                    buttonItemPriceListPageListFirst.Enabled = false;
                    buttonItemPriceListPageListPrevious.Enabled = false;
                    buttonItemPriceListPageListNext.Enabled = false;
                    buttonItemPriceListPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonItemPriceListPageListFirst.Enabled = false;
                    buttonItemPriceListPageListPrevious.Enabled = false;
                    buttonItemPriceListPageListNext.Enabled = true;
                    buttonItemPriceListPageListLast.Enabled = true;
                }
                else if (pageNumber == itemPriceListPageList.PageCount)
                {
                    buttonItemPriceListPageListFirst.Enabled = true;
                    buttonItemPriceListPageListPrevious.Enabled = true;
                    buttonItemPriceListPageListNext.Enabled = false;
                    buttonItemPriceListPageListLast.Enabled = false;
                }
                else
                {
                    buttonItemPriceListPageListFirst.Enabled = true;
                    buttonItemPriceListPageListPrevious.Enabled = true;
                    buttonItemPriceListPageListNext.Enabled = true;
                    buttonItemPriceListPageListLast.Enabled = true;
                }

                textBoxItemPriceListPageNumber.Text = pageNumber + " / " + itemPriceListPageList.PageCount;
                itemPriceListDataSource.DataSource = itemPriceListPageList;
            }
            else
            {
                buttonItemPriceListPageListFirst.Enabled = false;
                buttonItemPriceListPageListPrevious.Enabled = false;
                buttonItemPriceListPageListNext.Enabled = false;
                buttonItemPriceListPageListLast.Enabled = false;

                pageNumber = 1;

                itemPriceListData = new List<Entities.DgvItemDetailItemPriceListEntity>();
                itemPriceListDataSource.Clear();
                textBoxItemPriceListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvItemDetailItemPriceListEntity>> GetItemPriceListDataTask()
        {
            Controllers.MstArticlePriceController mstItemPriceController = new Controllers.MstArticlePriceController();
            List<Entities.MstArticlePriceEntity> listItemPrice = mstItemPriceController.ListItemPrice(mstItemEntity.Id);
            mstArticlePriceEntity = listItemPrice;
            if (listItemPrice.Any())
            {
                var itemPrices = from d in listItemPrice
                                 select new Entities.DgvItemDetailItemPriceListEntity
                                 {
                                     ColumnItemPriceListButtonEdit = "Edit",
                                     ColumnItemPriceListButtonDelete = "Delete",
                                     ColumnItemPriceListId = d.Id,
                                     ColumnItemPriceListPriceDescription = d.PriceDescription,
                                     ColumnItemPriceListPrice = d.Price.ToString("#,##0.00"),
                                 };

                return Task.FromResult(itemPrices.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvItemDetailItemPriceListEntity>());
            }
        }

        public void CreateItemPriceListDataGridView()
        {
            UpdateItemPriceListDataSource();

            dataGridViewItemPriceList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewItemPriceList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewItemPriceList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewItemPriceList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewItemPriceList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewItemPriceList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewItemPriceList.DataSource = itemPriceListDataSource;
        }

        private void textBoxItemPriceListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateItemPriceListDataSource();
            }
        }

        private void dataGridViewItemPriceList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetItemPriceListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewItemPriceList.CurrentCell.ColumnIndex == dataGridViewItemPriceList.Columns["ColumnItemPriceListButtonEdit"].Index)
            {
                Entities.MstArticlePriceEntity selectedItemPrice = new Entities.MstArticlePriceEntity()
                {
                    Id = Convert.ToInt32(dataGridViewItemPriceList.Rows[e.RowIndex].Cells[dataGridViewItemPriceList.Columns["ColumnItemPriceListId"].Index].Value),
                    ArticleId = Convert.ToInt32(dataGridViewItemPriceList.Rows[e.RowIndex].Cells[dataGridViewItemPriceList.Columns["ColumnItemPriceListArticleId"].Index].Value),
                    PriceDescription = dataGridViewItemPriceList.Rows[e.RowIndex].Cells[dataGridViewItemPriceList.Columns["ColumnItemPriceListPriceDescription"].Index].Value.ToString(),
                    Price = Convert.ToDecimal(dataGridViewItemPriceList.Rows[e.RowIndex].Cells[dataGridViewItemPriceList.Columns["ColumnItemPriceListPrice"].Index].Value),
                };

                MstArticlePriceDetailForm mstArticlePriceDetailForm = new MstArticlePriceDetailForm(this, selectedItemPrice, mstItemEntity.Id);
                mstArticlePriceDetailForm.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewItemPriceList.CurrentCell.ColumnIndex == dataGridViewItemPriceList.Columns["ColumnItemPriceListButtonDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete ItemPrice?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    Controllers.MstArticlePriceController mstItemPriceController = new Controllers.MstArticlePriceController();

                    String[] deleteItemPrice = mstItemPriceController.DeleteItemPrice(Convert.ToInt32(dataGridViewItemPriceList.Rows[e.RowIndex].Cells[2].Value));
                    if (deleteItemPrice[1].Equals("0") == false)
                    {
                        Int32 currentPageNumber = pageNumber;

                        pageNumber = 1;
                        UpdateItemPriceListDataSource();
                    }
                    else
                    {
                        MessageBox.Show(deleteItemPrice[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void GetItemPriceListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonItemPriceListPageListFirst_Click(object sender, EventArgs e)
        {
            itemPriceListPageList = new PagedList<Entities.DgvItemDetailItemPriceListEntity>(itemPriceListData, 1, pageSize);
            itemPriceListDataSource.DataSource = itemPriceListPageList;

            buttonItemPriceListPageListFirst.Enabled = false;
            buttonItemPriceListPageListPrevious.Enabled = false;
            buttonItemPriceListPageListNext.Enabled = true;
            buttonItemPriceListPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxItemPriceListPageNumber.Text = pageNumber + " / " + itemPriceListPageList.PageCount;
        }

        private void buttonItemPriceListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (itemPriceListPageList.HasPreviousPage == true)
            {
                itemPriceListPageList = new PagedList<Entities.DgvItemDetailItemPriceListEntity>(itemPriceListData, --pageNumber, pageSize);
                itemPriceListDataSource.DataSource = itemPriceListPageList;
            }

            buttonItemPriceListPageListNext.Enabled = true;
            buttonItemPriceListPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonItemPriceListPageListFirst.Enabled = false;
                buttonItemPriceListPageListPrevious.Enabled = false;
            }

            textBoxItemPriceListPageNumber.Text = pageNumber + " / " + itemPriceListPageList.PageCount;
        }

        private void buttonItemPriceListPageListNext_Click(object sender, EventArgs e)
        {
            if (itemPriceListPageList.HasNextPage == true)
            {
                itemPriceListPageList = new PagedList<Entities.DgvItemDetailItemPriceListEntity>(itemPriceListData, ++pageNumber, pageSize);
                itemPriceListDataSource.DataSource = itemPriceListPageList;
            }

            buttonItemPriceListPageListFirst.Enabled = true;
            buttonItemPriceListPageListPrevious.Enabled = true;

            if (pageNumber == itemPriceListPageList.PageCount)
            {
                buttonItemPriceListPageListNext.Enabled = false;
                buttonItemPriceListPageListLast.Enabled = false;
            }

            textBoxItemPriceListPageNumber.Text = pageNumber + " / " + itemPriceListPageList.PageCount;
        }

        private void buttonItemPriceListPageListLast_Click(object sender, EventArgs e)
        {
            itemPriceListPageList = new PagedList<Entities.DgvItemDetailItemPriceListEntity>(itemPriceListData, itemPriceListPageList.PageCount, pageSize);
            itemPriceListDataSource.DataSource = itemPriceListPageList;

            buttonItemPriceListPageListFirst.Enabled = true;
            buttonItemPriceListPageListPrevious.Enabled = true;
            buttonItemPriceListPageListNext.Enabled = false;
            buttonItemPriceListPageListLast.Enabled = false;

            pageNumber = itemPriceListPageList.PageCount;
            textBoxItemPriceListPageNumber.Text = pageNumber + " / " + itemPriceListPageList.PageCount;
        }

        private void buttonAddItemPrice_Click(object sender, EventArgs e)
        {
            MstArticlePriceDetailForm mstArticlePriceDetailForm = new MstArticlePriceDetailForm(this, null, mstItemEntity.Id);
            mstArticlePriceDetailForm.ShowDialog();
        }

        // ==============
        // Item Component
        // ==============

        public static List<Entities.DgvItemComponentEntity> itemComponentListData = new List<Entities.DgvItemComponentEntity>();
        public PagedList<Entities.DgvItemComponentEntity> itemComponentListPageList = new PagedList<Entities.DgvItemComponentEntity>(itemComponentListData, pageNumber, pageSize);
        public BindingSource itemComponentListDataSource = new BindingSource();

        private void buttonItemComponentAdd_Click(object sender, EventArgs e)
        {
            Entities.MstArticleComponentEntity newItemComponent = new Entities.MstArticleComponentEntity()
            {
                Id = 0,
                ItemId = mstItemEntity.Id,
                ComponentItemId = 0,
                Unit = "",
                Quantity = 0,
                Cost = 0,
                Amount = 0,
            };
            MstArticleComponentForm mstArticleComponentForm = new MstArticleComponentForm(this, newItemComponent);
            mstArticleComponentForm.ShowDialog();
        }


        public Task<List<Entities.DgvItemComponentEntity>> GetItemComponentListDataTask()
        {
            Controllers.MstArticleComponentController mstItemComponentController = new Controllers.MstArticleComponentController();
            List<Entities.MstArticleComponentEntity> listItemComponent = mstItemComponentController.ItemComponentList(mstItemEntity.Id);
            if (listItemComponent.Any())
            {
                var itemComponent = from d in listItemComponent
                                    select new Entities.DgvItemComponentEntity
                                    {
                                        ColumnItemComponentButtonEdit = "Edit",
                                        ColumnItemComponentButtonDelete = "Delete",
                                        ColumnItemComponentId = d.Id,
                                        ColumnItemComponentItemId = d.ItemId,
                                        ColumnItemComponenItemDescription = d.ItemDescription,
                                        ColumnItemComponentComponentItemId = d.ComponentItemId,
                                        ColumnItemComponentComponentItemDescription = d.ComponentItemDescription,
                                        ColumnItemComponenUnitId = d.UnitId,
                                        ColumnItemComponenUnit = d.Unit,
                                        ColumnItemComponenQuantity = d.Quantity.ToString("#,##0.00"),
                                        ColumnItemComponenCost = d.Cost.ToString("#,##0.00"),
                                        ColumnItemComponenAmount = d.Amount.ToString("#,##0.00"),
                                    };

                return Task.FromResult(itemComponent.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvItemComponentEntity>());
            }
        }

        public async void SetItemComponentListDataSourceAsync()
        {
            List<Entities.DgvItemComponentEntity> getItemComponentListData = await GetItemComponentListDataTask();
            if (getItemComponentListData.Any())
            {
                itemComponentListData = getItemComponentListData;
                itemComponentListPageList = new PagedList<Entities.DgvItemComponentEntity>(itemComponentListData, pageNumber, pageSize);

                if (itemComponentListPageList.PageCount == 1)
                {
                    buttonItemComponentListPageListFirst.Enabled = false;
                    buttonItemComponentListPageListPrevious.Enabled = false;
                    buttonItemComponentListPageListNext.Enabled = false;
                    buttonItemComponentListPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonItemComponentListPageListFirst.Enabled = false;
                    buttonItemComponentListPageListPrevious.Enabled = false;
                    buttonItemComponentListPageListNext.Enabled = true;
                    buttonItemComponentListPageListLast.Enabled = true;
                }
                else if (pageNumber == itemComponentListPageList.PageCount)
                {
                    buttonItemComponentListPageListFirst.Enabled = true;
                    buttonItemComponentListPageListPrevious.Enabled = true;
                    buttonItemComponentListPageListNext.Enabled = false;
                    buttonItemComponentListPageListLast.Enabled = false;
                }
                else
                {
                    buttonItemComponentListPageListFirst.Enabled = true;
                    buttonItemComponentListPageListPrevious.Enabled = true;
                    buttonItemComponentListPageListNext.Enabled = true;
                    buttonItemComponentListPageListLast.Enabled = true;
                }

                textBoxItemComponentListPageNumber.Text = pageNumber + " / " + itemComponentListPageList.PageCount;
                itemComponentListDataSource.DataSource = itemComponentListPageList;
            }
            else
            {
                buttonItemComponentListPageListFirst.Enabled = false;
                buttonItemComponentListPageListPrevious.Enabled = false;
                buttonItemComponentListPageListNext.Enabled = false;
                buttonItemComponentListPageListLast.Enabled = false;

                pageNumber = 1;

                itemComponentListData = new List<Entities.DgvItemComponentEntity>();
                itemComponentListDataSource.Clear();
                textBoxItemComponentListPageNumber.Text = "1 / 1";
            }
        }

        public void CreateItemComponentListDataGridView()
        {
            UpdateItemComponentListDataSource();

            dataGridViewItemComponentList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewItemComponentList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewItemComponentList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewItemComponentList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewItemComponentList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewItemComponentList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewItemComponentList.DataSource = itemComponentListDataSource;
        }

        public void UpdateItemComponentListDataSource()
        {
            SetItemComponentListDataSourceAsync();
        }

        private void dataGridViewItemComponentList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetItemComponentListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewItemComponentList.CurrentCell.ColumnIndex == dataGridViewItemComponentList.Columns["ColumnItemComponentButtonEdit"].Index)
            {
                Entities.MstArticleComponentEntity selectedItemComponent = new Entities.MstArticleComponentEntity()
                {
                    Id = Convert.ToInt32(dataGridViewItemComponentList.Rows[e.RowIndex].Cells[dataGridViewItemComponentList.Columns["ColumnItemComponentId"].Index].Value),
                    ItemId = Convert.ToInt32(dataGridViewItemComponentList.Rows[e.RowIndex].Cells[dataGridViewItemComponentList.Columns["ColumnItemComponentItemId"].Index].Value),
                    ComponentItemId = Convert.ToInt32(dataGridViewItemComponentList.Rows[e.RowIndex].Cells[dataGridViewItemComponentList.Columns["ColumnItemComponentComponentItemId"].Index].Value),
                    UnitId = Convert.ToInt32(dataGridViewItemComponentList.Rows[e.RowIndex].Cells[dataGridViewItemComponentList.Columns["ColumnItemComponenUnitId"].Index].Value),
                    Unit = dataGridViewItemComponentList.Rows[e.RowIndex].Cells[dataGridViewItemComponentList.Columns["ColumnItemComponenUnit"].Index].Value.ToString(),
                    Quantity = Convert.ToDecimal(dataGridViewItemComponentList.Rows[e.RowIndex].Cells[dataGridViewItemComponentList.Columns["ColumnItemComponenQuantity"].Index].Value),
                    Cost = Convert.ToDecimal(dataGridViewItemComponentList.Rows[e.RowIndex].Cells[dataGridViewItemComponentList.Columns["ColumnItemComponenCost"].Index].Value),
                    Amount = Convert.ToDecimal(dataGridViewItemComponentList.Rows[e.RowIndex].Cells[dataGridViewItemComponentList.Columns["ColumnItemComponenAmount"].Index].Value),
                };

                MstArticleComponentForm mstArticleComponentForm = new MstArticleComponentForm(this, selectedItemComponent);
                mstArticleComponentForm.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewItemComponentList.CurrentCell.ColumnIndex == dataGridViewItemComponentList.Columns["ColumnItemComponentButtonDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete Item Component?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    Controllers.MstArticleComponentController mstItemComponentController = new Controllers.MstArticleComponentController();

                    String[] deleteItemComponent = mstItemComponentController.DeleteItemComponent(Convert.ToInt32(dataGridViewItemComponentList.Rows[e.RowIndex].Cells[2].Value));
                    if (deleteItemComponent[1].Equals("0") == false)
                    {
                        Int32 currentPageNumber = pageNumber;

                        pageNumber = 1;
                        UpdateItemComponentListDataSource();
                    }
                    else
                    {
                        MessageBox.Show(deleteItemComponent[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void GetItemComponentListCurrentSelectedCell(Int32 id) { }

        private void buttonItemComponentListPageListFirst_Click(object sender, EventArgs e)
        {
            itemComponentListPageList = new PagedList<Entities.DgvItemComponentEntity>(itemComponentListData, 1, pageSize);
            itemComponentListDataSource.DataSource = itemComponentListPageList;

            buttonItemComponentListPageListFirst.Enabled = false;
            buttonItemComponentListPageListPrevious.Enabled = false;
            buttonItemComponentListPageListNext.Enabled = true;
            buttonItemComponentListPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxItemComponentListPageNumber.Text = pageNumber + " / " + itemComponentListPageList.PageCount;
        }

        private void buttonItemComponentListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (itemComponentListPageList.HasPreviousPage == true)
            {
                itemComponentListPageList = new PagedList<Entities.DgvItemComponentEntity>(itemComponentListData, --pageNumber, pageSize);
                itemComponentListDataSource.DataSource = itemComponentListPageList;
            }

            buttonItemComponentListPageListNext.Enabled = true;
            buttonItemComponentListPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonItemComponentListPageListFirst.Enabled = false;
                buttonItemComponentListPageListPrevious.Enabled = false;
            }

            textBoxItemComponentListPageNumber.Text = pageNumber + " / " + itemComponentListPageList.PageCount;
        }

        private void buttonItemComponentListPageListNext_Click(object sender, EventArgs e)
        {
            if (itemComponentListPageList.HasNextPage == true)
            {
                itemComponentListPageList = new PagedList<Entities.DgvItemComponentEntity>(itemComponentListData, ++pageNumber, pageSize);
                itemComponentListDataSource.DataSource = itemComponentListPageList;
            }

            buttonItemComponentListPageListFirst.Enabled = true;
            buttonItemComponentListPageListPrevious.Enabled = true;

            if (pageNumber == itemComponentListPageList.PageCount)
            {
                buttonItemComponentListPageListNext.Enabled = false;
                buttonItemComponentListPageListLast.Enabled = false;
            }

            textBoxItemComponentListPageNumber.Text = pageNumber + " / " + itemComponentListPageList.PageCount;
        }

        private void buttonItemComponentListPageListLast_Click(object sender, EventArgs e)
        {
            itemComponentListPageList = new PagedList<Entities.DgvItemComponentEntity>(itemComponentListData, itemComponentListPageList.PageCount, pageSize);
            itemComponentListDataSource.DataSource = itemComponentListPageList;

            buttonItemComponentListPageListFirst.Enabled = true;
            buttonItemComponentListPageListPrevious.Enabled = true;
            buttonItemComponentListPageListNext.Enabled = false;
            buttonItemComponentListPageListLast.Enabled = false;

            pageNumber = itemComponentListPageList.PageCount;
            textBoxItemComponentListPageNumber.Text = pageNumber + " / " + itemComponentListPageList.PageCount;
        }

        //===============
        // Item Inventory
        //===============

        public static List<Entities.DgvItemInventoryEntity> itemInventoryListData = new List<Entities.DgvItemInventoryEntity>();
        public PagedList<Entities.DgvItemInventoryEntity> itemInventoryListPageList = new PagedList<Entities.DgvItemInventoryEntity>(itemInventoryListData, pageNumber, pageSize);
        public BindingSource itemInventoryListDataSource = new BindingSource();

        public Task<List<Entities.DgvItemInventoryEntity>> GetItemInventoryListDataTask()
        {
            Controllers.MstArticleInventoryController mstItemInventoryController = new Controllers.MstArticleInventoryController();
            List<Entities.MstArticleInventoryEntity> listItemInventory = mstItemInventoryController.ListItemInventory(mstItemEntity.Id);
            if (listItemInventory.Any())
            {
                var itemComponent = from d in listItemInventory
                                    select new Entities.DgvItemInventoryEntity
                                    {
                                        ColumnItemInventoryButtonEdit = "Edit",
                                        ColumnItemInventoryId = d.Id,
                                        ColumnItemInventoryBranchId = d.ItemId,
                                        ColumnItemInventoryBranchCode = d.BranchCode,
                                        ColumnItemInventoryInventoryCode = d.InventoryCode,
                                        ColumnItemInventoryItemId = d.ItemId,
                                        ColumnItemInventoryQuantity = d.Quantity.ToString("#,##0.00"),
                                        ColumnItemInventoryCost1 = d.Cost1.ToString("#,##0.00"),
                                        ColumnItemInventoryCost2 = d.Cost2.ToString("#,##0.00"),
                                        ColumnItemInventoryCost3 = d.Cost3.ToString("#,##0.00"),
                                        ColumnItemInventoryCost4 = d.Cost4.ToString("#,##0.00"),
                                        ColumnItemInventoryCost5 = d.Cost5.ToString("#,##0.00"),
                                    };

                return Task.FromResult(itemComponent.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvItemInventoryEntity>());
            }
        }

        public async void SetItemInventoryListDataSourceAsync()
        {
            List<Entities.DgvItemInventoryEntity> getItemInventoryListData = await GetItemInventoryListDataTask();
            if (getItemInventoryListData.Any())
            {
                itemInventoryListData = getItemInventoryListData;
                itemInventoryListPageList = new PagedList<Entities.DgvItemInventoryEntity>(itemInventoryListData, pageNumber, pageSize);

                if (itemInventoryListPageList.PageCount == 1)
                {
                    buttonItemInventoryListPageListFirst.Enabled = false;
                    buttonItemInventoryListPageListPrevious.Enabled = false;
                    buttonItemInventoryListPageListNext.Enabled = false;
                    buttonItemInventoryListPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonItemInventoryListPageListFirst.Enabled = false;
                    buttonItemInventoryListPageListPrevious.Enabled = false;
                    buttonItemInventoryListPageListNext.Enabled = true;
                    buttonItemInventoryListPageListLast.Enabled = true;
                }
                else if (pageNumber == itemInventoryListPageList.PageCount)
                {
                    buttonItemInventoryListPageListFirst.Enabled = true;
                    buttonItemInventoryListPageListPrevious.Enabled = true;
                    buttonItemInventoryListPageListNext.Enabled = false;
                    buttonItemInventoryListPageListLast.Enabled = false;
                }
                else
                {
                    buttonItemInventoryListPageListFirst.Enabled = true;
                    buttonItemInventoryListPageListPrevious.Enabled = true;
                    buttonItemInventoryListPageListNext.Enabled = true;
                    buttonItemInventoryListPageListLast.Enabled = true;
                }

                textBoxItemInventoryListPageNumber.Text = pageNumber + " / " + itemInventoryListPageList.PageCount;
                itemInventoryListDataSource.DataSource = itemInventoryListPageList;
            }
            else
            {
                buttonItemInventoryListPageListFirst.Enabled = false;
                buttonItemInventoryListPageListPrevious.Enabled = false;
                buttonItemInventoryListPageListNext.Enabled = false;
                buttonItemInventoryListPageListLast.Enabled = false;

                pageNumber = 1;

                itemInventoryListData = new List<Entities.DgvItemInventoryEntity>();
                itemInventoryListDataSource.Clear();
                textBoxItemInventoryListPageNumber.Text = "1 / 1";
            }
        }

        public void CreateItemInventoryListDataGridView()
        {
            UpdateItemInventoryListDataSource();

            dataGridViewItemInventoryList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewItemInventoryList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewItemInventoryList.Columns[0].DefaultCellStyle.ForeColor = Color.White;
            dataGridViewItemInventoryList.DataSource = itemInventoryListDataSource;
        }

        public void UpdateItemInventoryListDataSource()
        {
            SetItemInventoryListDataSourceAsync();
        }

        private void dataGridViewItemInventoryList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetItemInventoryCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewItemInventoryList.CurrentCell.ColumnIndex == dataGridViewItemInventoryList.Columns["ColumnItemInventoryButtonEdit"].Index)
            {
                Entities.MstArticleInventoryEntity selectedArticleInventory = new Entities.MstArticleInventoryEntity()
                {
                    Id = Convert.ToInt32(dataGridViewItemInventoryList.Rows[e.RowIndex].Cells[dataGridViewItemInventoryList.Columns["ColumnItemInventoryId"].Index].Value),
                    BranchId = Convert.ToInt32(dataGridViewItemInventoryList.Rows[e.RowIndex].Cells[dataGridViewItemInventoryList.Columns["ColumnItemInventoryBranchId"].Index].Value),
                    BranchCode = dataGridViewItemInventoryList.Rows[e.RowIndex].Cells[dataGridViewItemInventoryList.Columns["ColumnItemInventoryBranchCode"].Index].Value.ToString(),
                    InventoryCode = dataGridViewItemInventoryList.Rows[e.RowIndex].Cells[dataGridViewItemInventoryList.Columns["ColumnItemInventoryInventoryCode"].Index].Value.ToString(),
                    ItemId = Convert.ToInt32(dataGridViewItemInventoryList.Rows[e.RowIndex].Cells[dataGridViewItemInventoryList.Columns["ColumnItemInventoryItemId"].Index].Value),
                    Quantity = Convert.ToDecimal(dataGridViewItemInventoryList.Rows[e.RowIndex].Cells[dataGridViewItemInventoryList.Columns["ColumnItemInventoryQuantity"].Index].Value),
                    Cost1 = Convert.ToDecimal(dataGridViewItemInventoryList.Rows[e.RowIndex].Cells[dataGridViewItemInventoryList.Columns["ColumnItemInventoryCost1"].Index].Value),
                    Cost2 = Convert.ToDecimal(dataGridViewItemInventoryList.Rows[e.RowIndex].Cells[dataGridViewItemInventoryList.Columns["ColumnItemInventoryCost2"].Index].Value),
                    Cost3 = Convert.ToDecimal(dataGridViewItemInventoryList.Rows[e.RowIndex].Cells[dataGridViewItemInventoryList.Columns["ColumnItemInventoryCost3"].Index].Value),
                    Cost4 = Convert.ToDecimal(dataGridViewItemInventoryList.Rows[e.RowIndex].Cells[dataGridViewItemInventoryList.Columns["ColumnItemInventoryCost4"].Index].Value),
                    Cost5 = Convert.ToDecimal(dataGridViewItemInventoryList.Rows[e.RowIndex].Cells[dataGridViewItemInventoryList.Columns["ColumnItemInventoryCost5"].Index].Value),
                };

                MstArticleInventoryDetail mstArticleInventoryDetail = new MstArticleInventoryDetail(this, selectedArticleInventory);
                mstArticleInventoryDetail.ShowDialog();
            }
        }

        public void GetItemInventoryCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonItemInventoryListPageListFirst_Click(object sender, EventArgs e)
        {
            itemInventoryListPageList = new PagedList<Entities.DgvItemInventoryEntity>(itemInventoryListData, 1, pageSize);
            itemInventoryListDataSource.DataSource = itemInventoryListPageList;

            buttonItemInventoryListPageListFirst.Enabled = false;
            buttonItemInventoryListPageListPrevious.Enabled = false;
            buttonItemInventoryListPageListNext.Enabled = true;
            buttonItemInventoryListPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxItemInventoryListPageNumber.Text = pageNumber + " / " + itemInventoryListPageList.PageCount;
        }

        private void buttonItemInventoryListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (itemInventoryListPageList.HasPreviousPage == true)
            {
                itemInventoryListPageList = new PagedList<Entities.DgvItemInventoryEntity>(itemInventoryListData, --pageNumber, pageSize);
                itemInventoryListDataSource.DataSource = itemInventoryListPageList;
            }

            buttonItemInventoryListPageListNext.Enabled = true;
            buttonItemInventoryListPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonItemInventoryListPageListFirst.Enabled = false;
                buttonItemInventoryListPageListPrevious.Enabled = false;
            }

            textBoxItemInventoryListPageNumber.Text = pageNumber + " / " + itemInventoryListPageList.PageCount;
        }

        private void buttonItemInventoryListPageListNext_Click(object sender, EventArgs e)
        {
            if (itemInventoryListPageList.HasNextPage == true)
            {
                itemInventoryListPageList = new PagedList<Entities.DgvItemInventoryEntity>(itemInventoryListData, ++pageNumber, pageSize);
                itemInventoryListDataSource.DataSource = itemInventoryListPageList;
            }

            buttonItemInventoryListPageListFirst.Enabled = true;
            buttonItemInventoryListPageListPrevious.Enabled = true;

            if (pageNumber == itemInventoryListPageList.PageCount)
            {
                buttonItemInventoryListPageListNext.Enabled = false;
                buttonItemInventoryListPageListLast.Enabled = false;
            }

            textBoxItemInventoryListPageNumber.Text = pageNumber + " / " + itemInventoryListPageList.PageCount;
        }

        private void buttonItemInventoryListPageListLast_Click(object sender, EventArgs e)
        {
            itemInventoryListPageList = new PagedList<Entities.DgvItemInventoryEntity>(itemInventoryListData, itemInventoryListPageList.PageCount, pageSize);
            itemInventoryListDataSource.DataSource = itemInventoryListPageList;

            buttonItemInventoryListPageListFirst.Enabled = true;
            buttonItemInventoryListPageListPrevious.Enabled = true;
            buttonItemInventoryListPageListNext.Enabled = false;
            buttonItemInventoryListPageListLast.Enabled = false;

            pageNumber = itemInventoryListPageList.PageCount;
            textBoxItemInventoryListPageNumber.Text = pageNumber + " / " + itemInventoryListPageList.PageCount;
        }

        private void comboBoxUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mstItemEntity.UnitId != Convert.ToInt32(comboBoxUnit.SelectedValue))
            {
                mstItemEntity.UnitId = Convert.ToInt32(comboBoxUnit.SelectedValue);
            }
        }

    }
}
