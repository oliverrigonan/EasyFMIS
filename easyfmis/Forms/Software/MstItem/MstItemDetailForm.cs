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

        public MstItemDetailForm(SysSoftwareForm softwareForm, MstItemListForm itemListForm, Entities.MstArticleEntity itemEntity)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            mstItemListForm = itemListForm;
            mstItemEntity = itemEntity;
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
                comboBoxDefaultSupplier.DisplayMember = "TaxCode";

            }
        }

        public void GetItemDetail()
        {
            UpdateComponents(mstItemEntity.IsLocked);

            textBoxItemCode.Text = mstItemEntity.ArticleCode;
            textBoxBarcode.Text = mstItemEntity.ArticleBarCode;
            textBoxDescription.Text = mstItemEntity.Article;
            textBoxAlias.Text = mstItemEntity.ArticleAlias;
            textBoxCategory.Text = mstItemEntity.Category;
            comboBoxVATInTax.SelectedValue = mstItemEntity.VATInTaxId;
            comboBoxVATOutTax.SelectedValue = mstItemEntity.VATOutTaxId;
            comboBoxUnit.SelectedValue = mstItemEntity.UnitId;
            comboBoxDefaultSupplier.SelectedValue = mstItemEntity.DefaultSupplierId;
            textBoxCost.Text = mstItemEntity.DefaultCost.ToString("#,##0.00");
            textBoxPrice.Text = mstItemEntity.DefaultPrice.ToString("#,##0.00"); ;
            textBoxReorderQuantity.Text = mstItemEntity.ReorderQuantity.ToString("#,##0.00"); ;
            checkBoxIsInventory.Checked = mstItemEntity.IsInventory;
            textBoxGenericName.Text = mstItemEntity.GenericArticleName;
            textBoxRemarks.Text = mstItemEntity.Remarks;

        }

        public void UpdateComponents(Boolean isLocked)
        {
 
            buttonLock.Enabled = !isLocked;
            buttonUnlock.Enabled = isLocked;

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

            //CreateItemPriceListDataGridView();

            //CreateItemComponentListDataGridView();
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            Controllers.MstArticleController mstItemController = new Controllers.MstArticleController();

            mstItemEntity.ArticleCode = textBoxItemCode.Text;
            mstItemEntity.ArticleBarCode = textBoxBarcode.Text;
            mstItemEntity.Article= textBoxDescription.Text;
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
    }
}
