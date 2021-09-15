using SoutiesSandbox;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Opus_Proto_1
{
    public partial class CreateJob : UserControl
    {
        public int index = 0;
        CustomFunctions cF = new CustomFunctions();
        public delegate void CreateJobEventHandler(object sender, CreateJobArgs e);
        public event CreateJobEventHandler createJob;
        private string username;
        private string conn;
        public CreateJob()
        {
            InitializeComponent();
        }
        private void btnCreateJob_Click(object sender, EventArgs e)
        {
            //Verification and insert code
            createJob(this, new CreateJobArgs(index));
        }
        public void setBackColor(Color color)
        {
            this.BackColor = color;
        }
        public void setButtonColor(Color color)
        {
            btnCreateJob.BackColor = color;
        }
        public void setUsername(string value)
        {
            username = value;
        }
        public void setConn(string value)
        {
            conn = value;
        }
    }
    public class CreateJobArgs : EventArgs
    {
        public int index;
        public CreateJobArgs(int value)
        {
            index = value;
        }
    }
}
