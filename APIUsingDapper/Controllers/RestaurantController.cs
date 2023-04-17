using APIUsingDapper.DAL.Interfaces;
using APIUsingDapper.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg;

namespace APIUsingDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurant _restaurant;
        public RestaurantController(IRestaurant rest)
        {
            _restaurant = rest;
        }




        /// <summary>
        /// loginCustomer
        /// </summary>
        /// <param name="loginCustomer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("LoginCustomer")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginCustomer(LoginCustomer loginCustomer)
        {
            TokenModel tokenModel = new TokenModel();
            //string result;
            try
            {
                tokenModel = await _restaurant.LoginCustomer(loginCustomer);
            }
            catch (Exception ex)
            {
                //result = 0;
                return BadRequest(ex.Message);
            }
            return Ok(tokenModel);
        }


        /// <summary>
        /// Get Staff details 
        /// </summary>
        /// <param name="StaffId"></param>
        ///  <param name="StaffName"></param>
        /// <returns></returns>

        /// <summary>
        /// This is to get customer details
        /// </summary>
        /// <param name="CustomerId"></param>
        ///  <param name="CustomerName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCustomerDetails")]
        [Authorize]
        public async Task<IActionResult> GetCustomerDetails(int CustomerId, string CustomerName)
        {
            CustomerDetails CustomerObj = new CustomerDetails();
            try
            {
                CustomerObj = await _restaurant.GetCustomerDetails(CustomerId, CustomerName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(CustomerObj);
        }

       

      

        /// <summary>
        /// This is used to add customer
        /// </summary>
        /// <param name="CustomerName"></param>
        /// <param name="CustomerContact"></param>
        /// <param name="CustomerAddress"></param>
        /// <param name="StaffId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddCustomer")]
        [Authorize]
        public async Task<IActionResult> AddingCustomer(AddCustomer addCustomer)
        {
            int result ;
            try
            {
                result = await _restaurant.AddingCustomer(addCustomer);
                if (result == 1)
                {
                    return Ok("values are inserted");
                }
                else
                {
                   return BadRequest("went wrong");
                }
            }
            catch (Exception ex)
            {
                result = 0;
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }


        /// <summary>
        /// Delete any customer details 
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteCustomer")]
        [Authorize]
        public async Task<IActionResult> DeletingCustomer(int CustomerId)
        {            
            string result;
            try
            {
               result = await _restaurant.DeletingCustomer(CustomerId);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           return Ok(result);
        }


        /// <summary>
        /// Delete staff from restaurant
        /// </summary>
        /// <param name="StaffId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteStaff")]
        [Authorize]
        public async Task<IActionResult> DeletingStaff(int StaffId)
        {
            
            string result;
            try
            {
                result = await _restaurant.DeletingStaff(StaffId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }



        /// <summary>
        /// all customer details are here
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("AllCustomerDetails")]
        [Authorize]
        public async Task<IActionResult> GetAllCustomerDetails()
        {
            IEnumerable<AllCustomerDetails> allCustomerDetails = null;
            try
            {
                allCustomerDetails = await _restaurant.GetAllCustomerDetails();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(allCustomerDetails);
        }

        

        [HttpGet]
        [Route("AllFoodList")]
        [Authorize]
        public async Task<IActionResult> GetAllFood()
        {
            IEnumerable<FoodList> foodlist = null;
            try
            {
                foodlist = await _restaurant.GetAllFood();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(foodlist);
        }

        [HttpPost]
        [Route("AddStaff")]
        [Authorize]
        public async Task<IActionResult> AddingStaff(AddStaff addStaff)
        {
            int result;
            try
            {
                result = await _restaurant.AddingStaff(addStaff);
                if (result == 1)
                {
                    return Ok("values are inserted");
                }
                else
                {
                    return BadRequest("went wrong");
                }
            }
            catch (Exception ex)
            {
                result = 0;
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }



        [HttpGet]
        [Route("AllStaffList")]
        [Authorize]
        public async Task<IActionResult> GetStaffLists()
        {
            IEnumerable<AllStaffList> stafflist = null;
            try
            {
                stafflist = await _restaurant.GetStaffLists();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(stafflist);
        
        
        }

        [HttpGet]
        [Route("GetFeedbackList")]
        [Authorize]
        public async Task<IActionResult> GetFeedbackList()
        {
            IEnumerable<FeedbackList> feedbackList = null;
            try
            {
                feedbackList = await _restaurant.GetFeedbackList();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(feedbackList);
        }

        [HttpPost]
        [Route("AddingFeedback")]
        [Authorize]
        public async Task <IActionResult> AddingFeedback( AddFeedback addFeedback)
        {
            int result;
            try
            {
                result = await _restaurant.AddingFeedback(addFeedback);
                if (result == 1)
                {
                    return Ok("values are inserted");
                }
                else
                {
                    return BadRequest("went wrong");
                }
            }
            catch (Exception ex)
            {
                result = 0;
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateCustomer")]
        [Authorize]
        public async Task<IActionResult> UpdatingFeedback(UpdateFeedback updateFeedback)
        {
            int result;
            try
            {
                result = await _restaurant.UpdatingFeedback(updateFeedback);
                if (result == 1)
                {
                    return Ok("values are updated");
                }
                else
                {
                    return BadRequest("something went wrong");
                }
            }
            catch (Exception ex)
            {
                result = 0;
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }


      

    }

}


