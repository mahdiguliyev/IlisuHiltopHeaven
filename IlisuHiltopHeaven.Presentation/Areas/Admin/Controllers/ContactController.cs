using IlisuHiltopHeaven.Data.Concrete.EntityFramework.Context;
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
            var contacts = await _db.Contacts.ToListAsync();
            if (contacts == null)
            {
                return NotFound();
            }
            return View(contacts);
        }
        [HttpGet]
        public async Task<IActionResult> Answer(int contactId)
        {
            var contact = await _db.Contacts.SingleOrDefaultAsync(c => c.Id == contactId);
            if (contact != null)
            {
                contact.IsAnswerd = true;

                _db.Contacts.Update(contact);
                await _db.SaveChangesAsync();

                _toastNotification.AddSuccessToastMessage("Kontact məlumatı cavablandırıldı!", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat!"
                });

                return RedirectToAction("index", "contact");
            }

            _toastNotification.AddErrorToastMessage("Kontact məlumatı tapılmadı!", new ToastrOptions
            {
                Title = "Uğursuz Əməliyyat!"
            });

            return RedirectToAction("index", "contact");
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int contactId)
        {
            var contact = await _db.Contacts.SingleOrDefaultAsync(c => c.Id == contactId);
            if (contact != null)
            {
                return View(contact);
            }

            _toastNotification.AddErrorToastMessage("Kontact məlumatı tapılmadı!", new ToastrOptions
            {
                Title = "Uğursuz Əməliyyat!"
            });

            return RedirectToAction("index", "contact");
        }
    }
}
