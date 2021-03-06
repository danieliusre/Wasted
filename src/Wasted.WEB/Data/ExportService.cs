using System;
using System.IO;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Drawing;
using System.Collections.Generic;

public class ExportService
{

    public MemoryStream CreatePdfTable<T>(List<T> dataModel, string header, string text)
    {
        if (dataModel == null)
        {
            throw new ArgumentNullException("dataModel is null");
        }
        //Create a new PDF document
        using (PdfDocument pdfDocument = new PdfDocument())
        {

            int paragraphAfterSpacing = 8;
            int cellMargin = 8;

            //Add page to the PDF document
            PdfPage page = pdfDocument.Pages.Add();

            //Create a new font
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);

            //Create a text element to draw a text in PDF page
            PdfTextElement title = new PdfTextElement(header, font, PdfBrushes.Black);
            PdfLayoutResult result = title.Draw(page, new PointF(0, 0));


            PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
            PdfTextElement content = new PdfTextElement(text, contentFont, PdfBrushes.Black);
            PdfLayoutFormat format = new PdfLayoutFormat();
            format.Layout = PdfLayoutType.Paginate;

            //Draw a text to the PDF document
            result = content.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

            //Create a PdfGrid
            PdfGrid pdfGrid = new PdfGrid();
            pdfGrid.Style.CellPadding.Left = cellMargin;
            pdfGrid.Style.CellPadding.Right = cellMargin;

            //Applying built-in style to the PDF grid
            pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent1);

            //Assign data source
            pdfGrid.DataSource = dataModel;

            pdfGrid.Style.Font = contentFont;

            //Draw PDF grid into the PDF page
            pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));

            using (MemoryStream stream = new MemoryStream())
            {
                //Saving the PDF document into the stream
                pdfDocument.Save(stream);
                //Closing the PDF document
                pdfDocument.Close(true);
                return stream;
                    
            }
        }
    }
}
