
using System.ComponentModel.DataAnnotations;

namespace NovaBusinessSystem.DTOs.Suppliers;

public record SupplierUpdateRequestDto(
    [Required]
    [StringLength(100, MinimumLength = 1)]
    string SupplierName,

    [Required]
    [StringLength(100, MinimumLength = 1)]
    string ContactName,

    [EmailAddress]
    [StringLength(254)]
    string? Email,

    [Phone]
    [StringLength(20)]
    string? Phone,

    [StringLength(250)]
    string? AddressLine,

    [StringLength(50)]
    string? City,

    [StringLength(100)]
    string? Country,

    [StringLength(100)]
    string? TaxNumber,

    [Range(0, 365)]
    int PaymentTermsDays,

    [Required]
    [RegularExpression("^(Active|Inactive|Blocked)$")]
    string Status,

    [StringLength(1000)]
    string? Notes
);
