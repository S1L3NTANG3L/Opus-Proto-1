
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
            this.label2.Location = new System.Drawing.Point(14, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Job Description:";
            // 
            // redtDesc
            // 
            this.redtDesc.Location = new System.Drawing.Point(14, 106);
            this.redtDesc.Name = "redtDesc";
            this.redtDesc.Size = new System.Drawing.Size(341, 120);
            this.redtDesc.TabIndex = 3;
            this.redtDesc.Text = "";
            // 
            // pnlApplicants
            // 
            this.pnlApplicants.Location = new System.Drawing.Point(14, 244);
            this.pnlApplicants.Name = "pnlApplicants";
            this.pnlApplicants.Size = new System.Drawing.Size(577, 394);
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
            // JobInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.pnlApplicants);
            this.Controls.Add(this.redtDesc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblJobName);
            this.Controls.Add(this.label1);
            this.Name = "JobInfo";
            this.Size = new System.Drawing.Size(604, 720);
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
    }
}
