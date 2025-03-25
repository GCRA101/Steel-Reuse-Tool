using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Autodesk.Revit.DB.SpecTypeId;

namespace ReuseSchemeTool.model.revit
{
    public class ViewDraftingsFactory
    {

        /* ATTRIBUTES */
        //Private instance - SINGLETON PATTERN
        private static ViewDraftingsFactory instance;
        private ViewDraftingBuilder builder;

        /* CONSTRUCTORS */
        //Private Default Constructor - SINGLETON PATTERN
        private ViewDraftingsFactory() { }

        /* METHODS */

        //getInstance Method - SINGLETON PATTERN
        public static ViewDraftingsFactory getInstance()
        {
            if (instance == null)
            { return new ViewDraftingsFactory(); }
            return instance;
        }


        public ViewDrafting createLegend(Autodesk.Revit.DB.ViewDrafting viewDrafting, string title, List<string> itemNames, List<Color> itemColors)
        {
            builder = new ViewDraftingBuilder(viewDrafting.Document, viewDrafting);
            
            TextNoteType titleNoteType =builder.createTextNoteType("Legend_Title", "Segoe UI", 5, true);
            TextNoteType itemNoteType = builder.createTextNoteType("Legend_Item", "Segoe UI", 4, false);
            builder.createTextNote(titleNoteType,new XYZ(0,400,0),title.ToUpper());
            builder.createLine(new XYZ(0, 200, 0), new XYZ(3000, 200, 0));

            for (int i = 0; i < itemNames.Count; i++) {
                builder.createRectangle(new XYZ(0, 0-i*300, 0),200,200, itemColors[i]);
                builder.createTextNote(itemNoteType, new XYZ(300, -300/4 - i * 300, 0), itemNames[i]);
            }

            return builder.getViewDrafting();
        }


        public ViewDrafting createNotesBox(Autodesk.Revit.DB.ViewDrafting viewDrafting, string title, List<string> items, Color bulletPointsColor)
        {
            builder = new ViewDraftingBuilder(viewDrafting.Document, viewDrafting);

            TextNoteType titleNoteType = builder.createTextNoteType("Legend_Title", "Segoe UI", 5, true);
            TextNoteType itemNoteType = builder.createTextNoteType("Legend_Item", "Segoe UI", 4, false);
            builder.createTextNote(titleNoteType, new XYZ(0, 400, 0), title.ToUpper());
            builder.createLine(new XYZ(0, 200, 0), new XYZ(3000, 200, 0));

            for (int i = 0; i < items.Count; i++)
            {
                builder.createCircle(new XYZ(50, 0 - i * 200, 0), 30, bulletPointsColor);
                builder.createTextNote(itemNoteType, new XYZ(200, 0 - i * 200, 0), items[i]);
            }

            return builder.getViewDrafting();
        }


        public ViewDrafting createPieChart(Autodesk.Revit.DB.ViewDrafting viewDrafting, List<PieSliceData> pieSlicesData, string title, string subTitle=null, string units=null, bool showPercentages=false)
        {
            builder = new ViewDraftingBuilder(viewDrafting.Document, viewDrafting);

            TextNoteType titleNoteType = builder.createTextNoteType("PieChart_Title", "Segoe UI", 5, true);
            TextNoteType itemNoteType = builder.createTextNoteType("PieChart_Item", "Segoe UI", 4, false);
            
            builder.createTextNote(titleNoteType, new XYZ(0, 400, 0), title.ToUpper());
            builder.createLine(new XYZ(0, 200, 0), new XYZ(4000, 200, 0));

            if (subTitle != null)
            {
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                builder.createTextNote(titleNoteType, new XYZ(0, 100, 0), textInfo.ToTitleCase(subTitle.ToLower()));
            }

            builder.createPieChart(new XYZ(800, -850, 0), 800, pieSlicesData, showPercentages, itemNoteType);

            for (int i = 0; i<pieSlicesData.Count();i++) 
            {
                FilledRegion circle = builder.createCircle(new XYZ(2000, -500 - i * 240, 0), 80, pieSlicesData[i].getColor());
                if (units!=null) builder.createTextNote(itemNoteType, new XYZ(2200, -500 - i * 240, 0), pieSlicesData[i].getName() + " - [" + pieSlicesData[i].getValue().ToString() + " " + units + "]");
                else builder.createTextNote(itemNoteType, new XYZ(2200, -500 - i * 240, 0), pieSlicesData[i].getName());
            }


            return builder.getViewDrafting();
        }

        public ViewDrafting createBarChart(Autodesk.Revit.DB.ViewDrafting viewDrafting, string title, List<ChartData> chartData, BarChartType barChartType, string notes=null, bool ascendingSort=false, bool dataLabels=false)
        {
            builder = new ViewDraftingBuilder(viewDrafting.Document, viewDrafting);

            TextNoteType titleNoteType = builder.createTextNoteType("StackedBarChart_Title", "Segoe UI", 5, true);
            TextNoteType itemNoteType = builder.createTextNoteType("StackedBarChart_Item", "Segoe UI", 2, false);

            builder.createTextNote(titleNoteType, new XYZ(0, 800, 0), title.ToUpper());
            builder.createLine(new XYZ(0, 600, 0), new XYZ(2000, 600, 0));

            if (notes!=null) builder.createTextNote(itemNoteType, new XYZ(0, 300, 0),notes);

            switch (barChartType)
            {
                case (BarChartType.CLUSTERED):
                    /* TO BE IMPLEMENTED */
                    break;
                case (BarChartType.STACKED):
                    builder.createStackedBarChart(new XYZ(0, 0, 0), itemNoteType, chartData, 200, 2000,ascendingSort,dataLabels);
                    break;
            }

            return builder.getViewDrafting();
        }


        public ViewDrafting createStockChart(Autodesk.Revit.DB.ViewDrafting viewDrafting, string title, Dictionary<string,List<double>> stocksData, Color stackColor=null)
        {
            builder = new ViewDraftingBuilder(viewDrafting.Document, viewDrafting);

            TextNoteType titleNoteType = builder.createTextNoteType("StockChart_Title", "Segoe UI", 5, true);
            TextNoteType itemNoteType = builder.createTextNoteType("StockChart_Item", "Segoe UI", 2, false);

            builder.createTextNote(titleNoteType, new XYZ(0, 400, 0), title.ToUpper());
            builder.createLine(new XYZ(0, 200, 0), new XYZ(4000, 200, 0));
            if (stackColor == null) stackColor = new Color(150, 150, 150);
            builder.createStockChart(new XYZ(0, -50, 0), itemNoteType, 4000, 600, 3000, 200, 20, 80, stocksData,stackColor);

            return builder.getViewDrafting();
        }


    }
}
