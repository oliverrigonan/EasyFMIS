﻿namespace easyfmis.Forms.Software.TrnCollection
{
    partial class TrnCollectionDetailCollectionLineDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnCollectionDetailCollectionLineDetailForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxSINumber = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxOtherInformation = new System.Windows.Forms.TextBox();
            this.textBoxGiftCertificateNumber = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxCreditCardExpiry = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxCreditCardHolderName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxCreditCardReferenceNumber = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxCreditCardBank = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxCreditCardType = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxCreditCardNumber = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxCreditCardVerificationCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxCheckBank = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePickerCheckDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxCheckNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxPayType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxArticleGroup = new System.Windows.Forms.ComboBox();
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
            this.panel1.Size = new System.Drawing.Size(574, 50);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::easyfmis.Properties.Resources.Collection;
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
            this.label1.Size = new System.Drawing.Size(215, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Collection Line Detail";
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
            this.buttonClose.Location = new System.Drawing.Point(494, 10);
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
            this.buttonSave.Location = new System.Drawing.Point(418, 10);
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
            this.panel2.Controls.Add(this.textBoxSINumber);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.textBoxOtherInformation);
            this.panel2.Controls.Add(this.textBoxGiftCertificateNumber);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.textBoxCreditCardExpiry);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.textBoxCreditCardHolderName);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.textBoxCreditCardReferenceNumber);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.textBoxCreditCardBank);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.textBoxCreditCardType);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.textBoxCreditCardNumber);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.textBoxCreditCardVerificationCode);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.textBoxCheckBank);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.dateTimePickerCheckDate);
            this.panel2.Controls.Add(this.textBoxCheckNumber);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.comboBoxPayType);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBoxAmount);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBoxArticleGroup);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(574, 528);
            this.panel2.TabIndex = 9;
            // 
            // textBoxSINumber
            // 
            this.textBoxSINumber.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxSINumber.Location = new System.Drawing.Point(214, 36);
            this.textBoxSINumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxSINumber.Name = "textBoxSINumber";
            this.textBoxSINumber.Size = new System.Drawing.Size(276, 26);
            this.textBoxSINumber.TabIndex = 60;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label17.Location = new System.Drawing.Point(86, 460);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(124, 19);
            this.label17.TabIndex = 59;
            this.label17.Text = "Other Information:";
            // 
            // textBoxOtherInformation
            // 
            this.textBoxOtherInformation.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxOtherInformation.Location = new System.Drawing.Point(214, 457);
            this.textBoxOtherInformation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxOtherInformation.Multiline = true;
            this.textBoxOtherInformation.Name = "textBoxOtherInformation";
            this.textBoxOtherInformation.Size = new System.Drawing.Size(276, 60);
            this.textBoxOtherInformation.TabIndex = 15;
            // 
            // textBoxGiftCertificateNumber
            // 
            this.textBoxGiftCertificateNumber.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxGiftCertificateNumber.Location = new System.Drawing.Point(214, 427);
            this.textBoxGiftCertificateNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxGiftCertificateNumber.Name = "textBoxGiftCertificateNumber";
            this.textBoxGiftCertificateNumber.Size = new System.Drawing.Size(276, 26);
            this.textBoxGiftCertificateNumber.TabIndex = 14;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label16.Location = new System.Drawing.Point(57, 430);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(153, 19);
            this.label16.TabIndex = 56;
            this.label16.Text = "Gift Certificate Number:";
            // 
            // textBoxCreditCardExpiry
            // 
            this.textBoxCreditCardExpiry.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCreditCardExpiry.Location = new System.Drawing.Point(214, 397);
            this.textBoxCreditCardExpiry.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCreditCardExpiry.Name = "textBoxCreditCardExpiry";
            this.textBoxCreditCardExpiry.Size = new System.Drawing.Size(276, 26);
            this.textBoxCreditCardExpiry.TabIndex = 13;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label15.Location = new System.Drawing.Point(88, 400);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(122, 19);
            this.label15.TabIndex = 54;
            this.label15.Text = "Credit Card Expiry:";
            // 
            // textBoxCreditCardHolderName
            // 
            this.textBoxCreditCardHolderName.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCreditCardHolderName.Location = new System.Drawing.Point(214, 367);
            this.textBoxCreditCardHolderName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCreditCardHolderName.Name = "textBoxCreditCardHolderName";
            this.textBoxCreditCardHolderName.Size = new System.Drawing.Size(276, 26);
            this.textBoxCreditCardHolderName.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label14.Location = new System.Drawing.Point(43, 370);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(167, 19);
            this.label14.TabIndex = 52;
            this.label14.Text = "Credit Card Holder Name:";
            // 
            // textBoxCreditCardReferenceNumber
            // 
            this.textBoxCreditCardReferenceNumber.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCreditCardReferenceNumber.Location = new System.Drawing.Point(214, 337);
            this.textBoxCreditCardReferenceNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCreditCardReferenceNumber.Name = "textBoxCreditCardReferenceNumber";
            this.textBoxCreditCardReferenceNumber.Size = new System.Drawing.Size(276, 26);
            this.textBoxCreditCardReferenceNumber.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label13.Location = new System.Drawing.Point(11, 340);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(199, 19);
            this.label13.TabIndex = 50;
            this.label13.Text = "Credit Card Reference Number:";
            // 
            // textBoxCreditCardBank
            // 
            this.textBoxCreditCardBank.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCreditCardBank.Location = new System.Drawing.Point(214, 307);
            this.textBoxCreditCardBank.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCreditCardBank.Name = "textBoxCreditCardBank";
            this.textBoxCreditCardBank.Size = new System.Drawing.Size(276, 26);
            this.textBoxCreditCardBank.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label12.Location = new System.Drawing.Point(94, 310);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 19);
            this.label12.TabIndex = 48;
            this.label12.Text = "Credit Card Bank:";
            // 
            // textBoxCreditCardType
            // 
            this.textBoxCreditCardType.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCreditCardType.Location = new System.Drawing.Point(214, 277);
            this.textBoxCreditCardType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCreditCardType.Name = "textBoxCreditCardType";
            this.textBoxCreditCardType.Size = new System.Drawing.Size(276, 26);
            this.textBoxCreditCardType.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label11.Location = new System.Drawing.Point(96, 280);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 19);
            this.label11.TabIndex = 46;
            this.label11.Text = "Credit Card Type:";
            // 
            // textBoxCreditCardNumber
            // 
            this.textBoxCreditCardNumber.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCreditCardNumber.Location = new System.Drawing.Point(214, 247);
            this.textBoxCreditCardNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCreditCardNumber.Name = "textBoxCreditCardNumber";
            this.textBoxCreditCardNumber.Size = new System.Drawing.Size(276, 26);
            this.textBoxCreditCardNumber.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label10.Location = new System.Drawing.Point(74, 250);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 19);
            this.label10.TabIndex = 44;
            this.label10.Text = "Credit Card Number:";
            // 
            // textBoxCreditCardVerificationCode
            // 
            this.textBoxCreditCardVerificationCode.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCreditCardVerificationCode.Location = new System.Drawing.Point(214, 217);
            this.textBoxCreditCardVerificationCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCreditCardVerificationCode.Name = "textBoxCreditCardVerificationCode";
            this.textBoxCreditCardVerificationCode.Size = new System.Drawing.Size(276, 26);
            this.textBoxCreditCardVerificationCode.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label9.Location = new System.Drawing.Point(21, 220);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(189, 19);
            this.label9.TabIndex = 42;
            this.label9.Text = "Credit Card Verification Code:";
            // 
            // textBoxCheckBank
            // 
            this.textBoxCheckBank.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCheckBank.Location = new System.Drawing.Point(214, 187);
            this.textBoxCheckBank.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCheckBank.Name = "textBoxCheckBank";
            this.textBoxCheckBank.Size = new System.Drawing.Size(276, 26);
            this.textBoxCheckBank.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label8.Location = new System.Drawing.Point(127, 190);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 19);
            this.label8.TabIndex = 40;
            this.label8.Text = "Check Bank:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label7.Location = new System.Drawing.Point(128, 160);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 19);
            this.label7.TabIndex = 39;
            this.label7.Text = "Check Date:";
            // 
            // dateTimePickerCheckDate
            // 
            this.dateTimePickerCheckDate.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.dateTimePickerCheckDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerCheckDate.Location = new System.Drawing.Point(214, 157);
            this.dateTimePickerCheckDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePickerCheckDate.Name = "dateTimePickerCheckDate";
            this.dateTimePickerCheckDate.Size = new System.Drawing.Size(122, 26);
            this.dateTimePickerCheckDate.TabIndex = 5;
            // 
            // textBoxCheckNumber
            // 
            this.textBoxCheckNumber.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCheckNumber.Location = new System.Drawing.Point(214, 127);
            this.textBoxCheckNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCheckNumber.Name = "textBoxCheckNumber";
            this.textBoxCheckNumber.Size = new System.Drawing.Size(276, 26);
            this.textBoxCheckNumber.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label6.Location = new System.Drawing.Point(107, 130);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 19);
            this.label6.TabIndex = 36;
            this.label6.Text = "Check Number:";
            // 
            // comboBoxPayType
            // 
            this.comboBoxPayType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxPayType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPayType.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.comboBoxPayType.FormattingEnabled = true;
            this.comboBoxPayType.Location = new System.Drawing.Point(214, 96);
            this.comboBoxPayType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxPayType.Name = "comboBoxPayType";
            this.comboBoxPayType.Size = new System.Drawing.Size(276, 27);
            this.comboBoxPayType.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label5.Location = new System.Drawing.Point(144, 99);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 19);
            this.label5.TabIndex = 34;
            this.label5.Text = "Pay Type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label4.Location = new System.Drawing.Point(133, 39);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 19);
            this.label4.TabIndex = 32;
            this.label4.Text = "SI Number:";
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxAmount.Location = new System.Drawing.Point(214, 66);
            this.textBoxAmount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(276, 26);
            this.textBoxAmount.TabIndex = 2;
            this.textBoxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCollectionLineAmount_KeyPress);
            this.textBoxAmount.Leave += new System.EventHandler(this.textBoxCollectionLineCost_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label2.Location = new System.Drawing.Point(148, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 19);
            this.label2.TabIndex = 30;
            this.label2.Text = "Amount:";
            // 
            // comboBoxArticleGroup
            // 
            this.comboBoxArticleGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxArticleGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxArticleGroup.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.comboBoxArticleGroup.FormattingEnabled = true;
            this.comboBoxArticleGroup.Location = new System.Drawing.Point(214, 5);
            this.comboBoxArticleGroup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxArticleGroup.Name = "comboBoxArticleGroup";
            this.comboBoxArticleGroup.Size = new System.Drawing.Size(276, 27);
            this.comboBoxArticleGroup.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label3.Location = new System.Drawing.Point(117, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "Article Group:";
            // 
            // TrnCollectionDetailCollectionLineDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(574, 578);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "TrnCollectionDetailCollectionLineDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Collection Line Detail";
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
        private System.Windows.Forms.ComboBox comboBoxArticleGroup;
        private System.Windows.Forms.TextBox textBoxCheckNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxPayType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxGiftCertificateNumber;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxCreditCardExpiry;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxCreditCardHolderName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxCreditCardReferenceNumber;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxCreditCardBank;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxCreditCardType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxCreditCardNumber;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxCreditCardVerificationCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxCheckBank;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePickerCheckDate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxOtherInformation;
        private System.Windows.Forms.TextBox textBoxSINumber;
    }
}