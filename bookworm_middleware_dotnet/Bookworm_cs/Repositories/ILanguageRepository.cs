using Bookworm_cs.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookworm_cs.Repositories
{
    public interface ILanguageRepository
    {
        Task<ActionResult<IEnumerable<Language>>> GetLanguageDescByTypeId(int typeid);
        Task<ActionResult<IEnumerable<Language>>> GetLanguageByLanguageId(int languageid);

    }
}
