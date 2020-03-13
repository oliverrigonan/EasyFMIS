namespace easyfmis.Forms.Software.TrnStockIn
{
    partial class TrnStockInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnStockInForm));
            this.textBoxStockInFilter = new System.Windows.Forms.TextBox();
            this.buttonStockInPageListFirst = new System.Windows.Forms.Button();
            this.buttonStockInPageListPrevious = new System.Windows.Forms.Button();
            this.buttonStockInPageListNext = new System.Windows.Forms.Button();
            this.dataGridViewStockIn = new System.Windows.Forms.DataGridView();
            this.buttonStockInPageListLast = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxStockInPageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePickerStockInFilterEndDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStockInFilterStartDate = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ColumnStockInButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnStockInButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnStockInId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockInINDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockInINNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockInRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockInIsReturned = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnStockInIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnStockInSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockIn)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxStockInFilter
            // 
            this.textBoxStockInFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStockInFilter.Location = new System.Drawing.Point(306, 6);
            this.textBoxStockInFilter.Name = "textBoxStockInFilter";
            this.textBoxStockInFilter.Size = new System.Drawing.Size(1082, 30);
            this.textBoxStockInFilter.TabIndex = 1;
            this.textBoxStockInFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxStockInFilter_KeyDown);
            // 
            // buttonStockInPageListFirst
            // 
            this.buttonStockInPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockInPageListFirst.Enabled = false;
            this.buttonStockInPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonStockInPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockInPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonStockInPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonStockInPageListFirst.Name = "buttonStockInPageListFirst";
            this.buttonStockInPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonStockInPageListFirst.TabIndex = 13;
            this.buttonStockInPageListFirst.Text = "First";
            this.buttonStockInPageListFirst.UseVisualStyleBackColor = false;
            this.buttonStockInPageListFirst.Click += new System.EventHandler(this.buttonStockInPageListFirst_Click);
            // 
            // buttonStockInPageListPrevious
            // 
            this.buttonStockInPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockInPageListPrevious.Enabled = false;
            this.buttonStockInPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonStockInPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockInPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonStockInPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonStockInPageListPrevious.Name = "buttonStockInPageListPrevious";
            this.buttonStockInPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonStockInPageListPrevious.TabIndex = 14;
            this.buttonStockInPageListPrevious.Text = "Previous";
            this.buttonStockInPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonStockInPageListPrevious.Click += new System.EventHandler(this.buttonStockInPageListPrevious_Click);
            // 
            // buttonStockInPageListNext
            // 
            this.buttonStockInPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockInPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonStockInPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockInPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonStockInPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonStockInPageListNext.Name = "buttonStockInPageListNext";
            this.buttonStockInPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonStockInPageListNext.TabIndex = 15;
            this.buttonStockInPageListNext.Text = "Next";
            this.buttonStockInPageListNext.UseVisualStyleBackColor = false;
            this.buttonStockInPageListNext.Click += new System.EventHandler(this.buttonStockInPageListNext_Click);
            // 
            // dataGridViewStockIn
            // 
            this.dataGridViewStockIn.AllowUserToAddRows = false;
            this.dataGridViewStockIn.AllowUserToDeleteRows = false;
            this.dataGridViewStockIn.AllowUserToResizeRows = false;
            this.dataGridViewStockIn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStockIn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewStockIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStockIn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStockInButtonEdit,
            this.ColumnStockInButtonDelete,
            this.ColumnStockInId,
            this.ColumnStockInINDate,
            this.ColumnStockInINNumber,
            this.ColumnStockInRemarks,
            this.ColumnStockInIsReturned,
            this.ColumnStockInIsLocked,
            this.ColumnStockInSpace});
            this.dataGridViewStockIn.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewStockIn.MultiSelect = false;
            this.dataGridViewStockIn.Name = "dataGridViewStockIn";
            this.dataGridViewStockIn.ReadOnly = true;
            this.dataGridViewStockIn.RowHeadersVisible = false;
            this.dataGridViewStockIn.RowTemplate.Height = 24;
            this.dataGridViewStockIn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStockIn.Size = new System.Drawing.Size(1376, 536);
            this.dataGridViewStockIn.TabIndex = 20;
            this.dataGridViewStockIn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStockIn_CellClick);
            // 
            // buttonStockInPageListLast
            // 
            this.buttonStockInPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockInPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonStockInPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockInPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonStockInPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonStockInPageListLast.Name = "buttonStockInPageListLast";
            this.buttonStockInPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonStockInPageListLast.TabIndex = 16;
            this.buttonStockInPageListLast.Text = "Last";
            this.buttonStockInPageListLast.UseVisualStyleBackColor = false;
            this.buttonStockInPageListLast.Click += new System.EventHandler(this.buttonStockInPageListLast_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonStockInPageListFirst);
            this.panel3.Controls.Add(this.buttonStockInPageListPrevious);
            this.panel3.Controls.Add(this.buttonStockInPageListNext);
            this.panel3.Controls.Add(this.buttonStockInPageListLast);
            this.panel3.Controls.Add(this.textBoxStockInPageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 584);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1400, 53);
            this.panel3.TabIndex = 21;
            // 
            // textBoxStockInPageNumber
            // 
            this.textBoxStockInPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxStockInPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxStockInPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxStockInPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxStockInPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxStockInPageNumber.Name = "textBoxStockInPageNumber";
            this.textBoxStockInPageNumber.ReadOnly = true;
            this.textBoxStockInPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxStockInPageNumber.TabIndex = 17;
            this.textBoxStockInPageNumber.TabStop = false;
            this.textBoxStockInPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateTimePickerStockInFilterEndDate);
            this.panel2.Controls.Add(this.dateTimePickerStockInFilterStartDate);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewStockIn);
            this.panel2.Controls.Add(this.textBoxStockInFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1400, 637);
            this.panel2.TabIndex = 7;
            // 
            // dateTimePickerStockInFilterEndDate
            // 
            this.dateTimePickerStockInFilterEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStockInFilterEndDate.Location = new System.Drawing.Point(159, 6);
            this.dateTimePickerStockInFilterEndDate.Name = "dateTimePickerStockInFilterEndDate";
            this.dateTimePickerStockInFilterEndDate.Size = new System.Drawing.Size(141, 30);
            this.dateTimePickerStockInFilterEndDate.TabIndex = 22;
            this.dateTimePickerStockInFilterEndDate.ValueChanged += new System.EventHandler(this.dateTimePickerStockInFilterEndDate_ValueChanged);
            // 
            // dateTimePickerStockInFilterStartDate
            // 
            this.dateTimePickerStockInFilterStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStockInFilterStartDate.Location = new System.Drawing.Point(12, 6);
            this.dateTimePickerStockInFilterStartDate.Name = "dateTimePickerStockInFilterStartDate";
            this.dateTimePickerStockInFilterStartDate.Size = new System.Drawing.Size(141, 30);
            this.dateTimePickerStockInFilterStartDate.TabIndex = 0;
            this.dateTimePickerStockInFilterStartDate.ValueChanged += new System.EventHandler(this.dateTimePickerStockInFilterStartDate_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.Stock_In;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
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
            this.label1.Location = new System.Drawing.Point(63, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stock-In List";
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
            this.buttonClose.Location = new System.Drawing.Point(1300, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(88, 40);
            this.buttonClose.TabIndex = 21;
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
            this.buttonAdd.Location = new System.Drawing.Point(1206, 12);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(88, 40);
            this.buttonAdd.TabIndex = 20;
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
            this.panel1.Size = new System.Drawing.Size(1400, 63);
            this.panel1.TabIndex = 6;
            // 
            // ColumnStockInButtonEdit
            // 
            this.ColumnStockInButtonEdit.DataPropertyName = "ColumnStockInButtonEdit";
            this.ColumnStockInButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnStockInButtonEdit.HeaderText = "";
            this.ColumnStockInButtonEdit.Name = "ColumnStockInButtonEdit";
            this.ColumnStockInButtonEdit.ReadOnly = true;
            this.ColumnStockInButtonEdit.Width = 70;
            // 
            // ColumnStockInButtonDelete
            // 
            this.ColumnStockInButtonDelete.DataPropertyName = "ColumnStockInButtonDelete";
            this.ColumnStockInButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnStockInButtonDelete.HeaderText = "";
            this.ColumnStockInButtonDelete.Name = "ColumnStockInButtonDelete";
            this.ColumnStockInButtonDelete.ReadOnly = true;
            this.ColumnStockInButtonDelete.Width = 70;
            // 
            // ColumnStockInId
            // 
            this.ColumnStockInId.DataPropertyName = "ColumnStockInId";
            this.ColumnStockInId.HeaderText = "Id";
            this.ColumnStockInId.Name = "ColumnStockInId";
            this.ColumnStockInId.ReadOnly = true;
            this.ColumnStockInId.Visible = false;
            // 
            // ColumnStockInINDate
            // 
            this.ColumnStockInINDate.DataPropertyName = "ColumnStockInINDate";
            this.ColumnStockInINDate.HeaderText = "IN Date";
            this.ColumnStockInINDate.Name = "ColumnStockInINDate";
            this.ColumnStockInINDate.ReadOnly = true;
            // 
            // ColumnStockInINNumber
            // 
            this.ColumnStockInINNumber.DataPropertyName = "ColumnStockInINNumber";
            this.ColumnStockInINNumber.HeaderText = "IN Number";
            this.ColumnStockInINNumber.Name = "ColumnStockInINNumber";
            this.ColumnStockInINNumber.ReadOnly = true;
            this.ColumnStockInINNumber.Width = 125;
            // 
            // ColumnStockInRemarks
            // 
            this.ColumnStockInRemarks.DataPropertyName = "ColumnStockInRemarks";
            this.ColumnStockInRemarks.HeaderText = "Remarks";
            this.ColumnStockInRemarks.Name = "ColumnStockInRemarks";
            this.ColumnStockInRemarks.ReadOnly = true;
            this.ColumnStockInRemarks.Width = 350;
            // 
            // ColumnStockInIsReturned
            // 
            this.ColumnStockInIsReturned.DataPropertyName = "ColumnStockInIsReturned";
            this.ColumnStockInIsReturned.HeaderText = "R";
            this.ColumnStockInIsReturned.Name = "ColumnStockInIsReturned";
            this.ColumnStockInIsReturned.ReadOnly = true;
            this.ColumnStockInIsReturned.Width = 35;
            // 
            // ColumnStockInIsLocked
            // 
            this.ColumnStockInIsLocked.DataPropertyName = "ColumnStockInIsLocked";
            this.ColumnStockInIsLocked.HeaderText = "L";
            this.ColumnStockInIsLocked.Name = "ColumnStockInIsLocked";
            this.ColumnStockInIsLocked.ReadOnly = true;
            this.ColumnStockInIsLocked.Width = 35;
            // 
            // ColumnStockInSpace
            // 
            this.ColumnStockInSpace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnStockInSpace.DataPropertyName = "ColumnStockInSpace";
            this.ColumnStockInSpace.HeaderText = "";
            this.ColumnStockInSpace.Name = "ColumnStockInSpace";
            this.ColumnStockInSpace.ReadOnly = true;
            // 
            // TrnStockInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1400, 700);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TrnStockInForm";
            this.Text = "Stock In List";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockIn)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxStockInFilter;
        private System.Windows.Forms.Button buttonStockInPageListFirst;
        private System.Windows.Forms.Button buttonStockInPageListPrevious;
        private System.Windows.Forms.Button buttonStockInPageListNext;
        private System.Windows.Forms.DataGridView dataGridViewStockIn;
        private System.Windows.Forms.Button buttonStockInPageListLast;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxStockInPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePickerStockInFilterStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStockInFilterEndDate;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnStockInButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnStockInButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockInId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockInINDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockInINNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockInRemarks;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnStockInIsReturned;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnStockInIsLocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockInSpace;
    }
}