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
            
            carManager.Add(new Car {BrandId=3,ColorId=3,DailyPrice=180000,ModelYear=2015,Description_= "FİESTA"});

            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description_);
            }


        }
    }
}