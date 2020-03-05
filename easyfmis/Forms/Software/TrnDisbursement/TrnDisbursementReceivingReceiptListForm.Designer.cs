namespace easyfmis.Forms.Software.TrnDisbursement
{
    partial class TrnDisbursementReceivingReceiptListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnDisbursementReceivingReceiptListForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxReceivingReceiptFilter = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonReceivingReceiptPageListFirst = new System.Windows.Forms.Button();
            this.buttonReceivingReceiptPageListPrevious = new System.Windows.Forms.Button();
            this.buttonReceivingReceiptPageListNext = new System.Windows.Forms.Button();
            this.buttonReceivingReceiptPageListLast = new System.Windows.Forms.Button();
            this.textBoxReceivingReceiptPageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridViewReceivingReceipt = new System.Windows.Forms.DataGridView();
            this.ColumnDisbursementReceivingReceiptListRRId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDisbursementReceivingReceiptListRRDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDisbursementReceivingReceiptListRRNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDisbursementReceivingReceiptListManualRRNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDisbursementReceivingReceiptListRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDisbursementReceivingReceiptListBalanceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDisbursementReceivingReceiptListButtongPick = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReceivingReceipt)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 63);
            this.panel1.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.Item;
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
            this.label1.Size = new System.Drawing.Size(223, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Receiving Receipt";
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
            this.buttonClose.Location = new System.Drawing.Point(882, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(88, 40);
            this.buttonClose.TabIndex = 20;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textBoxReceivingReceiptFilter
            // 
            this.textBoxReceivingReceiptFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxReceivingReceiptFilter.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxReceivingReceiptFilter.Location = new System.Drawing.Point(8, 6);
            this.textBoxReceivingReceiptFilter.Name = "textBoxReceivingReceiptFilter";
            this.textBoxReceivingReceiptFilter.Size = new System.Drawing.Size(958, 30);
            this.textBoxReceivingReceiptFilter.TabIndex = 0;
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
            this.panel3.Location = new System.Drawing.Point(3, 448);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(968, 53);
            this.panel3.TabIndex = 19;
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
            this.buttonReceivingReceiptPageListFirst.Click += new System.EventHandler(this.buttonSalesInvoicePageListFirst_Click);
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
            this.buttonReceivingReceiptPageListPrevious.Click += new System.EventHandler(this.buttonSalesInvoicePageListPrevious_Click);
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
            this.buttonReceivingReceiptPageListNext.Click += new System.EventHandler(this.buttonSalesInvoicePageListNext_Click);
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
            this.buttonReceivingReceiptPageListLast.Click += new System.EventHandler(this.buttonSalesInvoicePageListLast_Click);
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
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(982, 540);
            this.panel2.TabIndex = 10;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(982, 540);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridViewReceivingReceipt);
            this.tabPage1.Controls.Add(this.textBoxReceivingReceiptFilter);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(974, 504);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Receiving Receipt";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.ColumnDisbursementReceivingReceiptListRRId,
            this.ColumnDisbursementReceivingReceiptListRRDate,
            this.ColumnDisbursementReceivingReceiptListRRNumber,
            this.ColumnDisbursementReceivingReceiptListManualRRNumber,
            this.ColumnDisbursementReceivingReceiptListRemarks,
            this.ColumnDisbursementReceivingReceiptListBalanceAmount,
            this.ColumnDisbursementReceivingReceiptListButtongPick});
            this.dataGridViewReceivingReceipt.Location = new System.Drawing.Point(8, 42);
            this.dataGridViewReceivingReceipt.MultiSelect = false;
            this.dataGridViewReceivingReceipt.Name = "dataGridViewReceivingReceipt";
            this.dataGridViewReceivingReceipt.ReadOnly = true;
            this.dataGridViewReceivingReceipt.RowHeadersVisible = false;
            this.dataGridViewReceivingReceipt.RowTemplate.Height = 24;
            this.dataGridViewReceivingReceipt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReceivingReceipt.Size = new System.Drawing.Size(958, 400);
            this.dataGridViewReceivingReceipt.TabIndex = 21;
            this.dataGridViewReceivingReceipt.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewReceivingReceipt_CellClick);
            // 
            // ColumnDisbursementReceivingReceiptListRRId
            // 
            this.ColumnDisbursementReceivingReceiptListRRId.DataPropertyName = "ColumnDisbursementReceivingReceiptListRRId";
            this.ColumnDisbursementReceivingReceiptListRRId.HeaderText = "Id";
            this.ColumnDisbursementReceivingReceiptListRRId.Name = "ColumnDisbursementReceivingReceiptListRRId";
            this.ColumnDisbursementReceivingReceiptListRRId.ReadOnly = true;
            this.ColumnDisbursementReceivingReceiptListRRId.Visible = false;
            // 
            // ColumnDisbursementReceivingReceiptListRRDate
            // 
            this.ColumnDisbursementReceivingReceiptListRRDate.DataPropertyName = "ColumnDisbursementReceivingReceiptListRRDate";
            this.ColumnDisbursementReceivingReceiptListRRDate.HeaderText = "RR Date";
            this.ColumnDisbursementReceivingReceiptListRRDate.Name = "ColumnDisbursementReceivingReceiptListRRDate";
            this.ColumnDisbursementReceivingReceiptListRRDate.ReadOnly = true;
            // 
            // ColumnDisbursementReceivingReceiptListRRNumber
            // 
            this.ColumnDisbursementReceivingReceiptListRRNumber.DataPropertyName = "ColumnDisbursementReceivingReceiptListRRNumber";
            this.ColumnDisbursementReceivingReceiptListRRNumber.HeaderText = "RRNumber";
            this.ColumnDisbursementReceivingReceiptListRRNumber.Name = "ColumnDisbursementReceivingReceiptListRRNumber";
            this.ColumnDisbursementReceivingReceiptListRRNumber.ReadOnly = true;
            // 
            // ColumnDisbursementReceivingReceiptListManualRRNumber
            // 
            this.ColumnDisbursementReceivingReceiptListManualRRNumber.DataPropertyName = "ColumnDisbursementReceivingReceiptListManualRRNumber";
            this.ColumnDisbursementReceivingReceiptListManualRRNumber.HeaderText = "Manual RR No.";
            this.ColumnDisbursementReceivingReceiptListManualRRNumber.Name = "ColumnDisbursementReceivingReceiptListManualRRNumber";
            this.ColumnDisbursementReceivingReceiptListManualRRNumber.ReadOnly = true;
            this.ColumnDisbursementReceivingReceiptListManualRRNumber.Width = 130;
            // 
            // ColumnDisbursementReceivingReceiptListRemarks
            // 
            this.ColumnDisbursementReceivingReceiptListRemarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnDisbursementReceivingReceiptListRemarks.DataPropertyName = "ColumnDisbursementReceivingReceiptListRemarks";
            this.ColumnDisbursementReceivingReceiptListRemarks.HeaderText = "Remarks";
            this.ColumnDisbursementReceivingReceiptListRemarks.Name = "ColumnDisbursementReceivingReceiptListRemarks";
            this.ColumnDisbursementReceivingReceiptListRemarks.ReadOnly = true;
            // 
            // ColumnDisbursementReceivingReceiptListBalanceAmount
            // 
            this.ColumnDisbursementReceivingReceiptListBalanceAmount.DataPropertyName = "ColumnDisbursementReceivingReceiptListBalanceAmount";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnDisbursementReceivingReceiptListBalanceAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnDisbursementReceivingReceiptListBalanceAmount.HeaderText = "Balance Amount";
            this.ColumnDisbursementReceivingReceiptListBalanceAmount.Name = "ColumnDisbursementReceivingReceiptListBalanceAmount";
            this.ColumnDisbursementReceivingReceiptListBalanceAmount.ReadOnly = true;
            this.ColumnDisbursementReceivingReceiptListBalanceAmount.Width = 170;
            // 
            // ColumnDisbursementReceivingReceiptListButtongPick
            // 
            this.ColumnDisbursementReceivingReceiptListButtongPick.DataPropertyName = "ColumnDisbursementReceivingReceiptListButtongPick";
            this.ColumnDisbursementReceivingReceiptListButtongPick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnDisbursementReceivingReceiptListButtongPick.HeaderText = "";
            this.ColumnDisbursementReceivingReceiptListButtongPick.Name = "ColumnDisbursementReceivingReceiptListButtongPick";
            this.ColumnDisbursementReceivingReceiptListButtongPick.ReadOnly = true;
            this.ColumnDisbursementReceivingReceiptListButtongPick.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnDisbursementReceivingReceiptListButtongPick.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnDisbursementReceivingReceiptListButtongPick.Width = 70;
            // 
            // TrnDisbursementReceivingReceiptListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(982, 603);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrnDisbursementReceivingReceiptListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receiving Receipt";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReceivingReceipt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox textBoxReceivingReceiptFilter;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonReceivingReceiptPageListFirst;
        private System.Windows.Forms.Button buttonReceivingReceiptPageListPrevious;
        private System.Windows.Forms.Button buttonReceivingReceiptPageListNext;
        private System.Windows.Forms.Button buttonReceivingReceiptPageListLast;
        private System.Windows.Forms.TextBox textBoxReceivingReceiptPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridViewReceivingReceipt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDisbursementReceivingReceiptListRRId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDisbursementReceivingReceiptListRRDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDisbursementReceivingReceiptListRRNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDisbursementReceivingReceiptListManualRRNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDisbursementReceivingReceiptListRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDisbursementReceivingReceiptListBalanceAmount;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnDisbursementReceivingReceiptListButtongPick;
    }
}