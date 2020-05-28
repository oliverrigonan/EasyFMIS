namespace easyfmis.Forms.Software.MstCompany
{
    partial class MstCompanyDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MstCompanyDetailForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonLock = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonUnlock = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.buttonAddBranch = new System.Windows.Forms.Button();
            this.dataGridViewBranchFormList = new System.Windows.Forms.DataGridView();
            this.ColumnBranchListButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnBranchListButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnBranchListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBranchListBranchCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBranchListBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBranchListCompanyId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonBranchListPageListFirst = new System.Windows.Forms.Button();
            this.buttonBranchListPageListPrevious = new System.Windows.Forms.Button();
            this.buttonBranchListPageListNext = new System.Windows.Forms.Button();
            this.buttonBranchListPageListLast = new System.Windows.Forms.Button();
            this.textBoxBranchListPageNumber = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxCompanyCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCompany = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBranchFormList)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.buttonLock);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.buttonUnlock);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1091, 50);
            this.panel1.TabIndex = 5;
            // 
            // buttonLock
            // 
            this.buttonLock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonLock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonLock.FlatAppearance.BorderSize = 0;
            this.buttonLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLock.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLock.ForeColor = System.Drawing.Color.White;
            this.buttonLock.Location = new System.Drawing.Point(861, 10);
            this.buttonLock.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLock.Name = "buttonLock";
            this.buttonLock.Size = new System.Drawing.Size(70, 32);
            this.buttonLock.TabIndex = 20;
            this.buttonLock.Text = "Lock";
            this.buttonLock.UseVisualStyleBackColor = false;
            this.buttonLock.Click += new System.EventHandler(this.buttonLock_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.building;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
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
            this.label1.Size = new System.Drawing.Size(163, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Company Detail";
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
            this.buttonClose.Location = new System.Drawing.Point(1011, 10);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(70, 32);
            this.buttonClose.TabIndex = 22;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonUnlock
            // 
            this.buttonUnlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUnlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonUnlock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonUnlock.FlatAppearance.BorderSize = 0;
            this.buttonUnlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUnlock.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUnlock.ForeColor = System.Drawing.Color.White;
            this.buttonUnlock.Location = new System.Drawing.Point(936, 10);
            this.buttonUnlock.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUnlock.Name = "buttonUnlock";
            this.buttonUnlock.Size = new System.Drawing.Size(70, 32);
            this.buttonUnlock.TabIndex = 21;
            this.buttonUnlock.Text = "Unlock";
            this.buttonUnlock.UseVisualStyleBackColor = false;
            this.buttonUnlock.Click += new System.EventHandler(this.buttonUnlock_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1091, 510);
            this.panel2.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.buttonAddBranch);
            this.panel6.Controls.Add(this.dataGridViewBranchFormList);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 67);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1091, 401);
            this.panel6.TabIndex = 29;
            // 
            // buttonAddBranch
            // 
            this.buttonAddBranch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddBranch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonAddBranch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(34)))), ((int)(((byte)(116)))));
            this.buttonAddBranch.FlatAppearance.BorderSize = 0;
            this.buttonAddBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddBranch.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.buttonAddBranch.ForeColor = System.Drawing.Color.White;
            this.buttonAddBranch.Location = new System.Drawing.Point(1011, 4);
            this.buttonAddBranch.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddBranch.Name = "buttonAddBranch";
            this.buttonAddBranch.Size = new System.Drawing.Size(70, 32);
            this.buttonAddBranch.TabIndex = 8;
            this.buttonAddBranch.TabStop = false;
            this.buttonAddBranch.Text = "Add";
            this.buttonAddBranch.UseVisualStyleBackColor = false;
            this.buttonAddBranch.Click += new System.EventHandler(this.buttonAddBranch_Click);
            // 
            // dataGridViewBranchFormList
            // 
            this.dataGridViewBranchFormList.AllowUserToAddRows = false;
            this.dataGridViewBranchFormList.AllowUserToDeleteRows = false;
            this.dataGridViewBranchFormList.AllowUserToResizeRows = false;
            this.dataGridViewBranchFormList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewBranchFormList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBranchFormList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewBranchFormList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBranchFormList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnBranchListButtonEdit,
            this.ColumnBranchListButtonDelete,
            this.ColumnBranchListId,
            this.ColumnBranchListBranchCode,
            this.ColumnBranchListBranch,
            this.ColumnBranchListCompanyId});
            this.dataGridViewBranchFormList.Location = new System.Drawing.Point(10, 40);
            this.dataGridViewBranchFormList.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewBranchFormList.MultiSelect = false;
            this.dataGridViewBranchFormList.Name = "dataGridViewBranchFormList";
            this.dataGridViewBranchFormList.ReadOnly = true;
            this.dataGridViewBranchFormList.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.dataGridViewBranchFormList.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewBranchFormList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.dataGridViewBranchFormList.RowTemplate.Height = 24;
            this.dataGridViewBranchFormList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBranchFormList.Size = new System.Drawing.Size(1072, 355);
            this.dataGridViewBranchFormList.TabIndex = 1;
            this.dataGridViewBranchFormList.TabStop = false;
            this.dataGridViewBranchFormList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBranchList_CellClick);
            // 
            // ColumnBranchListButtonEdit
            // 
            this.ColumnBranchListButtonEdit.DataPropertyName = "ColumnBranchListButtonEdit";
            this.ColumnBranchListButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnBranchListButtonEdit.HeaderText = "";
            this.ColumnBranchListButtonEdit.Name = "ColumnBranchListButtonEdit";
            this.ColumnBranchListButtonEdit.ReadOnly = true;
            this.ColumnBranchListButtonEdit.Width = 70;
            // 
            // ColumnBranchListButtonDelete
            // 
            this.ColumnBranchListButtonDelete.DataPropertyName = "ColumnBranchListButtonDelete";
            this.ColumnBranchListButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnBranchListButtonDelete.HeaderText = "";
            this.ColumnBranchListButtonDelete.Name = "ColumnBranchListButtonDelete";
            this.ColumnBranchListButtonDelete.ReadOnly = true;
            this.ColumnBranchListButtonDelete.Width = 70;
            // 
            // ColumnBranchListId
            // 
            this.ColumnBranchListId.DataPropertyName = "ColumnBranchListId";
            this.ColumnBranchListId.HeaderText = "Id";
            this.ColumnBranchListId.Name = "ColumnBranchListId";
            this.ColumnBranchListId.ReadOnly = true;
            this.ColumnBranchListId.Visible = false;
            // 
            // ColumnBranchListBranchCode
            // 
            this.ColumnBranchListBranchCode.DataPropertyName = "ColumnBranchListBranchCode";
            this.ColumnBranchListBranchCode.HeaderText = "Code";
            this.ColumnBranchListBranchCode.Name = "ColumnBranchListBranchCode";
            this.ColumnBranchListBranchCode.ReadOnly = true;
            this.ColumnBranchListBranchCode.Width = 150;
            // 
            // ColumnBranchListBranch
            // 
            this.ColumnBranchListBranch.DataPropertyName = "ColumnBranchListBranch";
            this.ColumnBranchListBranch.HeaderText = "Branch";
            this.ColumnBranchListBranch.Name = "ColumnBranchListBranch";
            this.ColumnBranchListBranch.ReadOnly = true;
            this.ColumnBranchListBranch.Width = 300;
            // 
            // ColumnBranchListCompanyId
            // 
            this.ColumnBranchListCompanyId.DataPropertyName = "ColumnBranchListCompanyId";
            this.ColumnBranchListCompanyId.HeaderText = "CompanyId";
            this.ColumnBranchListCompanyId.Name = "ColumnBranchListCompanyId";
            this.ColumnBranchListCompanyId.ReadOnly = true;
            this.ColumnBranchListCompanyId.Visible = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.buttonBranchListPageListFirst);
            this.panel4.Controls.Add(this.buttonBranchListPageListPrevious);
            this.panel4.Controls.Add(this.buttonBranchListPageListNext);
            this.panel4.Controls.Add(this.buttonBranchListPageListLast);
            this.panel4.Controls.Add(this.textBoxBranchListPageNumber);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 468);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1091, 42);
            this.panel4.TabIndex = 27;
            // 
            // buttonBranchListPageListFirst
            // 
            this.buttonBranchListPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBranchListPageListFirst.Enabled = false;
            this.buttonBranchListPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonBranchListPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBranchListPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonBranchListPageListFirst.Location = new System.Drawing.Point(10, 7);
            this.buttonBranchListPageListFirst.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBranchListPageListFirst.Name = "buttonBranchListPageListFirst";
            this.buttonBranchListPageListFirst.Size = new System.Drawing.Size(66, 26);
            this.buttonBranchListPageListFirst.TabIndex = 13;
            this.buttonBranchListPageListFirst.Text = "First";
            this.buttonBranchListPageListFirst.UseVisualStyleBackColor = false;
            this.buttonBranchListPageListFirst.Click += new System.EventHandler(this.buttonBranchListPageListFirst_Click);
            // 
            // buttonBranchListPageListPrevious
            // 
            this.buttonBranchListPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBranchListPageListPrevious.Enabled = false;
            this.buttonBranchListPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonBranchListPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBranchListPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonBranchListPageListPrevious.Location = new System.Drawing.Point(80, 7);
            this.buttonBranchListPageListPrevious.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBranchListPageListPrevious.Name = "buttonBranchListPageListPrevious";
            this.buttonBranchListPageListPrevious.Size = new System.Drawing.Size(66, 26);
            this.buttonBranchListPageListPrevious.TabIndex = 14;
            this.buttonBranchListPageListPrevious.Text = "Previous";
            this.buttonBranchListPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonBranchListPageListPrevious.Click += new System.EventHandler(this.buttonBranchListPageListPrevious_Click);
            // 
            // buttonBranchListPageListNext
            // 
            this.buttonBranchListPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBranchListPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonBranchListPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBranchListPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonBranchListPageListNext.Location = new System.Drawing.Point(210, 7);
            this.buttonBranchListPageListNext.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBranchListPageListNext.Name = "buttonBranchListPageListNext";
            this.buttonBranchListPageListNext.Size = new System.Drawing.Size(66, 26);
            this.buttonBranchListPageListNext.TabIndex = 15;
            this.buttonBranchListPageListNext.Text = "Next";
            this.buttonBranchListPageListNext.UseVisualStyleBackColor = false;
            this.buttonBranchListPageListNext.Click += new System.EventHandler(this.buttonBranchListPageListNext_Click);
            // 
            // buttonBranchListPageListLast
            // 
            this.buttonBranchListPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBranchListPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonBranchListPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBranchListPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonBranchListPageListLast.Location = new System.Drawing.Point(278, 7);
            this.buttonBranchListPageListLast.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBranchListPageListLast.Name = "buttonBranchListPageListLast";
            this.buttonBranchListPageListLast.Size = new System.Drawing.Size(66, 26);
            this.buttonBranchListPageListLast.TabIndex = 16;
            this.buttonBranchListPageListLast.Text = "Last";
            this.buttonBranchListPageListLast.UseVisualStyleBackColor = false;
            this.buttonBranchListPageListLast.Click += new System.EventHandler(this.buttonBranchListPageListLast_Click);
            // 
            // textBoxBranchListPageNumber
            // 
            this.textBoxBranchListPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxBranchListPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxBranchListPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxBranchListPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxBranchListPageNumber.Location = new System.Drawing.Point(150, 11);
            this.textBoxBranchListPageNumber.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxBranchListPageNumber.Name = "textBoxBranchListPageNumber";
            this.textBoxBranchListPageNumber.ReadOnly = true;
            this.textBoxBranchListPageNumber.Size = new System.Drawing.Size(55, 16);
            this.textBoxBranchListPageNumber.TabIndex = 17;
            this.textBoxBranchListPageNumber.TabStop = false;
            this.textBoxBranchListPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.textBoxCompanyCode);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.textBoxCompany);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(8);
            this.panel3.Size = new System.Drawing.Size(1091, 67);
            this.panel3.TabIndex = 0;
            // 
            // textBoxCompanyCode
            // 
            this.textBoxCompanyCode.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCompanyCode.Location = new System.Drawing.Point(85, 5);
            this.textBoxCompanyCode.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCompanyCode.Name = "textBoxCompanyCode";
            this.textBoxCompanyCode.Size = new System.Drawing.Size(256, 26);
            this.textBoxCompanyCode.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label4.Location = new System.Drawing.Point(37, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Code:";
            // 
            // textBoxCompany
            // 
            this.textBoxCompany.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCompany.Location = new System.Drawing.Point(85, 35);
            this.textBoxCompany.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCompany.Name = "textBoxCompany";
            this.textBoxCompany.Size = new System.Drawing.Size(256, 26);
            this.textBoxCompany.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label3.Location = new System.Drawing.Point(10, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Company:";
            // 
            // MstCompanyDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1091, 560);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MstCompanyDetailForm";
            this.Text = "MstUserDetailForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBranchFormList)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonUnlock;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonLock;
        private System.Windows.Forms.TextBox textBoxCompanyCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCompany;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAddBranch;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonBranchListPageListFirst;
        private System.Windows.Forms.Button buttonBranchListPageListPrevious;
        private System.Windows.Forms.Button buttonBranchListPageListNext;
        private System.Windows.Forms.Button buttonBranchListPageListLast;
        private System.Windows.Forms.TextBox textBoxBranchListPageNumber;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dataGridViewBranchFormList;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnBranchListButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnBranchListButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBranchListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBranchListBranchCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBranchListBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBranchListCompanyId;
    }
}