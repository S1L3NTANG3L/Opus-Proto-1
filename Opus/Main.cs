﻿using MaterialSkin;
using MaterialSkin.Controls;
using SoutiesSandbox;
using System;
using System.Drawing;
using System.Reflection;

namespace Opus_Proto_1
{
    public partial class frmMain : MaterialForm
    {        
        public string pickedTheme;
        public Color themeButtonColor;
        public Color themeBackColor;
        public string sec_key;
        public string conn;
        public string currencyCode;
        private string username;
        private CustomFunctions cF = new CustomFunctions();
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            conn = cF.CreateRemoteSQLConnection("soutiesentrance.ddns.net", "13306", "opus_user", "opus2021", "opus_db");
            var temp = cF.ReadFromFile("\\Config\\config.dll");
            string[] tempArr = temp.StringArray;
            sec_key = "@xCp#fvaYKgTE3jQznutT92Qk5TmyAzHfsf2cEJhd$kt5m~n9YsWops%KZRMKXpCfi^fSm$kKo&4mbmSqtt7Up%XpCXc@Ff2YCvFY7ngNPPpxF`^~pTp^eWZjENf~9i#";
            pickedTheme = tempArr[0];
            currencyCode = tempArr[1];
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            if (pickedTheme == "Dark")
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.BLACK);
                themeButtonColor = Color.FromArgb(39, 62, 76);
                themeBackColor = Color.FromArgb(50, 50, 50);
            }
            else
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue800, Primary.Cyan800, Primary.LightBlue400, Accent.LightBlue700, TextShade.BLACK);
                themeButtonColor = Color.FromArgb(62, 155, 212);
                themeBackColor = Color.FromArgb(39, 124, 175);
            }
            Login lgnForm = new Login();
            lgnForm.setButtonBackColor(themeButtonColor);
            lgnForm.setConnection(conn);
            lgnForm.setBackColor(themeBackColor);
            lgnForm.setSecCode(sec_key);
            pnlMain.Controls.Add(lgnForm);
            lgnForm.Location = new Point(pnlMain.Width / 2 - 250, 0);
            lgnForm.onRemoveLogin += new Login.RemoveLoginEventHandler(LoadMainMenu_Click);
            lgnForm.LoadReg += new Login.LoadRegEventHandler(LoadRegistration_Click);
        }
        private void LoadMainMenu_Click(Object sender, LoginArgs e)
        {
            Login login = (Login)sender;
            username = login.getUsername();
            pnlMain.Controls.Remove(login);
            MainMenu mainMenu = new MainMenu();
            mainMenu.setBackColor(themeBackColor);
            mainMenu.onRemoveSite += new MainMenu.RemoveMMEventHandler(RemoveMMSite_Click);
            pnlMain.Controls.Add(mainMenu);
            mainMenu.Location = new Point(pnlMain.Width / 2 - 250, 0);
        }
        private void LoadRegistration_Click(Object sender, LoginArgs e)
        {
            Login login = (Login)sender;
            pnlMain.Controls.Remove(login);
            Registartion registartion = new Registartion();
            registartion.setBackColor(themeBackColor);
            registartion.setButtonBackColor(themeButtonColor);
            registartion.setConnection(conn);
            registartion.setSecCode(sec_key);
            registartion.onRemoveSite += new Registartion.RemoveRegEventHandler(RemoveRegSite_Click);
            pnlMain.Controls.Add(registartion);
            registartion.Location = new Point(pnlMain.Width / 2 - 600, 0);
        }
        private void RemoveOJSSite_Click(Object sender, OpenJobsSuperArgs e)
        {
            OpenJobsSuper jobsSuper = (OpenJobsSuper)sender;
            pnlMain.Controls.Remove(jobsSuper);
            MainMenu mainMenu = new MainMenu();
            mainMenu.setBackColor(themeBackColor);
            mainMenu.onRemoveSite += new MainMenu.RemoveMMEventHandler(RemoveMMSite_Click);
            pnlMain.Controls.Add(mainMenu);
            mainMenu.Location = new Point(pnlMain.Width / 2 - 250, 0);
        }
        private void RemoveRegSite_Click(Object sender, RegistrationArgs e)
        {
            Registartion registartion = (Registartion)sender;
            pnlMain.Controls.Remove(registartion);
            Login lgnForm = new Login();
            lgnForm.setButtonBackColor(themeButtonColor);
            lgnForm.setConnection(conn);
            lgnForm.setBackColor(themeBackColor);
            lgnForm.setSecCode(sec_key);
            pnlMain.Controls.Add(lgnForm);
            lgnForm.Location = new Point(pnlMain.Width / 2 - 250, 0);
            lgnForm.onRemoveLogin += new Login.RemoveLoginEventHandler(LoadMainMenu_Click);
            lgnForm.LoadReg += new Login.LoadRegEventHandler(LoadRegistration_Click);
        }
        private void RemoveUPSite_Click(Object sender, UserProfileArgs e)
        {
            UserProfile userProfile = (UserProfile)sender;
            pnlMain.Controls.Remove(userProfile);
            MainMenu mainMenu = new MainMenu();
            mainMenu.setBackColor(themeBackColor);
            mainMenu.onRemoveSite += new MainMenu.RemoveMMEventHandler(RemoveMMSite_Click);
            pnlMain.Controls.Add(mainMenu);
            mainMenu.Location = new Point(pnlMain.Width / 2 - 250, 0);
        }
        private void RemoveAJSSite_Click(Object sender, AvailableJobsSuperArgs e)
        {
            AvailableJobsSuper jobsSuper = (AvailableJobsSuper)sender;
            pnlMain.Controls.Remove(jobsSuper);
            MainMenu mainMenu = new MainMenu();
            mainMenu.setBackColor(themeBackColor);
            mainMenu.onRemoveSite += new MainMenu.RemoveMMEventHandler(RemoveMMSite_Click);
            pnlMain.Controls.Add(mainMenu);
            mainMenu.Location = new Point(pnlMain.Width / 2 - 250, 0);
        }
        private void RemoveSSite_Click(Object sender, SettingsArgs e)
        {
            Settings settings = (Settings)sender;
            pnlMain.Controls.Remove(settings);
            MainMenu mainMenu = new MainMenu();
            mainMenu.setBackColor(themeBackColor);
            mainMenu.onRemoveSite += new MainMenu.RemoveMMEventHandler(RemoveMMSite_Click);
            pnlMain.Controls.Add(mainMenu);
            mainMenu.Location = new Point(pnlMain.Width / 2 - 250, 0);
        }
        private void LoadApplicantUP_Click(Object sender, JobInfoArgs e)
        {
            JobInfo jobInfo = (JobInfo)sender;
            string tempUser = jobInfo.getUsername();
            string tempJobCode = jobInfo.getJobCode();
            pnlMain.Controls.Remove(jobInfo);
            UserProfile userProfile = new UserProfile();
            userProfile.JobInfoLoad += new UserProfile.JobInfoLEventHandler(LoadJobInfo2_Click);
            userProfile.setUsername(tempUser);
            userProfile.setJobCode(tempJobCode);
            userProfile.disableReview();
            userProfile.disableBackButton();
            userProfile.hideDetails();
            userProfile.dateJoined = cF.GetSingleStringSQL("SELECT Date_Joined FROM user_details WHERE Username = '" + tempUser + "'", conn);
            int rating = 0;
            string[] arrRatings = cF.GetStringArraySQL("SELECT Rating FROM reviews WHERE User_Reviewed_Code ='" + tempUser + "'", conn);
            if (arrRatings.Length != 0)
            {
                for (int i = 0; i < arrRatings.Length; i++)
                {
                    rating += int.Parse(arrRatings[i]);
                }
                rating = rating / arrRatings.Length;
            }
            userProfile.rating = rating;
            userProfile.setEmail(cF.GetSingleStringSQL("SELECT Email FROM user_details WHERE Username = '" + tempUser + "'", conn));
            userProfile.setNumber(cF.GetSingleStringSQL("SELECT Number FROM user_details WHERE Username = '" + tempUser + "'", conn));
            if (!(cF.GetCountSQL("SELECT COUNT(Review) FROM reviews WHERE User_Code ='" + tempUser + "' AND Rating NOT NULL", conn) == 0))
            {
                string[] arrReviews = cF.GetStringArraySQL("SELECT Review FROM reviews WHERE User_Reviewed_Code ='" + tempUser + "'", conn);
                string[] arrUsers = cF.GetStringArraySQL("SELECT User_Code FROM reviews WHERE User_Reviewed_Code ='" + tempUser + "' AND Rating NOT NULL", conn);
                for (int i = 0; i < arrReviews.Length; i++)
                {
                    userProfile.addReview("Review by: " + arrUsers[i] + "\n" + arrReviews[i]);
                }
            }
            userProfile.backColor = themeBackColor;
            userProfile.buttonColor = themeButtonColor;
            userProfile.setConn(conn);
            userProfile.setDefualtProfilePicture();
            pnlMain.Controls.Add(userProfile);
            userProfile.Location = new Point(pnlMain.Width / 2 - 330, 0);
        }
        private void LoadJobInfo_Click(Object sender, OpenJobsSuperArgs e)
        {
            OpenJobsSuper openJobsSuper = (OpenJobsSuper)sender;
            string tempJobCode = openJobsSuper.getJobCode();
            pnlMain.Controls.Clear();
            JobInfo jobInfo = new JobInfo(tempJobCode);
            jobInfo.LoadOpenJobs += new JobInfo.LoadOpenJobsEventHandler(LoadOpenJobs_Click);
            jobInfo.LoadApplicantUP += new JobInfo.LoadApplicantUPEventHandler(LoadApplicantUP_Click);
            jobInfo.setBackColor(themeBackColor);
            jobInfo.setButtonColor(themeButtonColor);
            jobInfo.setJobName(cF.GetSingleStringSQL("SELECT Job_Name FROM job_details WHERE Job_Code = '"
                + tempJobCode + "'", conn));
            jobInfo.setDesc(cF.GetSingleStringSQL("SELECT Job_Desc FROM available_jobs WHERE Job_Code = '"
                + tempJobCode + "'", conn));
            jobInfo.setConn(conn);
            if(!jobInfo.showCorrect())
            {
                jobInfo.loadApplicants();
            }
            pnlMain.Controls.Add(jobInfo);
            jobInfo.Location = new Point(pnlMain.Width / 2 - 200, 0);
        }
        private void LoadJobInfo2_Click(Object sender, UserProfileArgs e)
        {
            UserProfile userProfile = (UserProfile)sender;
            string tempJobCode = userProfile.getJobCode();
            pnlMain.Controls.Clear();
            JobInfo jobInfo = new JobInfo(tempJobCode);
            jobInfo.LoadOpenJobs += new JobInfo.LoadOpenJobsEventHandler(LoadOpenJobs_Click);
            jobInfo.LoadApplicantUP += new JobInfo.LoadApplicantUPEventHandler(LoadApplicantUP_Click);
            jobInfo.setBackColor(themeBackColor);
            jobInfo.setButtonColor(themeButtonColor);
            jobInfo.setJobName(cF.GetSingleStringSQL("SELECT Job_Name FROM job_details WHERE Job_Code = '"
                + tempJobCode + "'", conn));
            jobInfo.setDesc(cF.GetSingleStringSQL("SELECT Job_Desc FROM available_jobs WHERE Job_Code = '"
                + tempJobCode + "'", conn));
            jobInfo.setConn(conn);
            if (!jobInfo.showCorrect())
            {
                jobInfo.loadApplicants();
            }
            pnlMain.Controls.Add(jobInfo);
            jobInfo.Location = new Point(pnlMain.Width / 2 - 200, 0);
        }
        private void LoadOpenJobs_Click(Object sender, JobInfoArgs e)
        {
            pnlMain.Controls.Clear();
            OpenJobsSuper openJobsSuper = new OpenJobsSuper();
            openJobsSuper.setButtonBackColor(themeButtonColor);
            openJobsSuper.setConnection(conn);
            openJobsSuper.setBackColor(themeBackColor);
            openJobsSuper.setCurrencyCode(currencyCode);
            openJobsSuper.setUsername(username);
            openJobsSuper.onRemoveOJS += new OpenJobsSuper.RemoveOJSEventHandler(RemoveOJSSite_Click);
            openJobsSuper.LoadJobInfo += new OpenJobsSuper.LoadJobInfoEventHandler(LoadJobInfo_Click);
            pnlMain.Controls.Add(openJobsSuper);
            openJobsSuper.Location = new Point(pnlMain.Width / 2 - 600, 0);
        }
        private void RemovePJSSite_Click(Object sender, PastJobsSuperArgs e)
        {
            PastJobsSuper jobsSuper = (PastJobsSuper)sender;
            pnlMain.Controls.Remove(jobsSuper);
            MainMenu mainMenu = new MainMenu();
            mainMenu.setBackColor(themeBackColor);
            mainMenu.onRemoveSite += new MainMenu.RemoveMMEventHandler(RemoveMMSite_Click);
            pnlMain.Controls.Add(mainMenu);
            mainMenu.Location = new Point(pnlMain.Width / 2 - 250, 0);
        }
        private void RemoveMMSite_Click(Object sender, MainMenuArgs e)
        {
            MainMenu mainMenu = (MainMenu)sender;
            pnlMain.Controls.Remove(mainMenu);
            int temp = mainMenu.index;
            switch (temp)
            {
                case 1:
                    UserProfile userProfile = new UserProfile();
                    userProfile.setUsername(username);
                    userProfile.disableBack2();
                    userProfile.dateJoined = cF.GetSingleStringSQL("SELECT Date_Joined FROM user_details WHERE Username = '" + username + "'", conn);
                    int rating = 0;
                    string[] arrRatings = cF.GetStringArraySQL("SELECT Rating FROM reviews WHERE User_Reviewed_Code ='" + username + "'", conn);
                    if (arrRatings.Length != 0)
                    {
                        for (int i = 0; i < arrRatings.Length; i++)
                        {
                            rating += int.Parse(arrRatings[i]);
                        }
                        rating = rating / arrRatings.Length;
                    }
                    userProfile.rating = rating;
                    userProfile.setEmail(cF.GetSingleStringSQL("SELECT Email FROM user_details WHERE Username = '" + username + "'", conn));
                    userProfile.setNumber(cF.GetSingleStringSQL("SELECT Number FROM user_details WHERE Username = '" + username + "'", conn));
                    if (!(cF.GetCountSQL("SELECT COUNT(Review) FROM reviews WHERE User_Reviewed_Code ='" + username + "'", conn) == 0))
                    {
                        string[] arrReviews = cF.GetStringArraySQL("SELECT Review FROM reviews WHERE User_Reviewed_Code ='" + username + "'", conn);
                        string[] arrUsers = cF.GetStringArraySQL("SELECT Username FROM reviews WHERE User_Reviewed_Code ='" + username + "'", conn);
                        for (int i = 0; i < arrReviews.Length; i++)
                        {
                            userProfile.addReview("Review by: " + arrUsers[i] + "\t" + arrReviews[i]);
                        }
                    }
                    userProfile.backColor = themeBackColor;
                    userProfile.buttonColor = themeButtonColor;
                    userProfile.setConn(conn);
                    userProfile.setDefualtProfilePicture();
                    userProfile.onRemoveUP += new UserProfile.RemoveUPEventHandler(RemoveUPSite_Click);
                    pnlMain.Controls.Add(userProfile);
                    userProfile.Location = new Point(pnlMain.Width / 2 - 330, 0);
                    break;
                case 2:
                    OpenJobsSuper openJobsSuper = new OpenJobsSuper();
                    openJobsSuper.setButtonBackColor(themeButtonColor);
                    openJobsSuper.setConnection(conn);
                    openJobsSuper.setBackColor(themeBackColor);
                    openJobsSuper.setCurrencyCode(currencyCode);
                    openJobsSuper.setUsername(username);
                    openJobsSuper.onRemoveOJS += new OpenJobsSuper.RemoveOJSEventHandler(RemoveOJSSite_Click);
                    openJobsSuper.LoadJobInfo += new OpenJobsSuper.LoadJobInfoEventHandler(LoadJobInfo_Click);
                    pnlMain.Controls.Add(openJobsSuper);
                    openJobsSuper.Location = new Point(pnlMain.Width / 2 - 600, 0);
                    break;
                case 3:
                    AvailableJobsSuper availableJobsSuper = new AvailableJobsSuper();
                    availableJobsSuper.setButtonBackColor(themeButtonColor);
                    availableJobsSuper.setConnection(conn);
                    availableJobsSuper.setBackColor(themeBackColor);
                    availableJobsSuper.setCurrencyCode(currencyCode);
                    availableJobsSuper.setCurrentUser(username);
                    availableJobsSuper.onRemoveAJS += new AvailableJobsSuper.RemoveAJSEventHandler(RemoveAJSSite_Click);
                    pnlMain.Controls.Add(availableJobsSuper);
                    availableJobsSuper.Location = new Point(pnlMain.Width / 2 - 600, 0);
                    break;
                case 4:
                    PastJobsSuper pastJobsSuper = new PastJobsSuper();
                    pastJobsSuper.setButtonBackColor(themeButtonColor);
                    pastJobsSuper.setConnection(conn);
                    pastJobsSuper.setBackColor(themeBackColor);
                    pastJobsSuper.setCurrencyCode(currencyCode);
                    pastJobsSuper.onRemovePJS += new PastJobsSuper.RemovePJSEventHandler(RemovePJSSite_Click);
                    pnlMain.Controls.Add(pastJobsSuper);
                    pastJobsSuper.Location = new Point(pnlMain.Width / 2 - 600, 0);
                    break;
                case 5:
                    Settings settings = new Settings();
                    settings.setButtonBackColor(themeButtonColor);
                    settings.setCurrencyCode(currencyCode);
                    settings.setBackColor(themeBackColor);
                    settings.setPickedTheme(pickedTheme);
                    settings.onRemoveS += new Settings.RemoveSEventHandler(RemoveSSite_Click);
                    pnlMain.Controls.Add(settings);
                    settings.Location = new Point(pnlMain.Width / 2 - 275, 0);
                    settings.setVersion(Assembly.GetExecutingAssembly().GetName().Version);
                    break;
                case 6:
                    Login login = new Login();
                    login.setButtonBackColor(themeButtonColor);
                    login.setConnection(conn);
                    login.setBackColor(themeBackColor);
                    login.setSecCode(sec_key);
                    login.onRemoveLogin += new Login.RemoveLoginEventHandler(LoadMainMenu_Click);
                    login.LoadReg += new Login.LoadRegEventHandler(LoadRegistration_Click);
                    pnlMain.Controls.Add(login);
                    login.Location = new Point(pnlMain.Width / 2 - 250, 0);
                    break;
            }
        }
    }
}
