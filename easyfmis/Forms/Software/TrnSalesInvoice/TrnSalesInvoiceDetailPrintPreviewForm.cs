using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace easyfmis.Forms.Software.TrnSalesInvoice
{
    public partial class TrnSalesInvoiceDetailPrintPreviewForm : Form
    {
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());
        public Int32 SIId;
        String PrintPreference;

        public TrnSalesInvoiceDetailPrintPreviewForm(Int32 filterSIId, String printPreferenceFilter)
        {
            InitializeComponent();
            SIId = filterSIId;
            PrintPreference = printPreferenceFilter;

            Print();
        }

        private void Print()
        {
            if (PrintPreference == "Sales Invoice") { GeneratePDFSalesInvoice(); }
            if (PrintPreference == "Packing List") { GeneratePDFSalesInvoiceDRDetail(); }
        }
        //=============
        // Packing List
        //=============
        private void GeneratePDFSalesInvoiceDRDetail()
        {
            try
            {
                var fileName = "C:/EasyERPPDF/SalesInvoice_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                var currentUser = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;

                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));
                document.SetMargins(20f, 20f, 40f, 40f);

                document.Open();

                document.Open();

                iTextSharp.text.Font fontCourierNew07 = FontFactory.GetFont("Courier", 07);
                iTextSharp.text.Font fontCourierNew08 = FontFactory.GetFont("Courier", 08);
                iTextSharp.text.Font fontCourierNew09 = FontFactory.GetFont("Courier", 09);
                iTextSharp.text.Font fontCourierNew09Italic = FontFactory.GetFont("Courier", 09, iTextSharp.text.Font.ITALIC);
                iTextSharp.text.Font fontCourierNew10 = FontFactory.GetFont("Courier", 10);
                iTextSharp.text.Font fontCourierNew10Bold = FontFactory.GetFont("Courier", 10, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font fontCourierNew13Bold = FontFactory.GetFont("Courier", 13, iTextSharp.text.Font.BOLD);

                Paragraph headerLine = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(2F, 100.0F, BaseColor.BLACK, Element.ALIGN_MIDDLE, 5F)));
                Paragraph footerLine = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0F, 100.0F, BaseColor.BLACK, Element.ALIGN_MIDDLE, 5F)));

                var companyName = currentUser.FirstOrDefault().MstCompany.Company;
                var branch = currentUser.FirstOrDefault().MstBranch.Branch;
                var companyAddress = "";
                var companyContactNumber = "";
                var companyTaxNumber = "";

                PdfPTable tableHeader = new PdfPTable(2);
                tableHeader.SetWidths(new float[] { 70f, 30f });
                tableHeader.WidthPercentage = 100;
                tableHeader.AddCell(new PdfPCell(new Phrase(companyName, fontCourierNew13Bold)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase("Packing List", fontCourierNew13Bold)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyAddress, fontCourierNew09)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(branch, fontCourierNew09)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Rowspan = 3 });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyContactNumber, fontCourierNew09)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyTaxNumber, fontCourierNew09)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(headerLine)) { Border = 0, Colspan = 2 });
                document.Add(tableHeader);

                var salesInvoice = from d in db.TrnSalesInvoices where d.Id == Convert.ToInt32(SIId) && d.IsLocked == true select d;
                if (salesInvoice.Any())
                {
                    var currentSIPrefix = "DR";

                    String soldTo = salesInvoice.FirstOrDefault().MstArticle.Article;

                    String address = salesInvoice.FirstOrDefault().MstArticle.Address;
                    String contactPerson = salesInvoice.FirstOrDefault().MstArticle.ContactPerson;
                    String contactNumber = salesInvoice.FirstOrDefault().MstArticle.ContactNumber;

                    String salesNo = salesInvoice.FirstOrDefault().SINumber;
                    String TIN = salesInvoice.FirstOrDefault().MstArticle.TIN;
                    String salesDate = salesInvoice.FirstOrDefault().SIDate.ToShortDateString();

                    String manualSINumber = salesInvoice.FirstOrDefault().ManualSINumber;
                    String documentReference = "";

                    String businessStyle = salesInvoice.FirstOrDefault().MstArticle.MstArticleGroup.ArticleGroup;
                    String term = salesInvoice.FirstOrDefault().MstTerm.Term;
                    String salesPerson = salesInvoice.FirstOrDefault().MstUser5.FullName;

                    String salesRemarks = salesInvoice.FirstOrDefault().Remarks;
                    if (salesInvoice.FirstOrDefault().Remarks.Equals("NA") || salesInvoice.FirstOrDefault().Remarks.Equals("na")) { salesRemarks = ""; }

                    String preparedBy = salesInvoice.FirstOrDefault().MstUser3.FullName;
                    String checkedBy = salesInvoice.FirstOrDefault().MstUser1.FullName;
                    String approvedBy = salesInvoice.FirstOrDefault().MstUser.FullName;

                    PdfPTable tableSalesInvoice = new PdfPTable(4);
                    tableSalesInvoice.SetWidths(new float[] { 70f, 150f, 65f, 80f });
                    tableSalesInvoice.WidthPercentage = 100;
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Sold To: ", fontCourierNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(soldTo, fontCourierNew10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("No.:", fontCourierNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(currentSIPrefix + "-" + salesInvoice.FirstOrDefault().MstBranch.BranchCode + "-" + salesNo, fontCourierNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });

                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("TIN:  ", fontCourierNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(TIN, fontCourierNew10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Date: ", fontCourierNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(salesDate, fontCourierNew10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });

                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Address: ", fontCourierNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(address, fontCourierNew10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(currentSIPrefix + " Ref. No.: ", fontCourierNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(manualSINumber, fontCourierNew10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });

                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Contact Person: ", fontCourierNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(contactPerson, fontCourierNew10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Doc. Ref. No.: ", fontCourierNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(documentReference, fontCourierNew10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });

                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Contact No.: ", fontCourierNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(contactNumber, fontCourierNew10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Sales Person: ", fontCourierNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(salesPerson, fontCourierNew07)) { Border = 0, PaddingTop = 6f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });

                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Business Style: ", fontCourierNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(businessStyle, fontCourierNew10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Remarks: ", fontCourierNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(salesRemarks, fontCourierNew10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });

                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Term: ", fontCourierNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(term, fontCourierNew10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("", fontCourierNew10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, Colspan = 2 });

                    document.Add(tableSalesInvoice);

                    PdfPTable spaceTable = new PdfPTable(1);
                    spaceTable.SetWidths(new float[] { 100f });
                    spaceTable.WidthPercentage = 100;
                    spaceTable.AddCell(new PdfPCell(new Phrase(" ", fontCourierNew10Bold)) { Border = 0, PaddingTop = 5f });
                    document.Add(spaceTable);

                    var salesInvoiceItems = from d in salesInvoice.FirstOrDefault().TrnSalesInvoiceItems select d;
                    if (salesInvoiceItems.Any())
                    {
                        PdfPTable tableSalesInvoiceItems = new PdfPTable(6);
                        tableSalesInvoiceItems.SetWidths(new float[] { 60f, 50f, 110f, 280f, 70f, 100f });
                        tableSalesInvoiceItems.WidthPercentage = 100;
                        tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase("Qty.", fontCourierNew10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase("Unit", fontCourierNew10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase("Code", fontCourierNew10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase("Description", fontCourierNew10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        //tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase("Particulars", fontCourierNew10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase("Price", fontCourierNew10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase("Amount", fontCourierNew10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });

                        Decimal totalAmount = 0;
                        Decimal count = 0;

                        foreach (var salesInvoiceItem in salesInvoiceItems)
                        {
                            count += 1;

                            float paddingBottom = 3f;
                            if (count == salesInvoiceItems.Count())
                            {
                                paddingBottom = 6f;
                            }

                            String particulars = "";

                            tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.Quantity.ToString("#,##0.00"), fontCourierNew08)) { Border = 0, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.MstUnit.Unit, fontCourierNew08)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.MstArticle.ArticleBarCode, fontCourierNew08)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.MstArticle.Article, fontCourierNew08)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            //tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(particulars, fontCourierNew10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.NetPrice.ToString("#,##0.00"), fontCourierNew08)) { Border = 0, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.Amount.ToString("#,##0.00"), fontCourierNew08)) { Border = 0, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });

                            if (salesInvoiceItem.MstDiscount.Discount.Equals("Senior Citizen Discount") || salesInvoiceItem.MstDiscount.Discount.Equals("PWD"))
                            {
                                totalAmount += salesInvoiceItem.Price * salesInvoiceItem.Quantity;
                            }
                            else
                            {
                                totalAmount += salesInvoiceItem.Amount;
                            }
                        }

                        tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase("Total", fontCourierNew10Bold)) { Colspan = 6, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                        tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(totalAmount.ToString("#,##0.00"), fontCourierNew10Bold)) { Border = 0, Colspan = 6, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });

                        document.Add(tableSalesInvoiceItems);
                        document.Add(spaceTable);
                    }

                    document.Add(spaceTable);

                    PdfPTable tableUsers = new PdfPTable(4);
                    tableUsers.SetWidths(new float[] { 100f, 100f, 100f, 100f });
                    tableUsers.WidthPercentage = 100;
                    tableUsers.AddCell(new PdfPCell(new Phrase("Prepared by", fontCourierNew10Bold)) { PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase("Checked by", fontCourierNew10Bold)) { PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase("Approved by", fontCourierNew10Bold)) { PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase("Received by", fontCourierNew10Bold)) { PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(" ")) { PaddingBottom = 30f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(" ")) { PaddingBottom = 30f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(" ")) { PaddingBottom = 30f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(" ")) { PaddingBottom = 30f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(preparedBy, fontCourierNew10)) { HorizontalAlignment = 1, PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(checkedBy, fontCourierNew10)) { HorizontalAlignment = 1, PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(approvedBy, fontCourierNew10)) { HorizontalAlignment = 1, PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase("Date Received:", fontCourierNew10Bold)) { HorizontalAlignment = 0, PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    document.Add(tableUsers);
                    document.Add(spaceTable);
                }

                document.Close();

                Process.Start(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //==============
        // Sales Invoice
        //==============
        private void GeneratePDFSalesInvoice()
        {
            try
            {
                var fileName = "C:/EasyERPPDF/SalesInvoice_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                var currentUser = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;

                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));
                document.SetMargins(20f, 10f, 80f, 20f);

                document.Open();

                iTextSharp.text.Font fontCourierNew08 = FontFactory.GetFont("Courier", 08);
                iTextSharp.text.Font fontCourierNew09 = FontFactory.GetFont("Courier", 09);
                iTextSharp.text.Font fontCourierNew09Italic = FontFactory.GetFont("Courier", 09, iTextSharp.text.Font.ITALIC);
                iTextSharp.text.Font fontCourierNew10 = FontFactory.GetFont("Courier", 10);
                iTextSharp.text.Font fontCourierNew10Bold = FontFactory.GetFont("Courier", 10, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font fontCourierNew13 = FontFactory.GetFont("Courier", 13);

                iTextSharp.text.Font fontCourierNew13Bold = FontFactory.GetFont("Courier", 13, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font fontCourierNew20Bold = FontFactory.GetFont("Courier", 20, iTextSharp.text.Font.NORMAL);

                PdfPTable spaceTable = new PdfPTable(1);
                spaceTable.SetWidths(new float[] { 100f });
                spaceTable.WidthPercentage = 100;
                spaceTable.AddCell(new PdfPCell(new Phrase(" ", fontCourierNew10Bold)) { Border = 0, PaddingTop = 5f });


                Paragraph headerLine = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(2F, 100.0F, BaseColor.BLACK, Element.ALIGN_MIDDLE, 5F)));
                Paragraph footerLine = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0F, 100.0F, BaseColor.BLACK, Element.ALIGN_MIDDLE, 5F)));

                var companyName = currentUser.FirstOrDefault().MstCompany.Company;
                var branch = currentUser.FirstOrDefault().MstBranch.Branch;


                PdfPTable tableHeader = new PdfPTable(5);
                tableHeader.SetWidths(new float[] { 40f, 40f, 40f, 40f, 40f });
                tableHeader.WidthPercentage = 100;


                var salesInvoice = from d in db.TrnSalesInvoices where d.Id == Convert.ToInt32(SIId) && d.IsLocked == true select d;
                if (salesInvoice.Any())
                {
                    var currentSIPrefix = "SI";

                    String soldTo = salesInvoice.FirstOrDefault().MstArticle.Article;

                    String address = salesInvoice.FirstOrDefault().MstArticle.Address;
                    String contactPerson = salesInvoice.FirstOrDefault().MstArticle.ContactPerson;
                    String contactNumber = salesInvoice.FirstOrDefault().MstArticle.ContactNumber;

                    String salesNo = salesInvoice.FirstOrDefault().SINumber;
                    String TIN = salesInvoice.FirstOrDefault().MstArticle.TIN;
                    String salesDate = salesInvoice.FirstOrDefault().SIDate.ToShortDateString();

                    String manualSINumber = salesInvoice.FirstOrDefault().ManualSINumber;
                    String documentReference = "";

                    String businessStyle = salesInvoice.FirstOrDefault().MstArticle.MstArticleGroup.ArticleGroup;
                    String term = salesInvoice.FirstOrDefault().MstTerm.Term;
                    String salesPerson = salesInvoice.FirstOrDefault().MstUser4.FullName;

                    String salesRemarks = salesInvoice.FirstOrDefault().Remarks;
                    if (salesInvoice.FirstOrDefault().Remarks.Equals("NA") || salesInvoice.FirstOrDefault().Remarks.Equals("na")) { salesRemarks = ""; }

                    String preparedBy = salesInvoice.FirstOrDefault().MstUser3.FullName;
                    String checkedBy = salesInvoice.FirstOrDefault().MstUser1.FullName;
                    String approvedBy = salesInvoice.FirstOrDefault().MstUser.FullName;

                    tableHeader.AddCell(new PdfPCell(new Phrase("", fontCourierNew13)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                    tableHeader.AddCell(new PdfPCell(new Phrase("", fontCourierNew13)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                    tableHeader.AddCell(new PdfPCell(new Phrase("", fontCourierNew13)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                    tableHeader.AddCell(new PdfPCell(new Phrase("", fontCourierNew13)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                    //tableHeader.AddCell(new PdfPCell(new Phrase(salesNo, fontCourier13)) { Border = 0, PaddingTop = 7f, HorizontalAlignment = Element.ALIGN_RIGHT, FixedHeight = 28f });
                    tableHeader.AddCell(new PdfPCell(new Phrase(" ", fontCourierNew13)) { Border = 0, PaddingTop = 7f, HorizontalAlignment = Element.ALIGN_RIGHT, FixedHeight = 28f });
                    document.Add(tableHeader);
                    document.Add(spaceTable);

                    PdfPTable tableSalesInvoice = new PdfPTable(6);
                    tableSalesInvoice.SetWidths(new float[] { 23f, 39f, 19f, 29f, 25f, 45f });
                    tableSalesInvoice.WidthPercentage = 100;
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(soldTo, fontCourierNew08)) { Colspan = 3, Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontCourierNew08)) { PaddingLeft = 3f, Border = 0, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(salesDate, fontCourierNew08)) { PaddingLeft = 3f, Border = 0, PaddingRight = 5f, HorizontalAlignment = 0, FixedHeight = 12f });


                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(TIN, fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });

                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(address, fontCourierNew08)) { Colspan = 3, Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 25f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontCourierNew08)) { PaddingLeft = 3f, Border = 0, PaddingRight = 5f, FixedHeight = 12f });
                    //tableSalesInvoice.AddCell(new PdfPCell(new Phrase(currentSIPrefix + "-" + salesInvoice.FirstOrDefault().MstBranch.BranchCode + "-" + salesNo, fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, HorizontalAlignment = 0, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(manualSINumber, fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, HorizontalAlignment = 0, FixedHeight = 12f });

                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, HorizontalAlignment = 0, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("", fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, HorizontalAlignment = 0, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("", fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(term, fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });

                    document.Add(tableSalesInvoice);

                    document.Add(spaceTable);
                    document.Add(spaceTable);

                    PdfPTable tableSalesInvoiceItemsContainer = new PdfPTable(5);
                    tableSalesInvoiceItemsContainer.SetWidths(new float[] { 50f, 50f, 250f, 70f, 100f });
                    tableSalesInvoiceItemsContainer.WidthPercentage = 100;

                    PdfPTable tableSalesInvoiceItems = new PdfPTable(5);
                    tableSalesInvoiceItems.SetWidths(new float[] { 20f, 45f, 65f, 35f, 35f });
                    tableSalesInvoiceItems.WidthPercentage = 100;

                    var salesInvoiceItems = from d in salesInvoice.FirstOrDefault().TrnSalesInvoiceItems select d;
                    Decimal totalAmount = 0;
                    Decimal zeroRatedSales = 0;
                    Decimal _12PercentVat = 0;


                    Decimal count = 0;

                    if (salesInvoiceItems.Any())
                    {
                        if (count < 19)
                        {
                            foreach (var salesInvoiceItem in salesInvoiceItems)
                            {
                                count += 1;

                                float paddingBottom = 3f;
                                if (count == salesInvoiceItems.Count())
                                {
                                    paddingBottom = 6f;
                                }

                                tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.Quantity.ToString("#,##0.00"), fontCourierNew08)) { Border = 0, HorizontalAlignment = 2, PaddingBottom = paddingBottom, PaddingLeft = 3f, PaddingRight = 5f });
                                tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.MstUnit.Unit, fontCourierNew08)) { Border = 0, HorizontalAlignment = 0, PaddingBottom = paddingBottom, PaddingLeft = 3f, PaddingRight = 5f });
                                tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.MstArticle.Article, fontCourierNew08)) { Border = 0, HorizontalAlignment = 0, PaddingBottom = paddingBottom, PaddingLeft = 3f, PaddingRight = 5f });
                                tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.NetPrice.ToString("#,##0.00"), fontCourierNew08)) { Border = 0, HorizontalAlignment = 2, PaddingBottom = paddingBottom, PaddingLeft = 3f, PaddingRight = 5f });
                                tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.Amount.ToString("#,##0.00"), fontCourierNew08)) { Border = 0, HorizontalAlignment = 2, PaddingBottom = paddingBottom, PaddingLeft = 3f, PaddingRight = 5f });

                                if (salesInvoiceItem.MstDiscount.Discount.Equals("Senior Citizen Discount") || salesInvoiceItem.MstDiscount.Discount.Equals("PWD"))
                                {
                                    totalAmount += salesInvoiceItem.Price * salesInvoiceItem.Quantity;
                                }
                                else
                                {
                                    totalAmount += salesInvoiceItem.Amount;
                                }
                            }
                        }

                        zeroRatedSales = totalAmount / Convert.ToDecimal(1.12);
                        _12PercentVat = totalAmount - zeroRatedSales;
                        //tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase("Total", fontCourierNew10Bold)) { Colspan = 6, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                        //tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(totalAmount.ToString("#,##0.00"), fontCourierNew10Bold)) { HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });

                        //document.Add(tableSalesInvoiceItems);
                        //document.Add(spaceTable);

                        PdfPCell colspan5TableSalesInvoiceItems = new PdfPCell(tableSalesInvoiceItems);
                        colspan5TableSalesInvoiceItems.Colspan = 5;
                        colspan5TableSalesInvoiceItems.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

                        tableSalesInvoiceItemsContainer.AddCell(new PdfPCell(colspan5TableSalesInvoiceItems) { Border = 0, FixedHeight = 250f });

                        PdfPTable tableSalesInvoiceComputation = new PdfPTable(5);
                        tableSalesInvoiceComputation.SetWidths(new float[] { 20f, 45f, 65f, 35f, 35f });
                        tableSalesInvoiceComputation.WidthPercentage = 100;

                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(" ", fontCourierNew08)) { Border = 0, Colspan = 5, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });

                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(" ", fontCourierNew08)) { Border = 0, Colspan = 5, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });

                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase("", fontCourierNew08)) { Border = 0, Colspan = 5, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });

                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(" ", fontCourierNew08)) { Border = 0, Colspan = 5, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });

                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(salesRemarks, fontCourierNew08)) { Border = 0, Colspan = 3, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f, HorizontalAlignment = 2 });
                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(" ", fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f, HorizontalAlignment = 2 });
                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(zeroRatedSales.ToString("#,##0.00"), fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 24f, HorizontalAlignment = 2, PaddingTop = 8f, });

                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(" ", fontCourierNew08)) { Border = 0, Colspan = 4, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(_12PercentVat.ToString("#,##0.00"), fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f, HorizontalAlignment = 2 });

                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(" ", fontCourierNew08)) { Border = 0, Colspan = 4, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(totalAmount.ToString("#,##0.00"), fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f, HorizontalAlignment = 2 });

                        PdfPCell colspan5TableSalesInvoiceCcomputation = new PdfPCell(tableSalesInvoiceComputation);
                        colspan5TableSalesInvoiceCcomputation.Colspan = 5;
                        colspan5TableSalesInvoiceCcomputation.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

                        tableSalesInvoiceItemsContainer.AddCell(new PdfPCell(colspan5TableSalesInvoiceCcomputation) { Border = 0 });


                        tableSalesInvoiceItemsContainer.AddCell(new PdfPCell(new Phrase(" ", fontCourierNew08)) { Border = 0, Colspan = 5, FixedHeight = 94f });

                        PdfPTable tableSalesInvoiceUser = new PdfPTable(5);
                        tableSalesInvoiceUser.SetWidths(new float[] { 24f, 36f, 24f, 36f, 60f });
                        tableSalesInvoiceUser.WidthPercentage = 100;

                        tableSalesInvoiceUser.AddCell(new PdfPCell(new Phrase("", fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 36f });
                        tableSalesInvoiceUser.AddCell(new PdfPCell(new Phrase(checkedBy, fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 36f });
                        tableSalesInvoiceUser.AddCell(new PdfPCell(new Phrase("", fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 36f });
                        tableSalesInvoiceUser.AddCell(new PdfPCell(new Phrase(approvedBy, fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 36f });
                        tableSalesInvoiceUser.AddCell(new PdfPCell(new Phrase("", fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 36f });

                        tableSalesInvoiceUser.AddCell(new PdfPCell(new Phrase("", fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 36f });
                        tableSalesInvoiceUser.AddCell(new PdfPCell(new Phrase(preparedBy, fontCourierNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 36f });
                        tableSalesInvoiceUser.AddCell(new PdfPCell(new Phrase("", fontCourierNew08)) { Border = 0, Colspan = 3, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 36f });

                        PdfPCell colspan5TableSalesInvoiceUser = new PdfPCell(tableSalesInvoiceUser);
                        colspan5TableSalesInvoiceUser.Colspan = 5;
                        colspan5TableSalesInvoiceUser.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

                        tableSalesInvoiceItemsContainer.AddCell(new PdfPCell(colspan5TableSalesInvoiceUser) { Border = 0 });


                        document.Add(tableSalesInvoiceItemsContainer);
                        document.Add(spaceTable);
                    }
                }

                document.Close();

                Process.Start(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
