namespace NovaBusinessSystem.DTOs.Products.Inventory;

public record AddStockResultDto(
    int ProductID,
    string ProductName,
    int PreviousStock,
    int AddedStock,
    int NewStock
);