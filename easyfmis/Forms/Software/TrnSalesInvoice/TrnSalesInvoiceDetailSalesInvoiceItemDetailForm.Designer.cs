namespace easyfmis.Forms.Software.TrnSalesInvoice
{
    partial class TrnSalesInvoiceDetailSalesInvoiceItemDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnSalesInvoiceDetailSalesInvoiceItemDetailForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBoxInventoryCode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxUnit = new System.Windows.Forms.ComboBox();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNetPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSalesInvoiceItemItemDescription = new System.Windows.Forms.TextBox();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.comboBoxDiscount = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxDiscountRate = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxDiscountAmount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxTaxAmount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxTaxRate = new System.Windows.Forms.TextBox();
            this.comboBoxTax = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
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
            this.panel1.Size = new System.Drawing.Size(660, 63);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.POS;
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
            this.label1.Size = new System.Drawing.Size(304, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sales Invoice Item Detail";
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
            this.buttonClose.Location = new System.Drawing.Point(560, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(88, 40);
            this.buttonClose.TabIndex = 1;
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
            this.buttonSave.Location = new System.Drawing.Point(466, 12);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(88, 40);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.textBoxTaxAmount);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.textBoxTaxRate);
            this.panel2.Controls.Add(this.comboBoxTax);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.textBoxDiscountAmount);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.textBoxDiscountRate);
            this.panel2.Controls.Add(this.comboBoxDiscount);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textBoxPrice);
            this.panel2.Controls.Add(this.comboBoxInventoryCode);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.comboBoxUnit);
            this.panel2.Controls.Add(this.textBoxAmount);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBoxNetPrice);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBoxSalesInvoiceItemItemDescription);
            this.panel2.Controls.Add(this.textBoxQuantity);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(660, 489);
            this.panel2.TabIndex = 9;
            // 
            // comboBoxInventoryCode
            // 
            this.comboBoxInventoryCode.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.comboBoxInventoryCode.FormattingEnabled = true;
            this.comboBoxInventoryCode.Location = new System.Drawing.Point(177, 80);
            this.comboBoxInventoryCode.Name = "comboBoxInventoryCode";
            this.comboBoxInventoryCode.Size = new System.Drawing.Size(377, 31);
            this.comboBoxInventoryCode.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label5.Location = new System.Drawing.Point(40, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 23);
            this.label5.TabIndex = 26;
            this.label5.Text = "Inventory Code:";
            // 
            // comboBoxUnit
            // 
            this.comboBoxUnit.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.comboBoxUnit.FormattingEnabled = true;
            this.comboBoxUnit.Location = new System.Drawing.Point(177, 117);
            this.comboBoxUnit.Name = "comboBoxUnit";
            this.comboBoxUnit.Size = new System.Drawing.Size(138, 31);
            this.comboBoxUnit.TabIndex = 25;
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxAmount.Location = new System.Drawing.Point(177, 335);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.ReadOnly = true;
            this.textBoxAmount.Size = new System.Drawing.Size(269, 30);
            this.textBoxAmount.TabIndex = 24;
            this.textBoxAmount.TabStop = false;
            this.textBoxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label9.Location = new System.Drawing.Point(95, 338);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 23);
            this.label9.TabIndex = 23;
            this.label9.Text = "Amount:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label4.Location = new System.Drawing.Point(87, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 23);
            this.label4.TabIndex = 17;
            this.label4.Text = "Net Price:";
            // 
            // textBoxNetPrice
            // 
            this.textBoxNetPrice.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxNetPrice.Location = new System.Drawing.Point(177, 299);
            this.textBoxNetPrice.Name = "textBoxNetPrice";
            this.textBoxNetPrice.Size = new System.Drawing.Size(269, 30);
            this.textBoxNetPrice.TabIndex = 16;
            this.textBoxNetPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxNetPrice.TextChanged += new System.EventHandler(this.textBoxSalesInvoiceItemCost_TextChanged);
            this.textBoxNetPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSalesInvoiceItemCost_KeyPress);
            this.textBoxNetPrice.Leave += new System.EventHandler(this.textBoxSalesInvoiceItemCost_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label2.Location = new System.Drawing.Point(91, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Quantity:";
            // 
            // textBoxSalesInvoiceItemItemDescription
            // 
            this.textBoxSalesInvoiceItemItemDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSalesInvoiceItemItemDescription.BackColor = System.Drawing.Color.White;
            this.textBoxSalesInvoiceItemItemDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSalesInvoiceItemItemDescription.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.textBoxSalesInvoiceItemItemDescription.Location = new System.Drawing.Point(12, 6);
            this.textBoxSalesInvoiceItemItemDescription.Name = "textBoxSalesInvoiceItemItemDescription";
            this.textBoxSalesInvoiceItemItemDescription.ReadOnly = true;
            this.textBoxSalesInvoiceItemItemDescription.Size = new System.Drawing.Size(636, 32);
            this.textBoxSalesInvoiceItemItemDescription.TabIndex = 12;
            this.textBoxSalesInvoiceItemItemDescription.TabStop = false;
            this.textBoxSalesInvoiceItemItemDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxQuantity.Location = new System.Drawing.Point(177, 44);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(269, 30);
            this.textBoxQuantity.TabIndex = 11;
            this.textBoxQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxQuantity.TextChanged += new System.EventHandler(this.textBoxSalesInvoiceItemQuantity_TextChanged);
            this.textBoxQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSalesInvoiceItemQuantity_KeyPress);
            this.textBoxQuantity.Leave += new System.EventHandler(this.textBoxSalesInvoiceItemQuantity_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label3.Location = new System.Drawing.Point(125, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 23);
            this.label3.TabIndex = 14;
            this.label3.Text = "Unit:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label6.Location = new System.Drawing.Point(120, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 23);
            this.label6.TabIndex = 29;
            this.label6.Text = "Price:";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxPrice.Location = new System.Drawing.Point(177, 154);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.ReadOnly = true;
            this.textBoxPrice.Size = new System.Drawing.Size(269, 30);
            this.textBoxPrice.TabIndex = 28;
            this.textBoxPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // comboBoxDiscount
            // 
            this.comboBoxDiscount.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.comboBoxDiscount.FormattingEnabled = true;
            this.comboBoxDiscount.Location = new System.Drawing.Point(177, 190);
            this.comboBoxDiscount.Name = "comboBoxDiscount";
            this.comboBoxDiscount.Size = new System.Drawing.Size(377, 31);
            this.comboBoxDiscount.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label7.Location = new System.Drawing.Point(90, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 23);
            this.label7.TabIndex = 30;
            this.label7.Text = "Discount:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label8.Location = new System.Drawing.Point(51, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 23);
            this.label8.TabIndex = 33;
            this.label8.Text = "Discount Rate:";
            // 
            // textBoxDiscountRate
            // 
            this.textBoxDiscountRate.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxDiscountRate.Location = new System.Drawing.Point(177, 227);
            this.textBoxDiscountRate.Name = "textBoxDiscountRate";
            this.textBoxDiscountRate.Size = new System.Drawing.Size(269, 30);
            this.textBoxDiscountRate.TabIndex = 32;
            this.textBoxDiscountRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label10.Location = new System.Drawing.Point(23, 266);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(148, 23);
            this.label10.TabIndex = 35;
            this.label10.Text = "Discount Amount:";
            // 
            // textBoxDiscountAmount
            // 
            this.textBoxDiscountAmount.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxDiscountAmount.Location = new System.Drawing.Point(177, 263);
            this.textBoxDiscountAmount.Name = "textBoxDiscountAmount";
            this.textBoxDiscountAmount.Size = new System.Drawing.Size(269, 30);
            this.textBoxDiscountAmount.TabIndex = 34;
            this.textBoxDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label11.Location = new System.Drawing.Point(66, 447);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 23);
            this.label11.TabIndex = 41;
            this.label11.Text = "Tax Amount:";
            // 
            // textBoxTaxAmount
            // 
            this.textBoxTaxAmount.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxTaxAmount.Location = new System.Drawing.Point(177, 444);
            this.textBoxTaxAmount.Name = "textBoxTaxAmount";
            this.textBoxTaxAmount.Size = new System.Drawing.Size(269, 30);
            this.textBoxTaxAmount.TabIndex = 40;
            this.textBoxTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label12.Location = new System.Drawing.Point(94, 411);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 23);
            this.label12.TabIndex = 39;
            this.label12.Text = "Tax Rate:";
            // 
            // textBoxTaxRate
            // 
            this.textBoxTaxRate.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxTaxRate.Location = new System.Drawing.Point(177, 408);
            this.textBoxTaxRate.Name = "textBoxTaxRate";
            this.textBoxTaxRate.Size = new System.Drawing.Size(269, 30);
            this.textBoxTaxRate.TabIndex = 38;
            this.textBoxTaxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // comboBoxTax
            // 
            this.comboBoxTax.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.comboBoxTax.FormattingEnabled = true;
            this.comboBoxTax.Location = new System.Drawing.Point(177, 371);
            this.comboBoxTax.Name = "comboBoxTax";
            this.comboBoxTax.Size = new System.Drawing.Size(377, 31);
            this.comboBoxTax.TabIndex = 37;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label13.Location = new System.Drawing.Point(133, 374);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 23);
            this.label13.TabIndex = 36;
            this.label13.Text = "Tax:";
            // 
            // TrnSalesInvoiceDetailSalesInvoiceItemDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(660, 552);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TrnSalesInvoiceDetailSalesInvoiceItemDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock-Out Line Item Detail";
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
        private System.Windows.Forms.TextBox textBoxSalesInvoiceItemItemDescription;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNetPrice;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxUnit;
        private System.Windows.Forms.ComboBox comboBoxInventoryCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxTaxAmount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxTaxRate;
        private System.Windows.Forms.ComboBox comboBoxTax;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxDiscountAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxDiscountRate;
        private System.Windows.Forms.ComboBox comboBoxDiscount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPrice;
    }
}