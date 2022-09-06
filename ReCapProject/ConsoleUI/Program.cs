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

            var result=carManager.Add(new Car {BrandId = 4, ColorId = 5, DailyPrice = 0, ModelYear = 2019, Description_ = "HYBRİD" });
            
            if(result.Success)
            {
                
                foreach (var item in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
            

        }
    }
}