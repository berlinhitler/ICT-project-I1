using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using SignalPlotter.Toolkit;

namespace SignalPlotter.Network
{
    class NetworkInterfaceFactory
    {
        Dictionary<string, ManagementObject> managmentObjects = new Dictionary<string, ManagementObject>();
        Dictionary<string, System.Net.NetworkInformation.NetworkInterface> networkObjects = new Dictionary<string, System.Net.NetworkInformation.NetworkInterface>();
        Dictionary<string, Network.NetworkInterface> networkInterfaces = new Dictionary<string, NetworkInterface>();
        HashSet<string> locatedGUIDs = new HashSet<string>();

        public NetworkInterfaceFactory()
        {
        }

        public bool InitalizeAdapters(Debugger targetDebugger)
        {
            managmentObjects.Clear();
            networkObjects.Clear();
            networkInterfaces.Clear();

            ManagementObjectCollection networkObjectCollection = GetManagmentObjectCollection();
            System.Net.NetworkInformation.NetworkInterface[] adapters = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
            
            bool orphanedGUID = false;

            foreach (ManagementObject mo in networkObjectCollection)
            {
                if (mo["AdapterType"].ToString().Equals("Ethernet 802.3") && mo["GUID"] != null)
                {
                    locatedGUIDs.Add(mo["GUID"].ToString());
                    managmentObjects.Add(mo["GUID"].ToString(), mo);
                }
            }

            foreach (System.Net.NetworkInformation.NetworkInterface adapter in adapters)
            {
                locatedGUIDs.Add(adapter.Id);
                networkObjects.Add(adapter.Id, adapter);
            }

            foreach (string guid in locatedGUIDs)
            {
                if (managmentObjects.ContainsKey(guid) && networkObjects.ContainsKey(guid))
                {
                    // Create interface
                    Network.NetworkInterface instanceNetworkInterface = new NetworkInterface(targetDebugger, managmentObjects[guid], networkObjects[guid]);
                    networkInterfaces.Add(guid, instanceNetworkInterface);
                    targetDebugger.WriteLine("Interface " + instanceNetworkInterface.ToString() + " added to the interface pool.");
                }
                else
                {
                    orphanedGUID = true;
                    targetDebugger.WriteLine("Orphaned GUID: " + guid + " [NetworkInterfaceFactory]");
                }
            }

            return !orphanedGUID;
        }

        public HashSet<string> AdapterGUIDs()
        {
            return locatedGUIDs;
        }

        public Network.NetworkInterface GetInterface(string guid)
        {
            return networkInterfaces[guid];
        }

        public ManagementObjectCollection GetManagmentObjectCollection()
        {
            ManagementScope wmiSrv;
            ManagementObjectSearcher objSearcher;
            ManagementObjectCollection objColl;
            ObjectQuery objQuery;

            ConnectionOptions connOpts = new ConnectionOptions();
            objQuery = new ObjectQuery("SELECT * FROM Win32_NetworkAdapter WHERE AdapterTypeID <> NULL");
            wmiSrv = new ManagementScope(@"root\cimv2", connOpts);
            wmiSrv.Connect();
            objSearcher = new ManagementObjectSearcher(wmiSrv, objQuery);
            objSearcher.Options.Timeout = new TimeSpan(0, 0, 0, 0, 7000);
            objColl = objSearcher.Get();
            return objColl;
        }
    }
}
