using Bookworm_cs.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm_cs.Repositories
{
    public interface IShelfRepository
    {
        Task<Shelf>? GetById(int ShelfId);
        Task<IEnumerable<Product>> GetByCustomerId(int customerId);
        Task<Shelf> AddShelf(Shelf shelf);
    }
}
