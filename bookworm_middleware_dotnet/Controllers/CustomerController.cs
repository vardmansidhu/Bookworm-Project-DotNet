using Bookworm_cs.Models;
using Bookworm_cs.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookworm_cs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;
        public CustomerController(ICustomerRepository repository) { 
        _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>?>> GetCustomer() { 
        if(await _repository.GetAllCustomer() == null)
            {
                return NotFound();
            }
            return await _repository.GetAllCustomer();
        }
        [HttpGet("get/{id}")]
        public async Task<ActionResult<Customer>> GetByCustomerId(int id) { 
        var customer= await _repository.GetCustomer(id);
            return customer == null ? NotFound() : customer;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer) {
            if (id != customer.CustomerId) { 
            return BadRequest();
            }
            try {
                await _repository.Update(id, customer);
            }
            catch(DbUpdateConcurrencyException)
            {
                if (_repository.GetAllCustomer() == null)
                {
                    return NotFound();
                }
                else {
                    throw;
                }
            }
            return NoContent();
        }
        [HttpPost("add")]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        { 
        await _repository.Add(customer);
            return CreatedAtAction("PostCustomer", new { id = customer.CustomerId }, customer);
                }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id) {
            if (_repository.GetAllCustomer() == null) { 
            return NotFound();
            }
            var customer = _repository.Delete(id);
            if(customer == null) { return NotFound(); }
            await _repository.Delete(customer.Id);
            return NoContent();
        }

        [HttpGet("exists")]
        public async Task<ActionResult<bool>> CustomerExists([FromQuery] string email)
        {
            return await _repository.CustomerExists(email);
        }

        [HttpPost("login")]
        public async Task<ActionResult<int>> Login(LoginRequest request)
        {
            Console.WriteLine(request.customerEmail + " " + request.password);
            var customer = await _repository.Login(request.customerEmail, request.password);

            if (customer == null)
            {
                return Unauthorized();
            }

            return Ok(customer.CustomerId);
        }

        [HttpPost("logout")]
        public ActionResult Logout()
        {
            return Ok();
        }
    }
}
