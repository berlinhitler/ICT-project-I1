using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroundTruthing
{
    class AnnotationFrame
    {
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
            currentAnnotationBounding.Topleft_x = x;
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
            if (currentAnnotationBounding.Topleft_x == -1 ||
                currentAnnotationBounding.TopLeft_y == -1 ||
                currentAnnotationBounding.BottomRight_x == -1 ||
                currentAnnotationBounding.BottomRight_y == -1)
            {
                return false;
            }

            return true;
        }
    }
}
