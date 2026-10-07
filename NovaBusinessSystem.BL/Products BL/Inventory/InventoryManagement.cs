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
    }
}