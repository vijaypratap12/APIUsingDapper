using APIUsingDapper.Models;

namespace APIUsingDapper.DAL.Interfaces
{
    public interface IEmployee
    {
        public EmployeeModel GetEmployee(int UserId);
        public Task<Int32> AddEmployee(AddEmployee addEmployee);
    }
}
