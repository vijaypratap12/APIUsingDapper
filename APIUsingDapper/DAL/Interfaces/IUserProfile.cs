using APIUsingDapper.Models;

namespace APIUsingDapper.DAL.Interfaces
{
    public interface IUserProfile
    {
        public Task<UserProfile> GetUserProfile(Int64 UserId);
    }
}
