
namespace Opus_Proto_1
{
    partial class AvailableJobsSuper
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
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlAJSMain = new System.Windows.Forms.Panel();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblJobCat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(933, 757);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(129, 45);
            this.btnPrevious.TabIndex = 2;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(1080, 757);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(117, 45);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(3, 757);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(129, 45);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pnlAJSMain
            // 
            this.pnlAJSMain.AutoScroll = true;
            this.pnlAJSMain.Location = new System.Drawing.Point(0, 40);
            this.pnlAJSMain.Name = "pnlAJSMain";
            this.pnlAJSMain.Size = new System.Drawing.Size(1200, 711);
            this.pnlAJSMain.TabIndex = 5;
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(890, 6);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(304, 28);
            this.cmbCategory.TabIndex = 6;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // lblJobCat
            // 
            this.lblJobCat.AutoSize = true;
            this.lblJobCat.Location = new System.Drawing.Point(785, 9);
            this.lblJobCat.Name = "lblJobCat";
            this.lblJobCat.Size = new System.Drawing.Size(99, 20);
            this.lblJobCat.TabIndex = 9;
            this.lblJobCat.Text = "Job Category:";
            // 
            // AvailableJobsSuper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.lblJobCat);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.pnlAJSMain);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Name = "AvailableJobsSuper";
            this.Size = new System.Drawing.Size(1200, 805);
            this.Load += new System.EventHandler(this.AvailableJobsSuper_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel pnlAJSMain;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblJobCat;
    }
}
