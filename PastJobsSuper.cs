using MySql.Data.MySqlClient;
using SoutiesSandbox;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Opus_Proto_1
{
    public partial class PastJobsSuper : UserControl
    {
        public delegate void RemovePJSEventHandler(object sender, PastJobsSuperArgs e);
        public event RemovePJSEventHandler onRemovePJS;
        public int index = 0;
        private Color themeButtonColor;
        private const int SPACERY = 10;
        private const int SPACERX = 75;
        private int totalPageCount;
        private int pageNumber = 1;
        private string conn = "";
        private string currencyCode;
        private string username;
        private List<Jobs> lstJobs = new List<Jobs>();
        private CustomFunctions cF = new CustomFunctions();
        private Color backColor;
        public PastJobsSuper()
        {
            InitializeComponent();
        }
        private void PastJobsSuper_Load(object sender, EventArgs e)
        {
            LoadStartupPastJobsSuper();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            onRemovePJS(this, new PastJobsSuperArgs(index));
        }
        public void LoadStartupPastJobsSuper()
        {
            btnPrevious.Visible = false;
            FillList("SELECT job_details.Employer_code,job_details.Job_Code,job_details.Job_Name,job_details.Job_Type_Code,"
                + "available_jobs.Job_Desc, available_jobs.Pay_Amount FROM job_details INNER JOIN available_jobs "
                + "ON job_details.Job_Code = available_jobs.Job_Code WHERE (job_details.Employer_Code = '" + username + "' "
                + "OR job_details.Employee_Code = '" + username + "') AND job_details.In_Progress = 2");
            int number = cF.GetCountSQL("SELECT COUNT(job_details.Job_Code) FROM job_details INNER JOIN available_jobs "
                + "ON job_details.Job_Code = available_jobs.Job_Code WHERE (job_details.Employer_Code = '" + username + "' "
                + "OR job_details.Employee_Code = '" + username + "') AND job_details.In_Progress = 2", conn);
            decimal dtot = (decimal)(number / 20);
            totalPageCount = (int)Math.Ceiling(dtot);
            if (totalPageCount < 1)
            {
                btnNext.Visible = false;
            }
            LoadPastJobs("SELECT COUNT(job_details.Job_Code) FROM job_details INNER JOIN available_jobs "
                + "ON job_details.Job_Code = available_jobs.Job_Code WHERE (job_details.Employer_Code = '" + username + "' "
                + "OR job_details.Employee_Code = '" + username + "') AND job_details.In_Progress = 2");
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            pageNumber--;
            pnlPJS.Controls.Clear();
            LoadPastJobs("SELECT COUNT(job_details.Job_Code) FROM job_details INNER JOIN available_jobs "
                + "ON job_details.Job_Code = available_jobs.Job_Code WHERE job_details.Employer_Code = '" + username + "' "
                + "OR job_details.Employee_Code = '" + username + "'");
            if (pageNumber == 1)
            {
                btnPrevious.Visible = false;
            }
            if (pageNumber < totalPageCount)
            {
                btnNext.Visible = true;
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            pageNumber++;
            pnlPJS.Controls.Clear();
            LoadPastJobs("SELECT COUNT(job_details.Job_Code) FROM job_details INNER JOIN available_jobs "
                + "ON job_details.Job_Code = available_jobs.Job_Code WHERE job_details.Employer_Code = '" + username + "' "
                + "OR job_details.Employee_Code = '" + username + "'");
            if (pageNumber > 1)
            {
                btnPrevious.Visible = true;
            }
            if (pageNumber >= totalPageCount)
            {
                btnNext.Visible = false;
            }
        }
        private void FillList(string command)
        {
            using (MySqlConnection conn2 = new MySqlConnection(conn))
            {
                conn2.Open();
                MySqlCommand sqlCommand = new MySqlCommand(command, conn2);
                MySqlDataReader dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    lstJobs.Add(new Jobs(dataReader));
                }
            }
        }
        private void LeftRow(int Index)
        {
            PastJobs pastJob = new PastJobs();
            PastJobs previousJob;
            pnlPJS.Controls.Add(pastJob);
            if (pnlPJS.Controls.Count < 2)
            {
                pastJob.Location = new Point(0, 0);
            }
            else
            {
                previousJob = (PastJobs)pnlPJS.Controls[pnlPJS.Controls.Count - 2];
                pastJob.Location = new Point(0, previousJob.Location.Y + previousJob.Height + SPACERY);
            }
            pastJob.setJobName(lstJobs[pnlPJS.Controls.Count - 1 + Index].JobName);
            pastJob.setUsername(lstJobs[pnlPJS.Controls.Count - 1 + Index].Username);
            pastJob.setDesc(lstJobs[pnlPJS.Controls.Count - 1 + Index].Desc);
            pastJob.setPaymentRate(lstJobs[pnlPJS.Controls.Count - 1 + Index].PayAmount.FormatCurrency(currencyCode));
            pastJob.setConn(conn);
            pastJob.setJobCode(lstJobs[pnlPJS.Controls.Count - 1 + Index].JobCode);
            pastJob.index = pnlPJS.Controls.Count - 1;
            pastJob.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top)
             | System.Windows.Forms.AnchorStyles.Left);
            pastJob.setBackColor(backColor);
            pastJob.setButtonColor(themeButtonColor);
        }
        private void RightRow(int Index)
        {
            PastJobs pastJob = new PastJobs();
            PastJobs previousJob;
            PastJobs rightFirstJob = (PastJobs)pnlPJS.Controls[pnlPJS.Controls.Count - 10];
            pnlPJS.Controls.Add(pastJob);
            if (pnlPJS.Controls.Count < 12)
            {
                pastJob.Location = new Point(rightFirstJob.Location.X + rightFirstJob.Width + SPACERX, 0);
            }
            else
            {
                previousJob = (PastJobs)pnlPJS.Controls[pnlPJS.Controls.Count - 12];
                pastJob.Location = new Point(previousJob.Width + SPACERX, previousJob.Location.Y + previousJob.Height + SPACERY);
            }
            pastJob.setJobName(lstJobs[pnlPJS.Controls.Count - 1 + Index].JobName);
            pastJob.setUsername(lstJobs[pnlPJS.Controls.Count - 1 + Index].Username);
            pastJob.setDesc(lstJobs[pnlPJS.Controls.Count - 1 + Index].Desc);
            pastJob.setPaymentRate(lstJobs[pnlPJS.Controls.Count - 1 + Index].PayAmount.FormatCurrency(currencyCode));
            pastJob.setConn(conn);
            pastJob.setJobCode(lstJobs[pnlPJS.Controls.Count - 1 + Index].JobCode);
            pastJob.index = pnlPJS.Controls.Count - 1;
            pastJob.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top)
             | System.Windows.Forms.AnchorStyles.Left);
            pastJob.setBackColor(backColor);
            pastJob.setButtonColor(themeButtonColor);
        }
        private void LoadPastJobs(string command)
        {
            int smallCount = cF.GetCountSQL(command, conn);
            int index = (pageNumber - 1) * 20;
            int leftovers = smallCount - index;
            if (leftovers < 20)
            {
                if (leftovers <= 10)
                {
                    for (int i = 1; i < leftovers + 1; i++)
                    {
                        LeftRow(index);
                    }
                }
                else
                {
                    for (int i = 1; i < 11; i++)
                    {
                        LeftRow(index);
                    }
                    for (int i = 1; i < leftovers - 9; i++)
                    {
                        RightRow(index);
                    }
                }
            }
            else
            {
                for (int i = 1; i < 11; i++)
                {
                    LeftRow(index);
                }
                for (int i = 1; i < 11; i++)
                {
                    RightRow(index);
                }
            }
        }
        public void setButtonBackColor(Color color)
        {
            btnBack.BackColor = color;
            btnNext.BackColor = color;
            btnPrevious.BackColor = color;
            themeButtonColor = color;
        }
        public void setConnection(string conn)
        {
            this.conn = conn;
        }
        public void setBackColor(Color color)
        {
            this.BackColor = color;
            backColor = color;
        }
        public void setCurrencyCode(string currencyCode)
        {
            this.currencyCode = currencyCode;
        }
        public void setUsername(string username)
        {
            this.username = username;
        }

    }
    public class PastJobsSuperArgs : EventArgs
    {
        public int index;
        public PastJobsSuperArgs(int value)
        {
            index = value;
        }
    }
}
