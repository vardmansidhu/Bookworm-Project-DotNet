using Bookworm_cs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookworm_cs.Repositories
{
    public class SqlGenreRepository : IGenreRepository

    {
        private readonly AppDbContext context;
        public SqlGenreRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<IEnumerable<Genre>>> getGenreByLanguage(int id)
        {
            var genresInLanguage = await context.Genres
                .Where(g => g.LanguageId == id)
                .ToListAsync();

            return genresInLanguage;

        }
    }
}
