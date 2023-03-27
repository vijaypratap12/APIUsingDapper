using APIUsingDapper.DAL.Interfaces;
using APIUsingDapper.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;

namespace APIUsingDapper.DAL
{
    public class RestaurantRepo : IRestaurant
    {
        private readonly IConfiguration _config;
        private readonly string _connectionString;

        public RestaurantRepo(IConfiguration configuration)
        {
            _config = configuration;
            _connectionString = _config.GetConnectionString("ConString");
        }

        public async Task<StaffDetails> GetStaffDetails(int StaffId, string StaffName)
        {
            StaffDetails getStaffDetails = new StaffDetails();
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var procedure = "GetStaffDetails";
                    var values = new
                    {
                        StaffId = StaffId,
                        StaffName = StaffName

                    };
                    getStaffDetails = await connection.QueryFirstAsync<StaffDetails>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return getStaffDetails;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CustomerDetails> GetCustomerDetails(int CustomerId, string CustomerName)
        {
            CustomerDetails CustomerObj = new CustomerDetails();
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var procedure = "GetCustomerDetails";
                    var values = new
                    {
                        CustomerId = CustomerId,
                        CustomerName = CustomerName

                    };
                    CustomerObj = await connection.QueryFirstAsync<CustomerDetails>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return CustomerObj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<TotalPayment> GetTotalPayment(int PaymentId)
        {
            TotalPayment totalPayment = new TotalPayment();
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var procedure = "GetTotalPayment";
                    var values = new
                    {
                        PaymentId = PaymentId
                    };
                    totalPayment = await connection.QueryFirstAsync<TotalPayment>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return totalPayment;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<int> AddingCustomer(AddCustomer addCustomer)
        {
            int result;

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var procedure = "AddCustomer";
                    var values = new
                    {

                        CustomerName = addCustomer.CustomerName,
                        CustomerContact = addCustomer.CustomerContact,
                        CustomerAddress = addCustomer.CustomerAddress,
                        StaffId = addCustomer.StaffId,
                    };
                    result = await connection.QueryFirstAsync<int>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return result;
            }

            catch (Exception ex)
            {
                return 0;

            }
        }
   
        public async Task<int> CheckFoodAvailability(FoodAvailability foodAvailability)
        {
            int result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var procedure = "FoodAvailbility";
                    var values = new
                    {
                        FoodId = foodAvailability.FoodId
                    };
                    result = await connection.QueryFirstAsync<int>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<string> DeletingCustomer(int CustomerId)
        {
            string result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var procedure = "DeleteCustomer";
                    var values = new
                    {
                        CustomerId = CustomerId
                    };
                    result = await connection.QueryFirstAsync<string>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> DeletingStaff(int StaffId)
        {
            string result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var procedure = "DeleteStaff";
                    var values = new
                    {
                        StaffId = StaffId
                    };
                    result = await connection.QueryFirstAsync<string>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
