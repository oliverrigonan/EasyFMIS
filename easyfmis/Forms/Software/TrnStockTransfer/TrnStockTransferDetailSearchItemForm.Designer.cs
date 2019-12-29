namespace easyfmis.Forms.Software.TrnStockTransfer
{
    partial class TrnStockTransferDetailSearchItemForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnStockTransferDetailSearchItemForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.dataGridViewSearchItem = new System.Windows.Forms.DataGridView();
            this.ColumnSearchInventoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchInventoryItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchInventoryItemBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchInventoryItemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchInventoryItemInventoryCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchInventoryItemUnitId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchInventoryItemUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchInventoryItemQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchInventoryItemButtonPick = new System.Windows.Forms.DataGridViewButtonColumn();
            this.textBoxSearchItemFilter = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonSearchItemPageListFirst = new System.Windows.Forms.Button();
            this.buttonSearchItemPageListPrevious = new System.Windows.Forms.Button();
            this.buttonSearchItemPageListNext = new System.Windows.Forms.Button();
            this.buttonSearchItemPageListLast = new System.Windows.Forms.Button();
            this.textBoxSearchItemPageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchItem)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.label1.Size = new System.Drawing.Size(155, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search Item";
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
            // dataGridViewSearchItem
            // 
            this.dataGridViewSearchItem.AllowUserToAddRows = false;
            this.dataGridViewSearchItem.AllowUserToDeleteRows = false;
            this.dataGridViewSearchItem.AllowUserToResizeRows = false;
            this.dataGridViewSearchItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSearchItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSearchItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSearchItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSearchItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSearchInventoryId,
            this.ColumnSearchInventoryItemId,
            this.ColumnSearchInventoryItemBarCode,
            this.ColumnSearchInventoryItemDescription,
            this.ColumnSearchInventoryItemInventoryCode,
            this.ColumnSearchInventoryItemUnitId,
            this.ColumnSearchInventoryItemUnit,
            this.ColumnSearchInventoryItemQuantity,
            this.ColumnSearchInventoryItemButtonPick});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSearchItem.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewSearchItem.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewSearchItem.MultiSelect = false;
            this.dataGridViewSearchItem.Name = "dataGridViewSearchItem";
            this.dataGridViewSearchItem.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSearchItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewSearchItem.RowHeadersVisible = false;
            this.dataGridViewSearchItem.RowTemplate.Height = 24;
            this.dataGridViewSearchItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSearchItem.Size = new System.Drawing.Size(958, 439);
            this.dataGridViewSearchItem.TabIndex = 6;
            this.dataGridViewSearchItem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSearchItem_CellClick);
            // 
            // ColumnSearchInventoryId
            // 
            this.ColumnSearchInventoryId.DataPropertyName = "ColumnSearchInventoryId";
            this.ColumnSearchInventoryId.HeaderText = "Id";
            this.ColumnSearchInventoryId.Name = "ColumnSearchInventoryId";
            this.ColumnSearchInventoryId.ReadOnly = true;
            this.ColumnSearchInventoryId.Visible = false;
            // 
            // ColumnSearchInventoryItemId
            // 
            this.ColumnSearchInventoryItemId.DataPropertyName = "ColumnSearchInventoryItemId";
            this.ColumnSearchInventoryItemId.HeaderText = "ItemId";
            this.ColumnSearchInventoryItemId.Name = "ColumnSearchInventoryItemId";
            this.ColumnSearchInventoryItemId.ReadOnly = true;
            this.ColumnSearchInventoryItemId.Visible = false;
            // 
            // ColumnSearchInventoryItemBarCode
            // 
            this.ColumnSearchInventoryItemBarCode.DataPropertyName = "ColumnSearchInventoryItemBarCode";
            this.ColumnSearchInventoryItemBarCode.HeaderText = "Barcode";
            this.ColumnSearchInventoryItemBarCode.Name = "ColumnSearchInventoryItemBarCode";
            this.ColumnSearchInventoryItemBarCode.ReadOnly = true;
            this.ColumnSearchInventoryItemBarCode.Width = 150;
            // 
            // ColumnSearchInventoryItemDescription
            // 
            this.ColumnSearchInventoryItemDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSearchInventoryItemDescription.DataPropertyName = "ColumnSearchInventoryItemDescription";
            this.ColumnSearchInventoryItemDescription.HeaderText = "Item Description";
            this.ColumnSearchInventoryItemDescription.Name = "ColumnSearchInventoryItemDescription";
            this.ColumnSearchInventoryItemDescription.ReadOnly = true;
            // 
            // ColumnSearchInventoryItemInventoryCode
            // 
            this.ColumnSearchInventoryItemInventoryCode.DataPropertyName = "ColumnSearchInventoryItemInventoryCode";
            this.ColumnSearchInventoryItemInventoryCode.HeaderText = "Inventory Code";
            this.ColumnSearchInventoryItemInventoryCode.Name = "ColumnSearchInventoryItemInventoryCode";
            this.ColumnSearchInventoryItemInventoryCode.ReadOnly = true;
            this.ColumnSearchInventoryItemInventoryCode.Width = 150;
            // 
            // ColumnSearchInventoryItemUnitId
            // 
            this.ColumnSearchInventoryItemUnitId.DataPropertyName = "ColumnSearchInventoryItemUnitId";
            this.ColumnSearchInventoryItemUnitId.HeaderText = "UnitId";
            this.ColumnSearchInventoryItemUnitId.Name = "ColumnSearchInventoryItemUnitId";
            this.ColumnSearchInventoryItemUnitId.ReadOnly = true;
            this.ColumnSearchInventoryItemUnitId.Visible = false;
            // 
            // ColumnSearchInventoryItemUnit
            // 
            this.ColumnSearchInventoryItemUnit.DataPropertyName = "ColumnSearchInventoryItemUnit";
            this.ColumnSearchInventoryItemUnit.HeaderText = "Unit";
            this.ColumnSearchInventoryItemUnit.Name = "ColumnSearchInventoryItemUnit";
            this.ColumnSearchInventoryItemUnit.ReadOnly = true;
            // 
            // ColumnSearchInventoryItemQuantity
            // 
            this.ColumnSearchInventoryItemQuantity.DataPropertyName = "ColumnSearchInventoryItemQuantity";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnSearchInventoryItemQuantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnSearchInventoryItemQuantity.HeaderText = "Quantity";
            this.ColumnSearchInventoryItemQuantity.Name = "ColumnSearchInventoryItemQuantity";
            this.ColumnSearchInventoryItemQuantity.ReadOnly = true;
            // 
            // ColumnSearchInventoryItemButtonPick
            // 
            this.ColumnSearchInventoryItemButtonPick.DataPropertyName = "ColumnSearchInventoryItemButtonPick";
            this.ColumnSearchInventoryItemButtonPick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnSearchInventoryItemButtonPick.HeaderText = "Pick";
            this.ColumnSearchInventoryItemButtonPick.Name = "ColumnSearchInventoryItemButtonPick";
            this.ColumnSearchInventoryItemButtonPick.ReadOnly = true;
            this.ColumnSearchInventoryItemButtonPick.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSearchInventoryItemButtonPick.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnSearchInventoryItemButtonPick.Width = 70;
            // 
            // textBoxSearchItemFilter
            // 
            this.textBoxSearchItemFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearchItemFilter.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxSearchItemFilter.Location = new System.Drawing.Point(12, 6);
            this.textBoxSearchItemFilter.Name = "textBoxSearchItemFilter";
            this.textBoxSearchItemFilter.Size = new System.Drawing.Size(958, 30);
            this.textBoxSearchItemFilter.TabIndex = 0;
            this.textBoxSearchItemFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearchItemFilter_KeyDown);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonSearchItemPageListFirst);
            this.panel3.Controls.Add(this.buttonSearchItemPageListPrevious);
            this.panel3.Controls.Add(this.buttonSearchItemPageListNext);
            this.panel3.Controls.Add(this.buttonSearchItemPageListLast);
            this.panel3.Controls.Add(this.textBoxSearchItemPageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 487);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(982, 53);
            this.panel3.TabIndex = 19;
            // 
            // buttonSearchItemPageListFirst
            // 
            this.buttonSearchItemPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSearchItemPageListFirst.Enabled = false;
            this.buttonSearchItemPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonSearchItemPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchItemPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSearchItemPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonSearchItemPageListFirst.Name = "buttonSearchItemPageListFirst";
            this.buttonSearchItemPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonSearchItemPageListFirst.TabIndex = 13;
            this.buttonSearchItemPageListFirst.Text = "First";
            this.buttonSearchItemPageListFirst.UseVisualStyleBackColor = false;
            this.buttonSearchItemPageListFirst.Click += new System.EventHandler(this.buttonSearchItemPageListFirst_Click);
            // 
            // buttonSearchItemPageListPrevious
            // 
            this.buttonSearchItemPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSearchItemPageListPrevious.Enabled = false;
            this.buttonSearchItemPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonSearchItemPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchItemPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSearchItemPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonSearchItemPageListPrevious.Name = "buttonSearchItemPageListPrevious";
            this.buttonSearchItemPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonSearchItemPageListPrevious.TabIndex = 14;
            this.buttonSearchItemPageListPrevious.Text = "Previous";
            this.buttonSearchItemPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonSearchItemPageListPrevious.Click += new System.EventHandler(this.buttonSearchItemPageListPrevious_Click);
            // 
            // buttonSearchItemPageListNext
            // 
            this.buttonSearchItemPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSearchItemPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonSearchItemPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchItemPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSearchItemPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonSearchItemPageListNext.Name = "buttonSearchItemPageListNext";
            this.buttonSearchItemPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonSearchItemPageListNext.TabIndex = 15;
            this.buttonSearchItemPageListNext.Text = "Next";
            this.buttonSearchItemPageListNext.UseVisualStyleBackColor = false;
            this.buttonSearchItemPageListNext.Click += new System.EventHandler(this.buttonSearchItemPageListNext_Click);
            // 
            // buttonSearchItemPageListLast
            // 
            this.buttonSearchItemPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSearchItemPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonSearchItemPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchItemPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSearchItemPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonSearchItemPageListLast.Name = "buttonSearchItemPageListLast";
            this.buttonSearchItemPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonSearchItemPageListLast.TabIndex = 16;
            this.buttonSearchItemPageListLast.Text = "Last";
            this.buttonSearchItemPageListLast.UseVisualStyleBackColor = false;
            this.buttonSearchItemPageListLast.Click += new System.EventHandler(this.buttonSearchItemPageListLast_Click);
            // 
            // textBoxSearchItemPageNumber
            // 
            this.textBoxSearchItemPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSearchItemPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxSearchItemPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSearchItemPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxSearchItemPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxSearchItemPageNumber.Name = "textBoxSearchItemPageNumber";
            this.textBoxSearchItemPageNumber.ReadOnly = true;
            this.textBoxSearchItemPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxSearchItemPageNumber.TabIndex = 17;
            this.textBoxSearchItemPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.textBoxSearchItemFilter);
            this.panel2.Controls.Add(this.dataGridViewSearchItem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(982, 540);
            this.panel2.TabIndex = 10;
            // 
            // TrnStockTransferDetailSearchItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(982, 603);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrnStockTransferDetailSearchItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Item";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchItem)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.DataGridView dataGridViewSearchItem;
        private System.Windows.Forms.TextBox textBoxSearchItemFilter;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonSearchItemPageListFirst;
        private System.Windows.Forms.Button buttonSearchItemPageListPrevious;
        private System.Windows.Forms.Button buttonSearchItemPageListNext;
        private System.Windows.Forms.Button buttonSearchItemPageListLast;
        private System.Windows.Forms.TextBox textBoxSearchItemPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchInventoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchInventoryItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchInventoryItemBarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchInventoryItemDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchInventoryItemInventoryCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchInventoryItemUnitId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchInventoryItemUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchInventoryItemQuantity;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnSearchInventoryItemButtonPick;
    }
}