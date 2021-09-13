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
        private int pageShowing = 0;
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
        private void LoadStartUpOpenJobsSuper()//Change
        {
            cmbCategory.Items.AddRange(cF.GetStringArraySQL("SELECT Job_Name FROM job_types", conn));
            btnPrevious.Visible = false;
            FillList("SELECT job_details.Employer_code,job_details.Job_Code,job_details.Job_Type_Code,available_jobs.Job_Desc, available_jobs.Pay_Amount "
                + "FROM job_details INNER JOIN available_jobs ON job_details.Job_Code = available_jobs.Job_Code; ");
            int number = cF.GetCountSQL("SELECT COUNT(Job_Code) FROM job_details", conn);
            decimal dtot = (decimal)(number / 20);
            totalPageCount = (int)Math.Ceiling(dtot);
            LoadAvailableJobs("SELECT COUNT(Job_Code) FROM job_details");
        }
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)//Change
        {
            pnlOJS.Controls.Clear();
            string jobTypeCode = cF.GetSingleStringSQL("SELECT Job_Type_Code FROM  job_types WHERE Job_Name = '" + cmbCategory.SelectedItem.ToString() + "'", conn);
            MessageBox.Show(jobTypeCode);
            int number = cF.GetCountSQL("SELECT COUNT(job_details.Job_Code) FROM job_details INNER JOIN "
                + "available_jobs ON job_details.Job_Code = available_jobs.Job_Code WHERE job_details.Job_Type_Code = '" + jobTypeCode + "'", conn);
            decimal dtot = (decimal)(number / 20);
            totalPageCount = (int)Math.Ceiling(dtot);
            pageNumber = 1;
            FillList("SELECT job_details.Employer_code,job_details.Job_Code,job_details.Job_Type_Code,available_jobs.Job_Desc, available_jobs.Pay_Amount "
                + "FROM job_details INNER JOIN available_jobs ON job_details.Job_Code = available_jobs.Job_Code "
                + "WHERE job_details.Job_Type_Code = '" + jobTypeCode + "'");
            LoadAvailableJobs("SELECT COUNT(job_details.Job_Code) FROM job_details INNER JOIN available_jobs "
                + "ON job_details.Job_Code = available_jobs.Job_Code WHERE job_details.Job_Type_Code = '" + jobTypeCode + "'");
        }
        private void btnPrevious_Click(object sender, EventArgs e)//Change
        {
            pageNumber--;
            pnlOJS.Controls.Clear();
            if (cmbCategory.SelectedIndex == -1)
            {
                LoadAvailableJobs("SELECT COUNT(Job_Code) FROM available_jobs");
            }
            else
            {
                string jobCode = cF.GetSingleStringSQL("SELECT Job_Type_Code FROM  job_types WHERE Job_Name = '" + cmbCategory.SelectedItem.ToString() + "'", conn);
                LoadAvailableJobs("SELECT COUNT(Job_Code) FROM available_jobs WHERE Job_Type_Code = '" + jobCode + "'");
            }
            if (pageNumber == 1)
            {
                btnPrevious.Visible = false;
            }
            if (pageNumber < totalPageCount)
            {
                btnNext.Visible = true;
            }
        }
        private void btnNext_Click(object sender, EventArgs e)//Change
        {
            pageNumber++;
            pnlOJS.Controls.Clear();
            if (cmbCategory.SelectedIndex == -1)
            {
                LoadAvailableJobs("SELECT COUNT(Job_Code) FROM available_jobs");
            }
            else
            {
                string jobCode = cF.GetSingleStringSQL("SELECT Job_Type_Code FROM  job_types WHERE Job_Name = '" + cmbCategory.SelectedItem.ToString() + "'", conn);
                LoadAvailableJobs("SELECT COUNT(Job_Code) FROM available_jobs WHERE Job_Type_Code = '" + jobCode + "'");
            }
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
            //openJob.SetJobName(lstJobs[pnlOJS.Controls.Count - 1 + Index].JobCode);
            //openJob.SetUsername(lstJobs[pnlOJS.Controls.Count - 1 + Index].Username);
            //openJob.SetDescription(lstJobs[pnlOJS.Controls.Count - 1 + Index].Desc);
            //openJob.SetRating(int.Parse(cF.GetSingleStringSQL("SELECT Overall_Rating FROM user_details WHERE Username = '" + lstJobs[pnlOJS.Controls.Count - 1 + Index].Username + "'", conn)));
            //openJob.SetPaymentRate(lstJobs[pnlOJS.Controls.Count - 1 + Index].PayAmount.FormatCurrency(currencyCode));
            openJob.index = pnlOJS.Controls.Count - 1;
            openJob.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
             | System.Windows.Forms.AnchorStyles.Left))));
            //openJob.setBackColor(backColor);
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
            //openJob.SetJobName(lstJobs[pnlOJS.Controls.Count - 1 + Index].JobCode);
            //openJob.SetUsername(lstJobs[pnlOJS.Controls.Count - 1 + Index].Username);
            //openJob.SetDescription(lstJobs[pnlOJS.Controls.Count - 1 + Index].Desc);
            //openJob.SetRating(int.Parse(cF.GetSingleStringSQL("SELECT Overall_Rating FROM user_details WHERE Username = '" + lstJobs[pnlOJS.Controls.Count - 1 + Index].Username.ToString() + "'", conn)));
            //openJob.SetPaymentRate(lstJobs[pnlOJS.Controls.Count - 1 + Index].PayAmount.FormatCurrency(currencyCode));
            openJob.index = pnlOJS.Controls.Count - 1;
            openJob.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
             | System.Windows.Forms.AnchorStyles.Left))));
            //openJob.setBackColor(backColor);
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
