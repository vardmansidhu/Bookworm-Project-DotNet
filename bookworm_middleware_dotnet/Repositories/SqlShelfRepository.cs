using Bookworm_cs.Models;
using Bookworm_cs.Repositories;
using BookWorm_cs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_cs.Repositories
{
    public class SqlShelfRepository : IShelfRepository
    {
        private readonly AppDbContext context;
        private readonly IProductRepository productRepository;
        public SqlShelfRepository(AppDbContext context)
        {
            this.context = context;
            productRepository = new SqlProductRepository(context);
        }
        public async Task<IEnumerable<Product>> GetByCustomerId(int customerId)
        {
            var productIds = await GetProductIdByCustomerId(customerId);
            var products = new List<Product>();
            foreach (var productId in productIds)
            {
                var product = await productRepository.GetProductById(productId);
                if (product != null)
                {
                    products.Add(product);
                }
            }
            return products;
        }

        public async Task<Shelf>? GetById(int ShelfId)
        {
            if (context.Shelfs == null)
            {
                return null;
            }
            var myshelf = await context.Shelfs.FindAsync(ShelfId);
            if (myshelf == null)
            {
                return null;
            }
            return myshelf;
        }

        public async Task<List<int>> GetProductIdByCustomerId(int customerId)
        {
            var productIds = await context.Shelfs.Where(s => s.CustomerId == customerId).Select(s => s.ProductId).ToListAsync();
            return productIds;
        }

        public async Task<Shelf> AddShelf(Shelf shelf)
        {
            // Add the shelf to the database
            context.Shelfs.Add(shelf);
            await context.SaveChangesAsync();
            return shelf;
        }
    }
}
