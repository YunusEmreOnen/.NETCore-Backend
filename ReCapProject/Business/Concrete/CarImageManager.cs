using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileService;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImagedal;
        public CarImageManager(ICarImageDal imagedal)
        {
            _carImagedal = imagedal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageOfLimitExceed(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            var storageServiceResult = StorageService.Upload(file, @"D:\Kodlama.ioReCapProject\ReCapProject\WebAPI\Content\Images\");
            if (storageServiceResult.Success)
            {
                carImage.ImagePath = storageServiceResult.Data.FilePath;
                carImage.Date_ = storageServiceResult.Data.FileLoadTime;
                _carImagedal.Add(carImage);
                return new SuccessResult();
            }
            return new ErrorResult();

        }

        public IResult Delete(CarImage carImage)
        {
            var result = StorageService.Delete(carImage.ImagePath);
            if (result.Success)
            {
                _carImagedal.Delete(carImage);
                return new SuccessResult();
            }
            return new ErrorResult();

        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImagedal.GetAll());
        }

        public IResult GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImagedal.Get(x => x.Id == id));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            var result = StorageService.Update(file, carImage.ImagePath);
            _carImagedal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckIfCarImageOfLimitExceed(int carId)
        {
            var result = _carImagedal.GetAll(ı => ı.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImagelimitExceeded);
            }
            return new SuccessResult();
        }

        public IDataResult<List<string>> GetCarImagesByCarId(int carId)
        {
            List<string> carPaths;
            var result = _carImagedal.GetAll(i => i.CarId == carId);
            if (result != null)
            {
                carPaths = new List<string>();
                foreach (CarImage carImage in result)
                {
                    carPaths.Add(carImage.ImagePath);
                }
                return new SuccessDataResult<List<string>>(carPaths);
            }
            carPaths = new List<string>();
            carPaths.Add(@"D:\Kodlama.ioReCapProject\ReCapProject\WebAPI\Content\Images\defaultImage.jpg");
            return new ErrorDataResult<List<string>>(carPaths,Messages.GetDefaultCarImage);

        }

    }
}
