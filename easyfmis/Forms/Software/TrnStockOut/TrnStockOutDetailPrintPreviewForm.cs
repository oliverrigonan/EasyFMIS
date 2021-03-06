﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace easyfmis.Forms.Software.TrnStockOut
{
    public partial class TrnStockOutDetailPrintPreviewForm : Form
    {
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());
        public Int32 OTId;

        public TrnStockOutDetailPrintPreviewForm(Int32 filterOTId)
        {
            InitializeComponent();
            OTId = filterOTId;

            GeneratePDFStockOutDetail();
        }

        private void GeneratePDFStockOutDetail()
        {
            try
            {
                var fileName = "C:/EasyERPPDF/StockOut_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
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
                tableHeader.AddCell(new PdfPCell(new Phrase("Stock-Out", fontArial13Bold)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyAddress, fontArial09)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(branch, fontArial09)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Rowspan = 3 });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyContactNumber, fontArial09)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyTaxNumber, fontArial09)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(headerLine)) { Border = 0, Colspan = 2 });
                document.Add(tableHeader);

                var stockOut = from d in db.TrnStockOuts where d.Id == Convert.ToInt32(OTId) && d.IsLocked == true select d;
                if (stockOut.Any())
                {
                    String remarks = stockOut.FirstOrDefault().Remarks;
                    String OTNumber = stockOut.FirstOrDefault().OTNumber;
                    String OTDate = stockOut.FirstOrDefault().OTDate.ToShortDateString();
                    String preparedBy = stockOut.FirstOrDefault().MstUser3.FullName;
                    String checkedBy = stockOut.FirstOrDefault().MstUser1.FullName;
                    String approvedBy = stockOut.FirstOrDefault().MstUser.FullName;

                    PdfPTable tableStockOut = new PdfPTable(4);
                    tableStockOut.SetWidths(new float[] { 40f, 150f, 70f, 70f });
                    tableStockOut.WidthPercentage = 100;
                    tableStockOut.AddCell(new PdfPCell(new Phrase("No.:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableStockOut.AddCell(new PdfPCell(new Phrase("OT-" + stockOut.FirstOrDefault().MstBranch.BranchCode + "-" + OTNumber, fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableStockOut.AddCell(new PdfPCell(new Phrase("Remarks:", fontArial10Bold)) { Rowspan = 2, Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableStockOut.AddCell(new PdfPCell(new Phrase(remarks, fontArial10)) { Rowspan = 2, Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableStockOut.AddCell(new PdfPCell(new Phrase("Date:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableStockOut.AddCell(new PdfPCell(new Phrase(OTDate, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    document.Add(tableStockOut);

                    PdfPTable spaceTable = new PdfPTable(1);
                    spaceTable.SetWidths(new float[] { 100f });
                    spaceTable.WidthPercentage = 100;
                    spaceTable.AddCell(new PdfPCell(new Phrase(" ", fontArial10Bold)) { Border = 0, PaddingTop = 5f });
                    document.Add(spaceTable);

                    var stockOutItems = from d in stockOut.FirstOrDefault().TrnStockOutItems select d;
                    if (stockOutItems.Any())
                    {
                        var numberOfTableColumns = 6;
                        var widthCellsOTItems = new float[] { 80f, 70f, 120f, 250f, 100f, 100f };

                        PdfPTable tableStockOutItems = new PdfPTable(numberOfTableColumns);
                        tableStockOutItems.SetWidths(widthCellsOTItems);
                        tableStockOutItems.WidthPercentage = 100;
                        tableStockOutItems.AddCell(new PdfPCell(new Phrase("Qty.", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableStockOutItems.AddCell(new PdfPCell(new Phrase("Unit", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableStockOutItems.AddCell(new PdfPCell(new Phrase("Code", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableStockOutItems.AddCell(new PdfPCell(new Phrase("Description", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableStockOutItems.AddCell(new PdfPCell(new Phrase("Cost", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableStockOutItems.AddCell(new PdfPCell(new Phrase("Amount", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });

                        Decimal totalAmount = 0;
                        Int32 count = 0;

                        foreach (var stockOutItem in stockOutItems)
                        {
                            count += 1;

                            float paddingBottom = 3f;
                            if (count == stockOutItems.Count())
                            {
                                paddingBottom = 6f;
                            }

                            tableStockOutItems.AddCell(new PdfPCell(new Phrase(stockOutItem.Quantity.ToString("#,##0.00"), fontArial10)) { Border = 0, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableStockOutItems.AddCell(new PdfPCell(new Phrase(stockOutItem.MstUnit.Unit, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableStockOutItems.AddCell(new PdfPCell(new Phrase(stockOutItem.MstArticle.ArticleBarCode, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableStockOutItems.AddCell(new PdfPCell(new Phrase(stockOutItem.MstArticle.Article, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableStockOutItems.AddCell(new PdfPCell(new Phrase(stockOutItem.Cost.ToString("#,##0.00"), fontArial10)) { Border = 0, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableStockOutItems.AddCell(new PdfPCell(new Phrase(stockOutItem.Amount.ToString("#,##0.00"), fontArial10)) { Border = 0, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });

                            totalAmount += stockOutItem.Amount;
                        }

                        tableStockOutItems.AddCell(new PdfPCell(new Phrase("Total", fontArial10Bold)) { Colspan = 5, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                        tableStockOutItems.AddCell(new PdfPCell(new Phrase(totalAmount.ToString("#,##0.00"), fontArial10Bold)) { HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });

                        document.Add(tableStockOutItems);
                        document.Add(spaceTable);
                    }

                    //if (currentUser.FirstOrDefault().IsIncludeTotalQuantityPerUnit)
                    //{
                    //    PdfPTable tableUnits = new PdfPTable(3);
                    //    tableUnits.SetWidths(new float[] { 50f, 50f, 300f });
                    //    tableUnits.WidthPercentage = 100;
                    //    tableUnits.AddCell(new PdfPCell(new Phrase("Unit", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                    //    tableUnits.AddCell(new PdfPCell(new Phrase("Quantity", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                    //    tableUnits.AddCell(new PdfPCell(new Phrase(" ", fontArial10Bold)) { HorizontalAlignment = 1, Border = 0, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });

                    //    var stockOutItemUnits = from d in stockOut.FirstOrDefault().TrnStockOutItems
                    //                           group d by new
                    //                           {
                    //                               d.MstUnit.Unit,
                    //                           } into g
                    //                           select new
                    //                           {
                    //                               g.Key.Unit,
                    //                               Quantity = g.Sum(d => d.Quantity)
                    //                           };

                    //    if (stockOutItemUnits.Any())
                    //    {
                    //        foreach (var stockOutItemUnit in stockOutItemUnits)
                    //        {
                    //            tableUnits.AddCell(new PdfPCell(new Phrase(stockOutItemUnit.Unit, fontArial10)) { PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                    //            tableUnits.AddCell(new PdfPCell(new Phrase(stockOutItemUnit.Quantity.ToString("#,##0.00"), fontArial10)) { HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                    //            tableUnits.AddCell(new PdfPCell(new Phrase(" ", fontArial10)) { Border = 0, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                    //        }
                    //    }

                    //    document.Add(tableUnits);
                    //    document.Add(spaceTable);
                    //}

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
                    tableUsers.AddCell(new PdfPCell(new Phrase("Signature", fontArial10)) { HorizontalAlignment = 1, PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    document.Add(tableUsers);
                }

                document.Close();

                Process.Start(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static String GetMoneyWord(String input)
        {
            String decimals = "";
            if (input.Contains("."))
            {
                decimals = input.Substring(input.IndexOf(".") + 1);
                input = input.Remove(input.IndexOf("."));
            }

            String strWords = GetMoreThanThousandNumberWords(input);
            if (decimals.Length > 0)
            {
                if (Convert.ToDecimal(decimals) > 0)
                {
                    String getFirstRoundedDecimals = new String(decimals.Take(2).ToArray());
                    strWords += " Pesos And " + GetMoreThanThousandNumberWords(getFirstRoundedDecimals) + " Cents Only";
                }
                else
                {
                    strWords += " Pesos Only";
                }
            }
            else
            {
                strWords += " Pesos Only";
            }

            return strWords;
        }

        private static String GetMoreThanThousandNumberWords(string input)
        {
            try
            {
                String[] seperators = { "", " Thousand ", " Million ", " Billion " };

                int i = 0;

                String strWords = "";

                while (input.Length > 0)
                {
                    String _3digits = input.Length < 3 ? input : input.Substring(input.Length - 3);
                    input = input.Length < 3 ? "" : input.Remove(input.Length - 3);

                    Int32 no = Int32.Parse(_3digits);
                    _3digits = GetHundredNumberWords(no);

                    _3digits += seperators[i];
                    strWords = _3digits + strWords;

                    i++;
                }

                return strWords;
            }
            catch
            {
                return "Invalid Amount";
            }
        }

        private static String GetHundredNumberWords(Int32 no)
        {
            String[] Ones =
            {
                "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
                "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Ninteen"
            };

            String[] Tens = { "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            String word = "";

            if (no > 99 && no < 1000)
            {
                Int32 i = no / 100;
                word = word + Ones[i - 1] + " Hundred ";
                no = no % 100;
            }

            if (no > 19 && no < 100)
            {
                Int32 i = no / 10;
                word = word + Tens[i - 1] + " ";
                no = no % 10;
            }

            if (no > 0 && no < 20)
            {
                word = word + Ones[no - 1];
            }

            return word;
        }
    }
}
