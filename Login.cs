using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using SoutiesSandbox;

namespace Opus_Proto_1
{
    public partial class Login : UserControl
    {
        CustomFunctions cF = new CustomFunctions();
        string conn;
        public int index = 0;
        string sec_key;
        public delegate void RemoveLoginEventHandler(Object sender, LoginArgs e);
        public event RemoveLoginEventHandler onRemoveLogin;
        public Login()
        {
            InitializeComponent();
            btnLogin.BackColor = Color.FromArgb(39, 62, 76);
            lblInvalid.Visible = false;
            var temp = cF.ReadFromFile("Sec_key.txt");
            string[] tempArr = temp.StringArray;
            sec_key = tempArr[0];
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
            onRemoveLogin(this, new LoginArgs(index));
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
