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
            frmMain Main = (frmMain)this.Parent;
            //Add back color code
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {
            pbProfile.ImageLocation = Application.StartupPath + "\\Profile.png";
            pbAvailableJobs.ImageLocation = Application.StartupPath + "\\AvailableJobs.png";
            pbLogout.ImageLocation = Application.StartupPath + "\\LogOut.png";
            pbOpenJobs.ImageLocation = Application.StartupPath + "\\OpenJobs.png";
            pbPastJobs.ImageLocation = Application.StartupPath + "\\PastJobs.png";
            pbSettings.ImageLocation = Application.StartupPath + "\\Settings.png";
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
