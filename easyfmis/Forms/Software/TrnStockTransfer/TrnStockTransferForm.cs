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

namespace easyfmis.Forms.Software.TrnStockTransfer
{
    public partial class TrnStockTransferForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public static List<Entities.DgvStockTransferEntity> itemListData = new List<Entities.DgvStockTransferEntity>();
        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;
        public PagedList<Entities.DgvStockTransferEntity> itemListPageList = new PagedList<Entities.DgvStockTransferEntity>(itemListData, pageNumber, pageSize);
        public BindingSource itemListDataSource = new BindingSource();

        public TrnStockTransferForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            CreateStockTransferDataGridView();
        }

        public void UpdateStockTransferDataSource()
        {
            SetStockTransferDataSourceAsync();
        }

        public async void SetStockTransferDataSourceAsync()
        {
            List<Entities.DgvStockTransferEntity> getStockTransferData = await GetStockTransferDataTask();
            if (getStockTransferData.Any())
            {
                itemListData = getStockTransferData;
                itemListPageList = new PagedList<Entities.DgvStockTransferEntity>(itemListData, pageNumber, pageSize);

                if (itemListPageList.PageCount == 1)
                {
                    buttonStockTransferPageListFirst.Enabled = false;
                    buttonStockTransferPageListPrevious.Enabled = false;
                    buttonStockTransferPageListNext.Enabled = false;
                    buttonStockTransferPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonStockTransferPageListFirst.Enabled = false;
                    buttonStockTransferPageListPrevious.Enabled = false;
                    buttonStockTransferPageListNext.Enabled = true;
                    buttonStockTransferPageListLast.Enabled = true;
                }
                else if (pageNumber == itemListPageList.PageCount)
                {
                    buttonStockTransferPageListFirst.Enabled = true;
                    buttonStockTransferPageListPrevious.Enabled = true;
                    buttonStockTransferPageListNext.Enabled = false;
                    buttonStockTransferPageListLast.Enabled = false;
                }
                else
                {
                    buttonStockTransferPageListFirst.Enabled = true;
                    buttonStockTransferPageListPrevious.Enabled = true;
                    buttonStockTransferPageListNext.Enabled = true;
                    buttonStockTransferPageListLast.Enabled = true;
                }

                textBoxStockTransferPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
                itemListDataSource.DataSource = itemListPageList;
            }
            else
            {
                buttonStockTransferPageListFirst.Enabled = false;
                buttonStockTransferPageListPrevious.Enabled = false;
                buttonStockTransferPageListNext.Enabled = false;
                buttonStockTransferPageListLast.Enabled = false;

                pageNumber = 1;

                itemListData = new List<Entities.DgvStockTransferEntity>();
                itemListDataSource.Clear();
                textBoxStockTransferPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvStockTransferEntity>> GetStockTransferDataTask()
        {
            DateTime dateFilter = dateTimePickerStockTransferFilter.Value.Date;
            String filter = textBoxStockTransferFilter.Text;
            Controllers.TrnStockTransferController trnStockTransferController = new Controllers.TrnStockTransferController();

            List<Entities.TrnStockTransferEntity> listStockTransfer = trnStockTransferController.ListStockTransfer(dateFilter, filter);
            if (listStockTransfer.Any())
            {
                var items = from d in listStockTransfer
                            select new Entities.DgvStockTransferEntity
                            {
                                ColumnStockTransferButtonEdit = "Edit",
                                ColumnStockTransferButtonDelete = "Delete",
                                ColumnStockTransferId = d.Id,
                                ColumnStockTransferSTDate = d.STDate.ToShortDateString(),
                                ColumnStockTransferSTNumber = d.STNumber,
                                ColumnStockTransferToBranch = d.ToBranch,
                                ColumnStockTransferRemarks = d.Remarks,
                                ColumnStockTransferIsLocked = d.IsLocked,
                                ColumnStockTransferSpace = ""
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvStockTransferEntity>());
            }
        }

        public void CreateStockTransferDataGridView()
        {
            UpdateStockTransferDataSource();

            dataGridViewStockTransfer.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewStockTransfer.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewStockTransfer.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewStockTransfer.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewStockTransfer.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewStockTransfer.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewStockTransfer.DataSource = itemListDataSource;
        }

        public void GetStockTransferCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Controllers.TrnStockTransferController trnStockTransferController = new Controllers.TrnStockTransferController();
            String[] addStockTransfer = trnStockTransferController.AddStockTransfer();
            if (addStockTransfer[1].Equals("0") == false)
            {
                sysSoftwareForm.AddTabPageStockTransferDetail(this, trnStockTransferController.DetailStockTransfer(Convert.ToInt32(addStockTransfer[1])));
                UpdateStockTransferDataSource();
            }
            else
            {
                MessageBox.Show(addStockTransfer[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
            sysSoftwareForm.RemoveTabPage();
        }

        private void dataGridViewStockTransfer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetStockTransferCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewStockTransfer.CurrentCell.ColumnIndex == dataGridViewStockTransfer.Columns["ColumnStockTransferButtonEdit"].Index)
            {
                Controllers.TrnStockTransferController trnStockTransferController = new Controllers.TrnStockTransferController();
                sysSoftwareForm.AddTabPageStockTransferDetail(this, trnStockTransferController.DetailStockTransfer(Convert.ToInt32(dataGridViewStockTransfer.Rows[e.RowIndex].Cells[2].Value)));
            }

            if (e.RowIndex > -1 && dataGridViewStockTransfer.CurrentCell.ColumnIndex == dataGridViewStockTransfer.Columns["ColumnStockTransferButtonDelete"].Index)
            {
                Boolean isLocked = Convert.ToBoolean(dataGridViewStockTransfer.Rows[e.RowIndex].Cells[dataGridViewStockTransfer.Columns["ColumnStockTransferIsLocked"].Index].Value);

                if (isLocked == true)
                {
                    MessageBox.Show("Already locked.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult deleteDialogResult = MessageBox.Show("Delete Stock-In?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (deleteDialogResult == DialogResult.Yes)
                    {
                        Controllers.TrnStockTransferController trnStockTransferController = new Controllers.TrnStockTransferController();

                        String[] deleteStockTransfer = trnStockTransferController.DeleteStockTransfer(Convert.ToInt32(dataGridViewStockTransfer.Rows[e.RowIndex].Cells[2].Value));
                        if (deleteStockTransfer[1].Equals("0") == false)
                        {
                            pageNumber = 1;
                            UpdateStockTransferDataSource();
                        }
                        else
                        {
                            MessageBox.Show(deleteStockTransfer[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void dateTimePickerStockTransferFilter_ValueChanged(object sender, EventArgs e)
        {
            UpdateStockTransferDataSource();
        }

        private void textBoxStockTransferFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateStockTransferDataSource();
            }
        }

        private void buttonStockTransferPageListFirst_Click(object sender, EventArgs e)
        {
            itemListPageList = new PagedList<Entities.DgvStockTransferEntity>(itemListData, 1, pageSize);
            itemListDataSource.DataSource = itemListPageList;

            buttonStockTransferPageListFirst.Enabled = false;
            buttonStockTransferPageListPrevious.Enabled = false;
            buttonStockTransferPageListNext.Enabled = true;
            buttonStockTransferPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxStockTransferPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonStockTransferPageListPrevious_Click(object sender, EventArgs e)
        {
            if (itemListPageList.HasPreviousPage == true)
            {
                itemListPageList = new PagedList<Entities.DgvStockTransferEntity>(itemListData, --pageNumber, pageSize);
                itemListDataSource.DataSource = itemListPageList;
            }

            buttonStockTransferPageListNext.Enabled = true;
            buttonStockTransferPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonStockTransferPageListFirst.Enabled = false;
                buttonStockTransferPageListPrevious.Enabled = false;
            }

            textBoxStockTransferPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonStockTransferPageListNext_Click(object sender, EventArgs e)
        {
            if (itemListPageList.HasNextPage == true)
            {
                itemListPageList = new PagedList<Entities.DgvStockTransferEntity>(itemListData, ++pageNumber, pageSize);
                itemListDataSource.DataSource = itemListPageList;
            }

            buttonStockTransferPageListFirst.Enabled = true;
            buttonStockTransferPageListPrevious.Enabled = true;

            if (pageNumber == itemListPageList.PageCount)
            {
                buttonStockTransferPageListNext.Enabled = false;
                buttonStockTransferPageListLast.Enabled = false;
            }

            textBoxStockTransferPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonStockTransferPageListLast_Click(object sender, EventArgs e)
        {
            itemListPageList = new PagedList<Entities.DgvStockTransferEntity>(itemListData, itemListPageList.PageCount, pageSize);
            itemListDataSource.DataSource = itemListPageList;

            buttonStockTransferPageListFirst.Enabled = true;
            buttonStockTransferPageListPrevious.Enabled = true;
            buttonStockTransferPageListNext.Enabled = false;
            buttonStockTransferPageListLast.Enabled = false;

            pageNumber = itemListPageList.PageCount;
            textBoxStockTransferPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }
    }
}
