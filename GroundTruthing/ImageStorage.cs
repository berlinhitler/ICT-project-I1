using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace GroundTruthing
{
    public class ImageStorage
    {
        /**
         * The directory in which to search for jpg images
         **/
        private string workingDirectory;

        /**
         * List of images we have found in the working directory
         **/
        private string[] identifiedFiles;

        /**
         * Just save the working directory in the constructor
         **/
        public ImageStorage(string workingDirectory)
        {
            this.workingDirectory = workingDirectory;
        }

        /**
         * Scan the working directory and append the name of the found file to the list, clear the list in the process
         **/
        public bool Scan()
        {
            if (!Directory.Exists(workingDirectory))
            {
                return false;
            }

            identifiedFiles = Directory.GetFiles(workingDirectory, "*.jpg");

            if (identifiedFiles.Length == 0)
            {
                return false;
            }

            return true;
        }

        /**
         * Retrieve the number of files we have found
         **/
        public int FileCount()
        {
            return identifiedFiles.Length;
        }

        /**
         * Retrieve the number of files we have found
         **/
        public string GetWorkingDirectory()
        {
            return workingDirectory;
        }

        /**
         * Load the image from the file system, using the filename in the array at @index
         **/
        public Image ReadImage(int index)
        {
            try
            {
                if (index >= identifiedFiles.Length)
                {
                    return Bitmap.FromFile(identifiedFiles.Last());
                }

                if (index < 0)
                {
                    return Bitmap.FromFile(identifiedFiles.First()); 
                }

                return Bitmap.FromFile(identifiedFiles[index]);
            }
            catch (FileNotFoundException ex)
            {
                Debug.WriteLine(ex.Message);
                return DefaultImage();
            }
        }

        /**
         * Just a plain image, default is red
         **/
        public static Image DefaultImage()
        {
            Bitmap bmp = new Bitmap(1024, 1024);
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle ImageSize = new Rectangle(0, 0, 1024, 1024);
                graph.FillRectangle(Brushes.Red, ImageSize);
            }
            return bmp;
        }
    }
}
