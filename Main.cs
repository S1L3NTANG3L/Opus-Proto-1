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
        Login lgnForm = new Login();
        AvailableJobsSuper ajsForm = new AvailableJobsSuper();
        MainMenu mmForm = new MainMenu();       
        public frmMain()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {           
            pnlMain.Controls.Add(lgnForm);
            lgnForm.Location = new Point(pnlMain.Width/2-252, 0);
            lgnForm.onRemoveSite += new Login.RemoveSiteEventHandler(RemoveLgnSite_Click);
            ajsForm.onRemoveSite += new AvailableJobsSuper.RemoveSiteEventHandler(RemoveAJSSite_Click);
            mmForm.onRemoveSite += new MainMenu.RemoveSiteEventHandler(RemoveMMSite_Click);
        }
        private void RemoveLgnSite_Click(Object sender, LoginArgs e)
        {
            Login login = (Login)sender;
            Login update;
            for (int i = e.index; i < pnlMain.Controls.Count; i++)
            {
                update = (Login)pnlMain.Controls[i];
                update.Location = new Point(0,0);
                update.index = i;
            }
            pnlMain.Controls.Remove(login);
            MainMenu mainMenu = new MainMenu();
            pnlMain.Controls.Add(mainMenu);
            mainMenu.Location = new Point(pnlMain.Width / 2 - 252, 0);
        }
        private void RemoveAJSSite_Click(Object sender, AvailableJobsSuperArgs e)
        {
            AvailableJobsSuper jobsSuper = (AvailableJobsSuper)sender;
            AvailableJobsSuper update;
            for (int i = e.index; i < pnlMain.Controls.Count; i++)
            {
                update = (AvailableJobsSuper)pnlMain.Controls[i];
                update.Location = new Point(0, 0);
                update.index = i;
            }
            pnlMain.Controls.Remove(jobsSuper);
            MainMenu mainMenu = new MainMenu();
            pnlMain.Controls.Add(mainMenu);
            mainMenu.Location = new Point(pnlMain.Width / 2 - 252, 0);
        }
        private void gotoAvailable_Click(Object sender, MainMenuArgs e)
        {
            MainMenu mainMenu = (MainMenu)sender;
            MainMenu update;
            for (int i = e.index; i < pnlMain.Controls.Count; i++)
            {
                update = (MainMenu)pnlMain.Controls[i];
                update.Location = new Point(0, 0);
                update.index = i;
            }
            pnlMain.Controls.Remove(mainMenu);
            AvailableJobsSuper availableJobsSuper = new AvailableJobsSuper();
            pnlMain.Controls.Add(availableJobsSuper);
            availableJobsSuper.Location = new Point(pnlMain.Width / 2 - 252, 0);
        }
        private void gotoLogin_Click(Object sender, MainMenuArgs e)
        {
            MainMenu mainMenu = (MainMenu)sender;
            MainMenu update;
            for (int i = e.index; i < pnlMain.Controls.Count; i++)
            {
                update = (MainMenu)pnlMain.Controls[i];
                update.Location = new Point(0, 0);
                update.index = i;
            }
            pnlMain.Controls.Remove(mainMenu);
            Login login = new Login();
            pnlMain.Controls.Add(login);
            login.Location = new Point(pnlMain.Width / 2 - 252, 0);
        }
        private void RemoveMMSite_Click(Object sender, MainMenuArgs e)
        {
            MainMenu mainMenu = (MainMenu)sender;
            MainMenu update;
            for (int i = e.index; i < pnlMain.Controls.Count; i++)
            {
                update = (MainMenu)pnlMain.Controls[i];
                update.Location = new Point(0, 0);
                update.index = i;
            }
            pnlMain.Controls.Remove(mainMenu);
            int temp = mmForm.index;
            switch(temp)
            {
                case 1:                    
                    break;
                case 2:                    
                    break;
                case 3:
                    AvailableJobsSuper availableJobsSuper = new AvailableJobsSuper();
                    pnlMain.Controls.Add(availableJobsSuper);
                    availableJobsSuper.Location = new Point(pnlMain.Width / 2 - 252, 0);
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    Login login = new Login();
                    pnlMain.Controls.Add(login);
                    login.Location = new Point(pnlMain.Width / 2 - 252, 0);
                    break;

            }
        }
    }
}//Create load functions
