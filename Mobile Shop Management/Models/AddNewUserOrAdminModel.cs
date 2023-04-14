namespace Mobile_Shop_Management.Models
{
    public class AddNewUserOrAdminModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? UserType { get; set; }
        public string? Passwords { get; set; }
    }

    public class GetAllUserModel
    {
        public int? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? UserType { get; set; }
        public string? Passwords { get; set; }
        public DateTime? RegisterDate { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }

    }

    public class GetAllUsersModel
    {
        public int? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? UserType { get; set; }
        public string? Passwords { get; set; }
        //public DateTime? RegisterDate { get; set; }
        public int IsActive { get; set; }
        // public int IsDeleted { get; set; }

    }
    public class CustomerModel
    {

        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerMobileNumber { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }


    }

    public class GetCustomerModel
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerMobileNumber { get; set; }
        public string CustomerRegisterDate { get; set; }
        public string? Gender { get; set; }


    }

    public class AddressModel
    {


        public string? Address { get; set; }
        public int CustomerId { get; set; }
        public int IsSelected { get; set; }
    }


    public class AddProductModel
    {

        public string? ProductName { get; set; }
        public int? ProductQuantity { get; set; }
        public string? ProductCategory { get; set; }
        public string? ProductCompanyName { get; set; }
    }

    public class AddColorQuantitybypId
    {
        public string? ColorName { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductId { get; set; }
    }


    public class AddSizePricebypid
    {
        public string? ProductSize { get; set; }
        public int? ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductId { get; set; }
    }

    public class GetProductDetailModel
    {

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public DateTime ProductAddDate { get; set; }
        public string? ProductCategory { get; set; }
        public string? ProductCompanyName { get; set; }
        public string? ColorName { get; set; }
        public string? ProductSize { get; set; }
        public int ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
    }

    public class AddToCart
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public string? ProductSize { get; set; }

    }
    public class LoginUser
    {
        public int UserId { get; set; }
        public string? Passwords { get; set; }
        public string Email { get; set; }
    }
    public class TokenModel
    {
        public string token { get; set; }
        public int UserId { get; set; }
        public DateTime expiry { get; set; }
    }
}
