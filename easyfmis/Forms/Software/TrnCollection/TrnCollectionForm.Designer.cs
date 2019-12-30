namespace easyfmis.Forms.Software.TrnCollection
{
    partial class TrnCollectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnCollectionForm));
            this.textBoxCollectionFilter = new System.Windows.Forms.TextBox();
            this.buttonCollectionPageListFirst = new System.Windows.Forms.Button();
            this.buttonCollectionPageListPrevious = new System.Windows.Forms.Button();
            this.buttonCollectionPageListNext = new System.Windows.Forms.Button();
            this.dataGridViewCollection = new System.Windows.Forms.DataGridView();
            this.ColumnCollectionButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnCollectionButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnCollectionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCollectionORDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCollectionORNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCollectionCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCollectionRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCollectionIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnCollectionSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonCollectionPageListLast = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxCollectionPageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePickerCollectionFilterDateEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerCollectionFilterDateStart = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCollection)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxCollectionFilter
            // 
            this.textBoxCollectionFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCollectionFilter.Location = new System.Drawing.Point(306, 6);
            this.textBoxCollectionFilter.Name = "textBoxCollectionFilter";
            this.textBoxCollectionFilter.Size = new System.Drawing.Size(1082, 30);
            this.textBoxCollectionFilter.TabIndex = 1;
            this.textBoxCollectionFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCollectionFilter_KeyDown);
            // 
            // buttonCollectionPageListFirst
            // 
            this.buttonCollectionPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCollectionPageListFirst.Enabled = false;
            this.buttonCollectionPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonCollectionPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCollectionPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonCollectionPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonCollectionPageListFirst.Name = "buttonCollectionPageListFirst";
            this.buttonCollectionPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonCollectionPageListFirst.TabIndex = 13;
            this.buttonCollectionPageListFirst.Text = "First";
            this.buttonCollectionPageListFirst.UseVisualStyleBackColor = false;
            this.buttonCollectionPageListFirst.Click += new System.EventHandler(this.buttonCollectionPageListFirst_Click);
            // 
            // buttonCollectionPageListPrevious
            // 
            this.buttonCollectionPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCollectionPageListPrevious.Enabled = false;
            this.buttonCollectionPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonCollectionPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCollectionPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonCollectionPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonCollectionPageListPrevious.Name = "buttonCollectionPageListPrevious";
            this.buttonCollectionPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonCollectionPageListPrevious.TabIndex = 14;
            this.buttonCollectionPageListPrevious.Text = "Previous";
            this.buttonCollectionPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonCollectionPageListPrevious.Click += new System.EventHandler(this.buttonCollectionPageListPrevious_Click);
            // 
            // buttonCollectionPageListNext
            // 
            this.buttonCollectionPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCollectionPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonCollectionPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCollectionPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonCollectionPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonCollectionPageListNext.Name = "buttonCollectionPageListNext";
            this.buttonCollectionPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonCollectionPageListNext.TabIndex = 15;
            this.buttonCollectionPageListNext.Text = "Next";
            this.buttonCollectionPageListNext.UseVisualStyleBackColor = false;
            this.buttonCollectionPageListNext.Click += new System.EventHandler(this.buttonCollectionPageListNext_Click);
            // 
            // dataGridViewCollection
            // 
            this.dataGridViewCollection.AllowUserToAddRows = false;
            this.dataGridViewCollection.AllowUserToDeleteRows = false;
            this.dataGridViewCollection.AllowUserToResizeRows = false;
            this.dataGridViewCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCollection.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCollection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCollection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCollectionButtonEdit,
            this.ColumnCollectionButtonDelete,
            this.ColumnCollectionId,
            this.ColumnCollectionORDate,
            this.ColumnCollectionORNumber,
            this.ColumnCollectionCustomer,
            this.ColumnCollectionRemarks,
            this.ColumnCollectionIsLocked,
            this.ColumnCollectionSpace});
            this.dataGridViewCollection.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewCollection.MultiSelect = false;
            this.dataGridViewCollection.Name = "dataGridViewCollection";
            this.dataGridViewCollection.ReadOnly = true;
            this.dataGridViewCollection.RowHeadersVisible = false;
            this.dataGridViewCollection.RowTemplate.Height = 24;
            this.dataGridViewCollection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCollection.Size = new System.Drawing.Size(1376, 536);
            this.dataGridViewCollection.TabIndex = 20;
            this.dataGridViewCollection.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCollection_CellClick);
            // 
            // ColumnCollectionButtonEdit
            // 
            this.ColumnCollectionButtonEdit.DataPropertyName = "ColumnCollectionButtonEdit";
            this.ColumnCollectionButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnCollectionButtonEdit.HeaderText = "";
            this.ColumnCollectionButtonEdit.Name = "ColumnCollectionButtonEdit";
            this.ColumnCollectionButtonEdit.ReadOnly = true;
            this.ColumnCollectionButtonEdit.Width = 70;
            // 
            // ColumnCollectionButtonDelete
            // 
            this.ColumnCollectionButtonDelete.DataPropertyName = "ColumnCollectionButtonDelete";
            this.ColumnCollectionButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnCollectionButtonDelete.HeaderText = "";
            this.ColumnCollectionButtonDelete.Name = "ColumnCollectionButtonDelete";
            this.ColumnCollectionButtonDelete.ReadOnly = true;
            this.ColumnCollectionButtonDelete.Width = 70;
            // 
            // ColumnCollectionId
            // 
            this.ColumnCollectionId.DataPropertyName = "ColumnCollectionId";
            this.ColumnCollectionId.HeaderText = "Id";
            this.ColumnCollectionId.Name = "ColumnCollectionId";
            this.ColumnCollectionId.ReadOnly = true;
            this.ColumnCollectionId.Visible = false;
            // 
            // ColumnCollectionORDate
            // 
            this.ColumnCollectionORDate.DataPropertyName = "ColumnCollectionORDate";
            this.ColumnCollectionORDate.HeaderText = "OR Date";
            this.ColumnCollectionORDate.Name = "ColumnCollectionORDate";
            this.ColumnCollectionORDate.ReadOnly = true;
            // 
            // ColumnCollectionORNumber
            // 
            this.ColumnCollectionORNumber.DataPropertyName = "ColumnCollectionORNumber";
            this.ColumnCollectionORNumber.HeaderText = "OR Number";
            this.ColumnCollectionORNumber.Name = "ColumnCollectionORNumber";
            this.ColumnCollectionORNumber.ReadOnly = true;
            this.ColumnCollectionORNumber.Width = 125;
            // 
            // ColumnCollectionCustomer
            // 
            this.ColumnCollectionCustomer.DataPropertyName = "ColumnCollectionCustomer";
            this.ColumnCollectionCustomer.HeaderText = "Customer";
            this.ColumnCollectionCustomer.Name = "ColumnCollectionCustomer";
            this.ColumnCollectionCustomer.ReadOnly = true;
            this.ColumnCollectionCustomer.Width = 200;
            // 
            // ColumnCollectionRemarks
            // 
            this.ColumnCollectionRemarks.DataPropertyName = "ColumnCollectionRemarks";
            this.ColumnCollectionRemarks.HeaderText = "Remarks";
            this.ColumnCollectionRemarks.Name = "ColumnCollectionRemarks";
            this.ColumnCollectionRemarks.ReadOnly = true;
            this.ColumnCollectionRemarks.Width = 350;
            // 
            // ColumnCollectionIsLocked
            // 
            this.ColumnCollectionIsLocked.DataPropertyName = "ColumnCollectionIsLocked";
            this.ColumnCollectionIsLocked.HeaderText = "L";
            this.ColumnCollectionIsLocked.Name = "ColumnCollectionIsLocked";
            this.ColumnCollectionIsLocked.ReadOnly = true;
            this.ColumnCollectionIsLocked.Width = 35;
            // 
            // ColumnCollectionSpace
            // 
            this.ColumnCollectionSpace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnCollectionSpace.DataPropertyName = "ColumnCollectionSpace";
            this.ColumnCollectionSpace.HeaderText = "";
            this.ColumnCollectionSpace.Name = "ColumnCollectionSpace";
            this.ColumnCollectionSpace.ReadOnly = true;
            // 
            // buttonCollectionPageListLast
            // 
            this.buttonCollectionPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCollectionPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonCollectionPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCollectionPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonCollectionPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonCollectionPageListLast.Name = "buttonCollectionPageListLast";
            this.buttonCollectionPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonCollectionPageListLast.TabIndex = 16;
            this.buttonCollectionPageListLast.Text = "Last";
            this.buttonCollectionPageListLast.UseVisualStyleBackColor = false;
            this.buttonCollectionPageListLast.Click += new System.EventHandler(this.buttonCollectionPageListLast_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonCollectionPageListFirst);
            this.panel3.Controls.Add(this.buttonCollectionPageListPrevious);
            this.panel3.Controls.Add(this.buttonCollectionPageListNext);
            this.panel3.Controls.Add(this.buttonCollectionPageListLast);
            this.panel3.Controls.Add(this.textBoxCollectionPageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 584);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1400, 53);
            this.panel3.TabIndex = 21;
            // 
            // textBoxCollectionPageNumber
            // 
            this.textBoxCollectionPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxCollectionPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxCollectionPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCollectionPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxCollectionPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxCollectionPageNumber.Name = "textBoxCollectionPageNumber";
            this.textBoxCollectionPageNumber.ReadOnly = true;
            this.textBoxCollectionPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxCollectionPageNumber.TabIndex = 17;
            this.textBoxCollectionPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateTimePickerCollectionFilterDateEnd);
            this.panel2.Controls.Add(this.dateTimePickerCollectionFilterDateStart);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewCollection);
            this.panel2.Controls.Add(this.textBoxCollectionFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1400, 637);
            this.panel2.TabIndex = 7;
            // 
            // dateTimePickerCollectionFilterDateEnd
            // 
            this.dateTimePickerCollectionFilterDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerCollectionFilterDateEnd.Location = new System.Drawing.Point(159, 6);
            this.dateTimePickerCollectionFilterDateEnd.Name = "dateTimePickerCollectionFilterDateEnd";
            this.dateTimePickerCollectionFilterDateEnd.Size = new System.Drawing.Size(141, 30);
            this.dateTimePickerCollectionFilterDateEnd.TabIndex = 22;
            this.dateTimePickerCollectionFilterDateEnd.ValueChanged += new System.EventHandler(this.dateTimePickerCollectionFilterStartDate_ValueChanged);
            // 
            // dateTimePickerCollectionFilterDateStart
            // 
            this.dateTimePickerCollectionFilterDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerCollectionFilterDateStart.Location = new System.Drawing.Point(12, 6);
            this.dateTimePickerCollectionFilterDateStart.Name = "dateTimePickerCollectionFilterDateStart";
            this.dateTimePickerCollectionFilterDateStart.Size = new System.Drawing.Size(141, 30);
            this.dateTimePickerCollectionFilterDateStart.TabIndex = 0;
            this.dateTimePickerCollectionFilterDateStart.ValueChanged += new System.EventHandler(this.dateTimePickerCollectionFilterStartDate_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.Collection;
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
            this.label1.Size = new System.Drawing.Size(181, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Collection List";
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
            // TrnCollectionForm
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
            this.Name = "TrnCollectionForm";
            this.Text = "Stock In List";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCollection)).EndInit();
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

        private System.Windows.Forms.TextBox textBoxCollectionFilter;
        private System.Windows.Forms.Button buttonCollectionPageListFirst;
        private System.Windows.Forms.Button buttonCollectionPageListPrevious;
        private System.Windows.Forms.Button buttonCollectionPageListNext;
        private System.Windows.Forms.DataGridView dataGridViewCollection;
        private System.Windows.Forms.Button buttonCollectionPageListLast;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxCollectionPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePickerCollectionFilterDateStart;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnCollectionButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnCollectionButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCollectionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCollectionORDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCollectionORNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCollectionCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCollectionRemarks;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCollectionIsLocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCollectionSpace;
        private System.Windows.Forms.DateTimePicker dateTimePickerCollectionFilterDateEnd;
    }
}