using Bookworm_cs.Models;

namespace Bookworm_cs.Repositories
{
    public interface IProductRepository 
    {
        Task CreateProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);

        Task<IEnumerable<Product>> GetProductsByType(int id);
        Task<IEnumerable<Product>> GetProductsByLanguage(int id);
        Task<IEnumerable<Product>> GetProductsByLanguageAndType(int languageId, int typeId);
        Task<IEnumerable<Product>> GetProductsByGenre(int id);
        String GetProductNameById(int id);
        Task<IEnumerable<Product>> GetProductsByTypeNotInShelf(int typeId, int customerId);
        Task<IEnumerable<Product>> GetProductsByLanguageAndTypeNotInShelf(int languageId, int typeId, int customerId);
        Task<IEnumerable<object[]>> GetProductsIdAndName();
    }
}
