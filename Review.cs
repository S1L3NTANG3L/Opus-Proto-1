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
        //Need retunr code
        private string conn;
        private string username;
        private string userBeingReviewed;
        public Review()
        {
            InitializeComponent();
            starRatingControl.Top = 27;
            starRatingControl.Left = 327;
            Controls.Add(starRatingControl);
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //sql here
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
}
