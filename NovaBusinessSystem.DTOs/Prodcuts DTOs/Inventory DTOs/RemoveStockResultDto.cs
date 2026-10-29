namespace NovaBusinessSystem.DTOs.Products.Inventory;

public record RemoveStockResultDto(
    int ProductID,
    string ProductName,
    int PreviousStock,
    int RemovedStock,
    int NewStock
);