using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GroundTruthing
{
    public class Annotation
    {
        /**
         * Annotation identifier
         **/
        public int id;

        /**
         * Annotation short name
         **/
        public string name;

        /**
         * Visual representation
         **/
        public Color color;

        /**
         * Used when placed in a list
         **/
        public override string ToString()
        {
            return name;
        }
    }
}
