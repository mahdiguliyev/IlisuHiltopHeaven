using Microsoft.AspNetCore.Http;
using IlisuHiltopHeaven.Entities.ComplexTypes;
using IlisuHiltopHeaven.Entities.Dtos;
using IlisuHiltopHeaven.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Presentation.Helpers.Abstract
{
    public interface IImageHelper 
    {
        Task<IDataResult<ImageUploadedDto>> Upload(string name, IFormFile pictureFile, PictureType pictureType, string folderName = null);
        IDataResult<ImageDeletedDto> Delete(string pictureName);
    }
}
