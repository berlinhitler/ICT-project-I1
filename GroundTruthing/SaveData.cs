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
        private XmlWriter xmlWriter = null;
        private int currentFrameIndex = 0;

        public SaveData(string filename)
        {
            this.filename = filename;
        }

        public bool Save(AnnotationFrame[] frameData)
        {
            xmlWriter = XmlWriter.Create(filename);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("dataset");

            foreach (AnnotationFrame currentFrame in frameData)
            {
                xmlWriter.WriteStartElement("frame");
                xmlWriter.WriteAttributeString("number", "" + currentFrameIndex);
                xmlWriter.WriteEndElement();
                currentFrameIndex++;
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();

            xmlWriter.Flush();
            xmlWriter.Close();

            return true;
        }
    }
}
