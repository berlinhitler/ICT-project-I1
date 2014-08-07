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
                if (currentFrame == null)
                {
                    continue;
                }

                xmlWriter.WriteStartElement("frame");
                xmlWriter.WriteAttributeString("number", "" + currentFrameIndex);

                xmlWriter.WriteStartElement("objectlist");

                foreach (Annotation annotation in currentFrame.annotationTable.Keys)
                {
                    xmlWriter.WriteStartElement("object");
                    xmlWriter.WriteAttributeString("id", "" + annotation.id);

                    Bounding currentAnnotationBounding = (Bounding)currentFrame.annotationTable[annotation];
                    xmlWriter.WriteStartElement("box");

                    //height
                    int width = currentAnnotationBounding.BottomRight_x - currentAnnotationBounding.Topleft_x;
                    int height = currentAnnotationBounding.BottomRight_y - currentAnnotationBounding.TopLeft_y;

                    xmlWriter.WriteAttributeString("h", "" + height);
                    xmlWriter.WriteAttributeString("w", "" + width);
                    // TODO: calc center 
                    xmlWriter.WriteAttributeString("xc", "" + (currentAnnotationBounding.Topleft_x + (width / 2)));
                    xmlWriter.WriteAttributeString("yc", "" + (currentAnnotationBounding.TopLeft_y + (height / 2)));
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();

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
