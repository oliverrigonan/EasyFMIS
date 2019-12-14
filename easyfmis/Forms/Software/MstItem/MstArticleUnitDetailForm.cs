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
        static Int32 articleId = 0;
        public MstArticleUnitDetailForm(MstItemDetailForm itemDetailForm, Entities.MstArticleUnitEntity articleUnitEntity, Int32 itemId)
        {
            InitializeComponent();
            mstItemDetailForm = itemDetailForm;
            mstArticleUnitEntity = articleUnitEntity;

            articleId = itemId;

            GetUnitList();
        }

        public void GetUnitList()
        {
            Controllers.MstArticleUnitController mstArticleUnitController = new Controllers.MstArticleUnitController();
            if (mstArticleUnitController.DropDownListUnit().Any())
            {
                comboBoxUnit.DataSource = mstArticleUnitController.DropDownListUnit();
                comboBoxUnit.ValueMember = "Id";
                comboBoxUnit.DisplayMember = "Unit";
            }
            LoadArticleUnit();
        }

        public void LoadArticleUnit(){
            if (mstArticleUnitEntity != null) {
                textBoxBaseUnitMultiplier.Text = mstArticleUnitEntity.BaseUnitMultiplier.ToString("#,##0.00");
                textBoxUnitMultiplier.Text = mstArticleUnitEntity.UnitMultiplier.ToString("#,##0.00");
                comboBoxUnit.SelectedValue = mstArticleUnitEntity.UnitId;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (mstArticleUnitEntity == null)
            {
                Entities.MstArticleUnitEntity newArticleUnit = new Entities.MstArticleUnitEntity()
                {
                    ArticleId = articleId,
                    BaseUnitMultiplier = Convert.ToDecimal(textBoxBaseUnitMultiplier.Text),
                    UnitMultiplier = Convert.ToDecimal(textBoxUnitMultiplier.Text),
                    UnitId = Convert.ToInt32(comboBoxUnit.SelectedValue)
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
                mstArticleUnitEntity.UnitId = Convert.ToInt32(comboBoxUnit.SelectedValue);
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
    }
}
