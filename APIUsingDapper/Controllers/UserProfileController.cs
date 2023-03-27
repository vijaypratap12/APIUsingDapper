using APIUsingDapper.DAL.Interfaces;
using APIUsingDapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIUsingDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfile _user;
        public UserProfileController(IUserProfile user)
        {
            _user = user;
        }
        [HttpGet]
        public async Task<IActionResult> GetUserProfile(Int64 userId)
        {
            UserProfile user = new UserProfile();
            try
            {
                user = await _user.GetUserProfile(userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(user);
        }
    }
}
