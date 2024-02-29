using Bookworm_cs.Models;
using Bookworm_cs.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bookworm_cs.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _repository;

        public GenreController(IGenreRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("getByLanguageId/{id}")]
        public async Task<ActionResult<IEnumerable<Genre>>> getGenreByLanguage(int id)
        {
            return await _repository.getGenreByLanguage(id);
        }

    }

}
