namespace NovaBusinessSystem.DTOs.Products.Reports
{
    public record MonthlyProductPerformanceDTO(
        string Month,
        int Orders,
        int Units,
        decimal Revenue,
        string Growth
    );
}
