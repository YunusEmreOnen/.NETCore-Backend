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
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            //Checks to be made in the Business Layer
            _carDal.Delete(car);
        }

        public List<CarDto> GetAll()
        {
            //Checks to be made in the Business Layer
            return _carDal.GetAll();
        }

        public Car GetById(int Id)
        {
            //Checks to be made in the Business Layer
            return _carDal.GetById(Id);
        }

        public void Update(Car car)
        {
            //Checks to be made in the Business Layer
            _carDal.Update(car);
        }
    }
}
