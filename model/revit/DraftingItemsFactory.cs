using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ReuseSchemeTool.model.revit
{
    public class DraftingItemsFactory
    {


        public Autodesk.Revit.DB.Line createLine(XYZ startPoint, XYZ endPoint)
        {
            Autodesk.Revit.DB.Line line = Autodesk.Revit.DB.Line.CreateBound(startPoint, endPoint);

            return line;
        }


        public CurveLoop createRectangle(List<XYZ> cornerPoints)
        {
            List<Curve> curves = new List<Curve>
            {
                Autodesk.Revit.DB.Line.CreateBound(cornerPoints[0], cornerPoints[1]),
                Autodesk.Revit.DB.Line.CreateBound(cornerPoints[1], cornerPoints[2]),
                Autodesk.Revit.DB.Line.CreateBound(cornerPoints[2], cornerPoints[3]),
                Autodesk.Revit.DB.Line.CreateBound(cornerPoints[3], cornerPoints[0])
            };
            return CurveLoop.Create(curves);
        }

        private CurveLoop createCircle(XYZ centerPoint, double radius)
        {
            List<Curve> curves = new List<Curve>
            {
                Autodesk.Revit.DB.Arc.Create(centerPoint, radius, 0, Math.PI, XYZ.BasisX, XYZ.BasisY),
                Autodesk.Revit.DB.Arc.Create(centerPoint, radius, Math.PI, 2 * Math.PI, XYZ.BasisX, XYZ.BasisY)
             };
            return CurveLoop.Create(curves);
        }

        public TextNote createTextNote(string textnoteTypeName,XYZ location, string text)
        {

            Element textNoteType = new FilteredElementCollector(doc)
                                        .OfClass(typeof(TextNoteType))
                                        .Where(tnt => tnt.Name == textnoteTypeName);


            ElementId defaultTextTypeId = doc.GetDefaultElementTypeId(ElementTypeGroup.TextNoteType);
            TextNoteOptions opts = new TextNoteOptions();

            opts.TypeId = textNoteType.Id;
            opts.HorizontalAlignment = HorizontalTextAlignment.Left;
            opts.VerticalAlignment = VerticalTextAlignment.Middle;

            TextNote textNote = TextNote.Create(doc, legendView.Id, new XYZ(i * 10 + 5, -5, 0), text, new TextNoteOptions());

            return textNote;

        }



        public void createPieChart(Document doc, ViewDrafting view)
        {
            // Define the center and radius of the pie chart
            XYZ center = new XYZ(0, 0, 0);
            double radius = 5.0;

            // Generate random angles for the sectors
            Random random = new Random();
            double angle1 = 1 * Math.PI;
            double angle2 = 0.5 * Math.PI;
            double angle3 = 2 * Math.PI - angle1 - angle2;

            // Create the sectors
            createSector(doc, view, center, radius, 0, angle1, new Color(255, 0, 0)); // Red
            createSector(doc, view, center, radius, angle1, angle1 + angle2, new Color(0, 255, 0)); // Green
            createSector(doc, view, center, radius, angle1 + angle2, 2 * Math.PI, new Color(0, 0, 255)); // Blue
        }


        private void createSector(Document doc, ViewDrafting view, XYZ center, double radius, double startAngle, double endAngle, Color color)
        {
            // Create the arc for the sector
            Arc arc = Arc.Create(center, radius, startAngle, endAngle, XYZ.BasisX, XYZ.BasisY);

            // Create the lines from the center to the arc endpoints
            Autodesk.Revit.DB.Line line1 = Autodesk.Revit.DB.Line.CreateBound(center, arc.GetEndPoint(0));
            Autodesk.Revit.DB.Line line2 = Autodesk.Revit.DB.Line.CreateBound(arc.GetEndPoint(1), center);

            // Create the filled region
            List<Curve> curves = new List<Curve> { line1, arc, line2 };
            CurveLoop curveLoop = CurveLoop.Create(curves);
            List<CurveLoop> curveLoops = new List<CurveLoop> { curveLoop };

            FilledRegionType filledRegionType = new FilteredElementCollector(doc)
                .OfClass(typeof(FilledRegionType))
                .FirstElement() as FilledRegionType;

            FilledRegion filledRegion = FilledRegion.Create(doc, filledRegionType.Id, view.Id, curveLoops);

            // Set the color of the filled region
            OverrideGraphicSettings overrideSettings = new OverrideGraphicSettings();
            //overrideSettings.SetProjectionFillColor(color);
            doc.ActiveView.SetElementOverrides(filledRegion.Id, overrideSettings);
        }



    }
}
