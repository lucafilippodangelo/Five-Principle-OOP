using System;
using System.Collections.Generic;
using System.Text;

namespace TheLiskovSubstitutionPrinciple.ModulesWrongApproach
{
    public class RectangleW : ShapeW
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public RectangleW(){ }

        public override int Area()
        {
            return Height * Width;
        }
    }
}
