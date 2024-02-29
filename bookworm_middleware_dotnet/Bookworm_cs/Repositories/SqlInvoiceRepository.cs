using Bookworm_cs.DTOs;
using Bookworm_cs.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookworm_cs.Repositories
{
    public class SqlInvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _context;

        public SqlInvoiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int invoiceId)
        {
            return await _context.Invoices.FindAsync(invoiceId);
        }

        public async Task DeleteByInvoiceIdAsync(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Invoice>> GetByCustomerIdAsync(int customerId)
        {
            return await _context.Invoices
                .Where(i => i.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task DeleteByCustomerIdAsync(int customerId)
        {
            var invoices = _context.Invoices
                .Where(i => i.CustomerId == customerId);
            _context.Invoices.RemoveRange(invoices);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Invoice>> GetByInvoiceAmountAsync(int customerId)
        {
            // Assuming you want to get invoices by the total amount for a specific customer
            return await _context.Invoices
                .Where(i => i.CustomerId == customerId)
                .OrderByDescending(i => i.InvoiceAmount)
                .ToListAsync();
        }

        public async Task<List<Invoice>> GetInvoiceByDateAsync(DateTime date)
        {
            return await _context.Invoices
                .Where(i => i.InvoiceDate.Date == date.Date)
                .ToListAsync();
        }

         public async Task DeleteByInvoiceDateAsync(DateTime date)
         {
             var invoices = _context.Invoices
                 .Where(i => i.InvoiceDate.Date == date.Date);
             _context.Invoices.RemoveRange(invoices);
             await _context.SaveChangesAsync();
         }

        public async Task<int> CreateInvoiceAndDetails(InvoiceDTO invoiceDto)
        {
            // Create and save the Invoice
            var invoice = new Invoice
            {
                InvoiceDate = invoiceDto.InvoiceDate,
                CustomerId = invoiceDto.CustomerId,
                InvoiceAmount = invoiceDto.InvoiceAmount,
                Quantity = invoiceDto.Quantity
            };

            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            // Create and save the InvoiceDetails
            foreach (var detailDto in invoiceDto.InvoiceDetails)
            {
                var invoiceDetails = new InvoiceDetails
                {
                    InvoiceId = invoice.InvoiceId,
                    ProductId = detailDto.ProductId,
                    BasePrice = detailDto.BasePrice,
                    SellingPrice = detailDto.SellingPrice,
                    TransactionTypeId = detailDto.TransactionTypeId,
                    RentingDays = detailDto.RentingDays
                };

                _context.InvoiceDetails.Add(invoiceDetails);

                // Calculate royalty
                var productBeneficiaries = await _context.ProductBeneficiaries
                    .Where(pb => pb.ProductId == detailDto.ProductId)
                    .ToListAsync();

                foreach (var productBeneficiary in productBeneficiaries)
                {
                    Console.WriteLine(productBeneficiary.BenId);
                    var beneficiary = await _context.Beneficiaries.FindAsync(productBeneficiary.BenId);
                    Console.WriteLine(beneficiary);
                    double royalty = 0;

                    if (detailDto.TransactionTypeId == 1) // Purchase
                    {
                        royalty = detailDto.BasePrice * productBeneficiary.Percentage / 100;
                    }
                    else // Rent
                    {
                        var product = await _context.Products.FindAsync(detailDto.ProductId);
                        double rent = (double)product.RentPerDay;
                        royalty = (rent * detailDto.RentingDays) * productBeneficiary.Percentage / 100;
                    }

                    var royaltyCalculation = new RoyaltyCalculation
                    (
                        invoice.InvoiceId,
                        productBeneficiary.BenId,
                        DateTime.Now,
                        detailDto.ProductId,
                        detailDto.TransactionTypeId,
                        detailDto.SellingPrice,
                        detailDto.BasePrice,
                        royalty
                    );

                    _context.RoyaltyCalculations.Add(royaltyCalculation);
                }
            }

            await _context.SaveChangesAsync();

            return invoice.InvoiceId;
        }

        public async Task<int?> GetCustomerIdByInvoiceIdAsync(int invoiceId)
        {
            var invoice = await _context.Invoices.FindAsync(invoiceId);
            return invoice.CustomerId;
        }
        public int? GetCustomerIdByInvoiceId(int invoiceId)
        {
            var invoice = _context.Invoices.Find(invoiceId);
            return invoice.CustomerId;
        }
        public async Task<List<object[]>> GetOrdersByCustomerId(int customerId)
        {
            var orders = await _context.Invoices
                .Where(i => i.CustomerId == customerId)
                .Join(_context.InvoiceDetails,
                    invoice => invoice.InvoiceId,
                    invoiceDetail => invoiceDetail.InvoiceId,
                    (invoice, invoiceDetail) => new object[]
                    {
                invoice.InvoiceId,
                invoice.CustomerId,
                invoice.InvoiceAmount,
                invoice.InvoiceDate,
                invoiceDetail.BasePrice,
                invoiceDetail.SellingPrice,
                invoiceDetail.ProductId,
                invoiceDetail.TransactionTypeId
                    })
                .ToListAsync();
            return orders;
        }

    }
}