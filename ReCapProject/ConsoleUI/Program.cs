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
            
            carManager.Add(new Car { Id = 5, BrandId = 4, ColorId = 3, DailyPrice = 200000, ModelYear = 2010,Description= "FOCUS" });
            foreach (Car item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);
            }
            Console.WriteLine("--------------");
            
            Console.WriteLine(carManager.GetById(3).Description);
            Console.WriteLine("--------------");

            carManager.Update(new Car { Id = 5, BrandId = 4, ColorId = 3, DailyPrice = 1000000, ModelYear = 2020, Description = "Tesla" });
            foreach (Car item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);
            }
            Console.WriteLine("--------------");
           
            carManager.Delete(new Car { Id = 5, BrandId = 4 });
            foreach (Car item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);
            }
            Console.WriteLine("--------------");


        }
    }
}