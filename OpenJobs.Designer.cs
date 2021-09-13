
namespace Opus_Proto_1
{
    partial class OpenJobs
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
            this.lblPaymentRate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.redtDesc = new System.Windows.Forms.RichTextBox();
            this.lblJobName = new System.Windows.Forms.Label();
            this.btnInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPaymentRate
            // 
            this.lblPaymentRate.AutoSize = true;
            this.lblPaymentRate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPaymentRate.Location = new System.Drawing.Point(184, 177);
            this.lblPaymentRate.Name = "lblPaymentRate";
            this.lblPaymentRate.Size = new System.Drawing.Size(65, 28);
            this.lblPaymentRate.TabIndex = 10;
            this.lblPaymentRate.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 28);
            this.label1.TabIndex = 9;
            this.label1.Text = "Payment Rate(p/h):";
            // 
            // redtDesc
            // 
            this.redtDesc.Location = new System.Drawing.Point(3, 44);
            this.redtDesc.Name = "redtDesc";
            this.redtDesc.ReadOnly = true;
            this.redtDesc.Size = new System.Drawing.Size(544, 120);
            this.redtDesc.TabIndex = 8;
            this.redtDesc.Text = "Painter need to paint living all paint and tools supplied.";
            // 
            // lblJobName
            // 
            this.lblJobName.AutoSize = true;
            this.lblJobName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblJobName.Location = new System.Drawing.Point(3, 0);
            this.lblJobName.Name = "lblJobName";
            this.lblJobName.Size = new System.Drawing.Size(118, 41);
            this.lblJobName.TabIndex = 7;
            this.lblJobName.Text = "Painter";
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(430, 198);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(117, 49);
            this.btnInfo.TabIndex = 13;
            this.btnInfo.Text = "Info";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // OpenJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.lblPaymentRate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.redtDesc);
            this.Controls.Add(this.lblJobName);
            this.Name = "OpenJobs";
            this.Size = new System.Drawing.Size(550, 250);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPaymentRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox redtDesc;
        private System.Windows.Forms.Label lblJobName;
        private System.Windows.Forms.Button btnInfo;
    }
}
