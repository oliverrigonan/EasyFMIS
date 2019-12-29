namespace easyfmis.Forms.Software.MstItem
{
    partial class MstItemListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBoxItemListFilter = new System.Windows.Forms.TextBox();
            this.buttonItemListPageListFirst = new System.Windows.Forms.Button();
            this.buttonItemListPageListPrevious = new System.Windows.Forms.Button();
            this.buttonItemListPageListNext = new System.Windows.Forms.Button();
            this.buttonItemListPageListLast = new System.Windows.Forms.Button();
            this.textBoxItemListPageNumber = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewItemList = new System.Windows.Forms.DataGridView();
            this.ColumnItemListButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnItemListButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnItemListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemListArticleTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemListArticleCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemListDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemListArticleBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemListArticleAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemListGenericArticleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemListCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemListVATInTaxId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemListVATInTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemListVATOutTaxId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemListVATOutTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemListUnitId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemListUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemListDefaultSupplierId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemListDefaultCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemListPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemListOnHandQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemListIsInventory = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnItemListIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnItemListSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxItemListFilter
            // 
            this.textBoxItemListFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxItemListFilter.Location = new System.Drawing.Point(12, 6);
            this.textBoxItemListFilter.Name = "textBoxItemListFilter";
            this.textBoxItemListFilter.Size = new System.Drawing.Size(1376, 30);
            this.textBoxItemListFilter.TabIndex = 0;
            this.textBoxItemListFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxItemListFilter_KeyDown);
            // 
            // buttonItemListPageListFirst
            // 
            this.buttonItemListPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonItemListPageListFirst.Enabled = false;
            this.buttonItemListPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonItemListPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItemListPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonItemListPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonItemListPageListFirst.Name = "buttonItemListPageListFirst";
            this.buttonItemListPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonItemListPageListFirst.TabIndex = 13;
            this.buttonItemListPageListFirst.Text = "First";
            this.buttonItemListPageListFirst.UseVisualStyleBackColor = false;
            this.buttonItemListPageListFirst.Click += new System.EventHandler(this.buttonItemListPageListFirst_Click);
            // 
            // buttonItemListPageListPrevious
            // 
            this.buttonItemListPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonItemListPageListPrevious.Enabled = false;
            this.buttonItemListPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonItemListPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItemListPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonItemListPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonItemListPageListPrevious.Name = "buttonItemListPageListPrevious";
            this.buttonItemListPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonItemListPageListPrevious.TabIndex = 14;
            this.buttonItemListPageListPrevious.Text = "Previous";
            this.buttonItemListPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonItemListPageListPrevious.Click += new System.EventHandler(this.buttonItemListPageListPrevious_Click);
            // 
            // buttonItemListPageListNext
            // 
            this.buttonItemListPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonItemListPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonItemListPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItemListPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonItemListPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonItemListPageListNext.Name = "buttonItemListPageListNext";
            this.buttonItemListPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonItemListPageListNext.TabIndex = 15;
            this.buttonItemListPageListNext.Text = "Next";
            this.buttonItemListPageListNext.UseVisualStyleBackColor = false;
            this.buttonItemListPageListNext.Click += new System.EventHandler(this.buttonItemListPageListNext_Click);
            // 
            // buttonItemListPageListLast
            // 
            this.buttonItemListPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonItemListPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonItemListPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItemListPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonItemListPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonItemListPageListLast.Name = "buttonItemListPageListLast";
            this.buttonItemListPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonItemListPageListLast.TabIndex = 16;
            this.buttonItemListPageListLast.Text = "Last";
            this.buttonItemListPageListLast.UseVisualStyleBackColor = false;
            this.buttonItemListPageListLast.Click += new System.EventHandler(this.buttonItemListPageListLast_Click);
            // 
            // textBoxItemListPageNumber
            // 
            this.textBoxItemListPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxItemListPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxItemListPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxItemListPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxItemListPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxItemListPageNumber.Name = "textBoxItemListPageNumber";
            this.textBoxItemListPageNumber.ReadOnly = true;
            this.textBoxItemListPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxItemListPageNumber.TabIndex = 17;
            this.textBoxItemListPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonItemListPageListFirst);
            this.panel3.Controls.Add(this.buttonItemListPageListPrevious);
            this.panel3.Controls.Add(this.buttonItemListPageListNext);
            this.panel3.Controls.Add(this.buttonItemListPageListLast);
            this.panel3.Controls.Add(this.textBoxItemListPageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 584);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1400, 53);
            this.panel3.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewItemList);
            this.panel2.Controls.Add(this.textBoxItemListFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1400, 637);
            this.panel2.TabIndex = 21;
            // 
            // dataGridViewItemList
            // 
            this.dataGridViewItemList.AllowUserToAddRows = false;
            this.dataGridViewItemList.AllowUserToDeleteRows = false;
            this.dataGridViewItemList.AllowUserToOrderColumns = true;
            this.dataGridViewItemList.AllowUserToResizeRows = false;
            this.dataGridViewItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewItemList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnItemListButtonEdit,
            this.ColumnItemListButtonDelete,
            this.ColumnItemListId,
            this.ColumnItemListArticleTypeId,
            this.ColumnItemListArticleCode,
            this.ColumnItemListDescription,
            this.ColumnItemListArticleBarCode,
            this.ColumnItemListArticleAlias,
            this.ColumnItemListGenericArticleName,
            this.ColumnItemListCategory,
            this.ColumnItemListVATInTaxId,
            this.ColumnItemListVATInTax,
            this.ColumnItemListVATOutTaxId,
            this.ColumnItemListVATOutTax,
            this.ColumnItemListUnitId,
            this.ColumnItemListUnit,
            this.ColumnItemListDefaultSupplierId,
            this.ColumnItemListDefaultCost,
            this.ColumnItemListPrice,
            this.ColumnItemListOnHandQuantity,
            this.ColumnItemListIsInventory,
            this.ColumnItemListIsLocked,
            this.ColumnItemListSpace});
            this.dataGridViewItemList.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewItemList.MultiSelect = false;
            this.dataGridViewItemList.Name = "dataGridViewItemList";
            this.dataGridViewItemList.ReadOnly = true;
            this.dataGridViewItemList.RowHeadersVisible = false;
            this.dataGridViewItemList.RowTemplate.Height = 24;
            this.dataGridViewItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewItemList.Size = new System.Drawing.Size(1376, 536);
            this.dataGridViewItemList.TabIndex = 9;
            this.dataGridViewItemList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewItemList_CellClick);
            // 
            // ColumnItemListButtonEdit
            // 
            this.ColumnItemListButtonEdit.DataPropertyName = "ColumnItemListButtonEdit";
            this.ColumnItemListButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnItemListButtonEdit.HeaderText = "";
            this.ColumnItemListButtonEdit.Name = "ColumnItemListButtonEdit";
            this.ColumnItemListButtonEdit.ReadOnly = true;
            this.ColumnItemListButtonEdit.Width = 70;
            // 
            // ColumnItemListButtonDelete
            // 
            this.ColumnItemListButtonDelete.DataPropertyName = "ColumnItemListButtonDelete";
            this.ColumnItemListButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnItemListButtonDelete.HeaderText = "";
            this.ColumnItemListButtonDelete.Name = "ColumnItemListButtonDelete";
            this.ColumnItemListButtonDelete.ReadOnly = true;
            this.ColumnItemListButtonDelete.Width = 70;
            // 
            // ColumnItemListId
            // 
            this.ColumnItemListId.DataPropertyName = "ColumnItemListId";
            this.ColumnItemListId.HeaderText = "Id";
            this.ColumnItemListId.Name = "ColumnItemListId";
            this.ColumnItemListId.ReadOnly = true;
            this.ColumnItemListId.Visible = false;
            // 
            // ColumnItemListArticleTypeId
            // 
            this.ColumnItemListArticleTypeId.DataPropertyName = "ColumnItemListArticleTypeId";
            this.ColumnItemListArticleTypeId.HeaderText = "ArticleTypeId";
            this.ColumnItemListArticleTypeId.Name = "ColumnItemListArticleTypeId";
            this.ColumnItemListArticleTypeId.ReadOnly = true;
            this.ColumnItemListArticleTypeId.Visible = false;
            // 
            // ColumnItemListArticleCode
            // 
            this.ColumnItemListArticleCode.DataPropertyName = "ColumnItemListArticleCode";
            this.ColumnItemListArticleCode.HeaderText = "Code";
            this.ColumnItemListArticleCode.Name = "ColumnItemListArticleCode";
            this.ColumnItemListArticleCode.ReadOnly = true;
            this.ColumnItemListArticleCode.Width = 150;
            // 
            // ColumnItemListDescription
            // 
            this.ColumnItemListDescription.DataPropertyName = "ColumnItemListArticle";
            this.ColumnItemListDescription.HeaderText = "Item Description";
            this.ColumnItemListDescription.Name = "ColumnItemListDescription";
            this.ColumnItemListDescription.ReadOnly = true;
            this.ColumnItemListDescription.Width = 250;
            // 
            // ColumnItemListArticleBarCode
            // 
            this.ColumnItemListArticleBarCode.DataPropertyName = "ColumnItemListArticleBarCode";
            this.ColumnItemListArticleBarCode.HeaderText = "BarCode";
            this.ColumnItemListArticleBarCode.Name = "ColumnItemListArticleBarCode";
            this.ColumnItemListArticleBarCode.ReadOnly = true;
            this.ColumnItemListArticleBarCode.Width = 150;
            // 
            // ColumnItemListArticleAlias
            // 
            this.ColumnItemListArticleAlias.DataPropertyName = "ColumnItemListArticleAlias";
            this.ColumnItemListArticleAlias.HeaderText = "ArticleAlias";
            this.ColumnItemListArticleAlias.Name = "ColumnItemListArticleAlias";
            this.ColumnItemListArticleAlias.ReadOnly = true;
            this.ColumnItemListArticleAlias.Visible = false;
            this.ColumnItemListArticleAlias.Width = 250;
            // 
            // ColumnItemListGenericArticleName
            // 
            this.ColumnItemListGenericArticleName.DataPropertyName = "ColumnItemListGenericArticleName";
            this.ColumnItemListGenericArticleName.HeaderText = "GenericArticleName";
            this.ColumnItemListGenericArticleName.Name = "ColumnItemListGenericArticleName";
            this.ColumnItemListGenericArticleName.ReadOnly = true;
            this.ColumnItemListGenericArticleName.Visible = false;
            this.ColumnItemListGenericArticleName.Width = 300;
            // 
            // ColumnItemListCategory
            // 
            this.ColumnItemListCategory.DataPropertyName = "ColumnItemListCategory";
            this.ColumnItemListCategory.HeaderText = "Category";
            this.ColumnItemListCategory.Name = "ColumnItemListCategory";
            this.ColumnItemListCategory.ReadOnly = true;
            this.ColumnItemListCategory.Width = 150;
            // 
            // ColumnItemListVATInTaxId
            // 
            this.ColumnItemListVATInTaxId.DataPropertyName = "ColumnItemListVATInTaxId";
            this.ColumnItemListVATInTaxId.HeaderText = "VATInTaxId";
            this.ColumnItemListVATInTaxId.Name = "ColumnItemListVATInTaxId";
            this.ColumnItemListVATInTaxId.ReadOnly = true;
            this.ColumnItemListVATInTaxId.Visible = false;
            // 
            // ColumnItemListVATInTax
            // 
            this.ColumnItemListVATInTax.DataPropertyName = "ColumnItemListVATInTax";
            this.ColumnItemListVATInTax.HeaderText = "VATInTax";
            this.ColumnItemListVATInTax.Name = "ColumnItemListVATInTax";
            this.ColumnItemListVATInTax.ReadOnly = true;
            this.ColumnItemListVATInTax.Visible = false;
            this.ColumnItemListVATInTax.Width = 150;
            // 
            // ColumnItemListVATOutTaxId
            // 
            this.ColumnItemListVATOutTaxId.DataPropertyName = "ColumnItemListVATOutTaxId";
            this.ColumnItemListVATOutTaxId.HeaderText = "VATOutTaxId";
            this.ColumnItemListVATOutTaxId.Name = "ColumnItemListVATOutTaxId";
            this.ColumnItemListVATOutTaxId.ReadOnly = true;
            this.ColumnItemListVATOutTaxId.Visible = false;
            // 
            // ColumnItemListVATOutTax
            // 
            this.ColumnItemListVATOutTax.DataPropertyName = "ColumnItemListVATOutTax";
            this.ColumnItemListVATOutTax.HeaderText = "VATOutTax";
            this.ColumnItemListVATOutTax.Name = "ColumnItemListVATOutTax";
            this.ColumnItemListVATOutTax.ReadOnly = true;
            this.ColumnItemListVATOutTax.Visible = false;
            this.ColumnItemListVATOutTax.Width = 150;
            // 
            // ColumnItemListUnitId
            // 
            this.ColumnItemListUnitId.DataPropertyName = "ColumnItemListUnitId";
            this.ColumnItemListUnitId.HeaderText = "UnitId";
            this.ColumnItemListUnitId.Name = "ColumnItemListUnitId";
            this.ColumnItemListUnitId.ReadOnly = true;
            this.ColumnItemListUnitId.Visible = false;
            // 
            // ColumnItemListUnit
            // 
            this.ColumnItemListUnit.DataPropertyName = "ColumnItemListUnit";
            this.ColumnItemListUnit.HeaderText = "Unit";
            this.ColumnItemListUnit.Name = "ColumnItemListUnit";
            this.ColumnItemListUnit.ReadOnly = true;
            // 
            // ColumnItemListDefaultSupplierId
            // 
            this.ColumnItemListDefaultSupplierId.DataPropertyName = "ColumnItemListDefaultSupplierId";
            this.ColumnItemListDefaultSupplierId.HeaderText = "DefaultSupplierId";
            this.ColumnItemListDefaultSupplierId.Name = "ColumnItemListDefaultSupplierId";
            this.ColumnItemListDefaultSupplierId.ReadOnly = true;
            this.ColumnItemListDefaultSupplierId.Visible = false;
            // 
            // ColumnItemListDefaultCost
            // 
            this.ColumnItemListDefaultCost.DataPropertyName = "ColumnItemListDefaultCost";
            this.ColumnItemListDefaultCost.HeaderText = "Cost";
            this.ColumnItemListDefaultCost.Name = "ColumnItemListDefaultCost";
            this.ColumnItemListDefaultCost.ReadOnly = true;
            this.ColumnItemListDefaultCost.Visible = false;
            // 
            // ColumnItemListPrice
            // 
            this.ColumnItemListPrice.DataPropertyName = "ColumnItemListDefaultPrice";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnItemListPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnItemListPrice.HeaderText = "Price";
            this.ColumnItemListPrice.Name = "ColumnItemListPrice";
            this.ColumnItemListPrice.ReadOnly = true;
            // 
            // ColumnItemListOnHandQuantity
            // 
            this.ColumnItemListOnHandQuantity.DataPropertyName = "ColumnItemListReorderQuantity";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnItemListOnHandQuantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnItemListOnHandQuantity.HeaderText = "Reorder Qty.";
            this.ColumnItemListOnHandQuantity.Name = "ColumnItemListOnHandQuantity";
            this.ColumnItemListOnHandQuantity.ReadOnly = true;
            this.ColumnItemListOnHandQuantity.Visible = false;
            this.ColumnItemListOnHandQuantity.Width = 150;
            // 
            // ColumnItemListIsInventory
            // 
            this.ColumnItemListIsInventory.DataPropertyName = "ColumnItemListIsInventory";
            this.ColumnItemListIsInventory.HeaderText = "I";
            this.ColumnItemListIsInventory.Name = "ColumnItemListIsInventory";
            this.ColumnItemListIsInventory.ReadOnly = true;
            this.ColumnItemListIsInventory.Width = 35;
            // 
            // ColumnItemListIsLocked
            // 
            this.ColumnItemListIsLocked.DataPropertyName = "ColumnItemListIsLocked";
            this.ColumnItemListIsLocked.HeaderText = "L";
            this.ColumnItemListIsLocked.Name = "ColumnItemListIsLocked";
            this.ColumnItemListIsLocked.ReadOnly = true;
            this.ColumnItemListIsLocked.Width = 35;
            // 
            // ColumnItemListSpace
            // 
            this.ColumnItemListSpace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnItemListSpace.DataPropertyName = "ColumnItemListSpace";
            this.ColumnItemListSpace.HeaderText = "";
            this.ColumnItemListSpace.Name = "ColumnItemListSpace";
            this.ColumnItemListSpace.ReadOnly = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.Item;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(63, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Item List";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.buttonAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1400, 63);
            this.panel1.TabIndex = 20;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(79)))), ((int)(((byte)(28)))));
            this.buttonClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(79)))), ((int)(((byte)(28)))));
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(1300, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(88, 40);
            this.buttonClose.TabIndex = 21;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(1206, 12);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(88, 40);
            this.buttonAdd.TabIndex = 20;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // MstItemListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1400, 700);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MstItemListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MstItemForm";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxItemListFilter;
        private System.Windows.Forms.Button buttonItemListPageListFirst;
        private System.Windows.Forms.Button buttonItemListPageListPrevious;
        private System.Windows.Forms.Button buttonItemListPageListNext;
        private System.Windows.Forms.Button buttonItemListPageListLast;
        private System.Windows.Forms.TextBox textBoxItemListPageNumber;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewItemList;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnItemListButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnItemListButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListArticleTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListArticleCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListArticleBarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListArticleAlias;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListGenericArticleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListVATInTaxId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListVATInTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListVATOutTaxId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListVATOutTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListUnitId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListDefaultSupplierId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListDefaultCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListOnHandQuantity;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnItemListIsInventory;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnItemListIsLocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListSpace;
    }
}