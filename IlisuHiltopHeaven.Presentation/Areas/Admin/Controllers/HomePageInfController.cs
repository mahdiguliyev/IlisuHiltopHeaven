using IlisuHiltopHeaven.Data.Concrete.EntityFramework.Context;
using IlisuHiltopHeaven.Entities.ComplexTypes;
using IlisuHiltopHeaven.Entities.Concrete;
using IlisuHiltopHeaven.Presentation.Areas.Admin.Models;
using IlisuHiltopHeaven.Presentation.Helpers.Abstract;
using IlisuHiltopHeaven.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Editor")]
    public class HomePageInfController : Controller
    {
        private readonly IlisuHiltopHeavenContext _db;
        private readonly IToastNotification _toastNotification;
        private readonly IImageHelper _imageHelper;

        public HomePageInfController(IlisuHiltopHeavenContext db, IToastNotification toastNotification, IImageHelper imageHelper)
        {
            _db = db;
            _toastNotification = toastNotification;
            _imageHelper = imageHelper;
        }
        public async Task<IActionResult> Index()
        {
            var homepageinfs = await _db.HomePageInformations.Where(o => o.Language.LanguageCode == "az").Include(s => s.Language).ToListAsync();
            if (homepageinfs == null)
            {
                return NotFound();
            }
            return View(homepageinfs);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var homePageInfs = await _db.HomePageInformations.Where(hp => hp.LanguageGroupId == id).Include(s => s.Language).ToListAsync();
            if (homePageInfs.Count > 0)
            {
                var homePageInfAz = homePageInfs.FirstOrDefault(hp => hp.Language.LanguageCode == "az");
                var homePageInfEn = homePageInfs.FirstOrDefault(hp => hp.Language.LanguageCode == "eng");
                var homePageInfRu = homePageInfs.FirstOrDefault(hp => hp.Language.LanguageCode == "rus");

                Guid languageGroupId = new Guid();
                string imageOne = string.Empty;

                if (homePageInfAz != null)
                {
                    languageGroupId = homePageInfAz.LanguageGroupId;
                    imageOne = homePageInfAz.Image;
                }
                else if (homePageInfEn != null)
                {
                    languageGroupId = homePageInfEn.LanguageGroupId;
                    imageOne = homePageInfEn.Image;
                }
                else if (homePageInfRu != null)
                {
                    languageGroupId = homePageInfRu.LanguageGroupId;
                    imageOne = homePageInfRu.Image;
                }

                HomePageInfUpdateViewModel homePageInfUpdateViewModel = new HomePageInfUpdateViewModel()
                {
                    LanguageGroupId = languageGroupId,
                    Image = imageOne
                };

                if (homePageInfAz != null)
                {
                    homePageInfUpdateViewModel.TitleAz = homePageInfAz.Title;
                    homePageInfUpdateViewModel.DescriptionAz = homePageInfAz.Description;
                }
                if (homePageInfEn != null)
                {
                    homePageInfUpdateViewModel.TitleEn = homePageInfEn.Title;
                    homePageInfUpdateViewModel.DescriptionEn = homePageInfEn.Description;
                }
                if (homePageInfRu != null)
                {
                    homePageInfUpdateViewModel.TitleRu = homePageInfRu.Title;
                    homePageInfUpdateViewModel.DescriptionRu = homePageInfRu.Description;
                }

                return View(homePageInfUpdateViewModel);
            }

            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(HomePageInfUpdateViewModel homePageInfUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                if (homePageInfUpdateViewModel.LanguageGroupId == null)
                    return NotFound();

                var homePageInfs = await _db.HomePageInformations.Where(ap => ap.LanguageGroupId == homePageInfUpdateViewModel.LanguageGroupId).Include(s => s.Language).ToListAsync();

                if (homePageInfs.Count == 0)
                {
                    _toastNotification.AddErrorToastMessage("Məlumat tapılmadı!", new ToastrOptions
                    {
                        Title = "Uğursuz Əməliyyat!"
                    });

                    return RedirectToAction("index", "homepageinf");
                }

                var homePageInfAz = homePageInfs.FirstOrDefault(hp => hp.Language.LanguageCode == "az");
                var homePageInfEn = homePageInfs.FirstOrDefault(hp => hp.Language.LanguageCode == "eng");
                var homePageInfRu = homePageInfs.FirstOrDefault(hp => hp.Language.LanguageCode == "rus");

                string image = string.Empty;

                if (homePageInfAz != null)
                {
                    image = homePageInfAz.Image;
                }
                else if (homePageInfEn != null)
                {
                    image = homePageInfEn.Image;
                }
                else if (homePageInfRu != null)
                {
                    image = homePageInfRu.Image;
                }

                var oldImage = homePageInfUpdateViewModel.Image;
                if (homePageInfUpdateViewModel.ImageFile != null)
                {
                    var imageResult = await _imageHelper.Upload("homepageinf_image", homePageInfUpdateViewModel.ImageFile, PictureType.Post, "homepageinformation");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        image = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImage);
                    }
                }

                if (homePageInfAz != null)
                {
                    homePageInfAz.Title = homePageInfUpdateViewModel.TitleAz;
                    homePageInfAz.Description = homePageInfUpdateViewModel.DescriptionAz;

                    if (!string.IsNullOrEmpty(image))
                        homePageInfAz.Image = image;

                    _db.HomePageInformations.Update(homePageInfAz);
                }
                if (homePageInfEn != null)
                {
                    homePageInfEn.Title = homePageInfUpdateViewModel.TitleEn;
                    homePageInfEn.Description = homePageInfUpdateViewModel.DescriptionEn;

                    if (!string.IsNullOrEmpty(image))
                        homePageInfEn.Image = image;

                    _db.HomePageInformations.Update(homePageInfEn);
                }
                if (homePageInfRu != null)
                {
                    homePageInfRu.Title = homePageInfUpdateViewModel.TitleRu;
                    homePageInfRu.Description = homePageInfUpdateViewModel.DescriptionRu;

                    if (!string.IsNullOrEmpty(image))
                        homePageInfRu.Image = image;

                    _db.HomePageInformations.Update(homePageInfRu);
                }

                await _db.SaveChangesAsync();

                _toastNotification.AddSuccessToastMessage("Dəyişiklik edildi!", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat!"
                });

                return RedirectToAction("index", "homepageinf");
            }

            var languages = await _db.Languages.ToListAsync();
            homePageInfUpdateViewModel.Languages = languages;

            return View(homePageInfUpdateViewModel);
        }
    }
}
