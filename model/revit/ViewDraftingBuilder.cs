using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace ReuseSchemeTool.model.revit
{
    public class ViewDraftingBuilder
    {

        /* ATTRIBUTES */
        private Autodesk.Revit.DB.Document dbDoc;
        private Autodesk.Revit.DB.ViewDrafting viewDrafting = null;
        private FilledRegionType solidFilledRegionType;


        /* CONSTRUCTOR */

        public ViewDraftingBuilder(Document dbDoc)
        {
            this.dbDoc = dbDoc;
            this.solidFilledRegionType = getFilledRegionType();
        }

        public ViewDraftingBuilder(Document dbDoc, ViewDrafting viewDrafting) : this(dbDoc)
        {
            this.viewDrafting = viewDrafting;
        }




        /* METHODS */

        public void setViewDrafting(ViewDrafting viewDrafting)
        {
            this.viewDrafting = viewDrafting;
        }

        public ViewDrafting getViewDrafting()
        {
            if (this.viewDrafting == null) { return null; }

            ViewDrafting output = viewDrafting;

            this.viewDrafting = null;

            return output;
        }

        public Autodesk.Revit.DB.Line createLine(XYZ startPoint, XYZ endPoint, GraphicsStyle lineStyle=null)
        {
            if (viewDrafting == null) return null;

            startPoint = convertPointToInternalUnits(startPoint);
            endPoint = convertPointToInternalUnits(endPoint);

            Transaction revitTransaction = null;
            Autodesk.Revit.DB.Line line = null;

            try
            {
                //Start New Transaction
                if (!dbDoc.IsModifiable)
                {
                    revitTransaction = new Transaction(dbDoc, "Create Drafting Line");
                    revitTransaction.Start();
                }

                line = Autodesk.Revit.DB.Line.CreateBound(startPoint, endPoint);

                DetailCurve detailCurve = dbDoc.Create.NewDetailCurve(viewDrafting, line);

                if (lineStyle!=null) detailCurve.LineStyle = lineStyle;

                if (revitTransaction != null)
                {
                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }
            }
            catch (Exception ex)
            {
                if (revitTransaction != null)
                {

                    revitTransaction.RollBack();

                    TaskDialog.Show("ERROR MESSAGES", ex.Message);

                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }
            }

            return line;
        }


        private XYZ convertPointToInternalUnits(XYZ point_Metric)
        {
            return new XYZ(UnitUtils.ConvertToInternalUnits(point_Metric.X, UnitTypeId.Millimeters),
                           UnitUtils.ConvertToInternalUnits(point_Metric.Y, UnitTypeId.Millimeters),
                           UnitUtils.ConvertToInternalUnits(point_Metric.Z, UnitTypeId.Millimeters));
        }


        public FilledRegionType getFilledRegionType()
        {

            Transaction revitTransaction = null;

            FilledRegionType solidFilledRegionType=null;

            try
            {
                //Start New Transaction
                if (!dbDoc.IsModifiable)
                {
                    revitTransaction = new Transaction(dbDoc, "Create New Filled Region Type");
                    revitTransaction.Start();
                }

                // Retrieve the solid fill pattern
                FillPatternElement solidFillPattern = new FilteredElementCollector(dbDoc)
                    .OfClass(typeof(FillPatternElement))
                    .Cast<FillPatternElement>()
                    .FirstOrDefault(fp => fp.GetFillPattern().IsSolidFill);

                if (solidFillPattern == null)
                {
                    TaskDialog.Show("Error", "Solid fill pattern not found.");
                    return null;
                }

                // Check existence of FilledRegionType with Solid Fill
                solidFilledRegionType = new FilteredElementCollector(dbDoc)
                    .OfClass(typeof(FilledRegionType))
                    .Cast<FilledRegionType>()
                    .First(frt => frt.ForegroundPatternId == solidFillPattern.Id);

                if (solidFilledRegionType == null)
                {
                    FilledRegionType existingFilledRegionType = new FilteredElementCollector(dbDoc)
                    .OfClass(typeof(FilledRegionType))
                    .FirstElement() as FilledRegionType;

                    // Duplicate the existing FilledRegionType to create a new one
                    solidFilledRegionType = (FilledRegionType)existingFilledRegionType.Duplicate("Solid Filled Region Type 00");

                    // Set the fill pattern to solid
                    solidFilledRegionType.ForegroundPatternId = solidFillPattern.Id;
                }

                if (revitTransaction != null)
                {
                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }

            }
            catch (Exception ex)
            {
                if (revitTransaction != null)
                {

                    revitTransaction.RollBack();

                    TaskDialog.Show("ERROR MESSAGES", ex.Message);

                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }
            }

            return solidFilledRegionType;
        }


        public FilledRegion createRectangle(List<XYZ> cornerPoints, Color color)
        {

            if (viewDrafting == null) return null;

            Transaction revitTransaction = null;
            List<Curve> curves = null;
            FilledRegion filledRegion = null;

            try
            {
                //Start New Transaction
                if (!dbDoc.IsModifiable)
                {
                    revitTransaction = new Transaction(dbDoc, "Create Drafting Rectangle");
                    revitTransaction.Start();
                }

                CurveLoop curveLoop = createRectangle(cornerPoints);

                filledRegion = FilledRegion.Create(dbDoc, this.solidFilledRegionType.Id, viewDrafting.Id, new List<CurveLoop> { curveLoop });

                // Set the color of the filled region
                OverrideGraphicSettings overrideSettings = new OverrideGraphicSettings();
                overrideSettings.SetSurfaceForegroundPatternColor(color);
                viewDrafting.SetElementOverrides(filledRegion.Id, overrideSettings);

                if (revitTransaction != null)
                {
                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }

            }
            catch (Exception ex)
            {
                if (revitTransaction != null)
                {

                    revitTransaction.RollBack();

                    TaskDialog.Show("ERROR MESSAGES", ex.Message);

                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }
            }

            return filledRegion;
        }


        private CurveLoop createRectangle(List<XYZ> cornerPoints)
        {

            cornerPoints.Select(point=>convertPointToInternalUnits(point)).ToList();

            List<Curve> curves = new List<Curve>
            {
                Autodesk.Revit.DB.Line.CreateBound(cornerPoints[0], cornerPoints[1]),
                Autodesk.Revit.DB.Line.CreateBound(cornerPoints[1], cornerPoints[2]),
                Autodesk.Revit.DB.Line.CreateBound(cornerPoints[2], cornerPoints[3]),
                Autodesk.Revit.DB.Line.CreateBound(cornerPoints[3], cornerPoints[0])
            };
            return CurveLoop.Create(curves);

        }


        public FilledRegion createRectangle(XYZ topLeftCornerPoint, double width_mm, double height_mm, Color color)
        {

            if (viewDrafting == null) return null;

            Transaction revitTransaction = null;
            List<Curve> curves = null;
            FilledRegion filledRegion = null;

            try
            {
                //Start New Transaction
                if (!dbDoc.IsModifiable)
                {
                    revitTransaction = new Transaction(dbDoc, "Create Drafting Rectangle");
                    revitTransaction.Start();
                }

                CurveLoop curveLoop = createRectangle(topLeftCornerPoint, width_mm, height_mm);

                filledRegion = FilledRegion.Create(dbDoc, this.solidFilledRegionType.Id, viewDrafting.Id, new List<CurveLoop> { curveLoop });

                // Set the color of the filled region
                OverrideGraphicSettings overrideSettings = new OverrideGraphicSettings();
                overrideSettings.SetSurfaceForegroundPatternColor(color);
                viewDrafting.SetElementOverrides(filledRegion.Id, overrideSettings);

                if (revitTransaction != null)
                {
                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }

            }
            catch (Exception ex)
            {
                if (revitTransaction != null)
                {

                    revitTransaction.RollBack();

                    TaskDialog.Show("ERROR MESSAGES", ex.Message);

                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }
            }

            return filledRegion;
        }


        private CurveLoop createRectangle(XYZ topLeftCornerPoint, double width_mm, double height_mm)
        {
            XYZ pointA = convertPointToInternalUnits(topLeftCornerPoint);
            double width_ft = UnitUtils.ConvertToInternalUnits(width_mm, UnitTypeId.Millimeters);
            double height_ft = UnitUtils.ConvertToInternalUnits(height_mm, UnitTypeId.Millimeters);
            
            XYZ pointB = new XYZ(pointA.X + width_ft, pointA.Y, pointA.Z);
            XYZ pointC = new XYZ(pointA.X + width_ft, pointA.Y- height_ft, pointA.Z);
            XYZ pointD = new XYZ(pointA.X, pointA.Y - height_ft, pointA.Z);

            List<Curve> curves = new List<Curve>
            {
                Autodesk.Revit.DB.Line.CreateBound(pointA, pointB),
                Autodesk.Revit.DB.Line.CreateBound(pointB, pointC),
                Autodesk.Revit.DB.Line.CreateBound(pointC, pointD),
                Autodesk.Revit.DB.Line.CreateBound(pointD, pointA)
            };
            return CurveLoop.Create(curves);

        }


        public FilledRegion createCircle(XYZ centerPoint, double radius_mm, Color color)
        {

            if (viewDrafting == null) return null;

            Transaction revitTransaction = null;
            List<Curve> curves = null;
            FilledRegion filledRegion = null;

            try
            {
                //Start New Transaction
                if (!dbDoc.IsModifiable)
                {
                    revitTransaction = new Transaction(dbDoc, "Create Drafting Circle");
                    revitTransaction.Start();
                }

                CurveLoop curveLoop=createCircle(centerPoint, radius_mm);

                filledRegion = FilledRegion.Create(dbDoc, this.solidFilledRegionType.Id, viewDrafting.Id, new List<CurveLoop> { curveLoop });

                // Set the color of the filled region
                OverrideGraphicSettings overrideSettings = new OverrideGraphicSettings();
                overrideSettings.SetSurfaceForegroundPatternColor(color);
                viewDrafting.SetElementOverrides(filledRegion.Id, overrideSettings);

                if (revitTransaction != null)
                {
                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }

            }
            catch (Exception ex)
            {
                if (revitTransaction != null)
                {

                    revitTransaction.RollBack();

                    TaskDialog.Show("ERROR MESSAGES", ex.Message);

                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }
            }

            return filledRegion;
        }

        
        private CurveLoop createCircle(XYZ centerPoint, double radius_mm)
        {
            centerPoint=convertPointToInternalUnits(centerPoint);

            double radius_ft=UnitUtils.ConvertToInternalUnits(radius_mm, UnitTypeId.Millimeters);

            List<Curve> curves = new List<Curve> {
                    Autodesk.Revit.DB.Arc.Create(centerPoint, radius_ft, 0, Math.PI, XYZ.BasisX, XYZ.BasisY),
                    Autodesk.Revit.DB.Arc.Create(centerPoint, radius_ft, Math.PI, 2 * Math.PI, XYZ.BasisX, XYZ.BasisY)};

            return CurveLoop.Create(curves);

        }


        public TextNoteType createTextNoteType(string typeName, string fontName, Single fontSize_mm,Boolean bold)
        {

            TextNoteType newTextNoteType = null;
            TextNoteType textNoteType=null;
            Transaction revitTransaction = null;

            try
            {
                //Start New Transaction
                if (!dbDoc.IsModifiable)
                {
                    revitTransaction = new Transaction(dbDoc, "Create Drafting Rectangle");
                    revitTransaction.Start();
                }

                // Check if typeName is already in use
                textNoteType = new FilteredElementCollector(dbDoc)
                    .OfClass(typeof(TextNoteType))
                    .Cast<TextNoteType>()
                    .FirstOrDefault(tnt=>tnt.Name==typeName);

                if (textNoteType == null)
                {

                    // Retrieve an existing TextNoteType to duplicate
                    textNoteType = new FilteredElementCollector(dbDoc)
                        .OfClass(typeof(TextNoteType))
                        .FirstElement() as TextNoteType;

                    textNoteType = (TextNoteType)textNoteType.Duplicate(typeName);

                    // Set the properties of the new TextNoteType
                    textNoteType.get_Parameter(BuiltInParameter.TEXT_FONT).Set(fontName);
                    textNoteType.get_Parameter(BuiltInParameter.TEXT_SIZE).Set(UnitUtils.ConvertToInternalUnits(fontSize_mm, UnitTypeId.Millimeters));
                    if (bold == true) textNoteType.get_Parameter(BuiltInParameter.TEXT_STYLE_BOLD).Set(1);
                    else textNoteType.get_Parameter(BuiltInParameter.TEXT_STYLE_BOLD).Set(0);
                    textNoteType.get_Parameter(BuiltInParameter.LEADER_OFFSET_SHEET).Set(0);

                }


                if (revitTransaction != null)
                {
                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }

            }
            catch (Exception ex)
            {
                if (revitTransaction != null)
                {

                    revitTransaction.RollBack();

                    TaskDialog.Show("ERROR MESSAGES", ex.Message);

                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }
            }

            return textNoteType;
        }


        public TextNote createTextNote(string textnoteTypeName,XYZ location, string text)
        {
            if (viewDrafting == null) return null;

            Transaction revitTransaction = null;
            TextNote textNote=null;

            location=convertPointToInternalUnits(location);

            try
            {
                //Start New Transaction
                if (!dbDoc.IsModifiable)
                {
                    revitTransaction = new Transaction(dbDoc, "Create Drafting TextNote");
                    revitTransaction.Start();
                }

                Element textNoteType = new FilteredElementCollector(dbDoc)
                                        .OfClass(typeof(TextNoteType))
                                        .Where(tnt => tnt.Name == textnoteTypeName).First();

                ElementId defaultTextTypeId = dbDoc.GetDefaultElementTypeId(ElementTypeGroup.TextNoteType);
                TextNoteOptions opts = new TextNoteOptions();

                opts.TypeId = textNoteType.Id;
                opts.HorizontalAlignment = HorizontalTextAlignment.Left;
                opts.VerticalAlignment = VerticalTextAlignment.Middle;

                textNote = TextNote.Create(dbDoc, viewDrafting.Id, location, text, new TextNoteOptions());

                if (revitTransaction != null)
                {
                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }

            }
            catch (Exception ex)
            {
                if (revitTransaction != null)
                {

                    revitTransaction.RollBack();

                    TaskDialog.Show("ERROR MESSAGES", ex.Message);

                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }
            }

            return textNote;
        }


        public TextNote createTextNote(TextNoteType textnoteType, XYZ location, string text)
        {
            if (viewDrafting == null) return null;

            Transaction revitTransaction = null;
            TextNote textNote = null;

            location = convertPointToInternalUnits(location);

            try
            {
                //Start New Transaction
                if (!dbDoc.IsModifiable)
                {
                    revitTransaction = new Transaction(dbDoc, "Create Drafting TextNote");
                    revitTransaction.Start();
                }


                ElementId defaultTextTypeId = dbDoc.GetDefaultElementTypeId(ElementTypeGroup.TextNoteType);
                TextNoteOptions opts = new TextNoteOptions();

                opts.TypeId = textnoteType.Id;
                opts.HorizontalAlignment = HorizontalTextAlignment.Left;
                opts.VerticalAlignment = VerticalTextAlignment.Middle;

                textNote = TextNote.Create(dbDoc, viewDrafting.Id, location, text, opts);

                if (revitTransaction != null)
                {
                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }

            }
            catch (Exception ex)
            {
                if (revitTransaction != null)
                {

                    revitTransaction.RollBack();

                    TaskDialog.Show("ERROR MESSAGES", ex.Message);

                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }
            }

            return textNote;
        }



        public List<FilledRegion> createPieChart(XYZ center, double radius_mm, List<PieSliceData> pieSliceData)
        {
            if (viewDrafting == null) return null;

            Transaction revitTransaction = null;

            List<FilledRegion> filledRegions = new List<FilledRegion>();

            try
            {
                //Start New Transaction
                if (!dbDoc.IsModifiable)
                {
                    revitTransaction = new Transaction(dbDoc, "Create Drafting Pie Chart");
                    revitTransaction.Start();
                }


                // Generate angles for slices
                pieSliceData.ForEach(psd0 => psd0.setAngle(psd0.getValue() / pieSliceData.Sum(psd1 => psd1.getValue()) * 2 * Math.PI));


                double startAngle = 0;
                double currentAngle = 0;
                // Create the sectors
                for (int i = 0; i < pieSliceData.Count; i++)
                {
                    filledRegions.Add(createSector(center, radius_mm, startAngle, startAngle + pieSliceData[i].getAngle(), pieSliceData[i].getColor()));
                    startAngle += pieSliceData[i].getAngle();
                }


                if (revitTransaction != null)
                {
                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }
            }
            catch (Exception ex)
            {
                if (revitTransaction != null)
                {

                    revitTransaction.RollBack();

                    TaskDialog.Show("ERROR MESSAGES", ex.Message);

                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }
            }

            return filledRegions;
        }


        private FilledRegion createSector(XYZ center, double radius_mm, double startAngle, double endAngle, Color color)
        {
            center = convertPointToInternalUnits(center);
            double radius_ft = UnitUtils.ConvertToInternalUnits(radius_mm, UnitTypeId.Millimeters);
            FilledRegion filledRegion = null;

            // Create the arc for the sector
            Arc arc = Arc.Create(center, radius_ft, startAngle, endAngle, XYZ.BasisX, XYZ.BasisY);

            // Create the lines from the center to the arc endpoints
            Autodesk.Revit.DB.Line line1 = Autodesk.Revit.DB.Line.CreateBound(center, arc.GetEndPoint(0));
            Autodesk.Revit.DB.Line line2 = Autodesk.Revit.DB.Line.CreateBound(arc.GetEndPoint(1), center);

            // Create the filled region
            List<Curve> curves = new List<Curve> { line1, arc, line2 };
            CurveLoop curveLoop = CurveLoop.Create(curves);
            List<CurveLoop> curveLoops = new List<CurveLoop> { curveLoop };

            filledRegion = FilledRegion.Create(dbDoc, this.solidFilledRegionType.Id, viewDrafting.Id, new List<CurveLoop> { curveLoop });

            // Set the color of the filled region
            OverrideGraphicSettings overrideSettings = new OverrideGraphicSettings();
            overrideSettings.SetSurfaceForegroundPatternColor(color);
            viewDrafting.SetElementOverrides(filledRegion.Id, overrideSettings);

            return filledRegion;
        }

        public Dictionary<string,List<Autodesk.Revit.DB.Line>> createStockChart(XYZ topLeftCornerPoint, TextNoteType textNoteType, Single chartWidth, 
                                                   Single vSpacing, Single hSpacing, Single hStockMax, Dictionary<string,List<double>> stocksData)
        {
            if (viewDrafting == null) return null;

            Transaction revitTransaction = null;

            Dictionary<string, List<Autodesk.Revit.DB.Line>> linesDict = new Dictionary<string, List<Autodesk.Revit.DB.Line>>();

            try
            {
                //Start New Transaction
                if (!dbDoc.IsModifiable)
                {
                    revitTransaction = new Transaction(dbDoc, "Create Drafting Pie Chart");
                    revitTransaction.Start();
                }


                stocksData.Values.ToList().ForEach(list=>list.Sort());

                String key, label;
                double stockRefX;
                XYZ chartRefPoint = new XYZ(topLeftCornerPoint.X, topLeftCornerPoint.Y, topLeftCornerPoint.Z);
                XYZ lineStartPoint, lineEndPoint;
                List<double> values;

                for (int i = 0; i < stocksData.Count; i++) 
                {
                    
                    key = stocksData.Keys.ToList()[i];
                    stocksData.TryGetValue(key, out values);
                    label = key + " - " + values.Count() + " NO.";
                    chartRefPoint =  new XYZ(chartRefPoint.X, chartRefPoint.Y - vSpacing, chartRefPoint.Z);
                    TextNote labelTextNote = this.createTextNote(textNoteType, chartRefPoint, label);

                    List<Autodesk.Revit.DB.Line> lines = new List<Autodesk.Revit.DB.Line>();
                    LineStyle lineStyle = new LineStyle("ReuseStocksLineStyle", 10, new Color(230, 50, 135));
                    GraphicsStyle graphicsStyle = lineStyle.getGraphicsStyle(dbDoc);

                    double stockScaleRatio=hStockMax / values.Max();
                    double delta;
                    int k=0;

                    for (int j = 0; j < values.Count; j++)
                    {
                        stockRefX= chartRefPoint.X + 2000 + hSpacing * k;
                        
                        if (stockRefX > chartWidth)
                        {
                            chartRefPoint = new XYZ(chartRefPoint.X, chartRefPoint.Y - 600, chartRefPoint.Z);
                            k = 0;
                        }
                        
                        lineStartPoint = new XYZ(chartRefPoint.X+2000+hSpacing*k, chartRefPoint.Y, chartRefPoint.Z);
                        lineEndPoint = new XYZ(lineStartPoint.X, lineStartPoint.Y + values[j]* 2*stockScaleRatio, lineStartPoint.Z);
                        lines.Add(this.createLine(lineStartPoint,lineEndPoint, graphicsStyle));

                        k += 1;
                    }
                    linesDict.Add(label, lines);
                }

                if (revitTransaction != null)
                {
                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }
            }
            catch (Exception ex)
            {
                if (revitTransaction != null)
                {

                    revitTransaction.RollBack();

                    TaskDialog.Show("ERROR MESSAGES", ex.Message);

                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }
            }

            return linesDict;
        }

    }
}
