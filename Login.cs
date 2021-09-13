using SoutiesSandbox;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Opus_Proto_1
{
    public partial class Login : UserControl
    {
        CustomFunctions cF = new CustomFunctions();
        string conn;
        public int index = 0;
        public int buttonPressed;
        public delegate void RemoveLoginEventHandler(Object sender, LoginArgs e);
        public event RemoveLoginEventHandler onRemoveLogin;
        public Login()
        {
            InitializeComponent();
            lblInvalid.Visible = false;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //conn = cF.CreateRemoteSQLConnection("10.100.100.15", "13306", "Rechard", "V<6OD|>!$i]L", "opus_db");
            //if (edtPassword.Text == "")
            //{
            //    lblInvalid.Visible = true;
            //}
            //else if (edtUsername.Text == "")
            //{
            //    lblInvalid.Visible = true;
            //}
            //else if (cF.GetCountSQL("SELECT COUNT(Username) FROM student_responses_table WHERE student_number = '"
            //    + edtUsername.Text + "'", conn) == 0)//Need to change
            //{
            //    lblInvalid.Visible = true;
            //}
            //else if (cF.DecryptCipherTextToPlainText(cF.GetSingleStringSQL(
            //    "SELECT student_password FROM student_responses_table WHERE student_number = '" + edtUsername.Text + "'",//Need to change
            //    conn), sec_key) != edtPassword.Text)
            //{
            //    lblInvalid.Visible = true;
            //}
            //else
            //{
            //    onRemoveLogin(this, new LoginArgs(index));
            //}
            buttonPressed = 1;
            onRemoveLogin(this, new LoginArgs(index));
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
        public string username
        {
            //get { return edtUsername.Text; }
            get { return "RECHARD1"; }//Remember to change this
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            buttonPressed = 2;
            onRemoveLogin(this, new LoginArgs(index));
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
