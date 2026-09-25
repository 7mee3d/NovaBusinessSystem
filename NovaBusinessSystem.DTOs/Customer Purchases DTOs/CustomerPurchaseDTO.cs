namespace NovaBusinessSystem.DTOs
{

    public class CustomerPurchaseDTO
    {
        public int SaleID { get; private set; }
        public string SaleDate { get; private set; }
        public decimal Amount { get; private set; }
        public string PaymentMethod { get; private set; }
        public string Status { get; private set; }

        public CustomerPurchaseDTO(
            int saleID,
            string saleDate,
            decimal amount,
            string paymentMethod,
            string status)
        {
            this.SaleID = saleID;
            this.SaleDate = saleDate;
            this.Amount = amount;
            this.PaymentMethod = paymentMethod;
            this.Status = status;
        }
    }
}