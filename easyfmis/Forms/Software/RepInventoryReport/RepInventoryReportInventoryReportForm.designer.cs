namespace easyfmis.Forms.Software.RepInventoryReport
{
    partial class RepInventoryReportInventoryReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepInventoryReportInventoryReportForm));
            this.buttonInventoryReportPageListNext = new System.Windows.Forms.Button();
            this.buttonInventoryReportPageListPrevious = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonInventoryReportPageListFirst = new System.Windows.Forms.Button();
            this.buttonInventoryReportPageListLast = new System.Windows.Forms.Button();
            this.textBoxInventoryReportPageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxStartDate = new System.Windows.Forms.TextBox();
            this.textBoxEndDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCompany = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxBranch = new System.Windows.Forms.TextBox();
            this.dataGridViewInventoryReport = new System.Windows.Forms.DataGridView();
            this.ColumnInventoryReportBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInventoryReportItemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInventoryReportInventoryCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInventoryReportUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInventoryReportBeginningQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInventoryReportInQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInventoryReportOutQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInventoryReportEndinguantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInventoryReportCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInventoryReportAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInventoryReportSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonGenerateCSV = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.folderBrowserDialogGenerateCSV = new System.Windows.Forms.FolderBrowserDialog();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventoryReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonInventoryReportPageListNext
            // 
            this.buttonInventoryReportPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonInventoryReportPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonInventoryReportPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInventoryReportPageListNext.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonInventoryReportPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonInventoryReportPageListNext.Name = "buttonInventoryReportPageListNext";
            this.buttonInventoryReportPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonInventoryReportPageListNext.TabIndex = 10;
            this.buttonInventoryReportPageListNext.Text = "Next";
            this.buttonInventoryReportPageListNext.UseVisualStyleBackColor = false;
            this.buttonInventoryReportPageListNext.Click += new System.EventHandler(this.buttonInventoryReportPageListNext_Click);
            // 
            // buttonInventoryReportPageListPrevious
            // 
            this.buttonInventoryReportPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonInventoryReportPageListPrevious.Enabled = false;
            this.buttonInventoryReportPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonInventoryReportPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInventoryReportPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonInventoryReportPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonInventoryReportPageListPrevious.Name = "buttonInventoryReportPageListPrevious";
            this.buttonInventoryReportPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonInventoryReportPageListPrevious.TabIndex = 9;
            this.buttonInventoryReportPageListPrevious.Text = "Previous";
            this.buttonInventoryReportPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonInventoryReportPageListPrevious.Click += new System.EventHandler(this.buttonInventoryReportPageListPrevious_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.buttonInventoryReportPageListFirst);
            this.panel4.Controls.Add(this.buttonInventoryReportPageListNext);
            this.panel4.Controls.Add(this.buttonInventoryReportPageListLast);
            this.panel4.Controls.Add(this.buttonInventoryReportPageListPrevious);
            this.panel4.Controls.Add(this.textBoxInventoryReportPageNumber);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 537);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1382, 53);
            this.panel4.TabIndex = 20;
            // 
            // buttonInventoryReportPageListFirst
            // 
            this.buttonInventoryReportPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonInventoryReportPageListFirst.Enabled = false;
            this.buttonInventoryReportPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonInventoryReportPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInventoryReportPageListFirst.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonInventoryReportPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonInventoryReportPageListFirst.Name = "buttonInventoryReportPageListFirst";
            this.buttonInventoryReportPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonInventoryReportPageListFirst.TabIndex = 8;
            this.buttonInventoryReportPageListFirst.Text = "First";
            this.buttonInventoryReportPageListFirst.UseVisualStyleBackColor = false;
            this.buttonInventoryReportPageListFirst.Click += new System.EventHandler(this.buttonInventoryReportPageListFirst_Click);
            // 
            // buttonInventoryReportPageListLast
            // 
            this.buttonInventoryReportPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonInventoryReportPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonInventoryReportPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInventoryReportPageListLast.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonInventoryReportPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonInventoryReportPageListLast.Name = "buttonInventoryReportPageListLast";
            this.buttonInventoryReportPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonInventoryReportPageListLast.TabIndex = 11;
            this.buttonInventoryReportPageListLast.Text = "Last";
            this.buttonInventoryReportPageListLast.UseVisualStyleBackColor = false;
            this.buttonInventoryReportPageListLast.Click += new System.EventHandler(this.buttonInventoryReportPageListLast_Click);
            // 
            // textBoxInventoryReportPageNumber
            // 
            this.textBoxInventoryReportPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxInventoryReportPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxInventoryReportPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxInventoryReportPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxInventoryReportPageNumber.Name = "textBoxInventoryReportPageNumber";
            this.textBoxInventoryReportPageNumber.ReadOnly = true;
            this.textBoxInventoryReportPageNumber.Size = new System.Drawing.Size(69, 23);
            this.textBoxInventoryReportPageNumber.TabIndex = 12;
            this.textBoxInventoryReportPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewInventoryReport);
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
            this.panel3.Controls.Add(this.textBoxStartDate);
            this.panel3.Controls.Add(this.textBoxEndDate);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.textBoxCompany);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.textBoxBranch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1382, 47);
            this.panel3.TabIndex = 36;
            // 
            // textBoxStartDate
            // 
            this.textBoxStartDate.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxStartDate.Location = new System.Drawing.Point(108, 8);
            this.textBoxStartDate.Name = "textBoxStartDate";
            this.textBoxStartDate.ReadOnly = true;
            this.textBoxStartDate.Size = new System.Drawing.Size(149, 30);
            this.textBoxStartDate.TabIndex = 0;
            // 
            // textBoxEndDate
            // 
            this.textBoxEndDate.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxEndDate.Location = new System.Drawing.Point(348, 8);
            this.textBoxEndDate.Name = "textBoxEndDate";
            this.textBoxEndDate.ReadOnly = true;
            this.textBoxEndDate.Size = new System.Drawing.Size(149, 30);
            this.textBoxEndDate.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label5.Location = new System.Drawing.Point(503, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 23);
            this.label5.TabIndex = 28;
            this.label5.Text = "Company:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label4.Location = new System.Drawing.Point(263, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 23);
            this.label4.TabIndex = 34;
            this.label4.Text = "End Date:";
            // 
            // textBoxCompany
            // 
            this.textBoxCompany.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCompany.Location = new System.Drawing.Point(591, 8);
            this.textBoxCompany.Name = "textBoxCompany";
            this.textBoxCompany.ReadOnly = true;
            this.textBoxCompany.Size = new System.Drawing.Size(363, 30);
            this.textBoxCompany.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label2.Location = new System.Drawing.Point(960, 11);
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
            this.label3.Size = new System.Drawing.Size(90, 23);
            this.label3.TabIndex = 32;
            this.label3.Text = "Start Date:";
            // 
            // textBoxBranch
            // 
            this.textBoxBranch.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxBranch.Location = new System.Drawing.Point(1033, 8);
            this.textBoxBranch.Name = "textBoxBranch";
            this.textBoxBranch.ReadOnly = true;
            this.textBoxBranch.Size = new System.Drawing.Size(336, 30);
            this.textBoxBranch.TabIndex = 3;
            // 
            // dataGridViewInventoryReport
            // 
            this.dataGridViewInventoryReport.AllowUserToAddRows = false;
            this.dataGridViewInventoryReport.AllowUserToDeleteRows = false;
            this.dataGridViewInventoryReport.AllowUserToResizeRows = false;
            this.dataGridViewInventoryReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewInventoryReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewInventoryReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInventoryReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnInventoryReportBarCode,
            this.ColumnInventoryReportItemDescription,
            this.ColumnInventoryReportInventoryCode,
            this.ColumnInventoryReportUnit,
            this.ColumnInventoryReportBeginningQuantity,
            this.ColumnInventoryReportInQuantity,
            this.ColumnInventoryReportOutQuantity,
            this.ColumnInventoryReportEndinguantity,
            this.ColumnInventoryReportCost,
            this.ColumnInventoryReportAmount,
            this.ColumnInventoryReportSpace});
            this.dataGridViewInventoryReport.Location = new System.Drawing.Point(12, 53);
            this.dataGridViewInventoryReport.MultiSelect = false;
            this.dataGridViewInventoryReport.Name = "dataGridViewInventoryReport";
            this.dataGridViewInventoryReport.ReadOnly = true;
            this.dataGridViewInventoryReport.RowHeadersVisible = false;
            this.dataGridViewInventoryReport.RowTemplate.Height = 24;
            this.dataGridViewInventoryReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewInventoryReport.Size = new System.Drawing.Size(1357, 478);
            this.dataGridViewInventoryReport.TabIndex = 21;
            // 
            // ColumnInventoryReportBarCode
            // 
            this.ColumnInventoryReportBarCode.DataPropertyName = "ColumnInventoryReportBarCode";
            this.ColumnInventoryReportBarCode.HeaderText = "Bar Code";
            this.ColumnInventoryReportBarCode.Name = "ColumnInventoryReportBarCode";
            this.ColumnInventoryReportBarCode.ReadOnly = true;
            this.ColumnInventoryReportBarCode.Width = 250;
            // 
            // ColumnInventoryReportItemDescription
            // 
            this.ColumnInventoryReportItemDescription.DataPropertyName = "ColumnInventoryReportItemDescription";
            this.ColumnInventoryReportItemDescription.HeaderText = "Item Description";
            this.ColumnInventoryReportItemDescription.Name = "ColumnInventoryReportItemDescription";
            this.ColumnInventoryReportItemDescription.ReadOnly = true;
            this.ColumnInventoryReportItemDescription.Width = 350;
            // 
            // ColumnInventoryReportInventoryCode
            // 
            this.ColumnInventoryReportInventoryCode.DataPropertyName = "ColumnInventoryReportInventoryCode";
            this.ColumnInventoryReportInventoryCode.HeaderText = "Inventory Code";
            this.ColumnInventoryReportInventoryCode.Name = "ColumnInventoryReportInventoryCode";
            this.ColumnInventoryReportInventoryCode.ReadOnly = true;
            this.ColumnInventoryReportInventoryCode.Width = 200;
            // 
            // ColumnInventoryReportUnit
            // 
            this.ColumnInventoryReportUnit.DataPropertyName = "ColumnInventoryReportUnit";
            this.ColumnInventoryReportUnit.HeaderText = "Unit";
            this.ColumnInventoryReportUnit.Name = "ColumnInventoryReportUnit";
            this.ColumnInventoryReportUnit.ReadOnly = true;
            this.ColumnInventoryReportUnit.Width = 150;
            // 
            // ColumnInventoryReportBeginningQuantity
            // 
            this.ColumnInventoryReportBeginningQuantity.DataPropertyName = "ColumnInventoryReportBeginningQuantity";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnInventoryReportBeginningQuantity.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnInventoryReportBeginningQuantity.HeaderText = "Beg";
            this.ColumnInventoryReportBeginningQuantity.Name = "ColumnInventoryReportBeginningQuantity";
            this.ColumnInventoryReportBeginningQuantity.ReadOnly = true;
            this.ColumnInventoryReportBeginningQuantity.Width = 150;
            // 
            // ColumnInventoryReportInQuantity
            // 
            this.ColumnInventoryReportInQuantity.DataPropertyName = "ColumnInventoryReportInQuantity";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnInventoryReportInQuantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnInventoryReportInQuantity.HeaderText = "In";
            this.ColumnInventoryReportInQuantity.Name = "ColumnInventoryReportInQuantity";
            this.ColumnInventoryReportInQuantity.ReadOnly = true;
            this.ColumnInventoryReportInQuantity.Width = 150;
            // 
            // ColumnInventoryReportOutQuantity
            // 
            this.ColumnInventoryReportOutQuantity.DataPropertyName = "ColumnInventoryReportOutQuantity";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnInventoryReportOutQuantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnInventoryReportOutQuantity.HeaderText = "Out";
            this.ColumnInventoryReportOutQuantity.Name = "ColumnInventoryReportOutQuantity";
            this.ColumnInventoryReportOutQuantity.ReadOnly = true;
            this.ColumnInventoryReportOutQuantity.Width = 150;
            // 
            // ColumnInventoryReportEndinguantity
            // 
            this.ColumnInventoryReportEndinguantity.DataPropertyName = "ColumnInventoryReportEndinguantity";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnInventoryReportEndinguantity.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnInventoryReportEndinguantity.HeaderText = "End";
            this.ColumnInventoryReportEndinguantity.Name = "ColumnInventoryReportEndinguantity";
            this.ColumnInventoryReportEndinguantity.ReadOnly = true;
            this.ColumnInventoryReportEndinguantity.Width = 150;
            // 
            // ColumnInventoryReportCost
            // 
            this.ColumnInventoryReportCost.DataPropertyName = "ColumnInventoryReportCost";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnInventoryReportCost.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnInventoryReportCost.HeaderText = "Cost";
            this.ColumnInventoryReportCost.Name = "ColumnInventoryReportCost";
            this.ColumnInventoryReportCost.ReadOnly = true;
            this.ColumnInventoryReportCost.Width = 150;
            // 
            // ColumnInventoryReportAmount
            // 
            this.ColumnInventoryReportAmount.DataPropertyName = "ColumnInventoryReportAmount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnInventoryReportAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnInventoryReportAmount.HeaderText = "Amount";
            this.ColumnInventoryReportAmount.Name = "ColumnInventoryReportAmount";
            this.ColumnInventoryReportAmount.ReadOnly = true;
            this.ColumnInventoryReportAmount.Width = 150;
            // 
            // ColumnInventoryReportSpace
            // 
            this.ColumnInventoryReportSpace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnInventoryReportSpace.DataPropertyName = "ColumnInventoryReportSpace";
            this.ColumnInventoryReportSpace.HeaderText = "";
            this.ColumnInventoryReportSpace.Name = "ColumnInventoryReportSpace";
            this.ColumnInventoryReportSpace.ReadOnly = true;
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
            this.label1.Size = new System.Drawing.Size(218, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Inventory Report";
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
            // RepInventoryReportInventoryReportForm
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
            this.Name = "RepInventoryReportInventoryReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Report";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventoryReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonInventoryReportPageListNext;
        private System.Windows.Forms.Button buttonInventoryReportPageListPrevious;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonInventoryReportPageListFirst;
        private System.Windows.Forms.Button buttonInventoryReportPageListLast;
        private System.Windows.Forms.TextBox textBoxInventoryReportPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonGenerateCSV;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewInventoryReport;
        private System.Windows.Forms.TextBox textBoxEndDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxBranch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCompany;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInventoryReportBarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInventoryReportItemDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInventoryReportInventoryCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInventoryReportUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInventoryReportBeginningQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInventoryReportInQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInventoryReportOutQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInventoryReportEndinguantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInventoryReportCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInventoryReportAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInventoryReportSpace;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogGenerateCSV;
    }
}