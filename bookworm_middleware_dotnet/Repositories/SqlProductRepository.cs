using Bookworm_cs.Models;
using BookWorm_cs.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookworm_cs.Repositories
{
    public class SqlProductRepository : IProductRepository
    {   
        private readonly AppDbContext _context;

        public SqlProductRepository(AppDbContext context)
        {
               _context = context;
        }
        public async Task CreateProduct(Product product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public string GetProductNameById(int id)
        {
            var product = _context.Products.Find(id);
            return product?.ProductEngName;
        }

        public async Task<IEnumerable<Product>> GetProductsByGenre(int id)
        {
            return await _context.Products.Where(p => p.GenreId == id).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByLanguage(int id)
        {
            return await _context.Products.Where(p => p.LanguageId == id).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByLanguageAndType(int languageId, int typeId)
        {
            return await _context.Products.Where(p => p.LanguageId == languageId && p.ProductTypeId == typeId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByLanguageAndTypeNotInShelf(int languageId, int typeId, int customerId)
        {
            var productsNotInShelf = await _context.Products
                       .Where(p => p.ProductTypeId == typeId && p.LanguageId == languageId)
                       .Where(p => !_context.Shelfs.Any(s => s.ProductId == p.ProductId && s.CustomerId == customerId))
                       .ToListAsync();

            return productsNotInShelf;
        }

        public async Task<IEnumerable<Product>> GetProductsByType(int id)
        {
            return await _context.Products.Where(p => p.ProductTypeId == id).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByTypeNotInShelf(int typeId, int customerId)
        {
            var productsNotInShelf = await _context.Products
          .Where(p => p.ProductTypeId == typeId)
          .Where(p => !_context.Shelfs.Any(s => s.ProductId == p.ProductId && s.CustomerId == customerId))
          .ToListAsync();

            return productsNotInShelf;
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<object[]>> GetProductsIdAndName()
        {
            return await _context.Products.Select(p => new object[] { p.ProductId, p.ProductEngName }).ToListAsync();
        }
    }
}
