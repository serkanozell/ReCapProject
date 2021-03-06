using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Car added";
        public static string CarNameInvalid = "Car name invalid!!";
        public static string CarDeleted = "Car deleted";
        public static string CarUpdated = "Car updated";
        public static string BrandAdded = "Brand added";
        public static string BrandDeleted = "Brand deleted!!";
        public static string BrandUpdated = "Brand updated";
        public static string ColorAdded = "Color added";
        public static string ColorDeleted = "Color deleted!!";
        public static string ColorUpdated = "Color updated";
        public static string CarsListed = "Cars listed";
        public static string MaintenanceTime = "System is under maintenance!!";
        public static string BrandsListed = "Brands listed";
        public static string ColorsListed = "Color listed";
        public static string RentalAdded = "Rent added";
        public static string RentalDeleted = "Rent deleted";
        public static string RentalUpdated = "Rent updated";
        public static string RentalsListed = "Rents listed";
        public static string CustomerAdded = "Customer added";
        public static string CustomerDeleted = "Customer deleted";
        public static string CustomerUpdated = "Customer updated";
        public static string CustomersListed = "Customers listed";
        public static string UserAdded = "User added";
        public static string UserDeleted = "User deleted";
        public static string UserUpdated = "User updated";
        public static string UsersListed = "Users listed";
        public static string RentalFailed = "Rent failed";
        public static string ImageAdded = "Image added";
        public static string ImageDeleted = "Image deleted";
        public static string CarImageAddFailed = "Car image add failed";
        public static string AuthorizationDenied = "Authorization denied!!";
        public static string UserRegistered = "User registered";
        public static string UserNotFound = "User not found";
        public static string PasswordError = "Passwors error!!";
        public static string SuccessfulLogin = "Successful login";
        public static string UserAlreadyExists = "User already exist";
        public static string AccessTokenCreated = "Access token created";
    }
}