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

namespace easyfmis.Forms.Software.TrnStockTransfer
{
    public partial class TrnStockTransferDetailPrintPreviewForm : Form
    {
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());
        public Int32 STId;

        public TrnStockTransferDetailPrintPreviewForm(Int32 filterSTId)
        {
            InitializeComponent();
            STId = filterSTId;

            GeneratePDFStockTransferDetail();
        }

        private void GeneratePDFStockTransferDetail()
        {
            try
            {
                var fileName = "C:/EasyERPPDF/StockTransfer_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
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
                tableHeader.AddCell(new PdfPCell(new Phrase("Stock Transfer", fontArial13Bold)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyAddress, fontArial09)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(branch, fontArial09)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Rowspan = 3 });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyContactNumber, fontArial09)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyTaxNumber, fontArial09)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(headerLine)) { Border = 0, Colspan = 2 });
                document.Add(tableHeader);

                var stockTransfer = from d in db.TrnStockTransfers where d.Id == Convert.ToInt32(STId) && d.IsLocked == true select d;
                if (stockTransfer.Any())
                {
                    String toBranch = stockTransfer.FirstOrDefault().MstBranch1.Branch;
                    String remarks = stockTransfer.FirstOrDefault().Remarks;
                    String STNumber = stockTransfer.FirstOrDefault().STNumber;
                    String STDate = stockTransfer.FirstOrDefault().STDate.ToShortDateString();
                    String preparedBy = stockTransfer.FirstOrDefault().MstUser3.FullName;
                    String checkedBy = stockTransfer.FirstOrDefault().MstUser1.FullName;
                    String approvedBy = stockTransfer.FirstOrDefault().MstUser.FullName;

                    PdfPTable tableStockTransfer = new PdfPTable(4);
                    tableStockTransfer.SetWidths(new float[] { 40f, 150f, 70f, 70f });
                    tableStockTransfer.WidthPercentage = 100;
                    tableStockTransfer.AddCell(new PdfPCell(new Phrase("No.:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableStockTransfer.AddCell(new PdfPCell(new Phrase("ST-" + stockTransfer.FirstOrDefault().MstBranch.BranchCode + "-" + STNumber, fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableStockTransfer.AddCell(new PdfPCell(new Phrase("To Branch:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableStockTransfer.AddCell(new PdfPCell(new Phrase(toBranch, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableStockTransfer.AddCell(new PdfPCell(new Phrase("Date:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableStockTransfer.AddCell(new PdfPCell(new Phrase(STDate, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableStockTransfer.AddCell(new PdfPCell(new Phrase("Remarks:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableStockTransfer.AddCell(new PdfPCell(new Phrase(remarks, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    document.Add(tableStockTransfer);

                    PdfPTable spaceTable = new PdfPTable(1);
                    spaceTable.SetWidths(new float[] { 100f });
                    spaceTable.WidthPercentage = 100;
                    spaceTable.AddCell(new PdfPCell(new Phrase(" ", fontArial10Bold)) { Border = 0, PaddingTop = 5f });
                    document.Add(spaceTable);

                    var stockTransferItems = from d in stockTransfer.FirstOrDefault().TrnStockTransferItems select d;
                    if (stockTransferItems.Any())
                    {
                        var numberOfTableColumns = 6;
                        var widthCellsSTItems = new float[] { 80f, 70f, 120f, 250f, 100f, 100f };

                        PdfPTable tableStockTransferItems = new PdfPTable(numberOfTableColumns);
                        tableStockTransferItems.SetWidths(widthCellsSTItems);
                        tableStockTransferItems.WidthPercentage = 100;
                        tableStockTransferItems.AddCell(new PdfPCell(new Phrase("Qty.", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableStockTransferItems.AddCell(new PdfPCell(new Phrase("Unit", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableStockTransferItems.AddCell(new PdfPCell(new Phrase("Code", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableStockTransferItems.AddCell(new PdfPCell(new Phrase("Description", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableStockTransferItems.AddCell(new PdfPCell(new Phrase("Cost", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableStockTransferItems.AddCell(new PdfPCell(new Phrase("Amount", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });

                        Decimal totalAmount = 0;
                        Int32 count = 0;

                        foreach (var stockTransferItem in stockTransferItems)
                        {
                            count += 1;

                            float paddingBottom = 3f;
                            if (count == stockTransferItems.Count())
                            {
                                paddingBottom = 6f;
                            }

                            tableStockTransferItems.AddCell(new PdfPCell(new Phrase(stockTransferItem.Quantity.ToString("#,##0.00"), fontArial10)) { Border = 0, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableStockTransferItems.AddCell(new PdfPCell(new Phrase(stockTransferItem.MstUnit.Unit, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableStockTransferItems.AddCell(new PdfPCell(new Phrase(stockTransferItem.MstArticle.ArticleBarCode, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableStockTransferItems.AddCell(new PdfPCell(new Phrase(stockTransferItem.MstArticle.Article, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableStockTransferItems.AddCell(new PdfPCell(new Phrase(stockTransferItem.Cost.ToString("#,##0.00"), fontArial10)) { Border = 0, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableStockTransferItems.AddCell(new PdfPCell(new Phrase(stockTransferItem.Amount.ToString("#,##0.00"), fontArial10)) { Border = 0, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });

                            totalAmount += stockTransferItem.Amount;
                        }

                        tableStockTransferItems.AddCell(new PdfPCell(new Phrase("Total", fontArial10Bold)) { Colspan = 5, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                        tableStockTransferItems.AddCell(new PdfPCell(new Phrase(totalAmount.ToString("#,##0.00"), fontArial10Bold)) { HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });

                        document.Add(tableStockTransferItems);
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

                    //    var stockTransferItemUnits = from d in stockTransfer.FirstOrDefault().TrnStockTransferItems
                    //                           group d by new
                    //                           {
                    //                               d.MstUnit.Unit,
                    //                           } into g
                    //                           select new
                    //                           {
                    //                               g.Key.Unit,
                    //                               Quantity = g.Sum(d => d.Quantity)
                    //                           };

                    //    if (stockTransferItemUnits.Any())
                    //    {
                    //        foreach (var stockTransferItemUnit in stockTransferItemUnits)
                    //        {
                    //            tableUnits.AddCell(new PdfPCell(new Phrase(stockTransferItemUnit.Unit, fontArial10)) { PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                    //            tableUnits.AddCell(new PdfPCell(new Phrase(stockTransferItemUnit.Quantity.ToString("#,##0.00"), fontArial10)) { HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
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
