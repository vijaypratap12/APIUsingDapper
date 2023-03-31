using APIUsingDapper.DAL.Interfaces;
using Dapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using SMS.Models;
using System.Data;
using System.Xml.Linq;

namespace APIUsingDapper.DAL
{
    public class SchoolRepo :ISchool
    {
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        public SchoolRepo(IConfiguration configuration) { 

            _config = configuration;
            _connectionString = _config.GetConnectionString("ConString");
        }

        public async Task<string> AddNewStudent(AddStudentModel addStudentModel)
        {
            string result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "AddNewStudent";
                    var values = new
                    {
                        
                        StudentName=addStudentModel.StudentName,
                        Age=addStudentModel.Age,
                        MobileNumber = addStudentModel.MobileNumber
                    };

                    result = await connection.QueryFirstAsync<string>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> AddNewTeacher(AddTeacherModel addteacherModel)
        {
            string result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "AddNewTeacher";
                    var values = new
                    {

                        name= addteacherModel.name,
                        age=addteacherModel.age,
                        department=addteacherModel.department,
                    };
                    result = await connection.QueryFirstAsync<string>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<string> DeleteNewStudent(int StudentId)
        {
            string profile;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "deletestudent";
                    var values = new
                    {
                        StudentId = StudentId
                    };

                    profile = await connection.QueryFirstAsync<string>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return profile;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<SchoolModel> GetStudent(int StudentId)
        {
            SchoolModel profile = new SchoolModel();
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "studentinfobyid";
                    var values = new
                    {
                       StudentId = StudentId
                    };

                    profile = await connection.QueryFirstAsync<SchoolModel>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return profile;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<GetTeacherModel> GetTeacher(int TeacherId)
        {
            GetTeacherModel profile = new GetTeacherModel();
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "teacherinfobyid";
                    var values = new
                    {
                        TeacherId = TeacherId
                    };

                    profile = await connection.QueryFirstAsync<GetTeacherModel>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return profile;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<string> DeleteTeacher(int TeacherId)
        {
            string profile;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "Removeteacher";
                    var values = new
                    {
                        TeacherId = TeacherId
                    };

                    profile = await connection.QueryFirstAsync<string>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return profile;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<GetCourseModel> GetCourse(int CourseId)
        {
            GetCourseModel profile = new GetCourseModel();
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "courseinfobyid";
                    var values = new
                    {
                        CourseId = CourseId
                    };

                    profile = await connection.QueryFirstAsync<GetCourseModel>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return profile;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<string> AddNewCourse(AddCourseModel addCourseModel)
        {
            string result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "AddNewCourse";
                    var values = new
                    {

                        name = addCourseModel.name,
                        university= addCourseModel.university,
                    };
                    result = await connection.QueryFirstAsync<string>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
