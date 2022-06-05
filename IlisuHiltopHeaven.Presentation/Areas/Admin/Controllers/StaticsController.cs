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
using System.Linq;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Editor")]
    public class StaticsController : Controller
    {
        private readonly IlisuHiltopHeavenContext _db;
        private readonly IToastNotification _toastNotification;
        private readonly IImageHelper _imageHelper;
        public StaticsController(IlisuHiltopHeavenContext db, IToastNotification toastNotification, IImageHelper imageHelper)
        {
            _db = db;
            _toastNotification = toastNotification;
            _imageHelper = imageHelper;
        }

        [HttpGet]
        public async Task<IActionResult> HomePageSettings()
        {
            var homePages = await _db.HomePages.Where(hp => hp.Language.LanguageCode == "az").Include(hp => hp.Language).ToListAsync();
            if (homePages != null)
            {
                HomePageViewModel homePageViewModel = new HomePageViewModel
                {
                    HomePages = homePages
                };

                return View(homePageViewModel);
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateHomePageSetting(Guid id)
        {
            var homePages = await _db.HomePages.Where(hp => hp.LanguageGroupId == id).Include(hp => hp.Language).ToListAsync();
            if (homePages.Count > 0)
            {
                var homePageAz = homePages.FirstOrDefault(hp => hp.Language.LanguageCode == "az");
                var homePageEn = homePages.FirstOrDefault(hp => hp.Language.LanguageCode == "eng");
                var homePageRu = homePages.FirstOrDefault(hp => hp.Language.LanguageCode == "rus");

                Guid languageGroupId = new Guid();
                string image = string.Empty;
                string pageName = string.Empty;

                if (homePageAz != null)
                {
                    languageGroupId = homePageAz.LanguageGroupId;
                    image = homePageAz.Image;
                    pageName = homePageAz.PageName;
                }
                else if (homePageEn != null)
                {
                    languageGroupId = homePageAz.LanguageGroupId;
                    image = homePageAz.Image;
                    pageName = homePageEn.PageName;
                }
                else if (homePageRu != null)
                {
                    languageGroupId = homePageAz.LanguageGroupId;
                    image = homePageAz.Image;
                    pageName = homePageRu.PageName;
                }

                HomePageUpdateViewModel homePageUpdateViewModel = new HomePageUpdateViewModel()
                {
                    LanguageGroupId = languageGroupId,
                    Image = image,
                    PageName = pageName
                };

                if (homePageAz != null)
                {
                    homePageUpdateViewModel.TitleAz = homePageAz.Title;
                    homePageUpdateViewModel.DescriptionAz = homePageAz.Description;
                }
                if (homePageEn != null)
                {
                    homePageUpdateViewModel.TitleEn = homePageEn.Title;
                    homePageUpdateViewModel.DescriptionEn = homePageEn.Description;
                }
                if (homePageRu != null)
                {
                    homePageUpdateViewModel.TitleRu = homePageRu.Title;
                    homePageUpdateViewModel.DescriptionRu = homePageRu.Description;
                }

                return View(homePageUpdateViewModel);
            }

            _toastNotification.AddErrorToastMessage("Məlumat tapılmadı!", new ToastrOptions
            {
                Title = "Uğursuz Əməliyyat!"
            });

            return RedirectToAction("homepagesettings", "statics");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateHomePageSetting(HomePageUpdateViewModel homePageUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                if (homePageUpdateViewModel.LanguageGroupId == null)
                    return NotFound();

                var homePages = await _db.HomePages.Where(hp => hp.LanguageGroupId == homePageUpdateViewModel.LanguageGroupId).Include(hp => hp.Language).ToListAsync();

                if (homePages.Count == 0)
                {
                    _toastNotification.AddErrorToastMessage("Məlumat tapılmadı!", new ToastrOptions
                    {
                        Title = "Uğursuz Əməliyyat!"
                    });

                    return RedirectToAction("homepagesettings", "statics");
                }

                var homePageAz = homePages.FirstOrDefault(hp => hp.Language.LanguageCode == "az");
                var homePageEn = homePages.FirstOrDefault(hp => hp.Language.LanguageCode == "eng");
                var homePageRu = homePages.FirstOrDefault(hp => hp.Language.LanguageCode == "rus");

                string image = string.Empty;

                if (homePageAz != null)
                {
                    image = homePageAz.Image;
                }
                else if (homePageEn != null)
                {
                    image = homePageEn.Image;
                }
                else if (homePageRu != null)
                {
                    image = homePageRu.Image;
                }

                var oldImage = homePageUpdateViewModel.Image;
                if (homePageUpdateViewModel.ImageFile != null)
                {
                    var imageResult = await _imageHelper.Upload("homepageinf", homePageUpdateViewModel.ImageFile, PictureType.Post, "homepageinf");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        image = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImage);
                    }
                }

                if (homePageAz != null)
                {
                    homePageAz.Title = homePageUpdateViewModel.TitleAz;
                    homePageAz.Description = homePageUpdateViewModel.DescriptionAz;

                    if (!string.IsNullOrEmpty(image))
                        homePageAz.Image = image;

                    _db.HomePages.Update(homePageAz);
                }
                if (homePageEn != null)
                {
                    homePageEn.Title = homePageUpdateViewModel.TitleEn;
                    homePageEn.Description = homePageUpdateViewModel.DescriptionEn;

                    if (!string.IsNullOrEmpty(image))
                        homePageEn.Image = image;

                    _db.HomePages.Update(homePageEn);
                }
                if (homePageRu != null)
                {
                    homePageRu.Title = homePageUpdateViewModel.TitleRu;
                    homePageRu.Description = homePageUpdateViewModel.DescriptionRu;

                    if (!string.IsNullOrEmpty(image))
                        homePageRu.Image = image;

                    _db.HomePages.Update(homePageRu);
                }
                await _db.SaveChangesAsync();

                _toastNotification.AddSuccessToastMessage("Dəyişiklik edildi!", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat!"
                });

                return RedirectToAction("homepagesettings", "statics");
            }

            return View(homePageUpdateViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBannerSetting()
        {
            var banners = await _db.Banners.Include(b => b.Language).ToListAsync();
            if (banners.Count > 0)
            {
                var bannerAz = banners.FirstOrDefault(hp => hp.Language.LanguageCode == "az");
                var bannerEn = banners.FirstOrDefault(hp => hp.Language.LanguageCode == "eng");
                var bannerRu = banners.FirstOrDefault(hp => hp.Language.LanguageCode == "rus");

                Guid languageGroupId = new Guid();
                string imageOne = string.Empty, imageTwo = string.Empty, imageThree = string.Empty, imageFour = string.Empty, imageFive = string.Empty;
                string videoUrl = string.Empty;
                if (bannerAz != null)
                {
                    languageGroupId = bannerAz.LanguageGroupId;
                    imageOne = bannerAz.ImageOne;
                    imageTwo = bannerAz.ImageTwo;
                    imageThree = bannerAz.ImageThree;
                    imageFour = bannerAz.ImageFour;
                    imageFive = bannerAz.ImageFive;
                    videoUrl = bannerAz.VideoUrl;
                }
                else if (bannerEn != null)
                {
                    languageGroupId = bannerEn.LanguageGroupId;
                    imageOne = bannerEn.ImageOne;
                    imageTwo = bannerEn.ImageTwo;
                    imageThree = bannerEn.ImageThree;
                    imageFour = bannerEn.ImageFour;
                    imageFive = bannerEn.ImageFive;
                    videoUrl = bannerEn.VideoUrl;
                }
                else if (bannerRu != null)
                {
                    languageGroupId = bannerRu.LanguageGroupId;
                    imageOne = bannerRu.ImageOne;
                    imageTwo = bannerRu.ImageTwo;
                    imageThree = bannerRu.ImageThree;
                    imageFour = bannerRu.ImageFour;
                    imageFive = bannerRu.ImageFive;
                    videoUrl = bannerRu.VideoUrl;
                }

                BannerUpdateViewModel bannerUpdateViewModel = new BannerUpdateViewModel()
                {
                    LanguageGroupId = languageGroupId,
                    ImageOne = imageOne,
                    ImageTwo = imageTwo,
                    ImageThree = imageThree,
                    ImageFour = imageFour,
                    ImageFive = imageFive,
                    VideoUrl = videoUrl,
                };

                if (bannerAz != null)
                {
                    bannerUpdateViewModel.TitleAz = bannerAz.Title;
                    bannerUpdateViewModel.DescriptionAz = bannerAz.Description;
                }
                if (bannerEn != null)
                {
                    bannerUpdateViewModel.TitleEn = bannerEn.Title;
                    bannerUpdateViewModel.DescriptionEn = bannerEn.Description;
                }
                if (bannerRu != null)
                {
                    bannerUpdateViewModel.TitleRu = bannerRu.Title;
                    bannerUpdateViewModel.DescriptionRu = bannerRu.Description;
                }

                return View(bannerUpdateViewModel);
            }

            _toastNotification.AddErrorToastMessage("Məlumat tapılmadı!", new ToastrOptions
            {
                Title = "Uğursuz Əməliyyat!"
            });

            return RedirectToAction("updatebannersetting", "statics");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateBannerSetting(BannerUpdateViewModel bannerUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                if (bannerUpdateViewModel.LanguageGroupId == null)
                    return NotFound();

                var banners = await _db.Banners.Where(b => b.LanguageGroupId == bannerUpdateViewModel.LanguageGroupId).Include(b => b.Language).ToListAsync();

                if (banners.Count == 0)
                {
                    _toastNotification.AddErrorToastMessage("Məlumat tapılmadı!", new ToastrOptions
                    {
                        Title = "Uğursuz Əməliyyat!"
                    });

                    return RedirectToAction("updatebannersetting", "statics");
                }

                var bannerAz = banners.FirstOrDefault(hp => hp.Language.LanguageCode == "az");
                var bannerEn = banners.FirstOrDefault(hp => hp.Language.LanguageCode == "eng");
                var bannerRu = banners.FirstOrDefault(hp => hp.Language.LanguageCode == "rus");

                string imageOne = string.Empty, imageTwo = string.Empty, imageThree = string.Empty, imageFour = string.Empty, imageFive = string.Empty;
                string videoUrl = string.Empty;
                if (bannerAz != null)
                {
                    imageOne = bannerAz.ImageOne;
                    imageTwo = bannerAz.ImageTwo;
                    imageThree = bannerAz.ImageThree;
                    imageFour = bannerAz.ImageFour;
                    imageFive = bannerAz.ImageFive;
                    videoUrl = bannerAz.VideoUrl;
                }
                else if (bannerEn != null)
                {
                    imageOne = bannerEn.ImageOne;
                    imageTwo = bannerEn.ImageTwo;
                    imageThree = bannerEn.ImageThree;
                    imageFour = bannerEn.ImageFour;
                    imageFive = bannerEn.ImageFive;
                    videoUrl = bannerEn.VideoUrl;
                }
                else if (bannerRu != null)
                {
                    imageOne = bannerRu.ImageOne;
                    imageTwo = bannerRu.ImageTwo;
                    imageThree = bannerRu.ImageThree;
                    imageFour = bannerRu.ImageFour;
                    imageFive = bannerRu.ImageFive;
                    videoUrl = bannerRu.VideoUrl;
                }

                var oldImageOne = bannerUpdateViewModel.ImageOne;
                if (bannerUpdateViewModel.ImageFileOne != null)
                {
                    var imageResult = await _imageHelper.Upload("banner_image", bannerUpdateViewModel.ImageFileOne, PictureType.Post, "banner");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        imageOne = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImageOne);
                    }
                }
                var oldImageTwo = bannerUpdateViewModel.ImageTwo;
                if (bannerUpdateViewModel.ImageFileTwo != null)
                {
                    var imageResult = await _imageHelper.Upload("banner_image", bannerUpdateViewModel.ImageFileTwo, PictureType.Post, "banner");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        imageTwo = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImageTwo);
                    }
                }
                var oldImageThree = bannerUpdateViewModel.ImageThree;
                if (bannerUpdateViewModel.ImageFileThree != null)
                {
                    var imageResult = await _imageHelper.Upload("banner_image", bannerUpdateViewModel.ImageFileThree, PictureType.Post, "banner");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        imageThree = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImageThree);
                    }
                }
                var oldImageFour = bannerUpdateViewModel.ImageFour;
                if (bannerUpdateViewModel.ImageFileFour != null)
                {
                    var imageResult = await _imageHelper.Upload("banner_image", bannerUpdateViewModel.ImageFileFour, PictureType.Post, "banner");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        imageFour = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImageFour);
                    }
                }
                var oldImageFive = bannerUpdateViewModel.ImageFive;
                if (bannerUpdateViewModel.ImageFileFive != null)
                {
                    var imageResult = await _imageHelper.Upload("banner_image", bannerUpdateViewModel.ImageFileFive, PictureType.Post, "banner");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        imageFive = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImageFive);
                    }
                }

                if (bannerAz != null)
                {
                    bannerAz.Title = bannerUpdateViewModel.TitleAz;
                    bannerAz.Description = bannerUpdateViewModel.DescriptionAz;
                    
                    if (!string.IsNullOrEmpty(imageOne) || !string.IsNullOrEmpty(imageTwo) || !string.IsNullOrEmpty(imageThree) || !string.IsNullOrEmpty(imageFour) || !string.IsNullOrEmpty(imageFive))
                    {
                        bannerAz.ImageOne = imageOne;
                        bannerAz.ImageTwo = imageTwo;
                        bannerAz.ImageThree = imageThree;
                        bannerAz.ImageFour = imageFour;
                        bannerAz.ImageFive = imageFive;
                    }
                    bannerAz.VideoUrl = bannerUpdateViewModel.VideoUrl;

                    _db.Banners.Update(bannerAz);
                }
                if (bannerEn != null)
                {
                    bannerEn.Title = bannerUpdateViewModel.TitleEn;
                    bannerEn.Description = bannerUpdateViewModel.DescriptionEn;

                    if (!string.IsNullOrEmpty(imageOne) || !string.IsNullOrEmpty(imageTwo) || !string.IsNullOrEmpty(imageThree) || !string.IsNullOrEmpty(imageFour) || !string.IsNullOrEmpty(imageFive))
                    {
                        bannerEn.ImageOne = imageOne;
                        bannerEn.ImageTwo = imageTwo;
                        bannerEn.ImageThree = imageThree;
                        bannerEn.ImageFour = imageFour;
                        bannerEn.ImageFive = imageFive;
                    }
                    bannerEn.VideoUrl = bannerUpdateViewModel.VideoUrl;

                    _db.Banners.Update(bannerEn);
                }
                if (bannerRu != null)
                {
                    bannerRu.Title = bannerUpdateViewModel.TitleRu;
                    bannerRu.Description = bannerUpdateViewModel.DescriptionRu;

                    if (!string.IsNullOrEmpty(imageOne) || !string.IsNullOrEmpty(imageTwo) || !string.IsNullOrEmpty(imageThree) || !string.IsNullOrEmpty(imageFour) || !string.IsNullOrEmpty(imageFive))
                    {
                        bannerRu.ImageOne = imageOne;
                        bannerRu.ImageTwo = imageTwo;
                        bannerRu.ImageThree = imageThree;
                        bannerRu.ImageFour = imageFour;
                        bannerRu.ImageFive = imageFive;
                    }
                    bannerRu.VideoUrl = bannerUpdateViewModel.VideoUrl;

                    _db.Banners.Update(bannerRu);
                }

                await _db.SaveChangesAsync();

                _toastNotification.AddSuccessToastMessage("Dəyişiklik edildi!", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat!"
                });

                return RedirectToAction("updatebannersetting", "statics");
            }

            return View(bannerUpdateViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProjectSetting()
        {
            var projects = await _db.Projects.Include(p => p.Language).ToListAsync();
            if (projects.Count > 0)
            {
                var projectAz = projects.FirstOrDefault(p => p.Language.LanguageCode == "az");
                var projectEng = projects.FirstOrDefault(p => p.Language.LanguageCode == "eng");
                var projectRus = projects.FirstOrDefault(p => p.Language.LanguageCode == "rus");

                Guid languageGroupId = new Guid();
                string imageOne = string.Empty, imageTwo = string.Empty, imageThree = string.Empty, imageFour = string.Empty, imageFive = string.Empty, imageSix = string.Empty, imageMainOne = string.Empty, imageMainTwo = string.Empty, imageMainThree = string.Empty, imageMainFour = string.Empty, imageMainFive = string.Empty, imageMainSix = string.Empty;
                string mapUrl = string.Empty;
                if (projectAz != null)
                {
                    languageGroupId = projectAz.LanguageGroupId;
                    imageOne = projectAz.ImageOne;
                    imageTwo = projectAz.ImageTwo;
                    imageThree = projectAz.ImageThree;
                    imageFour = projectAz.ImageFour;
                    imageFive = projectAz.ImageFive;
                    imageSix = projectAz.ImageSix;
                    imageMainOne = projectAz.MainImageOne;
                    imageMainTwo = projectAz.MainImageTwo;
                    imageMainThree = projectAz.MainImageThree;
                    imageMainFour = projectAz.MainImageFour;
                    imageMainFive = projectAz.MainImageFive;
                    imageMainSix = projectAz.MainImageSix;
                    mapUrl = projectAz.MapUrl;
                }
                else if (projectEng != null)
                {
                    languageGroupId = projectEng.LanguageGroupId;
                    imageOne = projectEng.ImageOne;
                    imageTwo = projectEng.ImageTwo;
                    imageThree = projectEng.ImageThree;
                    imageFour = projectEng.ImageFour;
                    imageFive = projectEng.ImageFive;
                    imageSix = projectEng.ImageSix;
                    imageMainOne = projectEng.MainImageOne;
                    imageMainTwo = projectEng.MainImageTwo;
                    imageMainThree = projectEng.MainImageThree;
                    imageMainFour = projectEng.MainImageFour;
                    imageMainFive = projectEng.MainImageFive;
                    imageMainSix = projectEng.MainImageSix;
                    mapUrl = projectEng.MapUrl;
                }
                else if (projectRus != null)
                {
                    languageGroupId = projectRus.LanguageGroupId;
                    imageOne = projectRus.ImageOne;
                    imageTwo = projectRus.ImageTwo;
                    imageThree = projectRus.ImageThree;
                    imageFour = projectRus.ImageFour;
                    imageFive = projectRus.ImageFive;
                    imageSix = projectRus.ImageSix;
                    imageMainOne = projectRus.MainImageOne;
                    imageMainTwo = projectRus.MainImageTwo;
                    imageMainThree = projectRus.MainImageThree;
                    imageMainFour = projectRus.MainImageFour;
                    imageMainFive = projectRus.MainImageFive;
                    imageMainSix = projectRus.MainImageSix;
                    mapUrl = projectRus.MapUrl;
                }

                ProjectUpdateViewModel projectUpdateViewModel = new ProjectUpdateViewModel()
                {
                    LanguageGroupId = languageGroupId,
                    ImageOne = imageOne,
                    ImageTwo = imageTwo,
                    ImageThree = imageThree,
                    ImageFour = imageFour,
                    ImageFive = imageFive,
                    ImageSix = imageSix,
                    MainImageOne = imageMainOne,
                    MainImageTwo = imageMainTwo,
                    MainImageThree = imageMainThree,
                    MainImageFour = imageMainFour,
                    MainImageFive = imageMainFive,
                    MainImageSix = imageMainSix,
                    MapUrl = mapUrl
                };

                if (projectAz != null)
                {
                    projectUpdateViewModel.TitleAz1 = projectAz.Title1;
                    projectUpdateViewModel.TitleAz2 = projectAz.Title2;
                    projectUpdateViewModel.MainPlanAz = projectAz.MainPlan;
                    projectUpdateViewModel.ComlexLocAz = projectAz.ComlexLoc;
                    projectUpdateViewModel.BuildingProjectAz = projectAz.BuildingProject;
                }
                if (projectEng != null)
                {
                    projectUpdateViewModel.TitleEn1 = projectEng.Title1;
                    projectUpdateViewModel.TitleEn2 = projectEng.Title2;
                    projectUpdateViewModel.MainPlanEn = projectEng.MainPlan;
                    projectUpdateViewModel.ComlexLocEn = projectEng.ComlexLoc;
                    projectUpdateViewModel.BuildingProjectEn = projectEng.BuildingProject;
                }
                if (projectRus != null)
                {
                    projectUpdateViewModel.TitleRu1 = projectRus.Title1;
                    projectUpdateViewModel.TitleRu2 = projectRus.Title2;
                    projectUpdateViewModel.MainPlanRu = projectRus.MainPlan;
                    projectUpdateViewModel.ComlexLocRu = projectRus.ComlexLoc;
                    projectUpdateViewModel.BuildingProjectRu = projectRus.BuildingProject;
                }

                return View(projectUpdateViewModel);
            }

            _toastNotification.AddErrorToastMessage("Məlumat tapılmadı!", new ToastrOptions
            {
                Title = "Uğursuz Əməliyyat!"
            });

            return RedirectToAction("updateprojectsetting", "statics");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProjectSetting(ProjectUpdateViewModel projectUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                if (projectUpdateViewModel.LanguageGroupId == null)
                    return NotFound();

                var projects = await _db.Projects.Where(p => p.LanguageGroupId == projectUpdateViewModel.LanguageGroupId).Include(p => p.Language).ToListAsync();

                if (projects.Count == 0)
                {
                    _toastNotification.AddErrorToastMessage("Məlumat tapılmadı!", new ToastrOptions
                    {
                        Title = "Uğursuz Əməliyyat!"
                    });

                    return RedirectToAction("updateprojectsetting", "statics");
                }

                var projectAz = projects.FirstOrDefault(p => p.Language.LanguageCode == "az");
                var projectEng = projects.FirstOrDefault(p => p.Language.LanguageCode == "eng");
                var projectRus = projects.FirstOrDefault(p => p.Language.LanguageCode == "rus");

                string imageOne = string.Empty, imageTwo = string.Empty, imageThree = string.Empty, imageFour = string.Empty, imageFive = string.Empty, imageSix = string.Empty, imageMainOne = string.Empty, imageMainTwo = string.Empty, imageMainThree = string.Empty, imageMainFour = string.Empty, imageMainFive = string.Empty, imageMainSix = string.Empty;
                string mapUrl = string.Empty;

                if (projectAz != null)
                {
                    imageOne = projectAz.ImageOne;
                    imageTwo = projectAz.ImageTwo;
                    imageThree = projectAz.ImageThree;
                    imageFour = projectAz.ImageFour;
                    imageFive = projectAz.ImageFive;
                    imageSix = projectAz.ImageSix;
                    imageMainOne = projectAz.MainImageOne;
                    imageMainTwo = projectAz.MainImageTwo;
                    imageMainThree = projectAz.MainImageThree;
                    imageMainFour = projectAz.MainImageFour;
                    imageMainFive = projectAz.MainImageFive;
                    imageMainSix = projectAz.MainImageSix;
                    mapUrl = projectAz.MapUrl;
                }
                else if (projectEng != null)
                {
                    imageOne = projectEng.ImageOne;
                    imageTwo = projectEng.ImageTwo;
                    imageThree = projectEng.ImageThree;
                    imageFour = projectEng.ImageFour;
                    imageFive = projectEng.ImageFive;
                    imageSix = projectEng.ImageSix;
                    imageMainOne = projectEng.MainImageOne;
                    imageMainTwo = projectEng.MainImageTwo;
                    imageMainThree = projectEng.MainImageThree;
                    imageMainFour = projectEng.MainImageFour;
                    imageMainFive = projectEng.MainImageFive;
                    imageMainSix = projectEng.MainImageSix;
                    mapUrl = projectEng.MapUrl;
                }
                else if (projectRus != null)
                {
                    imageOne = projectRus.ImageOne;
                    imageTwo = projectRus.ImageTwo;
                    imageThree = projectRus.ImageThree;
                    imageFour = projectRus.ImageFour;
                    imageFive = projectRus.ImageFive;
                    imageSix = projectRus.ImageSix;
                    imageMainOne = projectRus.MainImageOne;
                    imageMainTwo = projectRus.MainImageTwo;
                    imageMainThree = projectRus.MainImageThree;
                    imageMainFour = projectRus.MainImageFour;
                    imageMainFive = projectRus.MainImageFive;
                    imageMainSix = projectRus.MainImageSix;
                    mapUrl = projectRus.MapUrl;
                }

                var oldImageOne = projectUpdateViewModel.MainImageOne;
                if (projectUpdateViewModel.MainImageFileOne != null)
                {
                    var imageResult = await _imageHelper.Upload("project_image", projectUpdateViewModel.MainImageFileOne, PictureType.Post, "project");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        //project.MainImageOne = imageResult.Data.FullName;
                        imageMainOne = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImageOne);
                    }
                }
                var oldImageTwo = projectUpdateViewModel.MainImageTwo;
                if (projectUpdateViewModel.MainImageFileTwo != null)
                {
                    var imageResult = await _imageHelper.Upload("project_image", projectUpdateViewModel.MainImageFileTwo, PictureType.Post, "project");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        imageMainTwo = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImageTwo);
                    }
                }
                var oldImageThree = projectUpdateViewModel.MainImageThree;
                if (projectUpdateViewModel.MainImageFileThree != null)
                {
                    var imageResult = await _imageHelper.Upload("project_image", projectUpdateViewModel.MainImageFileThree, PictureType.Post, "project");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        imageMainThree = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImageThree);
                    }
                }
                var oldImageMOne = projectUpdateViewModel.MainImageFour;
                if (projectUpdateViewModel.MainImageFileFour != null)
                {
                    var imageResult = await _imageHelper.Upload("project_image", projectUpdateViewModel.MainImageFileFour, PictureType.Post, "project");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        imageMainFour = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImageMOne);
                    }
                }
                var oldImageMTwo = projectUpdateViewModel.MainImageFive;
                if (projectUpdateViewModel.MainImageFileFive != null)
                {
                    var imageResult = await _imageHelper.Upload("project_image", projectUpdateViewModel.MainImageFileFive, PictureType.Post, "project");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        imageMainFive = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImageMTwo);
                    }
                }
                var oldImageMThree = projectUpdateViewModel.MainImageSix;
                if (projectUpdateViewModel.MainImageFileSix != null)
                {
                    var imageResult = await _imageHelper.Upload("project_image", projectUpdateViewModel.MainImageFileSix, PictureType.Post, "project");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        imageMainSix = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImageMThree);
                    }
                }
                var oldImageSix = projectUpdateViewModel.ImageOne;
                if (projectUpdateViewModel.ImageFileOne != null)
                {
                    var imageResult = await _imageHelper.Upload("project_image", projectUpdateViewModel.ImageFileOne, PictureType.Post, "project");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        imageOne = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImageSix);
                    }
                }
                var oldImageSeven = projectUpdateViewModel.ImageTwo;
                if (projectUpdateViewModel.ImageFileTwo != null)
                {
                    var imageResult = await _imageHelper.Upload("project_image", projectUpdateViewModel.ImageFileTwo, PictureType.Post, "project");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        imageTwo = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImageSeven);
                    }
                }
                var oldImageEight = projectUpdateViewModel.ImageThree;
                if (projectUpdateViewModel.ImageFileThree != null)
                {
                    var imageResult = await _imageHelper.Upload("project_image", projectUpdateViewModel.ImageFileThree, PictureType.Post, "project");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        imageThree = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImageEight);
                    }
                }
                var oldImageNine = projectUpdateViewModel.ImageFour;
                if (projectUpdateViewModel.ImageFileFour != null)
                {
                    var imageResult = await _imageHelper.Upload("project_image", projectUpdateViewModel.ImageFileFour, PictureType.Post, "project");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        imageFour = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImageNine);
                    }
                }
                var oldImageTen = projectUpdateViewModel.ImageFive;
                if (projectUpdateViewModel.ImageFileFive != null)
                {
                    var imageResult = await _imageHelper.Upload("project_image", projectUpdateViewModel.ImageFileFive, PictureType.Post, "project");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        imageFive = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImageTen);
                    }
                }
                var oldImageEleven = projectUpdateViewModel.ImageSix;
                if (projectUpdateViewModel.ImageFileSix != null)
                {
                    var imageResult = await _imageHelper.Upload("project_image", projectUpdateViewModel.ImageFileSix, PictureType.Post, "project");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        imageSix = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImageEleven);
                    }
                }

                if (projectAz != null)
                {
                    projectAz.Title1 = projectUpdateViewModel.TitleAz1;
                    projectAz.Title2 = projectUpdateViewModel.TitleAz2;
                    projectAz.MainPlan = projectUpdateViewModel.MainPlanAz;
                    projectAz.ComlexLoc = projectUpdateViewModel.ComlexLocAz;
                    projectAz.BuildingProject = projectUpdateViewModel.BuildingProjectAz;

                    if (!string.IsNullOrEmpty(imageOne) || !string.IsNullOrEmpty(imageTwo) || !string.IsNullOrEmpty(imageThree) || !string.IsNullOrEmpty(imageFour) || !string.IsNullOrEmpty(imageFive) || !string.IsNullOrEmpty(imageSix))
                    {
                        projectAz.ImageOne = imageOne;
                        projectAz.ImageTwo = imageTwo;
                        projectAz.ImageThree = imageThree;
                        projectAz.ImageFour = imageFour;
                        projectAz.ImageFive = imageFive;
                        projectAz.ImageSix = imageSix;
                    }
                    if (!string.IsNullOrEmpty(imageMainOne) || !string.IsNullOrEmpty(imageMainTwo) || !string.IsNullOrEmpty(imageMainThree) || !string.IsNullOrEmpty(imageMainFour) || !string.IsNullOrEmpty(imageMainFive) || !string.IsNullOrEmpty(imageMainSix))
                    {
                        projectAz.MainImageOne = imageMainOne;
                        projectAz.MainImageTwo = imageMainTwo;
                        projectAz.MainImageThree = imageMainThree;
                        projectAz.MainImageFour = imageMainFour;
                        projectAz.MainImageFive = imageMainFive;
                        projectAz.MainImageSix = imageMainSix;
                    }
                    projectAz.MapUrl = projectUpdateViewModel.MapUrl;

                    _db.Projects.Update(projectAz);
                }
                if (projectEng != null)
                {
                    projectEng.Title1 = projectUpdateViewModel.TitleEn1;
                    projectEng.Title2 = projectUpdateViewModel.TitleEn2;
                    projectEng.MainPlan = projectUpdateViewModel.MainPlanEn;
                    projectEng.ComlexLoc = projectUpdateViewModel.ComlexLocEn;
                    projectEng.BuildingProject = projectUpdateViewModel.BuildingProjectEn;

                    if (!string.IsNullOrEmpty(imageOne) || !string.IsNullOrEmpty(imageTwo) || !string.IsNullOrEmpty(imageThree) || !string.IsNullOrEmpty(imageFour) || !string.IsNullOrEmpty(imageFive) || !string.IsNullOrEmpty(imageSix))
                    {
                        projectEng.ImageOne = imageOne;
                        projectEng.ImageTwo = imageTwo;
                        projectEng.ImageThree = imageThree;
                        projectEng.ImageFour = imageFour;
                        projectEng.ImageFive = imageFive;
                        projectEng.ImageSix = imageSix;
                    }
                    if (!string.IsNullOrEmpty(imageMainOne) || !string.IsNullOrEmpty(imageMainTwo) || !string.IsNullOrEmpty(imageMainThree) || !string.IsNullOrEmpty(imageMainFour) || !string.IsNullOrEmpty(imageMainFive) || !string.IsNullOrEmpty(imageMainSix))
                    {
                        projectEng.MainImageOne = imageMainOne;
                        projectEng.MainImageTwo = imageMainTwo;
                        projectEng.MainImageThree = imageMainThree;
                        projectEng.MainImageFour = imageMainFour;
                        projectEng.MainImageFive = imageMainFive;
                        projectEng.MainImageSix = imageMainSix;
                    }
                    projectEng.MapUrl = projectUpdateViewModel.MapUrl;

                    _db.Projects.Update(projectRus);
                }
                if (projectRus != null)
                {
                    projectRus.Title1 = projectUpdateViewModel.TitleRu1;
                    projectRus.Title2 = projectUpdateViewModel.TitleRu2;
                    projectRus.MainPlan = projectUpdateViewModel.MainPlanRu;
                    projectRus.ComlexLoc = projectUpdateViewModel.ComlexLocRu;
                    projectRus.BuildingProject = projectUpdateViewModel.BuildingProjectRu;

                    if (!string.IsNullOrEmpty(imageOne) || !string.IsNullOrEmpty(imageTwo) || !string.IsNullOrEmpty(imageThree) || !string.IsNullOrEmpty(imageFour) || !string.IsNullOrEmpty(imageFive) || !string.IsNullOrEmpty(imageSix))
                    {
                        projectRus.ImageOne = imageOne;
                        projectRus.ImageTwo = imageTwo;
                        projectRus.ImageThree = imageThree;
                        projectRus.ImageFour = imageFour;
                        projectRus.ImageFive = imageFive;
                        projectRus.ImageSix = imageSix;
                    }
                    if (!string.IsNullOrEmpty(imageMainOne) || !string.IsNullOrEmpty(imageMainTwo) || !string.IsNullOrEmpty(imageMainThree) || !string.IsNullOrEmpty(imageMainFour) || !string.IsNullOrEmpty(imageMainFive) || !string.IsNullOrEmpty(imageMainSix))
                    {
                        projectRus.MainImageOne = imageMainOne;
                        projectRus.MainImageTwo = imageMainTwo;
                        projectRus.MainImageThree = imageMainThree;
                        projectRus.MainImageFour = imageMainFour;
                        projectRus.MainImageFive = imageMainFive;
                        projectRus.MainImageSix = imageMainSix;
                    }
                    projectRus.MapUrl = projectUpdateViewModel.MapUrl;

                    _db.Projects.Update(projectRus);
                }

                await _db.SaveChangesAsync();

                _toastNotification.AddSuccessToastMessage("Dəyişiklik edildi!", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat!"
                });

                return RedirectToAction("updateprojectsetting", "statics");
            }

            return View(projectUpdateViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateSellConditionSetting()
        {
            var sellConditions = await _db.SellConditions.Include(sc => sc.Language).ToListAsync();
            if (sellConditions.Count > 0)
            {
                var sellConditionAz = sellConditions.FirstOrDefault(p => p.Language.LanguageCode == "az");
                var sellConditionEng = sellConditions.FirstOrDefault(p => p.Language.LanguageCode == "eng");
                var sellConditionRus = sellConditions.FirstOrDefault(p => p.Language.LanguageCode == "rus");

                Guid languageGroupId = new Guid();

                if (sellConditionAz != null)
                    languageGroupId = sellConditionAz.LanguageGroupId;
                else if (sellConditionEng != null)
                    languageGroupId = sellConditionEng.LanguageGroupId;
                else if (sellConditionRus != null)
                    languageGroupId = sellConditionRus.LanguageGroupId;

                SellConditionUpdateViewModel sellConditionUpdateViewModel = new SellConditionUpdateViewModel()
                {
                    LanguageGroupId = languageGroupId
                };

                if (sellConditionAz != null)
                {
                    sellConditionUpdateViewModel.TitleAz = sellConditionAz.Title;
                    sellConditionUpdateViewModel.DescriptionAz = sellConditionAz.Description;
                }
                if (sellConditionEng != null)
                {
                    sellConditionUpdateViewModel.TitleEn = sellConditionEng.Title;
                    sellConditionUpdateViewModel.DescriptionEn = sellConditionEng.Description;
                }
                if (sellConditionRus != null)
                {
                    sellConditionUpdateViewModel.TitleRu = sellConditionRus.Title;
                    sellConditionUpdateViewModel.DescriptionRu = sellConditionRus.Description;
                }

                return View(sellConditionUpdateViewModel);
            }

            _toastNotification.AddErrorToastMessage("Məlumat tapılmadı!", new ToastrOptions
            {
                Title = "Uğursuz Əməliyyat!"
            });

            return RedirectToAction("updatesellconditionsetting", "statics");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSellConditionSetting(SellConditionUpdateViewModel sellConditionUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                if (sellConditionUpdateViewModel.LanguageGroupId == null)
                    return NotFound();

                var sellConditions = await _db.SellConditions.Where(sc => sc.LanguageGroupId == sellConditionUpdateViewModel.LanguageGroupId).Include(sc => sc.Language).ToListAsync();

                if (sellConditions.Count == 0)
                {
                    _toastNotification.AddErrorToastMessage("Məlumat tapılmadı!", new ToastrOptions
                    {
                        Title = "Uğursuz Əməliyyat!"
                    });

                    return RedirectToAction("updatesellconditionsetting", "statics");
                }

                var sellConditionAz = sellConditions.FirstOrDefault(p => p.Language.LanguageCode == "az");
                var sellConditionEng = sellConditions.FirstOrDefault(p => p.Language.LanguageCode == "eng");
                var sellConditionRus = sellConditions.FirstOrDefault(p => p.Language.LanguageCode == "rus");

                if (sellConditionAz != null)
                {
                    sellConditionAz.Title = sellConditionUpdateViewModel.TitleAz;
                    sellConditionAz.Description = sellConditionUpdateViewModel.DescriptionAz;

                    _db.SellConditions.Update(sellConditionAz);
                }
                if (sellConditionEng != null)
                {
                    sellConditionEng.Title = sellConditionUpdateViewModel.TitleEn;
                    sellConditionEng.Description = sellConditionUpdateViewModel.DescriptionEn;

                    _db.SellConditions.Update(sellConditionEng);
                }
                if (sellConditionRus != null)
                {
                    sellConditionRus.Title = sellConditionUpdateViewModel.TitleRu;
                    sellConditionRus.Description = sellConditionUpdateViewModel.DescriptionRu;

                    _db.SellConditions.Update(sellConditionRus);
                }

                await _db.SaveChangesAsync();

                _toastNotification.AddSuccessToastMessage("Dəyişiklik edildi!", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat!"
                });

                return RedirectToAction("updatesellconditionsetting", "statics");
            }

            return View(sellConditionUpdateViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTravelSetting()
        {
            var travels = await _db.Travels.Include(sc => sc.Language).ToListAsync();
            if (travels.Count > 0)
            {
                var travelAz = travels.FirstOrDefault(p => p.Language.LanguageCode == "az");
                var travelEng = travels.FirstOrDefault(p => p.Language.LanguageCode == "eng");
                var travelRus = travels.FirstOrDefault(p => p.Language.LanguageCode == "rus");

                Guid languageGroupId = new Guid();
                string imageOne = string.Empty, imageTwo = string.Empty, imageThree = string.Empty, imageFour = string.Empty, imageFive = string.Empty, imageSix = string.Empty;

                if (travelAz != null)
                {
                    languageGroupId = travelAz.LanguageGroupId;
                    imageOne = travelAz.ImageOne;
                    imageTwo = travelAz.ImageTwo;
                    imageThree = travelAz.ImageThree;
                    imageFour = travelAz.ImageFour;
                    imageFive = travelAz.ImageFive;
                    imageSix = travelAz.ImageSix;
                }
                else if (travelEng != null)
                {
                    languageGroupId = travelEng.LanguageGroupId;
                    imageOne = travelEng.ImageOne;
                    imageTwo = travelEng.ImageTwo;
                    imageThree = travelEng.ImageThree;
                    imageFour = travelEng.ImageFour;
                    imageFive = travelEng.ImageFive;
                    imageSix = travelEng.ImageSix;
                }
                else if (travelRus != null)
                {
                    languageGroupId = travelRus.LanguageGroupId;
                    imageOne = travelRus.ImageOne;
                    imageTwo = travelRus.ImageTwo;
                    imageThree = travelRus.ImageThree;
                    imageFour = travelRus.ImageFour;
                    imageFive = travelRus.ImageFive;
                    imageSix = travelRus.ImageSix;
                }

                TravelUpdateViewModel travelUpdateViewModel = new TravelUpdateViewModel()
                {
                    LanguageGroupId = languageGroupId,
                    ImageOne = imageOne,
                    ImageTwo = imageTwo,
                    ImageThree = imageThree,
                    ImageFour = imageFour,
                    ImageFive = imageFive,
                    ImageSix = imageSix
                };

                if (travelAz != null)
                {
                    travelUpdateViewModel.TitleAz = travelAz.Title;
                    travelUpdateViewModel.DescriptionAz = travelAz.Description;
                }
                if (travelEng != null)
                {
                    travelUpdateViewModel.TitleEn = travelEng.Title;
                    travelUpdateViewModel.DescriptionEn = travelEng.Description;
                }
                if (travelRus != null)
                {
                    travelUpdateViewModel.TitleRu = travelRus.Title;
                    travelUpdateViewModel.DescriptionRu = travelRus.Description;
                }

                return View(travelUpdateViewModel);
            }

            _toastNotification.AddErrorToastMessage("Məlumat tapılmadı!", new ToastrOptions
            {
                Title = "Uğursuz Əməliyyat!"
            });

            return RedirectToAction("updatetravelsetting", "statics");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTravelSetting(TravelUpdateViewModel travelUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                if (travelUpdateViewModel.LanguageGroupId == null)
                    return NotFound();

                var travels = await _db.Travels.Where(t => t.LanguageGroupId == travelUpdateViewModel.LanguageGroupId).Include(sc => sc.Language).ToListAsync();

                if (travels.Count == 0)
                {
                    _toastNotification.AddErrorToastMessage("Məlumat tapılmadı!", new ToastrOptions
                    {
                        Title = "Uğursuz Əməliyyat!"
                    });

                    return RedirectToAction("updatetravelsetting", "statics");
                }

                var travelAz = travels.FirstOrDefault(p => p.Language.LanguageCode == "az");
                var travelEng = travels.FirstOrDefault(p => p.Language.LanguageCode == "eng");
                var travelRus = travels.FirstOrDefault(p => p.Language.LanguageCode == "rus");

                string imageOne = string.Empty, imageTwo = string.Empty, imageThree = string.Empty, imageFour = string.Empty, imageFive = string.Empty, imageSix = string.Empty;

                if (travelAz != null)
                {
                    imageOne = travelAz.ImageOne;
                    imageTwo = travelAz.ImageTwo;
                    imageThree = travelAz.ImageThree;
                    imageFour = travelAz.ImageFour;
                    imageFive = travelAz.ImageFive;
                    imageSix = travelAz.ImageSix;
                }
                else if (travelEng != null)
                {
                    imageOne = travelEng.ImageOne;
                    imageTwo = travelEng.ImageTwo;
                    imageThree = travelEng.ImageThree;
                    imageFour = travelEng.ImageFour;
                    imageFive = travelEng.ImageFive;
                    imageSix = travelEng.ImageSix;
                }
                else if (travelRus != null)
                {
                    imageOne = travelRus.ImageOne;
                    imageTwo = travelRus.ImageTwo;
                    imageThree = travelRus.ImageThree;
                    imageFour = travelRus.ImageFour;
                    imageFive = travelRus.ImageFive;
                    imageSix = travelRus.ImageSix;
                }

                var oldImageOne = travelUpdateViewModel.ImageOne;
                if (travelUpdateViewModel.ImageFileOne != null)
                {
                    var imageResult = await _imageHelper.Upload("toure_image", travelUpdateViewModel.ImageFileOne, PictureType.Post, "toure");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        imageOne = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImageOne);
                    }
                }
                var oldImageTwo = travelUpdateViewModel.ImageTwo;
                if (travelUpdateViewModel.ImageFileTwo != null)
                {
                    var imageResult = await _imageHelper.Upload("toure_image", travelUpdateViewModel.ImageFileTwo, PictureType.Post, "toure");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        imageTwo = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImageTwo);
                    }
                }
                var oldImageThree = travelUpdateViewModel.ImageThree;
                if (travelUpdateViewModel.ImageFileThree != null)
                {
                    var imageResult = await _imageHelper.Upload("toure_image", travelUpdateViewModel.ImageFileThree, PictureType.Post, "toure");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        imageThree = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImageThree);
                    }
                }
                var oldImageFour = travelUpdateViewModel.ImageFour;
                if (travelUpdateViewModel.ImageFileFour != null)
                {
                    var imageResult = await _imageHelper.Upload("toure_image", travelUpdateViewModel.ImageFileFour, PictureType.Post, "toure");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        imageFour = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImageFour);
                    }
                }
                var oldImageFive = travelUpdateViewModel.ImageFive;
                if (travelUpdateViewModel.ImageFileFive != null)
                {
                    var imageResult = await _imageHelper.Upload("toure_image", travelUpdateViewModel.ImageFileFive, PictureType.Post, "toure");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        imageFive = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImageFive);
                    }
                }
                var oldImageSix = travelUpdateViewModel.ImageSix;
                if (travelUpdateViewModel.ImageFileSix != null)
                {
                    var imageResult = await _imageHelper.Upload("toure_image", travelUpdateViewModel.ImageFileSix, PictureType.Post, "toure");

                    if (imageResult.ResultStatus == ResultStatus.Success)
                    {
                        imageSix = imageResult.Data.FullName;
                        _imageHelper.Delete(oldImageSix);
                    }
                }

                if (travelAz != null)
                {
                    travelAz.Title = travelUpdateViewModel.TitleAz;
                    travelAz.Description = travelUpdateViewModel.DescriptionAz;

                    if (!string.IsNullOrEmpty(imageOne) || !string.IsNullOrEmpty(imageTwo) || !string.IsNullOrEmpty(imageThree) || !string.IsNullOrEmpty(imageFour) || !string.IsNullOrEmpty(imageFive) || !string.IsNullOrEmpty(imageSix))
                    {
                        travelAz.ImageOne = imageOne;
                        travelAz.ImageTwo = imageTwo;
                        travelAz.ImageThree = imageThree;
                        travelAz.ImageFour = imageFour;
                        travelAz.ImageFive = imageFive;
                        travelAz.ImageSix = imageSix;
                    }

                    _db.Travels.Update(travelAz);
                }
                if (travelEng != null)
                {
                    travelEng.Title = travelUpdateViewModel.TitleEn;
                    travelEng.Description = travelUpdateViewModel.DescriptionEn;

                    if (!string.IsNullOrEmpty(imageOne) || !string.IsNullOrEmpty(imageTwo) || !string.IsNullOrEmpty(imageThree) || !string.IsNullOrEmpty(imageFour) || !string.IsNullOrEmpty(imageFive) || !string.IsNullOrEmpty(imageSix))
                    {
                        travelEng.ImageOne = imageOne;
                        travelEng.ImageTwo = imageTwo;
                        travelEng.ImageThree = imageThree;
                        travelEng.ImageFour = imageFour;
                        travelEng.ImageFive = imageFive;
                        travelEng.ImageSix = imageSix;
                    }

                    _db.Travels.Update(travelEng);
                }
                if (travelRus != null)
                {
                    travelRus.Title = travelUpdateViewModel.TitleRu;
                    travelRus.Description = travelUpdateViewModel.DescriptionRu;

                    if (!string.IsNullOrEmpty(imageOne) || !string.IsNullOrEmpty(imageTwo) || !string.IsNullOrEmpty(imageThree) || !string.IsNullOrEmpty(imageFour) || !string.IsNullOrEmpty(imageFive) || !string.IsNullOrEmpty(imageSix))
                    {
                        travelRus.ImageOne = imageOne;
                        travelRus.ImageTwo = imageTwo;
                        travelRus.ImageThree = imageThree;
                        travelRus.ImageFour = imageFour;
                        travelRus.ImageFive = imageFive;
                        travelRus.ImageSix = imageSix;
                    }

                    _db.Travels.Update(travelRus);
                }

                await _db.SaveChangesAsync();

                _toastNotification.AddSuccessToastMessage("Dəyişiklik edildi!", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat!"
                });

                return RedirectToAction("updatetravelsetting", "statics");
            }

            return View(travelUpdateViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTitleAndSubtitle()
        {
            var titleAndSubtitles = await _db.TitleAndSubtitles.Include(ts => ts.Language).ToListAsync();
            if (titleAndSubtitles.Count > 0)
            {
                var titleSubtitleAz = titleAndSubtitles.FirstOrDefault(p => p.Language.LanguageCode == "az");
                var titleSubtitleEng = titleAndSubtitles.FirstOrDefault(p => p.Language.LanguageCode == "eng");
                var titleSubtitleRus = titleAndSubtitles.FirstOrDefault(p => p.Language.LanguageCode == "rus");

                Guid languageGroupId = new Guid();

                if (titleSubtitleAz != null)
                    languageGroupId = titleSubtitleAz.LanguageGroupId;
                if (titleSubtitleEng != null)
                    languageGroupId = titleSubtitleEng.LanguageGroupId;
                if (titleSubtitleRus != null)
                    languageGroupId = titleSubtitleRus.LanguageGroupId;

                TitleAndSubtitleUpdateViewModel titleAndSubtitleUpdateViewModel = new TitleAndSubtitleUpdateViewModel()
                {
                    LanguageGroupId = languageGroupId
                };

                if (titleSubtitleAz != null)
                {
                    titleAndSubtitleUpdateViewModel.TitleAz1 = titleSubtitleAz.Title1;
                    titleAndSubtitleUpdateViewModel.SubtitleAz1 = titleSubtitleAz.Subtitle1;
                    titleAndSubtitleUpdateViewModel.TitleAz2 = titleSubtitleAz.Title2;
                    titleAndSubtitleUpdateViewModel.SubtitleAz2 = titleSubtitleAz.Subtitle2;
                    titleAndSubtitleUpdateViewModel.TitleAz3 = titleSubtitleAz.Title3;
                    titleAndSubtitleUpdateViewModel.SubtitleAz3 = titleSubtitleAz.Subtitle3;
                }
                if (titleSubtitleEng != null)
                {
                    titleAndSubtitleUpdateViewModel.TitleEn1 = titleSubtitleEng.Title1;
                    titleAndSubtitleUpdateViewModel.SubtitleEn1 = titleSubtitleEng.Subtitle1;
                    titleAndSubtitleUpdateViewModel.TitleEn2 = titleSubtitleEng.Title2;
                    titleAndSubtitleUpdateViewModel.SubtitleEn2 = titleSubtitleEng.Subtitle2;
                    titleAndSubtitleUpdateViewModel.TitleEn3 = titleSubtitleEng.Title3;
                    titleAndSubtitleUpdateViewModel.SubtitleEn3 = titleSubtitleEng.Subtitle3;
                }
                if (titleSubtitleRus != null)
                {
                    titleAndSubtitleUpdateViewModel.TitleRu1 = titleSubtitleRus.Title1;
                    titleAndSubtitleUpdateViewModel.SubtitleRu1 = titleSubtitleRus.Subtitle1;
                    titleAndSubtitleUpdateViewModel.TitleRu2 = titleSubtitleRus.Title2;
                    titleAndSubtitleUpdateViewModel.SubtitleRu2 = titleSubtitleRus.Subtitle2;
                    titleAndSubtitleUpdateViewModel.TitleRu3 = titleSubtitleRus.Title3;
                    titleAndSubtitleUpdateViewModel.SubtitleRu3 = titleSubtitleRus.Subtitle3;
                }

                return View(titleAndSubtitleUpdateViewModel);
            }

            _toastNotification.AddErrorToastMessage("Məlumat tapılmadı!", new ToastrOptions
            {
                Title = "Uğursuz Əməliyyat!"
            });

            return RedirectToAction("updatetitleandsubtitle", "statics");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTitleAndSubtitle(TitleAndSubtitleUpdateViewModel titleAndSubtitleUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                if (titleAndSubtitleUpdateViewModel.LanguageGroupId == null)
                    return NotFound();

                var titleAndSubtitles = await _db.TitleAndSubtitles.Where(ts => ts.LanguageGroupId == titleAndSubtitleUpdateViewModel.LanguageGroupId).Include(ts => ts.Language).ToListAsync();

                if (titleAndSubtitles.Count == 0)
                {
                    _toastNotification.AddErrorToastMessage("Məlumat tapılmadı!", new ToastrOptions
                    {
                        Title = "Uğursuz Əməliyyat!"
                    });

                    return RedirectToAction("updatetitleandsubtitle", "statics");
                }

                var titleSubtitleAz = titleAndSubtitles.FirstOrDefault(p => p.Language.LanguageCode == "az");
                var titleSubtitleEng = titleAndSubtitles.FirstOrDefault(p => p.Language.LanguageCode == "eng");
                var titleSubtitleRus = titleAndSubtitles.FirstOrDefault(p => p.Language.LanguageCode == "rus");

                if (titleSubtitleAz != null)
                {
                    titleSubtitleAz.Title1 = titleAndSubtitleUpdateViewModel.TitleAz1;
                    titleSubtitleAz.Subtitle1 = titleAndSubtitleUpdateViewModel.SubtitleAz1;
                    titleSubtitleAz.Title2 = titleAndSubtitleUpdateViewModel.TitleAz2;
                    titleSubtitleAz.Subtitle2 = titleAndSubtitleUpdateViewModel.SubtitleAz2;
                    titleSubtitleAz.Title3 = titleAndSubtitleUpdateViewModel.TitleAz3;
                    titleSubtitleAz.Subtitle3 = titleAndSubtitleUpdateViewModel.SubtitleAz3;

                    _db.TitleAndSubtitles.Update(titleSubtitleAz);
                }
                if (titleSubtitleEng != null)
                {
                    titleSubtitleEng.Title1 = titleAndSubtitleUpdateViewModel.TitleEn1;
                    titleSubtitleEng.Subtitle1 = titleAndSubtitleUpdateViewModel.SubtitleEn1;
                    titleSubtitleEng.Title2 = titleAndSubtitleUpdateViewModel.TitleEn2;
                    titleSubtitleEng.Subtitle2 = titleAndSubtitleUpdateViewModel.SubtitleEn2;
                    titleSubtitleEng.Title3 = titleAndSubtitleUpdateViewModel.TitleEn3;
                    titleSubtitleEng.Subtitle3 = titleAndSubtitleUpdateViewModel.SubtitleEn3;

                    _db.TitleAndSubtitles.Update(titleSubtitleEng);
                }
                if (titleSubtitleRus != null)
                {
                    titleSubtitleRus.Title1 = titleAndSubtitleUpdateViewModel.TitleRu1;
                    titleSubtitleRus.Subtitle1 = titleAndSubtitleUpdateViewModel.SubtitleRu1;
                    titleSubtitleRus.Title2 = titleAndSubtitleUpdateViewModel.TitleRu2;
                    titleSubtitleRus.Subtitle2 = titleAndSubtitleUpdateViewModel.SubtitleRu2;
                    titleSubtitleRus.Title3 = titleAndSubtitleUpdateViewModel.TitleRu3;
                    titleSubtitleRus.Subtitle3 = titleAndSubtitleUpdateViewModel.SubtitleRu3;

                    _db.TitleAndSubtitles.Update(titleSubtitleRus);
                }

                await _db.SaveChangesAsync();

                _toastNotification.AddSuccessToastMessage("Dəyişiklik edildi!", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat!"
                });

                return RedirectToAction("updatetitleandsubtitle", "statics");
            }

            return View(titleAndSubtitleUpdateViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia()
        {
            var socialMedia = await _db.SocialMedias.FirstOrDefaultAsync();
            if (socialMedia != null)
            {
                var languages = await _db.Languages.ToListAsync();
                var socialMediaUpdateViewModel = new SocialMediaUpdateViewModel
                {
                    Id = socialMedia.Id,
                    PhoneNumber = socialMedia.PhoneNumber,
                    WhatsappUrl = socialMedia.WhatsappUrl,
                    InstagramUrl = socialMedia.InstagramUrl,
                    FacebookUrl = socialMedia.FacebookUrl,
                    YoutubeUrl = socialMedia.YoutubeUrl
                };

                return View(socialMediaUpdateViewModel);
            }

            _toastNotification.AddErrorToastMessage("Məlumat tapılmadı!", new ToastrOptions
            {
                Title = "Uğursuz Əməliyyat!"
            });

            return RedirectToAction("updatesocialmedia", "statics");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSocialMedia(SocialMediaUpdateViewModel socialMediaUpdateViewModel)
        {
            var socialMedia = await _db.SocialMedias.FirstOrDefaultAsync(hp => hp.Id == socialMediaUpdateViewModel.Id);
            if (socialMedia != null)
            {
                socialMedia.PhoneNumber = socialMediaUpdateViewModel.PhoneNumber;
                socialMedia.WhatsappUrl = socialMediaUpdateViewModel.WhatsappUrl;
                socialMedia.InstagramUrl = socialMediaUpdateViewModel.InstagramUrl;
                socialMedia.FacebookUrl = socialMediaUpdateViewModel.FacebookUrl;
                socialMedia.YoutubeUrl = socialMediaUpdateViewModel.YoutubeUrl;
                _db.SocialMedias.Update(socialMedia);
                await _db.SaveChangesAsync();

                _toastNotification.AddSuccessToastMessage("Dəyişiklik edildi!", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat!"
                });

                return RedirectToAction("updatesocialmedia", "statics");
            }

            _toastNotification.AddErrorToastMessage("Məlumat tapılmadı!", new ToastrOptions
            {
                Title = "Uğursuz Əməliyyat!"
            });

            return RedirectToAction("updatesocialmedia", "statics");
        }
    }
}
