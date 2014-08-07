using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroundTruthing
{
    public class Bounding
    {
        public int TopLeft_x;
        public int TopLeft_y;
        public int BottomRight_x;
        public int BottomRight_y;

        public Bounding(Bounding other)
        {
            TopLeft_x = other.TopLeft_x;
            TopLeft_y = other.TopLeft_y;
            BottomRight_x = other.BottomRight_x;
            BottomRight_y = other.BottomRight_y;
        }

        public Bounding()
        {
            TopLeft_x = -1;
            TopLeft_y = -1;
            BottomRight_x = -1;
            BottomRight_y = -1;
        }
    }
}
