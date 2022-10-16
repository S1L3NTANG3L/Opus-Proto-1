using RatingControls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Opus_Proto_1
{
    public partial class Applicants : UserControl
    {
        public int index = 0;
        public delegate void LoadUserProfileEventHandler(object sender, ApplicantsArgs e);
        public event LoadUserProfileEventHandler LoadUserProfile;
        public delegate void HireApplicantEventHandler(object sender, ApplicantsArgs e);
        public event HireApplicantEventHandler HireApplicant;
        private StarRatingControl starRatingControl = new StarRatingControl();
        private string username;
        public Applicants()
        {
            InitializeComponent();
            starRatingControl.Top = 32;
            starRatingControl.Left = 208;
            Controls.Add(starRatingControl);
            starRatingControl.Enabled = false;
        }
        public void setButtonColor(Color color)
        {
            btnAccept.BackColor = color;
        }
        public void setUsername(string value)
        {
            username = value;
        }
        public string getUsername()
        {
            return username;
        }
        public void setBackColor(Color color)
        {
            this.BackColor = color;
        }
        private void lblUsername_DoubleClick(object sender, EventArgs e)
        {
            LoadUserProfile(this, new ApplicantsArgs(index));
        }
        public int rating
        {
            set { starRatingControl.SelectedStar = value; }
        }
        private void btnAccept_Click(object sender, EventArgs e)
        {
            HireApplicant(this, new ApplicantsArgs(index));
        }
    }
    public class ApplicantsArgs : EventArgs
    {
        public int index;
        public ApplicantsArgs(int value)
        {
            index = value;
        }
    }
}
