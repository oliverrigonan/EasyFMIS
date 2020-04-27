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
        private Modules.SysUserRightsModule sysUserRights;

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
            CreateTaxListDataGridView();
            CreateUnitListDataGridView();

            sysUserRights = new Modules.SysUserRightsModule("MstTables");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (sysUserRights.GetUserRights().CanAdd == false)
                {
                    buttonAdd.Enabled = false;
                }

                if (sysUserRights.GetUserRights().CanEdit == false)
                {
                    dataGridViewDiscountList.Columns[0].Visible = false;
                    dataGridViewPayTypeList.Columns[0].Visible = false;
                    dataGridViewTaxList.Columns[0].Visible = false;
                    dataGridViewUnitList.Columns[0].Visible = false;
                    dataGridViewBankList.Columns[0].Visible = false;
                    dataGridViewCurencyList.Columns[0].Visible = false;
                }

                if (sysUserRights.GetUserRights().CanDelete == false)
                {
                    dataGridViewDiscountList.Columns[1].Visible = false;
                    dataGridViewPayTypeList.Columns[1].Visible = false;
                    dataGridViewTaxList.Columns[1].Visible = false;
                    dataGridViewUnitList.Columns[1].Visible = false;
                    dataGridViewBankList.Columns[1].Visible = false;
                    dataGridViewCurencyList.Columns[1].Visible = false;
                }

                CreateBankListDataGridView();
                CreateDiscountListDataGridView();
                CreatePayTypeListDataGridView();
                CreateCurrencyListDataGridView();
                CreateTaxListDataGridView();
                CreateUnitListDataGridView();
            }
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

        // ===
        // Tax
        // ===
        public static List<Entities.DgvSystemTablesTaxListEntity> taxListData = new List<Entities.DgvSystemTablesTaxListEntity>();
        public PagedList<Entities.DgvSystemTablesTaxListEntity> taxListPageList = new PagedList<Entities.DgvSystemTablesTaxListEntity>(taxListData, taxListPageNumber, pageSize);
        public BindingSource taxListDataSource = new BindingSource();
        public static Int32 taxListPageNumber = 1;

        public Task<List<Entities.DgvSystemTablesTaxListEntity>> GetTaxListDataTask()
        {
            String filter = textBoxTaxListFilter.Text;
            Controllers.MstTaxController mstTaxController = new Controllers.MstTaxController();

            List<Entities.MstTaxEntity> listTax = mstTaxController.ListTax();
            if (listTax.Any())
            {
                var payTax = from d in listTax
                             where d.TaxCode.ToLower().Contains(filter)
                             select new Entities.DgvSystemTablesTaxListEntity
                             {
                                 ColumnTaxListButtonEdit = "Edit",
                                 ColumnTaxListButtonDelete = "Delete",
                                 ColumnTaxListId = d.Id,
                                 ColumnTaxListTaxCode = d.TaxCode,
                                 ColumnTaxListTax = d.Tax,
                                 ColumnTaxListRate = d.Rate.ToString("#,##0.00"),
                                 ColumnTaxListAccountId = d.AccountId,
                                 ColumnTaxListAccount = d.Account
                             };

                return Task.FromResult(payTax.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvSystemTablesTaxListEntity>());
            }
        }

        public void UpdateTaxListDataSource()
        {
            SetTaxListDataSourceAsync();
        }

        public async void SetTaxListDataSourceAsync()
        {
            List<Entities.DgvSystemTablesTaxListEntity> getTaxListData = await GetTaxListDataTask();
            if (getTaxListData.Any())
            {
                taxListData = getTaxListData;
                taxListPageList = new PagedList<Entities.DgvSystemTablesTaxListEntity>(taxListData, taxListPageNumber, pageSize);

                if (taxListPageList.PageCount == 1)
                {
                    buttonTaxListPageListFirst.Enabled = false;
                    buttonTaxListPageListPrevious.Enabled = false;
                    buttonTaxListPageListNext.Enabled = false;
                    buttonTaxListPageListLast.Enabled = false;
                }
                else if (taxListPageNumber == 1)
                {
                    buttonTaxListPageListFirst.Enabled = false;
                    buttonTaxListPageListPrevious.Enabled = false;
                    buttonTaxListPageListNext.Enabled = true;
                    buttonTaxListPageListLast.Enabled = true;
                }
                else if (taxListPageNumber == taxListPageList.PageCount)
                {
                    buttonTaxListPageListFirst.Enabled = true;
                    buttonTaxListPageListPrevious.Enabled = true;
                    buttonTaxListPageListNext.Enabled = false;
                    buttonTaxListPageListLast.Enabled = false;
                }
                else
                {
                    buttonTaxListPageListFirst.Enabled = true;
                    buttonTaxListPageListPrevious.Enabled = true;
                    buttonTaxListPageListNext.Enabled = true;
                    buttonTaxListPageListLast.Enabled = true;
                }

                textBoxTaxListPageNumber.Text = taxListPageNumber + " / " + taxListPageList.PageCount;
                taxListDataSource.DataSource = taxListPageList;
            }
            else
            {
                buttonTaxListPageListFirst.Enabled = false;
                buttonTaxListPageListPrevious.Enabled = false;
                buttonTaxListPageListNext.Enabled = false;
                buttonTaxListPageListLast.Enabled = false;

                taxListPageNumber = 1;

                taxListData = new List<Entities.DgvSystemTablesTaxListEntity>();
                taxListDataSource.Clear();
                textBoxTaxListPageNumber.Text = "1 / 1";
            }
        }

        public void CreateTaxListDataGridView()
        {
            UpdateTaxListDataSource();

            dataGridViewTaxList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewTaxList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewTaxList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewTaxList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewTaxList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewTaxList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewTaxList.DataSource = taxListDataSource;
        }

        private void textBoxTaxListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateTaxListDataSource();
            }
        }

        private void dataGridViewTaxList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetTaxListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewTaxList.CurrentCell.ColumnIndex == dataGridViewTaxList.Columns["ColumnTaxListButtonEdit"].Index)
            {
                Entities.MstTaxEntity selecteTax = new Entities.MstTaxEntity()
                {

                    Id = Convert.ToInt32(dataGridViewTaxList.Rows[e.RowIndex].Cells[2].Value),
                    TaxCode = dataGridViewTaxList.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    Tax = dataGridViewTaxList.Rows[e.RowIndex].Cells[4].Value.ToString(),
                    Rate = Convert.ToDecimal(dataGridViewTaxList.Rows[e.RowIndex].Cells[5].Value),
                    AccountId = Convert.ToInt32(dataGridViewTaxList.Rows[e.RowIndex].Cells[6].Value)
                };

                SysSystemTablesTaxDetailForm SysSystemTablesTaxDetailForm = new SysSystemTablesTaxDetailForm(this, selecteTax);
                SysSystemTablesTaxDetailForm.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewTaxList.CurrentCell.ColumnIndex == dataGridViewTaxList.Columns["ColumnTaxListButtonDelete"].Index)
            {

                DialogResult deleteDialogResult = MessageBox.Show("Delete Tax?", "Easy ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    Controllers.MstTaxController mstTaxController = new Controllers.MstTaxController();

                    String[] deleteTax = mstTaxController.DeleteTax(Convert.ToInt32(dataGridViewTaxList.Rows[e.RowIndex].Cells[2].Value));
                    if (deleteTax[1].Equals("0") == false)
                    {
                        Int32 taxPageNumber = taxListPageNumber;

                        taxListPageNumber = 1;
                        UpdateTaxListDataSource();
                    }
                    else
                    {
                        MessageBox.Show(deleteTax[0], "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void GetTaxListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonTaxListPageListFirst_Click(object sender, EventArgs e)
        {
            taxListPageList = new PagedList<Entities.DgvSystemTablesTaxListEntity>(taxListData, 1, pageSize);
            taxListDataSource.DataSource = taxListPageList;

            buttonTaxListPageListFirst.Enabled = false;
            buttonTaxListPageListPrevious.Enabled = false;
            buttonTaxListPageListNext.Enabled = true;
            buttonTaxListPageListLast.Enabled = true;

            taxListPageNumber = 1;
            textBoxTaxListPageNumber.Text = taxListPageNumber + " / " + taxListPageList.PageCount;
        }

        private void buttonTaxListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (taxListPageList.HasPreviousPage == true)
            {
                taxListPageList = new PagedList<Entities.DgvSystemTablesTaxListEntity>(taxListData, --taxListPageNumber, pageSize);
                taxListDataSource.DataSource = taxListPageList;
            }

            buttonTaxListPageListNext.Enabled = true;
            buttonTaxListPageListLast.Enabled = true;

            if (taxListPageNumber == 1)
            {
                buttonTaxListPageListFirst.Enabled = false;
                buttonTaxListPageListPrevious.Enabled = false;
            }
        }

        private void buttonTaxListPageListNext_Click(object sender, EventArgs e)
        {
            if (taxListPageList.HasNextPage == true)
            {
                taxListPageList = new PagedList<Entities.DgvSystemTablesTaxListEntity>(taxListData, ++taxListPageNumber, pageSize);
                taxListDataSource.DataSource = taxListPageList;
            }

            buttonTaxListPageListFirst.Enabled = true;
            buttonTaxListPageListPrevious.Enabled = true;

            if (taxListPageNumber == taxListPageList.PageCount)
            {
                buttonTaxListPageListNext.Enabled = false;
                buttonTaxListPageListLast.Enabled = false;
            }

            textBoxTaxListPageNumber.Text = taxListPageNumber + " / " + taxListPageList.PageCount;
        }

        private void buttonTaxListPageListLast_Click(object sender, EventArgs e)
        {
            taxListPageList = new PagedList<Entities.DgvSystemTablesTaxListEntity>(taxListData, taxListPageList.PageCount, pageSize);
            taxListDataSource.DataSource = taxListPageList;

            buttonTaxListPageListFirst.Enabled = true;
            buttonTaxListPageListPrevious.Enabled = true;
            buttonTaxListPageListNext.Enabled = false;
            buttonTaxListPageListLast.Enabled = false;

            taxListPageNumber = payTypeListPageList.PageCount;
            textBoxTaxListPageNumber.Text = taxListPageNumber + " / " + taxListPageList.PageCount;
        }

        // ====
        // Unit
        // ====

        public static List<Entities.DgvSystemTablesUnitListEntity> unitListData = new List<Entities.DgvSystemTablesUnitListEntity>();
        public PagedList<Entities.DgvSystemTablesUnitListEntity> unitListPageList = new PagedList<Entities.DgvSystemTablesUnitListEntity>(unitListData, unitListPageNumber, pageSize);
        public BindingSource unitListDataSource = new BindingSource();
        public static Int32 unitListPageNumber = 1;
        public void UpdateUnitListDataSource()
        {
            SetUnitListDataSourceAsync();
        }

        public async void SetUnitListDataSourceAsync()
        {
            List<Entities.DgvSystemTablesUnitListEntity> getUnitListData = await GetUnitListDataTask();
            if (getUnitListData.Any())
            {
                unitListData = getUnitListData;
                unitListPageList = new PagedList<Entities.DgvSystemTablesUnitListEntity>(unitListData, unitListPageNumber, pageSize);

                if (unitListPageList.PageCount == 1)
                {
                    buttonUnitListPageListFirst.Enabled = false;
                    buttonUnitListPageListPrevious.Enabled = false;
                    buttonUnitListPageListNext.Enabled = false;
                    buttonUnitListPageListLast.Enabled = false;
                }
                else if (unitListPageNumber == 1)
                {
                    buttonUnitListPageListFirst.Enabled = false;
                    buttonUnitListPageListPrevious.Enabled = false;
                    buttonUnitListPageListNext.Enabled = true;
                    buttonUnitListPageListLast.Enabled = true;
                }
                else if (unitListPageNumber == unitListPageList.PageCount)
                {
                    buttonUnitListPageListFirst.Enabled = true;
                    buttonUnitListPageListPrevious.Enabled = true;
                    buttonUnitListPageListNext.Enabled = false;
                    buttonUnitListPageListLast.Enabled = false;
                }
                else
                {
                    buttonUnitListPageListFirst.Enabled = true;
                    buttonUnitListPageListPrevious.Enabled = true;
                    buttonUnitListPageListNext.Enabled = true;
                    buttonUnitListPageListLast.Enabled = true;
                }

                textBoxUnitListPageNumber.Text = unitListPageNumber + " / " + unitListPageList.PageCount;
                unitListDataSource.DataSource = unitListPageList;
            }
            else
            {
                buttonUnitListPageListFirst.Enabled = false;
                buttonUnitListPageListPrevious.Enabled = false;
                buttonUnitListPageListNext.Enabled = false;
                buttonUnitListPageListLast.Enabled = false;

                unitListPageNumber = 1;

                unitListData = new List<Entities.DgvSystemTablesUnitListEntity>();
                unitListDataSource.Clear();
                textBoxUnitListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvSystemTablesUnitListEntity>> GetUnitListDataTask()
        {
            String filter = textBoxUnitListFilter.Text;
            Controllers.MstUnitController mstUnitController = new Controllers.MstUnitController();

            List<Entities.MstUnitEntity> listUnit = mstUnitController.ListUnit();
            if (listUnit.Any())
            {
                var units = from d in listUnit
                            where d.Unit.ToLower().Contains(filter)
                            select new Entities.DgvSystemTablesUnitListEntity
                            {
                                ColumnUnitListButtonEdit = "Edit",
                                ColumnUnitListButtonDelete = "Delete",
                                ColumnUnitListId = d.Id,
                                ColumnUnitListUnit = d.Unit
                            };

                return Task.FromResult(units.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvSystemTablesUnitListEntity>());
            }
        }

        public void CreateUnitListDataGridView()
        {
            UpdateUnitListDataSource();

            dataGridViewUnitList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewUnitList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewUnitList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewUnitList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewUnitList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewUnitList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewUnitList.DataSource = unitListDataSource;
        }

        private void textBoxUnitListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateUnitListDataSource();
            }
        }

        private void dataGridViewUnitList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetUnitListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewUnitList.CurrentCell.ColumnIndex == dataGridViewUnitList.Columns["ColumnUnitListButtonEdit"].Index)
            {
                Entities.MstUnitEntity selectedUnit = new Entities.MstUnitEntity()
                {
                    Id = Convert.ToInt32(dataGridViewUnitList.Rows[e.RowIndex].Cells[2].Value),
                    Unit = dataGridViewUnitList.Rows[e.RowIndex].Cells[3].Value.ToString()
                };
                SysSystemTablesUnitDetailForm sysSystemTablesUnitDetailForm = new SysSystemTablesUnitDetailForm(this, selectedUnit);
                sysSystemTablesUnitDetailForm.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewUnitList.CurrentCell.ColumnIndex == dataGridViewUnitList.Columns["ColumnUnitListButtonDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete Unit?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    Controllers.MstUnitController mstUnitController = new Controllers.MstUnitController();

                    String[] deleteUnit = mstUnitController.DeleteUnit(Convert.ToInt32(dataGridViewUnitList.Rows[e.RowIndex].Cells[2].Value));
                    if (deleteUnit[1].Equals("0") == false)
                    {
                        Int32 currentPageNumber = unitListPageNumber;

                        unitListPageNumber = 1;
                        UpdateUnitListDataSource();
                    }
                    else
                    {
                        MessageBox.Show(deleteUnit[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void GetUnitListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonUnitListPageListFirst_Click(object sender, EventArgs e)
        {
            unitListPageList = new PagedList<Entities.DgvSystemTablesUnitListEntity>(unitListData, 1, pageSize);
            unitListDataSource.DataSource = unitListPageList;

            buttonUnitListPageListFirst.Enabled = false;
            buttonUnitListPageListPrevious.Enabled = false;
            buttonUnitListPageListNext.Enabled = true;
            buttonUnitListPageListLast.Enabled = true;

            unitListPageNumber = 1;
            textBoxUnitListPageNumber.Text = unitListPageNumber + " / " + unitListPageList.PageCount;
        }

        private void buttonUnitListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (unitListPageList.HasPreviousPage == true)
            {
                unitListPageList = new PagedList<Entities.DgvSystemTablesUnitListEntity>(unitListData, --unitListPageNumber, pageSize);
                unitListDataSource.DataSource = unitListPageList;
            }

            buttonUnitListPageListNext.Enabled = true;
            buttonUnitListPageListLast.Enabled = true;

            if (unitListPageNumber == 1)
            {
                buttonUnitListPageListFirst.Enabled = false;
                buttonUnitListPageListPrevious.Enabled = false;
            }

            textBoxUnitListPageNumber.Text = unitListPageNumber + " / " + unitListPageList.PageCount;
        }

        private void buttonUnitListPageListNext_Click(object sender, EventArgs e)
        {
            if (unitListPageList.HasNextPage == true)
            {
                unitListPageList = new PagedList<Entities.DgvSystemTablesUnitListEntity>(unitListData, ++unitListPageNumber, pageSize);
                unitListDataSource.DataSource = unitListPageList;
            }

            buttonUnitListPageListFirst.Enabled = true;
            buttonUnitListPageListPrevious.Enabled = true;

            if (unitListPageNumber == unitListPageList.PageCount)
            {
                buttonUnitListPageListNext.Enabled = false;
                buttonUnitListPageListLast.Enabled = false;
            }

            textBoxUnitListPageNumber.Text = unitListPageNumber + " / " + unitListPageList.PageCount;
        }

        private void buttonUnitListPageListLast_Click(object sender, EventArgs e)
        {
            unitListPageList = new PagedList<Entities.DgvSystemTablesUnitListEntity>(unitListData, unitListPageList.PageCount, pageSize);
            unitListDataSource.DataSource = unitListPageList;

            buttonUnitListPageListFirst.Enabled = true;
            buttonUnitListPageListPrevious.Enabled = true;
            buttonUnitListPageListNext.Enabled = false;
            buttonUnitListPageListLast.Enabled = false;

            unitListPageNumber = unitListPageList.PageCount;
            textBoxUnitListPageNumber.Text = unitListPageNumber + " / " + unitListPageList.PageCount;
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
                case "Tax":
                    SysSystemTablesTaxDetailForm SysSystemTablesTaxDetailForm = new SysSystemTablesTaxDetailForm(this, null);
                    SysSystemTablesTaxDetailForm.ShowDialog();
                    break;
                case "Unit":
                    SysSystemTablesUnitDetailForm SysSystemTablesUnitDetailForm = new SysSystemTablesUnitDetailForm(this, null);
                    SysSystemTablesUnitDetailForm.ShowDialog();
                    break;


            }
        }
    }
}
