using IlisuHiltopHeaven.Data.Concrete.EntityFramework.Context;
using IlisuHiltopHeaven.Presentation.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Presentation.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IlisuHiltopHeavenContext _db;

        public ServicesController(IlisuHiltopHeavenContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var servicesAz = await _db.Services.Include(s => s.ServiceAdvantages).Include(s => s.ServiceHiltopAdvantages).Where(s => s.Language.LanguageCode == "az").ToListAsync();
            var servicesEng = await _db.Services.Include(s => s.ServiceAdvantages).Include(s => s.ServiceHiltopAdvantages).Where(s => s.Language.LanguageCode == "eng").ToListAsync();
            var servicesRus = await _db.Services.Include(s => s.ServiceAdvantages).Include(s => s.ServiceHiltopAdvantages).Where(s => s.Language.LanguageCode == "rus").ToListAsync();
            var advantagesAz = await _db.Advantages.Where(s => s.Language.LanguageCode == "az").ToListAsync();
            var advantagesEng = await _db.Advantages.Where(s => s.Language.LanguageCode == "eng").ToListAsync();
            var advantagesRus = await _db.Advantages.Where(s => s.Language.LanguageCode == "rus").ToListAsync();
            var offices = await _db.Offices.Include(o => o.Language).ToListAsync();
            var homePages = await _db.HomePages.Include(hp => hp.Language).Where(hp => hp.PageName == "services").ToListAsync();
            var socialMedias = await _db.SocialMedias.FirstAsync();
            var titlesAndSubtitles = await _db.TitleAndSubtitles.Include(o => o.Language).ToListAsync();
            var advantagesHiltop = await _db.AdvantageHilltops.Include(o => o.Language).ToListAsync();

            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = rqf.RequestCulture.Culture;

            ServicesViewModel servicesViewModel = new ServicesViewModel();
            servicesViewModel.SocialMedia = socialMedias;
            if (culture.Name.StartsWith("az"))
            {
                servicesViewModel.Services = servicesAz;
                servicesViewModel.Advantages = advantagesAz;
                servicesViewModel.Offices = offices.Where(o => o.Language.LanguageCode == "az").ToList();
                servicesViewModel.HomePages = homePages.Where(o => o.Language.LanguageCode == "az").FirstOrDefault();
                servicesViewModel.TitleAndSubtitle = titlesAndSubtitles.FirstOrDefault(tsb => tsb.Language.LanguageCode == "az");
                servicesViewModel.AdvantageHiltops = advantagesHiltop.Where(s => s.Language.LanguageCode == "az").ToList();
            }
            if (culture.Name.StartsWith("en"))
            {
                servicesViewModel.Services = servicesEng;
                servicesViewModel.Advantages = advantagesEng;
                servicesViewModel.Offices = offices.Where(o => o.Language.LanguageCode == "eng").ToList();
                servicesViewModel.HomePages = homePages.Where(o => o.Language.LanguageCode == "eng").FirstOrDefault();
                servicesViewModel.TitleAndSubtitle = titlesAndSubtitles.FirstOrDefault(tsb => tsb.Language.LanguageCode == "eng");
                servicesViewModel.AdvantageHiltops = advantagesHiltop.Where(s => s.Language.LanguageCode == "eng").ToList();
            }
            if (culture.Name.StartsWith("ru"))
            {
                servicesViewModel.Services = servicesRus;
                servicesViewModel.Advantages = advantagesRus;
                servicesViewModel.Offices = offices.Where(o => o.Language.LanguageCode == "rus").ToList();
                servicesViewModel.HomePages = homePages.Where(o => o.Language.LanguageCode == "rus").FirstOrDefault();
                servicesViewModel.TitleAndSubtitle = titlesAndSubtitles.FirstOrDefault(tsb => tsb.Language.LanguageCode == "rus");
                servicesViewModel.AdvantageHiltops = advantagesHiltop.Where(s => s.Language.LanguageCode == "rus").ToList();
            }

            return View(servicesViewModel);
        }
    }
}
