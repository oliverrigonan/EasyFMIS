using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software.MstCompany
{
    public partial class MstCompanyDetailBranchDetailForm : Form
    {
        public MstCompanyDetailForm mstCompanyDetailForm;

        public Entities.MstBranchEntity mstBranchEntity;

        public Int32 companyId;

        public MstCompanyDetailBranchDetailForm(MstCompanyDetailForm companyDetailForm, Entities.MstBranchEntity branchEntity, Int32 _companyId)
        {
            InitializeComponent();

            mstCompanyDetailForm = companyDetailForm;
            mstBranchEntity = branchEntity;
            companyId = _companyId;

            GetBranchDetail();
        }

        public void GetBranchDetail()
        {
            if (mstBranchEntity != null)
            {
                textBoxBranchCode.Text = mstBranchEntity.BranchCode;
                textBoxBranch.Text = mstBranchEntity.Branch;
            }

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Controllers.MstBranchController mstBranchController = new Controllers.MstBranchController();
            if (mstBranchEntity == null)
            {
                Entities.MstBranchEntity newBranchEntity = new Entities.MstBranchEntity()
                {
                    BranchCode = textBoxBranchCode.Text,
                    Branch = textBoxBranch.Text,
                    CompanyId = companyId
                };
                String[] addBranch = mstBranchController.AddBranch(newBranchEntity);
                if (addBranch[1].Equals("0") == false)
                {
                    mstCompanyDetailForm.UpdateCompanyListDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(addBranch[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                mstBranchEntity.BranchCode = textBoxBranchCode.Text;
                mstBranchEntity.Branch = textBoxBranch.Text;
                String[] updateBranch = mstBranchController.UpdateBranch(mstBranchEntity);
                if (updateBranch[1].Equals("0") == false)
                {
                    mstCompanyDetailForm.UpdateCompanyListDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(updateBranch[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
