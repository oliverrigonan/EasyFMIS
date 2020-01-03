using System;
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

namespace easyfmis.Forms.Software.TrnDisbursement
{
    public partial class TrnDisbursementDetailPrintPreviewForm : Form
    {
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());
        public Int32 CVId;

        public TrnDisbursementDetailPrintPreviewForm(Int32 filterCVId)
        {
            InitializeComponent();
            CVId = filterCVId;

            GeneratePDFDisbursementDetail();
        }

        private void GeneratePDFDisbursementDetail()
        {
            try
            {
                var fileName = "D:/Disbursement_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
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
                tableHeader.AddCell(new PdfPCell(new Phrase("Cash/Check Voucher", fontArial13Bold)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyAddress, fontArial09)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(branch, fontArial09)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Rowspan = 3 });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyContactNumber, fontArial09)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyTaxNumber, fontArial09)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(headerLine)) { Border = 0, Colspan = 2 });
                document.Add(tableHeader);

                var disbursement = from d in db.TrnDisbursements where d.Id == Convert.ToInt32(CVId) && d.IsLocked == true select d;
                if (disbursement.Any())
                {
                    String payee = disbursement.FirstOrDefault().Payee;
                    String bank = disbursement.FirstOrDefault().MstArticle1.Article;
                    String particulars = disbursement.FirstOrDefault().Remarks;
                    String checkNo = disbursement.FirstOrDefault().CheckNumber;
                    String CVNumber = disbursement.FirstOrDefault().CVNumber;
                    String CVDate = disbursement.FirstOrDefault().CVDate.ToShortDateString();
                    String ManualCVNumber = disbursement.FirstOrDefault().ManualCVNumber;
                    String checkDate = Convert.ToDateTime(disbursement.FirstOrDefault().CheckDate).ToShortDateString();
                    String preparedBy = disbursement.FirstOrDefault().MstUser3.FullName;
                    String checkedBy = disbursement.FirstOrDefault().MstUser1.FullName;
                    String approvedBy = disbursement.FirstOrDefault().MstUser.FullName;

                    PdfPTable tableDisbursement = new PdfPTable(4);
                    tableDisbursement.SetWidths(new float[] { 50f, 140f, 70f, 70f });
                    tableDisbursement.WidthPercentage = 100;
                    tableDisbursement.AddCell(new PdfPCell(new Phrase("Payee:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableDisbursement.AddCell(new PdfPCell(new Phrase(payee, fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableDisbursement.AddCell(new PdfPCell(new Phrase("No.:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableDisbursement.AddCell(new PdfPCell(new Phrase("CV-" + disbursement.FirstOrDefault().MstBranch.BranchCode + "-" + CVNumber, fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableDisbursement.AddCell(new PdfPCell(new Phrase("Check No.:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableDisbursement.AddCell(new PdfPCell(new Phrase(checkNo, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableDisbursement.AddCell(new PdfPCell(new Phrase("Date:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableDisbursement.AddCell(new PdfPCell(new Phrase(CVDate, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableDisbursement.AddCell(new PdfPCell(new Phrase("Check Date:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableDisbursement.AddCell(new PdfPCell(new Phrase(checkDate, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableDisbursement.AddCell(new PdfPCell(new Phrase("CV Ref. No.:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableDisbursement.AddCell(new PdfPCell(new Phrase(ManualCVNumber, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableDisbursement.AddCell(new PdfPCell(new Phrase("Bank:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableDisbursement.AddCell(new PdfPCell(new Phrase(bank, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableDisbursement.AddCell(new PdfPCell(new Phrase("", fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2, Colspan = 2 });
                    tableDisbursement.AddCell(new PdfPCell(new Phrase("Particulars:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableDisbursement.AddCell(new PdfPCell(new Phrase(particulars, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableDisbursement.AddCell(new PdfPCell(new Phrase("", fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2, Colspan = 2 });
                    document.Add(tableDisbursement);

                    PdfPTable spaceTable = new PdfPTable(1);
                    spaceTable.SetWidths(new float[] { 100f });
                    spaceTable.WidthPercentage = 100;
                    spaceTable.AddCell(new PdfPCell(new Phrase(" ", fontArial10Bold)) { Border = 0, PaddingTop = 5f });
                    document.Add(spaceTable);

                    var disbursementLines = from d in disbursement.FirstOrDefault().TrnDisbursementLines select d;
                    if (disbursementLines.Any())
                    {
                        PdfPTable tableDisbursementLines = new PdfPTable(4);
                        float[] widthscellsDisbursementLines = new float[] { 120f, 80f, 140f, 100f };
                        tableDisbursementLines.SetWidths(widthscellsDisbursementLines);
                        tableDisbursementLines.WidthPercentage = 100;
                        tableDisbursementLines.AddCell(new PdfPCell(new Phrase("RR No.", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableDisbursementLines.AddCell(new PdfPCell(new Phrase("RR Date", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableDisbursementLines.AddCell(new PdfPCell(new Phrase("Particulars", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableDisbursementLines.AddCell(new PdfPCell(new Phrase("Paid Amount", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });

                        Decimal totalPaidAmount = 0;
                        Decimal count = 0;

                        foreach (var disbursementLine in disbursementLines)
                        {
                            count += 1;

                            float paddingBottom = 3f;
                            if (count == disbursementLines.Count())
                            {
                                paddingBottom = 6f;
                            }

                            String RRNumber = " ", RRDate = " ";
                            if (disbursementLine.RRId != null)
                            {
                                RRNumber = "RR-" + disbursementLine.TrnReceivingReceipt.MstBranch.BranchCode + "-" + disbursementLine.TrnReceivingReceipt.RRNumber;
                                RRDate = disbursementLine.TrnReceivingReceipt.RRDate.ToString("MM-dd-yyyy", CultureInfo.InvariantCulture);
                            }

                            tableDisbursementLines.AddCell(new PdfPCell(new Phrase(RRNumber, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableDisbursementLines.AddCell(new PdfPCell(new Phrase(RRDate, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableDisbursementLines.AddCell(new PdfPCell(new Phrase(disbursementLine.OtherInformation, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableDisbursementLines.AddCell(new PdfPCell(new Phrase(disbursementLine.Amount.ToString("#,##0.00"), fontArial10)) { Border = 0, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });

                            totalPaidAmount += disbursementLine.Amount;
                        }

                        tableDisbursementLines.AddCell(new PdfPCell(new Phrase("Total", fontArial10Bold)) { Colspan = 3, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                        tableDisbursementLines.AddCell(new PdfPCell(new Phrase(totalPaidAmount.ToString("#,##0.00"), fontArial10Bold)) { HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });

                        document.Add(tableDisbursementLines);
                        document.Add(spaceTable);
                    }

                    PdfPTable tableUserss = new PdfPTable(3);
                    tableUserss.SetWidths(new float[] { 100f, 100f, 100f });
                    tableUserss.WidthPercentage = 100;
                    tableUserss.AddCell(new PdfPCell(new Phrase("Prepared by", fontArial10Bold)) { PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUserss.AddCell(new PdfPCell(new Phrase("Checked by", fontArial10Bold)) { PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUserss.AddCell(new PdfPCell(new Phrase("Approved by", fontArial10Bold)) { PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUserss.AddCell(new PdfPCell(new Phrase(" ")) { PaddingBottom = 30f });
                    tableUserss.AddCell(new PdfPCell(new Phrase(" ")) { PaddingBottom = 30f });
                    tableUserss.AddCell(new PdfPCell(new Phrase(" ")) { PaddingBottom = 30f });
                    tableUserss.AddCell(new PdfPCell(new Phrase(preparedBy, fontArial10)) { HorizontalAlignment = 1, PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUserss.AddCell(new PdfPCell(new Phrase(checkedBy, fontArial10)) { HorizontalAlignment = 1, PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUserss.AddCell(new PdfPCell(new Phrase(approvedBy, fontArial10)) { HorizontalAlignment = 1, PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    document.Add(tableUserss);

                    document.Add(spaceTable);

                    PdfPTable tableMoneyWord = new PdfPTable(3);
                    tableMoneyWord.SetWidths(new float[] { 40f, 100f, 140f });
                    tableMoneyWord.WidthPercentage = 100;
                    tableMoneyWord.AddCell(new PdfPCell(new Phrase("Check No.", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableMoneyWord.AddCell(new PdfPCell(new Phrase(checkNo, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });

                    String paidAmount = Convert.ToString(Math.Round(disbursement.FirstOrDefault().Amount * 100) / 100);

                    var amountTablePhrase = new Phrase();
                    var amountString = "ZERO";

                    if (Convert.ToDecimal(paidAmount) != 0)
                    {
                        amountString = GetMoneyWord(paidAmount).ToUpper();
                    }

                    amountTablePhrase.Add(new Chunk("Representing Payment from " + currentUser.FirstOrDefault().MstCompany.Company + " the amount of ", fontArial10));
                    amountTablePhrase.Add(new Chunk(amountString + " (P " + disbursement.FirstOrDefault().Amount.ToString("#,##0.00") + ")", fontArial10Bold));

                    Paragraph paragraphAmountTable = new Paragraph();
                    paragraphAmountTable.SetLeading(0, 1.4f);
                    paragraphAmountTable.Add(amountTablePhrase);

                    PdfPCell chunkyAmountTable = new PdfPCell();
                    chunkyAmountTable.AddElement(paragraphAmountTable);
                    chunkyAmountTable.BorderWidth = PdfPCell.NO_BORDER;

                    tableMoneyWord.AddCell(new PdfPCell(chunkyAmountTable) { Rowspan = 4, Border = 0, PaddingTop = 0f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 0 });
                    tableMoneyWord.AddCell(new PdfPCell(new Phrase("Check Date", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableMoneyWord.AddCell(new PdfPCell(new Phrase(checkDate, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableMoneyWord.AddCell(new PdfPCell(new Phrase("Bank", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableMoneyWord.AddCell(new PdfPCell(new Phrase(bank, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableMoneyWord.AddCell(new PdfPCell(new Phrase("Manual No.", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableMoneyWord.AddCell(new PdfPCell(new Phrase(ManualCVNumber, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    document.Add(tableMoneyWord);

                    document.Add(spaceTable);
                    document.Add(spaceTable);

                    PdfPTable tableUserSign = new PdfPTable(4);
                    tableUserSign.SetWidths(new float[] { 115f, 60f, 5f, 40f });
                    tableUserSign.WidthPercentage = 100;
                    tableUserSign.AddCell(new PdfPCell(new Phrase(" ", fontArial10Bold)) { Border = 0 });
                    tableUserSign.AddCell(new PdfPCell(new Phrase(" ", fontArial10Bold)) { Border = 0 });
                    tableUserSign.AddCell(new PdfPCell(new Phrase(" ", fontArial10Bold)) { Border = 0 });
                    tableUserSign.AddCell(new PdfPCell(new Phrase(" ", fontArial10Bold)) { Border = 0 });
                    tableUserSign.AddCell(new PdfPCell(new Phrase(" ", fontArial10)) { Border = 0, });
                    tableUserSign.AddCell(new PdfPCell(new Phrase("Signature Over Printed Name", fontArial10Bold)) { Border = 1, HorizontalAlignment = 1 });
                    tableUserSign.AddCell(new PdfPCell(new Phrase(" ", fontArial10Bold)) { Border = 0 });
                    tableUserSign.AddCell(new PdfPCell(new Phrase("Date", fontArial10Bold)) { Border = 1, HorizontalAlignment = 1 });
                    document.Add(tableUserSign);
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
