using APIUsingDapper.Models;

namespace APIUsingDapper.DAL.Interfaces
{
    public interface IRestaurant
    {
        public Task<StaffDetails> GetStaffDetails(int StaffId, string StaffName);
        public Task<CustomerDetails> GetCustomerDetails(int CustomerId, string CustomerName);
        public Task<TotalPayment> GetTotalPayment(int PaymentId);
        public Task<int> AddingCustomer(AddCustomer addCustomer);
        public  Task<int> CheckFoodAvailability(FoodAvailability foodAvailability);
        public Task<string> DeletingCustomer(int CustomerId);
        public Task <string> DeletingStaff (int StaffId);

    }
}
