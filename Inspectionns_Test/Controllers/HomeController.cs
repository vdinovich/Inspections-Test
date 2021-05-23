namespace Inspections_Test.Controllers
{
    using Inspections_Test.Models;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Linq;

    public class HomeController : Controller
    {
        MyContext db;
        static int count_form = 1;
        static bool success = false;
        IEnumerable<InspectType> types;
        IEnumerable<Home> homes;

        public HomeController()
        {
            db = new MyContext();

            types = db.InspectTypes.ToList();
            homes = db.Homes.ToList();
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (success) { ViewBag.Success = "The record was inserted successfuly!"; }
            int selectedNumber = -1;

            ViewBag.CountForm = count_form;

            object[] objs = new object[] { new SelectList(types, "Id", "Name"), new SelectList(homes, "Id", "Name"), new SelectList(db.NonCompleances, "Id", "Name") };
            ViewBag.List = objs;

            var _1stcombo = new SelectList(db.LTCHARegs, "Id", "Name", selectedNumber);        
            ViewBag._1st = _1stcombo;

            var _2ndcombo = new SelectList(db.Sections.Where(c => c.LTCHARegId == selectedNumber), "Id", "Name");
            ViewBag._2nd = _2ndcombo;

            var _3rtcombo = new SelectList(db.Subsections.Where(s => s.SectionId == selectedNumber), "Id", "Name");
            ViewBag._3rd = _3rtcombo;

            var _4thcombo = new SelectList(db.OtherOptions.Where(o => o.SubsectionId == selectedNumber), "Id", "Name");
            ViewBag._4th = _4thcombo;

            return View();
        }

        [HttpPost]
        public ActionResult Index(InspectionInfo model)
        {
            //var param = Request.Params;
            string btnName = Request.Params
                     .Cast<string>()
                     .Where(p => p.StartsWith("btn"))
                     .Select(p => p.Substring("btn".Length))
                     .First();

            if (btnName.Equals("-add"))
            {
                int selectedNumber = -1;
                object[] objs = new object[] { new SelectList(types, "Id", "Name"), new SelectList(homes, "Id", "Name"), new SelectList(db.NonCompleances, "Id", "Name") };
                ViewBag.List = objs;

                var _1stcombo = new SelectList(db.LTCHARegs, "Id", "Name", selectedNumber);
                ViewBag._1st = _1stcombo;

                var _2ndcombo = new SelectList(db.Sections.Where(c => c.LTCHARegId == selectedNumber), "Id", "Name");
                ViewBag._2nd = _2ndcombo;

                var _3rtcombo = new SelectList(db.Subsections.Where(s => s.SectionId == selectedNumber), "Id", "Name");
                ViewBag._3rd = _3rtcombo;

                var _4thcombo = new SelectList(db.OtherOptions.Where(o => o.SubsectionId == selectedNumber), "Id", "Name");
                ViewBag._4th = _4thcombo;

                count_form++;
                ViewBag.CountForm = count_form;

                return View();
            }
            else if (btnName.Equals("-submit"))
            {

                success = true;
                return RedirectToAction("../Home/Index");
            }
            return View();
        }


        [HttpGet]
        public ActionResult GetItem(int id)
        {
            return PartialView(db.Sections.Where(p => p.LTCHARegId == id).ToList());
        }

        [HttpGet]
        public ActionResult GetSub1(int id)
        {
            return PartialView(db.Subsections.Where(p => p.SectionId == id).ToList());
        }

        [HttpGet]
        public ActionResult GetSub2(int id)
        {
            return PartialView(db.OtherOptions.Where(p => p.SubsectionId == id).ToList());
        }
    }
}