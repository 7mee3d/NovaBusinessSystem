namespace NovaBusinessSystem.DTOs.Products.Inventory
{
    public class InventoryValueDTO
    {
        public int TotalProducts { get; private set; }
        public int TotalStockUnits { get; private set; }
        public decimal TotalInventoryValue { get; private set; }
        public decimal AverageProductPrice { get; private set; }
        public decimal AverageStock { get; private set; }
        public string MostValuableStock { get; private set; }
        public decimal StockValue { get; private set; }

        public InventoryValueDTO(
            int totalProducts,
            int totalStockUnits,
            decimal totalInventoryValue,
            decimal averageProductPrice,
            decimal averageStock,
            string mostValuableStock,
            decimal stockValue)
        {
            this.TotalProducts = totalProducts;
            this.TotalStockUnits = totalStockUnits;
            this.TotalInventoryValue = totalInventoryValue;
            this.AverageProductPrice = averageProductPrice;
            this.AverageStock = averageStock;
            this.MostValuableStock = mostValuableStock;
            this.StockValue = stockValue;
        }
    }
}