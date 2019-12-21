namespace easyfmis.Forms.Software.TrnStockTransfer
{
    partial class TrnStockTransferForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnStockTransferForm));
            this.textBoxStockTransferFilter = new System.Windows.Forms.TextBox();
            this.buttonStockTransferPageListFirst = new System.Windows.Forms.Button();
            this.buttonStockTransferPageListPrevious = new System.Windows.Forms.Button();
            this.buttonStockTransferPageListNext = new System.Windows.Forms.Button();
            this.dataGridViewStockTransfer = new System.Windows.Forms.DataGridView();
            this.ColumnStockTransferButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnStockTransferButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnStockTransferId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockTransferSTDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockTransferSTNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockTransferToBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockTransferRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockTransferIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnStockTransferSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonStockTransferPageListLast = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxStockTransferPageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePickerStockTransferFilter = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockTransfer)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxStockTransferFilter
            // 
            this.textBoxStockTransferFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStockTransferFilter.Location = new System.Drawing.Point(159, 6);
            this.textBoxStockTransferFilter.Name = "textBoxStockTransferFilter";
            this.textBoxStockTransferFilter.Size = new System.Drawing.Size(1229, 30);
            this.textBoxStockTransferFilter.TabIndex = 19;
            this.textBoxStockTransferFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxStockTransferFilter_KeyDown);
            // 
            // buttonStockTransferPageListFirst
            // 
            this.buttonStockTransferPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockTransferPageListFirst.Enabled = false;
            this.buttonStockTransferPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonStockTransferPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockTransferPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonStockTransferPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonStockTransferPageListFirst.Name = "buttonStockTransferPageListFirst";
            this.buttonStockTransferPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonStockTransferPageListFirst.TabIndex = 13;
            this.buttonStockTransferPageListFirst.Text = "First";
            this.buttonStockTransferPageListFirst.UseVisualStyleBackColor = false;
            this.buttonStockTransferPageListFirst.Click += new System.EventHandler(this.buttonStockTransferPageListFirst_Click);
            // 
            // buttonStockTransferPageListPrevious
            // 
            this.buttonStockTransferPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockTransferPageListPrevious.Enabled = false;
            this.buttonStockTransferPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonStockTransferPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockTransferPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonStockTransferPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonStockTransferPageListPrevious.Name = "buttonStockTransferPageListPrevious";
            this.buttonStockTransferPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonStockTransferPageListPrevious.TabIndex = 14;
            this.buttonStockTransferPageListPrevious.Text = "Previous";
            this.buttonStockTransferPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonStockTransferPageListPrevious.Click += new System.EventHandler(this.buttonStockTransferPageListPrevious_Click);
            // 
            // buttonStockTransferPageListNext
            // 
            this.buttonStockTransferPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockTransferPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonStockTransferPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockTransferPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonStockTransferPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonStockTransferPageListNext.Name = "buttonStockTransferPageListNext";
            this.buttonStockTransferPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonStockTransferPageListNext.TabIndex = 15;
            this.buttonStockTransferPageListNext.Text = "Next";
            this.buttonStockTransferPageListNext.UseVisualStyleBackColor = false;
            this.buttonStockTransferPageListNext.Click += new System.EventHandler(this.buttonStockTransferPageListNext_Click);
            // 
            // dataGridViewStockTransfer
            // 
            this.dataGridViewStockTransfer.AllowUserToAddRows = false;
            this.dataGridViewStockTransfer.AllowUserToDeleteRows = false;
            this.dataGridViewStockTransfer.AllowUserToResizeRows = false;
            this.dataGridViewStockTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStockTransfer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewStockTransfer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStockTransfer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStockTransferButtonEdit,
            this.ColumnStockTransferButtonDelete,
            this.ColumnStockTransferId,
            this.ColumnStockTransferSTDate,
            this.ColumnStockTransferSTNumber,
            this.ColumnStockTransferToBranch,
            this.ColumnStockTransferRemarks,
            this.ColumnStockTransferIsLocked,
            this.ColumnStockTransferSpace});
            this.dataGridViewStockTransfer.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewStockTransfer.MultiSelect = false;
            this.dataGridViewStockTransfer.Name = "dataGridViewStockTransfer";
            this.dataGridViewStockTransfer.ReadOnly = true;
            this.dataGridViewStockTransfer.RowHeadersVisible = false;
            this.dataGridViewStockTransfer.RowTemplate.Height = 24;
            this.dataGridViewStockTransfer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStockTransfer.Size = new System.Drawing.Size(1376, 536);
            this.dataGridViewStockTransfer.TabIndex = 20;
            this.dataGridViewStockTransfer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStockTransfer_CellClick);
            // 
            // ColumnStockTransferButtonEdit
            // 
            this.ColumnStockTransferButtonEdit.DataPropertyName = "ColumnStockTransferButtonEdit";
            this.ColumnStockTransferButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnStockTransferButtonEdit.HeaderText = "";
            this.ColumnStockTransferButtonEdit.Name = "ColumnStockTransferButtonEdit";
            this.ColumnStockTransferButtonEdit.ReadOnly = true;
            this.ColumnStockTransferButtonEdit.Width = 70;
            // 
            // ColumnStockTransferButtonDelete
            // 
            this.ColumnStockTransferButtonDelete.DataPropertyName = "ColumnStockTransferButtonDelete";
            this.ColumnStockTransferButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnStockTransferButtonDelete.HeaderText = "";
            this.ColumnStockTransferButtonDelete.Name = "ColumnStockTransferButtonDelete";
            this.ColumnStockTransferButtonDelete.ReadOnly = true;
            this.ColumnStockTransferButtonDelete.Width = 70;
            // 
            // ColumnStockTransferId
            // 
            this.ColumnStockTransferId.DataPropertyName = "ColumnStockTransferId";
            this.ColumnStockTransferId.HeaderText = "Id";
            this.ColumnStockTransferId.Name = "ColumnStockTransferId";
            this.ColumnStockTransferId.ReadOnly = true;
            this.ColumnStockTransferId.Visible = false;
            // 
            // ColumnStockTransferSTDate
            // 
            this.ColumnStockTransferSTDate.DataPropertyName = "ColumnStockTransferSTDate";
            this.ColumnStockTransferSTDate.HeaderText = "ST Date";
            this.ColumnStockTransferSTDate.Name = "ColumnStockTransferSTDate";
            this.ColumnStockTransferSTDate.ReadOnly = true;
            // 
            // ColumnStockTransferSTNumber
            // 
            this.ColumnStockTransferSTNumber.DataPropertyName = "ColumnStockTransferSTNumber";
            this.ColumnStockTransferSTNumber.HeaderText = "ST Number";
            this.ColumnStockTransferSTNumber.Name = "ColumnStockTransferSTNumber";
            this.ColumnStockTransferSTNumber.ReadOnly = true;
            this.ColumnStockTransferSTNumber.Width = 125;
            // 
            // ColumnStockTransferToBranch
            // 
            this.ColumnStockTransferToBranch.DataPropertyName = "ColumnStockTransferToBranch";
            this.ColumnStockTransferToBranch.HeaderText = "To Branch";
            this.ColumnStockTransferToBranch.Name = "ColumnStockTransferToBranch";
            this.ColumnStockTransferToBranch.ReadOnly = true;
            this.ColumnStockTransferToBranch.Width = 150;
            // 
            // ColumnStockTransferRemarks
            // 
            this.ColumnStockTransferRemarks.DataPropertyName = "ColumnStockTransferRemarks";
            this.ColumnStockTransferRemarks.HeaderText = "Remarks";
            this.ColumnStockTransferRemarks.Name = "ColumnStockTransferRemarks";
            this.ColumnStockTransferRemarks.ReadOnly = true;
            this.ColumnStockTransferRemarks.Width = 350;
            // 
            // ColumnStockTransferIsLocked
            // 
            this.ColumnStockTransferIsLocked.DataPropertyName = "ColumnStockTransferIsLocked";
            this.ColumnStockTransferIsLocked.HeaderText = "L";
            this.ColumnStockTransferIsLocked.Name = "ColumnStockTransferIsLocked";
            this.ColumnStockTransferIsLocked.ReadOnly = true;
            this.ColumnStockTransferIsLocked.Width = 35;
            // 
            // ColumnStockTransferSpace
            // 
            this.ColumnStockTransferSpace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnStockTransferSpace.DataPropertyName = "ColumnStockTransferSpace";
            this.ColumnStockTransferSpace.HeaderText = "";
            this.ColumnStockTransferSpace.Name = "ColumnStockTransferSpace";
            this.ColumnStockTransferSpace.ReadOnly = true;
            // 
            // buttonStockTransferPageListLast
            // 
            this.buttonStockTransferPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockTransferPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonStockTransferPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockTransferPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonStockTransferPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonStockTransferPageListLast.Name = "buttonStockTransferPageListLast";
            this.buttonStockTransferPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonStockTransferPageListLast.TabIndex = 16;
            this.buttonStockTransferPageListLast.Text = "Last";
            this.buttonStockTransferPageListLast.UseVisualStyleBackColor = false;
            this.buttonStockTransferPageListLast.Click += new System.EventHandler(this.buttonStockTransferPageListLast_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonStockTransferPageListFirst);
            this.panel3.Controls.Add(this.buttonStockTransferPageListPrevious);
            this.panel3.Controls.Add(this.buttonStockTransferPageListNext);
            this.panel3.Controls.Add(this.buttonStockTransferPageListLast);
            this.panel3.Controls.Add(this.textBoxStockTransferPageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 584);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1400, 53);
            this.panel3.TabIndex = 21;
            // 
            // textBoxStockTransferPageNumber
            // 
            this.textBoxStockTransferPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxStockTransferPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxStockTransferPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxStockTransferPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxStockTransferPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxStockTransferPageNumber.Name = "textBoxStockTransferPageNumber";
            this.textBoxStockTransferPageNumber.ReadOnly = true;
            this.textBoxStockTransferPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxStockTransferPageNumber.TabIndex = 17;
            this.textBoxStockTransferPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateTimePickerStockTransferFilter);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewStockTransfer);
            this.panel2.Controls.Add(this.textBoxStockTransferFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1400, 637);
            this.panel2.TabIndex = 7;
            // 
            // dateTimePickerStockTransferFilter
            // 
            this.dateTimePickerStockTransferFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStockTransferFilter.Location = new System.Drawing.Point(12, 6);
            this.dateTimePickerStockTransferFilter.Name = "dateTimePickerStockTransferFilter";
            this.dateTimePickerStockTransferFilter.Size = new System.Drawing.Size(141, 30);
            this.dateTimePickerStockTransferFilter.TabIndex = 22;
            this.dateTimePickerStockTransferFilter.ValueChanged += new System.EventHandler(this.dateTimePickerStockTransferFilter_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.Stock_Transfer;
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
            this.label1.Size = new System.Drawing.Size(230, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stock Transfer List";
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
            this.buttonAdd.Location = new System.Drawing.Point(1206, 12);
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
            this.panel1.Size = new System.Drawing.Size(1400, 63);
            this.panel1.TabIndex = 6;
            // 
            // TrnStockTransferForm
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
            this.Name = "TrnStockTransferForm";
            this.Text = "Stock In List";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockTransfer)).EndInit();
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

        private System.Windows.Forms.TextBox textBoxStockTransferFilter;
        private System.Windows.Forms.Button buttonStockTransferPageListFirst;
        private System.Windows.Forms.Button buttonStockTransferPageListPrevious;
        private System.Windows.Forms.Button buttonStockTransferPageListNext;
        private System.Windows.Forms.DataGridView dataGridViewStockTransfer;
        private System.Windows.Forms.Button buttonStockTransferPageListLast;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxStockTransferPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePickerStockTransferFilter;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnStockTransferButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnStockTransferButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockTransferId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockTransferSTDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockTransferSTNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockTransferToBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockTransferRemarks;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnStockTransferIsLocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockTransferSpace;
    }
}