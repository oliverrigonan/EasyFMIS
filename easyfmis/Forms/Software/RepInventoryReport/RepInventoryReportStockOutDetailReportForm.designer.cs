namespace easyfmis.Forms.Software.RepInventoryReport
{
    partial class RepInventoryReportStockOutDetailReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepInventoryReportStockOutDetailReportForm));
            this.buttonStockOutDetailReportPageListNext = new System.Windows.Forms.Button();
            this.buttonStockOutDetailReportPageListPrevious = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonStockOutDetailReportPageListFirst = new System.Windows.Forms.Button();
            this.buttonStockOutDetailReportPageListLast = new System.Windows.Forms.Button();
            this.textBoxStockOutDetailReportPageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCompany = new System.Windows.Forms.TextBox();
            this.textBoxStartDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxEndDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxBranch = new System.Windows.Forms.TextBox();
            this.dataGridViewStockOutDetailReport = new System.Windows.Forms.DataGridView();
            this.ColumnStockOutDetailReportListOTNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutDetailReportListOTDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutDetailReportListBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutDetailReportListRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutDetailReportListPreparedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutDetailReportListCheckedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutDetailReportListApprovedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutDetailReportListItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutDetailReportListItemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutDetailReportListItemInventoryCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutDetailReportListUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutDetailReportListQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutDetailReportListCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutDetailReportListAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutDetailReportListBaseQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutDetailReportListBaseCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonGenerateCSV = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.folderBrowserDialogGenerateCSV = new System.Windows.Forms.FolderBrowserDialog();
            this.textBoxItemListFilter = new System.Windows.Forms.TextBox();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockOutDetailReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStockOutDetailReportPageListNext
            // 
            this.buttonStockOutDetailReportPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockOutDetailReportPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonStockOutDetailReportPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockOutDetailReportPageListNext.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonStockOutDetailReportPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonStockOutDetailReportPageListNext.Name = "buttonStockOutDetailReportPageListNext";
            this.buttonStockOutDetailReportPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonStockOutDetailReportPageListNext.TabIndex = 10;
            this.buttonStockOutDetailReportPageListNext.Text = "Next";
            this.buttonStockOutDetailReportPageListNext.UseVisualStyleBackColor = false;
            this.buttonStockOutDetailReportPageListNext.Click += new System.EventHandler(this.buttonSalesInvoiceDetailReportPageListNext_Click);
            // 
            // buttonStockOutDetailReportPageListPrevious
            // 
            this.buttonStockOutDetailReportPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockOutDetailReportPageListPrevious.Enabled = false;
            this.buttonStockOutDetailReportPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonStockOutDetailReportPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockOutDetailReportPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonStockOutDetailReportPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonStockOutDetailReportPageListPrevious.Name = "buttonStockOutDetailReportPageListPrevious";
            this.buttonStockOutDetailReportPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonStockOutDetailReportPageListPrevious.TabIndex = 9;
            this.buttonStockOutDetailReportPageListPrevious.Text = "Previous";
            this.buttonStockOutDetailReportPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonStockOutDetailReportPageListPrevious.Click += new System.EventHandler(this.buttonSalesInvoiceDetailReportPageListPrevious_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.buttonStockOutDetailReportPageListFirst);
            this.panel4.Controls.Add(this.buttonStockOutDetailReportPageListNext);
            this.panel4.Controls.Add(this.buttonStockOutDetailReportPageListLast);
            this.panel4.Controls.Add(this.buttonStockOutDetailReportPageListPrevious);
            this.panel4.Controls.Add(this.textBoxStockOutDetailReportPageNumber);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 537);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1382, 53);
            this.panel4.TabIndex = 20;
            // 
            // buttonStockOutDetailReportPageListFirst
            // 
            this.buttonStockOutDetailReportPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockOutDetailReportPageListFirst.Enabled = false;
            this.buttonStockOutDetailReportPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonStockOutDetailReportPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockOutDetailReportPageListFirst.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonStockOutDetailReportPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonStockOutDetailReportPageListFirst.Name = "buttonStockOutDetailReportPageListFirst";
            this.buttonStockOutDetailReportPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonStockOutDetailReportPageListFirst.TabIndex = 8;
            this.buttonStockOutDetailReportPageListFirst.Text = "First";
            this.buttonStockOutDetailReportPageListFirst.UseVisualStyleBackColor = false;
            this.buttonStockOutDetailReportPageListFirst.Click += new System.EventHandler(this.buttonSalesInvoiceDetailReportPageListFirst_Click);
            // 
            // buttonStockOutDetailReportPageListLast
            // 
            this.buttonStockOutDetailReportPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockOutDetailReportPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonStockOutDetailReportPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockOutDetailReportPageListLast.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonStockOutDetailReportPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonStockOutDetailReportPageListLast.Name = "buttonStockOutDetailReportPageListLast";
            this.buttonStockOutDetailReportPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonStockOutDetailReportPageListLast.TabIndex = 11;
            this.buttonStockOutDetailReportPageListLast.Text = "Last";
            this.buttonStockOutDetailReportPageListLast.UseVisualStyleBackColor = false;
            this.buttonStockOutDetailReportPageListLast.Click += new System.EventHandler(this.buttonSalesInvoiceDetailReportPageListLast_Click);
            // 
            // textBoxStockOutDetailReportPageNumber
            // 
            this.textBoxStockOutDetailReportPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxStockOutDetailReportPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxStockOutDetailReportPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxStockOutDetailReportPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxStockOutDetailReportPageNumber.Name = "textBoxStockOutDetailReportPageNumber";
            this.textBoxStockOutDetailReportPageNumber.ReadOnly = true;
            this.textBoxStockOutDetailReportPageNumber.Size = new System.Drawing.Size(69, 23);
            this.textBoxStockOutDetailReportPageNumber.TabIndex = 12;
            this.textBoxStockOutDetailReportPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.textBoxItemListFilter);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewStockOutDetailReport);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1382, 590);
            this.panel2.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.textBoxCompany);
            this.panel3.Controls.Add(this.textBoxStartDate);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.textBoxEndDate);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.textBoxBranch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1382, 47);
            this.panel3.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label4.Location = new System.Drawing.Point(498, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 23);
            this.label4.TabIndex = 34;
            this.label4.Text = "Company:";
            // 
            // textBoxCompany
            // 
            this.textBoxCompany.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCompany.Location = new System.Drawing.Point(591, 8);
            this.textBoxCompany.Name = "textBoxCompany";
            this.textBoxCompany.ReadOnly = true;
            this.textBoxCompany.Size = new System.Drawing.Size(149, 30);
            this.textBoxCompany.TabIndex = 33;
            // 
            // textBoxStartDate
            // 
            this.textBoxStartDate.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxStartDate.Location = new System.Drawing.Point(98, 8);
            this.textBoxStartDate.Name = "textBoxStartDate";
            this.textBoxStartDate.ReadOnly = true;
            this.textBoxStartDate.Size = new System.Drawing.Size(149, 30);
            this.textBoxStartDate.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label5.Location = new System.Drawing.Point(253, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 23);
            this.label5.TabIndex = 28;
            this.label5.Text = "End Date:";
            // 
            // textBoxEndDate
            // 
            this.textBoxEndDate.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxEndDate.Location = new System.Drawing.Point(343, 8);
            this.textBoxEndDate.Name = "textBoxEndDate";
            this.textBoxEndDate.ReadOnly = true;
            this.textBoxEndDate.Size = new System.Drawing.Size(149, 30);
            this.textBoxEndDate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label2.Location = new System.Drawing.Point(759, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 23);
            this.label2.TabIndex = 30;
            this.label2.Text = "Branch:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 23);
            this.label3.TabIndex = 32;
            this.label3.Text = "End Date";
            // 
            // textBoxBranch
            // 
            this.textBoxBranch.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxBranch.Location = new System.Drawing.Point(832, 8);
            this.textBoxBranch.Name = "textBoxBranch";
            this.textBoxBranch.ReadOnly = true;
            this.textBoxBranch.Size = new System.Drawing.Size(208, 30);
            this.textBoxBranch.TabIndex = 3;
            // 
            // dataGridViewStockOutDetailReport
            // 
            this.dataGridViewStockOutDetailReport.AllowUserToAddRows = false;
            this.dataGridViewStockOutDetailReport.AllowUserToDeleteRows = false;
            this.dataGridViewStockOutDetailReport.AllowUserToResizeRows = false;
            this.dataGridViewStockOutDetailReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStockOutDetailReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewStockOutDetailReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStockOutDetailReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStockOutDetailReportListOTNumber,
            this.ColumnStockOutDetailReportListOTDate,
            this.ColumnStockOutDetailReportListBranch,
            this.ColumnStockOutDetailReportListRemarks,
            this.ColumnStockOutDetailReportListPreparedBy,
            this.ColumnStockOutDetailReportListCheckedBy,
            this.ColumnStockOutDetailReportListApprovedBy,
            this.ColumnStockOutDetailReportListItemCode,
            this.ColumnStockOutDetailReportListItemDescription,
            this.ColumnStockOutDetailReportListItemInventoryCode,
            this.ColumnStockOutDetailReportListUnit,
            this.ColumnStockOutDetailReportListQuantity,
            this.ColumnStockOutDetailReportListCost,
            this.ColumnStockOutDetailReportListAmount,
            this.ColumnStockOutDetailReportListBaseQuantity,
            this.ColumnStockOutDetailReportListBaseCost});
            this.dataGridViewStockOutDetailReport.Location = new System.Drawing.Point(12, 89);
            this.dataGridViewStockOutDetailReport.MultiSelect = false;
            this.dataGridViewStockOutDetailReport.Name = "dataGridViewStockOutDetailReport";
            this.dataGridViewStockOutDetailReport.ReadOnly = true;
            this.dataGridViewStockOutDetailReport.RowHeadersVisible = false;
            this.dataGridViewStockOutDetailReport.RowTemplate.Height = 24;
            this.dataGridViewStockOutDetailReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStockOutDetailReport.Size = new System.Drawing.Size(1357, 442);
            this.dataGridViewStockOutDetailReport.TabIndex = 21;
            // 
            // ColumnStockOutDetailReportListOTNumber
            // 
            this.ColumnStockOutDetailReportListOTNumber.DataPropertyName = "ColumnStockOutDetailReportListOTNumber";
            this.ColumnStockOutDetailReportListOTNumber.HeaderText = "OT Number";
            this.ColumnStockOutDetailReportListOTNumber.Name = "ColumnStockOutDetailReportListOTNumber";
            this.ColumnStockOutDetailReportListOTNumber.ReadOnly = true;
            this.ColumnStockOutDetailReportListOTNumber.Width = 150;
            // 
            // ColumnStockOutDetailReportListOTDate
            // 
            this.ColumnStockOutDetailReportListOTDate.DataPropertyName = "ColumnStockOutDetailReportListOTDate";
            this.ColumnStockOutDetailReportListOTDate.HeaderText = "OT Date";
            this.ColumnStockOutDetailReportListOTDate.Name = "ColumnStockOutDetailReportListOTDate";
            this.ColumnStockOutDetailReportListOTDate.ReadOnly = true;
            this.ColumnStockOutDetailReportListOTDate.Width = 150;
            // 
            // ColumnStockOutDetailReportListBranch
            // 
            this.ColumnStockOutDetailReportListBranch.DataPropertyName = "ColumnStockOutDetailReportListBranch";
            this.ColumnStockOutDetailReportListBranch.HeaderText = "Branch";
            this.ColumnStockOutDetailReportListBranch.Name = "ColumnStockOutDetailReportListBranch";
            this.ColumnStockOutDetailReportListBranch.ReadOnly = true;
            this.ColumnStockOutDetailReportListBranch.Width = 150;
            // 
            // ColumnStockOutDetailReportListRemarks
            // 
            this.ColumnStockOutDetailReportListRemarks.DataPropertyName = "ColumnStockOutDetailReportListRemarks";
            this.ColumnStockOutDetailReportListRemarks.HeaderText = "Remarks";
            this.ColumnStockOutDetailReportListRemarks.Name = "ColumnStockOutDetailReportListRemarks";
            this.ColumnStockOutDetailReportListRemarks.ReadOnly = true;
            this.ColumnStockOutDetailReportListRemarks.Width = 200;
            // 
            // ColumnStockOutDetailReportListPreparedBy
            // 
            this.ColumnStockOutDetailReportListPreparedBy.DataPropertyName = "ColumnStockOutDetailReportListPreparedBy";
            this.ColumnStockOutDetailReportListPreparedBy.HeaderText = "Prepared By";
            this.ColumnStockOutDetailReportListPreparedBy.Name = "ColumnStockOutDetailReportListPreparedBy";
            this.ColumnStockOutDetailReportListPreparedBy.ReadOnly = true;
            this.ColumnStockOutDetailReportListPreparedBy.Width = 200;
            // 
            // ColumnStockOutDetailReportListCheckedBy
            // 
            this.ColumnStockOutDetailReportListCheckedBy.DataPropertyName = "ColumnStockOutDetailReportListCheckedBy";
            this.ColumnStockOutDetailReportListCheckedBy.HeaderText = "CheckedBy";
            this.ColumnStockOutDetailReportListCheckedBy.Name = "ColumnStockOutDetailReportListCheckedBy";
            this.ColumnStockOutDetailReportListCheckedBy.ReadOnly = true;
            this.ColumnStockOutDetailReportListCheckedBy.Width = 200;
            // 
            // ColumnStockOutDetailReportListApprovedBy
            // 
            this.ColumnStockOutDetailReportListApprovedBy.DataPropertyName = "ColumnStockOutDetailReportListApprovedBy";
            this.ColumnStockOutDetailReportListApprovedBy.HeaderText = "Approved By";
            this.ColumnStockOutDetailReportListApprovedBy.Name = "ColumnStockOutDetailReportListApprovedBy";
            this.ColumnStockOutDetailReportListApprovedBy.ReadOnly = true;
            this.ColumnStockOutDetailReportListApprovedBy.Width = 200;
            // 
            // ColumnStockOutDetailReportListItemCode
            // 
            this.ColumnStockOutDetailReportListItemCode.DataPropertyName = "ColumnStockOutDetailReportListItemCode";
            this.ColumnStockOutDetailReportListItemCode.HeaderText = "Item Code";
            this.ColumnStockOutDetailReportListItemCode.Name = "ColumnStockOutDetailReportListItemCode";
            this.ColumnStockOutDetailReportListItemCode.ReadOnly = true;
            this.ColumnStockOutDetailReportListItemCode.Width = 150;
            // 
            // ColumnStockOutDetailReportListItemDescription
            // 
            this.ColumnStockOutDetailReportListItemDescription.DataPropertyName = "ColumnStockOutDetailReportListItemDescription";
            this.ColumnStockOutDetailReportListItemDescription.HeaderText = "Item Description";
            this.ColumnStockOutDetailReportListItemDescription.Name = "ColumnStockOutDetailReportListItemDescription";
            this.ColumnStockOutDetailReportListItemDescription.ReadOnly = true;
            this.ColumnStockOutDetailReportListItemDescription.Width = 200;
            // 
            // ColumnStockOutDetailReportListItemInventoryCode
            // 
            this.ColumnStockOutDetailReportListItemInventoryCode.DataPropertyName = "ColumnStockOutDetailReportListItemInventoryCode";
            this.ColumnStockOutDetailReportListItemInventoryCode.HeaderText = "Inventory Code";
            this.ColumnStockOutDetailReportListItemInventoryCode.Name = "ColumnStockOutDetailReportListItemInventoryCode";
            this.ColumnStockOutDetailReportListItemInventoryCode.ReadOnly = true;
            this.ColumnStockOutDetailReportListItemInventoryCode.Width = 200;
            // 
            // ColumnStockOutDetailReportListUnit
            // 
            this.ColumnStockOutDetailReportListUnit.DataPropertyName = "ColumnStockOutDetailReportListUnit";
            this.ColumnStockOutDetailReportListUnit.HeaderText = "Unit";
            this.ColumnStockOutDetailReportListUnit.Name = "ColumnStockOutDetailReportListUnit";
            this.ColumnStockOutDetailReportListUnit.ReadOnly = true;
            // 
            // ColumnStockOutDetailReportListQuantity
            // 
            this.ColumnStockOutDetailReportListQuantity.DataPropertyName = "ColumnStockOutDetailReportListQuantity";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnStockOutDetailReportListQuantity.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnStockOutDetailReportListQuantity.HeaderText = "Quantity";
            this.ColumnStockOutDetailReportListQuantity.Name = "ColumnStockOutDetailReportListQuantity";
            this.ColumnStockOutDetailReportListQuantity.ReadOnly = true;
            this.ColumnStockOutDetailReportListQuantity.Width = 200;
            // 
            // ColumnStockOutDetailReportListCost
            // 
            this.ColumnStockOutDetailReportListCost.DataPropertyName = "ColumnStockOutDetailReportListCost";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnStockOutDetailReportListCost.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnStockOutDetailReportListCost.HeaderText = "Cost";
            this.ColumnStockOutDetailReportListCost.Name = "ColumnStockOutDetailReportListCost";
            this.ColumnStockOutDetailReportListCost.ReadOnly = true;
            this.ColumnStockOutDetailReportListCost.Width = 200;
            // 
            // ColumnStockOutDetailReportListAmount
            // 
            this.ColumnStockOutDetailReportListAmount.DataPropertyName = "ColumnStockOutDetailReportListAmount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnStockOutDetailReportListAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnStockOutDetailReportListAmount.HeaderText = "Amount";
            this.ColumnStockOutDetailReportListAmount.Name = "ColumnStockOutDetailReportListAmount";
            this.ColumnStockOutDetailReportListAmount.ReadOnly = true;
            this.ColumnStockOutDetailReportListAmount.Width = 200;
            // 
            // ColumnStockOutDetailReportListBaseQuantity
            // 
            this.ColumnStockOutDetailReportListBaseQuantity.DataPropertyName = "ColumnStockOutDetailReportListBaseQuantity";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnStockOutDetailReportListBaseQuantity.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnStockOutDetailReportListBaseQuantity.HeaderText = "Base Quantity";
            this.ColumnStockOutDetailReportListBaseQuantity.Name = "ColumnStockOutDetailReportListBaseQuantity";
            this.ColumnStockOutDetailReportListBaseQuantity.ReadOnly = true;
            this.ColumnStockOutDetailReportListBaseQuantity.Width = 200;
            // 
            // ColumnStockOutDetailReportListBaseCost
            // 
            this.ColumnStockOutDetailReportListBaseCost.DataPropertyName = "ColumnStockOutDetailReportListBaseCost";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnStockOutDetailReportListBaseCost.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnStockOutDetailReportListBaseCost.HeaderText = "BaseCost";
            this.ColumnStockOutDetailReportListBaseCost.Name = "ColumnStockOutDetailReportListBaseCost";
            this.ColumnStockOutDetailReportListBaseCost.ReadOnly = true;
            this.ColumnStockOutDetailReportListBaseCost.Width = 200;
            // 
            // buttonGenerateCSV
            // 
            this.buttonGenerateCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerateCSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonGenerateCSV.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonGenerateCSV.FlatAppearance.BorderSize = 0;
            this.buttonGenerateCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerateCSV.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerateCSV.ForeColor = System.Drawing.Color.White;
            this.buttonGenerateCSV.Location = new System.Drawing.Point(1187, 11);
            this.buttonGenerateCSV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonGenerateCSV.Name = "buttonGenerateCSV";
            this.buttonGenerateCSV.Size = new System.Drawing.Size(88, 40);
            this.buttonGenerateCSV.TabIndex = 20;
            this.buttonGenerateCSV.TabStop = false;
            this.buttonGenerateCSV.Text = "CSV";
            this.buttonGenerateCSV.UseVisualStyleBackColor = false;
            this.buttonGenerateCSV.Click += new System.EventHandler(this.buttonGenerateCSV_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.Reports;
            this.pictureBox1.Location = new System.Drawing.Point(14, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(71, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stock Out Detail Report";
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
            this.buttonClose.Location = new System.Drawing.Point(1281, 11);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(88, 40);
            this.buttonClose.TabIndex = 21;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_OnClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.buttonGenerateCSV);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1382, 63);
            this.panel1.TabIndex = 16;
            // 
            // textBoxItemListFilter
            // 
            this.textBoxItemListFilter.Location = new System.Drawing.Point(15, 53);
            this.textBoxItemListFilter.Name = "textBoxItemListFilter";
            this.textBoxItemListFilter.Size = new System.Drawing.Size(1353, 30);
            this.textBoxItemListFilter.TabIndex = 41;
            this.textBoxItemListFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxItemListFilter_KeyDown);
            // 
            // RepInventoryReportStockOutDetailReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1382, 653);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RepInventoryReportStockOutDetailReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Out Detail Report";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockOutDetailReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStockOutDetailReportPageListNext;
        private System.Windows.Forms.Button buttonStockOutDetailReportPageListPrevious;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonStockOutDetailReportPageListFirst;
        private System.Windows.Forms.Button buttonStockOutDetailReportPageListLast;
        private System.Windows.Forms.TextBox textBoxStockOutDetailReportPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonGenerateCSV;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewStockOutDetailReport;
        private System.Windows.Forms.TextBox textBoxStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxBranch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxEndDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogGenerateCSV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutDetailReportListOTNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutDetailReportListOTDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutDetailReportListBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutDetailReportListRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutDetailReportListPreparedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutDetailReportListCheckedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutDetailReportListApprovedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutDetailReportListItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutDetailReportListItemDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutDetailReportListItemInventoryCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutDetailReportListUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutDetailReportListQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutDetailReportListCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutDetailReportListAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutDetailReportListBaseQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutDetailReportListBaseCost;
        private System.Windows.Forms.TextBox textBoxItemListFilter;
    }
}