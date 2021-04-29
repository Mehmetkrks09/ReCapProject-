using Business.Abstracts;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Helpers;
using Core.Utilities.Result;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDAL;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDAL, IFileHelper fileHelper)
        {
            _carImageDAL = carImageDAL;
            _fileHelper = fileHelper;
        }

        //[ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            var imageCount = _carImageDAL.GetAll(c => c.CarId == carImage.CarId).Count;

            if (imageCount >= 5)
            {
                return new ErrorResult("One car must have 5 or less images");
            }

            var imageResult = _fileHelper.Upload(file);

            if (!imageResult.Succes)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = imageResult.Message;
            _carImageDAL.Add(carImage);
            return new SuccesResult(Messages.CarImageAdded);
        }

        //[ValidationAspect(typeof(CarImageValidator))]Sonradan ekle
        public IDataResult<CarImage> Get(int id)
        {
            return new SuccesDataResult<CarImage>(_carImageDAL.Get(c => c.Id == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccesDataResult<List<CarImage>>(_carImageDAL.GetAll());
        }


        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(id));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }

            return new SuccesDataResult<List<CarImage>>(CheckIfCarImageNull(id).Data);
        }

        public IResult Delete(CarImage carImage)
        {
            var image = _carImageDAL.Get(c => c.Id == carImage.Id);
            if (image == null)
            {
                return new ErrorResult("Image not found");
            }
            _fileHelper.Delete(image.ImagePath);
            _carImageDAL.Delete(carImage);
            return new SuccesResult("Image was deleted successfully");
        }
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var isImage = _carImageDAL.Get(c => c.Id == carImage.Id);
            if (isImage == null)
            {
                return new ErrorResult("Image not found");
            }

            var updatedFile = _fileHelper.Update(file, isImage.ImagePath);
            if (!updatedFile.Succes)
            {
                return new ErrorResult(updatedFile.Message);
            }
            carImage.ImagePath = updatedFile.Message;
            _carImageDAL.Update(carImage);
            return new SuccesResult("Car image updated");
        }


        private IDataResult<List<CarImage>> CheckIfCarImageNull(int carId)
        {
            try
            {
                string path = @"\images\logo.jpg";
                var result = _carImageDAL.GetAll(c => c.CarId == carId).Any();
                if (!result)
                {
                    List<CarImage> carimage = new List<CarImage>();
                    carimage.Add(new CarImage { CarId = carId, ImagePath = path, Date = DateTime.Now });
                    return new SuccesDataResult<List<CarImage>>(carimage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return new SuccesDataResult<List<CarImage>>(_carImageDAL.GetAll(c => c.CarId == carId).ToList());
        }

    }
}
