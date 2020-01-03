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

namespace easyfmis.Forms.Software.TrnCollection
{
    public partial class TrnCollectionDetailPrintPreviewForm : Form
    {
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());
        public Int32 ORId;

        public TrnCollectionDetailPrintPreviewForm(Int32 filterORId)
        {
            InitializeComponent();
            ORId = filterORId;

            GeneratePDFCollectionDetail();
        }

        private void GeneratePDFCollectionDetail()
        {
            try
            {
                var fileName = "D:/Collection_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
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
                tableHeader.AddCell(new PdfPCell(new Phrase("Official Receipt", fontArial13Bold)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyAddress, fontArial09)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(branch, fontArial09)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Rowspan = 3 });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyContactNumber, fontArial09)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyTaxNumber, fontArial09)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(headerLine)) { Border = 0, Colspan = 2 });
                document.Add(tableHeader);

                var collection = from d in db.TrnCollections where d.Id == Convert.ToInt32(ORId) && d.IsLocked == true select d;
                if (collection.Any())
                {
                    var currentORPrefix = "OR";
                    var currentSIPrefix = "SI";

                    String customer = collection.FirstOrDefault().MstArticle.Article;
                    String collectionNo = collection.FirstOrDefault().ORNumber;
                    String TIN = collection.FirstOrDefault().MstArticle.TIN;
                    String collectionDate = collection.FirstOrDefault().ORDate.ToShortDateString();
                    String address = collection.FirstOrDefault().MstArticle.Address;
                    String manualORNumber = collection.FirstOrDefault().ManualORNumber;
                    String businessStyle = collection.FirstOrDefault().MstArticle.MstArticleGroup.ArticleGroup;
                    String salesPerson = collection.FirstOrDefault().MstUser4.FullName;
                    String salesRemarks = "";
                    String preparedBy = collection.FirstOrDefault().MstUser3.FullName;
                    String checkedBy = collection.FirstOrDefault().MstUser.FullName;
                    String approvedBy = collection.FirstOrDefault().MstUser1.FullName;

                    PdfPTable tableCollection = new PdfPTable(4);
                    tableCollection.SetWidths(new float[] { 65f, 150f, 70f, 80f });
                    tableCollection.WidthPercentage = 100;
                    tableCollection.AddCell(new PdfPCell(new Phrase("Customer:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableCollection.AddCell(new PdfPCell(new Phrase(customer, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableCollection.AddCell(new PdfPCell(new Phrase("No.:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableCollection.AddCell(new PdfPCell(new Phrase(currentORPrefix + "-" + collection.FirstOrDefault().MstBranch.BranchCode + "-" + collectionNo, fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableCollection.AddCell(new PdfPCell(new Phrase("TIN:  ", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableCollection.AddCell(new PdfPCell(new Phrase(TIN, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableCollection.AddCell(new PdfPCell(new Phrase("Date:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableCollection.AddCell(new PdfPCell(new Phrase(collectionDate, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableCollection.AddCell(new PdfPCell(new Phrase("Address:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableCollection.AddCell(new PdfPCell(new Phrase(address, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableCollection.AddCell(new PdfPCell(new Phrase(currentORPrefix + " Ref. No.:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableCollection.AddCell(new PdfPCell(new Phrase(manualORNumber, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableCollection.AddCell(new PdfPCell(new Phrase("Business Style:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableCollection.AddCell(new PdfPCell(new Phrase(businessStyle, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableCollection.AddCell(new PdfPCell(new Phrase("", fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, Colspan = 2 });
                    tableCollection.AddCell(new PdfPCell(new Phrase("Remarks:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableCollection.AddCell(new PdfPCell(new Phrase(salesRemarks, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableCollection.AddCell(new PdfPCell(new Phrase("", fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, Colspan = 2 });
                    document.Add(tableCollection);

                    PdfPTable spaceTable = new PdfPTable(1);
                    spaceTable.SetWidths(new float[] { 100f });
                    spaceTable.WidthPercentage = 100;
                    spaceTable.AddCell(new PdfPCell(new Phrase(" ", fontArial10Bold)) { Border = 0, PaddingTop = 5f });
                    document.Add(spaceTable);

                    var collectionLines = from d in collection.FirstOrDefault().TrnCollectionLines select d;
                    if (collectionLines.Any())
                    {
                        PdfPTable tableCollectionLines = new PdfPTable(8);
                        tableCollectionLines.SetWidths(new float[] { 100f, 90f, 100f, 100f, 100f, 100f, 100f, 110f });
                        tableCollectionLines.WidthPercentage = 100;
                        tableCollectionLines.AddCell(new PdfPCell(new Phrase("SI No.", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableCollectionLines.AddCell(new PdfPCell(new Phrase("SI Date", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableCollectionLines.AddCell(new PdfPCell(new Phrase("Doc. Ref.", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableCollectionLines.AddCell(new PdfPCell(new Phrase("Pay Type", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableCollectionLines.AddCell(new PdfPCell(new Phrase("Check No.", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableCollectionLines.AddCell(new PdfPCell(new Phrase("Check Date", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableCollectionLines.AddCell(new PdfPCell(new Phrase("Check Bank", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableCollectionLines.AddCell(new PdfPCell(new Phrase("Amount", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });

                        Decimal totalAmount = 0;
                        Decimal count = 0;

                        foreach (var collectionLine in collectionLines)
                        {
                            count += 1;

                            float paddingBottom = 3f;
                            if (count == collectionLines.Count())
                            {
                                paddingBottom = 6f;
                            }

                            String SINumber = " ", SIDate = " ", DocumentReferenceNo = "";
                            if (collectionLine.SIId != null)
                            {
                                SINumber = currentSIPrefix + "-" + collectionLine.TrnSalesInvoice.MstBranch.BranchCode + "-" + collectionLine.TrnSalesInvoice.SINumber;
                                SIDate = collectionLine.TrnSalesInvoice.SIDate.ToShortDateString();
                                DocumentReferenceNo = "";
                            }

                            String checkDate = "";
                            if (collectionLine.CheckDate != null)
                            {
                                checkDate = Convert.ToDateTime(collectionLine.CheckDate).ToShortDateString();
                            }

                            tableCollectionLines.AddCell(new PdfPCell(new Phrase(SINumber, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableCollectionLines.AddCell(new PdfPCell(new Phrase(SIDate, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableCollectionLines.AddCell(new PdfPCell(new Phrase(DocumentReferenceNo, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableCollectionLines.AddCell(new PdfPCell(new Phrase(collectionLine.MstPayType.PayType, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableCollectionLines.AddCell(new PdfPCell(new Phrase(collectionLine.CheckNumber, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableCollectionLines.AddCell(new PdfPCell(new Phrase(checkDate, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableCollectionLines.AddCell(new PdfPCell(new Phrase(collectionLine.CheckBank, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableCollectionLines.AddCell(new PdfPCell(new Phrase(collectionLine.Amount.ToString("#,##0.00"), fontArial10)) { Border = 0, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });

                            totalAmount += collectionLine.Amount;
                        }

                        tableCollectionLines.AddCell(new PdfPCell(new Phrase("Total", fontArial10Bold)) { Colspan = 7, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                        tableCollectionLines.AddCell(new PdfPCell(new Phrase(totalAmount.ToString("#,##0.00"), fontArial10Bold)) { HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });

                        document.Add(tableCollectionLines);
                        document.Add(spaceTable);
                    }

                    PdfPTable tableUsers = new PdfPTable(3);
                    tableUsers.SetWidths(new float[] { 100f, 100f, 100f });
                    tableUsers.WidthPercentage = 100;
                    tableUsers.AddCell(new PdfPCell(new Phrase("Prepared by", fontArial10Bold)) { PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase("Checked by", fontArial10Bold)) { PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase("Approved by", fontArial10Bold)) { PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(" ")) { PaddingBottom = 30f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(" ")) { PaddingBottom = 30f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(" ")) { PaddingBottom = 30f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(preparedBy, fontArial10)) { HorizontalAlignment = 1, PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(checkedBy, fontArial10)) { HorizontalAlignment = 1, PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableUsers.AddCell(new PdfPCell(new Phrase(approvedBy, fontArial10)) { HorizontalAlignment = 1, PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
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
