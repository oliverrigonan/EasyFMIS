namespace easyfmis.Forms.Software.TrnSalesInvoice
{
    partial class TrnSalesInvoiceDetailSearchSalesOrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnSalesInvoiceDetailSearchSalesOrderForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dataGridViewSalesOrder = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonSalesOrderPageListFirst = new System.Windows.Forms.Button();
            this.buttonSalesOrderPageListPrevious = new System.Windows.Forms.Button();
            this.buttonSalesOrderPageListNext = new System.Windows.Forms.Button();
            this.buttonSalesOrderPageListLast = new System.Windows.Forms.Button();
            this.textBoxSalesOrderPageNumber = new System.Windows.Forms.TextBox();
            this.textBoxSearchSalesOrderItemFilter = new System.Windows.Forms.TextBox();
            this.ColumnSalesInvoiceSearchSalesOrderListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesInvoiceSearchSalesOrderListSODate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesInvoiceSearchSalesOrderListSONumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesInvoiceSearchSalesOrderListRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesInvoiceSearchSalesOrderListPick = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalesOrder)).BeginInit();
            this.panel5.SuspendLayout();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 50);
            this.panel1.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.Item;
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
            this.label1.Size = new System.Drawing.Size(120, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sales Order";
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
            this.buttonClose.Location = new System.Drawing.Point(706, 10);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(70, 32);
            this.buttonClose.TabIndex = 20;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(786, 432);
            this.panel2.TabIndex = 10;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(786, 432);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel6);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage3.Size = new System.Drawing.Size(778, 400);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Sales Order";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dataGridViewSalesOrder);
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Controls.Add(this.textBoxSearchSalesOrderItemFilter);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(2, 2);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(774, 396);
            this.panel6.TabIndex = 12;
            this.panel6.TabStop = true;
            // 
            // dataGridViewSalesOrder
            // 
            this.dataGridViewSalesOrder.AllowUserToAddRows = false;
            this.dataGridViewSalesOrder.AllowUserToDeleteRows = false;
            this.dataGridViewSalesOrder.AllowUserToResizeRows = false;
            this.dataGridViewSalesOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSalesOrder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewSalesOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSalesOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSalesInvoiceSearchSalesOrderListId,
            this.ColumnSalesInvoiceSearchSalesOrderListSODate,
            this.ColumnSalesInvoiceSearchSalesOrderListSONumber,
            this.ColumnSalesInvoiceSearchSalesOrderListRemarks,
            this.ColumnSalesInvoiceSearchSalesOrderListPick});
            this.dataGridViewSalesOrder.Location = new System.Drawing.Point(5, 36);
            this.dataGridViewSalesOrder.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewSalesOrder.MultiSelect = false;
            this.dataGridViewSalesOrder.Name = "dataGridViewSalesOrder";
            this.dataGridViewSalesOrder.ReadOnly = true;
            this.dataGridViewSalesOrder.RowHeadersVisible = false;
            this.dataGridViewSalesOrder.RowTemplate.Height = 24;
            this.dataGridViewSalesOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSalesOrder.Size = new System.Drawing.Size(764, 314);
            this.dataGridViewSalesOrder.TabIndex = 27;
            this.dataGridViewSalesOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSalesOrder_CellClick);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.buttonSalesOrderPageListFirst);
            this.panel5.Controls.Add(this.buttonSalesOrderPageListPrevious);
            this.panel5.Controls.Add(this.buttonSalesOrderPageListNext);
            this.panel5.Controls.Add(this.buttonSalesOrderPageListLast);
            this.panel5.Controls.Add(this.textBoxSalesOrderPageNumber);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 354);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(774, 42);
            this.panel5.TabIndex = 26;
            // 
            // buttonSalesOrderPageListFirst
            // 
            this.buttonSalesOrderPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalesOrderPageListFirst.Enabled = false;
            this.buttonSalesOrderPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonSalesOrderPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalesOrderPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSalesOrderPageListFirst.Location = new System.Drawing.Point(10, 7);
            this.buttonSalesOrderPageListFirst.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSalesOrderPageListFirst.Name = "buttonSalesOrderPageListFirst";
            this.buttonSalesOrderPageListFirst.Size = new System.Drawing.Size(66, 26);
            this.buttonSalesOrderPageListFirst.TabIndex = 13;
            this.buttonSalesOrderPageListFirst.Text = "First";
            this.buttonSalesOrderPageListFirst.UseVisualStyleBackColor = false;
            this.buttonSalesOrderPageListFirst.Click += new System.EventHandler(this.buttonSalesOrderPageListFirst_Click);
            // 
            // buttonSalesOrderPageListPrevious
            // 
            this.buttonSalesOrderPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalesOrderPageListPrevious.Enabled = false;
            this.buttonSalesOrderPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonSalesOrderPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalesOrderPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSalesOrderPageListPrevious.Location = new System.Drawing.Point(80, 7);
            this.buttonSalesOrderPageListPrevious.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSalesOrderPageListPrevious.Name = "buttonSalesOrderPageListPrevious";
            this.buttonSalesOrderPageListPrevious.Size = new System.Drawing.Size(66, 26);
            this.buttonSalesOrderPageListPrevious.TabIndex = 14;
            this.buttonSalesOrderPageListPrevious.Text = "Previous";
            this.buttonSalesOrderPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonSalesOrderPageListPrevious.Click += new System.EventHandler(this.buttonSalesOrderPageListPrevious_Click);
            // 
            // buttonSalesOrderPageListNext
            // 
            this.buttonSalesOrderPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalesOrderPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonSalesOrderPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalesOrderPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSalesOrderPageListNext.Location = new System.Drawing.Point(210, 7);
            this.buttonSalesOrderPageListNext.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSalesOrderPageListNext.Name = "buttonSalesOrderPageListNext";
            this.buttonSalesOrderPageListNext.Size = new System.Drawing.Size(66, 26);
            this.buttonSalesOrderPageListNext.TabIndex = 15;
            this.buttonSalesOrderPageListNext.Text = "Next";
            this.buttonSalesOrderPageListNext.UseVisualStyleBackColor = false;
            this.buttonSalesOrderPageListNext.Click += new System.EventHandler(this.buttonSalesOrderPageListNext_Click);
            // 
            // buttonSalesOrderPageListLast
            // 
            this.buttonSalesOrderPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalesOrderPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonSalesOrderPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalesOrderPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSalesOrderPageListLast.Location = new System.Drawing.Point(278, 7);
            this.buttonSalesOrderPageListLast.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSalesOrderPageListLast.Name = "buttonSalesOrderPageListLast";
            this.buttonSalesOrderPageListLast.Size = new System.Drawing.Size(66, 26);
            this.buttonSalesOrderPageListLast.TabIndex = 16;
            this.buttonSalesOrderPageListLast.Text = "Last";
            this.buttonSalesOrderPageListLast.UseVisualStyleBackColor = false;
            this.buttonSalesOrderPageListLast.Click += new System.EventHandler(this.buttonSalesOrderPageListLast_Click);
            // 
            // textBoxSalesOrderPageNumber
            // 
            this.textBoxSalesOrderPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSalesOrderPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxSalesOrderPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSalesOrderPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxSalesOrderPageNumber.Location = new System.Drawing.Point(150, 11);
            this.textBoxSalesOrderPageNumber.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSalesOrderPageNumber.Name = "textBoxSalesOrderPageNumber";
            this.textBoxSalesOrderPageNumber.ReadOnly = true;
            this.textBoxSalesOrderPageNumber.Size = new System.Drawing.Size(55, 16);
            this.textBoxSalesOrderPageNumber.TabIndex = 17;
            this.textBoxSalesOrderPageNumber.TabStop = false;
            this.textBoxSalesOrderPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSearchSalesOrderItemFilter
            // 
            this.textBoxSearchSalesOrderItemFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearchSalesOrderItemFilter.Font = new System.Drawing.Font("Segoe UI", 10.7F);
            this.textBoxSearchSalesOrderItemFilter.Location = new System.Drawing.Point(5, 6);
            this.textBoxSearchSalesOrderItemFilter.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSearchSalesOrderItemFilter.Name = "textBoxSearchSalesOrderItemFilter";
            this.textBoxSearchSalesOrderItemFilter.Size = new System.Drawing.Size(764, 26);
            this.textBoxSearchSalesOrderItemFilter.TabIndex = 1;
            this.textBoxSearchSalesOrderItemFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearchSalesOrderItemFilter_KeyDown);
            // 
            // ColumnSalesInvoiceSearchSalesOrderListId
            // 
            this.ColumnSalesInvoiceSearchSalesOrderListId.DataPropertyName = "ColumnSalesInvoiceSearchSalesOrderListId";
            this.ColumnSalesInvoiceSearchSalesOrderListId.HeaderText = "Id";
            this.ColumnSalesInvoiceSearchSalesOrderListId.Name = "ColumnSalesInvoiceSearchSalesOrderListId";
            this.ColumnSalesInvoiceSearchSalesOrderListId.ReadOnly = true;
            this.ColumnSalesInvoiceSearchSalesOrderListId.Visible = false;
            // 
            // ColumnSalesInvoiceSearchSalesOrderListSODate
            // 
            this.ColumnSalesInvoiceSearchSalesOrderListSODate.DataPropertyName = "ColumnSalesInvoiceSearchSalesOrderListSODate";
            this.ColumnSalesInvoiceSearchSalesOrderListSODate.HeaderText = "SO Date";
            this.ColumnSalesInvoiceSearchSalesOrderListSODate.Name = "ColumnSalesInvoiceSearchSalesOrderListSODate";
            this.ColumnSalesInvoiceSearchSalesOrderListSODate.ReadOnly = true;
            // 
            // ColumnSalesInvoiceSearchSalesOrderListSONumber
            // 
            this.ColumnSalesInvoiceSearchSalesOrderListSONumber.DataPropertyName = "ColumnSalesInvoiceSearchSalesOrderListSONumber";
            this.ColumnSalesInvoiceSearchSalesOrderListSONumber.HeaderText = "SO Number";
            this.ColumnSalesInvoiceSearchSalesOrderListSONumber.Name = "ColumnSalesInvoiceSearchSalesOrderListSONumber";
            this.ColumnSalesInvoiceSearchSalesOrderListSONumber.ReadOnly = true;
            this.ColumnSalesInvoiceSearchSalesOrderListSONumber.Width = 125;
            // 
            // ColumnSalesInvoiceSearchSalesOrderListRemarks
            // 
            this.ColumnSalesInvoiceSearchSalesOrderListRemarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSalesInvoiceSearchSalesOrderListRemarks.DataPropertyName = "ColumnSalesInvoiceSearchSalesOrderListRemarks";
            this.ColumnSalesInvoiceSearchSalesOrderListRemarks.HeaderText = "Remarks";
            this.ColumnSalesInvoiceSearchSalesOrderListRemarks.Name = "ColumnSalesInvoiceSearchSalesOrderListRemarks";
            this.ColumnSalesInvoiceSearchSalesOrderListRemarks.ReadOnly = true;
            // 
            // ColumnSalesInvoiceSearchSalesOrderListPick
            // 
            this.ColumnSalesInvoiceSearchSalesOrderListPick.DataPropertyName = "ColumnSalesInvoiceSearchSalesOrderListPick";
            this.ColumnSalesInvoiceSearchSalesOrderListPick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnSalesInvoiceSearchSalesOrderListPick.HeaderText = "";
            this.ColumnSalesInvoiceSearchSalesOrderListPick.Name = "ColumnSalesInvoiceSearchSalesOrderListPick";
            this.ColumnSalesInvoiceSearchSalesOrderListPick.ReadOnly = true;
            this.ColumnSalesInvoiceSearchSalesOrderListPick.Width = 70;
            // 
            // TrnSalesInvoiceDetailSearchSalesOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(786, 482);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TrnSalesInvoiceDetailSearchSalesOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Order";
            this.Load += new System.EventHandler(this.TrnSalesInvoiceDetailSearchItemForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalesOrder)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox textBoxSearchSalesOrderItemFilter;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button buttonSalesOrderPageListFirst;
        private System.Windows.Forms.Button buttonSalesOrderPageListPrevious;
        private System.Windows.Forms.Button buttonSalesOrderPageListNext;
        private System.Windows.Forms.Button buttonSalesOrderPageListLast;
        private System.Windows.Forms.TextBox textBoxSalesOrderPageNumber;
        private System.Windows.Forms.DataGridView dataGridViewSalesOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesInvoiceSearchSalesOrderListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesInvoiceSearchSalesOrderListSODate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesInvoiceSearchSalesOrderListSONumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesInvoiceSearchSalesOrderListRemarks;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnSalesInvoiceSearchSalesOrderListPick;
    }
}