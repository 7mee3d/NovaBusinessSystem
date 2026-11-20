
using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Suppliers;

namespace NovaBusinessSystem.DAL.Repositories;

public class SuppliersRepository : ISuppliersRepository
{

    public async Task<SupplierListResponseDTO> GetSupplierListAsync(SupplierListRequestDTO supplier)
    {


        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_GetSuppliers]", connection)
        {
            CommandType = System.Data.CommandType.StoredProcedure
        };

        command.Parameters.Add("@Search", System.Data.SqlDbType.NVarChar, 150).Value = supplier.Search;
        command.Parameters.Add("@Status", System.Data.SqlDbType.VarChar, 20).Value = supplier.Status;
        command.Parameters.Add("@SortBy", System.Data.SqlDbType.VarChar, 30).Value = supplier.SortBy;
        command.Parameters.Add("@SortDirection", System.Data.SqlDbType.VarChar, 4).Value = supplier.SortDirection;
        command.Parameters.Add("@PageNumber", System.Data.SqlDbType.Int).Value = supplier.PageNumber;
        command.Parameters.Add("@PageSize", System.Data.SqlDbType.Int).Value = supplier.PageSize;

        SqlParameter parameterTotalCount = new("@TotalCount", System.Data.SqlDbType.Int);

        parameterTotalCount.Direction = System.Data.ParameterDirection.Output;
        command.Parameters.Add(parameterTotalCount);

        await connection.OpenAsync();
        List<SupplierListItemResponseDTO> suppliers = new();

        using (var reader = await command.ExecuteReaderAsync())
        {
            while (await reader.ReadAsync())
            {
                SupplierListItemResponseDTO supplierItem = new(
                    SupplierID: reader.GetInt32(reader.GetOrdinal("SupplierID")),
                    SupplierName: reader.GetString(reader.GetOrdinal("SupplierName")),
                    City: reader.IsDBNull(reader.GetOrdinal("City"))
                        ? null
                        : reader.GetString(reader.GetOrdinal("City")),
                    Orders: reader.GetInt32(reader.GetOrdinal("Orders")),
                    Status: reader.GetString(reader.GetOrdinal("Status"))
                );

                suppliers.Add(supplierItem);
            }
        }
        var totalCount = Convert.ToInt32(parameterTotalCount.Value);
        var totalPages = (int)Math.Ceiling((double)totalCount / supplier.PageSize);

