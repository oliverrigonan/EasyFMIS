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

namespace easyfmis.Forms.Software.SysSystemTables
{
    public partial class SysSystemTablesForm : Form
    {

        public SysSoftwareForm sysSoftwareForm;

        public static Int32 pageSize = 50;

        public static List<Entities.DgvDiscountListEntity> discountListData = new List<Entities.DgvDiscountListEntity>();
        public PagedList<Entities.DgvDiscountListEntity> discountListPageList = new PagedList<Entities.DgvDiscountListEntity>(discountListData, discountListPageNumber, pageSize);
        public BindingSource discountListDataSource = new BindingSource();
        public static Int32 discountListPageNumber = 1;

        public static List<Entities.DgvBankListEntity> bankListData = new List<Entities.DgvBankListEntity>();
        public PagedList<Entities.DgvBankListEntity> bankListPageList = new PagedList<Entities.DgvBankListEntity>(bankListData, bankPageNumber, pageSize);
        public BindingSource bankListDataSource = new BindingSource();
        public static Int32 bankPageNumber = 1;

        public static List<Entities.DgvSystemTablesPayTypeListEntity> payTypeListData = new List<Entities.DgvSystemTablesPayTypeListEntity>();
        public PagedList<Entities.DgvSystemTablesPayTypeListEntity> payTypeListPageList = new PagedList<Entities.DgvSystemTablesPayTypeListEntity>(payTypeListData, payTypeListPageNumber, pageSize);
        public BindingSource payTypeListDataSource = new BindingSource();
        public static Int32 payTypeListPageNumber = 1;

        public SysSystemTablesForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();

            sysSoftwareForm = softwareForm;

            CreateBankListDataGridView();
            CreateDiscountListDataGridView();
            CreatePayTypeListDataGridView();
            CreateCurrencyListDataGridView();
        }

        // =======
        // ACCOUNT
        // =======
        // =======
        // Account
        // =======
        public void UpdateDiscountListDataSource()
        {
            SetDiscountListDataSourceAsync();
        }

