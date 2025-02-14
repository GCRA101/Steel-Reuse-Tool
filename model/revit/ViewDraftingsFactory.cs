using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            
            TextNoteType titleNoteType =builder.createTextNoteType("Legend_Title", "Segoe UI", 10, true);
            TextNoteType itemNoteType = builder.createTextNoteType("Legend_Item", "Segoe UI", 5, false);
            builder.createTextNote(titleNoteType,new XYZ(0,400,0),title.ToUpper());
            builder.createLine(new XYZ(0, 200, 0), new XYZ(3000, 200, 0));

            for (int i = 0; i < itemNames.Count; i++) {
                builder.createRectangle(new XYZ(0, 0-i*600, 0),300,300, itemColors[i]);
                builder.createTextNote(itemNoteType, new XYZ(400, -300/2 - i * 600, 0), itemNames[i]);
            }

            return builder.getViewDrafting();
        }


        public ViewDrafting createPieChart(Autodesk.Revit.DB.ViewDrafting viewDrafting, string title, List<PieSliceData> pieSlicesData, string units)
        {
            builder = new ViewDraftingBuilder(viewDrafting.Document, viewDrafting);

            TextNoteType titleNoteType = builder.createTextNoteType("PieChart_Title", "Segoe UI", 10, true);
            TextNoteType itemNoteType = builder.createTextNoteType("PieChart_Item", "Segoe UI", 5, false);
            
            builder.createTextNote(titleNoteType, new XYZ(0, 400, 0), title.ToUpper());
            builder.createLine(new XYZ(0, 200, 0), new XYZ(6000, 200, 0));
            builder.createPieChart(new XYZ(1000, -1400, 0), 1000, pieSlicesData);

            for (int i = 0; i<pieSlicesData.Count();i++) 
            {
                FilledRegion circle = builder.createCircle(new XYZ(3000, -500 - i * 400, 0), 100, pieSlicesData[i].getColor());
                builder.createTextNote(itemNoteType, new XYZ(3200, -500 - i * 400, 0), pieSlicesData[i].getName() + " - [" + pieSlicesData[i].getValue().ToString() + " " + units + "]");
            }


            return builder.getViewDrafting();
        }

        public ViewDrafting createBarChart(Autodesk.Revit.DB.ViewDrafting viewDrafting)
        {
            builder = new ViewDraftingBuilder(viewDrafting.Document, viewDrafting);


            return builder.getViewDrafting();
        }

        public ViewDrafting createStockChart(Autodesk.Revit.DB.ViewDrafting viewDrafting, string title, Dictionary<string,List<double>> stocksData)
        {
            builder = new ViewDraftingBuilder(viewDrafting.Document, viewDrafting);

            TextNoteType titleNoteType = builder.createTextNoteType("StockChart_Title", "Segoe UI", 10, true);
            TextNoteType itemNoteType = builder.createTextNoteType("StockChart_Item", "Segoe UI", 5, false);

            builder.createTextNote(titleNoteType, new XYZ(0, 400, 0), title.ToUpper());
            builder.createLine(new XYZ(0, 200, 0), new XYZ(6000, 200, 0));
            builder.createStockChart(new XYZ(0, -200, 0), itemNoteType, 15000, 1000, 100,250, stocksData);

            return builder.getViewDrafting();
        }


    }
}
