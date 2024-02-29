using BookWorm_cs.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm_cs.Repositories
{
    public interface IProductTypeRepository
    {
        Task<ActionResult<IEnumerable<ProductType>>> GetAllTypes();
    }
}