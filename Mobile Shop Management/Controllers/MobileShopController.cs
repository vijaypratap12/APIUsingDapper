using APIUsingDapper.Models;
using Microsoft.AspNetCore.Mvc;
using Mobile_Shop_Management.DAL.Interface;
using Mobile_Shop_Management.Models;

namespace Mobile_Shop_Management.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class MobileShopController : ControllerBase
    {

        private readonly IMobileShop _user;
        public MobileShopController(IMobileShop UserObj) {

            _user = UserObj;

        }

        /// <summary>
        /// add New User Or Admin with details 
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>


        [HttpPost]
        [Route("AddUserOrAdmin")]
        public async Task<IActionResult> AddUserOrAdmin(AddNewUserOrAdminModel userModel)
        {
            string result;
            try
            {
                result = await _user.AddUserOrAdmin(userModel);
                if (result==null)
                {
                    return BadRequest(result);
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        /// <summary>
        /// Get Customer Details By CustomerId
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCustomerDetailbyId")]
        public async Task<IActionResult> GetCustomerDetailbyId(int CustomerId)
        {
            GetCustomerModel customerModel = new GetCustomerModel();

                try
                {
                customerModel = await _user.GetCustomerDetailbyId(CustomerId);

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                return Ok(customerModel);
           
        }

        /// <summary>
        /// add address of Customer with Customer Id 
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>


        [HttpPost]
        [Route("AddAddressOfCustomerbyId")]
        public async Task<IActionResult> AddAddressOfCustomerbyId(AddressModel address)
        {
            string result;
            try
            {
                result = await _user.AddAddressOfCustomerbyId(address);
                if (result==null)
                {
                    return BadRequest(result);
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get Employee Details By UserId
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllUser")]
        public async Task<IActionResult> GetAllUser(int UserId)
        {

            GetAllUserModel user = new GetAllUserModel();
                try
                {
                    user = await _user.GetAllUser(UserId);
                
                 }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                return Ok(user);
         }


        /// <summary>
        /// add Size and Price by ProductId
        /// </summary>
        /// <param name="sizeprice"></param>
        /// <returns></returns>


        [HttpPost]
        [Route("AddSicePricebypId")]
        public async Task<IActionResult> AddSicePricebypId(AddSizePricebypid sizeprice)
        {
            string result;
            try
            {
                result = await _user.AddSicePricebypId(sizeprice);
                if (result == null)
                {
                    return BadRequest(result);
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        /// <summary>
        /// This end point for delete user or admin by thier Id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        /// 
        [HttpDelete]
        [Route("DeleteUserById")]
        public async Task<IActionResult> DeleteUserById(int UserId)
        {
            string result;
            try
            {
                result = await _user.DeleteUserById(UserId);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }



        /// <summary>
        /// add New Products with details 
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>


        [HttpPost]
        [Route("AddNewProduct")]
        public async Task<IActionResult> AddNewProduct(AddProductModel product)
        {
            string result;
            try
            {
                result = await _user.AddNewProduct(product);
                if (result == null)
                {
                    return BadRequest(result);
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        /// <summary>
        /// Get Product  Details By ProductId
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetProductDetailbyId")]
        public async Task<IActionResult> GetProductDetailbyId(int ProductId)
        {

            GetProductDetailModel user = new GetProductDetailModel();
            try
            {
                user = await _user.GetProductDetailbyId(ProductId);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(user);
        }


        /// <summary>
        /// add color and Quantity of  Products by Id 
        /// </summary>
        /// <param name="colorsize"></param>
        /// <returns></returns>


        [HttpPost]
        [Route("AddColoQuantitybypId")]
        public async Task<IActionResult> AddColoQuantitybypId(AddColorQuantitybypId colorsize)
        {
            string result;
            try
            {
                result = await _user.AddColoQuantitybypId(colorsize);
                if (result == null)
                {
                    return BadRequest(result);
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Updates the User or Admin Using by Id
        /// </summary>
        /// <param name="adduser"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateUserOrAdmin")]
        public async Task<IActionResult> UpdateUserOrAdmin(GetAllUserModel adduser)
        {
            string result;
            try
            {
                result = await _user.UpdateUserOrAdmin(adduser);
                if (result == null)
                {
                    return BadRequest(result);
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        /// <summary>
        /// add New Customer with details 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddNewCustomer")]
        public async Task<IActionResult> AddNewCustomer(CustomerModel addcustomer)
        {

            string result;
            try
            {
                result = await _user.AddNewCustomer(addcustomer);
                if (result == null)
                {
                    return BadRequest(result);
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
