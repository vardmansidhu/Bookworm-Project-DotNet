namespace Bookworm_cs.Models
{
    public class LibraryPackage
    {
        public int LibraryPackageId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int NoOfDays { get; set; }
        public int MaxBooks { get; set; }
    }
}
