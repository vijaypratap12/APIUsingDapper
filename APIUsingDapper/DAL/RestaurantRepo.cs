using APIUsingDapper.DAL.Interfaces;
using APIUsingDapper.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Core.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
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

       
        public async Task<int> AddingCustomer(AddCustomer addCustomer)
        {
            int result=0;

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var procedure = "AddCustomer";
                    var values = new
                    {

                        CustomerName = addCustomer.CustomerName,
                        CustomerContact = addCustomer.CustomerContact,
                        CustomerAddress = addCustomer.CustomerAddress
                        
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
        public async Task<IEnumerable<AllCustomerDetails>> GetAllCustomerDetails()
        {
           
            IEnumerable<AllCustomerDetails> allCustomerDetails = null;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var procedure = "AllCustomer";
                   
                    allCustomerDetails = await connection.QueryAsync<AllCustomerDetails>(procedure, null, commandType: CommandType.StoredProcedure);
                }
                return allCustomerDetails.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<FoodList>> GetAllFood()
        {

            IEnumerable<FoodList> foodlist = null;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var procedure = "ViewAllFood";

                    foodlist = await connection.QueryAsync<FoodList>(procedure, null, commandType: CommandType.StoredProcedure);
                }
                return foodlist.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> AddingStaff(AddStaff addStaff)
        {         
                int result = 0;

                try
                {
                    using (var connection = new MySqlConnection(_connectionString))
                    {
                        var procedure = "AddStaff";
                        var values = new
                        {

                            StaffName = addStaff.StaffName,
                            StaffContact = addStaff.StaffContact,
                            StaffCategory = addStaff.StaffCategory,
                            StaffAddress = addStaff.StaffAddress,
                            
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

        public async Task<IEnumerable<AllStaffList>> GetStaffLists()
        {
            IEnumerable<AllStaffList> stafflist = null;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var procedure = "AllStaff";

                    stafflist = await connection.QueryAsync<AllStaffList>(procedure, null, commandType: CommandType.StoredProcedure);
                }
                return stafflist.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<FeedbackList>> GetFeedbackList()
        {
            IEnumerable<FeedbackList> feedbackList = null;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var procedure = "AllFeedback";

                    feedbackList = await connection.QueryAsync<FeedbackList>(procedure, null, commandType: CommandType.StoredProcedure);
                }
                return feedbackList.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }


    


       
  
}



