using APIUsingDapper.Models;
using Dapper;
using Mobile_Shop_Management.DAL.Interface;
using Mobile_Shop_Management.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Reflection;

namespace Mobile_Shop_Management.DAL
{
    public class MobileShopRepo :IMobileShop
    {
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        public MobileShopRepo(IConfiguration configuration) { 
            _config = configuration;
            _connectionString = _config.GetConnectionString("ConString");
        }

        public async Task<string> AddAddressOfCustomerbyId(AddressModel address)
        {
            string result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "AddAddressOfCustomerbyId";
                    var values = new
                    {
                        Address=address.Address,
                        CustomerId=address.CustomerId,
                        IsSelected=address.IsSelected,

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

        public async Task<string> AddColoQuantitybypId(AddColorQuantitybypId colorsize)
        {
            string result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "AddColorOrQuantityByPId";
                    var values = new
                    {
                        ColorName=colorsize.ColorName,
                        ProductQuantity=colorsize.ProductQuantity,
                        ProductId=colorsize.ProductId,

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

        public async Task<string> AddNewCustomer(CustomerModel addcustomer)
        {
            string result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "AddNewCustomer";
                    var values = new
                    {
                        CustomerName = addcustomer.CustomerName,
                        CustomerEmail = addcustomer.CustomerEmail,
                        CustomerMobileNumber = addcustomer.CustomerMobileNumber,
                        Gender = addcustomer.Gender,

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

        public async Task<string> AddNewProduct(AddProductModel product)
        {
            string result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "AddNewProduct";
                    var values = new
                    {
                        ProductName=product.ProductName,
                        ProductQuantity=product.ProductQuantity,
                        ProductCategory=product.ProductCategory,
                        ProductCompanyName = product.ProductCompanyName
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

        public async Task<string> AddSicePricebypId(AddSizePricebypid sizeprice)
        {
            string result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "AddSizePriceByPID";
                    var values = new
                    {
                        ProductSize=sizeprice.ProductSize,
                        ProductPrice=sizeprice.ProductPrice,
                        ProductQuantity=sizeprice.ProductQuantity,
                        ProductId=sizeprice.ProductId,
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

        public async Task<string> AddUserOrAdmin(AddNewUserOrAdminModel adduser)
        {

            string result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "AddNewEmployeeOrAdmin";
                    var values = new
                    {
                        FirstName = adduser.FirstName,
                        LastName = adduser.LastName,
                        Address = adduser.Address,
                        PhoneNumber = adduser.PhoneNumber,
                        Email = adduser.Email,
                        UserType = adduser.UserType,
                        Passwords = adduser.Passwords
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

        public async Task<string> DeleteUserById(int UserId)
        {
            string result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "RemoveUserById";
                    var values = new
                    {
                        UserId = UserId
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

        /// <inheritdoc/>


        public async Task<GetAllUserModel> GetAllUser(int UserId)
        {
            GetAllUserModel user = new GetAllUserModel();
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "ShowAllUserAdmin";
                    var values = new
                    {
                        UserId=UserId
                    };

                    user = await connection.QueryFirstAsync<GetAllUserModel>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<GetCustomerModel> GetCustomerDetailbyId(int CustomerId)
        {
            GetCustomerModel customerModel = new GetCustomerModel();
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "GetEmployeeDetailById";
                    var values = new
                    {
                        CustomerId = CustomerId
                    };

                    customerModel = await connection.QueryFirstAsync<GetCustomerModel>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return customerModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<GetProductDetailModel> GetProductDetailbyId(int ProductId)
        {
            GetProductDetailModel customerModel = new GetProductDetailModel();
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "ShowProductDetailsbyPId";
                    var values = new
                    {
                        ProductId = ProductId
                    };

                    customerModel = await connection.QueryFirstAsync<GetProductDetailModel>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return customerModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> UpdateUserOrAdmin(GetAllUserModel adduser)
        {
            string result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "UpdateEmployeeOrAdmin";
                    var values = new
                    {
                        UserId=adduser.UserId,
                        FirstName = adduser.FirstName,
                        LastName = adduser.LastName,
                        Address = adduser.Address,
                        PhoneNumber = adduser.PhoneNumber,
                        Email = adduser.Email,
                        UserType = adduser.UserType,
                        Passwords = adduser.Passwords,
                        RegisterDate= adduser.RegisterDate,
                        IsActive= adduser.IsActive,
                        IsDeleted= adduser.IsDeleted,
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
    

