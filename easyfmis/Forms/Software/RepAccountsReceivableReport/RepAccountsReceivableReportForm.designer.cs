﻿namespace easyfmis.Forms.Software.RepAccountsReceivableReport
{
    partial class RepAccountsReceivableReportForm
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
            this.listBoxAccountsReceivableReport = new System.Windows.Forms.ListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.comboBoxSoldBy = new System.Windows.Forms.ComboBox();
            this.labelSoldBy = new System.Windows.Forms.Label();
            this.comboBoxCustomer = new System.Windows.Forms.ComboBox();
            this.labelCustomer = new System.Windows.Forms.Label();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.comboBoxBranch = new System.Windows.Forms.ComboBox();
            this.labelBranch = new System.Windows.Forms.Label();
            this.comboBoxCompany = new System.Windows.Forms.ComboBox();
            this.labelCompany = new System.Windows.Forms.Label();
            this.dateTimePickerDateAsOf = new System.Windows.Forms.DateTimePicker();
            this.labelDateAsOf = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonView = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.comboBoxItemCode = new System.Windows.Forms.ComboBox();
            this.labelItemCode = new System.Windows.Forms.Label();
            this.comboBoxItem = new System.Windows.Forms.ComboBox();
            this.labelItem = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxAccountsReceivableReport
            // 
            this.listBoxAccountsReceivableReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxAccountsReceivableReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxAccountsReceivableReport.FormattingEnabled = true;
            this.listBoxAccountsReceivableReport.ItemHeight = 19;
            this.listBoxAccountsReceivableReport.Items.AddRange(new object[] {
            "Accounts Receivable Report",
            "Statement of Account",
            "",
            "Sales Order Detail Report",
            "Sales Invoice Detail Report",
            "Collection Detail Report"});
            this.listBoxAccountsReceivableReport.Location = new System.Drawing.Point(0, 0);
            this.listBoxAccountsReceivableReport.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxAccountsReceivableReport.Name = "listBoxAccountsReceivableReport";
            this.listBoxAccountsReceivableReport.Size = new System.Drawing.Size(304, 495);
            this.listBoxAccountsReceivableReport.TabIndex = 4;
            this.listBoxAccountsReceivableReport.SelectedIndexChanged += new System.EventHandler(this.listBoxSalesReport_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.comboBoxItemCode);
            this.panel4.Controls.Add(this.labelItemCode);
            this.panel4.Controls.Add(this.comboBoxItem);
            this.panel4.Controls.Add(this.labelItem);
            this.panel4.Controls.Add(this.comboBoxSoldBy);
            this.panel4.Controls.Add(this.labelSoldBy);
            this.panel4.Controls.Add(this.comboBoxCustomer);
            this.panel4.Controls.Add(this.labelCustomer);
            this.panel4.Controls.Add(this.dateTimePickerEndDate);
            this.panel4.Controls.Add(this.labelEndDate);
            this.panel4.Controls.Add(this.dateTimePickerStartDate);
            this.panel4.Controls.Add(this.labelStartDate);
            this.panel4.Controls.Add(this.comboBoxBranch);
            this.panel4.Controls.Add(this.labelBranch);
            this.panel4.Controls.Add(this.comboBoxCompany);
            this.panel4.Controls.Add(this.labelCompany);
            this.panel4.Controls.Add(this.dateTimePickerDateAsOf);
            this.panel4.Controls.Add(this.labelDateAsOf);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 50);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1027, 510);
            this.panel4.TabIndex = 10;
            // 
            // comboBoxSoldBy
            // 
            this.comboBoxSoldBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxSoldBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxSoldBy.FormattingEnabled = true;
            this.comboBoxSoldBy.Location = new System.Drawing.Point(403, 223);
            this.comboBoxSoldBy.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxSoldBy.Name = "comboBoxSoldBy";
            this.comboBoxSoldBy.Size = new System.Drawing.Size(334, 27);
            this.comboBoxSoldBy.TabIndex = 17;
            this.comboBoxSoldBy.Visible = false;
            // 
            // labelSoldBy
            // 
            this.labelSoldBy.AutoSize = true;
            this.labelSoldBy.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.labelSoldBy.Location = new System.Drawing.Point(342, 226);
            this.labelSoldBy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSoldBy.Name = "labelSoldBy";
            this.labelSoldBy.Size = new System.Drawing.Size(57, 19);
            this.labelSoldBy.TabIndex = 41;
            this.labelSoldBy.Text = "Sold By:";
            this.labelSoldBy.Visible = false;
            // 
            // comboBoxCustomer
            // 
            this.comboBoxCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCustomer.FormattingEnabled = true;
            this.comboBoxCustomer.Location = new System.Drawing.Point(403, 192);
            this.comboBoxCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new System.Drawing.Size(334, 27);
            this.comboBoxCustomer.TabIndex = 16;
            this.comboBoxCustomer.Visible = false;
            // 
            // labelCustomer
            // 
            this.labelCustomer.AutoSize = true;
            this.labelCustomer.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.labelCustomer.Location = new System.Drawing.Point(328, 195);
            this.labelCustomer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new System.Drawing.Size(72, 19);
            this.labelCustomer.TabIndex = 39;
            this.labelCustomer.Text = "Customer:";
            this.labelCustomer.Visible = false;
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(403, 70);
            this.dateTimePickerEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(177, 26);
            this.dateTimePickerEndDate.TabIndex = 12;
            this.dateTimePickerEndDate.Visible = false;
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.labelEndDate.Location = new System.Drawing.Point(331, 74);
            this.labelEndDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(68, 19);
            this.labelEndDate.TabIndex = 37;
            this.labelEndDate.Text = "End Date:";
            this.labelEndDate.Visible = false;
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(403, 40);
            this.dateTimePickerStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(177, 26);
            this.dateTimePickerStartDate.TabIndex = 11;
            this.dateTimePickerStartDate.Visible = false;
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.labelStartDate.Location = new System.Drawing.Point(326, 44);
            this.labelStartDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(74, 19);
            this.labelStartDate.TabIndex = 35;
            this.labelStartDate.Text = "Start Date:";
            this.labelStartDate.Visible = false;
            // 
            // comboBoxBranch
            // 
            this.comboBoxBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxBranch.FormattingEnabled = true;
            this.comboBoxBranch.Location = new System.Drawing.Point(403, 161);
            this.comboBoxBranch.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxBranch.Name = "comboBoxBranch";
            this.comboBoxBranch.Size = new System.Drawing.Size(334, 27);
            this.comboBoxBranch.TabIndex = 15;
            this.comboBoxBranch.Visible = false;
            // 
            // labelBranch
            // 
            this.labelBranch.AutoSize = true;
            this.labelBranch.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.labelBranch.Location = new System.Drawing.Point(345, 164);
            this.labelBranch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBranch.Name = "labelBranch";
            this.labelBranch.Size = new System.Drawing.Size(54, 19);
            this.labelBranch.TabIndex = 33;
            this.labelBranch.Text = "Branch:";
            this.labelBranch.Visible = false;
            // 
            // comboBoxCompany
            // 
            this.comboBoxCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCompany.FormattingEnabled = true;
            this.comboBoxCompany.Location = new System.Drawing.Point(403, 130);
            this.comboBoxCompany.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxCompany.Name = "comboBoxCompany";
            this.comboBoxCompany.Size = new System.Drawing.Size(334, 27);
            this.comboBoxCompany.TabIndex = 14;
            this.comboBoxCompany.Visible = false;
            // 
            // labelCompany
            // 
            this.labelCompany.AutoSize = true;
            this.labelCompany.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.labelCompany.Location = new System.Drawing.Point(329, 133);
            this.labelCompany.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCompany.Name = "labelCompany";
            this.labelCompany.Size = new System.Drawing.Size(71, 19);
            this.labelCompany.TabIndex = 32;
            this.labelCompany.Text = "Company:";
            this.labelCompany.Visible = false;
            // 
            // dateTimePickerDateAsOf
            // 
            this.dateTimePickerDateAsOf.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDateAsOf.Location = new System.Drawing.Point(403, 100);
            this.dateTimePickerDateAsOf.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerDateAsOf.Name = "dateTimePickerDateAsOf";
            this.dateTimePickerDateAsOf.Size = new System.Drawing.Size(177, 26);
            this.dateTimePickerDateAsOf.TabIndex = 13;
            this.dateTimePickerDateAsOf.Visible = false;
            // 
            // labelDateAsOf
            // 
            this.labelDateAsOf.AutoSize = true;
            this.labelDateAsOf.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.labelDateAsOf.Location = new System.Drawing.Point(326, 104);
            this.labelDateAsOf.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDateAsOf.Name = "labelDateAsOf";
            this.labelDateAsOf.Size = new System.Drawing.Size(74, 19);
            this.labelDateAsOf.TabIndex = 31;
            this.labelDateAsOf.Text = "Date as of:";
            this.labelDateAsOf.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.listBoxAccountsReceivableReport);
            this.panel2.Location = new System.Drawing.Point(10, 5);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(304, 495);
            this.panel2.TabIndex = 22;
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
            this.label1.Size = new System.Drawing.Size(278, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Accounts Receivable Report";
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
            // comboBoxItemCode
            // 
            this.comboBoxItemCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxItemCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxItemCode.FormattingEnabled = true;
            this.comboBoxItemCode.Location = new System.Drawing.Point(403, 286);
            this.comboBoxItemCode.Name = "comboBoxItemCode";
            this.comboBoxItemCode.Size = new System.Drawing.Size(334, 27);
            this.comboBoxItemCode.TabIndex = 19;
            this.comboBoxItemCode.Visible = false;
            // 
            // labelItemCode
            // 
            this.labelItemCode.AutoSize = true;
            this.labelItemCode.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.labelItemCode.Location = new System.Drawing.Point(323, 289);
            this.labelItemCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelItemCode.Name = "labelItemCode";
            this.labelItemCode.Size = new System.Drawing.Size(76, 19);
            this.labelItemCode.TabIndex = 45;
            this.labelItemCode.Text = "Item Code:";
            this.labelItemCode.Visible = false;
            // 
            // comboBoxItem
            // 
            this.comboBoxItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxItem.FormattingEnabled = true;
            this.comboBoxItem.Location = new System.Drawing.Point(403, 254);
            this.comboBoxItem.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxItem.Name = "comboBoxItem";
            this.comboBoxItem.Size = new System.Drawing.Size(334, 27);
            this.comboBoxItem.TabIndex = 18;
            this.comboBoxItem.Visible = false;
            // 
            // labelItem
            // 
            this.labelItem.AutoSize = true;
            this.labelItem.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.labelItem.Location = new System.Drawing.Point(358, 257);
            this.labelItem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelItem.Name = "labelItem";
            this.labelItem.Size = new System.Drawing.Size(40, 19);
            this.labelItem.TabIndex = 44;
            this.labelItem.Text = "Item:";
            this.labelItem.Visible = false;
            // 
            // RepAccountsReceivableReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1027, 560);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RepAccountsReceivableReportForm";
            this.Text = "RepAccountsReceivableReportForm";
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

        private System.Windows.Forms.ListBox listBoxAccountsReceivableReport;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonView;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ComboBox comboBoxBranch;
        private System.Windows.Forms.Label labelBranch;
        private System.Windows.Forms.ComboBox comboBoxCompany;
        private System.Windows.Forms.Label labelCompany;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateAsOf;
        private System.Windows.Forms.Label labelDateAsOf;
        private System.Windows.Forms.ComboBox comboBoxCustomer;
        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.ComboBox comboBoxSoldBy;
        private System.Windows.Forms.Label labelSoldBy;
        private System.Windows.Forms.ComboBox comboBoxItemCode;
        private System.Windows.Forms.Label labelItemCode;
        private System.Windows.Forms.ComboBox comboBoxItem;
        private System.Windows.Forms.Label labelItem;
    }
}