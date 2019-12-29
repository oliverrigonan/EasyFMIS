namespace easyfmis.Forms.Software.TrnSalesInvoice
{
    partial class TrnSalesInvoiceDetailSalesInvoiceItemDetailPriceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnSalesInvoiceDetailSalesInvoiceItemDetailPriceForm));
            this.dataGridViewItemPriceList = new System.Windows.Forms.DataGridView();
            this.ColumnItemPriceListButtonPick = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnItemPriceListPriceDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemPriceListPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.buttonItemPriceListPageListFirst = new System.Windows.Forms.Button();
            this.buttonItemPriceListPageListPrevious = new System.Windows.Forms.Button();
            this.buttonItemPriceListPageListNext = new System.Windows.Forms.Button();
            this.buttonItemPriceListPageListLast = new System.Windows.Forms.Button();
            this.textBoxItemPriceListPageNumber = new System.Windows.Forms.TextBox();
            this.textBoxItemDescription = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemPriceList)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel15.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewItemPriceList
            // 
            this.dataGridViewItemPriceList.AllowUserToAddRows = false;
            this.dataGridViewItemPriceList.AllowUserToDeleteRows = false;
            this.dataGridViewItemPriceList.AllowUserToResizeRows = false;
            this.dataGridViewItemPriceList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewItemPriceList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewItemPriceList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewItemPriceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItemPriceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnItemPriceListButtonPick,
            this.ColumnItemPriceListPriceDescription,
            this.ColumnItemPriceListPrice});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewItemPriceList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewItemPriceList.Location = new System.Drawing.Point(12, 44);
            this.dataGridViewItemPriceList.MultiSelect = false;
            this.dataGridViewItemPriceList.Name = "dataGridViewItemPriceList";
            this.dataGridViewItemPriceList.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewItemPriceList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewItemPriceList.RowHeadersVisible = false;
            this.dataGridViewItemPriceList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.dataGridViewItemPriceList.RowTemplate.Height = 24;
            this.dataGridViewItemPriceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewItemPriceList.Size = new System.Drawing.Size(651, 210);
            this.dataGridViewItemPriceList.TabIndex = 25;
            this.dataGridViewItemPriceList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewItemPriceList_CellClick);
            // 
            // ColumnItemPriceListButtonPick
            // 
            this.ColumnItemPriceListButtonPick.DataPropertyName = "ColumnItemPriceListButtonPick";
            this.ColumnItemPriceListButtonPick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnItemPriceListButtonPick.HeaderText = "";
            this.ColumnItemPriceListButtonPick.Name = "ColumnItemPriceListButtonPick";
            this.ColumnItemPriceListButtonPick.ReadOnly = true;
            this.ColumnItemPriceListButtonPick.Width = 70;
            // 
            // ColumnItemPriceListPriceDescription
            // 
            this.ColumnItemPriceListPriceDescription.DataPropertyName = "ColumnItemPriceListPriceDescription";
            this.ColumnItemPriceListPriceDescription.HeaderText = "Price Description";
            this.ColumnItemPriceListPriceDescription.Name = "ColumnItemPriceListPriceDescription";
            this.ColumnItemPriceListPriceDescription.ReadOnly = true;
            this.ColumnItemPriceListPriceDescription.Width = 250;
            // 
            // ColumnItemPriceListPrice
            // 
            this.ColumnItemPriceListPrice.DataPropertyName = "ColumnItemPriceListPrice";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnItemPriceListPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnItemPriceListPrice.HeaderText = "Price";
            this.ColumnItemPriceListPrice.Name = "ColumnItemPriceListPrice";
            this.ColumnItemPriceListPrice.ReadOnly = true;
            this.ColumnItemPriceListPrice.Width = 150;
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
            this.panel1.Size = new System.Drawing.Size(675, 63);
            this.panel1.TabIndex = 8;
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
            this.label1.Size = new System.Drawing.Size(183, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Item Price List";
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
            this.buttonClose.Location = new System.Drawing.Point(575, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(88, 40);
            this.buttonClose.TabIndex = 20;
            this.buttonClose.TabStop = false;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel15);
            this.panel2.Controls.Add(this.dataGridViewItemPriceList);
            this.panel2.Controls.Add(this.textBoxItemDescription);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(675, 313);
            this.panel2.TabIndex = 9;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.White;
            this.panel15.Controls.Add(this.buttonItemPriceListPageListFirst);
            this.panel15.Controls.Add(this.buttonItemPriceListPageListPrevious);
            this.panel15.Controls.Add(this.buttonItemPriceListPageListNext);
            this.panel15.Controls.Add(this.buttonItemPriceListPageListLast);
            this.panel15.Controls.Add(this.textBoxItemPriceListPageNumber);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel15.Location = new System.Drawing.Point(0, 260);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(675, 53);
            this.panel15.TabIndex = 26;
            // 
            // buttonItemPriceListPageListFirst
            // 
            this.buttonItemPriceListPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonItemPriceListPageListFirst.Enabled = false;
            this.buttonItemPriceListPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonItemPriceListPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItemPriceListPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonItemPriceListPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonItemPriceListPageListFirst.Name = "buttonItemPriceListPageListFirst";
            this.buttonItemPriceListPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonItemPriceListPageListFirst.TabIndex = 13;
            this.buttonItemPriceListPageListFirst.Text = "First";
            this.buttonItemPriceListPageListFirst.UseVisualStyleBackColor = false;
            this.buttonItemPriceListPageListFirst.Click += new System.EventHandler(this.buttonItemPriceListPageListFirst_Click);
            // 
            // buttonItemPriceListPageListPrevious
            // 
            this.buttonItemPriceListPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonItemPriceListPageListPrevious.Enabled = false;
            this.buttonItemPriceListPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonItemPriceListPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItemPriceListPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonItemPriceListPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonItemPriceListPageListPrevious.Name = "buttonItemPriceListPageListPrevious";
            this.buttonItemPriceListPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonItemPriceListPageListPrevious.TabIndex = 14;
            this.buttonItemPriceListPageListPrevious.Text = "Previous";
            this.buttonItemPriceListPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonItemPriceListPageListPrevious.Click += new System.EventHandler(this.buttonItemPriceListPageListPrevious_Click);
            // 
            // buttonItemPriceListPageListNext
            // 
            this.buttonItemPriceListPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonItemPriceListPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonItemPriceListPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItemPriceListPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonItemPriceListPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonItemPriceListPageListNext.Name = "buttonItemPriceListPageListNext";
            this.buttonItemPriceListPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonItemPriceListPageListNext.TabIndex = 15;
            this.buttonItemPriceListPageListNext.Text = "Next";
            this.buttonItemPriceListPageListNext.UseVisualStyleBackColor = false;
            this.buttonItemPriceListPageListNext.Click += new System.EventHandler(this.buttonItemPriceListPageListNext_Click);
            // 
            // buttonItemPriceListPageListLast
            // 
            this.buttonItemPriceListPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonItemPriceListPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonItemPriceListPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItemPriceListPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonItemPriceListPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonItemPriceListPageListLast.Name = "buttonItemPriceListPageListLast";
            this.buttonItemPriceListPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonItemPriceListPageListLast.TabIndex = 16;
            this.buttonItemPriceListPageListLast.Text = "Last";
            this.buttonItemPriceListPageListLast.UseVisualStyleBackColor = false;
            this.buttonItemPriceListPageListLast.Click += new System.EventHandler(this.buttonItemPriceListPageListLast_Click);
            // 
            // textBoxItemPriceListPageNumber
            // 
            this.textBoxItemPriceListPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxItemPriceListPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxItemPriceListPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxItemPriceListPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxItemPriceListPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxItemPriceListPageNumber.Name = "textBoxItemPriceListPageNumber";
            this.textBoxItemPriceListPageNumber.ReadOnly = true;
            this.textBoxItemPriceListPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxItemPriceListPageNumber.TabIndex = 17;
            this.textBoxItemPriceListPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxItemDescription
            // 
            this.textBoxItemDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxItemDescription.BackColor = System.Drawing.Color.White;
            this.textBoxItemDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxItemDescription.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.textBoxItemDescription.Location = new System.Drawing.Point(12, 6);
            this.textBoxItemDescription.Name = "textBoxItemDescription";
            this.textBoxItemDescription.ReadOnly = true;
            this.textBoxItemDescription.Size = new System.Drawing.Size(651, 32);
            this.textBoxItemDescription.TabIndex = 7;
            this.textBoxItemDescription.TabStop = false;
            this.textBoxItemDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrnSalesInvoiceDetailSalesInvoiceItemDetailPriceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 376);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TrnSalesInvoiceDetailSalesInvoiceItemDetailPriceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Price List";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemPriceList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewItemPriceList;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnItemPriceListButtonPick;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemPriceListPriceDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemPriceListPrice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Button buttonItemPriceListPageListFirst;
        private System.Windows.Forms.Button buttonItemPriceListPageListPrevious;
        private System.Windows.Forms.Button buttonItemPriceListPageListNext;
        private System.Windows.Forms.Button buttonItemPriceListPageListLast;
        private System.Windows.Forms.TextBox textBoxItemPriceListPageNumber;
        private System.Windows.Forms.TextBox textBoxItemDescription;
    }
}