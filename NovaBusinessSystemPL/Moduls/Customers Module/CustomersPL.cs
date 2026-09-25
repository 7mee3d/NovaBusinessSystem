using Microsoft.Data.SqlClient;
using NovaBusinessSystem.DTOs;
using NovaBusinessSystem.BL;
using NovaBusinessSystem.Enumeration;
using nHelpersPL;

namespace NovaBusinessSystem.PL
{


    public class CustomersPL 
    {
        private static void PrintDetail(string label, object? value, int numberTabs)
        {
            const int ContentWidth = 50;

            string Text = $"{label,-20} : {value ?? " "}";

            if (Text.Length > ContentWidth)
                Text = Text[..ContentWidth];


            Console.WriteLine($"{HelperPL.GenarateTabs(numberTabs)}║ {Text,-48}║");
        }

        private static void _ShowSccessMessageAndShowInformationCustomer(CustomersBL informationCustomer, string message)
        {

            int width = 50;
            int contentWidth = width - 2;

            int paddingLeft = (contentWidth - message.Length) / 2;
            int paddingRight = contentWidth - message.Length - paddingLeft - 1;

            System.Console.WriteLine("\n\n\n");
            Console.WriteLine($"\n\n{HelperPL.GenarateTabs(7)}╔═════════════════════════════════════════════════╗");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║{new string(' ', paddingLeft)}{message}{new string(' ', paddingRight)} ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}╚═════════════════════════════════════════════════╝");

