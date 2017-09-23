using System;
using System.Collections.Generic;
using System.Text;

namespace TheLiskovSubstitutionPrinciple.ModulesWrongApproach
{
    public class SquareW : ShapeW
    {
        public int SideLength;

        public override int Area()
        {
            return SideLength * SideLength;
        }
    }
}