namespace easyfmis.Forms.Software.MstCompany
{
    partial class MstCompanyListForm
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
            this.textBoxCompanyListFilter = new System.Windows.Forms.TextBox();
            this.buttonCompanyListPageListFirst = new System.Windows.Forms.Button();
            this.buttonCompanyListPageListPrevious = new System.Windows.Forms.Button();
            this.buttonCompanyListPageListNext = new System.Windows.Forms.Button();
            this.dataGridViewCompanyList = new System.Windows.Forms.DataGridView();
            this.ColumnCompanyListButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnCompanyListButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnCustomerListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyListCompanyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyListCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyListIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.buttonCompanyListPageListLast = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxCompanyListPageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompanyList)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxCompanyListFilter
            // 
            this.textBoxCompanyListFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCompanyListFilter.Location = new System.Drawing.Point(12, 6);
            this.textBoxCompanyListFilter.Name = "textBoxCompanyListFilter";
            this.textBoxCompanyListFilter.Size = new System.Drawing.Size(1358, 30);
            this.textBoxCompanyListFilter.TabIndex = 0;
            this.textBoxCompanyListFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCompanyListFilter_KeyDown);
            // 
            // buttonCompanyListPageListFirst
            // 
            this.buttonCompanyListPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCompanyListPageListFirst.Enabled = false;
            this.buttonCompanyListPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonCompanyListPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCompanyListPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonCompanyListPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonCompanyListPageListFirst.Name = "buttonCompanyListPageListFirst";
            this.buttonCompanyListPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonCompanyListPageListFirst.TabIndex = 13;
            this.buttonCompanyListPageListFirst.Text = "First";
            this.buttonCompanyListPageListFirst.UseVisualStyleBackColor = false;
            this.buttonCompanyListPageListFirst.Click += new System.EventHandler(this.buttonCompanyListPageListFirst_Click);
            // 
            // buttonCompanyListPageListPrevious
            // 
            this.buttonCompanyListPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCompanyListPageListPrevious.Enabled = false;
            this.buttonCompanyListPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonCompanyListPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCompanyListPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonCompanyListPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonCompanyListPageListPrevious.Name = "buttonCompanyListPageListPrevious";
            this.buttonCompanyListPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonCompanyListPageListPrevious.TabIndex = 14;
            this.buttonCompanyListPageListPrevious.Text = "Previous";
            this.buttonCompanyListPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonCompanyListPageListPrevious.Click += new System.EventHandler(this.buttonCompanyListPageListPrevious_Click);
            // 
            // buttonCompanyListPageListNext
            // 
            this.buttonCompanyListPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCompanyListPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonCompanyListPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCompanyListPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonCompanyListPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonCompanyListPageListNext.Name = "buttonCompanyListPageListNext";
            this.buttonCompanyListPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonCompanyListPageListNext.TabIndex = 15;
            this.buttonCompanyListPageListNext.Text = "Next";
            this.buttonCompanyListPageListNext.UseVisualStyleBackColor = false;
            this.buttonCompanyListPageListNext.Click += new System.EventHandler(this.buttonCompanyListPageListNext_Click);
            // 
            // dataGridViewCompanyList
            // 
            this.dataGridViewCompanyList.AllowUserToAddRows = false;
            this.dataGridViewCompanyList.AllowUserToDeleteRows = false;
            this.dataGridViewCompanyList.AllowUserToResizeRows = false;
            this.dataGridViewCompanyList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCompanyList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCompanyList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCompanyList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCompanyListButtonEdit,
            this.ColumnCompanyListButtonDelete,
            this.ColumnCustomerListId,
            this.ColumnCompanyListCompanyCode,
            this.ColumnCompanyListCompany,
            this.ColumnCompanyListIsLocked});
            this.dataGridViewCompanyList.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewCompanyList.MultiSelect = false;
            this.dataGridViewCompanyList.Name = "dataGridViewCompanyList";
            this.dataGridViewCompanyList.ReadOnly = true;
            this.dataGridViewCompanyList.RowHeadersVisible = false;
            this.dataGridViewCompanyList.RowTemplate.Height = 24;
            this.dataGridViewCompanyList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCompanyList.Size = new System.Drawing.Size(1358, 518);
            this.dataGridViewCompanyList.TabIndex = 20;
            this.dataGridViewCompanyList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCompanyList_CellClick);
            // 
            // ColumnCompanyListButtonEdit
            // 
            this.ColumnCompanyListButtonEdit.DataPropertyName = "ColumnCompanyListButtonEdit";
            this.ColumnCompanyListButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnCompanyListButtonEdit.HeaderText = "";
            this.ColumnCompanyListButtonEdit.Name = "ColumnCompanyListButtonEdit";
            this.ColumnCompanyListButtonEdit.ReadOnly = true;
            this.ColumnCompanyListButtonEdit.Width = 70;
            // 
            // ColumnCompanyListButtonDelete
            // 
            this.ColumnCompanyListButtonDelete.DataPropertyName = "ColumnCompanyListButtonDelete";
            this.ColumnCompanyListButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnCompanyListButtonDelete.HeaderText = "";
            this.ColumnCompanyListButtonDelete.Name = "ColumnCompanyListButtonDelete";
            this.ColumnCompanyListButtonDelete.ReadOnly = true;
            this.ColumnCompanyListButtonDelete.Width = 70;
            // 
            // ColumnCustomerListId
            // 
            this.ColumnCustomerListId.DataPropertyName = "ColumnCompanyListId";
            this.ColumnCustomerListId.HeaderText = "Id";
            this.ColumnCustomerListId.Name = "ColumnCustomerListId";
            this.ColumnCustomerListId.ReadOnly = true;
            this.ColumnCustomerListId.Visible = false;
            // 
            // ColumnCompanyListCompanyCode
            // 
            this.ColumnCompanyListCompanyCode.DataPropertyName = "ColumnCompanyListCompanyCode";
            this.ColumnCompanyListCompanyCode.HeaderText = "Code";
            this.ColumnCompanyListCompanyCode.Name = "ColumnCompanyListCompanyCode";
            this.ColumnCompanyListCompanyCode.ReadOnly = true;
            this.ColumnCompanyListCompanyCode.Width = 150;
            // 
            // ColumnCompanyListCompany
            // 
            this.ColumnCompanyListCompany.DataPropertyName = "ColumnCompanyListCompany";
            this.ColumnCompanyListCompany.HeaderText = "Company";
            this.ColumnCompanyListCompany.Name = "ColumnCompanyListCompany";
            this.ColumnCompanyListCompany.ReadOnly = true;
            this.ColumnCompanyListCompany.Width = 250;
            // 
            // ColumnCompanyListIsLocked
            // 
            this.ColumnCompanyListIsLocked.DataPropertyName = "ColumnCompanyListIsLocked";
            this.ColumnCompanyListIsLocked.HeaderText = "L";
            this.ColumnCompanyListIsLocked.Name = "ColumnCompanyListIsLocked";
            this.ColumnCompanyListIsLocked.ReadOnly = true;
            this.ColumnCompanyListIsLocked.Width = 35;
            // 
            // buttonCompanyListPageListLast
            // 
            this.buttonCompanyListPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCompanyListPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonCompanyListPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCompanyListPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonCompanyListPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonCompanyListPageListLast.Name = "buttonCompanyListPageListLast";
            this.buttonCompanyListPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonCompanyListPageListLast.TabIndex = 16;
            this.buttonCompanyListPageListLast.Text = "Last";
            this.buttonCompanyListPageListLast.UseVisualStyleBackColor = false;
            this.buttonCompanyListPageListLast.Click += new System.EventHandler(this.buttonCompanyListPageListLast_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonCompanyListPageListFirst);
            this.panel3.Controls.Add(this.buttonCompanyListPageListPrevious);
            this.panel3.Controls.Add(this.buttonCompanyListPageListNext);
            this.panel3.Controls.Add(this.buttonCompanyListPageListLast);
            this.panel3.Controls.Add(this.textBoxCompanyListPageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 566);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1382, 53);
            this.panel3.TabIndex = 21;
            // 
            // textBoxCompanyListPageNumber
            // 
            this.textBoxCompanyListPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxCompanyListPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxCompanyListPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCompanyListPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxCompanyListPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxCompanyListPageNumber.Name = "textBoxCompanyListPageNumber";
            this.textBoxCompanyListPageNumber.ReadOnly = true;
            this.textBoxCompanyListPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxCompanyListPageNumber.TabIndex = 17;
            this.textBoxCompanyListPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewCompanyList);
            this.panel2.Controls.Add(this.textBoxCompanyListFilter);
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
            this.label1.Size = new System.Drawing.Size(174, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Company List";
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
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.building;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // MstCompanyListForm
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
            this.Name = "MstCompanyListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompanyList)).EndInit();
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

        private System.Windows.Forms.TextBox textBoxCompanyListFilter;
        private System.Windows.Forms.Button buttonCompanyListPageListFirst;
        private System.Windows.Forms.Button buttonCompanyListPageListPrevious;
        private System.Windows.Forms.Button buttonCompanyListPageListNext;
        private System.Windows.Forms.DataGridView dataGridViewCompanyList;
        private System.Windows.Forms.Button buttonCompanyListPageListLast;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxCompanyListPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnCompanyListButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnCompanyListButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCustomerListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyListCompanyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyListCompany;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCompanyListIsLocked;
    }
}