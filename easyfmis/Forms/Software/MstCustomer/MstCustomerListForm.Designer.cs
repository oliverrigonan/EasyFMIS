namespace easyfmis.Forms.Software.MstCustomer
{
    partial class MstCustomerListForm
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
            this.textBoxCustomerListFilter = new System.Windows.Forms.TextBox();
            this.buttonCustomerListPageListFirst = new System.Windows.Forms.Button();
            this.buttonCustomerListPageListPrevious = new System.Windows.Forms.Button();
            this.buttonCustomerListPageListNext = new System.Windows.Forms.Button();
            this.dataGridViewCustomerList = new System.Windows.Forms.DataGridView();
            this.buttonCustomerListPageListLast = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxCustomerListPageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ColumnCustomerListButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnCustomerListButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnCustomerListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCustomerListCustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCustomerListCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCustomerListContactNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCustomerListAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCustomerListIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnCustomerListSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomerList)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxCustomerListFilter
            // 
            this.textBoxCustomerListFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCustomerListFilter.Location = new System.Drawing.Point(12, 6);
            this.textBoxCustomerListFilter.Name = "textBoxCustomerListFilter";
            this.textBoxCustomerListFilter.Size = new System.Drawing.Size(1358, 30);
            this.textBoxCustomerListFilter.TabIndex = 19;
            this.textBoxCustomerListFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCustomerListFilter_KeyDown);
            // 
            // buttonCustomerListPageListFirst
            // 
            this.buttonCustomerListPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCustomerListPageListFirst.Enabled = false;
            this.buttonCustomerListPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonCustomerListPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustomerListPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonCustomerListPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonCustomerListPageListFirst.Name = "buttonCustomerListPageListFirst";
            this.buttonCustomerListPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonCustomerListPageListFirst.TabIndex = 13;
            this.buttonCustomerListPageListFirst.Text = "First";
            this.buttonCustomerListPageListFirst.UseVisualStyleBackColor = false;
            this.buttonCustomerListPageListFirst.Click += new System.EventHandler(this.buttonCustomerListPageListFirst_Click);
            // 
            // buttonCustomerListPageListPrevious
            // 
            this.buttonCustomerListPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCustomerListPageListPrevious.Enabled = false;
            this.buttonCustomerListPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonCustomerListPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustomerListPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonCustomerListPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonCustomerListPageListPrevious.Name = "buttonCustomerListPageListPrevious";
            this.buttonCustomerListPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonCustomerListPageListPrevious.TabIndex = 14;
            this.buttonCustomerListPageListPrevious.Text = "Previous";
            this.buttonCustomerListPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonCustomerListPageListPrevious.Click += new System.EventHandler(this.buttonCustomerListPageListPrevious_Click);
            // 
            // buttonCustomerListPageListNext
            // 
            this.buttonCustomerListPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCustomerListPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonCustomerListPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustomerListPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonCustomerListPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonCustomerListPageListNext.Name = "buttonCustomerListPageListNext";
            this.buttonCustomerListPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonCustomerListPageListNext.TabIndex = 15;
            this.buttonCustomerListPageListNext.Text = "Next";
            this.buttonCustomerListPageListNext.UseVisualStyleBackColor = false;
            this.buttonCustomerListPageListNext.Click += new System.EventHandler(this.buttonCustomerListPageListNext_Click);
            // 
            // dataGridViewCustomerList
            // 
            this.dataGridViewCustomerList.AllowUserToAddRows = false;
            this.dataGridViewCustomerList.AllowUserToDeleteRows = false;
            this.dataGridViewCustomerList.AllowUserToResizeRows = false;
            this.dataGridViewCustomerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCustomerList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCustomerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomerList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCustomerListButtonEdit,
            this.ColumnCustomerListButtonDelete,
            this.ColumnCustomerListId,
            this.ColumnCustomerListCustomerCode,
            this.ColumnCustomerListCustomer,
            this.ColumnCustomerListContactNumber,
            this.ColumnCustomerListAddress,
            this.ColumnCustomerListIsLocked,
            this.ColumnCustomerListSpace});
            this.dataGridViewCustomerList.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewCustomerList.MultiSelect = false;
            this.dataGridViewCustomerList.Name = "dataGridViewCustomerList";
            this.dataGridViewCustomerList.ReadOnly = true;
            this.dataGridViewCustomerList.RowHeadersVisible = false;
            this.dataGridViewCustomerList.RowTemplate.Height = 24;
            this.dataGridViewCustomerList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCustomerList.Size = new System.Drawing.Size(1358, 518);
            this.dataGridViewCustomerList.TabIndex = 20;
            this.dataGridViewCustomerList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCustomerList_CellClick);
            // 
            // buttonCustomerListPageListLast
            // 
            this.buttonCustomerListPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCustomerListPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonCustomerListPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustomerListPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonCustomerListPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonCustomerListPageListLast.Name = "buttonCustomerListPageListLast";
            this.buttonCustomerListPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonCustomerListPageListLast.TabIndex = 16;
            this.buttonCustomerListPageListLast.Text = "Last";
            this.buttonCustomerListPageListLast.UseVisualStyleBackColor = false;
            this.buttonCustomerListPageListLast.Click += new System.EventHandler(this.buttonCustomerListPageListLast_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonCustomerListPageListFirst);
            this.panel3.Controls.Add(this.buttonCustomerListPageListPrevious);
            this.panel3.Controls.Add(this.buttonCustomerListPageListNext);
            this.panel3.Controls.Add(this.buttonCustomerListPageListLast);
            this.panel3.Controls.Add(this.textBoxCustomerListPageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 566);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1382, 53);
            this.panel3.TabIndex = 21;
            // 
            // textBoxCustomerListPageNumber
            // 
            this.textBoxCustomerListPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxCustomerListPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxCustomerListPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCustomerListPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxCustomerListPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxCustomerListPageNumber.Name = "textBoxCustomerListPageNumber";
            this.textBoxCustomerListPageNumber.ReadOnly = true;
            this.textBoxCustomerListPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxCustomerListPageNumber.TabIndex = 17;
            this.textBoxCustomerListPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewCustomerList);
            this.panel2.Controls.Add(this.textBoxCustomerListFilter);
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
            this.label1.Text = "Customer List";
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
            this.buttonAdd.Location = new System.Drawing.Point(1188, 12);
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
            this.panel1.Size = new System.Drawing.Size(1382, 63);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.Customer;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // ColumnCustomerListButtonEdit
            // 
            this.ColumnCustomerListButtonEdit.DataPropertyName = "ColumnCustomerListButtonEdit";
            this.ColumnCustomerListButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnCustomerListButtonEdit.HeaderText = "";
            this.ColumnCustomerListButtonEdit.Name = "ColumnCustomerListButtonEdit";
            this.ColumnCustomerListButtonEdit.ReadOnly = true;
            this.ColumnCustomerListButtonEdit.Width = 70;
            // 
            // ColumnCustomerListButtonDelete
            // 
            this.ColumnCustomerListButtonDelete.DataPropertyName = "ColumnCustomerListButtonDelete";
            this.ColumnCustomerListButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnCustomerListButtonDelete.HeaderText = "";
            this.ColumnCustomerListButtonDelete.Name = "ColumnCustomerListButtonDelete";
            this.ColumnCustomerListButtonDelete.ReadOnly = true;
            this.ColumnCustomerListButtonDelete.Width = 70;
            // 
            // ColumnCustomerListId
            // 
            this.ColumnCustomerListId.DataPropertyName = "ColumnCustomerListId";
            this.ColumnCustomerListId.HeaderText = "Id";
            this.ColumnCustomerListId.Name = "ColumnCustomerListId";
            this.ColumnCustomerListId.ReadOnly = true;
            this.ColumnCustomerListId.Visible = false;
            // 
            // ColumnCustomerListCustomerCode
            // 
            this.ColumnCustomerListCustomerCode.DataPropertyName = "ColumnCustomerListCustomerCode";
            this.ColumnCustomerListCustomerCode.HeaderText = "Code";
            this.ColumnCustomerListCustomerCode.Name = "ColumnCustomerListCustomerCode";
            this.ColumnCustomerListCustomerCode.ReadOnly = true;
            this.ColumnCustomerListCustomerCode.Width = 150;
            // 
            // ColumnCustomerListCustomer
            // 
            this.ColumnCustomerListCustomer.DataPropertyName = "ColumnCustomerListCustomer";
            this.ColumnCustomerListCustomer.HeaderText = "Customer";
            this.ColumnCustomerListCustomer.Name = "ColumnCustomerListCustomer";
            this.ColumnCustomerListCustomer.ReadOnly = true;
            this.ColumnCustomerListCustomer.Width = 250;
            // 
            // ColumnCustomerListContactNumber
            // 
            this.ColumnCustomerListContactNumber.DataPropertyName = "ColumnCustomerListContactNumber";
            this.ColumnCustomerListContactNumber.HeaderText = "Contact No.";
            this.ColumnCustomerListContactNumber.Name = "ColumnCustomerListContactNumber";
            this.ColumnCustomerListContactNumber.ReadOnly = true;
            this.ColumnCustomerListContactNumber.Width = 200;
            // 
            // ColumnCustomerListAddress
            // 
            this.ColumnCustomerListAddress.DataPropertyName = "ColumnCustomerListAddress";
            this.ColumnCustomerListAddress.HeaderText = "Address";
            this.ColumnCustomerListAddress.Name = "ColumnCustomerListAddress";
            this.ColumnCustomerListAddress.ReadOnly = true;
            this.ColumnCustomerListAddress.Width = 250;
            // 
            // ColumnCustomerListIsLocked
            // 
            this.ColumnCustomerListIsLocked.DataPropertyName = "ColumnCustomerListIsLocked";
            this.ColumnCustomerListIsLocked.HeaderText = "L";
            this.ColumnCustomerListIsLocked.Name = "ColumnCustomerListIsLocked";
            this.ColumnCustomerListIsLocked.ReadOnly = true;
            this.ColumnCustomerListIsLocked.Width = 35;
            // 
            // ColumnCustomerListSpace
            // 
            this.ColumnCustomerListSpace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnCustomerListSpace.DataPropertyName = "ColumnCustomerListSpace";
            this.ColumnCustomerListSpace.HeaderText = "";
            this.ColumnCustomerListSpace.Name = "ColumnCustomerListSpace";
            this.ColumnCustomerListSpace.ReadOnly = true;
            // 
            // MstCustomerListForm
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
            this.Name = "MstCustomerListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomerList)).EndInit();
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

        private System.Windows.Forms.TextBox textBoxCustomerListFilter;
        private System.Windows.Forms.Button buttonCustomerListPageListFirst;
        private System.Windows.Forms.Button buttonCustomerListPageListPrevious;
        private System.Windows.Forms.Button buttonCustomerListPageListNext;
        private System.Windows.Forms.DataGridView dataGridViewCustomerList;
        private System.Windows.Forms.Button buttonCustomerListPageListLast;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxCustomerListPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnCustomerListButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnCustomerListButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCustomerListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCustomerListCustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCustomerListCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCustomerListContactNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCustomerListAddress;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCustomerListIsLocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCustomerListSpace;
    }
}