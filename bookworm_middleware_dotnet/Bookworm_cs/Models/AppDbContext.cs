using BookWorm_cs.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookworm_cs.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        //onConfiguration method
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\\ProjectModels;Initial Catalog=BookwormDB;Integrated Security=True");
            }
        }

        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Beneficiary> Beneficiaries { get; set; }
        public DbSet<ProductBeneficiary> ProductBeneficiaries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        //public DbSet<CustomerPreferencesAttribute> CustomerPreferencesAttributes { get; set; }
        //public DbSet<CustomerPreference> CustomerPreferences { get; set; }
        //public DbSet<Cart> Carts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public DbSet<RoyaltyCalculation> RoyaltyCalculations { get; set; }
        public DbSet<Shelf> Shelfs { get; set; }
        public DbSet<LibraryPackage> LibraryPackages { get; set; }
        public DbSet<PackageProduct> PackageProducts { get; set; }
    }
}
