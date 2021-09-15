using SoutiesSandbox;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Opus_Proto_1
{
    public partial class OpenJobs : UserControl
    {
        CustomFunctions cF = new CustomFunctions();
        public int index = 0;
        private string username;
        private string jobCode;
        private string conn;
        public delegate void RemoveOJEventHandler(object sender, OpenJobsArgs e);
        public event RemoveOJEventHandler onRemoveOJ;
        public delegate void JobDeleteEventHandler(object sender, OpenJobsArgs e);
        public event JobDeleteEventHandler JobDeleted;
        public OpenJobs()
        {
            InitializeComponent();
        }
        public void setDesc(string value)
        {
            redtDesc.Text = value;
        }
        public void setJobName(string value)
        {
            lblJobName.Text = value;
        }
        public void setUsername(string value)
        {
            username = value;
        }
        public void setJobCode(string value)
        {
            jobCode = value;
        }
        public void setPaymentRate(string value)
        {
            lblPaymentRate.Text = value;
        }
        public void setBackColor(Color value)
        {
            this.BackColor = value;
        }
        public void setButtonColor(Color value)
        {
            btnInfo.BackColor = value;
            btnRemove.BackColor = value;
        }
        public void setConn(string value)
        {
            conn = value;
        }
        public string getUsername()
        {
            return username;
        }
        public string getJobCode()
        {
            return jobCode;
        }
        private void btnInfo_Click(object sender, EventArgs e)
        {
            onRemoveOJ(this, new OpenJobsArgs(index));
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the job?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                cF.NonQuerySQL("DELETE FROM job_details WHERE Job_Code = '" + jobCode + "'", conn);
                cF.NonQuerySQL("DELETE FROM available_jobs WHERE Job_Code = '" + jobCode + "'", conn);
                JobDeleted(this, new OpenJobsArgs(index));
            }
        }
    }
    public class OpenJobsArgs : EventArgs
    {
        public int index;
        public OpenJobsArgs(int value)
        {
            index = value;
        }
    }
}
