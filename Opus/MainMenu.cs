using System;
using System.Drawing;
using System.Windows.Forms;

namespace Opus_Proto_1
{
    public partial class MainMenu : UserControl
    {
        public int index = 0;
        public delegate void RemoveMMEventHandler(Object sender, MainMenuArgs e);
        public event RemoveMMEventHandler onRemoveSite;
        public MainMenu()
        {
            InitializeComponent();
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {
            pbProfile.ImageLocation = Application.StartupPath + "\\Config\\Profile.png";
            pbAvailableJobs.ImageLocation = Application.StartupPath + "\\Config\\AvailableJobs.png";
            pbLogout.ImageLocation = Application.StartupPath + "\\Config\\LogOut.png";
            pbOpenJobs.ImageLocation = Application.StartupPath + "\\Config\\OpenJobs.png";
            pbPastJobs.ImageLocation = Application.StartupPath + "\\Config\\PastJobs.png";
            pbSettings.ImageLocation = Application.StartupPath + "\\Config\\Settings.png";
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.pbProfile, "Profile");
            toolTip1.SetToolTip(this.pbOpenJobs, "Open Jobs");
            toolTip1.SetToolTip(this.pbAvailableJobs, "Available Jobs");
            toolTip1.SetToolTip(this.pbPastJobs, "Past Jobs");
            toolTip1.SetToolTip(this.pbSettings, "Settings");
            toolTip1.SetToolTip(this.pbLogout, "Log Out");
        }
        private void pbProfile_Click(object sender, EventArgs e)
        {
            index = 1;
            onRemoveSite(this, new MainMenuArgs(index));
        }
        private void pbOpenJobs_Click(object sender, EventArgs e)
        {
            index = 2;
            onRemoveSite(this, new MainMenuArgs(index));
        }
        private void pbAvailableJobs_Click(object sender, EventArgs e)
        {
            index = 3;
            onRemoveSite(this, new MainMenuArgs(index));
        }
        private void pbPastJobs_Click(object sender, EventArgs e)
        {
            index = 4;
            onRemoveSite(this, new MainMenuArgs(index));
        }
        private void pbSettings_Click(object sender, EventArgs e)
        {
            index = 5;
            onRemoveSite(this, new MainMenuArgs(index));
        }
        private void pbLogout_Click(object sender, EventArgs e)
        {
            index = 6;
            onRemoveSite(this, new MainMenuArgs(index));
        }
        public void setBackColor(Color color)
        {
            BackColor = color;
        }
    }
    public class MainMenuArgs : EventArgs
    {
        public int index;
        public MainMenuArgs(int value)
        {
            index = value;
        }
    }
}
