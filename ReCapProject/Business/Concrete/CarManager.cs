using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(x=>x.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(x => x.ColorId == id);
        }

        public void Update(Car car)
        {
            //Checks to be made in the Business Layer
            _carDal.Update(car);
        }
    }
}
