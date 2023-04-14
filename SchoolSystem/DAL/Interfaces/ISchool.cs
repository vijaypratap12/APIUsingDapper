using SMS.Models;

namespace APIUsingDapper.DAL.Interfaces
{
    public interface ISchool
    {
       
        public Task<SchoolModel> GetStudent(int StudentId);
        public Task<string> AddNewStudent(AddStudentModel addStudentModel);
        public Task<string> DeleteNewStudent(int StudentId);
        public Task<string> AddNewTeacher(AddTeacherModel addteacherModel);
        public Task<GetTeacherModel> GetTeacher(int TeacherId);
        public Task<string> DeleteTeacher(int TeacherId);
        public Task<GetCourseModel> GetCourse(int CourseId);
        public Task<string> AddNewCourse(AddCourseModel addCourseModel);

    }
}
