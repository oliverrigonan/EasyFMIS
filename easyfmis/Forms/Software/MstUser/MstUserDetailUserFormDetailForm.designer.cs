﻿namespace easyfmis.Forms.Software.MstUser
{
    partial class MstUserDetailUserFormDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MstUserDetailUserFormDetailForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBoxCanEdit = new System.Windows.Forms.CheckBox();
            this.checkBoxCanPreview = new System.Windows.Forms.CheckBox();
            this.checkBoxCanPrint = new System.Windows.Forms.CheckBox();
            this.checkBoxCanUnlock = new System.Windows.Forms.CheckBox();
            this.checkBoxCanLock = new System.Windows.Forms.CheckBox();
            this.checkBoxCanAdd = new System.Windows.Forms.CheckBox();
            this.checkBoxCanDelete = new System.Windows.Forms.CheckBox();
            this.comboBoxForm = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 63);
            this.panel1.TabIndex = 6;
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
            this.label1.Size = new System.Drawing.Size(212, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "User Form Detail";
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
            this.buttonClose.Location = new System.Drawing.Point(416, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(88, 40);
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
            this.buttonSave.Location = new System.Drawing.Point(322, 12);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(88, 40);
            this.buttonSave.TabIndex = 20;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBoxCanEdit);
            this.panel2.Controls.Add(this.checkBoxCanPreview);
            this.panel2.Controls.Add(this.checkBoxCanPrint);
            this.panel2.Controls.Add(this.checkBoxCanUnlock);
            this.panel2.Controls.Add(this.checkBoxCanLock);
            this.panel2.Controls.Add(this.checkBoxCanAdd);
            this.panel2.Controls.Add(this.checkBoxCanDelete);
            this.panel2.Controls.Add(this.comboBoxForm);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(516, 279);
            this.panel2.TabIndex = 7;
            // 
            // checkBoxCanEdit
            // 
            this.checkBoxCanEdit.AutoSize = true;
            this.checkBoxCanEdit.Checked = true;
            this.checkBoxCanEdit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCanEdit.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.checkBoxCanEdit.Location = new System.Drawing.Point(71, 241);
            this.checkBoxCanEdit.Name = "checkBoxCanEdit";
            this.checkBoxCanEdit.Size = new System.Drawing.Size(96, 27);
            this.checkBoxCanEdit.TabIndex = 7;
            this.checkBoxCanEdit.Text = "Can Edit";
            this.checkBoxCanEdit.UseVisualStyleBackColor = true;
            // 
            // checkBoxCanPreview
            // 
            this.checkBoxCanPreview.AutoSize = true;
            this.checkBoxCanPreview.Checked = true;
            this.checkBoxCanPreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCanPreview.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.checkBoxCanPreview.Location = new System.Drawing.Point(71, 208);
            this.checkBoxCanPreview.Name = "checkBoxCanPreview";
            this.checkBoxCanPreview.Size = new System.Drawing.Size(125, 27);
            this.checkBoxCanPreview.TabIndex = 6;
            this.checkBoxCanPreview.Text = "Can Preview";
            this.checkBoxCanPreview.UseVisualStyleBackColor = true;
            // 
            // checkBoxCanPrint
            // 
            this.checkBoxCanPrint.AutoSize = true;
            this.checkBoxCanPrint.Checked = true;
            this.checkBoxCanPrint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCanPrint.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.checkBoxCanPrint.Location = new System.Drawing.Point(71, 175);
            this.checkBoxCanPrint.Name = "checkBoxCanPrint";
            this.checkBoxCanPrint.Size = new System.Drawing.Size(103, 27);
            this.checkBoxCanPrint.TabIndex = 5;
            this.checkBoxCanPrint.Text = "Can Print";
            this.checkBoxCanPrint.UseVisualStyleBackColor = true;
            // 
            // checkBoxCanUnlock
            // 
            this.checkBoxCanUnlock.AutoSize = true;
            this.checkBoxCanUnlock.Checked = true;
            this.checkBoxCanUnlock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCanUnlock.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.checkBoxCanUnlock.Location = new System.Drawing.Point(71, 142);
            this.checkBoxCanUnlock.Name = "checkBoxCanUnlock";
            this.checkBoxCanUnlock.Size = new System.Drawing.Size(119, 27);
            this.checkBoxCanUnlock.TabIndex = 4;
            this.checkBoxCanUnlock.Text = "Can Unlock";
            this.checkBoxCanUnlock.UseVisualStyleBackColor = true;
            // 
            // checkBoxCanLock
            // 
            this.checkBoxCanLock.AutoSize = true;
            this.checkBoxCanLock.Checked = true;
            this.checkBoxCanLock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCanLock.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.checkBoxCanLock.Location = new System.Drawing.Point(71, 109);
            this.checkBoxCanLock.Name = "checkBoxCanLock";
            this.checkBoxCanLock.Size = new System.Drawing.Size(101, 27);
            this.checkBoxCanLock.TabIndex = 3;
            this.checkBoxCanLock.Text = "Can Lock";
            this.checkBoxCanLock.UseVisualStyleBackColor = true;
            // 
            // checkBoxCanAdd
            // 
            this.checkBoxCanAdd.AutoSize = true;
            this.checkBoxCanAdd.Checked = true;
            this.checkBoxCanAdd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCanAdd.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.checkBoxCanAdd.Location = new System.Drawing.Point(71, 76);
            this.checkBoxCanAdd.Name = "checkBoxCanAdd";
            this.checkBoxCanAdd.Size = new System.Drawing.Size(98, 27);
            this.checkBoxCanAdd.TabIndex = 2;
            this.checkBoxCanAdd.Text = "Can Add";
            this.checkBoxCanAdd.UseVisualStyleBackColor = true;
            // 
            // checkBoxCanDelete
            // 
            this.checkBoxCanDelete.AutoSize = true;
            this.checkBoxCanDelete.Checked = true;
            this.checkBoxCanDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCanDelete.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.checkBoxCanDelete.Location = new System.Drawing.Point(71, 43);
            this.checkBoxCanDelete.Name = "checkBoxCanDelete";
            this.checkBoxCanDelete.Size = new System.Drawing.Size(116, 27);
            this.checkBoxCanDelete.TabIndex = 1;
            this.checkBoxCanDelete.Text = "Can Delete";
            this.checkBoxCanDelete.UseVisualStyleBackColor = true;
            // 
            // comboBoxForm
            // 
            this.comboBoxForm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxForm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxForm.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.comboBoxForm.FormattingEnabled = true;
            this.comboBoxForm.Location = new System.Drawing.Point(71, 6);
            this.comboBoxForm.Name = "comboBoxForm";
            this.comboBoxForm.Size = new System.Drawing.Size(433, 31);
            this.comboBoxForm.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 23);
            this.label2.TabIndex = 15;
            this.label2.Text = "Form:";
            // 
            // MstUserDetailUserFormDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(516, 342);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MstUserDetailUserFormDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Form Detail";
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxForm;
        private System.Windows.Forms.CheckBox checkBoxCanEdit;
        private System.Windows.Forms.CheckBox checkBoxCanPreview;
        private System.Windows.Forms.CheckBox checkBoxCanPrint;
        private System.Windows.Forms.CheckBox checkBoxCanUnlock;
        private System.Windows.Forms.CheckBox checkBoxCanLock;
        private System.Windows.Forms.CheckBox checkBoxCanAdd;
        private System.Windows.Forms.CheckBox checkBoxCanDelete;
    }
}