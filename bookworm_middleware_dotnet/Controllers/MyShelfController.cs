using Bookworm_cs.Models;
using BookWorm_cs.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm_cs.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class MyShelfController : ControllerBase
    {
        private readonly IShelfRepository _myShelfRepository;
        public MyShelfController(IShelfRepository myShelfRepository)
        {
            _myShelfRepository = myShelfRepository;
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<Shelf>> GetByShelfId(int id)
        {
            var myshelf=await _myShelfRepository.GetById(id);
            return myshelf == null ? NotFound() : myshelf;
        }

        [HttpGet("getbycustomer/{id}")]
        public async Task<IEnumerable<Product>> GetByCustId(int id)
        {
            return await _myShelfRepository.GetByCustomerId(id);
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddShelf(Shelf shelf)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdShelf = await _myShelfRepository.AddShelf(shelf);

            return Ok(createdShelf);
        }

    }
}