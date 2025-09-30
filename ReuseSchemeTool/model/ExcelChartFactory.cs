using Microsoft.Office.Core;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;

public class ExcelChartFactory : ExcelChartFactoryInterface
{
    // ATTRIBUTES
    private Workbook excelWkb;
    private Chart chart;

    // CONSTRUCTOR
    // Overloaded
    public ExcelChartFactory(Workbook excelWkb)
    {
        this.excelWkb = excelWkb;
    }

    // METHODS
    public void create(Microsoft.Office.Interop.Excel.XlChartType chartType, string chartTitle, string xAxisTitle,
                       Range xAxisSourceData, string yAxisTitle, List<string> seriesNames,
                       string seriesValuesRangeAddress, string tabName, 
                       Microsoft.Office.Interop.Excel.XlColorIndex tabColor)
    {
        this.addChart(tabName, tabColor);
        this.excelWkb.Sheets[tabName].Move(After: this.excelWkb.Sheets[this.excelWkb.Sheets.Count]);
        this.setChartType(chartType);
        this.setChartTitle(chartTitle);
        this.setChartAxis(xAxisTitle, Microsoft.Office.Interop.Excel.XlAxisType.xlCategory, 
                          Microsoft.Office.Interop.Excel.XlAxisGroup.xlPrimary, xAxisSourceData,
                          Microsoft.Office.Interop.Excel.XlDataLabelPosition.xlLabelPositionOutsideEnd);

        this.setChartSeries(seriesNames, seriesValuesRangeAddress, XlOrientation.xlUpward, 7);

        this.setChartFormatThreeD();
    }

    private void addChart(string name, Microsoft.Office.Interop.Excel.XlColorIndex color, bool deleteOtherCharts = false)
    {
        // Delete pre-existing Charts
        if (deleteOtherCharts) this.excelWkb.Charts.Delete();
        // Create new Chart
        this.chart = excelWkb.Charts.Add();
        // Assign Name and Color to Tab
        this.chart.Name = name;
        this.chart.Tab.ColorIndex = color;
    }

    // Methods Implemented from Interface ChartFactoryInterface
    public void setTabProperties(string name, Microsoft.Office.Interop.Excel.XlColorIndex color)
    {
        throw new NotImplementedException();
    }

    public void setChartType(Microsoft.Office.Interop.Excel.XlChartType chartType)
    {
        this.chart.ChartType = chartType;
    }

    public void setChartTitle(string title, bool hasTitle = true)
    {
        this.chart.HasTitle = hasTitle;
        this.chart.ChartTitle.Text = title;
    }

    public void setChartAxis(string axisTitle, Microsoft.Office.Interop.Excel.XlAxisType axisType, 
                                Microsoft.Office.Interop.Excel.XlAxisGroup axisGroup, Range sourceData, 
                                Microsoft.Office.Interop.Excel.XlDataLabelPosition labelsPosition)
    {
        if (axisType == Microsoft.Office.Interop.Excel.XlAxisType.xlCategory)
        {
            this.chart.SetElement(MsoChartElementType.msoElementPrimaryCategoryAxisTitleAdjacentToAxis);
        }
        else
        {
            this.chart.SetElement(MsoChartElementType.msoElementPrimaryValueAxisTitleAdjacentToAxis);
        }

        this.chart.Axes(axisType, axisGroup).AxisTitle.Text = axisTitle;
        this.chart.SetSourceData(sourceData);
    }

    public void setChartSeries(List<string> names, string valuesRangeAddress, XlOrientation labelsOrientation, int labelsFontSize)
    {
        for (int i = 0; i < names.Count; i++)
        {
            var series = this.chart.FullSeriesCollection(i + 1);
            series.Name = names[i];
            series.XValues = valuesRangeAddress;
        }
    }

    public void setChartFormatThreeD()
    {
        for (int i = 0; i < this.chart.SeriesCollection().Count(); i++)
        {
            var series = this.chart.FullSeriesCollection(i + 1).Format.ThreeD;
            series.BevelTopType = MsoBevelType.msoBevelCircle;
            series.BevelTopInset = 2;
            series.BevelTopDepth = 2;
        }
    }

}