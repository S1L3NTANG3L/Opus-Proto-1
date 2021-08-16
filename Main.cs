using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoutiesSandbox;

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
        public frmMain()
        {
            InitializeComponent();            
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            conn = cF.CreateRemoteSQLConnection("soutiesentrance.ddns.net", "13306", "Rechard", "V<6OD|>!$i]L", "opus_db");
            var temp = cF.ReadFromFile("config.txt");
            string[] tempArr = temp.StringArray;
            sec_key = tempArr[0];
            pickedTheme = tempArr[1];
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            if(pickedTheme == "Dark")
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                materialSkinManager.ColorScheme =  new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.BLACK);
                themeButtonColor = Color.FromArgb(39, 62, 76);
                themeBackColor = Color.FromArgb(50, 50, 50);
            }
            else
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue800, Primary.Cyan800, Primary.LightBlue400, Accent.LightBlue700, TextShade.BLACK);
                themeButtonColor = Color.FromArgb(62, 155, 212);
                themeBackColor = Color.FromArgb(39,124,175);
            }            
            Login lgnForm = new Login();
            lgnForm.setButtonBackColor(themeButtonColor);
            lgnForm.setConnection(conn);
            lgnForm.setBackColor(themeBackColor);
            pnlMain.Controls.Add(lgnForm);
            lgnForm.Location = new Point(pnlMain.Width/2-250, 0);            
            lgnForm.onRemoveLogin += new Login.RemoveLoginEventHandler(RemoveLgnSite_Click);
        }
        private void RemoveLgnSite_Click(Object sender, LoginArgs e)
        {
            Login login = (Login)sender;
            pnlMain.Controls.Remove(login);
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
        private void RemoveMMSite_Click(Object sender, MainMenuArgs e)
        {
            MainMenu mainMenu = (MainMenu)sender;
            pnlMain.Controls.Remove(mainMenu);
            int temp = mainMenu.index;
            switch (temp)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    AvailableJobsSuper availableJobsSuper = new AvailableJobsSuper();
                    availableJobsSuper.setButtonBackColor(themeButtonColor);
                    availableJobsSuper.setConnection(conn);
                    availableJobsSuper.setBackColor(themeBackColor);
                    availableJobsSuper.onRemoveAJS += new AvailableJobsSuper.RemoveAJSEventHandler(RemoveAJSSite_Click);
                    pnlMain.Controls.Add(availableJobsSuper);
                    availableJobsSuper.Location = new Point(pnlMain.Width/2-600,0);
                    break;
                case 4:
                    break;
                case 5:
                    Settings settings = new Settings();
                    settings.setButtonBackColor(themeButtonColor);
                    settings.setSecKey(sec_key);
                    settings.setBackColor(themeBackColor);
                    settings.onRemoveS += new Settings.RemoveSEventHandler(RemoveSSite_Click);
                    pnlMain.Controls.Add(settings);
                    settings.Location = new Point(pnlMain.Width / 2 - 275, 0);
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
}//Create load functions
