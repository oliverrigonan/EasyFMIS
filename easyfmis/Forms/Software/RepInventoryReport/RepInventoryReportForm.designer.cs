namespace easyfmis.Forms.Software.RepInventoryReport
{
    partial class RepInventoryReportForm
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
            this.listBoxInventoryReport = new System.Windows.Forms.ListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.comboBoxItemCode = new System.Windows.Forms.ComboBox();
            this.labelItemCode = new System.Windows.Forms.Label();
            this.comboBoxItem = new System.Windows.Forms.ComboBox();
            this.labelItem = new System.Windows.Forms.Label();
            this.comboBoxBranch = new System.Windows.Forms.ComboBox();
            this.labelBranch = new System.Windows.Forms.Label();
            this.comboBoxCompany = new System.Windows.Forms.ComboBox();
            this.labelCompany = new System.Windows.Forms.Label();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonView = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxInventoryReport
            // 
            this.listBoxInventoryReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxInventoryReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxInventoryReport.FormattingEnabled = true;
            this.listBoxInventoryReport.ItemHeight = 19;
            this.listBoxInventoryReport.Items.AddRange(new object[] {
            "Inventory Report",
            "Stock Card",
            "",
            "Stock-In Detail Report",
            "Stock-In Sales Return Detail Report",
            "Stock-Out Detail Report",
            "Stock Transfer Detail Report",
            " ",
            "Item List"});
            this.listBoxInventoryReport.Location = new System.Drawing.Point(0, 0);
            this.listBoxInventoryReport.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxInventoryReport.Name = "listBoxInventoryReport";
            this.listBoxInventoryReport.Size = new System.Drawing.Size(304, 495);
            this.listBoxInventoryReport.TabIndex = 4;
            this.listBoxInventoryReport.SelectedIndexChanged += new System.EventHandler(this.listBoxSalesReport_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.comboBoxItemCode);
            this.panel4.Controls.Add(this.labelItemCode);
            this.panel4.Controls.Add(this.comboBoxItem);
            this.panel4.Controls.Add(this.labelItem);
            this.panel4.Controls.Add(this.comboBoxBranch);
            this.panel4.Controls.Add(this.labelBranch);
            this.panel4.Controls.Add(this.comboBoxCompany);
            this.panel4.Controls.Add(this.labelCompany);
            this.panel4.Controls.Add(this.dateTimePickerStartDate);
            this.panel4.Controls.Add(this.labelStartDate);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.dateTimePickerEndDate);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.labelEndDate);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 50);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1027, 510);
            this.panel4.TabIndex = 10;
            // 
            // comboBoxItemCode
            // 
            this.comboBoxItemCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxItemCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxItemCode.FormattingEnabled = true;
            this.comboBoxItemCode.Location = new System.Drawing.Point(405, 194);
            this.comboBoxItemCode.Name = "comboBoxItemCode";
            this.comboBoxItemCode.Size = new System.Drawing.Size(334, 27);
            this.comboBoxItemCode.TabIndex = 5;
            this.comboBoxItemCode.Visible = false;
            this.comboBoxItemCode.SelectedIndexChanged += new System.EventHandler(this.comboBoxItemCode_SelectedIndexChanged);
            // 
            // labelItemCode
            // 
            this.labelItemCode.AutoSize = true;
            this.labelItemCode.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.labelItemCode.Location = new System.Drawing.Point(325, 197);
            this.labelItemCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelItemCode.Name = "labelItemCode";
            this.labelItemCode.Size = new System.Drawing.Size(76, 19);
            this.labelItemCode.TabIndex = 31;
            this.labelItemCode.Text = "Item Code:";
            this.labelItemCode.Visible = false;
            // 
            // comboBoxItem
            // 
            this.comboBoxItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxItem.FormattingEnabled = true;
            this.comboBoxItem.Location = new System.Drawing.Point(405, 162);
            this.comboBoxItem.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxItem.Name = "comboBoxItem";
            this.comboBoxItem.Size = new System.Drawing.Size(334, 27);
            this.comboBoxItem.TabIndex = 4;
            this.comboBoxItem.Visible = false;
            this.comboBoxItem.SelectedIndexChanged += new System.EventHandler(this.comboBoxItem_SelectedIndexChanged);
            // 
            // labelItem
            // 
            this.labelItem.AutoSize = true;
            this.labelItem.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.labelItem.Location = new System.Drawing.Point(360, 165);
            this.labelItem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelItem.Name = "labelItem";
            this.labelItem.Size = new System.Drawing.Size(40, 19);
            this.labelItem.TabIndex = 29;
            this.labelItem.Text = "Item:";
            this.labelItem.Visible = false;
            // 
            // comboBoxBranch
            // 
            this.comboBoxBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxBranch.FormattingEnabled = true;
            this.comboBoxBranch.Location = new System.Drawing.Point(405, 131);
            this.comboBoxBranch.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxBranch.Name = "comboBoxBranch";
            this.comboBoxBranch.Size = new System.Drawing.Size(334, 27);
            this.comboBoxBranch.TabIndex = 3;
            this.comboBoxBranch.Visible = false;
            // 
            // labelBranch
            // 
            this.labelBranch.AutoSize = true;
            this.labelBranch.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.labelBranch.Location = new System.Drawing.Point(347, 134);
            this.labelBranch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBranch.Name = "labelBranch";
            this.labelBranch.Size = new System.Drawing.Size(54, 19);
            this.labelBranch.TabIndex = 27;
            this.labelBranch.Text = "Branch:";
            this.labelBranch.Visible = false;
            // 
            // comboBoxCompany
            // 
            this.comboBoxCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCompany.FormattingEnabled = true;
            this.comboBoxCompany.Location = new System.Drawing.Point(405, 100);
            this.comboBoxCompany.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxCompany.Name = "comboBoxCompany";
            this.comboBoxCompany.Size = new System.Drawing.Size(334, 27);
            this.comboBoxCompany.TabIndex = 2;
            this.comboBoxCompany.Visible = false;
            this.comboBoxCompany.SelectedIndexChanged += new System.EventHandler(this.comboBoxCompany_SelectedIndexChanged);
            // 
            // labelCompany
            // 
            this.labelCompany.AutoSize = true;
            this.labelCompany.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.labelCompany.Location = new System.Drawing.Point(330, 103);
            this.labelCompany.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCompany.Name = "labelCompany";
            this.labelCompany.Size = new System.Drawing.Size(71, 19);
            this.labelCompany.TabIndex = 25;
            this.labelCompany.Text = "Company:";
            this.labelCompany.Visible = false;
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(405, 40);
            this.dateTimePickerStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(177, 26);
            this.dateTimePickerStartDate.TabIndex = 0;
            this.dateTimePickerStartDate.Visible = false;
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.labelStartDate.Location = new System.Drawing.Point(326, 46);
            this.labelStartDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(74, 19);
            this.labelStartDate.TabIndex = 23;
            this.labelStartDate.Text = "Start Date:";
            this.labelStartDate.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.listBoxInventoryReport);
            this.panel2.Location = new System.Drawing.Point(10, 5);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(304, 495);
            this.panel2.TabIndex = 22;
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(405, 70);
            this.dateTimePickerEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(177, 26);
            this.dateTimePickerEndDate.TabIndex = 1;
            this.dateTimePickerEndDate.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(188)))), ((int)(((byte)(0)))));
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(318, 5);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(699, 30);
            this.panel3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Filters";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.labelEndDate.Location = new System.Drawing.Point(332, 76);
            this.labelEndDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(68, 19);
            this.labelEndDate.TabIndex = 18;
            this.labelEndDate.Text = "End Date:";
            this.labelEndDate.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.buttonView);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1027, 50);
            this.panel1.TabIndex = 9;
            // 
            // buttonView
            // 
            this.buttonView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonView.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonView.FlatAppearance.BorderSize = 0;
            this.buttonView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonView.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonView.ForeColor = System.Drawing.Color.White;
            this.buttonView.Location = new System.Drawing.Point(872, 10);
            this.buttonView.Margin = new System.Windows.Forms.Padding(2);
            this.buttonView.Name = "buttonView";
            this.buttonView.Size = new System.Drawing.Size(70, 32);
            this.buttonView.TabIndex = 20;
            this.buttonView.TabStop = false;
            this.buttonView.Text = "View";
            this.buttonView.UseVisualStyleBackColor = false;
            this.buttonView.Click += new System.EventHandler(this.buttonView_OnClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.Reports;
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
            this.label1.Size = new System.Drawing.Size(175, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Inventory Report";
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
            this.buttonClose.Location = new System.Drawing.Point(947, 10);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(70, 32);
            this.buttonClose.TabIndex = 21;
            this.buttonClose.Text = "Close";
            this.buttonClose.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_OnClick);
            // 
            // RepInventoryReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1027, 560);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RepInventoryReportForm";
            this.Text = "RepInventoryReportForm";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxInventoryReport;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox comboBoxCompany;
        private System.Windows.Forms.Label labelCompany;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonView;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ComboBox comboBoxBranch;
        private System.Windows.Forms.Label labelBranch;
        private System.Windows.Forms.ComboBox comboBoxItem;
        private System.Windows.Forms.Label labelItem;
        private System.Windows.Forms.Label labelItemCode;
        private System.Windows.Forms.ComboBox comboBoxItemCode;
    }
}