            PrintDetail("Customer ID", informationCustomer.CustomerID, 7);
            PrintDetail("First Name", informationCustomer.FirstName, 7);
            PrintDetail("Last Name", informationCustomer.LastName, 7);
            PrintDetail("Email", informationCustomer.Email, 7);
            PrintDetail("Phone", informationCustomer.Phone, 7);
            PrintDetail("City", informationCustomer.City.Trim(), 7);
            PrintDetail("Registration Date", $"{informationCustomer.RegistrationDate.ToString("dd/MM/yyyy")}", 7);
            PrintDetail("Status", informationCustomer.Status, 7);
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}╚═════════════════════════════════════════════════╝");
        }

        private static void _MainMenuCustomersModule()
        {
            Console.WriteLine($"\n\n\n{HelperPL.GenarateTabs(7)}╔══════════════════════════════════════════╗");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║              👥 CUSTOMERS                ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}╠══════════════════════════════════════════╣");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║                                          ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║  1. 📋 List Customers                    ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║  2. 🔎 Get Customer By ID                ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║  3. ➕ Add Customer                      ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║  4. ✏️  Update Customer                   ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║  5. 🗑️  Delete Customer                   ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║  6. 🔍 Search Customers                  ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║  7. ⭐ Loyalty Points                    ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║  8. 🛒 Customer Purchases                ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║  9. 📊 Customer Report                   ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║                                          ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║  0. 🔙 Back                              ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║                                          ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}╚══════════════════════════════════════════╝");

        }

        private static void _PrintCustomerDetails(CustomersBL informationCustomer, string? title)
        {
            if ((informationCustomer is null) || string.IsNullOrWhiteSpace(title))
                return;

            HelperPL.PrintHeader(title, 7);

            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║ {"ID",-16} : {informationCustomer.CustomerID,-20}  ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║ {"Name",-16} : {string.Join(" ", informationCustomer.FirstName, informationCustomer.LastName),-20}  ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║ {"Email",-16} : {informationCustomer.Email,-20}  ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║ {"Phone",-16} : {informationCustomer.Phone,-20}  ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║ {"City",-16} : {informationCustomer.City,-20}  ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║ {"Registration",-16} : {informationCustomer.RegistrationDate,-20:dd/MM/yyyy}  ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║ {"Loyalty Points",-16} : {informationCustomer.LoyaltyPoints,-20}  ║");
            Console.WriteLine($"{HelperPL.GenarateTabs(7)}║ {"Status",-16} : {informationCustomer.Status,-20}  ║");

            Console.WriteLine($"{HelperPL.GenarateTabs(7)}╚══════════════════════════════════════════╝");
        }

        private static void _CustomersList()
        {
            Console.Clear();

            System.Console.WriteLine("\n\n");

            HelperPL.PrintHeader("📋 CUSTOMER LIST", 7);
            System.Console.WriteLine("\n\n\n");
            System.Console.WriteLine($"\t\t{"ID",-15} {"Name",-30} {"Email",-40} {"City",-15} {"Points",-10} {"Status",-15}");

            System.Console.WriteLine($"\t\t{new string('-', 123)}");
            List<CustomerDTO> L_ALlCustomers = CustomersBL.GetCustomersList().ToList();

            foreach (var Item_Customer in L_ALlCustomers)
                System.Console.WriteLine($"\t\t{Convert.ToInt32(Item_Customer.CustomerID),-15} {string.Join(" ", Item_Customer.FirstName, Item_Customer.LastName),-30} {Item_Customer.Email,-40} {Item_Customer.City,-15} {Convert.ToInt32(Item_Customer.LoyaltyPoints),-10} {Item_Customer.Status,-15}");
            System.Console.WriteLine($"\t\t{new string('-', 123)}\n\n");

            System.Console.WriteLine($"\t\tTotal Customers: {L_ALlCustomers.Count}\n\n");


        }

        private static string GetStatus(byte status)
        {
            switch (status)
            {
                case 0:
                    return "Inactive";
                case 1:
                    return "Active";
                case 2:
                    return "Blocked";

                default: return "";
            }
        }

        private static CustomerDTO? ReadInformationCustoemr()
        {
            string? firstName = HelperPL.ReadTheStringWithoutNumbers("First Name", 15, 7);
            string? lastName = HelperPL.ReadTheStringWithoutNumbers("Last Name", 15, 7);
            string? Email = HelperPL.ReadTheStringWithoutNumbers("Email", 15, 7);
            string? Phone = HelperPL.ReadTheStringWithNumbers<string>("Phone", 15, 7);
            string? City = HelperPL.ReadTheStringWithoutNumbers("City", 15, 7);

            byte status = 0;

            System.Console.Write($"{HelperPL.GenarateTabs(7)}Status (Active:1 , Inactive:0 , Blocked:2) : ");
            while (!byte.TryParse(Console.ReadLine(), out status))
                System.Console.Write($"{HelperPL.GenarateTabs(7)}Try Agian , Status (Active:1 , Inactive:0 , Blocked:2) : ");

            string StatusString = GetStatus(status);

            return new CustomerDTO(-1, firstName!, lastName!, Email!, Phone!, City!, DateTime.Now, (short)0, StatusString);

        }

        private static int ReadTheID()
        {
            Console.Clear();
            System.Console.WriteLine("\n\n\n");

            HelperPL.PrintHeader("🔎 GET CUSTOMER BY ID", 7);
            System.Console.WriteLine("\n\n");
            System.Console.Write($"{HelperPL.GenarateTabs(7)}Enter Customer ID: ");
            int ID = -1;
            while (!int.TryParse(Console.ReadLine(), out ID))
                System.Console.Write($"{HelperPL.GenarateTabs(7)}Invalid Data ID : ");

            System.Console.WriteLine("\n\n");


            return ID;
        }

        private static CustomersBL? GetCustomerByID()
        {

            System.Console.WriteLine("\n\n");
            CustomersBL customerInfo = CustomersBL.Find(ReadTheID())!;

            try
            {
                if (customerInfo is not null)
                    _PrintCustomerDetails(customerInfo, "👤 CUSTOMER DETAILS");
                else HelperPL.ShowNotFoundMessage($"Employee with ID {customerInfo?.CustomerID} was not found.", "❌ NOT FOUND", "Customer could not be found.");

            }
            catch (SqlException SEX)
            {
                HelperPL.ShowNotFoundMessage(SEX.Message, "❌ NOT FOUND", "Customer could not be found.");
            }

            return customerInfo;
        }

        private static void AddNewCustomer()
        {

            Console.Clear();
            System.Console.WriteLine("\n\n\n");
            HelperPL.PrintHeader("➕ ADD CUSTOMER", 7);

            try
            {
                CustomerDTO? customer = ReadInformationCustoemr();
                CustomersBL? customersBL = new CustomersBL();
                customersBL.ConvertDTOtoObject(customer!);

                if (customersBL!.SaveModeCustomer())
                {
                    _ShowSccessMessageAndShowInformationCustomer(customersBL, "✅ CUSTOMER ADDED");
                }


            }
            catch (SqlException SEX)
            {
                HelperPL.ShowNotFoundMessage(SEX.Message, "❌ CUSTOMER NOT ADDED", "Customer could not be added.");
            }

        }

        private static void _UpdateCustomer()
        {

            Console.Clear();

            try
            {
                CustomersBL infoCustomer = GetCustomerByID()!;
                System.Console.WriteLine("\n\n\n");
                HelperPL.PrintHeader("UPDATE CUSTOMER", 7);
                if (infoCustomer is not null)
                {
                    System.Console.WriteLine("\n\n");

                    CustomerDTO? customer = ReadInformationCustoemr();
                    infoCustomer.ConvertDTOtoObject(customer!);

                    if (infoCustomer!.SaveModeCustomer())
                    {
                        _ShowSccessMessageAndShowInformationCustomer(infoCustomer, "✅ CUSTOMER UPDATED");
                    }
                }

            }
            catch (SqlException SEX)
            {
                HelperPL.ShowNotFoundMessage(SEX.Message, "❌ CUSTOMER NOT UPDATED", "Customer could not be UPDATED.");
            }

        }

        private static void _DeleteCustomer()
        {

            Console.Clear();

            try
            {
                CustomersBL infoCustomer = GetCustomerByID()!;
                System.Console.WriteLine("\n\n\n");
                HelperPL.PrintHeader("🗑️  DELETE CUSTOMER", 7);

                if (infoCustomer is not null)
                {
                    System.Console.WriteLine("\n\n");

                    Console.Write($"{HelperPL.GenarateTabs(7)}Are you sure you want to delete this customer?\n");
                    Console.Write($"{HelperPL.GenarateTabs(7)}Y = Yes N = No  Choice: ");
                    char choice = 'n';

                    while (!char.TryParse(Console.ReadLine(), out choice) || char.ToLower(choice) is not ('y' or 'n'))

                        Console.Write($"{HelperPL.GenarateTabs(7)}Invalid Choive , pLease Enter valid choive -> Y = Yes N = No  Choice: ");

                    if (char.ToLower(choice) == 'y')
                    {
                        if (infoCustomer.DeleteCustomer())
                            _ShowSccessMessageAndShowInformationCustomer(infoCustomer, "✅ CUSTOMER DELETED");
                        else
                            HelperPL.ShowNotFoundMessage("❌ DELETE FAILED", "This customer cannot be deleted because\nthey have existing sales records.");
                    }
                    else
                        HelperPL.ShowNotFoundMessage("ℹ️  DELETE CANCELLED ", "No changes were made.");
                }

            }
            catch (SqlException SEX)
            {
                HelperPL.ShowNotFoundMessage(SEX.Message, "❌ CUSTOMER NOT UPDATED", "Customer could not be UPDATED.");
            }

        }

        // private static void _PrintMenuLoyaltyPoints()
        // {
        //     System.Console.WriteLine("\n\n\n");
        //     Console.Write($"{GenarateTabs(7)}╔══════════════════════════════════════════╗\n");
        //     Console.Write($"{GenarateTabs(7)}║            ⭐ LOYALTY POINTS             ║\n");
        //     Console.Write($"{GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
        //     Console.Write($"{GenarateTabs(7)}║                                          ║\n");
        //     Console.Write($"{GenarateTabs(7)}║  1. View Customer Points                 ║\n");
        //     Console.Write($"{GenarateTabs(7)}║  2. Add Points                           ║\n");
        //     Console.Write($"{GenarateTabs(7)}║  3. Redeem Points                        ║\n");
        //     Console.Write($"{GenarateTabs(7)}║  4. Top Loyalty Customers                ║\n");
        //     Console.Write($"{GenarateTabs(7)}║  5. Loyalty Statistics                   ║\n");
        //     Console.Write($"{GenarateTabs(7)}║                                          ║\n");
        //     Console.Write($"{GenarateTabs(7)}║  0. 🔙 Back                              ║\n");
        //     Console.Write($"{GenarateTabs(7)}╚══════════════════════════════════════════╝\n\n\n");


        // }

        // private static async Task ViewCustomerPointsAsync()
        // {
        //     try
        //     {
        //         int id = ReadTheID();
        //         System.Console.WriteLine("\n\n\n");

        //         HttpClient httpClient = new HttpClient();

        //         httpClient.BaseAddress =
        //             new Uri("http://localhost:5276/api/Customers/");

        //         var response = await httpClient.GetAsync($"LoyaltyPoints/{id}");


        //         if (response.IsSuccessStatusCode)
        //         {
        //             var jsonCustomer =
        //                 await response.Content.ReadFromJsonAsync<CustomerPointsDTO>();

        //             if (jsonCustomer is not null)
        //             {
        //                 Console.Write($"{GenarateTabs(7)}╔══════════════════════════════════════════╗\n");
        //                 Console.Write($"{GenarateTabs(7)}║             ⭐ CUSTOMER POINTS           ║\n");
        //                 Console.Write($"{GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
        //                 Console.Write($"{GenarateTabs(7)}║ Customer ID    : {jsonCustomer.CustomerID,-24}║\n");
        //                 Console.Write($"{GenarateTabs(7)}║ Customer Name  : {jsonCustomer.CustomerName,-24}║\n");
        //                 Console.Write($"{GenarateTabs(7)}║ Current Points : {jsonCustomer.CurrentPoints,-24}║\n");
        //                 Console.Write($"{GenarateTabs(7)}║ Loyalty Level  : {jsonCustomer.LoyaltyLevel,-24}║\n");
        //                 Console.Write($"{GenarateTabs(7)}╚══════════════════════════════════════════╝\n");
        //             }
        //         }
        //         else
        //         {


        //             if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        //             {
        //                 System.Console.Write($"{GenarateTabs(7)}");
        //                 Console.Write(await response.Content.ReadAsStringAsync());
        //             }
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         ShowNotFoundMessage("❌ NOT FOUND", ex.Message, "Customer could not be found.");
        //     }
        // }

        // private static async Task _AddPointsAsync()
        // {

        //     try
        //     {
        //         int ID = ReadTheID()!;

        //         if (ID > 0)
        //         {

        //             int pointsToAdd = 0;

        //             System.Console.WriteLine("\n\n");
        //             PrintHeader("⭐ ADD POINTS", 7);
        //             System.Console.WriteLine("\n\n");
        //             System.Console.Write($"{GenarateTabs(7)}Points To Add  : ");

        //             while (!int.TryParse(Console.ReadLine(), out pointsToAdd) || pointsToAdd <= 0)
        //                 System.Console.WriteLine($"{GenarateTabs(7)}Invalid Data Try Add valid points : ");

        //             HttpClient httpClient = new HttpClient();

        //             httpClient.BaseAddress = new Uri("http://localhost:5276/api/Customers/");

        //             var respone = await httpClient.PostAsync($"LoyaltyPoints/{ID}/{pointsToAdd}", null);

        //             if (respone.IsSuccessStatusCode)
        //             {
        //                 var content = await respone.Content.ReadFromJsonAsync<PointsTransactionResultDTO>();
        //                 System.Console.WriteLine("\n\n");
        //                 Console.Write($"{GenarateTabs(7)}╔══════════════════════════════════════════╗\n");
        //                 Console.Write($"{GenarateTabs(7)}║          ✅ POINTS ADDED                 ║\n");
        //                 Console.Write($"{GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
        //                 Console.Write($"{GenarateTabs(7)}║ Customer      : {content.CustomerName,-25}║\n");
        //                 Console.Write($"{GenarateTabs(7)}║ Previous      : {content.PreviousPoints,-25}║\n");
        //                 Console.Write($"{GenarateTabs(7)}║ Added         : {content.Points,-25}║\n");
        //                 Console.Write($"{GenarateTabs(7)}║ New Balance   : {content.NewBalance,-25}║\n");
        //                 Console.Write($"{GenarateTabs(7)}╚══════════════════════════════════════════╝\n");

        //                 return;

        //             }

        //             ShowNotFoundMessage("❌ POINTS DEDUCTED", $"{await respone.Content.ReadAsStringAsync()}");
        //         }
        //         else
        //             ShowNotFoundMessage("❌ NOT FOUND", "Customer could not be found.");
        //     }
        //     catch (Exception ex)
        //     {
        //         ShowNotFoundMessage("❌ NOT FOUND", ex.Message, "Customer could not be found.");
        //     }
        // }

        // private static async Task _RedeemPointsAsync()
        // {

        //     try
        //     {
        //         int ID = ReadTheID()!;

        //         if (ID > 0)
        //         {

        //             int pointsToAdd = 0;
        //             System.Console.WriteLine("\n\n");
        //             PrintHeader("🎁 REDEEM POINTS", 7);
        //             System.Console.WriteLine("\n\n");
        //             System.Console.Write($"{GenarateTabs(7)}Points To Redeem  : ");

        //             while (!int.TryParse(Console.ReadLine(), out pointsToAdd) || pointsToAdd <= 0)
        //                 System.Console.WriteLine($"{GenarateTabs(7)}Invalid Data Try Add valid points : ");

        //             HttpClient httpClient = new HttpClient();

        //             httpClient.BaseAddress = new Uri("http://localhost:5276/api/Customers/");

        //             var respone = await httpClient.PatchAsync($"LoyaltyPoints/{ID}/{pointsToAdd}", null);

        //             if (respone.IsSuccessStatusCode)
        //             {
        //                 var content = await respone.Content.ReadFromJsonAsync<PointsTransactionResultDTO>();

        //                 System.Console.WriteLine("\n\n");
        //                 Console.Write($"{GenarateTabs(7)}╔══════════════════════════════════════════╗\n");
        //                 Console.Write($"{GenarateTabs(7)}║            ✅ POINTS REDEEMED            ║\n");
        //                 Console.Write($"{GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
        //                 Console.Write($"{GenarateTabs(7)}║ Customer      : {content.CustomerName,-25}║\n");
        //                 Console.Write($"{GenarateTabs(7)}║ Previous      : {content.PreviousPoints,-25}║\n");
        //                 Console.Write($"{GenarateTabs(7)}║ Redeemed      : {content.Points,-25}║\n");
        //                 Console.Write($"{GenarateTabs(7)}║ New Balance   : {content.NewBalance,-25}║\n");
        //                 Console.Write($"{GenarateTabs(7)}╚══════════════════════════════════════════╝\n");

        //                 return;

        //             }

        //             ShowNotFoundMessage("❌ INSUFFICIENT POINTS", $"{await respone.Content.ReadAsStringAsync()}");
        //         }
        //         else
        //             ShowNotFoundMessage("❌ NOT FOUND", "Customer could not be found.");
        //     }
        //     catch (Exception ex)
        //     {
        //         ShowNotFoundMessage("❌ NOT FOUND", ex.Message, "Customer could not be found.");
        //     }
        // }

        // private static async Task _GetTopLoyaltyCustomersAsync()
        // {

        //     try
        //     {

        //         HttpClient httpClient = new HttpClient();

        //         httpClient.BaseAddress = new Uri("http://localhost:5276/api/Customers/LoyaltyPoints/");

        //         var respone = await httpClient.GetAsync("TopCustomers/");
        //         Console.Clear();

        //         PrintHeader("🏆 TOP LOYALTY CUSTOMERS", 7);
        //         if (respone.IsSuccessStatusCode)
        //         {
        //             var topLoyaltyCustomerPoints = await respone.Content.ReadFromJsonAsync<List<TopLoyaltyCustomerDTO>>();
        //             if (topLoyaltyCustomerPoints is not null)
        //             {
        //                 System.Console.WriteLine($"\n\n{GenarateTabs(6)}{"Rank",-15} {"Customer Name",-25} {"Points",-15} {"Level",-15}");
        //                 System.Console.WriteLine($"{GenarateTabs(6)}{new string('-', 70)}");


        //                 foreach (var item in topLoyaltyCustomerPoints)
        //                     System.Console.WriteLine($"{GenarateTabs(6)}{item.Rank,-15} {item.CustomerName,-25} {item.Points,-15} {item.Level,-15}");

        //                 System.Console.WriteLine($"{GenarateTabs(6)}{new string('-', 70)}");

        //             }

        //             return;
        //         }
        //         ShowNotFoundMessage("⚠️ NO DATA FOUND", $"{await respone.Content.ReadAsStringAsync()}");

        //     }
        //     catch (Exception ex)
        //     {
        //         ShowNotFoundMessage("❌ SYSTEM ERROR", ex.Message, "your request. Please try again.");
        //     }

        // }

        // private static async Task _GetLoyaltyStatisticsAsync()
        // {

        //     try
        //     {

        //         HttpClient httpClient = new HttpClient();

        //         httpClient.BaseAddress = new Uri("http://localhost:5276/api/Customers/LoyaltyPoints/");

        //         var respone = await httpClient.GetAsync("LoyaltyStatistics/");
        //         Console.Clear();
        //         System.Console.WriteLine("\n\n\n");
        //         PrintHeader("⭐ LOYALTY STATISTICS", 7);

        //         if (respone.IsSuccessStatusCode)
        //         {
        //             var loyaltyStatistics = await respone.Content.ReadFromJsonAsync<LoyaltyStatisticsDTO>();

        //             if (loyaltyStatistics is not null)
        //             {
        //                 Console.Write($"{GenarateTabs(7)}║ Total Loyalty Points : {loyaltyStatistics.TotalLoyaltyPoints,-18}║\n");
        //                 Console.Write($"{GenarateTabs(7)}║ Minimum Points       : {loyaltyStatistics.MinimumPoints,-18}║\n");
        //                 Console.Write($"{GenarateTabs(7)}║ Maximum Points       : {loyaltyStatistics.MaximumPoints,-18}║\n");
        //                 Console.Write($"{GenarateTabs(7)}║ Average Points       : {loyaltyStatistics.AveragePoints,-18:F2}║\n");
        //                 Console.Write($"{GenarateTabs(7)}║ Diamond Customers    : {loyaltyStatistics.DiamondCustomers,-18}║\n");
        //                 Console.Write($"{GenarateTabs(7)}║ Platinum Customers   : {loyaltyStatistics.PlatinumCustomers,-18}║\n");
        //                 Console.Write($"{GenarateTabs(7)}║ Gold Customers       : {loyaltyStatistics.GoldCustomers,-18}║\n");
        //                 Console.Write($"{GenarateTabs(7)}║ Silver Customers     : {loyaltyStatistics.SilverCustomers,-18}║\n");
        //                 Console.Write($"{GenarateTabs(7)}║ Bronze Customers     : {loyaltyStatistics.BronzeCustomers,-18}║\n");
        //                 Console.Write($"{GenarateTabs(7)}╚══════════════════════════════════════════╝\n");
        //             }

        //             return;
        //         }

        //         ShowNotFoundMessage("⚠️ NO DATA FOUND", $"{await respone.Content.ReadAsStringAsync()}");

        //     }
        //     catch (Exception ex)
        //     {
        //         ShowNotFoundMessage("❌ SYSTEM ERROR", ex.Message, "your request. Please try again.");
        //     }

        // }

        // private static async Task _StartUpLoyaltyPointsSection()
        // {
        //     while (true)
        //     {

        //         Console.Clear();
        //         _PrintMenuLoyaltyPoints();

        //         Console.Write($"{GenarateTabs(7)}Select: ");
        //         byte choice = 0;
        //         while (!byte.TryParse(Console.ReadLine(), out choice) || choice > 5)
        //             Console.Write($"{GenarateTabs(7)}Invalid Choive Select another choice : ");

        //         switch ((Enumerations.EnChoicesLoyaltyPoints)choice)
        //         {
        //             case Enumerations.EnChoicesLoyaltyPoints._kVIEW_CUSTOMER_POINTS:
        //                 {
        //                     await ViewCustomerPointsAsync();
        //                     break;
        //                 }

        //             case Enumerations.EnChoicesLoyaltyPoints._kBACK:
        //                 {
        //                     await StartUpCustomersModule();
        //                     break;
        //                 }

        //             case Enumerations.EnChoicesLoyaltyPoints._kADD_POINTS:
        //                 {
        //                     await _AddPointsAsync();
        //                     break;
        //                 }

        //             case Enumerations.EnChoicesLoyaltyPoints._kREDEEM_POINTS:
        //                 {
        //                     await _RedeemPointsAsync();
        //                     break;
        //                 }

        //             case Enumerations.EnChoicesLoyaltyPoints._kTOP_LOYALTY_CUSTOMERS:
        //                 {
        //                     await _GetTopLoyaltyCustomersAsync();
        //                     break;

        //                 }

        //             case Enumerations.EnChoicesLoyaltyPoints._kLOYALTY_STATISTICS :
        //                 {
        //                     await _GetLoyaltyStatisticsAsync();
        //                     break;
        //                 }
        //         }


        //         Console.WriteLine($"\n\n{GenarateTabs(7)}Press any key to continue...");
        //         Console.ReadKey();
        //     }
        // }

        public static async Task StartUpCustomersModule()
        {

            while (true)
            {
                Console.Clear();

                _MainMenuCustomersModule();

                Console.Write($"\n\n\n{HelperPL.GenarateTabs(7)}Select: ");
                byte ChoiceCustomer = 0;
                while (!byte.TryParse(Console.ReadLine(), out ChoiceCustomer) || ChoiceCustomer > 9)
                    System.Console.WriteLine("\t\tInvalid Choice Customer Menu ");

                switch ((Enumerations.EnChoicesCustomersModule)ChoiceCustomer)
                {
                    case Enumerations.EnChoicesCustomersModule._kLIST_CUSTOMERS:
                        {
                            _CustomersList();
                            break;

                        }
                    case Enumerations.EnChoicesCustomersModule._kGET_CUSTOMER_BY_ID:
                        {
                            GetCustomerByID();
                            break;
                        }

                    case Enumerations.EnChoicesCustomersModule._kADD_NEW_CUSTOMER:
                        {
                            AddNewCustomer();
                            break;
                        }

                    case Enumerations.EnChoicesCustomersModule._kUPDATE_INFORMATION_CUSTOMER:
                        {
                            _UpdateCustomer();
                            break;
                        }

                    case Enumerations.EnChoicesCustomersModule._kDELETE_CUSTOMER:
                        {
                            _DeleteCustomer();
                            break;
                        }

                    case Enumerations.EnChoicesCustomersModule._kLOYALTY_POINTS:
                        {
                            await Loyalty.StartUpLoyaltyPointsSection();
                            break;
                        }
                }


                Console.WriteLine($"\n{HelperPL.GenarateTabs(7)}Press any key to continue...");
                Console.ReadKey();
            }
        }


    }
}