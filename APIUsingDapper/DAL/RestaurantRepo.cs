using APIUsingDapper.DAL.Interfaces;
using APIUsingDapper.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver.Core.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;

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

        public async Task<string> DeletingStaff(int staffId)
        {
            string result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var procedure = "DeleteStaff";
                    var values = new
                    {
                        StaffId = staffId
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

        public async Task<int> AddingFeedback(AddFeedback addFeedback)
        {
            int result = 0;
            try
            {
                using(var connection = new MySqlConnection(_connectionString)) 
                {
                    var procedure = "AddFeedback";
                    var values = new
                    {
                        CustomerId = addFeedback.CustomerId,
                        FoodName = addFeedback.FoodName,
                        Messages = addFeedback.Messages,
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

        public async Task<int> UpdatingFeedback(UpdateFeedback updateFeedback)
        {
            int result = 0;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var procedure = "ch";
                    var values = new
                    {                       
                        CustomerAddress = updateFeedback.CustomerAddress,
                    };
                    result= await
                        connection.QueryFirstAsync<int>(procedure,values, commandType: CommandType.StoredProcedure);
                }
                return result;
            }
            catch (Exception ex) 
            { 
                return 0;
            }
        }
        //public async Task<int> LoginCustomer(LoginCustomer loginCustomer)
        //{
        //    int result = 0;
        //    try
        //    {
        //        using (var connection = new MySqlConnection(_connectionString))
        //        {
        //            var procedure = "LoginCustomer";
        //            var values = new
        //            {
        //                CustomerId = loginCustomer.CustomerId,
        //                CustomerName = loginCustomer.CustomerName,
        //            };
        //            result = await connection.QueryFirstAsync<int>(procedure, values, commandType: CommandType.StoredProcedure);
        //        }
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return 0;
        //    }
        //}

        /// <summary>
        /// logIN for customer
        /// </summary>
        /// <param name="loginCustomer"></param>
        /// <returns></returns>
        public async Task<TokenModel> LoginCustomer(LoginCustomer loginCustomer)
        {
            TokenModel tokenModel = new TokenModel();
            string result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var procedure = "LoginCustomer";
                    var values = new
                    {
                        CustomerId = loginCustomer.CustomerId,
                        CustomerName = loginCustomer.CustomerName
                    };
                    result = await connection.QueryFirstAsync<string>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                if (result != null)
                {
                    //var tokenHandler = new JwtSecurityTokenHandler();
                    //var securitykey = Encoding.ASCII.GetBytes("MadhuPatelMCN");
                    //var tokenDescriptor = new SecurityTokenDescriptor
                    //{
                    //    Subject = new ClaimsIdentity(new Claim[]
                    //{
                    //     new Claim(ClaimTypes.PrimarySid, loginCustomer.CustomerId.ToString()),
                    //     //new Claim(ClaimTypes.CustomerName, loginCustomer.CustomerName)
                    //}),
                    //    Expires = DateTime.UtcNow.AddMinutes(20),
                    //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(securitykey), SecurityAlgorithms.HmacSha256Signature)};
                    //var token = tokenHandler.CreateToken(tokenDescriptor);        
                    //tokenModel.token = new JwtSecurityTokenHandler().WriteToken(token);
                    //tokenModel.expiry = DateTime.Now.AddMinutes(20);
                    //tokenModel.CustomerId = loginCustomer.CustomerId;
                    ////tokenModel.CustomerName = loginCustomer.CustomerName;
                   
                    var claims = new[]
                    {
                         new Claim (ClaimTypes.PrimarySid, loginCustomer.CustomerId.ToString()),
                         new Claim (ClaimTypes.Name, loginCustomer.CustomerName.ToString()),
                     };
                    string k = _config["Jwt:key"];
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature); 
                    var token = new JwtSecurityToken(
                    _config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(20),
                    signingCredentials: signIn);                     // Generating token string

                    var jwtToken = new JwtSecurityTokenHandler().WriteToken(token); 

                    tokenModel.token = jwtToken; 
                    tokenModel.CustomerId = loginCustomer.CustomerId;
                    tokenModel.CustomerName = loginCustomer.CustomerName;
                    tokenModel.expires = token.ValidTo; 
                    return tokenModel;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }

    }
      
  
}



