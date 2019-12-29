namespace easyfmis.Forms.Software.TrnReceivingReceipt
{
    partial class TrnReceivingReceiptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnReceivingReceiptForm));
            this.textBoxReceivingReceiptFilter = new System.Windows.Forms.TextBox();
            this.buttonReceivingReceiptPageListFirst = new System.Windows.Forms.Button();
            this.buttonReceivingReceiptPageListPrevious = new System.Windows.Forms.Button();
            this.buttonReceivingReceiptPageListNext = new System.Windows.Forms.Button();
            this.dataGridViewReceivingReceipt = new System.Windows.Forms.DataGridView();
            this.ColumnReceivingReceiptButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnReceivingReceiptButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnReceivingReceiptId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReceivingReceiptRRDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReceivingReceiptRRNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReceivingReceiptManualRRNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReceivingReceiptRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReceivingReceiptAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReceivingReceiptIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnReceivingReceiptSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonReceivingReceiptPageListLast = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxReceivingReceiptPageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePickerReceivingReceiptFilter = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReceivingReceipt)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxReceivingReceiptFilter
            // 
            this.textBoxReceivingReceiptFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxReceivingReceiptFilter.Location = new System.Drawing.Point(159, 6);
            this.textBoxReceivingReceiptFilter.Name = "textBoxReceivingReceiptFilter";
            this.textBoxReceivingReceiptFilter.Size = new System.Drawing.Size(1229, 30);
            this.textBoxReceivingReceiptFilter.TabIndex = 1;
            this.textBoxReceivingReceiptFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxReceivingReceiptFilter_KeyDown);
            // 
            // buttonReceivingReceiptPageListFirst
            // 
            this.buttonReceivingReceiptPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReceivingReceiptPageListFirst.Enabled = false;
            this.buttonReceivingReceiptPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonReceivingReceiptPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReceivingReceiptPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonReceivingReceiptPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonReceivingReceiptPageListFirst.Name = "buttonReceivingReceiptPageListFirst";
            this.buttonReceivingReceiptPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonReceivingReceiptPageListFirst.TabIndex = 13;
            this.buttonReceivingReceiptPageListFirst.Text = "First";
            this.buttonReceivingReceiptPageListFirst.UseVisualStyleBackColor = false;
            this.buttonReceivingReceiptPageListFirst.Click += new System.EventHandler(this.buttonReceivingReceiptPageListFirst_Click);
            // 
            // buttonReceivingReceiptPageListPrevious
            // 
            this.buttonReceivingReceiptPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReceivingReceiptPageListPrevious.Enabled = false;
            this.buttonReceivingReceiptPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonReceivingReceiptPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReceivingReceiptPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonReceivingReceiptPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonReceivingReceiptPageListPrevious.Name = "buttonReceivingReceiptPageListPrevious";
            this.buttonReceivingReceiptPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonReceivingReceiptPageListPrevious.TabIndex = 14;
            this.buttonReceivingReceiptPageListPrevious.Text = "Previous";
            this.buttonReceivingReceiptPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonReceivingReceiptPageListPrevious.Click += new System.EventHandler(this.buttonReceivingReceiptPageListPrevious_Click);
            // 
            // buttonReceivingReceiptPageListNext
            // 
            this.buttonReceivingReceiptPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReceivingReceiptPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonReceivingReceiptPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReceivingReceiptPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonReceivingReceiptPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonReceivingReceiptPageListNext.Name = "buttonReceivingReceiptPageListNext";
            this.buttonReceivingReceiptPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonReceivingReceiptPageListNext.TabIndex = 15;
            this.buttonReceivingReceiptPageListNext.Text = "Next";
            this.buttonReceivingReceiptPageListNext.UseVisualStyleBackColor = false;
            this.buttonReceivingReceiptPageListNext.Click += new System.EventHandler(this.buttonReceivingReceiptPageListNext_Click);
            // 
            // dataGridViewReceivingReceipt
            // 
            this.dataGridViewReceivingReceipt.AllowUserToAddRows = false;
            this.dataGridViewReceivingReceipt.AllowUserToDeleteRows = false;
            this.dataGridViewReceivingReceipt.AllowUserToResizeRows = false;
            this.dataGridViewReceivingReceipt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewReceivingReceipt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewReceivingReceipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReceivingReceipt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnReceivingReceiptButtonEdit,
            this.ColumnReceivingReceiptButtonDelete,
            this.ColumnReceivingReceiptId,
            this.ColumnReceivingReceiptRRDate,
            this.ColumnReceivingReceiptRRNumber,
            this.ColumnReceivingReceiptManualRRNumber,
            this.ColumnReceivingReceiptRemarks,
            this.ColumnReceivingReceiptAmount,
            this.ColumnReceivingReceiptIsLocked,
            this.ColumnReceivingReceiptSpace});
            this.dataGridViewReceivingReceipt.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewReceivingReceipt.MultiSelect = false;
            this.dataGridViewReceivingReceipt.Name = "dataGridViewReceivingReceipt";
            this.dataGridViewReceivingReceipt.ReadOnly = true;
            this.dataGridViewReceivingReceipt.RowHeadersVisible = false;
            this.dataGridViewReceivingReceipt.RowTemplate.Height = 24;
            this.dataGridViewReceivingReceipt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReceivingReceipt.Size = new System.Drawing.Size(1376, 536);
            this.dataGridViewReceivingReceipt.TabIndex = 20;
            this.dataGridViewReceivingReceipt.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewReceivingReceipt_CellClick);
            // 
            // ColumnReceivingReceiptButtonEdit
            // 
            this.ColumnReceivingReceiptButtonEdit.DataPropertyName = "ColumnReceivingReceiptButtonEdit";
            this.ColumnReceivingReceiptButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnReceivingReceiptButtonEdit.HeaderText = "";
            this.ColumnReceivingReceiptButtonEdit.Name = "ColumnReceivingReceiptButtonEdit";
            this.ColumnReceivingReceiptButtonEdit.ReadOnly = true;
            this.ColumnReceivingReceiptButtonEdit.Width = 70;
            // 
            // ColumnReceivingReceiptButtonDelete
            // 
            this.ColumnReceivingReceiptButtonDelete.DataPropertyName = "ColumnReceivingReceiptButtonDelete";
            this.ColumnReceivingReceiptButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnReceivingReceiptButtonDelete.HeaderText = "";
            this.ColumnReceivingReceiptButtonDelete.Name = "ColumnReceivingReceiptButtonDelete";
            this.ColumnReceivingReceiptButtonDelete.ReadOnly = true;
            this.ColumnReceivingReceiptButtonDelete.Width = 70;
            // 
            // ColumnReceivingReceiptId
            // 
            this.ColumnReceivingReceiptId.DataPropertyName = "ColumnReceivingReceiptId";
            this.ColumnReceivingReceiptId.HeaderText = "Id";
            this.ColumnReceivingReceiptId.Name = "ColumnReceivingReceiptId";
            this.ColumnReceivingReceiptId.ReadOnly = true;
            this.ColumnReceivingReceiptId.Visible = false;
            // 
            // ColumnReceivingReceiptRRDate
            // 
            this.ColumnReceivingReceiptRRDate.DataPropertyName = "ColumnReceivingReceiptRRDate";
            this.ColumnReceivingReceiptRRDate.HeaderText = "RR Date";
            this.ColumnReceivingReceiptRRDate.Name = "ColumnReceivingReceiptRRDate";
            this.ColumnReceivingReceiptRRDate.ReadOnly = true;
            // 
            // ColumnReceivingReceiptRRNumber
            // 
            this.ColumnReceivingReceiptRRNumber.DataPropertyName = "ColumnReceivingReceiptRRNumber";
            this.ColumnReceivingReceiptRRNumber.HeaderText = "RR Number";
            this.ColumnReceivingReceiptRRNumber.Name = "ColumnReceivingReceiptRRNumber";
            this.ColumnReceivingReceiptRRNumber.ReadOnly = true;
            this.ColumnReceivingReceiptRRNumber.Width = 125;
            // 
            // ColumnReceivingReceiptManualRRNumber
            // 
            this.ColumnReceivingReceiptManualRRNumber.DataPropertyName = "ColumnReceivingReceiptManualRRNumber";
            this.ColumnReceivingReceiptManualRRNumber.HeaderText = "Manual RR Number";
            this.ColumnReceivingReceiptManualRRNumber.Name = "ColumnReceivingReceiptManualRRNumber";
            this.ColumnReceivingReceiptManualRRNumber.ReadOnly = true;
            this.ColumnReceivingReceiptManualRRNumber.Width = 150;
            // 
            // ColumnReceivingReceiptRemarks
            // 
            this.ColumnReceivingReceiptRemarks.DataPropertyName = "ColumnReceivingReceiptRemarks";
            this.ColumnReceivingReceiptRemarks.HeaderText = "Remarks";
            this.ColumnReceivingReceiptRemarks.Name = "ColumnReceivingReceiptRemarks";
            this.ColumnReceivingReceiptRemarks.ReadOnly = true;
            this.ColumnReceivingReceiptRemarks.Width = 350;
            // 
            // ColumnReceivingReceiptAmount
            // 
            this.ColumnReceivingReceiptAmount.DataPropertyName = "ColumnReceivingReceiptAmount";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnReceivingReceiptAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnReceivingReceiptAmount.HeaderText = "Amount";
            this.ColumnReceivingReceiptAmount.Name = "ColumnReceivingReceiptAmount";
            this.ColumnReceivingReceiptAmount.ReadOnly = true;
            this.ColumnReceivingReceiptAmount.Width = 150;
            // 
            // ColumnReceivingReceiptIsLocked
            // 
            this.ColumnReceivingReceiptIsLocked.DataPropertyName = "ColumnReceivingReceiptIsLocked";
            this.ColumnReceivingReceiptIsLocked.HeaderText = "L";
            this.ColumnReceivingReceiptIsLocked.Name = "ColumnReceivingReceiptIsLocked";
            this.ColumnReceivingReceiptIsLocked.ReadOnly = true;
            this.ColumnReceivingReceiptIsLocked.Width = 35;
            // 
            // ColumnReceivingReceiptSpace
            // 
            this.ColumnReceivingReceiptSpace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnReceivingReceiptSpace.DataPropertyName = "ColumnReceivingReceiptSpace";
            this.ColumnReceivingReceiptSpace.HeaderText = "";
            this.ColumnReceivingReceiptSpace.Name = "ColumnReceivingReceiptSpace";
            this.ColumnReceivingReceiptSpace.ReadOnly = true;
            // 
            // buttonReceivingReceiptPageListLast
            // 
            this.buttonReceivingReceiptPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReceivingReceiptPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonReceivingReceiptPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReceivingReceiptPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonReceivingReceiptPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonReceivingReceiptPageListLast.Name = "buttonReceivingReceiptPageListLast";
            this.buttonReceivingReceiptPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonReceivingReceiptPageListLast.TabIndex = 16;
            this.buttonReceivingReceiptPageListLast.Text = "Last";
            this.buttonReceivingReceiptPageListLast.UseVisualStyleBackColor = false;
            this.buttonReceivingReceiptPageListLast.Click += new System.EventHandler(this.buttonReceivingReceiptPageListLast_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonReceivingReceiptPageListFirst);
            this.panel3.Controls.Add(this.buttonReceivingReceiptPageListPrevious);
            this.panel3.Controls.Add(this.buttonReceivingReceiptPageListNext);
            this.panel3.Controls.Add(this.buttonReceivingReceiptPageListLast);
            this.panel3.Controls.Add(this.textBoxReceivingReceiptPageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 584);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1400, 53);
            this.panel3.TabIndex = 21;
            // 
            // textBoxReceivingReceiptPageNumber
            // 
            this.textBoxReceivingReceiptPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxReceivingReceiptPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxReceivingReceiptPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxReceivingReceiptPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxReceivingReceiptPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxReceivingReceiptPageNumber.Name = "textBoxReceivingReceiptPageNumber";
            this.textBoxReceivingReceiptPageNumber.ReadOnly = true;
            this.textBoxReceivingReceiptPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxReceivingReceiptPageNumber.TabIndex = 17;
            this.textBoxReceivingReceiptPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateTimePickerReceivingReceiptFilter);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewReceivingReceipt);
            this.panel2.Controls.Add(this.textBoxReceivingReceiptFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1400, 637);
            this.panel2.TabIndex = 7;
            // 
            // dateTimePickerReceivingReceiptFilter
            // 
            this.dateTimePickerReceivingReceiptFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerReceivingReceiptFilter.Location = new System.Drawing.Point(12, 6);
            this.dateTimePickerReceivingReceiptFilter.Name = "dateTimePickerReceivingReceiptFilter";
            this.dateTimePickerReceivingReceiptFilter.Size = new System.Drawing.Size(141, 30);
            this.dateTimePickerReceivingReceiptFilter.TabIndex = 0;
            this.dateTimePickerReceivingReceiptFilter.ValueChanged += new System.EventHandler(this.dateTimePickerReceivingReceiptFilter_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.Receiving_Receipt;
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
            this.label1.Size = new System.Drawing.Size(271, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Receiving Receipt List";
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
            // TrnReceivingReceiptForm
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
            this.Name = "TrnReceivingReceiptForm";
            this.Text = "Stock In List";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReceivingReceipt)).EndInit();
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

        private System.Windows.Forms.TextBox textBoxReceivingReceiptFilter;
        private System.Windows.Forms.Button buttonReceivingReceiptPageListFirst;
        private System.Windows.Forms.Button buttonReceivingReceiptPageListPrevious;
        private System.Windows.Forms.Button buttonReceivingReceiptPageListNext;
        private System.Windows.Forms.DataGridView dataGridViewReceivingReceipt;
        private System.Windows.Forms.Button buttonReceivingReceiptPageListLast;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxReceivingReceiptPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePickerReceivingReceiptFilter;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnReceivingReceiptButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnReceivingReceiptButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReceivingReceiptId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReceivingReceiptRRDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReceivingReceiptRRNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReceivingReceiptManualRRNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReceivingReceiptRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReceivingReceiptAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnReceivingReceiptIsLocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReceivingReceiptSpace;
    }
}