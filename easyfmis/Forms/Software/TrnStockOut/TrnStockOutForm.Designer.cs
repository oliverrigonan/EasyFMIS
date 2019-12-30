namespace easyfmis.Forms.Software.TrnStockOut
{
    partial class TrnStockOutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnStockOutForm));
            this.textBoxStockOutFilter = new System.Windows.Forms.TextBox();
            this.buttonStockOutPageListFirst = new System.Windows.Forms.Button();
            this.buttonStockOutPageListPrevious = new System.Windows.Forms.Button();
            this.buttonStockOutPageListNext = new System.Windows.Forms.Button();
            this.dataGridViewStockOut = new System.Windows.Forms.DataGridView();
            this.ColumnStockOutButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnStockOutButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnStockOutId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutOTDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutOTNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnStockOutSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonStockOutPageListLast = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxStockOutPageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePickerStockOutFilterStartDate = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePickerStockOutFilterEndDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockOut)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxStockOutFilter
            // 
            this.textBoxStockOutFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStockOutFilter.Location = new System.Drawing.Point(306, 6);
            this.textBoxStockOutFilter.Name = "textBoxStockOutFilter";
            this.textBoxStockOutFilter.Size = new System.Drawing.Size(1082, 30);
            this.textBoxStockOutFilter.TabIndex = 1;
            this.textBoxStockOutFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxStockOutFilter_KeyDown);
            // 
            // buttonStockOutPageListFirst
            // 
            this.buttonStockOutPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockOutPageListFirst.Enabled = false;
            this.buttonStockOutPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonStockOutPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockOutPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonStockOutPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonStockOutPageListFirst.Name = "buttonStockOutPageListFirst";
            this.buttonStockOutPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonStockOutPageListFirst.TabIndex = 13;
            this.buttonStockOutPageListFirst.Text = "First";
            this.buttonStockOutPageListFirst.UseVisualStyleBackColor = false;
            this.buttonStockOutPageListFirst.Click += new System.EventHandler(this.buttonStockOutPageListFirst_Click);
            // 
            // buttonStockOutPageListPrevious
            // 
            this.buttonStockOutPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockOutPageListPrevious.Enabled = false;
            this.buttonStockOutPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonStockOutPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockOutPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonStockOutPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonStockOutPageListPrevious.Name = "buttonStockOutPageListPrevious";
            this.buttonStockOutPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonStockOutPageListPrevious.TabIndex = 14;
            this.buttonStockOutPageListPrevious.Text = "Previous";
            this.buttonStockOutPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonStockOutPageListPrevious.Click += new System.EventHandler(this.buttonStockOutPageListPrevious_Click);
            // 
            // buttonStockOutPageListNext
            // 
            this.buttonStockOutPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockOutPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonStockOutPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockOutPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonStockOutPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonStockOutPageListNext.Name = "buttonStockOutPageListNext";
            this.buttonStockOutPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonStockOutPageListNext.TabIndex = 15;
            this.buttonStockOutPageListNext.Text = "Next";
            this.buttonStockOutPageListNext.UseVisualStyleBackColor = false;
            this.buttonStockOutPageListNext.Click += new System.EventHandler(this.buttonStockOutPageListNext_Click);
            // 
            // dataGridViewStockOut
            // 
            this.dataGridViewStockOut.AllowUserToAddRows = false;
            this.dataGridViewStockOut.AllowUserToDeleteRows = false;
            this.dataGridViewStockOut.AllowUserToResizeRows = false;
            this.dataGridViewStockOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStockOut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewStockOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStockOut.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStockOutButtonEdit,
            this.ColumnStockOutButtonDelete,
            this.ColumnStockOutId,
            this.ColumnStockOutOTDate,
            this.ColumnStockOutOTNumber,
            this.ColumnStockOutRemarks,
            this.ColumnStockOutIsLocked,
            this.ColumnStockOutSpace});
            this.dataGridViewStockOut.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewStockOut.MultiSelect = false;
            this.dataGridViewStockOut.Name = "dataGridViewStockOut";
            this.dataGridViewStockOut.ReadOnly = true;
            this.dataGridViewStockOut.RowHeadersVisible = false;
            this.dataGridViewStockOut.RowTemplate.Height = 24;
            this.dataGridViewStockOut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStockOut.Size = new System.Drawing.Size(1376, 536);
            this.dataGridViewStockOut.TabIndex = 20;
            this.dataGridViewStockOut.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStockOut_CellClick);
            // 
            // ColumnStockOutButtonEdit
            // 
            this.ColumnStockOutButtonEdit.DataPropertyName = "ColumnStockOutButtonEdit";
            this.ColumnStockOutButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnStockOutButtonEdit.HeaderText = "";
            this.ColumnStockOutButtonEdit.Name = "ColumnStockOutButtonEdit";
            this.ColumnStockOutButtonEdit.ReadOnly = true;
            this.ColumnStockOutButtonEdit.Width = 70;
            // 
            // ColumnStockOutButtonDelete
            // 
            this.ColumnStockOutButtonDelete.DataPropertyName = "ColumnStockOutButtonDelete";
            this.ColumnStockOutButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnStockOutButtonDelete.HeaderText = "";
            this.ColumnStockOutButtonDelete.Name = "ColumnStockOutButtonDelete";
            this.ColumnStockOutButtonDelete.ReadOnly = true;
            this.ColumnStockOutButtonDelete.Width = 70;
            // 
            // ColumnStockOutId
            // 
            this.ColumnStockOutId.DataPropertyName = "ColumnStockOutId";
            this.ColumnStockOutId.HeaderText = "Id";
            this.ColumnStockOutId.Name = "ColumnStockOutId";
            this.ColumnStockOutId.ReadOnly = true;
            this.ColumnStockOutId.Visible = false;
            // 
            // ColumnStockOutOTDate
            // 
            this.ColumnStockOutOTDate.DataPropertyName = "ColumnStockOutOTDate";
            this.ColumnStockOutOTDate.HeaderText = "OT Date";
            this.ColumnStockOutOTDate.Name = "ColumnStockOutOTDate";
            this.ColumnStockOutOTDate.ReadOnly = true;
            // 
            // ColumnStockOutOTNumber
            // 
            this.ColumnStockOutOTNumber.DataPropertyName = "ColumnStockOutOTNumber";
            this.ColumnStockOutOTNumber.HeaderText = "OT Number";
            this.ColumnStockOutOTNumber.Name = "ColumnStockOutOTNumber";
            this.ColumnStockOutOTNumber.ReadOnly = true;
            this.ColumnStockOutOTNumber.Width = 125;
            // 
            // ColumnStockOutRemarks
            // 
            this.ColumnStockOutRemarks.DataPropertyName = "ColumnStockOutRemarks";
            this.ColumnStockOutRemarks.HeaderText = "Remarks";
            this.ColumnStockOutRemarks.Name = "ColumnStockOutRemarks";
            this.ColumnStockOutRemarks.ReadOnly = true;
            this.ColumnStockOutRemarks.Width = 350;
            // 
            // ColumnStockOutIsLocked
            // 
            this.ColumnStockOutIsLocked.DataPropertyName = "ColumnStockOutIsLocked";
            this.ColumnStockOutIsLocked.HeaderText = "L";
            this.ColumnStockOutIsLocked.Name = "ColumnStockOutIsLocked";
            this.ColumnStockOutIsLocked.ReadOnly = true;
            this.ColumnStockOutIsLocked.Width = 35;
            // 
            // ColumnStockOutSpace
            // 
            this.ColumnStockOutSpace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnStockOutSpace.DataPropertyName = "ColumnStockOutSpace";
            this.ColumnStockOutSpace.HeaderText = "";
            this.ColumnStockOutSpace.Name = "ColumnStockOutSpace";
            this.ColumnStockOutSpace.ReadOnly = true;
            // 
            // buttonStockOutPageListLast
            // 
            this.buttonStockOutPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockOutPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonStockOutPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockOutPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonStockOutPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonStockOutPageListLast.Name = "buttonStockOutPageListLast";
            this.buttonStockOutPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonStockOutPageListLast.TabIndex = 16;
            this.buttonStockOutPageListLast.Text = "Last";
            this.buttonStockOutPageListLast.UseVisualStyleBackColor = false;
            this.buttonStockOutPageListLast.Click += new System.EventHandler(this.buttonStockOutPageListLast_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonStockOutPageListFirst);
            this.panel3.Controls.Add(this.buttonStockOutPageListPrevious);
            this.panel3.Controls.Add(this.buttonStockOutPageListNext);
            this.panel3.Controls.Add(this.buttonStockOutPageListLast);
            this.panel3.Controls.Add(this.textBoxStockOutPageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 584);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1400, 53);
            this.panel3.TabIndex = 21;
            // 
            // textBoxStockOutPageNumber
            // 
            this.textBoxStockOutPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxStockOutPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxStockOutPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxStockOutPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxStockOutPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxStockOutPageNumber.Name = "textBoxStockOutPageNumber";
            this.textBoxStockOutPageNumber.ReadOnly = true;
            this.textBoxStockOutPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxStockOutPageNumber.TabIndex = 17;
            this.textBoxStockOutPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateTimePickerStockOutFilterEndDate);
            this.panel2.Controls.Add(this.dateTimePickerStockOutFilterStartDate);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewStockOut);
            this.panel2.Controls.Add(this.textBoxStockOutFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1400, 637);
            this.panel2.TabIndex = 7;
            // 
            // dateTimePickerStockOutFilterStartDate
            // 
            this.dateTimePickerStockOutFilterStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStockOutFilterStartDate.Location = new System.Drawing.Point(12, 6);
            this.dateTimePickerStockOutFilterStartDate.Name = "dateTimePickerStockOutFilterStartDate";
            this.dateTimePickerStockOutFilterStartDate.Size = new System.Drawing.Size(141, 30);
            this.dateTimePickerStockOutFilterStartDate.TabIndex = 0;
            this.dateTimePickerStockOutFilterStartDate.ValueChanged += new System.EventHandler(this.dateTimePickerStockOutFilterStartDate_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.Stock_Out;
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
            this.label1.Size = new System.Drawing.Size(180, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stock-Out List";
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
            // dateTimePickerStockOutFilterEndDate
            // 
            this.dateTimePickerStockOutFilterEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStockOutFilterEndDate.Location = new System.Drawing.Point(159, 6);
            this.dateTimePickerStockOutFilterEndDate.Name = "dateTimePickerStockOutFilterEndDate";
            this.dateTimePickerStockOutFilterEndDate.Size = new System.Drawing.Size(141, 30);
            this.dateTimePickerStockOutFilterEndDate.TabIndex = 22;
            this.dateTimePickerStockOutFilterEndDate.ValueChanged += new System.EventHandler(this.dateTimePickerStockOutFilterEndDate_ValueChanged);
            // 
            // TrnStockOutForm
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
            this.Name = "TrnStockOutForm";
            this.Text = "Stock In List";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockOut)).EndInit();
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

        private System.Windows.Forms.TextBox textBoxStockOutFilter;
        private System.Windows.Forms.Button buttonStockOutPageListFirst;
        private System.Windows.Forms.Button buttonStockOutPageListPrevious;
        private System.Windows.Forms.Button buttonStockOutPageListNext;
        private System.Windows.Forms.DataGridView dataGridViewStockOut;
        private System.Windows.Forms.Button buttonStockOutPageListLast;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxStockOutPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePickerStockOutFilterStartDate;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnStockOutButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnStockOutButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutOTDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutOTNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutRemarks;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnStockOutIsLocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutSpace;
        private System.Windows.Forms.DateTimePicker dateTimePickerStockOutFilterEndDate;
    }
}