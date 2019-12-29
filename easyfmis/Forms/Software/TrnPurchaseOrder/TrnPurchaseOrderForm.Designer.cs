namespace easyfmis.Forms.Software.TrnPurchaseOrder
{
    partial class TrnPurchaseOrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnPurchaseOrderForm));
            this.textBoxPurchaseOrderFilter = new System.Windows.Forms.TextBox();
            this.buttonPurchaseOrderPageListFirst = new System.Windows.Forms.Button();
            this.buttonPurchaseOrderPageListPrevious = new System.Windows.Forms.Button();
            this.buttonPurchaseOrderPageListNext = new System.Windows.Forms.Button();
            this.dataGridViewPurchaseOrder = new System.Windows.Forms.DataGridView();
            this.ColumnPurchaseOrderListButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnPurchaseOrderListButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnPurchaseOrderListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPurchaseOrderListPODate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPurchaseOrderListPONumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPurchaseOrderListSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPurchaseOrderListRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPurchaseOrderListIsClose = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnPurchaseOrderListIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnPurchaseOrderListSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonPurchaseOrderPageListLast = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxPurchaseOrderPageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePickerPurchaseOrderFilter = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPurchaseOrder)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPurchaseOrderFilter
            // 
            this.textBoxPurchaseOrderFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPurchaseOrderFilter.Location = new System.Drawing.Point(159, 6);
            this.textBoxPurchaseOrderFilter.Name = "textBoxPurchaseOrderFilter";
            this.textBoxPurchaseOrderFilter.Size = new System.Drawing.Size(1229, 30);
            this.textBoxPurchaseOrderFilter.TabIndex = 1;
            this.textBoxPurchaseOrderFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPurchaseOrderFilter_KeyDown);
            // 
            // buttonPurchaseOrderPageListFirst
            // 
            this.buttonPurchaseOrderPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPurchaseOrderPageListFirst.Enabled = false;
            this.buttonPurchaseOrderPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonPurchaseOrderPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPurchaseOrderPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonPurchaseOrderPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonPurchaseOrderPageListFirst.Name = "buttonPurchaseOrderPageListFirst";
            this.buttonPurchaseOrderPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonPurchaseOrderPageListFirst.TabIndex = 13;
            this.buttonPurchaseOrderPageListFirst.Text = "First";
            this.buttonPurchaseOrderPageListFirst.UseVisualStyleBackColor = false;
            this.buttonPurchaseOrderPageListFirst.Click += new System.EventHandler(this.buttonPurchaseOrderPageListFirst_Click);
            // 
            // buttonPurchaseOrderPageListPrevious
            // 
            this.buttonPurchaseOrderPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPurchaseOrderPageListPrevious.Enabled = false;
            this.buttonPurchaseOrderPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonPurchaseOrderPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPurchaseOrderPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonPurchaseOrderPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonPurchaseOrderPageListPrevious.Name = "buttonPurchaseOrderPageListPrevious";
            this.buttonPurchaseOrderPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonPurchaseOrderPageListPrevious.TabIndex = 14;
            this.buttonPurchaseOrderPageListPrevious.Text = "Previous";
            this.buttonPurchaseOrderPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonPurchaseOrderPageListPrevious.Click += new System.EventHandler(this.buttonPurchaseOrderPageListPrevious_Click);
            // 
            // buttonPurchaseOrderPageListNext
            // 
            this.buttonPurchaseOrderPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPurchaseOrderPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonPurchaseOrderPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPurchaseOrderPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonPurchaseOrderPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonPurchaseOrderPageListNext.Name = "buttonPurchaseOrderPageListNext";
            this.buttonPurchaseOrderPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonPurchaseOrderPageListNext.TabIndex = 15;
            this.buttonPurchaseOrderPageListNext.Text = "Next";
            this.buttonPurchaseOrderPageListNext.UseVisualStyleBackColor = false;
            this.buttonPurchaseOrderPageListNext.Click += new System.EventHandler(this.buttonPurchaseOrderPageListNext_Click);
            // 
            // dataGridViewPurchaseOrder
            // 
            this.dataGridViewPurchaseOrder.AllowUserToAddRows = false;
            this.dataGridViewPurchaseOrder.AllowUserToDeleteRows = false;
            this.dataGridViewPurchaseOrder.AllowUserToResizeRows = false;
            this.dataGridViewPurchaseOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPurchaseOrder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPurchaseOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPurchaseOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPurchaseOrderListButtonEdit,
            this.ColumnPurchaseOrderListButtonDelete,
            this.ColumnPurchaseOrderListId,
            this.ColumnPurchaseOrderListPODate,
            this.ColumnPurchaseOrderListPONumber,
            this.ColumnPurchaseOrderListSupplier,
            this.ColumnPurchaseOrderListRemarks,
            this.ColumnPurchaseOrderListIsClose,
            this.ColumnPurchaseOrderListIsLocked,
            this.ColumnPurchaseOrderListSpace});
            this.dataGridViewPurchaseOrder.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewPurchaseOrder.MultiSelect = false;
            this.dataGridViewPurchaseOrder.Name = "dataGridViewPurchaseOrder";
            this.dataGridViewPurchaseOrder.ReadOnly = true;
            this.dataGridViewPurchaseOrder.RowHeadersVisible = false;
            this.dataGridViewPurchaseOrder.RowTemplate.Height = 24;
            this.dataGridViewPurchaseOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPurchaseOrder.Size = new System.Drawing.Size(1376, 536);
            this.dataGridViewPurchaseOrder.TabIndex = 20;
            this.dataGridViewPurchaseOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPurchaseOrder_CellClick);
            // 
            // ColumnPurchaseOrderListButtonEdit
            // 
            this.ColumnPurchaseOrderListButtonEdit.DataPropertyName = "ColumnPurchaseOrderListButtonEdit";
            this.ColumnPurchaseOrderListButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnPurchaseOrderListButtonEdit.HeaderText = "";
            this.ColumnPurchaseOrderListButtonEdit.Name = "ColumnPurchaseOrderListButtonEdit";
            this.ColumnPurchaseOrderListButtonEdit.ReadOnly = true;
            this.ColumnPurchaseOrderListButtonEdit.Width = 70;
            // 
            // ColumnPurchaseOrderListButtonDelete
            // 
            this.ColumnPurchaseOrderListButtonDelete.DataPropertyName = "ColumnPurchaseOrderListButtonDelete";
            this.ColumnPurchaseOrderListButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnPurchaseOrderListButtonDelete.HeaderText = "";
            this.ColumnPurchaseOrderListButtonDelete.Name = "ColumnPurchaseOrderListButtonDelete";
            this.ColumnPurchaseOrderListButtonDelete.ReadOnly = true;
            this.ColumnPurchaseOrderListButtonDelete.Width = 70;
            // 
            // ColumnPurchaseOrderListId
            // 
            this.ColumnPurchaseOrderListId.DataPropertyName = "ColumnPurchaseOrderListId";
            this.ColumnPurchaseOrderListId.HeaderText = "Id";
            this.ColumnPurchaseOrderListId.Name = "ColumnPurchaseOrderListId";
            this.ColumnPurchaseOrderListId.ReadOnly = true;
            this.ColumnPurchaseOrderListId.Visible = false;
            // 
            // ColumnPurchaseOrderListPODate
            // 
            this.ColumnPurchaseOrderListPODate.DataPropertyName = "ColumnPurchaseOrderListPODate";
            this.ColumnPurchaseOrderListPODate.HeaderText = "PO Date";
            this.ColumnPurchaseOrderListPODate.Name = "ColumnPurchaseOrderListPODate";
            this.ColumnPurchaseOrderListPODate.ReadOnly = true;
            // 
            // ColumnPurchaseOrderListPONumber
            // 
            this.ColumnPurchaseOrderListPONumber.DataPropertyName = "ColumnPurchaseOrderListPONumber";
            this.ColumnPurchaseOrderListPONumber.HeaderText = "PO Number";
            this.ColumnPurchaseOrderListPONumber.Name = "ColumnPurchaseOrderListPONumber";
            this.ColumnPurchaseOrderListPONumber.ReadOnly = true;
            this.ColumnPurchaseOrderListPONumber.Width = 125;
            // 
            // ColumnPurchaseOrderListSupplier
            // 
            this.ColumnPurchaseOrderListSupplier.DataPropertyName = "ColumnPurchaseOrderListSupplier";
            this.ColumnPurchaseOrderListSupplier.HeaderText = "Supplier";
            this.ColumnPurchaseOrderListSupplier.Name = "ColumnPurchaseOrderListSupplier";
            this.ColumnPurchaseOrderListSupplier.ReadOnly = true;
            this.ColumnPurchaseOrderListSupplier.Width = 200;
            // 
            // ColumnPurchaseOrderListRemarks
            // 
            this.ColumnPurchaseOrderListRemarks.DataPropertyName = "ColumnPurchaseOrderListRemarks";
            this.ColumnPurchaseOrderListRemarks.HeaderText = "Remarks";
            this.ColumnPurchaseOrderListRemarks.Name = "ColumnPurchaseOrderListRemarks";
            this.ColumnPurchaseOrderListRemarks.ReadOnly = true;
            this.ColumnPurchaseOrderListRemarks.Width = 200;
            // 
            // ColumnPurchaseOrderListIsClose
            // 
            this.ColumnPurchaseOrderListIsClose.DataPropertyName = "ColumnPurchaseOrderListIsClose";
            this.ColumnPurchaseOrderListIsClose.HeaderText = "C";
            this.ColumnPurchaseOrderListIsClose.Name = "ColumnPurchaseOrderListIsClose";
            this.ColumnPurchaseOrderListIsClose.ReadOnly = true;
            this.ColumnPurchaseOrderListIsClose.Width = 35;
            // 
            // ColumnPurchaseOrderListIsLocked
            // 
            this.ColumnPurchaseOrderListIsLocked.DataPropertyName = "ColumnPurchaseOrderListIsLocked";
            this.ColumnPurchaseOrderListIsLocked.HeaderText = "L";
            this.ColumnPurchaseOrderListIsLocked.Name = "ColumnPurchaseOrderListIsLocked";
            this.ColumnPurchaseOrderListIsLocked.ReadOnly = true;
            this.ColumnPurchaseOrderListIsLocked.Width = 35;
            // 
            // ColumnPurchaseOrderListSpace
            // 
            this.ColumnPurchaseOrderListSpace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnPurchaseOrderListSpace.DataPropertyName = "ColumnPurchaseOrderListSpace";
            this.ColumnPurchaseOrderListSpace.HeaderText = "";
            this.ColumnPurchaseOrderListSpace.Name = "ColumnPurchaseOrderListSpace";
            this.ColumnPurchaseOrderListSpace.ReadOnly = true;
            // 
            // buttonPurchaseOrderPageListLast
            // 
            this.buttonPurchaseOrderPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPurchaseOrderPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonPurchaseOrderPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPurchaseOrderPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonPurchaseOrderPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonPurchaseOrderPageListLast.Name = "buttonPurchaseOrderPageListLast";
            this.buttonPurchaseOrderPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonPurchaseOrderPageListLast.TabIndex = 16;
            this.buttonPurchaseOrderPageListLast.Text = "Last";
            this.buttonPurchaseOrderPageListLast.UseVisualStyleBackColor = false;
            this.buttonPurchaseOrderPageListLast.Click += new System.EventHandler(this.buttonPurchaseOrderPageListLast_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonPurchaseOrderPageListFirst);
            this.panel3.Controls.Add(this.buttonPurchaseOrderPageListPrevious);
            this.panel3.Controls.Add(this.buttonPurchaseOrderPageListNext);
            this.panel3.Controls.Add(this.buttonPurchaseOrderPageListLast);
            this.panel3.Controls.Add(this.textBoxPurchaseOrderPageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 584);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1400, 53);
            this.panel3.TabIndex = 21;
            // 
            // textBoxPurchaseOrderPageNumber
            // 
            this.textBoxPurchaseOrderPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxPurchaseOrderPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxPurchaseOrderPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPurchaseOrderPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxPurchaseOrderPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxPurchaseOrderPageNumber.Name = "textBoxPurchaseOrderPageNumber";
            this.textBoxPurchaseOrderPageNumber.ReadOnly = true;
            this.textBoxPurchaseOrderPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxPurchaseOrderPageNumber.TabIndex = 17;
            this.textBoxPurchaseOrderPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateTimePickerPurchaseOrderFilter);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewPurchaseOrder);
            this.panel2.Controls.Add(this.textBoxPurchaseOrderFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1400, 637);
            this.panel2.TabIndex = 7;
            // 
            // dateTimePickerPurchaseOrderFilter
            // 
            this.dateTimePickerPurchaseOrderFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerPurchaseOrderFilter.Location = new System.Drawing.Point(12, 6);
            this.dateTimePickerPurchaseOrderFilter.Name = "dateTimePickerPurchaseOrderFilter";
            this.dateTimePickerPurchaseOrderFilter.Size = new System.Drawing.Size(141, 30);
            this.dateTimePickerPurchaseOrderFilter.TabIndex = 0;
            this.dateTimePickerPurchaseOrderFilter.ValueChanged += new System.EventHandler(this.dateTimePickerPurchaseOrderFilter_ValueChanged);
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
            this.label1.Size = new System.Drawing.Size(243, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Purchase Order List";
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
            // TrnPurchaseOrderForm
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
            this.Name = "TrnPurchaseOrderForm";
            this.Text = "Stock In List";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPurchaseOrder)).EndInit();
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

        private System.Windows.Forms.TextBox textBoxPurchaseOrderFilter;
        private System.Windows.Forms.Button buttonPurchaseOrderPageListFirst;
        private System.Windows.Forms.Button buttonPurchaseOrderPageListPrevious;
        private System.Windows.Forms.Button buttonPurchaseOrderPageListNext;
        private System.Windows.Forms.DataGridView dataGridViewPurchaseOrder;
        private System.Windows.Forms.Button buttonPurchaseOrderPageListLast;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxPurchaseOrderPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePickerPurchaseOrderFilter;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnPurchaseOrderListButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnPurchaseOrderListButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPurchaseOrderListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPurchaseOrderListPODate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPurchaseOrderListPONumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPurchaseOrderListSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPurchaseOrderListRemarks;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnPurchaseOrderListIsClose;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnPurchaseOrderListIsLocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPurchaseOrderListSpace;
    }
}