using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UIUtils
{
  class ColorHelper
  {
    public const string YELLOW = "FF8500";
    public const string RED = "FF5959";
    public const string YELLOW_2 = "FFA500";
    public const string BLACK = "000000";
    public const string WHITE = "FFFFFF";
    public const string ORANGE = "FF843E";
    public const string GREEN = "75FB86";
    public const string BLUE = "7696FD";
    public const string PURPLE = "953DFF";
    public static Color HexaToRGB(string hexa)
    {
      int r = Convert.ToInt32(hexa.Substring(0, 2), 16);
      int g = Convert.ToInt32(hexa.Substring(2, 2), 16);
      int b = Convert.ToInt32(hexa.Substring(4, 2), 16);
      return new Color(r / 255f, g / 255f, b / 255f);
    }
  }
}
