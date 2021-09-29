using SoutiesSandbox;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Opus_Proto_1
{
    public partial class Settings : UserControl
    {
        public int index = 0;
        public delegate void RemoveSEventHandler(object sender, SettingsArgs e);
        public event RemoveSEventHandler onRemoveS;
        private CustomFunctions cF = new CustomFunctions();
        private string currencyCode;
        private string pickedTheme;        
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
            writeToConfig();
        }
        private void cmbCurrency_SelectionChangeCommitted(object sender, EventArgs e)
        {
            writeToConfig();
        }
        public void writeToConfig()
        {
            string[] arrTemp = new string[2];
            arrTemp[0] = cmbTheme.SelectedItem.ToString();
            arrTemp[1] = cmbCurrency.SelectedItem.ToString();
            cF.WriteToFile(arrTemp, "\\Config\\config.dll");
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
