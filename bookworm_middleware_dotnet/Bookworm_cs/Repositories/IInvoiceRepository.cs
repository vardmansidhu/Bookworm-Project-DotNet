using Bookworm_cs.DTOs;
using Bookworm_cs.Models;

namespace Bookworm_cs.Repositories
{
    public interface IInvoiceRepository
    {
        Task<Invoice> GetInvoiceByIdAsync(int invoiceId);
        Task DeleteByInvoiceIdAsync(int id);
        Task<List<Invoice>> GetByCustomerIdAsync(int customerId);
        Task DeleteByCustomerIdAsync(int customerId);
        Task<List<Invoice>> GetByInvoiceAmountAsync(int customerId);
        Task<List<Invoice>> GetInvoiceByDateAsync(DateTime date);
        Task DeleteByInvoiceDateAsync(DateTime date);
        public Task<int> CreateInvoiceAndDetails(InvoiceDTO invoiceDto);
        Task<int?> GetCustomerIdByInvoiceIdAsync(int invoiceId);
        int? GetCustomerIdByInvoiceId(int invoiceId);
        Task<List<object[]>> GetOrdersByCustomerId(int customerId);
    }
}
