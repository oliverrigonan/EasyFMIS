namespace easyfmis.Forms.Software.MstUser
{
    partial class MstUserDetailForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MstUserDetailForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonLock = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonUnlock = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.buttonAddUserForm = new System.Windows.Forms.Button();
            this.dataGridViewUserFormList = new System.Windows.Forms.DataGridView();
            this.ColumnUserFormListButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnUserFormListButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnUserFormListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUserFormListFormId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUserFormListForm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUserFormListUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUserFormListCanDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnUserFormListCanAdd = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnUserFormListCanLock = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnUserFormListCanUnlock = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnUserFormListCanPrint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnUserFormListCanPreview = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnUserFormListCanEdit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonUserFormListPageListFirst = new System.Windows.Forms.Button();
            this.buttonUserFormListPageListPrevious = new System.Windows.Forms.Button();
            this.buttonUserFormListPageListNext = new System.Windows.Forms.Button();
            this.buttonUserFormListPageListLast = new System.Windows.Forms.Button();
            this.textBoxUserFormListPageNumber = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxCompany = new System.Windows.Forms.ComboBox();
            this.comboBoxBranch = new System.Windows.Forms.ComboBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserFormList)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.buttonLock);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.buttonUnlock);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1091, 50);
            this.panel1.TabIndex = 5;
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
            this.buttonLock.Location = new System.Drawing.Point(861, 10);
            this.buttonLock.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonLock.Name = "buttonLock";
            this.buttonLock.Size = new System.Drawing.Size(70, 32);
            this.buttonLock.TabIndex = 20;
            this.buttonLock.Text = "Lock";
            this.buttonLock.UseVisualStyleBackColor = false;
            this.buttonLock.Click += new System.EventHandler(this.buttonLock_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.User;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.label1.Size = new System.Drawing.Size(117, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "User Detail";
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
            this.buttonClose.Location = new System.Drawing.Point(1011, 10);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(70, 32);
            this.buttonClose.TabIndex = 22;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
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
            this.buttonUnlock.Location = new System.Drawing.Point(936, 10);
            this.buttonUnlock.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonUnlock.Name = "buttonUnlock";
            this.buttonUnlock.Size = new System.Drawing.Size(70, 32);
            this.buttonUnlock.TabIndex = 21;
            this.buttonUnlock.Text = "Unlock";
            this.buttonUnlock.UseVisualStyleBackColor = false;
            this.buttonUnlock.Click += new System.EventHandler(this.buttonUnlock_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1091, 510);
            this.panel2.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.buttonAddUserForm);
            this.panel6.Controls.Add(this.dataGridViewUserFormList);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 95);
            this.panel6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1091, 373);
            this.panel6.TabIndex = 29;
            // 
            // buttonAddUserForm
            // 
            this.buttonAddUserForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddUserForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonAddUserForm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(34)))), ((int)(((byte)(116)))));
            this.buttonAddUserForm.FlatAppearance.BorderSize = 0;
            this.buttonAddUserForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddUserForm.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.buttonAddUserForm.ForeColor = System.Drawing.Color.White;
            this.buttonAddUserForm.Location = new System.Drawing.Point(1011, 5);
            this.buttonAddUserForm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAddUserForm.Name = "buttonAddUserForm";
            this.buttonAddUserForm.Size = new System.Drawing.Size(70, 32);
            this.buttonAddUserForm.TabIndex = 5;
            this.buttonAddUserForm.Text = "Add";
            this.buttonAddUserForm.UseVisualStyleBackColor = false;
            this.buttonAddUserForm.Click += new System.EventHandler(this.buttonAddUserForm_Click);
            // 
            // dataGridViewUserFormList
            // 
            this.dataGridViewUserFormList.AllowUserToAddRows = false;
            this.dataGridViewUserFormList.AllowUserToDeleteRows = false;
            this.dataGridViewUserFormList.AllowUserToResizeRows = false;
            this.dataGridViewUserFormList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewUserFormList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUserFormList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewUserFormList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUserFormList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnUserFormListButtonEdit,
            this.ColumnUserFormListButtonDelete,
            this.ColumnUserFormListId,
            this.ColumnUserFormListFormId,
            this.ColumnUserFormListForm,
            this.ColumnUserFormListUserId,
            this.ColumnUserFormListCanDelete,
            this.ColumnUserFormListCanAdd,
            this.ColumnUserFormListCanLock,
            this.ColumnUserFormListCanUnlock,
            this.ColumnUserFormListCanPrint,
            this.ColumnUserFormListCanPreview,
            this.ColumnUserFormListCanEdit});
            this.dataGridViewUserFormList.Location = new System.Drawing.Point(10, 42);
            this.dataGridViewUserFormList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewUserFormList.MultiSelect = false;
            this.dataGridViewUserFormList.Name = "dataGridViewUserFormList";
            this.dataGridViewUserFormList.ReadOnly = true;
            this.dataGridViewUserFormList.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.dataGridViewUserFormList.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewUserFormList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.dataGridViewUserFormList.RowTemplate.Height = 24;
            this.dataGridViewUserFormList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUserFormList.Size = new System.Drawing.Size(1072, 327);
            this.dataGridViewUserFormList.TabIndex = 1;
            this.dataGridViewUserFormList.TabStop = false;
            this.dataGridViewUserFormList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUserFormList_CellClick);
            // 
            // ColumnUserFormListButtonEdit
            // 
            this.ColumnUserFormListButtonEdit.DataPropertyName = "ColumnUserFormListButtonEdit";
            this.ColumnUserFormListButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnUserFormListButtonEdit.HeaderText = "";
            this.ColumnUserFormListButtonEdit.Name = "ColumnUserFormListButtonEdit";
            this.ColumnUserFormListButtonEdit.ReadOnly = true;
            this.ColumnUserFormListButtonEdit.Width = 70;
            // 
            // ColumnUserFormListButtonDelete
            // 
            this.ColumnUserFormListButtonDelete.DataPropertyName = "ColumnUserFormListButtonDelete";
            this.ColumnUserFormListButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnUserFormListButtonDelete.HeaderText = "";
            this.ColumnUserFormListButtonDelete.Name = "ColumnUserFormListButtonDelete";
            this.ColumnUserFormListButtonDelete.ReadOnly = true;
            this.ColumnUserFormListButtonDelete.Width = 70;
            // 
            // ColumnUserFormListId
            // 
            this.ColumnUserFormListId.DataPropertyName = "ColumnUserFormListId";
            this.ColumnUserFormListId.HeaderText = "Id";
            this.ColumnUserFormListId.Name = "ColumnUserFormListId";
            this.ColumnUserFormListId.ReadOnly = true;
            this.ColumnUserFormListId.Visible = false;
            // 
            // ColumnUserFormListFormId
            // 
            this.ColumnUserFormListFormId.DataPropertyName = "ColumnUserFormListFormId";
            this.ColumnUserFormListFormId.HeaderText = "Form Id";
            this.ColumnUserFormListFormId.Name = "ColumnUserFormListFormId";
            this.ColumnUserFormListFormId.ReadOnly = true;
            this.ColumnUserFormListFormId.Visible = false;
            // 
            // ColumnUserFormListForm
            // 
            this.ColumnUserFormListForm.DataPropertyName = "ColumnUserFormListForm";
            this.ColumnUserFormListForm.HeaderText = "Form";
            this.ColumnUserFormListForm.Name = "ColumnUserFormListForm";
            this.ColumnUserFormListForm.ReadOnly = true;
            this.ColumnUserFormListForm.Width = 300;
            // 
            // ColumnUserFormListUserId
            // 
            this.ColumnUserFormListUserId.DataPropertyName = "ColumnUserFormListUserId";
            this.ColumnUserFormListUserId.HeaderText = "User Id";
            this.ColumnUserFormListUserId.Name = "ColumnUserFormListUserId";
            this.ColumnUserFormListUserId.ReadOnly = true;
            this.ColumnUserFormListUserId.Visible = false;
            // 
            // ColumnUserFormListCanDelete
            // 
            this.ColumnUserFormListCanDelete.DataPropertyName = "ColumnUserFormListCanDelete";
            this.ColumnUserFormListCanDelete.HeaderText = "Delete";
            this.ColumnUserFormListCanDelete.Name = "ColumnUserFormListCanDelete";
            this.ColumnUserFormListCanDelete.ReadOnly = true;
            this.ColumnUserFormListCanDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnUserFormListCanDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnUserFormListCanDelete.Width = 80;
            // 
            // ColumnUserFormListCanAdd
            // 
            this.ColumnUserFormListCanAdd.DataPropertyName = "ColumnUserFormListCanAdd";
            this.ColumnUserFormListCanAdd.HeaderText = "Add";
            this.ColumnUserFormListCanAdd.Name = "ColumnUserFormListCanAdd";
            this.ColumnUserFormListCanAdd.ReadOnly = true;
            this.ColumnUserFormListCanAdd.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnUserFormListCanAdd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnUserFormListCanAdd.Width = 80;
            // 
            // ColumnUserFormListCanLock
            // 
            this.ColumnUserFormListCanLock.DataPropertyName = "ColumnUserFormListCanLock";
            this.ColumnUserFormListCanLock.HeaderText = "Lock";
            this.ColumnUserFormListCanLock.Name = "ColumnUserFormListCanLock";
            this.ColumnUserFormListCanLock.ReadOnly = true;
            this.ColumnUserFormListCanLock.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnUserFormListCanLock.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnUserFormListCanLock.Width = 80;
            // 
            // ColumnUserFormListCanUnlock
            // 
            this.ColumnUserFormListCanUnlock.DataPropertyName = "ColumnUserFormListCanUnlock";
            this.ColumnUserFormListCanUnlock.HeaderText = "Unlock";
            this.ColumnUserFormListCanUnlock.Name = "ColumnUserFormListCanUnlock";
            this.ColumnUserFormListCanUnlock.ReadOnly = true;
            this.ColumnUserFormListCanUnlock.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnUserFormListCanUnlock.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnUserFormListCanUnlock.Width = 80;
            // 
            // ColumnUserFormListCanPrint
            // 
            this.ColumnUserFormListCanPrint.DataPropertyName = "ColumnUserFormListCanPrint";
            this.ColumnUserFormListCanPrint.HeaderText = "Print";
            this.ColumnUserFormListCanPrint.Name = "ColumnUserFormListCanPrint";
            this.ColumnUserFormListCanPrint.ReadOnly = true;
            this.ColumnUserFormListCanPrint.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnUserFormListCanPrint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnUserFormListCanPrint.Width = 80;
            // 
            // ColumnUserFormListCanPreview
            // 
            this.ColumnUserFormListCanPreview.DataPropertyName = "ColumnUserFormListCanPreview";
            this.ColumnUserFormListCanPreview.HeaderText = "Preview";
            this.ColumnUserFormListCanPreview.Name = "ColumnUserFormListCanPreview";
            this.ColumnUserFormListCanPreview.ReadOnly = true;
            this.ColumnUserFormListCanPreview.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnUserFormListCanPreview.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnUserFormListCanPreview.Width = 80;
            // 
            // ColumnUserFormListCanEdit
            // 
            this.ColumnUserFormListCanEdit.DataPropertyName = "ColumnUserFormListCanEdit";
            this.ColumnUserFormListCanEdit.HeaderText = "Edit";
            this.ColumnUserFormListCanEdit.Name = "ColumnUserFormListCanEdit";
            this.ColumnUserFormListCanEdit.ReadOnly = true;
            this.ColumnUserFormListCanEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnUserFormListCanEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnUserFormListCanEdit.Width = 80;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.buttonUserFormListPageListFirst);
            this.panel4.Controls.Add(this.buttonUserFormListPageListPrevious);
            this.panel4.Controls.Add(this.buttonUserFormListPageListNext);
            this.panel4.Controls.Add(this.buttonUserFormListPageListLast);
            this.panel4.Controls.Add(this.textBoxUserFormListPageNumber);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 468);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1091, 42);
            this.panel4.TabIndex = 27;
            // 
            // buttonUserFormListPageListFirst
            // 
            this.buttonUserFormListPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUserFormListPageListFirst.Enabled = false;
            this.buttonUserFormListPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonUserFormListPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUserFormListPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonUserFormListPageListFirst.Location = new System.Drawing.Point(10, 7);
            this.buttonUserFormListPageListFirst.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonUserFormListPageListFirst.Name = "buttonUserFormListPageListFirst";
            this.buttonUserFormListPageListFirst.Size = new System.Drawing.Size(66, 26);
            this.buttonUserFormListPageListFirst.TabIndex = 13;
            this.buttonUserFormListPageListFirst.Text = "First";
            this.buttonUserFormListPageListFirst.UseVisualStyleBackColor = false;
            this.buttonUserFormListPageListFirst.Click += new System.EventHandler(this.buttonUserFormListPageListFirst_Click);
            // 
            // buttonUserFormListPageListPrevious
            // 
            this.buttonUserFormListPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUserFormListPageListPrevious.Enabled = false;
            this.buttonUserFormListPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonUserFormListPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUserFormListPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonUserFormListPageListPrevious.Location = new System.Drawing.Point(80, 7);
            this.buttonUserFormListPageListPrevious.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonUserFormListPageListPrevious.Name = "buttonUserFormListPageListPrevious";
            this.buttonUserFormListPageListPrevious.Size = new System.Drawing.Size(66, 26);
            this.buttonUserFormListPageListPrevious.TabIndex = 14;
            this.buttonUserFormListPageListPrevious.Text = "Previous";
            this.buttonUserFormListPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonUserFormListPageListPrevious.Click += new System.EventHandler(this.buttonUserFormListPageListPrevious_Click);
            // 
            // buttonUserFormListPageListNext
            // 
            this.buttonUserFormListPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUserFormListPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonUserFormListPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUserFormListPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonUserFormListPageListNext.Location = new System.Drawing.Point(210, 7);
            this.buttonUserFormListPageListNext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonUserFormListPageListNext.Name = "buttonUserFormListPageListNext";
            this.buttonUserFormListPageListNext.Size = new System.Drawing.Size(66, 26);
            this.buttonUserFormListPageListNext.TabIndex = 15;
            this.buttonUserFormListPageListNext.Text = "Next";
            this.buttonUserFormListPageListNext.UseVisualStyleBackColor = false;
            this.buttonUserFormListPageListNext.Click += new System.EventHandler(this.buttonUserFormListPageListNext_Click);
            // 
            // buttonUserFormListPageListLast
            // 
            this.buttonUserFormListPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUserFormListPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonUserFormListPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUserFormListPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonUserFormListPageListLast.Location = new System.Drawing.Point(278, 7);
            this.buttonUserFormListPageListLast.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonUserFormListPageListLast.Name = "buttonUserFormListPageListLast";
            this.buttonUserFormListPageListLast.Size = new System.Drawing.Size(66, 26);
            this.buttonUserFormListPageListLast.TabIndex = 16;
            this.buttonUserFormListPageListLast.Text = "Last";
            this.buttonUserFormListPageListLast.UseVisualStyleBackColor = false;
            this.buttonUserFormListPageListLast.Click += new System.EventHandler(this.buttonUserFormListPageListLast_Click);
            // 
            // textBoxUserFormListPageNumber
            // 
            this.textBoxUserFormListPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxUserFormListPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxUserFormListPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUserFormListPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxUserFormListPageNumber.Location = new System.Drawing.Point(150, 11);
            this.textBoxUserFormListPageNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxUserFormListPageNumber.Name = "textBoxUserFormListPageNumber";
            this.textBoxUserFormListPageNumber.ReadOnly = true;
            this.textBoxUserFormListPageNumber.Size = new System.Drawing.Size(55, 16);
            this.textBoxUserFormListPageNumber.TabIndex = 17;
            this.textBoxUserFormListPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.comboBoxCompany);
            this.panel3.Controls.Add(this.comboBoxBranch);
            this.panel3.Controls.Add(this.textBoxPassword);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.textBoxFullName);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.textBoxUserName);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.panel3.Size = new System.Drawing.Size(1091, 95);
            this.panel3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label2.Location = new System.Drawing.Point(404, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Branch:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label6.Location = new System.Drawing.Point(388, 8);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "Company:";
            // 
            // comboBoxCompany
            // 
            this.comboBoxCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCompany.FormattingEnabled = true;
            this.comboBoxCompany.Location = new System.Drawing.Point(466, 6);
            this.comboBoxCompany.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxCompany.Name = "comboBoxCompany";
            this.comboBoxCompany.Size = new System.Drawing.Size(239, 27);
            this.comboBoxCompany.TabIndex = 3;
            // 
            // comboBoxBranch
            // 
            this.comboBoxBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxBranch.FormattingEnabled = true;
            this.comboBoxBranch.Location = new System.Drawing.Point(466, 37);
            this.comboBoxBranch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxBranch.Name = "comboBoxBranch";
            this.comboBoxBranch.Size = new System.Drawing.Size(239, 27);
            this.comboBoxBranch.TabIndex = 4;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxPassword.Location = new System.Drawing.Point(88, 66);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '•';
            this.textBoxPassword.Size = new System.Drawing.Size(256, 26);
            this.textBoxPassword.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label5.Location = new System.Drawing.Point(16, 69);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Password:";
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxFullName.Location = new System.Drawing.Point(88, 6);
            this.textBoxFullName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(256, 26);
            this.textBoxFullName.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label4.Location = new System.Drawing.Point(17, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Fullname:";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxUserName.Location = new System.Drawing.Point(88, 36);
            this.textBoxUserName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(256, 26);
            this.textBoxUserName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label3.Location = new System.Drawing.Point(10, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Username:";
            // 
            // MstUserDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1091, 560);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MstUserDetailForm";
            this.Text = "MstUserDetailForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserFormList)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonUnlock;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonLock;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAddUserForm;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonUserFormListPageListFirst;
        private System.Windows.Forms.Button buttonUserFormListPageListPrevious;
        private System.Windows.Forms.Button buttonUserFormListPageListNext;
        private System.Windows.Forms.Button buttonUserFormListPageListLast;
        private System.Windows.Forms.TextBox textBoxUserFormListPageNumber;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dataGridViewUserFormList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxCompany;
        private System.Windows.Forms.ComboBox comboBoxBranch;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnUserFormListButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnUserFormListButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUserFormListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUserFormListFormId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUserFormListForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUserFormListUserId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnUserFormListCanDelete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnUserFormListCanAdd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnUserFormListCanLock;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnUserFormListCanUnlock;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnUserFormListCanPrint;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnUserFormListCanPreview;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnUserFormListCanEdit;
    }
}