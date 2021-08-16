using MaterialSkin.Controls;
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
    public partial class AvailableJobs : UserControl
    {
        public int index = 0;
        public AvailableJobs()
        {
            InitializeComponent();
        }
        public void SetJobName(string value)
        {
            lblJobName.Text = value;
        }
        public void SetDescription(string value)
        {
            redtDesc.Text = value;
        }
        public void SetUsername(string value)
        {
            lblUsername.Text = value;
        }
        public void SetRating(int value)
        {
            pbRating.Value = value;
        }
        public void SetPaymentRate(int value)
        {
            lblPaymentRate.Text = value.ToString();
        }
        private void lblUsername_Click(object sender, EventArgs e)
        {
            //Show user profile
        }
    }
}
