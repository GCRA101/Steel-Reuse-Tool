using System.IO;
using System.Security.Cryptography;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;

/// <summary>
///     <remarks>
///         Interface that defines the methods that all the concrete classes 
///         responsible for the creation of Excel charts must implement.
///     </remarks>
/// </summary>
/// 
public interface ExcelChartFactoryInterface
{
    void setChartType(XlChartType chartType);
    void setChartTitle(string title, bool hasTitle = true);
    void setChartAxis(string axisTitle, XlAxisType axisType, XlAxisGroup axisGroup,
                      Range sourceData, XlDataLabelPosition labelsPosition);
    void setChartSeries(List<string> names, string valuesRangeAddress, XlOrientation labelsOrientation, int labelsFontSize);
    void setChartFormatThreeD();
    void setTabProperties(string name, XlColorIndex color);
}