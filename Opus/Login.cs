using SoutiesSandbox;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Opus_Proto_1
{
    public partial class Login : UserControl
    {
        public int index = 0;
        public delegate void RemoveLoginEventHandler(Object sender, LoginArgs e);
        public event RemoveLoginEventHandler onRemoveLogin;
        public delegate void LoadRegEventHandler(Object sender, LoginArgs e);
        public event LoadRegEventHandler LoadReg;
        private CustomFunctions cF = new CustomFunctions();
        private string conn;
        private string sec_key;
        private string username;
        public Login()
        {
            InitializeComponent();
            lblInvalid.Visible = false;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }
        public void setButtonBackColor(Color color)
        {
            btnLogin.BackColor = color;
            btnRegister.BackColor = color;
            btnView.BackColor = color;
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
        private void btnView_Click(object sender, EventArgs e)
        {
            if (edtPassword.UseSystemPasswordChar)
            {
                edtPassword.UseSystemPasswordChar = false;
                edtPassword.PasswordChar = '\0';
            }
            else
            {
                edtPassword.UseSystemPasswordChar = true;
                edtPassword.PasswordChar = '*';
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((this.ActiveControl == edtPassword) && (keyData == Keys.Return))
            {
                login();
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }
        private void login()
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
                + " Email  = '" + edtUsername.Text.ToLower() + "'", conn) == 0)
            {
                lblInvalid.Visible = true;
            }
            else if (cF.DecryptCipherTextToPlainText(cF.GetSingleStringSQL(
                "SELECT Password FROM user_details WHERE Username  = '" + edtUsername.Text + "' OR"
                + " Email  = '" + edtUsername.Text.ToLower() + "'", conn), sec_key) != edtPassword.Text)
            {
                lblInvalid.Visible = true;
            }
            else
            {
                username = cF.GetSingleStringSQL("SELECT Username FROM user_details WHERE Username  = '" + edtUsername.Text + "' OR"
                + " Email  = '" + edtUsername.Text.ToLower() + "'", conn);
                onRemoveLogin(this, new LoginArgs(index));
            }
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

        
    
