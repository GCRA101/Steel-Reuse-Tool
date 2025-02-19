using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Media.Imaging;
using Microsoft.Office.Interop.Excel;
using ReuseSchemeTool.model;

public class ExcelDataManager
{
    // ATTRIBUTES
    private Application ExcelApp;
    private Workbook ExcelWkb;
    private Worksheet ExcelWks;

    private string filePath;

    // CONSTRUCTORS
    public ExcelDataManager(string filePath = "")
    {
        // Throw an exception if the input filepath provided doesn't correspond to an excel file
        if (filePath != "" && !(filePath.Contains(".xlsx") || filePath.Contains(".xlsm") || filePath.Contains(".xls")))
        {
            throw new InvalidFilePathException("The filepath provided doesn't correspond to an excel file.");
        }
        // Assign the filePath attribute with the filePath string input if this corresponds to an excel file
        this.filePath = filePath;
    }

    public void openEmbeddedExcelFile(string embeddedFilePath, string outputFilePath)
    {
        Stream excelStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(filePath);

        // Create a temporary file
        File.WriteAllBytes(outputFilePath, ReadFully(excelStream));

        // Open the Excel file using Interop
        Application excelApp = new Application();
        excelApp.Visible = true;
        Workbook workbook = excelApp.Workbooks.Open(outputFilePath);

        workbook.Close(true);
        excelApp.Quit();
        
    }


