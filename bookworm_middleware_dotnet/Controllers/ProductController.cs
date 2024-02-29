using Bookworm_cs.Models;
using Bookworm_cs.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bookworm_cs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet("get")]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }

        [HttpGet("get/{id}")]
        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);
        }

        [HttpGet("getByType/{id}")]
        public async Task<IEnumerable<Product>> GetProductsByType(int id)
        {
            return await _productRepository.GetProductsByType(id);
        }

        [HttpGet("language/{id}")]
        public async Task<IEnumerable<Product>> GetProductsByLanguage(int id)
        {
            return await _productRepository.GetProductsByLanguage(id);
        }

        [HttpGet("genre/{id}")]
        public async Task<IEnumerable<Product>> GetProductsByGenre(int id)
        {
            return await _productRepository.GetProductsByGenre(id);
        }

        [HttpGet("get/{typeId}/{languageId}")]
        public async Task<IEnumerable<Product>> GetProductsByLanguageAndType(int typeId, int languageId)
        {
            return await _productRepository.GetProductsByLanguageAndType(languageId, typeId);
        }

        [HttpGet("getByTypeNotInShelf/{typeId}/{customerId}")]
        public async Task<IEnumerable<Product>> GetProductsByTypeNotInShelf(int typeId, int customerId)
        {
            return await _productRepository.GetProductsByTypeNotInShelf(typeId, customerId);
        }

        [HttpGet("getByLanguageAndTypeNotInShelf/{languageId}/{typeId}/{customerId}")]
        public async Task<IEnumerable<Product>> GetProductsByLanguageAndTypeNotInShelf(int languageId, int typeId, int customerId)
        {
            return await _productRepository.GetProductsByLanguageAndTypeNotInShelf(languageId, typeId, customerId);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            await _productRepository.CreateProduct(product);
            return Ok();
        }

        [HttpGet("names")]
        public async Task<IEnumerable<object[]>> GetProductsIdAndName()
        {
            return await _productRepository.GetProductsIdAndName();
        }

    }
}
