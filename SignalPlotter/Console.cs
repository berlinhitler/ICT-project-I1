using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace SignalPlotter
{
    public partial class Console : Form
    {
        private Network.NetworkInterfaceFactory nf = new Network.NetworkInterfaceFactory();
        private List<SignalView> signals = new List<SignalView>();

        private Toolkit.Debugger debugger = null;
        private SignalView bigpondMeter = null;

        public Console()
        {
            InitializeComponent();
            Natives.WirelessNatives.Initalize();
            debugger = new Toolkit.Debugger(richTextBox1);
        }

        private void Console_Load(object sender, EventArgs e)
        {
            SignalView myBigpondMeter = new SignalView("BigPond0D14");
            signals.Add(myBigpondMeter);

            SignalView n1BigpondMeter = new SignalView("BigPond0D3B");
            signals.Add(n1BigpondMeter);

            SignalView n2BigpondMeter = new SignalView("NETGEAR59");
            signals.Add(n2BigpondMeter);

            flowLayoutPanel1.Controls.Add(myBigpondMeter);
            flowLayoutPanel1.Controls.Add(n1BigpondMeter);
            flowLayoutPanel1.Controls.Add(n2BigpondMeter);

            timer1.Start();
            nf.InitalizeAdapters(debugger);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Natives.WirelessNatives.PollAdapter();
            bigpondMeter.UpdateSignalReading();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Natives.WirelessNatives.PollAdapter();
            //bigpondMeter.UpdateSignalReading();

            foreach(SignalView sv in signals)
            {
                sv.UpdateSignalReading();
            }

        }

    }

}
