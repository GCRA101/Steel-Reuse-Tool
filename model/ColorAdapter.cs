using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    public static class ColorAdapter
    {
        // ATTRIBUTES
        private static model.RSTColor color;

        // METHODS

        private static void convertColor(System.Drawing.Color sysColor)
        {
            color = new model.RSTColor(sysColor.R, sysColor.G, sysColor.B);
        }

        private static void convertColor(Autodesk.Revit.DB.Color revitColor)
        {
            color = new model.RSTColor(revitColor.Red, revitColor.Green, revitColor.Blue);
        }

        public static Autodesk.Revit.DB.Color convertToRevit(System.Drawing.Color sysColor)
        {
            convertColor(sysColor);
            return new Autodesk.Revit.DB.Color(color.getRed(), color.getGreen(), color.getBlue());
        }

        public static System.Drawing.Color convertToSystem(Autodesk.Revit.DB.Color revitColor)
        {
            convertColor(revitColor);
            return System.Drawing.Color.FromArgb(color.getRed(), color.getGreen(), color.getBlue());
        }


    }
}
