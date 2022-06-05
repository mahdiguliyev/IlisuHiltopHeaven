using IlisuHiltopHeaven.Data.Concrete.EntityFramework.Context;
using IlisuHiltopHeaven.Entities.Concrete;
using IlisuHiltopHeaven.Presentation.Models;
using IlisuHiltopHeaven.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IlisuHiltopHeavenContext _db;
        private readonly IToastNotification _toastNotification;
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly IWebHostEnvironment _env;
        public HomeController(ILogger<HomeController> logger, IlisuHiltopHeavenContext db, IToastNotification toastNotification, IStringLocalizer<HomeController> localizer, IWebHostEnvironment env)
        {
            _logger = logger;
            _db = db;
            _toastNotification = toastNotification;
            _localizer = localizer;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var hpinformationsAz = await _db.HomePageInformations.Where(hpi => hpi.Language.LanguageCode == "az").ToListAsync();
            var hpinformationsEng = await _db.HomePageInformations.Where(hpi => hpi.Language.LanguageCode == "eng").ToListAsync();
            var hpinformationsRus = await _db.HomePageInformations.Where(hpi => hpi.Language.LanguageCode == "rus").ToListAsync();
            var homePages = await _db.HomePages.Include(hp => hp.Language).ToListAsync();
            var banners = await _db.Banners.Include(hp => hp.Language).ToListAsync();
            var sellConditions = await _db.SellConditions.Include(sc => sc.Language).ToListAsync();
            var offices = await _db.Offices.Include(o => o.Language).ToListAsync();
            var advantageOfPurchasings = await _db.AdvantageOfPurchasings.Include(o => o.Language).ToListAsync();
            var conditionOfPurchasings = await _db.ConditionsOfPurchasings.Include(o => o.Language).ToListAsync();
            var titlesAndSubtitles = await _db.TitleAndSubtitles.Include(o => o.Language).ToListAsync();
            var socialMedias = await _db.SocialMedias.FirstAsync();
            var services = await _db.Services.Include(o => o.Language).ToListAsync();
            var housingProject = await _db.HousingProjects.Include(o => o.Language).ToListAsync();
            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = rqf.RequestCulture.Culture;

            HomePageViewModel homePageViewModel = new HomePageViewModel();
            homePageViewModel.SocialMedia = socialMedias;
            if (culture.Name.StartsWith("az"))
            {
                homePageViewModel.HomePageInformation = hpinformationsAz;
                homePageViewModel.HomePages = homePages.Where(hp => hp.Language.LanguageCode == "az" && hp.PageName == "homepage").ToList();
                homePageViewModel.Banners = banners.Where(b => b.Language.LanguageCode == "az").ToList();
                homePageViewModel.SellConditions = sellConditions.Where(sc => sc.Language.LanguageCode == "az").ToList();
                homePageViewModel.Offices = offices.Where(o => o.Language.LanguageCode == "az").ToList();
                homePageViewModel.AdvantageOfPurchasings = advantageOfPurchasings.Where(o => o.Language.LanguageCode == "az").ToList();
                homePageViewModel.ConditionsOfPurchasings = conditionOfPurchasings.Where(o => o.Language.LanguageCode == "az").ToList();
                homePageViewModel.TitleAndSubtitle = titlesAndSubtitles.FirstOrDefault(tsb => tsb.Language.LanguageCode == "az");
                homePageViewModel.Services = services.Where(o => o.Language.LanguageCode == "az").ToList();
                homePageViewModel.HousingProjects = housingProject.Where(o => o.Language.LanguageCode == "az").ToList();
            }
            if (culture.Name.StartsWith("en"))
            {
                homePageViewModel.HomePageInformation = hpinformationsEng;
                homePageViewModel.HomePages = homePages.Where(hp => hp.Language.LanguageCode == "eng" && hp.PageName == "homepage").ToList();
                homePageViewModel.Banners = banners.Where(b => b.Language.LanguageCode == "eng").ToList();
                homePageViewModel.SellConditions = sellConditions.Where(sc => sc.Language.LanguageCode == "eng").ToList();
                homePageViewModel.Offices = offices.Where(o => o.Language.LanguageCode == "eng").ToList();
                homePageViewModel.AdvantageOfPurchasings = advantageOfPurchasings.Where(o => o.Language.LanguageCode == "eng").ToList();
                homePageViewModel.ConditionsOfPurchasings = conditionOfPurchasings.Where(o => o.Language.LanguageCode == "eng").ToList();
                homePageViewModel.TitleAndSubtitle = titlesAndSubtitles.FirstOrDefault(tsb => tsb.Language.LanguageCode == "eng");
                homePageViewModel.Services = services.Where(o => o.Language.LanguageCode == "eng").ToList();
                homePageViewModel.HousingProjects = housingProject.Where(o => o.Language.LanguageCode == "eng").ToList();
            }
            if (culture.Name.StartsWith("ru"))
            {
                homePageViewModel.HomePageInformation = hpinformationsRus;
                homePageViewModel.HomePages = homePages.Where(hp => hp.Language.LanguageCode == "rus" && hp.PageName == "homepage").ToList();
                homePageViewModel.Banners = banners.Where(b => b.Language.LanguageCode == "rus").ToList();
                homePageViewModel.SellConditions = sellConditions.Where(sc => sc.Language.LanguageCode == "rus").ToList();
                homePageViewModel.Offices = offices.Where(o => o.Language.LanguageCode == "rus").ToList();
                homePageViewModel.AdvantageOfPurchasings = advantageOfPurchasings.Where(o => o.Language.LanguageCode == "rus").ToList();
                homePageViewModel.ConditionsOfPurchasings = conditionOfPurchasings.Where(o => o.Language.LanguageCode == "rus").ToList();
                homePageViewModel.TitleAndSubtitle = titlesAndSubtitles.FirstOrDefault(tsb => tsb.Language.LanguageCode == "rus");
                homePageViewModel.Services = services.Where(o => o.Language.LanguageCode == "rus").ToList();
                homePageViewModel.HousingProjects = housingProject.Where(o => o.Language.LanguageCode == "rus").ToList();
            }

            return View(homePageViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> OrderCall(string phoneNumber)
        {
            if (phoneNumber != null)
            {

                Contact contact = new Contact
                {
                    PhoneNumber = phoneNumber,
                };

                await _db.Contacts.AddAsync(contact);
                await _db.SaveChangesAsync();

                //_toastNotification.AddSuccessToastMessage("*Zəng sifariş edildi!</br> *Call is ordered successfully!</br> *Звонок заказан успешно!", new ToastrOptions{});

                //return RedirectToAction("index", "home");
            }

            _toastNotification.AddErrorToastMessage("*Prefiks və mobil nömrə boş ola bilməz!</br> *Prefix and phone number cannot be null!</br> *Префикс и номер телефона не могут быть нулевыми!", new ToastrOptions{});
            return RedirectToAction("index", "home");
        }
        public FileContentResult Download()
        {
            var filename = "katalog.pdf";
            var filepath = _env.WebRootPath + "\\katalog\\" + filename;

            byte[] fileName = System.IO.File.ReadAllBytes(filepath);
            if (!System.IO.File.Exists(filepath))
            {
                ViewData["filenotfound"] = "Fayl tapılmadı!";

                return new FileContentResult(fileName, "application/pdf");
            }

            var result = new FileContentResult(fileName, "application/pdf")
            {
                FileDownloadName = "katalog.pdf"
            };

            return result;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
