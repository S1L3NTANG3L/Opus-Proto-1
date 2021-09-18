using SoutiesSandbox;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Opus_Proto_1
{
    public partial class PastJobs : UserControl
    {
        public int index = 0;
        private CustomFunctions cF = new CustomFunctions();
        private string username;
        private string jobCode;
        private string conn;
        public PastJobs()
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
            //if statement here to return the other employee
        }
        public void setJobCode(string value)
        {
            jobCode = value;
        }
        public void setTotalPaymentPayment(string value)
        {
            lblTotalPay.Text = value;
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
            btnPrint.BackColor = value;
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
        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            //Print to pdf code
        }
    }
}