        public async void SetDiscountListDataSourceAsync()
        {
            List<Entities.DgvDiscountListEntity> getDiscountListData = await GetDiscountListDataTask();
            if (getDiscountListData.Any())
            {
                discountListPageNumber = 1;
                discountListData = getDiscountListData;
                discountListPageList = new PagedList<Entities.DgvDiscountListEntity>(discountListData, discountListPageNumber, pageSize);

                if (discountListPageList.PageCount == 1)
                {
                    buttonDiscountListPageListFirst.Enabled = false;
                    buttonDiscountListPageListPrevious.Enabled = false;
                    buttonDiscountListPageListNext.Enabled = false;
                    buttonDiscountListPageListLast.Enabled = false;
                }
                else if (discountListPageNumber == 1)
                {
                    buttonDiscountListPageListFirst.Enabled = false;
                    buttonDiscountListPageListPrevious.Enabled = false;
                    buttonDiscountListPageListNext.Enabled = true;
                    buttonDiscountListPageListLast.Enabled = true;
                }
                else if (discountListPageNumber == discountListPageList.PageCount)
                {
                    buttonDiscountListPageListFirst.Enabled = true;
                    buttonDiscountListPageListPrevious.Enabled = true;
                    buttonDiscountListPageListNext.Enabled = false;
                    buttonDiscountListPageListLast.Enabled = false;
                }
                else
                {
                    buttonDiscountListPageListFirst.Enabled = true;
                    buttonDiscountListPageListPrevious.Enabled = true;
                    buttonDiscountListPageListNext.Enabled = true;
                    buttonDiscountListPageListLast.Enabled = true;
                }

                textBoxDiscountListPageNumber.Text = discountListPageNumber + " / " + discountListPageList.PageCount;
                discountListDataSource.DataSource = discountListPageList;
            }
            else
            {
                buttonDiscountListPageListFirst.Enabled = false;
                buttonDiscountListPageListPrevious.Enabled = false;
                buttonDiscountListPageListNext.Enabled = false;
                buttonDiscountListPageListLast.Enabled = false;

                discountListPageNumber = 1;

                discountListData = new List<Entities.DgvDiscountListEntity>();
                discountListDataSource.Clear();
                textBoxDiscountListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvDiscountListEntity>> GetDiscountListDataTask()
        {
            String filter = textBoxDiscountListFilter.Text;
            Controllers.MstDiscountController mstDiscountController = new Controllers.MstDiscountController();

            List<Entities.MstDiscountEntity> listAccount = mstDiscountController.ListDiscount(filter);
            if (listAccount.Any())
            {
                var accounts = from d in listAccount
                               select new Entities.DgvDiscountListEntity
                               {
                                   ColumnDiscountListEdit = "Edit",
                                   ColumnDiscountListDelete = "Delete",
                                   ColumnDiscountListId = d.Id,
                                   ColumnDiscountListDiscount = d.Discount,
                                   ColumnDiscountListDiscountRate = d.DiscountRate.ToString("#,##0.00")
                               };

                return Task.FromResult(accounts.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvDiscountListEntity>());
            }
        }

        public void CreateDiscountListDataGridView()
        {
            UpdateDiscountListDataSource();

            dataGridViewDiscountList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewDiscountList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewDiscountList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewDiscountList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewDiscountList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewDiscountList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewDiscountList.DataSource = discountListDataSource;
        }

        public void GetAccountListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonDiscountListPageListFirst_Click(object sender, EventArgs e)
        {
            discountListPageList = new PagedList<Entities.DgvDiscountListEntity>(discountListData, 1, pageSize);
            discountListDataSource.DataSource = discountListPageList;

            buttonDiscountListPageListFirst.Enabled = false;
            buttonDiscountListPageListPrevious.Enabled = false;
            buttonDiscountListPageListNext.Enabled = true;
            buttonDiscountListPageListLast.Enabled = true;

            discountListPageNumber = 1;
            textBoxDiscountListPageNumber.Text = discountListPageNumber + " / " + discountListPageList.PageCount;
        }

        private void buttonDiscountListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (discountListPageList.HasPreviousPage == true)
            {
                discountListPageList = new PagedList<Entities.DgvDiscountListEntity>(discountListData, --discountListPageNumber, pageSize);
                discountListDataSource.DataSource = discountListPageList;
            }

            buttonDiscountListPageListNext.Enabled = true;
            buttonDiscountListPageListLast.Enabled = true;

            if (discountListPageNumber == 1)
            {
                buttonDiscountListPageListFirst.Enabled = false;
                buttonDiscountListPageListPrevious.Enabled = false;
            }

            textBoxDiscountListPageNumber.Text = discountListPageNumber + " / " + discountListPageList.PageCount;
        }

        private void buttonDiscountListPageListNext_Click(object sender, EventArgs e)
        {
            if (discountListPageList.HasNextPage == true)
            {
                discountListPageList = new PagedList<Entities.DgvDiscountListEntity>(discountListData, ++discountListPageNumber, pageSize);
                discountListDataSource.DataSource = discountListPageList;
            }

            buttonDiscountListPageListFirst.Enabled = true;
            buttonDiscountListPageListPrevious.Enabled = true;

            if (discountListPageNumber == discountListPageList.PageCount)
            {
                buttonDiscountListPageListNext.Enabled = false;
                buttonDiscountListPageListLast.Enabled = false;
            }

            textBoxDiscountListPageNumber.Text = discountListPageNumber + " / " + discountListPageList.PageCount;
        }

        private void buttonDiscountListPageListLast_Click(object sender, EventArgs e)
        {
            discountListPageList = new PagedList<Entities.DgvDiscountListEntity>(discountListData, discountListPageList.PageCount, pageSize);
            discountListDataSource.DataSource = discountListPageList;

            buttonDiscountListPageListFirst.Enabled = true;
            buttonDiscountListPageListPrevious.Enabled = true;
            buttonDiscountListPageListNext.Enabled = false;
            buttonDiscountListPageListLast.Enabled = false;

            discountListPageNumber = discountListPageList.PageCount;
            textBoxDiscountListPageNumber.Text = discountListPageNumber + " / " + discountListPageList.PageCount;
        }

        private void dataGridViewDiscountList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetAccountListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewDiscountList.CurrentCell.ColumnIndex == dataGridViewDiscountList.Columns["ColumnDiscountListEdit"].Index)
            {
                Entities.MstDiscountEntity discount = new Entities.MstDiscountEntity
                {
                    Id = Convert.ToInt32(dataGridViewDiscountList.Rows[e.RowIndex].Cells[2].Value),
                    Discount = dataGridViewDiscountList.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    DiscountRate = Convert.ToDecimal(dataGridViewDiscountList.Rows[e.RowIndex].Cells[4].Value)
                };

                SysSystemTablesDiscountDetailForm sysSystemTablesDiscountDetailForm = new SysSystemTablesDiscountDetailForm(this, discount);
                sysSystemTablesDiscountDetailForm.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewDiscountList.CurrentCell.ColumnIndex == dataGridViewDiscountList.Columns["ColumnDiscountListDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete Discount?", "Easy ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    Controllers.MstDiscountController mstDiscountController = new Controllers.MstDiscountController();

                    String[] deleteDiscount = mstDiscountController.DeleteDiscount(Convert.ToInt32(dataGridViewDiscountList.Rows[e.RowIndex].Cells[2].Value));
                    if (deleteDiscount[1].Equals("0") == false)
                    {
                        Int32 currentPageNumber = discountListPageNumber;

                        discountListPageNumber = 1;
                        UpdateDiscountListDataSource();
                    }
                    else
                    {
                        MessageBox.Show(deleteDiscount[0], "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void textBoxDiscountListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateDiscountListDataSource();
            }
        }

        // ====
        // BANK
        // ====

        public void UpdateBankListDataSource()
        {
            SetBankListDataSourceAsync();
        }

        public async void SetBankListDataSourceAsync()
        {
            List<Entities.DgvBankListEntity> getBankListData = await GetBankListDataTask();
            if (getBankListData.Any())
            {
                bankPageNumber = 1;
                bankListData = getBankListData;
                bankListPageList = new PagedList<Entities.DgvBankListEntity>(bankListData, bankPageNumber, pageSize);

                if (bankListPageList.PageCount == 1)
                {
                    buttonBankListPageListFirst.Enabled = false;
                    buttonBankListPageListPrevious.Enabled = false;
                    buttonBankListPageListNext.Enabled = false;
                    buttonBankListPageListLast.Enabled = false;
                }
                else if (bankPageNumber == 1)
                {
                    buttonBankListPageListFirst.Enabled = false;
                    buttonBankListPageListPrevious.Enabled = false;
                    buttonBankListPageListNext.Enabled = true;
                    buttonBankListPageListLast.Enabled = true;
                }
                else if (bankPageNumber == bankListPageList.PageCount)
                {
                    buttonBankListPageListFirst.Enabled = true;
                    buttonBankListPageListPrevious.Enabled = true;
                    buttonBankListPageListNext.Enabled = false;
                    buttonBankListPageListLast.Enabled = false;
                }
                else
                {
                    buttonBankListPageListFirst.Enabled = true;
                    buttonBankListPageListPrevious.Enabled = true;
                    buttonBankListPageListNext.Enabled = true;
                    buttonBankListPageListLast.Enabled = true;
                }

                textBoxBankListPageNumber.Text = bankPageNumber + " / " + bankListPageList.PageCount;
                bankListDataSource.DataSource = bankListPageList;
            }
            else
            {
                buttonBankListPageListFirst.Enabled = false;
                buttonBankListPageListPrevious.Enabled = false;
                buttonBankListPageListNext.Enabled = false;
                buttonBankListPageListLast.Enabled = false;

                bankPageNumber = 1;

                bankListData = new List<Entities.DgvBankListEntity>();
                bankListDataSource.Clear();
                textBoxBankListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvBankListEntity>> GetBankListDataTask()
        {
            String filter = textBoxBankListFilter.Text;
            Controllers.MstArticleController mstBankController = new Controllers.MstArticleController();

            List<Entities.MstArticleEntity> listBank = mstBankController.ListArticle(4);
            if (listBank.Any())
            {
                var items = from d in listBank
                            where d.ArticleCode.Contains(filter)
                            || d.ArticleBarCode.Contains(filter)
                            || d.Article.Contains(filter)
                            || d.Category.Contains(filter)
                            select new Entities.DgvBankListEntity
                            {
                                ColumnBankListButtonEdit = "Edit",
                                ColumnBankListButtonDelete = "Delete",
                                ColumnBankListId = d.Id,
                                ColumnBankListBankCode = d.ArticleCode,
                                ColumnBankListBank = d.Article,
                                ColumnBankListContactNumber = d.Address,
                                ColumnBankListAddress = d.ContactNumber,
                                ColumnBankListIsLocked = d.IsLocked,
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvBankListEntity>());
            }
        }

        public void CreateBankListDataGridView()
        {
            UpdateBankListDataSource();

            dataGridViewBankList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewBankList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewBankList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewBankList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewBankList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewBankList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewBankList.DataSource = bankListDataSource;
        }

        public void GetBankListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }


        private void dataGridViewBankList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetBankListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewBankList.CurrentCell.ColumnIndex == dataGridViewBankList.Columns["ColumnBankListButtonEdit"].Index)
            {
                Controllers.MstArticleController mstBankController = new Controllers.MstArticleController();
                SysSystemTablesBankDetailForm mstBankDetailForm = new SysSystemTablesBankDetailForm(this, mstBankController.DetailArticle(Convert.ToInt32(dataGridViewBankList.Rows[e.RowIndex].Cells[2].Value)));
                mstBankDetailForm.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewBankList.CurrentCell.ColumnIndex == dataGridViewBankList.Columns["ColumnBankListButtonDelete"].Index)
            {
                Boolean isLocked = Convert.ToBoolean(dataGridViewBankList.Rows[e.RowIndex].Cells[7].Value);

                if (isLocked == true)
                {
                    MessageBox.Show("Already locked.", "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult deleteDialogResult = MessageBox.Show("Delete Bank?", "Easy ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (deleteDialogResult == DialogResult.Yes)
                    {
                        Controllers.MstArticleController mstBankController = new Controllers.MstArticleController();

                        String[] deleteBank = mstBankController.DeleteArticle(Convert.ToInt32(dataGridViewBankList.Rows[e.RowIndex].Cells[2].Value));
                        if (deleteBank[1].Equals("0") == false)
                        {
                            Int32 currentPageNumber = bankPageNumber;

                            bankPageNumber = 1;
                            UpdateBankListDataSource();

                            if (bankListPageList != null)
                            {
                                if (bankListData.Count() % pageSize == 1)
                                {
                                    bankPageNumber = currentPageNumber - 1;
                                }
                                else if (bankListData.Count() < 1)
                                {
                                    bankPageNumber = 1;
                                }
                                else
                                {
                                    bankPageNumber = currentPageNumber;
                                }

                                bankListDataSource.DataSource = bankListPageList;
                            }
                        }
                        else
                        {
                            MessageBox.Show(deleteBank[0], "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void textBoxBankListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateBankListDataSource();
            }
        }

        private void buttonBankListPageListFirst_Click(object sender, EventArgs e)
        {
            bankListPageList = new PagedList<Entities.DgvBankListEntity>(bankListData, 1, pageSize);
            bankListDataSource.DataSource = bankListPageList;

            buttonBankListPageListFirst.Enabled = false;
            buttonBankListPageListPrevious.Enabled = false;
            buttonBankListPageListNext.Enabled = true;
            buttonBankListPageListLast.Enabled = true;

            bankPageNumber = 1;
            textBoxBankListPageNumber.Text = bankPageNumber + " / " + bankListPageList.PageCount;
        }

        private void buttonBankListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (bankListPageList.HasPreviousPage == true)
            {
                bankListPageList = new PagedList<Entities.DgvBankListEntity>(bankListData, --bankPageNumber, pageSize);
                bankListDataSource.DataSource = bankListPageList;
            }

            buttonBankListPageListNext.Enabled = true;
            buttonBankListPageListLast.Enabled = true;

            if (bankPageNumber == 1)
            {
                buttonBankListPageListFirst.Enabled = false;
                buttonBankListPageListPrevious.Enabled = false;
            }

            textBoxBankListPageNumber.Text = bankPageNumber + " / " + bankListPageList.PageCount;
        }

        private void buttonBankListPageListNext_Click(object sender, EventArgs e)
        {
            if (bankListPageList.HasNextPage == true)
            {
                bankListPageList = new PagedList<Entities.DgvBankListEntity>(bankListData, ++bankPageNumber, pageSize);
                bankListDataSource.DataSource = bankListPageList;
            }

            buttonBankListPageListFirst.Enabled = true;
            buttonBankListPageListPrevious.Enabled = true;

            if (bankPageNumber == bankListPageList.PageCount)
            {
                buttonBankListPageListNext.Enabled = false;
                buttonBankListPageListLast.Enabled = false;
            }

            textBoxBankListPageNumber.Text = bankPageNumber + " / " + bankListPageList.PageCount;
        }

        private void buttonBankListPageListLast_Click(object sender, EventArgs e)
        {
            bankListPageList = new PagedList<Entities.DgvBankListEntity>(bankListData, bankListPageList.PageCount, pageSize);
            bankListDataSource.DataSource = bankListPageList;

            buttonBankListPageListFirst.Enabled = true;
            buttonBankListPageListPrevious.Enabled = true;
            buttonBankListPageListNext.Enabled = false;
            buttonBankListPageListLast.Enabled = false;

            bankPageNumber = bankListPageList.PageCount;
            textBoxBankListPageNumber.Text = bankPageNumber + " / " + bankListPageList.PageCount;
        }


        // ========
        // Pay Type
        // ========
        public void UpdatePayTypeListDataSource()
        {
            SetPayTypeListDataSourceAsync();
        }

        public async void SetPayTypeListDataSourceAsync()
        {
            List<Entities.DgvSystemTablesPayTypeListEntity> getPayTypeListData = await GetPayTypeListDataTask();
            if (getPayTypeListData.Any())
            {
                payTypeListData = getPayTypeListData;
                payTypeListPageList = new PagedList<Entities.DgvSystemTablesPayTypeListEntity>(payTypeListData, payTypeListPageNumber, pageSize);

                if (payTypeListPageList.PageCount == 1)
                {
                    buttonPayTypeListPageListFirst.Enabled = false;
                    buttonPayTypeListPageListPrevious.Enabled = false;
                    buttonPayTypeListPageListNext.Enabled = false;
                    buttonPayTypeListPageListLast.Enabled = false;
                }
                else if (payTypeListPageNumber == 1)
                {
                    buttonPayTypeListPageListFirst.Enabled = false;
                    buttonPayTypeListPageListPrevious.Enabled = false;
                    buttonPayTypeListPageListNext.Enabled = true;
                    buttonPayTypeListPageListLast.Enabled = true;
                }
                else if (payTypeListPageNumber == payTypeListPageList.PageCount)
                {
                    buttonPayTypeListPageListFirst.Enabled = true;
                    buttonPayTypeListPageListPrevious.Enabled = true;
                    buttonPayTypeListPageListNext.Enabled = false;
                    buttonPayTypeListPageListLast.Enabled = false;
                }
                else
                {
                    buttonPayTypeListPageListFirst.Enabled = true;
                    buttonPayTypeListPageListPrevious.Enabled = true;
                    buttonPayTypeListPageListNext.Enabled = true;
                    buttonPayTypeListPageListLast.Enabled = true;
                }

                textBoxPayTypeListPageNumber.Text = payTypeListPageNumber + " / " + payTypeListPageList.PageCount;
                payTypeListDataSource.DataSource = payTypeListPageList;
            }
            else
            {
                buttonPayTypeListPageListFirst.Enabled = false;
                buttonPayTypeListPageListPrevious.Enabled = false;
                buttonPayTypeListPageListNext.Enabled = false;
                buttonPayTypeListPageListLast.Enabled = false;

                payTypeListPageNumber = 1;

                payTypeListData = new List<Entities.DgvSystemTablesPayTypeListEntity>();
                payTypeListDataSource.Clear();
                textBoxPayTypeListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvSystemTablesPayTypeListEntity>> GetPayTypeListDataTask()
        {
            String filter = textBoxPayTypeListFilter.Text;
            Controllers.MstPayTypeController mstPayTypeController = new Controllers.MstPayTypeController();

            List<Entities.MstPayTypeEntity> listPayType = mstPayTypeController.ListPayType(filter);
            if (listPayType.Any())
            {
                var payTypes = from d in listPayType
                               select new Entities.DgvSystemTablesPayTypeListEntity
                               {
                                   ColumnPayTypeListButtonEdit = "Edit",
                                   ColumnPayTypeListButtonDelete = "Delete",
                                   ColumnPayTypeListId = d.Id,
                                   ColumnPayTypeListPayType = d.PayType,
                                   ColumnAccountId = Convert.ToInt32(d.AccountId),
                                   ColumnPayTypeListAccount = d.Account
                               };

                return Task.FromResult(payTypes.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvSystemTablesPayTypeListEntity>());
            }
        }

        public void CreatePayTypeListDataGridView()
        {
            UpdatePayTypeListDataSource();

            dataGridViewPayTypeList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewPayTypeList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewPayTypeList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewPayTypeList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewPayTypeList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewPayTypeList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewPayTypeList.DataSource = payTypeListDataSource;
        }

        private void textBoxPayTypeListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdatePayTypeListDataSource();
            }
        }

        private void dataGridViewPayTypeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetPayTypeListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewPayTypeList.CurrentCell.ColumnIndex == dataGridViewPayTypeList.Columns["ColumnPayTypeListButtonEdit"].Index)
            {
                Entities.MstPayTypeEntity selectePaytype = new Entities.MstPayTypeEntity()
                {
                    Id = Convert.ToInt32(dataGridViewPayTypeList.Rows[e.RowIndex].Cells[2].Value),
                    PayType = dataGridViewPayTypeList.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    AccountId = Convert.ToInt32(dataGridViewPayTypeList.Rows[e.RowIndex].Cells[4].Value)
                };

                SysSystemTablesPayTypeDetailForm sysSystemTablesPayTypeDetailForm = new SysSystemTablesPayTypeDetailForm(this, selectePaytype);
                sysSystemTablesPayTypeDetailForm.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewPayTypeList.CurrentCell.ColumnIndex == dataGridViewPayTypeList.Columns["ColumnPayTypeListButtonDelete"].Index)
            {

                DialogResult deleteDialogResult = MessageBox.Show("Delete PayType?", "Easy ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    Controllers.MstPayTypeController mstPayTypeController = new Controllers.MstPayTypeController();

                    String[] deletePayType = mstPayTypeController.DeletePayType(Convert.ToInt32(dataGridViewPayTypeList.Rows[e.RowIndex].Cells[2].Value));
                    if (deletePayType[1].Equals("0") == false)
                    {
                        Int32 currentPageNumber = payTypeListPageNumber;

                        payTypeListPageNumber = 1;
                        UpdatePayTypeListDataSource();
                    }
                    else
                    {
                        MessageBox.Show(deletePayType[0], "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void GetPayTypeListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonPayTypeListPageListFirst_Click(object sender, EventArgs e)
        {
            payTypeListPageList = new PagedList<Entities.DgvSystemTablesPayTypeListEntity>(payTypeListData, 1, pageSize);
            payTypeListDataSource.DataSource = payTypeListPageList;

            buttonPayTypeListPageListFirst.Enabled = false;
            buttonPayTypeListPageListPrevious.Enabled = false;
            buttonPayTypeListPageListNext.Enabled = true;
            buttonPayTypeListPageListLast.Enabled = true;

            payTypeListPageNumber = 1;
            textBoxPayTypeListPageNumber.Text = payTypeListPageNumber + " / " + payTypeListPageList.PageCount;
        }

        private void buttonPayTypeListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (payTypeListPageList.HasPreviousPage == true)
            {
                payTypeListPageList = new PagedList<Entities.DgvSystemTablesPayTypeListEntity>(payTypeListData, --payTypeListPageNumber, pageSize);
                payTypeListDataSource.DataSource = payTypeListPageList;
            }

            buttonPayTypeListPageListNext.Enabled = true;
            buttonPayTypeListPageListLast.Enabled = true;

            if (payTypeListPageNumber == 1)
            {
                buttonPayTypeListPageListFirst.Enabled = false;
                buttonPayTypeListPageListPrevious.Enabled = false;
            }

            textBoxPayTypeListPageNumber.Text = payTypeListPageNumber + " / " + payTypeListPageList.PageCount;
        }

        private void buttonPayTypeListPageListNext_Click(object sender, EventArgs e)
        {
            if (payTypeListPageList.HasNextPage == true)
            {
                payTypeListPageList = new PagedList<Entities.DgvSystemTablesPayTypeListEntity>(payTypeListData, ++payTypeListPageNumber, pageSize);
                payTypeListDataSource.DataSource = payTypeListPageList;
            }

            buttonPayTypeListPageListFirst.Enabled = true;
            buttonPayTypeListPageListPrevious.Enabled = true;

            if (payTypeListPageNumber == payTypeListPageList.PageCount)
            {
                buttonPayTypeListPageListNext.Enabled = false;
                buttonPayTypeListPageListLast.Enabled = false;
            }

            textBoxPayTypeListPageNumber.Text = payTypeListPageNumber + " / " + payTypeListPageList.PageCount;
        }

        private void buttonPayTypeListPageListLast_Click(object sender, EventArgs e)
        {
            payTypeListPageList = new PagedList<Entities.DgvSystemTablesPayTypeListEntity>(payTypeListData, payTypeListPageList.PageCount, pageSize);
            payTypeListDataSource.DataSource = payTypeListPageList;

            buttonPayTypeListPageListFirst.Enabled = true;
            buttonPayTypeListPageListPrevious.Enabled = true;
            buttonPayTypeListPageListNext.Enabled = false;
            buttonPayTypeListPageListLast.Enabled = false;

            payTypeListPageNumber = payTypeListPageList.PageCount;
            textBoxPayTypeListPageNumber.Text = payTypeListPageNumber + " / " + payTypeListPageList.PageCount;
        }

        // ========
        // Currency
        // ========
        public static List<Entities.DgvSystemTableCurrencyEntity> currencyListData = new List<Entities.DgvSystemTableCurrencyEntity>();
        public PagedList<Entities.DgvSystemTableCurrencyEntity> currencyListPageList = new PagedList<Entities.DgvSystemTableCurrencyEntity>(currencyListData, currencyListPageNumber, pageSize);
        public BindingSource currencyListDataSource = new BindingSource();
        public static Int32 currencyListPageNumber = 1;

        public Task<List<Entities.DgvSystemTableCurrencyEntity>> GetCurrencyListDataTask()
        {
            String filter = textBoxCurrencyListFilter.Text;
            Controllers.MstCurrencyController mstCurrencyController = new Controllers.MstCurrencyController();

            List<Entities.MstCurrencyEntity> listCurrency = mstCurrencyController.ListCurrency();
            if (listCurrency.Any())
            {
                var payTypes = from d in listCurrency
                               where d.CurrencyCode.ToLower().Contains(filter)
                               select new Entities.DgvSystemTableCurrencyEntity
                               {
                                   ColumnCurrencyListButtonEdit = "Edit",
                                   ColumnCurrencyListButtonDelete = "Delete",
                                   ColumnCurrencyListId = d.Id,
                                   ColumnCurrencyListCurrencyCode = d.CurrencyCode,
                                   ColumnCurrencyListCurrency = d.Currency,
                               };

                return Task.FromResult(payTypes.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvSystemTableCurrencyEntity>());
            }
        }

        public void UpdateCurrencyListDataSource()
        {
            SetCurrencyListDataSourceAsync();
        }

        public async void SetCurrencyListDataSourceAsync()
        {
            List<Entities.DgvSystemTableCurrencyEntity> getCurrencyListData = await GetCurrencyListDataTask();
            if (getCurrencyListData.Any())
            {
                currencyListData = getCurrencyListData;
                currencyListPageList = new PagedList<Entities.DgvSystemTableCurrencyEntity>(currencyListData, currencyListPageNumber, pageSize);

                if (currencyListPageList.PageCount == 1)
                {
                    buttonCurrencyListPageListFirst.Enabled = false;
                    buttonCurrencyListPageListPrevious.Enabled = false;
                    buttonCurrencyListPageListNext.Enabled = false;
                    buttonCurrencyListPageListLast.Enabled = false;
                }
                else if (currencyListPageNumber == 1)
                {
                    buttonCurrencyListPageListFirst.Enabled = false;
                    buttonCurrencyListPageListPrevious.Enabled = false;
                    buttonCurrencyListPageListNext.Enabled = true;
                    buttonCurrencyListPageListLast.Enabled = true;
                }
                else if (currencyListPageNumber == currencyListPageList.PageCount)
                {
                    buttonCurrencyListPageListFirst.Enabled = true;
                    buttonCurrencyListPageListPrevious.Enabled = true;
                    buttonCurrencyListPageListNext.Enabled = false;
                    buttonCurrencyListPageListLast.Enabled = false;
                }
                else
                {
                    buttonCurrencyListPageListFirst.Enabled = true;
                    buttonCurrencyListPageListPrevious.Enabled = true;
                    buttonCurrencyListPageListNext.Enabled = true;
                    buttonCurrencyListPageListLast.Enabled = true;
                }

                textBoxCurrencyListPageNumber.Text = currencyListPageNumber + " / " + currencyListPageList.PageCount;
                currencyListDataSource.DataSource = currencyListPageList;
            }
            else
            {
                buttonCurrencyListPageListFirst.Enabled = false;
                buttonCurrencyListPageListPrevious.Enabled = false;
                buttonCurrencyListPageListNext.Enabled = false;
                buttonCurrencyListPageListLast.Enabled = false;

                currencyListPageNumber = 1;

                currencyListData = new List<Entities.DgvSystemTableCurrencyEntity>();
                currencyListDataSource.Clear();
                textBoxCurrencyListPageNumber.Text = "1 / 1";
            }
        }

        public void CreateCurrencyListDataGridView()
        {
            UpdateCurrencyListDataSource();

            dataGridViewCurencyList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewCurencyList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewCurencyList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewCurencyList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewCurencyList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewCurencyList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewCurencyList.DataSource = currencyListDataSource;
        }

        private void textBoxCurrencyListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateCurrencyListDataSource();
            }
        }

        private void dataGridViewCurencyList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetCurrencyListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewCurencyList.CurrentCell.ColumnIndex == dataGridViewCurencyList.Columns["ColumnCurrencyListButtonEdit"].Index)
            {
                Entities.MstCurrencyEntity selecteCurrency = new Entities.MstCurrencyEntity()
                {
                    Id = Convert.ToInt32(dataGridViewCurencyList.Rows[e.RowIndex].Cells[2].Value),
                    CurrencyCode = dataGridViewCurencyList.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    Currency = dataGridViewCurencyList.Rows[e.RowIndex].Cells[4].Value.ToString()
                };

                SysSystemTablesCurrencyDetailForm SysSystemTablesCurrencyDetailForm = new SysSystemTablesCurrencyDetailForm(this, selecteCurrency);
                SysSystemTablesCurrencyDetailForm.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewCurencyList.CurrentCell.ColumnIndex == dataGridViewCurencyList.Columns["ColumnCurrencyListButtonDelete"].Index)
            {

                DialogResult deleteDialogResult = MessageBox.Show("Delete Currency?", "Easy ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    Controllers.MstCurrencyController mstCurrencyController = new Controllers.MstCurrencyController();

                    String[] deleteCurrency = mstCurrencyController.DeleteCurrency(Convert.ToInt32(dataGridViewCurencyList.Rows[e.RowIndex].Cells[2].Value));
                    if (deleteCurrency[1].Equals("0") == false)
                    {
                        Int32 currentPageNumber = currencyListPageNumber;

                        currencyListPageNumber = 1;
                        UpdateCurrencyListDataSource();
                    }
                    else
                    {
                        MessageBox.Show(deleteCurrency[0], "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void GetCurrencyListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonCurrencyListPageListFirst_Click(object sender, EventArgs e)
        {
            currencyListPageList = new PagedList<Entities.DgvSystemTableCurrencyEntity>(currencyListData, 1, pageSize);
            currencyListDataSource.DataSource = currencyListPageList;

            buttonCurrencyListPageListFirst.Enabled = false;
            buttonCurrencyListPageListPrevious.Enabled = false;
            buttonCurrencyListPageListNext.Enabled = true;
            buttonCurrencyListPageListLast.Enabled = true;

            currencyListPageNumber = 1;
            textBoxCurrencyListPageNumber.Text = currencyListPageNumber + " / " + currencyListPageList.PageCount;
        }

        private void buttonCurrencyListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (currencyListPageList.HasPreviousPage == true)
            {
                currencyListPageList = new PagedList<Entities.DgvSystemTableCurrencyEntity>(currencyListData, --currencyListPageNumber, pageSize);
                currencyListDataSource.DataSource = currencyListPageList;
            }

            buttonCurrencyListPageListNext.Enabled = true;
            buttonCurrencyListPageListLast.Enabled = true;

            if (currencyListPageNumber == 1)
            {
                buttonCurrencyListPageListFirst.Enabled = false;
                buttonCurrencyListPageListPrevious.Enabled = false;
            }
        }

        private void buttonCurrencyListPageListNext_Click(object sender, EventArgs e)
        {
            if (currencyListPageList.HasNextPage == true)
            {
                currencyListPageList = new PagedList<Entities.DgvSystemTableCurrencyEntity>(currencyListData, ++currencyListPageNumber, pageSize);
                currencyListDataSource.DataSource = currencyListPageList;
            }

            buttonCurrencyListPageListFirst.Enabled = true;
            buttonCurrencyListPageListPrevious.Enabled = true;

            if (currencyListPageNumber == currencyListPageList.PageCount)
            {
                buttonCurrencyListPageListNext.Enabled = false;
                buttonCurrencyListPageListLast.Enabled = false;
            }

            textBoxCurrencyListPageNumber.Text = currencyListPageNumber + " / " + currencyListPageList.PageCount;
        }

        private void buttonCurrencyListPageListLast_Click(object sender, EventArgs e)
        {
            currencyListPageList = new PagedList<Entities.DgvSystemTableCurrencyEntity>(currencyListData, currencyListPageList.PageCount, pageSize);
            currencyListDataSource.DataSource = currencyListPageList;

            buttonCurrencyListPageListFirst.Enabled = true;
            buttonCurrencyListPageListPrevious.Enabled = true;
            buttonCurrencyListPageListNext.Enabled = false;
            buttonCurrencyListPageListLast.Enabled = false;

            currencyListPageNumber = payTypeListPageList.PageCount;
            textBoxCurrencyListPageNumber.Text = currencyListPageNumber + " / " + currencyListPageList.PageCount;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            String selectedTab = tabControlSystemTable.SelectedTab.Text.ToString();
            switch (selectedTab)
            {
                case "Bank":
                    Controllers.MstArticleController mstBankController = new Controllers.MstArticleController();
                    String[] addBank = mstBankController.AddArticle("BANK");
                    if (addBank[1].Equals("0") == false)
                    {

                        SysSystemTablesBankDetailForm mstBankDetailForm = new SysSystemTablesBankDetailForm(this, mstBankController.DetailArticle(Convert.ToInt32(addBank[1])));
                        UpdateBankListDataSource();
                        mstBankDetailForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show(addBank[0], "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "Discount":
                    SysSystemTablesDiscountDetailForm sysSystemTablesDiscountDetailForm = new SysSystemTablesDiscountDetailForm(this, null);
                    sysSystemTablesDiscountDetailForm.ShowDialog();
                    break;
                case "Pay Type":
                    SysSystemTablesPayTypeDetailForm sysSystemTablesPayTypeDetailForm = new SysSystemTablesPayTypeDetailForm(this, null);
                    sysSystemTablesPayTypeDetailForm.ShowDialog();
                    break;
                case "Currency":
                    SysSystemTablesCurrencyDetailForm SysSystemTablesCurrencyDetailForm = new SysSystemTablesCurrencyDetailForm(this, null);
                    SysSystemTablesCurrencyDetailForm.ShowDialog();
                    break;
            }
        }
    }
}
