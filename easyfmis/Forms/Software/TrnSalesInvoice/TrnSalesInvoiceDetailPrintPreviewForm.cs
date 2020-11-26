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
        public String FontStyle = "Segoe";

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
                var fileName = "C:/EasyERPPDF/PackingList_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                var currentUser = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;

                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));
                document.SetMargins(20f, 20f, 40f, 40f);

                document.Open();

                document.Open();

                iTextSharp.text.Font fontNew07 = FontFactory.GetFont(FontStyle, 07);
                iTextSharp.text.Font fontNew08 = FontFactory.GetFont(FontStyle, 08);
                iTextSharp.text.Font fontNew09 = FontFactory.GetFont(FontStyle, 09);
                iTextSharp.text.Font fontNew09Italic = FontFactory.GetFont(FontStyle, 09, iTextSharp.text.Font.ITALIC);
                iTextSharp.text.Font fontNew10 = FontFactory.GetFont(FontStyle, 10);
                iTextSharp.text.Font fontNew10Bold = FontFactory.GetFont(FontStyle, 10, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font fontNew13Bold = FontFactory.GetFont(FontStyle, 13, iTextSharp.text.Font.BOLD);

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
                tableHeader.AddCell(new PdfPCell(new Phrase(companyName, fontNew13Bold)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase("Packing List", fontNew13Bold)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyAddress, fontNew09)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(branch, fontNew09)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Rowspan = 3 });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyContactNumber, fontNew09)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyTaxNumber, fontNew09)) { Border = 0 });
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

                    String preparedBy = salesInvoice.FirstOrDefault().MstUser.FullName;
                    String checkedBy = salesInvoice.FirstOrDefault().MstUser1.FullName;
                    String approvedBy = salesInvoice.FirstOrDefault().MstUser2.FullName;

                    PdfPTable tableSalesInvoice = new PdfPTable(4);
                    tableSalesInvoice.SetWidths(new float[] { 60f, 165f, 65f, 80f });
                    tableSalesInvoice.WidthPercentage = 100;
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Sold To: ", fontNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(soldTo, fontNew10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("No.:", fontNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(currentSIPrefix + "-" + salesInvoice.FirstOrDefault().MstBranch.BranchCode + "-" + salesNo, fontNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });

                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("TIN:  ", fontNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(TIN, fontNew10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Date: ", fontNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(salesDate, fontNew10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });

                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Address: ", fontNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(address, fontNew09)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(currentSIPrefix + " Ref. No.: ", fontNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(manualSINumber, fontNew10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });

                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Contact Person: ", fontNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(contactPerson, fontNew10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Doc. Ref. No.: ", fontNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(documentReference, fontNew10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });

                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Contact No.: ", fontNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(contactNumber, fontNew10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Sales Person: ", fontNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(salesPerson, fontNew10)) { Border = 0, PaddingTop = 6f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });

                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Business Style: ", fontNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(businessStyle, fontNew10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Term: ", fontNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(term, fontNew10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });

                    //tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Term: ", fontNew10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    //tableSalesInvoice.AddCell(new PdfPCell(new Phrase(term, fontNew10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    //tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontNew10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    ////tableSalesInvoice.AddCell(new PdfPCell(new Phrase("", fontNew10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, Colspan = 2 });

                    document.Add(tableSalesInvoice);

                    PdfPTable spaceTable = new PdfPTable(1);
                    spaceTable.SetWidths(new float[] { 100f });
                    spaceTable.WidthPercentage = 100;
                    spaceTable.AddCell(new PdfPCell(new Phrase(" ", fontNew10Bold)) { Border = 0, PaddingTop = 5f });

                    document.Add(spaceTable);

                    PdfPTable tableSalesInvoiceItemsContainer = new PdfPTable(6);
                    tableSalesInvoiceItemsContainer.SetWidths(new float[] { 50f, 50f, 50f, 50f, 50f, 50f, });
                    tableSalesInvoiceItemsContainer.WidthPercentage = 100;

                    PdfPTable tableSalesInvoiceItems = new PdfPTable(6);
                    tableSalesInvoiceItems.SetWidths(new float[] { 60f, 50f, 110f, 280f, 70f, 100f });
                    tableSalesInvoiceItems.WidthPercentage = 100;

                    var salesInvoiceItems = from d in salesInvoice.FirstOrDefault().TrnSalesInvoiceItems select d;
                    if (salesInvoiceItems.Any())
                    {
                        tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase("Qty.", fontNew10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase("Unit", fontNew10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase("Code", fontNew10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase("Description", fontNew10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase("Price", fontNew10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase("Amount", fontNew10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });

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

                            tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.Quantity.ToString("#,##0"), fontNew09)) { Border = 0, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.MstUnit.Unit, fontNew09)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.MstArticle.ArticleBarCode, fontNew09)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.MstArticle.Article, fontNew09)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.NetPrice.ToString("#,##0.00"), fontNew09)) { Border = 0, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.Amount.ToString("#,##0.00"), fontNew09)) { Border = 0, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });

                            if (salesInvoiceItem.MstDiscount.Discount.Equals("Senior Citizen Discount") || salesInvoiceItem.MstDiscount.Discount.Equals("PWD"))
                            {
                                totalAmount += salesInvoiceItem.Price * salesInvoiceItem.Quantity;
                            }
                            else
                            {
                                totalAmount += salesInvoiceItem.Amount;
                            }

                        }

                        tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase("Total", fontNew10Bold)) { Border= 0,Colspan = 5, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                        tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(totalAmount.ToString("#,##0.00"), fontNew10Bold)) { Border = 0, Colspan = 1, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                    }

                    PdfPCell colspan5SalesInvoiceItem = new PdfPCell(tableSalesInvoiceItems);
                    colspan5SalesInvoiceItem.Colspan = 6;
                    colspan5SalesInvoiceItem.HorizontalAlignment = 1;

                    tableSalesInvoiceItemsContainer.AddCell(new PdfPCell(colspan5SalesInvoiceItem) { Border = 0, FixedHeight = 440f });

                    document.Add(tableSalesInvoiceItemsContainer);

                    document.Add(spaceTable);

                    PdfPTable tableUsers = new PdfPTable(4);
                    tableUsers.SetWidths(new float[] { 100f, 100f, 100f, 100f });
                    tableUsers.WidthPercentage = 100;
                    tableUsers.AddCell(new PdfPCell(new Phrase("Remarks: " + salesRemarks, fontNew10Bold)) { Colspan = 4, Border = 0, PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase("Prepared by", fontNew10Bold)) { PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase("Checked by", fontNew10Bold)) { PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase("Approved by", fontNew10Bold)) { PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase("Received by", fontNew10Bold)) { PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(" ")) { PaddingBottom = 30f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(" ")) { PaddingBottom = 30f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(" ")) { PaddingBottom = 30f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(" ")) { PaddingBottom = 30f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(preparedBy, fontNew10)) { HorizontalAlignment = 1, PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(checkedBy, fontNew10)) { HorizontalAlignment = 1, PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(approvedBy, fontNew10)) { HorizontalAlignment = 1, PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase("Date Received:", fontNew10Bold)) { HorizontalAlignment = 0, PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
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

                iTextSharp.text.Font fontNew08 = FontFactory.GetFont(FontStyle, 08);
                iTextSharp.text.Font fontNew09 = FontFactory.GetFont(FontStyle, 09);
                iTextSharp.text.Font fontNew09Italic = FontFactory.GetFont(FontStyle, 09, iTextSharp.text.Font.ITALIC);
                iTextSharp.text.Font fontNew10 = FontFactory.GetFont(FontStyle, 10);
                iTextSharp.text.Font fontNew10Bold = FontFactory.GetFont(FontStyle, 10, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font fontNew13 = FontFactory.GetFont(FontStyle, 13);

                iTextSharp.text.Font fontNew13Bold = FontFactory.GetFont(FontStyle, 13, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font fontNew20Bold = FontFactory.GetFont(FontStyle, 20, iTextSharp.text.Font.NORMAL);

                PdfPTable spaceTable = new PdfPTable(1);
                spaceTable.SetWidths(new float[] { 100f });
                spaceTable.WidthPercentage = 100;
                spaceTable.AddCell(new PdfPCell(new Phrase(" ", fontNew10Bold)) { Border = 0, PaddingTop = 5f });


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

                    String preparedBy = salesInvoice.FirstOrDefault().MstUser.FullName;
                    String checkedBy = salesInvoice.FirstOrDefault().MstUser1.FullName;
                    String approvedBy = salesInvoice.FirstOrDefault().MstUser2.FullName;

                    tableHeader.AddCell(new PdfPCell(new Phrase("", fontNew13)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                    tableHeader.AddCell(new PdfPCell(new Phrase("", fontNew13)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                    tableHeader.AddCell(new PdfPCell(new Phrase("", fontNew13)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                    tableHeader.AddCell(new PdfPCell(new Phrase("", fontNew13)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                    tableHeader.AddCell(new PdfPCell(new Phrase(" ", fontNew13)) { Border = 0, PaddingTop = 7f, HorizontalAlignment = Element.ALIGN_RIGHT, FixedHeight = 28f });
                    document.Add(tableHeader);
                    document.Add(spaceTable);

                    PdfPTable tableSalesInvoice = new PdfPTable(6);
                    tableSalesInvoice.SetWidths(new float[] { 23f, 39f, 19f, 29f, 25f, 45f });
                    tableSalesInvoice.WidthPercentage = 100;
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(soldTo, fontNew10)) { Colspan = 4, Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 14f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(salesDate, fontNew09)) { PaddingLeft = 3f, Border = 0, PaddingRight = 5f, HorizontalAlignment = 0, FixedHeight = 14f });


                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 14f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(TIN, fontNew09)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 14f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 14f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 14f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 14f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 14f });

                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(address, fontNew09)) { Colspan = 3, Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 25f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontNew08)) { PaddingLeft = 3f, Border = 0, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(manualSINumber, fontNew09)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, HorizontalAlignment = 0, FixedHeight = 14f });

                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, HorizontalAlignment = 0, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("", fontNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, HorizontalAlignment = 0, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("", fontNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(term, fontNew09)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 14f });

                    document.Add(tableSalesInvoice);

                    document.Add(spaceTable);
                    document.Add(spaceTable);

                    PdfPTable tableSalesInvoiceItemsContainer = new PdfPTable(5);
                    tableSalesInvoiceItemsContainer.SetWidths(new float[] { 50f, 50f, 250f, 70f, 100f });
                    tableSalesInvoiceItemsContainer.WidthPercentage = 100;

                    PdfPTable tableSalesInvoiceItems = new PdfPTable(5);
                    tableSalesInvoiceItems.SetWidths(new float[] { 20f, 15f, 95f, 35f, 35f });
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

                                tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.Quantity.ToString("#,##0"), fontNew09)) { Border = 0, HorizontalAlignment = 0, PaddingBottom = paddingBottom, PaddingLeft = 3f, PaddingRight = 5f });
                                tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.MstUnit.Unit, fontNew09)) { Border = 0, HorizontalAlignment = 0, PaddingBottom = paddingBottom, PaddingLeft = 3f, PaddingRight = 5f });
                                tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.MstArticle.ArticleBarCode + "   " + salesInvoiceItem.MstArticle.Article, fontNew09)) { Border = 0, HorizontalAlignment = 0, PaddingBottom = paddingBottom, PaddingLeft = 3f, PaddingRight = 5f });
                                tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.NetPrice.ToString("#,##0.00"), fontNew09)) { Border = 0, HorizontalAlignment = 2, PaddingBottom = paddingBottom, PaddingLeft = 3f, PaddingRight = 5f });
                                tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.Amount.ToString("#,##0.00"), fontNew09)) { Border = 0, HorizontalAlignment = 2, PaddingBottom = paddingBottom, PaddingLeft = 3f, PaddingRight = 5f });

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

                        PdfPCell colspan5TableSalesInvoiceItems = new PdfPCell(tableSalesInvoiceItems);
                        colspan5TableSalesInvoiceItems.Colspan = 5;
                        colspan5TableSalesInvoiceItems.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

                        tableSalesInvoiceItemsContainer.AddCell(new PdfPCell(colspan5TableSalesInvoiceItems) { Border = 0, FixedHeight = 230f });

                        PdfPTable tableSalesInvoiceComputation = new PdfPTable(5);
                        tableSalesInvoiceComputation.SetWidths(new float[] { 20f, 45f, 65f, 35f, 35f });
                        tableSalesInvoiceComputation.WidthPercentage = 100;

                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(" ", fontNew08)) { Border = 0, Colspan = 5, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });

                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(" ", fontNew08)) { Border = 0, Colspan = 5, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });

                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase("", fontNew08)) { Border = 0, Colspan = 5, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });

                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(" ", fontNew08)) { Border = 0, Colspan = 5, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });

                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(" ", fontNew08)) { Border = 0, Colspan = 3, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f, HorizontalAlignment = 1 });
                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(" ", fontNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f, HorizontalAlignment = 2 });
                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(zeroRatedSales.ToString("#,##0.00"), fontNew09)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 24f, HorizontalAlignment = 2, PaddingTop = 8f, });
                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(" ", fontNew08)) { Border = 0, Colspan = 5, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(" ", fontNew08)) { Border = 0, Colspan = 5, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });

                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(" ", fontNew08)) { Border = 0, Colspan = 4, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(_12PercentVat.ToString("#,##0.00"), fontNew09)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 14f, HorizontalAlignment = 2 });

                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(" ", fontNew08)) { Border = 0, Colspan = 4, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(totalAmount.ToString("#,##0.00"), fontNew09)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 14f, HorizontalAlignment = 2 });

                        PdfPCell colspan5TableSalesInvoiceCcomputation = new PdfPCell(tableSalesInvoiceComputation);
                        colspan5TableSalesInvoiceCcomputation.Colspan = 5;
                        colspan5TableSalesInvoiceCcomputation.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

                        tableSalesInvoiceItemsContainer.AddCell(new PdfPCell(colspan5TableSalesInvoiceCcomputation) { Border = 0 });


                        tableSalesInvoiceItemsContainer.AddCell(new PdfPCell(new Phrase(salesRemarks, fontNew09)) { Border = 0, Colspan = 5, FixedHeight = 90f });

                        PdfPTable tableSalesInvoiceUser = new PdfPTable(5);
                        tableSalesInvoiceUser.SetWidths(new float[] { 24f, 36f, 24f, 36f, 60f });
                        tableSalesInvoiceUser.WidthPercentage = 100;

                        tableSalesInvoiceUser.AddCell(new PdfPCell(new Phrase("", fontNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 36f });
                        tableSalesInvoiceUser.AddCell(new PdfPCell(new Phrase(checkedBy, fontNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 36f });
                        tableSalesInvoiceUser.AddCell(new PdfPCell(new Phrase("", fontNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 36f });
                        tableSalesInvoiceUser.AddCell(new PdfPCell(new Phrase(approvedBy, fontNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 36f });
                        tableSalesInvoiceUser.AddCell(new PdfPCell(new Phrase("", fontNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 36f });

                        tableSalesInvoiceUser.AddCell(new PdfPCell(new Phrase("", fontNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 36f });
                        tableSalesInvoiceUser.AddCell(new PdfPCell(new Phrase(preparedBy, fontNew08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 36f });
                        tableSalesInvoiceUser.AddCell(new PdfPCell(new Phrase("", fontNew08)) { Border = 0, Colspan = 3, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 36f });

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
