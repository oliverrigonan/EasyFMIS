namespace easyfmis.Forms.Software.RepInventoryReport
{
    partial class RepInventoryReportStockTransferDetailReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepInventoryReportStockTransferDetailReportForm));
            this.buttonStockTransferDetailReportPageListNext = new System.Windows.Forms.Button();
            this.buttonStockTransferDetailReportPageListPrevious = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonStockTransferDetailReportPageListFirst = new System.Windows.Forms.Button();
            this.buttonStockTransferDetailReportPageListLast = new System.Windows.Forms.Button();
            this.buttonStockTransferDetailReportPageNumber = new System.Windows.Forms.TextBox();
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
            this.dataGridViewStockTransferDetailReport = new System.Windows.Forms.DataGridView();
            this.buttonGenerateCSV = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.folderBrowserDialogGenerateCSV = new System.Windows.Forms.FolderBrowserDialog();
            this.ColumnStockTransferDetailReportListSTNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockTransferDetailReportListSTDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockTransferDetailReportListBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockTransferDetailReportListToBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockTransferDetailReportListRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockTransferDetailReportListPreparedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockTransferDetailReportListCheckedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockTransferDetailReportListApprovedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockTransferDetailReportListItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockTransferDetailReportListItemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockTransferDetailReportListItemInventoryCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockTransferDetailReportListUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockTransferDetailReportListQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockTransferDetailReportListCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockTransferDetailReportListAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockTransferDetailReportListBaseQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockTransferDetailReportListBaseCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockTransferDetailReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStockTransferDetailReportPageListNext
            // 
            this.buttonStockTransferDetailReportPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockTransferDetailReportPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonStockTransferDetailReportPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockTransferDetailReportPageListNext.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonStockTransferDetailReportPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonStockTransferDetailReportPageListNext.Name = "buttonStockTransferDetailReportPageListNext";
            this.buttonStockTransferDetailReportPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonStockTransferDetailReportPageListNext.TabIndex = 10;
            this.buttonStockTransferDetailReportPageListNext.Text = "Next";
            this.buttonStockTransferDetailReportPageListNext.UseVisualStyleBackColor = false;
            this.buttonStockTransferDetailReportPageListNext.Click += new System.EventHandler(this.buttonStockTransferDetailReportPageListNext_Click);
            // 
            // buttonStockTransferDetailReportPageListPrevious
            // 
            this.buttonStockTransferDetailReportPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockTransferDetailReportPageListPrevious.Enabled = false;
            this.buttonStockTransferDetailReportPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonStockTransferDetailReportPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockTransferDetailReportPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonStockTransferDetailReportPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonStockTransferDetailReportPageListPrevious.Name = "buttonStockTransferDetailReportPageListPrevious";
            this.buttonStockTransferDetailReportPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonStockTransferDetailReportPageListPrevious.TabIndex = 9;
            this.buttonStockTransferDetailReportPageListPrevious.Text = "Previous";
            this.buttonStockTransferDetailReportPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonStockTransferDetailReportPageListPrevious.Click += new System.EventHandler(this.buttonStockTransferDetailReportPageListPrevious_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.buttonStockTransferDetailReportPageListFirst);
            this.panel4.Controls.Add(this.buttonStockTransferDetailReportPageListNext);
            this.panel4.Controls.Add(this.buttonStockTransferDetailReportPageListLast);
            this.panel4.Controls.Add(this.buttonStockTransferDetailReportPageListPrevious);
            this.panel4.Controls.Add(this.buttonStockTransferDetailReportPageNumber);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 537);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1382, 53);
            this.panel4.TabIndex = 20;
            // 
            // buttonStockTransferDetailReportPageListFirst
            // 
            this.buttonStockTransferDetailReportPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockTransferDetailReportPageListFirst.Enabled = false;
            this.buttonStockTransferDetailReportPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonStockTransferDetailReportPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockTransferDetailReportPageListFirst.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonStockTransferDetailReportPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonStockTransferDetailReportPageListFirst.Name = "buttonStockTransferDetailReportPageListFirst";
            this.buttonStockTransferDetailReportPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonStockTransferDetailReportPageListFirst.TabIndex = 8;
            this.buttonStockTransferDetailReportPageListFirst.Text = "First";
            this.buttonStockTransferDetailReportPageListFirst.UseVisualStyleBackColor = false;
            this.buttonStockTransferDetailReportPageListFirst.Click += new System.EventHandler(this.buttonStockTransferDetailReportPageListFirst_Click);
            // 
            // buttonStockTransferDetailReportPageListLast
            // 
            this.buttonStockTransferDetailReportPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockTransferDetailReportPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonStockTransferDetailReportPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockTransferDetailReportPageListLast.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonStockTransferDetailReportPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonStockTransferDetailReportPageListLast.Name = "buttonStockTransferDetailReportPageListLast";
            this.buttonStockTransferDetailReportPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonStockTransferDetailReportPageListLast.TabIndex = 11;
            this.buttonStockTransferDetailReportPageListLast.Text = "Last";
            this.buttonStockTransferDetailReportPageListLast.UseVisualStyleBackColor = false;
            this.buttonStockTransferDetailReportPageListLast.Click += new System.EventHandler(this.buttonStockTransferDetailReportPageListLast_Click);
            // 
            // buttonStockTransferDetailReportPageNumber
            // 
            this.buttonStockTransferDetailReportPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockTransferDetailReportPageNumber.BackColor = System.Drawing.Color.White;
            this.buttonStockTransferDetailReportPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.buttonStockTransferDetailReportPageNumber.Location = new System.Drawing.Point(188, 14);
            this.buttonStockTransferDetailReportPageNumber.Name = "buttonStockTransferDetailReportPageNumber";
            this.buttonStockTransferDetailReportPageNumber.ReadOnly = true;
            this.buttonStockTransferDetailReportPageNumber.Size = new System.Drawing.Size(69, 23);
            this.buttonStockTransferDetailReportPageNumber.TabIndex = 12;
            this.buttonStockTransferDetailReportPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewStockTransferDetailReport);
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
            // dataGridViewStockTransferDetailReport
            // 
            this.dataGridViewStockTransferDetailReport.AllowUserToAddRows = false;
            this.dataGridViewStockTransferDetailReport.AllowUserToDeleteRows = false;
            this.dataGridViewStockTransferDetailReport.AllowUserToResizeRows = false;
            this.dataGridViewStockTransferDetailReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStockTransferDetailReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewStockTransferDetailReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStockTransferDetailReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStockTransferDetailReportListSTNumber,
            this.ColumnStockTransferDetailReportListSTDate,
            this.ColumnStockTransferDetailReportListBranch,
            this.ColumnStockTransferDetailReportListToBranch,
            this.ColumnStockTransferDetailReportListRemarks,
            this.ColumnStockTransferDetailReportListPreparedBy,
            this.ColumnStockTransferDetailReportListCheckedBy,
            this.ColumnStockTransferDetailReportListApprovedBy,
            this.ColumnStockTransferDetailReportListItemCode,
            this.ColumnStockTransferDetailReportListItemDescription,
            this.ColumnStockTransferDetailReportListItemInventoryCode,
            this.ColumnStockTransferDetailReportListUnit,
            this.ColumnStockTransferDetailReportListQuantity,
            this.ColumnStockTransferDetailReportListCost,
            this.ColumnStockTransferDetailReportListAmount,
            this.ColumnStockTransferDetailReportListBaseQuantity,
            this.ColumnStockTransferDetailReportListBaseCost});
            this.dataGridViewStockTransferDetailReport.Location = new System.Drawing.Point(12, 53);
            this.dataGridViewStockTransferDetailReport.MultiSelect = false;
            this.dataGridViewStockTransferDetailReport.Name = "dataGridViewStockTransferDetailReport";
            this.dataGridViewStockTransferDetailReport.ReadOnly = true;
            this.dataGridViewStockTransferDetailReport.RowHeadersVisible = false;
            this.dataGridViewStockTransferDetailReport.RowTemplate.Height = 24;
            this.dataGridViewStockTransferDetailReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStockTransferDetailReport.Size = new System.Drawing.Size(1357, 478);
            this.dataGridViewStockTransferDetailReport.TabIndex = 21;
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
            this.label1.Size = new System.Drawing.Size(346, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stock Transfer Detail Report";
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
            // ColumnStockTransferDetailReportListSTNumber
            // 
            this.ColumnStockTransferDetailReportListSTNumber.DataPropertyName = "ColumnStockTransferDetailReportListSTNumber";
            this.ColumnStockTransferDetailReportListSTNumber.HeaderText = "ST Number";
            this.ColumnStockTransferDetailReportListSTNumber.Name = "ColumnStockTransferDetailReportListSTNumber";
            this.ColumnStockTransferDetailReportListSTNumber.ReadOnly = true;
            this.ColumnStockTransferDetailReportListSTNumber.Width = 150;
            // 
            // ColumnStockTransferDetailReportListSTDate
            // 
            this.ColumnStockTransferDetailReportListSTDate.DataPropertyName = "ColumnStockTransferDetailReportListSTDate";
            this.ColumnStockTransferDetailReportListSTDate.HeaderText = "ST Date";
            this.ColumnStockTransferDetailReportListSTDate.Name = "ColumnStockTransferDetailReportListSTDate";
            this.ColumnStockTransferDetailReportListSTDate.ReadOnly = true;
            this.ColumnStockTransferDetailReportListSTDate.Width = 150;
            // 
            // ColumnStockTransferDetailReportListBranch
            // 
            this.ColumnStockTransferDetailReportListBranch.DataPropertyName = "ColumnStockTransferDetailReportListBranch";
            this.ColumnStockTransferDetailReportListBranch.HeaderText = "Branch";
            this.ColumnStockTransferDetailReportListBranch.Name = "ColumnStockTransferDetailReportListBranch";
            this.ColumnStockTransferDetailReportListBranch.ReadOnly = true;
            this.ColumnStockTransferDetailReportListBranch.Width = 200;
            // 
            // ColumnStockTransferDetailReportListToBranch
            // 
            this.ColumnStockTransferDetailReportListToBranch.DataPropertyName = "ColumnStockTransferDetailReportListToBranch";
            this.ColumnStockTransferDetailReportListToBranch.HeaderText = "To Branch";
            this.ColumnStockTransferDetailReportListToBranch.Name = "ColumnStockTransferDetailReportListToBranch";
            this.ColumnStockTransferDetailReportListToBranch.ReadOnly = true;
            this.ColumnStockTransferDetailReportListToBranch.Width = 200;
            // 
            // ColumnStockTransferDetailReportListRemarks
            // 
            this.ColumnStockTransferDetailReportListRemarks.DataPropertyName = "ColumnStockTransferDetailReportListRemarks";
            this.ColumnStockTransferDetailReportListRemarks.HeaderText = "Remarks";
            this.ColumnStockTransferDetailReportListRemarks.Name = "ColumnStockTransferDetailReportListRemarks";
            this.ColumnStockTransferDetailReportListRemarks.ReadOnly = true;
            this.ColumnStockTransferDetailReportListRemarks.Width = 200;
            // 
            // ColumnStockTransferDetailReportListPreparedBy
            // 
            this.ColumnStockTransferDetailReportListPreparedBy.DataPropertyName = "ColumnStockTransferDetailReportListPreparedBy";
            this.ColumnStockTransferDetailReportListPreparedBy.HeaderText = "Prepared By";
            this.ColumnStockTransferDetailReportListPreparedBy.Name = "ColumnStockTransferDetailReportListPreparedBy";
            this.ColumnStockTransferDetailReportListPreparedBy.ReadOnly = true;
            this.ColumnStockTransferDetailReportListPreparedBy.Width = 200;
            // 
            // ColumnStockTransferDetailReportListCheckedBy
            // 
            this.ColumnStockTransferDetailReportListCheckedBy.DataPropertyName = "ColumnStockTransferDetailReportListCheckedBy";
            this.ColumnStockTransferDetailReportListCheckedBy.HeaderText = "Checked By";
            this.ColumnStockTransferDetailReportListCheckedBy.Name = "ColumnStockTransferDetailReportListCheckedBy";
            this.ColumnStockTransferDetailReportListCheckedBy.ReadOnly = true;
            this.ColumnStockTransferDetailReportListCheckedBy.Width = 200;
            // 
            // ColumnStockTransferDetailReportListApprovedBy
            // 
            this.ColumnStockTransferDetailReportListApprovedBy.DataPropertyName = "ColumnStockTransferDetailReportListApprovedBy";
            this.ColumnStockTransferDetailReportListApprovedBy.HeaderText = "Approved By";
            this.ColumnStockTransferDetailReportListApprovedBy.Name = "ColumnStockTransferDetailReportListApprovedBy";
            this.ColumnStockTransferDetailReportListApprovedBy.ReadOnly = true;
            this.ColumnStockTransferDetailReportListApprovedBy.Width = 200;
            // 
            // ColumnStockTransferDetailReportListItemCode
            // 
            this.ColumnStockTransferDetailReportListItemCode.DataPropertyName = "ColumnStockTransferDetailReportListItemCode";
            this.ColumnStockTransferDetailReportListItemCode.HeaderText = "Item Code";
            this.ColumnStockTransferDetailReportListItemCode.Name = "ColumnStockTransferDetailReportListItemCode";
            this.ColumnStockTransferDetailReportListItemCode.ReadOnly = true;
            this.ColumnStockTransferDetailReportListItemCode.Width = 150;
            // 
            // ColumnStockTransferDetailReportListItemDescription
            // 
            this.ColumnStockTransferDetailReportListItemDescription.DataPropertyName = "ColumnStockTransferDetailReportListItemDescription";
            this.ColumnStockTransferDetailReportListItemDescription.HeaderText = "Item Description";
            this.ColumnStockTransferDetailReportListItemDescription.Name = "ColumnStockTransferDetailReportListItemDescription";
            this.ColumnStockTransferDetailReportListItemDescription.ReadOnly = true;
            this.ColumnStockTransferDetailReportListItemDescription.Width = 250;
            // 
            // ColumnStockTransferDetailReportListItemInventoryCode
            // 
            this.ColumnStockTransferDetailReportListItemInventoryCode.DataPropertyName = "ColumnStockTransferDetailReportListItemInventoryCode";
            this.ColumnStockTransferDetailReportListItemInventoryCode.HeaderText = "Item InventoryCode";
            this.ColumnStockTransferDetailReportListItemInventoryCode.Name = "ColumnStockTransferDetailReportListItemInventoryCode";
            this.ColumnStockTransferDetailReportListItemInventoryCode.ReadOnly = true;
            this.ColumnStockTransferDetailReportListItemInventoryCode.Width = 250;
            // 
            // ColumnStockTransferDetailReportListUnit
            // 
            this.ColumnStockTransferDetailReportListUnit.DataPropertyName = "ColumnStockTransferDetailReportListUnit";
            this.ColumnStockTransferDetailReportListUnit.HeaderText = "Unit";
            this.ColumnStockTransferDetailReportListUnit.Name = "ColumnStockTransferDetailReportListUnit";
            this.ColumnStockTransferDetailReportListUnit.ReadOnly = true;
            this.ColumnStockTransferDetailReportListUnit.Width = 150;
            // 
            // ColumnStockTransferDetailReportListQuantity
            // 
            this.ColumnStockTransferDetailReportListQuantity.DataPropertyName = "ColumnStockTransferDetailReportListQuantity";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnStockTransferDetailReportListQuantity.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnStockTransferDetailReportListQuantity.HeaderText = "Quantity";
            this.ColumnStockTransferDetailReportListQuantity.Name = "ColumnStockTransferDetailReportListQuantity";
            this.ColumnStockTransferDetailReportListQuantity.ReadOnly = true;
            this.ColumnStockTransferDetailReportListQuantity.Width = 200;
            // 
            // ColumnStockTransferDetailReportListCost
            // 
            this.ColumnStockTransferDetailReportListCost.DataPropertyName = "ColumnStockTransferDetailReportListCost";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnStockTransferDetailReportListCost.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnStockTransferDetailReportListCost.HeaderText = "Cost";
            this.ColumnStockTransferDetailReportListCost.Name = "ColumnStockTransferDetailReportListCost";
            this.ColumnStockTransferDetailReportListCost.ReadOnly = true;
            this.ColumnStockTransferDetailReportListCost.Width = 200;
            // 
            // ColumnStockTransferDetailReportListAmount
            // 
            this.ColumnStockTransferDetailReportListAmount.DataPropertyName = "ColumnStockTransferDetailReportListAmount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnStockTransferDetailReportListAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnStockTransferDetailReportListAmount.HeaderText = "Amount";
            this.ColumnStockTransferDetailReportListAmount.Name = "ColumnStockTransferDetailReportListAmount";
            this.ColumnStockTransferDetailReportListAmount.ReadOnly = true;
            this.ColumnStockTransferDetailReportListAmount.Width = 200;
            // 
            // ColumnStockTransferDetailReportListBaseQuantity
            // 
            this.ColumnStockTransferDetailReportListBaseQuantity.DataPropertyName = "ColumnStockTransferDetailReportListBaseQuantity";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnStockTransferDetailReportListBaseQuantity.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnStockTransferDetailReportListBaseQuantity.HeaderText = "Base Quantity";
            this.ColumnStockTransferDetailReportListBaseQuantity.Name = "ColumnStockTransferDetailReportListBaseQuantity";
            this.ColumnStockTransferDetailReportListBaseQuantity.ReadOnly = true;
            this.ColumnStockTransferDetailReportListBaseQuantity.Width = 200;
            // 
            // ColumnStockTransferDetailReportListBaseCost
            // 
            this.ColumnStockTransferDetailReportListBaseCost.DataPropertyName = "ColumnStockTransferDetailReportListBaseCost";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnStockTransferDetailReportListBaseCost.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnStockTransferDetailReportListBaseCost.HeaderText = "Base Cost";
            this.ColumnStockTransferDetailReportListBaseCost.Name = "ColumnStockTransferDetailReportListBaseCost";
            this.ColumnStockTransferDetailReportListBaseCost.ReadOnly = true;
            this.ColumnStockTransferDetailReportListBaseCost.Width = 200;
            // 
            // RepInventoryReportStockTransferDetailReportForm
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
            this.Name = "RepInventoryReportStockTransferDetailReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Transfer Detail Report";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockTransferDetailReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStockTransferDetailReportPageListNext;
        private System.Windows.Forms.Button buttonStockTransferDetailReportPageListPrevious;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonStockTransferDetailReportPageListFirst;
        private System.Windows.Forms.Button buttonStockTransferDetailReportPageListLast;
        private System.Windows.Forms.TextBox buttonStockTransferDetailReportPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonGenerateCSV;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewStockTransferDetailReport;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockTransferDetailReportListSTNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockTransferDetailReportListSTDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockTransferDetailReportListBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockTransferDetailReportListToBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockTransferDetailReportListRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockTransferDetailReportListPreparedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockTransferDetailReportListCheckedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockTransferDetailReportListApprovedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockTransferDetailReportListItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockTransferDetailReportListItemDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockTransferDetailReportListItemInventoryCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockTransferDetailReportListUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockTransferDetailReportListQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockTransferDetailReportListCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockTransferDetailReportListAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockTransferDetailReportListBaseQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockTransferDetailReportListBaseCost;
    }
}