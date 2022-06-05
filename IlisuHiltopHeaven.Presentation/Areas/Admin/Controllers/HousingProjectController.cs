using IlisuHiltopHeaven.Data.Concrete.EntityFramework.Context;
using IlisuHiltopHeaven.Entities.ComplexTypes;
using IlisuHiltopHeaven.Presentation.Areas.Admin.Models;
using IlisuHiltopHeaven.Presentation.Helpers.Abstract;
using IlisuHiltopHeaven.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Editor")]
    public class HousingProjectController : Controller
    {
        private readonly IlisuHiltopHeavenContext _db;
        private readonly IToastNotification _toastNotification;
        private readonly IImageHelper _imageHelper;
        public HousingProjectController(IlisuHiltopHeavenContext db, IToastNotification toastNotification, IImageHelper imageHelper)
        {
            _db = db;
            _toastNotification = toastNotification;
            _imageHelper = imageHelper;
        }
        //public async Task<IActionResult> Index()
        //{
        //    var housingProjects = await _db.HousingProjects.Where(o => o.Language.LanguageCode == "az").Include(s => s.Language).ToListAsync();
        //    if (housingProjects == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(housingProjects);
        //}
        [HttpGet]
        public async Task<IActionResult> Update()
        {
            var housingProjects = await _db.HousingProjects.Include(s => s.Language).ToListAsync();
            if (housingProjects.Count > 0)
            {
                var housingProjectAz = housingProjects.FirstOrDefault(hp => hp.Language.LanguageCode == "az");
                var housingProjectEn = housingProjects.FirstOrDefault(hp => hp.Language.LanguageCode == "eng");
                var housingProjectRu = housingProjects.FirstOrDefault(hp => hp.Language.LanguageCode == "rus");

                Guid languageGroupId = new Guid();
                string imageOne = string.Empty, imageTwo = string.Empty, imageThree = string.Empty;

                if (housingProjectAz != null)
                {
                    languageGroupId = housingProjectAz.LanguageGroupId;
                    imageOne = housingProjectAz.Image1;
                    imageTwo = housingProjectAz.Image2;
                    imageThree = housingProjectAz.Image3;
                }
                else if (housingProjectEn != null)
                {
                    languageGroupId = housingProjectEn.LanguageGroupId;
                    imageOne = housingProjectEn.Image1;
                    imageTwo = housingProjectEn.Image2;
                    imageThree = housingProjectEn.Image3;
                }
                else if (housingProjectRu != null)
                {
                    languageGroupId = housingProjectRu.LanguageGroupId;
                    imageOne = housingProjectRu.Image1;
                    imageTwo = housingProjectRu.Image2;
                    imageThree = housingProjectRu.Image3;
                }

                HousingProjectUpdateViewModel housingProjectUpdateViewModel = new HousingProjectUpdateViewModel()
                {
                    LanguageGroupId = languageGroupId,
                    Image1 = imageOne,
                    Image2 = imageTwo,
                    Image3 = imageThree
                };

                if (housingProjectAz != null)
                {
                    housingProjectUpdateViewModel.MainTitleAz = housingProjectAz.MainTitle;
                    housingProjectUpdateViewModel.DescriptionAz = housingProjectAz.Description;
                    housingProjectUpdateViewModel.floorAz1 = housingProjectAz.floor1;
                    housingProjectUpdateViewModel.floorAz2 = housingProjectAz.floor2;
                    housingProjectUpdateViewModel.floorAz3 = housingProjectAz.floor3;
                }
                if (housingProjectEn != null)
                {
                    housingProjectUpdateViewModel.MainTitleEn = housingProjectEn.MainTitle;
                    housingProjectUpdateViewModel.DescriptionEn = housingProjectEn.Description;
                    housingProjectUpdateViewModel.floorEn1 = housingProjectEn.floor1;
                    housingProjectUpdateViewModel.floorEn2 = housingProjectEn.floor2;
                    housingProjectUpdateViewModel.floorEn3 = housingProjectEn.floor3;
                }
                if (housingProjectRu != null)
                {
                    housingProjectUpdateViewModel.MainTitleRu = housingProjectRu.MainTitle;
                    housingProjectUpdateViewModel.DescriptionRu = housingProjectRu.Description;
                    housingProjectUpdateViewModel.floorRu1 = housingProjectRu.floor1;
                    housingProjectUpdateViewModel.floorRu2 = housingProjectRu.floor2;
                    housingProjectUpdateViewModel.floorRu3 = housingProjectRu.floor3;
                }

                return View(housingProjectUpdateViewModel);
            }

            _toastNotification.AddErrorToastMessage("Məlumat tapılmadı!", new ToastrOptions
            {
                Title = "Uğursuz Əməliyyat!"
            });

            return RedirectToAction("index", "home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(HousingProjectUpdateViewModel housingProjectUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                if (housingProjectUpdateViewModel.LanguageGroupId == null)
                    return NotFound();

                var housingProjects = await _db.HousingProjects.Where(ap => ap.LanguageGroupId == housingProjectUpdateViewModel.LanguageGroupId).Include(s => s.Language).ToListAsync();

                if (housingProjects.Count == 0)
                {
                    _toastNotification.AddErrorToastMessage("Məlumat tapılmadı!", new ToastrOptions
                    {
                        Title = "Uğursuz Əməliyyat!"
                    });

                    return RedirectToAction("index", "home");
                }

                var housingProjectAz = housingProjects.FirstOrDefault(hp => hp.Language.LanguageCode == "az");
                var housingProjectEn = housingProjects.FirstOrDefault(hp => hp.Language.LanguageCode == "eng");
                var housingProjectRu = housingProjects.FirstOrDefault(hp => hp.Language.LanguageCode == "rus");

                string imageOne = string.Empty, imageTwo = string.Empty, imageThree = string.Empty;

                if (housingProjectAz != null)
                {
                    imageOne = housingProjectAz.Image1;
                    imageTwo = housingProjectAz.Image2;
                    imageThree = housingProjectAz.Image3;
                }
                else if (housingProjectEn != null)
                {
                    imageOne = housingProjectEn.Image1;
                    imageTwo = housingProjectEn.Image2;
                    imageThree = housingProjectEn.Image3;
                }
                else if (housingProjectRu != null)
                {
                    imageOne = housingProjectRu.Image1;
                    imageTwo = housingProjectRu.Image2;
                    imageThree = housingProjectRu.Image3;
                }

                var oldImageOne = housingProjectUpdateViewModel.Image1;
                if (housingProjectUpdateViewModel.ImageFileOne != null)
                {
                    var imageResult = await _imageHelper.Upload("housingproject_image1", housingProjectUpdateViewModel.ImageFileOne, PictureType.Post, "housingproject");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        imageOne = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImageOne);
                    }
                }
                var oldImageTwo = housingProjectUpdateViewModel.Image2;
                if (housingProjectUpdateViewModel.ImageFileTwo != null)
                {
                    var imageResult = await _imageHelper.Upload("housingproject_image2", housingProjectUpdateViewModel.ImageFileTwo, PictureType.Post, "housingproject");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        imageTwo = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImageTwo);
                    }
                }
                var oldImageThree = housingProjectUpdateViewModel.Image3;
                if (housingProjectUpdateViewModel.ImageFileThree != null)
                {
                    var imageResult = await _imageHelper.Upload("housingproject_image3", housingProjectUpdateViewModel.ImageFileThree, PictureType.Post, "housingproject");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        imageThree = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImageThree);
                    }
                }

                if (housingProjectAz != null)
                {
                    housingProjectAz.MainTitle = housingProjectUpdateViewModel.MainTitleAz;
                    housingProjectAz.Description = housingProjectUpdateViewModel.DescriptionAz;
                    housingProjectAz.floor1 = housingProjectUpdateViewModel.floorAz1;
                    housingProjectAz.floor2 = housingProjectUpdateViewModel.floorAz2;
                    housingProjectAz.floor3 = housingProjectUpdateViewModel.floorAz3;

                    if (!string.IsNullOrEmpty(imageOne) || !string.IsNullOrEmpty(imageTwo) || !string.IsNullOrEmpty(imageThree))
                    {
                        housingProjectAz.Image1 = imageOne;
                        housingProjectAz.Image2 = imageTwo;
                        housingProjectAz.Image3 = imageThree;
                    }

                    _db.HousingProjects.Update(housingProjectAz);
                }
                if (housingProjectEn != null)
                {
                    housingProjectEn.MainTitle = housingProjectUpdateViewModel.MainTitleEn;
                    housingProjectEn.Description = housingProjectUpdateViewModel.DescriptionEn;
                    housingProjectEn.floor1 = housingProjectUpdateViewModel.floorEn1;
                    housingProjectEn.floor2 = housingProjectUpdateViewModel.floorEn2;
                    housingProjectEn.floor3 = housingProjectUpdateViewModel.floorEn3;

                    if (!string.IsNullOrEmpty(imageOne) || !string.IsNullOrEmpty(imageTwo) || !string.IsNullOrEmpty(imageThree))
                    {
                        housingProjectEn.Image1 = imageOne;
                        housingProjectEn.Image2 = imageTwo;
                        housingProjectEn.Image3 = imageThree;
                    }

                    _db.HousingProjects.Update(housingProjectEn);
                }
                if (housingProjectRu != null)
                {
                    housingProjectRu.MainTitle = housingProjectUpdateViewModel.MainTitleRu;
                    housingProjectRu.Description =  housingProjectUpdateViewModel.DescriptionRu;
                    housingProjectRu.floor1 = housingProjectUpdateViewModel.floorRu1;
                    housingProjectRu.floor2 = housingProjectUpdateViewModel.floorRu2;
                    housingProjectRu.floor3 = housingProjectUpdateViewModel.floorRu3;

                    if (!string.IsNullOrEmpty(imageOne) || !string.IsNullOrEmpty(imageTwo) || !string.IsNullOrEmpty(imageThree))
                    {
                        housingProjectRu.Image1 = imageOne;
                        housingProjectRu.Image2 = imageTwo;
                        housingProjectRu.Image3 = imageThree;
                    }

                    _db.HousingProjects.Update(housingProjectRu);
                }

                await _db.SaveChangesAsync();

                _toastNotification.AddSuccessToastMessage("Dəyişiklik edildi!", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat!"
                });

                return RedirectToAction("index", "home");
            }

            var languages = await _db.Languages.ToListAsync();
            housingProjectUpdateViewModel.Languages = languages;

            return View(housingProjectUpdateViewModel);
        }
    }
}
