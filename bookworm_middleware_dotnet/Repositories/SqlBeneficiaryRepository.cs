using Bookworm_cs.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookworm_cs.Repositories
{
    public class SqlBeneficiaryRepository : IBeneficiaryRepository
    {
        private readonly AppDbContext _context;

        public SqlBeneficiaryRepository (AppDbContext context)
        {
            _context = context;
        }
        public async Task AddBeneficiary(Beneficiary beneficiary)
        {
            await _context.AddAsync(beneficiary);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBeneficiary(int benId)
        {
            Beneficiary? beneficiary = await _context.Beneficiaries.FindAsync(benId);
            if (beneficiary != null)
            {
                _context.Beneficiaries.Remove(beneficiary);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Beneficiary>> GetAllBeneficiaries()
        {
            return await _context.Beneficiaries.ToListAsync();
        }

        public async Task<Beneficiary> GetBeneficiary(int benId)
        {
            return await _context.Beneficiaries.FindAsync(benId);
        }

        public async Task UpdateBeneficiary(int id, Beneficiary beneficiary)
        {   
            Beneficiary beneficiaryUpdate = await _context.Beneficiaries.FindAsync(id);
            if (beneficiaryUpdate != null)
            {
                beneficiaryUpdate.BenName = beneficiary.BenName;
                beneficiaryUpdate.Email = beneficiary.Email;
                beneficiaryUpdate.Contact = beneficiary.Contact;
                beneficiaryUpdate.BankName = beneficiary.BankName;
                beneficiaryUpdate.BankBranch = beneficiary.BankBranch;
                beneficiaryUpdate.IFSC = beneficiary.IFSC;
                beneficiaryUpdate.AccountNo = beneficiary.AccountNo;
                beneficiaryUpdate.AccountType = beneficiary.AccountType;
                beneficiaryUpdate.PAN = beneficiary.PAN;
                await _context.SaveChangesAsync();
            }
        }
    }
}
