
namespace NovaBusinessSystem.DTOs.Products.Sales
{
    public class ProductSalesHistoryDTO
    {
        public int SaleID { get; private set; }
        public string SaleDate { get; private set; }
        public string CustomerName { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public string Status { get; private set; }

        public ProductSalesHistoryDTO(
            int saleID,
            string saleDate,
            string customerName,
            int quantity,
            decimal unitPrice,
            string status)
        {
            SaleID = saleID;
            SaleDate = saleDate;
            CustomerName = customerName;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Status = status;
        }
    }
}
