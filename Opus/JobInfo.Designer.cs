
namespace Opus_Proto_1
{
    partial class JobInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblJobName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.redtDesc = new System.Windows.Forms.RichTextBox();
            this.pnlApplicants = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCloseJob = new System.Windows.Forms.Button();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPayAmount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Job Name:";
            // 
            // lblJobName
            // 
            this.lblJobName.AutoSize = true;
            this.lblJobName.Location = new System.Drawing.Point(123, 22);
            this.lblJobName.Name = "lblJobName";
            this.lblJobName.Size = new System.Drawing.Size(79, 20);
            this.lblJobName.TabIndex = 1;
            this.lblJobName.Text = "Job Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Job Description:";
            // 
            // redtDesc
            // 
            this.redtDesc.Location = new System.Drawing.Point(14, 98);
            this.redtDesc.Name = "redtDesc";
            this.redtDesc.Size = new System.Drawing.Size(341, 120);
            this.redtDesc.TabIndex = 3;
            this.redtDesc.Text = "";
            // 
            // pnlApplicants
            // 
            this.pnlApplicants.AutoScroll = true;
            this.pnlApplicants.Location = new System.Drawing.Point(14, 281);
            this.pnlApplicants.Name = "pnlApplicants";
            this.pnlApplicants.Size = new System.Drawing.Size(577, 357);
            this.pnlApplicants.TabIndex = 4;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(14, 659);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(140, 44);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Applicants:";
            // 
            // btnCloseJob
            // 
            this.btnCloseJob.Location = new System.Drawing.Point(451, 659);
            this.btnCloseJob.Name = "btnCloseJob";
            this.btnCloseJob.Size = new System.Drawing.Size(140, 44);
            this.btnCloseJob.TabIndex = 7;
            this.btnCloseJob.Text = "Close Job";
            this.btnCloseJob.UseVisualStyleBackColor = true;
            this.btnCloseJob.Click += new System.EventHandler(this.btnCloseJob_Click);
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Location = new System.Drawing.Point(14, 258);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(50, 20);
            this.lblEmployeeName.TabIndex = 8;
            this.lblEmployeeName.Text = "label4";
            this.lblEmployeeName.Click += new System.EventHandler(this.lblEmployeeName_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(305, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Total Pay Amount:";
            // 
            // lblPayAmount
            // 
            this.lblPayAmount.AutoSize = true;
            this.lblPayAmount.Location = new System.Drawing.Point(439, 258);
            this.lblPayAmount.Name = "lblPayAmount";
            this.lblPayAmount.Size = new System.Drawing.Size(50, 20);
            this.lblPayAmount.TabIndex = 10;
            this.lblPayAmount.Text = "label5";
            // 
            // JobInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPayAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblEmployeeName);
            this.Controls.Add(this.btnCloseJob);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.pnlApplicants);
            this.Controls.Add(this.redtDesc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblJobName);
            this.Controls.Add(this.label1);
            this.Name = "JobInfo";
            this.Size = new System.Drawing.Size(600, 720);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblJobName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox redtDesc;
        private System.Windows.Forms.Panel pnlApplicants;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCloseJob;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPayAmount;
    }
}
