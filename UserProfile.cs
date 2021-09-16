using RatingControls;
using SoutiesSandbox;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Opus_Proto_1
{
    public partial class UserProfile : UserControl
    {
        CustomFunctions cf = new CustomFunctions();
        private StarRatingControl starRatingControl = new StarRatingControl();
        public delegate void RemoveUPEventHandler(object sender, UserProfileArgs e);
        public event RemoveUPEventHandler onRemoveUP;
        private string conn;
        public int index = 0;
        public UserProfile()
        {
            InitializeComponent();
            starRatingControl.Top = 125;
            starRatingControl.Left = 424;
            Controls.Add(starRatingControl);
            starRatingControl.Enabled = false;
            edtEmail.Visible = false;
            edtPhoneNumber.Visible = false;
            lblInvalidEmail.Visible = false;
            lblInvalidNumber.Visible = false;
            lblProfile.Visible = false;
            pbProfilePicture.Enabled = false;
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
        public void setConn(string value)
        {
            conn = value;
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
                this.btnEdit.BackColor = this.btnBack.BackColor = value;
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            onRemoveUP(this, new UserProfileArgs(index));
        }
        public void hideDetails()
        {
            lblEmail.Visible = false;
            lblPhone.Visible = false;
            label2.Visible = false;
            label4.Visible = false;
            btnEdit.Visible = false;
        }
        public void setEmail(string value)
        {
            edtEmail.Text = lblEmail.Text = value;
        }
        public void setNumber(string value)
        {
            edtPhoneNumber.Text = lblPhone.Text = value;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            lblInvalidEmail.Visible = false;
            lblInvalidNumber.Visible = false;
            if (btnEdit.Text == "Edit")
            {
                btnEdit.Text = "Save";
                edtEmail.Visible = true;
                edtPhoneNumber.Visible = true;
                lblProfile.Visible = true;
                pbProfilePicture.Enabled = true;
            }
            else
            {          
                if(!cf.EmailVerification(edtEmail.Text))
                {
                    lblInvalidEmail.Visible = true;
                }
                else if(edtPhoneNumber.Text.Length < 9)
                {
                    lblInvalidNumber.Visible = true;
                }
                else
                {
                    cf.NonQuerySQL("UPDATE user_details SET Email ='" + edtEmail.Text + "', Number = '" + edtPhoneNumber.Text + "'", conn);
                    lblEmail.Text = edtEmail.Text;
                    lblPhone.Text = edtPhoneNumber.Text;
                    btnEdit.Text = "Edit";
                    edtEmail.Visible = false;
                    edtPhoneNumber.Visible = false;
                    lblProfile.Visible = false;
                    pbProfilePicture.Enabled = false;
                }
                
            }
        }
        private void pbProfilePicture_Click(object sender, EventArgs e)
        {
            try
            {
                if (opnfdPicture.ShowDialog() == DialogResult.OK)
                {
                    opnfdPicture.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                    pbProfilePicture.Image = new Bitmap(opnfdPicture.FileName);
                    pbProfilePicture.Image.Save(Application.StartupPath+"\\Config\\DefaultPP.png",ImageFormat.Png);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to change picture.\n" + ex.Message,ex.ToString(),MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
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
