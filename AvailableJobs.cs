﻿using System;
using System.Drawing;
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
        public void SetPaymentRate(string value)
        {
            lblPaymentRate.Text = value;
        }
        private void lblUsername_Click(object sender, EventArgs e)
        {
            //Show user profile
        }
        public void setBackColor(Color color)
        {
            this.BackColor = color;
        }
    }
}
