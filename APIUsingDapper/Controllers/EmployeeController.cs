using APIUsingDapper.DAL.Interfaces;
using APIUsingDapper.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Relational;

namespace APIUsingDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
            private readonly IEmployee _user;
            public EmployeeController(IEmployee user)
            {
                _user = user;
            }

        /// <summary>
        /// Get Employee Details By UserId
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpGet]

            public async Task<IActionResult> GetEmployee(long userId)
            {
                EmployeeModel user = new EmployeeModel();
                try
                {
                    user = await _user.GetEmployee(userId);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                return Ok(user);
            }

        /// <summary>
        /// add Employee details for new user
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeModeladd employeeModel1)
        {
            int result=0;
            try
            {
                result = await _user.AddEmployee(employeeModel1);
                if (result == 0)
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

