/* IMPORT LIBRARIES */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;


namespace ReuseSchemeTool.model.revit
{
    public class ColorsFactory
    {
        /* ATTRIBUTES */
        // Private static instance - SINGLETON PATTERN
        private static ColorsFactory instance;

        /* CONSTRUCTORS */
        // Private Default Constructor - SINGLETON PATTERN
        private ColorsFactory() { }


        /* METHODS */

        // Public Static getInstance() Method - SINGLETON PATTERN
        public static ColorsFactory getInstance()
        {
            if (instance == null) { return new ColorsFactory(); }
            return instance;
        }


        //Public create Method
        public List<Autodesk.Revit.DB.Color> create(List<BHColor> bhColors)
        {
            return bhColors.Select(bhColor => this.createBHColor(bhColor))
                           .Select(color => new Autodesk.Revit.DB.Color(color.R, color.G, color.B))
                           .ToList();
        }

        public Color createBHColor(BHColor bhColor)
        {

            switch (bhColor)
            {
                case BHColor.DARK_GREY: return Color.FromArgb(88,82,83);
                case BHColor.DARK_PURPLE: return Color.FromArgb(36,19,95);
                case BHColor.DARK_PLUM: return Color.FromArgb(109,16,78);
                case BHColor.MID_BLUE: return Color.FromArgb(0,109,168);
                case BHColor.DARK_ORANGE: return Color.FromArgb(208,106,19);
                case BHColor.DARK_GREEN: return Color.FromArgb(93,130,45);
                case BHColor.DARK_YELLOW: return Color.FromArgb(240,172,27);
                case BHColor.DARK_BLUE: return Color.FromArgb(28,54,96);
                case BHColor.DARK_RED: return Color.FromArgb(188,32,75);
                case BHColor.BRIGHT_GREY: return Color.FromArgb(227,224,214);
                case BHColor.BRIGHT_PURPLE: return Color.FromArgb(112,47,138);
                case BHColor.BRIGHT_PINK: return Color.FromArgb(230,49,135);
                case BHColor.BRIGHT_BLUE: return Color.FromArgb(0,169,224);
                case BHColor.BRIGHT_YELLOW: return Color.FromArgb(255,207,1);
                case BHColor.BRIGHT_GREEN: return Color.FromArgb(108,194,78);
                case BHColor.BRIGHT_ORANGE: return Color.FromArgb(235,103,28);
                case BHColor.BRIGHT_TEAL: return Color.FromArgb(0,164,153);
                case BHColor.BRIGHT_RED: return Color.FromArgb(213,0,50);
                case BHColor.MUTED_GREY: return Color.FromArgb(150,140,131);
                case BHColor.MUTED_PURPLE: return Color.FromArgb(143,114,176);
                case BHColor.MUTED_YELLOW: return Color.FromArgb(252,209,109);
                case BHColor.MUTED_BLUE: return Color.FromArgb(141,185,202);
                case BHColor.MUTED_ORANGE: return Color.FromArgb(238,120,55);
                case BHColor.MUTED_GREEN: return Color.FromArgb(175,193,162);
                case BHColor.MUTED_PLUM: return Color.FromArgb(182,43,119);
                case BHColor.MUTED_DUCK_EGG: return Color.FromArgb(160,210,201);
                case BHColor.MUTED_CORAL: return Color.FromArgb(230,72,77);
                default: return Color.FromArgb(0, 0, 0);
            }
        }



        //Public create Method - FACTORY PATTERN
        public List<Autodesk.Revit.DB.Color> create(ColorPalette colorPalette, int colorsNum)
        {
            switch (colorPalette)
            {
                case ColorPalette.RAINBOW: return this.rainbowColors(colorsNum);
                case ColorPalette.RANDOM: return this.randomColors(colorsNum);
                case ColorPalette.TRAFFICLIGHTS: return this.trafficLightColors(colorsNum);
                default: return null;
            }
        }

        /*Private rainbowColors Method
          Private as it doesn't need to be visible to the client
          Create a list of Revit DB color objects in a rainbow type pattern*/
        private List<Autodesk.Revit.DB.Color> rainbowColors(int colorsNum)
        {
            List<Autodesk.Revit.DB.Color>colors = new List<Autodesk.Revit.DB.Color> ();
            
            for (int i = 0; i < colorsNum; i++){
                byte red = (byte)(127 * Math.Sin(0.3 * i) + 128);
                byte green = (byte)(127 * Math.Sin(0.3 * i + 2) + 128);
                byte blue = (byte)(127 * Math.Sin(0.3 * i + 4) + 128);
                colors.Add(new Autodesk.Revit.DB.Color(red, green, blue));}
        
            return colors;
        }

        /*Private randomColors Method
          Private as it doesn't need to be visible to the client
          Create a list of Revit DB color objects in a random type pattern*/
        private List<Autodesk.Revit.DB.Color> randomColors(int colorsNum)
        {
            List<Autodesk.Revit.DB.Color> colors = new List<Autodesk.Revit.DB.Color>();
            Random random = new Random();

            for (int i = 0; i < colorsNum; i++)
            {
                byte red = (byte)random.Next(0,256);
                byte green = (byte)random.Next(0, 256);
                byte blue = (byte)random.Next(0, 256);
                colors.Add(new Autodesk.Revit.DB.Color(red, green, blue));
            }

            return colors;
        }

