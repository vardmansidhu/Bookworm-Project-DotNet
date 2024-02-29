using Bookworm_cs.Models;
using Bookworm_cs.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bookworm_cs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryRepository _libraryRepository;

        public LibraryController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<LibraryPackage>>> GetAllLibraryPackages()
        {
            var packages = await _libraryRepository.GetAllLibraryPackagesAsync();
            return Ok(packages);
        }

        [HttpGet("{id}/products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByPackageId(int id)
        {
            var products = await _libraryRepository.GetProductsByLibraryPackageIdAsync(id);
            if(products==null)
                return NotFound();
            return Ok(products);
        }
    }
}
