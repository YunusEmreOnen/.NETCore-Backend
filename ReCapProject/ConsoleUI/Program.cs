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
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car {BrandId = 3, ColorId = 4, DailyPrice = 1800000, ModelYear = 2019, Description_ = "MUSTANG" });


            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine(item);
            }
            

        }
    }
}