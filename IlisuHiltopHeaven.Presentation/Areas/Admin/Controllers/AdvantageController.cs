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
    public class AdvantageController : Controller
    {
        private readonly IlisuHiltopHeavenContext _db;
        private readonly IToastNotification _toastNotification;
        public AdvantageController(IlisuHiltopHeavenContext db, IToastNotification toastNotification)
        {
            _db = db;
            _toastNotification = toastNotification;
        }
        public async Task<IActionResult> Index()
        {
            var advantages = await _db.Advantages.Include(a => a.Language).ToListAsync();
            var advantagesHiltop = await _db.AdvantageHilltops.Include(a => a.Language).ToListAsync();
            if (advantages == null || advantagesHiltop == null)
            {
                return NotFound();
            }
            return View(new AdvantageViewModel { Advantages = advantages, AdvantageHilltops = advantagesHiltop });
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var languages = await _db.Languages.ToListAsync();
            if (languages != null)
            {
                return View(new AdvantageAddViewModel { Languages = languages });
            }

            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AdvantageAddViewModel advantageAddViewModel)
        {
            if (ModelState.IsValid)
            {
                Advantage advantage = new Advantage
                {
                    Title = advantageAddViewModel.Title,
                    LanguageId = advantageAddViewModel.LanguageId
                };

                await _db.Advantages.AddAsync(advantage);
                await _db.SaveChangesAsync();

                _toastNotification.AddSuccessToastMessage("Əlavə edildi!", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat!"
                });

                return RedirectToAction("index", "advantage");
            }

            var languages = await _db.Languages.ToListAsync();
            advantageAddViewModel.Languages = languages;

            return View(advantageAddViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int advantageId)
        {
            var advantage = await _db.Advantages.Include(o => o.Language).SingleOrDefaultAsync(o => o.Id == advantageId);
            if (advantage != null)
            {
                var languages = await _db.Languages.ToListAsync();

                var advantageUpdateViewModel = new AdvantageUpdateViewModel()
                {
                    Id = advantage.Id,
                    Title = advantage.Title,
                    LanguageId = advantage.LanguageId,
                    Languages = languages
                };

                return View(advantageUpdateViewModel);
            }

            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AdvantageUpdateViewModel advantageUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                var advantage = await _db.Advantages.SingleOrDefaultAsync(o => o.Id == advantageUpdateViewModel.Id);

                advantage.Title = advantageUpdateViewModel.Title;
                advantage.LanguageId = advantageUpdateViewModel.LanguageId;

                _db.Advantages.Update(advantage);
                await _db.SaveChangesAsync();

                _toastNotification.AddSuccessToastMessage("Dəyişiklik edildi!", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat!"
                });

                return RedirectToAction("index", "advantage");
            }

            var languages = await _db.Languages.ToListAsync();
            advantageUpdateViewModel.Languages = languages;

            return View(advantageUpdateViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int advantageId)
        {
            var advantage = await _db.Advantages.Include(o => o.Language).SingleOrDefaultAsync(o => o.Id == advantageId);
            if (advantage != null)
            {
                return View(advantage);
            }

            return NotFound();
        }
        public async Task<IActionResult> Delete(Advantage advantage)
        {
            var result = await _db.Advantages.AnyAsync(s => s.Id == advantage.Id);
            if (result)
            {
                var advantageDB = await _db.Advantages.Where(s => s.Id == advantage.Id).FirstOrDefaultAsync();

                _db.Advantages.Remove(advantageDB);
                await _db.SaveChangesAsync();

                _toastNotification.AddSuccessToastMessage("Dəyişiklik edildi!", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat!"
                });

                return RedirectToAction("index", "advantage");
            }

            _toastNotification.AddErrorToastMessage("Silinmə zamanı xəta baş verdi!", new ToastrOptions
            {
                Title = "Uğursuz Əməliyyat!"
            });

            return RedirectToAction("index", "advantage");
        }


        [HttpGet]
        public async Task<IActionResult> AddHilltopAdvantage()
        {
            var languages = await _db.Languages.ToListAsync();
            if (languages != null)
            {
                return View(new AdvantageAddViewModel { Languages = languages });
            }

            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddHilltopAdvantage(AdvantageAddViewModel advantageAddViewModel)
        {
            if (ModelState.IsValid)
            {
                AdvantageHilltop advantageHiltop = new AdvantageHilltop
                {
                    Title = advantageAddViewModel.Title,
                    LanguageId = advantageAddViewModel.LanguageId
                };

                await _db.AdvantageHilltops.AddAsync(advantageHiltop);
                await _db.SaveChangesAsync();

                _toastNotification.AddSuccessToastMessage("Əlavə edildi!", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat!"
                });

                return RedirectToAction("index", "advantage");
            }

            var languages = await _db.Languages.ToListAsync();
            advantageAddViewModel.Languages = languages;

            return View(advantageAddViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateHilltopAdvantage(int advantageId)
        {
            var advantageHilltop = await _db.AdvantageHilltops.Include(o => o.Language).SingleOrDefaultAsync(o => o.Id == advantageId);
            if (advantageHilltop != null)
            {
                var languages = await _db.Languages.ToListAsync();

                var advantageUpdateViewModel = new AdvantageUpdateViewModel()
                {
                    Id = advantageHilltop.Id,
                    Title = advantageHilltop.Title,
                    LanguageId = advantageHilltop.LanguageId,
                    Languages = languages
                };

                return View(advantageUpdateViewModel);
            }

            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateHilltopAdvantage(AdvantageUpdateViewModel advantageUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                var advantageHilltop = await _db.AdvantageHilltops.SingleOrDefaultAsync(o => o.Id == advantageUpdateViewModel.Id);

                advantageHilltop.Title = advantageUpdateViewModel.Title;
                advantageHilltop.LanguageId = advantageUpdateViewModel.LanguageId;

                _db.AdvantageHilltops.Update(advantageHilltop);
                await _db.SaveChangesAsync();

                _toastNotification.AddSuccessToastMessage("Dəyişiklik edildi!", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat!"
                });

                return RedirectToAction("index", "advantage");
            }

            var languages = await _db.Languages.ToListAsync();
            advantageUpdateViewModel.Languages = languages;

            return View(advantageUpdateViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteHilltopAdvantage(int advantageId)
        {
            var advantageHilltop = await _db.AdvantageHilltops.Include(o => o.Language).SingleOrDefaultAsync(o => o.Id == advantageId);
            if (advantageHilltop != null)
            {
                return View(advantageHilltop);
            }

            return NotFound();
        }
        public async Task<IActionResult> DeleteHilltopAdvantage(AdvantageHilltop advantageHilltop)
        {
            var result = await _db.AdvantageHilltops.AnyAsync(s => s.Id == advantageHilltop.Id);
            if (result)
            {
                var advantageHilltopDB = await _db.AdvantageHilltops.Where(s => s.Id == advantageHilltop.Id).FirstOrDefaultAsync();

                _db.AdvantageHilltops.Remove(advantageHilltopDB);
                await _db.SaveChangesAsync();

                _toastNotification.AddSuccessToastMessage("Dəyişiklik edildi!", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat!"
                });

                return RedirectToAction("index", "advantage");
            }

            _toastNotification.AddErrorToastMessage("Silinmə zamanı xəta baş verdi!", new ToastrOptions
            {
                Title = "Uğursuz Əməliyyat!"
            });

            return RedirectToAction("index", "advantage");
        }
    }
}
