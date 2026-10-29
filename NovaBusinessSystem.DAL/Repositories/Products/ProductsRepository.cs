using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Products;

namespace NovaBusinessSystem.DAL.Products;

public class ProductsRepository : IProductsRepository
{
    public async Task<IEnumerable<ProductResponseDto?>> GetAllAsync()
    {
        List<ProductResponseDto> products = new();


        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].usp_GetAllProducts", connection)
        {

            CommandType = CommandType.StoredProcedure
        };

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        int productIdOrdinal = reader.GetOrdinal("ProductID");
        int productNameOrdinal = reader.GetOrdinal("ProductName");
        int categoryOrdinal = reader.GetOrdinal("Category");
        int priceOrdinal = reader.GetOrdinal("Price");
        int stockQuantityOrdinal = reader.GetOrdinal("StockQuantity");
        int statusOrdinal = reader.GetOrdinal("Status");

        while (await reader.ReadAsync())
        {
            products.Add(new ProductResponseDto(
                reader.GetInt32(productIdOrdinal),
                reader.GetString(productNameOrdinal),
                reader.GetString(categoryOrdinal),
                reader.GetDecimal(priceOrdinal),
                reader.GetInt32(stockQuantityOrdinal),
                reader.GetString(statusOrdinal)
            ));
        }

        return products;
    }

    public async Task<ProductResponseDto?> GetProductByIDAsync(int productID)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

        using var command = new SqlCommand("[dbo].[usp_GetProductByID]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        int productIdOrdinal = reader.GetOrdinal("ProductID");
        int productNameOrdinal = reader.GetOrdinal("ProductName");
        int categoryOrdinal = reader.GetOrdinal("Category");
        int priceOrdinal = reader.GetOrdinal("Price");
        int stockQuantityOrdinal = reader.GetOrdinal("StockQuantity");
        int statusOrdinal = reader.GetOrdinal("Status");

        return new ProductResponseDto(
            reader.GetInt32(productIdOrdinal),
            reader.GetString(productNameOrdinal),
            reader.GetString(categoryOrdinal),
            reader.GetDecimal(priceOrdinal),
            reader.GetInt32(stockQuantityOrdinal),
            reader.GetString(statusOrdinal)
        );
    }

    public async Task<int> AddProductAsync(ProductCreateRequestDto product)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

        using var command = new SqlCommand("[dbo].[usp_AddNewProduct]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@ProductName", SqlDbType.VarChar, 100).Value = product.ProductName;

        command.Parameters.Add("@Category", SqlDbType.VarChar, 100).Value = product.Category;

        var priceParameter = command.Parameters.Add("@Price", SqlDbType.Decimal);

        priceParameter.Precision = 18;
        priceParameter.Scale = 2;
        priceParameter.Value = product.Price;

        command.Parameters.Add("@StockQuantity", SqlDbType.Int).Value = product.StockQuantity;

        command.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = product.Status;

        var productIdParameter = command.Parameters.Add("@ProductID", SqlDbType.Int);

        productIdParameter.Direction = ParameterDirection.Output;

        await connection.OpenAsync();

        await command.ExecuteNonQueryAsync();

        return Convert.ToInt32(productIdParameter.Value);
    }

    public async Task<bool> UpdateProductAsync(int productID, ProductUpdateRequestDto product)
    {

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

        using var command = new SqlCommand("[dbo].[usp_UpdateProduct]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

        command.Parameters.Add("@ProductName", SqlDbType.VarChar, 100).Value = product.ProductName;

        command.Parameters.Add("@Category", SqlDbType.VarChar, 100).Value = product.Category;

        var priceParameter = command.Parameters.Add("@Price", SqlDbType.Decimal);

        priceParameter.Precision = 18;
        priceParameter.Scale = 2;
        priceParameter.Value = product.Price;

        command.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = product.Status;

        await connection.OpenAsync();

        object? result = await command.ExecuteScalarAsync();

        return result is null or DBNull
        ? false :
        Convert.ToInt32(result) > 0;
    }

    public async Task<bool> DeleteProductAsync(int productID)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

        using var command = new SqlCommand("[dbo].[usp_DeleteProduct]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

        await connection.OpenAsync();

        int rowsAffected = await command.ExecuteNonQueryAsync();

        return rowsAffected > 0;
    }
}