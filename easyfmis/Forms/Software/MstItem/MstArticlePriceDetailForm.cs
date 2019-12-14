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
    public partial class MstArticlePriceDetailForm : Form
    {
        MstItemDetailForm mstItemDetailForm;
        Entities.MstArticlePriceEntity mstArticlePriceEntity;
        Int32 articleId = 0;

        public MstArticlePriceDetailForm(MstItemDetailForm itemDetailForm, Entities.MstArticlePriceEntity articlePriceEntity, Int32 itemId)
        {
            InitializeComponent();
            mstItemDetailForm = itemDetailForm;
            mstArticlePriceEntity = articlePriceEntity;
            articleId = itemId;

            LoadItemPrice();
        }

        public void LoadItemPrice()
        {
            if (mstArticlePriceEntity != null)
            {
                textBoxPriceDescription.Text = mstArticlePriceEntity.PriceDescription;
                textBoxPrice.Text = mstArticlePriceEntity.Price.ToString("#,##0.00");
            }
            else
            {
                textBoxPriceDescription.Text = "";
                textBoxPrice.Text = "0.00";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            

            if (mstArticlePriceEntity == null)
            {
                Entities.MstArticlePriceEntity newItemPrice = new Entities.MstArticlePriceEntity()
                {
                    ArticleId = articleId,
                    PriceDescription = textBoxPriceDescription.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                };

                Controllers.MstArticlePriceController mstArticlePriceController = new Controllers.MstArticlePriceController();
                String[] addItemPrice = mstArticlePriceController.AddItemPrice(newItemPrice);

                if (addItemPrice[1].Equals("0") == true)
                {
                    MessageBox.Show(addItemPrice[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    mstItemDetailForm.UpdateItemPriceListDataSource();
                    Close();
                }
            }
            else
            {
                mstArticlePriceEntity.PriceDescription= textBoxPriceDescription.Text;
                mstArticlePriceEntity.Price = Convert.ToDecimal(textBoxPrice.Text);
                Controllers.MstArticlePriceController mstArticlePriceController = new Controllers.MstArticlePriceController();

                String[] updateItemPrice = mstArticlePriceController.UpdateItemPrice(mstArticlePriceEntity);

                if (updateItemPrice[1].Equals("0") == true)
                {
                    MessageBox.Show(updateItemPrice[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    mstItemDetailForm.UpdateItemPriceListDataSource();
                    Close();
                }
            }
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
    }
}
