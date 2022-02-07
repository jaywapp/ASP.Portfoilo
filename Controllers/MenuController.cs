using JaywappWorld.Service;
using JaywappWorld.Service.Loader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JaywappWorld.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult About()
        {
            var path = "";
            var about = AboutLoader.Load(path);

            ViewBag.IntroduceTitle = new Text("소개", "Introduce");
            ViewBag.EducationTitle = new Text("학력", "Education");
            ViewBag.ExperienceTitle = new Text("경력", "Work Experience");

            ViewBag.Introduce = about.Introduce;
            ViewBag.Educations = about.Education;
            ViewBag.WorkExperience = about.WorkExperience;

            return View();
        }

        public ActionResult Role()
        {
            return View();
        }

        public ActionResult Project()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}