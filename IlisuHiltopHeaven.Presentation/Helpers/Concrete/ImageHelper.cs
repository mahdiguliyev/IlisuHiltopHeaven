using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using IlisuHiltopHeaven.Entities.ComplexTypes;
using IlisuHiltopHeaven.Entities.Dtos;
using IlisuHiltopHeaven.Presentation.Helpers.Abstract;
using IlisuHiltopHeaven.Shared.Utilities.Extensions;
using IlisuHiltopHeaven.Shared.Utilities.Results.Abstract;
using IlisuHiltopHeaven.Shared.Utilities.Results.ComplexTypes;
using IlisuHiltopHeaven.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace IlisuHiltopHeaven.Presentation.Helpers.Concrete
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _wwwroot;
        private readonly string imgFolder = "img";
        private const string userImagesFolder = "userImages";
        private const string postImagesFolder = "postImages";
        public ImageHelper(IWebHostEnvironment webHostEnvironment)
        {
            _wwwroot = webHostEnvironment.WebRootPath;
        }

        public IDataResult<ImageDeletedDto> Delete(string pictureName)
        {
            var fileToDelete = Path.Combine($"{_wwwroot}/{imgFolder}", pictureName);
            if (System.IO.File.Exists(fileToDelete))
            {
                var fileInfo = new FileInfo(fileToDelete);
                var imageDeletedDto = new ImageDeletedDto
                {
                    FullName = pictureName,
                    Extension = fileInfo.Extension,
                    Path = fileInfo.FullName,
                    Size = fileInfo.Length
                };
                System.IO.File.Delete(fileToDelete);

                return new DataResult<ImageDeletedDto>(ResultStatus.Success, imageDeletedDto);
            }
            else
            {
                return new DataResult<ImageDeletedDto>(ResultStatus.Error, "The image not found", null);
            }
        }
        public async Task<IDataResult<ImageUploadedDto>> Upload(string name, IFormFile pictureFile,PictureType pictureType, string folderName = null)
        {
            folderName ??= pictureType == PictureType.User ? userImagesFolder : postImagesFolder;

            if (!Directory.Exists($"{_wwwroot}/{imgFolder}/{folderName}"))
            {
                Directory.CreateDirectory($"{_wwwroot}/{imgFolder}/{folderName}");
            }

            string oldFileName = Path.GetFileNameWithoutExtension(pictureFile.FileName);
            string fileExtension = Path.GetExtension(pictureFile.FileName);

            //Checking special characters in FileName
            Regex regex = new Regex("[*'\",._&#^@]");
            name = regex.Replace(name, string.Empty);

            DateTime dateTime = DateTime.Now;
            string newFileName = $"{name}_{dateTime.FullDateAndTimeStringWithUnserscore()}{fileExtension}";

            var path = Path.Combine($"{_wwwroot}/{imgFolder}/{folderName}", newFileName);

            using (var image = Image.Load(pictureFile.OpenReadStream()))
            {
                //string newSize = ResizeImage(image, 1000, image.Height);
                //string[] hwSize = newSize.Split(",");
                if (image.Width > 1600 || image.Height > 1600)
                {
                    image.Mutate(img => img.Resize(image.Width / 2, image.Height / 2));
                }

                await image.SaveAsync(path);
            }

            string message = pictureType == PictureType.User ? $"{name}'s image for user profile is updaded successfully." : $"{name}'s image for the article is updaded successfully.";

            return new DataResult<ImageUploadedDto>(ResultStatus.Success, message, new ImageUploadedDto
            {
                FullName = $"{folderName}/{newFileName}",
                OldName = oldFileName,
                Extension = fileExtension,
                FolderName = folderName,
                Path = path,
                Size = pictureFile.Length
            });
        }
        public string ResizeImage(Image image, int maxwidth, int maxHeight)
        {
            if (image.Width > maxwidth || image.Height > maxHeight)
            {
                double widthRatio = (double)image.Width / (double)maxwidth;
                double heightRatio = (double)image.Height / (double)maxHeight;
                double ratio = Math.Max(widthRatio, heightRatio);

                int newWidth = (int)(image.Width / ratio);
                int newHeight = (int)(image.Height / ratio);

                return newHeight.ToString() + "," + newWidth.ToString();
            }
            else
            {
                return image.Width.ToString() + "," + image.Height.ToString();
            }
        }
    }
}
