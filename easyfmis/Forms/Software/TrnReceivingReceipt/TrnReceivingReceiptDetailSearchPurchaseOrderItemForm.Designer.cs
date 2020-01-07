namespace easyfmis.Forms.Software.TrnReceivingReceipt
{
    partial class TrnReceivingReceiptDetailSearchPurchaseOrderItemForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnReceivingReceiptDetailSearchPurchaseOrderItemForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.dataGridViewSearchPurchaseOrderItem = new System.Windows.Forms.DataGridView();
            this.ColumnSearchPurchaseOrderItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchPurchaseOrderItemBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchPurchaseOrderItemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchPurchaseOrderItemUnitId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchPurchaseOrderItemUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchPurchaseOrderItemBaseQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchPurchaseOrderItemBaseCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchPurchaseOrderItemVATInTaxId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchPurchaseOrderItemVATInTaxRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchPurchaseOrderItemButtonPick = new System.Windows.Forms.DataGridViewButtonColumn();
            this.textBoxSearchPurchaseOrderItemFilter = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonSearchPurchaseOrderItemPageListFirst = new System.Windows.Forms.Button();
            this.buttonSearchPurchaseOrderItemPageListPrevious = new System.Windows.Forms.Button();
            this.buttonSearchPurchaseOrderItemPageListNext = new System.Windows.Forms.Button();
            this.buttonSearchPurchaseOrderItemPageListLast = new System.Windows.Forms.Button();
            this.textBoxSearchPurchaseOrderItemPageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBoxPONumber = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchPurchaseOrderItem)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 63);
            this.panel1.TabIndex = 9;
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
            this.label1.Size = new System.Drawing.Size(342, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search Purchase Order Item";
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
            this.buttonClose.Location = new System.Drawing.Point(882, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(88, 40);
            this.buttonClose.TabIndex = 20;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // dataGridViewSearchPurchaseOrderItem
            // 
            this.dataGridViewSearchPurchaseOrderItem.AllowUserToAddRows = false;
            this.dataGridViewSearchPurchaseOrderItem.AllowUserToDeleteRows = false;
            this.dataGridViewSearchPurchaseOrderItem.AllowUserToResizeRows = false;
            this.dataGridViewSearchPurchaseOrderItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSearchPurchaseOrderItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSearchPurchaseOrderItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSearchPurchaseOrderItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSearchPurchaseOrderItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSearchPurchaseOrderItemId,
            this.ColumnSearchPurchaseOrderItemBarCode,
            this.ColumnSearchPurchaseOrderItemDescription,
            this.ColumnSearchPurchaseOrderItemUnitId,
            this.ColumnSearchPurchaseOrderItemUnit,
            this.ColumnSearchPurchaseOrderItemBaseQuantity,
            this.ColumnSearchPurchaseOrderItemBaseCost,
            this.ColumnSearchPurchaseOrderItemVATInTaxId,
            this.ColumnSearchPurchaseOrderItemVATInTaxRate,
            this.ColumnSearchPurchaseOrderItemButtonPick});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSearchPurchaseOrderItem.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewSearchPurchaseOrderItem.Location = new System.Drawing.Point(12, 43);
            this.dataGridViewSearchPurchaseOrderItem.MultiSelect = false;
            this.dataGridViewSearchPurchaseOrderItem.Name = "dataGridViewSearchPurchaseOrderItem";
            this.dataGridViewSearchPurchaseOrderItem.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSearchPurchaseOrderItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewSearchPurchaseOrderItem.RowHeadersVisible = false;
            this.dataGridViewSearchPurchaseOrderItem.RowTemplate.Height = 24;
            this.dataGridViewSearchPurchaseOrderItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSearchPurchaseOrderItem.Size = new System.Drawing.Size(958, 438);
            this.dataGridViewSearchPurchaseOrderItem.TabIndex = 6;
            this.dataGridViewSearchPurchaseOrderItem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSearchPurchaseOrderItem_CellClick);
            // 
            // ColumnSearchPurchaseOrderItemId
            // 
            this.ColumnSearchPurchaseOrderItemId.DataPropertyName = "ColumnSearchPurchaseOrderItemId";
            this.ColumnSearchPurchaseOrderItemId.HeaderText = "Id";
            this.ColumnSearchPurchaseOrderItemId.Name = "ColumnSearchPurchaseOrderItemId";
            this.ColumnSearchPurchaseOrderItemId.ReadOnly = true;
            this.ColumnSearchPurchaseOrderItemId.Visible = false;
            // 
            // ColumnSearchPurchaseOrderItemBarCode
            // 
            this.ColumnSearchPurchaseOrderItemBarCode.DataPropertyName = "ColumnSearchPurchaseOrderItemBarCode";
            this.ColumnSearchPurchaseOrderItemBarCode.HeaderText = "Bar Code";
            this.ColumnSearchPurchaseOrderItemBarCode.Name = "ColumnSearchPurchaseOrderItemBarCode";
            this.ColumnSearchPurchaseOrderItemBarCode.ReadOnly = true;
            this.ColumnSearchPurchaseOrderItemBarCode.Width = 150;
            // 
            // ColumnSearchPurchaseOrderItemDescription
            // 
            this.ColumnSearchPurchaseOrderItemDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSearchPurchaseOrderItemDescription.DataPropertyName = "ColumnSearchPurchaseOrderItemDescription";
            this.ColumnSearchPurchaseOrderItemDescription.HeaderText = "Item Description";
            this.ColumnSearchPurchaseOrderItemDescription.Name = "ColumnSearchPurchaseOrderItemDescription";
            this.ColumnSearchPurchaseOrderItemDescription.ReadOnly = true;
            // 
            // ColumnSearchPurchaseOrderItemUnitId
            // 
            this.ColumnSearchPurchaseOrderItemUnitId.DataPropertyName = "ColumnSearchPurchaseOrderItemUnitId";
            this.ColumnSearchPurchaseOrderItemUnitId.HeaderText = "UnitId";
            this.ColumnSearchPurchaseOrderItemUnitId.Name = "ColumnSearchPurchaseOrderItemUnitId";
            this.ColumnSearchPurchaseOrderItemUnitId.ReadOnly = true;
            this.ColumnSearchPurchaseOrderItemUnitId.Visible = false;
            // 
            // ColumnSearchPurchaseOrderItemUnit
            // 
            this.ColumnSearchPurchaseOrderItemUnit.DataPropertyName = "ColumnSearchPurchaseOrderItemUnit";
            this.ColumnSearchPurchaseOrderItemUnit.HeaderText = "Unit";
            this.ColumnSearchPurchaseOrderItemUnit.Name = "ColumnSearchPurchaseOrderItemUnit";
            this.ColumnSearchPurchaseOrderItemUnit.ReadOnly = true;
            // 
            // ColumnSearchPurchaseOrderItemBaseQuantity
            // 
            this.ColumnSearchPurchaseOrderItemBaseQuantity.DataPropertyName = "ColumnSearchPurchaseOrderItemBaseQuantity";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnSearchPurchaseOrderItemBaseQuantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnSearchPurchaseOrderItemBaseQuantity.HeaderText = "Quantity";
            this.ColumnSearchPurchaseOrderItemBaseQuantity.Name = "ColumnSearchPurchaseOrderItemBaseQuantity";
            this.ColumnSearchPurchaseOrderItemBaseQuantity.ReadOnly = true;
            // 
            // ColumnSearchPurchaseOrderItemBaseCost
            // 
            this.ColumnSearchPurchaseOrderItemBaseCost.DataPropertyName = "ColumnSearchPurchaseOrderItemBaseCost";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnSearchPurchaseOrderItemBaseCost.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnSearchPurchaseOrderItemBaseCost.HeaderText = "Cost";
            this.ColumnSearchPurchaseOrderItemBaseCost.Name = "ColumnSearchPurchaseOrderItemBaseCost";
            this.ColumnSearchPurchaseOrderItemBaseCost.ReadOnly = true;
            // 
            // ColumnSearchPurchaseOrderItemVATInTaxId
            // 
            this.ColumnSearchPurchaseOrderItemVATInTaxId.DataPropertyName = "ColumnSearchPurchaseOrderItemVATInTaxId";
            this.ColumnSearchPurchaseOrderItemVATInTaxId.HeaderText = "VAT In Tax Id";
            this.ColumnSearchPurchaseOrderItemVATInTaxId.Name = "ColumnSearchPurchaseOrderItemVATInTaxId";
            this.ColumnSearchPurchaseOrderItemVATInTaxId.ReadOnly = true;
            this.ColumnSearchPurchaseOrderItemVATInTaxId.Visible = false;
            // 
            // ColumnSearchPurchaseOrderItemVATInTaxRate
            // 
            this.ColumnSearchPurchaseOrderItemVATInTaxRate.DataPropertyName = "ColumnSearchPurchaseOrderItemVATInTaxRate";
            this.ColumnSearchPurchaseOrderItemVATInTaxRate.HeaderText = "VAT In Tax Rate";
            this.ColumnSearchPurchaseOrderItemVATInTaxRate.Name = "ColumnSearchPurchaseOrderItemVATInTaxRate";
            this.ColumnSearchPurchaseOrderItemVATInTaxRate.ReadOnly = true;
            this.ColumnSearchPurchaseOrderItemVATInTaxRate.Visible = false;
            // 
            // ColumnSearchPurchaseOrderItemButtonPick
            // 
            this.ColumnSearchPurchaseOrderItemButtonPick.DataPropertyName = "ColumnSearchPurchaseOrderItemButtonPick";
            this.ColumnSearchPurchaseOrderItemButtonPick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnSearchPurchaseOrderItemButtonPick.HeaderText = "Pick";
            this.ColumnSearchPurchaseOrderItemButtonPick.Name = "ColumnSearchPurchaseOrderItemButtonPick";
            this.ColumnSearchPurchaseOrderItemButtonPick.ReadOnly = true;
            this.ColumnSearchPurchaseOrderItemButtonPick.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSearchPurchaseOrderItemButtonPick.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnSearchPurchaseOrderItemButtonPick.Width = 70;
            // 
            // textBoxSearchPurchaseOrderItemFilter
            // 
            this.textBoxSearchPurchaseOrderItemFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearchPurchaseOrderItemFilter.Font = new System.Drawing.Font("Segoe UI", 10.7F);
            this.textBoxSearchPurchaseOrderItemFilter.Location = new System.Drawing.Point(263, 7);
            this.textBoxSearchPurchaseOrderItemFilter.Name = "textBoxSearchPurchaseOrderItemFilter";
            this.textBoxSearchPurchaseOrderItemFilter.Size = new System.Drawing.Size(707, 31);
            this.textBoxSearchPurchaseOrderItemFilter.TabIndex = 1;
            this.textBoxSearchPurchaseOrderItemFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearchPurchaseOrderItemFilter_KeyDown);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonSearchPurchaseOrderItemPageListFirst);
            this.panel3.Controls.Add(this.buttonSearchPurchaseOrderItemPageListPrevious);
            this.panel3.Controls.Add(this.buttonSearchPurchaseOrderItemPageListNext);
            this.panel3.Controls.Add(this.buttonSearchPurchaseOrderItemPageListLast);
            this.panel3.Controls.Add(this.textBoxSearchPurchaseOrderItemPageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 487);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(982, 53);
            this.panel3.TabIndex = 19;
            // 
            // buttonSearchPurchaseOrderItemPageListFirst
            // 
            this.buttonSearchPurchaseOrderItemPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSearchPurchaseOrderItemPageListFirst.Enabled = false;
            this.buttonSearchPurchaseOrderItemPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonSearchPurchaseOrderItemPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchPurchaseOrderItemPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSearchPurchaseOrderItemPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonSearchPurchaseOrderItemPageListFirst.Name = "buttonSearchPurchaseOrderItemPageListFirst";
            this.buttonSearchPurchaseOrderItemPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonSearchPurchaseOrderItemPageListFirst.TabIndex = 13;
            this.buttonSearchPurchaseOrderItemPageListFirst.Text = "First";
            this.buttonSearchPurchaseOrderItemPageListFirst.UseVisualStyleBackColor = false;
            this.buttonSearchPurchaseOrderItemPageListFirst.Click += new System.EventHandler(this.buttonSearchPurchaseOrderItemPageListFirst_Click);
            // 
            // buttonSearchPurchaseOrderItemPageListPrevious
            // 
            this.buttonSearchPurchaseOrderItemPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSearchPurchaseOrderItemPageListPrevious.Enabled = false;
            this.buttonSearchPurchaseOrderItemPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonSearchPurchaseOrderItemPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchPurchaseOrderItemPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSearchPurchaseOrderItemPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonSearchPurchaseOrderItemPageListPrevious.Name = "buttonSearchPurchaseOrderItemPageListPrevious";
            this.buttonSearchPurchaseOrderItemPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonSearchPurchaseOrderItemPageListPrevious.TabIndex = 14;
            this.buttonSearchPurchaseOrderItemPageListPrevious.Text = "Previous";
            this.buttonSearchPurchaseOrderItemPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonSearchPurchaseOrderItemPageListPrevious.Click += new System.EventHandler(this.buttonSearchPurchaseOrderItemPageListPrevious_Click);
            // 
            // buttonSearchPurchaseOrderItemPageListNext
            // 
            this.buttonSearchPurchaseOrderItemPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSearchPurchaseOrderItemPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonSearchPurchaseOrderItemPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchPurchaseOrderItemPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSearchPurchaseOrderItemPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonSearchPurchaseOrderItemPageListNext.Name = "buttonSearchPurchaseOrderItemPageListNext";
            this.buttonSearchPurchaseOrderItemPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonSearchPurchaseOrderItemPageListNext.TabIndex = 15;
            this.buttonSearchPurchaseOrderItemPageListNext.Text = "Next";
            this.buttonSearchPurchaseOrderItemPageListNext.UseVisualStyleBackColor = false;
            this.buttonSearchPurchaseOrderItemPageListNext.Click += new System.EventHandler(this.buttonSearchPurchaseOrderItemPageListNext_Click);
            // 
            // buttonSearchPurchaseOrderItemPageListLast
            // 
            this.buttonSearchPurchaseOrderItemPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSearchPurchaseOrderItemPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonSearchPurchaseOrderItemPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchPurchaseOrderItemPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSearchPurchaseOrderItemPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonSearchPurchaseOrderItemPageListLast.Name = "buttonSearchPurchaseOrderItemPageListLast";
            this.buttonSearchPurchaseOrderItemPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonSearchPurchaseOrderItemPageListLast.TabIndex = 16;
            this.buttonSearchPurchaseOrderItemPageListLast.Text = "Last";
            this.buttonSearchPurchaseOrderItemPageListLast.UseVisualStyleBackColor = false;
            this.buttonSearchPurchaseOrderItemPageListLast.Click += new System.EventHandler(this.buttonSearchPurchaseOrderItemPageListLast_Click);
            // 
            // textBoxSearchPurchaseOrderItemPageNumber
            // 
            this.textBoxSearchPurchaseOrderItemPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSearchPurchaseOrderItemPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxSearchPurchaseOrderItemPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSearchPurchaseOrderItemPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxSearchPurchaseOrderItemPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxSearchPurchaseOrderItemPageNumber.Name = "textBoxSearchPurchaseOrderItemPageNumber";
            this.textBoxSearchPurchaseOrderItemPageNumber.ReadOnly = true;
            this.textBoxSearchPurchaseOrderItemPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxSearchPurchaseOrderItemPageNumber.TabIndex = 17;
            this.textBoxSearchPurchaseOrderItemPageNumber.TabStop = false;
            this.textBoxSearchPurchaseOrderItemPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBoxPONumber);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.textBoxSearchPurchaseOrderItemFilter);
            this.panel2.Controls.Add(this.dataGridViewSearchPurchaseOrderItem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(982, 540);
            this.panel2.TabIndex = 10;
            this.panel2.TabStop = true;
            // 
            // comboBoxPONumber
            // 
            this.comboBoxPONumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxPONumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPONumber.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.comboBoxPONumber.FormattingEnabled = true;
            this.comboBoxPONumber.IntegralHeight = false;
            this.comboBoxPONumber.ItemHeight = 23;
            this.comboBoxPONumber.Location = new System.Drawing.Point(12, 6);
            this.comboBoxPONumber.Name = "comboBoxPONumber";
            this.comboBoxPONumber.Size = new System.Drawing.Size(245, 31);
            this.comboBoxPONumber.TabIndex = 0;
            this.comboBoxPONumber.SelectedIndexChanged += new System.EventHandler(this.comboBoxPONumber_SelectedIndexChanged);
            // 
            // TrnReceivingReceiptDetailSearchPurchaseOrderItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(982, 603);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrnReceivingReceiptDetailSearchPurchaseOrderItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Purchase Order Item";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchPurchaseOrderItem)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.DataGridView dataGridViewSearchPurchaseOrderItem;
        private System.Windows.Forms.TextBox textBoxSearchPurchaseOrderItemFilter;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonSearchPurchaseOrderItemPageListFirst;
        private System.Windows.Forms.Button buttonSearchPurchaseOrderItemPageListPrevious;
        private System.Windows.Forms.Button buttonSearchPurchaseOrderItemPageListNext;
        private System.Windows.Forms.Button buttonSearchPurchaseOrderItemPageListLast;
        private System.Windows.Forms.TextBox textBoxSearchPurchaseOrderItemPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBoxPONumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchPurchaseOrderItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchPurchaseOrderItemBarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchPurchaseOrderItemDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchPurchaseOrderItemUnitId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchPurchaseOrderItemUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchPurchaseOrderItemBaseQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchPurchaseOrderItemBaseCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchPurchaseOrderItemVATInTaxId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchPurchaseOrderItemVATInTaxRate;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnSearchPurchaseOrderItemButtonPick;
    }
}