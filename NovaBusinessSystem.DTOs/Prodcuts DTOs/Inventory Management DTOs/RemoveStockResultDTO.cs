namespace NovaBusinessSystem.DTOs.Products.Inventory
{
    public class RemoveStockResultDTO
    {
        public int ProductID { get; private set; }
        public string ProductName { get; private set; }
        public int PreviousStock { get; private set; }
        public int RemovedStock { get; private set; }
        public int NewStock { get; private set; }

        public RemoveStockResultDTO(
            int productID,
            string productName,
            int previousStock,
            int removedStock,
            int newStock)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.PreviousStock = previousStock;
            this.RemovedStock = removedStock;
            this.NewStock = newStock;
        }
    }
}