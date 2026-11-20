
using System.ComponentModel.DataAnnotations;

namespace NovaBusinessSystem.DTOs.Suppliers;

public record SupplierCreateRequestDto(
    [property: Required]
    [property: StringLength(100, MinimumLength = 1)]
    string SupplierName,

    [property: Required]
    [property: StringLength(100, MinimumLength = 1)]
    string ContactName,

    [property: EmailAddress]
    [property: StringLength(254)]
    string? Email,

    [property: Phone]
    [property: StringLength(20)]
    string? Phone,

    [property: StringLength(250)]
    string? AddressLine,

    [property: StringLength(50)]
    string? City,

    [property: StringLength(100)]
    string? Country,

    [property: StringLength(100)]
    string? TaxNumber,

    [property: Range(0, 365)]
    int PaymentTermsDays = 30,

    [property: Required]
    [property: RegularExpression("^(Active|Inactive|Blocked)$")]
    string Status = "Active",

    [property: StringLength(1000)]
    string? Notes = null
);
