using Bookworm_cs.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookworm_cs.Repositories
{
    public interface ICustomerRepository
    {
        Task<ActionResult<Customer>?> GetCustomer(int CustomerId);
        Task<ActionResult<IEnumerable<Customer>>> GetAllCustomer();
        Task<ActionResult<Customer>> Add(Customer customer);
        Task<Customer> Update(int id, Customer customerChanges);
        Task<Customer> Delete(int CustomerId);
        Task<bool> CustomerExists(string email);
        Task<Customer?> Login(string email, string password);
        String GetCustomerNameById(int id);

    }

}

