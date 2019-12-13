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

        public void GetUnitList()
        {
            Controllers.MstArticleController mstItemController = new Controllers.MstArticleController();
            if (mstItemController.DropdownListItemUnit().Any())
            {
                comboBoxUnit.DataSource = mstItemController.DropdownListItemUnit();
                comboBoxUnit.ValueMember = "Id";
                comboBoxUnit.DisplayMember = "Unit";

                GetSupplierList();
            }
        }
    }
}
