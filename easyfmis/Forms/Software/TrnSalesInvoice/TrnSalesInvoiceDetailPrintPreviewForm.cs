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

        private void Print() {
            if (PrintPreference == "Sales Invoice") { GeneratePDFSalesInvoiceDetailFitToLayout(); }
            if (PrintPreference == "Packing List") { GeneratePDFSalesInvoiceDetail(); }
        }

        private void GeneratePDFSalesInvoiceDetail()
        {
            try
            {
                var fileName = "C:/EasyERPPDF/SalesInvoice_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                var currentUser = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;

                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));

                document.Open();

                iTextSharp.text.Font fontArial09 = FontFactory.GetFont("Arial", 09);
                iTextSharp.text.Font fontArial09Italic = FontFactory.GetFont("Arial", 09, iTextSharp.text.Font.ITALIC);
                iTextSharp.text.Font fontArial10 = FontFactory.GetFont("Arial", 10);
                iTextSharp.text.Font fontArial10Bold = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font fontArial13Bold = FontFactory.GetFont("Arial", 13, iTextSharp.text.Font.BOLD);

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
                tableHeader.AddCell(new PdfPCell(new Phrase(companyName, fontArial13Bold)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase("Sales Invoice", fontArial13Bold)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyAddress, fontArial09)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(branch, fontArial09)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Rowspan = 3 });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyContactNumber, fontArial09)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyTaxNumber, fontArial09)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(headerLine)) { Border = 0, Colspan = 2 });
                document.Add(tableHeader);

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

                    PdfPTable tableSalesInvoice = new PdfPTable(4);
                    tableSalesInvoice.SetWidths(new float[] { 65f, 150f, 70f, 80f });
                    tableSalesInvoice.WidthPercentage = 100;
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Sold To: ", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(soldTo, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("No.:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(currentSIPrefix + "-" + salesInvoice.FirstOrDefault().MstBranch.BranchCode + "-" + salesNo, fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });

                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("TIN:  ", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(TIN, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Date: ", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(salesDate, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });

                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Address: ", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(address, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(currentSIPrefix + " Ref. No.: ", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(manualSINumber, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });

                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Contact Person: ", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(contactPerson, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Doc. Ref. No.: ", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(documentReference, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });

                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Contact No.: ", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(contactNumber, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Sales Person: ", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(salesPerson, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });

                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Business Style: ", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(businessStyle, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Remarks: ", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(salesRemarks, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });

                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("Term: ", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(term, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase("", fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, Colspan = 2 });

                    document.Add(tableSalesInvoice);

                    PdfPTable spaceTable = new PdfPTable(1);
                    spaceTable.SetWidths(new float[] { 100f });
                    spaceTable.WidthPercentage = 100;
                    spaceTable.AddCell(new PdfPCell(new Phrase(" ", fontArial10Bold)) { Border = 0, PaddingTop = 5f });
                    document.Add(spaceTable);

                    var salesInvoiceItems = from d in salesInvoice.FirstOrDefault().TrnSalesInvoiceItems select d;
                    if (salesInvoiceItems.Any())
                    {
                        PdfPTable tableSalesInvoiceItems = new PdfPTable(7);
                        tableSalesInvoiceItems.SetWidths(new float[] { 50f, 50f, 70f, 250f, 80f, 70f, 100f });
                        tableSalesInvoiceItems.WidthPercentage = 100;
                        tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase("Qty.", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase("Unit", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase("Code", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase("Description", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase("Particulars", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase("Price", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase("Amount", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });

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

                            tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.Quantity.ToString("#,##0.00"), fontArial10)) { Border = 0, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.MstUnit.Unit, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.MstArticle.ArticleBarCode, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.MstArticle.Article, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(particulars, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.NetPrice.ToString("#,##0.00"), fontArial10)) { Border = 0, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.Amount.ToString("#,##0.00"), fontArial10)) { Border = 0, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });

                            if (salesInvoiceItem.MstDiscount.Discount.Equals("Senior Citizen Discount") || salesInvoiceItem.MstDiscount.Discount.Equals("PWD"))
                            {
                                totalAmount += salesInvoiceItem.Price * salesInvoiceItem.Quantity;
                            }
                            else
                            {
                                totalAmount += salesInvoiceItem.Amount;
                            }
                        }

                        tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase("Total", fontArial10Bold)) { Colspan = 6, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                        tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(totalAmount.ToString("#,##0.00"), fontArial10Bold)) { HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });

                        document.Add(tableSalesInvoiceItems);
                        document.Add(spaceTable);

                        //if (currentUser.FirstOrDefault().IsIncludeTotalQuantityPerUnit)
                        //{
                        //    PdfPTable tableUnits = new PdfPTable(3);
                        //    tableUnits.SetWidths(new float[] { 50f, 50f, 300f });
                        //    tableUnits.WidthPercentage = 100;
                        //    tableUnits.AddCell(new PdfPCell(new Phrase("Unit", fontArial09Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                        //    tableUnits.AddCell(new PdfPCell(new Phrase("Quantity", fontArial09Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                        //    tableUnits.AddCell(new PdfPCell(new Phrase(" ", fontArial09Bold)) { HorizontalAlignment = 1, Border = 0, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });

                        //    var salesInvoiceItemUnits = from d in salesInvoice.FirstOrDefault().TrnSalesInvoiceItems
                        //                              group d by new
                        //                              {
                        //                                  d.MstUnit.Unit,
                        //                              } into g
                        //                              select new
                        //                              {
                        //                                  g.Key.Unit,
                        //                                  Quantity = g.Sum(d => d.Quantity)
                        //                              };

                        //    if (salesInvoiceItemUnits.Any())
                        //    {
                        //        foreach (var salesInvoiceItemUnit in salesInvoiceItemUnits)
                        //        {
                        //            tableUnits.AddCell(new PdfPCell(new Phrase(salesInvoiceItemUnit.Unit, fontArial09)) { PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                        //            tableUnits.AddCell(new PdfPCell(new Phrase(salesInvoiceItemUnit.Quantity.ToString("#,##0.00"), fontArial09)) { HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                        //            tableUnits.AddCell(new PdfPCell(new Phrase(" ", fontArial10)) { Border = 0, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                        //        }
                        //    }

                        //    document.Add(tableUnits);
                        //}

                        //if (currentUser.FirstOrDefault().IsSIVATAnalysisIncluded)
                        //{
                        //    var vatItems = from d in salesInvoice.FirstOrDefault().TrnSalesInvoiceItems group d by new { d.MstTaxType.TaxType, d.MstDiscount.Discount } into g select g;
                        //    Decimal totalVATAmount = vatItems.Where(d => d.Key.Discount != "Senior Citizen Discount" || d.Key.Discount != "PWD").Sum(d => d.Sum(g => g.VATAmount));
                        //    Decimal totalVATAmountSenior = vatItems.Where(d => d.Key.Discount == "Senior Citizen Discount" || d.Key.Discount == "PWD").Sum(d => d.Sum(g => ((g.MstArticle.MstTaxType.TaxRate / 100) * (g.Price * g.Quantity) / ((g.MstArticle.MstTaxType.TaxRate / 100) + 1))));

                        //    Decimal totalAmountNetofVAT = totalAmount - (totalVATAmount + totalVATAmountSenior);

                        //    var vatableSalesItems = from d in salesInvoiceItems where d.MstTaxType.TaxType.Equals("VAT Output") select d;
                        //    var vatExemptItems = from d in salesInvoiceItems
                        //                         where d.MstTaxType.TaxType.Equals("VAT Exempt") && !(d.MstDiscount.Discount.Equals("Senior Citizen Discount") || d.MstDiscount.Discount.Equals("PWD"))
                        //                         select d;

                        //    var vatExemptItemsSenior = from d in salesInvoiceItems
                        //                               where d.MstTaxType.TaxType.Equals("VAT Exempt") && (d.MstDiscount.Discount.Equals("Senior Citizen Discount") || d.MstDiscount.Discount.Equals("PWD"))
                        //                               select d;

                        //    var vatExemptAmount = vatExemptItems.Sum(d => d.Amount) + vatExemptItemsSenior.Sum(g => totalAmount - ((g.MstArticle.MstTaxType.TaxRate / 100) * (g.Price * g.Quantity) / ((g.MstArticle.MstTaxType.TaxRate / 100) + 1)));

                        //    var vatZeroRatedItems = from d in salesInvoiceItems where d.MstTaxType.TaxType.Equals("VAT Zero Rated") select d;
                        //    var lessSCPWDDiscount = from d in salesInvoiceItems where d.MstDiscount.Discount.Equals("Senior Citizen Discount") || d.MstDiscount.Discount.Equals("PWD") select d;

                        //    var lessSCPWDDiscountAmount = lessSCPWDDiscount.Sum(d => d.DiscountAmount * d.Quantity);
                        //    var totalAmountDue = totalAmount;

                        //    var amountDue = totalAmountNetofVAT - lessSCPWDDiscountAmount;
                        //    if (lessSCPWDDiscountAmount > 0)
                        //    {
                        //        totalAmountDue = amountDue;
                        //    }

                        //    PdfPTable tableVATAnalysis = new PdfPTable(5);
                        //    tableVATAnalysis.SetWidths(new float[] { 130f, 50f, 30f, 70f, 30f });
                        //    tableVATAnalysis.WidthPercentage = 100;
                        //    tableVATAnalysis.AddCell(new PdfPCell(new Phrase(" ", fontArial09)) { Border = 0, PaddingTop = 10f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                        //    tableVATAnalysis.AddCell(new PdfPCell(new Phrase("VATable Sales:", fontArial09)) { Border = 0, PaddingTop = 10f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                        //    tableVATAnalysis.AddCell(new PdfPCell(new Phrase(vatableSalesItems.Sum(d => d.Amount).ToString("#,##0.00"), fontArial09)) { Border = 0, PaddingTop = 10f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                        //    tableVATAnalysis.AddCell(new PdfPCell(new Phrase("Total Sales (VAT Inclusive).:", fontArial09)) { Border = 0, PaddingTop = 10f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                        //    tableVATAnalysis.AddCell(new PdfPCell(new Phrase(totalAmount.ToString("#,##0.00"), fontArial09)) { Border = 0, PaddingTop = 10f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                        //    tableVATAnalysis.AddCell(new PdfPCell(new Phrase(" ", fontArial09)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                        //    tableVATAnalysis.AddCell(new PdfPCell(new Phrase("VAT Exempt Sales:", fontArial09)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                        //    tableVATAnalysis.AddCell(new PdfPCell(new Phrase(vatExemptAmount.ToString("#,##0.00"), fontArial09)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                        //    tableVATAnalysis.AddCell(new PdfPCell(new Phrase("Less VAT:", fontArial09)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                        //    tableVATAnalysis.AddCell(new PdfPCell(new Phrase((totalVATAmount + totalVATAmountSenior).ToString("#,##0.00"), fontArial09)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                        //    tableVATAnalysis.AddCell(new PdfPCell(new Phrase(" ", fontArial09)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                        //    tableVATAnalysis.AddCell(new PdfPCell(new Phrase("Zero Rated Sales:", fontArial09)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                        //    tableVATAnalysis.AddCell(new PdfPCell(new Phrase(vatZeroRatedItems.Sum(d => d.Amount).ToString("#,##0.00"), fontArial09)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                        //    tableVATAnalysis.AddCell(new PdfPCell(new Phrase("Amount Net of VAT:", fontArial09)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                        //    tableVATAnalysis.AddCell(new PdfPCell(new Phrase(totalAmountNetofVAT.ToString("#,##0.00"), fontArial09)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                        //    tableVATAnalysis.AddCell(new PdfPCell(new Phrase(" ", fontArial09)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                        //    tableVATAnalysis.AddCell(new PdfPCell(new Phrase("VAT Amount:", fontArial09)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                        //    tableVATAnalysis.AddCell(new PdfPCell(new Phrase(totalVATAmount.ToString("#,##0.00"), fontArial09)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                        //    tableVATAnalysis.AddCell(new PdfPCell(new Phrase("Less SC/PWD Discount:", fontArial09)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                        //    tableVATAnalysis.AddCell(new PdfPCell(new Phrase(lessSCPWDDiscount.Sum(d => d.DiscountAmount * d.Quantity).ToString("#,##0.00"), fontArial09)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                        //    tableVATAnalysis.AddCell(new PdfPCell(new Phrase(" ", fontArial09)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, Colspan = 3, HorizontalAlignment = 2 });
                        //    tableVATAnalysis.AddCell(new PdfPCell(new Phrase("TOTAL AMOUNT DUE:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                        //    tableVATAnalysis.AddCell(new PdfPCell(new Phrase(totalAmountDue.ToString("#,##0.00"), fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });

                        //    document.Add(tableVATAnalysis);
                        //}
                    }

                    document.Add(spaceTable);

                    PdfPTable tableUsers = new PdfPTable(4);
                    tableUsers.SetWidths(new float[] { 100f, 100f, 100f, 100f });
                    tableUsers.WidthPercentage = 100;
                    tableUsers.AddCell(new PdfPCell(new Phrase("Prepared by", fontArial10Bold)) { PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase("Checked by", fontArial10Bold)) { PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase("Approved by", fontArial10Bold)) { PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase("Received by", fontArial10Bold)) { PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(" ")) { PaddingBottom = 30f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(" ")) { PaddingBottom = 30f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(" ")) { PaddingBottom = 30f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(" ")) { PaddingBottom = 30f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(preparedBy, fontArial10)) { HorizontalAlignment = 1, PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(checkedBy, fontArial10)) { HorizontalAlignment = 1, PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(approvedBy, fontArial10)) { HorizontalAlignment = 1, PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase("Date Received:", fontArial10Bold)) { HorizontalAlignment = 0, PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
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

        private void GeneratePDFSalesInvoiceDetailFitToLayout()
        {
            try
            {
                var fileName = "C:/EasyERPPDF/SalesInvoice_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                var currentUser = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;

                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));
                document.SetMargins(20f, 10f, 80f, 20f);

                document.Open();

                iTextSharp.text.Font fontArial08 = FontFactory.GetFont("Arial", 08);
                iTextSharp.text.Font fontArial09 = FontFactory.GetFont("Arial", 09);
                iTextSharp.text.Font fontArial09Italic = FontFactory.GetFont("Arial", 09, iTextSharp.text.Font.ITALIC);
                iTextSharp.text.Font fontArial10 = FontFactory.GetFont("Arial", 10);
                iTextSharp.text.Font fontArial10Bold = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font fontArial13 = FontFactory.GetFont("Arial", 13);

                iTextSharp.text.Font fontArial13Bold = FontFactory.GetFont("Arial", 13, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font fontArial20Bold = FontFactory.GetFont("Arial", 20, iTextSharp.text.Font.NORMAL);

                PdfPTable spaceTable = new PdfPTable(1);
                spaceTable.SetWidths(new float[] { 100f });
                spaceTable.WidthPercentage = 100;
                spaceTable.AddCell(new PdfPCell(new Phrase(" ", fontArial10Bold)) { Border = 0, PaddingTop = 5f });


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

                    tableHeader.AddCell(new PdfPCell(new Phrase("", fontArial13)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                    tableHeader.AddCell(new PdfPCell(new Phrase("", fontArial13)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                    tableHeader.AddCell(new PdfPCell(new Phrase("", fontArial13)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                    tableHeader.AddCell(new PdfPCell(new Phrase("", fontArial13)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                    //tableHeader.AddCell(new PdfPCell(new Phrase(salesNo, fontArial13)) { Border = 0, PaddingTop = 7f, HorizontalAlignment = Element.ALIGN_RIGHT, FixedHeight = 28f });
                    tableHeader.AddCell(new PdfPCell(new Phrase(" ", fontArial13)) { Border = 0, PaddingTop = 7f, HorizontalAlignment = Element.ALIGN_RIGHT, FixedHeight = 28f });
                    document.Add(tableHeader);
                    document.Add(spaceTable);

                    PdfPTable tableSalesInvoice = new PdfPTable(6);
                    tableSalesInvoice.SetWidths(new float[] { 23f, 39f, 19f, 29f, 25f, 45f });
                    tableSalesInvoice.WidthPercentage = 100;
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontArial08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(soldTo, fontArial08)) { Colspan = 3, Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontArial08)) { PaddingLeft = 3f, Border = 0, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(salesDate, fontArial08)) { PaddingLeft = 3f, Border = 0, PaddingRight = 5f, HorizontalAlignment = 0, FixedHeight = 12f });


                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontArial08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(TIN, fontArial08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontArial08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontArial08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontArial08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontArial08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });

                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontArial08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(address, fontArial08)) { Colspan = 3, Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 25f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontArial08)) { PaddingLeft = 3f, Border = 0, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(currentSIPrefix + "-" + salesInvoice.FirstOrDefault().MstBranch.BranchCode + "-" + salesNo, fontArial08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, HorizontalAlignment = 0, FixedHeight = 12f });

                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontArial08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, HorizontalAlignment = 0, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(salesPerson, fontArial08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, HorizontalAlignment = 0, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontArial08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(businessStyle, fontArial08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(" ", fontArial08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                    tableSalesInvoice.AddCell(new PdfPCell(new Phrase(term, fontArial08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });

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

                                tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.Quantity.ToString("#,##0.00"), fontArial08)) { Border = 0, HorizontalAlignment = 2, PaddingBottom = paddingBottom, PaddingLeft = 3f, PaddingRight = 5f });
                                tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.MstUnit.Unit, fontArial08)) { Border = 0, HorizontalAlignment = 0, PaddingBottom = paddingBottom, PaddingLeft = 3f, PaddingRight = 5f });
                                tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.MstArticle.Article, fontArial08)) { Border = 0, HorizontalAlignment = 0, PaddingBottom = paddingBottom, PaddingLeft = 3f, PaddingRight = 5f });
                                tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.NetPrice.ToString("#,##0.00"), fontArial08)) { Border = 0, HorizontalAlignment = 2, PaddingBottom = paddingBottom, PaddingLeft = 3f, PaddingRight = 5f });
                                tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(salesInvoiceItem.Amount.ToString("#,##0.00"), fontArial08)) { Border = 0, HorizontalAlignment = 2, PaddingBottom = paddingBottom, PaddingLeft = 3f, PaddingRight = 5f });

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
                        //tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase("Total", fontArial10Bold)) { Colspan = 6, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                        //tableSalesInvoiceItems.AddCell(new PdfPCell(new Phrase(totalAmount.ToString("#,##0.00"), fontArial10Bold)) { HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });

                        //document.Add(tableSalesInvoiceItems);
                        //document.Add(spaceTable);

                        PdfPCell colspan5TableSalesInvoiceItems = new PdfPCell(tableSalesInvoiceItems);
                        colspan5TableSalesInvoiceItems.Colspan = 5;
                        colspan5TableSalesInvoiceItems.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

                        tableSalesInvoiceItemsContainer.AddCell(new PdfPCell(colspan5TableSalesInvoiceItems) { Border = 0, FixedHeight = 250f });

                        PdfPTable tableSalesInvoiceComputation = new PdfPTable(5);
                        tableSalesInvoiceComputation.SetWidths(new float[] { 20f, 45f, 65f, 35f, 35f });
                        tableSalesInvoiceComputation.WidthPercentage = 100;

                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(" ", fontArial08)) { Border = 0, Colspan = 5, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });

                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(" ", fontArial08)) { Border = 0, Colspan = 5, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });

                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(" ", fontArial08)) { Border = 0, Colspan = 5, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });

                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(" ", fontArial08)) { Border = 0, Colspan = 5, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });

                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(" ", fontArial08)) { Border = 0, Colspan = 4, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(zeroRatedSales.ToString("#,##0.00"), fontArial08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 24f, HorizontalAlignment = 2, PaddingTop = 8f, });

                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(" ", fontArial08)) { Border = 0, Colspan = 4, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(_12PercentVat.ToString("#,##0.00"), fontArial08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f, HorizontalAlignment = 2 });

                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(" ", fontArial08)) { Border = 0, Colspan = 4, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f });
                        tableSalesInvoiceComputation.AddCell(new PdfPCell(new Phrase(totalAmount.ToString("#,##0.00"), fontArial08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 12f, HorizontalAlignment = 2 });

                        PdfPCell colspan5TableSalesInvoiceCcomputation = new PdfPCell(tableSalesInvoiceComputation);
                        colspan5TableSalesInvoiceCcomputation.Colspan = 5;
                        colspan5TableSalesInvoiceCcomputation.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

                        tableSalesInvoiceItemsContainer.AddCell(new PdfPCell(colspan5TableSalesInvoiceCcomputation) { Border = 0 });


                        tableSalesInvoiceItemsContainer.AddCell(new PdfPCell(new Phrase(" ", fontArial08)) { Border = 0, Colspan = 5, FixedHeight = 94f });

                        PdfPTable tableSalesInvoiceUser = new PdfPTable(5);
                        tableSalesInvoiceUser.SetWidths(new float[] { 24f, 36f, 24f, 36f, 60f });
                        tableSalesInvoiceUser.WidthPercentage = 100;

                        tableSalesInvoiceUser.AddCell(new PdfPCell(new Phrase("", fontArial08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 36f });
                        tableSalesInvoiceUser.AddCell(new PdfPCell(new Phrase(checkedBy, fontArial08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 36f });
                        tableSalesInvoiceUser.AddCell(new PdfPCell(new Phrase("", fontArial08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 36f });
                        tableSalesInvoiceUser.AddCell(new PdfPCell(new Phrase(approvedBy, fontArial08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 36f });
                        tableSalesInvoiceUser.AddCell(new PdfPCell(new Phrase("", fontArial08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 36f });

                        tableSalesInvoiceUser.AddCell(new PdfPCell(new Phrase("", fontArial08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 36f });
                        tableSalesInvoiceUser.AddCell(new PdfPCell(new Phrase(preparedBy, fontArial08)) { Border = 0, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 36f });
                        tableSalesInvoiceUser.AddCell(new PdfPCell(new Phrase("", fontArial08)) { Border = 0, Colspan = 3, PaddingLeft = 3f, PaddingRight = 5f, FixedHeight = 36f });

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
