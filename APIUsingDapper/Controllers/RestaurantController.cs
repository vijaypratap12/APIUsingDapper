using APIUsingDapper.DAL.Interfaces;
using APIUsingDapper.Models;
using Microsoft.AspNetCore.Mvc;

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
        /// Get Staff details 
        /// </summary>
        /// <param name="StaffId"></param>
        ///  <param name="StaffName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getStaffDetails")]
        public async Task<IActionResult> GetStaffDetails(int StaffId, string StaffName)
        {
            StaffDetails getStaffDetails = new StaffDetails();
            try
            {
                getStaffDetails = await _restaurant.GetStaffDetails(StaffId, StaffName);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(getStaffDetails);
        }
        /// <summary>
        /// This is to get customer details
        /// </summary>
        /// <param name="CustomerId"></param>
        ///  <param name="CustomerName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCustomerDetails")]
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
        /// get total payment done by customer
        /// </summary>
        /// <param name="PaymentId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("TotalPayment")]
        public async Task<IActionResult> GetTotalPayment(int PaymentId)
        {
            TotalPayment totalPayment = new TotalPayment();
            try
            {
                totalPayment = await _restaurant.GetTotalPayment(PaymentId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(totalPayment);
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
        public async Task<IActionResult> AddingCustomer(AddCustomer addCustomer)
        {
            int result;
            try
            {
                result = await _restaurant.AddingCustomer(addCustomer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        /// <summary>
        /// This is used to check whehther that particular food is available or not by foodId
        /// </summary>
        /// <param name="FoodId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("foodAvailability")]
        public async Task<IActionResult> CheckFoodAvailability(FoodAvailability foodAvailability)
        {
            int result;
            try
            {
                result = await _restaurant.CheckFoodAvailability(foodAvailability);
            }
            catch (Exception ex)
            {
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
        public async Task<IActionResult> DeletingCustomer(int CustomerId)
        {
            //DeleteCustomer deleteCustomer = new DeleteCustomer();
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

        [HttpDelete]
        [Route("DeleteStaff")]
        public async Task<IActionResult> DeletingStaff(int StaffId)
        {
            //DeleteCustomer deleteCustomer = new DeleteCustomer();
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


    }
}


