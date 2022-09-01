using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2010,DailyPrice=250000,Description_="Duster" },
                new Car{Id=2,BrandId=2,ColorId=3,ModelYear=2013,DailyPrice=307777,Description_="Clio" },
                new Car{Id=3,BrandId=3,ColorId=2,ModelYear=2019,DailyPrice=410000,Description_="SUV 3008" },
                new Car{Id=4,BrandId=3,ColorId=1,ModelYear=2020,DailyPrice=810499,Description_="SUV 5008" }
            };

            _brands = new List<Brand>()
            {
                new Brand{Id=1,BrandName="Dacia"},
                new Brand{Id=2,BrandName="Renault"},
                new Brand{Id=3,BrandName="Peugeot"},
                new Brand{Id=4,BrandName="Ford"},

            };

            _colors = new List<Color>()
            {
                new Color{Id=1,ColorName="White"},
                new Color{Id=2,ColorName="Black"},
                new Color{Id=3,ColorName="Red"},
                new Color{Id=4,ColorName="Blue"}
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

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDto> GetAll()
        {
            var resault = from p in _cars
                          join b in _brands
                        on p.BrandId equals b.Id
                          join c in _colors on p.ColorId equals c.Id
                          select new CarDto{ CarId = p.Id, BrandName = b.BrandName,ColorName=c.ColorName,DailyPrice=p.DailyPrice,
                          ModelYear=p.ModelYear,Description=p.Description_};


           return resault.ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>>? filter = null)
        {
            throw new NotImplementedException();
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
            carToUpdate.Description_ = car.Description_;
        }
        
    }
}
