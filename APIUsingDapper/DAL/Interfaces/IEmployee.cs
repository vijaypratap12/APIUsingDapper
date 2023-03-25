using APIUsingDapper.Models;

namespace APIUsingDapper.DAL.Interfaces
{
    public interface IEmployee
    {
        public Task<EmployeeModel> GetEmployee(Int64 UserId);
        public Task<int> AddEmployee(EmployeeModeladd employeemodeladd);
    }
}
