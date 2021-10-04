using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2D_Chess
{
    public partial class LogForm : Form
    {
        public bool Hidden { get; private set; } = false;

        private int currentLog { get; set; } = 0;

        public LogForm()
        {
            InitializeComponent();
        }

        public void Toggle(bool state)
        {
            Hidden = state;
            Visible = state;
            Log(Logger.Messages);
        }

        public void Log(List<Logger.LogMessage> messages)
        {
            for(int i = currentLog; i<messages.Count; i++)
            {
                rtfLog.ForeColor = Logger.StatusTextColour[messages[i].Status];
                rtfLog.Text += messages[i].Message + "\n";
            }
            currentLog = messages.Count;
            rtfLog.Select(rtfLog.Text.Length, 0);
            rtfLog.ScrollToCaret();
        }
    }
}
