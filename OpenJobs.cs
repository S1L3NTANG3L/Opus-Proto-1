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
    public partial class OpenJobs : UserControl
    {
        public int index = 0;
        private string username;
        private string jobCode;
        public delegate void RemoveOJEventHandler(object sender, OpenJobsArgs e);
        public event RemoveOJEventHandler onRemoveOJ;
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
