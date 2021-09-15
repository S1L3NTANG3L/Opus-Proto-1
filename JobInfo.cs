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
    public partial class JobInfo : UserControl
    {
        public int index = 0;
        private string jobCode;
        public delegate void LoadOpenJobsEventHandler(object sender, JobInfoArgs e);
        public event LoadOpenJobsEventHandler LoadOpenJobs;
        public JobInfo(string JobCode)
        {
            InitializeComponent();
            jobCode = JobCode;
            //need to load applicant objects think this needs to be done on the main.cs
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LoadOpenJobs(this, new JobInfoArgs(index));
        }
        public void setBackColor(Color color)
        {
            BackColor = color;
        }
        public void setButtonColor(Color color)
        {
            btnBack.BackColor = color;
        }
        public void setJobName(string name)
        {
            lblJobName.Text = name;
        }
        public void setDesc(string desc)
        {
            redtDesc.Text = desc;
        }
    }
    public class JobInfoArgs : EventArgs
    {
        public int index;
        public JobInfoArgs(int value)
        {
            index = value;
        }
    }
}
