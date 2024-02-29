using Bookworm_cs.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookworm_cs.Repositories
{
    public interface IGenreRepository
    {
        Task<ActionResult<IEnumerable<Genre>>> getGenreByLanguage(int id);
    }
}
