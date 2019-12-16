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
    public partial class MstArticleInventoryDetail : Form
    {
        MstItemDetailForm mstItemDetailForm;
        Entities.MstArticleInventoryEntity mstArticleInventoryEntity;

        public MstArticleInventoryDetail(MstItemDetailForm itemDetailForm, Entities.MstArticleInventoryEntity articleInventoryEntity)
        {
            InitializeComponent();
            mstItemDetailForm = itemDetailForm;
            mstArticleInventoryEntity = articleInventoryEntity;
            LoadComponent();
        }

        public void LoadComponent() {
            textBoxBranchCode.Text = mstArticleInventoryEntity.BranchCode;
            textBoxInventoryCode.Text = mstArticleInventoryEntity.InventoryCode;
            textBoxQuantity.Text = mstArticleInventoryEntity.Quantity.ToString("#,##0.00");
            textBoxCost1.Text = mstArticleInventoryEntity.Cost1.ToString("#,##0.00");
            textBoxCost2.Text = mstArticleInventoryEntity.Cost2.ToString("#,##0.00");
            textBoxCost3.Text = mstArticleInventoryEntity.Cost3.ToString("#,##0.00");
            textBoxCost4.Text = mstArticleInventoryEntity.Cost4.ToString("#,##0.00");
            textBoxCost5.Text = mstArticleInventoryEntity.Cost5.ToString("#,##0.00");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            mstArticleInventoryEntity.Quantity = Convert.ToDecimal(textBoxQuantity.Text);
            mstArticleInventoryEntity.Cost1 = Convert.ToDecimal(textBoxCost1.Text);
            mstArticleInventoryEntity.Cost2 = Convert.ToDecimal(textBoxCost2.Text);
            mstArticleInventoryEntity.Cost3 = Convert.ToDecimal(textBoxCost3.Text);
            mstArticleInventoryEntity.Cost4 = Convert.ToDecimal(textBoxCost4.Text);
            mstArticleInventoryEntity.Cost5 = Convert.ToDecimal(textBoxCost5.Text);

            Controllers.MstArticleInventoryController mstArticleInventoryController = new Controllers.MstArticleInventoryController();
            String[] updateItemInventory = mstArticleInventoryController.UpdateItemInventory(mstArticleInventoryEntity);

            if (updateItemInventory[1].Equals("0") == true)
            {
                MessageBox.Show(updateItemInventory[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                mstItemDetailForm.UpdateItemInventoryListDataSource();
                Close();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
