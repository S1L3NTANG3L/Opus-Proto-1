using MySql.Data.MySqlClient;
using SoutiesSandbox;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Opus_Proto_1
{
    public partial class AvailableJobsSuper : UserControl
    {
        Color backColor;
        public int index = 0;
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
        public delegate void RemoveAJSEventHandler(object sender, AvailableJobsSuperArgs e);
        public event RemoveAJSEventHandler onRemoveAJS;
        public AvailableJobsSuper()
        {
            InitializeComponent();
        }
        private void AvailableJobsSuper_Load(object sender, EventArgs e)
        {
            LoadStartUpAvailableJobsSuper();
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            pageNumber--;
            pnlAJSMain.Controls.Clear();
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
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlAJSMain.Controls.Clear();
            string jobTypeCode = cF.GetSingleStringSQL("SELECT Job_Type_Code FROM  job_types WHERE Job_Name = '" + cmbCategory.SelectedItem.ToString() + "'", conn);
            MessageBox.Show(jobTypeCode);
            int number = cF.GetCountSQL("SELECT COUNT(job_details.Job_Code) FROM job_details INNER JOIN "
                +"available_jobs ON job_details.Job_Code = available_jobs.Job_Code WHERE job_details.Job_Type_Code = '" + jobTypeCode + "'", conn);
            decimal dtot = (decimal)(number / 20);
            totalPageCount = (int)Math.Ceiling(dtot);
            pageNumber = 1;
            FillList("SELECT job_details.Employer_code,job_details.Job_Code,job_details.Job_Type_Code,available_jobs.Job_Desc, available_jobs.Pay_Amount "
                + "FROM job_details INNER JOIN available_jobs ON job_details.Job_Code = available_jobs.Job_Code "
                +"WHERE job_details.Job_Type_Code = '" + jobTypeCode + "'");
            LoadAvailableJobs("SELECT COUNT(job_details.Job_Code) FROM job_details INNER JOIN available_jobs "
                +"ON job_details.Job_Code = available_jobs.Job_Code WHERE job_details.Job_Type_Code = '" + jobTypeCode + "'");
        }
        private void RemoveAvailableJobs_Click(Object sender, AvailableJobsArgs e)
        {
            AvailableJobs availableJobs = (AvailableJobs)sender;
            username = availableJobs.getUsername();
            pnlAJSMain.Controls.Clear();
            UserProfile userProfile = new UserProfile();
            userProfile.username = this.username;
            userProfile.rating = cF.GetSingleIntegerSQL("SELECT Overall_Rating FROM user_details WHERE Username ='" + username + "'",conn);
            //userProfile.profilePicture = sqlCode; Need to figure this out
            userProfile.backColor = this.backColor;
            userProfile.buttonColor = this.themeButtonColor;
            userProfile.disableBackButton();
            userProfile.setDefualtProfilePicture();
            if(!(cF.GetCountSQL("SELECT COUNT(Review) FROM reviews WHERE User_Code ='" + username + "'", conn) == 0))
            {
                string[] arrReviews = cF.GetStringArraySQL("SELECT Review FROM reviews WHERE User_Code ='" + username + "'", conn);
                for (int i = 0; i < arrReviews.Length; i++)
                {
                    userProfile.addReview(arrReviews[i]);
                }                
            }
            pnlAJSMain.Controls.Add(userProfile);
            userProfile.Location = new Point(pnlAJSMain.Width / 2 - 330, 0);
            pageShowing++;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if(pageShowing == 0)
            {
                onRemoveAJS(this, new AvailableJobsSuperArgs(index));
            }
            else
            {
                pnlAJSMain.Controls.Clear();
                LoadStartUpAvailableJobsSuper();
                pageShowing--;
            }            
        }
        private void LoadStartUpAvailableJobsSuper()
        {
            cmbCategory.Items.AddRange(cF.GetStringArraySQL("SELECT Job_Name FROM job_types", conn));
            btnPrevious.Visible = false;
            FillList("SELECT job_details.Employer_code,job_details.Job_Code,job_details.Job_Type_Code,available_jobs.Job_Desc, available_jobs.Pay_Amount "
                +"FROM job_details INNER JOIN available_jobs ON job_details.Job_Code = available_jobs.Job_Code; ");
            int number = cF.GetCountSQL("SELECT COUNT(Job_Code) FROM job_Details", conn);
            decimal dtot = (decimal)(number / 20);
            totalPageCount = (int)Math.Ceiling(dtot);
            LoadAvailableJobs("SELECT COUNT(Job_Code) FROM job_details");
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
            AvailableJobs availableJob = new AvailableJobs();
            availableJob.onRemoveAJ += new AvailableJobs.RemoveAJEventHandler(RemoveAvailableJobs_Click);
            AvailableJobs previousJob;
            pnlAJSMain.Controls.Add(availableJob);
            if (pnlAJSMain.Controls.Count < 2)
            {
                availableJob.Location = new Point(0, 0);
            }
            else
            {
                previousJob = (AvailableJobs)pnlAJSMain.Controls[pnlAJSMain.Controls.Count - 2];
                availableJob.Location = new Point(0, previousJob.Location.Y + previousJob.Height + SPACERY);
            }
            availableJob.SetJobName(lstJobs[pnlAJSMain.Controls.Count - 1 + Index].JobCode);
            availableJob.SetUsername(lstJobs[pnlAJSMain.Controls.Count - 1 + Index].Username);
            availableJob.SetDescription(lstJobs[pnlAJSMain.Controls.Count - 1 + Index].Desc);
            availableJob.SetRating(int.Parse(cF.GetSingleStringSQL("SELECT Overall_Rating FROM user_details WHERE Username = '" + lstJobs[pnlAJSMain.Controls.Count - 1 + Index].Username + "'", conn)));
            availableJob.SetPaymentRate(lstJobs[pnlAJSMain.Controls.Count - 1 + Index].PayAmount.FormatCurrency(currencyCode));
            availableJob.index = pnlAJSMain.Controls.Count - 1;
            availableJob.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
             | System.Windows.Forms.AnchorStyles.Left))));
            availableJob.setBackColor(backColor);
        }
        private void RightRow(int Index)
        {
            AvailableJobs availableJob = new AvailableJobs();
            availableJob.onRemoveAJ += new AvailableJobs.RemoveAJEventHandler(RemoveAvailableJobs_Click);
            AvailableJobs previousJob;
            AvailableJobs rightFirstJob = (AvailableJobs)pnlAJSMain.Controls[pnlAJSMain.Controls.Count - 10];
            pnlAJSMain.Controls.Add(availableJob);
            if (pnlAJSMain.Controls.Count < 12)
            {
                availableJob.Location = new Point(rightFirstJob.Location.X + rightFirstJob.Width + SPACERX, 0);
            }
            else
            {
                previousJob = (AvailableJobs)pnlAJSMain.Controls[pnlAJSMain.Controls.Count - 12];
                availableJob.Location = new Point(previousJob.Width + SPACERX, previousJob.Location.Y + previousJob.Height + SPACERY);
            }
            availableJob.SetJobName(lstJobs[pnlAJSMain.Controls.Count - 1 + Index].JobCode);
            availableJob.SetUsername(lstJobs[pnlAJSMain.Controls.Count - 1 + Index].Username);
            availableJob.SetDescription(lstJobs[pnlAJSMain.Controls.Count - 1 + Index].Desc);
            availableJob.SetRating(int.Parse(cF.GetSingleStringSQL("SELECT Overall_Rating FROM user_details WHERE Username = '" + lstJobs[pnlAJSMain.Controls.Count - 1 + Index].Username.ToString() + "'", conn)));
            availableJob.SetPaymentRate(lstJobs[pnlAJSMain.Controls.Count - 1 + Index].PayAmount.FormatCurrency(currencyCode));
            availableJob.index = pnlAJSMain.Controls.Count - 1;
            availableJob.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
             | System.Windows.Forms.AnchorStyles.Left))));
            availableJob.setBackColor(backColor);
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
        public decimal PayAmount { get; private set; }
        public Jobs(System.Data.IDataRecord Data)
        {
            Username = (string)Data[0];
            JobCode = (string)Data[1];
            JobTypeCode = (string)Data[2];
            Desc = (string)Data[3];
            PayAmount = (decimal)Data[4];
        }
    }
    public static class DecimalExtension
    {
        private static readonly Dictionary<string, CultureInfo> ISOCurrenciesToACultureMap =
            CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                .Select(c => new { c, new RegionInfo(c.LCID).ISOCurrencySymbol })
                .GroupBy(x => x.ISOCurrencySymbol)
                .ToDictionary(g => g.Key, g => g.First().c, StringComparer.OrdinalIgnoreCase);

        public static string FormatCurrency(this decimal amount, string currencyCode)
        {
            CultureInfo culture;
            if (ISOCurrenciesToACultureMap.TryGetValue(currencyCode, out culture))
                return string.Format(culture, "{0:C}", amount);
            return amount.ToString("0.00");
        }
    }
}
