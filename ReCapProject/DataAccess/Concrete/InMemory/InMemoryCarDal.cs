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
        //InMemory Cars,Colors,Blanks objects
        List<Car> _cars;
        List<Brand> _brands;
        List<Color> _colors;

        //InMemory Cars Constructor Method
        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car{CarId=1,BrandId=1,ColorId=1,ModelYear=2010,DailyPrice=250000,Description="Duster" },
                new Car{CarId=2,BrandId=2,ColorId=3,ModelYear=2013,DailyPrice=307777,Description="Clio" },
                new Car{CarId=3,BrandId=3,ColorId=2,ModelYear=2019,DailyPrice=410000,Description="SUV 3008" },
                new Car{CarId=4,BrandId=3,ColorId=1,ModelYear=2020,DailyPrice=810499,Description="SUV 5008" }
            };

            _brands = new List<Brand>()
            {
                new Brand{BrandId=1,BrandName="Dacia"},
                new Brand{BrandId=2,BrandName="Renault"},
                new Brand{BrandId=3,BrandName="Peugeot"},
                new Brand{BrandId=4,BrandName="Ford"},

            };

            _colors = new List<Color>()
            {
                new Color{ColorId=1,ColorName="White"},
                new Color{ColorId=2,ColorName="Black"},
                new Color{ColorId=3,ColorName="Red"},
                new Color{ColorId=4,ColorName="Blue"}
            };

        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete;
            carToDelete = _cars.FirstOrDefault(x => x.CarId == car.CarId);
            _cars.Remove(carToDelete);
            
        }

        public List<CarDto> GetAll()
        {
            var resault = from p in _cars
                          join b in _brands
                        on p.BrandId equals b.BrandId
                          join c in _colors on p.ColorId equals c.ColorId
                          select new CarDto{ CarId = p.CarId, BrandName = b.BrandName,ColorName=c.ColorName,DailyPrice=p.DailyPrice,
                          ModelYear=p.ModelYear,Description=p.Description};


           return resault.ToList();
        }

        public Car GetById(int Id)
        {
            return _cars.FirstOrDefault(x=>x.CarId==Id);
        }

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate = _cars.FirstOrDefault(x => x.CarId == car.CarId);

            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
        
    }
}
