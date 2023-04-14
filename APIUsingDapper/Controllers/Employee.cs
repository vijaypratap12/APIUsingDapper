using APIUsingDapper.DAL.Interfaces;
using APIUsingDapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIUsingDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employee : ControllerBase
    {
        private readonly IEmployee employee;
        public Employee(IEmployee employee)
        {

            this.employee = employee;   

        }
        /// <summary>
        /// This method is used to get employee based on user id.
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetEmployeeByUserId")]
        public IActionResult GetEmployeeData(int UserId)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            try
            {
                employeeModel = employee.GetEmployee(UserId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(employeeModel);

        }
        /// <summary>
        /// This method is used for adding new employee
        /// </summary>
        /// <param name="addEmployee"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddNewEmployee")]
        public async Task<IActionResult> AddEmployee(AddEmployee addEmployee)
        {
            Int32 result=0;
            try
            {
                result = await employee.AddEmployee(addEmployee);
                if (result == 1)
                {
                    return Ok("Values are inserted");
                }
                else
                {
                    return BadRequest("Something went wrong");
                }
            }
            catch(Exception ex)
            {
                result = 0;
                return BadRequest(result);
            }
        }
    }
}
