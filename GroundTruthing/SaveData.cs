using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GroundTruthing
{
    class SaveData
    {
        private string filename = "";
        private XmlDocument xmlDoc = null;

        public SaveData(string filename)
        {
            this.filename = filename;
        }

        public bool Save()
        {
            return true;
        }
    }
}
