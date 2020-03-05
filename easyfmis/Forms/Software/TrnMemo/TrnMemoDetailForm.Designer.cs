namespace easyfmis.Forms.Software.TrnMemo
{
    partial class TrnMemoDetailForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnMemoDetailForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonLock = new System.Windows.Forms.Button();
            this.buttonUnlock = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxArticleType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxArticle = new System.Windows.Forms.ComboBox();
            this.textBoxBranch = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxRemarks = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxApprovedBy = new System.Windows.Forms.ComboBox();
            this.comboBoxCheckedBy = new System.Windows.Forms.ComboBox();
            this.comboBoxPreparedBy = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerMODate = new System.Windows.Forms.DateTimePicker();
            this.textBoxMONumber = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxTotalPOAmount = new System.Windows.Forms.TextBox();
            this.buttonMemoLinePageListFirst = new System.Windows.Forms.Button();
            this.buttonMemoLinePageListPrevious = new System.Windows.Forms.Button();
            this.buttonMemoLinePageListNext = new System.Windows.Forms.Button();
            this.buttonMemoLinePageListLast = new System.Windows.Forms.Button();
            this.textBoxMemoLinePageNumber = new System.Windows.Forms.TextBox();
            this.dataGridViewMemoLine = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageStockOutItems = new System.Windows.Forms.TabPage();
            this.buttonAddMemoLine = new System.Windows.Forms.Button();
            this.ColumnMemoLineListButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnMemoLineListButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnMemoLineListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemoLineListMOId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemoLineListSIId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemoLineListSINumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemoLineListRRId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemoLineListRRNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemoLineListDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemoLineListCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemoLineListParticulars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemoLineListSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMemoLine)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageStockOutItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.buttonLock);
            this.panel1.Controls.Add(this.buttonUnlock);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1400, 63);
            this.panel1.TabIndex = 7;
            // 
            // buttonLock
            // 
            this.buttonLock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonLock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonLock.FlatAppearance.BorderSize = 0;
            this.buttonLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLock.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLock.ForeColor = System.Drawing.Color.White;
            this.buttonLock.Location = new System.Drawing.Point(1112, 12);
            this.buttonLock.Name = "buttonLock";
            this.buttonLock.Size = new System.Drawing.Size(88, 40);
            this.buttonLock.TabIndex = 20;
            this.buttonLock.Text = "Lock";
            this.buttonLock.UseVisualStyleBackColor = false;
            this.buttonLock.Click += new System.EventHandler(this.buttonLock_Click);
            // 
            // buttonUnlock
            // 
            this.buttonUnlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUnlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonUnlock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonUnlock.FlatAppearance.BorderSize = 0;
            this.buttonUnlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUnlock.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUnlock.ForeColor = System.Drawing.Color.White;
            this.buttonUnlock.Location = new System.Drawing.Point(1206, 12);
            this.buttonUnlock.Name = "buttonUnlock";
            this.buttonUnlock.Size = new System.Drawing.Size(88, 40);
            this.buttonUnlock.TabIndex = 21;
            this.buttonUnlock.Text = "Unlock";
            this.buttonUnlock.UseVisualStyleBackColor = false;
            this.buttonUnlock.Click += new System.EventHandler(this.buttonUnlock_Click);
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
            this.label1.Size = new System.Drawing.Size(167, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Memo Detail";
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
            this.buttonClose.TabIndex = 23;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.comboBoxArticleType);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.comboBoxArticle);
            this.panel3.Controls.Add(this.textBoxBranch);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.textBoxRemarks);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.comboBoxApprovedBy);
            this.panel3.Controls.Add(this.comboBoxCheckedBy);
            this.panel3.Controls.Add(this.comboBoxPreparedBy);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.dateTimePickerMODate);
            this.panel3.Controls.Add(this.textBoxMONumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10);
            this.panel3.Size = new System.Drawing.Size(1400, 201);
            this.panel3.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label3.Location = new System.Drawing.Point(46, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 23);
            this.label3.TabIndex = 33;
            this.label3.Text = "Article Type:";
            // 
            // comboBoxArticleType
            // 
            this.comboBoxArticleType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxArticleType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxArticleType.FormattingEnabled = true;
            this.comboBoxArticleType.Location = new System.Drawing.Point(154, 114);
            this.comboBoxArticleType.Name = "comboBoxArticleType";
            this.comboBoxArticleType.Size = new System.Drawing.Size(298, 31);
            this.comboBoxArticleType.TabIndex = 32;
            this.comboBoxArticleType.SelectionChangeCommitted += new System.EventHandler(this.comboBoxArticleType_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label6.Location = new System.Drawing.Point(88, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 23);
            this.label6.TabIndex = 31;
            this.label6.Text = "Name:";
            // 
            // comboBoxArticle
            // 
            this.comboBoxArticle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxArticle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxArticle.FormattingEnabled = true;
            this.comboBoxArticle.Location = new System.Drawing.Point(154, 151);
            this.comboBoxArticle.Name = "comboBoxArticle";
            this.comboBoxArticle.Size = new System.Drawing.Size(298, 31);
            this.comboBoxArticle.TabIndex = 5;
            // 
            // textBoxBranch
            // 
            this.textBoxBranch.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxBranch.Location = new System.Drawing.Point(154, 6);
            this.textBoxBranch.Name = "textBoxBranch";
            this.textBoxBranch.ReadOnly = true;
            this.textBoxBranch.Size = new System.Drawing.Size(298, 30);
            this.textBoxBranch.TabIndex = 0;
            this.textBoxBranch.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label5.Location = new System.Drawing.Point(81, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 23);
            this.label5.TabIndex = 26;
            this.label5.Text = "Branch:";
            // 
            // textBoxRemarks
            // 
            this.textBoxRemarks.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxRemarks.Location = new System.Drawing.Point(597, 117);
            this.textBoxRemarks.Multiline = true;
            this.textBoxRemarks.Name = "textBoxRemarks";
            this.textBoxRemarks.Size = new System.Drawing.Size(298, 77);
            this.textBoxRemarks.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label13.Location = new System.Drawing.Point(480, 85);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 23);
            this.label13.TabIndex = 23;
            this.label13.Text = "Approved by:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label12.Location = new System.Drawing.Point(489, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 23);
            this.label12.TabIndex = 22;
            this.label12.Text = "Checked by:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label11.Location = new System.Drawing.Point(485, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 23);
            this.label11.TabIndex = 21;
            this.label11.Text = "Prepared by:";
            // 
            // comboBoxApprovedBy
            // 
            this.comboBoxApprovedBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxApprovedBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxApprovedBy.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.comboBoxApprovedBy.FormattingEnabled = true;
            this.comboBoxApprovedBy.Location = new System.Drawing.Point(597, 80);
            this.comboBoxApprovedBy.Name = "comboBoxApprovedBy";
            this.comboBoxApprovedBy.Size = new System.Drawing.Size(298, 31);
            this.comboBoxApprovedBy.TabIndex = 11;
            // 
            // comboBoxCheckedBy
            // 
            this.comboBoxCheckedBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxCheckedBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCheckedBy.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.comboBoxCheckedBy.FormattingEnabled = true;
            this.comboBoxCheckedBy.Location = new System.Drawing.Point(597, 43);
            this.comboBoxCheckedBy.Name = "comboBoxCheckedBy";
            this.comboBoxCheckedBy.Size = new System.Drawing.Size(298, 31);
            this.comboBoxCheckedBy.TabIndex = 10;
            // 
            // comboBoxPreparedBy
            // 
            this.comboBoxPreparedBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxPreparedBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPreparedBy.Enabled = false;
            this.comboBoxPreparedBy.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.comboBoxPreparedBy.FormattingEnabled = true;
            this.comboBoxPreparedBy.Location = new System.Drawing.Point(597, 6);
            this.comboBoxPreparedBy.Name = "comboBoxPreparedBy";
            this.comboBoxPreparedBy.Size = new System.Drawing.Size(298, 31);
            this.comboBoxPreparedBy.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label7.Location = new System.Drawing.Point(513, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 23);
            this.label7.TabIndex = 11;
            this.label7.Text = "Remarks:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label4.Location = new System.Drawing.Point(65, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "MO Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label2.Location = new System.Drawing.Point(38, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "MO Number:";
            // 
            // dateTimePickerMODate
            // 
            this.dateTimePickerMODate.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.dateTimePickerMODate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerMODate.Location = new System.Drawing.Point(154, 78);
            this.dateTimePickerMODate.Name = "dateTimePickerMODate";
            this.dateTimePickerMODate.Size = new System.Drawing.Size(196, 30);
            this.dateTimePickerMODate.TabIndex = 2;
            // 
            // textBoxMONumber
            // 
            this.textBoxMONumber.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxMONumber.Location = new System.Drawing.Point(154, 42);
            this.textBoxMONumber.Name = "textBoxMONumber";
            this.textBoxMONumber.ReadOnly = true;
            this.textBoxMONumber.Size = new System.Drawing.Size(196, 30);
            this.textBoxMONumber.TabIndex = 1;
            this.textBoxMONumber.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.textBoxTotalPOAmount);
            this.panel4.Controls.Add(this.buttonMemoLinePageListFirst);
            this.panel4.Controls.Add(this.buttonMemoLinePageListPrevious);
            this.panel4.Controls.Add(this.buttonMemoLinePageListNext);
            this.panel4.Controls.Add(this.buttonMemoLinePageListLast);
            this.panel4.Controls.Add(this.textBoxMemoLinePageNumber);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 344);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1386, 53);
            this.panel4.TabIndex = 25;
            // 
            // textBoxTotalPOAmount
            // 
            this.textBoxTotalPOAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTotalPOAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTotalPOAmount.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotalPOAmount.Location = new System.Drawing.Point(816, 9);
            this.textBoxTotalPOAmount.Name = "textBoxTotalPOAmount";
            this.textBoxTotalPOAmount.Size = new System.Drawing.Size(549, 34);
            this.textBoxTotalPOAmount.TabIndex = 18;
            this.textBoxTotalPOAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonMemoLinePageListFirst
            // 
            this.buttonMemoLinePageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMemoLinePageListFirst.Enabled = false;
            this.buttonMemoLinePageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonMemoLinePageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMemoLinePageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonMemoLinePageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonMemoLinePageListFirst.Name = "buttonMemoLinePageListFirst";
            this.buttonMemoLinePageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonMemoLinePageListFirst.TabIndex = 13;
            this.buttonMemoLinePageListFirst.Text = "First";
            this.buttonMemoLinePageListFirst.UseVisualStyleBackColor = false;
            this.buttonMemoLinePageListFirst.Click += new System.EventHandler(this.buttonMemoLinePageListFirst_Click);
            // 
            // buttonMemoLinePageListPrevious
            // 
            this.buttonMemoLinePageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMemoLinePageListPrevious.Enabled = false;
            this.buttonMemoLinePageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonMemoLinePageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMemoLinePageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonMemoLinePageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonMemoLinePageListPrevious.Name = "buttonMemoLinePageListPrevious";
            this.buttonMemoLinePageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonMemoLinePageListPrevious.TabIndex = 14;
            this.buttonMemoLinePageListPrevious.Text = "Previous";
            this.buttonMemoLinePageListPrevious.UseVisualStyleBackColor = false;
            this.buttonMemoLinePageListPrevious.Click += new System.EventHandler(this.buttonMemoLinePageListPrevious_Click);
            // 
            // buttonMemoLinePageListNext
            // 
            this.buttonMemoLinePageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMemoLinePageListNext.FlatAppearance.BorderSize = 0;
            this.buttonMemoLinePageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMemoLinePageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonMemoLinePageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonMemoLinePageListNext.Name = "buttonMemoLinePageListNext";
            this.buttonMemoLinePageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonMemoLinePageListNext.TabIndex = 15;
            this.buttonMemoLinePageListNext.Text = "Next";
            this.buttonMemoLinePageListNext.UseVisualStyleBackColor = false;
            this.buttonMemoLinePageListNext.Click += new System.EventHandler(this.buttonMemoLinePageListNext_Click);
            // 
            // buttonMemoLinePageListLast
            // 
            this.buttonMemoLinePageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMemoLinePageListLast.FlatAppearance.BorderSize = 0;
            this.buttonMemoLinePageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMemoLinePageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonMemoLinePageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonMemoLinePageListLast.Name = "buttonMemoLinePageListLast";
            this.buttonMemoLinePageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonMemoLinePageListLast.TabIndex = 16;
            this.buttonMemoLinePageListLast.Text = "Last";
            this.buttonMemoLinePageListLast.UseVisualStyleBackColor = false;
            this.buttonMemoLinePageListLast.Click += new System.EventHandler(this.buttonMemoLinePageListLast_Click);
            // 
            // textBoxMemoLinePageNumber
            // 
            this.textBoxMemoLinePageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxMemoLinePageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxMemoLinePageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMemoLinePageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxMemoLinePageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxMemoLinePageNumber.Name = "textBoxMemoLinePageNumber";
            this.textBoxMemoLinePageNumber.ReadOnly = true;
            this.textBoxMemoLinePageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxMemoLinePageNumber.TabIndex = 17;
            this.textBoxMemoLinePageNumber.TabStop = false;
            this.textBoxMemoLinePageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridViewMemoLine
            // 
            this.dataGridViewMemoLine.AllowUserToAddRows = false;
            this.dataGridViewMemoLine.AllowUserToDeleteRows = false;
            this.dataGridViewMemoLine.AllowUserToResizeRows = false;
            this.dataGridViewMemoLine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMemoLine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMemoLine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewMemoLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMemoLine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnMemoLineListButtonEdit,
            this.ColumnMemoLineListButtonDelete,
            this.ColumnMemoLineListId,
            this.ColumnMemoLineListMOId,
            this.ColumnMemoLineListSIId,
            this.ColumnMemoLineListSINumber,
            this.ColumnMemoLineListRRId,
            this.ColumnMemoLineListRRNumber,
            this.ColumnMemoLineListDebit,
            this.ColumnMemoLineListCredit,
            this.ColumnMemoLineListParticulars,
            this.ColumnMemoLineListSpace});
            this.dataGridViewMemoLine.Location = new System.Drawing.Point(8, 52);
            this.dataGridViewMemoLine.MultiSelect = false;
            this.dataGridViewMemoLine.Name = "dataGridViewMemoLine";
            this.dataGridViewMemoLine.ReadOnly = true;
            this.dataGridViewMemoLine.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.dataGridViewMemoLine.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewMemoLine.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.dataGridViewMemoLine.RowTemplate.Height = 24;
            this.dataGridViewMemoLine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMemoLine.Size = new System.Drawing.Size(1376, 286);
            this.dataGridViewMemoLine.TabIndex = 1;
            this.dataGridViewMemoLine.TabStop = false;
            this.dataGridViewMemoLine.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMemoLine_CellClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1400, 637);
            this.panel2.TabIndex = 8;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel6.Controls.Add(this.tabControl1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 201);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1400, 436);
            this.panel6.TabIndex = 27;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageStockOutItems);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1400, 436);
            this.tabControl1.TabIndex = 9;
            this.tabControl1.TabStop = false;
            // 
            // tabPageStockOutItems
            // 
            this.tabPageStockOutItems.Controls.Add(this.buttonAddMemoLine);
            this.tabPageStockOutItems.Controls.Add(this.panel4);
            this.tabPageStockOutItems.Controls.Add(this.dataGridViewMemoLine);
            this.tabPageStockOutItems.Location = new System.Drawing.Point(4, 32);
            this.tabPageStockOutItems.Name = "tabPageStockOutItems";
            this.tabPageStockOutItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStockOutItems.Size = new System.Drawing.Size(1392, 400);
            this.tabPageStockOutItems.TabIndex = 0;
            this.tabPageStockOutItems.Text = "Memo Lines";
            this.tabPageStockOutItems.UseVisualStyleBackColor = true;
            // 
            // buttonAddMemoLine
            // 
            this.buttonAddMemoLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddMemoLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonAddMemoLine.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonAddMemoLine.FlatAppearance.BorderSize = 0;
            this.buttonAddMemoLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddMemoLine.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddMemoLine.ForeColor = System.Drawing.Color.White;
            this.buttonAddMemoLine.Location = new System.Drawing.Point(1296, 6);
            this.buttonAddMemoLine.Name = "buttonAddMemoLine";
            this.buttonAddMemoLine.Size = new System.Drawing.Size(88, 40);
            this.buttonAddMemoLine.TabIndex = 24;
            this.buttonAddMemoLine.Text = "Add";
            this.buttonAddMemoLine.UseVisualStyleBackColor = false;
            this.buttonAddMemoLine.Click += new System.EventHandler(this.buttonAddMemoLine_Click);
            // 
            // ColumnMemoLineListButtonEdit
            // 
            this.ColumnMemoLineListButtonEdit.DataPropertyName = "ColumnMemoLineListButtonEdit";
            this.ColumnMemoLineListButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnMemoLineListButtonEdit.HeaderText = "";
            this.ColumnMemoLineListButtonEdit.Name = "ColumnMemoLineListButtonEdit";
            this.ColumnMemoLineListButtonEdit.ReadOnly = true;
            this.ColumnMemoLineListButtonEdit.Width = 70;
            // 
            // ColumnMemoLineListButtonDelete
            // 
            this.ColumnMemoLineListButtonDelete.DataPropertyName = "ColumnMemoLineListButtonDelete";
            this.ColumnMemoLineListButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnMemoLineListButtonDelete.HeaderText = "";
            this.ColumnMemoLineListButtonDelete.Name = "ColumnMemoLineListButtonDelete";
            this.ColumnMemoLineListButtonDelete.ReadOnly = true;
            this.ColumnMemoLineListButtonDelete.Width = 70;
            // 
            // ColumnMemoLineListId
            // 
            this.ColumnMemoLineListId.DataPropertyName = "ColumnMemoLineListId";
            this.ColumnMemoLineListId.HeaderText = "Id";
            this.ColumnMemoLineListId.Name = "ColumnMemoLineListId";
            this.ColumnMemoLineListId.ReadOnly = true;
            this.ColumnMemoLineListId.Visible = false;
            // 
            // ColumnMemoLineListMOId
            // 
            this.ColumnMemoLineListMOId.DataPropertyName = "ColumnMemoLineListMOId";
            this.ColumnMemoLineListMOId.HeaderText = "MOId";
            this.ColumnMemoLineListMOId.Name = "ColumnMemoLineListMOId";
            this.ColumnMemoLineListMOId.ReadOnly = true;
            this.ColumnMemoLineListMOId.Visible = false;
            // 
            // ColumnMemoLineListSIId
            // 
            this.ColumnMemoLineListSIId.DataPropertyName = "ColumnMemoLineListSIId";
            this.ColumnMemoLineListSIId.HeaderText = "SIId";
            this.ColumnMemoLineListSIId.Name = "ColumnMemoLineListSIId";
            this.ColumnMemoLineListSIId.ReadOnly = true;
            this.ColumnMemoLineListSIId.Visible = false;
            // 
            // ColumnMemoLineListSINumber
            // 
            this.ColumnMemoLineListSINumber.DataPropertyName = "ColumnMemoLineListSINumber";
            this.ColumnMemoLineListSINumber.HeaderText = "SINumber";
            this.ColumnMemoLineListSINumber.Name = "ColumnMemoLineListSINumber";
            this.ColumnMemoLineListSINumber.ReadOnly = true;
            this.ColumnMemoLineListSINumber.Width = 150;
            // 
            // ColumnMemoLineListRRId
            // 
            this.ColumnMemoLineListRRId.DataPropertyName = "ColumnMemoLineListRRId";
            this.ColumnMemoLineListRRId.HeaderText = "RRId";
            this.ColumnMemoLineListRRId.Name = "ColumnMemoLineListRRId";
            this.ColumnMemoLineListRRId.ReadOnly = true;
            this.ColumnMemoLineListRRId.Visible = false;
            // 
            // ColumnMemoLineListRRNumber
            // 
            this.ColumnMemoLineListRRNumber.DataPropertyName = "ColumnMemoLineListRRNumber";
            this.ColumnMemoLineListRRNumber.HeaderText = "RR Number";
            this.ColumnMemoLineListRRNumber.Name = "ColumnMemoLineListRRNumber";
            this.ColumnMemoLineListRRNumber.ReadOnly = true;
            this.ColumnMemoLineListRRNumber.Width = 150;
            // 
            // ColumnMemoLineListDebit
            // 
            this.ColumnMemoLineListDebit.DataPropertyName = "ColumnMemoLineListDebit";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnMemoLineListDebit.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnMemoLineListDebit.HeaderText = "Debit";
            this.ColumnMemoLineListDebit.Name = "ColumnMemoLineListDebit";
            this.ColumnMemoLineListDebit.ReadOnly = true;
            this.ColumnMemoLineListDebit.Width = 150;
            // 
            // ColumnMemoLineListCredit
            // 
            this.ColumnMemoLineListCredit.DataPropertyName = "ColumnMemoLineListCredit";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnMemoLineListCredit.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnMemoLineListCredit.HeaderText = "Credit";
            this.ColumnMemoLineListCredit.Name = "ColumnMemoLineListCredit";
            this.ColumnMemoLineListCredit.ReadOnly = true;
            this.ColumnMemoLineListCredit.Width = 150;
            // 
            // ColumnMemoLineListParticulars
            // 
            this.ColumnMemoLineListParticulars.DataPropertyName = "ColumnMemoLineListParticulars";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnMemoLineListParticulars.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnMemoLineListParticulars.HeaderText = "Particulars";
            this.ColumnMemoLineListParticulars.Name = "ColumnMemoLineListParticulars";
            this.ColumnMemoLineListParticulars.ReadOnly = true;
            this.ColumnMemoLineListParticulars.Width = 200;
            // 
            // ColumnMemoLineListSpace
            // 
            this.ColumnMemoLineListSpace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnMemoLineListSpace.DataPropertyName = "ColumnMemoLineListSpace";
            this.ColumnMemoLineListSpace.HeaderText = "";
            this.ColumnMemoLineListSpace.Name = "ColumnMemoLineListSpace";
            this.ColumnMemoLineListSpace.ReadOnly = true;
            // 
            // TrnMemoDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1400, 700);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrnMemoDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrnStockOutDetail";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMemoLine)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageStockOutItems.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonLock;
        private System.Windows.Forms.Button buttonUnlock;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxRemarks;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxApprovedBy;
        private System.Windows.Forms.ComboBox comboBoxCheckedBy;
        private System.Windows.Forms.ComboBox comboBoxPreparedBy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerMODate;
        private System.Windows.Forms.TextBox textBoxMONumber;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonMemoLinePageListFirst;
        private System.Windows.Forms.Button buttonMemoLinePageListPrevious;
        private System.Windows.Forms.Button buttonMemoLinePageListNext;
        private System.Windows.Forms.Button buttonMemoLinePageListLast;
        private System.Windows.Forms.TextBox textBoxMemoLinePageNumber;
        private System.Windows.Forms.DataGridView dataGridViewMemoLine;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox textBoxBranch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageStockOutItems;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxArticle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTotalPOAmount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttonAddMemoLine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxArticleType;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnMemoLineListButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnMemoLineListButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemoLineListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemoLineListMOId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemoLineListSIId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemoLineListSINumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemoLineListRRId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemoLineListRRNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemoLineListDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemoLineListCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemoLineListParticulars;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemoLineListSpace;
    }
}