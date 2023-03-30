using APIUsingDapper.DAL.Interfaces;
using APIUsingDapper.Models;
using Dapper;
using MySqlConnector;
using System.Data;

namespace APIUsingDapper.DAL
{
    public class UserProfileRepo : IUserProfile
    {
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        public UserProfileRepo(IConfiguration configuration)
        {
            _config = configuration;
            _connectionString = _config.GetConnectionString("ConString1");
        }
        public async Task<UserProfile> GetUserProfile(long UserId)
        {
            UserProfile profile = new UserProfile();
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

                    profile = await connection.QueryFirstAsync<UserProfile>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return profile;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
