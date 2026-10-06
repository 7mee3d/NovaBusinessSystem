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
                throw new ArgumentException("Invalid Product ID.");

            if (stockToAdded <= 0)
                throw new ArgumentException(
                    "Stock to add must be greater than zero.");

            return await InventoryDAL.AddStockAsync(
                productID,
                stockToAdded
            );
        }
    }
}