using SMS.Models;
using Microsoft.AspNetCore.Mvc;
using APIUsingDapper.DAL.Interfaces;

namespace APIUsingDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchool _user;
        public SchoolController(ISchool school)
        { 
        _user = school;
        }

        /// <summary>
        ///  Add new student
        /// </summary>
        /// <param name="addStudentModel"></param>
        /// <returns></returns>
        
        [HttpPost]
        [Route("AddNewStudent")]

        public async Task<IActionResult> AddNewStudent(AddStudentModel addStudentModel)
        {
            string user;
            try
            {
                user = await _user.AddNewStudent(addStudentModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(user);
        }

        /// <summary>
        /// Get Student Details By StudentId
        /// </summary>
        /// <param name="StudentId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetStudent")]

        public async Task<IActionResult> GetStudent(int StudentId)
        {
            SchoolModel user = new SchoolModel();
            try
            {
                user = await _user.GetStudent(StudentId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(user);
        }

        /// <summary>
        /// Delete Student Details By StudentId
        /// </summary>
        /// <param name="StudentId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteNewStudent")]

        public async Task<IActionResult> DeleteNewStudent(int StudentId)
        {
            string user;
            try
            {
                user = await _user.DeleteNewStudent(StudentId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(user);
        }
        
            /// <summary>
            ///  Add new teacher
            /// </summary>
            /// <param name="addTeacherModel"></param>
            /// <returns></returns>

        [HttpPost]
        [Route("AddNewTeacher")]
        public async Task<IActionResult> AddNewTeacher(AddTeacherModel addteacherModel)
        {
            string user;
            try
            {
                user = await _user.AddNewTeacher(addteacherModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(user);
        }
        /// <summary>
        /// Get Teacher Details By TeacherId
        /// </summary>
        /// <param name="TeacherId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTeacher")]
        public async Task<IActionResult> GetTeacher(int TeacherId)
        {
            GetTeacherModel user = new GetTeacherModel();
            try
            {
                user = await _user.GetTeacher(TeacherId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(user);
        }
        /// <summary>
        /// Delete Teacher Details By Id
        /// </summary>
        /// <param name="TeacherId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteTeacher")]
        public async Task<IActionResult> DeleteTeacher(int TeacherId)
        {
            string user;
            try
            {
                user = await _user.DeleteTeacher(TeacherId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(user);
        }
        /// <summary>
        /// Get Course Details By CourseId
        /// </summary>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCourse")]
        public async Task<IActionResult> GetCourse(int CourseId)
        {
            GetCourseModel user = new GetCourseModel();
            try
            {
                user = await _user.GetCourse(CourseId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(user);
        }
        /// <summary>
        ///  Add new Course
        /// </summary>
        /// <param name="addCourseModel"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("AddNewCourse")]
        public async Task<IActionResult> AddNewCourse(AddCourseModel addCourseModel)
        {
            string user;
            try
            {
                user = await _user.AddNewCourse(addCourseModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(user);
        }
    }
}
