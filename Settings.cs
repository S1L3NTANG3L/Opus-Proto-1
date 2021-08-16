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
    public partial class Settings : UserControl
    {
        CustomFunctions cF = new CustomFunctions();
        private string sec_key;
        public int index = 0;
        public delegate void RemoveSEventHandler(object sender, SettingsArgs e);
        public event RemoveSEventHandler onRemoveS;
        public Settings()
        {
            InitializeComponent();
        }
        private void cmbTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] arrTemp = new string[2];
            arrTemp[0] = sec_key;
            if(cmbTheme.SelectedIndex == 0)
            {
                arrTemp[1] = "Light";
                cF.WriteToFile(arrTemp, "config.txt");
            }
            else
            {
                arrTemp[1] = "Dark";
                cF.WriteToFile(arrTemp, "config.txt");
            }
            if (MessageBox.Show("Program needs to restart to apply theme.\nWould you like to exit now?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
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
        public void setBackColor(Color color)
        {
            BackColor = color;
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
