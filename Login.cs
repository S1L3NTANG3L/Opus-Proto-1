using SoutiesSandbox;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Opus_Proto_1
{
    public partial class Login : UserControl
    {
        CustomFunctions cF = new CustomFunctions();
        private string conn;
        private string sec_key;
        private string username;
        public int index = 0;
        public delegate void RemoveLoginEventHandler(Object sender, LoginArgs e);
        public event RemoveLoginEventHandler onRemoveLogin;
        public delegate void LoadRegEventHandler(Object sender, LoginArgs e);
        public event LoadRegEventHandler LoadReg;
        public Login()
        {
            InitializeComponent();
            lblInvalid.Visible = false;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblInvalid.Visible = false;
            if (edtPassword.Text == "")
            {
                lblInvalid.Visible = true;
            }
            else if (edtUsername.Text == "")
            {
                lblInvalid.Visible = true;
            }
            else if (cF.GetCountSQL("SELECT COUNT(Name) FROM user_details WHERE Username  = '" + edtUsername.Text + "' OR"
                +" Email  = '" + edtUsername.Text.ToLower() + "'", conn) == 0)
            {
                lblInvalid.Visible = true;
            }            
            else if (cF.DecryptCipherTextToPlainText(cF.GetSingleStringSQL(
                "SELECT Password FROM user_details WHERE Username  = '" + edtUsername.Text + "' OR"
                +" Email  = '" + edtUsername.Text.ToLower() + "'", conn), sec_key) != edtPassword.Text)
            {
                lblInvalid.Visible = true;
            }
            else
            {
                username = edtUsername.Text;
                onRemoveLogin(this, new LoginArgs(index));
            }
        }
        public void setButtonBackColor(Color color)
        {
            btnLogin.BackColor = color;
            btnRegister.BackColor = color;
        }
        public void setConnection(string conn)
        {
            this.conn = conn;
        }
        public void setBackColor(Color color)
        {
            BackColor = color;
        }
        public void setSecCode(string value)
        {
            sec_key = value;
        }
        public string getUsername()
        {
            return username;
        }  
        private void btnRegister_Click(object sender, EventArgs e)
        {
            LoadReg(this, new LoginArgs(index));
        }
    }
    public class LoginArgs : EventArgs
    {
        public int index;
        public LoginArgs(int iValue)
        {
            index = iValue;
        }
    }
}
