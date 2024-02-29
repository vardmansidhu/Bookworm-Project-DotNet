namespace Bookworm_cs.DTOs
{
    public class InvoiceDTO
    {
        public DateTime InvoiceDate { get; set; }
        public int? CustomerId { get; set; }
        public float? InvoiceAmount { get; set; }
        public int Quantity { get; set; }
        public List<InvoiceDetailDto> InvoiceDetails { get; set; }

        public override string ToString()
        {
            return $"InvoiceDTO [InvoiceDate={InvoiceDate}, CustomerId={CustomerId}, InvoiceAmount={InvoiceAmount}, Quantity={Quantity}, InvoiceDetails={InvoiceDetails}]";
        }
    }
}