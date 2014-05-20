using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using SignalPlotter.Toolkit;

namespace SignalPlotter.Network
{
    class NetworkInterface
    {
        private Debugger debuggingInstance = null;
        private ManagementObject managmentObject = null;
        private System.Net.NetworkInformation.NetworkInterface niNetworkInterface = null;

        public NetworkInterface(Debugger debuggingInstance, ManagementObject managmentObject,
            System.Net.NetworkInformation.NetworkInterface niNetworkInterface)
        {
            this.debuggingInstance = debuggingInstance;
            if (managmentObject["GUID"].ToString() != niNetworkInterface.Id)
            {
                debuggingInstance.WriteLine("GUID specified in ManagementObject and NetworkInformation.NetworkInterface do not match, this is an internal error. [NetworkInterface]");
            }
            this.managmentObject = managmentObject;
            this.niNetworkInterface = niNetworkInterface;
        }

        public override string ToString()
        {
            return this.niNetworkInterface.Description;
        }
    }
}
