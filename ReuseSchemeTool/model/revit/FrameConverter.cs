using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ReuseSchemeTool.model.revit
{
    public class FrameConverter
    {

        /* ATTRIBUTES */
        private Autodesk.Revit.DB.Document dbDoc;
        private List<string> categoryNames;
        private Autodesk.Revit.DB.Element element;

        /* CONSTRUCTORS */
        public FrameConverter(Autodesk.Revit.DB.Document dbDoc)
        {
            this.dbDoc = dbDoc;
            this.categoryNames= new List<string> { "Structural Framing", "Structural Columns" };
        }


        /* METHODS */

        public Frame getObj(Autodesk.Revit.DB.Element element)
        {
            this.element = element;

            if (!checkObjType()) return null;

            Frame frame = new Frame();

            frame.setSection(getProperty());
            frame.setMaterial(getMaterial());
            frame.setGeometry((Line)getGeometry());
            frame.setLength_m(getLength());
            frame.setType(getType());
            frame.setUniqueId(getUniqueId());

            return frame;

        }

        private Boolean checkObjType()
        {
            return this.categoryNames.Contains(element.Category.Name);
        }

        private Section getProperty()
        {

            String name= ((ElementType)dbDoc.GetElement(element.GetTypeId())).Name;
            
            Single area_mm2=0;
            Parameter secAreaParam=null;

            if (((FamilyInstance)element).Symbol.LookupParameter("Section Area") != null)
                secAreaParam = ((FamilyInstance)element).Symbol.LookupParameter("Section Area");
            else if (((FamilyInstance)element).Symbol.LookupParameter("A") != null)
                secAreaParam = ((FamilyInstance)element).Symbol.LookupParameter("A");

            // Convert secAreaParam value from internal units (ft^2) to external units (mm^2)
            if (secAreaParam != null) area_mm2 = (Single)UnitUtils.ConvertFromInternalUnits(secAreaParam.AsDouble(),UnitTypeId.SquareMillimeters);


            Single weight_kg_m = 0;
            Parameter secWeightParam = null;

            if (((FamilyInstance)element).Symbol.LookupParameter("Nominal Weight") != null)
                secWeightParam = ((FamilyInstance)element).Symbol.LookupParameter("Nominal Weight");
            else if (((FamilyInstance)element).Symbol.LookupParameter("W") != null)
                secWeightParam = ((FamilyInstance)element).Symbol.LookupParameter("W");

            // Convert secWeightParam value from internal units (kgf/m) to external units (kg/m)
            if (secWeightParam != null) weight_kg_m= (Single)(secWeightParam.AsDouble()/ 9.80665);

            return new Section(name, area_mm2, weight_kg_m);
        }

        private String getMaterial()
        {
            Parameter materialParam = element.LookupParameter("BHE_Material");
            return materialParam.AsValueString();
        }

        private Geometry getGeometry()
        {
            Options options = new Options();
            options.ComputeReferences = true;
            options.IncludeNonVisibleObjects = true;


            XYZ startRvtPP = null;
            XYZ endRvtPP=null;

            FamilyInstance frame = element as FamilyInstance;
            if (frame != null)
            {
                GeometryElement geometryElement = frame.get_Geometry(options);
                foreach (GeometryObject geometryObject in geometryElement)
                {
                    Curve curve = geometryObject as Curve;
                    if (curve != null)
                    {
                        startRvtPP = curve.GetEndPoint(0);
                        endRvtPP = curve.GetEndPoint(1);
                    }
                }

            }


            Point startPoint = new Point(startRvtPP.X, startRvtPP.Y, startRvtPP.Z);
            Point endPoint = new Point(endRvtPP.X, endRvtPP.Y, endRvtPP.Z);

            return new Line(startPoint, endPoint);
        }

        private double getLength()
        {
            Parameter lengthParam = element.LookupParameter("Length");
            return Math.Round(UnitUtils.ConvertFromInternalUnits(lengthParam.AsDouble(),UnitTypeId.Meters),3);
        }

        private FrameType getType()
        {
            BuiltInCategory builtInCategory = (BuiltInCategory)element.Category.Id.IntegerValue;

            switch (builtInCategory)
            {
                case BuiltInCategory.OST_HorizontalBracing:
                case BuiltInCategory.OST_KickerBracing:
                case BuiltInCategory.OST_VerticalBracing:
                    return FrameType.BRACING;
                case BuiltInCategory.OST_StructuralColumns:
                    return FrameType.COLUMN;
                case BuiltInCategory.OST_StructuralFraming:
                    return FrameType.BEAM;
            }

            return FrameType.NOTAPPLICABLE;
        }

        private String getUniqueId()
        {
            return element.Id.ToString();
        }

    }

}