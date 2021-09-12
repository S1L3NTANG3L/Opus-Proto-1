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
    public partial class Registartion : UserControl
    {
        CustomFunctions cF = new CustomFunctions();
        public int index = 0;
        public delegate void RemoveRegEventHandler(object sender, RegistrationArgs e);
        public event RemoveRegEventHandler onRemoveSite;
        private string conn;
        public Registartion()
        {
            InitializeComponent();
        }
        private void Registartion_Load(object sender, EventArgs e)
        {

        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            onRemoveSite(this, new RegistrationArgs(index));
        }
        public void setButtonBackColor(Color color)
        {
            btnSubmit.BackColor = color;
            btnBack.BackColor = color;
        }
        public void setConnection(string conn)
        {
            this.conn = conn;
        }
        public void setBackColor(Color color)
        {
            this.BackColor = color;
            pnlReg.BackColor = color;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            onRemoveSite(this, new RegistrationArgs(index));
        }
    }
    public class RegistrationArgs : EventArgs
    {
        public int index;
        public RegistrationArgs(int value)
        {
            index = value;
        }
    }
}
