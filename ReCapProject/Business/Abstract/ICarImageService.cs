using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<string>> GetCarImagesByCarId(int carId);
        IResult Add(IFormFile file,CarImage carImage);
        IResult Update(IFormFile file,CarImage CarImage);
        IResult Delete(CarImage image);
        IResult GetById(int id);

    }
}
