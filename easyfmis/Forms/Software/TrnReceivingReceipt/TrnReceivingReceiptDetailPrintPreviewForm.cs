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

namespace easyfmis.Forms.Software.TrnReceivingReceipt
{
    public partial class TrnReceivingReceiptDetailPrintPreviewForm : Form
    {
        public Data.easyfmisdbDataContext db = new Data.easyfmisdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());
        public Int32 RRId;

        public TrnReceivingReceiptDetailPrintPreviewForm(Int32 filterRRId)
        {
            InitializeComponent();
            RRId = filterRRId;

            GeneratePDFReceivingReceiptDetail();
        }

        private void GeneratePDFReceivingReceiptDetail()
        {
            try
            {
                var fileName = "D:/ReceivingReceipt_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
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
                tableHeader.AddCell(new PdfPCell(new Phrase("Receiving Receipt", fontArial13Bold)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyAddress, fontArial09)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(branch, fontArial09)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Rowspan = 3 });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyContactNumber, fontArial09)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyTaxNumber, fontArial09)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(headerLine)) { Border = 0, Colspan = 2 });
                document.Add(tableHeader);

                var receivingReceipt = from d in db.TrnReceivingReceipts where d.Id == Convert.ToInt32(RRId) && d.IsLocked == true select d;
                if (receivingReceipt.Any())
                {
                    String supplier = receivingReceipt.FirstOrDefault().MstArticle.Article;
                    String term = receivingReceipt.FirstOrDefault().MstTerm.Term;
                    String dueDate = receivingReceipt.FirstOrDefault().RRDate.AddDays(Convert.ToInt32(receivingReceipt.FirstOrDefault().MstTerm.NumberOfDays)).ToString("MM-dd-yyyy", CultureInfo.InvariantCulture);
                    String remarks = receivingReceipt.FirstOrDefault().Remarks;
                    String RRNumber = receivingReceipt.FirstOrDefault().RRNumber;
                    String RRDate = receivingReceipt.FirstOrDefault().RRDate.ToShortDateString();
                    String manualRRNumber = receivingReceipt.FirstOrDefault().ManualRRNumber;
                    String preparedBy = receivingReceipt.FirstOrDefault().MstUser3.FullName;
                    String checkedBy = receivingReceipt.FirstOrDefault().MstUser1.FullName;
                    String approvedBy = receivingReceipt.FirstOrDefault().MstUser.FullName;
                    String receivedBy = receivingReceipt.FirstOrDefault().MstUser4.FullName;

                    PdfPTable tableReceivingReceipt = new PdfPTable(4);
                    tableReceivingReceipt.SetWidths(new float[] { 40f, 150f, 70f, 70f });
                    tableReceivingReceipt.WidthPercentage = 100;
                    tableReceivingReceipt.AddCell(new PdfPCell(new Phrase("Customer:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableReceivingReceipt.AddCell(new PdfPCell(new Phrase(supplier, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableReceivingReceipt.AddCell(new PdfPCell(new Phrase("No.:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableReceivingReceipt.AddCell(new PdfPCell(new Phrase("RR-" + receivingReceipt.FirstOrDefault().MstBranch.BranchCode + "-" + RRNumber, fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableReceivingReceipt.AddCell(new PdfPCell(new Phrase("Term:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableReceivingReceipt.AddCell(new PdfPCell(new Phrase(term, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableReceivingReceipt.AddCell(new PdfPCell(new Phrase("Date:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableReceivingReceipt.AddCell(new PdfPCell(new Phrase(RRDate, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableReceivingReceipt.AddCell(new PdfPCell(new Phrase("Due Date:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableReceivingReceipt.AddCell(new PdfPCell(new Phrase(dueDate, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableReceivingReceipt.AddCell(new PdfPCell(new Phrase("RR Ref. No.:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableReceivingReceipt.AddCell(new PdfPCell(new Phrase(manualRRNumber, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableReceivingReceipt.AddCell(new PdfPCell(new Phrase("Remarks:", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableReceivingReceipt.AddCell(new PdfPCell(new Phrase(remarks, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableReceivingReceipt.AddCell(new PdfPCell(new Phrase("", fontArial10Bold)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    tableReceivingReceipt.AddCell(new PdfPCell(new Phrase("", fontArial10)) { Border = 0, PaddingTop = 3f, PaddingLeft = 5f, PaddingRight = 5f, HorizontalAlignment = 2 });
                    document.Add(tableReceivingReceipt);

                    PdfPTable spaceTable = new PdfPTable(1);
                    spaceTable.SetWidths(new float[] { 100f });
                    spaceTable.WidthPercentage = 100;
                    spaceTable.AddCell(new PdfPCell(new Phrase(" ", fontArial10Bold)) { Border = 0, PaddingTop = 5f });
                    document.Add(spaceTable);

                    var receivingReceiptItems = from d in receivingReceipt.FirstOrDefault().TrnReceivingReceiptItems select d;
                    if (receivingReceiptItems.Any())
                    {
                        int numberOfCells = 9;
                        float[] withCells = new float[] { 50f, 110f, 80f, 70f, 100f, 200f, 100f, 100f, 100f };

                        PdfPTable tableReceivingReceiptItems = new PdfPTable(numberOfCells);
                        tableReceivingReceiptItems.SetWidths(withCells);
                        tableReceivingReceiptItems.WidthPercentage = 100;
                        tableReceivingReceiptItems.AddCell(new PdfPCell(new Phrase("No.", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableReceivingReceiptItems.AddCell(new PdfPCell(new Phrase("PO No.", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableReceivingReceiptItems.AddCell(new PdfPCell(new Phrase("Qty.", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableReceivingReceiptItems.AddCell(new PdfPCell(new Phrase("Unit", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableReceivingReceiptItems.AddCell(new PdfPCell(new Phrase("Code", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableReceivingReceiptItems.AddCell(new PdfPCell(new Phrase("Description", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableReceivingReceiptItems.AddCell(new PdfPCell(new Phrase("Branch", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableReceivingReceiptItems.AddCell(new PdfPCell(new Phrase("Cost", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                        tableReceivingReceiptItems.AddCell(new PdfPCell(new Phrase("Amount", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });

                        Decimal totalAmount = 0;
                        Decimal count = 0;

                        foreach (var receivingReceiptItem in receivingReceiptItems)
                        {
                            count += 1;
                            totalAmount += receivingReceiptItem.Amount;

                            float paddingBottom = 3f;
                            if (count == receivingReceiptItems.Count())
                            {
                                paddingBottom = 6f;
                            }

                            tableReceivingReceiptItems.AddCell(new PdfPCell(new Phrase(count.ToString("#,##0"), fontArial10)) { Border = 0, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableReceivingReceiptItems.AddCell(new PdfPCell(new Phrase("PO-" + receivingReceiptItem.TrnPurchaseOrder.MstBranch.BranchCode + "-" + receivingReceiptItem.TrnPurchaseOrder.PONumber, fontArial10)) { Border = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableReceivingReceiptItems.AddCell(new PdfPCell(new Phrase(receivingReceiptItem.Quantity.ToString("#,##0.00"), fontArial10)) { Border = 0, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableReceivingReceiptItems.AddCell(new PdfPCell(new Phrase(receivingReceiptItem.MstUnit.Unit, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableReceivingReceiptItems.AddCell(new PdfPCell(new Phrase(receivingReceiptItem.MstArticle.ArticleBarCode, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableReceivingReceiptItems.AddCell(new PdfPCell(new Phrase(receivingReceiptItem.MstArticle.Article, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableReceivingReceiptItems.AddCell(new PdfPCell(new Phrase(receivingReceiptItem.MstBranch.Branch, fontArial10)) { Border = 0, HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableReceivingReceiptItems.AddCell(new PdfPCell(new Phrase(receivingReceiptItem.Cost.ToString("#,##0.00"), fontArial10)) { Border = 0, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                            tableReceivingReceiptItems.AddCell(new PdfPCell(new Phrase(receivingReceiptItem.Amount.ToString("#,##0.00"), fontArial10)) { Border = 0, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = paddingBottom, PaddingLeft = 5f, PaddingRight = 5f });
                        }

                        var colspan = 8;

                        tableReceivingReceiptItems.AddCell(new PdfPCell(new Phrase("Total", fontArial10Bold)) { Colspan = colspan, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                        tableReceivingReceiptItems.AddCell(new PdfPCell(new Phrase(totalAmount.ToString("#,##0.00"), fontArial10Bold)) { HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });

                        document.Add(tableReceivingReceiptItems);
                        document.Add(spaceTable);
                    }

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
                    tableUsers.AddCell(new PdfPCell(new Phrase(receivedBy, fontArial10)) { HorizontalAlignment = 1, PaddingTop = 5f, PaddingBottom = 9f, PaddingLeft = 5f, PaddingRight = 5f });
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
