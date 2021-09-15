using MaterialSkin;
using MaterialSkin.Controls;
using SoutiesSandbox;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Opus_Proto_1
{
    public partial class frmMain : MaterialForm
    {
        CustomFunctions cF = new CustomFunctions();
        public string pickedTheme;
        public Color themeButtonColor;
        public Color themeBackColor;
        public string sec_key;
        public string conn;
        public string currencyCode;
        private string username;
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            //conn = cF.CreateRemoteSQLConnection("soutiesentrance.ddns.net", "13306", "opus_user", "opus2021", "opus_db");//Remote Connection
            conn = cF.CreateRemoteSQLConnection("192.168.50.34", "13306", "opus_user", "opus2021", "opus_db");//Needs to change for external access
            var temp = cF.ReadFromFile("\\Config\\config.dll");
            string[] tempArr = temp.StringArray;
            sec_key = tempArr[0];
            pickedTheme = tempArr[1];
            currencyCode = tempArr[2];
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
            pnlMain.Controls.Add(lgnForm);
            lgnForm.Location = new Point(pnlMain.Width / 2 - 250, 0);
            lgnForm.onRemoveLogin += new Login.RemoveLoginEventHandler(RemoveLgnSite_Click);
        }
        private void RemoveLgnSite_Click(Object sender, LoginArgs e)
        {
            Login login = (Login)sender;
            username = login.username;
            if(login.buttonPressed == 1)
            {
                pnlMain.Controls.Remove(login);
                MainMenu mainMenu = new MainMenu();
                mainMenu.setBackColor(themeBackColor);
                mainMenu.onRemoveSite += new MainMenu.RemoveMMEventHandler(RemoveMMSite_Click);
                pnlMain.Controls.Add(mainMenu);
                mainMenu.Location = new Point(pnlMain.Width / 2 - 250, 0);
            }
            else
            {
                pnlMain.Controls.Remove(login);
                Registartion registartion = new Registartion();
                registartion.setBackColor(themeBackColor);
                registartion.setButtonBackColor(themeButtonColor);
                registartion.setConnection(conn);
                registartion.onRemoveSite += new Registartion.RemoveRegEventHandler(RemoveRegSite_Click);
                pnlMain.Controls.Add(registartion);
                registartion.Location = new Point(pnlMain.Width / 2 - 600, 0);
            }
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
            pnlMain.Controls.Add(lgnForm);
            lgnForm.Location = new Point(pnlMain.Width / 2 - 250, 0);
            lgnForm.onRemoveLogin += new Login.RemoveLoginEventHandler(RemoveLgnSite_Click);
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
        private void LoadJobInfo_Click(Object sender, OpenJobsSuperArgs e)
        {
            OpenJobsSuper openJobsSuper = (OpenJobsSuper)sender;
            string tempJobCode = openJobsSuper.getJobCode();
            pnlMain.Controls.Clear();
            JobInfo jobInfo = new JobInfo(tempJobCode);
            jobInfo.LoadOpenJobs += new JobInfo.LoadOpenJobsEventHandler(LoadOpenJobs_Click);
            jobInfo.setBackColor(themeBackColor);
            jobInfo.setButtonColor(themeButtonColor);
            jobInfo.setJobName(cF.GetSingleStringSQL("SELECT Job_Name FROM job_details WHERE Job_Code = '" + tempJobCode + "'", conn));
            jobInfo.setDesc(cF.GetSingleStringSQL("SELECT Job_Desc FROM available_jobs WHERE Job_Code = '" + tempJobCode + "'", conn));
            pnlMain.Controls.Add(jobInfo);
            jobInfo.Location = new Point(pnlMain.Width / 2 - 300, 0);
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
        private void RemoveMMSite_Click(Object sender, MainMenuArgs e)
        {
            MainMenu mainMenu = (MainMenu)sender;
            pnlMain.Controls.Remove(mainMenu);
            int temp = mainMenu.index;
            switch (temp)
            {
                case 1:
                    UserProfile userProfile = new UserProfile();
                    userProfile.username = this.username;
                    userProfile.rating = cF.GetSingleIntegerSQL("SELECT Overall_Rating FROM user_details WHERE Username = '" + username + "'",conn);
                    userProfile.backColor = themeBackColor;
                    userProfile.buttonColor = themeButtonColor;
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
                    availableJobsSuper.onRemoveAJS += new AvailableJobsSuper.RemoveAJSEventHandler(RemoveAJSSite_Click);
                    pnlMain.Controls.Add(availableJobsSuper);
                    availableJobsSuper.Location = new Point(pnlMain.Width / 2 - 600, 0);
                    break;
                case 4:
                    break;
                case 5:
                    Settings settings = new Settings();
                    settings.setButtonBackColor(themeButtonColor);
                    settings.setSecKey(sec_key);
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
                    login.onRemoveLogin += new Login.RemoveLoginEventHandler(RemoveLgnSite_Click);
                    pnlMain.Controls.Add(login);
                    login.Location = new Point(pnlMain.Width / 2 - 250, 0);
                    break;
            }
        }
    }
}