        /*Private trafficLightColors Method
          Private as it doesn't need to be visible to the client
          Create a list of Revit DB color objects in a random type pattern*/
        private List<Autodesk.Revit.DB.Color> trafficLightColors(int colorsNum)
        {
            List<Autodesk.Revit.DB.Color> colorsRange = new List<Autodesk.Revit.DB.Color>();
            List<Autodesk.Revit.DB.Color> colors = new List<Autodesk.Revit.DB.Color>();

            long steps = Math.Max(100, colorsNum*2);
            long halfSteps = steps / 2;
            // Green to Orange
            for (long i = 0; i < halfSteps; i++)
            {
                double t = (double)i / (halfSteps - 1);
                byte r = (byte)(255 * t);
                byte g = 255;
                byte b = 0;
                colorsRange.Add(new Autodesk.Revit.DB.Color(r, g, b));
            }

            // Orange to Red
            for (long i = halfSteps; i < steps; i++)
            {
                double t = (double)(i - halfSteps) / (halfSteps - 1);
                byte r = 255;
                byte g = (byte)(255 * (1 - t));
                byte b = 0;
                colorsRange.Add(new Autodesk.Revit.DB.Color(r, g, b));
            }

            int step =(int)Math.Round((double)colorsRange.Count /(colorsNum-1))-1;

            for (int i = 0; i < colorsRange.Count; i += step)
            {
                colors.Add(colorsRange[i]);
            }

            return colors;
        }


        //Public create Method - FACTORY PATTERN
        public List<Autodesk.Revit.DB.Color> create(BHColorPalette colorPalette, int colorsNum)
        {
            switch (colorPalette)
            {
                case BHColorPalette.TRAFFICLIGHTS_BRIGHT: 
                    return this.bhTrafficLightColors(BHColorPaletteType.BRIGHT,colorsNum);
                case BHColorPalette.TRAFFICLIGHTS_MUTED:  
                    return this.bhTrafficLightColors(BHColorPaletteType.MUTED, colorsNum);
                case BHColorPalette.TRAFFICLIGHTS_DARK:   
                    return this.bhTrafficLightColors(BHColorPaletteType.DARK, colorsNum);
                default: return null;
            }
        }


        private List<Autodesk.Revit.DB.Color> bhTrafficLightColors(BHColorPaletteType bhColorPaletteType, int colorsNum)
        {
            List<Autodesk.Revit.DB.Color> colorsRange = new List<Autodesk.Revit.DB.Color>();
            List<Autodesk.Revit.DB.Color> colors = new List<Autodesk.Revit.DB.Color>();

            Color refColor01 = new Color();
            Color refColor02 = new Color();
            Color refColor03 = new Color();


            switch (bhColorPaletteType)
            {
                case (BHColorPaletteType.DARK):
                    refColor01 = this.createBHColor(BHColor.DARK_GREEN);
                    refColor02 = this.createBHColor(BHColor.DARK_ORANGE);
                    refColor03 = this.createBHColor(BHColor.DARK_RED);
                    break;
                case (BHColorPaletteType.MUTED):
                    refColor01 = this.createBHColor(BHColor.MUTED_GREEN);
                    refColor02 = this.createBHColor(BHColor.MUTED_ORANGE);
                    refColor03 = this.createBHColor(BHColor.MUTED_CORAL);
                    break;
                case (BHColorPaletteType.BRIGHT):
                    refColor01 = this.createBHColor(BHColor.DARK_GREEN);
                    refColor02 = this.createBHColor(BHColor.DARK_ORANGE);
                    refColor03 = this.createBHColor(BHColor.DARK_RED);
                    break;
            }

            int deltaR01 = refColor02.R - refColor01.R;
            int deltaG01 = refColor02.G - refColor01.G;
            int deltaB01 = refColor02.B - refColor01.B;

            int deltaR02 = refColor03.R - refColor02.R;
            int deltaG02 = refColor03.G - refColor02.G;
            int deltaB02 = refColor03.B - refColor02.B;


            long steps = Math.Max(100, colorsNum * 2);
            long halfSteps = steps / 2;
            // Green to Orange
            for (long i = 0; i < halfSteps; i++)
            {
                double t = (double)i / (halfSteps - 1);
                byte r = (byte)(refColor01.R + (int)((deltaR01 / halfSteps) * i));
                byte g = (byte)(refColor01.G + (int)((deltaG01 / halfSteps) * i));
                byte b = (byte)(refColor01.B + (int)((deltaB01 / halfSteps) * i));
                colorsRange.Add(new Autodesk.Revit.DB.Color(r, g, b));
            }

            // Orange to Red
            for (long i = halfSteps; i < steps; i++)
            {
                byte r = (byte)(refColor02.R + (int)((deltaR02 / halfSteps) * (i - halfSteps)));
                byte g = (byte)(refColor02.G + (int)((deltaG02 / halfSteps) * (i - halfSteps)));
                byte b = (byte)(refColor02.B + (int)((deltaB02 / halfSteps) * (i - halfSteps)));
                colorsRange.Add(new Autodesk.Revit.DB.Color(r, g, b));
            }

            int step = (int)Math.Round((double)colorsRange.Count / (colorsNum - 1)) - 1;

            for (int i = 0; i < colorsRange.Count; i += step)
            {
                colors.Add(colorsRange[i]);
            }

            return colors;
        }
    }


}
