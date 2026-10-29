using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Products.Inventory;

namespace NovaBusinessSystem.DAL.Repositories;

public class InventoryRepository : IInventoryRepository
{
    public async Task<ProductStockResponseDto?> ViewProductStockAsync(int productID)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_ViewProductStock]", connection)
        {

            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        int productIDOrdinal = reader.GetOrdinal("ProductID");
        int productNameOrdinal = reader.GetOrdinal("ProductName");
        int categoryOrdinal = reader.GetOrdinal("Category");
        int priceOrdinal = reader.GetOrdinal("Price");
        int stockQuantityOrdinal = reader.GetOrdinal("StockQuantity");
        int stockValueOrdinal = reader.GetOrdinal("Stock Value");
        int statusOrdinal = reader.GetOrdinal("Status");

        return new ProductStockResponseDto(
            reader.GetInt32(productIDOrdinal),
            reader.GetString(productNameOrdinal),
            reader.GetString(categoryOrdinal),
            reader.GetDecimal(priceOrdinal),
            reader.GetInt32(stockQuantityOrdinal),
            reader.GetDecimal(stockValueOrdinal),
            reader.GetString(statusOrdinal)
        );
    }

    public async Task<AddStockResultDto?> AddStockAsync(int productID, int stockToAdded)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_AddStock]", connection)
        {

            CommandType = CommandType.StoredProcedure
        };
        command.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
        command.Parameters.Add("@StockToAdded", SqlDbType.Int).Value = stockToAdded;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        int productIDOrdinal = reader.GetOrdinal("ProductID");
        int productNameOrdinal = reader.GetOrdinal("ProductName");
        int previousStockOrdinal = reader.GetOrdinal("PreviousStock");
        int addedStockOrdinal = reader.GetOrdinal("AddedStock");
        int newStockOrdinal = reader.GetOrdinal("NewStock");

        return new AddStockResultDto(
            reader.GetInt32(productIDOrdinal),
            reader.GetString(productNameOrdinal),
            reader.GetInt32(previousStockOrdinal),
            reader.GetInt32(addedStockOrdinal),
            reader.GetInt32(newStockOrdinal)
        );
    }

    public async Task<RemoveStockResultDto?> RemoveStockAsync(int productID, int stockToBeRemove)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_RemoveStock]", connection)
        {

            CommandType = CommandType.StoredProcedure
        };
        command.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
        command.Parameters.Add("@StockToBeRemove", SqlDbType.Int).Value = stockToBeRemove;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        int productIDOrdinal = reader.GetOrdinal("ProductID");
        int productNameOrdinal = reader.GetOrdinal("ProductName");
        int previousStockOrdinal = reader.GetOrdinal("PreviousStock");
        int removedStockOrdinal = reader.GetOrdinal("RemovedStock");
        int newStockOrdinal = reader.GetOrdinal("NewStock");

        return new RemoveStockResultDto(
            reader.GetInt32(productIDOrdinal),
            reader.GetString(productNameOrdinal),
            reader.GetInt32(previousStockOrdinal),
            reader.GetInt32(removedStockOrdinal),
            reader.GetInt32(newStockOrdinal)
        );
    }

    public async Task<AdjustStockResultDto?> AdjustStockAsync(int productID, int actualStock)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_AdjustStock]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
        command.Parameters.Add("@ActualStock", SqlDbType.Int).Value = actualStock;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        int productIDOrdinal = reader.GetOrdinal("ProductID");
        int productNameOrdinal = reader.GetOrdinal("ProductName");
        int previousStockOrdinal = reader.GetOrdinal("PreviousStock");
        int actualStockOrdinal = reader.GetOrdinal("ActualStock");
        int adjustmentOrdinal = reader.GetOrdinal("Adjustment");

        return new AdjustStockResultDto(
            reader.GetInt32(productIDOrdinal),
            reader.GetString(productNameOrdinal),
            reader.GetInt32(previousStockOrdinal),
            reader.GetInt32(actualStockOrdinal),
            reader.GetInt32(adjustmentOrdinal)
        );
    }

    public async Task<IEnumerable<LowStockProductDto>> GetLowStockProducts(int threshold)
    {
        List<LowStockProductDto> lowStockProducts = new();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_GetLowStockProducts]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@Threshold", SqlDbType.Int).Value = threshold;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        int productIDOrdinal = reader.GetOrdinal("ProductID");
        int productNameOrdinal = reader.GetOrdinal("ProductName");
        int categoryOrdinal = reader.GetOrdinal("Category");
        int stockQuantityOrdinal = reader.GetOrdinal("StockQuantity");
        int statusOrdinal = reader.GetOrdinal("Status");

        while (await reader.ReadAsync())
        {
            lowStockProducts.Add(new LowStockProductDto(
                reader.GetInt32(productIDOrdinal),
                reader.GetString(productNameOrdinal),
                reader.GetString(categoryOrdinal),
                reader.GetInt32(stockQuantityOrdinal),
                reader.GetString(statusOrdinal)
            ));
        }

        return lowStockProducts;
    }

    public async Task<IEnumerable<OutOfStockProductDto>> GetOutOfStockProducts()
    {
        List<OutOfStockProductDto> outOfStockProducts = new();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[GetOutOfStockProducts]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        int productIDOrdinal = reader.GetOrdinal("ProductID");
        int productNameOrdinal = reader.GetOrdinal("ProductName");
        int categoryOrdinal = reader.GetOrdinal("Category");
        int statusOrdinal = reader.GetOrdinal("Status");

        while (await reader.ReadAsync())
        {
            outOfStockProducts.Add(new OutOfStockProductDto(
                reader.GetInt32(productIDOrdinal),
                reader.GetString(productNameOrdinal),
                reader.GetString(categoryOrdinal),
                reader.GetString(statusOrdinal)
            ));
        }

        return outOfStockProducts;
    }

    public async Task<InventoryValueDto?> GetInventoryValueAsync()
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_GetInventoryValue]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        int totalProductsOrdinal = reader.GetOrdinal("TotalProducts");
        int totalStockUnitsOrdinal = reader.GetOrdinal("TotalStockUnits");
        int totalInventoryValueOrdinal = reader.GetOrdinal("TotalInventoryValue");
        int averageProductPriceOrdinal = reader.GetOrdinal("AverageProductPrice");
        int averageStockOrdinal = reader.GetOrdinal("AverageStock");
        int productNameOrdinal = reader.GetOrdinal("ProductName");
        int stockValueOrdinal = reader.GetOrdinal("StockValue");

        return new InventoryValueDto(
            reader.GetInt32(totalProductsOrdinal),
            reader.GetInt32(totalStockUnitsOrdinal),
            reader.GetDecimal(totalInventoryValueOrdinal),
            reader.GetDecimal(averageProductPriceOrdinal),
            reader.GetDecimal(averageStockOrdinal),
            reader.GetString(productNameOrdinal),
            reader.GetDecimal(stockValueOrdinal)
        );
    }

}
