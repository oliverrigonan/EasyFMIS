namespace easyfmis.Forms.Software.TrnDisbursement
{
    partial class TrnDisbursementListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnDisbursementListForm));
            this.textBoxDisbursementFilter = new System.Windows.Forms.TextBox();
            this.buttonDisbursementPageListFirst = new System.Windows.Forms.Button();
            this.buttonDisbursementPageListPrevious = new System.Windows.Forms.Button();
            this.buttonDisbursementPageListNext = new System.Windows.Forms.Button();
            this.dataGridViewDisbursement = new System.Windows.Forms.DataGridView();
            this.buttonDisbursementPageListLast = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxDisbursementPageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePickerDisbursementFilter = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ColumnDisbursementListButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnDisbursementListButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnDisbursementListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDisbursementListCVDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDisbursementListCVNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDisbursementListSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDisbursementListRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDisbursementListIsCrossCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnDisbursementListIsClear = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnDisbursementListIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnDisbursementListSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDisbursement)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxDisbursementFilter
            // 
            this.textBoxDisbursementFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDisbursementFilter.Location = new System.Drawing.Point(159, 6);
            this.textBoxDisbursementFilter.Name = "textBoxDisbursementFilter";
            this.textBoxDisbursementFilter.Size = new System.Drawing.Size(1229, 30);
            this.textBoxDisbursementFilter.TabIndex = 19;
            this.textBoxDisbursementFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxDisbursementFilter_KeyDown);
            // 
            // buttonDisbursementPageListFirst
            // 
            this.buttonDisbursementPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDisbursementPageListFirst.Enabled = false;
            this.buttonDisbursementPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonDisbursementPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDisbursementPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonDisbursementPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonDisbursementPageListFirst.Name = "buttonDisbursementPageListFirst";
            this.buttonDisbursementPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonDisbursementPageListFirst.TabIndex = 13;
            this.buttonDisbursementPageListFirst.Text = "First";
            this.buttonDisbursementPageListFirst.UseVisualStyleBackColor = false;
            this.buttonDisbursementPageListFirst.Click += new System.EventHandler(this.buttonDisbursementPageListFirst_Click);
            // 
            // buttonDisbursementPageListPrevious
            // 
            this.buttonDisbursementPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDisbursementPageListPrevious.Enabled = false;
            this.buttonDisbursementPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonDisbursementPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDisbursementPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonDisbursementPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonDisbursementPageListPrevious.Name = "buttonDisbursementPageListPrevious";
            this.buttonDisbursementPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonDisbursementPageListPrevious.TabIndex = 14;
            this.buttonDisbursementPageListPrevious.Text = "Previous";
            this.buttonDisbursementPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonDisbursementPageListPrevious.Click += new System.EventHandler(this.buttonDisbursementPageListPrevious_Click);
            // 
            // buttonDisbursementPageListNext
            // 
            this.buttonDisbursementPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDisbursementPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonDisbursementPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDisbursementPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonDisbursementPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonDisbursementPageListNext.Name = "buttonDisbursementPageListNext";
            this.buttonDisbursementPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonDisbursementPageListNext.TabIndex = 15;
            this.buttonDisbursementPageListNext.Text = "Next";
            this.buttonDisbursementPageListNext.UseVisualStyleBackColor = false;
            this.buttonDisbursementPageListNext.Click += new System.EventHandler(this.buttonDisbursementPageListNext_Click);
            // 
            // dataGridViewDisbursement
            // 
            this.dataGridViewDisbursement.AllowUserToAddRows = false;
            this.dataGridViewDisbursement.AllowUserToDeleteRows = false;
            this.dataGridViewDisbursement.AllowUserToResizeRows = false;
            this.dataGridViewDisbursement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDisbursement.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewDisbursement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDisbursement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDisbursementListButtonEdit,
            this.ColumnDisbursementListButtonDelete,
            this.ColumnDisbursementListId,
            this.ColumnDisbursementListCVDate,
            this.ColumnDisbursementListCVNumber,
            this.ColumnDisbursementListSupplier,
            this.ColumnDisbursementListRemarks,
            this.ColumnDisbursementListIsCrossCheck,
            this.ColumnDisbursementListIsClear,
            this.ColumnDisbursementListIsLocked,
            this.ColumnDisbursementListSpace});
            this.dataGridViewDisbursement.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewDisbursement.MultiSelect = false;
            this.dataGridViewDisbursement.Name = "dataGridViewDisbursement";
            this.dataGridViewDisbursement.ReadOnly = true;
            this.dataGridViewDisbursement.RowHeadersVisible = false;
            this.dataGridViewDisbursement.RowTemplate.Height = 24;
            this.dataGridViewDisbursement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDisbursement.Size = new System.Drawing.Size(1376, 536);
            this.dataGridViewDisbursement.TabIndex = 20;
            this.dataGridViewDisbursement.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDisbursement_CellClick);
            // 
            // buttonDisbursementPageListLast
            // 
            this.buttonDisbursementPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDisbursementPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonDisbursementPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDisbursementPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonDisbursementPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonDisbursementPageListLast.Name = "buttonDisbursementPageListLast";
            this.buttonDisbursementPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonDisbursementPageListLast.TabIndex = 16;
            this.buttonDisbursementPageListLast.Text = "Last";
            this.buttonDisbursementPageListLast.UseVisualStyleBackColor = false;
            this.buttonDisbursementPageListLast.Click += new System.EventHandler(this.buttonDisbursementPageListLast_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonDisbursementPageListFirst);
            this.panel3.Controls.Add(this.buttonDisbursementPageListPrevious);
            this.panel3.Controls.Add(this.buttonDisbursementPageListNext);
            this.panel3.Controls.Add(this.buttonDisbursementPageListLast);
            this.panel3.Controls.Add(this.textBoxDisbursementPageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 584);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1400, 53);
            this.panel3.TabIndex = 21;
            // 
            // textBoxDisbursementPageNumber
            // 
            this.textBoxDisbursementPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxDisbursementPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxDisbursementPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDisbursementPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxDisbursementPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxDisbursementPageNumber.Name = "textBoxDisbursementPageNumber";
            this.textBoxDisbursementPageNumber.ReadOnly = true;
            this.textBoxDisbursementPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxDisbursementPageNumber.TabIndex = 17;
            this.textBoxDisbursementPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateTimePickerDisbursementFilter);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewDisbursement);
            this.panel2.Controls.Add(this.textBoxDisbursementFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1400, 637);
            this.panel2.TabIndex = 7;
            // 
            // dateTimePickerDisbursementFilter
            // 
            this.dateTimePickerDisbursementFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDisbursementFilter.Location = new System.Drawing.Point(12, 6);
            this.dateTimePickerDisbursementFilter.Name = "dateTimePickerDisbursementFilter";
            this.dateTimePickerDisbursementFilter.Size = new System.Drawing.Size(141, 30);
            this.dateTimePickerDisbursementFilter.TabIndex = 22;
            this.dateTimePickerDisbursementFilter.ValueChanged += new System.EventHandler(this.dateTimePickerDisbursementFilter_ValueChanged);
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
            this.label1.Size = new System.Drawing.Size(227, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Disbursement List";
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
            this.buttonClose.TabIndex = 1;
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
            this.buttonAdd.TabIndex = 0;
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
            // ColumnDisbursementListButtonEdit
            // 
            this.ColumnDisbursementListButtonEdit.DataPropertyName = "ColumnDisbursementListButtonEdit";
            this.ColumnDisbursementListButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnDisbursementListButtonEdit.HeaderText = "";
            this.ColumnDisbursementListButtonEdit.Name = "ColumnDisbursementListButtonEdit";
            this.ColumnDisbursementListButtonEdit.ReadOnly = true;
            this.ColumnDisbursementListButtonEdit.Width = 70;
            // 
            // ColumnDisbursementListButtonDelete
            // 
            this.ColumnDisbursementListButtonDelete.DataPropertyName = "ColumnDisbursementListButtonDelete";
            this.ColumnDisbursementListButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnDisbursementListButtonDelete.HeaderText = "";
            this.ColumnDisbursementListButtonDelete.Name = "ColumnDisbursementListButtonDelete";
            this.ColumnDisbursementListButtonDelete.ReadOnly = true;
            this.ColumnDisbursementListButtonDelete.Width = 70;
            // 
            // ColumnDisbursementListId
            // 
            this.ColumnDisbursementListId.DataPropertyName = "ColumnDisbursementListId";
            this.ColumnDisbursementListId.HeaderText = "Id";
            this.ColumnDisbursementListId.Name = "ColumnDisbursementListId";
            this.ColumnDisbursementListId.ReadOnly = true;
            this.ColumnDisbursementListId.Visible = false;
            // 
            // ColumnDisbursementListCVDate
            // 
            this.ColumnDisbursementListCVDate.DataPropertyName = "ColumnDisbursementListCVDate";
            this.ColumnDisbursementListCVDate.HeaderText = "CV Date";
            this.ColumnDisbursementListCVDate.Name = "ColumnDisbursementListCVDate";
            this.ColumnDisbursementListCVDate.ReadOnly = true;
            // 
            // ColumnDisbursementListCVNumber
            // 
            this.ColumnDisbursementListCVNumber.DataPropertyName = "ColumnDisbursementListCVNumber";
            this.ColumnDisbursementListCVNumber.HeaderText = "CV Number";
            this.ColumnDisbursementListCVNumber.Name = "ColumnDisbursementListCVNumber";
            this.ColumnDisbursementListCVNumber.ReadOnly = true;
            this.ColumnDisbursementListCVNumber.Width = 125;
            // 
            // ColumnDisbursementListSupplier
            // 
            this.ColumnDisbursementListSupplier.DataPropertyName = "ColumnDisbursementListSupplier";
            this.ColumnDisbursementListSupplier.HeaderText = "Supplier";
            this.ColumnDisbursementListSupplier.Name = "ColumnDisbursementListSupplier";
            this.ColumnDisbursementListSupplier.ReadOnly = true;
            this.ColumnDisbursementListSupplier.Width = 200;
            // 
            // ColumnDisbursementListRemarks
            // 
            this.ColumnDisbursementListRemarks.DataPropertyName = "ColumnDisbursementListRemarks";
            this.ColumnDisbursementListRemarks.HeaderText = "Remarks";
            this.ColumnDisbursementListRemarks.Name = "ColumnDisbursementListRemarks";
            this.ColumnDisbursementListRemarks.ReadOnly = true;
            this.ColumnDisbursementListRemarks.Width = 200;
            // 
            // ColumnDisbursementListIsCrossCheck
            // 
            this.ColumnDisbursementListIsCrossCheck.DataPropertyName = "ColumnDisbursementListIsCrossCheck";
            this.ColumnDisbursementListIsCrossCheck.HeaderText = "Cross Check";
            this.ColumnDisbursementListIsCrossCheck.Name = "ColumnDisbursementListIsCrossCheck";
            this.ColumnDisbursementListIsCrossCheck.ReadOnly = true;
            // 
            // ColumnDisbursementListIsClear
            // 
            this.ColumnDisbursementListIsClear.DataPropertyName = "ColumnDisbursementListIsClear";
            this.ColumnDisbursementListIsClear.HeaderText = "Clear";
            this.ColumnDisbursementListIsClear.Name = "ColumnDisbursementListIsClear";
            this.ColumnDisbursementListIsClear.ReadOnly = true;
            this.ColumnDisbursementListIsClear.Width = 35;
            // 
            // ColumnDisbursementListIsLocked
            // 
            this.ColumnDisbursementListIsLocked.DataPropertyName = "ColumnDisbursementListIsLocked";
            this.ColumnDisbursementListIsLocked.HeaderText = "L";
            this.ColumnDisbursementListIsLocked.Name = "ColumnDisbursementListIsLocked";
            this.ColumnDisbursementListIsLocked.ReadOnly = true;
            this.ColumnDisbursementListIsLocked.Width = 35;
            // 
            // ColumnDisbursementListSpace
            // 
            this.ColumnDisbursementListSpace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnDisbursementListSpace.DataPropertyName = "ColumnDisbursementListSpace";
            this.ColumnDisbursementListSpace.HeaderText = "";
            this.ColumnDisbursementListSpace.Name = "ColumnDisbursementListSpace";
            this.ColumnDisbursementListSpace.ReadOnly = true;
            // 
            // TrnDisbursementForm
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
            this.Name = "TrnDisbursementForm";
            this.Text = "Stock In List";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDisbursement)).EndInit();
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

        private System.Windows.Forms.TextBox textBoxDisbursementFilter;
        private System.Windows.Forms.Button buttonDisbursementPageListFirst;
        private System.Windows.Forms.Button buttonDisbursementPageListPrevious;
        private System.Windows.Forms.Button buttonDisbursementPageListNext;
        private System.Windows.Forms.DataGridView dataGridViewDisbursement;
        private System.Windows.Forms.Button buttonDisbursementPageListLast;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxDisbursementPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePickerDisbursementFilter;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnDisbursementListButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnDisbursementListButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDisbursementListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDisbursementListCVDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDisbursementListCVNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDisbursementListSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDisbursementListRemarks;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnDisbursementListIsCrossCheck;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnDisbursementListIsClear;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnDisbursementListIsLocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDisbursementListSpace;
    }
}