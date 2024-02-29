using Bookworm_cs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bookworm_cs.Repositories
{
    public class SqlLanguageRepository : ILanguageRepository
    {
        private readonly AppDbContext context;

        public SqlLanguageRepository(AppDbContext context)
        {
            this.context = context;
            
        }

        public async Task<ActionResult<IEnumerable<Language>>> GetLanguageByLanguageId(int languageid)
        {
            if (context.Languages == null)
            {
                return null;
            }

            var language = await context.Languages.Where(l => l.LanguageId == languageid).ToListAsync();

            if (language == null)
            {
                return new NotFoundResult();
            }

            return language;
        }

        public async Task<ActionResult<IEnumerable<Language>>> GetLanguageDescByTypeId(int typeid)
        {
            if (context.Languages == null)
            {
                return null;
            }

            var language = await context.Languages
                .Where(l => l.ProductTypeId == typeid)
                .ToListAsync();

            if (language == null)
            {
                return new NotFoundResult();
            }

            return language;
        }
    }
}
