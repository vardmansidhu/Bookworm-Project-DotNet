using BookWorm_cs.Models;
using BookWorm_cs.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm_cs.Controllers
{
    [Route("/api/productType")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeRepository _repository;

        public ProductTypeController(IProductTypeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<ProductType>>> GetProductTypes()
        {
            if(await _repository.GetAllTypes() == null)
            {
                return NotFound();
            }
            return await _repository.GetAllTypes();
        }
    }
}