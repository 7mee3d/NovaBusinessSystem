namespace NovaBusinessSystem.DTOs.Products.Inventory
{
    public class AddStockResultDTO
    {
        public int ProductID { get; private set; }
        public string ProductName { get; private set; }
        public int PreviousStock { get; private set; }
        public int AddedStock { get; private set; }
        public int NewStock { get; private set; }

        public AddStockResultDTO(
            int productID,
            string productName,
            int previousStock,
            int addedStock,
            int newStock)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.PreviousStock = previousStock;
            this.AddedStock = addedStock;
            this.NewStock = newStock;
        }
    }
}