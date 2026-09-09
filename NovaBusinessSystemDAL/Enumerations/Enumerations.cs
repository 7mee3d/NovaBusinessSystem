namespace nEnumeration
{

    public class Enumerations
    {
        public enum EnStatus
        {
            _kACTIVE = 1,
            _kINACTIVE = 0 ,
             _kSUSPENDED = 2
        }

        public enum EnMode
        {
            _kADD = 1 ,
            _kUPDATE = 2 
        }

        public enum EnCategoriesEmployees
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

        public enum EnChoicesSearchEmployees
        {
            _kBACK_MAIN_MENU_EMPLOYEES = 0 ,
            _kSEARCH_BY_FULL_NAME = 1 ,
            _kSEARCH_BY_DEPARTMENT_NAME = 2 , 
            _kSEARCH_BY_JOB_TITLE = 3 , 
            _kSEARCH_BY_STATUS = 4 
        }

        public enum EnChoicesEmployeesReport
        {
            _kBACK = 0 ,
            _kDEPARTMENT_SUMMARY = 1 ,
            _kSALARY_SUMMARY = 2 ,
            _kEMPLOYEE_STATUS_SUMMARY = 3,
            _kHIRING_SUMMARY = 4 
        }

    }
}