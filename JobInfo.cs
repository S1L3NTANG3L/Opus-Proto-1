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
        public JobInfo()
        {
            InitializeComponent();
            //need to load applicant objects think this needs to be done on the main.cs
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //Event Arguement that takes you back to open jobs
        }
        public string JobName
        {
            set { lblJobName.Text = value; }
        }
        public string JobDesc
        {
            set { redtDesc.Text = value; }
        }
    }
}
