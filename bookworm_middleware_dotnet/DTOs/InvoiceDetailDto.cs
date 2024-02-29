namespace Bookworm_cs.DTOs
{
    public class InvoiceDetailDto
    {
        public int ProductId { get; set; }
        //public int Quantity { get; set; }
        public float BasePrice { get; set; }
        public float SellingPrice { get; set; }
        public int TransactionTypeId { get; set; }
        public int RentingDays { get; set; }
        public int InvoiceId { get; set; }

        public override string ToString()
        {
            return $"InvoiceDetailDto [ProductId={ProductId}, BasePrice={BasePrice}, SellingPrice={SellingPrice}, TransactionTypeId={TransactionTypeId}, RentingDays={RentingDays}, InvoiceId={InvoiceId}]";
        }
    }
}
