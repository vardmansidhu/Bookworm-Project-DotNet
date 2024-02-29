using Bookworm_cs.Models;

namespace Bookworm_cs.Repositories
{
    public interface ILibraryRepository
    {
        Task<IEnumerable<LibraryPackage>> GetAllLibraryPackagesAsync();

        Task<IEnumerable<Product>> GetProductsByLibraryPackageIdAsync(int languagepackageId);
    }
}
