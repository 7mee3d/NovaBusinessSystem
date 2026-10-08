using NovaBusinessSystem.DAL.Products.Inventory;
using NovaBusinessSystem.DTOs.Products.Inventory;

namespace NovaBusinessSystem.BL.Products.Inventory
{
    public class InventoryManagement
    {
        public static async Task<ProductStockDTO?> ViewProductStockAsync(int productID)
        {
            return await InventoryDAL.ViewProductStockAsync(productID);
        }

        public static async Task<AddStockResultDTO?> AddStockAsync(int productID, int stockToAdded)
        {
            if (productID <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(productID),
                    "Invalid Product ID."
                    );

            if (stockToAdded <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(stockToAdded),
                    "Stock to add must be greater than zero.");

            return await InventoryDAL.AddStockAsync(
                productID,
                stockToAdded
            );
        }

        public static async Task<RemoveStockResultDTO?> RemoveStockAsync(
             int productID,
             int stockToBeRemove)
        {
            if (productID <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(productID),
                    "Product ID must be greater than zero.");

            if (stockToBeRemove <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(stockToBeRemove),
                    "Stock to remove must be greater than zero.");

            return await InventoryDAL.RemoveStockAsync(
                productID,
                stockToBeRemove
            );
        }

        public static async Task<AdjustStockResultDTO?> AdjustStockAsync(
            int productID,
            int actualStock)
        {
            if (productID <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(productID),
                    "Product ID must be greater than zero.");

            if (actualStock < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(actualStock),
                    "Actual stock cannot be negative.");

            return await InventoryDAL.AdjustStockAsync(
                productID,
                actualStock
            );
        }

        public static async Task<IEnumerable<LowStockProductDTO>> GetLowStockProducts(int threshold)
        {
            if (threshold < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(threshold),
                    "Threshold cannot be negative.");

            return await InventoryDAL.GetLowStockProducts(
                threshold
                );
        }

        public static async Task<IEnumerable<OutOfStockProductDTO>> GetOutOfStockProducts()
        {
            return await InventoryDAL.GetOutOfStockProducts();
        }
    }
}