using IlisuHiltopHeaven.Data.Concrete.EntityFramework.Context;
using IlisuHiltopHeaven.Entities.ComplexTypes;
using IlisuHiltopHeaven.Entities.Concrete;
using IlisuHiltopHeaven.Presentation.Areas.Admin.Models;
using IlisuHiltopHeaven.Presentation.Helpers.Abstract;
using IlisuHiltopHeaven.Services.Utilities;
using IlisuHiltopHeaven.Shared.Utilities.Results.Abstract;
using IlisuHiltopHeaven.Shared.Utilities.Results.ComplexTypes;
using IlisuHiltopHeaven.Shared.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Editor")]
    public class ServiceController : Controller
    {
        private readonly IlisuHiltopHeavenContext _db;
        private readonly IToastNotification _toastNotification;
        private readonly IImageHelper _imageHelper;
        private readonly IWebHostEnvironment _environment;
        private readonly string _wwwroot;

        public ServiceController(IlisuHiltopHeavenContext db, IToastNotification toastNotification, IImageHelper imageHelper, IWebHostEnvironment environment)
        {
            _db = db;
            _toastNotification = toastNotification;
            _imageHelper = imageHelper;
            _wwwroot = environment.WebRootPath;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _db.Services.Include(s => s.Language).ToListAsync();
            if (services == null)
            {
                return NotFound();
            }
            return View(services);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int serviceId)
        {
            var service = await _db.Services.Include(s => s.Language).Include(s => s.ServiceAdvantages).Include(s => s.ServiceHiltopAdvantages).SingleOrDefaultAsync(s => s.Id == serviceId);
            var advantages = await _db.Advantages.ToListAsync();
            var advantagesHiltop = await _db.AdvantageHilltops.ToListAsync();
            if (service != null)
            {
                var selectedAdvantages = service.ServiceAdvantages.Select(s => new Advantage()
                {
                    Id = s.Advantage.Id,
                    Title = s.Advantage.Title
                });
                var selectedHiltopAdvantages = service.ServiceHiltopAdvantages.Select(s => new AdvantageHilltop()
                {
                    Id = s.AdvantageHilltop.Id,
                    Title = s.AdvantageHilltop.Title
                });
                var selectList = new List<SelectListItem>();
                var selectHiltopList = new List<SelectListItem>();

                advantages.ForEach(i => selectList.Add(new SelectListItem(i.Title, i.Id.ToString(), selectedAdvantages.Select(a => a.Id).Contains(i.Id))));
                advantagesHiltop.ForEach(i => selectHiltopList.Add(new SelectListItem(i.Title, i.Id.ToString(), selectedHiltopAdvantages.Select(a => a.Id).Contains(i.Id))));

                var languages = await _db.Languages.ToListAsync();
                var serviceUpdateViewModel = new ServiceUpdateViewModel()
                {
                    Id = service.Id,
                    Title = service.Title,
                    Description = service.Description,
                    PercentageOwner = service.PercentageOwner,
                    PercentageIHH = service.PercentageIHH,
                    Image = service.Image,
                    LanguageId = service.Language.Id,
                    Languages = languages,
                    Advantages = selectList,
                    HiltopAdvantages = selectHiltopList
                };

                return View(serviceUpdateViewModel);
            }

            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ServiceUpdateViewModel serviceUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                var service = await _db.Services.Include(s => s.ServiceAdvantages).Include(s => s.ServiceHiltopAdvantages).SingleOrDefaultAsync(s => s.Id == serviceUpdateViewModel.Id);

                service.Title = serviceUpdateViewModel.Title;
                service.Description = serviceUpdateViewModel.Description;
                service.PercentageOwner = serviceUpdateViewModel.PercentageOwner;
                service.PercentageIHH = serviceUpdateViewModel.PercentageIHH;
                service.LanguageId = serviceUpdateViewModel.LanguageId;


                var selectedAdvantages = serviceUpdateViewModel.SelectedAdvantages;
                var selectedHiltopAdvantages = serviceUpdateViewModel.SelectedHiltopAdvantages;
                var existingAdvantages = service.ServiceAdvantages.Select(sa => sa.AdvantageId).ToList();
                var existingHiltopAdvantages = service.ServiceHiltopAdvantages.Select(sa => sa.AdvantageHiltopId).ToList();

                if (selectedAdvantages != null)
                {
                    var toAdd = selectedAdvantages.Except(existingAdvantages).ToList();
                    var toRemove = existingAdvantages.Except(selectedAdvantages).ToList();

                    service.ServiceAdvantages = service.ServiceAdvantages.Where(s => !toRemove.Contains(s.AdvantageId)).ToList();
                    foreach (var addAdvantage in toAdd)
                    {
                        service.ServiceAdvantages.Add(new ServiceAdvantage()
                        {
                            AdvantageId = addAdvantage,
                            ServiceId = service.Id
                        });
                    }
                }
                if (selectedHiltopAdvantages != null)
                {
                    var toAdd = selectedHiltopAdvantages.Except(existingHiltopAdvantages).ToList();
                    var toRemove = existingHiltopAdvantages.Except(selectedHiltopAdvantages).ToList();

                    service.ServiceHiltopAdvantages = service.ServiceHiltopAdvantages.Where(s => !toRemove.Contains(s.AdvantageHiltopId)).ToList();
                    foreach (var addAdvantage in toAdd)
                    {
                        service.ServiceHiltopAdvantages.Add(new ServiceHiltopAdvantage()
                        {
                            AdvantageHiltopId = addAdvantage,
                            ServiceId = service.Id
                        });
                    }
                }

                //_db.Services.Update(service);
                await _db.SaveChangesAsync();

                _toastNotification.AddSuccessToastMessage("Dəyişiklik edildi!", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat!"
                });

                return RedirectToAction("index", "service");
            }

            var languages = await _db.Languages.ToListAsync();
            var advantages = await _db.Advantages.ToListAsync();
            var selectList = new List<SelectListItem>();
            foreach (var advantage in advantages)
            {
                selectList.Add(new SelectListItem(advantage.Title, advantage.Id.ToString()));
            }
            serviceUpdateViewModel.Languages = languages;
            serviceUpdateViewModel.Advantages = selectList;

            return View(serviceUpdateViewModel);
        }
        public async Task<IActionResult> ActivateAndDeactivate(int serviceId)
        {
            var service = await _db.Services.Include(s => s.Language).SingleOrDefaultAsync(s => s.Id == serviceId);
            if (service != null)
            {
                if (service.IsActive == true)
                {
                    service.IsActive = false;
                    await _db.SaveChangesAsync();

                    _toastNotification.AddSuccessToastMessage("Xidmət silindi!", new ToastrOptions
                    {
                        Title = "Uğurlu Əməliyyat!"
                    });

                    return RedirectToAction("index", "service");
                }
                else
                {
                    service.IsActive = true;
                    await _db.SaveChangesAsync();

                    _toastNotification.AddSuccessToastMessage("Xidmət geri qaytarıldı!", new ToastrOptions
                    {
                        Title = "Uğurlu Əməliyyat!"
                    });

                    return RedirectToAction("index", "service");
                }
            }

            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteAdvantages(int serviceId)
        {
            var service = await _db.Services.Include(s => s.ServiceAdvantages).Include(s => s.ServiceHiltopAdvantages).SingleOrDefaultAsync(s => s.Id == serviceId);
            var serviceAdvantages = await _db.ServiceAdvantages.Where(sa => sa.ServiceId == service.Id).ToListAsync();
            var serviceHiltopAdvantages = await _db.ServiceHiltopAdvantages.Where(sa => sa.ServiceId == service.Id).ToListAsync();

            foreach (var serviceAdvantage in serviceAdvantages)
            {
                _db.ServiceAdvantages.Remove(serviceAdvantage);
            }
            foreach (var serviceHiltopAdvantage in serviceHiltopAdvantages)
            {
                _db.ServiceHiltopAdvantages.Remove(serviceHiltopAdvantage);
            }

            await _db.SaveChangesAsync();

            _toastNotification.AddSuccessToastMessage("Bütün avatanlar sıfırlandı!", new ToastrOptions
            {
                Title = "Uğurlu Əməliyyat!"
            });
            return RedirectToAction("index", "service");
        }
    }
    
}
