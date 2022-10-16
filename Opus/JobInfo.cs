using System;
using System.Drawing;
using System.Windows.Forms;
using SoutiesSandbox;

namespace Opus_Proto_1
{
    public partial class JobInfo : UserControl
    {
        public int index = 0;
        public delegate void LoadOpenJobsEventHandler(object sender, JobInfoArgs e);
        public event LoadOpenJobsEventHandler LoadOpenJobs;
        public delegate void LoadApplicantUPEventHandler(object sender, JobInfoArgs e);
        public event LoadApplicantUPEventHandler LoadApplicantUP;
        private string jobCode;
        private string conn;
        private Color backColor;
        private Color buttonColor;
        private CustomFunctions cF = new CustomFunctions();
        private int SPACERY = 10;
        private string username;
        private string currencyCode;
        public JobInfo(string JobCode)
        {
            InitializeComponent();
            jobCode = JobCode;
            lblEmployeeName.Visible = false;
            btnCloseJob.Visible = false;
            label4.Visible = false;
            lblPayAmount.Visible = false;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            LoadOpenJobs(this, new JobInfoArgs(index));
        }
        public void setBackColor(Color color)
        {
            BackColor = backColor = color;
        }
        public void setButtonColor(Color color)
        {
            btnBack.BackColor = buttonColor = color;
        }
        public void setJobName(string name)
        {
            lblJobName.Text = name;
        }
        public void setDesc(string desc)
        {
            redtDesc.Text = desc;
        }
        public void setConn(string value)
        {
            conn = value;
        }
        public void loadApplicants()
        {
            string[] arrUsers = cF.GetStringArraySQL("SELECT Employee_Code FROM applications WHERE Job_Code = '" + jobCode + "'", conn);
            if(arrUsers.Length != 0)
            {
                for (int i = 0; i < arrUsers.Length; i++)
                {
                    Applicants availableApplicant = new Applicants();
                    availableApplicant.HireApplicant += new Applicants.HireApplicantEventHandler(HireApplicant_Click);
                    availableApplicant.LoadUserProfile += new Applicants.LoadUserProfileEventHandler(ShowUserProfile_Click);
                    Applicants previousApplicant;
                    pnlApplicants.Controls.Add(availableApplicant);
                    if (pnlApplicants.Controls.Count < 2)
                    {
                        availableApplicant.Location = new Point(0, 0);
                    }
                    else
                    {
                        previousApplicant = (Applicants)pnlApplicants.Controls[pnlApplicants.Controls.Count - 2];
                        availableApplicant.Location = new Point(0, previousApplicant.Location.Y + previousApplicant.Height + SPACERY);
                    }
                    availableApplicant.setBackColor(backColor);
                    availableApplicant.setButtonColor(buttonColor);
                    availableApplicant.setUsername(arrUsers[i]);
                    availableApplicant.rating = loadRating(arrUsers[i]);
                }
            }                
        }
        private void HireApplicant_Click(Object sender, ApplicantsArgs e)
        {
            Applicants applicants = (Applicants)sender;
            string user = applicants.getUsername();
            cF.NonQuerySQL("UPDATE job_details SET Employee_Code = '" + user + "', In_Progress = 1 WHERE Jobe_Code = '" + jobCode + "'",conn);
            cF.NonQuerySQL("DELETE FROM applicants WHERE Job_Code = '" + jobCode + "'", conn);
            LoadOpenJobs(this, new JobInfoArgs(index));
        }
        private int loadRating(string rUsename)
        {
            int rating = 0;
            string[] arrRatings = cF.GetStringArraySQL("SELECT Rating FROM reviews WHERE User_Reviewed_Code ='" + rUsename + "'", conn);
            if (arrRatings.Length == 0)
            {
                return 0;
            }
            else
            {
                for (int i = 0; i < arrRatings.Length; i++)
                {
                    rating += int.Parse(arrRatings[i]);
                }
                rating = rating / arrRatings.Length;
                return rating;
            }

        }
        private void ShowUserProfile_Click(Object sender, ApplicantsArgs e)
        {
            Applicants applicants = (Applicants)sender;
            username = applicants.getUsername();
            LoadApplicantUP(this, new JobInfoArgs(index));
        }
        public string getUsername()
        {
            return username;
        }
        public string getJobCode()
        {
            return jobCode;
        }
        public bool showCorrect()
        {
            int InProgress = cF.GetSingleIntegerSQL("SELECT In_Progress FROM job_details WHERE Job_Code = '" + jobCode + "'", conn);
            if (InProgress == 1)
            {
                pnlApplicants.Visible = false;
                lblEmployeeName.Visible = true;
                btnCloseJob.Visible = true;
                lblEmployeeName.Text = cF.GetSingleStringSQL("SELECT Employee_Code FROM job_details WHERE Job_Code = '" + jobCode + "'", conn);
                return true;                
            }
            else if(InProgress ==  0)            
            {                
                return false;
            }
            else
            {
                pnlApplicants.Visible = false;
                lblEmployeeName.Visible = true;                
                lblEmployeeName.Text = cF.GetSingleStringSQL("SELECT Employee_Code FROM job_details WHERE Job_Code = '" + jobCode + "'", conn);
                lblPayAmount.Visible = true;
                label4.Visible = true;
                lblPayAmount.Text = lblPayAmount.Text = ((decimal)cF.GetSingleIntegerSQL("SELECT Payment_Amount_w_Rev FROM job_details WHERE Job_Code = '" + jobCode + "'", conn)).FormatCurrency(currencyCode);
                return true;
            }

        }
        private void lblEmployeeName_Click(object sender, EventArgs e)
        {            
            username = lblEmployeeName.Text;
            LoadApplicantUP(this, new JobInfoArgs(index));
        }
        private void btnCloseJob_Click(object sender, EventArgs e)
        {
            string temp = Microsoft.VisualBasic.Interaction.InputBox("Please enter the amount of hours the job took:", "Enter Hours", "1");
            int hours = 0;
            if(!int.TryParse(temp, out hours))
            {
                MessageBox.Show("Incorrect input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                label4.Visible = true;
                lblPayAmount.Visible = true;
                int payAmount = cF.GetSingleIntegerSQL("SELECT Pay_Amount FROM available_jobs WHERE Job_Code = '" + jobCode + "'", conn);
                int total = payAmount * hours;
                float totalwRev = total * (float)1.03;
                float rev = totalwRev - total;
                lblPayAmount.Text = ((decimal)totalwRev).FormatCurrency(currencyCode);
                cF.NonQuerySQL("UPDATE job_details SET In_Progress = 2, Payment_Amount_w_Rev = '" + totalwRev + "', Total_work_time = '" + hours + "'", conn);
                cF.NonQuerySQL("INSERT INTO past_jobs VALUES(SELECT * FROM available_Jobs WHERE Job_Code = '" + jobCode + "')",conn);
                cF.NonQuerySQL("DELETE FROM available_jobs WHERE Job_Code = '" + jobCode + "'", conn);
                cF.NonQuerySQL("INSERT INTO revenue_ledger VALUES('" + jobCode + "','" + rev + "')", conn);
                btnCloseJob.Visible = false;
            }
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
