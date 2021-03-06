﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software.TrnDisbursement
{
    public partial class TrnDisbursementDetailDisbursementLineDetailForm : Form
    {
        public TrnDisbursementDetailForm trnDisbursementDetailForm;
        public Entities.TrnDisbursementLineEntity trnDisbursementLineEntity;
        public Entities.TrnDisbursementEntity trnDisbursementEntity;
        public Int32 disbursementId;

        public TrnDisbursementDetailDisbursementLineDetailForm(TrnDisbursementDetailForm disbursementDetailForm, Entities.TrnDisbursementLineEntity disbursementLineEntity, Entities.TrnDisbursementEntity disbursementEntity)
        {
            InitializeComponent();

            trnDisbursementDetailForm = disbursementDetailForm;
            trnDisbursementLineEntity = disbursementLineEntity;
            trnDisbursementEntity = disbursementEntity;

            GetArticleGroupList();

        }

        public void GetArticleGroupList()
        {
            Controllers.TrnDisbursementLineController trnDisbursementLineController = new Controllers.TrnDisbursementLineController();
            var articleGroup = trnDisbursementLineController.DropDownArticleGroup();
            if (articleGroup.Any())
            {
                comboBoxArticleGroup.DataSource = articleGroup;
                comboBoxArticleGroup.ValueMember = "Id";
                comboBoxArticleGroup.DisplayMember = "ArticleGroup";

                GetDisbursementLineDetail();
            }
        }

        public void GetDisbursementLineDetail()
        {
            if (trnDisbursementLineEntity != null)
            {
                textBoxRRNumber.Text = trnDisbursementLineEntity.RRNumber;
                textBoxAmount.Text = trnDisbursementLineEntity.Amount.ToString("#,##0.00");
                textBoxOtherInformation.Text = trnDisbursementLineEntity.OtherInformation;
            }
            if (trnDisbursementLineEntity.ArticleGroupId != 0)
            {
                comboBoxArticleGroup.SelectedValue = trnDisbursementLineEntity.ArticleGroupId;
            }
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            SavePurchaseOrderItem();
        }

        public void SavePurchaseOrderItem()
        {
            Controllers.TrnDisbursementLineController trnDisbursementLineController = new Controllers.TrnDisbursementLineController();
            if (trnDisbursementLineEntity.Id == 0)
            {
                Entities.TrnDisbursementLineEntity newDisbursementLineEntity = new Entities.TrnDisbursementLineEntity()
                {
                    CVId = trnDisbursementEntity.Id,
                    ArticleGroupId = Convert.ToInt32(comboBoxArticleGroup.SelectedValue),
                    RRId = trnDisbursementLineEntity.RRId,
                    Amount = Convert.ToDecimal(textBoxAmount.Text),
                    OtherInformation = textBoxOtherInformation.Text
                };

                String[] addDisbursementLine = trnDisbursementLineController.AddDisbursementLine(newDisbursementLineEntity);
                if (addDisbursementLine[1].Equals("0") == false)
                {
                    trnDisbursementDetailForm.UpdateDisbursementLineDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(addDisbursementLine[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Entities.TrnDisbursementLineEntity updateDisbursementLineEntity = new Entities.TrnDisbursementLineEntity()
                {
                    Id = trnDisbursementLineEntity.Id,
                    CVId = trnDisbursementEntity.Id,
                    ArticleGroupId = Convert.ToInt32(comboBoxArticleGroup.SelectedValue),
                    RRId = trnDisbursementLineEntity.RRId,
                    Amount = Convert.ToDecimal(textBoxAmount.Text),
                    OtherInformation = textBoxOtherInformation.Text
                };

                String[] updateDisbursementLine = trnDisbursementLineController.UpdateDisbursementLine(trnDisbursementLineEntity.Id, updateDisbursementLineEntity);
                if (updateDisbursementLine[1].Equals("0") == false)
                {
                    trnDisbursementDetailForm.UpdateDisbursementLineDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(updateDisbursementLine[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void textBoxAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxAmount_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxAmount.Text))
            {
                textBoxAmount.Text = "0.00";
            }
        }

        private void textBoxAmount_Leave(object sender, EventArgs e)
        {
            textBoxAmount.Text = Convert.ToDecimal(textBoxAmount.Text).ToString("#,##0.00");
        }
    }
}
