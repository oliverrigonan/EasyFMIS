namespace easyfmis.Forms.Software.RepInventoryReport
{
    partial class RepInventoryReportStockInDetailReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepInventoryReportStockInDetailReportForm));
            this.buttonStockInDetailReportPageListNext = new System.Windows.Forms.Button();
            this.buttonStockInDetailReportPageListPrevious = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonStockInDetailReportPageListFirst = new System.Windows.Forms.Button();
            this.buttonStockInDetailReportPageListLast = new System.Windows.Forms.Button();
            this.textBoxStockInDetailReportPageNumber = new System.Windows.Forms.TextBox();
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
            this.dataGridViewStockInDetailReport = new System.Windows.Forms.DataGridView();
            this.ColumnStockInDetailReportListINNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockInDetailReportListINDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockInDetailReportListBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockInDetailReportListRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockInDetailReportListPreparedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockInDetailReportListCheckedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockInDetailReportListApprovedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockInDetailReportListItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockInDetailReportListItemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockInDetailReportListUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockInDetailReportListQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockInDetailReportListCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockInDetailReportListAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockInDetailReportListBaseQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockInDetailReportListBaseCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockInDetailReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStockInDetailReportPageListNext
            // 
            this.buttonStockInDetailReportPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockInDetailReportPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonStockInDetailReportPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockInDetailReportPageListNext.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonStockInDetailReportPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonStockInDetailReportPageListNext.Name = "buttonStockInDetailReportPageListNext";
            this.buttonStockInDetailReportPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonStockInDetailReportPageListNext.TabIndex = 10;
            this.buttonStockInDetailReportPageListNext.Text = "Next";
            this.buttonStockInDetailReportPageListNext.UseVisualStyleBackColor = false;
            this.buttonStockInDetailReportPageListNext.Click += new System.EventHandler(this.buttonStockInDetailReportPageListNext_Click);
            // 
            // buttonStockInDetailReportPageListPrevious
            // 
            this.buttonStockInDetailReportPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockInDetailReportPageListPrevious.Enabled = false;
            this.buttonStockInDetailReportPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonStockInDetailReportPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockInDetailReportPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonStockInDetailReportPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonStockInDetailReportPageListPrevious.Name = "buttonStockInDetailReportPageListPrevious";
            this.buttonStockInDetailReportPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonStockInDetailReportPageListPrevious.TabIndex = 9;
            this.buttonStockInDetailReportPageListPrevious.Text = "Previous";
            this.buttonStockInDetailReportPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonStockInDetailReportPageListPrevious.Click += new System.EventHandler(this.buttonStockInDetailReportPageListPrevious_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.buttonStockInDetailReportPageListFirst);
            this.panel4.Controls.Add(this.buttonStockInDetailReportPageListNext);
            this.panel4.Controls.Add(this.buttonStockInDetailReportPageListLast);
            this.panel4.Controls.Add(this.buttonStockInDetailReportPageListPrevious);
            this.panel4.Controls.Add(this.textBoxStockInDetailReportPageNumber);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 537);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1382, 53);
            this.panel4.TabIndex = 20;
            // 
            // buttonStockInDetailReportPageListFirst
            // 
            this.buttonStockInDetailReportPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockInDetailReportPageListFirst.Enabled = false;
            this.buttonStockInDetailReportPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonStockInDetailReportPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockInDetailReportPageListFirst.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonStockInDetailReportPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonStockInDetailReportPageListFirst.Name = "buttonStockInDetailReportPageListFirst";
            this.buttonStockInDetailReportPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonStockInDetailReportPageListFirst.TabIndex = 8;
            this.buttonStockInDetailReportPageListFirst.Text = "First";
            this.buttonStockInDetailReportPageListFirst.UseVisualStyleBackColor = false;
            this.buttonStockInDetailReportPageListFirst.Click += new System.EventHandler(this.buttonStockInDetailReportPageListFirst_Click);
            // 
            // buttonStockInDetailReportPageListLast
            // 
            this.buttonStockInDetailReportPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockInDetailReportPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonStockInDetailReportPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockInDetailReportPageListLast.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonStockInDetailReportPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonStockInDetailReportPageListLast.Name = "buttonStockInDetailReportPageListLast";
            this.buttonStockInDetailReportPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonStockInDetailReportPageListLast.TabIndex = 11;
            this.buttonStockInDetailReportPageListLast.Text = "Last";
            this.buttonStockInDetailReportPageListLast.UseVisualStyleBackColor = false;
            this.buttonStockInDetailReportPageListLast.Click += new System.EventHandler(this.buttonStockInDetailReportPageListLast_Click);
            // 
            // textBoxStockInDetailReportPageNumber
            // 
            this.textBoxStockInDetailReportPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxStockInDetailReportPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxStockInDetailReportPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxStockInDetailReportPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxStockInDetailReportPageNumber.Name = "textBoxStockInDetailReportPageNumber";
            this.textBoxStockInDetailReportPageNumber.ReadOnly = true;
            this.textBoxStockInDetailReportPageNumber.Size = new System.Drawing.Size(69, 23);
            this.textBoxStockInDetailReportPageNumber.TabIndex = 12;
            this.textBoxStockInDetailReportPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.textBoxItemListFilter);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewStockInDetailReport);
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
            // dataGridViewStockInDetailReport
            // 
            this.dataGridViewStockInDetailReport.AllowUserToAddRows = false;
            this.dataGridViewStockInDetailReport.AllowUserToDeleteRows = false;
            this.dataGridViewStockInDetailReport.AllowUserToResizeRows = false;
            this.dataGridViewStockInDetailReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStockInDetailReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewStockInDetailReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStockInDetailReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStockInDetailReportListINNumber,
            this.ColumnStockInDetailReportListINDate,
            this.ColumnStockInDetailReportListBranch,
            this.ColumnStockInDetailReportListRemarks,
            this.ColumnStockInDetailReportListPreparedBy,
            this.ColumnStockInDetailReportListCheckedBy,
            this.ColumnStockInDetailReportListApprovedBy,
            this.ColumnStockInDetailReportListItemCode,
            this.ColumnStockInDetailReportListItemDescription,
            this.ColumnStockInDetailReportListUnit,
            this.ColumnStockInDetailReportListQuantity,
            this.ColumnStockInDetailReportListCost,
            this.ColumnStockInDetailReportListAmount,
            this.ColumnStockInDetailReportListBaseQuantity,
            this.ColumnStockInDetailReportListBaseCost});
            this.dataGridViewStockInDetailReport.Location = new System.Drawing.Point(12, 89);
            this.dataGridViewStockInDetailReport.MultiSelect = false;
            this.dataGridViewStockInDetailReport.Name = "dataGridViewStockInDetailReport";
            this.dataGridViewStockInDetailReport.ReadOnly = true;
            this.dataGridViewStockInDetailReport.RowHeadersVisible = false;
            this.dataGridViewStockInDetailReport.RowTemplate.Height = 24;
            this.dataGridViewStockInDetailReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStockInDetailReport.Size = new System.Drawing.Size(1357, 442);
            this.dataGridViewStockInDetailReport.TabIndex = 21;
            // 
            // ColumnStockInDetailReportListINNumber
            // 
            this.ColumnStockInDetailReportListINNumber.DataPropertyName = "ColumnStockInDetailReportListINNumber";
            this.ColumnStockInDetailReportListINNumber.HeaderText = "IN Number";
            this.ColumnStockInDetailReportListINNumber.Name = "ColumnStockInDetailReportListINNumber";
            this.ColumnStockInDetailReportListINNumber.ReadOnly = true;
            this.ColumnStockInDetailReportListINNumber.Width = 150;
            // 
            // ColumnStockInDetailReportListINDate
            // 
            this.ColumnStockInDetailReportListINDate.DataPropertyName = "ColumnStockInDetailReportListINDate";
            this.ColumnStockInDetailReportListINDate.HeaderText = "IN Date";
            this.ColumnStockInDetailReportListINDate.Name = "ColumnStockInDetailReportListINDate";
            this.ColumnStockInDetailReportListINDate.ReadOnly = true;
            this.ColumnStockInDetailReportListINDate.Width = 150;
            // 
            // ColumnStockInDetailReportListBranch
            // 
            this.ColumnStockInDetailReportListBranch.DataPropertyName = "ColumnStockInDetailReportListBranch";
            this.ColumnStockInDetailReportListBranch.HeaderText = "Branch";
            this.ColumnStockInDetailReportListBranch.Name = "ColumnStockInDetailReportListBranch";
            this.ColumnStockInDetailReportListBranch.ReadOnly = true;
            this.ColumnStockInDetailReportListBranch.Width = 200;
            // 
            // ColumnStockInDetailReportListRemarks
            // 
            this.ColumnStockInDetailReportListRemarks.DataPropertyName = "ColumnStockInDetailReportListRemarks";
            this.ColumnStockInDetailReportListRemarks.HeaderText = "Remarks";
            this.ColumnStockInDetailReportListRemarks.Name = "ColumnStockInDetailReportListRemarks";
            this.ColumnStockInDetailReportListRemarks.ReadOnly = true;
            this.ColumnStockInDetailReportListRemarks.Width = 200;
            // 
            // ColumnStockInDetailReportListPreparedBy
            // 
            this.ColumnStockInDetailReportListPreparedBy.DataPropertyName = "ColumnStockInDetailReportListPreparedBy";
            this.ColumnStockInDetailReportListPreparedBy.HeaderText = "Prepared By";
            this.ColumnStockInDetailReportListPreparedBy.Name = "ColumnStockInDetailReportListPreparedBy";
            this.ColumnStockInDetailReportListPreparedBy.ReadOnly = true;
            this.ColumnStockInDetailReportListPreparedBy.Width = 200;
            // 
            // ColumnStockInDetailReportListCheckedBy
            // 
            this.ColumnStockInDetailReportListCheckedBy.DataPropertyName = "ColumnStockInDetailReportListCheckedBy";
            this.ColumnStockInDetailReportListCheckedBy.HeaderText = "Checked By";
            this.ColumnStockInDetailReportListCheckedBy.Name = "ColumnStockInDetailReportListCheckedBy";
            this.ColumnStockInDetailReportListCheckedBy.ReadOnly = true;
            this.ColumnStockInDetailReportListCheckedBy.Width = 200;
            // 
            // ColumnStockInDetailReportListApprovedBy
            // 
            this.ColumnStockInDetailReportListApprovedBy.DataPropertyName = "ColumnStockInDetailReportListApprovedBy";
            this.ColumnStockInDetailReportListApprovedBy.HeaderText = "Approved  By";
            this.ColumnStockInDetailReportListApprovedBy.Name = "ColumnStockInDetailReportListApprovedBy";
            this.ColumnStockInDetailReportListApprovedBy.ReadOnly = true;
            this.ColumnStockInDetailReportListApprovedBy.Width = 200;
            // 
            // ColumnStockInDetailReportListItemCode
            // 
            this.ColumnStockInDetailReportListItemCode.DataPropertyName = "ColumnStockInDetailReportListItemCode";
            this.ColumnStockInDetailReportListItemCode.HeaderText = "Item Code";
            this.ColumnStockInDetailReportListItemCode.Name = "ColumnStockInDetailReportListItemCode";
            this.ColumnStockInDetailReportListItemCode.ReadOnly = true;
            this.ColumnStockInDetailReportListItemCode.Width = 180;
            // 
            // ColumnStockInDetailReportListItemDescription
            // 
            this.ColumnStockInDetailReportListItemDescription.DataPropertyName = "ColumnStockInDetailReportListItemDescription";
            this.ColumnStockInDetailReportListItemDescription.HeaderText = "Item Description";
            this.ColumnStockInDetailReportListItemDescription.Name = "ColumnStockInDetailReportListItemDescription";
            this.ColumnStockInDetailReportListItemDescription.ReadOnly = true;
            this.ColumnStockInDetailReportListItemDescription.Width = 250;
            // 
            // ColumnStockInDetailReportListUnit
            // 
            this.ColumnStockInDetailReportListUnit.DataPropertyName = "ColumnStockInDetailReportListUnit";
            this.ColumnStockInDetailReportListUnit.HeaderText = "Unit";
            this.ColumnStockInDetailReportListUnit.Name = "ColumnStockInDetailReportListUnit";
            this.ColumnStockInDetailReportListUnit.ReadOnly = true;
            this.ColumnStockInDetailReportListUnit.Width = 150;
            // 
            // ColumnStockInDetailReportListQuantity
            // 
            this.ColumnStockInDetailReportListQuantity.DataPropertyName = "ColumnStockInDetailReportListQuantity";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnStockInDetailReportListQuantity.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnStockInDetailReportListQuantity.HeaderText = "Quantity";
            this.ColumnStockInDetailReportListQuantity.Name = "ColumnStockInDetailReportListQuantity";
            this.ColumnStockInDetailReportListQuantity.ReadOnly = true;
            this.ColumnStockInDetailReportListQuantity.Width = 200;
            // 
            // ColumnStockInDetailReportListCost
            // 
            this.ColumnStockInDetailReportListCost.DataPropertyName = "ColumnStockInDetailReportListCost";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnStockInDetailReportListCost.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnStockInDetailReportListCost.HeaderText = "Cost";
            this.ColumnStockInDetailReportListCost.Name = "ColumnStockInDetailReportListCost";
            this.ColumnStockInDetailReportListCost.ReadOnly = true;
            this.ColumnStockInDetailReportListCost.Width = 200;
            // 
            // ColumnStockInDetailReportListAmount
            // 
            this.ColumnStockInDetailReportListAmount.DataPropertyName = "ColumnStockInDetailReportListAmount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnStockInDetailReportListAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnStockInDetailReportListAmount.HeaderText = "Amount";
            this.ColumnStockInDetailReportListAmount.Name = "ColumnStockInDetailReportListAmount";
            this.ColumnStockInDetailReportListAmount.ReadOnly = true;
            this.ColumnStockInDetailReportListAmount.Width = 200;
            // 
            // ColumnStockInDetailReportListBaseQuantity
            // 
            this.ColumnStockInDetailReportListBaseQuantity.DataPropertyName = "ColumnStockInDetailReportListBaseQuantity";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnStockInDetailReportListBaseQuantity.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnStockInDetailReportListBaseQuantity.HeaderText = "Base Quantity";
            this.ColumnStockInDetailReportListBaseQuantity.Name = "ColumnStockInDetailReportListBaseQuantity";
            this.ColumnStockInDetailReportListBaseQuantity.ReadOnly = true;
            this.ColumnStockInDetailReportListBaseQuantity.Width = 200;
            // 
            // ColumnStockInDetailReportListBaseCost
            // 
            this.ColumnStockInDetailReportListBaseCost.DataPropertyName = "ColumnStockInDetailReportListBaseCost";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnStockInDetailReportListBaseCost.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnStockInDetailReportListBaseCost.HeaderText = "Base Cost";
            this.ColumnStockInDetailReportListBaseCost.Name = "ColumnStockInDetailReportListBaseCost";
            this.ColumnStockInDetailReportListBaseCost.ReadOnly = true;
            this.ColumnStockInDetailReportListBaseCost.Width = 200;
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
            this.label1.Size = new System.Drawing.Size(273, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stock In Detail Report";
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
            this.textBoxItemListFilter.TabIndex = 39;
            this.textBoxItemListFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxItemListFilter_KeyDown);
            // 
            // RepInventoryReportStockInDetailReportForm
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
            this.Name = "RepInventoryReportStockInDetailReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock In Detail Report";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockInDetailReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStockInDetailReportPageListNext;
        private System.Windows.Forms.Button buttonStockInDetailReportPageListPrevious;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonStockInDetailReportPageListFirst;
        private System.Windows.Forms.Button buttonStockInDetailReportPageListLast;
        private System.Windows.Forms.TextBox textBoxStockInDetailReportPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonGenerateCSV;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewStockInDetailReport;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockInDetailReportListINNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockInDetailReportListINDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockInDetailReportListBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockInDetailReportListRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockInDetailReportListPreparedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockInDetailReportListCheckedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockInDetailReportListApprovedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockInDetailReportListItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockInDetailReportListItemDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockInDetailReportListUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockInDetailReportListQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockInDetailReportListCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockInDetailReportListAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockInDetailReportListBaseQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockInDetailReportListBaseCost;
        private System.Windows.Forms.TextBox textBoxItemListFilter;
    }
}