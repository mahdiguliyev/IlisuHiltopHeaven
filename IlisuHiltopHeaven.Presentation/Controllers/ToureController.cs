using IlisuHiltopHeaven.Data.Concrete.EntityFramework.Context;
using IlisuHiltopHeaven.Presentation.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Presentation.Controllers
{
    public class ToureController : Controller
    {
        private readonly IlisuHiltopHeavenContext _db;

        public ToureController(IlisuHiltopHeavenContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var toures = await _db.Travels.Include(t => t.Language).ToListAsync();
            var offices = await _db.Offices.Include(o => o.Language).ToListAsync();
            var homePages = await _db.HomePages.Include(hp => hp.Language).Where(hp => hp.PageName == "toure").ToListAsync();
            var socialMedias = await _db.SocialMedias.FirstAsync();

            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = rqf.RequestCulture.Culture;

            ToureViewModel toureViewModel = new ToureViewModel();
            toureViewModel.SocialMedia = socialMedias;
            if (culture.Name.StartsWith("az"))
            {
                toureViewModel.Travels = toures.Where(t => t.Language.LanguageCode == "az").ToList();
                toureViewModel.Offices = offices.Where(o => o.Language.LanguageCode == "az").ToList();
                toureViewModel.HomePages = homePages.Where(o => o.Language.LanguageCode == "az").FirstOrDefault();
            }
            if (culture.Name.StartsWith("en"))
            {
                toureViewModel.Travels = toures.Where(t => t.Language.LanguageCode == "eng").ToList();
                toureViewModel.Offices = offices.Where(o => o.Language.LanguageCode == "eng").ToList();
                toureViewModel.HomePages = homePages.Where(o => o.Language.LanguageCode == "eng").FirstOrDefault();
            }
            if (culture.Name.StartsWith("ru"))
            {
                toureViewModel.Travels = toures.Where(t => t.Language.LanguageCode == "rus").ToList();
                toureViewModel.Offices = offices.Where(o => o.Language.LanguageCode == "rus").ToList();
                toureViewModel.HomePages = homePages.Where(o => o.Language.LanguageCode == "rus").FirstOrDefault();
            }

            return View(toureViewModel);
        }
    }
}
