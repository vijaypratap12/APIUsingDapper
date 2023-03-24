using APIUsingDapper.Controllers;
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
        /// <summary>
        /// This method is used to add employee
        /// </summary>
        /// <param name="addEmployee"></param>
        /// <returns></returns>

        public async Task<Int32> AddEmployee(AddEmployee addEmployee)
        {
            Int32 result = 0;
            try
            {
                using(var connection = new MySqlConnection(_connectionString))
                {
                    var procedure = "AddEmployee";
                    var values = new
                    {
                        FirstName = addEmployee.FirstName,
                        LastName = addEmployee.LastName,
                        UserName = addEmployee.UserName,
                        Email = addEmployee.Email
                    };
                    result = connection.QueryFirst<Int32>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return result;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// This method is get all the employee.
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public EmployeeModel GetEmployee(int UserId)
        {
            EmployeeModel employee = new EmployeeModel();
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

                    employee = connection.QueryFirst<EmployeeModel>(procedure, values, commandType: CommandType.StoredProcedure);
                }
            }

            catch (Exception ex)
            {
                return null;
            }
            return employee;
        }
    }
}
