namespace easyfmis.Forms.Software.TrnSalesInvoice
{
    partial class TrnSalesInvoiceForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnSalesInvoiceForm));
            this.textBoxSalesInvoiceFilter = new System.Windows.Forms.TextBox();
            this.buttonSalesInvoicePageListFirst = new System.Windows.Forms.Button();
            this.buttonSalesInvoicePageListPrevious = new System.Windows.Forms.Button();
            this.buttonSalesInvoicePageListNext = new System.Windows.Forms.Button();
            this.dataGridViewSalesInvoice = new System.Windows.Forms.DataGridView();
            this.buttonSalesInvoicePageListLast = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxSalesInvoicePageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePickerSalesInvoiceFilterEndDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerSalesInvoiceFilterStartDate = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ColumnSalesInvoiceButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnSalesInvoiceButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnSalesInvoiceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesInvoiceSIDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesInvoiceSINumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesInvoiceManualSINumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesInvoiceCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesInvoiceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesInvoicePaidAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesInvoiceBalanceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesInvoiceMemoAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesInvoiceRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesInvoiceIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnSalesInvoiceSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalesInvoice)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSalesInvoiceFilter
            // 
            this.textBoxSalesInvoiceFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSalesInvoiceFilter.Location = new System.Drawing.Point(250, 5);
            this.textBoxSalesInvoiceFilter.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSalesInvoiceFilter.Name = "textBoxSalesInvoiceFilter";
            this.textBoxSalesInvoiceFilter.Size = new System.Drawing.Size(838, 26);
            this.textBoxSalesInvoiceFilter.TabIndex = 1;
            this.textBoxSalesInvoiceFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSalesInvoiceFilter_KeyDown);
            // 
            // buttonSalesInvoicePageListFirst
            // 
            this.buttonSalesInvoicePageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalesInvoicePageListFirst.Enabled = false;
            this.buttonSalesInvoicePageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonSalesInvoicePageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalesInvoicePageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSalesInvoicePageListFirst.Location = new System.Drawing.Point(10, 7);
            this.buttonSalesInvoicePageListFirst.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSalesInvoicePageListFirst.Name = "buttonSalesInvoicePageListFirst";
            this.buttonSalesInvoicePageListFirst.Size = new System.Drawing.Size(66, 26);
            this.buttonSalesInvoicePageListFirst.TabIndex = 13;
            this.buttonSalesInvoicePageListFirst.Text = "First";
            this.buttonSalesInvoicePageListFirst.UseVisualStyleBackColor = false;
            this.buttonSalesInvoicePageListFirst.Click += new System.EventHandler(this.buttonSalesInvoicePageListFirst_Click);
            // 
            // buttonSalesInvoicePageListPrevious
            // 
            this.buttonSalesInvoicePageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalesInvoicePageListPrevious.Enabled = false;
            this.buttonSalesInvoicePageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonSalesInvoicePageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalesInvoicePageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSalesInvoicePageListPrevious.Location = new System.Drawing.Point(80, 7);
            this.buttonSalesInvoicePageListPrevious.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSalesInvoicePageListPrevious.Name = "buttonSalesInvoicePageListPrevious";
            this.buttonSalesInvoicePageListPrevious.Size = new System.Drawing.Size(66, 26);
            this.buttonSalesInvoicePageListPrevious.TabIndex = 14;
            this.buttonSalesInvoicePageListPrevious.Text = "Previous";
            this.buttonSalesInvoicePageListPrevious.UseVisualStyleBackColor = false;
            this.buttonSalesInvoicePageListPrevious.Click += new System.EventHandler(this.buttonSalesInvoicePageListPrevious_Click);
            // 
            // buttonSalesInvoicePageListNext
            // 
            this.buttonSalesInvoicePageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalesInvoicePageListNext.FlatAppearance.BorderSize = 0;
            this.buttonSalesInvoicePageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalesInvoicePageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSalesInvoicePageListNext.Location = new System.Drawing.Point(210, 7);
            this.buttonSalesInvoicePageListNext.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSalesInvoicePageListNext.Name = "buttonSalesInvoicePageListNext";
            this.buttonSalesInvoicePageListNext.Size = new System.Drawing.Size(66, 26);
            this.buttonSalesInvoicePageListNext.TabIndex = 15;
            this.buttonSalesInvoicePageListNext.Text = "Next";
            this.buttonSalesInvoicePageListNext.UseVisualStyleBackColor = false;
            this.buttonSalesInvoicePageListNext.Click += new System.EventHandler(this.buttonSalesInvoicePageListNext_Click);
            // 
            // dataGridViewSalesInvoice
            // 
            this.dataGridViewSalesInvoice.AllowUserToAddRows = false;
            this.dataGridViewSalesInvoice.AllowUserToDeleteRows = false;
            this.dataGridViewSalesInvoice.AllowUserToResizeRows = false;
            this.dataGridViewSalesInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSalesInvoice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewSalesInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSalesInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSalesInvoiceButtonEdit,
            this.ColumnSalesInvoiceButtonDelete,
            this.ColumnSalesInvoiceId,
            this.ColumnSalesInvoiceSIDate,
            this.ColumnSalesInvoiceSINumber,
            this.ColumnSalesInvoiceManualSINumber,
            this.ColumnSalesInvoiceCustomer,
            this.ColumnSalesInvoiceAmount,
            this.ColumnSalesInvoicePaidAmount,
            this.ColumnSalesInvoiceBalanceAmount,
            this.ColumnSalesInvoiceMemoAmount,
            this.ColumnSalesInvoiceRemarks,
            this.ColumnSalesInvoiceIsLocked,
            this.ColumnSalesInvoiceSpace});
            this.dataGridViewSalesInvoice.Location = new System.Drawing.Point(10, 34);
            this.dataGridViewSalesInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewSalesInvoice.MultiSelect = false;
            this.dataGridViewSalesInvoice.Name = "dataGridViewSalesInvoice";
            this.dataGridViewSalesInvoice.ReadOnly = true;
            this.dataGridViewSalesInvoice.RowHeadersVisible = false;
            this.dataGridViewSalesInvoice.RowTemplate.Height = 24;
            this.dataGridViewSalesInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSalesInvoice.Size = new System.Drawing.Size(1077, 429);
            this.dataGridViewSalesInvoice.TabIndex = 20;
            this.dataGridViewSalesInvoice.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSalesInvoice_CellClick);
            // 
            // buttonSalesInvoicePageListLast
            // 
            this.buttonSalesInvoicePageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalesInvoicePageListLast.FlatAppearance.BorderSize = 0;
            this.buttonSalesInvoicePageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalesInvoicePageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSalesInvoicePageListLast.Location = new System.Drawing.Point(278, 7);
            this.buttonSalesInvoicePageListLast.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSalesInvoicePageListLast.Name = "buttonSalesInvoicePageListLast";
            this.buttonSalesInvoicePageListLast.Size = new System.Drawing.Size(66, 26);
            this.buttonSalesInvoicePageListLast.TabIndex = 16;
            this.buttonSalesInvoicePageListLast.Text = "Last";
            this.buttonSalesInvoicePageListLast.UseVisualStyleBackColor = false;
            this.buttonSalesInvoicePageListLast.Click += new System.EventHandler(this.buttonSalesInvoicePageListLast_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonSalesInvoicePageListFirst);
            this.panel3.Controls.Add(this.buttonSalesInvoicePageListPrevious);
            this.panel3.Controls.Add(this.buttonSalesInvoicePageListNext);
            this.panel3.Controls.Add(this.buttonSalesInvoicePageListLast);
            this.panel3.Controls.Add(this.textBoxSalesInvoicePageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 468);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1096, 42);
            this.panel3.TabIndex = 21;
            // 
            // textBoxSalesInvoicePageNumber
            // 
            this.textBoxSalesInvoicePageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSalesInvoicePageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxSalesInvoicePageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSalesInvoicePageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxSalesInvoicePageNumber.Location = new System.Drawing.Point(150, 11);
            this.textBoxSalesInvoicePageNumber.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSalesInvoicePageNumber.Name = "textBoxSalesInvoicePageNumber";
            this.textBoxSalesInvoicePageNumber.ReadOnly = true;
            this.textBoxSalesInvoicePageNumber.Size = new System.Drawing.Size(55, 16);
            this.textBoxSalesInvoicePageNumber.TabIndex = 17;
            this.textBoxSalesInvoicePageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateTimePickerSalesInvoiceFilterEndDate);
            this.panel2.Controls.Add(this.dateTimePickerSalesInvoiceFilterStartDate);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewSalesInvoice);
            this.panel2.Controls.Add(this.textBoxSalesInvoiceFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1096, 510);
            this.panel2.TabIndex = 7;
            // 
            // dateTimePickerSalesInvoiceFilterEndDate
            // 
            this.dateTimePickerSalesInvoiceFilterEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerSalesInvoiceFilterEndDate.Location = new System.Drawing.Point(127, 5);
            this.dateTimePickerSalesInvoiceFilterEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerSalesInvoiceFilterEndDate.Name = "dateTimePickerSalesInvoiceFilterEndDate";
            this.dateTimePickerSalesInvoiceFilterEndDate.Size = new System.Drawing.Size(114, 26);
            this.dateTimePickerSalesInvoiceFilterEndDate.TabIndex = 22;
            this.dateTimePickerSalesInvoiceFilterEndDate.ValueChanged += new System.EventHandler(this.dateTimePickerSalesInvoiceFilterEndDate_ValueChanged);
            // 
            // dateTimePickerSalesInvoiceFilterStartDate
            // 
            this.dateTimePickerSalesInvoiceFilterStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerSalesInvoiceFilterStartDate.Location = new System.Drawing.Point(10, 5);
            this.dateTimePickerSalesInvoiceFilterStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerSalesInvoiceFilterStartDate.Name = "dateTimePickerSalesInvoiceFilterStartDate";
            this.dateTimePickerSalesInvoiceFilterStartDate.Size = new System.Drawing.Size(114, 26);
            this.dateTimePickerSalesInvoiceFilterStartDate.TabIndex = 0;
            this.dateTimePickerSalesInvoiceFilterStartDate.ValueChanged += new System.EventHandler(this.dateTimePickerSalesInvoiceFilterStartDate_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.POS1;
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
            this.label1.Size = new System.Drawing.Size(173, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sales Invoice List";
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
            this.buttonClose.Location = new System.Drawing.Point(1016, 10);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(70, 32);
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
            this.buttonAdd.Location = new System.Drawing.Point(941, 10);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(70, 32);
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
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1096, 50);
            this.panel1.TabIndex = 6;
            // 
            // ColumnSalesInvoiceButtonEdit
            // 
            this.ColumnSalesInvoiceButtonEdit.DataPropertyName = "ColumnSalesInvoiceButtonEdit";
            this.ColumnSalesInvoiceButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnSalesInvoiceButtonEdit.HeaderText = "";
            this.ColumnSalesInvoiceButtonEdit.Name = "ColumnSalesInvoiceButtonEdit";
            this.ColumnSalesInvoiceButtonEdit.ReadOnly = true;
            this.ColumnSalesInvoiceButtonEdit.Width = 70;
            // 
            // ColumnSalesInvoiceButtonDelete
            // 
            this.ColumnSalesInvoiceButtonDelete.DataPropertyName = "ColumnSalesInvoiceButtonDelete";
            this.ColumnSalesInvoiceButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnSalesInvoiceButtonDelete.HeaderText = "";
            this.ColumnSalesInvoiceButtonDelete.Name = "ColumnSalesInvoiceButtonDelete";
            this.ColumnSalesInvoiceButtonDelete.ReadOnly = true;
            this.ColumnSalesInvoiceButtonDelete.Width = 70;
            // 
            // ColumnSalesInvoiceId
            // 
            this.ColumnSalesInvoiceId.DataPropertyName = "ColumnSalesInvoiceId";
            this.ColumnSalesInvoiceId.HeaderText = "Id";
            this.ColumnSalesInvoiceId.Name = "ColumnSalesInvoiceId";
            this.ColumnSalesInvoiceId.ReadOnly = true;
            this.ColumnSalesInvoiceId.Visible = false;
            // 
            // ColumnSalesInvoiceSIDate
            // 
            this.ColumnSalesInvoiceSIDate.DataPropertyName = "ColumnSalesInvoiceSIDate";
            this.ColumnSalesInvoiceSIDate.HeaderText = "SI Date";
            this.ColumnSalesInvoiceSIDate.Name = "ColumnSalesInvoiceSIDate";
            this.ColumnSalesInvoiceSIDate.ReadOnly = true;
            // 
            // ColumnSalesInvoiceSINumber
            // 
            this.ColumnSalesInvoiceSINumber.DataPropertyName = "ColumnSalesInvoiceSINumber";
            this.ColumnSalesInvoiceSINumber.HeaderText = "SI Number";
            this.ColumnSalesInvoiceSINumber.Name = "ColumnSalesInvoiceSINumber";
            this.ColumnSalesInvoiceSINumber.ReadOnly = true;
            this.ColumnSalesInvoiceSINumber.Width = 125;
            // 
            // ColumnSalesInvoiceManualSINumber
            // 
            this.ColumnSalesInvoiceManualSINumber.DataPropertyName = "ColumnSalesInvoiceManualSINumber";
            this.ColumnSalesInvoiceManualSINumber.HeaderText = "Manual SI Number";
            this.ColumnSalesInvoiceManualSINumber.Name = "ColumnSalesInvoiceManualSINumber";
            this.ColumnSalesInvoiceManualSINumber.ReadOnly = true;
            this.ColumnSalesInvoiceManualSINumber.Width = 150;
            // 
            // ColumnSalesInvoiceCustomer
            // 
            this.ColumnSalesInvoiceCustomer.DataPropertyName = "ColumnSalesInvoiceCustomer";
            this.ColumnSalesInvoiceCustomer.HeaderText = "Customer";
            this.ColumnSalesInvoiceCustomer.Name = "ColumnSalesInvoiceCustomer";
            this.ColumnSalesInvoiceCustomer.ReadOnly = true;
            this.ColumnSalesInvoiceCustomer.Width = 200;
            // 
            // ColumnSalesInvoiceAmount
            // 
            this.ColumnSalesInvoiceAmount.DataPropertyName = "ColumnSalesInvoiceAmount";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnSalesInvoiceAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnSalesInvoiceAmount.HeaderText = "Amount";
            this.ColumnSalesInvoiceAmount.Name = "ColumnSalesInvoiceAmount";
            this.ColumnSalesInvoiceAmount.ReadOnly = true;
            this.ColumnSalesInvoiceAmount.Width = 150;
            // 
            // ColumnSalesInvoicePaidAmount
            // 
            this.ColumnSalesInvoicePaidAmount.DataPropertyName = "ColumnSalesInvoicePaidAmount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnSalesInvoicePaidAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnSalesInvoicePaidAmount.HeaderText = "Paid Amount";
            this.ColumnSalesInvoicePaidAmount.Name = "ColumnSalesInvoicePaidAmount";
            this.ColumnSalesInvoicePaidAmount.ReadOnly = true;
            this.ColumnSalesInvoicePaidAmount.Width = 150;
            // 
            // ColumnSalesInvoiceBalanceAmount
            // 
            this.ColumnSalesInvoiceBalanceAmount.DataPropertyName = "ColumnSalesInvoiceBalanceAmount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnSalesInvoiceBalanceAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnSalesInvoiceBalanceAmount.HeaderText = "Balance Amount";
            this.ColumnSalesInvoiceBalanceAmount.Name = "ColumnSalesInvoiceBalanceAmount";
            this.ColumnSalesInvoiceBalanceAmount.ReadOnly = true;
            this.ColumnSalesInvoiceBalanceAmount.Width = 150;
            // 
            // ColumnSalesInvoiceMemoAmount
            // 
            this.ColumnSalesInvoiceMemoAmount.DataPropertyName = "ColumnSalesInvoiceMemoAmount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnSalesInvoiceMemoAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnSalesInvoiceMemoAmount.HeaderText = "Memo Amount";
            this.ColumnSalesInvoiceMemoAmount.Name = "ColumnSalesInvoiceMemoAmount";
            this.ColumnSalesInvoiceMemoAmount.ReadOnly = true;
            this.ColumnSalesInvoiceMemoAmount.Width = 150;
            // 
            // ColumnSalesInvoiceRemarks
            // 
            this.ColumnSalesInvoiceRemarks.DataPropertyName = "ColumnSalesInvoiceRemarks";
            this.ColumnSalesInvoiceRemarks.HeaderText = "Remarks";
            this.ColumnSalesInvoiceRemarks.Name = "ColumnSalesInvoiceRemarks";
            this.ColumnSalesInvoiceRemarks.ReadOnly = true;
            this.ColumnSalesInvoiceRemarks.Width = 250;
            // 
            // ColumnSalesInvoiceIsLocked
            // 
            this.ColumnSalesInvoiceIsLocked.DataPropertyName = "ColumnSalesInvoiceIsLocked";
            this.ColumnSalesInvoiceIsLocked.HeaderText = "L";
            this.ColumnSalesInvoiceIsLocked.Name = "ColumnSalesInvoiceIsLocked";
            this.ColumnSalesInvoiceIsLocked.ReadOnly = true;
            this.ColumnSalesInvoiceIsLocked.Width = 35;
            // 
            // ColumnSalesInvoiceSpace
            // 
            this.ColumnSalesInvoiceSpace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSalesInvoiceSpace.DataPropertyName = "ColumnSalesInvoiceSpace";
            this.ColumnSalesInvoiceSpace.HeaderText = "";
            this.ColumnSalesInvoiceSpace.Name = "ColumnSalesInvoiceSpace";
            this.ColumnSalesInvoiceSpace.ReadOnly = true;
            // 
            // TrnSalesInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1096, 560);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "TrnSalesInvoiceForm";
            this.Text = "Stock In List";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalesInvoice)).EndInit();
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

        private System.Windows.Forms.TextBox textBoxSalesInvoiceFilter;
        private System.Windows.Forms.Button buttonSalesInvoicePageListFirst;
        private System.Windows.Forms.Button buttonSalesInvoicePageListPrevious;
        private System.Windows.Forms.Button buttonSalesInvoicePageListNext;
        private System.Windows.Forms.DataGridView dataGridViewSalesInvoice;
        private System.Windows.Forms.Button buttonSalesInvoicePageListLast;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxSalesInvoicePageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePickerSalesInvoiceFilterStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerSalesInvoiceFilterEndDate;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnSalesInvoiceButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnSalesInvoiceButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesInvoiceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesInvoiceSIDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesInvoiceSINumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesInvoiceManualSINumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesInvoiceCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesInvoiceAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesInvoicePaidAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesInvoiceBalanceAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesInvoiceMemoAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesInvoiceRemarks;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnSalesInvoiceIsLocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesInvoiceSpace;
    }
}