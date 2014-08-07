using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroundTruthing
{
    class AnnotationFrame
    {
        public int cX;
        public int cY;
        public int w;
        public int h;
        /**
         * Annotation to Bounding map, the frame holds a single bounding box for each object in the frame
         **/
        public Hashtable annotationTable = new Hashtable();

        /**
         * Update A refrence point
         **/
        public void UpdateTop(Annotation annotation, int x, int y)
        {
            if (annotationTable[annotation] == null)
            {
                annotationTable[annotation] = new Bounding();
            }

            Bounding currentAnnotationBounding = (Bounding)annotationTable[annotation];
            currentAnnotationBounding.TopLeft_x = x;
            currentAnnotationBounding.TopLeft_y = y;
        }

        /**
         * Update B refrence point
         **/
        public void UpdateBottom(Annotation annotation, int x, int y)
        {
            if (annotationTable[annotation] == null)
            {
                annotationTable[annotation] = new Bounding();
            }

            Bounding currentAnnotationBounding = (Bounding)annotationTable[annotation];
            currentAnnotationBounding.BottomRight_x = x;
            currentAnnotationBounding.BottomRight_y = y;
        }

        /**
         * Check if we have valid A and B refrence
         **/
        public bool AnnotationComplete(Annotation annotation)
        {
            Bounding currentAnnotationBounding = (Bounding)annotationTable[annotation];
            if (currentAnnotationBounding.TopLeft_x == -1 ||
                currentAnnotationBounding.TopLeft_y == -1 ||
                currentAnnotationBounding.BottomRight_x == -1 ||
                currentAnnotationBounding.BottomRight_y == -1)
            {
                return false;
            }
            if(currentAnnotationBounding.TopLeft_x > currentAnnotationBounding.BottomRight_x)
            {
                int temp = currentAnnotationBounding.TopLeft_x;
                UpdateTop(annotation, currentAnnotationBounding.BottomRight_x, currentAnnotationBounding.TopLeft_y);
                UpdateBottom(annotation, temp, currentAnnotationBounding.BottomRight_y);
            }
            if(currentAnnotationBounding.TopLeft_y > currentAnnotationBounding.BottomRight_y)
            {
                int temp =  currentAnnotationBounding.TopLeft_y;
                UpdateTop(annotation, currentAnnotationBounding.TopLeft_x, currentAnnotationBounding.BottomRight_y);
                UpdateBottom(annotation, currentAnnotationBounding.BottomRight_x, temp);
            }
            UpdateFrameInfomrmation(currentAnnotationBounding.TopLeft_x, currentAnnotationBounding.TopLeft_y,
                currentAnnotationBounding.BottomRight_x, currentAnnotationBounding.BottomRight_y);
            return true;
        }

        public void UpdateFrameInfomrmation(int TopLeft_x, int TopLeft_y, int BottomRight_x, int BottomRight_y)
        {
            w = Math.Abs(BottomRight_x - TopLeft_x);
            h = Math.Abs(BottomRight_y - TopLeft_y);
            cX = TopLeft_x + (w / 2);
            cY = TopLeft_y + (h / 2);
            System.Diagnostics.Debug.WriteLine("cX:" + cX + "cY" + cY + "w" + w + "h" + h);
        }
    }
}
