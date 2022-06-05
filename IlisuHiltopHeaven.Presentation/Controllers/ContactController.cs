using IlisuHiltopHeaven.Data.Concrete.EntityFramework.Context;
using IlisuHiltopHeaven.Entities.Concrete;
using IlisuHiltopHeaven.Presentation.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Presentation.Controllers
{
    public class ContactController : Controller
    {
        private readonly IlisuHiltopHeavenContext _db;
        private readonly IToastNotification _toastNotification;
        public ContactController(IlisuHiltopHeavenContext db, IToastNotification toastNotification)
        {
            _db = db;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            var offices = await _db.Offices.Include(o => o.Language).ToListAsync();
            var homePages = await _db.HomePages.Include(hp => hp.Language).Where(hp => hp.PageName == "contact").ToListAsync();
            var socialMedias = await _db.SocialMedias.FirstOrDefaultAsync();
            var mainOffice = await _db.Offices.Include(o => o.Language).Where(o => o.IsMain == true).ToListAsync();

            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = rqf.RequestCulture.Culture;

            ContactViewModel contactViewModel = new ContactViewModel();
            contactViewModel.SocialMedia = socialMedias;
            if (culture.Name.StartsWith("az"))
            {
                contactViewModel.Offices = offices.Where(o => o.Language.LanguageCode == "az").ToList();
                contactViewModel.HomePages = homePages.Where(o => o.Language.LanguageCode == "az").FirstOrDefault();
                contactViewModel.MainOffice = mainOffice.Where(o => o.Language.LanguageCode == "az").FirstOrDefault();
            }
            if (culture.Name.StartsWith("en"))
            {
                contactViewModel.Offices = offices.Where(o => o.Language.LanguageCode == "eng").ToList();
                contactViewModel.HomePages = homePages.Where(o => o.Language.LanguageCode == "eng").FirstOrDefault();
                contactViewModel.MainOffice = mainOffice.Where(o => o.Language.LanguageCode == "eng").FirstOrDefault();
            }
            if (culture.Name.StartsWith("ru"))
            {
                contactViewModel.Offices = offices.Where(o => o.Language.LanguageCode == "rus").ToList();
                contactViewModel.HomePages = homePages.Where(o => o.Language.LanguageCode == "rus").FirstOrDefault();
                contactViewModel.MainOffice = mainOffice.Where(o => o.Language.LanguageCode == "rus").FirstOrDefault();
            }

            return View(contactViewModel);
        }
    }
}
