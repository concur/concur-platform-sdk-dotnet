namespace Concur.Sample.ClientLibrary
{
    partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.LoginButton = new System.Windows.Forms.Button();
			this.LoginIdTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.PasswordTextBox = new System.Windows.Forms.TextBox();
			this.OAuthTokenTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.ExpensePolicyListBox = new System.Windows.Forms.ListBox();
			this.label6 = new System.Windows.Forms.Label();
			this.ReportNameBox = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.VendorDescriptionTextBox = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.TransactionAmountTextBox = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.TransactionCurrencyTextBox = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.TransactionDateTextBox = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.CreateEverythingButton = new System.Windows.Forms.Button();
			this.ExpenseTypeComboBox = new System.Windows.Forms.ComboBox();
			this.PaymentTypeComboBox = new System.Windows.Forms.ComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.ExpenseEntryFileImagePathTextBox = new System.Windows.Forms.TextBox();
			this.ExpenseEntryFileImageButton = new System.Windows.Forms.Button();
			this.openEntryImageFileDialog2 = new System.Windows.Forms.OpenFileDialog();
			this.label7 = new System.Windows.Forms.Label();
			this.ClientIdTextBox = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// LoginButton
			// 
			this.LoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoginButton.Location = new System.Drawing.Point(12, 145);
			this.LoginButton.Name = "LoginButton";
			this.LoginButton.Size = new System.Drawing.Size(671, 29);
			this.LoginButton.TabIndex = 0;
			this.LoginButton.Text = "Login to get OAuth Token";
			this.LoginButton.UseVisualStyleBackColor = true;
			this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
			// 
			// LoginIdTextBox
			// 
			this.LoginIdTextBox.Location = new System.Drawing.Point(61, 82);
			this.LoginIdTextBox.Name = "LoginIdTextBox";
			this.LoginIdTextBox.Size = new System.Drawing.Size(272, 20);
			this.LoginIdTextBox.TabIndex = 1;
			this.LoginIdTextBox.Text = "e.g. John@CompanyA.com";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 86);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "LoginID:";
			// 
			// PasswordTextBox
			// 
			this.PasswordTextBox.Location = new System.Drawing.Point(410, 84);
			this.PasswordTextBox.Name = "PasswordTextBox";
			this.PasswordTextBox.Size = new System.Drawing.Size(274, 20);
			this.PasswordTextBox.TabIndex = 3;
			// 
			// OAuthTokenTextBox
			// 
			this.OAuthTokenTextBox.Location = new System.Drawing.Point(425, 117);
			this.OAuthTokenTextBox.Name = "OAuthTokenTextBox";
			this.OAuthTokenTextBox.ReadOnly = true;
			this.OAuthTokenTextBox.Size = new System.Drawing.Size(259, 20);
			this.OAuthTokenTextBox.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(350, 120);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "OAuth Token:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(352, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Password:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(16, 229);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(82, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "Expense Policy:";
			// 
			// ExpensePolicyListBox
			// 
			this.ExpensePolicyListBox.FormattingEnabled = true;
			this.ExpensePolicyListBox.Location = new System.Drawing.Point(19, 245);
			this.ExpensePolicyListBox.Name = "ExpensePolicyListBox";
			this.ExpensePolicyListBox.Size = new System.Drawing.Size(311, 56);
			this.ExpensePolicyListBox.TabIndex = 5;
			this.ExpensePolicyListBox.SelectedIndexChanged += new System.EventHandler(this.ExpensePolicyListBox_SelectedIndexChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(13, 198);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(73, 13);
			this.label6.TabIndex = 2;
			this.label6.Text = "Report Name:";
			// 
			// ReportNameBox
			// 
			this.ReportNameBox.Location = new System.Drawing.Point(86, 194);
			this.ReportNameBox.Name = "ReportNameBox";
			this.ReportNameBox.Size = new System.Drawing.Size(598, 20);
			this.ReportNameBox.TabIndex = 4;
			this.ReportNameBox.Text = "TestReportWithImage";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(350, 326);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 13);
			this.label8.TabIndex = 2;
			this.label8.Text = "Vendor Description:";
			// 
			// VendorDescriptionTextBox
			// 
			this.VendorDescriptionTextBox.Location = new System.Drawing.Point(456, 323);
			this.VendorDescriptionTextBox.Name = "VendorDescriptionTextBox";
			this.VendorDescriptionTextBox.Size = new System.Drawing.Size(228, 20);
			this.VendorDescriptionTextBox.TabIndex = 4;
			this.VendorDescriptionTextBox.Text = "SomeTestVendor";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(16, 328);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(105, 13);
			this.label9.TabIndex = 2;
			this.label9.Text = "Transaction Amount:";
			// 
			// TransactionAmountTextBox
			// 
			this.TransactionAmountTextBox.Location = new System.Drawing.Point(126, 324);
			this.TransactionAmountTextBox.Name = "TransactionAmountTextBox";
			this.TransactionAmountTextBox.Size = new System.Drawing.Size(207, 20);
			this.TransactionAmountTextBox.TabIndex = 4;
			this.TransactionAmountTextBox.Text = "12.34";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(13, 355);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(111, 13);
			this.label10.TabIndex = 2;
			this.label10.Text = "Transaction Currency:";
			// 
			// TransactionCurrencyTextBox
			// 
			this.TransactionCurrencyTextBox.Location = new System.Drawing.Point(123, 351);
			this.TransactionCurrencyTextBox.Name = "TransactionCurrencyTextBox";
			this.TransactionCurrencyTextBox.Size = new System.Drawing.Size(207, 20);
			this.TransactionCurrencyTextBox.TabIndex = 4;
			this.TransactionCurrencyTextBox.Text = "USD";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(350, 251);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(78, 13);
			this.label11.TabIndex = 2;
			this.label11.Text = "Expense Type:";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(348, 357);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(92, 13);
			this.label12.TabIndex = 2;
			this.label12.Text = "Transaction Date:";
			// 
			// TransactionDateTextBox
			// 
			this.TransactionDateTextBox.Location = new System.Drawing.Point(439, 353);
			this.TransactionDateTextBox.Name = "TransactionDateTextBox";
			this.TransactionDateTextBox.Size = new System.Drawing.Size(244, 20);
			this.TransactionDateTextBox.TabIndex = 4;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(350, 279);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(78, 13);
			this.label13.TabIndex = 2;
			this.label13.Text = "Payment Type:";
			// 
			// CreateEverythingButton
			// 
			this.CreateEverythingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CreateEverythingButton.Location = new System.Drawing.Point(205, 430);
			this.CreateEverythingButton.Name = "CreateEverythingButton";
			this.CreateEverythingButton.Size = new System.Drawing.Size(248, 39);
			this.CreateEverythingButton.TabIndex = 7;
			this.CreateEverythingButton.Text = "Create Report with Image";
			this.CreateEverythingButton.UseVisualStyleBackColor = true;
			this.CreateEverythingButton.Click += new System.EventHandler(this.CreateEverythingButton_Click);
			// 
			// ExpenseTypeComboBox
			// 
			this.ExpenseTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ExpenseTypeComboBox.FormattingEnabled = true;
			this.ExpenseTypeComboBox.Location = new System.Drawing.Point(439, 245);
			this.ExpenseTypeComboBox.Name = "ExpenseTypeComboBox";
			this.ExpenseTypeComboBox.Size = new System.Drawing.Size(244, 21);
			this.ExpenseTypeComboBox.Sorted = true;
			this.ExpenseTypeComboBox.TabIndex = 8;
			// 
			// PaymentTypeComboBox
			// 
			this.PaymentTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.PaymentTypeComboBox.FormattingEnabled = true;
			this.PaymentTypeComboBox.Location = new System.Drawing.Point(439, 272);
			this.PaymentTypeComboBox.Name = "PaymentTypeComboBox";
			this.PaymentTypeComboBox.Size = new System.Drawing.Size(244, 21);
			this.PaymentTypeComboBox.Sorted = true;
			this.PaymentTypeComboBox.TabIndex = 8;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(16, 396);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(127, 13);
			this.label14.TabIndex = 2;
			this.label14.Text = "Expense Image File Path:";
			// 
			// ExpenseEntryFileImagePathTextBox
			// 
			this.ExpenseEntryFileImagePathTextBox.Location = new System.Drawing.Point(149, 392);
			this.ExpenseEntryFileImagePathTextBox.Name = "ExpenseEntryFileImagePathTextBox";
			this.ExpenseEntryFileImagePathTextBox.Size = new System.Drawing.Size(437, 20);
			this.ExpenseEntryFileImagePathTextBox.TabIndex = 4;
			// 
			// ExpenseEntryFileImageButton
			// 
			this.ExpenseEntryFileImageButton.Location = new System.Drawing.Point(592, 391);
			this.ExpenseEntryFileImageButton.Name = "ExpenseEntryFileImageButton";
			this.ExpenseEntryFileImageButton.Size = new System.Drawing.Size(92, 21);
			this.ExpenseEntryFileImageButton.TabIndex = 6;
			this.ExpenseEntryFileImageButton.Text = "Browse...";
			this.ExpenseEntryFileImageButton.UseVisualStyleBackColor = true;
			this.ExpenseEntryFileImageButton.Click += new System.EventHandler(this.ExpenseEntryFileImageButton_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(10, 117);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(83, 13);
			this.label7.TabIndex = 10;
			this.label7.Text = "OAuth Client ID:";
			// 
			// ClientIdTextBox
			// 
			this.ClientIdTextBox.AccessibleDescription = "";
			this.ClientIdTextBox.Location = new System.Drawing.Point(94, 113);
			this.ClientIdTextBox.Name = "ClientIdTextBox";
			this.ClientIdTextBox.Size = new System.Drawing.Size(239, 20);
			this.ClientIdTextBox.TabIndex = 9;
			this.ClientIdTextBox.Text = " a real app would obtain this ID from a config file";
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(15, 12);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(668, 45);
			this.textBox1.TabIndex = 12;
			this.textBox1.Text = resources.GetString("textBox1.Text");
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(696, 483);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.ClientIdTextBox);
			this.Controls.Add(this.PaymentTypeComboBox);
			this.Controls.Add(this.ExpenseTypeComboBox);
			this.Controls.Add(this.CreateEverythingButton);
			this.Controls.Add(this.ExpenseEntryFileImageButton);
			this.Controls.Add(this.ExpensePolicyListBox);
			this.Controls.Add(this.ExpenseEntryFileImagePathTextBox);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.TransactionDateTextBox);
			this.Controls.Add(this.TransactionCurrencyTextBox);
			this.Controls.Add(this.TransactionAmountTextBox);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.VendorDescriptionTextBox);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.ReportNameBox);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.OAuthTokenTextBox);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.PasswordTextBox);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.LoginIdTextBox);
			this.Controls.Add(this.LoginButton);
			this.Name = "MainForm";
			this.Text = "Concur Platform SDK Sample";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox LoginIdTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox OAuthTokenTextBox;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox ExpensePolicyListBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ReportNameBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox VendorDescriptionTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TransactionAmountTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TransactionCurrencyTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TransactionDateTextBox;
		private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button CreateEverythingButton;
        private System.Windows.Forms.ComboBox ExpenseTypeComboBox;
        private System.Windows.Forms.ComboBox PaymentTypeComboBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox ExpenseEntryFileImagePathTextBox;
        private System.Windows.Forms.Button ExpenseEntryFileImageButton;
        private System.Windows.Forms.OpenFileDialog openEntryImageFileDialog2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox ClientIdTextBox;
		private System.Windows.Forms.TextBox textBox1;
    }
}

