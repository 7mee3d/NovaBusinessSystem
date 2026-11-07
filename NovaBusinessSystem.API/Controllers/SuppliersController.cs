
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Suppliers;

namespace NovaBusinessSystem.API;

[ApiController]
[Route("api/Suppliers")]
public class SuppliersController : ControllerBase
{

    private readonly ISuppliersService _service;

    public SuppliersController(ISuppliersService service)
    {
        this._service = service;
    }

    [HttpGet]
    public async Task<Results<Ok<SupplierListResponseDTO>, BadRequest<string>>> GetSupplierListAsync(
        [FromQuery] SupplierListRequestDTO supplierRequest
        )
    {
        if (supplierRequest is null)
            return TypedResults.BadRequest($"{nameof(supplierRequest)} is null");

        var SupplierListResponse =
         await _service.GetSupplierListAsync(supplierRequest);

        return TypedResults.Ok(SupplierListResponse);
    }
}