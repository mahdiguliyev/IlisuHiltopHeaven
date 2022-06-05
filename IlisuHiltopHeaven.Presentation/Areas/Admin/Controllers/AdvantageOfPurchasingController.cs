using IlisuHiltopHeaven.Data.Concrete.EntityFramework.Context;
using IlisuHiltopHeaven.Presentation.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
    public class AdvantageOfPurchasingController : Controller
    {
        private readonly IlisuHiltopHeavenContext _db;
        private readonly IToastNotification _toastNotification;
        public AdvantageOfPurchasingController(IlisuHiltopHeavenContext db, IToastNotification toastNotification)
        {
            _db = db;
            _toastNotification = toastNotification;
        }
        //public async Task<ActionResult> Index()
        //{
        //    var advantageOfPurchasings = await _db.AdvantageOfPurchasings.Where(o => o.Language.LanguageCode == "az").Include(s => s.Language).ToListAsync();

        //    if (advantageOfPurchasings != null)
        //    {
        //        AdvantageOfPurchasingViewModel advantageOfPurchasingViewModel = new AdvantageOfPurchasingViewModel
        //        {
        //            AdvantageOfPurchasings = advantageOfPurchasings
        //        };

        //        return View(advantageOfPurchasingViewModel);
        //    }

        //    return NotFound();
        //}
        [HttpGet]
        public async Task<IActionResult> Update()
        {
            var advantageOfPurchasings = await _db.AdvantageOfPurchasings.Include(o => o.Language).ToListAsync();
            if (advantageOfPurchasings.Count > 0)
            {
                var advantageOfPurchasingAz = advantageOfPurchasings.FirstOrDefault(hp => hp.Language.LanguageCode == "az");
                var advantageOfPurchasingEn = advantageOfPurchasings.FirstOrDefault(hp => hp.Language.LanguageCode == "eng");
                var advantageOfPurchasingRu = advantageOfPurchasings.FirstOrDefault(hp => hp.Language.LanguageCode == "rus");

                Guid languageGroupId = new Guid();
                string imageOne = string.Empty, imageTwo = string.Empty, imageThree = string.Empty;

                if (advantageOfPurchasingAz != null)
                {
                    languageGroupId = advantageOfPurchasingAz.LanguageGroupId;
                    imageOne = advantageOfPurchasingAz.Image1;
                    imageTwo = advantageOfPurchasingAz.Image2;
                    imageThree = advantageOfPurchasingAz.Image3;
                }
                else if(advantageOfPurchasingEn != null)
                {
                    languageGroupId = advantageOfPurchasingEn.LanguageGroupId;
                    imageOne = advantageOfPurchasingEn.Image1;
                    imageTwo = advantageOfPurchasingEn.Image2;
                    imageThree = advantageOfPurchasingEn.Image3;
                }
                else if(advantageOfPurchasingRu != null)
                {
                    languageGroupId = advantageOfPurchasingRu.LanguageGroupId;
                    imageOne = advantageOfPurchasingRu.Image1;
                    imageTwo = advantageOfPurchasingRu.Image2;
                    imageThree = advantageOfPurchasingRu.Image3;
                }

                AdvantageOfPurchasingUpdateViewModel advantageUpdateViewModel = new AdvantageOfPurchasingUpdateViewModel()
                {
                    LanguageGroupId = languageGroupId,
                    Image1 = imageOne,
                    Image2 = imageTwo,
                    Image3 = imageThree
                };

                if (advantageOfPurchasingAz != null)
                {
                    advantageUpdateViewModel.MainTitle = advantageOfPurchasingAz.MainTitle;
                    advantageUpdateViewModel.Title1 = advantageOfPurchasingAz.Title1;
                    advantageUpdateViewModel.Description1 = advantageOfPurchasingAz.Description1;
                    advantageUpdateViewModel.Title2 = advantageOfPurchasingAz.Title2;
                    advantageUpdateViewModel.Description2 = advantageOfPurchasingAz.Description2;
                    advantageUpdateViewModel.Title3 = advantageOfPurchasingAz.Title3;
                    advantageUpdateViewModel.Description3 = advantageOfPurchasingAz.Description3;
                }
                if (advantageOfPurchasingEn != null)
                {
                    advantageUpdateViewModel.MainTitleEn = advantageOfPurchasingEn.MainTitle;
                    advantageUpdateViewModel.TitleEn1 = advantageOfPurchasingEn.Title1;
                    advantageUpdateViewModel.DescriptionEn1 = advantageOfPurchasingEn.Description1;
                    advantageUpdateViewModel.TitleEn2 = advantageOfPurchasingEn.Title2;
                    advantageUpdateViewModel.DescriptionEn2 = advantageOfPurchasingEn.Description2;
                    advantageUpdateViewModel.TitleEn3 = advantageOfPurchasingEn.Title3;
                    advantageUpdateViewModel.DescriptionEn3 = advantageOfPurchasingEn.Description3;
                }
                if (advantageOfPurchasingRu != null)
                {
                    advantageUpdateViewModel.MainTitleRu = advantageOfPurchasingRu.MainTitle;
                    advantageUpdateViewModel.TitleRu1 = advantageOfPurchasingRu.Title1;
                    advantageUpdateViewModel.DescriptionRu1 = advantageOfPurchasingRu.Description1;
                    advantageUpdateViewModel.TitleRu2 = advantageOfPurchasingRu.Title2;
                    advantageUpdateViewModel.DescriptionRu2 = advantageOfPurchasingRu.Description2;
                    advantageUpdateViewModel.TitleRu3 = advantageOfPurchasingRu.Title3;
                    advantageUpdateViewModel.DescriptionRu3 = advantageOfPurchasingRu.Description3;
                }

                return View(advantageUpdateViewModel);
            }

            _toastNotification.AddErrorToastMessage("Məlumat tapılmadı!", new ToastrOptions
            {
                Title = "Uğursuz Əməliyyat!"
            });

            return RedirectToAction("index", "home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AdvantageOfPurchasingUpdateViewModel advantageOfPurchasingUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                if (advantageOfPurchasingUpdateViewModel.LanguageGroupId == null)
                    return NotFound();

                var advantageOfPurchasings = await _db.AdvantageOfPurchasings.Where(ap => ap.LanguageGroupId == advantageOfPurchasingUpdateViewModel.LanguageGroupId).Include(o => o.Language).ToListAsync();

                if (advantageOfPurchasings.Count == 0)
                {
                    _toastNotification.AddErrorToastMessage("Məlumat tapılmadı!", new ToastrOptions
                    {
                        Title = "Uğursuz Əməliyyat!"
                    });

                    return RedirectToAction("index", "home");
                }

                var advantageOfPurchasingAz = advantageOfPurchasings.FirstOrDefault(hp => hp.Language.LanguageCode == "az");
                var advantageOfPurchasingEn = advantageOfPurchasings.FirstOrDefault(hp => hp.Language.LanguageCode == "eng");
                var advantageOfPurchasingRu = advantageOfPurchasings.FirstOrDefault(hp => hp.Language.LanguageCode == "rus");

                if (advantageOfPurchasingAz != null)
                {
                    advantageOfPurchasingAz.MainTitle = advantageOfPurchasingUpdateViewModel.MainTitle;
                    advantageOfPurchasingAz.Title1 = advantageOfPurchasingUpdateViewModel.Title1;
                    advantageOfPurchasingAz.Description1 = advantageOfPurchasingUpdateViewModel.Description1;
                    advantageOfPurchasingAz.Title2 = advantageOfPurchasingUpdateViewModel.Title2;
                    advantageOfPurchasingAz.Description2 = advantageOfPurchasingUpdateViewModel.Description2;
                    advantageOfPurchasingAz.Title3 = advantageOfPurchasingUpdateViewModel.Title3;
                    advantageOfPurchasingAz.Description3 = advantageOfPurchasingUpdateViewModel.Description3;

                    _db.AdvantageOfPurchasings.Update(advantageOfPurchasingAz);
                }
                if (advantageOfPurchasingEn != null)
                {
                    advantageOfPurchasingEn.MainTitle = advantageOfPurchasingUpdateViewModel.MainTitleEn;
                    advantageOfPurchasingEn.Title1 = advantageOfPurchasingUpdateViewModel.TitleEn1;
                    advantageOfPurchasingEn.Description1 = advantageOfPurchasingUpdateViewModel.DescriptionEn1;
                    advantageOfPurchasingEn.Title2 = advantageOfPurchasingUpdateViewModel.TitleEn2;
                    advantageOfPurchasingEn.Description2 = advantageOfPurchasingUpdateViewModel.DescriptionEn2;
                    advantageOfPurchasingEn.Title3 = advantageOfPurchasingUpdateViewModel.TitleEn3;
                    advantageOfPurchasingEn.Description3 = advantageOfPurchasingUpdateViewModel.DescriptionEn3;

                    _db.AdvantageOfPurchasings.Update(advantageOfPurchasingEn);
                }
                if (advantageOfPurchasingRu != null)
                {
                    advantageOfPurchasingRu.MainTitle = advantageOfPurchasingUpdateViewModel.MainTitleRu;
                    advantageOfPurchasingRu.Title1 = advantageOfPurchasingUpdateViewModel.TitleRu1;
                    advantageOfPurchasingRu.Description1 = advantageOfPurchasingUpdateViewModel.DescriptionRu1;
                    advantageOfPurchasingRu.Title2 = advantageOfPurchasingUpdateViewModel.TitleRu2;
                    advantageOfPurchasingRu.Description2 = advantageOfPurchasingUpdateViewModel.DescriptionRu2;
                    advantageOfPurchasingRu.Title3 = advantageOfPurchasingUpdateViewModel.TitleRu3;
                    advantageOfPurchasingRu.Description3 = advantageOfPurchasingUpdateViewModel.DescriptionRu3;

                    _db.AdvantageOfPurchasings.Update(advantageOfPurchasingRu);
                }
                
                await _db.SaveChangesAsync();

                _toastNotification.AddSuccessToastMessage("Dəyişiklik edildi!", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat!"
                });

                return RedirectToAction("index", "home");
            }

            var languages = await _db.Languages.ToListAsync();
            advantageOfPurchasingUpdateViewModel.Languages = languages;

            return View(advantageOfPurchasingUpdateViewModel);
        }
    }
}
