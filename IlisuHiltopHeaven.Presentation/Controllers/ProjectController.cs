using IlisuHiltopHeaven.Data.Concrete.EntityFramework.Context;
using IlisuHiltopHeaven.Entities.Concrete;
using IlisuHiltopHeaven.Presentation.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Presentation.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IlisuHiltopHeavenContext _db;
        public ProjectController(IlisuHiltopHeavenContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var projects = await _db.Projects.Include(p => p.Language).ToListAsync();
            var offices = await _db.Offices.Include(o => o.Language).ToListAsync();
            var homePages = await _db.HomePages.Include(hp => hp.Language).Where(hp => hp.PageName == "project").ToListAsync();
            var socialMedias = await _db.SocialMedias.FirstAsync();

            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = rqf.RequestCulture.Culture;


            ProjectViewModel projectViewModel = new ProjectViewModel();
            projectViewModel.SocialMedia = socialMedias;
            if (culture.Name.StartsWith("az"))
            {
                projectViewModel.Projects = projects.Where(p => p.Language.LanguageCode == "az").ToList();
                projectViewModel.Offices = offices.Where(o => o.Language.LanguageCode == "az").ToList();
                projectViewModel.HomePages = homePages.Where(o => o.Language.LanguageCode == "az").FirstOrDefault();
            }
            if (culture.Name.StartsWith("en"))
            {
                projectViewModel.Projects = projects.Where(p => p.Language.LanguageCode == "eng").ToList();
                projectViewModel.Offices = offices.Where(o => o.Language.LanguageCode == "eng").ToList();
                projectViewModel.HomePages = homePages.Where(o => o.Language.LanguageCode == "eng").FirstOrDefault();
            }
            if (culture.Name.StartsWith("ru"))
            {
                projectViewModel.Projects = projects.Where(p => p.Language.LanguageCode == "rus").ToList();
                projectViewModel.Offices = offices.Where(o => o.Language.LanguageCode == "rus").ToList();
                projectViewModel.HomePages = homePages.Where(o => o.Language.LanguageCode == "rus").FirstOrDefault();
            }

            return View(projectViewModel);
        }
    }
}
