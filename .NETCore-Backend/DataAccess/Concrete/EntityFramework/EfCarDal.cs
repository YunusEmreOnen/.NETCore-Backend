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
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentCarDbContext context = new RentCarDbContext())
            {
                var resault = from p in context.Cars
                              join b in context.Brands
                              on p.BrandId equals b.Id
                              join c in context.Colors on p.ColorId equals c.Id
                              select new CarDetailDto
                              {
                                  CarId = p.Id,
                                  BrandName = b.BrandName,
                                  ColorName = c.ColorName,
                                  DailyPrice = p.DailyPrice,
                                  ModelYear = p.ModelYear,
                                  Description = p.Description_
                              };

                return resault.ToList();
            }

            
        }
    }
}