    // Helper method to read the stream fully
    private static byte[] ReadFully(Stream input)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            input.CopyTo(ms);
            return ms.ToArray();
        }
    }



    // METHODS
    public void Initialize()
    {
        // 1. INITIALIZE EXCEL APPLICATION
        ExcelApp = new Application();
        ExcelApp.Visible = true;

        // 2. OPEN/CREATE EXCEL WORKBOOK
        if (filePath == "")
        {
            ExcelWkb = ExcelApp.Workbooks.Add();
        }
        else if (filePath.Contains(".xlsx") || filePath.Contains(".xlsm") || filePath.Contains(".xls"))
        {
            ExcelWkb = ExcelApp.Workbooks.Open(filePath);
        }
    }

    //public void Write(string worksheetName, List<FrameDecorator> data, string headerTitle = "")
    //{
    //    // 1. OPEN/CREATE EXCEL WORKSHEET
    //    if (ExcelWks == null)
    //    {
    //        if (ExcelWkb.Worksheets.Cast<Worksheet>().Select(wks => wks.Name).Contains(worksheetName))
    //        {
    //            ExcelWks = ExcelWkb.Worksheets[worksheetName];
    //        }
    //        else
    //        {
    //            ExcelWks = ExcelWkb.Worksheets.Add();
    //            ExcelWks.Name = worksheetName;
    //            ExcelWkb.Sheets["Sheet1"].Delete();
    //        }
    //        //ExcelWks.Tab.ColorIndex = 6;
    //        ExcelWks.Activate();
    //    }

    //    // 2. POSITION ACTIVE CELL
    //    if (ExcelWks.Range["B4"].Value == null)
    //    {
    //        ExcelWks.Range["B4"].Activate();
    //    }
    //    else
    //    {
    //        ExcelWks.Range["B4"].End[XlDirection.xlToRight].Offset[0, 1].Activate();
    //    }

    //    // 3. WRITE DATA IN THE WORKSHEET
    //    for (int i = 0; i < data.Count; i++)
    //    {
    //        // 3.1 Get PileObject Data

    //        // Get pile object attribute names and values in a dictionary format
    //        //Dictionary<string, string> pileObjData = data[i];

    //        // 3.2 Create Headers

    //        if (i == 0)
    //        {
    //            // Create Secondary Excel Headers with the names of the pile object attributes
    //            int k = 0;
    //            pileObjData.Keys.ToList().ForEach(key =>
    //            {
    //                ExcelApp.ActiveCell.Offset[0, k].Value = key;
    //                k++;
    //            });

    //            // Create Primary Excel Header with input header title if provided
    //            if (headerTitle != "")
    //            {
    //                Range headerRange = ExcelApp.Range[ExcelApp.ActiveCell.Offset[-1, 0],
    //                    ExcelApp.ActiveCell.End[XlDirection.xlToRight].Offset[-1, 0]];
    //                headerRange.Merge();
    //                headerRange.Value = headerTitle;
    //                FormatRange(headerRange, ExcelRangeType.HEADER_PRIMARY);
    //            }

    //            // Assign Range Format to Secondary Excel Headers
    //            Range subHeaderRange = ExcelApp.Range[ExcelApp.ActiveCell,
    //                ExcelApp.ActiveCell.End[XlDirection.xlToRight]];
    //            FormatRange(subHeaderRange, ExcelRangeType.HEADER_SECONDARY);
    //        }

    //        // 3.3 Write PileObject Data into the cells below the headers
    //        for (int j = 0; j < pileObjData.Count; j++)
    //        {
    //            ExcelApp.ActiveCell.Offset[i + 1, j].Value = pileObjData.Values.ElementAt(j);
    //        }
    //    }
    //}

    public void SetFilePath(string filePath)
    {
        if (filePath != "" && !(filePath.Contains(".xlsx") || filePath.Contains(".xlsm") || filePath.Contains(".xls")))
        {
            throw new InvalidFilePathException("The filepath provided doesn't correspond to an excel file.");
        }
        this.filePath = filePath;
    }

    public void Dispose()
    {
        if (this.filePath != "")
        {
            ExcelWkb.Save();
            ExcelWkb.Close();
            ExcelApp = null;
        }
    }

    //public void FormatRange(Range range, ExcelRangeType excelRangeType)
    //{
    //    // Assign specific Range Format based on input ExcelRangeType Enum value
    //    switch (excelRangeType)
    //    {
    //        case ExcelRangeType.HEADER_PRIMARY:
    //            // Call private FormatRange() method with pre-set inputs
    //            FormatRange(range, "Segoe UI", 10, true, XlHAlign.xlHAlignCenter, XlVAlign.xlVAlignCenter, XlLineStyle.xlContinuous,
    //                XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexNone, XlPattern.xlPatternLinearGradient, 90,
    //                XlThemeColor.xlThemeColorAccent6, false);
    //            break;
    //        case ExcelRangeType.HEADER_SECONDARY:
    //            // Call private FormatRange() method with pre-set inputs
    //            FormatRange(range, interiorColor: 19);
    //            break;
    //        case ExcelRangeType.NORMAL:
    //            // Call private FormatRange() method with pre-set inputs
    //            FormatRange(range);
    //            break;
    //    }
    //}

    private void FormatRange(Range range, string fontName = "Segoe UI", int fontSize = 10, bool fontBold = false,
    XlHAlign textHorAlignment = XlHAlign.xlHAlignCenter, XlVAlign textVertAlignment = XlVAlign.xlVAlignCenter,
    XlLineStyle borderLineStyle = XlLineStyle.xlContinuous, XlBorderWeight borderLineWeight = XlBorderWeight.xlThin,
        XlColorIndex interiorColor = XlColorIndex.xlColorIndexNone, XlPattern interiorPattern = XlPattern.xlPatternNone,
        int gradientDegree = 0, XlThemeColor gradientThemeColor = XlThemeColor.xlThemeColorDark1, bool autoFit = true)
    {
        // Font
        range.Font.Name = fontName;
        range.Font.Bold = fontBold;
        range.Font.Size = fontSize;

        // Text Alignment
        range.HorizontalAlignment = textHorAlignment;
        range.VerticalAlignment = textVertAlignment;

        // Color Pattern
        if (interiorPattern != XlPattern.xlPatternNone)
        {
            range.Interior.ColorIndex = interiorColor;
            range.Interior.Pattern = interiorPattern;
            range.Interior.Gradient.Degree = gradientDegree;
            range.Interior.Gradient.ColorStops.Add(0).ThemeColor = gradientThemeColor;
            range.Interior.Gradient.ColorStops.Add(0).TintAndShade = 0.400006103701895;
        }

        // Edges
        XlBordersIndex[] edgeTypes = { XlBordersIndex.xlEdgeLeft, XlBordersIndex.xlEdgeTop,
                                       XlBordersIndex.xlEdgeRight, XlBordersIndex.xlEdgeBottom };

        edgeTypes.ToList().ForEach(edgeType =>
        {
            range.Borders[edgeType].LineStyle = borderLineStyle;
            range.Borders[edgeType].Weight = borderLineWeight;
        });

        // Autofit
        if (autoFit) range.EntireColumn.AutoFit();
    }
}