namespace easyfmis.Forms.Software.TrnMemo
{
    partial class TrnMemoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnMemoForm));
            this.textBoxMemoFilter = new System.Windows.Forms.TextBox();
            this.buttonMemoPageListFirst = new System.Windows.Forms.Button();
            this.buttonMemoPageListPrevious = new System.Windows.Forms.Button();
            this.buttonMemoPageListNext = new System.Windows.Forms.Button();
            this.dataGridViewMemo = new System.Windows.Forms.DataGridView();
            this.buttonMemoPageListLast = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxMemoPageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePickerMemoFilterEndDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerMemoFilterStartDate = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ColumnMemoListButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnMemoListButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnMemoListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemoListMODate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemoListMONumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemoListArticle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemoListRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemoListIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnMemoListSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMemo)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxMemoFilter
            // 
            this.textBoxMemoFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMemoFilter.Location = new System.Drawing.Point(306, 6);
            this.textBoxMemoFilter.Name = "textBoxMemoFilter";
            this.textBoxMemoFilter.Size = new System.Drawing.Size(1082, 30);
            this.textBoxMemoFilter.TabIndex = 1;
            this.textBoxMemoFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMemoFilter_KeyDown);
            // 
            // buttonMemoPageListFirst
            // 
            this.buttonMemoPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMemoPageListFirst.Enabled = false;
            this.buttonMemoPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonMemoPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMemoPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonMemoPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonMemoPageListFirst.Name = "buttonMemoPageListFirst";
            this.buttonMemoPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonMemoPageListFirst.TabIndex = 13;
            this.buttonMemoPageListFirst.Text = "First";
            this.buttonMemoPageListFirst.UseVisualStyleBackColor = false;
            this.buttonMemoPageListFirst.Click += new System.EventHandler(this.buttonMemoPageListFirst_Click);
            // 
            // buttonMemoPageListPrevious
            // 
            this.buttonMemoPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMemoPageListPrevious.Enabled = false;
            this.buttonMemoPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonMemoPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMemoPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonMemoPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonMemoPageListPrevious.Name = "buttonMemoPageListPrevious";
            this.buttonMemoPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonMemoPageListPrevious.TabIndex = 14;
            this.buttonMemoPageListPrevious.Text = "Previous";
            this.buttonMemoPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonMemoPageListPrevious.Click += new System.EventHandler(this.buttonMemoPageListPrevious_Click);
            // 
            // buttonMemoPageListNext
            // 
            this.buttonMemoPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMemoPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonMemoPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMemoPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonMemoPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonMemoPageListNext.Name = "buttonMemoPageListNext";
            this.buttonMemoPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonMemoPageListNext.TabIndex = 15;
            this.buttonMemoPageListNext.Text = "Next";
            this.buttonMemoPageListNext.UseVisualStyleBackColor = false;
            this.buttonMemoPageListNext.Click += new System.EventHandler(this.buttonMemoPageListNext_Click);
            // 
            // dataGridViewMemo
            // 
            this.dataGridViewMemo.AllowUserToAddRows = false;
            this.dataGridViewMemo.AllowUserToDeleteRows = false;
            this.dataGridViewMemo.AllowUserToResizeRows = false;
            this.dataGridViewMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMemo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewMemo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMemo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnMemoListButtonEdit,
            this.ColumnMemoListButtonDelete,
            this.ColumnMemoListId,
            this.ColumnMemoListMODate,
            this.ColumnMemoListMONumber,
            this.ColumnMemoListArticle,
            this.ColumnMemoListRemarks,
            this.ColumnMemoListIsLocked,
            this.ColumnMemoListSpace});
            this.dataGridViewMemo.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewMemo.MultiSelect = false;
            this.dataGridViewMemo.Name = "dataGridViewMemo";
            this.dataGridViewMemo.ReadOnly = true;
            this.dataGridViewMemo.RowHeadersVisible = false;
            this.dataGridViewMemo.RowTemplate.Height = 24;
            this.dataGridViewMemo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMemo.Size = new System.Drawing.Size(1376, 536);
            this.dataGridViewMemo.TabIndex = 20;
            this.dataGridViewMemo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMemo_CellClick);
            // 
            // buttonMemoPageListLast
            // 
            this.buttonMemoPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMemoPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonMemoPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMemoPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonMemoPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonMemoPageListLast.Name = "buttonMemoPageListLast";
            this.buttonMemoPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonMemoPageListLast.TabIndex = 16;
            this.buttonMemoPageListLast.Text = "Last";
            this.buttonMemoPageListLast.UseVisualStyleBackColor = false;
            this.buttonMemoPageListLast.Click += new System.EventHandler(this.buttonMemoPageListLast_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonMemoPageListFirst);
            this.panel3.Controls.Add(this.buttonMemoPageListPrevious);
            this.panel3.Controls.Add(this.buttonMemoPageListNext);
            this.panel3.Controls.Add(this.buttonMemoPageListLast);
            this.panel3.Controls.Add(this.textBoxMemoPageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 584);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1400, 53);
            this.panel3.TabIndex = 21;
            // 
            // textBoxMemoPageNumber
            // 
            this.textBoxMemoPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxMemoPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxMemoPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMemoPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxMemoPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxMemoPageNumber.Name = "textBoxMemoPageNumber";
            this.textBoxMemoPageNumber.ReadOnly = true;
            this.textBoxMemoPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxMemoPageNumber.TabIndex = 17;
            this.textBoxMemoPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateTimePickerMemoFilterEndDate);
            this.panel2.Controls.Add(this.dateTimePickerMemoFilterStartDate);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewMemo);
            this.panel2.Controls.Add(this.textBoxMemoFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1400, 637);
            this.panel2.TabIndex = 7;
            // 
            // dateTimePickerMemoFilterEndDate
            // 
            this.dateTimePickerMemoFilterEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerMemoFilterEndDate.Location = new System.Drawing.Point(159, 6);
            this.dateTimePickerMemoFilterEndDate.Name = "dateTimePickerMemoFilterEndDate";
            this.dateTimePickerMemoFilterEndDate.Size = new System.Drawing.Size(141, 30);
            this.dateTimePickerMemoFilterEndDate.TabIndex = 22;
            this.dateTimePickerMemoFilterEndDate.ValueChanged += new System.EventHandler(this.dateTimePickerMemoFilterEndDate_ValueChanged);
            // 
            // dateTimePickerMemoFilterStartDate
            // 
            this.dateTimePickerMemoFilterStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerMemoFilterStartDate.Location = new System.Drawing.Point(12, 6);
            this.dateTimePickerMemoFilterStartDate.Name = "dateTimePickerMemoFilterStartDate";
            this.dateTimePickerMemoFilterStartDate.Size = new System.Drawing.Size(141, 30);
            this.dateTimePickerMemoFilterStartDate.TabIndex = 0;
            this.dateTimePickerMemoFilterStartDate.ValueChanged += new System.EventHandler(this.dateTimePickerMemoFilterStartDate_ValueChanged);
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
            this.label1.Size = new System.Drawing.Size(139, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Memo List";
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
            // ColumnMemoListButtonEdit
            // 
            this.ColumnMemoListButtonEdit.DataPropertyName = "ColumnMemoListButtonEdit";
            this.ColumnMemoListButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnMemoListButtonEdit.HeaderText = "";
            this.ColumnMemoListButtonEdit.Name = "ColumnMemoListButtonEdit";
            this.ColumnMemoListButtonEdit.ReadOnly = true;
            this.ColumnMemoListButtonEdit.Width = 70;
            // 
            // ColumnMemoListButtonDelete
            // 
            this.ColumnMemoListButtonDelete.DataPropertyName = "ColumnMemoListButtonDelete";
            this.ColumnMemoListButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnMemoListButtonDelete.HeaderText = "";
            this.ColumnMemoListButtonDelete.Name = "ColumnMemoListButtonDelete";
            this.ColumnMemoListButtonDelete.ReadOnly = true;
            this.ColumnMemoListButtonDelete.Width = 70;
            // 
            // ColumnMemoListId
            // 
            this.ColumnMemoListId.DataPropertyName = "ColumnMemoListId";
            this.ColumnMemoListId.HeaderText = "Id";
            this.ColumnMemoListId.Name = "ColumnMemoListId";
            this.ColumnMemoListId.ReadOnly = true;
            this.ColumnMemoListId.Visible = false;
            // 
            // ColumnMemoListMODate
            // 
            this.ColumnMemoListMODate.DataPropertyName = "ColumnMemoListMODate";
            this.ColumnMemoListMODate.HeaderText = "Date";
            this.ColumnMemoListMODate.Name = "ColumnMemoListMODate";
            this.ColumnMemoListMODate.ReadOnly = true;
            // 
            // ColumnMemoListMONumber
            // 
            this.ColumnMemoListMONumber.DataPropertyName = "ColumnMemoListMONumber";
            this.ColumnMemoListMONumber.HeaderText = "Memo Number";
            this.ColumnMemoListMONumber.Name = "ColumnMemoListMONumber";
            this.ColumnMemoListMONumber.ReadOnly = true;
            this.ColumnMemoListMONumber.Width = 125;
            // 
            // ColumnMemoListArticle
            // 
            this.ColumnMemoListArticle.DataPropertyName = "ColumnMemoListArticle";
            this.ColumnMemoListArticle.HeaderText = "Full Name";
            this.ColumnMemoListArticle.Name = "ColumnMemoListArticle";
            this.ColumnMemoListArticle.ReadOnly = true;
            this.ColumnMemoListArticle.Width = 200;
            // 
            // ColumnMemoListRemarks
            // 
            this.ColumnMemoListRemarks.DataPropertyName = "ColumnMemoListRemarks";
            this.ColumnMemoListRemarks.HeaderText = "Remarks";
            this.ColumnMemoListRemarks.Name = "ColumnMemoListRemarks";
            this.ColumnMemoListRemarks.ReadOnly = true;
            this.ColumnMemoListRemarks.Width = 200;
            // 
            // ColumnMemoListIsLocked
            // 
            this.ColumnMemoListIsLocked.DataPropertyName = "ColumnMemoListIsLocked";
            this.ColumnMemoListIsLocked.HeaderText = "L";
            this.ColumnMemoListIsLocked.Name = "ColumnMemoListIsLocked";
            this.ColumnMemoListIsLocked.ReadOnly = true;
            this.ColumnMemoListIsLocked.Width = 35;
            // 
            // ColumnMemoListSpace
            // 
            this.ColumnMemoListSpace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnMemoListSpace.DataPropertyName = "ColumnMemoListSpace";
            this.ColumnMemoListSpace.HeaderText = "";
            this.ColumnMemoListSpace.Name = "ColumnMemoListSpace";
            this.ColumnMemoListSpace.ReadOnly = true;
            // 
            // TrnMemoForm
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
            this.Name = "TrnMemoForm";
            this.Text = "Stock In List";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMemo)).EndInit();
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

        private System.Windows.Forms.TextBox textBoxMemoFilter;
        private System.Windows.Forms.Button buttonMemoPageListFirst;
        private System.Windows.Forms.Button buttonMemoPageListPrevious;
        private System.Windows.Forms.Button buttonMemoPageListNext;
        private System.Windows.Forms.DataGridView dataGridViewMemo;
        private System.Windows.Forms.Button buttonMemoPageListLast;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxMemoPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePickerMemoFilterStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerMemoFilterEndDate;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnMemoListButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnMemoListButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemoListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemoListMODate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemoListMONumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemoListArticle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemoListRemarks;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnMemoListIsLocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemoListSpace;
    }
}