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
            pnlMain.Controls.Add(lgnForm);
            lgnForm.Location = new Point(pnlMain.Width/2-252, 0);
            lgnForm.onRemoveSite += new Login.RemoveSiteEventHandler(RemoveSite_Click);
        }
        private void RemoveSite_Click(Object sender, LoginArgs e)
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
            AvailableJobsSuper availableJobsSuper = new AvailableJobsSuper();
            pnlMain.Controls.Add(availableJobsSuper);
            availableJobsSuper.Location = new Point(pnlMain.Width / 2 - 252, 0);
        }
    }
}//Create load functions
