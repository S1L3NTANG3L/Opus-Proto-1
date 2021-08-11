using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Opus_Proto_1
{
    public partial class frmMain : Form
    {             
        public frmMain()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Login lgnForm = new Login();
            AvailableJobsSuper ajsForm = new AvailableJobsSuper();
            MainMenu mmForm = new MainMenu();
            pnlMain.Controls.Add(lgnForm);
            lgnForm.Location = new Point(pnlMain.Width/2-252, 0);            
            lgnForm.onRemoveLogin += new Login.RemoveLoginEventHandler(RemoveLgnSite_Click);
        }
        private void RemoveLgnSite_Click(Object sender, LoginArgs e)
        {
            Login login = (Login)sender;
            pnlMain.Controls.Remove(login);
            MainMenu mainMenu = new MainMenu();
            mainMenu.onRemoveSite += new MainMenu.RemoveMMEventHandler(RemoveMMSite_Click);
            pnlMain.Controls.Add(mainMenu);
            mainMenu.Location = new Point(pnlMain.Width / 2 - 252, 0);
        }
        private void RemoveAJSSite_Click(Object sender, AvailableJobsSuperArgs e)
        {
            AvailableJobsSuper jobsSuper = (AvailableJobsSuper)sender;
            pnlMain.Controls.Remove(jobsSuper);
            MainMenu mainMenu = new MainMenu();
            pnlMain.Controls.Add(mainMenu);
            mainMenu.Location = new Point(pnlMain.Width / 2 - 252, 0);
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
                    availableJobsSuper.onRemoveAJS += new AvailableJobsSuper.RemoveAJSEventHandler(RemoveAJSSite_Click);
                    pnlMain.Controls.Add(availableJobsSuper);
                    availableJobsSuper.Location = new Point(pnlMain.Width / 2 - 252, 0);
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    Login login = new Login();
                    login.onRemoveLogin += new Login.RemoveLoginEventHandler(RemoveLgnSite_Click);
                    pnlMain.Controls.Add(login);
                    login.Location = new Point(pnlMain.Width / 2 - 252, 0);
                    break;
            }
        }
    }
}//Create load functions
