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
    public partial class MstArticleUnitDetailForm : Form
    {
        MstItemDetailForm mstItemDetailForm;
        Entities.MstArticleUnitEntity mstArticleUnitEntity;
        Entities.MstArticleEntity itemArticleEntity;
        static Int32 articleId = 0;
        public MstArticleUnitDetailForm(MstItemDetailForm itemDetailForm, Entities.MstArticleUnitEntity articleUnitEntity, Entities.MstArticleEntity mstItemArticleEntity)
        {
            InitializeComponent();
            mstItemDetailForm = itemDetailForm;
            mstArticleUnitEntity = articleUnitEntity;

            itemArticleEntity = mstItemArticleEntity;

            GetUnitList();
        }

        public void GetUnitList()
        {
            Controllers.MstArticleUnitController mstArticleUnitController = new Controllers.MstArticleUnitController();
            if (mstArticleUnitController.DropDownListUnit().Any())
            {
                comboBoxBaseUnit.DataSource = mstArticleUnitController.DropDownListUnit();
                comboBoxBaseUnit.ValueMember = "Id";
                comboBoxBaseUnit.DisplayMember = "Unit";
            }

            if (mstArticleUnitController.DropDownListUnit().Any())
            {
                comboBoxConvertedUnit.DataSource = mstArticleUnitController.DropDownListUnit();
                comboBoxConvertedUnit.ValueMember = "Id";
                comboBoxConvertedUnit.DisplayMember = "Unit";
            }

            LoadArticleUnit();
        }

        public void LoadArticleUnit(){
            if (mstArticleUnitEntity != null)
            {
                textBoxBaseUnitMultiplier.Text = mstArticleUnitEntity.BaseUnitMultiplier.ToString("#,##0.00");
                textBoxUnitMultiplier.Text = mstArticleUnitEntity.UnitMultiplier.ToString("#,##0.00");
                comboBoxBaseUnit.SelectedValue = itemArticleEntity.UnitId;
                comboBoxConvertedUnit.SelectedValue = mstArticleUnitEntity.UnitId;
            }
            else
            {
                textBoxBaseUnitMultiplier.Text = (0).ToString("#,##0.00");
                textBoxUnitMultiplier.Text = (0).ToString("#,##0.00");

            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (mstArticleUnitEntity == null)
            {
                Entities.MstArticleUnitEntity newArticleUnit = new Entities.MstArticleUnitEntity()
                {
                    ArticleId = itemArticleEntity.Id,
                    BaseUnitMultiplier = Convert.ToDecimal(textBoxBaseUnitMultiplier.Text),
                    UnitMultiplier = Convert.ToDecimal(textBoxUnitMultiplier.Text),
                    UnitId = Convert.ToInt32(comboBoxConvertedUnit.SelectedValue)
                };

                Controllers.MstArticleUnitController mstArticleUnitController = new Controllers.MstArticleUnitController();
                String[] addArticleUnit = mstArticleUnitController.AddArticleUnit(newArticleUnit);
                if (addArticleUnit[1].Equals("0") == true)
                {
                    MessageBox.Show(addArticleUnit[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    mstItemDetailForm.UpdateArticleUnitListDataSource();
                    Close();
                }
            }
            else
            {
                mstArticleUnitEntity.BaseUnitMultiplier = Convert.ToDecimal(textBoxBaseUnitMultiplier.Text);
                mstArticleUnitEntity.UnitMultiplier = Convert.ToDecimal(textBoxUnitMultiplier.Text);
                mstArticleUnitEntity.UnitId = Convert.ToInt32(comboBoxConvertedUnit.SelectedValue);

                Controllers.MstArticleUnitController mstArticleUnitController = new Controllers.MstArticleUnitController();

                String[] updatArticleUnit = mstArticleUnitController.UpdateArticleUnit(mstArticleUnitEntity);
                if (updatArticleUnit[1].Equals("0") == true)
                {
                    MessageBox.Show(updatArticleUnit[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    mstItemDetailForm.UpdateArticleUnitListDataSource();
                    Close();
                }

            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxBaseUnitMultiplier_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxBaseUnitMultiplie_Leave(object sender, EventArgs e)
        {
            textBoxBaseUnitMultiplier.Text = Convert.ToDecimal(textBoxBaseUnitMultiplier.Text).ToString("#,##0.00");
        }

        private void textBoxUnitMultiplier_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxUnitMultiplier_Leave(object sender, EventArgs e)
        {
            textBoxUnitMultiplier.Text = Convert.ToDecimal(textBoxUnitMultiplier.Text).ToString("#,##0.00");
        }
    }
}
