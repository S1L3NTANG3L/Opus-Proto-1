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
            lblError.Visible = false;
        }
        private void btnCreateJob_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            if (edtCity.Text == "" || edtJobName.Text == "" || edtState.Text == "" || edtZip.Text == "" ||
                redtAddress.Text == "" || redtJobDesc.Text == "" || cmbCategory.SelectedIndex == -1)
            {
                lblError.Visible = true;
            }
            else
            {
                string uuid = cF.UUIDGenerator();
                cF.NonQuerySQL("INSERT INTO job_details VALUES('" + uuid + "','" + edtJobName.Text + "',"
                    + "'" + cF.GetSingleStringSQL("SELECT Job_Type_Code FROM job_types WHERE Job_Name = '" + cmbCategory.SelectedText + "'", conn) + ""
                    + "',NULL,'" + username + "','" + redtAddress.Text + "','" + edtCity.Text + "','" + edtState.Text + "',"
                    + "'" + edtZip.Text + "','0','0','0')", conn);
                cF.NonQuerySQL("INSERT INTO available_jobs VALUES('" + uuid + "','" + redtJobDesc.Text + "'," + nudPay.Value + ")", conn);
                createJob(this, new CreateJobArgs(index));
            }            
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
        public void fillComboBox()
        {
            cmbCategory.Items.AddRange(cF.GetStringArraySQL("SELECT Job_Name FROM job_types",conn));
        }
        private void cmbCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            nudPay.Minimum = nudPay.Value = cF.GetSingleIntegerSQL("SELECT Job_Min_Pay_Amount FROM job_types WHERE Job_Name = '" + cmbCategory.SelectedText + "'", conn);
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
