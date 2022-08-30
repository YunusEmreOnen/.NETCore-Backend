using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            
            carManager.Add(new Car { CarId = 5, BrandId = 4, ColorId = 3, DailyPrice = 200000, ModelYear = 2010,Description= "FOCUS" });
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------");
            
            Console.WriteLine(carManager.GetById(3).Description);
            Console.WriteLine("--------------");

            carManager.Update(new Car { CarId = 5, BrandId = 4, ColorId = 3, DailyPrice = 1000000, ModelYear = 2020, Description = "Fiesta" });
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------");
           
            carManager.Delete(new Car { CarId = 5, BrandId = 4 });
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------");


        }
    }
}