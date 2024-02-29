using Bookworm_cs.Repositories;
using Bookworm_cs.Models;
using iText.Layout;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Kernel.Font;
using System.Threading.Tasks;
using iText.Layout.Borders;
using iText.Layout.Properties;
using System;
using iText.StyledXmlParser.Node;

namespace Bookworm_cs.PDF
{
    public class InvoicePDFExporter
    {
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;

        public InvoicePDFExporter(ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public byte[] GenerateInvoice(List<InvoiceDetails> invoiceDetails, int id)
        {
            List<InvoiceDetails> invoiceDetailsAsync = invoiceDetails;
            int? idAsync = id;

            Random random = new Random();
            int rand = random.Next(1000, 9999);

            DateTime dateTime = DateTime.Now;

            using (MemoryStream ms = new MemoryStream())
            {
                //PdfWriter pdfWriter = new PdfWriter("Invoice_" + rand.ToString() + ".pdf");
                PdfWriter pdfWriter = new PdfWriter(ms);
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                Document document = new Document(pdfDocument);
                
                PdfFont boldFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFontFamilies.HELVETICA);
                PdfFont headingFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFontFamilies.HELVETICA);

                float[] headerWidth = { 1, 1 };
                Table headerTable = new Table(headerWidth);
                headerTable.SetWidth(700f);
                headerTable.SetVerticalBorderSpacing(100f);

                Cell headerCell = new Cell();
                headerCell.Add(new Paragraph("Bookworm"));
                headerCell.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                headerCell.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.LEFT);
                headerCell.SetFontSize(20f);
                headerCell.SetFont(boldFont);

                Cell headerCell2 = new Cell();
                headerCell2.Add(new Paragraph("Payment Invoice"));
                headerCell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                headerCell2.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.RIGHT);

                //headerTable.AddCell(new Cell().Add(new Paragraph("Bookworm")));
                //headerTable.AddCell(new Cell().Add(new Paragraph("Invoice")));

                headerTable.AddCell(headerCell);
                headerTable.AddCell(headerCell2);

                document.Add(headerTable);


                // Create a new table with 2 columns
                Table customerTable = new Table(2);
                customerTable.SetWidth(UnitValue.CreatePercentValue(100));

                // Add cells to the table
                Cell name = new Cell().Add(new Paragraph("Customer Name: " + _customerRepository.GetCustomerNameById(id)));
                name.SetBorder(Border.NO_BORDER);
                name.SetTextAlignment(TextAlignment.LEFT);
                name.SetMarginTop(30f);
                name.SetMarginBottom(30f);
                customerTable.AddCell(name);

                Cell date = new Cell().Add(new Paragraph("Date: " + dateTime.ToString("dd-MM-yyyy")));
                date.SetBorder(Border.NO_BORDER);
                date.SetTextAlignment(TextAlignment.RIGHT);
                name.SetMarginTop(30f);
                name.SetMarginBottom(30f);
                customerTable.AddCell(date);

                document.Add(customerTable);

                // Create a new table with 5 columns
                Table productTable = new Table(5);
                productTable.SetWidth(UnitValue.CreatePercentValue(100));

                // Add cells to the table
                productTable.AddCell(new Cell().Add(new Paragraph("Product No.")));
                productTable.AddCell(new Cell().Add(new Paragraph("Product Name")));
                productTable.AddCell(new Cell().Add(new Paragraph("Transaction Type")));
                productTable.AddCell(new Cell().Add(new Paragraph("Renting Days")));
                productTable.AddCell(new Cell().Add(new Paragraph("Price")));

                int count = 1;
                double total = 0;

                // Add rows to the table
                foreach (InvoiceDetails invoiceDetail in invoiceDetails)
                {
                    total += invoiceDetail.SellingPrice;

                    if (invoiceDetail.RentingDays == null)
                    {
                        invoiceDetail.RentingDays = 0;
                    }

                    Cell countCell = new Cell(1, 1).Add(new Paragraph(count++.ToString()));
                    countCell.SetPadding(10f);
                    productTable.AddCell(countCell);

                    int productId = invoiceDetail.ProductId ?? default(int);
                    Cell nameCell = new Cell(1, 1).Add(new Paragraph(_productRepository.GetProductNameById(productId).ToString()));
                    nameCell.SetPadding(10f);
                    productTable.AddCell(nameCell);

                    string purchaseType;

                    if (invoiceDetail.TransactionTypeId == 1)
                        purchaseType = "Purchase";
                    else
                        purchaseType = "Rent";

                    Cell typeCell = new Cell(1, 1).Add(new Paragraph(purchaseType));
                    typeCell.SetPadding(10f);
                    productTable.AddCell(typeCell);

                    Cell rentCell = new Cell(1, 1).Add(new Paragraph(invoiceDetail.RentingDays.ToString()));
                    rentCell.SetPadding(10f);
                    productTable.AddCell(rentCell);

                    Cell priceCell = new Cell(1, 1).Add(new Paragraph(invoiceDetail.SellingPrice.ToString()));
                    priceCell.SetPadding(10f);
                    productTable.AddCell(priceCell);

                }

                document.Add(productTable);

                // Create a new table with 2 columns for the total
                Table totalTable = new Table(2);
                totalTable.SetWidth(UnitValue.CreatePercentValue(100));

                // Add cells to the table
                totalTable.AddCell(new Cell().Add(new Paragraph("Total")));
                totalTable.AddCell(new Cell().Add(new Paragraph("₹" + total.ToString())));

                document.Add(totalTable);

                // Create a new table with 1 column for the footer
                Table footerTable = new Table(1);
                //footerTable.SetWidth(600);
                //footerTable.SetHorizontalAlignment(HorizontalAlignment.CENTER);

                // Add cells to the table
                Cell footerCell = new Cell();
                footerCell.Add(new Paragraph("Thank you for shopping with us!"));
                footerCell.SetBorder(Border.NO_BORDER);
                footerCell.SetMarginLeft(200f);
                //footerCell.SetHorizontalAlignment(HorizontalAlignment.CENTER);
                //footerCell.SetPadding(30f);
                footerTable.AddCell(footerCell);
                //footerTable.AddCell(new Cell().Add(new Paragraph("Thank you for shopping with us!")));

                document.Add(footerTable);

                // Close the document
                document.Close();

                return ms.ToArray();
            }
        }

    }
}
