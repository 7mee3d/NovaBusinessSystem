
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


}