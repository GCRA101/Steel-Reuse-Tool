using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ReuseSchemeTool.model
{
    public class FrameConverter
    {
        /* ATTRIBUTES */
        private Autodesk.Revit.DB.Document dbDoc;
        private List<String> categoryNames = new List<string> { "Structural Framing", "Structural Columns" };

        /* CONSTRUCTORS */
        public FrameConverter(Autodesk.Revit.DB.Document dbDoc)
        {
            this.dbDoc = dbDoc;
        }


        /* METHODS */

        public Frame getFrameObj(Autodesk.Revit.DB.Element element)
        {
            if (!checkObjType(element)) return null;

            Frame frame = new Frame();

            frame.setSection(getProperty(element));
            frame.setMaterial(getMaterial(element));
            frame.setGeometry(getGeometry(element));
            frame.setLength(getLength(element));
            frame.setType(getType(element));
            frame.setUniqueId(getUniqueId(element));

            return frame;

        }

        private Boolean checkObjType(Autodesk.Revit.DB.Element element)
        {
            return this.categoryNames.Contains(element.Category.Name);
        }

        private Section getProperty(Autodesk.Revit.DB.Element element)
        {

            String name= ((ElementType)dbDoc.GetElement(element.GetTypeId())).Name;
            
            Single area_mm2=0;
            Parameter secAreaParam=((FamilyInstance)element).Symbol.LookupParameter("Section Area");
            // Convert secAreaParam value from internal units (ft^2) to external units (mm^2)
            if (secAreaParam != null) area_mm2 = (Single)UnitUtils.ConvertFromInternalUnits(secAreaParam.AsDouble(),UnitTypeId.SquareMillimeters);

            Single weight_kg_m=0;
            Parameter secWeightParam = ((FamilyInstance)element).Symbol.LookupParameter("Nominal Weight");
            // Convert secWeightParam value from internal units (kgf/m) to external units (kg/m)
            if (secWeightParam != null) weight_kg_m= (Single)(secWeightParam.AsDouble()/ 9.80665);

            return new Section(name, area_mm2, weight_kg_m);
        }

        private String getMaterial(Autodesk.Revit.DB.Element element)
        {
            Parameter materialParam = element.LookupParameter("BHE_Material");
            return materialParam.AsValueString();
        }

        private Line getGeometry(Autodesk.Revit.DB.Element element)
        {
            //XYZ startRvtPP = null, endRvtPP = null;
            //// Get the location curve of the element
            //LocationCurve locCurve = element.Location as LocationCurve;
            //if (locCurve != null)
            //{
            //    startRvtPP = locCurve.Curve.GetEndPoint(0);
            //    endRvtPP = locCurve.Curve.GetEndPoint(1);
            //}

            //Point startPoint = new Point(startRvtPP.X, startRvtPP.Y, startRvtPP.Z);
            //Point endPoint = new Point(endRvtPP.X, endRvtPP.Y, endRvtPP.Z);

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

        private Double getLength(Autodesk.Revit.DB.Element element)
        {
            Parameter lengthParam = element.LookupParameter("Length");
            return lengthParam.AsDouble();
        }

        private FrameType getType(Autodesk.Revit.DB.Element element)
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

        private String getUniqueId(Autodesk.Revit.DB.Element element)
        {
            return element.Id.ToString();
        }
    }

}