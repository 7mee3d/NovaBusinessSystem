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
    }
}