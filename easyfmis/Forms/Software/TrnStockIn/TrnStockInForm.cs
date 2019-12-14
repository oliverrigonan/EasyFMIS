using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagedList;

namespace easyfmis.Forms.Software.TrnStockIn
{
    public partial class TrnStockInForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public static List<Entities.DgvStockInEntity> itemListData = new List<Entities.DgvStockInEntity>();
        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;
        public PagedList<Entities.DgvStockInEntity> itemListPageList = new PagedList<Entities.DgvStockInEntity>(itemListData, pageNumber, pageSize);
        public BindingSource itemListDataSource = new BindingSource();

        public TrnStockInForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            CreateStockInDataGridView();
        }

        public void UpdateStockInDataSource()
        {
            SetStockInDataSourceAsync();
        }

        public async void SetStockInDataSourceAsync()
        {
            List<Entities.DgvStockInEntity> getStockInData = await GetStockInDataTask();
            if (getStockInData.Any())
            {
                itemListData = getStockInData;
                itemListPageList = new PagedList<Entities.DgvStockInEntity>(itemListData, pageNumber, pageSize);

                if (itemListPageList.PageCount == 1)
                {
                    buttonStockInPageListFirst.Enabled = false;
                    buttonStockInPageListPrevious.Enabled = false;
                    buttonStockInPageListNext.Enabled = false;
                    buttonStockInPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonStockInPageListFirst.Enabled = false;
                    buttonStockInPageListPrevious.Enabled = false;
                    buttonStockInPageListNext.Enabled = true;
                    buttonStockInPageListLast.Enabled = true;
                }
                else if (pageNumber == itemListPageList.PageCount)
                {
                    buttonStockInPageListFirst.Enabled = true;
                    buttonStockInPageListPrevious.Enabled = true;
                    buttonStockInPageListNext.Enabled = false;
                    buttonStockInPageListLast.Enabled = false;
                }
                else
                {
                    buttonStockInPageListFirst.Enabled = true;
                    buttonStockInPageListPrevious.Enabled = true;
                    buttonStockInPageListNext.Enabled = true;
                    buttonStockInPageListLast.Enabled = true;
                }

                textBoxStockInPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
                itemListDataSource.DataSource = itemListPageList;
            }
            else
            {
                buttonStockInPageListFirst.Enabled = false;
                buttonStockInPageListPrevious.Enabled = false;
                buttonStockInPageListNext.Enabled = false;
                buttonStockInPageListLast.Enabled = false;

                pageNumber = 1;

                itemListData = new List<Entities.DgvStockInEntity>();
                itemListDataSource.Clear();
                textBoxStockInPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvStockInEntity>> GetStockInDataTask()
        {
            DateTime dateFilter = dateTimePickerStockInFilter.Value.Date;
            String filter = textBoxStockInFilter.Text;
            Controllers.TrnStockInController trnStockInController = new Controllers.TrnStockInController();

            List<Entities.TrnStockInEntity> listStockIn = trnStockInController.ListStockIn(dateFilter, filter);
            if (listStockIn.Any())
            {
                var items = from d in listStockIn
                            select new Entities.DgvStockInEntity
                            {
                                ColumnStockInButtonEdit = "Edit",
                                ColumnStockInButtonDelete = "Delete",
                                ColumnStockInId = d.Id,
                                ColumnStockInINDate = d.INDate.ToShortDateString(),
                                ColumnStockInINNumber = d.INNumber,
                                ColumnStockInRemarks = d.Remarks,
                                ColumnStockInIsLocked = d.IsLocked,
                                ColumnStockInSpace = ""
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvStockInEntity>());
            }
        }

        public void CreateStockInDataGridView()
        {
            UpdateStockInDataSource();

            dataGridViewStockIn.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewStockIn.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewStockIn.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewStockIn.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewStockIn.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewStockIn.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewStockIn.DataSource = itemListDataSource;
        }

        public void GetStockInCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Controllers.TrnStockInController trnStockInController = new Controllers.TrnStockInController();
            String[] addStockIn = trnStockInController.AddStockIn();
            if (addStockIn[1].Equals("0") == false)
            {
                sysSoftwareForm.AddTabPageStockInDetail(this, trnStockInController.DetailStockIn(Convert.ToInt32(addStockIn[1])));
                UpdateStockInDataSource();
            }
            else
            {
                MessageBox.Show(addStockIn[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
            sysSoftwareForm.RemoveTabPage();
        }

        private void dataGridViewStockIn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetStockInCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewStockIn.CurrentCell.ColumnIndex == dataGridViewStockIn.Columns["ColumnStockInButtonEdit"].Index)
            {
                Controllers.TrnStockInController trnStockInController = new Controllers.TrnStockInController();
                sysSoftwareForm.AddTabPageStockInDetail(this, trnStockInController.DetailStockIn(Convert.ToInt32(dataGridViewStockIn.Rows[e.RowIndex].Cells[2].Value)));
            }

            if (e.RowIndex > -1 && dataGridViewStockIn.CurrentCell.ColumnIndex == dataGridViewStockIn.Columns["ColumnStockInButtonDelete"].Index)
            {
                Boolean isLocked = Convert.ToBoolean(dataGridViewStockIn.Rows[e.RowIndex].Cells[dataGridViewStockIn.Columns["ColumnStockInIsLocked"].Index].Value);

                if (isLocked == true)
                {
                    MessageBox.Show("Already locked.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult deleteDialogResult = MessageBox.Show("Delete Stock-In?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (deleteDialogResult == DialogResult.Yes)
                    {
                        Controllers.TrnStockInController trnStockInController = new Controllers.TrnStockInController();

                        String[] deleteStockIn = trnStockInController.DeleteStockIn(Convert.ToInt32(dataGridViewStockIn.Rows[e.RowIndex].Cells[2].Value));
                        if (deleteStockIn[1].Equals("0") == false)
                        {
                            pageNumber = 1;
                            UpdateStockInDataSource();
                        }
                        else
                        {
                            MessageBox.Show(deleteStockIn[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void dateTimePickerStockInFilter_ValueChanged(object sender, EventArgs e)
        {
            UpdateStockInDataSource();
        }

        private void textBoxStockInFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateStockInDataSource();
            }
        }

        private void buttonStockInPageListFirst_Click(object sender, EventArgs e)
        {
            itemListPageList = new PagedList<Entities.DgvStockInEntity>(itemListData, 1, pageSize);
            itemListDataSource.DataSource = itemListPageList;

            buttonStockInPageListFirst.Enabled = false;
            buttonStockInPageListPrevious.Enabled = false;
            buttonStockInPageListNext.Enabled = true;
            buttonStockInPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxStockInPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonStockInPageListPrevious_Click(object sender, EventArgs e)
        {
            if (itemListPageList.HasPreviousPage == true)
            {
                itemListPageList = new PagedList<Entities.DgvStockInEntity>(itemListData, --pageNumber, pageSize);
                itemListDataSource.DataSource = itemListPageList;
            }

            buttonStockInPageListNext.Enabled = true;
            buttonStockInPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonStockInPageListFirst.Enabled = false;
                buttonStockInPageListPrevious.Enabled = false;
            }

            textBoxStockInPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonStockInPageListNext_Click(object sender, EventArgs e)
        {
            if (itemListPageList.HasNextPage == true)
            {
                itemListPageList = new PagedList<Entities.DgvStockInEntity>(itemListData, ++pageNumber, pageSize);
                itemListDataSource.DataSource = itemListPageList;
            }

            buttonStockInPageListFirst.Enabled = true;
            buttonStockInPageListPrevious.Enabled = true;

            if (pageNumber == itemListPageList.PageCount)
            {
                buttonStockInPageListNext.Enabled = false;
                buttonStockInPageListLast.Enabled = false;
            }

            textBoxStockInPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonStockInPageListLast_Click(object sender, EventArgs e)
        {
            itemListPageList = new PagedList<Entities.DgvStockInEntity>(itemListData, itemListPageList.PageCount, pageSize);
            itemListDataSource.DataSource = itemListPageList;

            buttonStockInPageListFirst.Enabled = true;
            buttonStockInPageListPrevious.Enabled = true;
            buttonStockInPageListNext.Enabled = false;
            buttonStockInPageListLast.Enabled = false;

            pageNumber = itemListPageList.PageCount;
            textBoxStockInPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }
    }
}
