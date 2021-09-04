using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (CarRentContext context = new CarRentContext())
            {
                var result = from cu in context.Customers
                             join u in context.Users
                             on cu.CustomerId equals u.UserId
                             join r in context.Rentals
                             on cu.CustomerId equals r.CustomerId
                             select new CustomerDetailDto
                             {
                                 UserId = u.UserId,
                                 CompanyName = cu.CompanyName,
                                 CustomerId = cu.CustomerId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}