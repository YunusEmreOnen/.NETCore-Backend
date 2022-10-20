using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new EfCarDal());

            //var result = carManager.Add(new Car { BrandId = 5, ColorId = 5, DailyPrice = 1111111, ModelYear = 2019, Description_ = "HYBRİD" });

            //if (result.Success)
            //{

            //    foreach (var item in carManager.GetCarDetails().Data)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}

            RentalManager rentaManager = new RentalManager(new EfRentalDal());

            var result1 = rentaManager.Add(new Rental { CarId = 2, CustomerId = 3, RentDate = new DateTime(2021, 12, 1) });
            Console.WriteLine(result1.Message);
            
            var result2 = rentaManager.Add(new Rental { CarId = 2, CustomerId = 3, RentDate = new DateTime(2021, 12, 1) });
            Console.WriteLine(result2.Message);

        }
    }
}