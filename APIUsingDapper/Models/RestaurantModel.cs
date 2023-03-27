namespace APIUsingDapper.Models
{
    public class StaffDetails
    {
        public int? StaffId { get; set; }
        public string? StaffName { get; set; }
    }
    public class CustomerDetails
    {
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
    }
    public class TotalPayment
    {
        public int PaymentId { get; set; }
    }
    public class AddCustomer
    {
        public string? CustomerName { get; set; }
        public string? CustomerContact { get; set; }
        public string? CustomerAddress { get; set; }
        public int StaffId { get; set; }
    }
    public class FoodAvailability
    {
        public int FoodId { get; set; }     
    }
    public class DeleteCustomer
    {
        public int CustomerId { get; set; }
    }
    public class DeleteStaff 
    { 
        public int StaffId { get; set; }
    }
}
