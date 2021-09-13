using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Opus_Proto_1
{
    public partial class OpenJobsSuper : UserControl
    {
        public int index = 0;
        Color backColor;
        private Color themeButtonColor;
        private const int SPACERY = 10;
        private const int SPACERX = 75;
        private int totalPageCount;
        private int pageNumber = 1;
        private string conn = "";
        private string currencyCode;
        private int pageShowing = 0;
        private string username;
        public delegate void RemoveOJSEventHandler(object sender, OpenJobsSuperArgs e);
        public event RemoveOJSEventHandler onRemoveOJS;
        public OpenJobsSuper()
        {
            InitializeComponent();
        }
        private void OpenJobsSuper_Load(object sender, EventArgs e)
        {

        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            onRemoveOJS(this, new OpenJobsSuperArgs(index));
        }
        public void setButtonBackColor(Color color)
        {
            btnBack.BackColor = color;
            btnNext.BackColor = color;
            btnPrevious.BackColor = color;
            themeButtonColor = color;
        }
        public void setConnection(string conn)
        {
            this.conn = conn;
        }
        public void setBackColor(Color color)
        {
            this.BackColor = color;
            backColor = color;
        }
        public void setCurrencyCode(string currencyCode)
        {
            this.currencyCode = currencyCode;
        }
        public void setUsername(string username)
        {
            this.username = username;
        }
    }
    public class OpenJobsSuperArgs : EventArgs
    {
        public int index;
        public OpenJobsSuperArgs(int value)
        {
            index = value;
        }
    }
}
