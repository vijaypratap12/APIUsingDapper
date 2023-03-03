using APIUsingDapper.DAL.Interfaces;
using APIUsingDapper.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace APIUsingDapper.DAL
{
    public class UserProfileRepo : IUserProfile
    {
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        public UserProfileRepo(IConfiguration configuration)
        {
            _config = configuration;
            _connectionString = _config.GetConnectionString("ConString");
        }
        public async Task<UserProfile> GetUserProfile(long UserId)
        {
            UserProfile profile = new UserProfile();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "[GetUserProfile]";
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
