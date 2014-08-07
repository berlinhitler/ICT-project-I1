using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace GroundTruthing
{
    class LoadData
    {

        /**
         * the name of the loaded file
         **/
        public string selectedFilename = "";

        /**
         * the list of annotation objects
         **/
        private LinkedList<Annotation> loadedAnnotations = new LinkedList<Annotation>();

        /**
         * the list of loaded frames
         **/
        public LinkedList<AnnotationFrame> loadedFrames = new LinkedList<AnnotationFrame>();

        /**
         * the current read frame
         **/
        private AnnotationFrame currentFrame = null;

        /**
         * the current object
         **/
        private Annotation currentObject = null;

        /**
         * just do nothing for now
         **/
        public LoadData()
        {
        }

        /**
         * read in the file content and start parsing
         **/
        public bool OpenFile()
        {
            OpenFileDialog fileSelector = new OpenFileDialog();

            if (fileSelector.ShowDialog() == DialogResult.OK)
            {
                return ParseFile(fileSelector.FileName);
            }

            else
            {
                return false;
            }
        }

        /**
         * return all the frames we have read
         **/
        public AnnotationFrame[] GetFrames()
        {
            AnnotationFrame[] returnArray = new AnnotationFrame[loadedFrames.Count];
            for (int i = 0; i < loadedFrames.Count; i++)
            {
                returnArray[i] = loadedFrames.ElementAt(i);
            }

            return returnArray;
        }

        /**
         * determine all unique actors
         **/
        public LinkedList<Annotation> ExtractActors()
        {
            return loadedAnnotations;
        }

        /**
         * parse the selected file
         **/
        private bool ParseFile(string filename)
        {
            XmlReader xmlFileReader = XmlReader.Create(filename);

            while (xmlFileReader.Read())
            {
                if (xmlFileReader.IsStartElement())
                {
                    switch (xmlFileReader.Name)
                    {
                        case "frame":
                            AddFrame();
                            break;

                        case "object":
                            AddObject(Int32.Parse(xmlFileReader["id"]), xmlFileReader["name"]);
                            break;

                        case "box":
                            AddBox( Int32.Parse(xmlFileReader["h"]),
                                    Int32.Parse(xmlFileReader["w"]),
                                    Int32.Parse(xmlFileReader["xc"]),
                                    Int32.Parse(xmlFileReader["yc"])    );
                            break;
                    }
                }
            }

            return true;
        }

        /**
         * move to the next frame
         **/
        private void AddFrame()
        {
            AnnotationFrame newFrame = new AnnotationFrame();
            currentFrame = newFrame;
            loadedFrames.AddLast(newFrame);
        }

        /**
         * move to the next object
         **/
        private void AddObject(int objectID, string name)
        {
            Annotation newAnnotation = GenerateAnnotation(name);
            newAnnotation.id = objectID;
            currentObject = newAnnotation;
        }

        /**
         * move to the add a bounding on the current frame for the current object
         **/
        private void AddBox(int height, int width, int centerX, int centerY)
        {
            Bounding newBounding = new Bounding();

            newBounding.TopLeft_x = centerX - (width / 2);
            newBounding.TopLeft_y = centerY - (height / 2);
            newBounding.BottomRight_x = centerX + (width / 2);
            newBounding.BottomRight_y = centerY + (height / 2);

            currentFrame.annotationTable[currentObject] = newBounding;
        }

        /**
         * Generate an annotation if none exist otherwise return the existing one
         **/
        private Annotation GenerateAnnotation(string name)
        {
            foreach (Annotation currentAnnotation in loadedAnnotations)
            {
                if (currentAnnotation.name == name)
                {
                    return currentAnnotation;
                }
            }

            Annotation returnAnnotation = new Annotation();
            returnAnnotation.name = name;
            loadedAnnotations.AddLast(returnAnnotation);
            return returnAnnotation;
        }
    }
}
