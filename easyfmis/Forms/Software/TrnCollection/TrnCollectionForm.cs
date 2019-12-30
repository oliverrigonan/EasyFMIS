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

namespace easyfmis.Forms.Software.TrnCollection
{
    public partial class TrnCollectionForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public static List<Entities.DgvCollectionEntity> itemListData = new List<Entities.DgvCollectionEntity>();
        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;
        public PagedList<Entities.DgvCollectionEntity> itemListPageList = new PagedList<Entities.DgvCollectionEntity>(itemListData, pageNumber, pageSize);
        public BindingSource itemListDataSource = new BindingSource();

        public TrnCollectionForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            CreateCollectionDataGridView();
        }

        public void UpdateCollectionDataSource()
        {
            SetCollectionDataSourceAsync();
        }

        public async void SetCollectionDataSourceAsync()
        {
            List<Entities.DgvCollectionEntity> getCollectionData = await GetCollectionDataTask();
            if (getCollectionData.Any())
            {
                itemListData = getCollectionData;
                itemListPageList = new PagedList<Entities.DgvCollectionEntity>(itemListData, pageNumber, pageSize);

                if (itemListPageList.PageCount == 1)
                {
                    buttonCollectionPageListFirst.Enabled = false;
                    buttonCollectionPageListPrevious.Enabled = false;
                    buttonCollectionPageListNext.Enabled = false;
                    buttonCollectionPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonCollectionPageListFirst.Enabled = false;
                    buttonCollectionPageListPrevious.Enabled = false;
                    buttonCollectionPageListNext.Enabled = true;
                    buttonCollectionPageListLast.Enabled = true;
                }
                else if (pageNumber == itemListPageList.PageCount)
                {
                    buttonCollectionPageListFirst.Enabled = true;
                    buttonCollectionPageListPrevious.Enabled = true;
                    buttonCollectionPageListNext.Enabled = false;
                    buttonCollectionPageListLast.Enabled = false;
                }
                else
                {
                    buttonCollectionPageListFirst.Enabled = true;
                    buttonCollectionPageListPrevious.Enabled = true;
                    buttonCollectionPageListNext.Enabled = true;
                    buttonCollectionPageListLast.Enabled = true;
                }

                textBoxCollectionPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
                itemListDataSource.DataSource = itemListPageList;
            }
            else
            {
                buttonCollectionPageListFirst.Enabled = false;
                buttonCollectionPageListPrevious.Enabled = false;
                buttonCollectionPageListNext.Enabled = false;
                buttonCollectionPageListLast.Enabled = false;

                pageNumber = 1;

                itemListData = new List<Entities.DgvCollectionEntity>();
                itemListDataSource.Clear();
                textBoxCollectionPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvCollectionEntity>> GetCollectionDataTask()
        {
            DateTime startDateFilter = dateTimePickerCollectionFilterDateStart.Value.Date;
            DateTime endDateFilter = dateTimePickerCollectionFilterDateEnd.Value.Date;

            String filter = textBoxCollectionFilter.Text;
            Controllers.TrnCollectionController trnCollectionController = new Controllers.TrnCollectionController();

            List<Entities.TrnCollectionEntity> listCollection = trnCollectionController.ListCollection(startDateFilter, endDateFilter, filter);
            if (listCollection.Any())
            {
                var items = from d in listCollection
                            select new Entities.DgvCollectionEntity
                            {
                                ColumnCollectionButtonEdit = "Edit",
                                ColumnCollectionButtonDelete = "Delete",
                                ColumnCollectionId = d.Id,
                                ColumnCollectionORDate = d.ORDate.ToShortDateString(),
                                ColumnCollectionORNumber = d.ORNumber,
                                ColumnCollectionCustomer = d.Customer,
                                ColumnCollectionRemarks = d.Remarks,
                                ColumnCollectionIsLocked = d.IsLocked,
                                ColumnCollectionSpace = ""
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvCollectionEntity>());
            }
        }

        public void CreateCollectionDataGridView()
        {
            UpdateCollectionDataSource();

            dataGridViewCollection.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewCollection.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewCollection.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewCollection.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewCollection.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewCollection.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewCollection.DataSource = itemListDataSource;
        }

        public void GetCollectionCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Controllers.TrnCollectionController trnCollectionController = new Controllers.TrnCollectionController();
            String[] addCollection = trnCollectionController.AddCollection();
            if (addCollection[1].Equals("0") == false)
            {
                sysSoftwareForm.AddTabPageCollectionDetail(this, trnCollectionController.DetailCollection(Convert.ToInt32(addCollection[1])));
                UpdateCollectionDataSource();
            }
            else
            {
                MessageBox.Show(addCollection[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
            sysSoftwareForm.RemoveTabPage();
        }

        private void dataGridViewCollection_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetCollectionCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewCollection.CurrentCell.ColumnIndex == dataGridViewCollection.Columns["ColumnCollectionButtonEdit"].Index)
            {
                Controllers.TrnCollectionController trnCollectionController = new Controllers.TrnCollectionController();
                sysSoftwareForm.AddTabPageCollectionDetail(this, trnCollectionController.DetailCollection(Convert.ToInt32(dataGridViewCollection.Rows[e.RowIndex].Cells[2].Value)));
            }

            if (e.RowIndex > -1 && dataGridViewCollection.CurrentCell.ColumnIndex == dataGridViewCollection.Columns["ColumnCollectionButtonDelete"].Index)
            {
                Boolean isLocked = Convert.ToBoolean(dataGridViewCollection.Rows[e.RowIndex].Cells[dataGridViewCollection.Columns["ColumnCollectionIsLocked"].Index].Value);

                if (isLocked == true)
                {
                    MessageBox.Show("Already locked.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult deleteDialogResult = MessageBox.Show("Delete Stock-In?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (deleteDialogResult == DialogResult.Yes)
                    {
                        Controllers.TrnCollectionController trnCollectionController = new Controllers.TrnCollectionController();

                        String[] deleteCollection = trnCollectionController.DeleteCollection(Convert.ToInt32(dataGridViewCollection.Rows[e.RowIndex].Cells[2].Value));
                        if (deleteCollection[1].Equals("0") == false)
                        {
                            pageNumber = 1;
                            UpdateCollectionDataSource();
                        }
                        else
                        {
                            MessageBox.Show(deleteCollection[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void dateTimePickerCollectionFilterStartDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateCollectionDataSource();
        }

        private void dateTimePickerCollectionFilterEndDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateCollectionDataSource();
        }

        private void textBoxCollectionFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateCollectionDataSource();
            }
        }

        private void buttonCollectionPageListFirst_Click(object sender, EventArgs e)
        {
            itemListPageList = new PagedList<Entities.DgvCollectionEntity>(itemListData, 1, pageSize);
            itemListDataSource.DataSource = itemListPageList;

            buttonCollectionPageListFirst.Enabled = false;
            buttonCollectionPageListPrevious.Enabled = false;
            buttonCollectionPageListNext.Enabled = true;
            buttonCollectionPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxCollectionPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonCollectionPageListPrevious_Click(object sender, EventArgs e)
        {
            if (itemListPageList.HasPreviousPage == true)
            {
                itemListPageList = new PagedList<Entities.DgvCollectionEntity>(itemListData, --pageNumber, pageSize);
                itemListDataSource.DataSource = itemListPageList;
            }

            buttonCollectionPageListNext.Enabled = true;
            buttonCollectionPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonCollectionPageListFirst.Enabled = false;
                buttonCollectionPageListPrevious.Enabled = false;
            }

            textBoxCollectionPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonCollectionPageListNext_Click(object sender, EventArgs e)
        {
            if (itemListPageList.HasNextPage == true)
            {
                itemListPageList = new PagedList<Entities.DgvCollectionEntity>(itemListData, ++pageNumber, pageSize);
                itemListDataSource.DataSource = itemListPageList;
            }

            buttonCollectionPageListFirst.Enabled = true;
            buttonCollectionPageListPrevious.Enabled = true;

            if (pageNumber == itemListPageList.PageCount)
            {
                buttonCollectionPageListNext.Enabled = false;
                buttonCollectionPageListLast.Enabled = false;
            }

            textBoxCollectionPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonCollectionPageListLast_Click(object sender, EventArgs e)
        {
            itemListPageList = new PagedList<Entities.DgvCollectionEntity>(itemListData, itemListPageList.PageCount, pageSize);
            itemListDataSource.DataSource = itemListPageList;

            buttonCollectionPageListFirst.Enabled = true;
            buttonCollectionPageListPrevious.Enabled = true;
            buttonCollectionPageListNext.Enabled = false;
            buttonCollectionPageListLast.Enabled = false;

            pageNumber = itemListPageList.PageCount;
            textBoxCollectionPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }
    }
}
