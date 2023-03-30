using APIUsingDapper.DAL.Interfaces;
using APIUsingDapper.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace APIUsingDapper.DAL
{
    public class EmployeeRepo : IEmployee
    {
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        public EmployeeRepo(IConfiguration configuration)
        {
            _config = configuration;
            _connectionString = _config.GetConnectionString("ConString");
        }



        public async Task<EmployeeModel> GetEmployee(long UserId)
        {
            EmployeeModel profile = new EmployeeModel();
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "GetEmployeeData";
                    var values = new
                    {
                        UserId = UserId
                    };

                    profile = await connection.QueryFirstAsync<EmployeeModel>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return profile;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<int> AddEmployee(EmployeeModeladd e)
        {
            //EmployeeModel employee1 = new EmployeeModel();
            int result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "AddEmployee";
                    var values = new
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        UserName = e.UserName,
                        Email = e.Email,
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



        //public async Task<EmployeeModel> GetEmployee(long UserId)
        //{
        //    EmployeeModel employee = new EmployeeModel();
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //    return employee;    
        //}
    }
}
