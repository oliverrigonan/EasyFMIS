using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software.TrnSalesInvoice
{
    public partial class TrnSalesInvoiceDetailDiscountForm : Form
    {
        public TrnSalesInvoiceDetailForm trnSalesInvoiceDetailForm;
        public Entities.TrnSalesInvoiceEntity trnSalesInvoiceEntity;

        public TrnSalesInvoiceDetailDiscountForm(TrnSalesInvoiceDetailForm salesInvoiceDetailForm, Entities.TrnSalesInvoiceEntity salesInvoiceEntity)
        {
            InitializeComponent();

            trnSalesInvoiceDetailForm = salesInvoiceDetailForm;
            trnSalesInvoiceEntity = salesInvoiceEntity;

            GetDiscount();
        }

        public void GetDiscount()
        {
            Controllers.TrnSalesInvoiceItemController trnSalesInvoiceItemController = new Controllers.TrnSalesInvoiceItemController();
            if (trnSalesInvoiceItemController.DropdownListSalesInvoiceDiscount().Any())
            {
                comboBoxDiscount.DataSource = trnSalesInvoiceItemController.DropdownListSalesInvoiceDiscount();
                comboBoxDiscount.ValueMember = "Id";
                comboBoxDiscount.DisplayMember = "Discount";
            }
        }

        private void comboBoxDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDiscount.SelectedItem == null)
            {
                return;
            }

            var selectedItem = (Entities.MstDiscountEntity)comboBoxDiscount.SelectedItem;
            if (selectedItem != null)
            {
                textBoxDiscountRate.Text = selectedItem.DiscountRate.ToString("#,##0.00");
            }
        }

        public void GetSalesDiscountInformation()
        {
            //Controllers.TrnSalesController trnSalesController = new Controllers.TrnSalesController();

            Int32? discountId = null;
            String seniorCitizenID = "";

            //if (trnSalesInvoiceDetailForm != null)
            //{
            //    discountId = trnSalesController.DiscountDetailSales(trnSalesInvoiceDetailForm.trnSalesEntity.Id).DiscountId;
            //    seniorCitizenID = trnSalesController.DiscountDetailSales(trnSalesInvoiceDetailForm.trnSalesEntity.Id).SeniorCitizenId;
            //    seniorCitizenName = trnSalesController.DiscountDetailSales(trnSalesInvoiceDetailForm.trnSalesEntity.Id).SeniorCitizenName;
            //    seniorCitizenAge = trnSalesController.DiscountDetailSales(trnSalesInvoiceDetailForm.trnSalesEntity.Id).SeniorCitizenAge.ToString();
            //}

            if (discountId != null)
            {
                comboBoxDiscount.SelectedValue = discountId;
                textBoxDiscountRate.Text = seniorCitizenID;
               
            }
            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Int32 discountId = Convert.ToInt32(comboBoxDiscount.SelectedValue);
            Decimal discountRate = Convert.ToDecimal(textBoxDiscountRate.Text);

            Entities.MstDiscountEntity discountEntity = new Entities.MstDiscountEntity()
            {
                Id = discountId,
                DiscountRate = discountRate
            };

            Controllers.TrnSalesInvoiceItemController trnSalesInvoiceItemController = new Controllers.TrnSalesInvoiceItemController();

            String[] discountSales = new String[2];

            if (trnSalesInvoiceDetailForm != null)
            {
                discountSales = trnSalesInvoiceItemController.DiscountSalesInvoice(trnSalesInvoiceDetailForm.trnSalesInvoiceEntity.Id, discountEntity);
            }

            if (discountSales[1].Equals("0") == false)
            {
                if (trnSalesInvoiceDetailForm != null)
                {
                    trnSalesInvoiceDetailForm.UpdateSalesInvoiceItemDataSource();
                }

                Close();
            }
            else
            {
                MessageBox.Show(discountSales[0], "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
       
    }
}
