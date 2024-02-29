using Bookworm_cs.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookworm_cs.Repositories
{
    public class SqlInvoiceDetailsRepository : IInvoiceDetailsRepository
    {
        private readonly AppDbContext _context;

        public SqlInvoiceDetailsRepository (AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<InvoiceDetails>> GetAllInvoiceDetailsAsync()
        {
            return await _context.InvoiceDetails.ToListAsync();
        }

        public async Task<List<InvoiceDetails>> GetInvoiceDetailsByInvoiceIdAsync(int invoiceId)
        {
            return await _context.InvoiceDetails
                .Where(id => id.InvoiceId == invoiceId)
                .ToListAsync();
        }
        public List<InvoiceDetails> GetInvoiceDetailsByInvoiceId(int invoiceId)
        {
            return _context.InvoiceDetails
                .Where(id => id.InvoiceId == invoiceId)
                .ToList();
        }

        public async Task<InvoiceDetails> GetInvoiceDetailsByIdAsync(int id)
        {
            return await _context.InvoiceDetails.FindAsync(id);
        }

        public async Task AddInvoiceDetailsAsync(InvoiceDetails invoiceDetails)
        {
            _context.InvoiceDetails.Add(invoiceDetails);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateInvoiceDetailsAsync(InvoiceDetails invoiceDetails)
        {
            _context.InvoiceDetails.Update(invoiceDetails);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInvoiceDetailsAsync(int id)
        {
            var invoiceDetails = await _context.InvoiceDetails.FindAsync(id);
            if (invoiceDetails != null)
            {
                _context.InvoiceDetails.Remove(invoiceDetails);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<int?>> GetTrendingProducts()
        {
            var topPurchasedProducts = _context.InvoiceDetails
                .GroupBy(detail => detail.ProductId)
                .OrderByDescending(group => group.Count())
                .Select(group => group.Key)
                .ToList();
            return topPurchasedProducts;
        }
    }
}
