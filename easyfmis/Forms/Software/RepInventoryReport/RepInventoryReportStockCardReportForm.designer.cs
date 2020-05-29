namespace easyfmis.Forms.Software.RepInventoryReport
{
    partial class RepInventoryReportStockCardReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepInventoryReportStockCardReportForm));
            this.buttonStockCardReportPageListNext = new System.Windows.Forms.Button();
            this.buttonStockCardReportPageListPrevious = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonStockCardReportPageListFirst = new System.Windows.Forms.Button();
            this.buttonStockCardReportPageListLast = new System.Windows.Forms.Button();
            this.textBoxStockCardReportPageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxItemListFilter = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxItemCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxItem = new System.Windows.Forms.TextBox();
            this.textBoxStartDate = new System.Windows.Forms.TextBox();
            this.textBoxEndDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCompany = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxBranch = new System.Windows.Forms.TextBox();
            this.dataGridViewStockCardReport = new System.Windows.Forms.DataGridView();
            this.ColumnStockCardReportDocument = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockCardReportInventoryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockCardReportUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockCardReportBeginningQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockCardReportInQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockCardReportOutQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockCardReportRunninguantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockCardReportCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockCardReportAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockCardReportSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonGenerateCSV = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.folderBrowserDialogGenerateCSV = new System.Windows.Forms.FolderBrowserDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockCardReport)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStockCardReportPageListNext
            // 
            this.buttonStockCardReportPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockCardReportPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonStockCardReportPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockCardReportPageListNext.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonStockCardReportPageListNext.Location = new System.Drawing.Point(262, 9);
            this.buttonStockCardReportPageListNext.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStockCardReportPageListNext.Name = "buttonStockCardReportPageListNext";
            this.buttonStockCardReportPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonStockCardReportPageListNext.TabIndex = 10;
            this.buttonStockCardReportPageListNext.Text = "Next";
            this.buttonStockCardReportPageListNext.UseVisualStyleBackColor = false;
            this.buttonStockCardReportPageListNext.Click += new System.EventHandler(this.buttonStockCardReportPageListNext_Click);
            // 
            // buttonStockCardReportPageListPrevious
            // 
            this.buttonStockCardReportPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockCardReportPageListPrevious.Enabled = false;
            this.buttonStockCardReportPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonStockCardReportPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockCardReportPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonStockCardReportPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonStockCardReportPageListPrevious.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStockCardReportPageListPrevious.Name = "buttonStockCardReportPageListPrevious";
            this.buttonStockCardReportPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonStockCardReportPageListPrevious.TabIndex = 9;
            this.buttonStockCardReportPageListPrevious.Text = "Previous";
            this.buttonStockCardReportPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonStockCardReportPageListPrevious.Click += new System.EventHandler(this.buttonStockCardReportPageListPrevious_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.buttonStockCardReportPageListFirst);
            this.panel4.Controls.Add(this.buttonStockCardReportPageListNext);
            this.panel4.Controls.Add(this.buttonStockCardReportPageListLast);
            this.panel4.Controls.Add(this.buttonStockCardReportPageListPrevious);
            this.panel4.Controls.Add(this.textBoxStockCardReportPageNumber);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 538);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1284, 52);
            this.panel4.TabIndex = 20;
            // 
            // buttonStockCardReportPageListFirst
            // 
            this.buttonStockCardReportPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockCardReportPageListFirst.Enabled = false;
            this.buttonStockCardReportPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonStockCardReportPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockCardReportPageListFirst.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonStockCardReportPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonStockCardReportPageListFirst.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStockCardReportPageListFirst.Name = "buttonStockCardReportPageListFirst";
            this.buttonStockCardReportPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonStockCardReportPageListFirst.TabIndex = 8;
            this.buttonStockCardReportPageListFirst.Text = "First";
            this.buttonStockCardReportPageListFirst.UseVisualStyleBackColor = false;
            this.buttonStockCardReportPageListFirst.Click += new System.EventHandler(this.buttonStockCardReportPageListFirst_Click);
            // 
            // buttonStockCardReportPageListLast
            // 
            this.buttonStockCardReportPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockCardReportPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonStockCardReportPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockCardReportPageListLast.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonStockCardReportPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonStockCardReportPageListLast.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStockCardReportPageListLast.Name = "buttonStockCardReportPageListLast";
            this.buttonStockCardReportPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonStockCardReportPageListLast.TabIndex = 11;
            this.buttonStockCardReportPageListLast.Text = "Last";
            this.buttonStockCardReportPageListLast.UseVisualStyleBackColor = false;
            this.buttonStockCardReportPageListLast.Click += new System.EventHandler(this.buttonStockCardReportPageListLast_Click);
            // 
            // textBoxStockCardReportPageNumber
            // 
            this.textBoxStockCardReportPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxStockCardReportPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxStockCardReportPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxStockCardReportPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxStockCardReportPageNumber.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxStockCardReportPageNumber.Name = "textBoxStockCardReportPageNumber";
            this.textBoxStockCardReportPageNumber.ReadOnly = true;
            this.textBoxStockCardReportPageNumber.Size = new System.Drawing.Size(69, 23);
            this.textBoxStockCardReportPageNumber.TabIndex = 12;
            this.textBoxStockCardReportPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.textBoxItemListFilter);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewStockCardReport);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 62);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1284, 590);
            this.panel2.TabIndex = 17;
            // 
            // textBoxItemListFilter
            // 
            this.textBoxItemListFilter.Location = new System.Drawing.Point(15, 90);
            this.textBoxItemListFilter.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxItemListFilter.Name = "textBoxItemListFilter";
            this.textBoxItemListFilter.Size = new System.Drawing.Size(1255, 30);
            this.textBoxItemListFilter.TabIndex = 40;
            this.textBoxItemListFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxItemListFilter_KeyDown);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.textBoxItemCode);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.textBoxItem);
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
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1284, 84);
            this.panel3.TabIndex = 36;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label7.Location = new System.Drawing.Point(10, 49);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 23);
            this.label7.TabIndex = 38;
            this.label7.Text = "Item Code:";
            // 
            // textBoxItemCode
            // 
            this.textBoxItemCode.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxItemCode.Location = new System.Drawing.Point(108, 45);
            this.textBoxItemCode.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxItemCode.Name = "textBoxItemCode";
            this.textBoxItemCode.ReadOnly = true;
            this.textBoxItemCode.Size = new System.Drawing.Size(389, 30);
            this.textBoxItemCode.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label6.Location = new System.Drawing.Point(536, 49);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 23);
            this.label6.TabIndex = 36;
            this.label6.Text = "Item:";
            // 
            // textBoxItem
            // 
            this.textBoxItem.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxItem.Location = new System.Drawing.Point(591, 45);
            this.textBoxItem.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxItem.Name = "textBoxItem";
            this.textBoxItem.ReadOnly = true;
            this.textBoxItem.Size = new System.Drawing.Size(680, 30);
            this.textBoxItem.TabIndex = 4;
            // 
            // textBoxStartDate
            // 
            this.textBoxStartDate.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxStartDate.Location = new System.Drawing.Point(108, 8);
            this.textBoxStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxStartDate.Name = "textBoxStartDate";
            this.textBoxStartDate.ReadOnly = true;
            this.textBoxStartDate.Size = new System.Drawing.Size(149, 30);
            this.textBoxStartDate.TabIndex = 0;
            // 
            // textBoxEndDate
            // 
            this.textBoxEndDate.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxEndDate.Location = new System.Drawing.Point(348, 8);
            this.textBoxEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxEndDate.Name = "textBoxEndDate";
            this.textBoxEndDate.ReadOnly = true;
            this.textBoxEndDate.Size = new System.Drawing.Size(149, 30);
            this.textBoxEndDate.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label5.Location = new System.Drawing.Point(498, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 23);
            this.label5.TabIndex = 28;
            this.label5.Text = "Company:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label4.Location = new System.Drawing.Point(262, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 23);
            this.label4.TabIndex = 34;
            this.label4.Text = "End Date:";
            // 
            // textBoxCompany
            // 
            this.textBoxCompany.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCompany.Location = new System.Drawing.Point(591, 8);
            this.textBoxCompany.Margin = new System.Windows.Forms.Padding(2);
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
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
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
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 23);
            this.label3.TabIndex = 32;
            this.label3.Text = "Start Date:";
            // 
            // textBoxBranch
            // 
            this.textBoxBranch.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxBranch.Location = new System.Drawing.Point(1032, 8);
            this.textBoxBranch.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxBranch.Name = "textBoxBranch";
            this.textBoxBranch.ReadOnly = true;
            this.textBoxBranch.Size = new System.Drawing.Size(239, 30);
            this.textBoxBranch.TabIndex = 3;
            // 
            // dataGridViewStockCardReport
            // 
            this.dataGridViewStockCardReport.AllowUserToAddRows = false;
            this.dataGridViewStockCardReport.AllowUserToDeleteRows = false;
            this.dataGridViewStockCardReport.AllowUserToResizeRows = false;
            this.dataGridViewStockCardReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStockCardReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewStockCardReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStockCardReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStockCardReportDocument,
            this.ColumnStockCardReportInventoryDate,
            this.ColumnStockCardReportUnit,
            this.ColumnStockCardReportBeginningQuantity,
            this.ColumnStockCardReportInQuantity,
            this.ColumnStockCardReportOutQuantity,
            this.ColumnStockCardReportRunninguantity,
            this.ColumnStockCardReportCost,
            this.ColumnStockCardReportAmount,
            this.ColumnStockCardReportSpace});
            this.dataGridViewStockCardReport.Location = new System.Drawing.Point(12, 126);
            this.dataGridViewStockCardReport.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewStockCardReport.MultiSelect = false;
            this.dataGridViewStockCardReport.Name = "dataGridViewStockCardReport";
            this.dataGridViewStockCardReport.ReadOnly = true;
            this.dataGridViewStockCardReport.RowHeadersVisible = false;
            this.dataGridViewStockCardReport.RowTemplate.Height = 24;
            this.dataGridViewStockCardReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStockCardReport.Size = new System.Drawing.Size(1259, 405);
            this.dataGridViewStockCardReport.TabIndex = 21;
            // 
            // ColumnStockCardReportDocument
            // 
            this.ColumnStockCardReportDocument.DataPropertyName = "ColumnStockCardReportDocument";
            this.ColumnStockCardReportDocument.HeaderText = "Document";
            this.ColumnStockCardReportDocument.Name = "ColumnStockCardReportDocument";
            this.ColumnStockCardReportDocument.ReadOnly = true;
            this.ColumnStockCardReportDocument.Width = 200;
            // 
            // ColumnStockCardReportInventoryDate
            // 
            this.ColumnStockCardReportInventoryDate.DataPropertyName = "ColumnStockCardReportInventoryDate";
            this.ColumnStockCardReportInventoryDate.HeaderText = "Inventory Date";
            this.ColumnStockCardReportInventoryDate.Name = "ColumnStockCardReportInventoryDate";
            this.ColumnStockCardReportInventoryDate.ReadOnly = true;
            this.ColumnStockCardReportInventoryDate.Width = 150;
            // 
            // ColumnStockCardReportUnit
            // 
            this.ColumnStockCardReportUnit.DataPropertyName = "ColumnStockCardReportUnit";
            this.ColumnStockCardReportUnit.HeaderText = "Unit";
            this.ColumnStockCardReportUnit.Name = "ColumnStockCardReportUnit";
            this.ColumnStockCardReportUnit.ReadOnly = true;
            // 
            // ColumnStockCardReportBeginningQuantity
            // 
            this.ColumnStockCardReportBeginningQuantity.DataPropertyName = "ColumnStockCardReportBeginningQuantity";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnStockCardReportBeginningQuantity.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnStockCardReportBeginningQuantity.HeaderText = "Beg";
            this.ColumnStockCardReportBeginningQuantity.Name = "ColumnStockCardReportBeginningQuantity";
            this.ColumnStockCardReportBeginningQuantity.ReadOnly = true;
            this.ColumnStockCardReportBeginningQuantity.Width = 150;
            // 
            // ColumnStockCardReportInQuantity
            // 
            this.ColumnStockCardReportInQuantity.DataPropertyName = "ColumnStockCardReportInQuantity";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnStockCardReportInQuantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnStockCardReportInQuantity.HeaderText = "In";
            this.ColumnStockCardReportInQuantity.Name = "ColumnStockCardReportInQuantity";
            this.ColumnStockCardReportInQuantity.ReadOnly = true;
            this.ColumnStockCardReportInQuantity.Width = 150;
            // 
            // ColumnStockCardReportOutQuantity
            // 
            this.ColumnStockCardReportOutQuantity.DataPropertyName = "ColumnStockCardReportOutQuantity";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnStockCardReportOutQuantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnStockCardReportOutQuantity.HeaderText = "Out";
            this.ColumnStockCardReportOutQuantity.Name = "ColumnStockCardReportOutQuantity";
            this.ColumnStockCardReportOutQuantity.ReadOnly = true;
            this.ColumnStockCardReportOutQuantity.Width = 150;
            // 
            // ColumnStockCardReportRunninguantity
            // 
            this.ColumnStockCardReportRunninguantity.DataPropertyName = "ColumnStockCardReportRunninguantity";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnStockCardReportRunninguantity.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnStockCardReportRunninguantity.HeaderText = "Balance";
            this.ColumnStockCardReportRunninguantity.Name = "ColumnStockCardReportRunninguantity";
            this.ColumnStockCardReportRunninguantity.ReadOnly = true;
            this.ColumnStockCardReportRunninguantity.Width = 150;
            // 
            // ColumnStockCardReportCost
            // 
            this.ColumnStockCardReportCost.DataPropertyName = "ColumnStockCardReportCost";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnStockCardReportCost.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnStockCardReportCost.HeaderText = "Cost";
            this.ColumnStockCardReportCost.Name = "ColumnStockCardReportCost";
            this.ColumnStockCardReportCost.ReadOnly = true;
            this.ColumnStockCardReportCost.Width = 150;
            // 
            // ColumnStockCardReportAmount
            // 
            this.ColumnStockCardReportAmount.DataPropertyName = "ColumnStockCardReportAmount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnStockCardReportAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnStockCardReportAmount.HeaderText = "Amount";
            this.ColumnStockCardReportAmount.Name = "ColumnStockCardReportAmount";
            this.ColumnStockCardReportAmount.ReadOnly = true;
            this.ColumnStockCardReportAmount.Width = 150;
            // 
            // ColumnStockCardReportSpace
            // 
            this.ColumnStockCardReportSpace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnStockCardReportSpace.DataPropertyName = "ColumnStockCardReportSpace";
            this.ColumnStockCardReportSpace.HeaderText = "";
            this.ColumnStockCardReportSpace.Name = "ColumnStockCardReportSpace";
            this.ColumnStockCardReportSpace.ReadOnly = true;
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
            this.buttonGenerateCSV.Location = new System.Drawing.Point(1089, 11);
            this.buttonGenerateCSV.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.buttonGenerateCSV.Name = "buttonGenerateCSV";
            this.buttonGenerateCSV.Size = new System.Drawing.Size(88, 40);
            this.buttonGenerateCSV.TabIndex = 20;
            this.buttonGenerateCSV.TabStop = false;
            this.buttonGenerateCSV.Text = "CSV";
            this.buttonGenerateCSV.UseVisualStyleBackColor = false;
            this.buttonGenerateCSV.Click += new System.EventHandler(this.buttonGenerateCSV_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(71, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stock Card Report";
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
            this.buttonClose.Location = new System.Drawing.Point(1182, 11);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
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
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1284, 62);
            this.panel1.TabIndex = 16;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.Reports;
            this.pictureBox1.Location = new System.Drawing.Point(14, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // RepInventoryReportStockCardReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1284, 652);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "RepInventoryReportStockCardReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Card Report";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockCardReport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStockCardReportPageListNext;
        private System.Windows.Forms.Button buttonStockCardReportPageListPrevious;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonStockCardReportPageListFirst;
        private System.Windows.Forms.Button buttonStockCardReportPageListLast;
        private System.Windows.Forms.TextBox textBoxStockCardReportPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonGenerateCSV;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewStockCardReport;
        private System.Windows.Forms.TextBox textBoxEndDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxBranch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCompany;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogGenerateCSV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockCardReportDocument;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockCardReportInventoryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockCardReportUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockCardReportBeginningQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockCardReportInQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockCardReportOutQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockCardReportRunninguantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockCardReportCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockCardReportAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockCardReportSpace;
        private System.Windows.Forms.TextBox textBoxItemListFilter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxItemCode;
    }
}