
namespace Opus_Proto_1
{
    partial class PastJobs
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblPaymentRate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.redtDesc = new System.Windows.Forms.RichTextBox();
            this.lblJobName = new System.Windows.Forms.Label();
            this.lblEmp = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalPay = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(433, 210);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(117, 49);
            this.btnPrint.TabIndex = 18;
            this.btnPrint.Text = "Print Info";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblPaymentRate
            // 
            this.lblPaymentRate.AutoSize = true;
            this.lblPaymentRate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPaymentRate.Location = new System.Drawing.Point(187, 180);
            this.lblPaymentRate.Name = "lblPaymentRate";
            this.lblPaymentRate.Size = new System.Drawing.Size(65, 28);
            this.lblPaymentRate.TabIndex = 17;
            this.lblPaymentRate.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 28);
            this.label1.TabIndex = 16;
            this.label1.Text = "Payment Rate(p/h):";
            // 
            // redtDesc
            // 
            this.redtDesc.Location = new System.Drawing.Point(6, 47);
            this.redtDesc.Name = "redtDesc";
            this.redtDesc.ReadOnly = true;
            this.redtDesc.Size = new System.Drawing.Size(544, 120);
            this.redtDesc.TabIndex = 15;
            this.redtDesc.Text = "Painter need to paint living all paint and tools supplied.";
            // 
            // lblJobName
            // 
            this.lblJobName.AutoSize = true;
            this.lblJobName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblJobName.Location = new System.Drawing.Point(3, 3);
            this.lblJobName.Name = "lblJobName";
            this.lblJobName.Size = new System.Drawing.Size(118, 41);
            this.lblJobName.TabIndex = 14;
            this.lblJobName.Text = "Painter";
            // 
            // lblEmp
            // 
            this.lblEmp.AutoSize = true;
            this.lblEmp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEmp.Location = new System.Drawing.Point(205, 217);
            this.lblEmp.Name = "lblEmp";
            this.lblEmp.Size = new System.Drawing.Size(65, 28);
            this.lblEmp.TabIndex = 20;
            this.lblEmp.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(6, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 28);
            this.label3.TabIndex = 19;
            this.label3.Text = "Employee/Employer:";
            // 
            // lblTotalPay
            // 
            this.lblTotalPay.AutoSize = true;
            this.lblTotalPay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotalPay.Location = new System.Drawing.Point(386, 180);
            this.lblTotalPay.Name = "lblTotalPay";
            this.lblTotalPay.Size = new System.Drawing.Size(65, 28);
            this.lblTotalPay.TabIndex = 22;
            this.lblTotalPay.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(287, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 28);
            this.label4.TabIndex = 21;
            this.label4.Text = "Total Pay:\r\n";
            // 
            // PastJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTotalPay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblEmp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblPaymentRate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.redtDesc);
            this.Controls.Add(this.lblJobName);
            this.Name = "PastJobs";
            this.Size = new System.Drawing.Size(557, 278);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblPaymentRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox redtDesc;
        private System.Windows.Forms.Label lblJobName;
        private System.Windows.Forms.Label lblEmp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalPay;
        private System.Windows.Forms.Label label4;
    }
}
