
namespace Opus_Proto_1
{
    partial class AvailableJobs
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
            this.lblJobName = new System.Windows.Forms.Label();
            this.redtDesc = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPaymentRate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.pbRating = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblJobName
            // 
            this.lblJobName.AutoSize = true;
            this.lblJobName.Location = new System.Drawing.Point(3, 9);
            this.lblJobName.Name = "lblJobName";
            this.lblJobName.Size = new System.Drawing.Size(54, 20);
            this.lblJobName.TabIndex = 0;
            this.lblJobName.Text = "Painter";
            // 
            // redtDesc
            // 
            this.redtDesc.Location = new System.Drawing.Point(3, 32);
            this.redtDesc.Name = "redtDesc";
            this.redtDesc.ReadOnly = true;
            this.redtDesc.Size = new System.Drawing.Size(447, 120);
            this.redtDesc.TabIndex = 1;
            this.redtDesc.Text = "Painter need to paint living all paint and tools supplied.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Payment Rate(p/h):";
            // 
            // lblPaymentRate
            // 
            this.lblPaymentRate.AutoSize = true;
            this.lblPaymentRate.Location = new System.Drawing.Point(144, 155);
            this.lblPaymentRate.Name = "lblPaymentRate";
            this.lblPaymentRate.Size = new System.Drawing.Size(50, 20);
            this.lblPaymentRate.TabIndex = 3;
            this.lblPaymentRate.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Posted by:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(88, 186);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(50, 20);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "label3";
            this.lblUsername.Click += new System.EventHandler(this.lblUsername_Click);
            // 
            // pbRating
            // 
            this.pbRating.Location = new System.Drawing.Point(236, 177);
            this.pbRating.Name = "pbRating";
            this.pbRating.Size = new System.Drawing.Size(125, 29);
            this.pbRating.Step = 1;
            this.pbRating.TabIndex = 6;
            // 
            // AvailableJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(130)))), ((int)(((byte)(182)))));
            this.Controls.Add(this.pbRating);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPaymentRate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.redtDesc);
            this.Controls.Add(this.lblJobName);
            this.Name = "AvailableJobs";
            this.Size = new System.Drawing.Size(463, 239);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJobName;
        private System.Windows.Forms.RichTextBox redtDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPaymentRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.ProgressBar pbRating;
    }
}
