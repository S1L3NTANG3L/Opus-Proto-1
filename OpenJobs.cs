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
        public void setPayRate(string value)
        {
            lblPaymentRate.Text = value;
        }
    }
}
