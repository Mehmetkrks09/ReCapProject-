using Core.Utilities.Result;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstracts
{
  public  interface ICarImageService
    {

        IDataResult<List<CarImage>> GetByCarId(int id);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> Get(int carImageid);
        IResult Add(IFormFile file, CarImage carImage);
        IResult Update(IFormFile carImages, CarImage carImage);
        IResult Delete(CarImage carImage);
    }
}
