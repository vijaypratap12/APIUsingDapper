namespace SMS.Models
{
    public class SchoolModel
    {
        public int StudentId { get; set; }
         public string StudentName { get; set; }
        public int Age { get; set; }    
        public string MobileNumber { get; set; }
    }
    public class AddStudentModel
    {
        public string StudentName { get; set; }
        public int Age { get; set; }
        public string MobileNumber { get; set; }
    }

    public class AddTeacherModel
    {
        
        public string name{ get; set; }
        public int age { get; set; }
        public string department { get; set; }
    }
    public class GetTeacherModel
    {

        public string name { get; set; }
        public int age { get; set; }
        public string department { get; set; }
    }
    public class GetCourseModel
    {
        public int courseid { get; set; }
        public string name { get; set; }
        public string university { get; set; }
    }
    public class AddCourseModel
    {
        public string name { get; set; }
        public string university { get; set; }
    }


}
