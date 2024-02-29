using Bookworm_cs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookworm_cs.Repositories
{
    public class SqlCustomerRepository : ICustomerRepository

    {

        private readonly AppDbContext context;
        public SqlCustomerRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<ActionResult<Customer>> Add(Customer customer)
        {
            context.Customers.Add(customer);
            await context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> Delete(int CustomerId)
        {
            Customer customer = context.Customers.Find(CustomerId);
            if (customer != null)
            {
                context.Customers.Remove(customer);
                await context.SaveChangesAsync();
            }
            return customer;

        }

        public async Task<ActionResult<IEnumerable<Customer?>>> GetAllCustomer()
        {
            if (context.Customers == null)
            {
                return null;
            }
            return await context.Customers.ToListAsync();
        }

        public async Task<ActionResult<Customer>?> GetCustomer(int CustomerId)
        {
            if (context.Customers == null)
            {
                return null;
            }
            var customer = await context.Customers.FindAsync(CustomerId);
            if (customer == null)
            {

                return null;
            }
            return customer;
        }

        public async Task<Customer> Update(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return null;
            }
            context.Entry(customer).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }

            }
            return null;
        }
        private bool CustomerExists(int id)
        {
            return (context.Customers?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }

        public async Task<bool> CustomerExists(string email)
        {
            bool isExists = await context.Customers.AnyAsync(e => e.CustomerEmail == email);
            return isExists;
        }

        public async Task<Customer?> Login(string email, string password)
        {
            var customer = await context.Customers
                .FirstOrDefaultAsync(c => c.CustomerEmail == email && c.Password == password);

            return customer;
        }

        public String GetCustomerNameById(int id)
        {
            var name = context.Customers.Find(id);
            return name.CustomerName;
        }

    }
}