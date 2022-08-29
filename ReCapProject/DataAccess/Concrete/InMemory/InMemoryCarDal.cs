using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        //InMemory Cars object
        List<Car> _cars;

        //InMemory Cars Constructor Method
        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2010,DailyPrice=250000,Description="DUSTER" },
                new Car{Id=2,BrandId=2,ColorId=3,ModelYear=2013,DailyPrice=307777,Description="CLİO" },
                new Car{Id=3,BrandId=3,ColorId=2,ModelYear=2019,DailyPrice=410000,Description="SUV 3008" },
                new Car{Id=4,BrandId=3,ColorId=1,ModelYear=2020,DailyPrice=810499,Description="SUV 5008" }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete;
            carToDelete = _cars.FirstOrDefault(x => x.Id == car.Id);
            _cars.Remove(carToDelete);
            
        }

        public List<Car> GetAll()
        {
           return _cars;
        }

        public Car GetById(int Id)
        {
            return _cars.FirstOrDefault(x=>x.Id==Id);
        }

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate = _cars.FirstOrDefault(x => x.Id == car.Id);

            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
        
    }
}
