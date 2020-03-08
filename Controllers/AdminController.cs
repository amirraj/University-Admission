using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admission.Models;
namespace Admission.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            Varsity_Admission examEntity = new Varsity_Admission();
            var getYear = examEntity.Exams.ToList();
            SelectList list = new SelectList(getYear, "E_Id", "E_Year");
            ViewBag.year = list;
            return View();
        }
        public ActionResult SetExam()
        {
            return View();
        }

        public ActionResult AssignSetter()
        {
            return View();
        }
    }
}