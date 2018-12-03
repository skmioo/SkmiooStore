using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Rect
{
    public double X { get; }
    public double Y { get; }
    public double Width { get;  }
    public double Height { get;  }

    public Rect(double _x, double _y, double _width, double _height)
    {
        X = _x;
        Y = _y;
        Width = _width;
        Height = _height;
    }

    public bool Contains(Rect bounds)
    {
        double right1 = X + Width;
        double bottom1 = Y + Height;
        double right2 = bounds.X + bounds.Width;
        double bottom2 = bounds.Y + bounds.Height;
        ////先简单检测,如果未重叠直接返回，否则进行具体的重叠检测

        double centerOffsetX = doubleAbs((X + right1) * 0.5f - (bounds.X + right2) * 0.5f);
        double centerOffsetY = doubleAbs((Y + bottom1) * 0.5f - (bounds.Y + bottom2) * 0.5f);
        double addX = (Width + bounds.Width) * 0.5f;
        double addY = (Height + bounds.Height) * 0.5f;
        if (centerOffsetX < addX && centerOffsetY < addY)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public double doubleAbs(double value)
    {
        return value >= 0.00000001 ? value : -value;

    }
}
