using System.Data;
using nCustomersDAL;

namespace nCustomersBL
{

    public class CustomersBL
    {
        
        public static DataTable GetCustomersList () => CustomersDAL.GetAllCustomersList();
    }
    
}