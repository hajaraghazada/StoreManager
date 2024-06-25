namespace Iyun25_2024_StoreManager.Entities
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public List<Product> Products { get; set; }
        public decimal TotalAmount { get; set; }
        public User Seller { get; set; }
        public DateTime SaleDate { get; set; }
        public bool IsRefund { get; set; } = false;
    }
}
