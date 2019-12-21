namespace easyfmis.Forms.Software.TrnSalesOrder
{
    partial class TrnSalesOrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnSalesOrderForm));
            this.textBoxSalesOrderFilter = new System.Windows.Forms.TextBox();
            this.buttonSalesOrderPageListFirst = new System.Windows.Forms.Button();
            this.buttonSalesOrderPageListPrevious = new System.Windows.Forms.Button();
            this.buttonSalesOrderPageListNext = new System.Windows.Forms.Button();
            this.dataGridViewStockOut = new System.Windows.Forms.DataGridView();
            this.ColumnStockOutButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnStockOutButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnStockOutId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutOTDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutOTNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnStockOutSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSalesOrderPageListLast = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxSalesOrderPageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePickerSalesOrderFilter = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockOut)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSalesOrderFilter
            // 
            this.textBoxSalesOrderFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSalesOrderFilter.Location = new System.Drawing.Point(159, 6);
            this.textBoxSalesOrderFilter.Name = "textBoxSalesOrderFilter";
            this.textBoxSalesOrderFilter.Size = new System.Drawing.Size(1229, 30);
            this.textBoxSalesOrderFilter.TabIndex = 19;
            this.textBoxSalesOrderFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxStockOutFilter_KeyDown);
            // 
            // buttonSalesOrderPageListFirst
            // 
            this.buttonSalesOrderPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalesOrderPageListFirst.Enabled = false;
            this.buttonSalesOrderPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonSalesOrderPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalesOrderPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSalesOrderPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonSalesOrderPageListFirst.Name = "buttonSalesOrderPageListFirst";
            this.buttonSalesOrderPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonSalesOrderPageListFirst.TabIndex = 13;
            this.buttonSalesOrderPageListFirst.Text = "First";
            this.buttonSalesOrderPageListFirst.UseVisualStyleBackColor = false;
            this.buttonSalesOrderPageListFirst.Click += new System.EventHandler(this.buttonStockOutPageListFirst_Click);
            // 
            // buttonSalesOrderPageListPrevious
            // 
            this.buttonSalesOrderPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalesOrderPageListPrevious.Enabled = false;
            this.buttonSalesOrderPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonSalesOrderPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalesOrderPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSalesOrderPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonSalesOrderPageListPrevious.Name = "buttonSalesOrderPageListPrevious";
            this.buttonSalesOrderPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonSalesOrderPageListPrevious.TabIndex = 14;
            this.buttonSalesOrderPageListPrevious.Text = "Previous";
            this.buttonSalesOrderPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonSalesOrderPageListPrevious.Click += new System.EventHandler(this.buttonStockOutPageListPrevious_Click);
            // 
            // buttonSalesOrderPageListNext
            // 
            this.buttonSalesOrderPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalesOrderPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonSalesOrderPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalesOrderPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSalesOrderPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonSalesOrderPageListNext.Name = "buttonSalesOrderPageListNext";
            this.buttonSalesOrderPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonSalesOrderPageListNext.TabIndex = 15;
            this.buttonSalesOrderPageListNext.Text = "Next";
            this.buttonSalesOrderPageListNext.UseVisualStyleBackColor = false;
            this.buttonSalesOrderPageListNext.Click += new System.EventHandler(this.buttonStockOutPageListNext_Click);
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
            // buttonSalesOrderPageListLast
            // 
            this.buttonSalesOrderPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalesOrderPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonSalesOrderPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalesOrderPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSalesOrderPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonSalesOrderPageListLast.Name = "buttonSalesOrderPageListLast";
            this.buttonSalesOrderPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonSalesOrderPageListLast.TabIndex = 16;
            this.buttonSalesOrderPageListLast.Text = "Last";
            this.buttonSalesOrderPageListLast.UseVisualStyleBackColor = false;
            this.buttonSalesOrderPageListLast.Click += new System.EventHandler(this.buttonStockOutPageListLast_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonSalesOrderPageListFirst);
            this.panel3.Controls.Add(this.buttonSalesOrderPageListPrevious);
            this.panel3.Controls.Add(this.buttonSalesOrderPageListNext);
            this.panel3.Controls.Add(this.buttonSalesOrderPageListLast);
            this.panel3.Controls.Add(this.textBoxSalesOrderPageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 584);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1400, 53);
            this.panel3.TabIndex = 21;
            // 
            // textBoxSalesOrderPageNumber
            // 
            this.textBoxSalesOrderPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSalesOrderPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxSalesOrderPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSalesOrderPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxSalesOrderPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxSalesOrderPageNumber.Name = "textBoxSalesOrderPageNumber";
            this.textBoxSalesOrderPageNumber.ReadOnly = true;
            this.textBoxSalesOrderPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxSalesOrderPageNumber.TabIndex = 17;
            this.textBoxSalesOrderPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateTimePickerSalesOrderFilter);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewStockOut);
            this.panel2.Controls.Add(this.textBoxSalesOrderFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1400, 637);
            this.panel2.TabIndex = 7;
            // 
            // dateTimePickerSalesOrderFilter
            // 
            this.dateTimePickerSalesOrderFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerSalesOrderFilter.Location = new System.Drawing.Point(12, 6);
            this.dateTimePickerSalesOrderFilter.Name = "dateTimePickerSalesOrderFilter";
            this.dateTimePickerSalesOrderFilter.Size = new System.Drawing.Size(141, 30);
            this.dateTimePickerSalesOrderFilter.TabIndex = 22;
            this.dateTimePickerSalesOrderFilter.ValueChanged += new System.EventHandler(this.dateTimePickerStockOutFilter_ValueChanged);
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
            // TrnSalesOrderForm
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
            this.Name = "TrnSalesOrderForm";
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

        private System.Windows.Forms.TextBox textBoxSalesOrderFilter;
        private System.Windows.Forms.Button buttonSalesOrderPageListFirst;
        private System.Windows.Forms.Button buttonSalesOrderPageListPrevious;
        private System.Windows.Forms.Button buttonSalesOrderPageListNext;
        private System.Windows.Forms.DataGridView dataGridViewStockOut;
        private System.Windows.Forms.Button buttonSalesOrderPageListLast;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxSalesOrderPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePickerSalesOrderFilter;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnStockOutButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnStockOutButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutOTDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutOTNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutRemarks;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnStockOutIsLocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutSpace;
    }
}