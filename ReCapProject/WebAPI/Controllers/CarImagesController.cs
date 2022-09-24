using Business.Abstract;
using Core.Entities;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _imageService;
        public CarImagesController(ICarImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _imageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }

        [HttpPost("add")]
        public IActionResult Add(IFormFile file, CarImage carImage)
        {
            var result = _imageService.Add(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _imageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(IFormFile file, CarImage carImage)
        {
            var result = _imageService.Update(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getcarimagebycarid")]
        public ActionResult GetCarImagesByCarId(int carId)
        {
            var result = _imageService.GetCarImagesByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return Ok(result);
            
        }
    }
}
