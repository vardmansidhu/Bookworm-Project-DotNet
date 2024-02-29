using Bookworm_cs.Models;
using Bookworm_cs.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bookworm_cs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {

        public ILanguageRepository _languageRepository;


        public LanguageController(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;

        }

        [HttpGet("getByTypeId/{typeId}")]
        public async Task<ActionResult<IEnumerable<Language>>> GetLanguageByTypeId(int typeId)
        {
            var language = await _languageRepository.GetLanguageDescByTypeId(typeId);

            if (language == null)
            {
                return NotFound();
            }
            else

            return language;
        }

        [HttpGet("getByLanguageId/{langId}")]
        public async Task<ActionResult<IEnumerable<Language>>> GetLanguageByLanguageId(int langId)
        {
            var language = await _languageRepository.GetLanguageByLanguageId(langId);

            if (language == null)
            {
                return NotFound();
            }
            else

                return language;
        }
    }
}
