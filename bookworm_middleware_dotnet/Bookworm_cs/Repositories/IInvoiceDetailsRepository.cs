using Bookworm_cs.Models;

namespace Bookworm_cs.Repositories
{
    public interface IInvoiceDetailsRepository
    {
        Task<List<InvoiceDetails>> GetAllInvoiceDetailsAsync();

        Task<List<InvoiceDetails>> GetInvoiceDetailsByInvoiceIdAsync(int invoiceId);
        List<InvoiceDetails> GetInvoiceDetailsByInvoiceId(int invoiceId);

        Task<InvoiceDetails> GetInvoiceDetailsByIdAsync(int id);

        Task AddInvoiceDetailsAsync(InvoiceDetails invoiceDetails);

        Task UpdateInvoiceDetailsAsync(InvoiceDetails invoiceDetails);

        Task DeleteInvoiceDetailsAsync(int id);
        Task<IEnumerable<int?>> GetTrendingProducts();
    }

}
