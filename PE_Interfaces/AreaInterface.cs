using System;
using System.Collections.Generic;
using System.Text;

namespace PE_Interfaces
{
    interface IArea
    {
        // Properties
        double Area { get; }
        double Perimeter { get; }
        // Is an (x,y) coordinate within the area of this object?
        bool ContainsPosition(IPosition position);
        // Is this area larger than the area of another object?
        bool IsLargerThan(IArea areaToCheck);
    }
}
