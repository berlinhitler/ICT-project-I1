using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SignalPlotter.Natives
{
    class WirelessNatives
    {
        [DllImport("WirelessNatives.dll")]
        public static extern void Initalize();

        [DllImport("WirelessNatives.dll")]
        public static extern void PollAdapter();

        [DllImport("WirelessNatives.dll")]
        public static extern int GetRSSI(string ssid);
    }
}
