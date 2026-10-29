namespace NovaBusinessSystem.DTOs.Products.Reports
{
    public record MonthlyProductPerformanceReportDto(
        string Month,
        int Orders,
        int Units,
        decimal Revenue,
        string Growth
    );
}
