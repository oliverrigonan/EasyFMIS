﻿namespace easyfmis.Forms.Software.TrnSalesInvoice
{
    partial class TrnSalesInvoiceDetailSearchItemForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnSalesInvoiceDetailSearchItemForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxSearchInventoryItemFilter = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonSearchInventoryItemPageListFirst = new System.Windows.Forms.Button();
            this.buttonSearchInventoryItemPageListPrevious = new System.Windows.Forms.Button();
            this.buttonSearchInventoryItemPageListNext = new System.Windows.Forms.Button();
            this.buttonSearchInventoryItemPageListLast = new System.Windows.Forms.Button();
            this.textBoxSearchInventoryItemPageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridViewSearchInventoryItem = new System.Windows.Forms.DataGridView();
            this.ColumnSearchInventoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchInventoryItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchInventoryItemBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchInventoryItemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchInventoryItemInventoryCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchInventoryItemUnitId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchInventoryItemUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchInventoryItemQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchInventoryItemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchInventoryItemButtonPick = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnSearchInventoryItemVATOutTaxId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchInventoryItemVATOutTaxRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchInventoryItemSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBoxSearchNonInventoryItemFilter = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonSearchNonInventoryItemPageListFirst = new System.Windows.Forms.Button();
            this.buttonSearchNonInventoryItemPageListPrevious = new System.Windows.Forms.Button();
            this.buttonSearchNonInventoryItemPageListNext = new System.Windows.Forms.Button();
            this.buttonSearchNonInventoryItemPageListLast = new System.Windows.Forms.Button();
            this.textBoxSearchNonInventoryItemPageNumber = new System.Windows.Forms.TextBox();
            this.dataGridViewSearchNonInventoryItem = new System.Windows.Forms.DataGridView();
            this.ColumnSearchNonInventoryItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchNonInventoryItemBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchNonInventoryItemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchNonInventoryItemUnitId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchNonInventoryItemUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchNonInventoryItemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchNonInventoryVATOutTaxId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchNonInventoryVATOutTaxRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchNonInventoryItemButtonPick = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchInventoryItem)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchNonInventoryItem)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 50);
            this.panel1.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.Item;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(50, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search Item";
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
            this.buttonClose.Location = new System.Drawing.Point(706, 10);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(70, 32);
            this.buttonClose.TabIndex = 20;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textBoxSearchInventoryItemFilter
            // 
            this.textBoxSearchInventoryItemFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearchInventoryItemFilter.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxSearchInventoryItemFilter.Location = new System.Drawing.Point(6, 5);
            this.textBoxSearchInventoryItemFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxSearchInventoryItemFilter.Name = "textBoxSearchInventoryItemFilter";
            this.textBoxSearchInventoryItemFilter.Size = new System.Drawing.Size(767, 26);
            this.textBoxSearchInventoryItemFilter.TabIndex = 0;
            this.textBoxSearchInventoryItemFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearchInventoryItemFilter_KeyDown);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonSearchInventoryItemPageListFirst);
            this.panel3.Controls.Add(this.buttonSearchInventoryItemPageListPrevious);
            this.panel3.Controls.Add(this.buttonSearchInventoryItemPageListNext);
            this.panel3.Controls.Add(this.buttonSearchInventoryItemPageListLast);
            this.panel3.Controls.Add(this.textBoxSearchInventoryItemPageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(2, 356);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(774, 42);
            this.panel3.TabIndex = 19;
            // 
            // buttonSearchInventoryItemPageListFirst
            // 
            this.buttonSearchInventoryItemPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSearchInventoryItemPageListFirst.Enabled = false;
            this.buttonSearchInventoryItemPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonSearchInventoryItemPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchInventoryItemPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSearchInventoryItemPageListFirst.Location = new System.Drawing.Point(10, 7);
            this.buttonSearchInventoryItemPageListFirst.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSearchInventoryItemPageListFirst.Name = "buttonSearchInventoryItemPageListFirst";
            this.buttonSearchInventoryItemPageListFirst.Size = new System.Drawing.Size(66, 26);
            this.buttonSearchInventoryItemPageListFirst.TabIndex = 13;
            this.buttonSearchInventoryItemPageListFirst.Text = "First";
            this.buttonSearchInventoryItemPageListFirst.UseVisualStyleBackColor = false;
            this.buttonSearchInventoryItemPageListFirst.Click += new System.EventHandler(this.buttonSearchInventoryItemPageListFirst_Click);
            // 
            // buttonSearchInventoryItemPageListPrevious
            // 
            this.buttonSearchInventoryItemPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSearchInventoryItemPageListPrevious.Enabled = false;
            this.buttonSearchInventoryItemPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonSearchInventoryItemPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchInventoryItemPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSearchInventoryItemPageListPrevious.Location = new System.Drawing.Point(80, 7);
            this.buttonSearchInventoryItemPageListPrevious.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSearchInventoryItemPageListPrevious.Name = "buttonSearchInventoryItemPageListPrevious";
            this.buttonSearchInventoryItemPageListPrevious.Size = new System.Drawing.Size(66, 26);
            this.buttonSearchInventoryItemPageListPrevious.TabIndex = 14;
            this.buttonSearchInventoryItemPageListPrevious.Text = "Previous";
            this.buttonSearchInventoryItemPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonSearchInventoryItemPageListPrevious.Click += new System.EventHandler(this.buttonSearchInventoryItemPageListPrevious_Click);
            // 
            // buttonSearchInventoryItemPageListNext
            // 
            this.buttonSearchInventoryItemPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSearchInventoryItemPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonSearchInventoryItemPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchInventoryItemPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSearchInventoryItemPageListNext.Location = new System.Drawing.Point(210, 7);
            this.buttonSearchInventoryItemPageListNext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSearchInventoryItemPageListNext.Name = "buttonSearchInventoryItemPageListNext";
            this.buttonSearchInventoryItemPageListNext.Size = new System.Drawing.Size(66, 26);
            this.buttonSearchInventoryItemPageListNext.TabIndex = 15;
            this.buttonSearchInventoryItemPageListNext.Text = "Next";
            this.buttonSearchInventoryItemPageListNext.UseVisualStyleBackColor = false;
            this.buttonSearchInventoryItemPageListNext.Click += new System.EventHandler(this.buttonSearchInventoryItemPageListNext_Click);
            // 
            // buttonSearchInventoryItemPageListLast
            // 
            this.buttonSearchInventoryItemPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSearchInventoryItemPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonSearchInventoryItemPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchInventoryItemPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSearchInventoryItemPageListLast.Location = new System.Drawing.Point(278, 7);
            this.buttonSearchInventoryItemPageListLast.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSearchInventoryItemPageListLast.Name = "buttonSearchInventoryItemPageListLast";
            this.buttonSearchInventoryItemPageListLast.Size = new System.Drawing.Size(66, 26);
            this.buttonSearchInventoryItemPageListLast.TabIndex = 16;
            this.buttonSearchInventoryItemPageListLast.Text = "Last";
            this.buttonSearchInventoryItemPageListLast.UseVisualStyleBackColor = false;
            this.buttonSearchInventoryItemPageListLast.Click += new System.EventHandler(this.buttonSearchInventoryItemPageListLast_Click);
            // 
            // textBoxSearchInventoryItemPageNumber
            // 
            this.textBoxSearchInventoryItemPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSearchInventoryItemPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxSearchInventoryItemPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSearchInventoryItemPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxSearchInventoryItemPageNumber.Location = new System.Drawing.Point(150, 11);
            this.textBoxSearchInventoryItemPageNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxSearchInventoryItemPageNumber.Name = "textBoxSearchInventoryItemPageNumber";
            this.textBoxSearchInventoryItemPageNumber.ReadOnly = true;
            this.textBoxSearchInventoryItemPageNumber.Size = new System.Drawing.Size(55, 16);
            this.textBoxSearchInventoryItemPageNumber.TabIndex = 17;
            this.textBoxSearchInventoryItemPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(786, 432);
            this.panel2.TabIndex = 10;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(786, 432);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBoxSearchInventoryItemFilter);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.dataGridViewSearchInventoryItem);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(778, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Inventory Items";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSearchInventoryItem
            // 
            this.dataGridViewSearchInventoryItem.AllowUserToAddRows = false;
            this.dataGridViewSearchInventoryItem.AllowUserToDeleteRows = false;
            this.dataGridViewSearchInventoryItem.AllowUserToResizeRows = false;
            this.dataGridViewSearchInventoryItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSearchInventoryItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewSearchInventoryItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSearchInventoryItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSearchInventoryId,
            this.ColumnSearchInventoryItemId,
            this.ColumnSearchInventoryItemBarCode,
            this.ColumnSearchInventoryItemDescription,
            this.ColumnSearchInventoryItemInventoryCode,
            this.ColumnSearchInventoryItemUnitId,
            this.ColumnSearchInventoryItemUnit,
            this.ColumnSearchInventoryItemQuantity,
            this.ColumnSearchInventoryItemPrice,
            this.ColumnSearchInventoryItemButtonPick,
            this.ColumnSearchInventoryItemVATOutTaxId,
            this.ColumnSearchInventoryItemVATOutTaxRate,
            this.ColumnSearchInventoryItemSpace});
            this.dataGridViewSearchInventoryItem.Location = new System.Drawing.Point(6, 34);
            this.dataGridViewSearchInventoryItem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewSearchInventoryItem.MultiSelect = false;
            this.dataGridViewSearchInventoryItem.Name = "dataGridViewSearchInventoryItem";
            this.dataGridViewSearchInventoryItem.ReadOnly = true;
            this.dataGridViewSearchInventoryItem.RowHeadersVisible = false;
            this.dataGridViewSearchInventoryItem.RowTemplate.Height = 24;
            this.dataGridViewSearchInventoryItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSearchInventoryItem.Size = new System.Drawing.Size(766, 320);
            this.dataGridViewSearchInventoryItem.TabIndex = 6;
            this.dataGridViewSearchInventoryItem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSearchInventoryItem_CellClick);
            // 
            // ColumnSearchInventoryId
            // 
            this.ColumnSearchInventoryId.DataPropertyName = "ColumnSearchInventoryId";
            this.ColumnSearchInventoryId.HeaderText = "Id";
            this.ColumnSearchInventoryId.Name = "ColumnSearchInventoryId";
            this.ColumnSearchInventoryId.ReadOnly = true;
            this.ColumnSearchInventoryId.Visible = false;
            // 
            // ColumnSearchInventoryItemId
            // 
            this.ColumnSearchInventoryItemId.DataPropertyName = "ColumnSearchInventoryItemId";
            this.ColumnSearchInventoryItemId.HeaderText = "ItemId";
            this.ColumnSearchInventoryItemId.Name = "ColumnSearchInventoryItemId";
            this.ColumnSearchInventoryItemId.ReadOnly = true;
            this.ColumnSearchInventoryItemId.Visible = false;
            // 
            // ColumnSearchInventoryItemBarCode
            // 
            this.ColumnSearchInventoryItemBarCode.DataPropertyName = "ColumnSearchInventoryItemBarCode";
            this.ColumnSearchInventoryItemBarCode.HeaderText = "Barcode";
            this.ColumnSearchInventoryItemBarCode.Name = "ColumnSearchInventoryItemBarCode";
            this.ColumnSearchInventoryItemBarCode.ReadOnly = true;
            // 
            // ColumnSearchInventoryItemDescription
            // 
            this.ColumnSearchInventoryItemDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSearchInventoryItemDescription.DataPropertyName = "ColumnSearchInventoryItemDescription";
            this.ColumnSearchInventoryItemDescription.HeaderText = "Item Description";
            this.ColumnSearchInventoryItemDescription.Name = "ColumnSearchInventoryItemDescription";
            this.ColumnSearchInventoryItemDescription.ReadOnly = true;
            // 
            // ColumnSearchInventoryItemInventoryCode
            // 
            this.ColumnSearchInventoryItemInventoryCode.DataPropertyName = "ColumnSearchInventoryItemInventoryCode";
            this.ColumnSearchInventoryItemInventoryCode.HeaderText = "Inventory Code";
            this.ColumnSearchInventoryItemInventoryCode.Name = "ColumnSearchInventoryItemInventoryCode";
            this.ColumnSearchInventoryItemInventoryCode.ReadOnly = true;
            this.ColumnSearchInventoryItemInventoryCode.Width = 150;
            // 
            // ColumnSearchInventoryItemUnitId
            // 
            this.ColumnSearchInventoryItemUnitId.DataPropertyName = "ColumnSearchInventoryItemUnitId";
            this.ColumnSearchInventoryItemUnitId.HeaderText = "UnitId";
            this.ColumnSearchInventoryItemUnitId.Name = "ColumnSearchInventoryItemUnitId";
            this.ColumnSearchInventoryItemUnitId.ReadOnly = true;
            this.ColumnSearchInventoryItemUnitId.Visible = false;
            // 
            // ColumnSearchInventoryItemUnit
            // 
            this.ColumnSearchInventoryItemUnit.DataPropertyName = "ColumnSearchInventoryItemUnit";
            this.ColumnSearchInventoryItemUnit.HeaderText = "Unit";
            this.ColumnSearchInventoryItemUnit.Name = "ColumnSearchInventoryItemUnit";
            this.ColumnSearchInventoryItemUnit.ReadOnly = true;
            this.ColumnSearchInventoryItemUnit.Width = 70;
            // 
            // ColumnSearchInventoryItemQuantity
            // 
            this.ColumnSearchInventoryItemQuantity.DataPropertyName = "ColumnSearchInventoryItemQuantity";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnSearchInventoryItemQuantity.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnSearchInventoryItemQuantity.HeaderText = "Qty.";
            this.ColumnSearchInventoryItemQuantity.Name = "ColumnSearchInventoryItemQuantity";
            this.ColumnSearchInventoryItemQuantity.ReadOnly = true;
            this.ColumnSearchInventoryItemQuantity.Width = 70;
            // 
            // ColumnSearchInventoryItemPrice
            // 
            this.ColumnSearchInventoryItemPrice.DataPropertyName = "ColumnSearchInventoryItemPrice";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnSearchInventoryItemPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnSearchInventoryItemPrice.HeaderText = "Price";
            this.ColumnSearchInventoryItemPrice.Name = "ColumnSearchInventoryItemPrice";
            this.ColumnSearchInventoryItemPrice.ReadOnly = true;
            this.ColumnSearchInventoryItemPrice.Width = 70;
            // 
            // ColumnSearchInventoryItemButtonPick
            // 
            this.ColumnSearchInventoryItemButtonPick.DataPropertyName = "ColumnSearchInventoryItemButtonPick";
            this.ColumnSearchInventoryItemButtonPick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnSearchInventoryItemButtonPick.HeaderText = "Pick";
            this.ColumnSearchInventoryItemButtonPick.Name = "ColumnSearchInventoryItemButtonPick";
            this.ColumnSearchInventoryItemButtonPick.ReadOnly = true;
            this.ColumnSearchInventoryItemButtonPick.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSearchInventoryItemButtonPick.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnSearchInventoryItemButtonPick.Width = 70;
            // 
            // ColumnSearchInventoryItemVATOutTaxId
            // 
            this.ColumnSearchInventoryItemVATOutTaxId.DataPropertyName = "ColumnSearchInventoryItemVATOutTaxId";
            this.ColumnSearchInventoryItemVATOutTaxId.HeaderText = "VAT Out Tax Id";
            this.ColumnSearchInventoryItemVATOutTaxId.Name = "ColumnSearchInventoryItemVATOutTaxId";
            this.ColumnSearchInventoryItemVATOutTaxId.ReadOnly = true;
            this.ColumnSearchInventoryItemVATOutTaxId.Visible = false;
            // 
            // ColumnSearchInventoryItemVATOutTaxRate
            // 
            this.ColumnSearchInventoryItemVATOutTaxRate.DataPropertyName = "ColumnSearchInventoryItemVATOutTaxRate";
            this.ColumnSearchInventoryItemVATOutTaxRate.HeaderText = "VAT OutT ax Rate";
            this.ColumnSearchInventoryItemVATOutTaxRate.Name = "ColumnSearchInventoryItemVATOutTaxRate";
            this.ColumnSearchInventoryItemVATOutTaxRate.ReadOnly = true;
            this.ColumnSearchInventoryItemVATOutTaxRate.Visible = false;
            // 
            // ColumnSearchInventoryItemSpace
            // 
            this.ColumnSearchInventoryItemSpace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSearchInventoryItemSpace.DataPropertyName = "ColumnSearchInventoryItemSpace";
            this.ColumnSearchInventoryItemSpace.HeaderText = "";
            this.ColumnSearchInventoryItemSpace.Name = "ColumnSearchInventoryItemSpace";
            this.ColumnSearchInventoryItemSpace.ReadOnly = true;
            this.ColumnSearchInventoryItemSpace.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBoxSearchNonInventoryItemFilter);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.dataGridViewSearchNonInventoryItem);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(778, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Non-Inventory Items";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBoxSearchNonInventoryItemFilter
            // 
            this.textBoxSearchNonInventoryItemFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearchNonInventoryItemFilter.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxSearchNonInventoryItemFilter.Location = new System.Drawing.Point(6, 5);
            this.textBoxSearchNonInventoryItemFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxSearchNonInventoryItemFilter.Name = "textBoxSearchNonInventoryItemFilter";
            this.textBoxSearchNonInventoryItemFilter.Size = new System.Drawing.Size(767, 26);
            this.textBoxSearchNonInventoryItemFilter.TabIndex = 0;
            this.textBoxSearchNonInventoryItemFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearchNonInventoryItemFilter_KeyDown);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.buttonSearchNonInventoryItemPageListFirst);
            this.panel4.Controls.Add(this.buttonSearchNonInventoryItemPageListPrevious);
            this.panel4.Controls.Add(this.buttonSearchNonInventoryItemPageListNext);
            this.panel4.Controls.Add(this.buttonSearchNonInventoryItemPageListLast);
            this.panel4.Controls.Add(this.textBoxSearchNonInventoryItemPageNumber);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(2, 356);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(774, 42);
            this.panel4.TabIndex = 22;
            // 
            // buttonSearchNonInventoryItemPageListFirst
            // 
            this.buttonSearchNonInventoryItemPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSearchNonInventoryItemPageListFirst.Enabled = false;
            this.buttonSearchNonInventoryItemPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonSearchNonInventoryItemPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchNonInventoryItemPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSearchNonInventoryItemPageListFirst.Location = new System.Drawing.Point(10, 7);
            this.buttonSearchNonInventoryItemPageListFirst.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSearchNonInventoryItemPageListFirst.Name = "buttonSearchNonInventoryItemPageListFirst";
            this.buttonSearchNonInventoryItemPageListFirst.Size = new System.Drawing.Size(66, 26);
            this.buttonSearchNonInventoryItemPageListFirst.TabIndex = 13;
            this.buttonSearchNonInventoryItemPageListFirst.Text = "First";
            this.buttonSearchNonInventoryItemPageListFirst.UseVisualStyleBackColor = false;
            this.buttonSearchNonInventoryItemPageListFirst.Click += new System.EventHandler(this.buttonSearchNonInventoryItemPageListFirst_Click);
            // 
            // buttonSearchNonInventoryItemPageListPrevious
            // 
            this.buttonSearchNonInventoryItemPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSearchNonInventoryItemPageListPrevious.Enabled = false;
            this.buttonSearchNonInventoryItemPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonSearchNonInventoryItemPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchNonInventoryItemPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSearchNonInventoryItemPageListPrevious.Location = new System.Drawing.Point(80, 7);
            this.buttonSearchNonInventoryItemPageListPrevious.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSearchNonInventoryItemPageListPrevious.Name = "buttonSearchNonInventoryItemPageListPrevious";
            this.buttonSearchNonInventoryItemPageListPrevious.Size = new System.Drawing.Size(66, 26);
            this.buttonSearchNonInventoryItemPageListPrevious.TabIndex = 14;
            this.buttonSearchNonInventoryItemPageListPrevious.Text = "Previous";
            this.buttonSearchNonInventoryItemPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonSearchNonInventoryItemPageListPrevious.Click += new System.EventHandler(this.buttonSearchNonInventoryItemPageListPrevious_Click);
            // 
            // buttonSearchNonInventoryItemPageListNext
            // 
            this.buttonSearchNonInventoryItemPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSearchNonInventoryItemPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonSearchNonInventoryItemPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchNonInventoryItemPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSearchNonInventoryItemPageListNext.Location = new System.Drawing.Point(210, 7);
            this.buttonSearchNonInventoryItemPageListNext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSearchNonInventoryItemPageListNext.Name = "buttonSearchNonInventoryItemPageListNext";
            this.buttonSearchNonInventoryItemPageListNext.Size = new System.Drawing.Size(66, 26);
            this.buttonSearchNonInventoryItemPageListNext.TabIndex = 15;
            this.buttonSearchNonInventoryItemPageListNext.Text = "Next";
            this.buttonSearchNonInventoryItemPageListNext.UseVisualStyleBackColor = false;
            this.buttonSearchNonInventoryItemPageListNext.Click += new System.EventHandler(this.buttonSearchNonInventoryItemPageListNext_Click);
            // 
            // buttonSearchNonInventoryItemPageListLast
            // 
            this.buttonSearchNonInventoryItemPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSearchNonInventoryItemPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonSearchNonInventoryItemPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchNonInventoryItemPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSearchNonInventoryItemPageListLast.Location = new System.Drawing.Point(278, 7);
            this.buttonSearchNonInventoryItemPageListLast.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSearchNonInventoryItemPageListLast.Name = "buttonSearchNonInventoryItemPageListLast";
            this.buttonSearchNonInventoryItemPageListLast.Size = new System.Drawing.Size(66, 26);
            this.buttonSearchNonInventoryItemPageListLast.TabIndex = 16;
            this.buttonSearchNonInventoryItemPageListLast.Text = "Last";
            this.buttonSearchNonInventoryItemPageListLast.UseVisualStyleBackColor = false;
            this.buttonSearchNonInventoryItemPageListLast.Click += new System.EventHandler(this.buttonSearchNonInventoryItemPageListLast_Click);
            // 
            // textBoxSearchNonInventoryItemPageNumber
            // 
            this.textBoxSearchNonInventoryItemPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSearchNonInventoryItemPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxSearchNonInventoryItemPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSearchNonInventoryItemPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxSearchNonInventoryItemPageNumber.Location = new System.Drawing.Point(150, 11);
            this.textBoxSearchNonInventoryItemPageNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxSearchNonInventoryItemPageNumber.Name = "textBoxSearchNonInventoryItemPageNumber";
            this.textBoxSearchNonInventoryItemPageNumber.ReadOnly = true;
            this.textBoxSearchNonInventoryItemPageNumber.Size = new System.Drawing.Size(55, 16);
            this.textBoxSearchNonInventoryItemPageNumber.TabIndex = 17;
            this.textBoxSearchNonInventoryItemPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridViewSearchNonInventoryItem
            // 
            this.dataGridViewSearchNonInventoryItem.AllowUserToAddRows = false;
            this.dataGridViewSearchNonInventoryItem.AllowUserToDeleteRows = false;
            this.dataGridViewSearchNonInventoryItem.AllowUserToResizeRows = false;
            this.dataGridViewSearchNonInventoryItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSearchNonInventoryItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewSearchNonInventoryItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSearchNonInventoryItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSearchNonInventoryItemId,
            this.ColumnSearchNonInventoryItemBarCode,
            this.ColumnSearchNonInventoryItemDescription,
            this.ColumnSearchNonInventoryItemUnitId,
            this.ColumnSearchNonInventoryItemUnit,
            this.ColumnSearchNonInventoryItemPrice,
            this.ColumnSearchNonInventoryVATOutTaxId,
            this.ColumnSearchNonInventoryVATOutTaxRate,
            this.ColumnSearchNonInventoryItemButtonPick});
            this.dataGridViewSearchNonInventoryItem.Location = new System.Drawing.Point(6, 34);
            this.dataGridViewSearchNonInventoryItem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewSearchNonInventoryItem.MultiSelect = false;
            this.dataGridViewSearchNonInventoryItem.Name = "dataGridViewSearchNonInventoryItem";
            this.dataGridViewSearchNonInventoryItem.ReadOnly = true;
            this.dataGridViewSearchNonInventoryItem.RowHeadersVisible = false;
            this.dataGridViewSearchNonInventoryItem.RowTemplate.Height = 24;
            this.dataGridViewSearchNonInventoryItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSearchNonInventoryItem.Size = new System.Drawing.Size(766, 320);
            this.dataGridViewSearchNonInventoryItem.TabIndex = 21;
            this.dataGridViewSearchNonInventoryItem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSearchNonInventoryItem_CellClick);
            // 
            // ColumnSearchNonInventoryItemId
            // 
            this.ColumnSearchNonInventoryItemId.DataPropertyName = "ColumnSearchNonInventoryItemId";
            this.ColumnSearchNonInventoryItemId.HeaderText = "ItemId";
            this.ColumnSearchNonInventoryItemId.Name = "ColumnSearchNonInventoryItemId";
            this.ColumnSearchNonInventoryItemId.ReadOnly = true;
            this.ColumnSearchNonInventoryItemId.Visible = false;
            // 
            // ColumnSearchNonInventoryItemBarCode
            // 
            this.ColumnSearchNonInventoryItemBarCode.DataPropertyName = "ColumnSearchNonInventoryItemBarCode";
            this.ColumnSearchNonInventoryItemBarCode.HeaderText = "Barcode";
            this.ColumnSearchNonInventoryItemBarCode.Name = "ColumnSearchNonInventoryItemBarCode";
            this.ColumnSearchNonInventoryItemBarCode.ReadOnly = true;
            this.ColumnSearchNonInventoryItemBarCode.Width = 150;
            // 
            // ColumnSearchNonInventoryItemDescription
            // 
            this.ColumnSearchNonInventoryItemDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSearchNonInventoryItemDescription.DataPropertyName = "ColumnSearchNonInventoryItemDescription";
            this.ColumnSearchNonInventoryItemDescription.HeaderText = "Item Description";
            this.ColumnSearchNonInventoryItemDescription.Name = "ColumnSearchNonInventoryItemDescription";
            this.ColumnSearchNonInventoryItemDescription.ReadOnly = true;
            // 
            // ColumnSearchNonInventoryItemUnitId
            // 
            this.ColumnSearchNonInventoryItemUnitId.DataPropertyName = "ColumnSearchNonInventoryItemUnitId";
            this.ColumnSearchNonInventoryItemUnitId.HeaderText = "UnitId";
            this.ColumnSearchNonInventoryItemUnitId.Name = "ColumnSearchNonInventoryItemUnitId";
            this.ColumnSearchNonInventoryItemUnitId.ReadOnly = true;
            this.ColumnSearchNonInventoryItemUnitId.Visible = false;
            // 
            // ColumnSearchNonInventoryItemUnit
            // 
            this.ColumnSearchNonInventoryItemUnit.DataPropertyName = "ColumnSearchNonInventoryItemUnit";
            this.ColumnSearchNonInventoryItemUnit.HeaderText = "Unit";
            this.ColumnSearchNonInventoryItemUnit.Name = "ColumnSearchNonInventoryItemUnit";
            this.ColumnSearchNonInventoryItemUnit.ReadOnly = true;
            // 
            // ColumnSearchNonInventoryItemPrice
            // 
            this.ColumnSearchNonInventoryItemPrice.DataPropertyName = "ColumnSearchNonInventoryItemPrice";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnSearchNonInventoryItemPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnSearchNonInventoryItemPrice.HeaderText = "Price";
            this.ColumnSearchNonInventoryItemPrice.Name = "ColumnSearchNonInventoryItemPrice";
            this.ColumnSearchNonInventoryItemPrice.ReadOnly = true;
            // 
            // ColumnSearchNonInventoryVATOutTaxId
            // 
            this.ColumnSearchNonInventoryVATOutTaxId.DataPropertyName = "ColumnSearchNonInventoryVATOutTaxId";
            this.ColumnSearchNonInventoryVATOutTaxId.HeaderText = "VAT Out Tax Id";
            this.ColumnSearchNonInventoryVATOutTaxId.Name = "ColumnSearchNonInventoryVATOutTaxId";
            this.ColumnSearchNonInventoryVATOutTaxId.ReadOnly = true;
            this.ColumnSearchNonInventoryVATOutTaxId.Visible = false;
            // 
            // ColumnSearchNonInventoryVATOutTaxRate
            // 
            this.ColumnSearchNonInventoryVATOutTaxRate.DataPropertyName = "ColumnSearchNonInventoryVATOutTaxRate";
            this.ColumnSearchNonInventoryVATOutTaxRate.HeaderText = "VAT Out Tax Rate";
            this.ColumnSearchNonInventoryVATOutTaxRate.Name = "ColumnSearchNonInventoryVATOutTaxRate";
            this.ColumnSearchNonInventoryVATOutTaxRate.ReadOnly = true;
            this.ColumnSearchNonInventoryVATOutTaxRate.Visible = false;
            // 
            // ColumnSearchNonInventoryItemButtonPick
            // 
            this.ColumnSearchNonInventoryItemButtonPick.DataPropertyName = "ColumnSearchNonInventoryItemButtonPick";
            this.ColumnSearchNonInventoryItemButtonPick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnSearchNonInventoryItemButtonPick.HeaderText = "Pick";
            this.ColumnSearchNonInventoryItemButtonPick.Name = "ColumnSearchNonInventoryItemButtonPick";
            this.ColumnSearchNonInventoryItemButtonPick.ReadOnly = true;
            this.ColumnSearchNonInventoryItemButtonPick.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSearchNonInventoryItemButtonPick.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnSearchNonInventoryItemButtonPick.Width = 70;
            // 
            // TrnSalesInvoiceDetailSearchItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(786, 482);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TrnSalesInvoiceDetailSearchItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Item";
            this.Load += new System.EventHandler(this.TrnSalesInvoiceDetailSearchItemForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchInventoryItem)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchNonInventoryItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox textBoxSearchInventoryItemFilter;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonSearchInventoryItemPageListFirst;
        private System.Windows.Forms.Button buttonSearchInventoryItemPageListPrevious;
        private System.Windows.Forms.Button buttonSearchInventoryItemPageListNext;
        private System.Windows.Forms.Button buttonSearchInventoryItemPageListLast;
        private System.Windows.Forms.TextBox textBoxSearchInventoryItemPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxSearchNonInventoryItemFilter;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonSearchNonInventoryItemPageListFirst;
        private System.Windows.Forms.Button buttonSearchNonInventoryItemPageListPrevious;
        private System.Windows.Forms.Button buttonSearchNonInventoryItemPageListNext;
        private System.Windows.Forms.Button buttonSearchNonInventoryItemPageListLast;
        private System.Windows.Forms.TextBox textBoxSearchNonInventoryItemPageNumber;
        private System.Windows.Forms.DataGridView dataGridViewSearchNonInventoryItem;
        private System.Windows.Forms.DataGridView dataGridViewSearchInventoryItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchNonInventoryItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchNonInventoryItemBarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchNonInventoryItemDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchNonInventoryItemUnitId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchNonInventoryItemUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchNonInventoryItemPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchNonInventoryVATOutTaxId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchNonInventoryVATOutTaxRate;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnSearchNonInventoryItemButtonPick;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchInventoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchInventoryItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchInventoryItemBarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchInventoryItemDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchInventoryItemInventoryCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchInventoryItemUnitId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchInventoryItemUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchInventoryItemQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchInventoryItemPrice;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnSearchInventoryItemButtonPick;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchInventoryItemVATOutTaxId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchInventoryItemVATOutTaxRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchInventoryItemSpace;
    }
}