using APIUsingDapper.Models;
using DnsClient;

namespace APIUsingDapper.DAL.Interfaces
{
    public interface IRestaurant
    {        
        public Task<CustomerDetails> GetCustomerDetails(int CustomerId, string CustomerName);       
        public Task<int> AddingCustomer(AddCustomer addCustomer);       
        public Task<string> DeletingCustomer(int CustomerId);
        public Task <string> DeletingStaff (int StaffId);      
        public Task<IEnumerable<AllCustomerDetails>?> GetAllCustomerDetails();
        public Task<IEnumerable<FoodList>?> GetAllFood();
        public Task<int> AddingStaff(AddStaff addStaff);
        public Task<IEnumerable<AllStaffList>> GetStaffLists();
        public Task<IEnumerable<FeedbackList>> GetFeedbackList();
        public Task<int> AddingFeedback (AddFeedback addFeedback);
        public Task<int> UpdatingFeedback(UpdateFeedback updateFeedback);
        //public Task<int> LoginCustomer(LoginCustomer loginCustomer);
        public Task<TokenModel> LoginCustomer(LoginCustomer loginCustomer);


    }
}
