using NovaBusinessSystem.DAL.Customers.Reports;
using NovaBusinessSystem.DTOs.Customers.Reports;

namespace NovaBusinessSystem.BL.Customers.Reports
{

    public class ReportBL
    {

        public static async Task<IEnumerable<CustomerStatusDTO>>? GetCustomerStatusSummaryAsync() => await ReportDAL.GetCustomerStatusSummaryAsync()!;
        public static async Task<IEnumerable<CustomersByCityDTO>>? GetCustomersByCityAsync() => await ReportDAL.GetCustomersByCityAsync()!;
    }
}