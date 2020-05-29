namespace easyfmis.Forms.Software.SysUtilities
{
    partial class SysUtilitiesItemPriceCostForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SysUtilitiesItemPriceCostForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxItemListFilter = new System.Windows.Forms.TextBox();
            this.dataGridViewItemList = new System.Windows.Forms.DataGridView();
            this.ColumnSysMenuItemListItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSysMenuItemListItemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSysMenuItemListOnHandQuatity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSysMenuItemListUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSysMenuItemListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridViewPriceList = new System.Windows.Forms.DataGridView();
            this.ColumnPriceDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCostList = new System.Windows.Forms.DataGridView();
            this.ColumnCostDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.buttonItemListPageListFirst = new System.Windows.Forms.Button();
            this.buttonItemListPageListPrevious = new System.Windows.Forms.Button();
            this.buttonItemListPageListNext = new System.Windows.Forms.Button();
            this.buttonItemListPageListLast = new System.Windows.Forms.Button();
            this.textBoxItemListPageNumber = new System.Windows.Forms.TextBox();
            this.backgroundWorkerEasyfisIntegration = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemList)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPriceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCostList)).BeginInit();
            this.panel6.SuspendLayout();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1386, 62);
            this.panel1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.costpricet;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
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
            this.label1.Location = new System.Drawing.Point(62, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Item Price and Cost";
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
            this.buttonClose.Location = new System.Drawing.Point(1286, 12);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(88, 40);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 62);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1386, 638);
            this.panel2.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1386, 638);
            this.panel3.TabIndex = 21;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.textBoxItemListFilter);
            this.panel4.Controls.Add(this.dataGridViewItemList);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(934, 585);
            this.panel4.TabIndex = 27;
            // 
            // textBoxItemListFilter
            // 
            this.textBoxItemListFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxItemListFilter.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxItemListFilter.Location = new System.Drawing.Point(12, 5);
            this.textBoxItemListFilter.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxItemListFilter.Name = "textBoxItemListFilter";
            this.textBoxItemListFilter.Size = new System.Drawing.Size(916, 30);
            this.textBoxItemListFilter.TabIndex = 24;
            this.textBoxItemListFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxItemListFilter_KeyDown);
            // 
            // dataGridViewItemList
            // 
            this.dataGridViewItemList.AllowUserToAddRows = false;
            this.dataGridViewItemList.AllowUserToDeleteRows = false;
            this.dataGridViewItemList.AllowUserToResizeRows = false;
            this.dataGridViewItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewItemList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSysMenuItemListItemCode,
            this.ColumnSysMenuItemListItemDescription,
            this.ColumnSysMenuItemListOnHandQuatity,
            this.ColumnSysMenuItemListUnit,
            this.ColumnSysMenuItemListId});
            this.dataGridViewItemList.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewItemList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewItemList.MultiSelect = false;
            this.dataGridViewItemList.Name = "dataGridViewItemList";
            this.dataGridViewItemList.ReadOnly = true;
            this.dataGridViewItemList.RowHeadersVisible = false;
            this.dataGridViewItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewItemList.Size = new System.Drawing.Size(918, 536);
            this.dataGridViewItemList.TabIndex = 23;
            this.dataGridViewItemList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewItemList_CellClick);
            // 
            // ColumnSysMenuItemListItemCode
            // 
            this.ColumnSysMenuItemListItemCode.DataPropertyName = "ColumnSysMenuItemListItemCode";
            this.ColumnSysMenuItemListItemCode.HeaderText = "Item Code";
            this.ColumnSysMenuItemListItemCode.Name = "ColumnSysMenuItemListItemCode";
            this.ColumnSysMenuItemListItemCode.ReadOnly = true;
            this.ColumnSysMenuItemListItemCode.Width = 150;
            // 
            // ColumnSysMenuItemListItemDescription
            // 
            this.ColumnSysMenuItemListItemDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSysMenuItemListItemDescription.DataPropertyName = "ColumnSysMenuItemListItemDescription";
            this.ColumnSysMenuItemListItemDescription.HeaderText = "Description";
            this.ColumnSysMenuItemListItemDescription.Name = "ColumnSysMenuItemListItemDescription";
            this.ColumnSysMenuItemListItemDescription.ReadOnly = true;
            // 
            // ColumnSysMenuItemListOnHandQuatity
            // 
            this.ColumnSysMenuItemListOnHandQuatity.DataPropertyName = "ColumnSysMenuItemListOnHandQuatity";
            this.ColumnSysMenuItemListOnHandQuatity.HeaderText = "On Hand Qty";
            this.ColumnSysMenuItemListOnHandQuatity.Name = "ColumnSysMenuItemListOnHandQuatity";
            this.ColumnSysMenuItemListOnHandQuatity.ReadOnly = true;
            this.ColumnSysMenuItemListOnHandQuatity.Width = 120;
            // 
            // ColumnSysMenuItemListUnit
            // 
            this.ColumnSysMenuItemListUnit.DataPropertyName = "ColumnSysMenuItemListUnit";
            this.ColumnSysMenuItemListUnit.HeaderText = "Unit";
            this.ColumnSysMenuItemListUnit.Name = "ColumnSysMenuItemListUnit";
            this.ColumnSysMenuItemListUnit.ReadOnly = true;
            // 
            // ColumnSysMenuItemListId
            // 
            this.ColumnSysMenuItemListId.DataPropertyName = "ColumnSysMenuItemListId";
            this.ColumnSysMenuItemListId.FillWeight = 1F;
            this.ColumnSysMenuItemListId.HeaderText = "";
            this.ColumnSysMenuItemListId.MaxInputLength = 1;
            this.ColumnSysMenuItemListId.Name = "ColumnSysMenuItemListId";
            this.ColumnSysMenuItemListId.ReadOnly = true;
            this.ColumnSysMenuItemListId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnSysMenuItemListId.Visible = false;
            this.ColumnSysMenuItemListId.Width = 5;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dataGridViewPriceList);
            this.panel5.Controls.Add(this.dataGridViewCostList);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(938, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(448, 586);
            this.panel5.TabIndex = 26;
            // 
            // dataGridViewPriceList
            // 
            this.dataGridViewPriceList.AllowUserToAddRows = false;
            this.dataGridViewPriceList.AllowUserToDeleteRows = false;
            this.dataGridViewPriceList.AllowUserToResizeColumns = false;
            this.dataGridViewPriceList.AllowUserToResizeRows = false;
            this.dataGridViewPriceList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPriceList.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewPriceList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPriceList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewPriceList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPriceList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPriceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPriceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPriceDescription,
            this.ColumnPrice});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPriceList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewPriceList.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewPriceList.Location = new System.Drawing.Point(4, 42);
            this.dataGridViewPriceList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewPriceList.Name = "dataGridViewPriceList";
            this.dataGridViewPriceList.ReadOnly = true;
            this.dataGridViewPriceList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPriceList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewPriceList.RowHeadersVisible = false;
            this.dataGridViewPriceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPriceList.Size = new System.Drawing.Size(431, 263);
            this.dataGridViewPriceList.TabIndex = 24;
            // 
            // ColumnPriceDescription
            // 
            this.ColumnPriceDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnPriceDescription.HeaderText = "Price Description";
            this.ColumnPriceDescription.Name = "ColumnPriceDescription";
            this.ColumnPriceDescription.ReadOnly = true;
            // 
            // ColumnPrice
            // 
            this.ColumnPrice.HeaderText = "Price";
            this.ColumnPrice.Name = "ColumnPrice";
            this.ColumnPrice.ReadOnly = true;
            this.ColumnPrice.Width = 150;
            // 
            // dataGridViewCostList
            // 
            this.dataGridViewCostList.AllowUserToAddRows = false;
            this.dataGridViewCostList.AllowUserToDeleteRows = false;
            this.dataGridViewCostList.AllowUserToResizeColumns = false;
            this.dataGridViewCostList.AllowUserToResizeRows = false;
            this.dataGridViewCostList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCostList.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewCostList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCostList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewCostList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCostList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewCostList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCostList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCostDescription,
            this.ColumnCost});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCostList.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewCostList.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewCostList.Location = new System.Drawing.Point(1, 315);
            this.dataGridViewCostList.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewCostList.Name = "dataGridViewCostList";
            this.dataGridViewCostList.ReadOnly = true;
            this.dataGridViewCostList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCostList.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewCostList.RowHeadersVisible = false;
            this.dataGridViewCostList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCostList.Size = new System.Drawing.Size(431, 263);
            this.dataGridViewCostList.TabIndex = 25;
            // 
            // ColumnCostDescription
            // 
            this.ColumnCostDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnCostDescription.HeaderText = "Cost Description";
            this.ColumnCostDescription.Name = "ColumnCostDescription";
            this.ColumnCostDescription.ReadOnly = true;
            // 
            // ColumnCost
            // 
            this.ColumnCost.HeaderText = "Cost";
            this.ColumnCost.Name = "ColumnCost";
            this.ColumnCost.ReadOnly = true;
            this.ColumnCost.Width = 150;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel6.Controls.Add(this.buttonItemListPageListFirst);
            this.panel6.Controls.Add(this.buttonItemListPageListPrevious);
            this.panel6.Controls.Add(this.buttonItemListPageListNext);
            this.panel6.Controls.Add(this.buttonItemListPageListLast);
            this.panel6.Controls.Add(this.textBoxItemListPageNumber);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 586);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1386, 52);
            this.panel6.TabIndex = 22;
            // 
            // buttonItemListPageListFirst
            // 
            this.buttonItemListPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonItemListPageListFirst.Enabled = false;
            this.buttonItemListPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonItemListPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItemListPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonItemListPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonItemListPageListFirst.Margin = new System.Windows.Forms.Padding(2);
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
            this.buttonItemListPageListPrevious.Margin = new System.Windows.Forms.Padding(2);
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
            this.buttonItemListPageListNext.Location = new System.Drawing.Point(262, 9);
            this.buttonItemListPageListNext.Margin = new System.Windows.Forms.Padding(2);
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
            this.buttonItemListPageListLast.Margin = new System.Windows.Forms.Padding(2);
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
            this.textBoxItemListPageNumber.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxItemListPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxItemListPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxItemListPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxItemListPageNumber.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxItemListPageNumber.Name = "textBoxItemListPageNumber";
            this.textBoxItemListPageNumber.ReadOnly = true;
            this.textBoxItemListPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxItemListPageNumber.TabIndex = 17;
            this.textBoxItemListPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // backgroundWorkerEasyfisIntegration
            // 
            this.backgroundWorkerEasyfisIntegration.WorkerReportsProgress = true;
            this.backgroundWorkerEasyfisIntegration.WorkerSupportsCancellation = true;
            // 
            // SysUtilitiesItemPriceCostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1386, 700);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "SysUtilitiesItemPriceCostForm";
            this.Text = "Settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemList)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPriceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCostList)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panel2;
        private System.ComponentModel.BackgroundWorker backgroundWorkerEasyfisIntegration;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBoxItemListFilter;
        private System.Windows.Forms.DataGridView dataGridViewItemList;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGridViewPriceList;
        private System.Windows.Forms.DataGridView dataGridViewCostList;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button buttonItemListPageListFirst;
        private System.Windows.Forms.Button buttonItemListPageListPrevious;
        private System.Windows.Forms.Button buttonItemListPageListNext;
        private System.Windows.Forms.Button buttonItemListPageListLast;
        private System.Windows.Forms.TextBox textBoxItemListPageNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSysMenuItemListItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSysMenuItemListItemDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSysMenuItemListOnHandQuatity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSysMenuItemListUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSysMenuItemListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPriceDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCostDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCost;
    }
}