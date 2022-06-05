using IlisuHiltopHeaven.Data.Concrete.EntityFramework.Context;
using IlisuHiltopHeaven.Entities.Concrete;
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
    public class OfficeController : Controller
    {
        private readonly IlisuHiltopHeavenContext _db;
        private readonly IToastNotification _toastNotification;

        public OfficeController(IlisuHiltopHeavenContext db, IToastNotification toastNotification)
        {
            _db = db;
            _toastNotification = toastNotification;
        }
        public async Task<IActionResult> Index()
        {
            var offices = await _db.Offices.Where(o => o.Language.LanguageCode == "az").Include(s => s.Language).ToListAsync();
            if (offices == null)
            {
                return NotFound();
            }
            return View(offices);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var languages = await _db.Languages.ToListAsync();
            if (languages != null)
            {
                return View(new OfficeAddViewModel { Languages = languages });
            }

            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(OfficeAddViewModel officeAddViewModel)
        {
            if (ModelState.IsValid)
            {
                Guid languageGroupId = Guid.NewGuid();
                string mapUrl = string.Empty;

                if (officeAddViewModel.MapUrl != null)
                {
                    mapUrl = officeAddViewModel.MapUrl;
                }

                if (!string.IsNullOrEmpty(officeAddViewModel.OfficeNameAz))
                {
                    Office officeAz = new Office
                    {
                        OfficeName = officeAddViewModel.OfficeNameAz,
                        Address = officeAddViewModel.AddressAz,
                        Number1 = officeAddViewModel.NumberAz1,
                        Number2 = officeAddViewModel.NumberAz2,
                        Number3 = officeAddViewModel.NumberAz3,
                        LanguageId = 1,
                        LanguageGroupId = languageGroupId,
                        Email = officeAddViewModel.EmailAz,
                        WorkDays = officeAddViewModel.WorkDaysAz,
                        WorkHours = officeAddViewModel.WorkHoursAz,
                        MapUrl = mapUrl
                    };

                    await _db.Offices.AddAsync(officeAz);
                }
                if (!string.IsNullOrEmpty(officeAddViewModel.OfficeNameEn))
                {
                    Office officeEn = new Office
                    {
                        OfficeName = officeAddViewModel.OfficeNameEn,
                        Address = officeAddViewModel.AddressEn,
                        Number1 = officeAddViewModel.NumberEn1,
                        Number2 = officeAddViewModel.NumberEn2,
                        Number3 = officeAddViewModel.NumberEn3,
                        LanguageId = 2,
                        LanguageGroupId = languageGroupId,
                        Email = officeAddViewModel.EmailEn,
                        WorkDays = officeAddViewModel.WorkDaysEn,
                        WorkHours = officeAddViewModel.WorkHoursEn,
                        MapUrl = mapUrl
                    };

                    await _db.Offices.AddAsync(officeEn);
                }
                if (!string.IsNullOrEmpty(officeAddViewModel.OfficeNameRu))
                {
                    Office officeRu = new Office
                    {
                        OfficeName = officeAddViewModel.OfficeNameRu,
                        Address = officeAddViewModel.AddressRu,
                        Number1 = officeAddViewModel.NumberRu1,
                        Number2 = officeAddViewModel.NumberRu2,
                        Number3 = officeAddViewModel.NumberRu3,
                        LanguageId = 3,
                        LanguageGroupId = languageGroupId,
                        Email = officeAddViewModel.EmailRu,
                        WorkDays = officeAddViewModel.WorkDaysRu,
                        WorkHours = officeAddViewModel.WorkHoursRu,
                        MapUrl = mapUrl
                    };

                    await _db.Offices.AddAsync(officeRu);
                }

                await _db.SaveChangesAsync();

                _toastNotification.AddSuccessToastMessage("Əlavə edildi!", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat!"
                });

                return RedirectToAction("index", "office");
            }

            return View(officeAddViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var offices = await _db.Offices.Where(o => o.LanguageGroupId == id).Include(o => o.Language).ToListAsync();
            if (offices.Count > 0)
            {
                var officeAz = offices.FirstOrDefault(hp => hp.Language.LanguageCode == "az");
                var officeEn = offices.FirstOrDefault(hp => hp.Language.LanguageCode == "eng");
                var officeRu = offices.FirstOrDefault(hp => hp.Language.LanguageCode == "rus");

                Guid languageGroupId = new Guid();
                string mapUrl = string.Empty;

                if (officeAz != null)
                {
                    languageGroupId = officeAz.LanguageGroupId;
                    mapUrl = officeAz.MapUrl;
                }
                else if (officeEn != null)
                {
                    languageGroupId = officeEn.LanguageGroupId;
                    mapUrl = officeEn.MapUrl;
                }
                
                else if (officeRu != null)
                {
                    languageGroupId = officeRu.LanguageGroupId;
                    mapUrl = officeRu.MapUrl;
                }

                OfficeUpdateViewModel officeUpdateViewModel = new OfficeUpdateViewModel()
                {
                    LanguageGroupId = languageGroupId,
                    MapUrl = mapUrl
                };

                if (officeAz != null)
                {
                    officeUpdateViewModel.OfficeNameAz = officeAz.OfficeName;
                    officeUpdateViewModel.AddressAz = officeAz.Address;
                    officeUpdateViewModel.NumberAz1 = officeAz.Number1;
                    officeUpdateViewModel.NumberAz2 = officeAz.Number2;
                    officeUpdateViewModel.NumberAz3 = officeAz.Number3;
                    officeUpdateViewModel.EmailAz = officeAz.Email;
                    officeUpdateViewModel.WorkDaysAz = officeAz.WorkDays;
                    officeUpdateViewModel.WorkHoursAz = officeAz.WorkHours;
                }
                if (officeEn != null)
                {
                    officeUpdateViewModel.OfficeNameEn = officeEn.OfficeName;
                    officeUpdateViewModel.AddressEn = officeEn.Address;
                    officeUpdateViewModel.NumberEn1 = officeEn.Number1;
                    officeUpdateViewModel.NumberEn2 = officeEn.Number2;
                    officeUpdateViewModel.NumberEn3 = officeEn.Number3;
                    officeUpdateViewModel.EmailEn = officeEn.Email;
                    officeUpdateViewModel.WorkDaysEn = officeEn.WorkDays;
                    officeUpdateViewModel.WorkHoursEn = officeEn.WorkHours;
                }
                if (officeRu != null)
                {
                    officeUpdateViewModel.OfficeNameRu = officeRu.OfficeName;
                    officeUpdateViewModel.AddressRu = officeRu.Address;
                    officeUpdateViewModel.NumberRu1 = officeRu.Number1;
                    officeUpdateViewModel.NumberRu2 = officeRu.Number2;
                    officeUpdateViewModel.NumberRu3 = officeRu.Number3;
                    officeUpdateViewModel.EmailRu = officeRu.Email;
                    officeUpdateViewModel.WorkDaysRu = officeRu.WorkDays;
                    officeUpdateViewModel.WorkHoursRu = officeRu.WorkHours;
                }

                return View(officeUpdateViewModel);
            }

            _toastNotification.AddErrorToastMessage("Məlumat tapılmadı!", new ToastrOptions
            {
                Title = "Uğursuz Əməliyyat!"
            });

            return RedirectToAction("index", "office");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(OfficeUpdateViewModel officeUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                if (officeUpdateViewModel.LanguageGroupId == null)
                    return NotFound();

                var offices = await _db.Offices.Where(o => o.LanguageGroupId == officeUpdateViewModel.LanguageGroupId).Include(o => o.Language).ToListAsync();

                if (offices.Count == 0)
                {
                    _toastNotification.AddErrorToastMessage("Məlumat tapılmadı!", new ToastrOptions
                    {
                        Title = "Uğursuz Əməliyyat!"
                    });

                    return RedirectToAction("index", "office");
                }

                var officeAz = offices.FirstOrDefault(hp => hp.Language.LanguageCode == "az");
                var officeEn = offices.FirstOrDefault(hp => hp.Language.LanguageCode == "eng");
                var officeRu = offices.FirstOrDefault(hp => hp.Language.LanguageCode == "rus");

                string mapUrl = string.Empty;
                if (officeAz != null)
                    mapUrl = officeAz.MapUrl;
                else if (officeEn != null)
                    mapUrl = officeEn.MapUrl;
                else if (officeRu != null)
                    mapUrl = officeRu.MapUrl;

                if (officeAz != null)
                {
                    officeAz.OfficeName = officeUpdateViewModel.OfficeNameAz;
                    officeAz.Address = officeUpdateViewModel.AddressAz;
                    officeAz.Number1 = officeUpdateViewModel.NumberAz1;
                    officeAz.Number2 = officeUpdateViewModel.NumberAz2;
                    officeAz.Number3 = officeUpdateViewModel.NumberAz3;
                    officeAz.Email = officeUpdateViewModel.EmailAz;
                    officeAz.WorkDays = officeUpdateViewModel.WorkDaysAz;
                    officeAz.WorkHours = officeUpdateViewModel.WorkHoursAz;
                    officeAz.MapUrl = officeUpdateViewModel.MapUrl;

                    _db.Offices.Update(officeAz);
                }
                if (officeEn != null)
                {
                    officeEn.OfficeName = officeUpdateViewModel.OfficeNameEn;
                    officeEn.Address = officeUpdateViewModel.AddressEn;
                    officeEn.Number1 = officeUpdateViewModel.NumberEn1;
                    officeEn.Number2 = officeUpdateViewModel.NumberEn2;
                    officeEn.Number3 = officeUpdateViewModel.NumberEn3;
                    officeEn.Email = officeUpdateViewModel.EmailEn;
                    officeEn.WorkDays = officeUpdateViewModel.WorkDaysEn;
                    officeEn.WorkHours = officeUpdateViewModel.WorkHoursEn;
                    officeEn.MapUrl = officeUpdateViewModel.MapUrl;

                    _db.Offices.Update(officeEn);
                }
                if (officeRu != null)
                {
                    officeRu.OfficeName = officeUpdateViewModel.OfficeNameRu;
                    officeRu.Address = officeUpdateViewModel.AddressRu;
                    officeRu.Number1 = officeUpdateViewModel.NumberRu1;
                    officeRu.Number2 = officeUpdateViewModel.NumberRu2;
                    officeRu.Number3 = officeUpdateViewModel.NumberRu3;
                    officeRu.Email = officeUpdateViewModel.EmailRu;
                    officeRu.WorkDays = officeUpdateViewModel.WorkDaysRu;
                    officeRu.WorkHours =  officeUpdateViewModel.WorkHoursRu;
                    officeRu.MapUrl = officeUpdateViewModel.MapUrl;

                    _db.Offices.Update(officeRu);
                }
                
                await _db.SaveChangesAsync();

                _toastNotification.AddSuccessToastMessage("Dəyişiklik edildi!", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat!"
                });

                return RedirectToAction("index", "office");
            }

            var languages = await _db.Languages.ToListAsync();
            officeUpdateViewModel.Languages = languages;

            return View(officeUpdateViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int officeId)
        {
            var office = await _db.Offices.Include(o => o.Language).SingleOrDefaultAsync(o => o.Id == officeId);
            if (office != null)
            {
                return View(office);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Office office)
        {
            var result = await _db.Offices.AnyAsync(s => s.Id == office.Id);
            var officeFromDb = await _db.Offices.FirstOrDefaultAsync(o => o.Id == office.Id);
            if (result)
            {
                var officesDB = await _db.Offices.Where(s => s.LanguageGroupId == officeFromDb.LanguageGroupId).ToListAsync();

                _db.Offices.RemoveRange(officesDB);

                await _db.SaveChangesAsync();

                _toastNotification.AddSuccessToastMessage("Ofis silindi!", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat!"
                });

                return RedirectToAction("index", "office");
            }

            _toastNotification.AddErrorToastMessage("Silinmə zamanı xəta baş verdi!", new ToastrOptions
            {
                Title = "Uğursuz Əməliyyat!"
            });

            return RedirectToAction("index", "office");
        }
        [HttpGet]
        public async Task<IActionResult> ChangedToMain(int officeId)
        {
            var office = await _db.Offices.SingleOrDefaultAsync(c => c.Id == officeId);
            if (office != null)
            {
                if (office.IsMain == false)
                {
                    office.IsMain = true;

                    _db.Offices.Update(office);
                    await _db.SaveChangesAsync();

                    _toastNotification.AddSuccessToastMessage("Ofis əsas ofis olaraq seçildi!", new ToastrOptions
                    {
                        Title = "Uğurlu Əməliyyat!"
                    });

                    return RedirectToAction("index", "office");
                }
                else
                {
                    office.IsMain = false;

                    _db.Offices.Update(office);
                    await _db.SaveChangesAsync();

                    _toastNotification.AddSuccessToastMessage("Ofis filial olaraq dəyişdirildi!", new ToastrOptions
                    {
                        Title = "Uğurlu Əməliyyat!"
                    });

                    return RedirectToAction("index", "office");
                }

            }

            _toastNotification.AddErrorToastMessage("Ofis məlumatı tapılmadı!", new ToastrOptions
            {
                Title = "Uğursuz Əməliyyat!"
            });

            return RedirectToAction("index", "contact");
        }
    }
}
