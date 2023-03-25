using APIUsingDapper.Models;
using Mobile_Shop_Management.Models;

namespace Mobile_Shop_Management.DAL.Interface
{
    public interface IMobileShop
    {
        public Task<string> AddUserOrAdmin(AddNewUserOrAdminModel adduser);
        public Task<GetAllUserModel> GetAllUser(int UserId);
        public Task<String>DeleteUserById(int UserId);
        public Task<string> UpdateUserOrAdmin(GetAllUserModel adduser);
        public Task<string> AddNewCustomer(CustomerModel addcustomer);
        public Task<string> AddAddressOfCustomerbyId(AddressModel address);
        public Task<GetCustomerModel> GetCustomerDetailbyId(int CustomerId);
        public Task<string> AddNewProduct(AddProductModel product);
        public Task<string> AddColoQuantitybypId(AddColorQuantitybypId colorsize);
        public Task<string> AddSicePricebypId(AddSizePricebypid sizeprice);
        public Task<GetProductDetailModel> GetProductDetailbyId(int ProductId);
    }
}
