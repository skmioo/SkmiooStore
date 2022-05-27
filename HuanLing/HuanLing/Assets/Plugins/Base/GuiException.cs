using System;
using System.Collections.Generic;

namespace UYMO
{
    public class GuiException : UnimplementedException
    {
        public GuiException(string guiName, string desc)
            : base(string.Format("GUI Exception: {0}\n{1}", guiName, desc))
        {
            //
        }
    }
}
