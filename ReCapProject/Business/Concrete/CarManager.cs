using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            //Checks to be made in the Business Layer
            if(car.Description_.Length<=1)
            {
                throw new Exception("Araba modeli en az 2 harf içermelidir.");
            }
            else if (car.DailyPrice<=0)
            {
                throw new Exception("Arabanın fiyatı 0 dan büyük olmalıdır.");
            }
            else
            {
                _carDal.Add(car);
            }
            
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public void Delete(Car car)
        {
            //Checks to be made in the Business Layer
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            //Checks to be made in the Business Layer
            return _carDal.GetAll();
        }

        public Car GetById(int CarId)
        {
            return _carDal.Get(x => x.Id == CarId);
        }

        public List<Car> GetCarsByBrandId(int BrandId)
        {
            return _carDal.GetAll(x=>x.BrandId == BrandId);
        }

        public List<Car> GetCarsByColorId(int ColorId)
        {
            return _carDal.GetAll(x => x.ColorId == ColorId);
        }

        public void Update(Car car)
        {
            //Checks to be made in the Business Layer
            _carDal.Update(car);
        }
    }
}
