﻿namespace easyfmis.Forms.Software.MstSupplier
{
    partial class MstSupplierDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MstSupplierDetailForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonLock = new System.Windows.Forms.Button();
            this.buttonUnlock = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBoxTerms = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxArticleGroup = new System.Windows.Forms.ComboBox();
            this.textBoxRemarks = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxTIN = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxEmailAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxContactNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxContactPerson = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSupplier = new System.Windows.Forms.TextBox();
            this.textBoxSupplierCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.buttonLock);
            this.panel1.Controls.Add(this.buttonUnlock);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1104, 50);
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
            this.buttonLock.Location = new System.Drawing.Point(874, 10);
            this.buttonLock.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonLock.Name = "buttonLock";
            this.buttonLock.Size = new System.Drawing.Size(70, 32);
            this.buttonLock.TabIndex = 20;
            this.buttonLock.TabStop = false;
            this.buttonLock.Text = "Lock";
            this.buttonLock.UseVisualStyleBackColor = false;
            this.buttonLock.Click += new System.EventHandler(this.buttonLock_Click);
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
            this.buttonUnlock.Location = new System.Drawing.Point(949, 10);
            this.buttonUnlock.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonUnlock.Name = "buttonUnlock";
            this.buttonUnlock.Size = new System.Drawing.Size(70, 32);
            this.buttonUnlock.TabIndex = 21;
            this.buttonUnlock.TabStop = false;
            this.buttonUnlock.Text = "Unlock";
            this.buttonUnlock.UseVisualStyleBackColor = false;
            this.buttonUnlock.Click += new System.EventHandler(this.buttonUnlock_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.Supplier;
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
            this.label1.Size = new System.Drawing.Size(153, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Supplier Detail";
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
            this.buttonClose.Location = new System.Drawing.Point(1024, 10);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(70, 32);
            this.buttonClose.TabIndex = 22;
            this.buttonClose.TabStop = false;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.comboBoxTerms);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.comboBoxArticleGroup);
            this.panel2.Controls.Add(this.textBoxRemarks);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.textBoxTIN);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.textBoxEmailAddress);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textBoxContactNumber);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.textBoxContactPerson);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBoxAddress);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBoxSupplier);
            this.panel2.Controls.Add(this.textBoxSupplierCode);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.panel2.Size = new System.Drawing.Size(1104, 510);
            this.panel2.TabIndex = 6;
            // 
            // comboBoxTerms
            // 
            this.comboBoxTerms.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxTerms.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxTerms.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.comboBoxTerms.FormattingEnabled = true;
            this.comboBoxTerms.Location = new System.Drawing.Point(129, 302);
            this.comboBoxTerms.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxTerms.Name = "comboBoxTerms";
            this.comboBoxTerms.Size = new System.Drawing.Size(172, 27);
            this.comboBoxTerms.TabIndex = 47;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label12.Location = new System.Drawing.Point(77, 305);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 19);
            this.label12.TabIndex = 48;
            this.label12.Text = "Terms:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label8.Location = new System.Drawing.Point(61, 336);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 19);
            this.label8.TabIndex = 44;
            this.label8.Text = "Remarks:";
            // 
            // comboBoxArticleGroup
            // 
            this.comboBoxArticleGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxArticleGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxArticleGroup.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.comboBoxArticleGroup.FormattingEnabled = true;
            this.comboBoxArticleGroup.Location = new System.Drawing.Point(129, 65);
            this.comboBoxArticleGroup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxArticleGroup.Name = "comboBoxArticleGroup";
            this.comboBoxArticleGroup.Size = new System.Drawing.Size(172, 27);
            this.comboBoxArticleGroup.TabIndex = 2;
            // 
            // textBoxRemarks
            // 
            this.textBoxRemarks.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxRemarks.Location = new System.Drawing.Point(129, 333);
            this.textBoxRemarks.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxRemarks.Multiline = true;
            this.textBoxRemarks.Name = "textBoxRemarks";
            this.textBoxRemarks.Size = new System.Drawing.Size(328, 82);
            this.textBoxRemarks.TabIndex = 43;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label10.Location = new System.Drawing.Point(32, 68);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 19);
            this.label10.TabIndex = 40;
            this.label10.Text = "Article Group:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label9.Location = new System.Drawing.Point(92, 275);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 19);
            this.label9.TabIndex = 38;
            this.label9.Text = "TIN:";
            // 
            // textBoxTIN
            // 
            this.textBoxTIN.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxTIN.Location = new System.Drawing.Point(129, 272);
            this.textBoxTIN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxTIN.Name = "textBoxTIN";
            this.textBoxTIN.Size = new System.Drawing.Size(172, 26);
            this.textBoxTIN.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label7.Location = new System.Drawing.Point(32, 245);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 19);
            this.label7.TabIndex = 14;
            this.label7.Text = "EmailAddress:";
            // 
            // textBoxEmailAddress
            // 
            this.textBoxEmailAddress.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxEmailAddress.Location = new System.Drawing.Point(129, 242);
            this.textBoxEmailAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxEmailAddress.Name = "textBoxEmailAddress";
            this.textBoxEmailAddress.Size = new System.Drawing.Size(228, 26);
            this.textBoxEmailAddress.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label6.Location = new System.Drawing.Point(11, 215);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "Contact Number:";
            // 
            // textBoxContactNumber
            // 
            this.textBoxContactNumber.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxContactNumber.Location = new System.Drawing.Point(129, 212);
            this.textBoxContactNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxContactNumber.Name = "textBoxContactNumber";
            this.textBoxContactNumber.Size = new System.Drawing.Size(172, 26);
            this.textBoxContactNumber.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label5.Location = new System.Drawing.Point(20, 185);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Contact Person:";
            // 
            // textBoxContactPerson
            // 
            this.textBoxContactPerson.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxContactPerson.Location = new System.Drawing.Point(129, 182);
            this.textBoxContactPerson.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxContactPerson.Name = "textBoxContactPerson";
            this.textBoxContactPerson.Size = new System.Drawing.Size(228, 26);
            this.textBoxContactPerson.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label2.Location = new System.Drawing.Point(64, 99);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Address:";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxAddress.Location = new System.Drawing.Point(129, 96);
            this.textBoxAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxAddress.Multiline = true;
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(328, 82);
            this.textBoxAddress.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label3.Location = new System.Drawing.Point(64, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Supplier:";
            // 
            // textBoxSupplier
            // 
            this.textBoxSupplier.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxSupplier.Location = new System.Drawing.Point(129, 35);
            this.textBoxSupplier.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxSupplier.Name = "textBoxSupplier";
            this.textBoxSupplier.Size = new System.Drawing.Size(228, 26);
            this.textBoxSupplier.TabIndex = 1;
            // 
            // textBoxSupplierCode
            // 
            this.textBoxSupplierCode.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxSupplierCode.Location = new System.Drawing.Point(129, 5);
            this.textBoxSupplierCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxSupplierCode.Name = "textBoxSupplierCode";
            this.textBoxSupplierCode.ReadOnly = true;
            this.textBoxSupplierCode.Size = new System.Drawing.Size(172, 26);
            this.textBoxSupplierCode.TabIndex = 0;
            this.textBoxSupplierCode.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label4.Location = new System.Drawing.Point(28, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Supplier Code:";
            // 
            // MstSupplierDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1104, 560);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MstSupplierDetailForm";
            this.Text = "MstSupplierDetailForm";
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
        private System.Windows.Forms.Button buttonLock;
        private System.Windows.Forms.Button buttonUnlock;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxSupplierCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxEmailAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxContactNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxContactPerson;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSupplier;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxTIN;
        private System.Windows.Forms.ComboBox comboBoxArticleGroup;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxRemarks;
        private System.Windows.Forms.ComboBox comboBoxTerms;
        private System.Windows.Forms.Label label12;
    }
}