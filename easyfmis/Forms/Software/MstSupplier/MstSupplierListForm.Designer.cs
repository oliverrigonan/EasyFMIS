namespace easyfmis.Forms.Software.MstSupplier
{
    partial class MstSupplierListForm
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
            this.textBoxSupplierListFilter = new System.Windows.Forms.TextBox();
            this.buttonSupplierListPageListFirst = new System.Windows.Forms.Button();
            this.buttonSupplierListPageListPrevious = new System.Windows.Forms.Button();
            this.buttonSupplierListPageListNext = new System.Windows.Forms.Button();
            this.dataGridViewSupplierList = new System.Windows.Forms.DataGridView();
            this.ColumnSupplierListButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnSupplierListButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnSupplierListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSupplierListSupplierCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSupplierListSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSupplierListContactNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSupplierListAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSupplierListIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnSupplierListSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSupplierListPageListLast = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxSupplierListPageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSupplierList)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxSupplierListFilter
            // 
            this.textBoxSupplierListFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSupplierListFilter.Location = new System.Drawing.Point(12, 6);
            this.textBoxSupplierListFilter.Name = "textBoxSupplierListFilter";
            this.textBoxSupplierListFilter.Size = new System.Drawing.Size(1358, 30);
            this.textBoxSupplierListFilter.TabIndex = 0;
            this.textBoxSupplierListFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSupplierListFilter_KeyDown);
            // 
            // buttonSupplierListPageListFirst
            // 
            this.buttonSupplierListPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSupplierListPageListFirst.Enabled = false;
            this.buttonSupplierListPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonSupplierListPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSupplierListPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSupplierListPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonSupplierListPageListFirst.Name = "buttonSupplierListPageListFirst";
            this.buttonSupplierListPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonSupplierListPageListFirst.TabIndex = 13;
            this.buttonSupplierListPageListFirst.Text = "First";
            this.buttonSupplierListPageListFirst.UseVisualStyleBackColor = false;
            this.buttonSupplierListPageListFirst.Click += new System.EventHandler(this.buttonSupplierListPageListFirst_Click);
            // 
            // buttonSupplierListPageListPrevious
            // 
            this.buttonSupplierListPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSupplierListPageListPrevious.Enabled = false;
            this.buttonSupplierListPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonSupplierListPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSupplierListPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSupplierListPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonSupplierListPageListPrevious.Name = "buttonSupplierListPageListPrevious";
            this.buttonSupplierListPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonSupplierListPageListPrevious.TabIndex = 14;
            this.buttonSupplierListPageListPrevious.Text = "Previous";
            this.buttonSupplierListPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonSupplierListPageListPrevious.Click += new System.EventHandler(this.buttonSupplierListPageListPrevious_Click);
            // 
            // buttonSupplierListPageListNext
            // 
            this.buttonSupplierListPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSupplierListPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonSupplierListPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSupplierListPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSupplierListPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonSupplierListPageListNext.Name = "buttonSupplierListPageListNext";
            this.buttonSupplierListPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonSupplierListPageListNext.TabIndex = 15;
            this.buttonSupplierListPageListNext.Text = "Next";
            this.buttonSupplierListPageListNext.UseVisualStyleBackColor = false;
            this.buttonSupplierListPageListNext.Click += new System.EventHandler(this.buttonSupplierListPageListNext_Click);
            // 
            // dataGridViewSupplierList
            // 
            this.dataGridViewSupplierList.AllowUserToAddRows = false;
            this.dataGridViewSupplierList.AllowUserToDeleteRows = false;
            this.dataGridViewSupplierList.AllowUserToResizeRows = false;
            this.dataGridViewSupplierList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSupplierList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewSupplierList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSupplierList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSupplierListButtonEdit,
            this.ColumnSupplierListButtonDelete,
            this.ColumnSupplierListId,
            this.ColumnSupplierListSupplierCode,
            this.ColumnSupplierListSupplier,
            this.ColumnSupplierListContactNumber,
            this.ColumnSupplierListAddress,
            this.ColumnSupplierListIsLocked,
            this.ColumnSupplierListSpace});
            this.dataGridViewSupplierList.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewSupplierList.MultiSelect = false;
            this.dataGridViewSupplierList.Name = "dataGridViewSupplierList";
            this.dataGridViewSupplierList.ReadOnly = true;
            this.dataGridViewSupplierList.RowHeadersVisible = false;
            this.dataGridViewSupplierList.RowTemplate.Height = 24;
            this.dataGridViewSupplierList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSupplierList.Size = new System.Drawing.Size(1358, 518);
            this.dataGridViewSupplierList.TabIndex = 20;
            this.dataGridViewSupplierList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSupplierList_CellClick);
            // 
            // ColumnSupplierListButtonEdit
            // 
            this.ColumnSupplierListButtonEdit.DataPropertyName = "ColumnSupplierListButtonEdit";
            this.ColumnSupplierListButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnSupplierListButtonEdit.HeaderText = "";
            this.ColumnSupplierListButtonEdit.Name = "ColumnSupplierListButtonEdit";
            this.ColumnSupplierListButtonEdit.ReadOnly = true;
            this.ColumnSupplierListButtonEdit.Width = 70;
            // 
            // ColumnSupplierListButtonDelete
            // 
            this.ColumnSupplierListButtonDelete.DataPropertyName = "ColumnSupplierListButtonDelete";
            this.ColumnSupplierListButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnSupplierListButtonDelete.HeaderText = "";
            this.ColumnSupplierListButtonDelete.Name = "ColumnSupplierListButtonDelete";
            this.ColumnSupplierListButtonDelete.ReadOnly = true;
            this.ColumnSupplierListButtonDelete.Width = 70;
            // 
            // ColumnSupplierListId
            // 
            this.ColumnSupplierListId.DataPropertyName = "ColumnSupplierListId";
            this.ColumnSupplierListId.HeaderText = "Id";
            this.ColumnSupplierListId.Name = "ColumnSupplierListId";
            this.ColumnSupplierListId.ReadOnly = true;
            this.ColumnSupplierListId.Visible = false;
            // 
            // ColumnSupplierListSupplierCode
            // 
            this.ColumnSupplierListSupplierCode.DataPropertyName = "ColumnSupplierListSupplierCode";
            this.ColumnSupplierListSupplierCode.HeaderText = "Code";
            this.ColumnSupplierListSupplierCode.Name = "ColumnSupplierListSupplierCode";
            this.ColumnSupplierListSupplierCode.ReadOnly = true;
            this.ColumnSupplierListSupplierCode.Width = 150;
            // 
            // ColumnSupplierListSupplier
            // 
            this.ColumnSupplierListSupplier.DataPropertyName = "ColumnSupplierListSupplier";
            this.ColumnSupplierListSupplier.HeaderText = "Supplier";
            this.ColumnSupplierListSupplier.Name = "ColumnSupplierListSupplier";
            this.ColumnSupplierListSupplier.ReadOnly = true;
            this.ColumnSupplierListSupplier.Width = 250;
            // 
            // ColumnSupplierListContactNumber
            // 
            this.ColumnSupplierListContactNumber.DataPropertyName = "ColumnSupplierListContactNumber";
            this.ColumnSupplierListContactNumber.HeaderText = "Contact No.";
            this.ColumnSupplierListContactNumber.Name = "ColumnSupplierListContactNumber";
            this.ColumnSupplierListContactNumber.ReadOnly = true;
            this.ColumnSupplierListContactNumber.Width = 200;
            // 
            // ColumnSupplierListAddress
            // 
            this.ColumnSupplierListAddress.DataPropertyName = "ColumnSupplierListAddress";
            this.ColumnSupplierListAddress.HeaderText = "Address";
            this.ColumnSupplierListAddress.Name = "ColumnSupplierListAddress";
            this.ColumnSupplierListAddress.ReadOnly = true;
            this.ColumnSupplierListAddress.Width = 250;
            // 
            // ColumnSupplierListIsLocked
            // 
            this.ColumnSupplierListIsLocked.DataPropertyName = "ColumnSupplierListIsLocked";
            this.ColumnSupplierListIsLocked.HeaderText = "L";
            this.ColumnSupplierListIsLocked.Name = "ColumnSupplierListIsLocked";
            this.ColumnSupplierListIsLocked.ReadOnly = true;
            this.ColumnSupplierListIsLocked.Width = 35;
            // 
            // ColumnSupplierListSpace
            // 
            this.ColumnSupplierListSpace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSupplierListSpace.DataPropertyName = "ColumnSupplierListSpace";
            this.ColumnSupplierListSpace.HeaderText = "";
            this.ColumnSupplierListSpace.Name = "ColumnSupplierListSpace";
            this.ColumnSupplierListSpace.ReadOnly = true;
            // 
            // buttonSupplierListPageListLast
            // 
            this.buttonSupplierListPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSupplierListPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonSupplierListPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSupplierListPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSupplierListPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonSupplierListPageListLast.Name = "buttonSupplierListPageListLast";
            this.buttonSupplierListPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonSupplierListPageListLast.TabIndex = 16;
            this.buttonSupplierListPageListLast.Text = "Last";
            this.buttonSupplierListPageListLast.UseVisualStyleBackColor = false;
            this.buttonSupplierListPageListLast.Click += new System.EventHandler(this.buttonSupplierListPageListLast_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonSupplierListPageListFirst);
            this.panel3.Controls.Add(this.buttonSupplierListPageListPrevious);
            this.panel3.Controls.Add(this.buttonSupplierListPageListNext);
            this.panel3.Controls.Add(this.buttonSupplierListPageListLast);
            this.panel3.Controls.Add(this.textBoxSupplierListPageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 566);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1382, 53);
            this.panel3.TabIndex = 21;
            // 
            // textBoxSupplierListPageNumber
            // 
            this.textBoxSupplierListPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSupplierListPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxSupplierListPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSupplierListPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxSupplierListPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxSupplierListPageNumber.Name = "textBoxSupplierListPageNumber";
            this.textBoxSupplierListPageNumber.ReadOnly = true;
            this.textBoxSupplierListPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxSupplierListPageNumber.TabIndex = 17;
            this.textBoxSupplierListPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewSupplierList);
            this.panel2.Controls.Add(this.textBoxSupplierListFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1382, 619);
            this.panel2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(63, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Supplier List";
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
            this.buttonClose.Location = new System.Drawing.Point(1282, 12);
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
            this.buttonAdd.Location = new System.Drawing.Point(1188, 12);
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
            this.panel1.Size = new System.Drawing.Size(1382, 63);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.Supplier;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // MstSupplierListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1382, 682);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MstSupplierListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSupplierList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSupplierListFilter;
        private System.Windows.Forms.Button buttonSupplierListPageListFirst;
        private System.Windows.Forms.Button buttonSupplierListPageListPrevious;
        private System.Windows.Forms.Button buttonSupplierListPageListNext;
        private System.Windows.Forms.DataGridView dataGridViewSupplierList;
        private System.Windows.Forms.Button buttonSupplierListPageListLast;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxSupplierListPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnSupplierListButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnSupplierListButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSupplierListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSupplierListSupplierCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSupplierListSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSupplierListContactNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSupplierListAddress;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnSupplierListIsLocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSupplierListSpace;
    }
}