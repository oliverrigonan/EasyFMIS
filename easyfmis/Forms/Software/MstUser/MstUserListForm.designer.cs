namespace easyfmis.Forms.Software.MstUser
{
    partial class MstUserListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MstUserListForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxUserListFilter = new System.Windows.Forms.TextBox();
            this.dataGridViewUserList = new System.Windows.Forms.DataGridView();
            this.ColumnUserListButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnUserListButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnUserListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUserListUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUserListFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUserListBranchId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUserListBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUserListCompanyId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUserListCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUserListIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.textBoxUserListPageNumber = new System.Windows.Forms.TextBox();
            this.buttonUserListPageListLast = new System.Windows.Forms.Button();
            this.buttonUserListPageListNext = new System.Windows.Forms.Button();
            this.buttonUserListPageListPrevious = new System.Windows.Forms.Button();
            this.buttonUserListPageListFirst = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserList)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
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
            this.panel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.User;
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
            this.label1.Size = new System.Drawing.Size(116, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "User List";
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
            // textBoxUserListFilter
            // 
            this.textBoxUserListFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUserListFilter.Location = new System.Drawing.Point(12, 6);
            this.textBoxUserListFilter.Name = "textBoxUserListFilter";
            this.textBoxUserListFilter.Size = new System.Drawing.Size(1376, 30);
            this.textBoxUserListFilter.TabIndex = 0;
            this.textBoxUserListFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxUserListFilter_KeyDown);
            // 
            // dataGridViewUserList
            // 
            this.dataGridViewUserList.AllowUserToAddRows = false;
            this.dataGridViewUserList.AllowUserToDeleteRows = false;
            this.dataGridViewUserList.AllowUserToResizeRows = false;
            this.dataGridViewUserList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewUserList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUserList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnUserListButtonEdit,
            this.ColumnUserListButtonDelete,
            this.ColumnUserListId,
            this.ColumnUserListUserName,
            this.ColumnUserListFullName,
            this.ColumnUserListBranchId,
            this.ColumnUserListBranch,
            this.ColumnUserListCompanyId,
            this.ColumnUserListCompany,
            this.ColumnUserListIsLocked});
            this.dataGridViewUserList.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewUserList.MultiSelect = false;
            this.dataGridViewUserList.Name = "dataGridViewUserList";
            this.dataGridViewUserList.ReadOnly = true;
            this.dataGridViewUserList.RowHeadersVisible = false;
            this.dataGridViewUserList.RowTemplate.Height = 24;
            this.dataGridViewUserList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUserList.Size = new System.Drawing.Size(1376, 536);
            this.dataGridViewUserList.TabIndex = 9;
            this.dataGridViewUserList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUserList_CellClick);
            // 
            // ColumnUserListButtonEdit
            // 
            this.ColumnUserListButtonEdit.DataPropertyName = "ColumnUserListButtonEdit";
            this.ColumnUserListButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnUserListButtonEdit.HeaderText = "";
            this.ColumnUserListButtonEdit.Name = "ColumnUserListButtonEdit";
            this.ColumnUserListButtonEdit.ReadOnly = true;
            this.ColumnUserListButtonEdit.Width = 70;
            // 
            // ColumnUserListButtonDelete
            // 
            this.ColumnUserListButtonDelete.DataPropertyName = "ColumnUserListButtonDelete";
            this.ColumnUserListButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnUserListButtonDelete.HeaderText = "";
            this.ColumnUserListButtonDelete.Name = "ColumnUserListButtonDelete";
            this.ColumnUserListButtonDelete.ReadOnly = true;
            this.ColumnUserListButtonDelete.Width = 70;
            // 
            // ColumnUserListId
            // 
            this.ColumnUserListId.DataPropertyName = "ColumnUserListId";
            this.ColumnUserListId.HeaderText = "Id";
            this.ColumnUserListId.Name = "ColumnUserListId";
            this.ColumnUserListId.ReadOnly = true;
            this.ColumnUserListId.Visible = false;
            // 
            // ColumnUserListUserName
            // 
            this.ColumnUserListUserName.DataPropertyName = "ColumnUserListUserName";
            this.ColumnUserListUserName.HeaderText = "Username";
            this.ColumnUserListUserName.Name = "ColumnUserListUserName";
            this.ColumnUserListUserName.ReadOnly = true;
            this.ColumnUserListUserName.Width = 250;
            // 
            // ColumnUserListFullName
            // 
            this.ColumnUserListFullName.DataPropertyName = "ColumnUserListFullName";
            this.ColumnUserListFullName.HeaderText = "Fullname";
            this.ColumnUserListFullName.Name = "ColumnUserListFullName";
            this.ColumnUserListFullName.ReadOnly = true;
            this.ColumnUserListFullName.Width = 250;
            // 
            // ColumnUserListBranchId
            // 
            this.ColumnUserListBranchId.DataPropertyName = "ColumnUserListBranchId";
            this.ColumnUserListBranchId.HeaderText = "BranchId";
            this.ColumnUserListBranchId.Name = "ColumnUserListBranchId";
            this.ColumnUserListBranchId.ReadOnly = true;
            this.ColumnUserListBranchId.Visible = false;
            // 
            // ColumnUserListBranch
            // 
            this.ColumnUserListBranch.DataPropertyName = "ColumnUserListBranch";
            this.ColumnUserListBranch.HeaderText = "Branch";
            this.ColumnUserListBranch.Name = "ColumnUserListBranch";
            this.ColumnUserListBranch.ReadOnly = true;
            this.ColumnUserListBranch.Width = 200;
            // 
            // ColumnUserListCompanyId
            // 
            this.ColumnUserListCompanyId.DataPropertyName = "ColumnUserListCompanyId";
            this.ColumnUserListCompanyId.HeaderText = "CompanyId";
            this.ColumnUserListCompanyId.Name = "ColumnUserListCompanyId";
            this.ColumnUserListCompanyId.ReadOnly = true;
            this.ColumnUserListCompanyId.Visible = false;
            // 
            // ColumnUserListCompany
            // 
            this.ColumnUserListCompany.DataPropertyName = "ColumnUserListCompany";
            this.ColumnUserListCompany.HeaderText = "Company";
            this.ColumnUserListCompany.Name = "ColumnUserListCompany";
            this.ColumnUserListCompany.ReadOnly = true;
            this.ColumnUserListCompany.Width = 200;
            // 
            // ColumnUserListIsLocked
            // 
            this.ColumnUserListIsLocked.DataPropertyName = "ColumnUserListIsLocked";
            this.ColumnUserListIsLocked.HeaderText = "L";
            this.ColumnUserListIsLocked.Name = "ColumnUserListIsLocked";
            this.ColumnUserListIsLocked.ReadOnly = true;
            this.ColumnUserListIsLocked.Width = 35;
            // 
            // textBoxUserListPageNumber
            // 
            this.textBoxUserListPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxUserListPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxUserListPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUserListPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxUserListPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxUserListPageNumber.Name = "textBoxUserListPageNumber";
            this.textBoxUserListPageNumber.ReadOnly = true;
            this.textBoxUserListPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxUserListPageNumber.TabIndex = 17;
            this.textBoxUserListPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonUserListPageListLast
            // 
            this.buttonUserListPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUserListPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonUserListPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUserListPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonUserListPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonUserListPageListLast.Name = "buttonUserListPageListLast";
            this.buttonUserListPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonUserListPageListLast.TabIndex = 16;
            this.buttonUserListPageListLast.Text = "Last";
            this.buttonUserListPageListLast.UseVisualStyleBackColor = false;
            this.buttonUserListPageListLast.Click += new System.EventHandler(this.buttonUserListPageListLast_Click);
            // 
            // buttonUserListPageListNext
            // 
            this.buttonUserListPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUserListPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonUserListPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUserListPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonUserListPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonUserListPageListNext.Name = "buttonUserListPageListNext";
            this.buttonUserListPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonUserListPageListNext.TabIndex = 15;
            this.buttonUserListPageListNext.Text = "Next";
            this.buttonUserListPageListNext.UseVisualStyleBackColor = false;
            this.buttonUserListPageListNext.Click += new System.EventHandler(this.buttonUserListPageListNext_Click);
            // 
            // buttonUserListPageListPrevious
            // 
            this.buttonUserListPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUserListPageListPrevious.Enabled = false;
            this.buttonUserListPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonUserListPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUserListPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonUserListPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonUserListPageListPrevious.Name = "buttonUserListPageListPrevious";
            this.buttonUserListPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonUserListPageListPrevious.TabIndex = 14;
            this.buttonUserListPageListPrevious.Text = "Previous";
            this.buttonUserListPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonUserListPageListPrevious.Click += new System.EventHandler(this.buttonUserListPageListPrevious_Click);
            // 
            // buttonUserListPageListFirst
            // 
            this.buttonUserListPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUserListPageListFirst.Enabled = false;
            this.buttonUserListPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonUserListPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUserListPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonUserListPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonUserListPageListFirst.Name = "buttonUserListPageListFirst";
            this.buttonUserListPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonUserListPageListFirst.TabIndex = 13;
            this.buttonUserListPageListFirst.Text = "First";
            this.buttonUserListPageListFirst.UseVisualStyleBackColor = false;
            this.buttonUserListPageListFirst.Click += new System.EventHandler(this.buttonUserListPageListFirst_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewUserList);
            this.panel2.Controls.Add(this.textBoxUserListFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1400, 637);
            this.panel2.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonUserListPageListFirst);
            this.panel3.Controls.Add(this.buttonUserListPageListPrevious);
            this.panel3.Controls.Add(this.buttonUserListPageListNext);
            this.panel3.Controls.Add(this.buttonUserListPageListLast);
            this.panel3.Controls.Add(this.textBoxUserListPageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 584);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1400, 53);
            this.panel3.TabIndex = 18;
            // 
            // MstUserListForm
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
            this.Name = "MstUserListForm";
            this.Text = "MstUserListForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserList)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxUserListFilter;
        private System.Windows.Forms.DataGridView dataGridViewUserList;
        private System.Windows.Forms.TextBox textBoxUserListPageNumber;
        private System.Windows.Forms.Button buttonUserListPageListLast;
        private System.Windows.Forms.Button buttonUserListPageListNext;
        private System.Windows.Forms.Button buttonUserListPageListPrevious;
        private System.Windows.Forms.Button buttonUserListPageListFirst;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnUserListButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnUserListButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUserListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUserListUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUserListFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUserListBranchId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUserListBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUserListCompanyId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUserListCompany;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnUserListIsLocked;
    }
}