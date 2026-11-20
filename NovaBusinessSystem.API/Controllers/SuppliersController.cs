
using System.Runtime.Serialization;
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
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<Results<Ok<SupplierDetailsResponseDTO>, BadRequest<string>>> GetSupplierDetailsResponseAsync(
        [FromRoute(Name = "id")] int id
        )
    {
        if (id <= 0)
            return TypedResults.BadRequest($"{nameof(id)} is zero or negative");

        var SupplierDetailsResponse =
         await _service.GetSupplierDetailsResponseAsync(id);

        return TypedResults.Ok(SupplierDetailsResponse);
    }

    [HttpPost]
    [ProducesResponseType(typeof(SupplierCreateResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<Results<Ok<SupplierCreateResponseDto>, BadRequest<string>>> CreateSupplier(
    [FromBody] SupplierCreateRequestDto supplierRequest)
    {
        var supplierResponse = await _service.CreateSupplierAsync(supplierRequest);

        if (supplierResponse is null)
            return TypedResults.BadRequest("Failed to create supplier.");

        return TypedResults.Ok(supplierResponse);
    }


    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(SupplierUpdateResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<Results<Ok<SupplierUpdateResponseDto>, BadRequest<string>, NotFound<string>>> UpdateSupplier(
    [FromRoute(Name = "id")] int id,
    [FromBody] SupplierUpdateRequestDto updateRequest)
    {
        if (id <= 0)
            return TypedResults.BadRequest("Invalid supplier ID.");

        var supplierUpdateResponse = await _service.UpdateSupplier(id, updateRequest);

        if (supplierUpdateResponse is null)
            return TypedResults.NotFound("Supplier was not found.");

        return TypedResults.Ok(supplierUpdateResponse);
    }
}