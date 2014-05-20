using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SignalPlotter
{
    public partial class SignalView : UserControl
    {
        private string ssid;
        private static int count = 0;

        Color[] colors = new Color[] { 
            Color.Red,
            Color.Gray,
            Color.Yellow
        };

        public SignalView(string ssid)
        {
            InitializeComponent();
            this.ssid = ssid;
            count %= 3;
            count++;
            this.BackColor = colors[count-1];
        }

        private void SignalView_Load(object sender, EventArgs e)
        {
            lbSSID.Text = this.ssid;
        }

        public void UpdateSignalReading()
        {
            int recievedRSSI = Natives.WirelessNatives.GetRSSI(ssid);
            lbRSSIResult.Text = "" + recievedRSSI;
            lbDistanceResult.Text = "" + calculateDistance((double)recievedRSSI, 2400000);
        }

        public double calculateDistance(double signalLevelInDb, double freqInMHz)
        {
            double exp = (27.55 - (20 * Math.Log10(freqInMHz)) - signalLevelInDb) / 20.0;
            return Math.Pow(10.0, exp);
        }
    }
}
