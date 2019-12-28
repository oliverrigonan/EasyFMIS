namespace easyfmis.Forms.Software.SysSystemTables
{
    partial class SysSystemTablesForm
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
            this.textBoxBankListFilter = new System.Windows.Forms.TextBox();
            this.buttonBankListPageListFirst = new System.Windows.Forms.Button();
            this.buttonBankListPageListPrevious = new System.Windows.Forms.Button();
            this.buttonBankListPageListNext = new System.Windows.Forms.Button();
            this.dataGridViewBankList = new System.Windows.Forms.DataGridView();
            this.ColumnBankListButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnBankListButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnBankListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBankListBankCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBankListBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBankListContactNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBankListAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBankListIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnBankListSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonBankListPageListLast = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxBankListPageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBankList)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxBankListFilter
            // 
            this.textBoxBankListFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBankListFilter.Location = new System.Drawing.Point(12, 6);
            this.textBoxBankListFilter.Name = "textBoxBankListFilter";
            this.textBoxBankListFilter.Size = new System.Drawing.Size(1344, 30);
            this.textBoxBankListFilter.TabIndex = 19;
            this.textBoxBankListFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxBankListFilter_KeyDown);
            // 
            // buttonBankListPageListFirst
            // 
            this.buttonBankListPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBankListPageListFirst.Enabled = false;
            this.buttonBankListPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonBankListPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBankListPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonBankListPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonBankListPageListFirst.Name = "buttonBankListPageListFirst";
            this.buttonBankListPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonBankListPageListFirst.TabIndex = 13;
            this.buttonBankListPageListFirst.Text = "First";
            this.buttonBankListPageListFirst.UseVisualStyleBackColor = false;
            this.buttonBankListPageListFirst.Click += new System.EventHandler(this.buttonBankListPageListFirst_Click);
            // 
            // buttonBankListPageListPrevious
            // 
            this.buttonBankListPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBankListPageListPrevious.Enabled = false;
            this.buttonBankListPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonBankListPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBankListPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonBankListPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonBankListPageListPrevious.Name = "buttonBankListPageListPrevious";
            this.buttonBankListPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonBankListPageListPrevious.TabIndex = 14;
            this.buttonBankListPageListPrevious.Text = "Previous";
            this.buttonBankListPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonBankListPageListPrevious.Click += new System.EventHandler(this.buttonBankListPageListPrevious_Click);
            // 
            // buttonBankListPageListNext
            // 
            this.buttonBankListPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBankListPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonBankListPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBankListPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonBankListPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonBankListPageListNext.Name = "buttonBankListPageListNext";
            this.buttonBankListPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonBankListPageListNext.TabIndex = 15;
            this.buttonBankListPageListNext.Text = "Next";
            this.buttonBankListPageListNext.UseVisualStyleBackColor = false;
            this.buttonBankListPageListNext.Click += new System.EventHandler(this.buttonBankListPageListNext_Click);
            // 
            // dataGridViewBankList
            // 
            this.dataGridViewBankList.AllowUserToAddRows = false;
            this.dataGridViewBankList.AllowUserToDeleteRows = false;
            this.dataGridViewBankList.AllowUserToResizeRows = false;
            this.dataGridViewBankList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewBankList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewBankList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBankList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnBankListButtonEdit,
            this.ColumnBankListButtonDelete,
            this.ColumnBankListId,
            this.ColumnBankListBankCode,
            this.ColumnBankListBank,
            this.ColumnBankListContactNumber,
            this.ColumnBankListAddress,
            this.ColumnBankListIsLocked,
            this.ColumnBankListSpace});
            this.dataGridViewBankList.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewBankList.MultiSelect = false;
            this.dataGridViewBankList.Name = "dataGridViewBankList";
            this.dataGridViewBankList.ReadOnly = true;
            this.dataGridViewBankList.RowHeadersVisible = false;
            this.dataGridViewBankList.RowTemplate.Height = 24;
            this.dataGridViewBankList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBankList.Size = new System.Drawing.Size(1344, 476);
            this.dataGridViewBankList.TabIndex = 20;
            this.dataGridViewBankList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBankList_CellClick);
            // 
            // ColumnBankListButtonEdit
            // 
            this.ColumnBankListButtonEdit.DataPropertyName = "ColumnBankListButtonEdit";
            this.ColumnBankListButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnBankListButtonEdit.HeaderText = "";
            this.ColumnBankListButtonEdit.Name = "ColumnBankListButtonEdit";
            this.ColumnBankListButtonEdit.ReadOnly = true;
            this.ColumnBankListButtonEdit.Width = 70;
            // 
            // ColumnBankListButtonDelete
            // 
            this.ColumnBankListButtonDelete.DataPropertyName = "ColumnBankListButtonDelete";
            this.ColumnBankListButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnBankListButtonDelete.HeaderText = "";
            this.ColumnBankListButtonDelete.Name = "ColumnBankListButtonDelete";
            this.ColumnBankListButtonDelete.ReadOnly = true;
            this.ColumnBankListButtonDelete.Width = 70;
            // 
            // ColumnBankListId
            // 
            this.ColumnBankListId.DataPropertyName = "ColumnBankListId";
            this.ColumnBankListId.HeaderText = "Id";
            this.ColumnBankListId.Name = "ColumnBankListId";
            this.ColumnBankListId.ReadOnly = true;
            this.ColumnBankListId.Visible = false;
            // 
            // ColumnBankListBankCode
            // 
            this.ColumnBankListBankCode.DataPropertyName = "ColumnBankListBankCode";
            this.ColumnBankListBankCode.HeaderText = "Code";
            this.ColumnBankListBankCode.Name = "ColumnBankListBankCode";
            this.ColumnBankListBankCode.ReadOnly = true;
            this.ColumnBankListBankCode.Width = 150;
            // 
            // ColumnBankListBank
            // 
            this.ColumnBankListBank.DataPropertyName = "ColumnBankListBank";
            this.ColumnBankListBank.HeaderText = "Bank";
            this.ColumnBankListBank.Name = "ColumnBankListBank";
            this.ColumnBankListBank.ReadOnly = true;
            this.ColumnBankListBank.Width = 250;
            // 
            // ColumnBankListContactNumber
            // 
            this.ColumnBankListContactNumber.DataPropertyName = "ColumnBankListContactNumber";
            this.ColumnBankListContactNumber.HeaderText = "Contact No.";
            this.ColumnBankListContactNumber.Name = "ColumnBankListContactNumber";
            this.ColumnBankListContactNumber.ReadOnly = true;
            this.ColumnBankListContactNumber.Width = 200;
            // 
            // ColumnBankListAddress
            // 
            this.ColumnBankListAddress.DataPropertyName = "ColumnBankListAddress";
            this.ColumnBankListAddress.HeaderText = "Address";
            this.ColumnBankListAddress.Name = "ColumnBankListAddress";
            this.ColumnBankListAddress.ReadOnly = true;
            this.ColumnBankListAddress.Width = 250;
            // 
            // ColumnBankListIsLocked
            // 
            this.ColumnBankListIsLocked.DataPropertyName = "ColumnBankListIsLocked";
            this.ColumnBankListIsLocked.HeaderText = "L";
            this.ColumnBankListIsLocked.Name = "ColumnBankListIsLocked";
            this.ColumnBankListIsLocked.ReadOnly = true;
            this.ColumnBankListIsLocked.Width = 35;
            // 
            // ColumnBankListSpace
            // 
            this.ColumnBankListSpace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnBankListSpace.DataPropertyName = "ColumnBankListSpace";
            this.ColumnBankListSpace.HeaderText = "";
            this.ColumnBankListSpace.Name = "ColumnBankListSpace";
            this.ColumnBankListSpace.ReadOnly = true;
            // 
            // buttonBankListPageListLast
            // 
            this.buttonBankListPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBankListPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonBankListPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBankListPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonBankListPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonBankListPageListLast.Name = "buttonBankListPageListLast";
            this.buttonBankListPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonBankListPageListLast.TabIndex = 16;
            this.buttonBankListPageListLast.Text = "Last";
            this.buttonBankListPageListLast.UseVisualStyleBackColor = false;
            this.buttonBankListPageListLast.Click += new System.EventHandler(this.buttonBankListPageListLast_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonBankListPageListFirst);
            this.panel3.Controls.Add(this.buttonBankListPageListPrevious);
            this.panel3.Controls.Add(this.buttonBankListPageListNext);
            this.panel3.Controls.Add(this.buttonBankListPageListLast);
            this.panel3.Controls.Add(this.textBoxBankListPageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 524);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1368, 53);
            this.panel3.TabIndex = 21;
            // 
            // textBoxBankListPageNumber
            // 
            this.textBoxBankListPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxBankListPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxBankListPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxBankListPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxBankListPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxBankListPageNumber.Name = "textBoxBankListPageNumber";
            this.textBoxBankListPageNumber.ReadOnly = true;
            this.textBoxBankListPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxBankListPageNumber.TabIndex = 17;
            this.textBoxBankListPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewBankList);
            this.panel2.Controls.Add(this.textBoxBankListFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1368, 577);
            this.panel2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(63, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "System Tables";
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
            this.buttonClose.Location = new System.Drawing.Point(1282, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(88, 40);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(1188, 12);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(88, 40);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.buttonAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1382, 63);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.System_Tables;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 63);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1382, 619);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1374, 583);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bank";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1374, 583);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // SysSystemTablesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1382, 682);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SysSystemTablesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBankList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxBankListFilter;
        private System.Windows.Forms.Button buttonBankListPageListFirst;
        private System.Windows.Forms.Button buttonBankListPageListPrevious;
        private System.Windows.Forms.Button buttonBankListPageListNext;
        private System.Windows.Forms.DataGridView dataGridViewBankList;
        private System.Windows.Forms.Button buttonBankListPageListLast;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxBankListPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnBankListButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnBankListButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBankListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBankListBankCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBankListBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBankListContactNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBankListAddress;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnBankListIsLocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBankListSpace;
    }
}