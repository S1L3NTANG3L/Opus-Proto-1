
namespace Opus_Proto_1
{
    partial class Settings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbTheme = new System.Windows.Forms.ComboBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // cmbTheme
            // 
            this.cmbTheme.FormattingEnabled = true;
            this.cmbTheme.Items.AddRange(new object[] {
            "Light",
            "Dark"});
            this.cmbTheme.Location = new System.Drawing.Point(175, 38);
            this.cmbTheme.Name = "cmbTheme";
            this.cmbTheme.Size = new System.Drawing.Size(151, 28);
            this.cmbTheme.TabIndex = 0;
            this.cmbTheme.SelectionChangeCommitted += new System.EventHandler(this.cmbTheme_SelectionChangeCommitted);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(23, 689);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(94, 29);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Theme:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Currency:";
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Items.AddRange(new object[] {
            "AFN",
            "EUR",
            "ALL",
            "DZD",
            "USD",
            "AOA",
            "XCD",
            "ARS",
            "AMD",
            "AWG",
            "AUD",
            "AZN",
            "BSD",
            "BHD",
            "BDT",
            "BBD",
            "BYN",
            "BZD",
            "XOF",
            "BMD",
            "INR",
            "BTN",
            "BOB",
            "BOV",
            "BAM",
            "BWP",
            "NOK",
            "BRL",
            "BND",
            "BGN",
            "BIF",
            "CVE",
            "KHR",
            "XAF",
            "CAD",
            "KYD",
            "CLP",
            "CLF",
            "CNY",
            "COP",
            "COU",
            "KMF",
            "CDF",
            "NZD",
            "CRC",
            "HRK",
            "CUP",
            "CUC",
            "ANG",
            "CZK",
            "DKK",
            "DJF",
            "DOP",
            "EGP",
            "SVC",
            "ERN",
            "SZL",
            "ETB",
            "FKP",
            "FJD",
            "XPF",
            "GMD",
            "GEL",
            "GHS",
            "GIP",
            "GTQ",
            "GBP",
            "GNF",
            "GYD",
            "HTG",
            "HNL",
            "HKD",
            "HUF",
            "ISK",
            "IDR",
            "XDR",
            "IRR",
            "IQD",
            "ILS",
            "JMD",
            "JPY",
            "JOD",
            "KZT",
            "KES",
            "KPW",
            "KRW",
            "KWD",
            "KGS",
            "LAK",
            "LBP",
            "LSL",
            "ZAR",
            "LRD",
            "LYD",
            "CHF",
            "MOP",
            "MKD",
            "MGA",
            "MWK",
            "MYR",
            "MVR",
            "MRU",
            "MUR",
            "XUA",
            "MXN",
            "MXV",
            "MDL",
            "MNT",
            "MAD",
            "MZN",
            "MMK",
            "NAD",
            "NPR",
            "NIO",
            "NGN",
            "OMR",
            "PKR",
            "PAB",
            "PGK",
            "PYG",
            "PEN",
            "PHP",
            "PLN",
            "QAR",
            "RON",
            "RUB",
            "RWF",
            "SHP",
            "WST",
            "STN",
            "SAR",
            "RSD",
            "SCR",
            "SLL",
            "SGD",
            "XSU",
            "SBD",
            "SOS",
            "SSP",
            "LKR",
            "SDG",
            "SRD",
            "SEK",
            "CHE",
            "CHW",
            "SYP",
            "TWD",
            "TJS",
            "TZS",
            "THB",
            "TOP",
            "TTD",
            "TND",
            "TRY",
            "TMT",
            "UGX",
            "UAH",
            "AED",
            "USN",
            "UYU",
            "UYI",
            "UYW",
            "UZS",
            "VUV",
            "VES",
            "VND",
            "YER",
            "ZMW",
            "ZWL"});
            this.cmbCurrency.Location = new System.Drawing.Point(175, 94);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(151, 28);
            this.cmbCurrency.TabIndex = 4;
            this.cmbCurrency.SelectionChangeCommitted += new System.EventHandler(this.cmbCurrency_SelectionChangeCommitted);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(252, 689);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(145, 20);
            this.lblVersion.TabIndex = 5;
            this.lblVersion.Text = "Version: {0}.{1}.{2}.{3}";
            // 
            // listBox1
            // 
            this.listBox1.Enabled = false;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Items.AddRange(new object[] {
            "Opus 2021",
            "*All rights reserved*",
            "Written by: Rechard Preston 33301212",
            "With the help of:",
            "Ofentse Mthembu 35624930",
            "Caitlin Botha 34669205",
            "Sarah Masu 32850123",
            "Zanele Mtimkulu 3055273"});
            this.listBox1.Location = new System.Drawing.Point(175, 505);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(332, 164);
            this.listBox1.TabIndex = 6;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.cmbCurrency);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.cmbTheme);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(550, 750);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTheme;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ListBox listBox1;
    }
}
