using Bookworm_cs.Models;
using Bookworm_cs.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bookworm_cs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiaryController : ControllerBase
    {
        private readonly IBeneficiaryRepository _beneficiaryRepository;

        public BeneficiaryController(IBeneficiaryRepository beneficiaryRepository)
        {
            _beneficiaryRepository = beneficiaryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beneficiary>>> GetBeneficiaries()
        {
            return Ok(await _beneficiaryRepository.GetAllBeneficiaries());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Beneficiary>> GetBeneficiary(int id)
        {
            var beneficiary = await _beneficiaryRepository.GetBeneficiary(id);
            if (beneficiary == null)
            {
                return NotFound();
            }
            return Ok(beneficiary);
        }

        [HttpPost]
        public async Task<ActionResult<Beneficiary>> PostBeneficiary(Beneficiary beneficiary)
        {
            await _beneficiaryRepository.AddBeneficiary(beneficiary);
            return CreatedAtAction("GetBeneficiary", new { id = beneficiary.BenId }, beneficiary);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeneficiary(int id, Beneficiary beneficiary)
        {
            if (id != beneficiary.BenId)
            {
                return BadRequest();
            }
            await _beneficiaryRepository.UpdateBeneficiary(id, beneficiary);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeneficiary(int id)
        {
            await _beneficiaryRepository.DeleteBeneficiary(id);
            return NoContent();
        }
    }
}
