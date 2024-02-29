using Bookworm_cs.DTOs;
using Bookworm_cs.Models;
using Bookworm_cs.PDF;
using Bookworm_cs.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bookworm_cs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IInvoiceDetailsRepository _invoiceDetailsRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository, IInvoiceDetailsRepository invoiceDetailsRepository, IProductRepository productRepository, ICustomerRepository customerRepository)
        {
            _invoiceRepository = invoiceRepository;
            _invoiceDetailsRepository = invoiceDetailsRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<Invoice>> GetById(int id)
        {
            var invoice = await _invoiceRepository.GetInvoiceByIdAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }

        [HttpPost("add")]
        public async Task<ActionResult<int>> AddInvoice( InvoiceDTO invoiceDto)
        {
            invoiceDto.InvoiceDate = DateTime.Now;
            var result = await _invoiceRepository.CreateInvoiceAndDetails(invoiceDto);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _invoiceRepository.DeleteByInvoiceIdAsync(id);
            return NoContent();
        }

        [HttpGet("orders/{id}")]
        public async Task<ActionResult<List<object[]>>> GetOrdersByCustomerId(int id)
        {
            var orders = await _invoiceRepository.GetOrdersByCustomerId(id);
            if (orders == null)
            {
                return NotFound();
            }
            return Ok(orders);
        }


        [HttpGet("pdf/{id}")]
        public async Task<IActionResult> GetInvoicePdf(int id)
        {
            var exporter = new InvoicePDFExporter(_customerRepository, _productRepository);
            var invoiceDetails = _invoiceDetailsRepository.GetInvoiceDetailsByInvoiceId(id);
            var customerId = _invoiceRepository.GetCustomerIdByInvoiceId(id);

            if (customerId == null)
            {
                return NotFound(); // or some other appropriate response
            }

            var pdf = exporter.GenerateInvoice(invoiceDetails, customerId.Value);
            return File(pdf,"application/pdf");
        }
        [HttpGet("trending")]
        public async Task<ActionResult<List<object[]>>> GetTrendingProducts()
        {
            var orders = await _invoiceDetailsRepository.GetTrendingProducts();
            if (orders == null)
            {
                return NotFound();
            }
            return Ok(orders);
        }
    }

}
