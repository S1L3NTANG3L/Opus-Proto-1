﻿using RatingControls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Opus_Proto_1
{
    public partial class AvailableJobs : UserControl
    {
        public int index = 0;        
        public delegate void RemoveAJEventHandler(object sender, AvailableJobsArgs e);
        public event RemoveAJEventHandler onRemoveAJ;
        public delegate void ApplyEventHandler(object sender, AvailableJobsArgs e);
        public event ApplyEventHandler onApply;
        private string jobCode;
        private StarRatingControl starRatingControl = new StarRatingControl();
        public AvailableJobs()
        {
            InitializeComponent();
            starRatingControl.Top = 215;
            starRatingControl.Left = 250;
            Controls.Add(starRatingControl);
            starRatingControl.Enabled = false;
            lblUsername.ForeColor = Color.Blue;
        }
        public void setJobName(string value)
        {
            lblJobName.Text = value;
        }
        public void setDescription(string value)
        {
            redtDesc.Text = value;
        }
        public void setUsername(string value)
        {
            lblUsername.Text = value;
        }
        public void setRating(int value)
        {
            starRatingControl.SelectedStar = value;
        }
        public void setApplyStatus(bool value)
        {
            if (!value)
            {
                btnApply.Visible = false;
            }
        }
        public void setPaymentRate(string value)
        {
            lblPaymentRate.Text = value;
        }
        private void lblUsername_Click(object sender, EventArgs e)
        {
            onRemoveAJ(this, new AvailableJobsArgs(index));
        }
        public void setBackColor(Color color)
        {
            this.BackColor = color;
        }
        public void setButtonColor(Color color)
        {
            btnApply.BackColor = color;
        }
        public string getUsername()
        {
            return lblUsername.Text;
        }
        public string getJobCode()
        {
            return jobCode;
        }
        public void setJobCode(string value)
        {
            jobCode = value;
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            onApply(this, new AvailableJobsArgs(index));
        }
    }
    public class AvailableJobsArgs : EventArgs
    {
        public int index;
        public AvailableJobsArgs(int value)
        {
            index = value;
        }
    }
}
