namespace easyfmis.Forms.Software.TrnMemo
{
    partial class TrnMemoDetailMemoLineDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnMemoDetailMemoLineDetailForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxCredit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxSINumber = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxRRNumber = new System.Windows.Forms.ComboBox();
            this.textBoxDebit = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxParticulars = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 50);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.Stock_In;
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
            this.label1.Size = new System.Drawing.Size(180, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Memo Line Detail";
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
            this.buttonClose.Location = new System.Drawing.Point(310, 10);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(70, 32);
            this.buttonClose.TabIndex = 21;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(234, 10);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(70, 32);
            this.buttonSave.TabIndex = 20;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBoxCredit);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.comboBoxSINumber);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBoxRRNumber);
            this.panel2.Controls.Add(this.textBoxDebit);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBoxParticulars);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(390, 207);
            this.panel2.TabIndex = 9;
            // 
            // textBoxCredit
            // 
            this.textBoxCredit.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCredit.Location = new System.Drawing.Point(156, 97);
            this.textBoxCredit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCredit.Name = "textBoxCredit";
            this.textBoxCredit.Size = new System.Drawing.Size(216, 26);
            this.textBoxCredit.TabIndex = 26;
            this.textBoxCredit.TabStop = false;
            this.textBoxCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxCredit.TextChanged += new System.EventHandler(this.textBoxCreditAmount_TextChanged);
            this.textBoxCredit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCreditAmount_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label5.Location = new System.Drawing.Point(49, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 19);
            this.label5.TabIndex = 27;
            this.label5.Text = "Credit Amount:";
            // 
            // comboBoxSINumber
            // 
            this.comboBoxSINumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxSINumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxSINumber.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.comboBoxSINumber.FormattingEnabled = true;
            this.comboBoxSINumber.Location = new System.Drawing.Point(156, 5);
            this.comboBoxSINumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxSINumber.Name = "comboBoxSINumber";
            this.comboBoxSINumber.Size = new System.Drawing.Size(216, 27);
            this.comboBoxSINumber.TabIndex = 24;
            this.comboBoxSINumber.SelectedIndexChanged += new System.EventHandler(this.comboBoxSINumber_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label2.Location = new System.Drawing.Point(38, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 19);
            this.label2.TabIndex = 25;
            this.label2.Text = "Sales Invoice No.:";
            // 
            // comboBoxRRNumber
            // 
            this.comboBoxRRNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxRRNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxRRNumber.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.comboBoxRRNumber.FormattingEnabled = true;
            this.comboBoxRRNumber.Location = new System.Drawing.Point(156, 36);
            this.comboBoxRRNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxRRNumber.Name = "comboBoxRRNumber";
            this.comboBoxRRNumber.Size = new System.Drawing.Size(216, 27);
            this.comboBoxRRNumber.TabIndex = 1;
            this.comboBoxRRNumber.SelectedIndexChanged += new System.EventHandler(this.comboBoxRRNumber_SelectedIndexChanged);
            // 
            // textBoxDebit
            // 
            this.textBoxDebit.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxDebit.Location = new System.Drawing.Point(156, 67);
            this.textBoxDebit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxDebit.Name = "textBoxDebit";
            this.textBoxDebit.Size = new System.Drawing.Size(216, 26);
            this.textBoxDebit.TabIndex = 3;
            this.textBoxDebit.TabStop = false;
            this.textBoxDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxDebit.TextChanged += new System.EventHandler(this.textBoxDebitAmount_TextChanged);
            this.textBoxDebit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDebitAmount_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label9.Location = new System.Drawing.Point(53, 70);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 19);
            this.label9.TabIndex = 23;
            this.label9.Text = "Debit Amount:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label4.Location = new System.Drawing.Point(77, 130);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 19);
            this.label4.TabIndex = 17;
            this.label4.Text = "Particulars:";
            // 
            // textBoxParticulars
            // 
            this.textBoxParticulars.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxParticulars.Location = new System.Drawing.Point(156, 127);
            this.textBoxParticulars.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxParticulars.Multiline = true;
            this.textBoxParticulars.Name = "textBoxParticulars";
            this.textBoxParticulars.Size = new System.Drawing.Size(216, 74);
            this.textBoxParticulars.TabIndex = 2;
            this.textBoxParticulars.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxParticulars.TextChanged += new System.EventHandler(this.textBoxParticulars_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label3.Location = new System.Drawing.Point(10, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "Receiving Receipt No.:";
            // 
            // TrnMemoDetailMemoLineDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(390, 257);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "TrnMemoDetailMemoLineDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memo Line Detail";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxParticulars;
        private System.Windows.Forms.TextBox textBoxDebit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxRRNumber;
        private System.Windows.Forms.ComboBox comboBoxSINumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCredit;
        private System.Windows.Forms.Label label5;
    }
}