namespace NovaBusinessSystem.DTOs.Products.Inventory;

public record AdjustStockResultDto(
    int ProductID,
    string ProductName,
    int PreviousStock,
    int ActualStock,
    int Adjustment
);