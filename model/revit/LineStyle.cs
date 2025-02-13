using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model.revit
{
    public class LineStyle
    {
        /* ATTRIBUTES */
        private string name;
        private int lineWeight;
        private Color color;

        /* CONSTRUCTORS */
        // Overloaded 01
        public LineStyle(string name, int lineWeight, Color color)
        {
            this.name = name;
            this.lineWeight = lineWeight;
            this.color = color;
        }

        /* METHODS */
        public GraphicsStyle getGraphicsStyle(Autodesk.Revit.DB.Document dbDoc)
        {
            // Step 1: Create a new line style
            Category lineCategory = dbDoc.Settings.Categories.get_Item(BuiltInCategory.OST_Lines);
            Category newLineCategory = null;

            foreach (Category cat in lineCategory.SubCategories)
            {
                if (cat.Name == name) { newLineCategory = cat; break; }
            }

            if (newLineCategory == null)
            {
                newLineCategory = dbDoc.Settings.Categories.NewSubcategory(lineCategory, name);
            }

            newLineCategory.SetLineWeight(lineWeight, GraphicsStyleType.Projection);
            newLineCategory.LineColor = color;

            GraphicsStyle lineStyle = newLineCategory.GetGraphicsStyle(GraphicsStyleType.Projection);

            return lineStyle;

        }


        // Setters
        public void setName (string name) { this.name= name; }
        public void setLineWeight(int lineWeight) { this.lineWeight = lineWeight; }
        public void setColor (Color color) { this.color = color; }

        // Getters
        public string getName () { return this.name; }
        public int getLineWeight() { return this.lineWeight; }
        public Color getColor() { return this.color; }

    }
}
