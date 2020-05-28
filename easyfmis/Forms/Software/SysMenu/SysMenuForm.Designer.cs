namespace easyfmis.Forms.Software.SysMenu
{
    partial class SysMenuForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SysMenuForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle56 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle57 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle58 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle59 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle60 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageListMenuIcons = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxItemListFilter = new System.Windows.Forms.TextBox();
            this.dataGridViewItemList = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewPriceList = new System.Windows.Forms.DataGridView();
            this.ColumnPriceDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCostList = new System.Windows.Forms.DataGridView();
            this.ColumnCostDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonItemListPageListFirst = new System.Windows.Forms.Button();
            this.buttonItemListPageListPrevious = new System.Windows.Forms.Button();
            this.buttonItemListPageListNext = new System.Windows.Forms.Button();
            this.buttonItemListPageListLast = new System.Windows.Forms.Button();
            this.textBoxItemListPageNumber = new System.Windows.Forms.TextBox();
            this.buttonCollection = new System.Windows.Forms.Button();
            this.buttonDisbursement = new System.Windows.Forms.Button();
            this.buttonAccountsReceivableReport = new System.Windows.Forms.Button();
            this.buttonStockTransfer = new System.Windows.Forms.Button();
            this.buttonItem = new System.Windows.Forms.Button();
            this.buttonUser = new System.Windows.Forms.Button();
            this.buttonCompany = new System.Windows.Forms.Button();
            this.buttonReceivingReceipt = new System.Windows.Forms.Button();
            this.buttonSupplier = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonCustomer = new System.Windows.Forms.Button();
            this.buttonMemo = new System.Windows.Forms.Button();
            this.buttonSystemTables = new System.Windows.Forms.Button();
            this.buttonAccountsPayableReport = new System.Windows.Forms.Button();
            this.buttonSalesOrder = new System.Windows.Forms.Button();
            this.buttonPurchaseOrder = new System.Windows.Forms.Button();
            this.buttonStockOut = new System.Windows.Forms.Button();
            this.buttonSalesInvoice = new System.Windows.Forms.Button();
            this.buttonStockIn = new System.Windows.Forms.Button();
            this.buttonInventoryReport = new System.Windows.Forms.Button();
            this.ColumnSysMenuItemListItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSysMenuItemListItemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSysMenuItemListOnHandQuatity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSysMenuItemListUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSysMenuItemListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemList)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPriceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCostList)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageListMenuIcons
            // 
            this.imageListMenuIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMenuIcons.ImageStream")));
            this.imageListMenuIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMenuIcons.Images.SetKeyName(0, "Customer.png");
            this.imageListMenuIcons.Images.SetKeyName(1, "Disbursement.png");
            this.imageListMenuIcons.Images.SetKeyName(2, "Discounting.png");
            this.imageListMenuIcons.Images.SetKeyName(3, "Inventory.png");
            this.imageListMenuIcons.Images.SetKeyName(4, "Item.png");
            this.imageListMenuIcons.Images.SetKeyName(5, "POS.png");
            this.imageListMenuIcons.Images.SetKeyName(6, "Reports.png");
            this.imageListMenuIcons.Images.SetKeyName(7, "Utilities.png");
            this.imageListMenuIcons.Images.SetKeyName(8, "User.png");
            this.imageListMenuIcons.Images.SetKeyName(9, "Stock In.png");
            this.imageListMenuIcons.Images.SetKeyName(10, "Stock Out.png");
            this.imageListMenuIcons.Images.SetKeyName(11, "Settings.png");
            this.imageListMenuIcons.Images.SetKeyName(12, "Stock Count.png");
            this.imageListMenuIcons.Images.SetKeyName(13, "System Tables.png");
            this.imageListMenuIcons.Images.SetKeyName(14, "Company.png");
            this.imageListMenuIcons.Images.SetKeyName(15, "Supplier.png");
            this.imageListMenuIcons.Images.SetKeyName(16, "Purchase Order.png");
            this.imageListMenuIcons.Images.SetKeyName(17, "Receiving Receipt.png");
            this.imageListMenuIcons.Images.SetKeyName(18, "Collection.png");
            this.imageListMenuIcons.Images.SetKeyName(19, "Sales Order.png");
            this.imageListMenuIcons.Images.SetKeyName(20, "Stock Transfer.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.buttonCollection);
            this.panel1.Controls.Add(this.buttonDisbursement);
            this.panel1.Controls.Add(this.buttonAccountsReceivableReport);
            this.panel1.Controls.Add(this.buttonStockTransfer);
            this.panel1.Controls.Add(this.buttonItem);
            this.panel1.Controls.Add(this.buttonUser);
            this.panel1.Controls.Add(this.buttonCompany);
            this.panel1.Controls.Add(this.buttonReceivingReceipt);
            this.panel1.Controls.Add(this.buttonSupplier);
            this.panel1.Controls.Add(this.buttonSettings);
            this.panel1.Controls.Add(this.buttonCustomer);
            this.panel1.Controls.Add(this.buttonMemo);
            this.panel1.Controls.Add(this.buttonSystemTables);
            this.panel1.Controls.Add(this.buttonAccountsPayableReport);
            this.panel1.Controls.Add(this.buttonSalesOrder);
            this.panel1.Controls.Add(this.buttonPurchaseOrder);
            this.panel1.Controls.Add(this.buttonStockOut);
            this.panel1.Controls.Add(this.buttonSalesInvoice);
            this.panel1.Controls.Add(this.buttonStockIn);
            this.panel1.Controls.Add(this.buttonInventoryReport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1096, 560);
            this.panel1.TabIndex = 19;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Location = new System.Drawing.Point(756, 105);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(616, 415);
            this.panel3.TabIndex = 20;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.textBoxItemListFilter);
            this.panel4.Controls.Add(this.dataGridViewItemList);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(361, 373);
            this.panel4.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 19);
            this.label1.TabIndex = 25;
            this.label1.Text = "Search";
            // 
            // textBoxItemListFilter
            // 
            this.textBoxItemListFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxItemListFilter.Location = new System.Drawing.Point(65, 14);
            this.textBoxItemListFilter.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxItemListFilter.Name = "textBoxItemListFilter";
            this.textBoxItemListFilter.Size = new System.Drawing.Size(289, 26);
            this.textBoxItemListFilter.TabIndex = 24;
            this.textBoxItemListFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxItemListFilter_KeyDown);
            // 
            // dataGridViewItemList
            // 
            this.dataGridViewItemList.AllowUserToAddRows = false;
            this.dataGridViewItemList.AllowUserToDeleteRows = false;
            this.dataGridViewItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewItemList.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewItemList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSysMenuItemListItemCode,
            this.ColumnSysMenuItemListItemDescription,
            this.ColumnSysMenuItemListOnHandQuatity,
            this.ColumnSysMenuItemListUnit,
            this.ColumnSysMenuItemListId});
            this.dataGridViewItemList.Location = new System.Drawing.Point(0, 51);
            this.dataGridViewItemList.Name = "dataGridViewItemList";
            this.dataGridViewItemList.ReadOnly = true;
            this.dataGridViewItemList.RowHeadersVisible = false;
            this.dataGridViewItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewItemList.Size = new System.Drawing.Size(358, 322);
            this.dataGridViewItemList.TabIndex = 23;
            this.dataGridViewItemList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewItemList_CellClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewPriceList);
            this.panel2.Controls.Add(this.dataGridViewCostList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(364, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(252, 373);
            this.panel2.TabIndex = 26;
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
            dataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle55.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle55.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPriceList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle55;
            this.dataGridViewPriceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPriceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPriceDescription,
            this.ColumnPrice});
            dataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle56.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle56.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle56.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle56.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle56.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle56.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPriceList.DefaultCellStyle = dataGridViewCellStyle56;
            this.dataGridViewPriceList.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewPriceList.Location = new System.Drawing.Point(1, 51);
            this.dataGridViewPriceList.Name = "dataGridViewPriceList";
            this.dataGridViewPriceList.ReadOnly = true;
            this.dataGridViewPriceList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle57.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle57.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle57.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle57.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle57.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle57.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle57.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPriceList.RowHeadersDefaultCellStyle = dataGridViewCellStyle57;
            this.dataGridViewPriceList.RowHeadersVisible = false;
            this.dataGridViewPriceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPriceList.Size = new System.Drawing.Size(252, 152);
            this.dataGridViewPriceList.TabIndex = 24;
            // 
            // ColumnPriceDescription
            // 
            this.ColumnPriceDescription.HeaderText = "Price Description";
            this.ColumnPriceDescription.Name = "ColumnPriceDescription";
            this.ColumnPriceDescription.ReadOnly = true;
            this.ColumnPriceDescription.Width = 150;
            // 
            // ColumnPrice
            // 
            this.ColumnPrice.HeaderText = "Price";
            this.ColumnPrice.Name = "ColumnPrice";
            this.ColumnPrice.ReadOnly = true;
            // 
            // dataGridViewCostList
            // 
            this.dataGridViewCostList.AllowUserToAddRows = false;
            this.dataGridViewCostList.AllowUserToDeleteRows = false;
            this.dataGridViewCostList.AllowUserToResizeColumns = false;
            this.dataGridViewCostList.AllowUserToResizeRows = false;
            this.dataGridViewCostList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCostList.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewCostList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCostList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewCostList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle58.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle58.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle58.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCostList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle58;
            this.dataGridViewCostList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCostList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCostDescription,
            this.ColumnCost});
            dataGridViewCellStyle59.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle59.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle59.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle59.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle59.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle59.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle59.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCostList.DefaultCellStyle = dataGridViewCellStyle59;
            this.dataGridViewCostList.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewCostList.Location = new System.Drawing.Point(1, 216);
            this.dataGridViewCostList.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewCostList.Name = "dataGridViewCostList";
            this.dataGridViewCostList.ReadOnly = true;
            this.dataGridViewCostList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle60.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle60.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle60.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCostList.RowHeadersDefaultCellStyle = dataGridViewCellStyle60;
            this.dataGridViewCostList.RowHeadersVisible = false;
            this.dataGridViewCostList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCostList.Size = new System.Drawing.Size(252, 152);
            this.dataGridViewCostList.TabIndex = 25;
            // 
            // ColumnCostDescription
            // 
            this.ColumnCostDescription.HeaderText = "Cost Description";
            this.ColumnCostDescription.Name = "ColumnCostDescription";
            this.ColumnCostDescription.ReadOnly = true;
            this.ColumnCostDescription.Width = 150;
            // 
            // ColumnCost
            // 
            this.ColumnCost.HeaderText = "Cost";
            this.ColumnCost.Name = "ColumnCost";
            this.ColumnCost.ReadOnly = true;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.Controls.Add(this.buttonItemListPageListFirst);
            this.panel5.Controls.Add(this.buttonItemListPageListPrevious);
            this.panel5.Controls.Add(this.buttonItemListPageListNext);
            this.panel5.Controls.Add(this.buttonItemListPageListLast);
            this.panel5.Controls.Add(this.textBoxItemListPageNumber);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 373);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(616, 42);
            this.panel5.TabIndex = 22;
            // 
            // buttonItemListPageListFirst
            // 
            this.buttonItemListPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonItemListPageListFirst.Enabled = false;
            this.buttonItemListPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonItemListPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItemListPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonItemListPageListFirst.Location = new System.Drawing.Point(10, 7);
            this.buttonItemListPageListFirst.Margin = new System.Windows.Forms.Padding(2);
            this.buttonItemListPageListFirst.Name = "buttonItemListPageListFirst";
            this.buttonItemListPageListFirst.Size = new System.Drawing.Size(66, 26);
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
            this.buttonItemListPageListPrevious.Location = new System.Drawing.Point(80, 7);
            this.buttonItemListPageListPrevious.Margin = new System.Windows.Forms.Padding(2);
            this.buttonItemListPageListPrevious.Name = "buttonItemListPageListPrevious";
            this.buttonItemListPageListPrevious.Size = new System.Drawing.Size(66, 26);
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
            this.buttonItemListPageListNext.Location = new System.Drawing.Point(210, 7);
            this.buttonItemListPageListNext.Margin = new System.Windows.Forms.Padding(2);
            this.buttonItemListPageListNext.Name = "buttonItemListPageListNext";
            this.buttonItemListPageListNext.Size = new System.Drawing.Size(66, 26);
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
            this.buttonItemListPageListLast.Location = new System.Drawing.Point(278, 7);
            this.buttonItemListPageListLast.Margin = new System.Windows.Forms.Padding(2);
            this.buttonItemListPageListLast.Name = "buttonItemListPageListLast";
            this.buttonItemListPageListLast.Size = new System.Drawing.Size(66, 26);
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
            this.textBoxItemListPageNumber.Location = new System.Drawing.Point(150, 11);
            this.textBoxItemListPageNumber.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxItemListPageNumber.Name = "textBoxItemListPageNumber";
            this.textBoxItemListPageNumber.ReadOnly = true;
            this.textBoxItemListPageNumber.Size = new System.Drawing.Size(55, 16);
            this.textBoxItemListPageNumber.TabIndex = 17;
            this.textBoxItemListPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonCollection
            // 
            this.buttonCollection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonCollection.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonCollection.FlatAppearance.BorderSize = 0;
            this.buttonCollection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCollection.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonCollection.ForeColor = System.Drawing.Color.White;
            this.buttonCollection.ImageIndex = 18;
            this.buttonCollection.ImageList = this.imageListMenuIcons;
            this.buttonCollection.Location = new System.Drawing.Point(196, 422);
            this.buttonCollection.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCollection.Name = "buttonCollection";
            this.buttonCollection.Padding = new System.Windows.Forms.Padding(8);
            this.buttonCollection.Size = new System.Drawing.Size(182, 98);
            this.buttonCollection.TabIndex = 17;
            this.buttonCollection.Text = "\r\nCollection";
            this.buttonCollection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCollection.UseVisualStyleBackColor = false;
            this.buttonCollection.Click += new System.EventHandler(this.buttonCollection_Click);
            // 
            // buttonDisbursement
            // 
            this.buttonDisbursement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonDisbursement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonDisbursement.FlatAppearance.BorderSize = 0;
            this.buttonDisbursement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDisbursement.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonDisbursement.ForeColor = System.Drawing.Color.White;
            this.buttonDisbursement.ImageKey = "Disbursement.png";
            this.buttonDisbursement.ImageList = this.imageListMenuIcons;
            this.buttonDisbursement.Location = new System.Drawing.Point(10, 422);
            this.buttonDisbursement.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDisbursement.Name = "buttonDisbursement";
            this.buttonDisbursement.Padding = new System.Windows.Forms.Padding(8);
            this.buttonDisbursement.Size = new System.Drawing.Size(182, 98);
            this.buttonDisbursement.TabIndex = 16;
            this.buttonDisbursement.Text = "\r\nDisbursement";
            this.buttonDisbursement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonDisbursement.UseVisualStyleBackColor = false;
            this.buttonDisbursement.Click += new System.EventHandler(this.buttonDisbursement_Click);
            // 
            // buttonAccountsReceivableReport
            // 
            this.buttonAccountsReceivableReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonAccountsReceivableReport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonAccountsReceivableReport.FlatAppearance.BorderSize = 0;
            this.buttonAccountsReceivableReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAccountsReceivableReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonAccountsReceivableReport.ForeColor = System.Drawing.Color.White;
            this.buttonAccountsReceivableReport.ImageKey = "Reports.png";
            this.buttonAccountsReceivableReport.ImageList = this.imageListMenuIcons;
            this.buttonAccountsReceivableReport.Location = new System.Drawing.Point(196, 319);
            this.buttonAccountsReceivableReport.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAccountsReceivableReport.Name = "buttonAccountsReceivableReport";
            this.buttonAccountsReceivableReport.Padding = new System.Windows.Forms.Padding(8);
            this.buttonAccountsReceivableReport.Size = new System.Drawing.Size(182, 98);
            this.buttonAccountsReceivableReport.TabIndex = 13;
            this.buttonAccountsReceivableReport.Text = "\r\nAccounts Receivable";
            this.buttonAccountsReceivableReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonAccountsReceivableReport.UseVisualStyleBackColor = false;
            this.buttonAccountsReceivableReport.Click += new System.EventHandler(this.buttonAccountsReceivableReport_Click);
            // 
            // buttonStockTransfer
            // 
            this.buttonStockTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonStockTransfer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonStockTransfer.FlatAppearance.BorderSize = 0;
            this.buttonStockTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockTransfer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonStockTransfer.ForeColor = System.Drawing.Color.White;
            this.buttonStockTransfer.ImageIndex = 20;
            this.buttonStockTransfer.ImageList = this.imageListMenuIcons;
            this.buttonStockTransfer.Location = new System.Drawing.Point(382, 422);
            this.buttonStockTransfer.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStockTransfer.Name = "buttonStockTransfer";
            this.buttonStockTransfer.Padding = new System.Windows.Forms.Padding(8);
            this.buttonStockTransfer.Size = new System.Drawing.Size(182, 98);
            this.buttonStockTransfer.TabIndex = 18;
            this.buttonStockTransfer.Text = "\r\nStock Transfer";
            this.buttonStockTransfer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonStockTransfer.UseVisualStyleBackColor = false;
            this.buttonStockTransfer.Click += new System.EventHandler(this.buttonStockTransfer_Click);
            // 
            // buttonItem
            // 
            this.buttonItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonItem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonItem.FlatAppearance.BorderSize = 0;
            this.buttonItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonItem.ForeColor = System.Drawing.Color.White;
            this.buttonItem.ImageIndex = 4;
            this.buttonItem.ImageList = this.imageListMenuIcons;
            this.buttonItem.Location = new System.Drawing.Point(382, 10);
            this.buttonItem.Margin = new System.Windows.Forms.Padding(2);
            this.buttonItem.Name = "buttonItem";
            this.buttonItem.Padding = new System.Windows.Forms.Padding(8);
            this.buttonItem.Size = new System.Drawing.Size(182, 98);
            this.buttonItem.TabIndex = 2;
            this.buttonItem.Text = "\r\nItem";
            this.buttonItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonItem.UseVisualStyleBackColor = false;
            this.buttonItem.Click += new System.EventHandler(this.buttonItem_Click);
            // 
            // buttonUser
            // 
            this.buttonUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonUser.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonUser.FlatAppearance.BorderSize = 0;
            this.buttonUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonUser.ForeColor = System.Drawing.Color.White;
            this.buttonUser.ImageIndex = 8;
            this.buttonUser.ImageList = this.imageListMenuIcons;
            this.buttonUser.Location = new System.Drawing.Point(569, 113);
            this.buttonUser.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUser.Name = "buttonUser";
            this.buttonUser.Padding = new System.Windows.Forms.Padding(8);
            this.buttonUser.Size = new System.Drawing.Size(182, 98);
            this.buttonUser.TabIndex = 7;
            this.buttonUser.Text = "\r\nUser";
            this.buttonUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonUser.UseVisualStyleBackColor = false;
            this.buttonUser.Click += new System.EventHandler(this.buttonUser_Click);
            // 
            // buttonCompany
            // 
            this.buttonCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonCompany.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonCompany.FlatAppearance.BorderSize = 0;
            this.buttonCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCompany.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonCompany.ForeColor = System.Drawing.Color.White;
            this.buttonCompany.ImageKey = "Company.png";
            this.buttonCompany.ImageList = this.imageListMenuIcons;
            this.buttonCompany.Location = new System.Drawing.Point(569, 10);
            this.buttonCompany.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCompany.Name = "buttonCompany";
            this.buttonCompany.Padding = new System.Windows.Forms.Padding(8);
            this.buttonCompany.Size = new System.Drawing.Size(182, 98);
            this.buttonCompany.TabIndex = 3;
            this.buttonCompany.Text = "\r\nCompany";
            this.buttonCompany.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCompany.UseVisualStyleBackColor = false;
            this.buttonCompany.Click += new System.EventHandler(this.buttonCompany_Click);
            // 
            // buttonReceivingReceipt
            // 
            this.buttonReceivingReceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonReceivingReceipt.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonReceivingReceipt.FlatAppearance.BorderSize = 0;
            this.buttonReceivingReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReceivingReceipt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonReceivingReceipt.ForeColor = System.Drawing.Color.White;
            this.buttonReceivingReceipt.ImageIndex = 17;
            this.buttonReceivingReceipt.ImageList = this.imageListMenuIcons;
            this.buttonReceivingReceipt.Location = new System.Drawing.Point(10, 216);
            this.buttonReceivingReceipt.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReceivingReceipt.Name = "buttonReceivingReceipt";
            this.buttonReceivingReceipt.Padding = new System.Windows.Forms.Padding(8);
            this.buttonReceivingReceipt.Size = new System.Drawing.Size(182, 98);
            this.buttonReceivingReceipt.TabIndex = 8;
            this.buttonReceivingReceipt.Text = "\r\nReceiving Receipt";
            this.buttonReceivingReceipt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonReceivingReceipt.UseVisualStyleBackColor = false;
            this.buttonReceivingReceipt.Click += new System.EventHandler(this.buttonReceivingReceipt_Click);
            // 
            // buttonSupplier
            // 
            this.buttonSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonSupplier.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonSupplier.FlatAppearance.BorderSize = 0;
            this.buttonSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSupplier.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonSupplier.ForeColor = System.Drawing.Color.White;
            this.buttonSupplier.ImageIndex = 15;
            this.buttonSupplier.ImageList = this.imageListMenuIcons;
            this.buttonSupplier.Location = new System.Drawing.Point(10, 10);
            this.buttonSupplier.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSupplier.Name = "buttonSupplier";
            this.buttonSupplier.Padding = new System.Windows.Forms.Padding(8);
            this.buttonSupplier.Size = new System.Drawing.Size(182, 98);
            this.buttonSupplier.TabIndex = 0;
            this.buttonSupplier.Text = "\r\nSupplier";
            this.buttonSupplier.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonSupplier.UseVisualStyleBackColor = false;
            this.buttonSupplier.Click += new System.EventHandler(this.buttonSupplier_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonSettings.FlatAppearance.BorderSize = 0;
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonSettings.ForeColor = System.Drawing.Color.White;
            this.buttonSettings.ImageKey = "Settings.png";
            this.buttonSettings.ImageList = this.imageListMenuIcons;
            this.buttonSettings.Location = new System.Drawing.Point(569, 422);
            this.buttonSettings.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Padding = new System.Windows.Forms.Padding(8);
            this.buttonSettings.Size = new System.Drawing.Size(182, 98);
            this.buttonSettings.TabIndex = 19;
            this.buttonSettings.Text = "\r\nSettings";
            this.buttonSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonSettings.UseVisualStyleBackColor = false;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // buttonCustomer
            // 
            this.buttonCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonCustomer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonCustomer.FlatAppearance.BorderSize = 0;
            this.buttonCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustomer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonCustomer.ForeColor = System.Drawing.Color.White;
            this.buttonCustomer.ImageIndex = 0;
            this.buttonCustomer.ImageList = this.imageListMenuIcons;
            this.buttonCustomer.Location = new System.Drawing.Point(196, 10);
            this.buttonCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCustomer.Name = "buttonCustomer";
            this.buttonCustomer.Padding = new System.Windows.Forms.Padding(8);
            this.buttonCustomer.Size = new System.Drawing.Size(182, 98);
            this.buttonCustomer.TabIndex = 1;
            this.buttonCustomer.Text = "\r\nCustomer";
            this.buttonCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCustomer.UseVisualStyleBackColor = false;
            this.buttonCustomer.Click += new System.EventHandler(this.buttonCustomer_Click);
            // 
            // buttonMemo
            // 
            this.buttonMemo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonMemo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonMemo.FlatAppearance.BorderSize = 0;
            this.buttonMemo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMemo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonMemo.ForeColor = System.Drawing.Color.White;
            this.buttonMemo.ImageKey = "Reports.png";
            this.buttonMemo.ImageList = this.imageListMenuIcons;
            this.buttonMemo.Location = new System.Drawing.Point(569, 319);
            this.buttonMemo.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMemo.Name = "buttonMemo";
            this.buttonMemo.Padding = new System.Windows.Forms.Padding(8);
            this.buttonMemo.Size = new System.Drawing.Size(182, 98);
            this.buttonMemo.TabIndex = 15;
            this.buttonMemo.Text = "Memo";
            this.buttonMemo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonMemo.UseVisualStyleBackColor = false;
            this.buttonMemo.Click += new System.EventHandler(this.buttonMemo_Click);
            // 
            // buttonSystemTables
            // 
            this.buttonSystemTables.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonSystemTables.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonSystemTables.FlatAppearance.BorderSize = 0;
            this.buttonSystemTables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSystemTables.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonSystemTables.ForeColor = System.Drawing.Color.White;
            this.buttonSystemTables.ImageIndex = 13;
            this.buttonSystemTables.ImageList = this.imageListMenuIcons;
            this.buttonSystemTables.Location = new System.Drawing.Point(569, 216);
            this.buttonSystemTables.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSystemTables.Name = "buttonSystemTables";
            this.buttonSystemTables.Padding = new System.Windows.Forms.Padding(8);
            this.buttonSystemTables.Size = new System.Drawing.Size(182, 98);
            this.buttonSystemTables.TabIndex = 11;
            this.buttonSystemTables.Text = "\r\nSystem Tables";
            this.buttonSystemTables.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonSystemTables.UseVisualStyleBackColor = false;
            this.buttonSystemTables.Click += new System.EventHandler(this.buttonSystemTables_Click);
            // 
            // buttonAccountsPayableReport
            // 
            this.buttonAccountsPayableReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonAccountsPayableReport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonAccountsPayableReport.FlatAppearance.BorderSize = 0;
            this.buttonAccountsPayableReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAccountsPayableReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonAccountsPayableReport.ForeColor = System.Drawing.Color.White;
            this.buttonAccountsPayableReport.ImageIndex = 6;
            this.buttonAccountsPayableReport.ImageList = this.imageListMenuIcons;
            this.buttonAccountsPayableReport.Location = new System.Drawing.Point(10, 319);
            this.buttonAccountsPayableReport.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAccountsPayableReport.Name = "buttonAccountsPayableReport";
            this.buttonAccountsPayableReport.Padding = new System.Windows.Forms.Padding(8);
            this.buttonAccountsPayableReport.Size = new System.Drawing.Size(182, 98);
            this.buttonAccountsPayableReport.TabIndex = 12;
            this.buttonAccountsPayableReport.Text = "\r\nAccounts Payable";
            this.buttonAccountsPayableReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonAccountsPayableReport.UseVisualStyleBackColor = false;
            this.buttonAccountsPayableReport.Click += new System.EventHandler(this.buttonAccountsPayableReport_Click);
            // 
            // buttonSalesOrder
            // 
            this.buttonSalesOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonSalesOrder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonSalesOrder.FlatAppearance.BorderSize = 0;
            this.buttonSalesOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalesOrder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonSalesOrder.ForeColor = System.Drawing.Color.White;
            this.buttonSalesOrder.ImageIndex = 19;
            this.buttonSalesOrder.ImageList = this.imageListMenuIcons;
            this.buttonSalesOrder.Location = new System.Drawing.Point(196, 113);
            this.buttonSalesOrder.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSalesOrder.Name = "buttonSalesOrder";
            this.buttonSalesOrder.Padding = new System.Windows.Forms.Padding(8);
            this.buttonSalesOrder.Size = new System.Drawing.Size(182, 98);
            this.buttonSalesOrder.TabIndex = 5;
            this.buttonSalesOrder.Text = "\r\nSales Order";
            this.buttonSalesOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonSalesOrder.UseVisualStyleBackColor = false;
            this.buttonSalesOrder.Click += new System.EventHandler(this.buttonSalesOrder_Click);
            // 
            // buttonPurchaseOrder
            // 
            this.buttonPurchaseOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonPurchaseOrder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonPurchaseOrder.FlatAppearance.BorderSize = 0;
            this.buttonPurchaseOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPurchaseOrder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonPurchaseOrder.ForeColor = System.Drawing.Color.White;
            this.buttonPurchaseOrder.ImageIndex = 16;
            this.buttonPurchaseOrder.ImageList = this.imageListMenuIcons;
            this.buttonPurchaseOrder.Location = new System.Drawing.Point(10, 113);
            this.buttonPurchaseOrder.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPurchaseOrder.Name = "buttonPurchaseOrder";
            this.buttonPurchaseOrder.Padding = new System.Windows.Forms.Padding(8);
            this.buttonPurchaseOrder.Size = new System.Drawing.Size(182, 98);
            this.buttonPurchaseOrder.TabIndex = 4;
            this.buttonPurchaseOrder.Text = "\r\nPurchase Order";
            this.buttonPurchaseOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonPurchaseOrder.UseVisualStyleBackColor = false;
            this.buttonPurchaseOrder.Click += new System.EventHandler(this.buttonPurchaseOrder_Click);
            // 
            // buttonStockOut
            // 
            this.buttonStockOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonStockOut.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonStockOut.FlatAppearance.BorderSize = 0;
            this.buttonStockOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockOut.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonStockOut.ForeColor = System.Drawing.Color.White;
            this.buttonStockOut.ImageIndex = 10;
            this.buttonStockOut.ImageList = this.imageListMenuIcons;
            this.buttonStockOut.Location = new System.Drawing.Point(382, 216);
            this.buttonStockOut.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStockOut.Name = "buttonStockOut";
            this.buttonStockOut.Padding = new System.Windows.Forms.Padding(8);
            this.buttonStockOut.Size = new System.Drawing.Size(182, 98);
            this.buttonStockOut.TabIndex = 10;
            this.buttonStockOut.Text = "\r\nStock Out";
            this.buttonStockOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonStockOut.UseVisualStyleBackColor = false;
            this.buttonStockOut.Click += new System.EventHandler(this.buttonStockOut_Click);
            // 
            // buttonSalesInvoice
            // 
            this.buttonSalesInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonSalesInvoice.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonSalesInvoice.FlatAppearance.BorderSize = 0;
            this.buttonSalesInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalesInvoice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonSalesInvoice.ForeColor = System.Drawing.Color.White;
            this.buttonSalesInvoice.ImageKey = "POS.png";
            this.buttonSalesInvoice.ImageList = this.imageListMenuIcons;
            this.buttonSalesInvoice.Location = new System.Drawing.Point(196, 216);
            this.buttonSalesInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSalesInvoice.Name = "buttonSalesInvoice";
            this.buttonSalesInvoice.Padding = new System.Windows.Forms.Padding(8);
            this.buttonSalesInvoice.Size = new System.Drawing.Size(182, 98);
            this.buttonSalesInvoice.TabIndex = 9;
            this.buttonSalesInvoice.Text = "\r\nSales Invoice";
            this.buttonSalesInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonSalesInvoice.UseVisualStyleBackColor = false;
            this.buttonSalesInvoice.Click += new System.EventHandler(this.buttonSalesInvoice_Click);
            // 
            // buttonStockIn
            // 
            this.buttonStockIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonStockIn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonStockIn.FlatAppearance.BorderSize = 0;
            this.buttonStockIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockIn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonStockIn.ForeColor = System.Drawing.Color.White;
            this.buttonStockIn.ImageIndex = 9;
            this.buttonStockIn.ImageList = this.imageListMenuIcons;
            this.buttonStockIn.Location = new System.Drawing.Point(382, 113);
            this.buttonStockIn.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStockIn.Name = "buttonStockIn";
            this.buttonStockIn.Padding = new System.Windows.Forms.Padding(8);
            this.buttonStockIn.Size = new System.Drawing.Size(182, 98);
            this.buttonStockIn.TabIndex = 6;
            this.buttonStockIn.Text = "\r\nStock In";
            this.buttonStockIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonStockIn.UseVisualStyleBackColor = false;
            this.buttonStockIn.Click += new System.EventHandler(this.buttonStockIn_Click);
            // 
            // buttonInventoryReport
            // 
            this.buttonInventoryReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonInventoryReport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonInventoryReport.FlatAppearance.BorderSize = 0;
            this.buttonInventoryReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInventoryReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonInventoryReport.ForeColor = System.Drawing.Color.White;
            this.buttonInventoryReport.ImageKey = "Reports.png";
            this.buttonInventoryReport.ImageList = this.imageListMenuIcons;
            this.buttonInventoryReport.Location = new System.Drawing.Point(382, 319);
            this.buttonInventoryReport.Margin = new System.Windows.Forms.Padding(2);
            this.buttonInventoryReport.Name = "buttonInventoryReport";
            this.buttonInventoryReport.Padding = new System.Windows.Forms.Padding(8);
            this.buttonInventoryReport.Size = new System.Drawing.Size(182, 98);
            this.buttonInventoryReport.TabIndex = 14;
            this.buttonInventoryReport.Text = "\r\nInventory Report";
            this.buttonInventoryReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonInventoryReport.UseVisualStyleBackColor = false;
            this.buttonInventoryReport.Click += new System.EventHandler(this.buttonInventoryReport_Click);
            // 
            // ColumnSysMenuItemListItemCode
            // 
            this.ColumnSysMenuItemListItemCode.DataPropertyName = "ColumnSysMenuItemListItemCode";
            this.ColumnSysMenuItemListItemCode.HeaderText = "Item Code";
            this.ColumnSysMenuItemListItemCode.Name = "ColumnSysMenuItemListItemCode";
            this.ColumnSysMenuItemListItemCode.ReadOnly = true;
            // 
            // ColumnSysMenuItemListItemDescription
            // 
            this.ColumnSysMenuItemListItemDescription.DataPropertyName = "ColumnSysMenuItemListItemDescription";
            this.ColumnSysMenuItemListItemDescription.HeaderText = "Description";
            this.ColumnSysMenuItemListItemDescription.Name = "ColumnSysMenuItemListItemDescription";
            this.ColumnSysMenuItemListItemDescription.ReadOnly = true;
            this.ColumnSysMenuItemListItemDescription.Width = 250;
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
            // SysMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1096, 560);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "SysMenuForm";
            this.Text = "Menu";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemList)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPriceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCostList)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonItem;
        private System.Windows.Forms.ImageList imageListMenuIcons;
        private System.Windows.Forms.Button buttonCompany;
        private System.Windows.Forms.Button buttonSupplier;
        private System.Windows.Forms.Button buttonCustomer;
        private System.Windows.Forms.Button buttonSystemTables;
        private System.Windows.Forms.Button buttonSalesOrder;
        private System.Windows.Forms.Button buttonStockOut;
        private System.Windows.Forms.Button buttonStockIn;
        private System.Windows.Forms.Button buttonInventoryReport;
        private System.Windows.Forms.Button buttonSalesInvoice;
        private System.Windows.Forms.Button buttonPurchaseOrder;
        private System.Windows.Forms.Button buttonAccountsPayableReport;
        private System.Windows.Forms.Button buttonMemo;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonReceivingReceipt;
        private System.Windows.Forms.Button buttonUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonStockTransfer;
        private System.Windows.Forms.Button buttonCollection;
        private System.Windows.Forms.Button buttonDisbursement;
        private System.Windows.Forms.Button buttonAccountsReceivableReport;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridViewCostList;
        private System.Windows.Forms.DataGridView dataGridViewPriceList;
        private System.Windows.Forms.DataGridView dataGridViewItemList;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button buttonItemListPageListFirst;
        private System.Windows.Forms.Button buttonItemListPageListPrevious;
        private System.Windows.Forms.Button buttonItemListPageListNext;
        private System.Windows.Forms.Button buttonItemListPageListLast;
        private System.Windows.Forms.TextBox textBoxItemListPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPriceDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCostDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCost;
        private System.Windows.Forms.TextBox textBoxItemListFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSysMenuItemListItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSysMenuItemListItemDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSysMenuItemListOnHandQuatity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSysMenuItemListUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSysMenuItemListId;
    }
}