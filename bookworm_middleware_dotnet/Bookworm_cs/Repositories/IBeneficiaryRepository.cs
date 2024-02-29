using Bookworm_cs.Models;

namespace Bookworm_cs.Repositories
{
    public interface IBeneficiaryRepository
    {
        Task<Beneficiary> GetBeneficiary(int benId);
        Task<IEnumerable<Beneficiary>> GetAllBeneficiaries();
        Task AddBeneficiary(Beneficiary beneficiary);
        Task UpdateBeneficiary(int id, Beneficiary beneficiary);
        Task DeleteBeneficiary(int benId);
    }
}
