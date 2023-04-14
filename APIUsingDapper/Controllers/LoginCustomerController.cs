using APIUsingDapper.DAL.Interfaces;
using APIUsingDapper.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIUsingDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginCustomerController : ControllerBase
    {

        private readonly IRestaurant _restaurant;
        public LoginCustomerController(IRestaurant rest)
        {
            _restaurant = rest;
        }

        ///// <summary>
        ///// loginCustomer
        ///// </summary>
        ///// <param name="loginCustomer"></param>
        ///// <returns></returns>
        //[HttpPost]
        //[Route("LoginCustomer")]
        //[AllowAnonymous]
        //public async Task<IActionResult> LoginCustomer(LoginCustomer loginCustomer)
        //{
        //    TokenModel tokenModel = new TokenModel();
        //    //string result;
        //    try
        //    {
        //        tokenModel = await _restaurant.LoginCustomer(loginCustomer);
        //    }
        //    catch (Exception ex)
        //    {
        //        //result = 0;
        //        return BadRequest(ex.Message);
        //    }
        //    return Ok(tokenModel);
        //}
    }
}
