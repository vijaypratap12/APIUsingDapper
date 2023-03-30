using MongoDB.Bson.Serialization.IdGenerators;
using System.Globalization;

namespace APIUsingDapper.Models
{
   
    public class CustomerDetails
    {
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
    }
   
    public class AddCustomer
    {
        public string? CustomerName { get; set; }
        public string? CustomerContact { get; set; }
        public string? CustomerAddress { get; set; }
        
    }
   
    public class DeleteCustomer
    {
        public int CustomerId { get; set; }
    }
    public class DeleteStaff 
    { 
        public int StaffId { get; set; }
    }
    public class AllCustomerDetails
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }    
        public string CustomerContact { get; set; }
        public string CustomerAddress { get; set; }
        
    }

    public class FoodList
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string FoodPrice { get; set; }
        public string StaffId { get; set; }
    }
    public class AddStaff
    {
        public string? StaffName { get; set; }
        public string? StaffContact { get; set; }
        public string StaffCategory { get; set; }
        public string? StaffAddress { get; set; }
    }

    public class AllStaffList
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string StaffCategory { get; set; }
        public string StaffContact { get; set; }
        public string StaffAddress { get; set; }
    }

    public class FeedbackList
    {
        public int FeedbaackId { get; set; }
        public int? CustomerId { get; set; }
        public string? FoodName { get; set; }
        public string? Messages { get; set; }
    }

    public class AddFeedback
    {
        public int CustomerId { get; set; }
        public string FoodName { get; set; }
        public string Messages { get; set; }
    }
}

