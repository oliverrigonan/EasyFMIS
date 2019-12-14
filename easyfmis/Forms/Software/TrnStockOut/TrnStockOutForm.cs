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

namespace easyfmis.Forms.Software.TrnStockOut
{
    public partial class TrnStockOutForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public static List<Entities.DgvStockOutEntity> itemListData = new List<Entities.DgvStockOutEntity>();
        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;
        public PagedList<Entities.DgvStockOutEntity> itemListPageList = new PagedList<Entities.DgvStockOutEntity>(itemListData, pageNumber, pageSize);
        public BindingSource itemListDataSource = new BindingSource();

        public TrnStockOutForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            CreateStockOutDataGridView();
        }

        public void UpdateStockOutDataSource()
        {
            SetStockOutDataSourceAsync();
        }

        public async void SetStockOutDataSourceAsync()
        {
            List<Entities.DgvStockOutEntity> getStockOutData = await GetStockOutDataTask();
            if (getStockOutData.Any())
            {
                itemListData = getStockOutData;
                itemListPageList = new PagedList<Entities.DgvStockOutEntity>(itemListData, pageNumber, pageSize);

                if (itemListPageList.PageCount == 1)
                {
                    buttonStockOutPageListFirst.Enabled = false;
                    buttonStockOutPageListPrevious.Enabled = false;
                    buttonStockOutPageListNext.Enabled = false;
                    buttonStockOutPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonStockOutPageListFirst.Enabled = false;
                    buttonStockOutPageListPrevious.Enabled = false;
                    buttonStockOutPageListNext.Enabled = true;
                    buttonStockOutPageListLast.Enabled = true;
                }
                else if (pageNumber == itemListPageList.PageCount)
                {
                    buttonStockOutPageListFirst.Enabled = true;
                    buttonStockOutPageListPrevious.Enabled = true;
                    buttonStockOutPageListNext.Enabled = false;
                    buttonStockOutPageListLast.Enabled = false;
                }
                else
                {
                    buttonStockOutPageListFirst.Enabled = true;
                    buttonStockOutPageListPrevious.Enabled = true;
                    buttonStockOutPageListNext.Enabled = true;
                    buttonStockOutPageListLast.Enabled = true;
                }

                textBoxStockOutPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
                itemListDataSource.DataSource = itemListPageList;
            }
            else
            {
                buttonStockOutPageListFirst.Enabled = false;
                buttonStockOutPageListPrevious.Enabled = false;
                buttonStockOutPageListNext.Enabled = false;
                buttonStockOutPageListLast.Enabled = false;

                pageNumber = 1;

                itemListData = new List<Entities.DgvStockOutEntity>();
                itemListDataSource.Clear();
                textBoxStockOutPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvStockOutEntity>> GetStockOutDataTask()
        {
            DateTime dateFilter = dateTimePickerStockOutFilter.Value.Date;
            String filter = textBoxStockOutFilter.Text;
            Controllers.TrnStockOutController trnStockOutController = new Controllers.TrnStockOutController();

            List<Entities.TrnStockOutEntity> listStockOut = trnStockOutController.ListStockOut(dateFilter, filter);
            if (listStockOut.Any())
            {
                var items = from d in listStockOut
                            select new Entities.DgvStockOutEntity
                            {
                                ColumnStockOutButtonEdit = "Edit",
                                ColumnStockOutButtonDelete = "Delete",
                                ColumnStockOutId = d.Id,
                                ColumnStockOutOTDate = d.OTDate.ToShortDateString(),
                                ColumnStockOutOTNumber = d.OTNumber,
                                ColumnStockOutRemarks = d.Remarks,
                                ColumnStockOutIsLocked = d.IsLocked,
                                ColumnStockOutSpace = ""
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvStockOutEntity>());
            }
        }

        public void CreateStockOutDataGridView()
        {
            UpdateStockOutDataSource();

            dataGridViewStockOut.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewStockOut.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewStockOut.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewStockOut.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewStockOut.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewStockOut.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewStockOut.DataSource = itemListDataSource;
        }

        public void GetStockOutCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Controllers.TrnStockOutController trnStockOutController = new Controllers.TrnStockOutController();
            String[] addStockOut = trnStockOutController.AddStockOut();
            if (addStockOut[1].Equals("0") == false)
            {
                sysSoftwareForm.AddTabPageStockOutDetail(this, trnStockOutController.DetailStockOut(Convert.ToInt32(addStockOut[1])));
                UpdateStockOutDataSource();
            }
            else
            {
                MessageBox.Show(addStockOut[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
            sysSoftwareForm.RemoveTabPage();
        }

        private void dataGridViewStockOut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetStockOutCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewStockOut.CurrentCell.ColumnIndex == dataGridViewStockOut.Columns["ColumnStockOutButtonEdit"].Index)
            {
                Controllers.TrnStockOutController trnStockOutController = new Controllers.TrnStockOutController();
                sysSoftwareForm.AddTabPageStockOutDetail(this, trnStockOutController.DetailStockOut(Convert.ToInt32(dataGridViewStockOut.Rows[e.RowIndex].Cells[2].Value)));
            }

            if (e.RowIndex > -1 && dataGridViewStockOut.CurrentCell.ColumnIndex == dataGridViewStockOut.Columns["ColumnStockOutButtonDelete"].Index)
            {
                Boolean isLocked = Convert.ToBoolean(dataGridViewStockOut.Rows[e.RowIndex].Cells[dataGridViewStockOut.Columns["ColumnStockOutIsLocked"].Index].Value);

                if (isLocked == true)
                {
                    MessageBox.Show("Already locked.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult deleteDialogResult = MessageBox.Show("Delete Stock-In?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (deleteDialogResult == DialogResult.Yes)
                    {
                        Controllers.TrnStockOutController trnStockOutController = new Controllers.TrnStockOutController();

                        String[] deleteStockOut = trnStockOutController.DeleteStockOut(Convert.ToInt32(dataGridViewStockOut.Rows[e.RowIndex].Cells[2].Value));
                        if (deleteStockOut[1].Equals("0") == false)
                        {
                            pageNumber = 1;
                            UpdateStockOutDataSource();
                        }
                        else
                        {
                            MessageBox.Show(deleteStockOut[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void dateTimePickerStockOutFilter_ValueChanged(object sender, EventArgs e)
        {
            UpdateStockOutDataSource();
        }

        private void textBoxStockOutFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateStockOutDataSource();
            }
        }

        private void buttonStockOutPageListFirst_Click(object sender, EventArgs e)
        {
            itemListPageList = new PagedList<Entities.DgvStockOutEntity>(itemListData, 1, pageSize);
            itemListDataSource.DataSource = itemListPageList;

            buttonStockOutPageListFirst.Enabled = false;
            buttonStockOutPageListPrevious.Enabled = false;
            buttonStockOutPageListNext.Enabled = true;
            buttonStockOutPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxStockOutPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonStockOutPageListPrevious_Click(object sender, EventArgs e)
        {
            if (itemListPageList.HasPreviousPage == true)
            {
                itemListPageList = new PagedList<Entities.DgvStockOutEntity>(itemListData, --pageNumber, pageSize);
                itemListDataSource.DataSource = itemListPageList;
            }

            buttonStockOutPageListNext.Enabled = true;
            buttonStockOutPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonStockOutPageListFirst.Enabled = false;
                buttonStockOutPageListPrevious.Enabled = false;
            }

            textBoxStockOutPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonStockOutPageListNext_Click(object sender, EventArgs e)
        {
            if (itemListPageList.HasNextPage == true)
            {
                itemListPageList = new PagedList<Entities.DgvStockOutEntity>(itemListData, ++pageNumber, pageSize);
                itemListDataSource.DataSource = itemListPageList;
            }

            buttonStockOutPageListFirst.Enabled = true;
            buttonStockOutPageListPrevious.Enabled = true;

            if (pageNumber == itemListPageList.PageCount)
            {
                buttonStockOutPageListNext.Enabled = false;
                buttonStockOutPageListLast.Enabled = false;
            }

            textBoxStockOutPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonStockOutPageListLast_Click(object sender, EventArgs e)
        {
            itemListPageList = new PagedList<Entities.DgvStockOutEntity>(itemListData, itemListPageList.PageCount, pageSize);
            itemListDataSource.DataSource = itemListPageList;

            buttonStockOutPageListFirst.Enabled = true;
            buttonStockOutPageListPrevious.Enabled = true;
            buttonStockOutPageListNext.Enabled = false;
            buttonStockOutPageListLast.Enabled = false;

            pageNumber = itemListPageList.PageCount;
            textBoxStockOutPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }
    }
}