        return new SupplierListResponseDTO(suppliers, totalCount, supplier.PageNumber, supplier.PageSize, totalPages);

    }

    public async Task<SupplierDetailsResponseDTO?> GetSupplierDetailsResponseAsync(int supplierID)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

        using var command = new SqlCommand("[dbo].[usp_GetSupplierByID]", connection)
        {
            CommandType = System.Data.CommandType.StoredProcedure
        };

        command.Parameters.Add("@SupplierID", System.Data.SqlDbType.Int).Value = supplierID;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        var supplierDetails = new SupplierDetailsDTO(
            SupplierID: reader.GetInt32(reader.GetOrdinal("SupplierID")),
            SupplierName: reader.GetString(reader.GetOrdinal("SupplierName")),
            ContactName: reader.IsDBNull(reader.GetOrdinal("ContactName"))
                ? null
                : reader.GetString(reader.GetOrdinal("ContactName")),
            Email: reader.IsDBNull(reader.GetOrdinal("Email"))
                ? null
                : reader.GetString(reader.GetOrdinal("Email")),
            Phone: reader.IsDBNull(reader.GetOrdinal("Phone"))
                ? null
                : reader.GetString(reader.GetOrdinal("Phone")),
            City: reader.IsDBNull(reader.GetOrdinal("City"))
                ? null
                : reader.GetString(reader.GetOrdinal("City")),
            Country: reader.IsDBNull(reader.GetOrdinal("Country"))
                ? null
                : reader.GetString(reader.GetOrdinal("Country")),
            PaymentTerms: $"{(int)reader.GetInt16(reader.GetOrdinal("PaymentTermsDays"))} Days",
            Status: reader.GetString(reader.GetOrdinal("Status"))
        );

        var supplierProcurementSummary = new SupplierProcurementSummaryDTO(
            TotalPurchaseOrders: reader.GetInt32(reader.GetOrdinal("TotalPurchaseOrders")),
            FullyReceivedOrders: reader.GetInt32(reader.GetOrdinal("FullyReceivedOrders")),
            OpenOrders: reader.GetInt32(reader.GetOrdinal("OpenOrders")),
            CancelledOrders: reader.GetInt32(reader.GetOrdinal("CancelledOrders")),
            TotalOrderedValue: reader.GetDecimal(reader.GetOrdinal("TotalOrderedValue")),
            AcceptedReceivedValue: reader.GetDecimal(reader.GetOrdinal("AcceptedReceivedValue")),
            LastPurchaseOrderDate: reader.IsDBNull(reader.GetOrdinal("LastPurchaseOrder"))
                ? null
                : reader.GetDateTime(reader.GetOrdinal("LastPurchaseOrder"))
        );

        return new SupplierDetailsResponseDTO(
            supplierDetails,
            supplierProcurementSummary
        );
    }

    public async Task<SupplierCreateResponseDto?> CreateSupplierAsync(SupplierCreateRequestDto supplierRequest)
    {

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_CreateSupplier]", connection)
        {
            CommandType = System.Data.CommandType.StoredProcedure
        };


        command.Parameters.Add("@SupplierName", SqlDbType.NVarChar, 100).Value = supplierRequest.SupplierName;
        command.Parameters.Add("@ContactName", SqlDbType.NVarChar, 100).Value = supplierRequest.ContactName;
        command.Parameters.Add("@Email", SqlDbType.VarChar, 254).Value = (object?)supplierRequest.Email ?? DBNull.Value;
        command.Parameters.Add("@Phone", SqlDbType.VarChar, 20).Value = (object?)supplierRequest.Phone ?? DBNull.Value;
        command.Parameters.Add("@AddressLine", SqlDbType.NVarChar, 250).Value = (object?)supplierRequest.AddressLine ?? DBNull.Value;
        command.Parameters.Add("@City", SqlDbType.NVarChar, 50).Value = (object?)supplierRequest.City ?? DBNull.Value;
        command.Parameters.Add("@Country", SqlDbType.NVarChar, 100).Value = (object?)supplierRequest.Country ?? DBNull.Value;
        command.Parameters.Add("@TaxNumber", SqlDbType.NVarChar, 100).Value = (object?)supplierRequest.TaxNumber ?? DBNull.Value;
        command.Parameters.Add("@PaymentTermsDays", SqlDbType.Int).Value = supplierRequest.PaymentTermsDays;
        command.Parameters.Add("@Status", SqlDbType.VarChar, 20).Value = supplierRequest.Status;
        command.Parameters.Add("@Notes", SqlDbType.NVarChar, 1000).Value = (object?)supplierRequest.Notes ?? DBNull.Value;

        var supplierIdParameter = command.Parameters.Add("@SupplierID", SqlDbType.Int);
        supplierIdParameter.Direction = ParameterDirection.Output;

        await connection.OpenAsync();

        await command.ExecuteNonQueryAsync();

        var supplierID = Convert.ToInt32(supplierIdParameter.Value);
        if (supplierID <= 0)
            return null;


        return new SupplierCreateResponseDto(
                supplierID,
                supplierRequest.SupplierName,
                supplierRequest.City,
                supplierRequest.PaymentTermsDays,
                supplierRequest.Status
        );

    }

    public async Task<SupplierUpdateResponseDto?> UpdateSupplier(int supplierID, SupplierUpdateRequestDto supplierUpdate)
    {

        List<SupplierUpdateResponseDto> suppliers = new();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_UpdateSupplier]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };


        command.Parameters.Add("@SupplierID", SqlDbType.Int).Value = supplierID;
        command.Parameters.Add("@SupplierName", SqlDbType.NVarChar, 100).Value = supplierUpdate.SupplierName;
        command.Parameters.Add("@ContactName", SqlDbType.NVarChar, 100).Value = supplierUpdate.ContactName;
        command.Parameters.Add("@Email", SqlDbType.VarChar, 254).Value = (object?)supplierUpdate.Email ?? DBNull.Value;
        command.Parameters.Add("@Phone", SqlDbType.VarChar, 20).Value = (object?)supplierUpdate.Phone ?? DBNull.Value;
        command.Parameters.Add("@AddressLine", SqlDbType.NVarChar, 250).Value = (object?)supplierUpdate.AddressLine ?? DBNull.Value;
        command.Parameters.Add("@City", SqlDbType.NVarChar, 50).Value = (object?)supplierUpdate.City ?? DBNull.Value;
        command.Parameters.Add("@Country", SqlDbType.NVarChar, 100).Value = (object?)supplierUpdate.Country ?? DBNull.Value;
        command.Parameters.Add("@TaxNumber", SqlDbType.NVarChar, 100).Value = (object?)supplierUpdate.TaxNumber ?? DBNull.Value;
        command.Parameters.Add("@PaymentTermsDays", SqlDbType.Int).Value = supplierUpdate.PaymentTermsDays;
        command.Parameters.Add("@Status", SqlDbType.VarChar, 20).Value = supplierUpdate.Status;
        command.Parameters.Add("@Notes", SqlDbType.NVarChar, 1000).Value = (object?)supplierUpdate.Notes ?? DBNull.Value;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        var supplierIdOrdinal = reader.GetOrdinal("SupplierID");
        var supplierNameOrdinal = reader.GetOrdinal("SupplierName");
        var statusOrdinal = reader.GetOrdinal("Status");
        var updatedAtOrdinal = reader.GetOrdinal("UpdatedAt");

        return new SupplierUpdateResponseDto(
            reader.GetInt32(supplierIdOrdinal),
            reader.GetString(supplierNameOrdinal),
            reader.GetString(statusOrdinal),
            reader.GetDateTime(updatedAtOrdinal)
        );
    }

    public async Task<DeleteSupplierResponseDto?> DeleteSupplierAsync(int supplierID)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

        using var command = new SqlCommand("[dbo].[usp_DeleteSupplier]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@SupplierID", SqlDbType.Int).Value = supplierID;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        return new DeleteSupplierResponseDto(
            SupplierID: reader.GetInt32(reader.GetOrdinal("SupplierID")),
            Action: reader.GetString(reader.GetOrdinal("Action")),
            Message: reader.GetString(reader.GetOrdinal("Message"))
        );
    }
}