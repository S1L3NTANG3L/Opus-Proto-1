using RatingControls;
using SoutiesSandbox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Opus_Proto_1
{
    public partial class Review : UserControl
    {
        CustomFunctions cf = new CustomFunctions();
        private StarRatingControl starRatingControl = new StarRatingControl();
        public int index = 0;
        public delegate void AddReviewEventHandler(object sender, ReviewArgs e);
        public event AddReviewEventHandler AddReview;
        private string conn;
        private string username;
        private string userBeingReviewed;
        public Review()
        {
            InitializeComponent();
            starRatingControl.Top = 27;
            starRatingControl.Left = 365;
            Controls.Add(starRatingControl);
            lblError.Visible = false;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            if (starRatingControl.SelectedStar < 0)
            {
                lblError.Visible = true;
            }
            else
            {
                cf.NonQuerySQL("INSERT INTO reviews VALUES('" + username + "'," + starRatingControl.SelectedStar + ",'" + redtReview.Text + "','" + userBeingReviewed + "')", conn);
                AddReview(this, new ReviewArgs(index));
            }            
        }
        public void setBackColor(Color color)
        {
            BackColor = color;
        }
        public void setButtonColor(Color color)
        {
            btnSubmit.BackColor = color;
        }
        public void setConn(string value)
        {
            conn = value;
        }
        public void setUsername(string value)
        {
            username = value;
        }
        public void setUserBeingReviewed(string value)
        {
            userBeingReviewed = value;
        }
    }
    public class ReviewArgs : EventArgs
    {
        public int index;
        public ReviewArgs(int value)
        {
            index = value;
        }
    }
}
