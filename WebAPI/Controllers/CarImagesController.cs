using Business.Abstracts;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }


        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycarid")]
        public IActionResult GetByCarId([FromForm(Name = "carId")] int carId)
        {
            var result = _carImageService.GetByCarId(carId);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]

        public IActionResult Add([FromForm(Name = "Image")] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(file, carImage);
            if (result.Succes)
            {
                return Ok(result);
            }
            Console.WriteLine("Hatalı bişeyler oldu");
            return BadRequest(result);
           
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("carImageId"))] int carId)
        {

            var deleteCarImageByCarId = _carImageService.Get(carId).Data;
            var result = _carImageService.Delete(deleteCarImageByCarId);

            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("updateimage")]

        public IActionResult Update([FromForm(Name = "Image")] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Update(file, carImage);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

    }
}
