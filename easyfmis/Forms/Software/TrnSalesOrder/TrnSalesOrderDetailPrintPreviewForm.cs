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

namespace easyfmis.Forms.Software.TrnSalesOrder
{
    public partial class TrnSalesOrderDetailPrintPreviewForm : Form
    {
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());
        public Int32 SOId;

        public TrnSalesOrderDetailPrintPreviewForm(Int32 filterSOId)
        {
            InitializeComponent();
            SOId = filterSOId;

            GeneratePDFSalesOrderDetail();
        }

        private void GeneratePDFSalesOrderDetail()
        {
            try
            {
                var fileName = "C:/EasyERPPDF/SalesOrder_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
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
                tableHeader.AddCell(new PdfPCell(new Phrase("Sales Order", fontArial13Bold)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyAddress, fontArial09)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(branch, fontArial09)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Rowspan = 3 });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyContactNumber, fontArial09)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyTaxNumber, fontArial09)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(headerLine)) { Border = 0, Colspan = 2 });
                document.Add(tableHeader);

                var salesOrder = from d in db.TrnSalesOrders where d.Id == Convert.ToInt32(SOId) && d.IsLocked == true select d;
                if (salesOrder.Any())
                {
                    var currentSOPrefix = "SO";

                    String soldTo = salesOrder.FirstOrDefault().MstArticle.Article;

                    String address = salesOrder.FirstOrDefault().MstArticle.Address;
                    String contactPerson = salesOrder.FirstOrDefault().MstArticle.ContactPerson;
                    String contactNumber = salesOrder.FirstOrDefault().MstArticle.ContactNumber;

                    String salesNo = salesOrder.FirstOrDefault().SONumber;
                    String TIN = salesOrder.FirstOrDefault().MstArticle.TIN;
                    String salesDate = salesOrder.FirstOrDefault().SODate.ToShortDateString();

                    String manualSONumber = salesOrder.FirstOrDefault().ManualSONumber;
                    String documentReference = "";

                    String businessStyle = salesOrder.FirstOrDefault().MstArticle.MstArticleGroup.ArticleGroup;
                    String term = salesOrder.FirstOrDefault().MstTerm.Term;
                    String salesPerson = salesOrder.FirstOrDefault().MstUser4.FullName;

                    String salesRemarks = salesOrder.FirstOrDefault().Remarks;
                    if (salesOrder.FirstOrDefault().Remarks.Equals("NA") || salesOrder.FirstOrDefault().Remarks.Equals("na")) { salesRemarks = ""; }

                    String preparedBy = salesOrder.FirstOrDefault().MstUser3.FullName;
                    String checkedBy = salesOrder.FirstOrDefault().MstUser1.FullName;
                    String approvedBy = salesOrder.FirstOrDefault().MstUser.FullName;

                    PdfPTable tableSalesOrder = new PdfPTable(4);
                    tableSalesOrder.SetWidths(new float[] { 65f, 150f, 70f, 80f });
                    tableSalesOrder.WidthPercentage = 100;
                    tableSalesOrder.AddCell(new PdfPCell(new Phrase("Sold To: ", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesOrder.AddCell(new PdfPCell(new Phrase(soldTo, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesOrder.AddCell(new PdfPCell(new Phrase("No.:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableSalesOrder.AddCell(new PdfPCell(new Phrase(currentSOPrefix + "-" + salesOrder.FirstOrDefault().MstBranch.BranchCode + "-" + salesNo, fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });

                    tableSalesOrder.AddCell(new PdfPCell(new Phrase("TIN:  ", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesOrder.AddCell(new PdfPCell(new Phrase(TIN, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesOrder.AddCell(new PdfPCell(new Phrase("Date: ", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableSalesOrder.AddCell(new PdfPCell(new Phrase(salesDate, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });

                    tableSalesOrder.AddCell(new PdfPCell(new Phrase("Address: ", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesOrder.AddCell(new PdfPCell(new Phrase(address, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesOrder.AddCell(new PdfPCell(new Phrase(currentSOPrefix + " Ref. No.: ", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableSalesOrder.AddCell(new PdfPCell(new Phrase(manualSONumber, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });

                    tableSalesOrder.AddCell(new PdfPCell(new Phrase("Contact Person: ", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesOrder.AddCell(new PdfPCell(new Phrase(contactPerson, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesOrder.AddCell(new PdfPCell(new Phrase("Doc. Ref. No.: ", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableSalesOrder.AddCell(new PdfPCell(new Phrase(documentReference, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });

                    tableSalesOrder.AddCell(new PdfPCell(new Phrase("Contact No.: ", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesOrder.AddCell(new PdfPCell(new Phrase(contactNumber, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesOrder.AddCell(new PdfPCell(new Phrase("Sales Person: ", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableSalesOrder.AddCell(new PdfPCell(new Phrase(salesPerson, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });

                    tableSalesOrder.AddCell(new PdfPCell(new Phrase("Business Style: ", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesOrder.AddCell(new PdfPCell(new Phrase(businessStyle, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesOrder.AddCell(new PdfPCell(new Phrase("Remarks: ", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableSalesOrder.AddCell(new PdfPCell(new Phrase(salesRemarks, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });

                    tableSalesOrder.AddCell(new PdfPCell(new Phrase("Term: ", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesOrder.AddCell(new PdfPCell(new Phrase(term, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableSalesOrder.AddCell(new PdfPCell(new Phrase("", fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, Colspan = 2 });

                    document.Add(tableSalesOrder);

                    PdfPTable spaceTable = new PdfPTable(1);
                    spaceTable.SetWidths(new float[] { 100f });
                    spaceTable.WidthPercentage = 100;
                    spaceTable.AddCell(new PdfPCell(new Phrase(" ", fontArial10Bold)) { Border = 0, PaddingTop = 5f });
                    document.Add(spaceTable);

                    var salesOrderItems = from d in salesOrder.FirstOrDefault().TrnSalesOrderItems select d;
                    if (salesOrderItems.Any())
                    {
                        PdfPTable tableSalesOrderItems = new PdfPTable(7);
                        tableSalesOrderItems.SetWidths(new float[] { 50f, 50f, 70f, 250f, 80f, 70f, 100f });
                        tableSalesOrderItems.WidthPercentage = 100;
                        tableSalesOrderItems.AddCell(new PdfPCell(new Phrase("Qty.", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableSalesOrderItems.AddCell(new PdfPCell(new Phrase("Unit", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableSalesOrderItems.AddCell(new PdfPCell(new Phrase("Code", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableSalesOrderItems.AddCell(new PdfPCell(new Phrase("Description", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableSalesOrderItems.AddCell(new PdfPCell(new Phrase("Particulars", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableSalesOrderItems.AddCell(new PdfPCell(new Phrase("Price", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableSalesOrderItems.AddCell(new PdfPCell(new Phrase("Amount", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });

                        Decimal totalAmount = 0;
                        Decimal count = 0;

                        foreach (var salesOrderItem in salesOrderItems)
                        {
                            count += 1;

                            float paddingBottom = 3f;
                            if (count == salesOrderItems.Count())
                            {
                                paddingBottom = 6f;
                            }

                            String particulars = "";

                            tableSalesOrderItems.AddCell(new PdfPCell(new Phrase(salesOrderItem.Quantity.ToString("#,##0.00"), fontArial10)) { Border = 0, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableSalesOrderItems.AddCell(new PdfPCell(new Phrase(salesOrderItem.MstUnit.Unit, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableSalesOrderItems.AddCell(new PdfPCell(new Phrase(salesOrderItem.MstArticle.ArticleBarCode, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableSalesOrderItems.AddCell(new PdfPCell(new Phrase(salesOrderItem.MstArticle.Article, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableSalesOrderItems.AddCell(new PdfPCell(new Phrase(particulars, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableSalesOrderItems.AddCell(new PdfPCell(new Phrase(salesOrderItem.NetPrice.ToString("#,##0.00"), fontArial10)) { Border = 0, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableSalesOrderItems.AddCell(new PdfPCell(new Phrase(salesOrderItem.Amount.ToString("#,##0.00"), fontArial10)) { Border = 0, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });

                            if (salesOrderItem.MstDiscount.Discount.Equals("Senior Citizen Discount") || salesOrderItem.MstDiscount.Discount.Equals("PWD"))
                            {
                                totalAmount += salesOrderItem.Price * salesOrderItem.Quantity;
                            }
                            else
                            {
                                totalAmount += salesOrderItem.Amount;
                            }
                        }

                        tableSalesOrderItems.AddCell(new PdfPCell(new Phrase("Total", fontArial10Bold)) { Colspan = 6, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                        tableSalesOrderItems.AddCell(new PdfPCell(new Phrase(totalAmount.ToString("#,##0.00"), fontArial10Bold)) { HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });

                        document.Add(tableSalesOrderItems);
                        document.Add(spaceTable);

                        //if (currentUser.FirstOrDefault().IsIncludeTotalQuantityPerUnit)
                        //{
                        //    PdfPTable tableUnits = new PdfPTable(3);
                        //    tableUnits.SetWidths(new float[] { 50f, 50f, 300f });
                        //    tableUnits.WidthPercentage = 100;
                        //    tableUnits.AddCell(new PdfPCell(new Phrase("Unit", fontArial09Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                        //    tableUnits.AddCell(new PdfPCell(new Phrase("Quantity", fontArial09Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                        //    tableUnits.AddCell(new PdfPCell(new Phrase(" ", fontArial09Bold)) { HorizontalAlignment = 1, Border = 0, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });

                        //    var salesOrderItemUnits = from d in salesOrder.FirstOrDefault().TrnSalesOrderItems
                        //                              group d by new
                        //                              {
                        //                                  d.MstUnit.Unit,
                        //                              } into g
                        //                              select new
                        //                              {
                        //                                  g.Key.Unit,
                        //                                  Quantity = g.Sum(d => d.Quantity)
                        //                              };

                        //    if (salesOrderItemUnits.Any())
                        //    {
                        //        foreach (var salesOrderItemUnit in salesOrderItemUnits)
                        //        {
                        //            tableUnits.AddCell(new PdfPCell(new Phrase(salesOrderItemUnit.Unit, fontArial09)) { PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                        //            tableUnits.AddCell(new PdfPCell(new Phrase(salesOrderItemUnit.Quantity.ToString("#,##0.00"), fontArial09)) { HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                        //            tableUnits.AddCell(new PdfPCell(new Phrase(" ", fontArial10)) { Border = 0, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                        //        }
                        //    }

                        //    document.Add(tableUnits);
                        //}

                        //if (currentUser.FirstOrDefault().IsSIVATAnalysisIncluded)
                        //{
                        //    var vatItems = from d in salesOrder.FirstOrDefault().TrnSalesOrderItems group d by new { d.MstTaxType.TaxType, d.MstDiscount.Discount } into g select g;
                        //    Decimal totalVATAmount = vatItems.Where(d => d.Key.Discount != "Senior Citizen Discount" || d.Key.Discount != "PWD").Sum(d => d.Sum(g => g.VATAmount));
                        //    Decimal totalVATAmountSenior = vatItems.Where(d => d.Key.Discount == "Senior Citizen Discount" || d.Key.Discount == "PWD").Sum(d => d.Sum(g => ((g.MstArticle.MstTaxType.TaxRate / 100) * (g.Price * g.Quantity) / ((g.MstArticle.MstTaxType.TaxRate / 100) + 1))));

                        //    Decimal totalAmountNetofVAT = totalAmount - (totalVATAmount + totalVATAmountSenior);

                        //    var vatableSalesItems = from d in salesOrderItems where d.MstTaxType.TaxType.Equals("VAT Output") select d;
                        //    var vatExemptItems = from d in salesOrderItems
                        //                         where d.MstTaxType.TaxType.Equals("VAT Exempt") && !(d.MstDiscount.Discount.Equals("Senior Citizen Discount") || d.MstDiscount.Discount.Equals("PWD"))
                        //                         select d;

                        //    var vatExemptItemsSenior = from d in salesOrderItems
                        //                               where d.MstTaxType.TaxType.Equals("VAT Exempt") && (d.MstDiscount.Discount.Equals("Senior Citizen Discount") || d.MstDiscount.Discount.Equals("PWD"))
                        //                               select d;

                        //    var vatExemptAmount = vatExemptItems.Sum(d => d.Amount) + vatExemptItemsSenior.Sum(g => totalAmount - ((g.MstArticle.MstTaxType.TaxRate / 100) * (g.Price * g.Quantity) / ((g.MstArticle.MstTaxType.TaxRate / 100) + 1)));

                        //    var vatZeroRatedItems = from d in salesOrderItems where d.MstTaxType.TaxType.Equals("VAT Zero Rated") select d;
                        //    var lessSCPWDDiscount = from d in salesOrderItems where d.MstDiscount.Discount.Equals("Senior Citizen Discount") || d.MstDiscount.Discount.Equals("PWD") select d;

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
    }
}
