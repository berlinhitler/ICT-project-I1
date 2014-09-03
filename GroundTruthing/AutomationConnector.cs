using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace GroundTruthing
{
    class AutomationConnector
    {
        [DllImport("imagefunction.dll")]
        public static extern void ProcessImage(byte[] imageStream, Int32 imageStreamSize);
    }
}
