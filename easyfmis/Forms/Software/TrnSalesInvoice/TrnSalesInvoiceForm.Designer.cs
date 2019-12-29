namespace easyfmis.Forms.Software.TrnSalesInvoice
{
    partial class TrnSalesInvoiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnSalesInvoiceForm));
            this.textBoxSalesInvoiceFilter = new System.Windows.Forms.TextBox();
            this.buttonSalesInvoicePageListFirst = new System.Windows.Forms.Button();
            this.buttonSalesInvoicePageListPrevious = new System.Windows.Forms.Button();
            this.buttonSalesInvoicePageListNext = new System.Windows.Forms.Button();
            this.dataGridViewSalesInvoice = new System.Windows.Forms.DataGridView();
            this.ColumnSalesInvoiceButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnSalesInvoiceButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnSalesInvoiceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesInvoiceSIDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesInvoiceSINumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesInvoiceManualSINumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesInvoiceRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesInvoiceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesInvoiceIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnSalesInvoiceSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSalesInvoicePageListLast = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxSalesInvoicePageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePickerSalesInvoiceFilter = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalesInvoice)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSalesInvoiceFilter
            // 
            this.textBoxSalesInvoiceFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSalesInvoiceFilter.Location = new System.Drawing.Point(159, 6);
            this.textBoxSalesInvoiceFilter.Name = "textBoxSalesInvoiceFilter";
            this.textBoxSalesInvoiceFilter.Size = new System.Drawing.Size(1229, 30);
            this.textBoxSalesInvoiceFilter.TabIndex = 1;
            this.textBoxSalesInvoiceFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSalesInvoiceFilter_KeyDown);
            // 
            // buttonSalesInvoicePageListFirst
            // 
            this.buttonSalesInvoicePageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalesInvoicePageListFirst.Enabled = false;
            this.buttonSalesInvoicePageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonSalesInvoicePageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalesInvoicePageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSalesInvoicePageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonSalesInvoicePageListFirst.Name = "buttonSalesInvoicePageListFirst";
            this.buttonSalesInvoicePageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonSalesInvoicePageListFirst.TabIndex = 13;
            this.buttonSalesInvoicePageListFirst.Text = "First";
            this.buttonSalesInvoicePageListFirst.UseVisualStyleBackColor = false;
            this.buttonSalesInvoicePageListFirst.Click += new System.EventHandler(this.buttonSalesInvoicePageListFirst_Click);
            // 
            // buttonSalesInvoicePageListPrevious
            // 
            this.buttonSalesInvoicePageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalesInvoicePageListPrevious.Enabled = false;
            this.buttonSalesInvoicePageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonSalesInvoicePageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalesInvoicePageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSalesInvoicePageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonSalesInvoicePageListPrevious.Name = "buttonSalesInvoicePageListPrevious";
            this.buttonSalesInvoicePageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonSalesInvoicePageListPrevious.TabIndex = 14;
            this.buttonSalesInvoicePageListPrevious.Text = "Previous";
            this.buttonSalesInvoicePageListPrevious.UseVisualStyleBackColor = false;
            this.buttonSalesInvoicePageListPrevious.Click += new System.EventHandler(this.buttonSalesInvoicePageListPrevious_Click);
            // 
            // buttonSalesInvoicePageListNext
            // 
            this.buttonSalesInvoicePageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalesInvoicePageListNext.FlatAppearance.BorderSize = 0;
            this.buttonSalesInvoicePageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalesInvoicePageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSalesInvoicePageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonSalesInvoicePageListNext.Name = "buttonSalesInvoicePageListNext";
            this.buttonSalesInvoicePageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonSalesInvoicePageListNext.TabIndex = 15;
            this.buttonSalesInvoicePageListNext.Text = "Next";
            this.buttonSalesInvoicePageListNext.UseVisualStyleBackColor = false;
            this.buttonSalesInvoicePageListNext.Click += new System.EventHandler(this.buttonSalesInvoicePageListNext_Click);
            // 
            // dataGridViewSalesInvoice
            // 
            this.dataGridViewSalesInvoice.AllowUserToAddRows = false;
            this.dataGridViewSalesInvoice.AllowUserToDeleteRows = false;
            this.dataGridViewSalesInvoice.AllowUserToResizeRows = false;
            this.dataGridViewSalesInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSalesInvoice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewSalesInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSalesInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSalesInvoiceButtonEdit,
            this.ColumnSalesInvoiceButtonDelete,
            this.ColumnSalesInvoiceId,
            this.ColumnSalesInvoiceSIDate,
            this.ColumnSalesInvoiceSINumber,
            this.ColumnSalesInvoiceManualSINumber,
            this.ColumnSalesInvoiceRemarks,
            this.ColumnSalesInvoiceAmount,
            this.ColumnSalesInvoiceIsLocked,
            this.ColumnSalesInvoiceSpace});
            this.dataGridViewSalesInvoice.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewSalesInvoice.MultiSelect = false;
            this.dataGridViewSalesInvoice.Name = "dataGridViewSalesInvoice";
            this.dataGridViewSalesInvoice.ReadOnly = true;
            this.dataGridViewSalesInvoice.RowHeadersVisible = false;
            this.dataGridViewSalesInvoice.RowTemplate.Height = 24;
            this.dataGridViewSalesInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSalesInvoice.Size = new System.Drawing.Size(1376, 536);
            this.dataGridViewSalesInvoice.TabIndex = 20;
            this.dataGridViewSalesInvoice.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSalesInvoice_CellClick);
            // 
            // ColumnSalesInvoiceButtonEdit
            // 
            this.ColumnSalesInvoiceButtonEdit.DataPropertyName = "ColumnSalesInvoiceButtonEdit";
            this.ColumnSalesInvoiceButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnSalesInvoiceButtonEdit.HeaderText = "";
            this.ColumnSalesInvoiceButtonEdit.Name = "ColumnSalesInvoiceButtonEdit";
            this.ColumnSalesInvoiceButtonEdit.ReadOnly = true;
            this.ColumnSalesInvoiceButtonEdit.Width = 70;
            // 
            // ColumnSalesInvoiceButtonDelete
            // 
            this.ColumnSalesInvoiceButtonDelete.DataPropertyName = "ColumnSalesInvoiceButtonDelete";
            this.ColumnSalesInvoiceButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnSalesInvoiceButtonDelete.HeaderText = "";
            this.ColumnSalesInvoiceButtonDelete.Name = "ColumnSalesInvoiceButtonDelete";
            this.ColumnSalesInvoiceButtonDelete.ReadOnly = true;
            this.ColumnSalesInvoiceButtonDelete.Width = 70;
            // 
            // ColumnSalesInvoiceId
            // 
            this.ColumnSalesInvoiceId.DataPropertyName = "ColumnSalesInvoiceId";
            this.ColumnSalesInvoiceId.HeaderText = "Id";
            this.ColumnSalesInvoiceId.Name = "ColumnSalesInvoiceId";
            this.ColumnSalesInvoiceId.ReadOnly = true;
            this.ColumnSalesInvoiceId.Visible = false;
            // 
            // ColumnSalesInvoiceSIDate
            // 
            this.ColumnSalesInvoiceSIDate.DataPropertyName = "ColumnSalesInvoiceSIDate";
            this.ColumnSalesInvoiceSIDate.HeaderText = "SI Date";
            this.ColumnSalesInvoiceSIDate.Name = "ColumnSalesInvoiceSIDate";
            this.ColumnSalesInvoiceSIDate.ReadOnly = true;
            // 
            // ColumnSalesInvoiceSINumber
            // 
            this.ColumnSalesInvoiceSINumber.DataPropertyName = "ColumnSalesInvoiceSINumber";
            this.ColumnSalesInvoiceSINumber.HeaderText = "SI Number";
            this.ColumnSalesInvoiceSINumber.Name = "ColumnSalesInvoiceSINumber";
            this.ColumnSalesInvoiceSINumber.ReadOnly = true;
            this.ColumnSalesInvoiceSINumber.Width = 125;
            // 
            // ColumnSalesInvoiceManualSINumber
            // 
            this.ColumnSalesInvoiceManualSINumber.DataPropertyName = "ColumnSalesInvoiceManualSINumber";
            this.ColumnSalesInvoiceManualSINumber.HeaderText = "Manual SI Number";
            this.ColumnSalesInvoiceManualSINumber.Name = "ColumnSalesInvoiceManualSINumber";
            this.ColumnSalesInvoiceManualSINumber.ReadOnly = true;
            this.ColumnSalesInvoiceManualSINumber.Width = 150;
            // 
            // ColumnSalesInvoiceRemarks
            // 
            this.ColumnSalesInvoiceRemarks.DataPropertyName = "ColumnSalesInvoiceRemarks";
            this.ColumnSalesInvoiceRemarks.HeaderText = "Remarks";
            this.ColumnSalesInvoiceRemarks.Name = "ColumnSalesInvoiceRemarks";
            this.ColumnSalesInvoiceRemarks.ReadOnly = true;
            this.ColumnSalesInvoiceRemarks.Width = 350;
            // 
            // ColumnSalesInvoiceAmount
            // 
            this.ColumnSalesInvoiceAmount.DataPropertyName = "ColumnSalesInvoiceAmount";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnSalesInvoiceAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnSalesInvoiceAmount.HeaderText = "Amount";
            this.ColumnSalesInvoiceAmount.Name = "ColumnSalesInvoiceAmount";
            this.ColumnSalesInvoiceAmount.ReadOnly = true;
            this.ColumnSalesInvoiceAmount.Width = 150;
            // 
            // ColumnSalesInvoiceIsLocked
            // 
            this.ColumnSalesInvoiceIsLocked.DataPropertyName = "ColumnSalesInvoiceIsLocked";
            this.ColumnSalesInvoiceIsLocked.HeaderText = "L";
            this.ColumnSalesInvoiceIsLocked.Name = "ColumnSalesInvoiceIsLocked";
            this.ColumnSalesInvoiceIsLocked.ReadOnly = true;
            this.ColumnSalesInvoiceIsLocked.Width = 35;
            // 
            // ColumnSalesInvoiceSpace
            // 
            this.ColumnSalesInvoiceSpace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSalesInvoiceSpace.DataPropertyName = "ColumnSalesInvoiceSpace";
            this.ColumnSalesInvoiceSpace.HeaderText = "";
            this.ColumnSalesInvoiceSpace.Name = "ColumnSalesInvoiceSpace";
            this.ColumnSalesInvoiceSpace.ReadOnly = true;
            // 
            // buttonSalesInvoicePageListLast
            // 
            this.buttonSalesInvoicePageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalesInvoicePageListLast.FlatAppearance.BorderSize = 0;
            this.buttonSalesInvoicePageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalesInvoicePageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSalesInvoicePageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonSalesInvoicePageListLast.Name = "buttonSalesInvoicePageListLast";
            this.buttonSalesInvoicePageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonSalesInvoicePageListLast.TabIndex = 16;
            this.buttonSalesInvoicePageListLast.Text = "Last";
            this.buttonSalesInvoicePageListLast.UseVisualStyleBackColor = false;
            this.buttonSalesInvoicePageListLast.Click += new System.EventHandler(this.buttonSalesInvoicePageListLast_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonSalesInvoicePageListFirst);
            this.panel3.Controls.Add(this.buttonSalesInvoicePageListPrevious);
            this.panel3.Controls.Add(this.buttonSalesInvoicePageListNext);
            this.panel3.Controls.Add(this.buttonSalesInvoicePageListLast);
            this.panel3.Controls.Add(this.textBoxSalesInvoicePageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 584);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1400, 53);
            this.panel3.TabIndex = 21;
            // 
            // textBoxSalesInvoicePageNumber
            // 
            this.textBoxSalesInvoicePageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSalesInvoicePageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxSalesInvoicePageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSalesInvoicePageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxSalesInvoicePageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxSalesInvoicePageNumber.Name = "textBoxSalesInvoicePageNumber";
            this.textBoxSalesInvoicePageNumber.ReadOnly = true;
            this.textBoxSalesInvoicePageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxSalesInvoicePageNumber.TabIndex = 17;
            this.textBoxSalesInvoicePageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateTimePickerSalesInvoiceFilter);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewSalesInvoice);
            this.panel2.Controls.Add(this.textBoxSalesInvoiceFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1400, 637);
            this.panel2.TabIndex = 7;
            // 
            // dateTimePickerSalesInvoiceFilter
            // 
            this.dateTimePickerSalesInvoiceFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerSalesInvoiceFilter.Location = new System.Drawing.Point(12, 6);
            this.dateTimePickerSalesInvoiceFilter.Name = "dateTimePickerSalesInvoiceFilter";
            this.dateTimePickerSalesInvoiceFilter.Size = new System.Drawing.Size(141, 30);
            this.dateTimePickerSalesInvoiceFilter.TabIndex = 0;
            this.dateTimePickerSalesInvoiceFilter.ValueChanged += new System.EventHandler(this.dateTimePickerSalesInvoiceFilter_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.POS1;
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
            this.label1.Size = new System.Drawing.Size(214, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sales Invoice List";
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
            // TrnSalesInvoiceForm
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
            this.Name = "TrnSalesInvoiceForm";
            this.Text = "Stock In List";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalesInvoice)).EndInit();
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

        private System.Windows.Forms.TextBox textBoxSalesInvoiceFilter;
        private System.Windows.Forms.Button buttonSalesInvoicePageListFirst;
        private System.Windows.Forms.Button buttonSalesInvoicePageListPrevious;
        private System.Windows.Forms.Button buttonSalesInvoicePageListNext;
        private System.Windows.Forms.DataGridView dataGridViewSalesInvoice;
        private System.Windows.Forms.Button buttonSalesInvoicePageListLast;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxSalesInvoicePageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePickerSalesInvoiceFilter;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnSalesInvoiceButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnSalesInvoiceButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesInvoiceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesInvoiceSIDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesInvoiceSINumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesInvoiceManualSINumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesInvoiceRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesInvoiceAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnSalesInvoiceIsLocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesInvoiceSpace;
    }
}