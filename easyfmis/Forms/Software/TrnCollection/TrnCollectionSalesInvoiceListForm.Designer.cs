namespace easyfmis.Forms.Software.TrnCollection
{
    partial class TrnCollectionSalesInvoiceListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnCollectionSalesInvoiceListForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxSalesInvoiceFilter = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonSalesInvoicePageListFirst = new System.Windows.Forms.Button();
            this.buttonSalesInvoicePageListPrevious = new System.Windows.Forms.Button();
            this.buttonSalesInvoicePageListNext = new System.Windows.Forms.Button();
            this.buttonSalesInvoicePageListLast = new System.Windows.Forms.Button();
            this.textBoxSalesInvoicePageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridViewSalesInvoice = new System.Windows.Forms.DataGridView();
            this.ColumnCollectionSalesInvoiceListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCollectionSalesInvoiceListSIDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCollectionSalesInvoiceListSINumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCollectionSalesInvoiceListManualSINumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCollectionSalesInvoiceListRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCollectionSalesInvoiceListBalanceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCollectionSalesInvoiceListButtonPick = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalesInvoice)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(166, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sales Invoice";
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
            // textBoxSalesInvoiceFilter
            // 
            this.textBoxSalesInvoiceFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSalesInvoiceFilter.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxSalesInvoiceFilter.Location = new System.Drawing.Point(8, 6);
            this.textBoxSalesInvoiceFilter.Name = "textBoxSalesInvoiceFilter";
            this.textBoxSalesInvoiceFilter.Size = new System.Drawing.Size(958, 30);
            this.textBoxSalesInvoiceFilter.TabIndex = 0;
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
            this.panel3.Location = new System.Drawing.Point(3, 448);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(968, 53);
            this.panel3.TabIndex = 19;
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
            this.tabPage1.Controls.Add(this.dataGridViewSalesInvoice);
            this.tabPage1.Controls.Add(this.textBoxSalesInvoiceFilter);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(974, 504);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sales Invoice";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.ColumnCollectionSalesInvoiceListId,
            this.ColumnCollectionSalesInvoiceListSIDate,
            this.ColumnCollectionSalesInvoiceListSINumber,
            this.ColumnCollectionSalesInvoiceListManualSINumber,
            this.ColumnCollectionSalesInvoiceListRemarks,
            this.ColumnCollectionSalesInvoiceListBalanceAmount,
            this.ColumnCollectionSalesInvoiceListButtonPick});
            this.dataGridViewSalesInvoice.Location = new System.Drawing.Point(8, 42);
            this.dataGridViewSalesInvoice.MultiSelect = false;
            this.dataGridViewSalesInvoice.Name = "dataGridViewSalesInvoice";
            this.dataGridViewSalesInvoice.ReadOnly = true;
            this.dataGridViewSalesInvoice.RowHeadersVisible = false;
            this.dataGridViewSalesInvoice.RowTemplate.Height = 24;
            this.dataGridViewSalesInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSalesInvoice.Size = new System.Drawing.Size(958, 400);
            this.dataGridViewSalesInvoice.TabIndex = 21;
            this.dataGridViewSalesInvoice.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSalesInvoice_CellClick);
            // 
            // ColumnCollectionSalesInvoiceListId
            // 
            this.ColumnCollectionSalesInvoiceListId.DataPropertyName = "ColumnCollectionSalesInvoiceListId";
            this.ColumnCollectionSalesInvoiceListId.HeaderText = "Id";
            this.ColumnCollectionSalesInvoiceListId.Name = "ColumnCollectionSalesInvoiceListId";
            this.ColumnCollectionSalesInvoiceListId.ReadOnly = true;
            this.ColumnCollectionSalesInvoiceListId.Visible = false;
            // 
            // ColumnCollectionSalesInvoiceListSIDate
            // 
            this.ColumnCollectionSalesInvoiceListSIDate.DataPropertyName = "ColumnCollectionSalesInvoiceListSIDate";
            this.ColumnCollectionSalesInvoiceListSIDate.HeaderText = "SI Date";
            this.ColumnCollectionSalesInvoiceListSIDate.Name = "ColumnCollectionSalesInvoiceListSIDate";
            this.ColumnCollectionSalesInvoiceListSIDate.ReadOnly = true;
            // 
            // ColumnCollectionSalesInvoiceListSINumber
            // 
            this.ColumnCollectionSalesInvoiceListSINumber.DataPropertyName = "ColumnCollectionSalesInvoiceListSINumber";
            this.ColumnCollectionSalesInvoiceListSINumber.HeaderText = "SI Number";
            this.ColumnCollectionSalesInvoiceListSINumber.Name = "ColumnCollectionSalesInvoiceListSINumber";
            this.ColumnCollectionSalesInvoiceListSINumber.ReadOnly = true;
            // 
            // ColumnCollectionSalesInvoiceListManualSINumber
            // 
            this.ColumnCollectionSalesInvoiceListManualSINumber.DataPropertyName = "ColumnCollectionSalesInvoiceListManualSINumber";
            this.ColumnCollectionSalesInvoiceListManualSINumber.HeaderText = "Manual SI No.";
            this.ColumnCollectionSalesInvoiceListManualSINumber.Name = "ColumnCollectionSalesInvoiceListManualSINumber";
            this.ColumnCollectionSalesInvoiceListManualSINumber.ReadOnly = true;
            this.ColumnCollectionSalesInvoiceListManualSINumber.Width = 130;
            // 
            // ColumnCollectionSalesInvoiceListRemarks
            // 
            this.ColumnCollectionSalesInvoiceListRemarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnCollectionSalesInvoiceListRemarks.DataPropertyName = "ColumnCollectionSalesInvoiceListRemarks";
            this.ColumnCollectionSalesInvoiceListRemarks.HeaderText = "Remarks";
            this.ColumnCollectionSalesInvoiceListRemarks.Name = "ColumnCollectionSalesInvoiceListRemarks";
            this.ColumnCollectionSalesInvoiceListRemarks.ReadOnly = true;
            // 
            // ColumnCollectionSalesInvoiceListBalanceAmount
            // 
            this.ColumnCollectionSalesInvoiceListBalanceAmount.DataPropertyName = "ColumnCollectionSalesInvoiceListBalanceAmount";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnCollectionSalesInvoiceListBalanceAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnCollectionSalesInvoiceListBalanceAmount.HeaderText = "Balance Amount";
            this.ColumnCollectionSalesInvoiceListBalanceAmount.Name = "ColumnCollectionSalesInvoiceListBalanceAmount";
            this.ColumnCollectionSalesInvoiceListBalanceAmount.ReadOnly = true;
            this.ColumnCollectionSalesInvoiceListBalanceAmount.Width = 170;
            // 
            // ColumnCollectionSalesInvoiceListButtonPick
            // 
            this.ColumnCollectionSalesInvoiceListButtonPick.DataPropertyName = "ColumnCollectionSalesInvoiceListButtonPick";
            this.ColumnCollectionSalesInvoiceListButtonPick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnCollectionSalesInvoiceListButtonPick.HeaderText = "";
            this.ColumnCollectionSalesInvoiceListButtonPick.Name = "ColumnCollectionSalesInvoiceListButtonPick";
            this.ColumnCollectionSalesInvoiceListButtonPick.ReadOnly = true;
            this.ColumnCollectionSalesInvoiceListButtonPick.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnCollectionSalesInvoiceListButtonPick.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnCollectionSalesInvoiceListButtonPick.Width = 70;
            // 
            // TrnCollectionSalesInvoiceListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(982, 603);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrnCollectionSalesInvoiceListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Item";
            this.Load += new System.EventHandler(this.TrnSalesInvoiceDetailSearchItemForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalesInvoice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox textBoxSalesInvoiceFilter;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonSalesInvoicePageListFirst;
        private System.Windows.Forms.Button buttonSalesInvoicePageListPrevious;
        private System.Windows.Forms.Button buttonSalesInvoicePageListNext;
        private System.Windows.Forms.Button buttonSalesInvoicePageListLast;
        private System.Windows.Forms.TextBox textBoxSalesInvoicePageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridViewSalesInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCollectionSalesInvoiceListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCollectionSalesInvoiceListSIDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCollectionSalesInvoiceListSINumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCollectionSalesInvoiceListManualSINumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCollectionSalesInvoiceListRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCollectionSalesInvoiceListBalanceAmount;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnCollectionSalesInvoiceListButtonPick;
    }
}