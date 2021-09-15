using RatingControls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Opus_Proto_1
{
    public partial class UserProfile : UserControl
    {
        private StarRatingControl starRatingControl = new StarRatingControl();
        public delegate void RemoveUPEventHandler(object sender, UserProfileArgs e);
        public event RemoveUPEventHandler onRemoveUP;
        public int index = 0;
        public UserProfile()
        {
            InitializeComponent();
            starRatingControl.Top = 125;
            starRatingControl.Left = 424;
            Controls.Add(starRatingControl);
            starRatingControl.Enabled = false;
        }
        public void disableBackButton()
        {
            btnBack.Visible = false;
            btnBack.Enabled = false;
        }
        public void setDefualtProfilePicture()
        {
            pbProfilePicture.ImageLocation = Application.StartupPath + "\\Config\\DefaultPP.png";
            pbProfilePicture.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        public Image profilePicture
        {
            set
            {
                pbProfilePicture.Image = value;
            }
        }
        public string username
        {
            set
            {
                lblUsername.Text = value;
            }
        }
        public string dateJoined
        {
            set
            {
                lblDateJoined.Text = value;
            }
        }
        public int rating
        {
            set
            {
                starRatingControl.SelectedStar = value;
            }
        }
        public void addReview(string value)
        {
            lstbReviews.Items.Add(value);
        }
        public Color backColor
        {
            set
            {
                this.BackColor = value;
            }
        }
        public Color buttonColor
        {
            set
            {
                this.btnBack.BackColor = value;
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            onRemoveUP(this, new UserProfileArgs(index));
        }
    }
    public class UserProfileArgs : EventArgs
    {
        public int index;
        public UserProfileArgs(int value)
        {
            index = value;
        }
    }
}
