using SoutiesSandbox;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Opus_Proto_1
{
    public partial class Settings : UserControl
    {
        CustomFunctions cF = new CustomFunctions();
        private string sec_key;
        private string currencyCode;
        private string pickedTheme;
        public int index = 0;
        public delegate void RemoveSEventHandler(object sender, SettingsArgs e);
        public event RemoveSEventHandler onRemoveS;
        public Settings()
        {
            InitializeComponent();

        }
        private void Settings_Load(object sender, EventArgs e)
        {
            int temp = 0;
            for (int i = 0; i < cmbCurrency.Items.Count; i++)
            {
                if (cmbCurrency.Items[i].ToString() == currencyCode)
                {
                    temp = i;
                    break;
                }
            }
            cmbCurrency.SelectedIndex = temp;
            temp = 0;
            for (int i = 0; i < cmbTheme.Items.Count; i++)
            {
                if (cmbTheme.Items[i].ToString() == pickedTheme)
                {
                    temp = i;
                    break;
                }
            }
            cmbTheme.SelectedIndex = temp;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            onRemoveS(this, new SettingsArgs(index));
        }
        public void setButtonBackColor(Color color)
        {
            btnBack.BackColor = color;
        }
        public void setSecKey(string sec_key)
        {
            this.sec_key = sec_key;
        }
        public void setCurrencyCode(string currencyCode)
        {
            this.currencyCode = currencyCode;
        }
        public void setBackColor(Color color)
        {
            BackColor = color;
        }
        public void setPickedTheme(string pickedTheme)
        {
            this.pickedTheme = pickedTheme;
        }
        public void setVersion(Version version)
        {
            this.lblVersion.Text = String.Format(this.lblVersion.Text, version.Major, version.Minor, version.Build, version.Revision);
        }
        private void cmbTheme_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string[] arrTemp = new string[3];
            arrTemp[0] = sec_key;
            arrTemp[1] = cmbTheme.SelectedItem.ToString();
            arrTemp[2] = currencyCode;
            cF.WriteToFile(arrTemp, "config.dll");
            if (MessageBox.Show("Program needs to restart to apply theme.\nWould you like to exit now?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Restart();
                Environment.Exit(0);
            }
        }
        private void cmbCurrency_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string[] arrTemp = new string[3];
            arrTemp[0] = sec_key;
            arrTemp[1] = pickedTheme;
            arrTemp[2] = cmbCurrency.SelectedItem.ToString();
            cF.WriteToFile(arrTemp, "config.dll");
            if (MessageBox.Show("Program needs to restart to apply theme.\nWould you like to exit now?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Restart();
                Environment.Exit(0);
            }
        }
    }
    public class SettingsArgs : EventArgs
    {
        public int index;
        public SettingsArgs(int value)
        {
            index = value;
        }
    }
}
