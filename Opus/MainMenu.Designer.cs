
namespace Opus_Proto_1
{
    partial class MainMenu
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
            this.pbProfile = new System.Windows.Forms.PictureBox();
            this.pbOpenJobs = new System.Windows.Forms.PictureBox();
            this.pbAvailableJobs = new System.Windows.Forms.PictureBox();
            this.pbPastJobs = new System.Windows.Forms.PictureBox();
            this.pbSettings = new System.Windows.Forms.PictureBox();
            this.pbLogout = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOpenJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvailableJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPastJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogout)).BeginInit();
            this.SuspendLayout();
            // 
            // pbProfile
            // 
            this.pbProfile.Location = new System.Drawing.Point(25, 25);
            this.pbProfile.Name = "pbProfile";
            this.pbProfile.Size = new System.Drawing.Size(200, 200);
            this.pbProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProfile.TabIndex = 0;
            this.pbProfile.TabStop = false;
            this.pbProfile.Click += new System.EventHandler(this.pbProfile_Click);
            // 
            // pbOpenJobs
            // 
            this.pbOpenJobs.Location = new System.Drawing.Point(275, 25);
            this.pbOpenJobs.Name = "pbOpenJobs";
            this.pbOpenJobs.Size = new System.Drawing.Size(200, 200);
            this.pbOpenJobs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOpenJobs.TabIndex = 1;
            this.pbOpenJobs.TabStop = false;
            this.pbOpenJobs.Click += new System.EventHandler(this.pbOpenJobs_Click);
            // 
            // pbAvailableJobs
            // 
            this.pbAvailableJobs.Location = new System.Drawing.Point(25, 275);
            this.pbAvailableJobs.Name = "pbAvailableJobs";
            this.pbAvailableJobs.Size = new System.Drawing.Size(200, 200);
            this.pbAvailableJobs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAvailableJobs.TabIndex = 2;
            this.pbAvailableJobs.TabStop = false;
            this.pbAvailableJobs.Click += new System.EventHandler(this.pbAvailableJobs_Click);
            // 
            // pbPastJobs
            // 
            this.pbPastJobs.Location = new System.Drawing.Point(275, 275);
            this.pbPastJobs.Name = "pbPastJobs";
            this.pbPastJobs.Size = new System.Drawing.Size(200, 200);
            this.pbPastJobs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPastJobs.TabIndex = 3;
            this.pbPastJobs.TabStop = false;
            this.pbPastJobs.Click += new System.EventHandler(this.pbPastJobs_Click);
            // 
            // pbSettings
            // 
            this.pbSettings.Location = new System.Drawing.Point(25, 525);
            this.pbSettings.Name = "pbSettings";
            this.pbSettings.Size = new System.Drawing.Size(200, 200);
            this.pbSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSettings.TabIndex = 4;
            this.pbSettings.TabStop = false;
            this.pbSettings.Click += new System.EventHandler(this.pbSettings_Click);
            // 
            // pbLogout
            // 
            this.pbLogout.Location = new System.Drawing.Point(275, 525);
            this.pbLogout.Name = "pbLogout";
            this.pbLogout.Size = new System.Drawing.Size(200, 200);
            this.pbLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogout.TabIndex = 5;
            this.pbLogout.TabStop = false;
            this.pbLogout.Click += new System.EventHandler(this.pbLogout_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbLogout);
            this.Controls.Add(this.pbSettings);
            this.Controls.Add(this.pbPastJobs);
            this.Controls.Add(this.pbAvailableJobs);
            this.Controls.Add(this.pbOpenJobs);
            this.Controls.Add(this.pbProfile);
            this.Name = "MainMenu";
            this.Size = new System.Drawing.Size(500, 786);
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOpenJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvailableJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPastJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbProfile;
        private System.Windows.Forms.PictureBox pbOpenJobs;
        private System.Windows.Forms.PictureBox pbAvailableJobs;
        private System.Windows.Forms.PictureBox pbPastJobs;
        private System.Windows.Forms.PictureBox pbSettings;
        private System.Windows.Forms.PictureBox pbLogout;
    }
}
