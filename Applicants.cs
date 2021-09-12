using RatingControls;
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
    public partial class Applicants : UserControl
    {
        private StarRatingControl starRatingControl = new StarRatingControl();
        //Need an event arguement for username click
        public Applicants()
        {
            InitializeComponent();
            starRatingControl.Top = 32;
            starRatingControl.Left = 208;
            Controls.Add(starRatingControl);
            starRatingControl.Enabled = false;
        }
        public string username
        {
            set { lblUsername.Text = value; }
        }
        public void setButtonColor(Color color)
        {
            btnAccept.BackColor = color;
        }
        public void setBackColor(Color color)
        {
            this.BackColor = color;
        }
        private void lblUsername_DoubleClick(object sender, EventArgs e)
        {
            //Event arguement needs to hide JobInfo and open UserProfile
        }
        public int rating
        {
            set { starRatingControl.SelectedStar = value; }
        }
    }
}
