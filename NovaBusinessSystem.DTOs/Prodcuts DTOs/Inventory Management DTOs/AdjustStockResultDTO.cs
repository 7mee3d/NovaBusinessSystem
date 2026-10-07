namespace NovaBusinessSystem.DTOs.Products.Inventory
{
    public class AdjustStockResultDTO
    {
        public int ProductID { get; private set; }
        public string ProductName { get; private set; }
        public int PreviousStock { get; private set; }
        public int ActualStock { get; private set; }
        public int Adjustment { get; private set; }

        public AdjustStockResultDTO(
            int productID,
            string productName,
            int previousStock,
            int actualStock,
            int adjustment)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.PreviousStock = previousStock;
            this.ActualStock = actualStock;
            this.Adjustment = adjustment;
        }
    }
}