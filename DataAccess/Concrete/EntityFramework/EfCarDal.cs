using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentContext context = new CarRentContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands 
                             on c.BrandId equals b.Id
                             join co in context.Colors 
                             on c.ColorId equals co.Id
                             
                             select new CarDetailDto
                             {
                                 
                                 CarName = c.CarName,
                                 ColorName =co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 BrandName = b.BrandName,
                                 ModelYear = c.ModelYear
                                 
                                 
                             };
                //var result = from c in context.Cars
                //             join co in context.Colors
                //             on c.ColorId equals co.ColorId
                //             join b in context.Brands
                //             on c.BrandId equals b.BrandId
                //             select new CarDetailDto
                //             {
                //                 CarName = c.CarName,
                //                 ColorName = co.ColorName,
                //                 BrandName = b.BrandName,
                //                 DailyPrice = c.DailyPrice

                //             };
                //var abc = result;
                return result.ToList();
            }
        }
    }
}
