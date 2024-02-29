using Bookworm_cs.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookworm_cs.Repositories
{
    public class SqlLibraryRepository : ILibraryRepository
    {
        public readonly AppDbContext _context;

        public SqlLibraryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LibraryPackage>> GetAllLibraryPackagesAsync()
        {
            return await _context.LibraryPackages.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByLibraryPackageIdAsync(int librarypackageId)
        {
            var products = await _context.PackageProducts.Where(pp=>pp.LibrarypackageId == librarypackageId).Select(pp=>pp.Product).ToListAsync();
            return products;
        }
    }
}
