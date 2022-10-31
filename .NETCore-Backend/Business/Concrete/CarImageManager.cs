using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Storage;
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
        public IResult Add(IFormFile file, int carId)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageOfLimitExceed(carId));
            if (result == null)
            {
                var fileStorageResult = FileStorageHelper.Upload(file, "wwwroot\\Uploads\\Images\\");
                if (fileStorageResult.Success)
                {
                    CarImage carImage = new CarImage()
                    {
                        CarId = carId,
                        ImagePath = fileStorageResult.Data.FilePath,
                        Date_ = fileStorageResult.Data.FileLoadTime
                    };

                    _carImagedal.Add(carImage);
                    return new SuccessResult();
                }
                return new ErrorResult(fileStorageResult.Message);
            }
            return result;

            

        }

        public IResult Delete(CarImage carImage)
        {
            var result = FileStorageHelper.Delete(carImage.ImagePath);
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

        public IResult Update(IFormFile file, string imagePath)
        {
            var carImage = _carImagedal.Get(i=>i.ImagePath==imagePath);
            if(carImage!=null)
            {
                var storageResult = FileStorageHelper.Update(file, imagePath);
                
                carImage.Date_ = storageResult.Data.FileLoadTime;
                _carImagedal.Update(carImage);
                return new SuccessResult();
            }
            return new ErrorResult();
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

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int carId)
        {
            
            var result = _carImagedal.GetAll(i => i.CarId == carId);
            if (result.Count!=0)
            {
                return new SuccessDataResult<List<CarImage>>(result);
            }
            else
            {
                List<CarImage> imageList = new List<CarImage>();
                CarImage carImage=new CarImage()
                {
                    CarId = carId,
                    ImagePath = "defaultImage.jpeg",
                    Date_ = DateTime.Now
                };
                imageList.Add(carImage);
                return new SuccessDataResult<List<CarImage>>(imageList, Messages.GetDefaultCarImage);
            }
          

        }

    }
}
