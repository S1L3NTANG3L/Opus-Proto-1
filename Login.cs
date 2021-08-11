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
    public partial class Login : UserControl
    {
        public int loginI = 0;
        public delegate void RemoveLoginEventHandler(Object sender, LoginArgs e);
        public event RemoveLoginEventHandler onRemoveLogin;
        public Login()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Add verification etc
            onRemoveLogin(this, new LoginArgs(loginI));
        }
    }
    public class LoginArgs : EventArgs
    {
        public int index;
        public LoginArgs(int value)
        {
            index = value;
        }
    }
}
