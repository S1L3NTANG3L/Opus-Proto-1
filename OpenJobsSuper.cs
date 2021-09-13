using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SoutiesSandbox;

namespace Opus_Proto_1
{
    public partial class OpenJobsSuper : UserControl
    {
        public int index = 0;
        Color backColor;
        private Color themeButtonColor;
        private const int SPACERY = 10;
        private const int SPACERX = 75;
        private int totalPageCount;
        private int pageNumber = 1;
        private string conn = "";
        private string currencyCode;
        private string username;
        List<Jobs> lstJobs = new List<Jobs>();
        CustomFunctions cF = new CustomFunctions();
        public delegate void RemoveOJSEventHandler(object sender, OpenJobsSuperArgs e);
        public event RemoveOJSEventHandler onRemoveOJS;
        public OpenJobsSuper()
        {
            InitializeComponent();
        }
        private void OpenJobsSuper_Load(object sender, EventArgs e)
        {
            LoadStartUpOpenJobsSuper();
        }
        private void LoadStartUpOpenJobsSuper()
        {
            btnPrevious.Visible = false;
            FillList("SELECT job_details.Employer_code,job_details.Job_Code,job_details.Job_Name,job_details.Job_Type_Code,"
                +"open_jobs.Job_Desc, open_jobs.Pay_Amount FROM job_details INNER JOIN open_jobs "
                +"ON job_details.Job_Code = open_jobs.Job_Code WHERE job_details.Employer_Code = '" + username + "' "
                +"OR job_details.Employee_Code = '" + username + "'");
            int number = cF.GetCountSQL("SELECT COUNT(job_details.Job_Code) FROM job_details INNER JOIN open_jobs "
                +"ON job_details.Job_Code = open_jobs.Job_Code WHERE job_details.Employer_Code = '" + username + "' "
                +"OR job_details.Employee_Code = '" + username + "'", conn);
            decimal dtot = (decimal)(number / 20);
            totalPageCount = (int)Math.Ceiling(dtot);
            if(totalPageCount < 1)
            {
                btnNext.Visible = false;
            }
            LoadAvailableJobs("SELECT COUNT(job_details.Job_Code) FROM job_details INNER JOIN open_jobs "
                +"ON job_details.Job_Code = open_jobs.Job_Code WHERE job_details.Employer_Code = '" + username + "' "
                +"OR job_details.Employee_Code = '" + username + "'");
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            pageNumber--;
            pnlOJS.Controls.Clear();
            LoadAvailableJobs("SELECT COUNT(job_details.Job_Code) FROM job_details INNER JOIN open_jobs "
                +"ON job_details.Job_Code = open_jobs.Job_Code WHERE job_details.Employer_Code = '" + username + "' "
                +"OR job_details.Employee_Code = '" + username + "'");
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
            pnlOJS.Controls.Clear();
            LoadAvailableJobs("SELECT COUNT(job_details.Job_Code) FROM job_details INNER JOIN open_jobs "
                + "ON job_details.Job_Code = open_jobs.Job_Code WHERE job_details.Employer_Code = '" + username + "' "
                +"OR job_details.Employee_Code = '" + username + "'");
            if (pageNumber > 1)
            {
                btnPrevious.Visible = true;
            }
            if (pageNumber >= totalPageCount)
            {
                btnNext.Visible = false;
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            onRemoveOJS(this, new OpenJobsSuperArgs(index));
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
        private void LeftRow(int Index)//Change
        {
            OpenJobs openJob = new OpenJobs();
            //availableJob.onRemoveAJ += new AvailableJobs.RemoveAJEventHandler(RemoveAvailableJobs_Click);
            OpenJobs previousJob;
            pnlOJS.Controls.Add(openJob);
            if (pnlOJS.Controls.Count < 2)
            {
                openJob.Location = new Point(0, 0);
            }
            else
            {
                previousJob = (OpenJobs)pnlOJS.Controls[pnlOJS.Controls.Count - 2];
                openJob.Location = new Point(0, previousJob.Location.Y + previousJob.Height + SPACERY);
            }
            openJob.setJobName(lstJobs[pnlOJS.Controls.Count - 1 + Index].JobCode);
            openJob.setUsername(lstJobs[pnlOJS.Controls.Count - 1 + Index].Username);
            openJob.setDesc(lstJobs[pnlOJS.Controls.Count - 1 + Index].Desc);
            openJob.setPaymentRate(lstJobs[pnlOJS.Controls.Count - 1 + Index].PayAmount.FormatCurrency(currencyCode));
            openJob.index = pnlOJS.Controls.Count - 1;
            openJob.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
             | System.Windows.Forms.AnchorStyles.Left))));
            openJob.setBackColor(backColor);
            openJob.setButtonColor(themeButtonColor);
        }
        private void RightRow(int Index)//Change
        {
            OpenJobs openJob = new OpenJobs();
            //availableJob.onRemoveAJ += new AvailableJobs.RemoveAJEventHandler(RemoveAvailableJobs_Click);
            OpenJobs previousJob;
            OpenJobs rightFirstJob = (OpenJobs)pnlOJS.Controls[pnlOJS.Controls.Count - 10];
            pnlOJS.Controls.Add(openJob);
            if (pnlOJS.Controls.Count < 12)
            {
                openJob.Location = new Point(rightFirstJob.Location.X + rightFirstJob.Width + SPACERX, 0);
            }
            else
            {
                previousJob = (OpenJobs)pnlOJS.Controls[pnlOJS.Controls.Count - 12];
                openJob.Location = new Point(previousJob.Width + SPACERX, previousJob.Location.Y + previousJob.Height + SPACERY);
            }
            openJob.setJobName(lstJobs[pnlOJS.Controls.Count - 1 + Index].JobCode);
            openJob.setUsername(lstJobs[pnlOJS.Controls.Count - 1 + Index].Username);
            openJob.setDesc(lstJobs[pnlOJS.Controls.Count - 1 + Index].Desc);
            openJob.setPaymentRate(lstJobs[pnlOJS.Controls.Count - 1 + Index].PayAmount.FormatCurrency(currencyCode));
            openJob.index = pnlOJS.Controls.Count - 1;
            openJob.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
             | System.Windows.Forms.AnchorStyles.Left))));
            openJob.setBackColor(backColor);
            openJob.setButtonColor(themeButtonColor);
        }
        private void LoadAvailableJobs(string command)
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
    }
    public class OpenJobsSuperArgs : EventArgs
    {
        public int index;
        public OpenJobsSuperArgs(int value)
        {
            index = value;
        }
    }
}
