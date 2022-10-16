
namespace Opus_Proto_1
{
    partial class PastJobsSuper
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlPJS = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(3, 648);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(129, 45);
            this.btnBack.TabIndex = 17;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(1081, 648);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(117, 45);
            this.btnNext.TabIndex = 16;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(934, 648);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(129, 45);
            this.btnPrevious.TabIndex = 15;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(788, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 14;
            // 
            // pnlPJS
            // 
            this.pnlPJS.AutoScroll = true;
            this.pnlPJS.Location = new System.Drawing.Point(0, 8);
            this.pnlPJS.Name = "pnlPJS";
            this.pnlPJS.Size = new System.Drawing.Size(1200, 634);
            this.pnlPJS.TabIndex = 13;
            // 
            // PastJobsSuper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlPJS);
            this.Name = "PastJobsSuper";
            this.Size = new System.Drawing.Size(1200, 700);
            this.Load += new System.EventHandler(this.PastJobsSuper_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlPJS;
    }
}
