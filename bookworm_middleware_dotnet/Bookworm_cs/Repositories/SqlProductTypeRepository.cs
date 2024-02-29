using Bookworm_cs.Models;
using BookWorm_cs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_cs.Repositories
{
    public class SqlProductTypeRepository : IProductTypeRepository
    {
        private readonly AppDbContext context;

        public SqlProductTypeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<ActionResult<IEnumerable<ProductType>>> GetAllTypes()
        {
            if (context.ProductTypes == null)
            {
                return null;
            }
            return await context.ProductTypes.ToListAsync();
        }
    }
}
