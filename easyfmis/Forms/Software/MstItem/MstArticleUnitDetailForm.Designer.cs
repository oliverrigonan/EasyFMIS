﻿namespace easyfmis.Forms.Software.MstItem
{
    partial class MstArticleUnitDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MstArticleUnitDetailForm));
            this.comboBoxBaseUnit = new System.Windows.Forms.ComboBox();
            this.textBoxUnitMultiplier = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxBaseUnitMultiplier = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.comboBoxConvertedUnit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxBaseUnit
            // 
            this.comboBoxBaseUnit.DropDownWidth = 150;
            this.comboBoxBaseUnit.Enabled = false;
            this.comboBoxBaseUnit.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.comboBoxBaseUnit.FormattingEnabled = true;
            this.comboBoxBaseUnit.Location = new System.Drawing.Point(262, 73);
            this.comboBoxBaseUnit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxBaseUnit.Name = "comboBoxBaseUnit";
            this.comboBoxBaseUnit.Size = new System.Drawing.Size(145, 27);
            this.comboBoxBaseUnit.TabIndex = 2;
            this.comboBoxBaseUnit.TabStop = false;
            // 
            // textBoxUnitMultiplier
            // 
            this.textBoxUnitMultiplier.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxUnitMultiplier.Location = new System.Drawing.Point(113, 104);
            this.textBoxUnitMultiplier.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxUnitMultiplier.Name = "textBoxUnitMultiplier";
            this.textBoxUnitMultiplier.Size = new System.Drawing.Size(145, 26);
            this.textBoxUnitMultiplier.TabIndex = 1;
            this.textBoxUnitMultiplier.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxUnitMultiplier_KeyPress);
            this.textBoxUnitMultiplier.Leave += new System.EventHandler(this.textBoxUnitMultiplier_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label4.Location = new System.Drawing.Point(258, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 19);
            this.label4.TabIndex = 17;
            this.label4.Text = "Unit:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label3.Location = new System.Drawing.Point(3, 107);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "Converted Unit:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label2.Location = new System.Drawing.Point(39, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "Base Unit:";
            // 
            // textBoxBaseUnitMultiplier
            // 
            this.textBoxBaseUnitMultiplier.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxBaseUnitMultiplier.Location = new System.Drawing.Point(113, 74);
            this.textBoxBaseUnitMultiplier.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxBaseUnitMultiplier.Name = "textBoxBaseUnitMultiplier";
            this.textBoxBaseUnitMultiplier.Size = new System.Drawing.Size(145, 26);
            this.textBoxBaseUnitMultiplier.TabIndex = 0;
            this.textBoxBaseUnitMultiplier.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxBaseUnitMultiplier_KeyPress);
            this.textBoxBaseUnitMultiplier.Leave += new System.EventHandler(this.textBoxBaseUnitMultiplie_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 50);
            this.panel1.TabIndex = 13;
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
            this.buttonSave.Location = new System.Drawing.Point(272, 10);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(70, 32);
            this.buttonSave.TabIndex = 20;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.Item;
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
            this.label1.Location = new System.Drawing.Point(50, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Unit Conversion Detail";
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
            this.buttonClose.Location = new System.Drawing.Point(347, 10);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(70, 32);
            this.buttonClose.TabIndex = 21;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // comboBoxConvertedUnit
            // 
            this.comboBoxConvertedUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxConvertedUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxConvertedUnit.DropDownHeight = 90;
            this.comboBoxConvertedUnit.DropDownWidth = 150;
            this.comboBoxConvertedUnit.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.comboBoxConvertedUnit.FormattingEnabled = true;
            this.comboBoxConvertedUnit.IntegralHeight = false;
            this.comboBoxConvertedUnit.Location = new System.Drawing.Point(262, 104);
            this.comboBoxConvertedUnit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxConvertedUnit.Name = "comboBoxConvertedUnit";
            this.comboBoxConvertedUnit.Size = new System.Drawing.Size(145, 27);
            this.comboBoxConvertedUnit.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label5.Location = new System.Drawing.Point(109, 52);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 19);
            this.label5.TabIndex = 19;
            this.label5.Text = "Quantity:";
            // 
            // MstArticleUnitDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(427, 136);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxConvertedUnit);
            this.Controls.Add(this.comboBoxBaseUnit);
            this.Controls.Add(this.textBoxUnitMultiplier);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxBaseUnitMultiplier);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "MstArticleUnitDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unit Conversion Detail";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxBaseUnit;
        private System.Windows.Forms.TextBox textBoxUnitMultiplier;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxBaseUnitMultiplier;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ComboBox comboBoxConvertedUnit;
        private System.Windows.Forms.Label label5;
    }
}