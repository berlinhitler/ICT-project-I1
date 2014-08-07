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

        public Bounding()
        {
            TopLeft_x = -1;
            TopLeft_y = -1;
            BottomRight_x = -1;
            BottomRight_y = -1;
        }
    }
}
