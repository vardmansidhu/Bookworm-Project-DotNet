namespace Bookworm_cs.Models
{
    public class PackageProduct
    {
        public int packageProductId { get; set; }
        public int LibrarypackageId { get; set; }
        public LibraryPackage LibraryPackage { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
