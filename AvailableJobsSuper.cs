using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SoutiesSandbox;

namespace Opus_Proto_1
{
    public partial class AvailableJobsSuper : UserControl
    {
        public int ajsI=0;
        const int SPACERY = 3;
        const int SPACERX = 20;
        int totalPageCount;
        int pageNumber = 1;
        string conn = "";
        List<Jobs> lstJobs = new List<Jobs>();
        CustomFunctions cf = new CustomFunctions();
        public delegate void RemoveAJSEventHandler(object sender, AvailableJobsSuperArgs e);
        public event RemoveAJSEventHandler onRemoveAJS;
        public AvailableJobsSuper()
        {
            InitializeComponent();
        }
        private void AvailableJobsSuper_Load(object sender, EventArgs e)
        {            
            conn = cf.CreateRemoteSQLConnection("10.100.100.15", "13306", "Rechard", "V<6OD|>!$i]L", "opus_db");
            cmbCategory.Items.AddRange(cf.GetStringArraySQL("SELECT Job_Name FROM job_types", conn));
            btnPrevious.Visible = false;
            FillList("SELECT * FROM available_jobs");            
            int number = cf.GetCountSQL("SELECT COUNT(Job_Code) FROM available_jobs", conn);
            decimal dtot = (decimal)(number / 50);
            totalPageCount = (int)Math.Ceiling(dtot);
            LoadAvailableJobs("SELECT COUNT(Job_Code) FROM available_jobs");
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            pageNumber--;
            pnlAJSMain.Controls.Clear();
            if(cmbCategory.SelectedIndex == -1)
            {
                LoadAvailableJobs("SELECT COUNT(Job_Code) FROM available_jobs");
            }
            else
            {
                string jobCode = cf.GetSingleStringSQL("SELECT Job_Type_Code FROM  job_types WHERE Job_Name = '" + cmbCategory.SelectedItem.ToString() + "'", conn);
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
        private void btnNext_Click(object sender, EventArgs e)
        {
            pageNumber++;
            pnlAJSMain.Controls.Clear();
            if (cmbCategory.SelectedIndex == -1)
            {
                LoadAvailableJobs("SELECT COUNT(Job_Code) FROM available_jobs");
            }
            else
            {
                string jobCode = cf.GetSingleStringSQL("SELECT Job_Type_Code FROM  job_types WHERE Job_Name = '" + cmbCategory.SelectedItem.ToString() + "'", conn);
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
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlAJSMain.Controls.Clear();
            string jobCode = cf.GetSingleStringSQL("SELECT Job_Type_Code FROM  job_types WHERE Job_Name = '" + cmbCategory.SelectedItem.ToString() + "'",conn);
            MessageBox.Show(jobCode);
            int number = cf.GetCountSQL("SELECT COUNT(Job_Code) FROM available_jobs WHERE Job_Type_Code = '" + jobCode + "'" , conn);
            decimal dtot = (decimal)(number / 50);
            totalPageCount = (int)Math.Ceiling(dtot);
            pageNumber = 1;
            FillList("SELECT * FROM available_jobs WHERE Job_Type_Code = '" + jobCode + "'");
            LoadAvailableJobs("SELECT COUNT(Job_Code) FROM available_jobs WHERE Job_Type_Code = '" + jobCode + "'");
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            onRemoveAJS(this, new AvailableJobsSuperArgs(ajsI));
        }
        private void LoadAvailableJobs(string command)
        {
            int smallCount = cf.GetCountSQL(command,conn);
            int index = (pageNumber - 1) * 50;
            int leftovers = smallCount - index;
            if (leftovers < 50)
            {
                if(leftovers <=25)
                {
                    for (int i = 1; i < leftovers+1; i++)
                    {
                        Left(index);
                    }
                }
                else
                {
                    for (int i = 1; i < 26; i++)
                    {
                        Left(index);
                    }
                    for (int i = 1; i < leftovers - 24; i++)
                    {
                        Right(index);
                    }
                }
            }
            else
            {
                for (int i = 1; i < 26; i++)
                {
                    Left(index);
                }
                for (int i = 1; i < 26; i++)
                {
                    Right(index);
                }
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
        private void Left(int Index)
        {
            AvailableJobs availableJob = new AvailableJobs();
            AvailableJobs previousJob;
            pnlAJSMain.Controls.Add(availableJob);
            if (pnlAJSMain.Controls.Count < 2)
            {
                availableJob.Location = new Point(0, 0);
            }
            else
            {
                previousJob = (AvailableJobs)pnlAJSMain.Controls[pnlAJSMain.Controls.Count - 2];
                availableJob.Location = new Point(0, previousJob.Location.Y + previousJob.Height + 3);
            }
            availableJob.SetJobName(lstJobs[pnlAJSMain.Controls.Count - 1 + Index].JobCode);
            availableJob.SetUsername(lstJobs[pnlAJSMain.Controls.Count - 1 + Index].Username);
            availableJob.SetDescription(lstJobs[pnlAJSMain.Controls.Count - 1 + Index].Desc);
            availableJob.SetRating((int.Parse(cf.GetSingleStringSQL("SELECT Overall_Rating FROM user_details WHERE Username = '" + lstJobs[pnlAJSMain.Controls.Count - 1 + Index].Username + "'", conn)) / 5 * 100));
            availableJob.SetPaymentRate(lstJobs[pnlAJSMain.Controls.Count - 1 + Index].PayAmount);
            availableJob.index = pnlAJSMain.Controls.Count - 1;
            availableJob.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
             | System.Windows.Forms.AnchorStyles.Left))));
        }
        private void Right(int Index)
        {
            AvailableJobs availableJob = new AvailableJobs();
            AvailableJobs previousJob;
            AvailableJobs rightFirstJob = (AvailableJobs)pnlAJSMain.Controls[pnlAJSMain.Controls.Count - 25];
            pnlAJSMain.Controls.Add(availableJob);
            if (pnlAJSMain.Controls.Count < 27)
            {
                availableJob.Location = new Point(rightFirstJob.Location.X + rightFirstJob.Width + SPACERX, 0);
            }
            else
            {
                previousJob = (AvailableJobs)pnlAJSMain.Controls[pnlAJSMain.Controls.Count - 27];
                availableJob.Location = new Point(previousJob.Width + SPACERX, previousJob.Location.Y + previousJob.Height + SPACERY);
            }
            availableJob.SetJobName(lstJobs[pnlAJSMain.Controls.Count - 1 + Index].JobCode);
            availableJob.SetUsername(lstJobs[pnlAJSMain.Controls.Count - 1 + Index].Username);
            availableJob.SetDescription(lstJobs[pnlAJSMain.Controls.Count - 1 + Index].Desc);
            availableJob.SetRating((int.Parse(cf.GetSingleStringSQL("SELECT Overall_Rating FROM user_details WHERE Username = '" + lstJobs[pnlAJSMain.Controls.Count - 1 + Index].Username.ToString() + "'", conn)) / 5 * 100));
            availableJob.SetPaymentRate(lstJobs[pnlAJSMain.Controls.Count - 1 + Index].PayAmount);
            availableJob.index = pnlAJSMain.Controls.Count - 1;
            availableJob.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
             | System.Windows.Forms.AnchorStyles.Left))));
        }

        

        //Need event arguement to shoot to Userprofile page
    }
    public class AvailableJobsSuperArgs : EventArgs
    {
        public int index;
        public AvailableJobsSuperArgs(int value)
        {
            index = value;
        }
    }
    public class Jobs
    {
        public string Username { get; private set; }
        public string JobCode { get; private set; }
        public string JobTypeCode { get; private set; }
        public string Desc { get; private set; }
        public int PayAmount { get; private set; }
        public Jobs(System.Data.IDataRecord Data)
        {
            Username = (string)Data[0];
            JobCode = (string)Data[1];
            JobTypeCode = (string)Data[2];
            Desc = (string)Data[3];
            PayAmount = (int)Data[4];
        }
    }
}
