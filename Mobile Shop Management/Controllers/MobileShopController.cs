using Microsoft.AspNetCore.Authorization;
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
        public MobileShopController(IMobileShop UserObj)
        {

            _user = UserObj;

        }

        /// <summary>
        ///Login User
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>

        [HttpPost]
        [AllowAnonymous]
        [Route("LoginUserOrAdmin")]

        public async Task<IActionResult> LoginUserOrAdmin(LoginUser loginUser)
        {
            TokenModel tokenModel = new TokenModel();   
            try
            {
                tokenModel = await _user.LoginUserOrAdmin(loginUser);
                if (tokenModel == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(tokenModel);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// add New User Or Admin with details 
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>


        [HttpPost]
        [Route("AddNewProduct")]
        [Authorize]
        public async Task<IActionResult> AddUserOrAdmin(AddNewUserOrAdminModel userModel)
        {
            string result;
            try
            {
                result = await _user.AddUserOrAdmin(userModel);
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
        /// add to cart with details 
        /// </summary>
        /// <param name="addToCart"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("AddToCart")]
        [Authorize]
        public async Task<IActionResult> AddToCart(AddToCart addToCart)
        {
            string result;
            try
            {
                result = await _user.AddToCart(addToCart);
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
        /// Get Customer Details By CustomerId
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCustomerDetailbyId")]
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> AddAddressOfCustomerbyId(AddressModel address)
        {
            string result;
            try
            {
                result = await _user.AddAddressOfCustomerbyId(address);
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
        /// Get Employee Details By UserId
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllUser")]
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        /// This end point for delete Customer by thier Id
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        /// 
        [HttpDelete]
        [Route("DeleteCustomerById")]
        [Authorize]
        public async Task<IActionResult> DeleteCustomerById(int CustomerId)
        {
            int result;
            try
            {
                result = await _user.DeleteCustomerById(CustomerId);

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
        [Route("AddUserOrAdmin")]
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> UpdateUsersOrAdmin(GetAllUsersModel adduser)
        {
            string result;
            try
            {
                result = await _user.UpdateUsersOrAdmin(adduser);
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
        [Authorize]
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


        /// <summary>
        /// Get all Employee Details 
        /// </summary>
        /// <param name="*"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllUsers")]
        [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {

            IEnumerable<GetAllUserModel> user = null;
            try
            {
                user = await _user.GetAllUsers();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(user);
        }

        /// <summary>
        /// Get all Customers Details 
        /// </summary>
        /// <param name="*"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllCustomers")]
        [Authorize]
        public async Task<IActionResult> GetAllCustomers()
        {

            IEnumerable<GetCustomerModel> user = null;
            try
            {
                user = await _user.GetAllCustomers();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(user);
        }

    }
}
