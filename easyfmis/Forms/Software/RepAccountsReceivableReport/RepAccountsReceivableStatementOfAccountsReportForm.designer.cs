namespace easyfmis.Forms.Software.RepAccountsReceivableReport
{
    partial class RepAccountsReceivableStatementOfAccountsReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepAccountsReceivableStatementOfAccountsReportForm));
            this.buttonStatementOfAccountReportPageListNext = new System.Windows.Forms.Button();
            this.buttonStatementOfAccountleReportPageListPrevious = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonStatementOfAccountReportPageListFirst = new System.Windows.Forms.Button();
            this.buttonStatementOfAccountReportPageListLast = new System.Windows.Forms.Button();
            this.textBoxStatementOfAccountReportPageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCustomer = new System.Windows.Forms.TextBox();
            this.textBoxDateAsOf = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxCompany = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxBranch = new System.Windows.Forms.TextBox();
            this.dataGridViewStatementOfAccountReport = new System.Windows.Forms.DataGridView();
            this.buttonGenerateCSV = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.folderBrowserDialogGenerateCSV = new System.Windows.Forms.FolderBrowserDialog();
            this.ColumnReceivableStatementOfAccountReportListBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReceivableStatementOfAccountReportListSINumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReceivableStatementOfAccountReportListSIDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReceivableStatementOfAccountReportListManualSINumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReceivableStatementOfAccountReportListCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReceivableStatementOfAccountReportListTerm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReceivableStatementOfAccountReportListAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReceivableStatementOfAccountReportListPaidAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReceivableStatementOfAccountReportListMemoAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReceivableStatementOfAccountReportListBalanceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStatementOfAccountReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStatementOfAccountReportPageListNext
            // 
            this.buttonStatementOfAccountReportPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStatementOfAccountReportPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonStatementOfAccountReportPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStatementOfAccountReportPageListNext.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonStatementOfAccountReportPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonStatementOfAccountReportPageListNext.Name = "buttonStatementOfAccountReportPageListNext";
            this.buttonStatementOfAccountReportPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonStatementOfAccountReportPageListNext.TabIndex = 10;
            this.buttonStatementOfAccountReportPageListNext.Text = "Next";
            this.buttonStatementOfAccountReportPageListNext.UseVisualStyleBackColor = false;
            this.buttonStatementOfAccountReportPageListNext.Click += new System.EventHandler(this.buttonStatementOfAccountReportPageListNext_Click);
            // 
            // buttonStatementOfAccountleReportPageListPrevious
            // 
            this.buttonStatementOfAccountleReportPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStatementOfAccountleReportPageListPrevious.Enabled = false;
            this.buttonStatementOfAccountleReportPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonStatementOfAccountleReportPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStatementOfAccountleReportPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonStatementOfAccountleReportPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonStatementOfAccountleReportPageListPrevious.Name = "buttonStatementOfAccountleReportPageListPrevious";
            this.buttonStatementOfAccountleReportPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonStatementOfAccountleReportPageListPrevious.TabIndex = 9;
            this.buttonStatementOfAccountleReportPageListPrevious.Text = "Previous";
            this.buttonStatementOfAccountleReportPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonStatementOfAccountleReportPageListPrevious.Click += new System.EventHandler(this.buttonStatementOfAccountReportPageListPrevious_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.buttonStatementOfAccountReportPageListFirst);
            this.panel4.Controls.Add(this.buttonStatementOfAccountReportPageListNext);
            this.panel4.Controls.Add(this.buttonStatementOfAccountReportPageListLast);
            this.panel4.Controls.Add(this.buttonStatementOfAccountleReportPageListPrevious);
            this.panel4.Controls.Add(this.textBoxStatementOfAccountReportPageNumber);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 537);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1382, 53);
            this.panel4.TabIndex = 20;
            // 
            // buttonStatementOfAccountReportPageListFirst
            // 
            this.buttonStatementOfAccountReportPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStatementOfAccountReportPageListFirst.Enabled = false;
            this.buttonStatementOfAccountReportPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonStatementOfAccountReportPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStatementOfAccountReportPageListFirst.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonStatementOfAccountReportPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonStatementOfAccountReportPageListFirst.Name = "buttonStatementOfAccountReportPageListFirst";
            this.buttonStatementOfAccountReportPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonStatementOfAccountReportPageListFirst.TabIndex = 8;
            this.buttonStatementOfAccountReportPageListFirst.Text = "First";
            this.buttonStatementOfAccountReportPageListFirst.UseVisualStyleBackColor = false;
            this.buttonStatementOfAccountReportPageListFirst.Click += new System.EventHandler(this.buttonStatementOfAccountReportPageListFirst_Click);
            // 
            // buttonStatementOfAccountReportPageListLast
            // 
            this.buttonStatementOfAccountReportPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStatementOfAccountReportPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonStatementOfAccountReportPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStatementOfAccountReportPageListLast.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonStatementOfAccountReportPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonStatementOfAccountReportPageListLast.Name = "buttonStatementOfAccountReportPageListLast";
            this.buttonStatementOfAccountReportPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonStatementOfAccountReportPageListLast.TabIndex = 11;
            this.buttonStatementOfAccountReportPageListLast.Text = "Last";
            this.buttonStatementOfAccountReportPageListLast.UseVisualStyleBackColor = false;
            this.buttonStatementOfAccountReportPageListLast.Click += new System.EventHandler(this.buttonStatementOfAccountReportPageListLast_Click);
            // 
            // textBoxStatementOfAccountReportPageNumber
            // 
            this.textBoxStatementOfAccountReportPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxStatementOfAccountReportPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxStatementOfAccountReportPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxStatementOfAccountReportPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxStatementOfAccountReportPageNumber.Name = "textBoxStatementOfAccountReportPageNumber";
            this.textBoxStatementOfAccountReportPageNumber.ReadOnly = true;
            this.textBoxStatementOfAccountReportPageNumber.Size = new System.Drawing.Size(69, 23);
            this.textBoxStatementOfAccountReportPageNumber.TabIndex = 12;
            this.textBoxStatementOfAccountReportPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewStatementOfAccountReport);
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
            this.panel3.Controls.Add(this.textBoxCustomer);
            this.panel3.Controls.Add(this.textBoxDateAsOf);
            this.panel3.Controls.Add(this.label5);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label4.Location = new System.Drawing.Point(996, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 23);
            this.label4.TabIndex = 34;
            this.label4.Text = "Customer:";
            // 
            // textBoxCustomer
            // 
            this.textBoxCustomer.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCustomer.Location = new System.Drawing.Point(1090, 8);
            this.textBoxCustomer.Name = "textBoxCustomer";
            this.textBoxCustomer.ReadOnly = true;
            this.textBoxCustomer.Size = new System.Drawing.Size(255, 30);
            this.textBoxCustomer.TabIndex = 33;
            // 
            // textBoxDateAsOf
            // 
            this.textBoxDateAsOf.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxDateAsOf.Location = new System.Drawing.Point(109, 8);
            this.textBoxDateAsOf.Name = "textBoxDateAsOf";
            this.textBoxDateAsOf.ReadOnly = true;
            this.textBoxDateAsOf.Size = new System.Drawing.Size(149, 30);
            this.textBoxDateAsOf.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label5.Location = new System.Drawing.Point(264, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 23);
            this.label5.TabIndex = 28;
            this.label5.Text = "Company:";
            // 
            // textBoxCompany
            // 
            this.textBoxCompany.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCompany.Location = new System.Drawing.Point(352, 8);
            this.textBoxCompany.Name = "textBoxCompany";
            this.textBoxCompany.ReadOnly = true;
            this.textBoxCompany.Size = new System.Drawing.Size(304, 30);
            this.textBoxCompany.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label2.Location = new System.Drawing.Point(662, 11);
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
            this.label3.Size = new System.Drawing.Size(91, 23);
            this.label3.TabIndex = 32;
            this.label3.Text = "Date as of:";
            // 
            // textBoxBranch
            // 
            this.textBoxBranch.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxBranch.Location = new System.Drawing.Point(735, 8);
            this.textBoxBranch.Name = "textBoxBranch";
            this.textBoxBranch.ReadOnly = true;
            this.textBoxBranch.Size = new System.Drawing.Size(255, 30);
            this.textBoxBranch.TabIndex = 3;
            // 
            // dataGridViewStatementOfAccountReport
            // 
            this.dataGridViewStatementOfAccountReport.AllowUserToAddRows = false;
            this.dataGridViewStatementOfAccountReport.AllowUserToDeleteRows = false;
            this.dataGridViewStatementOfAccountReport.AllowUserToResizeRows = false;
            this.dataGridViewStatementOfAccountReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStatementOfAccountReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewStatementOfAccountReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStatementOfAccountReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnReceivableStatementOfAccountReportListBranch,
            this.ColumnReceivableStatementOfAccountReportListSINumber,
            this.ColumnReceivableStatementOfAccountReportListSIDate,
            this.ColumnReceivableStatementOfAccountReportListManualSINumber,
            this.ColumnReceivableStatementOfAccountReportListCustomer,
            this.ColumnReceivableStatementOfAccountReportListTerm,
            this.ColumnReceivableStatementOfAccountReportListAmount,
            this.ColumnReceivableStatementOfAccountReportListPaidAmount,
            this.ColumnReceivableStatementOfAccountReportListMemoAmount,
            this.ColumnReceivableStatementOfAccountReportListBalanceAmount});
            this.dataGridViewStatementOfAccountReport.Location = new System.Drawing.Point(12, 53);
            this.dataGridViewStatementOfAccountReport.MultiSelect = false;
            this.dataGridViewStatementOfAccountReport.Name = "dataGridViewStatementOfAccountReport";
            this.dataGridViewStatementOfAccountReport.ReadOnly = true;
            this.dataGridViewStatementOfAccountReport.RowHeadersVisible = false;
            this.dataGridViewStatementOfAccountReport.RowTemplate.Height = 24;
            this.dataGridViewStatementOfAccountReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStatementOfAccountReport.Size = new System.Drawing.Size(1357, 478);
            this.dataGridViewStatementOfAccountReport.TabIndex = 21;
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
            this.label1.Size = new System.Drawing.Size(284, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Statement of Accounts";
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
            // ColumnReceivableStatementOfAccountReportListBranch
            // 
            this.ColumnReceivableStatementOfAccountReportListBranch.DataPropertyName = "ColumnReceivableStatementOfAccountReportListBranch";
            this.ColumnReceivableStatementOfAccountReportListBranch.HeaderText = "Branch";
            this.ColumnReceivableStatementOfAccountReportListBranch.Name = "ColumnReceivableStatementOfAccountReportListBranch";
            this.ColumnReceivableStatementOfAccountReportListBranch.ReadOnly = true;
            this.ColumnReceivableStatementOfAccountReportListBranch.Width = 150;
            // 
            // ColumnReceivableStatementOfAccountReportListSINumber
            // 
            this.ColumnReceivableStatementOfAccountReportListSINumber.DataPropertyName = "ColumnReceivableStatementOfAccountReportListSINumber";
            this.ColumnReceivableStatementOfAccountReportListSINumber.HeaderText = "SI Number";
            this.ColumnReceivableStatementOfAccountReportListSINumber.Name = "ColumnReceivableStatementOfAccountReportListSINumber";
            this.ColumnReceivableStatementOfAccountReportListSINumber.ReadOnly = true;
            this.ColumnReceivableStatementOfAccountReportListSINumber.Width = 125;
            // 
            // ColumnReceivableStatementOfAccountReportListSIDate
            // 
            this.ColumnReceivableStatementOfAccountReportListSIDate.DataPropertyName = "ColumnReceivableStatementOfAccountReportListSIDate";
            this.ColumnReceivableStatementOfAccountReportListSIDate.HeaderText = "SI Date";
            this.ColumnReceivableStatementOfAccountReportListSIDate.Name = "ColumnReceivableStatementOfAccountReportListSIDate";
            this.ColumnReceivableStatementOfAccountReportListSIDate.ReadOnly = true;
            // 
            // ColumnReceivableStatementOfAccountReportListManualSINumber
            // 
            this.ColumnReceivableStatementOfAccountReportListManualSINumber.DataPropertyName = "ColumnReceivableStatementOfAccountReportListManualSINumber";
            this.ColumnReceivableStatementOfAccountReportListManualSINumber.HeaderText = "Manual SI Number";
            this.ColumnReceivableStatementOfAccountReportListManualSINumber.Name = "ColumnReceivableStatementOfAccountReportListManualSINumber";
            this.ColumnReceivableStatementOfAccountReportListManualSINumber.ReadOnly = true;
            this.ColumnReceivableStatementOfAccountReportListManualSINumber.Width = 200;
            // 
            // ColumnReceivableStatementOfAccountReportListCustomer
            // 
            this.ColumnReceivableStatementOfAccountReportListCustomer.DataPropertyName = "ColumnReceivableStatementOfAccountReportListCustomer";
            this.ColumnReceivableStatementOfAccountReportListCustomer.HeaderText = "Customer";
            this.ColumnReceivableStatementOfAccountReportListCustomer.Name = "ColumnReceivableStatementOfAccountReportListCustomer";
            this.ColumnReceivableStatementOfAccountReportListCustomer.ReadOnly = true;
            this.ColumnReceivableStatementOfAccountReportListCustomer.Width = 200;
            // 
            // ColumnReceivableStatementOfAccountReportListTerm
            // 
            this.ColumnReceivableStatementOfAccountReportListTerm.DataPropertyName = "ColumnReceivableStatementOfAccountReportListTerm";
            this.ColumnReceivableStatementOfAccountReportListTerm.HeaderText = "Term";
            this.ColumnReceivableStatementOfAccountReportListTerm.Name = "ColumnReceivableStatementOfAccountReportListTerm";
            this.ColumnReceivableStatementOfAccountReportListTerm.ReadOnly = true;
            // 
            // ColumnReceivableStatementOfAccountReportListAmount
            // 
            this.ColumnReceivableStatementOfAccountReportListAmount.DataPropertyName = "ColumnReceivableStatementOfAccountReportListAmount";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnReceivableStatementOfAccountReportListAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnReceivableStatementOfAccountReportListAmount.HeaderText = "Amount";
            this.ColumnReceivableStatementOfAccountReportListAmount.Name = "ColumnReceivableStatementOfAccountReportListAmount";
            this.ColumnReceivableStatementOfAccountReportListAmount.ReadOnly = true;
            this.ColumnReceivableStatementOfAccountReportListAmount.Width = 200;
            // 
            // ColumnReceivableStatementOfAccountReportListPaidAmount
            // 
            this.ColumnReceivableStatementOfAccountReportListPaidAmount.DataPropertyName = "ColumnReceivableStatementOfAccountReportListPaidAmount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnReceivableStatementOfAccountReportListPaidAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnReceivableStatementOfAccountReportListPaidAmount.HeaderText = "Paid Amount";
            this.ColumnReceivableStatementOfAccountReportListPaidAmount.Name = "ColumnReceivableStatementOfAccountReportListPaidAmount";
            this.ColumnReceivableStatementOfAccountReportListPaidAmount.ReadOnly = true;
            this.ColumnReceivableStatementOfAccountReportListPaidAmount.Width = 200;
            // 
            // ColumnReceivableStatementOfAccountReportListMemoAmount
            // 
            this.ColumnReceivableStatementOfAccountReportListMemoAmount.DataPropertyName = "ColumnReceivableStatementOfAccountReportListMemoAmount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnReceivableStatementOfAccountReportListMemoAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnReceivableStatementOfAccountReportListMemoAmount.HeaderText = "Memo Amount";
            this.ColumnReceivableStatementOfAccountReportListMemoAmount.Name = "ColumnReceivableStatementOfAccountReportListMemoAmount";
            this.ColumnReceivableStatementOfAccountReportListMemoAmount.ReadOnly = true;
            this.ColumnReceivableStatementOfAccountReportListMemoAmount.Width = 200;
            // 
            // ColumnReceivableStatementOfAccountReportListBalanceAmount
            // 
            this.ColumnReceivableStatementOfAccountReportListBalanceAmount.DataPropertyName = "ColumnReceivableStatementOfAccountReportListBalanceAmount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnReceivableStatementOfAccountReportListBalanceAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnReceivableStatementOfAccountReportListBalanceAmount.HeaderText = "Balance Amount";
            this.ColumnReceivableStatementOfAccountReportListBalanceAmount.Name = "ColumnReceivableStatementOfAccountReportListBalanceAmount";
            this.ColumnReceivableStatementOfAccountReportListBalanceAmount.ReadOnly = true;
            this.ColumnReceivableStatementOfAccountReportListBalanceAmount.Width = 200;
            // 
            // RepAccountsReceivableStatementOfAccountsReportForm
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
            this.Name = "RepAccountsReceivableStatementOfAccountsReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statement of Accounts";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStatementOfAccountReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStatementOfAccountReportPageListNext;
        private System.Windows.Forms.Button buttonStatementOfAccountleReportPageListPrevious;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonStatementOfAccountReportPageListFirst;
        private System.Windows.Forms.Button buttonStatementOfAccountReportPageListLast;
        private System.Windows.Forms.TextBox textBoxStatementOfAccountReportPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonGenerateCSV;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewStatementOfAccountReport;
        private System.Windows.Forms.TextBox textBoxDateAsOf;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxBranch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCompany;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogGenerateCSV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReceivableStatementOfAccountReportListBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReceivableStatementOfAccountReportListSINumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReceivableStatementOfAccountReportListSIDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReceivableStatementOfAccountReportListManualSINumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReceivableStatementOfAccountReportListCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReceivableStatementOfAccountReportListTerm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReceivableStatementOfAccountReportListAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReceivableStatementOfAccountReportListPaidAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReceivableStatementOfAccountReportListMemoAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReceivableStatementOfAccountReportListBalanceAmount;
    }
}