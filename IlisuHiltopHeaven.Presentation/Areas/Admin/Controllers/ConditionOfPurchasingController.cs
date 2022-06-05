using IlisuHiltopHeaven.Data.Concrete.EntityFramework.Context;
using IlisuHiltopHeaven.Presentation.Areas.Admin.Models;
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
    public class ConditionOfPurchasingController : Controller
    {
        private readonly IlisuHiltopHeavenContext _db;
        private readonly IToastNotification _toastNotification;
        public ConditionOfPurchasingController(IlisuHiltopHeavenContext db, IToastNotification toastNotification)
        {
            _db = db;
            _toastNotification = toastNotification;
        }
        //public async Task<ActionResult> Index()
        //{
        //    var conditionOfPurchasings = await _db.ConditionsOfPurchasings.Where(o => o.Language.LanguageCode == "az").Include(s => s.Language).ToListAsync();

        //    if (conditionOfPurchasings != null)
        //    {
        //        ConditionOfPurchasingViewModel conditionOfPurchasingViewModel = new ConditionOfPurchasingViewModel
        //        {
        //            ConditionsOfPurchasings = conditionOfPurchasings
        //        };

        //        return View(conditionOfPurchasingViewModel);
        //    }

        //    return NotFound();
        //}
        [HttpGet]
        public async Task<IActionResult> Update()
        {
            var conditionOfPurchasings = await _db.ConditionsOfPurchasings.Include(o => o.Language).ToListAsync();
            if (conditionOfPurchasings.Count > 0)
            {
                var advantageOfPurchasingAz = conditionOfPurchasings.FirstOrDefault(hp => hp.Language.LanguageCode == "az");
                var advantageOfPurchasingEn = conditionOfPurchasings.FirstOrDefault(hp => hp.Language.LanguageCode == "eng");
                var advantageOfPurchasingRu = conditionOfPurchasings.FirstOrDefault(hp => hp.Language.LanguageCode == "rus");

                Guid languageGroupId = new Guid();
                string imageOne = string.Empty, imageTwo = string.Empty, imageThree = string.Empty;

                if (advantageOfPurchasingAz != null)
                {
                    languageGroupId = advantageOfPurchasingAz.LanguageGroupId;
                    imageOne = advantageOfPurchasingAz.Image1;
                    imageTwo = advantageOfPurchasingAz.Image2;
                    imageThree = advantageOfPurchasingAz.Image3;
                }
                else if (advantageOfPurchasingEn != null)
                {
                    languageGroupId = advantageOfPurchasingEn.LanguageGroupId;
                    imageOne = advantageOfPurchasingEn.Image1;
                    imageTwo = advantageOfPurchasingEn.Image2;
                    imageThree = advantageOfPurchasingEn.Image3;
                }
                else if (advantageOfPurchasingRu != null)
                {
                    languageGroupId = advantageOfPurchasingRu.LanguageGroupId;
                    imageOne = advantageOfPurchasingRu.Image1;
                    imageTwo = advantageOfPurchasingRu.Image2;
                    imageThree = advantageOfPurchasingRu.Image3;
                }

                ConditionOfPurchasingUpdateViewModel conditionUpdateViewModel = new ConditionOfPurchasingUpdateViewModel()
                {
                    LanguageGroupId = languageGroupId,
                    Image = imageOne,
                    Image2 = imageTwo,
                    Image3 = imageThree
                };

                if (advantageOfPurchasingAz != null)
                {
                    conditionUpdateViewModel.MainTitleAz = advantageOfPurchasingAz.MainTitle;
                    conditionUpdateViewModel.TitleAz1 = advantageOfPurchasingAz.Title1;
                    conditionUpdateViewModel.DescriptionAz1 = advantageOfPurchasingAz.Description1;
                    conditionUpdateViewModel.TitleAz2 = advantageOfPurchasingAz.Title2;
                    conditionUpdateViewModel.DescriptionAz2 = advantageOfPurchasingAz.Description2;
                    conditionUpdateViewModel.TitleAz3 = advantageOfPurchasingAz.Title3;
                    conditionUpdateViewModel.DescriptionAz3 = advantageOfPurchasingAz.Description3;
                }
                if (advantageOfPurchasingEn != null)
                {
                    conditionUpdateViewModel.MainTitleEn = advantageOfPurchasingEn.MainTitle;
                    conditionUpdateViewModel.TitleEn1 = advantageOfPurchasingEn.Title1;
                    conditionUpdateViewModel.DescriptionEn1 = advantageOfPurchasingEn.Description1;
                    conditionUpdateViewModel.TitleEn2 = advantageOfPurchasingEn.Title2;
                    conditionUpdateViewModel.DescriptionEn2 = advantageOfPurchasingEn.Description2;
                    conditionUpdateViewModel.TitleEn3 = advantageOfPurchasingEn.Title3;
                    conditionUpdateViewModel.DescriptionEn3 = advantageOfPurchasingEn.Description3;
                }
                if (advantageOfPurchasingRu != null)
                {
                    conditionUpdateViewModel.MainTitleRu = advantageOfPurchasingRu.MainTitle;
                    conditionUpdateViewModel.TitleRu1 = advantageOfPurchasingRu.Title1;
                    conditionUpdateViewModel.DescriptionRu1 = advantageOfPurchasingRu.Description1;
                    conditionUpdateViewModel.TitleRu2 = advantageOfPurchasingRu.Title2;
                    conditionUpdateViewModel.DescriptionRu2 = advantageOfPurchasingRu.Description2;
                    conditionUpdateViewModel.TitleRu3 = advantageOfPurchasingRu.Title3;
                    conditionUpdateViewModel.DescriptionRu3 = advantageOfPurchasingRu.Description3;
                }

                return View(conditionUpdateViewModel);
            }

            _toastNotification.AddErrorToastMessage("Məlumat tapılmadı!", new ToastrOptions
            {
                Title = "Uğursuz Əməliyyat!"
            });

            return RedirectToAction("index", "home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ConditionOfPurchasingUpdateViewModel conditionOfPurchasingUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                if (conditionOfPurchasingUpdateViewModel.LanguageGroupId == null)
                    return NotFound();

                var conditionOfPurchasings = await _db.ConditionsOfPurchasings.Where(ap => ap.LanguageGroupId == conditionOfPurchasingUpdateViewModel.LanguageGroupId).Include(o => o.Language).ToListAsync();

                if (conditionOfPurchasings.Count == 0)
                {
                    _toastNotification.AddErrorToastMessage("Məlumat tapılmadı!", new ToastrOptions
                    {
                        Title = "Uğursuz Əməliyyat!"
                    });

                    return RedirectToAction("index", "home");
                }

                var advantageOfPurchasingAz = conditionOfPurchasings.FirstOrDefault(hp => hp.Language.LanguageCode == "az");
                var advantageOfPurchasingEn = conditionOfPurchasings.FirstOrDefault(hp => hp.Language.LanguageCode == "eng");
                var advantageOfPurchasingRu = conditionOfPurchasings.FirstOrDefault(hp => hp.Language.LanguageCode == "rus");

                if (advantageOfPurchasingAz != null)
                {
                    advantageOfPurchasingAz.MainTitle = conditionOfPurchasingUpdateViewModel.MainTitleAz;
                    advantageOfPurchasingAz.Title1 = conditionOfPurchasingUpdateViewModel.TitleAz1;
                    advantageOfPurchasingAz.Description1 = conditionOfPurchasingUpdateViewModel.DescriptionAz1;
                    advantageOfPurchasingAz.Title2 = conditionOfPurchasingUpdateViewModel.TitleAz2;
                    advantageOfPurchasingAz.Description2 = conditionOfPurchasingUpdateViewModel.DescriptionAz2;
                    advantageOfPurchasingAz.Title3 = conditionOfPurchasingUpdateViewModel.TitleAz3;
                    advantageOfPurchasingAz.Description3 = conditionOfPurchasingUpdateViewModel.DescriptionAz3;

                    _db.ConditionsOfPurchasings.Update(advantageOfPurchasingAz);
                }
                if (advantageOfPurchasingEn != null)
                {
                    advantageOfPurchasingEn.MainTitle = conditionOfPurchasingUpdateViewModel.MainTitleEn;
                    advantageOfPurchasingEn.Title1 = conditionOfPurchasingUpdateViewModel.TitleEn1;
                    advantageOfPurchasingEn.Description1 = conditionOfPurchasingUpdateViewModel.DescriptionEn1;
                    advantageOfPurchasingEn.Title2 = conditionOfPurchasingUpdateViewModel.TitleEn2;
                    advantageOfPurchasingEn.Description2 = conditionOfPurchasingUpdateViewModel.DescriptionEn2;
                    advantageOfPurchasingEn.Title3 = conditionOfPurchasingUpdateViewModel.TitleEn3;
                    advantageOfPurchasingEn.Description3 = conditionOfPurchasingUpdateViewModel.DescriptionEn3;

                    _db.ConditionsOfPurchasings.Update(advantageOfPurchasingEn);
                }
                if (advantageOfPurchasingRu != null)
                {
                    advantageOfPurchasingRu.MainTitle = conditionOfPurchasingUpdateViewModel.MainTitleRu;
                    advantageOfPurchasingRu.Title1 = conditionOfPurchasingUpdateViewModel.TitleRu1;
                    advantageOfPurchasingRu.Description1 = conditionOfPurchasingUpdateViewModel.DescriptionRu1;
                    advantageOfPurchasingRu.Title2 = conditionOfPurchasingUpdateViewModel.TitleRu2;
                    advantageOfPurchasingRu.Description2 = conditionOfPurchasingUpdateViewModel.DescriptionRu2;
                    advantageOfPurchasingRu.Title3 = conditionOfPurchasingUpdateViewModel.TitleRu3;
                    advantageOfPurchasingRu.Description3 = conditionOfPurchasingUpdateViewModel.DescriptionRu3;

                    _db.ConditionsOfPurchasings.Update(advantageOfPurchasingRu);
                }

                await _db.SaveChangesAsync();

                _toastNotification.AddSuccessToastMessage("Dəyişiklik edildi!", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat!"
                });

                return RedirectToAction("index", "home");
            }

            return View(conditionOfPurchasingUpdateViewModel);
        }
    }
}
