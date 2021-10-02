using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImageCount(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            FileHelperForLocalStorage.Add(formFile, CreateNewPath(formFile, out var pathForDb));

            carImage.ImagePath = pathForDb;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.ImageAdded);

        }

        public IResult Delete(CarImage carImage)
        {
            FileHelperForLocalStorage.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count == 0)
            {
                return new SuccessDataResult<List<CarImage>>(IfCarHasNoPhotoGetDefaultPhotoInTheList());
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.CarId == carId));
        }

        public IDataResult<List<CarImage>> GetByCarImageId(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count == 0)
            {
                return new SuccessDataResult<List<CarImage>>(IfCarHasNoPhotoGetDefaultPhotoInTheList());
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.CarId == carId));
        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            throw new NotImplementedException();
        }

        private IResult CheckCarImageCount(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageAddFailed);
            }
            return new SuccessResult();
        }

        private string CreateNewPath(IFormFile formFile, out string pathForDb)
        {

            var fileInfo = new FileInfo(formFile.FileName);
            pathForDb = $@"{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}_{DateTime.Now.Millisecond}{fileInfo.Extension}";
            var createdPathForHdd = $@"{Environment.CurrentDirectory}\wwwroot\images\" + pathForDb;

            return createdPathForHdd;
        }

        private List<CarImage> IfCarHasNoPhotoGetDefaultPhotoInTheList()
        {
            //var realpath = ImagePath = $@"{Environment.CurrentDirectory}\wwwroot\images\CarRentalDefault.jpg"
            var defaultImageInImageList = new List<CarImage>();
            var carImage = new CarImage
            {
                ImagePath = "CarRentalDefault.jpg"
            };
            defaultImageInImageList.Add(carImage);
            return defaultImageInImageList;
        }
    }
}
