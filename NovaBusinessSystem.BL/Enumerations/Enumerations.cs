namespace NovaBusinessSystem.Enumeration
{

    public class Enumerations
    {
        public enum EnStatus : byte
        {
            _kACTIVE = 1,
            _kINACTIVE = 0,
            _kSUSPENDED = 2
        }

        public enum EnMode : byte
        {
            _kADD = 1,
            _kUPDATE = 2
        }

        public enum EnCategoriesEmployees : byte
        {

            _kBACK = 0,
            _kLIST_EMPLOYEES = 1,
            _kGET_EMPLOYEES_BY_ID = 2,
            _kADD_EMPLOYEE = 3,
            _kUPDATE_INFORMATION_EMPLOYEE = 4,
            _kDELETE_EMPLOYEE = 5,
            _kSEARCH_EMPLOYEES = 6,
            _kEMPLOYEE_REPORT = 7


        }

        public enum EnChoicesSearchEmployees : byte
        {
            _kBACK_MAIN_MENU_EMPLOYEES = 0,
            _kSEARCH_BY_FULL_NAME = 1,
            _kSEARCH_BY_DEPARTMENT_NAME = 2,
            _kSEARCH_BY_JOB_TITLE = 3,
            _kSEARCH_BY_STATUS = 4
        }

        public enum EnChoicesEmployeesReport : byte
        {
            _kBACK = 0,
            _kDEPARTMENT_SUMMARY = 1,
            _kSALARY_SUMMARY = 2,
            _kEMPLOYEE_STATUS_SUMMARY = 3,
            _kHIRING_SUMMARY = 4
        }

        public enum EnChoicesCustomersModule : byte
        {
            _kBACK_MAIN_MENU = 0,
            _kLIST_CUSTOMERS = 1,
            _kGET_CUSTOMER_BY_ID = 2,
            _kADD_NEW_CUSTOMER = 3,
            _kUPDATE_INFORMATION_CUSTOMER = 4,
            _kDELETE_CUSTOMER = 5,
            _kSEARCH_CUSTOMERS = 6,
            _kLOYALTY_POINTS = 7,
            _kCUSTOMER_PURCHASES = 8,
            _kCUSTOMER_REPORT = 9

        }

        public enum EnChoicesLoyaltyPoints : byte
        {
            _kBACK = 0,
            _kVIEW_CUSTOMER_POINTS = 1,
            _kADD_POINTS = 2,
            _kREDEEM_POINTS = 3,
            _kTOP_LOYALTY_CUSTOMERS = 4,
            _kLOYALTY_STATISTICS = 5
        }

        public enum EnChoicesCustomerPurchases : byte
        {
            _kBACK = 0,
            _kPURCHASE_HISTORY = 1,
            _kCUSTOMER_SPENDING_SUMMARY = 2,
            _kCUSTOMER_FAVORITE_PRODUCTS = 3,
            _kCUSTOMER_MONTHLY_PURCHASES = 4,
            _kCUSTOMER_RANKING = 5
        }
    }
}