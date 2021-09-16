using SoutiesSandbox;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Opus_Proto_1
{
    public partial class Registartion : UserControl
    {        
        public int index = 0;
        public delegate void RemoveRegEventHandler(object sender, RegistrationArgs e);
        public event RemoveRegEventHandler onRemoveSite;
        private string conn;
        private string sec_code;
        private CustomFunctions cF = new CustomFunctions();
        public Registartion()
        {
            InitializeComponent();
        }
        private void Registartion_Load(object sender, EventArgs e)
        {
            lblInvalid.Visible = false;
            lblInvalidUsername.Visible = false;
            lblPasswordMatch.Visible = false;
            lblLength.Visible = false;
            lblEmail.Visible = false;
            edtPassword.UseSystemPasswordChar = true;
            edtConfirm.UseSystemPasswordChar = true;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            lblInvalid.Visible = false;
            lblInvalidUsername.Visible = false;
            lblPasswordMatch.Visible = false;
            lblLength.Visible = false;
            lblEmail.Visible = false;
            int number;
            bool flag = true;
            if (edtAddress.Text == "" || edtConfirm.Text == "" || edtEmail.Text == "" || edtId.Text == "" || edtName.Text == "" ||
                edtNumber.Text == "" || edtPassword.Text == "" || edtProvince.Text == "" || edtSurname.Text == "" || edtTown.Text == "" ||
                edtUsername.Text == "" || edtZip.Text == "")
            {
                lblInvalid.Visible = true;
                flag = false;
            }
            else if (edtPassword.Text != edtConfirm.Text)
            {
                flag = false;
                lblPasswordMatch.Visible = true;
            }
            else if (cF.LuhnAlgorithm(edtId.Text))
            {
                flag = false;
                lblInvalid.Visible = true;
                MessageBox.Show("Id");
            }
            else if (!int.TryParse(edtNumber.Text, out number))
            {
                flag = false;
                lblInvalid.Visible = true;
            }
            else if (edtNumber.TextLength != 9)
            {
                flag = false;
                lblInvalid.Visible = true;
            }
            else if (!cF.EmailVerification(edtEmail.Text))
            {
                flag = false;
                lblInvalid.Visible = true;
            }
            else if (cF.GetCountSQL("SELECT COUNT(Name) FROM user_details WHERE Username = '" + edtUsername.Text.ToLower() + "'", conn) > 0)
            {
                flag = false;
                lblInvalidUsername.Visible = true;
            }
            else if (cF.GetCountSQL("SELECT COUNT(Name) FROM user_details WHERE Email = '" + edtEmail.Text + "'", conn) > 0)
            {
                flag = false;
                lblEmail.Visible = true;
            }
            else if (edtPassword.TextLength < 8)
            {
                flag = false;
                lblLength.Visible = true;
            }
            if (flag)
            {
                cF.NonQuerySQL("INSERT INTO user_details VALUES('" + edtUsername.Text + "','" + edtName.Text + "','" + edtSurname.Text + "'"
                    + ",'" + edtEmail.Text.ToLower() + "','" + edtId.Text + "','" + cF.EncryptPlainTextToCipherText(edtPassword.Text, sec_code) + "'"
                    + ",0,0,0,'" + edtNumber.Text + "','" + edtAddress.Text + "','" + edtTown.Text + "','" + edtProvince.Text + "'"
                    + ",'" + edtZip.Text + "','" + DateTime.Now.ToShortDateString() + "')", conn);
                onRemoveSite(this, new RegistrationArgs(index));
            }
        }
        public void setButtonBackColor(Color color)
        {
            btnSubmit.BackColor = color;
            btnBack.BackColor = color;
            btnCreatePassword.BackColor = color;
            btnView.BackColor = color;
            btnView2.BackColor = color;
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
        public void setSecCode(string value)
        {
            sec_code = value;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            onRemoveSite(this, new RegistrationArgs(index));
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
        private void btnView2_Click(object sender, EventArgs e)
        {
            if (edtConfirm.UseSystemPasswordChar)
            {
                edtConfirm.UseSystemPasswordChar = false;
                edtConfirm.PasswordChar = '\0';
            }
            else
            {
                edtConfirm.UseSystemPasswordChar = true;
                edtConfirm.PasswordChar = '*';
            }
        }
        private void btnCreatePassword_Click(object sender, EventArgs e)
        {
            string password = cF.RandomPasswordGenerator((int)nudPasswordLength.Value);
            edtPassword.Text = edtConfirm.Text = password;
        }
        private void pbProfilePicture_Click(object sender, EventArgs e)
        {
            try
            {
                if (opnfdPicture.ShowDialog() == DialogResult.OK)
                {
                    opnfdPicture.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                    pbProfilePicture.Image = new Bitmap(opnfdPicture.FileName);
                    pbProfilePicture.Image.Save(Application.StartupPath + "\\Config\\DefaultPP.png", ImageFormat.Png);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to change picture.\n" + ex.Message, ex.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
